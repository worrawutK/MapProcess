Public Class InputQty

    Private Sub btnConfirm_Click(sender As System.Object, e As System.EventArgs) Handles btnConfirm.Click

    End Sub

    Private Sub tbxInput_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles tbxInput.KeyDown

        If e.KeyCode Then

        End If
    End Sub

    Private Sub InputQty_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Process.Start("C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe")
        tbxInput.Focus()
    End Sub
End Class