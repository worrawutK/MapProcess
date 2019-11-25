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
    Private Sub lbClose_Click(sender As Object, e As EventArgs) Handles lbClose.Click
        Me.Close()
    End Sub

    Private Sub frmInputCarrierLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxCarrierInput.Focus()
        TextBoxCarrierInput.Select()
        lbClose.Parent = PictureBox1
    End Sub

    Private Sub TextBoxCarrierInput_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxCarrierInput.KeyPress
        If TextBoxCarrierInput.TextLength * 5 <= 100 Then
            ProgressBar1.Value = (TextBoxCarrierInput.TextLength) * 5
        Else
            ProgressBar1.Value = 100
        End If

        If e.KeyChar = vbCr Then
            TextBoxCarrierInput.Text = TextBoxCarrierInput.Text.ToUpper()
            If TextBoxCarrierInput.Text.Length = 11 Then
                c_CarrierLoad = TextBoxCarrierInput.Text
                TextBoxCarrierInput.Text = ""
                Me.Close()
            Else
                MsgBox("รูปของ Carrier ไม่ถูกต้อง")
                TextBoxCarrierInput.Text = ""
                TextBoxCarrierInput.Select()
            End If
        End If
    End Sub
End Class