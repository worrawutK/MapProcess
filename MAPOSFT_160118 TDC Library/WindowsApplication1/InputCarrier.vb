Public Class InputCarrier
    Dim c_MaxValue As Integer
    Private c_QrCarrierNo As String
    Public Property QrCarrierNo() As String
        Get
            Return c_QrCarrierNo
        End Get
        Set(ByVal value As String)
            c_QrCarrierNo = value
        End Set
    End Property
    Sub New(maxValue As Integer, header As String, colorInput As Color)

        ' This call is required by the designer.
        InitializeComponent()
        c_MaxValue = maxValue
        ' Add any initialization after the InitializeComponent() call.
        lbDisplay.Text = header
        ProgressBar1.Maximum = maxValue
        Me.BackColor = colorInput
    End Sub
    Private Sub TextBoxQrCodeInput_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxQrCodeInput.KeyPress
        If ProgressBar1.Value < ProgressBar1.Maximum Then
            ProgressBar1.Value += 1
        End If
        If e.KeyChar = Chr(13) Then
            If TextBoxQrCodeInput.Text.Length = c_MaxValue Then
                c_QrCarrierNo = TextBoxQrCodeInput.Text
                Me.DialogResult = DialogResult.OK
            Else
                MessageBox.Show("กรุณาตรวจสอบ " & lbDisplay.Text & " (" & TextBoxQrCodeInput.Text & ")")
                TextBoxQrCodeInput.Text = ""
            End If
        End If
    End Sub

    Private Sub timer1_Tick(sender As Object, e As EventArgs) Handles timer1.Tick
        If labelTextScan.ForeColor = Color.Red Then
            labelTextScan.ForeColor = Color.Green
            panel1.BackColor = Color.Green
        Else
            labelTextScan.ForeColor = Color.Red
            panel1.BackColor = Color.Red
        End If
    End Sub

    Private Sub InputQrCarrierNo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxQrCodeInput.Focus()
    End Sub

    Private Sub PictureboxQrCodeInputCheck_Click(sender As Object, e As EventArgs) Handles PictureboxQrCodeInputCheck.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class