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
    End Sub

    Private Sub TextBoxCarrierLoad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxCarrierLoad.KeyPress
        If e.KeyChar = vbCr Then
            TextBoxCarrierLoad.Text = TextBoxCarrierLoad.Text.ToUpper()
            If TextBoxCarrierLoad.Text.Length = 11 Then
                c_CarrierLoad = TextBoxCarrierLoad.Text
                TextBoxCarrierLoad.Text = ""
                Me.Close()
            Else
                MsgBox("รูปของ Carrier ไม่ถูกต้อง")
                TextBoxCarrierLoad.Text = ""
                TextBoxCarrierLoad.Select()
            End If
        End If
    End Sub

    Private Sub LbClose_Click(sender As Object, e As EventArgs) Handles lbClose.Click
        Me.Close()
    End Sub
End Class