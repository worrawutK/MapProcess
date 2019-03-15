Public Class MsgShow
    Public txt As String
    Private Sub MsgShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = txt
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class