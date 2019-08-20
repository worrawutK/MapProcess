Imports Rohm.Apcs.Tdc
Imports MAP_Label.RohmService
Imports System.IO

Public Class frmInputQrCode

    'Dim lotNo As String
    ''Dim assyDevice As String
    ''Dim package As String
    'Dim opNo As String
    'Dim inputQty As String

    Private c_LotNo As String
    Public Property LotNo() As String
        Get
            Return c_LotNo
        End Get
        Set(ByVal value As String)
            c_LotNo = value
        End Set
    End Property
    Private c_OpNo As String
    Public Property OpNo() As String
        Get
            Return c_OpNo
        End Get
        Set(ByVal value As String)
            c_OpNo = value
        End Set
    End Property
    Private c_InputQty As String
    Public Property InputQty() As String
        Get
            Return c_InputQty
        End Get
        Set(ByVal value As String)
            c_InputQty = value
        End Set
    End Property
    Public IsPass As Boolean = True
    Private c_QrCode As String
    'Public Property QrCode() As String
    '    Get
    '        Return c_QrCode
    '    End Get
    '    Set(ByVal value As String)
    '        c_QrCode = value
    '    End Set
    'End Property
    Private Sub frmInputQrCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Location = New System.Drawing.Point(700, 650)
        LbPKG.Text = "Package "
        LbDevice.Text = "Device "
        LbLotNo.Text = "Lot No. "

        If lbCaption.Text = "Input QR Code" Then
            TbQRInput.Text = ""
            TbQRInput.Select()
            ProgressBar1.Maximum = 252
        ElseIf lbCaption.Text = "Input GL No." Then                                                                                                                                                           'Case Input Edit Or Magzine Edit
            TbQRInput.Text = ""
            TbQRInput.Select()
        ElseIf lbCaption.Text = "Input OP No. CANCEL LOT" Then
            ProgressBar1.Maximum = 6
        Else
            'tbxInput.Enabled = True
            'tbxInput.Select()

        End If
        'If Form1.lbLotNo.Text = "" Then
        '    lbMag.Enabled = False
        'End If
        TbQRInput.Location = New Point(250, Me.ProgressBar1.Top)
        btnConfirm.Enabled = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Maximum >= TbQRInput.Text.Length Then
            ProgressBar1.Value = TbQRInput.Text.Length
        End If

    End Sub

    Private Sub tbxInput_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxInput.Click, tbxInput.Enter
        KeyBoardCall(tbxInput)
    End Sub


    '
    ' Data input recieve after Cr key Check Case , "Input QR , Input OP No , Input  Qty  , -------------------------------
    ' Input Edit
    '
    'Public QrCode As String
    Private Sub TbQRInput_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TbQRInput.KeyPress, tbxInput.KeyPress

        If e.KeyChar = vbCr Then                                                                                                                        'CR Key Recieve
            TbQRInput.Text = TbQRInput.Text.ToUpper

            Select Case lbCaption.Text

                Case "Input QR Code"

                    If TbQRInput.Text.Length = 252 OrElse TbQRInput.Text.Length = My.Settings.QRCodeLength Then
                        ' QrCode = TbQRInput.Text

                        Dim WorkSlipQR As New WorkingSlipQRCode
                        WorkSlipQR.SplitQRCode(TbQRInput.Text)
                        Parameter.LotNo = WorkSlipQR.LotNo
                        Parameter.Package = WorkSlipQR.Package.ToUpper
                        Parameter.Device = WorkSlipQR.Device
                        Parameter.OpNo = Parameter.OpNo
                        Parameter.QR = TbQRInput.Text
                        If Parameter.LotNo Like "*F*" Then
                            Dim ans = RecipeCheck(Parameter.Package)
                            If ans Like "*Error*" Then
                                MsgBox("กรุณาติดต่อ PACKAGE ให้ทำการลงทะเบียน Recipe " & Parameter.Package)
                                Me.Close()
                                Exit Sub
                            End If
                        End If

                        lotNo = TbQRInput.Text.Substring(30, 10)

                        '   Cancel = False
                        If CheckLot() = False Then
                            ' Exit Sub

                            Exit Sub
                        Else
                            If LoopLot = True Then 'run มากกว่า 1 ครั้ง
                                GoTo Renrun
                            End If

                        End If

                        'If My.Settings.Debug = True Then
                        '    GoTo AB
                        'End If
                        ''TDC -------------------------------------------------------------------------------
                        '   
                        ' If Not Parameter.LotNo Like "*F*" Then
                        'If My.Settings.RunMode.ToUpper = "OFFLINE" Then
                        '    Form1.SerialPort1.Write("LR ," + Parameter.QR + "," + My.Settings.RingNumberAlot.ToString + Chr(13))
                        '    Me.DialogResult = Windows.Forms.DialogResult.OK
                        '    Exit Sub
                        'End If

                        'If My.Settings.RunOffline = False Then

                        '    If LotRequestTDC(TbQRInput.Text.Substring(30, 10), RunModeType.Normal, "MAP-" & Form1.lbMC.Text) = False Then
                        '        'TbQRInput.Text = ""
                        '        ' TbQRInput.Select()
                        '        GoTo FailTDC
                        '    End If

                        '    '  Dim frm As Form1
                        '    ' Form1.SerialPort1.Open()

                        '    ' Form1.SerialPort1.Close()
                        '    '  SerialPort1.Write("LP01" + "00" + Chr(13))


                        'End If
