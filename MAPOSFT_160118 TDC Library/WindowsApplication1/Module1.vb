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
    Friend Function SetupLot(lotNo As String, mcNo As String, opNo As String, process As String, layerNo As String, ByRef cmd As String) As Boolean
        Try
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
    Public Sub SaveLog(functionName As String, ByVal txt As String)
        Dim file_Log As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath & "\Log.txt", True)

        file_Log.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss") & ">> " & functionName & " >> " & txt)
        file_Log.Close()
    End Sub

End Module
