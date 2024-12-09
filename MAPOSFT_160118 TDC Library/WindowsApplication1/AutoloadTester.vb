Imports System.IO
Imports MAP_OSFT.FTService

Public Class AutoloadTester
    Public Function LoadProgramTester(testerQrCode As String, testerNo As String, testerProgram As String, opNo As String, mcNo As String) As Resultbase
        Dim result As New Resultbase
        result.IsPass = True
        Dim mailBox As String = GetMailBox(testerQrCode, testerNo)
        Dim cmd As String = testerNo + "," + testerProgram + "," + opNo

        WriteTextOverwriteFile(Path.Combine(mailBox, "loadinf.txt"), cmd)
        WriteTextOverwriteFile(Path.Combine(mailBox, "selfcon.txt"), mcNo)

        Return result
    End Function

    Public Function GetMailBox(testerQrCode As String, testerNo As String) As String
        Dim proxy As New SettingServiceSoapClient()
        Return proxy.GetTesterMailBoxPathWithPrefix(testerQrCode, testerNo)
    End Function

    'Private void WriteTextOverwriteFile(String fileName, String text)
    '    {
    '        Using (StreamWriter sw = New StreamWriter(fileName, false))
    '        {
    '            sw.WriteLine(text);
    '        }
    '    }
    Private Sub WriteTextOverwriteFile(fileName As String, text As String)
        Using sw As New StreamWriter(fileName, False)
            sw.WriteLine(text)
        End Using
    End Sub
End Class