Renrun:
                        'End If



                        ' Save QR Code to transsaction table                                On Error GoTo ErrHander

                        TransactionDataTableAdapter.Fill(DBxDataSet.TransactionData, Parameter.LotNo)
                        If DBxDataSet.TransactionData.Count <> 0 Then


                            Dim trans As DBxDataSet.TransactionDataRow = DBxDataSet.TransactionData.Rows(0)

                            '
                            'QR OK Data Save -----------------------------------------------------------------------------------
                            '

                            LbPKG.Text = "Package  : " & trans.Package
                            LbDevice.Text = "Device    : " & trans.Device
                            LbLotNo.Text = "Lot No.    : " & lotNo

                            '005588 tee Before check data that MarkTextLine is not null 
                            Dim MarkTextLine1 As String = ""
                            Dim MarkTextLine2 As String = ""
                            Dim MarkTextLine3 As String = ""
                            If trans.IsMarkTextLine1Null = False Then
                                MarkTextLine1 = trans.MarkTextLine1
                            End If
                            If trans.IsMarkTextLine2Null = False Then
                                MarkTextLine2 = trans.MarkTextLine2
                            End If
                            If trans.IsMarkTextLine3Null = False Then
                                MarkTextLine3 = trans.MarkTextLine3
                            End If



                            lbMarkNo.Text = "Mark No  : " & MarkTextLine1 & " " & MarkTextLine2 & " " & MarkTextLine3
                        End If
                        If Parameter.LotNo Like "*F*" Then
                            LbPKG.Text = "Package  : " & Parameter.Package
                            LbDevice.Text = "Device    : " & Parameter.Device
                            LbLotNo.Text = "Lot No.    : " & Parameter.LotNo
                            '  GoTo Flot

                        End If
                        'Flot:
                        'AB:
                        '
                        'Switch to OP No. input -------------------------------------------------------------------------------
                        '
                        lbCaption.Text = "Input OP No."
                        lbCaption.ForeColor = Color.Blue
                        TbQRInput.Text = ""
                        TbQRInput.Select()
                        ProgressBar1.Maximum = 6

                        Exit Sub
                    Else
                        MsgBox("Please Input QR Code Size ''252''", 48, "QR Code Size ''" & TbQRInput.Text.Length & "''")
