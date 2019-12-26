Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports Rohm
'Imports Rohm.Apcs.Tdc
Imports Rohm.Ems

Public Class Form1
    Public m_EmsClient As EmsServiceClient = New EmsServiceClient("MAP", "http://webserv.thematrix.net:7777/EmsService")
    'One event per load
    Private Sub lbAndon_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim str As String = My.Computer.Name
        Dim F1 As New Font("ARIAL", 11, FontStyle.Regular)
        Dim sbrush As New SolidBrush(Color.Black)
        Dim g As Graphics = Me.CreateGraphics()
        g.DrawString(str, F1, sbrush, lbMinimize.Left, lbMinimize.Bottom + 15)
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '!! Check Comment at [On Error Resume Next] of [ Protected Overrides Sub WndProc] for test this Sub afer new edit

        initial()
        BuildMCList()



        If Not Master Then
            lbMaster.Hide()
            btnInsert.Hide()
        Else
            tbxRemark.Enabled = False
            FstSave.Hide()
        End If
        DateTimePicker1.Hide()

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        WrXml(SelPath & "Config.xml", Confg)
    End Sub



#Region "===Initial"
    'Dim TargetWinTitle As String

    Private Sub initial()
        If Directory.Exists(TempDataBasePath) = False Then                          'AutoDirectory Create
            Directory.CreateDirectory(TempDataBasePath)
            Directory.CreateDirectory(TempPath)
        End If
        ''Label.text clear ----------------------------------------------------------------------------------------------
        For Each lb As Label In Panel1.Controls
            lb.Text = ""
        Next
        For Each lb As Label In Panel3.Controls
            lb.Text = ""
        Next
        For Each lb As Label In Panel4.Controls
            lb.Text = ""
        Next

        ''TDC Check and Run ----------------------------------------------------------------------------------------------
        'Dim tWnd1 As Integer = FindWindow(vbNullString, "TDC")
        'If tWnd1 = 0 Then
        '    If File.Exists(TDCFilePath) Then
        '        Me.m_TDCProcess = New Process
        '        Me.m_TDCProcess = Process.Start(TDCFilePath)
        '    Else
        '        MsgBox("Please Insert File ''machine.exe'' To ''" & Application.StartupPath & "\Modules\TDC''", 48, "File Not Found")
        '        Me.Close()
        '    End If
        'End If                                                                  'Target application name of post message
        If Not Me.Text = "Self Controller" Then                                 'TDC PostmMessage Receive name
            Me.Text = "Self Controller"
        End If
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then        'One application run only 130205
            Me.Close()
        End If
        txtPostMSGRecv.Hide()

        On Error Resume Next                                         'Config Load
        Confg = RdXml(SelPath & "Config.xml")
        If Confg.Offline Then
            lbOffline.Visible = True
        Else
            lbOffline.Visible = False
        End If


    End Sub


#End Region

#Region "===  KeyBoard Control"
    Dim KYB As KeyBoard

    Private Sub KeyBoardCall(ByVal OBJ As TextBox, ByVal Keys As Boolean)
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
        KYB.NumPad = Keys                         'Numpad =True , Keyboard = False
        KYB.Show()
        AddHandler KYB.FormClosed, AddressOf KYB_Formclose

    End Sub
    Private Sub KYB_Formclose()
        lbRevision.Focus()                   'tbxCtrl unfocus

    End Sub

#End Region

#Region "===PassWord"
    Dim Pbx As PassWord
    Private Sub PassWord(ByVal Level As String)   '"OPERATOR","ENGINEER","ADMIN"

        If Pbx Is Nothing Then                  'One open only
            Pbx = New PassWord
        ElseIf Pbx.IsDisposed Then
            Pbx = New PassWord
        End If
        Pbx.Level = Level
        Pbx.Owner = Me
        Pbx.TopMost = True
        Pbx.ShowDialog()
    End Sub

#End Region

