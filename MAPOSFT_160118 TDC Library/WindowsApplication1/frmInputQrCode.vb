'Imports Rohm.Apcs.Tdc
'Imports MAP_OSFT.RohmService


Public Class frmInputQrCode

    Dim lotNo As String
    'Dim assyDevice As String
    'Dim package As String
    Dim opNo As String
    Dim inputQty As String
    Dim proName As String
    Dim bxName As String
    Dim processCon As String


    Private Sub frmInputQrCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Location = New System.Drawing.Point(150, 300)
        LbPKG.Text = "Package "
        LbDevice.Text = "Device "
        LbLotNo.Text = "Lot No. "
        lbProName.Text = "Program Name."
        lbBxName.Text = "Box Name."
        lbprocess.Text = "Process"

        If lbCaption.Text = "Input QR Code" Then
            TbQRInput.Text = ""
            TbQRInput.Select()
            ProgressBar1.Maximum = 150
        ElseIf lbCaption.Text = "Input GL No." Then                                                                                                                                                           'Case Input Edit Or Magzine Edit
            TbQRInput.Text = ""
            TbQRInput.Select()

        Else
            'tbxInput.Enabled = True
            'tbxInput.Select()

        End If
        'If Form1.lbLotNo.Text = "" Then
        '    lbMag.Enabled = False
        'End If
        TbQRInput.Location = New Point(250, Me.ProgressBar1.Top)
        btnConfirm.Enabled = False
        Panel1.Enabled = False


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Maximum > TbQRInput.Text.Length Then
            ProgressBar1.Value = TbQRInput.Text.Length
        Else
            ProgressBar1.Value = ProgressBar1.Maximum
        End If

    End Sub

    Private Sub tbxInput_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxInput.Click, tbxInput.Enter
        If lbCaption.Text = "Process Condition" Then
            KeyBoardCall(tbxInput, False)
        Else
            KeyBoardCall(tbxInput, True)

        End If

    End Sub
    '
    ' Data input recieve after Cr key Check Case , "Input QR , Input OP No , Input  Qty  , -------------------------------
    ' Input Edit
    '
    '

    'Function LotRequestTDC(ByVal LotNo As String, ByVal rm As RunModeType, ByVal MCNo As String) As Boolean
    '    ' Dim mc As String = "MAP-" & MCNo
    '    Dim strMess As String = ""
    '    Dim res As TdcLotRequestResponse = m_TdcService.LotRequest(MCNo, LotNo, rm)

    '    If res.HasError Then

    '        Using svError As ApcsWebServiceSoapClient = New ApcsWebServiceSoapClient
    '            If svError.LotRptIgnoreError(MCNo, res.ErrorCode) = False Then
    '                Dim li As LotInfo = Nothing
    '                li = m_TdcService.GetLotInfo(LotNo, MCNo)
    '                Using dlg As TdcAlarmMessageForm = New TdcAlarmMessageForm(res.ErrorCode, res.ErrorMessage, LotNo, li)
    '                    dlg.ShowDialog()
    '                    Return False
    '                End Using
    '            End If
    '        End Using
    '        strMess = res.ErrorCode & " : " & res.ErrorMessage
    '        Return True
    '    Else
    '        strMess = "00 : Run Normal"
    '        Return True
    '    End If
    'End Function

    Private Sub TbQRInput_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TbQRInput.KeyPress, tbxInput.KeyPress

        If e.KeyChar = vbCr Then                                                                                                                        'CR Key Recieve
            TbQRInput.Text = TbQRInput.Text.ToUpper

            Select Case lbCaption.Text

                Case "Input QR Code"

'                    If TbQRInput.Text.Length = 252 Then
'                        '
'                        'TDC -------------------------------------------------------------------------------
'                        '   
'                        'TDC -------------------------------------------------------------------------------
'                        '   
'                        If My.Settings.RunOffline = False Then
'                            m_iLibraryService.SetupLot()
'                            If LotRequestTDC(TbQRInput.Text.Substring(30, 10), RunModeType.Normal, "MAP-" & frmMain.lbMC.Text) = False Then
'                                'TbQRInput.Text = ""
'                                ' TbQRInput.Select()
'                                GoTo FailTDC
'                            End If
'                        End If

'                        ' Save QR Code to transsaction table                                On Error GoTo ErrHander
'                        lotNo = TbQRInput.Text.Substring(30, 10)
'                        TransactionDataTableAdapter.Fill(DBxDataSet.TransactionData, lotNo)
'                        Dim trans As DBxDataSet.TransactionDataRow = DBxDataSet.TransactionData.Rows(0)

'                        '
'                        'QR OK Data Save -----------------------------------------------------------------------------------
'                        '

'                        LbPKG.Text = "Package             : " & trans.Package
'                        LbDevice.Text = "Device               : " & trans.Device
'                        LbLotNo.Text = "Lot No.               : " & lotNo


'                        '
'                        'Switch to OP No. input -------------------------------------------------------------------------------
'                        '
'                        lbCaption.Text = "Input OP No."
'                        lbCaption.ForeColor = Color.Blue
'                        TbQRInput.Text = ""
'                        TbQRInput.Select()
'                        ProgressBar1.Maximum = 3

