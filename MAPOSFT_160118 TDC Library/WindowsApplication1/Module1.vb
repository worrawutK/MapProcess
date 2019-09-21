Imports System.Runtime.Serialization.Formatters.Soap                      'XML Format
'Imports Rohm.Apcs.Tdc
Imports MAP_OSFT.iLibraryService
Imports MessageDialog
Imports System.Reflection

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
    Friend Function SetupLot(lotNo As String, mcNo As String, opNo As String, process As String, layerNo As String, strCommand As String(), ByRef cmd As String) As Boolean
        Try

            Dim mcProgram As String = strCommand(8)
            Dim device As String = strCommand(6)
            'mcProgram AUTO(1),AUTO(2), OS ,OSFT
            'Check flow lot and mcProgram
            Dim flowLot As String = GetFlowLot(lotNo).Replace(" ", "").ToUpper()
            'Dim ftSetup As FTSetupData = GetFTSetup(mcNo)
            'SaveLog(MethodInfo.GetCurrentMethod().ToString(), "MachineProgram:" & mcProgram & ",LotFlow:" & flowLot & ":" & device & ",FTSetup:" & ftSetup.SetupFlow & ":" & ftSetup.Device)
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
                MessageBoxDialog.ShowMessageDialog("SetupLot(CheckProgram)", " Error," & "Program not match " & vbCrLf & "(Machine:" & mcProgram & ",Lot:" & flowLot & "," & vbCrLf & mcNo & "," & lotNo, "")
                Return False
            End If


            'Check FT Setup
            'Dim ftFlow As String = ""
            'Select Case ftSetup.SetupFlow.Replace(" ", "").ToUpper()
            '    Case "OSFT", "AUTO1"
            '        ftFlow = "AUTO(1)"
            '    Case "AUTO2"
            '        ftFlow = "AUTO(2)"

            'End Select
            'If ftSetup.Device <> device OrElse ftFlow <> flowLot Then
            '    cmd = "Error," & "Flow not match (MachineSetup:" & ftSetup.SetupFlow & "," & ftSetup.Device & ",Lot:" & flowLot & "," & mcNo & "," & lotNo & ","
            '    SaveLog(MethodInfo.GetCurrentMethod().ToString(), "CheckFTSetupFlow" & ">> Not Pass" & "Flow not match (Machine:" & ftSetup.SetupFlow & "," & ftSetup.Device & ",Lot:" & flowLot & "," & mcNo & "," & lotNo)
            '    MessageBoxDialog.ShowMessageDialog("SetupLot(CheckFTSetupFlow)", " Error," & "Flow not match " & vbCrLf & "(Machine:" & ftSetup.SetupFlow & "," & ftSetup.Device & ",Lot:" & flowLot & "," & vbCrLf & mcNo & "," & lotNo, "")
            '    Return False
            'End If

            Dim result = m_iLibraryService.SetupLot(lotNo, mcNo, opNo, process, layerNo)
            Select Case Not result.IsPass
                Case SetupLotResult.Status.NotPass
                    cmd = "Error," & result.Type.ToString() & "," & mcNo & "," & lotNo & ","
                    SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Not Pass")
                    MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
                    Return False
                Case SetupLotResult.Status.Warning
                    MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
            End Select
            m_Recipe = result.Recipe
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Pass")
            Return True
        Catch ex As Exception
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString())
            Return False
        End Try

    End Function
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
            Dim result = m_iLibraryService.StartLot(lotNo, mcNo, opNo, recipe)
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
            Dim result = m_iLibraryService.EndLot(lotNo, mcNo, opNo, good, ng)
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
