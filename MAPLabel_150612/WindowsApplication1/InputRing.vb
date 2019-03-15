Public Class InputRing
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If CInt(tbxInput.Text) > 25 Or CInt(tbxInput.Text) < 1 Then
            MsgBox("จำนวน Ring อยู่ระหว่าง 1-25")
            KeyBoardCall(tbxInput)
            Exit Sub
        End If
        If Parameter.LotNo.ToUpper Like "*F*" Then
            RingNumberFlot = CInt(tbxInput.Text)
        Else
            RingNumberAlot = CInt(tbxInput.Text)
        End If
        Me.DialogResult = DialogResult.OK

    End Sub

    Private Sub InputRing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Parameter.LotNo.ToUpper Like "*F*" Then
            tbxInput.Text = RingNumberFlot.ToString
        Else
            tbxInput.Text = RingNumberAlot.ToString
        End If
        KeyBoardCall(tbxInput)
    End Sub
#Region "===  KeyBoard Control"
    Dim KYB As KeyBoard

    Private Sub KeyBoardCall(ByVal OBJ As TextBox)
        If KYB Is Nothing Then
            KYB = New KeyBoard
        ElseIf KYB.IsDisposed Then
            KYB = New KeyBoard
        End If
        KYB.TargetText = OBJ
        KYB.Owner = Me
        KYB.StartPosition = FormStartPosition.Manual
        Dim xsize As Rectangle = Screen.PrimaryScreen.Bounds
        KYB.Left = 10
        KYB.Top = 0
        KYB.TopMost = True
        KYB.NumPad = True                        'Numpad =True , Keyboard = False
        KYB.Show()
        AddHandler KYB.FormClosed, AddressOf KYB_Formclose

    End Sub
    Private Sub KYB_Formclose()
        'tbxCtrl unfocus

    End Sub

#End Region
End Class