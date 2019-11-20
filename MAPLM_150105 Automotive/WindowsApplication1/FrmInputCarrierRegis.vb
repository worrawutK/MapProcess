Public Class FrmInputCarrierRegis
    Private c_CarrierRegis As String
    Public Property CarrierRegis() As String
        Get
            Return c_CarrierRegis
        End Get
        Set(ByVal value As String)
            c_CarrierRegis = value
        End Set
    End Property
    Private Sub LbClose_Click(sender As Object, e As EventArgs) Handles lbClose.Click
        Me.Close()
    End Sub

    Private Sub FrmInputCarrierRegis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxCarrierRegis.Focus()
        TextBoxCarrierRegis.Select()
    End Sub

    Private Sub TextBoxCarrierRegis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxCarrierRegis.KeyPress
        If e.KeyChar = vbCr Then
            TextBoxCarrierRegis.Text = TextBoxCarrierRegis.Text.ToUpper()
            If TextBoxCarrierRegis.Text.Length = 11 Then
                c_CarrierRegis = TextBoxCarrierRegis.Text
                TextBoxCarrierRegis.Text = ""
                Me.Close()
            Else
                MsgBox("รูปของ Carrier ไม่ถูกต้อง")
                TextBoxCarrierRegis.Text = ""
                TextBoxCarrierRegis.Select()
            End If
        End If
    End Sub
End Class