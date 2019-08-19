Imports System.Runtime.Serialization.Formatters.Soap                      'XML Format
Imports System.Reflection
Imports MAP_Dicer.iLibraryService
Imports MessageDialog
Module Module1
    Friend ReadOnly _ipServer = "172.16.0.100"                      'ZION Server
    Friend ReadOnly _ipDbxUser = "172.16.0.102"                     'DBX,APCS  Server
    Friend TempPath As String = "D:\SelCon MapDicer\LOG\Temp\"
    Friend TempDataBasePath As String = "D:\SelCon MapDicer\LOG\TempDataBase\"
    Friend SelPath As String = "D:\SelCon MapDicer\"
    Friend TDCFilePath As String = Application.StartupPath & "\Modules\TDC\machine.exe"
    Friend Confg As New Setting
    Friend dt As Date = Now                                         'Search range of 1st inspect
    Friend dt1 As Date = dt.AddDays(-1)                           ' 1 mount
    Friend ReadOnly ProcessHeader As String = "MAP-"                  'TDC Header
    Friend Master As Boolean = False
    Friend NetVer As String = "1.01_151125"


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
    Private m_iLibraryService As ServiceiLibraryClient = New ServiceiLibraryClient()
    Private m_Recipe As String
    Friend Function SetupLot(lotNo As String, mcNo As String, opNo As String, processName As String, layerNo As String) As Boolean
        Try
            Dim result = m_iLibraryService.SetupLot(lotNo, mcNo, opNo, processName, layerNo)
            Select Case result.IsPass
                Case SetupLotResult.Status.NotPass
                    MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
                    Return False
                Case SetupLotResult.Status.Pass

                Case SetupLotResult.Status.Warning
                    MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
            End Select
            m_Recipe = result.Recipe
            Return True
        Catch ex As Exception
            MessageBoxDialog.ShowMessageDialog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString(), "Exception")
            Return False
        End Try

    End Function

    Friend Function StartLot(lotNo As String, mcNo As String, opNo As String) As Boolean
        Try
            Dim result = m_iLibraryService.StartLot(lotNo, mcNo, opNo, m_Recipe)
            If Not result.IsPass Then
                MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
                Return False
            End If
            Return True
        Catch ex As Exception
            MessageBoxDialog.ShowMessageDialog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString(), "Exception")
            Return False
        End Try

    End Function

    Friend Function EndLot(lotNo As String, mcNo As String, opNo As String, good As Integer, ng As Integer) As Boolean
        Try
            Dim result = m_iLibraryService.EndLot(lotNo, mcNo, opNo, good, ng)
            If Not result.IsPass Then
                MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
                Return False
            End If
            Return True
        Catch ex As Exception
            MessageBoxDialog.ShowMessageDialog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString(), "Exception")
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
            Return True
        Catch ex As Exception
            MessageBoxDialog.ShowMessageDialog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString(), "Exception")
            Return False
        End Try
    End Function
    Friend Function CancelLot(lotNo As String, mcNo As String, opNo As String) As Boolean
        Try
            Dim result = m_iLibraryService.Reinput(lotNo, mcNo, opNo, 0, 0, EndMode.AbnormalEndReset)
            If Not result.IsPass Then
                MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
                Return False
            End If
            Return True
        Catch ex As Exception
            MessageBoxDialog.ShowMessageDialog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString(), "Exception")
            Return False
        End Try
    End Function
End Module