'                        Exit Sub
'                    Else
'                        MsgBox("Please Input QR Code Size ''252''", 48, "QR Code Size ''" & TbQRInput.Text.Length & "''")
'FailTDC:
'                        TbQRInput.Text = ""
'                        TbQRInput.Select()
'                    End If

                Case "Input OP No."

                    If TbQRInput.Text.Length = 6 And IsNumeric(TbQRInput.Text.Remove(0, 1)) Then
                        '
                        'OP No. input OK ---------------------------------------------------------------------------------------
                        opNo = TbQRInput.Text
                        LbOPNo.Text = "OP No.               :  " & TbQRInput.Text



                        lbCaption.Text = "Process Condition"                                 'OS/FT,FT
                        lbCaption.ForeColor = Color.Black
                        Panel1.Enabled = True
                        tbxInput.Text = ""
                        Exit Sub
                    Else
                        MsgBox("Please Input OP No.", 48, "OP NO.")

                        TbQRInput.Text = ""
                        TbQRInput.Select()
                    End If

                Case "Process Condition"
                    If Not tbxInput.Text = "" Then
                        bxName = tbxInput.Text
                        lbProName.Text = "Program Name    : " & proName
                        lbBxName.Text = "Box Name          : " & bxName
                        tbxInput.Text = ""
                        KYB.Dispose()
                        lbInputPcs.Text = "Input Qty."
                        GoTo NextInputQty

                    End If

                    If RadioButton1.Checked Then
                        processCon = "OS"
                        proName = DBxDataSet.TransactionData.Rows(0)("OSProgram")
                        lbCaption.Text = "Process Condition"
                        tbxInput.Enabled = True
                        tbxInput.Select()
                        lbInputPcs.Text = "Box Name"
                        KeyBoardCall(tbxInput, False)
                        Panel1.Enabled = False
                        Exit Sub

                    ElseIf RadioButton2.Checked Then
                        processCon = "AUTO1"
                    ElseIf RadioButton3.Checked Then
                        processCon = "OS/FT"
                    Else
                        Exit Sub
                    End If


                    lbCaption.Text = "Test Condition"
                    TbQRInput.Text = ""
                    TbQRInput.Select()
                    lbCaption.ForeColor = Color.Blue
                    ProgressBar1.Maximum = 15
                    Panel1.Enabled = False
                    lbprocess.Text = "Process : " & processCon
                    Exit Sub

                Case "Test Condition"
                    Dim FTdata() As String = Split(TbQRInput.Text, ",")
                    If FTdata.Length > 7 Then
                        proName = FTdata(7)
                        bxName = FTdata(6)
                        lbProName.Text = "Program Name    : " & proName
                        lbBxName.Text = "Box Name          : " & bxName
