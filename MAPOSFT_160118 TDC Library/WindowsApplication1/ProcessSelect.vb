


Public Class ProcessSelect
    Dim bxName As String
    Dim processCon As String


    ''Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.Click, RadioButton2.Click, RadioButton3.Click, RadioButton4.Click

    ''    processCon = sender.text

    ''        tbxInput.Enabled = True
    ''        tbxInput.Select()
    ''        KeyBoardCall(tbxInput, False)
    ''        Me.Location = New Point(KYB.Left, KYB.Bottom)

    ''    Exit Sub


    ''End Sub
  




#Region "===  KeyBoard Control"
    Dim KYB As KeyBoard

    Private Sub KeyBoardCall(ByVal OBJ As TextBox, ByVal Nump As Boolean)
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
        KYB.NumPad = Nump                         'Numpad =True , Keyboard = False
        KYB.Show()
        AddHandler KYB.FormClosed, AddressOf KYB_Formclose

    End Sub
    Private Sub KYB_Formclose()
        'tbxCtrl unfocus

    End Sub

#End Region

    Private Sub tbxInput_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxInput.Validated
        If Not tbxInput.Text = "" Then
            bxName = tbxInput.Text
        End If
    End Sub

  
    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        ''Form1.lbProcess.Text = processCon
        frmMain.DBxDataSet.MAPOSFTData.Rows(0)("BoxName") = bxName

        Me.Close()
    End Sub
    Private Sub tbxInput_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxInput.Click, tbxInput.Enter
        KeyBoardCall(tbxInput, False)
        Me.Location = New Point(KYB.Left, KYB.Bottom)
    End Sub


    Private Sub ProcessSelect_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case frmMain.lbProcess.Text
            Case "OS"
                RadioButton1.Checked = True
            Case "AUTO1"
                RadioButton2.Checked = True
            Case "AUTO2"
                RadioButton3.Checked = True
            Case "OS+FT"
                RadioButton4.Checked = True
        End Select

    End Sub
End Class