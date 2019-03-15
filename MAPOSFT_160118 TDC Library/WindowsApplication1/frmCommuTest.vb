Imports System.Security.Permissions
Imports System.Security

Public Class Form3

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Check \\IPBC\DATA\Info.txt access is available"
        Dim ans As String
        ans = clsNfdMap.GetProberInfo(frmMain.Panel2.Controls(0).Text)
        If ans Like "Error*" Then
            MsgBox("ไม่สามารถเข้าถึง เครื่อง \\" & frmMain.Panel2.Controls(0).Text & "\DATA\Info.txt", MsgBoxStyle.Critical)
        Else
            MsgBox(ans)
        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If Not My.Computer.Network.Ping(frmMain.lbTestName.Text) Then            'Pink OK Exit
                MsgBox("Error :การเชื่อมต่อกับ Tester ล้มเหลวไม่สามารถดำเนินการต่อได้", MsgBoxStyle.Critical)
                Exit Sub
            Else
                MsgBox("OK")
            End If
        Catch ex As Exception
            MsgBox("Error : " & ex.ToString, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub Form3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not My.Computer.Network.IsAvailable Then
            MsgBox("Error : PC Nework point not Open", MsgBoxStyle.Critical)
            Me.Close()
            Exit Sub
        End If
        If Not My.Computer.Network.Ping(_ipDbxUser) Then            'Pink OK Exit
            MsgBox("Error :การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้", MsgBoxStyle.Critical)
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Not System.IO.Directory.Exists(MapdataPath & frmMain.lbMC.Text) Then
            MsgBox("ไม่มี Folder c:\nfd\" & frmMain.lbMC.Text & "กรุณาสร้าง  Folder", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim writePermission As FileIOPermission = New FileIOPermission(FileIOPermissionAccess.Write, "C:\NFD")
        If Not (SecurityManager.IsGranted(writePermission)) Then
            MsgBox(" ยังไม่ได้สิทธิ ใน การใช้งาน  C:\NFD ")
            Exit Sub
        End If

        'upload file...
        Try
            Dim clsStream As New System.IO.StreamWriter(MapdataPath & "testfile.txt")
            clsStream.Write(Format(Now, "yyyy/MM/dd HH:mm:ss"))
            clsStream.Close()
            clsStream.Dispose()
            Dim ans As String
            ans = clsNfdMap.deleteFile(MapdataPath & "testfile.txt")
            If ans Like "Error*" Then
                MsgBox(ans)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try


        MsgBox("OK กรูณาตรวสอบ ว่า C:\NFD เปิดสิทธิในการเขียนให้ User หรือยัง")

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ' Internet IE > OPITION > Proxy Server <NoCheck> 

        Try
            Dim mycom As String = "ftp://" & My.Computer.Name & "/" & frmMain.Panel2.Controls(0).Text & "/test.txt"
            Dim myuser As String = "Administrator"
            Dim mypassword As String = InputBox("Input administrator password")


            Dim clsRequest As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(mycom), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential(myuser, mypassword)
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            ' read in file...


            Dim bFile() As Byte = System.Text.Encoding.ASCII.GetBytes(Format(Now, "yyyy/MM/dd HH:mm:ss"))


            ' upload file...
            Dim clsStream As System.IO.Stream = clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()


            clsRequest = DirectCast(System.Net.WebRequest.Create(mycom), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential(myuser, mypassword)
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            clsRequest.GetResponse()

            MsgBox("OK")


            ''Form1.Close()
        Catch ex As Exception
            MsgBox("Error" & ex.ToString, MsgBoxStyle.Critical)



        End Try

    End Sub





    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Not TextBox1.Text.IndexOf(",") < 0 Then
            Dim proName As String
            proName = TextBox1.Text.Split(",")(7)
            TextBox1.Text = proName
        End If

        If TextBox1.Text = "" Then
            MsgBox("กรูณาใส่ TestProgram Name")
            Exit Sub
        End If
        If frmMain.lbMC.Text = frmMain.lbMC.Name Then
            MsgBox("กรูณาใส่ เลือก MC No.ก่อน")
            Exit Sub
        End If

        Dim ans As String
        ans = frmMain.TestProLoadAuto(frmMain.lbMC.Text, TextBox1.Text, "000000")     '(9)>Program Name , (7)> OPname

        If ans Like "Error*" Then
            MsgBox(ans)
            Exit Sub
        End If

        MsgBox("OK")
    End Sub
End Class