#Region "=== TDC (APCS DATA BASE)"

    ''SendPostMessage("@CNTREQ" & "|" & ProcessHeader & SelConM.McNo & "|" & "00")
    ''SendPostMessage("@LOTREQ" & "|" & ProcessHeader & SelConM.McNo & "|" & SelConM.LotNo & "," & SelConM.OpNo & ",00")   'Normal
    ''SendPostMessage("@LOTEND|" & ProcessHeader & SelConM.McNo & "|" & SelConM.LotNo & "," & _
    '' SelConM.EndTime & "," & SelConM.OutputPcs & "," & SelConM.InputPcs - SelConM.OutputPcs & ",01") 'Lot End       'Normal


    ''******  Name of MainForm is Self Controller *******'

    'Private strRecv As String
    '<DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    '  Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    'End Function
    'Private Declare Function PostMessage Lib "user32.dll" Alias "PostMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    'Private m_TDCProcess As Process
    'Private Const WM_CUSTOMMESSAGE As Long = &H400
    'Private Const WM_CUSTOMMESSAGE_END As Long = &HD
    'Delegate Sub DelegateLoadSimFile(ByVal fpath As String, ByRef listControl As ListBox)
    'Private dLoadSimFile As DelegateLoadSimFile

    'Private Sub SendString(ByVal hWnd As Integer, ByVal strSend As String)
    '    'create byte array
    '    Dim ba() As Byte
    '    ba = Encoding.UTF8.GetBytes(strSend)
    '    For i As Integer = 0 To ba.Length - 1
    '        PostMessage(hWnd, WM_CUSTOMMESSAGE, 0, ba(i))
    '    Next
    '    PostMessage(hWnd, WM_CUSTOMMESSAGE, 0, WM_CUSTOMMESSAGE_END)

    'End Sub
    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    On Error Resume Next
    '    MyBase.WndProc(m)
    '    If m.Msg = WM_CUSTOMMESSAGE Then
    '        If m.LParam <> &HD Then
    '            Dim tmp(0) As Byte
    '            tmp(0) = m.LParam
    '            strRecv = strRecv & (Encoding.UTF8.GetString(tmp))
    '        Else
    '            Me.txtPostMSGRecv.Text = strRecv
    '            strRecv = ""
    '        End If
    '    End If

    'End Sub
    'Public Sub SendPostMessage(ByVal strSend As String)
    '    If Confg.Offline Then                                                       'Offline Mode
    '        Exit Sub
    '    End If
    '    lbStatus.Text = ""
    '    Dim tWnd As Long
    '    tWnd = FindWindow(vbNullString, "TDC")
    '    If tWnd <> 0 And strSend <> "" Then
    '        Dim i As Integer
    '        For i = 1 To Len(strSend)
    '            Call PostMessage(tWnd, WM_CUSTOMMESSAGE, 0, Asc(Mid(strSend, i, 1)))
    '        Next
    '        Call PostMessage(tWnd, WM_CUSTOMMESSAGE, 0, WM_CUSTOMMESSAGE_END)       ' Send [CR] Code

    '    End If
    'End Sub
    'Private Sub txtPostMSGRecv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPostMSGRecv.TextChanged
    '    Dim PMSRecvData As String
    '    Dim SplitData() As String
    '    Dim HEADER, Content1 As String
    '    Dim Content() As String
    '    Dim ContentMCNo() As String
    '    Dim HeaderMCNo As String
    '    PMSRecvData = txtPostMSGRecv.Text
    '    SplitData = Split(PMSRecvData, "|")
    '    If SplitData.Length > 3 Then                        'Concatenate string back block 3
    '        For i = 3 To SplitData.Length - 1
    '            SplitData(2) = SplitData(2) & "|" & SplitData(i)
    '        Next
    '    End If
    '    HEADER = SplitData(0)
    '    ContentMCNo = Split(SplitData(1), "-")
    '    HeaderMCNo = ContentMCNo(1) & "-" & ContentMCNo(2)
    '    Content1 = SplitData(2)

    '    Select Case HEADER
    '        Case "@CNTREQ"                                  '***  TDC Commu: Get Reply -> Lot Setup Report  ***
    '            If SplitData(2) = 0 Then

    '            ElseIf SplitData(2) = 1 Then
    '                MsgBox("Not Connect To TDC", 48, "Connect TDC")
    '            End If


    '        Case "@LOTRPT"                          '***  TDC Commu: Get Reply -> Lot Information Request  ***
    '            Content = Split(Content1, ",")
    '            If UBound(Content) >= 2 Then        ' LotReport  Return OK
    '                SendPostMessage("@LOTRPT|" & ProcessHeader & HeaderMCNo & "|" & "00")   '***  TDC Commu: ACK Lot Information Request  ***
    '                SendPostMessage("@LOTSET|" & ProcessHeader & lbMC.Text & "|" & lbLotNo.Text & "," & lbStart.Text & ",00")   ' TDC lotstart 

    '            ElseIf UBound(Content) = 1 Then       'LotReport Return NG 


    '                If Content(0) = "01" Then         'Error 01 Not Found


    '                ElseIf Content(0) = "02" Then     'Error 02 Running


    '                ElseIf Content(0) = "04" Then     'Error 04 Machine not found


    '                ElseIf Content(0) = "05" Then


    '                ElseIf Content(0) = "06" Then


    '                ElseIf Content(0) = "70" Then


    '                ElseIf Content(0) = "71" Then


    '                ElseIf Content(0) = "72" Then


    '                ElseIf Content(0) = "73" Then


    '                ElseIf Content(0) = "99" Then
    '                End If
    '                lbStatus.Show()
    '                lbStatus.Text = Content(0) & ":" & Content(1)
    '                addlogfile(lbLotNo.Text & Content(0) & ":" & Content(1))


    '            End If

    '        Case "@LOTSET"                                  '***  TDC No Handle For Right Now


    '        Case "@STRRPT"                                  '***  TDC Commu: Get Reply -> Lot Setup Report  ***
    '            SendPostMessage("@STRRPT" & "|" & ProcessHeader & HeaderMCNo & "|" & "00")         '***  TDC Commu: ACK Start Information Request  **

    '        Case "@LOTEND"                                  '***  TDC No Handle For Right Now


    '        Case "@ENDINF"                                  '***  TDC Commu: Get Reply -> Lot END Report  ***
    '            Content = Split(Content1, ",")
    '            SendPostMessage("@ENDINF|" & ProcessHeader & HeaderMCNo & "|" & "00")          '***  TDC Commu: ACK End Information Request  ***
    '            If IsNumeric(Content(0)) Then
    '                addlogfile(lbLotNo.Text & " , " & PMSRecvData)
    '                lbStatus.Show()
    '                lbStatus.Text = PMSRecvData
    '            End If
    '    End Select                                                                     'Show SelconM data change
    '    txtPostMSGRecv.Text = ""
    'End Sub

    Private Sub addlogfile(ByVal m As String)
        ' Dim logfile As String = My.Application.Info.DirectoryPath & "logtest.csv"
        Dim logfile As String = SelPath & "\LOG\TDC_Errlog.txt"
        Try
            Dim outfile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(logfile, True)
            outfile.WriteLine(Date.Now & " , " & m)
            outfile.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim sr As StreamReader = File.OpenText(logfile)
        If sr.BaseStream.Length > 900000 Then
            sr.Close()
            File.Delete(logfile)
        End If
        sr.Close()
    End Sub

#End Region

