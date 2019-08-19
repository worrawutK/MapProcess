Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
'Imports Rohm.Apcs.Tdc
Imports Rohm.Ems

Public Class Form1
    Dim m_Locker As New Object
    Private m_LotReqQueue As Queue(Of String) = New Queue(Of String)
    Dim m_LotReqMes As String
    Private m_LotSetQueue As Queue(Of String) = New Queue(Of String)
    Private m_LotEndQueue As Queue(Of String) = New Queue(Of String)

    Public m_EmsClient As EmsServiceClient = New EmsServiceClient("MAP", "http://webserv.thematrix.net:7777/EmsService")
    ' Private m_TdcService As TdcService

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
        'If File.Exists(TempPath & "\MAPPKGDCData") Then
        '    DBxDataSet.MAPPKGDCData.ReadXml(TempPath & "\MAPPKGDCData")
        'End If

        If Not Master Then
            lbMaster.Hide()
            btnInsert.Hide()
        Else
            KeysToolStripMenuItem1.Checked = True
            DBxDataBaseToolStripMenuItem1.Enabled = False
            tbxRemark.Enabled = False
            FstSave.Hide()
        End If

        If My.Settings.HasZ2Blade = True Then 'Run 2 Blade
            tbBladeLotNoZ1.Enabled = False
            tbBladeTypeZ1.Enabled = False
            tbBladeLotNoZ2.Enabled = False
            tbBladeTypeZ2.Enabled = False

        Else 'Run 1 Blade


            Label10.Enabled = False
            Label11.Enabled = False
            Label12.Enabled = False
            Label13.Enabled = False
            Label14.Enabled = False
            Label15.Enabled = False
            Label16.Enabled = False
            Label17.Enabled = False
            Label18.Enabled = False

            tbBladeLotNoZ1.Enabled = False
            tbBladeTypeZ1.Enabled = False
            tbBladeLotNoZ2.Enabled = False
            tbBladeTypeZ2.Enabled = False

            lbBladeCalZ2.Enabled = False
            lbNowBladeWearZ2.Enabled = False
            tbBladeTypeZ2.Enabled = False
            tbBladeLotNoZ2.Enabled = False
            lbBladeChangeZ2.Enabled = False

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

        For Each ctrl In Me.Controls
            If TypeOf ctrl Is Label Then
                If IsNumeric(ctrl.text) Then
                    ctrl.text = ""
                End If
            End If

        Next

        For Each lb As Label In Panel1.Controls
            If lb.Text.Contains("Z") = False Then
                lb.Text = ""
            End If

        Next
        For Each lb As Label In Panel3.Controls
            lb.Text = ""
        Next

        ''For Each lb As Label In Panel4.Controls
        ''    lb.Text = ""
        ''Next

        'TDC Check and Run ----------------------------------------------------------------------------------------------
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

    'SendPostMessage("@CNTREQ" & "|" & ProcessHeader & SelConM.McNo & "|" & "00")
    'SendPostMessage("@LOTREQ" & "|" & ProcessHeader & SelConM.McNo & "|" & SelConM.LotNo & "," & SelConM.OpNo & ",00")   'Normal
    'SendPostMessage("@LOTEND|" & ProcessHeader & SelConM.McNo & "|" & SelConM.LotNo & "," & _
    ' SelConM.EndTime & "," & SelConM.OutputPcs & "," & SelConM.InputPcs - SelConM.OutputPcs & ",01") 'Lot End       'Normal


    '******  Name of MainForm is Self Controller *******'

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
        Try
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
            DBxDataSet.MAPPKGDCData.WriteXml(TempDataBasePath & "\" & ProcessHeader & lbMC.Text)

            If MAPPKGDCDataTableAdapter.Update(DBxDataSet.MAPPKGDCData.Rows(0)) = 1 Then
                If Not lbEnd.Text = "" Then                 'Del tempdatabase if lot end
                    If File.Exists(TempDataBasePath & "\" & ProcessHeader & lbMC.Text) Then
                        File.Delete(TempDataBasePath & "\" & ProcessHeader & lbMC.Text)
                    End If
                End If
            End If
            'Save data to PC

            ' ''tmbGgwWrDbxSyn.Enabled = True                       'Bgw Syn Mode
        Catch ex As Exception
            addlogfile("End WrDBX" & ex.ToString)
            SaveLog(Message.Cellcon, "End WrDBX" & ex.ToString)
        End Try


    End Sub

    Private Sub OfflineLoop()

        DBxDataSet.MAPPKGDCData.WriteXml(TempDataBasePath & "\" & ProcessHeader & lbMC.Text)         'Save data to PC
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
            Dim dt As New DBxDataSet.MAPPKGDCDataDataTable
            dt = ds.MAPPKGDCData

            'Resync Loop -------------------
            For i = 0 To dt.Count - 1
                Me.MAPPKGDCDataTableAdapter.LoadLot(DBxDataSet.MAPPKGDCData, dt.Rows(i)("MCNo"), dt.Rows(i)("LotNo"), dt.Rows(i)("LotStartTime"))
                If DBxDataSet.MAPPKGDCData.Count = 0 Then                            'If no record
                    If Me.MAPPKGDCDataTableAdapter.Update(dt.Rows(i)) > 0 Then

                        'Kill(f)

                    End If
                Else
                    Me.DBxDataSet.MAPPKGDCData.Rows(0).ItemArray = dt.Rows(i).ItemArray
                    If Me.MAPPKGDCDataTableAdapter.Update(DBxDataSet.MAPPKGDCData.Rows(0)) > 0 Then

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

    '#Region "===ToolBar & Common Button"
    '    'Private Sub lbAndon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '    Try
    '    '        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/andontmn", AppWinStyle.NormalFocus) 'Web andon for manual M/C
    '    '    Catch ex As Exception
    '    '        MsgBox(ex.Message)
    '    '    End Try
    '    'End Sub

    '    'Private Sub lbSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '    ContextMenuStrip1.Show(lbSetting, New Point(0, lbSetting.Height))
    '    'End Sub
    '    Private Sub OffLineModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OffLineModeToolStripMenuItem.Click
    '        PassWord("ENGINEER")
    '        If Not Pbx.Level = "ENGINEER" Then
    '            Exit Sub
    '        End If
    '        Confg.Offline = True                                 'OffLine Mode = true
    '        lbOffline.Visible = True
    '        addlogfile("M/C Offline Select")
    '        KeysToolStripMenuItem1.Checked = True
    '        DBxDataBaseToolStripMenuItem1.Checked = False

    '    End Sub

    '    Private Sub OnLineModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnLineModeToolStripMenuItem.Click
    '        If Not My.Computer.Network.IsAvailable Then
    '            MsgBox("PC Nework point not Open")
    '            Exit Sub
    '        End If
    '        If Not My.Computer.Network.Ping(_ipDbxUser) Then            'Pink OK Exit
    '            MsgBox("การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้")
    '            Exit Sub
    '        End If

    '        KeysToolStripMenuItem1.Checked = False                      'Input Mode
    '        DBxDataBaseToolStripMenuItem1.Checked = True

    '        Confg.Offline = False
    '        lbOffline.Visible = False
    '        ReCoverDBx()

    '        'SendPostMessage("@CNTREQ" & "|" & ProcessHeader & My.Computer.Name & "|" & "00")
    '        addlogfile("M/C Online Select")

    '    End Sub
    '    Private Sub lbHelp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbHelp.Click
    '        On Error Resume Next
    '        Process.Start(Application.StartupPath & "\MapDCManualx.pdf")
    '    End Sub

    '    'Private Sub lbMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbMinimize.Click
    '    '    Me.WindowState = FormWindowState.Minimized
    '    'End Sub
    '    'Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
    '    '    Me.Close()
    '    'End Sub
    '    Private Sub lbWkRecd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbWkRecd.Click
    '        Try
    '            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/ERecord/", AppWinStyle.NormalFocus)
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub


    '    Private Sub DBxDataBaseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBxDataBaseToolStripMenuItem1.Click
    '        If Not Confg.Offline Then
    '            KeysToolStripMenuItem1.Checked = False
    '            DBxDataBaseToolStripMenuItem1.Checked = True
    '        End If

    '    End Sub

    '    Private Sub KeysToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeysToolStripMenuItem1.Click
    '        PassWord("ENGINEER")
    '        If Not Pbx.Level = "ENGINEER" Then
    '            Exit Sub
    '        End If
    '        KeysToolStripMenuItem1.Checked = True
    '        DBxDataBaseToolStripMenuItem1.Checked = False
    '    End Sub
    '    'Private Sub lbRevision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbRevision.Click
    '    '    On Error Resume Next
    '    '    Process.Start(Application.StartupPath & "\Revision.txt")
    '    'End Sub
    '    Private Sub NumpadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumpadToolStripMenuItem.Click
    '        If NumpadToolStripMenuItem.Checked Then
    '            NumpadToolStripMenuItem.Checked = False
    '        Else
    '            NumpadToolStripMenuItem.Checked = True
    '        End If

    '    End Sub
    '#End Region
    'Andon
    'Setting
    'Help
    'WorkRecord
    'Minimize
    'close
#Region "===  INSPECTION MODE"
    Dim ModeSelect As Mode
    Dim LB As New Label
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click, Label3.Click, Label6.Click, Label4.Click, Label9.Click, Label7.Click, Label13.Click, Label12.Click, Label10.Click, Label22.Click, Label21.Click, Label20.Click, Label19.Click, Label18.Click, Label16.Click, Label15.Click, Label26.Click, Label25.Click, Label24.Click, Label23.Click, lbLeadZ2.Click, lbLeadZ1.Click
        If Not KYB Is Nothing Then                               'Cross type of object use miss protect
            KYB.Dispose()
        End If
        If DBxDataSet.MAPPKGDCData.Count = 0 Then
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
        If LB.Name = "Label25" Or LB.Name = "Label26" Then
            ModeSelect.Top = LB.Top - ModeSelect.Height       'Lower Control Display at Top of controls
        End If
        ModeSelect.Left = LB.Left
        ModeSelect.BackColor = System.Drawing.SystemColors.Control
        AddHandler ModeSelect.CheckedChange, AddressOf Removecontrol
    End Sub
    Private Sub Removecontrol()
        Dim row As DataRow = Me.DBxDataSet.MAPPKGDCData.Rows(0)
        Dim index As Integer = Me.DBxDataSet.MAPPKGDCData.Columns.IndexOf("Z1KerfWidthBe") - 1    'Get offset index of work column
        LB.Text = ModeSelect.Mode
        LB.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        Panel1.Controls.Remove(ModeSelect)

        For i = 1 To 26
            'Save to MAPDATA macth index         
            If LB.Name = "Label" & (i) Then
                row(i + index) = LB.Text                                        'Index MAPData =9 Index Label.Name=i
            End If
        Next


    End Sub

    Private Sub lbAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAll.Click
        'All A Select
        If DBxDataSet.MAPPKGDCData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        Dim index As Integer = Me.DBxDataSet.MAPPKGDCData.Columns.IndexOf("Z1KerfWidthBe") - 1    'Get offset index of work column
        Dim row As DataRow = Me.DBxDataSet.MAPPKGDCData.Rows(0)
        For Each l As Label In Panel1.Controls
            If l.Name.Contains("Label") = True Then
                If TypeOf l Is Label Then                              'Type Mode focus filter
                    Dim Lno As Integer = l.Name.ToString.Remove(0, 5)  'Get Label No.in Panel1
                    If My.Settings.HasZ2Blade = True Then

                        If ((Lno - 1) Mod 3 = 0) And Lno < 20 Then         '1st Line
                            row(Lno + index) = "A"
                        End If
                        If (Lno = 21 Or Lno = 23 Or Lno = 25) Then
                            row(Lno + index) = "A"
                        End If

                    Else
                        'If ((Lno - 1) Mod 3 = 0) And Lno < 20 Then         '1st Line
                        '    row(Lno + index) = "A"
                        'End If
                        If (Lno = 1 Or Lno = 4 Or Lno = 7 Or Lno = 19 Or Lno = 21 Or Lno = 23 Or Lno = 25) Then
                            row(Lno + index) = "A"
                        End If
                        If Lno = 11 Or Lno = 14 Or Lno = 17 Or Lno = 10 Or Lno = 13 Or Lno = 16 Then
                            row(Lno + index) = DBNull.Value
                            l.Enabled = False
                        End If
                    End If
                End If
            End If
        Next

        For Each strDataRow As DBxDataSet.MAPPKGDCDataRow In DBxDataSet.MAPPKGDCData.Rows
            If My.Settings.HasZ2Blade = True Then
                strDataRow.Andon = "N"
                strDataRow.Z1BladeChange = ""
                strDataRow.Z2BladeChange = ""
                strDataRow.Z1BladeCarlibation = "N"
                strDataRow.Z2BladeCarlibation = "N"
                strDataRow.LeadZingScratchBe = "A"

                tbBladeLotNoZ1.Enabled = False
                tbBladeTypeZ1.Enabled = False
                tbBladeLotNoZ2.Enabled = False
                tbBladeTypeZ2.Enabled = False
            Else
                strDataRow.Andon = "N"
                strDataRow.Z1BladeChange = ""
                strDataRow.Z2BladeChange = ""
                strDataRow.Z1BladeCarlibation = "N"
                strDataRow.Z2BladeCarlibation = ""
                strDataRow.Z2BladeType = ""
                strDataRow.Z2BladeLotNo = ""
                strDataRow.LeadZingScratchBe = "A"


                tbBladeLotNoZ1.Enabled = False
                tbBladeTypeZ1.Enabled = False
                tbBladeLotNoZ2.Enabled = False
                tbBladeTypeZ2.Enabled = False

                lbBladeCalZ2.Enabled = False
                lbNowBladeWearZ2.Enabled = False
                tbBladeTypeZ2.Enabled = False
                tbBladeLotNoZ2.Enabled = False
                lbBladeChangeZ2.Enabled = False
                tbBladeLotNoZ2.Text = ""
                tbBladeTypeZ2.Text = ""

            End If


        Next




    End Sub
    Private Sub Label1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseHover, Label3.MouseHover, Label6.MouseHover, Label4.MouseHover, Label9.MouseHover, Label7.MouseHover, Label13.MouseHover, Label12.MouseHover, Label10.MouseHover, Label22.MouseHover, Label21.MouseHover, Label20.MouseHover, Label19.MouseHover, Label18.MouseHover, Label16.MouseHover, Label15.MouseHover, Label26.MouseHover, Label25.MouseHover, Label24.MouseHover, Label23.MouseHover, lbAll.MouseHover, lbLeadZ2.MouseHover, lbLeadZ1.MouseHover

        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave, Label3.MouseLeave, Label6.MouseLeave, Label4.MouseLeave, Label9.MouseLeave, Label7.MouseLeave, Label13.MouseLeave, Label12.MouseLeave, Label10.MouseLeave, Label22.MouseLeave, Label21.MouseLeave, Label20.MouseLeave, Label19.MouseLeave, Label18.MouseLeave, Label16.MouseLeave, Label15.MouseLeave, Label26.MouseLeave, Label25.MouseLeave, Label24.MouseLeave, Label23.MouseLeave, lbAll.MouseLeave, lbLeadZ2.MouseLeave, lbLeadZ1.MouseLeave
        sender.BorderStyle = BorderStyle.None
    End Sub
    'Priority data keys check ----
    'This function when call need anyobject sender for reference target object
    ' Like >> LB = CType(sender, Label);


    Private Function DataPrioity() As Boolean                       'Return False > Exit sub(Prohibit)
        Dim Inst(34) As Boolean
        If DBxDataSet.MAPPKGDCData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Function
        End If

        'Default set ----



        'data check index is label.name  no. ---------
        Dim LBNo As Integer = -1                                    'Check if sender isnot Label
        If LB.Name.Length > 5 And LB.Name.Contains("Label") = True Then
            LBNo = LB.Name.ToString.Remove(0, 5)                    'Get LB No
        End If

        For Each l As Label In Panel1.Controls
            'Type Mode focus filter
            If My.Settings.HasZ2Blade = True Then

            End If
            If l.Name.Contains("Label") = True Then
                Dim Lno As Integer = l.Name.ToString.Remove(0, 5)  'Get Label No.in Panel1

                '1. Lock Afer if Before is A Mode or empty ---- 1 to 25

                If (l.Text = "A" Or l.Text = "") And ((Lno - 1) Mod 3 = 0) And Lno < 19 Then
                    If LBNo = Lno + 2 Then                          'Click LB is After
                        Return False
                        Exit Function
                    End If
                End If

                If (l.Text = "A" Or l.Text = "") And (Lno = 19 Or Lno = 21 Or Lno = 23 Or Lno = 25) Then
                    If LBNo = Lno + 1 Then                          'Click LB is After
                        Return False
                        Exit Function
                    End If
                End If

                '2. Check data Empty(First condition prohibit check) ---

                If l.Text = "" Then                                 'Empty = false ,Fill = true(defualt)
                    Inst(Lno) = True
                End If
            End If

        Next

        If lbTableChk.Text = "" Then
            Inst(33) = True
        End If

        If Not LBNo = -1 Then                                   'Other no check mark
            Return True
            Exit Function
        End If


        'First condition prohibit
        For i = 1 To 34
            If Inst(i) Then     'Label =""
                Select Case i
                    Case 33
                        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Table Check")
                        Return False
                        Exit Function
                    Case 1
                        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Kerf Width (Z1)")
                        Return False
                        Exit Function
                    Case 4
                        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Cutting position (Z1)")
                        Return False
                        Exit Function
                    Case 7
                        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Chipping (Z1)")
                        Return False
                        Exit Function
                    Case 10
                        If My.Settings.HasZ2Blade = True Then
                            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Kerf Width (Z2)")
                            Return False
                            Exit Function
                        End If
                    Case 13
                        If My.Settings.HasZ2Blade = True Then
                            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Cutting position (Z2)")
                            Return False
                            Exit Function
                        End If
                    Case 16
                        If My.Settings.HasZ2Blade = True Then
                            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Chipping (Z2)")
                            Return False
                            Exit Function
                        End If
                    Case 19
                        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  PKG Burr")
                        Return False
                        Exit Function

                    Case 21
                        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Melt Plate")
                        Return False
                        Exit Function
                    Case 23
                        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Crack ,Chipping")
                        Return False
                        Exit Function
                    Case 25
                        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Cut depth")
                        Return False
                        Exit Function
                    Case 27
                        If LB.Text = "lbLotJudge" Then
                            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Blsde amount of wafer")
                            Return False
                            Exit Function
                        End If
                    Case 29
                        If LB.Text = "lbLotJudge" Then
                            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Blsde Change")
                            Return False
                            Exit Function
                        End If
                    Case 31
                        If LB.Text = "lbLotJudge" Then
                            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Blsde Calibration")
                            Return False
                            Exit Function
                        End If
                    Case 2, 5, 8
                        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  ค่า  Actual")
                        Return False
                        Exit Function
                    Case 11, 14, 17
                        If My.Settings.HasZ2Blade = True Then
                            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  ค่า  Actual")
                            Return False
                            Exit Function
                        End If
                End Select

            End If
        Next




        Return True
    End Function


#End Region
    'Mode ABC User control Display 
    'Data piority check

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



        WrDBX()
        If Not KYB Is Nothing Then
            KYB.Dispose()
        End If
    End Sub

    Private Sub btnFinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinal.Click
        Dim z1Wear As String = lbNowBladeWearZ1.Text
        Dim z2Wear As String = lbNowBladeWearZ2.Text


        If DBxDataSet.MAPPKGDCData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        If lbLotJudge.Text = "" Then
            MsgBox("ยังไม่ได้ Judgement Lot")
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
        If My.Settings.HasZ2Blade = True Then
            If tbBladeTypeZ1.Text = "" Or tbBladeTypeZ2.Text = "" Then
                MsgBox("กรุณากรอก BladeType Z1,Z2")
                Exit Sub
            ElseIf tbBladeLotNoZ1.Text = "" Or tbBladeLotNoZ2.Text = "" Then
                MsgBox("กรุณากรอก Blade LotNo Z1,Z2")
                Exit Sub
            ElseIf z1Wear = "" Or z2Wear = "" Then
                MsgBox("กรุณากรอก BladeWear Z1,Z2")
                Exit Sub
            ElseIf lbBladeChangeZ1.Text = "" Or lbBladeChangeZ2.Text = "" Then
                MsgBox("กรุณาเลือกโหมด  BladeChange Z1,Z2")
                Exit Sub
            End If
        Else
            If tbBladeTypeZ1.Text = "" Then
                MsgBox("กรุณากรอก BladeType Z1,Z2")
                Exit Sub
            ElseIf tbBladeLotNoZ1.Text = "" Then
                MsgBox("กรุณากรอก Blade LotNo Z1,Z2")
                Exit Sub
            ElseIf z1Wear = "" Then
                MsgBox("กรุณากรอก BladeWear Z1,Z2")
                Exit Sub
            ElseIf lbBladeChangeZ1.Text = "" Then
                MsgBox("กรุณาเลือกโหมด  BladeChange Z1,Z2")
                Exit Sub
            End If
        End If


        For Each strData As DBxDataSet.MAPPKGDCDataRow In DBxDataSet.MAPPKGDCData.Rows
            If Master Then
                strData.LotEndTime = DateTimePicker1.Value
            Else
                strData.LotEndTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
            End If
            strData.SelfConVersion = lbRevision.Text.Remove(0, lbRevision.Text.IndexOf("Ver "))
            strData.NetVersion = NetVer
            If strData.IsRemarkNull = True Then
                strData.Remark = ""
            End If

            If CInt(tbICOff.Text) <> 0 Then
                strData.ICOffQty = tbICOff.Text
            End If

            If CInt(tbMakerQty.Text) <> 0 Then
                strData.MakerQty = tbMakerQty.Text
            End If

            strData.Z1BladeType = tbBladeTypeZ1.Text
            strData.Z2BladeType = tbBladeTypeZ2.Text
            strData.Z1BladeLotNo = tbBladeLotNoZ1.Text
            strData.Z2BladeLotNo = tbBladeLotNoZ2.Text

            strData.Z1BladeAmonthWear = z1Wear
            If z2Wear <> "" Then
                strData.Z2BladeAmonthWear = z2Wear
            End If
        Next
        'If Master Then
        '    DBxDataSet.MAPPKGDCData.Rows(0)("LotEndTime") = DateTimePicker1.Value
        'Else
        '    DBxDataSet.MAPPKGDCData.Rows(0)("LotEndTime") = Format(Now, "yyyy/MM/dd HH:mm:ss")
        'End If

        'DBxDataSet.MAPPKGDCData.Rows(0)("SelfConVersion") = lbRevision.Text.Remove(0, lbRevision.Text.IndexOf("Ver "))
        'DBxDataSet.MAPPKGDCData.Rows(0)("NetVersion") = NetVer

        WrDBX()

        'SendPostMessage("@LOTEND|" & ProcessHeader & lbMC.Text & "|" & lbLotNo.Text & "," & _
        ' lbEnd.Text & "," & lbGood.Text & "," & CInt(lbInput.Text) - CInt(lbGood.Text) & ",01") 'Lot End       'Normal
        'TDC End
        EndLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text, CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text))
        'Dim resEnd As TdcResponse = m_TdcService.LotEnd(ProcessHeader & lbMC.Text, lbLotNo.Text, CDate(lbEnd.Text), CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text), EndModeType.Normal, lbOp.Text)

        'EMS end
        Try
            m_EmsClient.SetOutput(lbMC.Text, CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text))
            m_EmsClient.SetLotEnd(lbMC.Text) 'LA-01
            m_EmsClient.SetActivity(lbMC.Text, "Stop", TmeCategory.StopLoss)
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
        If NumpadToolStripMenuItem.Checked Then
            tbxCtrl.Text = ""
            tbxCtrl.Select()
        Else
            tbxCtrl.Text = LB.Text                                          'Defult 0 when click
            tbxCtrl.Select(tbxCtrl.Text.Length, 0)
            KeyBoardCall(tbxCtrl, True)
        End If

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



        If tbxCtrl.Text >= Int16.MaxValue Then
            MsgBox(" ใส่ค่าได้ไม่เกิน" & Int16.MaxValue)
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
                DBxDataSet.MAPPKGDCData.Rows(0)("TotalGood") = LB.Text
            Case "lbNg"
                If lbGood.Text = "" Then                         'Input Good the Ng
                    Exit Sub
                End If

                DBxDataSet.MAPPKGDCData.Rows(0)("TotalNG") = LB.Text

            Case "lbInput"
                DBxDataSet.MAPPKGDCData.Rows(0)("InputQty") = LB.Text


            Case Else
                Dim row As DataRow = Me.DBxDataSet.MAPPKGDCData.Rows(0)
                Dim index As Integer = Me.DBxDataSet.MAPPKGDCData.Columns.IndexOf("Z1KerfWidthBe") - 1    'Get offset index of work column
                For i = 0 To 40
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
    'Numberic input value change 

#Region "=== Alarm data"

    Private Sub Label34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label33.Click, Label34.Click, Label39.Click, Label38.Click, Label37.Click, Label36.Click, Label35.Click, Label40.Click

        If DBxDataSet.MAPPKGDCData.Count = 0 Then
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

    Private Sub Label34_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label33.MouseHover, Label34.MouseHover, Label39.MouseHover, Label38.MouseHover, Label37.MouseHover, Label36.MouseHover, Label35.MouseHover, Label40.MouseHover
        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label34_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label33.MouseLeave, Label34.MouseLeave, Label39.MouseLeave, Label38.MouseLeave, Label37.MouseLeave, Label36.MouseLeave, Label35.MouseLeave, Label40.MouseLeave
        sender.BorderStyle = BorderStyle.None
    End Sub
    Private Sub TextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxRemark.Enter
        If DBxDataSet.MAPPKGDCData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        If Not KYB Is Nothing Then
            KYB.Dispose()
        End If
        KeyBoardCall(sender, False)


    End Sub

    Private Sub TextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxRemark.Validated
        If DBxDataSet.MAPPKGDCData.Count = 0 Then
            '    'MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If

        sender = CType(sender, TextBox)
        If sender.TextLength > 20 Then
            MsgBox("ใส่ข้อมูลได้ไม่เกิน 20 ตัวอักษร")
            sender.Text = ""
        End If

        If sender.Name = "tbxAlarmName" Then

            DBxDataSet.MAPPKGDCData.Rows(0)("AlmOtherName") = sender.Text

        ElseIf sender.Name = "tbxRemark" Then
            DBxDataSet.MAPPKGDCData.Rows(0)("Remark") = sender.Text
            cbxRemark.Text = sender.text
        End If
    End Sub
    Private Sub cbxRemark_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxRemark.Click
        If DBxDataSet.MAPPKGDCData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            lbMaster.Select()
            Exit Sub
        End If
    End Sub
    Private Sub cbxRemark_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxRemark.SelectedIndexChanged
        If DBxDataSet.MAPPKGDCData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        DBxDataSet.MAPPKGDCData.Rows(0)("Remark") = cbxRemark.SelectedItem
        tbxRemark.Text = cbxRemark.SelectedItem
    End Sub
#End Region
    'Alarm Freq
    'Remark

#Region "===OK/NG ,Yes/No Judge "

    Private Sub lbLotJudge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbLotJudge.Click
        '=== Data input incomplete check ------------------
        If DBxDataSet.MAPPKGDCData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        If Not KYB Is Nothing Then
            KYB.Dispose()
        End If

        Dim Btemp As New Label
        Btemp.Name = "Label-1"
        Btemp.Text = sender.name                                     'Spectial Check
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
        If Not lbNg.Text = CInt(lbInput.Text) - CInt(lbGood.Text) Then
            MsgBox("ใส่จำนวนรวม Good Ng ไม่เท่ากับ Input(Zero Control)")
            Exit Sub
        End If

        If lbLotJudge.Text = "OK" Then
            lbLotJudge.Text = "NG"
        Else
            lbLotJudge.Text = "OK"
        End If

        DBxDataSet.MAPPKGDCData.Rows(0)("LotJudgement") = lbLotJudge.Text
        If Master Then
            DBxDataSet.MAPPKGDCData.Rows(0)("LotEndTime") = DateTimePicker1.Value
            DBxDataSet.MAPPKGDCData.Rows(0)("Remark") = "INSERT LOT"
            tbxRemark.Text = "INSERT LOT"
            clickLb = True
            DateTimePicker1.Show()
        End If
    End Sub

    Private Sub lbAndonJudge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAndonJudge.Click

        If DBxDataSet.MAPPKGDCData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If

        If lbAndonJudge.Text = "Y" Then
            lbAndonJudge.Text = "N"
            DBxDataSet.MAPPKGDCData.Rows(0)("Andon") = "N"
        Else
            lbAndonJudge.Text = "Y"
            DBxDataSet.MAPPKGDCData.Rows(0)("Andon") = "Y"
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


    Private Sub Label29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbBladeChangeZ1.Click, lbBladeChangeZ2.Click, lbBladeCalZ1.Click, lbBladeCalZ2.Click
        If DBxDataSet.MAPPKGDCData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If

        Dim lb As Label = CType(sender, Label)
        For Each strDataRow As DBxDataSet.MAPPKGDCDataRow In DBxDataSet.MAPPKGDCData.Rows
            If lb.Text = "Y" Then
                lb.Text = "N"
            Else
                lb.Text = "Y"
            End If
            Select Case lb.Name
                Case "lbBladeChangeZ1"
                    strDataRow.Z1BladeChange = lb.Text
                    If lb.Text = "Y" Then
                        tbBladeLotNoZ1.Enabled = True
                        tbBladeTypeZ1.Enabled = True
                    Else
                        tbBladeLotNoZ1.Enabled = False
                        tbBladeTypeZ1.Enabled = False
                    End If
                Case "lbBladeChangeZ2"
                    strDataRow.Z2BladeChange = lb.Text
                    If lb.Text = "Y" Then
                        tbBladeLotNoZ2.Enabled = True
                        tbBladeTypeZ2.Enabled = True
                    Else
                        tbBladeLotNoZ2.Enabled = False
                        tbBladeTypeZ2.Enabled = False
                    End If
                Case "lbBladeCalZ1"
                    strDataRow.Z1BladeCarlibation = lb.Text
                Case "lbBladeCalZ2"
                    strDataRow.Z2BladeCarlibation = lb.Text
            End Select
        Next

    End Sub

    Private Sub lbAndonJudge_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAndonJudge.MouseHover, lbLotJudge.MouseHover, lbGL.MouseHover, lbBladeChangeZ1.MouseHover, lbBladeChangeZ2.MouseHover, lbBladeCalZ1.MouseHover, lbBladeCalZ2.MouseHover, lbTableChk.MouseHover
        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub lbAndonJudge_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAndonJudge.MouseLeave, lbLotJudge.MouseLeave, lbGL.MouseLeave, lbBladeChangeZ1.MouseLeave, lbBladeChangeZ2.MouseLeave, lbBladeCalZ1.MouseLeave, lbBladeCalZ2.MouseLeave, lbTableChk.MouseLeave
        sender.BorderStyle = BorderStyle.None
    End Sub

    Private Sub lbTableChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbTableChk.Click
        If DBxDataSet.MAPPKGDCData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If

        If lbTableChk.Text = "OK" Then
            lbTableChk.Text = "NG"
        Else
            lbTableChk.Text = "OK"
        End If

        For Each strDataRow As DBxDataSet.MAPPKGDCDataRow In DBxDataSet.MAPPKGDCData.Rows
            strDataRow.TableCheck = lbTableChk.Text
            If lbNowBladeWearZ1.Text <> "" Then
                strDataRow.Z1BladeAmonthWear = lbNowBladeWearZ1.Text
            End If
            If lbNowBladeWearZ2.Text <> "" Then
                strDataRow.Z2BladeAmonthWear = lbNowBladeWearZ2.Text
            End If
        Next



    End Sub
#End Region
    'Mark Spec judge
    'LotJudge
    'AndonJudge
    'GL Check
    'Label Y/N
    'Label OK/NG


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

        'If Confg.MCList(0) = "" Then                        ' Ver1.02 20141226 By Prasar783
        '    Array.Resize(Confg.MCList, 2)
        '    Confg.MCList(0) = My.Settings.MCNo
        'End If

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
    Sub PreBladeAmonthWear()
        Dim PreLotData As DBxDataSet.MAPPKGDCDataDataTable = New DBxDataSet.MAPPKGDCDataDataTable
        MAPPKGDCDataTableAdapter.FillPreviousBladeAmonthWear(PreLotData, "MAP-" & lbMC.Text)
        If PreLotData.Rows.Count <> 0 Then
            Dim BladeWearFirst As Boolean = False
            Dim BladeType As Boolean = False
            Dim BladeWearNowFirst As Boolean = False
            For Each strDataRow As DBxDataSet.MAPPKGDCDataRow In PreLotData
                If BladeWearNowFirst = False Then
                    If strDataRow.IsZ1BladeAmonthWearNull = False Then
                        lbNowBladeWearZ1.Text = strDataRow.Z1BladeAmonthWear
                    Else
                        lbNowBladeWearZ1.Text = ""
                    End If

                    If strDataRow.IsZ2BladeAmonthWearNull = False Then
                        lbNowBladeWearZ2.Text = strDataRow.Z2BladeAmonthWear
                    Else
                        lbNowBladeWearZ2.Text = ""
                    End If

                    BladeWearNowFirst = True
                End If


                If strDataRow.IsLotEndTimeNull = False And BladeWearFirst = False Then
                    lbPreBladeWearZ1.Text = strDataRow.Z1BladeAmonthWear
                    If strDataRow.IsZ2BladeAmonthWearNull = False Then
                        lbPreBladeWearZ2.Text = strDataRow.Z2BladeAmonthWear
                    End If

                    BladeWearFirst = True
                End If

                If strDataRow.IsZ1BladeTypeNull = False And BladeType = False Then
                    BladeType = True
                    If strDataRow.IsZ1BladeTypeNull = False Then
                        tbBladeTypeZ1.Text = strDataRow.Z1BladeType
                    Else
                        tbBladeTypeZ1.Text = "-"
                    End If

                    If strDataRow.IsZ2BladeTypeNull = False Then
                        tbBladeTypeZ2.Text = strDataRow.Z2BladeType
                    Else
                        tbBladeTypeZ2.Text = "-"
                    End If

                    If strDataRow.IsZ1BladeLotNoNull = False Then
                        tbBladeLotNoZ1.Text = strDataRow.Z1BladeLotNo
                    Else
                        tbBladeLotNoZ1.Text = "-"
                    End If

                    If strDataRow.IsZ2BladeLotNoNull = False Then
                        tbBladeLotNoZ2.Text = strDataRow.Z2BladeLotNo
                    Else
                        tbBladeLotNoZ2.Text = "-"
                    End If
                End If

                If My.Settings.HasZ2Blade = False Then

                    'strDataRow.Z2BladeAmonthWear = Nothing
                    strDataRow.Z2BladeCarlibation = Nothing
                    strDataRow.Z2BladeChange = Nothing

                    tbBladeLotNoZ2.Text = ""
                    tbBladeTypeZ2.Text = ""
                    lbPreBladeWearZ2.Text = ""

                End If

            Next


        End If
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
        DBxDataSet.MAPPKGDCData.Clear()
        DBxDataSet.TransactionData.Clear()
        'No Binding Controls ---------------
        lbStatus.Hide()

        tbxRemark.Text = ""

        lbMC.Text = sender.text            'Set Click MC No.
        MachineOnline(ProcessHeader & lbMC.Text, iLibraryService.MachineOnline.Online)
        '=== Query 
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

        'EMS end

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
                Me.MAPPKGDCDataTableAdapter.FillByMCNo(DBxDataSet.MAPPKGDCData, ProcessHeader & sender.text)
                PreBladeAmonthWear()
            End If

        Else
            'Offline ReLoad Mapdata from PC ------- 
            'Offline can not get Device ,Package
            Me.DBxDataSet.MAPPKGDCData.Clear()
            If File.Exists(TempDataBasePath & "\" & ProcessHeader & sender.Text) Then                                         'Clear table for new query
                Me.DBxDataSet.MAPPKGDCData.ReadXml(TempDataBasePath & "\" & ProcessHeader & sender.text)
            End If
        End If


        If Not DBxDataSet.MAPPKGDCData.Count = 0 Then                                        'Binding Textbox
            '   On Error GoTo fin                                                             'DBNull ignore
            Try
                tbxRemark.Text = DBxDataSet.MAPPKGDCData.Rows(0)("Remark")
            Catch ex As Exception

            End Try

            'fin:
        End If

        'First input ------ Count =0 
        'Reload data ------ Count >0
        If DBxDataSet.MAPPKGDCData.Count = 0 Or (Confg.Offline And lbEnd.Text <> "") Then      'Case offline  lotendtime judge to continue

            If Confg.Offline And DBxDataSet.MAPPKGDCData.Count > 100 Then
                MsgBox("ไม่สารารถทำการผลิต แบบ OFFLINE ต่อเนื่องเกิน 100 Lots ")
                Exit Sub
            End If

            For Each b As Button In Panel2.Controls                'Clear Err if New Input
                If b.Text = lbMC.Text Then
                    ErrorProvider1.SetError(b, "")

                End If
            Next

            lbNowBladeWearZ1.Text = ""
            lbNowBladeWearZ2.Text = ""
inputQr:
            Dim QRInput As New frmInputQrCode
            QRInput.lbCaption.Text = "Input QR Code"
            tbBladeLotNoZ1.Text = ""
            tbBladeLotNoZ2.Text = ""
            tbBladeTypeZ1.Text = ""
            tbBladeTypeZ2.Text = ""

            QRInput.ShowDialog()
            If Not QRInput.lotNo = "" Then
                '  SendPostMessage("@LOTREQ" & "|" & ProcessHeader & lbMC.Text & "|" & lbLotNo.Text & "," & lbOp.Text & ",00")   'Normal
                If QRInput.IsPass = False OrElse Not SetupLot(QRInput.LotNo, ProcessHeader & lbMC.Text, QRInput.OpNo, "MAP", "0250") Then
                    GoTo inputQr
                End If
                'Save data to MAPPKGDCDatatable
                Dim dr As DBxDataSet.MAPPKGDCDataRow = DBxDataSet.MAPPKGDCData.NewRow
                dr.MCNo = ProcessHeader & lbMC.Text
                dr.LotNo = QRInput.LotNo
                dr.InputQty = QRInput.InputQty
                dr.OPNo = QRInput.OpNo
                dr.LotStartTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
                DBxDataSet.MAPPKGDCData.Rows.InsertAt(dr, 0)

                MAPPKGDCDataBindingSource.Position = 0          'Update new data 

                '    SendPostMessage("@LOTREQ" & "|" & ProcessHeader & lbMC.Text & "|" & lbLotNo.Text & "," & lbOp.Text & ",00")   'Normal
                'LotSet TDC
                Try
                    'Dim resSet As TdcResponse = m_TdcService.LotSet(ProcessHeader & lbMC.Text, lbLotNo.Text, CDate(lbStart.Text), lbOp.Text, RunModeType.Normal)
                    StartLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text)
                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                    If My.Settings.RunOffline Then
                        MsgBox("LotSet :" & ex.Message.ToString())
                    End If
                End Try

                'EMS monitor
                Try
                    m_EmsClient.SetCurrentLot(lbMC.Text, lbLotNo.Text, 0)
                    m_EmsClient.SetActivity(lbMC.Text, "Running", TmeCategory.NetOperationTime)
                Catch ex As Exception
                    SaveLog(Message.Cellcon, "SetActivity Running:" & ex.ToString)
                End Try

                '  Dim resSet As TdcResponse = m_TdcService.LotSet(ProcessHeader & lbMC.Text, lbLotNo.Text, CDate(lbStart.Text), lbOp.Text, RunModeType.Normal)

                DBxDataSet.MAPPKGDCData.Rows(0)("CutSpeed") = "30/60"
                WrDBX()                                            'Save to dbx
            End If
            tbMakerQty.Text = "0"
            tbICOff.Text = "0"
        End If


        'Query Package(Binding) , Device(Binding) , Mark No.(Set)
        If lbLotNo.Text <> "" And Not Confg.Offline Then
            Me.TransactionDataTableAdapter1.Fill(DBxDataSet.TransactionData, lbLotNo.Text)
            PreBladeAmonthWear()
        End If

        If lbBladeChangeZ1.Text = "N" Then
            tbBladeLotNoZ1.Enabled = False
            tbBladeTypeZ1.Enabled = False
        Else
            tbBladeLotNoZ1.Enabled = True
            tbBladeTypeZ1.Enabled = True
        End If
        If lbBladeChangeZ2.Text = "N" Then
            tbBladeLotNoZ2.Enabled = False
            tbBladeTypeZ2.Enabled = False
        Else
            tbBladeLotNoZ2.Enabled = True
            tbBladeTypeZ2.Enabled = True
        End If


        'SyncLock m_Locker
        '    Dim strLotReqData As String = "MAP-" & SelfData.MCNO & "," & SelfData.LotNo & "," & SelfData.LotStartMode
        '    m_LotReqQueue.Enqueue(strLotReqData)
        'End SyncLock
        'bgTDCLotReq.RunWorkerAsync()
        'AlarmMessage("โปรดรอสักครู่ . . . . ")




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

        For Each M In Panel2.Controls
            If M.text = cms.SourceControl.Text Then
                Panel2.Controls.Remove(M)
                Exit For
            End If
        Next

        Dim mc As New List(Of String)
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




#Region "===Act"
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click, Label8.Click, Label5.Click, Label14.Click, Label11.Click, Label17.Click, lbNowBladeWearZ2.Click, lbNowBladeWearZ1.Click
        If DBxDataSet.MAPPKGDCData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If


        LB = CType(sender, Label)                                'Text change display label

        If LB.Text Like "*0.*" Then
            LB.Text = CInt(LB.Text.Split(".")(1)).ToString
        End If

        If Not ModeSelect Is Nothing Then                        'Cross type of object use miss protect
            ModeSelect.Dispose()
        End If

        If NumpadToolStripMenuItem.Checked Then
            tbxCtrl.Text = ""
            tbxCtrl.Select()
        Else
            tbxCtrl.Text = LB.Text                                          'Defult 0 when click
            tbxCtrl.Select(tbxCtrl.Text.Length, 0)
            KeyBoardCall(tbxCtrl, True)
        End If



    End Sub

    Private Sub Label2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseHover, Label8.MouseHover, Label5.MouseHover, Label14.MouseHover, Label11.MouseHover, Label17.MouseHover, lbNowBladeWearZ1.MouseHover, lbNowBladeWearZ2.MouseHover, lbPreBladeWearZ2.MouseHover, lbPreBladeWearZ1.MouseHover

        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave, Label8.MouseLeave, Label5.MouseLeave, Label14.MouseLeave, Label11.MouseLeave, Label17.MouseLeave, lbNowBladeWearZ1.MouseLeave, lbNowBladeWearZ2.MouseLeave, lbPreBladeWearZ2.MouseLeave, lbPreBladeWearZ1.MouseLeave
        sender.BorderStyle = BorderStyle.None
    End Sub




#End Region

    'ACT
    'Blade amount



    Private Sub lbCutSpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbCutSpd.Click
        If lbCutSpd.Text = "30/60" Then
            DBxDataSet.MAPPKGDCData.Rows(0)("CutSpeed") = "30/30"
        Else
            DBxDataSet.MAPPKGDCData.Rows(0)("CutSpeed") = "30/60"
        End If
    End Sub

#Region "Master Option"
    Public Insert As Boolean
    Dim clickLb As Boolean


    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        DBxDataSet.MAPPKGDCData.Clear()
        DBxDataSet.TransactionData.Clear()
        Insert = True
    End Sub

    Private Sub lbStart_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbStart.Click, lbEnd.Click
        If Master And Not lbStart.Text = "" Then
            DateTimePicker1.Format = DateTimePickerFormat.Custom
            DateTimePicker1.CustomFormat = "yyyy-MM-dd  HH :mm :ss"
            DateTimePicker1.Show()
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
                DBxDataSet.MAPPKGDCData.Rows(0)("LotEndTime") = DateTimePicker1.Value
            End If
        Else
            DBxDataSet.MAPPKGDCData.Rows(0)("LotStartTime") = DateTimePicker1.Value
        End If
    End Sub


    Private Sub lbMspec_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbTableChk.TextChanged, Label1.TextChanged
        DateTimePicker1.Hide()
    End Sub
#End Region
    Private Sub lbBMRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim tmpStr As String
        Dim MCNo As String = "MAP-" & lbMC.Text
        tmpStr = "MCNo=" & MCNo
        tmpStr = tmpStr & "&LotNo=" & lbLotNo.Text
        If lbStart.Text <> "" AndAlso lbEnd.Text = "" Then
            tmpStr = tmpStr & "&MCStatus=Running"
        Else
            tmpStr = tmpStr & "&MCStatus=Stop"
        End If

        tmpStr = tmpStr & "&AlarmNo="
        tmpStr = tmpStr & "&AlarmName="

        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainloginPD.asp?" & tmpStr, vbNormalFocus)
        Process.Start("C:\WINDOWS\system32\osk.exe")
    End Sub

    Private Sub lbPMRepairing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim MCNo As String = "MAP-" & lbMC.Text
        Process.Start("C:\WINDOWS\system32\osk.exe")
        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainPMlogin.asp?" & "MCNo=" & MCNo, vbNormalFocus)
    End Sub

    Private Sub tbBladeTypeZ1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBladeTypeZ1.Click, tbBladeTypeZ2.Click, tbBladeLotNoZ1.Click, tbBladeLotNoZ2.Click
        Dim tb As TextBox = CType(sender, TextBox)
        KeyBoardCall(tb, False)
        tb.Focus()
    End Sub

    Private Sub Label50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbBladeType.Click
        'เอาค่าก่อนหน้ามาแสดง
    End Sub

    Private Sub Label51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbBladeLotNo.Click
        'เอาค่าก่อนหน้ามาแสดง
    End Sub

    Private Sub tbMakerQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbMakerQty.TextChanged, tbICOff.TextChanged
        Dim tb As TextBox = CType(sender, TextBox)
        If IsNumeric(tb.Text) = False Then
            MsgBox("กรุณาหรอกเฉพาะตัวเลข")
            Exit Sub
        End If

    End Sub

    Private Sub tbMakerQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbMakerQty.Click, tbICOff.Click
        If DBxDataSet.MAPPKGDCData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        Dim tb As TextBox = CType(sender, TextBox)
        KeyBoardCall(tb, True)
    End Sub

    Private Sub LotCancelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LotCancelToolStripMenuItem.Click
        If lbLotNo.Text = "" Then
            MsgBox("ไม่สามารถ LotCancel ได้")
            Exit Sub
        End If
        If MessageBox.Show("คุณต้องการ LotCancel แน่ใจหรือไม่ ???", "", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Dim MCno As New Label
        ' Dim LotNo As String = ""
        For Each strDataRow As DBxDataSet.MAPPKGDCDataRow In DBxDataSet.MAPPKGDCData.Rows
            MCno.Text = strDataRow.MCNo.Replace("MAP-", "")
            strDataRow.Remark = "LotCancel"
            '   LotNo = strDataRow.LotNo
        Next
        CancelLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text)
        'Dim resEnd As TdcResponse = m_TdcService.LotEnd(ProcessHeader & lbMC.Text, lbLotNo.Text, Format(Now, "yyyy-MM-dd HH:mm:ss"), 0, 0, EndModeType.AbnormalEndReset, lbOp.Text)
        'EMS end
        Try
            m_EmsClient.SetOutput(lbMC.Text, 0, 0)
            m_EmsClient.SetLotEnd(lbMC.Text) 'LA-01
            m_EmsClient.SetActivity(lbMC.Text, "Stop", TmeCategory.StopLoss)
        Catch ex As Exception
            SaveLog(Message.Cellcon, "SetActivity Stop Cancel:" & ex.ToString)
        End Try
        '     Form1.SaveLog(Form1.Message.Cellcon, "Cancel Lot" & resEnd.ErrorCode & ":" & resEnd.ErrorMessage)
        MAPPKGDCDataTableAdapter.Update(DBxDataSet.MAPPKGDCData.Rows(0))
        MCClick(MCno, EventArgs.Empty)
    End Sub

    'Private Sub TDCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDCToolStripMenuItem.Click
    '    Dim frmTDC As SettingTDC = New SettingTDC
    '    frmTDC.ShowDialog()
    'End Sub
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
        ' Process.Start("C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe")
        Process.Start("C:\WINDOWS\system32\osk.exe")
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        On Error Resume Next
        Process.Start(Application.StartupPath & "\MapDCManualx.pdf")
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
            MachineOnline(ProcessHeader & lbMC.Text, iLibraryService.MachineOnline.Offline)
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
