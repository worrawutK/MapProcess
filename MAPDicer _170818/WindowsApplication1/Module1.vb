Imports System.Runtime.Serialization.Formatters.Soap                      'XML Format
Imports Rohm.Apcs.Tdc

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
    Friend m_TdcService As TdcService

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
End Module
