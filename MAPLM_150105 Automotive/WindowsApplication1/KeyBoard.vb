Public Class KeyBoard
    Friend TargetText As TextBox
    Friend NumPad As Boolean
   

    
    Private Sub KeyBoard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If NumPad Then                                      'NumPad
            Me.Size = New Size(384, 304)
            Panel2.Hide()
            Me.Text = "NumPad"
        Else                                                'KeyBoard
            Dim i As Integer
            Dim j As Integer
            For i = 0 To 26
                Dim b1 As New BT
                If i = 26 Then
                    b1.Text = Chr(44)                        'Comma
                Else
                    b1.Text = Chr(65 + i)
                End If
             
                Panel2.Controls.Add(b1)
                j = i Mod 8
                b1.Left = 5 + (j * b1.Width)
                j = i \ 8
                b1.Top = 4 + (b1.Height * j)
                AddHandler b1.Click, AddressOf LetterClick
            Next


        End If
      
    End Sub
    Private Sub LetterClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TypeOf sender Is Button Then
            TargetText.Focus()
            My.Computer.Keyboard.SendKeys(sender.text)
        End If
    End Sub

    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        TargetText.Focus()
        My.Computer.Keyboard.SendKeys("{ENTER}")

    End Sub
    Private Sub btsLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btsLeft.Click
        TargetText.Focus()
        My.Computer.Keyboard.SendKeys("{LEFT}")
    End Sub

    Private Sub btnBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBS.Click
        TargetText.Focus()
        My.Computer.Keyboard.SendKeys("{BS}")
    End Sub

    Private Sub btnRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRight.Click
        TargetText.Focus()
        My.Computer.Keyboard.SendKeys("{RIGHT}")
    End Sub

    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn00.Click, btn000.Click _
    , btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        
        TargetText.Focus()
        My.Computer.Keyboard.SendKeys(sender.text)

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnEnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnt.Click
        TargetText.Focus()
        My.Computer.Keyboard.SendKeys("{ENTER}")
    End Sub
End Class
Public Class BT
    Inherits Button
    Public Sub New()
        MyBase.New()
        Me.Font = New Font("Tahoma", 8, FontStyle.Regular)
        Me.Size = New Size(60, 50)
        Me.BackColor = Color.White
    End Sub

End Class