Imports System.Runtime.Serialization.Formatters.Soap                      'XML Format
Imports Rohm.Apcs.Tdc

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
