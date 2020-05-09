Imports System.Runtime.Serialization.Formatters.Soap                      'XML Format
'Imports Rohm.Apcs.Tdc
Imports MAP_Label.iLibraryService
Imports MessageDialog
Imports System.Reflection
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml

Module Module1
    Enum MAP
        ASE
        ROHM
    End Enum
    Friend Alarm As String = "STOP"
    Friend RingNumberAlot As Integer
    Friend RingNumberFlot As Integer
    Friend Parameter As New ParameterTC
    Friend MAPFormat As String
    Friend ReadOnly _ipServer = "172.16.0.100"                      'ZION Server
    Friend ReadOnly _ipDbxUser = "172.16.0.102"                     'DBX,APCS  Server
    Friend TempPath As String = "D:\SelCon MapLB\LOG\Temp\"
    Friend TempDataBasePath As String = "D:\SelCon MapLB\LOG\TempDataBase\"
    Friend SelPath As String = "D:\SelCon MapLB\"
    Friend TDCFilePath As String = Application.StartupPath & "\Modules\TDC\machine.exe"
    Friend Confg As New Setting
    Friend dt As Date = Now                                         'Search range of 1st inspect
    Friend dt1 As Date = dt.AddDays(-1)                           ' 1 mount
    Friend ReadOnly ProcessHeader As String = "MAP-"                  'TDC Header
    Friend Master As Boolean = False
    Friend NetVer As String = "Ver1.02_141226"
    ' Friend m_TdcService As TdcService
    Friend Sub WrXml(ByVal pathfile As String, ByVal TarObj As Object)
        'Dim xfile As String = SelPath & "Config.xml"
        Dim fs As New IO.FileStream(pathfile, IO.FileMode.Create)
        Dim bs As New SoapFormatter
        bs.Serialize(fs, TarObj)
        fs.Close()
    End Sub
    Friend Sub WriterXml(ByVal pathfile As String, ByVal TarObj As Object)
        Dim xsSubmit As XmlSerializer = New XmlSerializer(TarObj.GetType)
        Using sww As New StringWriter
            Using writer As StreamWriter = New StreamWriter(pathfile, False)
                xsSubmit.Serialize(writer, TarObj)
                Dim xxx = sww.ToString
            End Using
        End Using
    End Sub
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
    'Private m_Recipe As String
    Public m_LotData As LotData
    Public m_PathFileLotData As String = System.IO.Path.Combine(Application.StartupPath, "LotData.xml")
    Friend Function SetupLot(lotNo As String, mcNo As String, opNo As String, processName As String, layerNo As String) As Boolean
        Try
            Dim carrierInfo As CarrierInfo = m_iLibraryService.GetCarrierInfo(mcNo, lotNo, opNo)
            If carrierInfo.EnabledControlCarrier = CarrierInfo.CarrierStatus.Use AndAlso carrierInfo.InControlCarrier = CarrierInfo.CarrierStatus.Use Then
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
            'Dim result = m_iLibraryService.SetupLot(lotNo, mcNo, opNo, processName, layerNo)
            Dim setupParamiter As SetupLotSpecialParametersEventArgs = New SetupLotSpecialParametersEventArgs With {
                .LayerNoApcs = layerNo
            }
            Dim result = m_iLibraryService.SetupLotPhase2(lotNo, mcNo, opNo, processName, Licenser.Check, m_LotData.CarrierInfo,setupParamiter)
            Select Case result.IsPass
                Case SetupLotResult.Status.NotPass
                    SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Not Pass," & result.FunctionName & "," & result.Cause & "," & result.Type.ToString())
                    MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
                    Return False
                Case SetupLotResult.Status.Pass

                Case SetupLotResult.Status.Warning
                    MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
            End Select
            m_LotData = New LotData With {
                .LotNo = lotNo,
                .MachineNo = mcNo,
                .Recipe = result.Recipe,
                .CarrierInfo = carrierInfo,
                .OpNo = opNo
                }
            WriterXml(m_PathFileLotData, m_LotData)
            'm_Recipe = result.Recipe
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Pass")
            Return True
        Catch ex As Exception
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString())
            MessageBoxDialog.ShowMessageDialog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString(), "Exception")
            Return False
        End Try

    End Function

    Friend Function StartLot(lotNo As String, mcNo As String, opNo As String) As Boolean
        Try
            'Dim result = m_iLibraryService.StartLot(lotNo, mcNo, opNo, m_LotData.Recipe)
            Dim result = m_iLibraryService.StartLotPhase2(lotNo, mcNo, opNo, m_LotData.Recipe, m_LotData.CarrierInfo, Nothing)
            If Not result.IsPass Then
                SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Not Pass," & result.FunctionName & "," & result.Cause & "," & result.Type.ToString())
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

    Friend Function EndLot(lotNo As String, mcNo As String, opNo As String, good As Integer, ng As Integer) As Boolean
        Try
            'Dim result = m_iLibraryService.EndLot(lotNo, mcNo, opNo, good, ng)
            Dim result = m_iLibraryService.EndLotPhase2(lotNo, mcNo, opNo, good, ng, Licenser.Check, m_LotData.CarrierInfo, Nothing)
            If Not result.IsPass Then
                SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Not Pass," & result.FunctionName & "," & result.Cause & "," & result.Type.ToString())
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
    Friend Function MachineOnline(mcNo As String, state As MachineOnline) As Boolean
        Try
            Dim result = m_iLibraryService.MachineOnlineState(mcNo, state)
            If Not result.IsPass Then
                SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Not Pass," & result.FunctionName & "," & result.Cause & "," & result.Type.ToString())
                MessageBoxDialog.ShowMessageDialog(result.FunctionName, result.Cause, result.Type.ToString())
                Return False
            End If
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Pass")
            If state = iLibraryService.MachineOnline.Offline Then
                m_iLibraryService.Close()
            End If
            Return True
        Catch ex As Exception
            SaveLog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString())
            MessageBoxDialog.ShowMessageDialog(MethodInfo.GetCurrentMethod().ToString(), ex.Message.ToString(), "Exception")
            Return False
        End Try
    End Function
    Friend Function CancelLot(lotNo As String, mcNo As String, opNo As String) As Boolean
        Try
            Dim result = m_iLibraryService.Reinput(lotNo, mcNo, opNo, 0, 0, EndMode.AbnormalEndReset)
            If Not result.IsPass Then
                SaveLog(MethodInfo.GetCurrentMethod().ToString(), result.Type.ToString() & ">> Not Pass," & result.FunctionName & "," & result.Cause & "," & result.Type.ToString())
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
