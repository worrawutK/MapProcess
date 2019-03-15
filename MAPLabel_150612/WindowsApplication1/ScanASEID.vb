Public Class ScanASEID
    Friend TargetText As TextBox
    Friend AssyLot As String
    Friend ringList As New Dictionary(Of String, String)
    Friend Message As String
    Private Sub ScanASEID_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbAssyLotNo.Text = AssyLot
        RingID.Text = AssyLot & "01"

        TextBox1.Focus()
        QRCode.BackColor = Color.LawnGreen
        RingID.BackColor = Color.YellowGreen
        btRegister.Enabled = False
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = vbCr Then
            If TextBox1.Text.Length = 12 Then
                StripID01.Text = TextBox1.Text
                StripID01.BackColor = Color.YellowGreen
                QRCode.BackColor = Color.Silver
                btRegister.BackColor = Color.LawnGreen
                btRegister.Enabled = True
                Button1.Enabled = True


            End If
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btRegister.Click
        If StripID01.Text.Length = 12 Then
            Message = "SD," & AssyLot & ",01,01," & StripID01.Text & ",  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                "
            'If Not ringList.ContainsKey(StripID.Text.Trim.ToUpper) Then

            '    'SD,1234F1111V,01,01,276-00266-02    ,02,276-00266-01    ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                
            '    ' ringList.Add(StripID.Text.Trim.ToUpper, RingID.Text.Trim.ToUpper) 'ASE,LOT,RingID
            '    'ringList.add(Key,txt)
            'End If
            Me.DialogResult = DialogResult.OK
        End If
        TextBox1.Focus()
    End Sub

    Private Sub QRCode_Click(sender As Object, e As EventArgs) Handles QRCode.Click
        TextBox1.Focus()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Focus()
        StripID01.Text = ""
        StripID01.BackColor = Color.Silver
        QRCode.BackColor = Color.LawnGreen
        RingID.BackColor = Color.YellowGreen
        btRegister.Enabled = False
        Button1.Enabled = False
    End Sub
End Class