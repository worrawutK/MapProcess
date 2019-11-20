Public Class FrmInputCarrierTranfer
    Private c_CarrierTranfer As String
    Public Property CarrierTranfer() As String
        Get
            Return c_CarrierTranfer
        End Get
        Set(ByVal value As String)
            c_CarrierTranfer = value
        End Set
    End Property
    Private Sub FrmInputCarrierTranfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxCarrierTranfer.Focus()
        TextBoxCarrierTranfer.Select()
    End Sub

    Private Sub TextBoxCarrierTranfer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxCarrierTranfer.KeyPress
        If e.KeyChar = vbCr Then
            TextBoxCarrierTranfer.Text = TextBoxCarrierTranfer.Text.ToUpper()
            If TextBoxCarrierTranfer.Text.Length = 11 Then
                c_CarrierTranfer = TextBoxCarrierTranfer.Text
                TextBoxCarrierTranfer.Text = ""
                Me.Close()
            Else
                MsgBox("รูปของ Carrier ไม่ถูกต้อง")
                TextBoxCarrierTranfer.Text = ""
                TextBoxCarrierTranfer.Select()
            End If
        End If
    End Sub
End Class