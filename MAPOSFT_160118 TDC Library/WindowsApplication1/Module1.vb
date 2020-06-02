Imports System.Runtime.Serialization.Formatters.Soap                      'XML Format
'Imports Rohm.Apcs.Tdc
Imports MAP_OSFT.iLibraryService
Imports MessageDialog
Imports System.Reflection
Imports System.Xml.Serialization
Imports System.IO

Module Module1
    Friend Const _ipServer = "172.16.0.100"                      'ZION Server
    Friend Const _ipDbxUser = "172.16.0.102"                     'DBX,APCS  Server
    Friend Const TempPath As String = "D:\SelCon MapOSFT\LOG\Temp\"
    Friend Const TempDataBasePath As String = "D:\SelCon MapOSFT\LOG\TempDataBase\"
    Friend Const SelPath As String = "D:\SelCon MapOSFT\"
    Friend TDCFilePath As String = Application.StartupPath & "\Modules\TDC\machine.exe"
    Friend Const MapdataPath As String = "C:\NFD\"
    Friend Const MapZipDestin As String = SelPath & "MapZip\"
    Friend Confg As New Setting
    Friend dt As Date = Now                                         'Search range of 1st inspect
    Friend dt1 As Date = dt.AddDays(-1)                           ' 1 mounth
    Friend Const ProcessHeader As String = "MAP-"                  'TDC Header
    Friend Master As Boolean = False
    Friend Const NetVer As String = "2.00_151014"
    Friend LotInfos As List(Of Lotinfo) = New List(Of Lotinfo)
    'Friend m_TdcService As TdcService
    Friend m_iLibraryService As ServiceiLibraryClient = New ServiceiLibraryClient()
    Friend Sub WrXml(ByVal pathfile As String, ByVal TarObj As Object)
        'Dim xfile As String = SelPath & "Config.xml"
        Dim fs As New IO.FileStream(pathfile, IO.FileMode.Create)
        Dim bs As New SoapFormatter
        bs.Serialize(fs, TarObj)
        fs.Close()
    End Sub
    Friend Function RdXml(ByVal pathfile As String) As Object
        'Dim xfile As String = SelPath & "Config.xml"
        Dim TarObj As New Object
        If Dir(pathfile) <> "" Then
            Dim fs As New IO.FileStream(pathfile, IO.FileMode.Open)
            Dim bs As New SoapFormatter
            TarObj = bs.Deserialize(fs)
            fs.Close()
        End If
        Return TarObj
    End Function
    Friend m_Recipe As String
    Public m_LotData As LotData
    Public m_PathFileLotData As String = System.IO.Path.Combine(Application.StartupPath, "LotData.xml")
    Public m_PathFileLotInfos As String = System.IO.Path.Combine(Application.StartupPath, "LotInfos.xml")
    Friend Function SetupLot(lotNo As String, mcNo As String, opNo As String, process As String, layerNo As String, strCommand As String(), ByRef cmd As String) As Boolean
        Try

            Dim mcProgram As String = strCommand(8).Trim().ToUpper()
            Dim device As String = strCommand(6)
            'mcProgram AUTO(1),AUTO(2), OS ,OSFT
            'Check flow lot and mcProgram
            Dim flowLot As String
            Dim lotInfo As LotInformation = m_iLibraryService.GetLotInfo(lotNo, mcNo)
            If lotInfo Is Nothing OrElse lotInfo.LotType = LotInformation.LotTypeState.Apcs Then
                flowLot = GetFlowLot(lotNo).Replace(" ", "").ToUpper()
            Else
                flowLot = lotInfo.JobName
            End If
            If flowLot.Trim.ToUpper = "OS1" Then
                flowLot = "OS"
            End If
            Dim ftSetup As FTSetupData = GetFTSetup(mcNo)
            If (ftSetup Is Nothing) Then
                cmd = "Error," & "Setup Check Sheet not register"
                SaveLog(MethodInfo.GetCurrentMethod().ToString(), "CheckProgram" & ">> Not Pass" & "Setup Check Sheet not register")
                MessageBoxDialog.ShowMessageDialog("SetupLot(GetFTSetup)", " Error," & "เครื่อง :" & mcNo & " นี้ยังไม่ได้ทำการลงทะเบียนในระบบ Setup Check Sheet กรุราติดต่อหัวหน้างาน", "GetFTSetup")
                Return False
            End If

            Try
                SaveLog(MethodInfo.GetCurrentMethod().ToString(), "MachineProgram:" & mcProgram & ",LotFlow:" & flowLot & ":" & device & ",FTSetup:" & ftSetup.SetupFlow & ":" & ftSetup.Device)

            Catch ex As Exception
                SaveLog(MethodInfo.GetCurrentMethod().ToString(), "Lot:" & lotNo & ",mcNo:" & mcNo & ",opNo:" & opNo & ",process:" & process & ",layerNo:" & layerNo & ",cmd:" & cmd)
            End Try

            Select Case mcProgram.Replace(" ", "").ToUpper()
                Case "OSFT"
                    mcProgram = "OS+AUTO(1)"
                Case "AUTO1"
                    mcProgram = "AUTO(1)"
                Case "AUTO2"
                    mcProgram = "AUTO(2)"

            End Select
            If mcProgram <> flowLot Then
                cmd = "Error," & "Program not match (Machine:" & strCommand(8) & ",Lot:" & flowLot & "," & mcNo & "," & lotNo & ","
                SaveLog(MethodInfo.GetCurrentMethod().ToString(), "CheckProgram" & ">> Not Pass" & "Program not match (Machine:" & mcProgram & ",Lot:" & flowLot & "," & mcNo & "," & lotNo)
                MessageBoxDialog.ShowMessageDialog("SetupLot(CheckProgram)", " Error," & "โปรแกรมไม่ตรงกับ Lot " & vbCrLf & "(Machine:" & mcProgram & ",Lot:" & flowLot & "," & vbCrLf & mcNo & "," & lotNo, "")
                Return False
            End If


            'Check FT Setup
            Dim ftFlow As String = ""
            Select Case ftSetup.SetupFlow.Replace(" ", "").ToUpper()
                Case "O/S1"
                    ftFlow = "OS"
                Case "OSFT"
                    ftFlow = "OS+AUTO(1)"
                Case "AUTO1"
                    ftFlow = "AUTO(1)"
                Case "AUTO2"
                    ftFlow = "AUTO(2)"
            End Select
            If ftSetup.Device <> device Then ''OrElse ftFlow <> flowLot Then
                If ftFlow = "AUTO(1)" AndAlso flowLot = "OS+AUTO(1)" Then

                ElseIf ftFlow <> flowLot Then
                    cmd = "Error," & "Flow not match (MachineSetup:" & ftSetup.SetupFlow & "," & ftSetup.Device & ",Lot:" & flowLot & "," & mcNo & "," & lotNo & ","
                    SaveLog(MethodInfo.GetCurrentMethod().ToString(), "CheckFTSetupFlow" & ">> Not Pass" & "Flow not match (Machine:" & ftSetup.SetupFlow & "," & ftSetup.Device & ",Lot:" & flowLot & "," & mcNo & "," & lotNo)
                    MessageBoxDialog.ShowMessageDialog("SetupLot(CheckFTSetupFlow)", " Error," & "Flow การผลิตไม่ตรงกับที่ Setup ไว้" & vbCrLf & "(Machine:" & ftSetup.SetupFlow & "," & ftSetup.Device & ",Lot:" & flowLot & "," & device & "," & vbCrLf & mcNo & "," & lotNo, "")
                    Return False
                End If

            End If
            Dim carrierInfo As CarrierInfo = m_iLibraryService.GetCarrierInfo(mcNo, lotNo, opNo)
            If carrierInfo.InControlCarrier = CarrierInfo.CarrierStatus.Use And carrierInfo.EnabledControlCarrier = CarrierInfo.CarrierStatus.Use Then
                If carrierInfo.LoadCarrier = CarrierInfo.CarrierStatus.Use Then
                    Dim frm As InputCarrier = New InputCarrier(11, "Input load carrier No.", Color.SpringGreen)
                    If frm.ShowDialog() = DialogResult.OK Then
                        carrierInfo.LoadCarrierNo = frm.QrCarrierNo
                    Else
                        Return False
                    End If
                End If
                If carrierInfo.RegisterCarrier = CarrierInfo.CarrierStatus.Use Then
                    Dim frm As InputCarrier = New InputCarrier(11, "Input load carrier No. (Registration)", Color.SpringGreen)
                    If frm.ShowDialog() = DialogResult.OK Then
                        carrierInfo.RegisterCarrierNo = frm.QrCarrierNo
                    Else
                        Return False
                    End If
                End If
                If carrierInfo.TransferCarrier = CarrierInfo.CarrierStatus.Use Then
                    Dim frm As InputCarrier = New InputCarrier(11, "Input unload carrier No.", Color.OrangeRed)
                    If frm.ShowDialog() = DialogResult.OK Then
                        carrierInfo.TransferCarrierNo = frm.QrCarrierNo
                    Else
                        Return False
                    End If

                End If
            End If
            Dim setupParamiter As SetupLotSpecialParametersEventArgs = New SetupLotSpecialParametersEventArgs With {
                .LayerNoApcs = layerNo
            }
            'Dim result = m_iLibraryService.SetupLot(lotNo, mcNo, opNo, process, layerNo)
            Dim result = m_iLibraryService.SetupLotPhase2(lotNo, mcNo, opNo, process, Licenser.Check, m_LotData.CarrierInfo, setupParamiter)
            If result.IsPass = SetupLotResult.Status.NotPass Then
                cmd = "Error," & result.Type.ToString() & "," & mcNo & "," & lotNo & ","
                SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Not Pass")
                MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
                Return False
            ElseIf result.IsPass = SetupLotResult.Status.Warning Then
                MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
            End If
            'Select Case result.IsPass
            '    Case SetupLotResult.Status.NotPass

            '    Case SetupLotResult.Status.Warning
            '        MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
            'End Select
            m_LotData = New LotData With {
                .LotNo = lotNo,
                .MachineNo = mcNo,
                .Recipe = result.Recipe,
                .CarrierInfo = carrierInfo,
                .OpNo = opNo
                }
            WriterXml(m_PathFileLotData, m_LotData)
            m_Recipe = result.Recipe
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Pass")

            'Save program tester
            Dim lotinfoProgram As Lotinfo = New Lotinfo
            lotinfoProgram.MachineNo = strCommand(3) 'mcNo ipbc IPB-22
            lotinfoProgram.LotNo = lotNo
            lotinfoProgram.TesterProgram = strCommand(9)
            lotinfoProgram.OpNo = opNo
            lotinfoProgram.DateCreate = Now
            If (LotInfos Is Nothing) Then
                LotInfos = New List(Of Lotinfo)
            End If
            Dim lotData As Lotinfo = LotInfos.Where(Function(x) x.MachineNo = lotinfoProgram.MachineNo).FirstOrDefault
            If (lotData IsNot Nothing) Then
                LotInfos.Remove(lotData)
                LotInfos.Add(lotinfoProgram)
            Else
                LotInfos.Add(lotinfoProgram)
            End If
            Try
                WriterXml(m_PathFileLotInfos, LotInfos)
            Catch ex As Exception
                SaveLog(MethodInfo.GetCurrentMethod().ToString(), SelPath & "LotInfos.xml=>" & ex.Message.ToString())
            End Try

            Return True
        Catch ex As Exception
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString())
            Return False
        End Try

    End Function
    Friend Function ReadXml(Of T)(ByVal fileName As String) As T
        If Not File.Exists(fileName) Then
            Return Nothing
        End If

        Using fs As StreamReader = New StreamReader(fileName)
            Dim bs = New XmlSerializer(GetType(T))
            Dim data As T = CType(bs.Deserialize(fs), T)
            Return data
        End Using
    End Function
    Friend Sub WriterXml(ByVal pathfile As String, ByVal TarObj As Object, Optional append As Boolean = False)
        Dim xsSubmit As XmlSerializer = New XmlSerializer(TarObj.GetType)
        Using sww As New StringWriter
            Using writer As StreamWriter = New StreamWriter(pathfile, append)
                xsSubmit.Serialize(writer, TarObj)
            End Using
        End Using
    End Sub
    Private Function GetFlowLot(lotNo As String) As String
        Dim data As DataTable = New DataTable()
        Using cmd As New SqlClient.SqlCommand
            cmd.Connection = New SqlClient.SqlConnection("Data Source=172.16.0.102;Initial Catalog=APCSDB;Persist Security Info=True;User ID=system;Password=p@$$w0rd")
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT LAYER_TABLE.OPE_NAME AS Process, LOT1_DATA.PLAN_DAY AS Plan_Date, LOT2_DATA.REAL_START AS StartTime, LOT2_DATA.REAL_DAY AS EndTime, 
                                                          LOT2_DATA.MACHINE, LOT2_DATA.OPERATOR1 AS OpNo_In, LOT2_DATA.OPERATOR2 AS OpNo_Out, LOT2_DATA.GOOD_PIECES AS GoodPcs, 
                                                          LOT2_DATA.BAD_PIECES AS NgPcs,LOT2_TABLE.OPE_SEQ as current_process,LOT1_DATA.OPE_SEQ,LOT2_TABLE.STATUS1
                                                          FROM LOT1_DATA INNER JOIN
                                                          LAYER_TABLE ON LOT1_DATA.LAY_NO = LAYER_TABLE.LAY_NO LEFT OUTER JOIN
                                                          LOT2_DATA ON LOT1_DATA.LOT_NO = LOT2_DATA.LOT_NO AND LOT2_DATA.OPE_SEQ = LOT1_DATA.OPE_SEQ
					                                      inner join LOT2_TABLE on LOT2_TABLE.LOT_NO = LOT1_DATA.LOT_NO
                                                          WHERE (LOT1_DATA.LOT_NO = @LotNo) AND (LOT1_DATA.N_OPE_SEQ <> 0) and LOT2_TABLE.OPE_SEQ = LOT1_DATA.OPE_SEQ"
            cmd.Parameters.Add("@LotNo", SqlDbType.VarChar).Value = lotNo
            cmd.Connection.Open()
            Using rd = cmd.ExecuteReader()
                If rd.HasRows Then
                    data.Load(rd)
                End If
            End Using

        End Using
        For Each row As DataRow In data.Rows
            Return row("Process").ToString()
        Next
        Return ""
    End Function
    Private Function GetFTSetup(mcNo As String) As FTSetupData
        Dim data As DataTable = New DataTable()
        Using cmd As New SqlClient.SqlCommand
            cmd.Connection = New SqlClient.SqlConnection("Data Source=172.16.0.102;Initial Catalog=DBx;Persist Security Info=True;User ID=system;Password=p@$$w0rd")
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT [MCNo],[LotNo],[PackageName],[DeviceName],[ProgramName],[TestFlow],[SetupConfirmDate]" &
                              " FROM [DBx].[dbo].[FTSetupReport]" &
                              " where MCNo = @mcNo"
            cmd.Parameters.Add("@mcNo", SqlDbType.VarChar).Value = mcNo
            cmd.Connection.Open()
            Using rd = cmd.ExecuteReader()
                If rd.HasRows Then
                    data.Load(rd)
                End If
            End Using
        End Using
        For Each row As DataRow In data.Rows
            Dim ftSetup As FTSetupData = New FTSetupData()
            ftSetup.Device = row("DeviceName").ToString()
            ftSetup.Package = row("PackageName").ToString()
            ftSetup.McNo = mcNo
            ftSetup.SetupFlow = row("TestFlow").ToString()
            Return ftSetup
        Next
        Return Nothing
    End Function
    Friend Function StartLot(lotNo As String, mcNo As String, opNo As String, recipe As String) As Boolean
        Try
            'Dim result = m_iLibraryService.StartLot(lotNo, mcNo, opNo, recipe)
            Dim result = m_iLibraryService.StartLotPhase2(lotNo, mcNo, opNo, m_LotData.Recipe, m_LotData.CarrierInfo, Nothing)
            If Not result.IsPass Then
                SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Not Pass")
                MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
                Return False
            End If
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Pass")
            Return True
        Catch ex As Exception
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString())
            Return False
        End Try

    End Function
    Friend Function EndLot(lotNo As String, mcNo As String, opNo As String, good As Integer, ng As Integer) As Boolean
        Try
            'Dim result = m_iLibraryService.EndLot(lotNo, mcNo, opNo, good, ng)
            Dim result = m_iLibraryService.EndLotPhase2(lotNo, mcNo, opNo, good, ng, Licenser.Check, m_LotData.CarrierInfo, Nothing)
            If Not result.IsPass Then
                SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Not Pass")
                MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
                Return False
            End If
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Pass")
            Return True
        Catch ex As Exception
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString())
            Return False
        End Try

    End Function
    Friend Function FinalLot(lotNo As String, mcNo As String, opNo As String) As Boolean
        Try
            'Dim result = m_iLibraryService.EndLot(lotNo, mcNo, opNo, good, ng)
            Dim result = m_iLibraryService.UpdateFinalinspection(lotNo, opNo, Judge.OK, mcNo)
            If Not result.IsPass Then
                SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Not Pass")
                ' MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
                Return False
            End If
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Pass")
            Return True
        Catch ex As Exception
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString())
            Return False
        End Try

    End Function
    Friend Function RetestLot(lotNo As String, mcNo As String, opNo As String) As Boolean
        Try
            Dim result = m_iLibraryService.Reinput(lotNo, mcNo, opNo, 0, 0, EndMode.AbnormalEndReset)
            If Not result.IsPass Then
                SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Not Pass")
                MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
                Return False
            End If
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Pass")
            Return True
        Catch ex As Exception
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString())
            Return False
        End Try

    End Function
    Friend Function MachineOnline(mcNo As String, state As MachineOnline) As Boolean
        Try
            Dim result = m_iLibraryService.MachineOnlineState(mcNo, state)
            If Not result.IsPass Then
                MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
                Return False
            End If
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Pass")
            Return True
        Catch ex As Exception
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString())
            MessageBoxDialog.ShowMessageDialog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString(), "Exception")
            Return False
        End Try
    End Function
    Public Sub SaveLog(functionName As String, ByVal txt As String)
        Dim file_Log As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath & "\Log.txt", True)

        file_Log.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss") & ">> " & functionName & " >> " & txt)
        file_Log.Close()
    End Sub

End Module
