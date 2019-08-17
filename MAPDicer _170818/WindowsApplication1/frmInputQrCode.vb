
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Soap
Imports System.Threading
Imports System.Xml.Serialization




Public Class frmInputQrCode

    'Dim lotNo As String
    ''Dim assyDevice As String
    ''Dim package As String
    'Dim opNo As String
    'Dim inputQty As String
    Public IsPass As Boolean = True

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
    Private c_QrCode As String
    Public Property QrCode() As String
        Get
            Return c_QrCode
        End Get
        Set(ByVal value As String)
            c_QrCode = value
        End Set
    End Property


    Private Sub frmInputQrCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Location = New System.Drawing.Point(150, 300)
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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbQRInput.TextChanged
        If ProgressBar1.Maximum > TbQRInput.Text.Length Then
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
    '    Dim li As LotInfo
    '    Private m_LotReqQueue As String
    '    ' Private m_TdcService As TdcService
    '    Dim m_dlg As TdcAlarmMessageForm
    '    Enum MCLock
    '        Unlock
    '        Lock

    '    End Enum
    '    Private Structure TDC_Parameter
    '        Dim LotNo As String
    '        Dim StartMode As RunModeType
    '        Dim TimeStamp As Date
    '        Dim GoodPcs As Integer
    '        Dim NgPcs As Integer
    '        Dim EndMode As EndModeType
    '        Dim EqNo As String
    '        Dim OPID As String
    '    End Structure
    '    Private Function LotReqQueue(ByVal MCNo As String, ByVal LotNo As String)
    '        If My.Settings.RunOffline Then
    '            GoTo Offline

    '        End If
    '        li = Nothing
    '        Dim StatusMCLock As Integer
    '        Dim strMess As String = ""
    '        'Dim res2 As TdcResponse = m_TdcService.LotRequest(MCNo, LotNo, RunModeType.Normal)

    '        Dim Parameter As New TDC_Parameter
    '        Parameter.LotNo = LotNo
    '        Parameter.StartMode = RunModeType.Normal
    '        Parameter.EqNo = MCNo

    '        Dim res As TdcLotRequestResponse = m_TdcService.LotRequest(Parameter.EqNo, Parameter.LotNo, Parameter.StartMode)
    '        ' Dim res2 As TdcResponse = m_TdcService.LotRequest(MCNo, LotNo, RunModeType.Normal)


    '        'Rpl.LotNoTag MAP_Dicer
    '        Using proxy As MAP_Dicer.RohmService.ApcsWebServiceSoapClient = New MAP_Dicer.RohmService.ApcsWebServiceSoapClient()
    '            If proxy.LotRptIgnoreError(res.MCNo, res.ErrorCode) Then
    '                GoTo OKAns
    '            End If
    '        End Using



    '        If res.HasError Then
    '            If res.ErrorCode = "01" Then
    '                strMess = "01 : Not found"
    '                If My.Settings.NotFound = MCLock.Unlock Then
    '                    StatusMCLock = MCLock.Unlock
    '                Else
    '                    StatusMCLock = MCLock.Lock
    '                End If
    '            ElseIf res.ErrorCode = "02" Then
    '                strMess = "02 : Running" 'Lotset ซ้ำ
    '                If My.Settings.Running = MCLock.Unlock Then
    '                    StatusMCLock = MCLock.Unlock
    '                Else
    '                    StatusMCLock = MCLock.Lock
    '                End If
    '            ElseIf res.ErrorCode = "03" Then
    '                strMess = "03 : Not run" 'End ที่ยังไม่ lotset
    '                If My.Settings.NotRun = MCLock.Unlock Then
    '                    StatusMCLock = MCLock.Unlock
    '                Else
    '                    StatusMCLock = MCLock.Lock
    '                End If
    '            ElseIf res.ErrorCode = "04" Then
    '                strMess = "04 : Machine not found" 'Machine ยังไม่ลงทะเบียน
    '                If My.Settings.MachineNotFound = MCLock.Unlock Then
    '                    StatusMCLock = MCLock.Unlock
    '                Else
    '                    StatusMCLock = MCLock.Lock
    '                End If
    '            ElseIf res.ErrorCode = "05" Then
    '                strMess = "05 : Error lot status"
    '                If My.Settings.ErrorLotStatus = MCLock.Unlock Then
    '                    StatusMCLock = MCLock.Unlock
    '                Else
    '                    StatusMCLock = MCLock.Lock
    '                End If
    '            ElseIf res.ErrorCode = "06" Then
    '                strMess = "06 : " & res.ErrorMessage 'run ผิด flow
    '                If My.Settings.ErrorFlow = MCLock.Unlock Then
    '                    StatusMCLock = MCLock.Unlock
    '                Else
    '                    StatusMCLock = MCLock.Lock
    '                End If
    '            ElseIf res.ErrorCode = "70" Then
    '                strMess = "70 : Error connect database"
    '                If My.Settings.ErrorConnectDatabase = MCLock.Unlock Then
    '                    StatusMCLock = MCLock.Unlock
    '                Else
    '                    StatusMCLock = MCLock.Lock
    '                End If
    '            ElseIf res.ErrorCode = "71" Then
    '                strMess = "71 : Error read database"
    '                If My.Settings.ErrorReadDatabase = MCLock.Unlock Then
    '                    StatusMCLock = MCLock.Unlock
    '                Else
    '                    StatusMCLock = MCLock.Lock
    '                End If
    '            ElseIf res.ErrorCode = "72" Then
    '                strMess = "72 : Error write database"
    '                If My.Settings.ErrorWriteDatabase = MCLock.Unlock Then
    '                    StatusMCLock = MCLock.Unlock
    '                Else
    '                    StatusMCLock = MCLock.Lock
    '                End If
    '            ElseIf res.ErrorCode = "99" Then
    '                strMess = "99 : " & res.ErrorMessage 'Other
    '                If My.Settings.ErrorOther = MCLock.Unlock Then
    '                    StatusMCLock = MCLock.Unlock
    '                Else
    '                    StatusMCLock = MCLock.Lock
    '                End If
    '            End If
    '        Else
    'OKAns:
    '            strMess = "00 : Run Normal"
    '            StatusMCLock = MCLock.Unlock
    '        End If


    '        If StatusMCLock = MCLock.Lock Then
    '            li = m_TdcService.GetLotInfo(LotNo, MCNo)
    '            m_dlg = New TdcAlarmMessageForm(res.ErrorCode, res.ErrorMessage, LotNo, li)
    '            m_dlg.ShowDialog()
    '            Return False
    '        Else
    'Offline:
    '            Return True
    '        End If


    '        'lbLotInfo.Text = strMess


    '        ' BtStart.Enabled = True


    '    End Function
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
    Private Sub TbQRInput_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TbQRInput.KeyPress, tbxInput.KeyPress

        If e.KeyChar = vbCr Then                                                                                                                        'CR Key Recieve
            TbQRInput.Text = TbQRInput.Text.ToUpper

            Select Case lbCaption.Text

                Case "Input QR Code"

                    If TbQRInput.Text.Length >= 252 Then


                        'TDC -------------------------------------------------------------------------------
                        '   
                        'If My.Settings.RunOffline = False Then
                        '    Dim LotRequest As Boolean = LotRequestTDC(TbQRInput.Text.Substring(30, 10), RunModeType.Normal, "MAP-" & Form1.lbMC.Text)
                        '    ' Form1.SaveLog(Form1.Message.Cellcon, "LotRequestTDC :" & LotRequest)
                        '    If LotRequest = False Then
                        '        'TbQRInput.Text = ""
                        '        ' TbQRInput.Select()
                        '        GoTo FailTDC
                        '    End If
                        'End If
                        QrCode = TbQRInput.Text
                        '
                        'QR OK Data Save -----------------------------------------------------------------------------------
                        '
                        '  lotNo = TbQRInput.Text.Substring(30, 10)

                        Dim WorkSlipQR As New WorkingSlipQRCode
                        WorkSlipQR.SplitQRCode(TbQRInput.Text)
                        WorkSlipQR.TransactionDataSave(TbQRInput.Text)
                        lotNo = WorkSlipQR.LotNo
                        TransactionDataTableAdapter.Fill(DBxDataSet.TransactionData, lotNo)
                        Dim trans As DBxDataSet.TransactionDataRow = DBxDataSet.TransactionData.Rows(0)

                        LbPKG.Text = "Package  : " & trans.Package
                        LbDevice.Text = "Device    : " & trans.Device
                        LbLotNo.Text = "Lot No.    : " & lotNo
                        'lotNo = TbQRInput.Text.Substring(30, 10)
                        'TransactionDataTableAdapter.Fill(DBxDataSet.TransactionData, lotNo)
                        'Dim trans As DBxDataSet.TransactionDataRow = DBxDataSet.TransactionData.Rows(0)

                        'LbPKG.Text = "Package  : " & trans.Package
                        'LbDevice.Text = "Device    : " & trans.Device
                        'LbLotNo.Text = "Lot No.    : " & lotNo
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

                    If TbQRInput.Text.Length = 6 And IsNumeric(TbQRInput.Text.Remove(0, 1)) Then
                        Dim ETC2 As String = Trim(QrCode.Substring(232, 20))
                        Dim QROpNo As String = TbQRInput.Text
                        If My.Settings.AuthenticationUser = True Then
                            If PermiisionCheck(ETC2, QROpNo, My.Settings.MC_MAPGroup, My.Settings.GL_MAPGroup, "MAP", Form1.lbMC.Text) = False Then
                                MsgBox(ErrMesETG)
                                TbQRInput.Text = ""
                                TbQRInput.Select()
                                Exit Sub
                            End If
                        End If

                        '
                        'OP No. input OK ---------------------------------------------------------------------------------------
                        opNo = TbQRInput.Text
                        LbOPNo.Text = "OP No.    :  " & TbQRInput.Text
                        TbQRInput.Text = ""
                        lbCaption.Text = "Input  Qty"
                        lbCaption.ForeColor = Color.Black
                        If Form1.KeysToolStripMenuItem1.Checked Or lotNo Like "*F*" Then
                            tbxInput.Enabled = True
                            tbxInput.Select()
                            KeyBoardCall(tbxInput)
                            btnConfirm.Enabled = True
                        Else
                            If lotNo.Length = 10 Then                      'Lotno blank check
                                MAPPKGMTDataTableAdapter.Fill(DBxDataSet.MAPPKGMTData, lotNo)
                                If DBxDataSet.MAPPKGMTData.Count > 0 Then
                                    If Not IsNumeric(DBxDataSet.MAPPKGMTData.Rows(0)("TotalGood")) Then
                                        MsgBox("ไม่มีค่างาน Goods ของ  Process ก่อนหน้า ให้กลับไปตรวจสอบและทำการแก้ไขให้ถูกต้อง")
                                        Exit Sub
                                    End If

                                    tbxInput.Text = DBxDataSet.MAPPKGMTData.Rows(0)("TotalGood")
                                    'If tbxInput.Text = "" Then                         'ในกรณีไม่มีค่า Good จะให้ run ได้
                                    '    tbxInput.Enabled = True
                                    '    tbxInput.Select()
                                    '    KeyBoardCall(tbxInput)
                                    '    btnConfirm.Enabled = True
                                    'End If
                                    btnConfirm.Enabled = True
                                Else
                                    MsgBox("ไม่สารถทำการผลิตได้เนื่องจาก ใน Process Mount ไม่มีประวัติ Lotนี้")
                                    IsPass = False
                                    Me.Close()
                                End If
                            Else
                                MsgBox("Lot No. ไม่ถูกต้อง")
                            End If

                        End If

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
                    ''Save data to MAPPKGDCDatatable
                    'Dim dr As DBxDataSet.MAPPKGDCDataRow = Form1.DBxDataSet.MAPPKGDCData.NewRow
                    'dr.MCNo = ProcessHeader & Form1.lbMC.Text
                    'dr.LotNo = lotNo
                    'dr.InputQty = inputQty
                    'dr.OPNo = opNo
                    'dr.LotStartTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
                    'Form1.DBxDataSet.MAPPKGDCData.Rows.InsertAt(dr, 0)

                    'With Form1
                    '    .MAPPKGDCDataBindingSource.Position = 0          'Update new data 

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
                    Form1.DBxDataSet.MAPPKGDCData.Rows(0)("GLCheck") = TbQRInput.Text
                    Me.Close()


                Case Else
                    TbQRInput.Text = ""
                    TbQRInput.Select()
            End Select





        End If


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




    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
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
        ''Save data to MAPPKGDCDatatable
        'Dim dr As DBxDataSet.MAPPKGDCDataRow = Form1.DBxDataSet.MAPPKGDCData.NewRow
        'dr.MCNo = ProcessHeader & Form1.lbMC.Text
        'dr.LotNo = lotNo
        'dr.InputQty = inputQty
        'dr.OPNo = opNo
        'dr.LotStartTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
        'Form1.DBxDataSet.MAPPKGDCData.Rows.InsertAt(dr, 0)

        'With Form1
        '    .MAPPKGDCDataBindingSource.Position = 0          'Update new data 

        'End With
        tbxInput.Text = ""
        tbxInput.Enabled = False

        Me.Close()
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