FailTDC:
                        TbQRInput.Text = ""
                        TbQRInput.Select()
                    End If

                Case "Input OP No."

                    If TbQRInput.Text.Length = 6 AndAlso IsNumeric(TbQRInput.Text.Remove(0, 1)) Then

                        Dim ETC2 As String = Trim(Parameter.QR.Substring(232, 20))
                        Dim QROpNo As String = TbQRInput.Text
                        If My.Settings.AuthenticationUser = True Then
                            If PermiisionCheck(ETC2, QROpNo, My.Settings.MC_MAPGroup, My.Settings.GL_MAPGroup, "MAP", Form1.lbMC.Text) = False Then
                                MsgBox(ErrMesETG)
                                TbQRInput.Text = ""
                                TbQRInput.Select()
                                Exit Sub
                            End If
                        End If

                        Parameter.OpNo = TbQRInput.Text
                        '   Form1.SerialPort1.Write("LR" + Parameter.QR + Chr(13))
                        'If My.Settings.MAPFormat = MAP.ASE.ToString Then

                        '    Me.Close()
                        '    Exit Sub
                        'End If
                        '
                        'OP No. input OK ---------------------------------------------------------------------------------------
                        opNo = TbQRInput.Text
                        LbOPNo.Text = "OP No.    :  " & TbQRInput.Text
                        TbQRInput.Text = ""
                        lbCaption.Text = "Input  Qty"
                        lbCaption.ForeColor = Color.Black
                        If Form1.KeysToolStripMenuItem1.Checked Then 'Or Parameter.LotNo Like "*F*"
                            tbxInput.Enabled = True
                            tbxInput.Select()
                            KeyBoardCall(tbxInput)
                            btnConfirm.Enabled = True
                        Else
                            If lotNo.Length = 10 Then                      'Lotno blank check
                                MAPPKGDCDataTableAdapter.Fill(DBxDataSet.MAPPKGDCData, lotNo)
                                If DBxDataSet.MAPPKGDCData.Count > 0 Then
                                    If Not IsNumeric(DBxDataSet.MAPPKGDCData.Rows(0)("TotalGood")) Then
                                        MsgBox("ไม่มีค่างาน Goods ของ  Process ก่อนหน้า ให้กลับไปตรวจสอบและทำการแก้ไขให้ถูกต้อง")
                                        Exit Sub
                                    End If
                                    tbxInput.Text = DBxDataSet.MAPPKGDCData.Rows(0)("TotalGood")
                                    'If tbxInput.Text = "" Then                         'ในกรณีไม่มีค่า Good จะให้ run ได้
                                    '    tbxInput.Enabled = True
                                    '    tbxInput.Select()
                                    '    KeyBoardCall(tbxInput)
                                    '    btnConfirm.Enabled = True
                                    'End If
                                    btnConfirm.Enabled = True
                                Else
                                    '    MsgBox("ไม่สารถทำการผลิตได้เนื่องจาก ใน Process Dicer ไม่มีประวัติ Lotนี้")
                                    ' Exit Sub
                                    '  Me.Close()
                                    MsgBox("Process Dicer ไม่มีประวัติ Lotนี้ กรุณา Input Qty")
                                    tbxInput.Enabled = True
                                    tbxInput.Select()
                                    KeyBoardCall(tbxInput)
                                    btnConfirm.Enabled = True
                                End If
                            Else
                                MsgBox("Lot No. ไม่ถูกต้อง")
                            End If

                        End If

                        btnConfirm.Enabled = True
                        Exit Sub
                    Else
                        MsgBox("Please Input OP No.", 48, "OP NO.")

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

                    ''Save data to MAPALDatatable
                    'Dim dr As DBxDataSet.MAPALDataRow = Form1.DBxDataSet.MAPALData.NewRow
                    'dr.MCNo = ProcessHeader & Form1.lbMC.Text
                    'dr.LotNo = lotNo
                    'dr.InputQty = inputQty
                    'dr.OPNo = opNo
                    'dr.LotStartTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
                    'Form1.DBxDataSet.MAPALData.Rows.InsertAt(dr, 0)

                    'With Form1
                    '    .MAPALDataBindingSource.Position = 0          'Update new data 
                    'End With
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
                    Form1.DBxDataSet.MAPALData.Rows(0)("GLCheck") = TbQRInput.Text
                    Me.Close()

                Case "Input OP No. CANCEL LOT"
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
                    If Cancel = True Then

                        If Parameter.LotNo Like "*F*" Then

                            Dim aa As String = Form1.CancelASEStrip(Parameter.LotNo)
                            If aa Like "*True*" Then
                                '   MsgBox(CancelASEStrip(Parameter.LotNo))
                                MsgBox("Cancel F Lot สำเร็จ")
                            Else
                                MsgBox(aa)
                            End If
                        Else
                            MsgBox("Cancel A Lot สำเร็จ")
                        End If
                        CancelLot(Parameter.LotNo, ProcessHeader & My.Settings.MCNo, Parameter.OpNo)
                        ' Dim resEnd As TdcResponse = m_TdcService.LotEnd(ProcessHeader & My.Settings.MCNo, Parameter.LotNo, Format(Now, "yyyy-MM-dd HH:mm:ss"), 0, 0, EndModeType.AbnormalEndReset, TbQRInput.Text)
                        ' Form1.SaveLog(Form1.Message.Cellcon, "Cancel Lot" & resEnd.ErrorCode & ":" & resEnd.ErrorMessage)
                        MapalDataTableAdapter1.Update(DBxDataSet.MAPALData)

                        lbCaption.Text = "Input QR Code"
                        lbCaption.ForeColor = Color.Blue
                        TbQRInput.Text = ""
                        TbQRInput.Select()
                        ProgressBar1.Maximum = 6
                        Exit Sub
                    End If


                    ''  Form1.DBxDataSet.MAPALData.Rows(0)("GLCheck") = TbQRInput.Text
                    'lbCaption.Text = "Input QR Code"
                    'lbCaption.ForeColor = Color.Blue
                    'TbQRInput.Text = ""
                    'TbQRInput.Select()
                    'ProgressBar1.Maximum = 300

                    'Exit Sub
                    'Me.Close()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Case Else
                    TbQRInput.Text = ""
                    TbQRInput.Select()
            End Select





        End If


    End Sub
    Dim Cancel As Boolean
    Dim LoopLot As Boolean
    Public Function CheckLot()
        LoopLot = False
        Cancel = False
        Try
            MapalDataTableAdapter1.FillCheckLot(DBxDataSet.MAPALData, Parameter.LotNo, ProcessHeader & My.Settings.MCNo)

            If DBxDataSet.MAPALData.Count <> 0 Then
                For Each Data As DBxDataSet.MAPALDataRow In DBxDataSet.MAPALData
                    If Not Data.IsLotEndTimeNull Then
                        Dim result2 As Integer = MessageBox.Show("Lot นี้จบไปแล้ว ต้องการ run อีกรอบหรือไม่ ?", "Message", MessageBoxButtons.YesNo)
                        If result2 = DialogResult.No Then
                            Return False
                        ElseIf result2 = DialogResult.Yes Then
                            LoopLot = True
                            Return True
                        End If
                        ' MsgBox("Lot นี้จบไปแล้ว")
                        'Dim result As Integer = MessageBox.Show("ต้องการ CANCEL Lot หรือไม่ ?", "Message", MessageBoxButtons.YesNo)
                        'If result = DialogResult.Yes Then
                        '    Return True
                        'End If
                        ' Me.Close()
                        '  Return False

                    End If
                    Data.LotEndTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
                    Data.Remark = "CANCELLOT"

                Next
                Dim result As Integer = MessageBox.Show("ต้องการ CANCEL Lot หรือไม่ ?", "Message", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then

                    '  MessageBox.Show("No pressed")

                ElseIf result = DialogResult.Yes Then

                    Cancel = True
                    '    MessageBox.Show("Yes pressed")           
                    lbCaption.Text = "Input OP No. CANCEL LOT"
                    lbCaption.ForeColor = Color.Blue
                    TbQRInput.Text = ""
                    TbQRInput.Select()
                    ProgressBar1.Maximum = 6
                    Return False
                    Exit Function
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

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
    '                    dlg.TopMost = True
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
        KYB.Location = New Point(1250, 700)
        AddHandler KYB.FormClosed, AddressOf KYB_Formclose

    End Sub
    Private Sub KYB_Formclose()
        'tbxCtrl unfocus

    End Sub

#End Region




    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If IsNumeric(tbxInput.Text) Then
            'If tbxInput.Text > 32768 Then
            '    MsgBox("ใส่ค่าได้ไม่เกิน  32768 pcs", 48)
            '    tbxInput.Text = ""
            '    Exit Sub
            'Else
            Parameter.Input = CInt(tbxInput.Text)
            inputQty = tbxInput.Text
            tbxInput.Text = ""
            lbInputPcs.Text = "Input Qty :  " & inputQty

            'End If
        Else
            MsgBox("กรุณาใส่ค่าตัวเลข", 48, "ขั้นตอน input data")
            tbxInput.Text = ""
            Exit Sub
        End If
        '''Save data to MAPALDatatable
        'Form1.DBxDataSet.MAPALData.Clear()
        'Dim dr As DBxDataSet.MAPALDataRow = Form1.DBxDataSet.MAPALData.NewRow
        'dr.MCNo = ProcessHeader & Form1.lbMC.Text
        'dr.LotNo = lotNo
        'dr.InputQty = inputQty
        'dr.OPNo = OpNo

        '' dr.LotStartTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
        'Form1.DBxDataSet.MAPALData.Rows.InsertAt(dr, 0)

        'With Form1
        '    .MAPALDataBindingSource.Position = 0          'Update new data 
        'End With

        tbxInput.Text = ""
        tbxInput.Enabled = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
        'Me.Close()
    End Sub

    Dim package_id As String
    Dim block_columns As String
    Dim block_rows As String
    Dim device_columns As String
    Dim device_rows As String
    Dim device_size_x As String
    Dim device_size_y As String
    Dim supplier_ As String
    Function RecipeCheck(RecipeName As String) As String
        Dim RECIPE_PATH As String = My.Application.Info.DirectoryPath & "\RECIPE"
        Dim PathFile As String() = Directory.GetFiles(RECIPE_PATH)
        Dim Filename As List(Of String) = New List(Of String)
        For Each Name As String In PathFile
            Filename.Add(Path.GetFileName(Name).Split(".")(0))
        Next
        If Not Filename.Contains(RecipeName) Then
            RecipeHeaderMapXTableAdapter1.Fill(DBxDataSet.RecipeHeaderMapX, RecipeName)
            If DBxDataSet.RecipeHeaderMapX.Rows.Count > 0 Then
                For Each Recipe As DBxDataSet.RecipeHeaderMapXRow In DBxDataSet.RecipeHeaderMapX
                    package_id = Recipe.Package
                    block_columns = Recipe.BlockClm
                    block_rows = Recipe.BlockRw
                    device_columns = Recipe.DeviceClm
                    device_rows = Recipe.DeviceRw
                    device_size_x = Recipe.DeviceSizeX
                    device_size_y = Recipe.DeviceSizeY
                    supplier_ = Recipe.Supplier
                    XmlDocCreate(RECIPE_PATH & "\" & package_id & ".xml")
                Next
                Return "True,Download Recipe"
            Else
                Return "Error,Not Recipe" '"กรุณาติดต่อ PACKAGE ให้ทำการลงทะเบียน Recipe"

            End If
        End If
        Return "True,Already Exists"
    End Function
    Private Sub XmlDocCreate(ByVal Path As String)
        Dim Docx As New XDocument()
        Docx =
<?xml version="1.0" encoding="UTF-8"?>
<packagedata>
    <package_id>VSON04Z111</package_id>
    <block_columns>2</block_columns>
    <block_rows>1</block_rows>
    <device_columns>50</device_columns>
    <device_rows>72</device_rows>
    <device_size_x>1100</device_size_x>
    <device_size_y>1400</device_size_y>
    <supplier>ASE</supplier>
</packagedata>

        Dim Package = From l In Docx.Elements.Descendants("package_id") Select l
        Package.Value = package_id 'TextBox1.Text.ToUpper.Trim
        Dim BlockClm = From l In Docx.Elements.Descendants("block_columns") Select l
        BlockClm.Value = block_columns 'TextBox2.Text.ToUpper.Trim
        Dim BlockRw = From l In Docx.Elements.Descendants("block_rows") Select l
        BlockRw.Value = block_rows 'TextBox3.Text.ToUpper.Trim
        Dim DeviceClm = From l In Docx.Elements.Descendants("device_columns") Select l
        DeviceClm.Value = device_columns 'TextBox4.Text.ToUpper.Trim
        Dim DeviceRw = From l In Docx.Elements.Descendants("device_rows") Select l
        DeviceRw.Value = device_rows 'TextBox5.Text.ToUpper.Trim
        Dim DeviceSizeX = From l In Docx.Elements.Descendants("device_size_x") Select l
        DeviceSizeX.Value = device_size_x 'TextBox6.Text.ToUpper.Trim
        Dim DeviceSizeY = From l In Docx.Elements.Descendants("device_size_y") Select l
        DeviceSizeY.Value = device_size_y 'TextBox7.Text.ToUpper.Trim
        Dim Supplier = From l In Docx.Elements.Descendants("supplier") Select l
        Supplier.Value = supplier_ 'TextBox8.Text.ToUpper.Trim

        Docx.Save(Path)

    End Sub
#Region "===AuthenticationUser"


    'Dim ETC2 As String                          'From QR Code ,Check ETC2 = BDXX-M/BJ/C is auto motive
    'Dim strNextOperatorNo As String              'OP No.
    'Dim GetUserAuthenGroupByMCType As String       'M/C Type ( Refer with DBx.Group)
    'Dim GL_Group As String                         'GL Gruop ( Refer with DBx.Group)
    'Dim Process As String                        'Process Ex. "FL"
    'Dim MCNo As String                           'MC No Ex "FL-V-01"
    Friend ErrMesETG As String
    Friend Function PermiisionCheck(ByVal ETC2 As String, ByVal strNextOperatorNo As String, ByVal GetUserAuthenGroupByMCType As String, ByVal GL_Group As String, ByVal Procees As String, ByVal MCNo As String) As Boolean
        Dim permission As New AuthenticationUser.AuthenUser
        Dim AuthenPass As Boolean
        ErrMesETG = ""
        'OprData.PermitCheckResult = "Check"
        Try

            If permission.CheckAutomotiveLot(ETC2) Then
                'OprData.AutoMotiveLot = True
                'This lot is Automotive
                If Not permission.CheckMachineAutomotive(Procees, MCNo) Then          '(EQP.Machine.MCNo = @MCNo) AND (LSIProcess.Name = @ProcessName) AND (EQP.Machine.Automotive = 'true')
                    ErrMesETG = "MC No.นี้ไม่สามารถรัน Lot Automotive ได้ "
                    '_OperatorAlarm = "Machine cannot run the automotive lot,Please contact ETG"
                    'MsgBox("MC No.นี้ไม่สามารถรัน Lot Automotive ได้  กรุณาติดต่อ ETG/SYSTEM")
                    'OprData.PermitCheckResult = "False : Not Machine AutoMotive (Auotmotive Lot) MC No. " & MCNo
                    Return False
                End If

                Dim UserAuthen As Boolean = permission.AuthenUser(strNextOperatorNo, GetUserAuthenGroupByMCType)        '170408 \783 Authen Detail warning
                Dim UserAutoMotive As Boolean = permission.AuthenUser(strNextOperatorNo, "AUTOMOTIVE")                  '170408 \783 Authen Detail warning
                Dim UserGL As Boolean = permission.AuthenUser(strNextOperatorNo, GL_Group) 'GL Can run every condition  '170408 \783 Authen Detail warning

                AuthenPass = UserAuthen And UserAutoMotive

                If AuthenPass = False Then AuthenPass = UserGL 'GL Can run every condition
                If AuthenPass = False Then
                    If Not UserAuthen Then
                        ErrMesETG = "OP No.นี้ไม่สามารถรัน Lot Automotive ได้ เนื่องจาก license หมดอายุ หรือ ไม่มี license ( GroupCheck: " & GetUserAuthenGroupByMCType & ")" & "กรุณาติดต่อ ETG"
                        Return AuthenPass
                    End If
                    If Not UserAutoMotive Then
                        ErrMesETG = "OP No.นี้ไม่สามารถรัน Lot Automotive ได้ เนื่องจาก ไม่มีสิทธิ รัน AUTOMOTIVE ( GroupCheck: AUTOMOTIVE ) กรุณาติดต่อ ETG"
                        Return AuthenPass
                    End If
                    If Not UserGL Then
                        ErrMesETG = "OP No(GL).นี้ไม่สามารถรัน Lot Automotive ได้ เนื่องจากไม่มีสิทธิในกลุ่ม GL ( GroupCheck: " & GL_Group & ")" & "กรุณาติดต่อ ETG"
                        Return AuthenPass
                    End If
                    'OprData.PermitCheckResult = "False : Not Operaotr AutoMotive OP ID. " & strNextOperatorNo
                End If
                If AuthenPass Then
                    'OprData.PermitCheckResult = "True : (Automotive Lot)"

                End If
            Else
                'OprData.PermitCheckResult = "False : Not Operaotr AutoMotive (Auotmotive Lot) OP ID. " & strNextOperatorNo
                'OprData.AutoMotiveLot = False
                'This lot isn't Automotive
                AuthenPass = permission.AuthenUser(strNextOperatorNo, GetUserAuthenGroupByMCType)
                If AuthenPass = False Then AuthenPass = permission.AuthenUser(strNextOperatorNo, GL_Group)
                If AuthenPass = False Then
                    ErrMesETG = "OP No.นี้ไม่สามารถรัน Lotนี้ ได้ (license หมดอายุ หรือ ไม่มี license ,GroupCheck: " & GetUserAuthenGroupByMCType & ")" & "กรุณาติดต่อ ETG"   '170408 \783 Authen Detail warning
                    '_OperatorAlarm = "OP No cannot run ,Please contact ETG"
                    'OprData.PermitCheckResult = "False : OP ID No license or expire license (Normal Lot) OP ID. " & strNextOperatorNo
                End If
                If AuthenPass Then
                    'OprData.PermitCheckResult = "True : (Normal Lot)"

                End If
            End If


            Return AuthenPass
        Catch ex As Exception 'Network Error
            ErrMesETG = "Connection Error"
            Return False
        End Try
    End Function


    Public Function UserAuthen(ByVal strNextOperatorNo As String, ByVal GetUserAuthenGroupByMCType As String, ByVal GL_Group As String) As Boolean
        Dim permission As New AuthenticationUser.AuthenUser
        Dim AuthenPass As Boolean

        AuthenPass = permission.AuthenUser(strNextOperatorNo, GetUserAuthenGroupByMCType)
        If AuthenPass = False Then AuthenPass = permission.AuthenUser(strNextOperatorNo, GL_Group)
        If AuthenPass = False Then
            ErrMesETG = "OP No.นี้ไม่สามารถรันได้  กรุณาติดต่อ ETG" 'MsgBox("OP No.นี้ไม่สามารถรันได้  กรุณาติดต่อ ETG/SYSTEM")
            '_OperatorAlarm = "OP No cannot run ,Please contact ETG"
        End If

        Return AuthenPass
    End Function

    Public Function MachineAuomotive(ByVal Procees As String, ByVal MCNo As String) As Boolean
        Dim permission As New AuthenticationUser.AuthenUser
        Return permission.CheckMachineAutomotive(Procees, MCNo)           '(EQP.Machine.MCNo = @MCNo) AND (LSIProcess.Name = @ProcessName) AND (EQP.Machine.Automotive = 'true')
    End Function


#End Region


End Class