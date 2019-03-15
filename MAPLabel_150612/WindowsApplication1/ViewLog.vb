Public Class ViewLog
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        TextBox1.Text = Nothing
    End Sub

    Private Sub ViewLog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        '   Form1.Log.Hide()
    End Sub
End Class