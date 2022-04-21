Imports System.Data.SqlClient

Public Class TestProgramAutoloadingDialog
    Private autoLoad As AutoloadTester
    Private c_TesterQrCode As String
    Private c_TesterNo As String
    Private c_TestProgram As String
    Private c_OpNo As String
    Private c_MachineNo As String
    Sub New(testerQrCode As String, testerNo As String, testerProgram As String, testerOpNo As String, machineNo As String)

        ' This call is required by the designer.
        InitializeComponent()
        c_TesterQrCode = testerQrCode
        c_TesterNo = testerNo
        c_TestProgram = testerProgram
        c_OpNo = testerOpNo
        c_MachineNo = machineNo

        ' Add any initialization after the InitializeComponent() call.
        autoLoad = New AutoloadTester
    End Sub

    Private Sub backgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        autoLoad.LoadProgramTester(c_TesterQrCode, c_TesterNo, c_TestProgram, c_OpNo, c_MachineNo)
    End Sub

    Private Sub TestProgramAutoloadingDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFTSetupRecord(c_MachineNo)
    End Sub
    Private Function GetFTSetupRecord(mcNo As String) As FTSetupRecord
        Dim ftSetup As New FTSetupRecord
        Using cmd As New SqlCommand
            cmd.Connection = New SqlConnection("Data Source=172.16.0.102;Initial Catalog=DBx;Persist Security Info=True;User ID=system;Password=p@$$w0rd")
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT        MCNo, LotNo, PackageName, DeviceName, ProgramName, TesterType, TestFlow, QRCodesocket1, QRCodesocket2, QRCodesocket3, QRCodesocket4, QRCodesocketChannel1, QRCodesocketChannel2, QRCodesocketChannel3, 
                         QRCodesocketChannel4, TesterNoA, TesterNoAQRcode, TesterNoB, TesterNoBQRcode, ChannelAFTB, ChannelAFTBQRcode, ChannelBFTB, ChannelBFTBQRcode, TestBoxA, TestBoxAQRcode, TestBoxB, TestBoxBQRcode, 
                         AdaptorA, AdaptorAQRcode, AdaptorB, AdaptorBQRcode, DutcardA, DutcardAQRcode, DutcardB, DutcardBQRcode, BridgecableA, BridgecableAQRcode, BridgecableB, BridgecableBQRcode, TypeChangePackage, SetupStartDate, 
                         SetupEndDate, BoxTesterConnection, OptionSetup, OptionConnection, OptionName1, OptionName2, OptionName3, OptionName4, OptionName5, OptionName6, OptionName7, OptionType1, OptionType1QRcode, OptionType2, 
                         OptionType2QRcode, OptionType3, OptionType3QRcode, OptionType4, OptionType4QRcode, OptionType5, OptionType5QRcode, OptionType6, OptionType6QRcode, OptionType7, OptionType7QRcode, OptionSetting1, 
                         OptionSetting2, OptionSetting3, OptionSetting4, OptionSetting5, OptionSetting6, OptionSetting7, QfpVacuumPad, QfpSocketSetup, QfpSocketDecision, QfpDecisionLeadPress, QfpTray, SopStopper, SopSocketDecision, 
                         SopDecisionLeadPress, ManualCheckTest, ManualCheckTE, ManualCheckRequestTE, ManualCheckRequestTEConfirm, PkgGood, PkgNG, PkgGoodJudgement, PkgNGJudgement, PkgNishikiCamara, 
                         PkgNishikiCamaraJudgement, PkqBantLead, PkqKakeHige, BgaSmallBall, BgaBentTape, Bge5S, SetupStatus, ConfirmedCheckSheetOp, ConfirmedCheckSheetSection, ConfirmedCheckSheetGL, ConfirmedShonoSection, 
                         ConfirmedShonoGL, ConfirmedShonoOp, StatusShonoOP, SetupConfirmDate
                            FROM            FTSetupReport
                            WHERE        (MCNo = @McNo)"
            cmd.Parameters.Add("@McNo", SqlDbType.VarChar).Value = mcNo
            cmd.Connection.Open()
            Dim data = cmd.ExecuteReader()
            Dim dataTable As New DataTable
            dataTable.Load(data)
            For Each dataRow As DataRow In dataTable.Rows
                ftSetup.MCNo = mcNo
                ftSetup.TesterChA = IIf(dataRow.IsNull("TesterNoA"), "", dataRow("TesterNoA").ToString())
                ftSetup.TesterChAQrCode = IIf(dataRow.IsNull("TesterNoAQRcode"), "", dataRow("TesterNoAQRcode").ToString())
                ftSetup.TesterChB = IIf(dataRow.IsNull("TesterNoB"), "", dataRow("TesterNoB").ToString())
                ftSetup.TesterChBQrCode = IIf(dataRow.IsNull("TesterNoBQRcode"), "", dataRow("TesterNoBQRcode").ToString())
                ftSetup.TesterType = IIf(dataRow.IsNull("TesterType"), "", dataRow("TesterType").ToString())
                ftSetup.TestFlow = IIf(dataRow.IsNull("TestFlow"), "", dataRow("TestFlow").ToString())
                ftSetup.ProgramName = IIf(dataRow.IsNull("ProgramName"), "", dataRow("ProgramName").ToString())
                ftSetup.Status = IIf(dataRow.IsNull("SetupStatus"), "", dataRow("SetupStatus").ToString())
                ftSetup.PackageName = IIf(dataRow.IsNull("PackageName"), "", dataRow("PackageName").ToString())
                ftSetup.FTDevice = IIf(dataRow.IsNull("DeviceName"), "", dataRow("DeviceName").ToString())
                ftSetup.SocketNumCh1 = IIf(dataRow.IsNull("QRCodesocket1"), "", dataRow("QRCodesocket1").ToString())
                ftSetup.SocketNumCh2 = IIf(dataRow.IsNull("QRCodesocket2"), "", dataRow("QRCodesocket2").ToString())
                ftSetup.SocketNumCh3 = IIf(dataRow.IsNull("QRCodesocket3"), "", dataRow("QRCodesocket3").ToString())
                ftSetup.SocketNumCh4 = IIf(dataRow.IsNull("QRCodesocket4"), "", dataRow("QRCodesocket4").ToString())
                ftSetup.BoxNamChA = IIf(dataRow.IsNull("TestBoxA"), "", dataRow("TestBoxA").ToString())
                ftSetup.BoxNamChB = IIf(dataRow.IsNull("TestBoxB"), "", dataRow("TestBoxB").ToString())
                ftSetup.FtbChA = IIf(dataRow.IsNull("ChannelAFTB"), "", dataRow("ChannelAFTB").ToString())
                ftSetup.FtbChB = IIf(dataRow.IsNull("ChannelBFTB"), "", dataRow("ChannelBFTB").ToString())
                ftSetup.StatusShokoOP = IIf(dataRow.IsNull("StatusShonoOP"), "", dataRow("StatusShonoOP").ToString())
                ftSetup.TimeStamp = DateTime.Now
                'dataRow.IsNull("TesterNoA")IIF(String.IsNullorEmpty(txtBookTitle.Text),objBook.DisplayName, txtBookTitle.Text)

            Next

        End Using
        Return ftSetup
    End Function
End Class