NextInputQty:
                        TbQRInput.Text = ""
                        lbCaption.Text = "Input  Qty"
                        lbCaption.ForeColor = Color.Black

                        If frmMain.KeysToolStripMenuItem.Checked Then
                            tbxInput.Enabled = True
                            tbxInput.Select()
                            KeyBoardCall(tbxInput, True)
                            btnConfirm.Enabled = True
                        Else
                            If lotNo.Length = 10 Then                      'Lotno blank check

                                If processCon Like "AUTO*" Then                  'FT Get goood from OS
                                    MAPOSFTDataTableAdapter.FillBy(DBxDataSet.MAPOSFTData, lotNo)
                                    If DBxDataSet.MAPOSFTData.Count > 0 Then
                                        If Not IsNumeric(DBxDataSet.MAPOSFTData.Rows(0)("TotalGood")) Then
                                            MsgBox("ไม่มีค่างาน Goods ของ  Process ก่อนหน้า ให้กลับไปตรวจสอบและทำการแก้ไขให้ถูกต้อง")
                                            Exit Sub
                                        End If
                                        tbxInput.Text = DBxDataSet.MAPOSFTData.Rows(0)("TotalGood")
                                        btnConfirm.Enabled = True
                                    Else
                                        MsgBox("ไม่สารถทำการผลิตได้เนื่องจาก ใน Process OS ไม่มีประวัติ Lotนี้")
                                        Me.Close()
                                    End If
                                Else                                       'OS OS/FT Get good from AUTO Label
                                    MAPALDataTableAdapter.FillBy(DBxDataSet.MAPALData, lotNo)
                                    If DBxDataSet.MAPALData.Count > 0 Then
                                        If Not IsNumeric(DBxDataSet.MAPALData.Rows(0)("TotalGood")) Then
                                            MsgBox("ไม่มีค่างาน Goods ของ  Process ก่อนหน้า ให้กลับไปตรวจสอบและทำการแก้ไขให้ถูกต้อง")
                                            Exit Sub
                                        End If
                                        tbxInput.Text = DBxDataSet.MAPALData.Rows(0)("TotalGood")
                                        'If tbxInput.Text = "" Then                         'ในกรณีไม่มีค่า Good จะให้ run ได้
                                        '    tbxInput.Enabled = True
                                        '    tbxInput.Select()
                                        '    KeyBoardCall(tbxInput)
                                        '    btnConfirm.Enabled = True
                                        'End If
                                        btnConfirm.Enabled = True
                                    Else
                                        MsgBox("ไม่สารถทำการผลิตได้เนื่องจาก ใน Process Auto Label ไม่มีประวัติ Lotนี้")
                                        Me.Close()
                                    End If
                                End If

                            Else
                                MsgBox("Lot No. ไม่ถูกต้อง")
                            End If

                        End If
                        btnConfirm.Enabled = True
                        Exit Sub

                    Else
                        MsgBox("กรุณาใส่ ข้อมูล 'FT OPERATION INSTRUCTION SHEET QR' เท่านั้น")
                        TbQRInput.Text = ""
                        TbQRInput.Select()
                    End If

                Case "Input  Qty"

                    If IsNumeric(tbxInput.Text) Then
                        'If tbxInput.Text > 32768 Then
                        '    MsgBox("ใส่ค่าได้ไม่เกิน  32768 pcs", 48)
                        '    tbxInput.Text = ""
                        '    Exit Sub
                        'Else
                        inputQty = tbxInput.Text
                        tbxInput.Text = ""
                        lbInputPcs.Text = "Input Qty :  " & inputQty

                        'End If
                    Else
                        MsgBox("กรุณาใส่ค่าตัวเลข", 48, "ขั้นตอน input data")
                        tbxInput.Text = ""

                    End If
                    'Save data to MAPALDatatable

                    '------ 2loop ยืนยัน  ปิด


                    Dim dr As DBxDataSet.MAPOSFTDataRow = frmMain.DBxDataSet.MAPOSFTData.NewRow
                    dr.MCNo = ProcessHeader & frmMain.lbMC.Text
                    dr.LotNo = lotNo
                    dr.InputQty = inputQty
                    dr.OPNo = opNo
                    dr.LotStartTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
                    dr.Process = processCon
                    dr.ProgramName = proName
                    dr.BoxName = bxName
                    If Not processCon Like "AUTO*" Then                      ''If FT MAPOS is null _130904
                        dr.MAPOS = 0
                    End If

                    frmMain.DBxDataSet.MAPOSFTData.Rows.InsertAt(dr, 0)

                    With frmMain
                        .MAPOSFTDataBindingSource.Position = 0          'Update new data 
                    End With
                    tbxInput.Text = ""
                    tbxInput.Enabled = False

                    Me.Close()

                Case "Input GL No."
                    If Not IsNumeric(TbQRInput.Text) Then
                        MsgBox("ให้ใส่รหัสที่เป็นตัวเลขหกหลัก")
                        TbQRInput.Text = ""
                        Exit Sub
                    End If
                    If TbQRInput.Text.Length <> 6 Then
                        MsgBox("ให้ใส่รหัสที่เป็นตัวเลขหกหลัก")
                        TbQRInput.Text = ""
                        Exit Sub
                    End If
                    frmMain.DBxDataSet.MAPOSFTData.Rows(0)("GLCheck") = TbQRInput.Text
                    Me.Close()


                Case Else
                    TbQRInput.Text = ""
                    TbQRInput.Select()
            End Select





        End If


    End Sub


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




    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        ''If lbInputPcs.Text = "Box Name" Then

        ''    TbQRInput.Select()
        ''    My.Computer.Keyboard.SendKeys("{ENTER}")            'Send event Keypress & VBCr
        ''    Exit Sub
        ''End If
        If IsNumeric(tbxInput.Text) Then
            'If tbxInput.Text > 32768 Then
            '    MsgBox("ใส่ค่าได้ไม่เกิน  32768 pcs", 48)
            '    tbxInput.Text = ""
            '    Exit Sub
            'Else
            inputQty = tbxInput.Text
            tbxInput.Text = ""
            lbInputPcs.Text = "Input Qty :  " & inputQty

            'End If
        Else
            MsgBox("กรุณาใส่ค่าตัวเลข", 48, "ขั้นตอน input data")
            tbxInput.Text = ""
            Exit Sub
        End If
        'Save data to MAPALDatatable
        Dim dr As DBxDataSet.MAPOSFTDataRow = frmMain.DBxDataSet.MAPOSFTData.NewRow
        dr.MCNo = ProcessHeader & frmMain.lbMC.Text
        dr.LotNo = lotNo
        dr.InputQty = inputQty
        dr.OPNo = opNo
        dr.LotStartTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
        dr.Process = processCon
        dr.ProgramName = proName
        dr.BoxName = bxName
        If Not processCon Like "AUTO*" Then                      ''If FT MAPOS is null _130904
            dr.MAPOS = 0
        End If
        frmMain.DBxDataSet.MAPOSFTData.Rows.InsertAt(dr, 0)

        With frmMain
            .MAPOSFTDataBindingSource.Position = 0          'Update new data 
        End With
        tbxInput.Text = ""
        tbxInput.Enabled = False

        Me.Close()
    End Sub


    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        TbQRInput.Select()
        My.Computer.Keyboard.SendKeys("{ENTER}")            'Send event Keypress & VBCr
    End Sub


End Class