Public Class frmInputCarrierLoad
    Private c_CarrierLoad As String
    Public Property CarrierLoad() As String
        Get
            Return c_CarrierLoad
        End Get
        Set(ByVal value As String)
            c_CarrierLoad = value
        End Set
    End Property
    Private Sub FrmInputCarrierLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxCarrierLoad.Focus()
        TextBoxCarrierLoad.Select()
        lbClose.Parent = PictureBox1
    End Sub

    Private Sub TextBoxCarrierLoad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxCarrierLoad.KeyPress

        If TextBoxCarrierLoad.TextLength * 5 <= 100 Then
            ProgressBar1.Value = (TextBoxCarrierLoad.TextLength) * 5
        Else
            ProgressBar1.Value = 100
        End If
        If e.KeyChar = vbCr Then
            TextBoxCarrierLoad.Text = TextBoxCarrierLoad.Text.ToUpper()
            If TextBoxCarrierLoad.Text.Length = 11 Then
                c_CarrierLoad = TextBoxCarrierLoad.Text
                TextBoxCarrierLoad.Text = ""
                Me.DialogResult = DialogResult.OK
            Else
                MsgBox("รูปของ Carrier ไม่ถูกต้อง")
                TextBoxCarrierLoad.Text = ""
                TextBoxCarrierLoad.Select()
            End If
        End If
    End Sub

    Private Sub LbClose_Click(sender As Object, e As EventArgs) Handles lbClose.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class