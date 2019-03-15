Public Class CHECK_ASE_LOT
    Public ASE_LOT As Boolean = False
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If TextBox1.Text.Length = 10 Then
                'CHECK ASE LOT NO.
                'if ...
                'MsgBox("No ASE Lot No.")
                'else
                'ASE_LOT = True
                'Parameter = Nothing
                'MAPFormat=Nothing

            End If
        End If
    End Sub
End Class