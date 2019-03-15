Imports System.Windows.Forms

Public Class PassWord
    Dim KYB As KeyBoard
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Close()
        KYB.Close()
    End Sub

    Private _Level As String
    Public Property Level() As String
        Get
            Dim PassWordKey As String = ""
            Select Case _Level
                Case "OPERATOR"
                    PassWordKey = ""
                Case "ENGINEER"
                    PassWordKey = Format(Now, "MMyydd")
                Case "ADMIN"
                    PassWordKey = "PE1ED"
                Case "MAP"
                    PassWordKey = "MAP"
                Case Else
                    PassWordKey = ""
            End Select
            If Not TextBox1.Text.ToUpper = PassWordKey Then
                _Level = "OPERATOR"
            End If
            TextBox1.Text = ""
            Return _Level
        End Get
        Set(ByVal value As String)
            _Level = value
        End Set
    End Property

   
    Private Sub PassWord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KYB = New KeyBoard
        KYB.TargetText = TextBox1
        KYB.Show()
        KYB.TopMost = True
        KYB.NumPad = False
        Me.Text = "INPUT " & _Level & " PASS WORD"
    End Sub

    Private Sub PassWord_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles OK_Button.Paint
        Dim F As New Font("ARIAL", 9, FontStyle.Regular)
        Dim sbrush As New SolidBrush(Color.Black)
        Dim g As Graphics = Me.CreateGraphics()
        g.DrawString("Pass Word Keys :", F, sbrush, TextBox1.Left - 110, TextBox1.Top + TextBox1.Height / 4)
    End Sub
End Class