#Region "===DBX Read&Write"
    Dim bgwWrDbxSyn As Boolean = False
    Private Sub WrDBX()

        'DB.X disconnect save to PC
        If Confg.Offline Then
            OfflineLoop()
            Exit Sub
        End If
        ' == Online  ----
        If Not My.Computer.Network.IsAvailable Then
            MsgBox("PC Nework point not Open")
            Exit Sub
        End If
        If Not My.Computer.Network.Ping(_ipDbxUser) Then            'Can Pink if Computer Connect only
            MsgBox("การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้")
            Exit Sub
        End If
        DBxDataSet.MAPLMData.WriteXml(TempDataBasePath & "\" & lbMC.Text)

        If MaplmDataTableAdapter1.Update(DBxDataSet.MAPLMData.Rows(0)) = 1 Then
            If Not lbEnd.Text = "" Then                 'Del tempdatabase if lot end
                If File.Exists(TempDataBasePath & "\" & lbMC.Text) Then
                    File.Delete(TempDataBasePath & "\" & lbMC.Text)
                End If
            End If
        End If
        'Save data to PC

        ' ''tmbGgwWrDbxSyn.Enabled = True                       'Bgw Syn Mode

    End Sub

    Private Sub OfflineLoop()

        DBxDataSet.MAPLMData.WriteXml(TempDataBasePath & "\" & lbMC.Text)         'Save data to PC
        MsgBox("OffLine Mode บันทึกลง PC")

    End Sub
    Private Sub ReCoverDBx()
        'Read SelconM from PC then update to database if complete delete file
        Dim ds As New DBxDataSet
        If Directory.GetFiles(TempDataBasePath).Length = 0 Then     'Check file in folder
            Exit Sub
        End If

        For Each f In Directory.GetFiles(TempDataBasePath)
            ds.ReadXml(f)
            Dim dt As New DBxDataSet.MAPLMDataDataTable
            dt = ds.MAPLMData


            'Resync Loop -------------------
            For i = 0 To dt.Count - 1
                Me.MaplmDataTableAdapter1.LoadLot(DBxDataSet.MAPLMData, dt.Rows(i)("LotNo"), dt.Rows(i)("MCNo"), dt.Rows(i)("LotStartTime"))
                If DBxDataSet.MAPLMData.Count = 0 Then                            'If no record
                    If Me.MaplmDataTableAdapter1.Update(dt.Rows(i)) > 0 Then
                        'Kill(f)
                    End If
                Else
                    Me.DBxDataSet.MAPLMData.Rows(0).ItemArray = dt.Rows(i).ItemArray
                    If Me.MaplmDataTableAdapter1.Update(DBxDataSet.MAPLMData.Rows(0)) > 0 Then
                        'Kill(f)
                    End If
                End If
            Next
        Next


    End Sub




    Private Sub bgwWrDbx_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwWrDbx.DoWork


    End Sub

    Private Sub bgwWrDbx_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwWrDbx.RunWorkerCompleted

        ' ''bgwWrDbxSyn = False                           'Bgw Syn Mode
        ' ''tmbGgwWrDbxSyn.Enabled = False                'Bgw Syn Mode

    End Sub

    '=== Bgw Syn Mode--------------------
    ' ''Private Sub tmbGgwWrDbxSyn_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmbGgwWrDbxSyn.Tick
    ' ''    'Wait bgw Complete
    ' ''    Dim info As New Label
    ' ''    Me.Controls.Add(info)
    ' ''    info.Text = "Please Wait ...."
    ' ''    info.Location = New Point(Panel2.Location.X, Panel2.Bottom)
    ' ''    While bgwWrDbxSyn
    ' ''    End While
    ' ''    Me.Controls.Remove(info)
    ' ''    tmbGgwWrDbxSyn.Enabled = False
    ' ''End Sub
#End Region


    'Andon
    'Setting
    'Help
    'WorkRecord
    'Minimize
    'close
#Region "===  INSPECTION MODE"
    Dim ModeSelect As Mode
    Dim LB As New Label
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click, Label2.Click, Label4.Click, Label3.Click, Label6.Click, Label5.Click, Label8.Click, Label7.Click
        If Not KYB Is Nothing Then                               'Cross type of object use miss protect
            KYB.Dispose()
        End If
        If DBxDataSet.MAPLMData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        LB = CType(sender, Label)
        If Not DataPrioity() Then                               'Prohibit return false
            Exit Sub
        End If
        If ModeSelect Is Nothing Then                            'Alway control display at front
            ModeSelect = New Mode
        ElseIf Not ModeSelect.IsDisposed Then
            Exit Sub
        End If
        ModeSelect = New Mode
        Me.Panel1.Controls.Add(ModeSelect)
        ModeSelect.BringToFront()
        ModeSelect.Top = LB.Top + LB.Height
        If LB.Name = "Label7" Or LB.Name = "Label8" Or LB.Name = "Label5" Or LB.Name = "Label6" Then
            ModeSelect.Top = LB.Top - ModeSelect.Height       'Lower Control Display at Top of controls
        End If
        ModeSelect.Left = LB.Left
        ModeSelect.BackColor = System.Drawing.SystemColors.Control
        AddHandler ModeSelect.CheckedChange, AddressOf Removecontrol
    End Sub
    Private Sub Removecontrol()
        Dim row As DataRow = Me.DBxDataSet.MAPLMData.Rows(0)
        Dim index As Integer = Me.DBxDataSet.MAPLMData.Columns.IndexOf("NoMarkBe") - 1    'Get offset index of work column
        LB.Text = ModeSelect.Mode
        LB.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        Panel1.Controls.Remove(ModeSelect)

        For i = 1 To 8
            'Save to MAPDATA macth index         
            If LB.Name = "Label" & (i) Then
                row(i + index) = LB.Text                                        'Index MAPData =9 Index Label.Name=i
            End If
        Next


    End Sub

    Private Sub lbAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAll.Click
        'All A Select
        If DBxDataSet.MAPLMData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        Dim row As DataRow = Me.DBxDataSet.MAPLMData.Rows(0)
        Dim index As Integer = Me.DBxDataSet.MAPLMData.Columns.IndexOf("NoMarkBe") - 1    'Get offset index of work column
        For Each l In Panel1.Controls
            If TypeOf l Is Label Then                              'Type Mode focus filter
                Dim Lno As Integer = l.NAME.ToString.Remove(0, 5)  'Get Label No.in Panel1
                If (Lno Mod 2 = 1) Then         '1st Line
                    row(Lno + index) = "A"
                End If

            End If
        Next

        DBxDataSet.MAPLMData.Rows(0)("Andon") = "N"

    End Sub
    Private Sub Label1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseHover, Label2.MouseHover, Label4.MouseHover, Label3.MouseHover, Label6.MouseHover, Label5.MouseHover, Label8.MouseHover, Label7.MouseHover, lbAll.MouseHover

        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave, Label2.MouseLeave, Label4.MouseLeave, Label3.MouseLeave, Label6.MouseLeave, Label5.MouseLeave, Label8.MouseLeave, Label7.MouseLeave, lbAll.MouseLeave
        sender.BorderStyle = BorderStyle.None
    End Sub
    'Priority data keys check ----
    'This function when call need anyobject sender for reference target object
    ' Like >> LB = CType(sender, Label);
    Dim MarkSpec As Boolean
    Dim NoMark As Boolean
    Dim DoubleMark As Boolean
    Dim CutTin As Boolean
    Dim MisAlg As Boolean
    Private Function DataPrioity() As Boolean                       'Return False > Exit sub(Prohibit)


        'Default set ----
        MarkSpec = True
        NoMark = True
        DoubleMark = True
        CutTin = True
        MisAlg = True

        'data check index is label.name  no. ---------
        Dim LBNo As Integer = -1                                    'Check if sender isnot Label
        If LB.Name.Length > 5 Then
            LBNo = LB.Name.ToString.Remove(0, 5)                    'Get LB No
        End If

        For Each l In Panel1.Controls
            If TypeOf l Is Label Then                              'Type Mode focus filter
                Dim Lno As Integer = l.NAME.ToString.Remove(0, 5)  'Get Label No.in Panel1

                '1. Lock Afer if Before is A Mode or empty ----
                If (l.Text = "A" Or l.text = "") And (Lno = 1 Or Lno = 3 Or Lno = 5 Or Lno = 7) Then
                    If LBNo = Lno + 1 Then                          'Click LB is After
                        Return False
                        Exit Function
                    End If
                End If

                '2. Check data Empty(First condition prohibit check) ---

                If l.text = "" Then                                 'Empty = false ,Fill = true(defualt)
                    Select Case Lno
                        Case 1
                            NoMark = False

                        Case 3
                            DoubleMark = False

                        Case 5
                            CutTin = False

                        Case 7
                            MisAlg = False
                    End Select
                End If
            End If
        Next
        If lbMspec.Text = "" Then
            MarkSpec = False
        End If

        If Not LBNo = -1 Then                                   'Other no check mark
            Return True
            Exit Function
        End If

        'First condition prohibit
        If Not (MarkSpec And NoMark And DoubleMark And CutTin And MisAlg) Then
            If Not MarkSpec Then
                MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Marking spec")
            ElseIf Not NoMark Then
                MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  No Mark")

            ElseIf Not DoubleMark Then
                MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ DoubleMark")
            ElseIf Not CutTin Then
                MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ Cut Tin of Mark")
            Else
                MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Misalignment or MisPosition")
            End If

            Return False
            Exit Function
        End If
        Return True
    End Function


#End Region
    'Mode ABC User control Display 

#Region "Inspection Save"
    Private Sub FstSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FstSave.Click
        Dim Btemp As New Label
        Btemp.Name = "Label-1"
        LB = Btemp
        If Not DataPrioity() Then
            Exit Sub
        End If
        If Not lbGood.Text = "" Then
            MsgBox("ไม่สารามารถบันทึกข้อมูล 1st Save ได้เนื่องจากอยู่ในขบวนการ จบLot")
            Exit Sub
        End If
        lbGood.Enabled = True
        WrDBX()
    End Sub

    Private Sub btnFinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinal.Click

        If DBxDataSet.MAPLMData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        If lbLotJudge.Text = "" Then
            MsgBox("ยังไม่ได้ Judgement Lot")
            Exit Sub
        End If
        If Not lbNg.Text = CInt(lbInput.Text) - CInt(lbGood.Text) Then
            MsgBox("ใส่จำนวนรวม Good Ng ไม่เท่ากับ Input(Zero Control)")
            Exit Sub
        End If



        If lbLotJudge.Text = "NG" And lbGL.Text = "" Then
            MsgBox("Lot Judgement = NG ต้องใส่รหัส GLยืนยัน")
            Exit Sub

        End If

        If lbAndonJudge.Text = "Y" And lbGL.Text = "" Then
            MsgBox("Andon = Y ต้องใส่รหัส GLยืนยัน")
            Exit Sub
        End If

        If Master Then
            DBxDataSet.MAPLMData.Rows(0)("LotEndTime") = DateTimePicker1.Value
        Else
            DBxDataSet.MAPLMData.Rows(0)("LotEndTime") = Format(Now, "yyyy/MM/dd HH:mm:ss")
        End If


        DBxDataSet.MAPLMData.Rows(0)("SelfConVersion") = lbRevision.Text.Remove(0, lbRevision.Text.IndexOf("Ver "))
        DBxDataSet.MAPLMData.Rows(0)("NetVersion") = NetVer


        WrDBX()

        'SendPostMessage("@LOTEND|" & ProcessHeader & lbMC.Text & "|" & lbLotNo.Text & "," & _
        ' lbEnd.Text & "," & lbGood.Text & "," & CInt(lbInput.Text) - CInt(lbGood.Text) & ",01") 'Lot End       'Normal
        'CDate(lbEnd.Text),Format(Now, "yyyy-MM-dd HH:mm:ss")
        'Dim resEnd As TdcResponse = m_TdcService.LotEnd(ProcessHeader & lbMC.Text, lbLotNo.Text, CDate(lbEnd.Text), CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text), EndModeType.Normal, lbOp.Text)
        EndLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text, CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text))
        'EMS end
        Try
            m_EmsClient.SetOutput(lbMC.Text, CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text))
            m_EmsClient.SetLotEnd(lbMC.Text) 'LA-01
            m_EmsClient.SetActivity(lbMC.Text, "Stop", TmeCategory.StopLoss)
            btnFinal.Enabled = False
        Catch ex As Exception
            SaveLog(Message.Cellcon, "SetActivity Stop:" & ex.ToString)
        End Try
    End Sub

#End Region


#Region "=== Good NG Input"
    Private Sub lbGood_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbGood.Click, lbNg.Click, lbInput.Click
        Dim Btemp As New Label                                  'First inspec empty check
        Btemp.Name = "Label-1"
        LB = Btemp

        If Not DataPrioity() Then
            Exit Sub
        End If



        LB = CType(sender, Label)                                'Text change display label
        If Not ModeSelect Is Nothing Then                        'Cross type of object use miss protect
            ModeSelect.Dispose()
        End If
        tbxCtrl.Text = LB.Text                                          'Defult 0 when click
        tbxCtrl.Select(tbxCtrl.Text.Length, 0)
        KeyBoardCall(tbxCtrl, True)
    End Sub

    Private Sub lbGood_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbGood.MouseHover, lbNg.MouseHover, lbInput.MouseHover
        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub lbGood_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbGood.MouseLeave, lbNg.MouseLeave, lbInput.MouseLeave
        sender.BorderStyle = BorderStyle.None
    End Sub
    Private Sub tbxCtrl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxCtrl.TextChanged
        If tbxCtrl.Text = "" Then                                                        '" " Value skip for save to work datatable 
            tbxCtrl.Text = "0"
            'Exit Sub
        End If
        If tbxCtrl.Text >= Int32.MaxValue Then
            MsgBox(" ใส่ค่าได้ไม่เกิน" & Int32.MaxValue)
            Exit Sub
        End If
        LB.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        LB.Text = CInt(tbxCtrl.Text)

        Select Case LB.Name
            Case "lbGood"
                If LB.Text > CInt(lbInput.Text) Then
                    MsgBox("ใส่จำนวนเกินค่า Input ไม่ได้")
                    tbxCtrl.Text = ""
                    Exit Sub
                End If
                DBxDataSet.MAPLMData.Rows(0)("TotalGood") = LB.Text
            Case "lbNg"
                If lbGood.Text = "" Then                         'Input Good the Ng
                    Exit Sub
                End If
                'If Not LB.Text = CInt(lbInput.Text) - CInt(lbGood.Text) Then
                '    MsgBox("ใส่จำนวนรวม Good Ng ไม่เท่ากับ Input(Zero Control)")
                '    tbxCtrl.Text = ""
                '    Exit Sub
                'End If

                DBxDataSet.MAPLMData.Rows(0)("TotalNG") = LB.Text

            Case "lbInput"
                DBxDataSet.MAPLMData.Rows(0)("InputQty") = LB.Text


            Case Else
                Dim row As DataRow = Me.DBxDataSet.MAPLMData.Rows(0)
                Dim index As Integer = Me.DBxDataSet.MAPLMData.Columns.IndexOf("NoMarkBe") - 1    'Get offset index of work column
                For i = 9 To 15                                                                  'Controls in panel1 WB inspection item 
                    If LB.Name = "Label" & (i) Then
                        row(i + index) = LB.Text
                    End If
                Next

        End Select



    End Sub

#End Region
    'Good
    'ng
    'input adjust

#Region "=== Alarm data"
    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click, Label10.Click, Label15.Click, Label13.Click, Label12.Click, Label11.Click
        If DBxDataSet.MAPLMData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If


        LB = CType(sender, Label)                                'Text change display label

        If Not ModeSelect Is Nothing Then                        'Cross type of object use miss protect
            ModeSelect.Dispose()
        End If

        tbxCtrl.Text = LB.Text                                          'Defult 0 when click
        tbxCtrl.Select(tbxCtrl.Text.Length, 0)
        'tbxCtrl.Size = LB.Size
        KeyBoardCall(tbxCtrl, True)
    End Sub

    Private Sub Label9_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseHover, Label10.MouseHover, Label15.MouseHover, Label13.MouseHover, Label12.MouseHover, Label11.MouseHover
        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseLeave, Label10.MouseLeave, Label15.MouseLeave, Label13.MouseLeave, Label12.MouseLeave, Label11.MouseLeave
        sender.BorderStyle = BorderStyle.None
    End Sub
    Private Sub TextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxAlarmName.Enter, tbxRemark.Enter

        If DBxDataSet.MAPLMData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            lbMaster.Select()
            Exit Sub
        End If
        If Not KYB Is Nothing Then
            KYB.Dispose()
        End If
        KeyBoardCall(sender, False)


    End Sub

    Private Sub TextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxAlarmName.Validated, tbxRemark.Validated

        If DBxDataSet.MAPLMData.Count = 0 Then
            '    'MsgBox("ไม่มีข้อมูลการผลิต")

            Exit Sub
        End If

        sender = CType(sender, TextBox)
        If sender.TextLength > 20 Then
            MsgBox("ใส่ข้อมูลได้ไม่เกิน 20 ตัวอักษร")
            sender.Text = ""
        End If

        If sender.Name = "tbxAlarmName" Then

            DBxDataSet.MAPLMData.Rows(0)("AlmOtherName") = sender.Text

        ElseIf sender.Name = "tbxRemark" Then

            DBxDataSet.MAPLMData.Rows(0)("Remark") = sender.Text
            cbxRemark.Text = sender.text
        End If
    End Sub

    Private Sub cbxRemark_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxRemark.Click
        If DBxDataSet.MAPLMData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            lbMaster.Select()
            Exit Sub
        End If
    End Sub
    Private Sub cbxRemark_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxRemark.SelectedIndexChanged
        If DBxDataSet.MAPLMData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        DBxDataSet.MAPLMData.Rows(0)("Remark") = cbxRemark.SelectedItem
        tbxRemark.Text = cbxRemark.SelectedItem
    End Sub

#End Region
    'Alarm Freq
    'Remark

#Region "===OK/NG ,Yes/No Judge "
    Private Sub lbMspec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbMspec.Click
        If DBxDataSet.MAPLMData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If

        If lbMspec.Text = "OK" Then
            lbMspec.Text = "NG"
        Else
            lbMspec.Text = "OK"
        End If
        DBxDataSet.MAPLMData.Rows(0)("MarkingSpec") = lbMspec.Text                 'Top one data save

    End Sub
    Private Sub lbLotJudge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbLotJudge.Click
        '=== Data input incomplete check ------------------
        If DBxDataSet.MAPLMData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        If Not KYB Is Nothing Then
            KYB.Dispose()
        End If

        Dim Btemp As New Label
        Btemp.Name = "Label-1"
        LB = Btemp
        If Not DataPrioity() Then
            Exit Sub
        End If

        If lbGood.Text = "" Then
            MsgBox("ยังไม่ได้ใส่ค่า Total Goods Qty(PCS)")
            Exit Sub
        End If

        If lbNg.Text = "" Then
            MsgBox("ยังไม่ได้ใส่ค่า Total NG Qty(PCS)")
            Exit Sub
        End If

        If lbLotJudge.Text = "OK" Then
            lbLotJudge.Text = "NG"
        Else
            lbLotJudge.Text = "OK"
        End If
        DBxDataSet.MAPLMData.Rows(0)("LotJudgement") = lbLotJudge.Text
        If Master Then
            DBxDataSet.MAPLMData.Rows(0)("LotEndTime") = DateTimePicker1.Value
            DBxDataSet.MAPLMData.Rows(0)("Remark") = "INSERT LOT"
            tbxRemark.Text = "INSERT LOT"
            clickLb = True
            DateTimePicker1.Show()
        End If
    End Sub

    Private Sub lbAndonJudge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAndonJudge.Click

        If DBxDataSet.MAPLMData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If

        If lbAndonJudge.Text = "Y" Then
            lbAndonJudge.Text = "N"
            DBxDataSet.MAPLMData.Rows(0)("Andon") = "N"
        Else
            lbAndonJudge.Text = "Y"
            DBxDataSet.MAPLMData.Rows(0)("Andon") = "Y"
        End If


    End Sub

    Private Sub lbGL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbGL.Click
        If Not lbLotJudge.Text = "NG" And Not lbAndonJudge.Text = "Y" Then
            Exit Sub
        End If

        Dim QRInput As New frmInputQrCode
        QRInput.lbCaption.Text = "Input GL No."
        QRInput.ShowDialog()

    End Sub

    Private Sub lbAndonJudge_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAndonJudge.MouseHover, lbLotJudge.MouseHover, lbGL.MouseHover, lbMspec.MouseHover
        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub lbAndonJudge_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAndonJudge.MouseLeave, lbLotJudge.MouseLeave, lbGL.MouseLeave, lbMspec.MouseLeave
        sender.BorderStyle = BorderStyle.None
    End Sub


#End Region
    'Mark Spec judge
    'LotJudge
    'AndonJudge
    'GL Check

#Region "===MC List"

    Private Sub MCSettingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCSettingToolStripMenuItem.Click
        Dim str As String = InputBox("ใสชื่อเครื่องจักร", "MC Name")
        If Panel2.Controls.Count > 10 Then
            MsgBox("สามารถใส่เครื่องได้สูงสุด 10 เครื่อง")
        End If

        If str <> "" Then
            Confg.MCList(UBound(Confg.MCList)) = str.ToUpper
            Dim L As Integer = Confg.MCList.Length
            Array.Resize(Confg.MCList, L + 1)
        End If
        BuildMCList()

    End Sub
    Private Sub BuildMCList()
        Panel2.Controls.Clear()


        If Confg.MCList(0) = "" Then                        ' Ver1.02 20141226 By Prasar783
            Array.Resize(Confg.MCList, 2)
            Confg.MCList(0) = My.Settings.MCNo
        End If


        For i = 0 To Confg.MCList.Count - 2
            Dim B As New Button
            Panel2.Controls.Add(B)
            B.Font = New Font("Tahoma", 7, FontStyle.Regular)
            'B.TextAlign = ContentAlignment.MiddleLeft
            B.Size = New Size(40, 40)
            B.BackColor = Color.White
            B.Text = Confg.MCList(i)
            B.Left = 9 + (i * (B.Width + 25))
            B.ContextMenuStrip = ContextMenuStrip2
            AddHandler B.Click, AddressOf MCClick
        Next

    End Sub
    Dim RegisterEMS As Boolean = False
    Private Sub MCClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '=== Clear all display ------------

        If Not KYB Is Nothing Then                               'Cross type of object use miss protect
            KYB.Dispose()
        End If
        If Not ModeSelect Is Nothing Then
            ModeSelect.Dispose()
        End If
        '  DBxDataSet.MAPLMData.Clear()
        DBxDataSet.MAPLMData.Clear()
        DBxDataSet.TransactionData.Clear()
        'No Binding Controls ---------------
        lbStatus.Hide()
        tbxAlarmName.Text = ""
        tbxRemark.Text = ""
        lbMarkNo.Text = ""
        lbMC.Text = sender.text            'Set Click MC No.
        btnFinal.Enabled = True
        '=== Query 
        MachineOnline("MAP-" & lbMC.Text, iLibraryService.MachineOnline.Online)
        'EMS
        Try
            If RegisterEMS = False Then
                Dim reg As EmsMachineRegisterInfo = New EmsMachineRegisterInfo(lbMC.Text, "MAP-" & lbMC.Text, "MAP", My.Settings.MachineType, "", 0, 0, 0, 0, 0)
                m_EmsClient.Register(reg)
                RegisterEMS = True
            End If

        Catch ex As Exception
            SaveLog(Message.Cellcon, "EmsMachineRegisterInfo :" & ex.ToString)
        End Try




        If Not Confg.Offline Then
            If Not My.Computer.Network.IsAvailable Then
                MsgBox("PC Nework point not Open")
                Exit Sub
            End If
            If Not My.Computer.Network.Ping(_ipDbxUser) Then            'Pink OK Exit
                MsgBox("การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้")
                Exit Sub
            End If

            'Online  ReLoad Mapdata from dbx ------- 
            If Insert Then
                Insert = False
            Else
                '     Dim aaa As New DBxDataSetTableAdapters.MAPLMDataTableAdapter
                MaplmDataTableAdapter1.FillByMCno(DBxDataSet.MAPLMData, ProcessHeader & sender.text)
            End If

        Else
            'Offline ReLoad Mapdata from PC ------- 
            'Offline can not get Device ,Package
            Me.DBxDataSet.MAPLMData.Clear()
            If File.Exists(TempDataBasePath & "\" & sender.Text) Then                                         'Clear table for new query
                Me.DBxDataSet.MAPLMData.ReadXml(TempDataBasePath & "\" & sender.text)
            End If

        End If
        If Not DBxDataSet.MAPLMData.Count = 0 Then                                        'Binding Textbox
            '    On Error GoTo fin                                                             'DBNull ignore
            If Not DBxDataSet.MAPLMData.Rows(0)("AlmOtherName") Is DBNull.Value Then
                tbxAlarmName.Text = DBxDataSet.MAPLMData.Rows(0)("AlmOtherName")
            End If
            If Not DBxDataSet.MAPLMData.Rows(0)("Remark") Is DBNull.Value Then
                tbxRemark.Text = DBxDataSet.MAPLMData.Rows(0)("Remark")
            End If

fin:
        End If

        'First input ------ Count =0 
        'Reload data ------ Count >0
        If DBxDataSet.MAPLMData.Count = 0 Or (Confg.Offline And lbEnd.Text <> "") Then      'Case offline  lotendtime judge to continue

            If Confg.Offline And DBxDataSet.MAPLMData.Count > 100 Then
                MsgBox("ไม่สารารถทำการผลิต แบบ OFFLINE ต่อเนื่องเกิน 100 Lots ")
                Exit Sub
            End If

            For Each b As Button In Panel2.Controls                'Clear Err if New Input
                If b.Text = lbMC.Text Then
                    ErrorProvider1.SetError(b, "")

                End If
            Next
inputQr:
            Dim QRInput As New frmInputQrCode
            QRInput.lbCaption.Text = "Input QR Code"
            QRInput.ShowDialog()
            If Not QRInput.LotNo = "" Then
                '  SendPostMessage("@LOTREQ" & "|" & ProcessHeader & lbMC.Text & "|" & lbLotNo.Text & "," & lbOp.Text & ",00")   'Normal
                If Not SetupLot(QRInput.LotNo, ProcessHeader & lbMC.Text, QRInput.OpNo, "MAP", "0250") Then
                    GoTo inputQr
                End If


                Dim trans As TransactionData = New TransactionData(QRInput.QrCode)
                If My.Computer.Network.IsAvailable Then
                    If My.Computer.Network.Ping(_ipDbxUser) Then                                                        ' Save QR Code to transsaction table                                On Error GoTo ErrHander
                        trans.Save()

                    End If
                Else

                End If
                'Save data to MAPLMdatatable
                Dim dr As DBxDataSet.MAPLMDataRow = DBxDataSet.MAPLMData.NewRow
                dr.MCNo = ProcessHeader & lbMC.Text
                dr.LotNo = QRInput.LotNo
                dr.InputQty = QRInput.InputQty
                dr.OPNo = QRInput.OpNo
                dr.LotStartTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
                DBxDataSet.MAPLMData.Rows.InsertAt(dr, 0)

                MAPLMDataBindingSource.Position = 0          'Update new data 
                lbGood.Enabled = False


                StartLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text)
                'Dim resSet As TdcResponse = m_TdcService.LotSet(ProcessHeader & lbMC.Text, lbLotNo.Text, CDate(lbStart.Text), lbOp.Text, RunModeType.Normal)

                'EMS monitor
                Try
                    If RegisterEMS = False Then
                        m_EmsClient.SetCurrentLot(lbMC.Text, lbLotNo.Text, 0)
                        m_EmsClient.SetActivity(lbMC.Text, "Running", TmeCategory.NetOperationTime)
                    End If

                Catch ex As Exception
                    SaveLog(Message.Cellcon, "SetActivity Running:" & ex.ToString)
                End Try

                WrDBX()                                            'Save to dbx
            End If

        End If


        'Query Package(Binding) , Device(Binding) , Mark No.(Set)
        If lbLotNo.Text <> "" And Not Confg.Offline Then
            TransactionDataTableAdapter.Fill(DBxDataSet.TransactionData, lbLotNo.Text)
            lbMarkNo.Text = DBxDataSet.TransactionData(0)("MarkTextLine1") & " " & DBxDataSet.TransactionData(0)("MarkTextLine2") _
                            & " " & DBxDataSet.TransactionData(0)("MarkTextLine3")
        End If



    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        PassWord("MAP")
        If Not Pbx.Level = "MAP" Then
            Exit Sub
        End If
        'Find Object owner of contexstrip
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        'Del target object
        Dim mc As New List(Of String)
        For Each M In Panel2.Controls
            If M.text = cms.SourceControl.Text Then
                Panel2.Controls.Remove(M)
                Exit For
            End If
        Next
        For Each M In Panel2.Controls
            mc.Add(M.text)
        Next
        mc.Add(Nothing)                               '+ Notthing 
        Confg.MCList = mc.ToArray()
        BuildMCList()
    End Sub

    Private Sub lbStatus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbStatus.TextChanged
        If Not lbStatus.Text = "" Then
            For Each b As Button In Panel2.Controls
                If b.Text = lbMC.Text Then
                    ErrorProvider1.SetError(b, lbStatus.Text)
                    ErrorProvider1.SetIconAlignment(b, ErrorIconAlignment.TopRight)
                End If
            Next
        End If
    End Sub

#End Region


    'M/C Name Click
    'ErrorProvider1


#Region "Master Option"
    Public Insert As Boolean
    Dim clickLb As Boolean
    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        DBxDataSet.MAPLMData.Clear()
        DBxDataSet.TransactionData.Clear()
        lbMarkNo.Text = ""
        Insert = True

    End Sub
    Private Sub lbStart_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbStart.Click, lbEnd.Click
        If Master And Not lbStart.Text = "" Then
            DateTimePicker1.Format = DateTimePickerFormat.Custom
            DateTimePicker1.CustomFormat = "yyyy-MM-dd  HH :mm :ss"
            DateTimePicker1.Show()
            btnFinal.Enabled = True
            If sender.name = "lbEnd" Then
                clickLb = True
            Else
                clickLb = False
            End If
            DateTimePicker1.Value = lbStart.Text
        End If
    End Sub

    Private Sub lbStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbStart.MouseHover, lbEnd.MouseHover
        If Master Then
            sender.BorderStyle = BorderStyle.FixedSingle
        End If

    End Sub

    Private Sub lbStart_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbStart.MouseLeave, lbEnd.MouseLeave
        If Master Then
            sender.BorderStyle = BorderStyle.None
        End If
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If clickLb Then
            If Not lbEnd.Text = "" Then
                DBxDataSet.MAPLMData.Rows(0)("LotEndTime") = DateTimePicker1.Value
            End If
        Else
            DBxDataSet.MAPLMData.Rows(0)("LotStartTime") = DateTimePicker1.Value
        End If
    End Sub


    Private Sub lbMspec_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbMspec.TextChanged
        DateTimePicker1.Hide()
    End Sub
#End Region










#Region "===ToolBar & Common Button"
    Private Sub TDCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDCToolStripMenuItem.Click
        Dim frmTDC As SettingTDC = New SettingTDC
        frmTDC.ShowDialog()
    End Sub


    Private Sub ByAutoToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ByAutoToolStripMenuItem.Click
        Try
            Dim requestUrl As String             'Call Andon by pass parameter 161029 \783
            requestUrl = String.Format("http://webserv.thematrix.net/andontmn/Client/Default.aspx?p={0}&mc={1}&lot={2}&pkg={3}&dv={4}&line={5}&op={6}",
                                        "MAP", lbMC.Text, lbLotNo.Text, lbPackage.Text, lbDevice.Text, "", lbOp.Text)
            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe " & requestUrl, AppWinStyle.NormalFocus)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ByManualToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ByManualToolStripMenuItem.Click
        Try
            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/andontmn", AppWinStyle.NormalFocus) 'Web andon for manual M/C     'Maual input
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BMRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BMRequestToolStripMenuItem.Click
        'Dim tmpStr As String
        'Dim MCNo As String = "MAP-" & lbMC.Text
        'tmpStr = "MCNo=" & MCNo
        'tmpStr = tmpStr & "&LotNo=" & lbLotNo.Text
        'If lbStart.Text <> "" AndAlso lbEnd.Text = "" Then
        '    tmpStr = tmpStr & "&MCStatus=Running"
        'Else
        '    tmpStr = tmpStr & "&MCStatus=Stop"
        'End If

        'tmpStr = tmpStr & "&AlarmNo="
        'tmpStr = tmpStr & "&AlarmName="

        'Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainloginPD.asp?" & tmpStr, vbNormalFocus)
        'Process.Start("C:\WINDOWS\system32\osk.exe")

        Dim tmpStr As String
        tmpStr = "MCNo=" & lbMC.Text
        tmpStr = tmpStr & "&LotNo=" & lbLotNo.Text
        If lbStart.Text <> "" AndAlso lbEnd.Text = "" Then
            tmpStr = tmpStr & "&MCStatus=Running"
        Else
            tmpStr = tmpStr & "&MCStatus=Stop"
        End If

        tmpStr = tmpStr & "&AlarmNo="
        tmpStr = tmpStr & "&AlarmName="

        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainloginPD.asp?" & tmpStr, vbNormalFocus)
        ''   Process.Start("C:\WINDOWS\system32\osk.exe") '
        Process.Start("C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe")
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        On Error Resume Next
        Process.Start(Application.StartupPath & "\MapLaserManualx.pdf")
    End Sub

    Private Sub WorkRecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkRecordToolStripMenuItem.Click
        Try
            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/ERECORD/", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PMRepairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PMRepairToolStripMenuItem.Click
        Dim MCNo As String = "MAP-" & lbMC.Text
        Process.Start("C:\WINDOWS\system32\osk.exe")
        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainPMlogin.asp?" & "MCNo=" & MCNo, vbNormalFocus)


    End Sub

    Private Sub APCSStaffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles APCSStaffToolStripMenuItem.Click
        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/ApcsStaff", AppWinStyle.NormalFocus)

    End Sub



    Private Sub OnLineModeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OnLineModeToolStripMenuItem1.Click
        If Not My.Computer.Network.IsAvailable Then
            MsgBox("PC Nework point not Open")
            Exit Sub
        End If
        If Not My.Computer.Network.Ping(_ipDbxUser) Then            'Pink OK Exit
            MsgBox("การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้")
            Exit Sub
        End If

        Confg.Offline = False
        lbOffline.Visible = False
        ReCoverDBx()

        'SendPostMessage("@CNTREQ" & "|" & ProcessHeader & My.Computer.Name & "|" & "00")
        addlogfile("M/C Online Select")
    End Sub

    Private Sub MCSettingToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MCSettingToolStripMenuItem1.Click
        Dim str As String = InputBox("ใสชื่อเครื่องจักร", "MC Name")
        If Panel2.Controls.Count > 10 Then
            MsgBox("สามารถใส่เครื่องได้สูงสุด 10 เครื่อง")
        End If

        If str <> "" Then
            Confg.MCList(UBound(Confg.MCList)) = str.ToUpper
            Dim L As Integer = Confg.MCList.Length
            Array.Resize(Confg.MCList, L + 1)
        End If
        BuildMCList()
    End Sub

    Private Sub TDCToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TDCToolStripMenuItem1.Click
        Dim frmTDC As SettingTDC = New SettingTDC
        frmTDC.ShowDialog()
    End Sub

    Private Sub lbRevision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbRevision.Click
        On Error Resume Next
        Process.Start(Application.StartupPath & "\Revision.txt")
    End Sub

    Private Sub lbMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If lbMC.Text <> "lbMC" Then
            MachineOnline("MAP-" & lbMC.Text, iLibraryService.MachineOnline.Offline)
        End If

        Me.Close()
    End Sub

    Private Sub SettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingToolStripMenuItem.Click
        If My.Settings.AuthenticationUser = True Then
            ONToolStripMenuItem.CheckState = CheckState.Checked
            OFFToolStripMenuItem.CheckState = CheckState.Unchecked
        Else
            ONToolStripMenuItem.CheckState = CheckState.Unchecked
            OFFToolStripMenuItem.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub ONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ONToolStripMenuItem.Click
        My.Settings.AuthenticationUser = True
        My.Settings.Save()
    End Sub

    Private Sub OFFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OFFToolStripMenuItem.Click
        My.Settings.AuthenticationUser = False
        My.Settings.Save()
    End Sub



    'Private Sub lbAndon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/andontmn", AppWinStyle.NormalFocus) 'Web andon for manual M/C
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub lbSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ContextMenuStrip1.Show(lbSetting, New Point(0, lbSetting.Height))
    'End Sub
    'Private Sub OffLineModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OffLineModeToolStripMenuItem.Click
    '    PassWord("ENGINEER")
    '    If Not Pbx.Level = "ENGINEER" Then
    '        Exit Sub
    '    End If
    '    Confg.Offline = True                                 'OffLine Mode = true
    '    lbOffline.Visible = True
    '    addlogfile("M/C Offline Select")

    'End Sub

    'Private Sub OnLineModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnLineModeToolStripMenuItem.Click
    '    If Not My.Computer.Network.IsAvailable Then
    '        MsgBox("PC Nework point not Open")
    '        Exit Sub
    '    End If
    '    If Not My.Computer.Network.Ping(_ipDbxUser) Then            'Pink OK Exit
    '        MsgBox("การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้")
    '        Exit Sub
    '    End If

    '    Confg.Offline = False
    '    lbOffline.Visible = False
    '    ReCoverDBx()

    '    'SendPostMessage("@CNTREQ" & "|" & ProcessHeader & My.Computer.Name & "|" & "00")
    '    addlogfile("M/C Online Select")

    'End Sub
    'Private Sub lbHelp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    On Error Resume Next
    '    Process.Start(Application.StartupPath & "\MapLaserManualx.pdf")
    'End Sub


    'Private Sub lbWkRecd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/ERECORD/", AppWinStyle.NormalFocus)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub


    'Private Sub lbBMRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim tmpStr As String
    '    Dim MCNo As String = "MAP-" & lbMC.Text
    '    tmpStr = "MCNo=" & MCNo
    '    tmpStr = tmpStr & "&LotNo=" & lbLotNo.Text
    '    If lbStart.Text <> "" AndAlso lbEnd.Text = "" Then
    '        tmpStr = tmpStr & "&MCStatus=Running"
    '    Else
    '        tmpStr = tmpStr & "&MCStatus=Stop"
    '    End If

    '    tmpStr = tmpStr & "&AlarmNo="
    '    tmpStr = tmpStr & "&AlarmName="

    '    Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainloginPD.asp?" & tmpStr, vbNormalFocus)
    '    Process.Start("C:\WINDOWS\system32\osk.exe")
    'End Sub
    'Private Sub lbPMRepairing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim MCNo As String = "MAP-" & lbMC.Text
    '    Process.Start("C:\WINDOWS\system32\osk.exe")
    '    Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainPMlogin.asp?" & "MCNo=" & MCNo, vbNormalFocus)
    'End Sub
#End Region
    Public Enum Message
        Send
        Rcv
        Cellcon
    End Enum
    Public Sub SaveLog(ByVal MessageStatus As Integer, ByVal txt As String)
        Dim file_Log As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath & "\Log.txt", True)
        If MessageStatus = Message.Send Then
            file_Log.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss") & ">> Send >> " & txt)
        ElseIf MessageStatus = Message.Rcv Then
            file_Log.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss") & ">> Rcv >> " & txt)
        Else
            file_Log.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss") & " >> " & txt)
        End If

        file_Log.Close()
    End Sub
End Class
