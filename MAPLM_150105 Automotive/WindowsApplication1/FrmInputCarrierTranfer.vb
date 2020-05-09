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
        lbClose.Parent = PictureBox1
    End Sub
    Sub New(frm As String)

        ' This call is required by the designer.
        InitializeComponent()
        If frm = "tranfer" Then
            PictureBox1.Image = Global.MAP_LM.My.Resources.Resources.TranGIF
        ElseIf frm = "unload" Then
            PictureBox1.Image = Global.MAP_LM.My.Resources.Resources.UnloadGIF
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub TextBoxCarrierTranfer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxCarrierTranfer.KeyPress

        If TextBoxCarrierTranfer.TextLength * 5 <= 100 Then
            ProgressBar1.Value = (TextBoxCarrierTranfer.TextLength) * 5
        Else
            ProgressBar1.Value = 100
        End If
        If e.KeyChar = vbCr Then
            TextBoxCarrierTranfer.Text = TextBoxCarrierTranfer.Text.ToUpper()
            If TextBoxCarrierTranfer.Text.Length = 11 Then
                c_CarrierTranfer = TextBoxCarrierTranfer.Text
                TextBoxCarrierTranfer.Text = ""
                Me.DialogResult = DialogResult.OK
            Else
                MsgBox("รูปของ Carrier ไม่ถูกต้อง")
                TextBoxCarrierTranfer.Text = ""
                TextBoxCarrierTranfer.Select()
            End If
        End If
    End Sub

    Private Sub lbClose_Click(sender As Object, e As EventArgs) Handles lbClose.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class