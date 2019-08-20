Option Strict Off

Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
'Imports Rohm.Apcs.Tdc

Imports System.IO.Ports
'Imports Rohm.Database
Imports System.ComponentModel
Imports System.Threading
Imports System.Data.SqlClient
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization
Imports Rohm.Ems
'Imports SelfCon_SANTEC.ServiceReference1

Public Class Form1
    Public m_EmsClient As EmsServiceClient = New EmsServiceClient("MAP", "http://webserv.thematrix.net:7777/EmsService")
    'One event per load
    Private Sub lbAndon_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim str As String = My.Computer.Name
        Dim F1 As New Font("ARIAL", 11, FontStyle.Regular)
        Dim sbrush As New SolidBrush(Color.Black)
        Dim g As Graphics = Me.CreateGraphics()
        g.DrawString(str, F1, sbrush, PictureBox1.Left, PictureBox1.Bottom + 15)
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MachineOnline("MAP-" & My.Settings.MCNo, iLibraryService.MachineOnline.Online)
        Try
            Dim reg As EmsMachineRegisterInfo = New EmsMachineRegisterInfo(My.Settings.MCNo, "MAP-" & My.Settings.MCNo, "MAP", My.Settings.MachineType, "", 0, 0, 0, 0, 0)
            m_EmsClient.Register(reg)
        Catch ex As Exception
            SaveLog(Message.Cellcon, "EmsMachineRegisterInfo :" & ex.ToString)
        End Try
        '   rs.FindAllControls(Me)
        Me.WindowState = FormWindowState.Maximized
        If My.Settings.Debug = True Then
            DataGridView1.Visible = True
            Button1.Visible = True
            Button5.Visible = True
            TextBox1.Visible = True
        End If
        RunMode.Text = My.Settings.RunMode
        lbMC.Text = My.Settings.MCNo

        Try
            SerialPort1.PortName = My.Settings.Comport '"COM1"
            SerialPort1.Encoding = System.Text.Encoding.GetEncoding("SHIFT-JIS")
            If SerialPort1.IsOpen Then
                SerialPort1.Close()
            End If
            SerialPort1.Open()
        Catch ex As Exception

        End Try



        'm_TdcService = TdcService.GetInstance()
        'm_TdcService.ConnectionString = My.Settings.APCSDBConnectionString

        '!! Check Comment at [On Error Resume Next] of [ Protected Overrides Sub WndProc] for test this Sub afer new edit
        initial()
        BuildMCList()
        If File.Exists(TempPath & "\MAPALData") Then
            DBxDataSet.MAPALData.ReadXml(TempPath & "\MAPALData")
        End If
        If Not Master Then
            lbMaster.Hide()
            btnInsert.Hide()
        Else
            KeysToolStripMenuItem.Checked = True
            DBxDatabaseToolStripMenuItem.Enabled = False
            tbxRemark.Enabled = False
            FstSave.Hide()
        End If
        DateTimePicker1.Hide()
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
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




        Try 'Config Load
            Confg = CType(RdXml(SelPath & "Config.xml"), Setting)

            If Confg.Offline Then
                lbOffline.Visible = True
            Else
                lbOffline.Visible = False
            End If

        Catch ex As Exception

            addlogfile("Load Config Err")

        End Try




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
#Region "===DBX Read&Write"
    Dim bgwWrDbxSyn As Boolean = False
    Public Sub WrDBX() 'DBx

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
        DBxDataSet.MAPALData.WriteXml(TempDataBasePath & "\" & lbMC.Text)

        If MAPALDataTableAdapter.Update(DBxDataSet.MAPALData.Rows(0)) = 1 Then
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

        DBxDataSet.MAPALData.WriteXml(TempDataBasePath & "\" & lbMC.Text)         'Save data to PC
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
            Dim dt As New DBxDataSet.MAPALDataDataTable
            dt = ds.MAPALData


            'Resync Loop -------------------
            For i = 0 To dt.Count - 1
                Me.MAPALDataTableAdapter.LoadLot(DBxDataSet.MAPALData, dt.Rows(i)("LotNo"), dt.Rows(i)("MCNo"), dt.Rows(i)("LotStartTime"))
                If DBxDataSet.MAPALData.Count = 0 Then                            'If no record
                    If Me.MAPALDataTableAdapter.Update(dt.Rows(i)) > 0 Then
                        'Kill(f)
                    End If
                Else
                    Me.DBxDataSet.MAPALData.Rows(0).ItemArray = dt.Rows(i).ItemArray
                    If Me.MAPALDataTableAdapter.Update(DBxDataSet.MAPALData.Rows(0)) > 0 Then
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


#End Region

    '#Region "===ToolBar & Common Button"
    'Public CellConData As New ParameterTC
    'Private Sub Label9_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles Label9.Click
    '    SerialPort1.Close()
    '    Dim frm As SettingComport = New SettingComport
    '    frm.ShowDialog()
    '    CellConData.ComPort = SerialPort1.PortName.ToString
    'End Sub
    '    Private Sub lbAndon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAndon.Click
    '        Try
    '            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/andontmn", AppWinStyle.NormalFocus) 'Web andon for manual M/C
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub lbSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbSetting.Click
    '        ContextMenuStrip1.Show(lbSetting, New Point(0, lbSetting.Height))
    '    End Sub
    '    Private Sub OffLineModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OffLineModeToolStripMenuItem.Click
    '        PassWord("ENGINEER")
    '        If Not Pbx.Level = "ENGINEER" Then
    '            Exit Sub
    '        End If
    '        Confg.Offline = True                                 'OffLine Mode = true
    '        lbOffline.Visible = True
    '        addlogfile("M/C Offline Select")
    '        KeysToolStripMenuItem.Checked = True
    '        DBxDatabaseToolStripMenuItem.Checked = False
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
    '        KeysToolStripMenuItem.Checked = False                      'Input Mode
    '        DBxDatabaseToolStripMenuItem.Checked = True

    '        Confg.Offline = False
    '        lbOffline.Visible = False
    '        ReCoverDBx()

    '        'SendPostMessage("@CNTREQ" & "|" & ProcessHeader & My.Computer.Name & "|" & "00")
    '        addlogfile("M/C Online Select")

    '    End Sub
    '    Private Sub lbHelp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbHelp.Click
    '        On Error Resume Next
    '        Process.Start(Application.StartupPath & "\MapAutoLabelerManualx.pdf")
    '    End Sub


    '    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
    '        Dim result As Integer = MessageBox.Show("ต้องการออกจากโปรแกรมหรือไม่ ?", "Message", MessageBoxButtons.YesNo)
    '        If result = DialogResult.No Then



    '        ElseIf result = DialogResult.Yes Then
    '            Me.Close()
    '        End If


    '    End Sub
    '    Private Sub lbWkRecd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbWkRecd.Click
    '        Try
    '            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/ERECORD/", AppWinStyle.NormalFocus)
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub
    '    Private Sub lbRevision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbRevision.Click
    '        On Error Resume Next
    '        Process.Start(Application.StartupPath & "\Revision.txt")
    '    End Sub

    '    Private Sub DBxDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DBxDatabaseToolStripMenuItem.Click
    '        If Not Confg.Offline Then
    '            KeysToolStripMenuItem.Checked = False
    '            DBxDatabaseToolStripMenuItem.Checked = True
    '        End If
    '    End Sub

    '    Private Sub KeysToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeysToolStripMenuItem.Click
    '        PassWord("ENGINEER")
    '        If Not Pbx.Level = "ENGINEER" Then
    '            Exit Sub
    '        End If
    '        KeysToolStripMenuItem.Checked = True
    '        DBxDatabaseToolStripMenuItem.Checked = False
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
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click, Label3.Click, Label2.Click, Label1.Click
        'If My.Settings.MAPFormat = MAP.ASE.ToString Then

        '    LB = CType(sender, Label)                                'Text change display label
        '    Dim key As KeyBoard = New KeyBoard
        '    key.TargetText = LB
        '    key.NumPad = True
        '    key.Show()
        '    Exit Sub
        'End If

        '--------------
        If Not KYB Is Nothing Then                               'Cross type of object use miss protect
            KYB.Dispose()
        End If
        'If DBxDataSet.MAPALData.Count = 0 Then
        '    MsgBox("ไม่มีข้อมูลการผลิต")
        '    Exit Sub
        'End If
        If lbInput.Text = "" Then
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
        'If LB.Name = "Label7" Or LB.Name = "Label8" Or LB.Name = "Label5" Or LB.Name = "Label6" Then
        '    ModeSelect.Top = LB.Top - ModeSelect.Height       'Lower Control Display at Top of controls
        'End If
        ModeSelect.Left = LB.Left
        ModeSelect.BackColor = System.Drawing.SystemColors.Control
        AddHandler ModeSelect.CheckedChange, AddressOf Removecontrol
    End Sub
    Private Sub Removecontrol()
        Dim row As DataRow = Me.DBxDataSet.MAPALData.Rows(0)
        Dim index As Integer = Me.DBxDataSet.MAPALData.Columns.IndexOf("LabelPosChkBe") - 1    'Get offset index of work column
        LB.Text = ModeSelect.Mode
        LB.Font = New Font("Microsoft Sans Serif", 18, FontStyle.Regular)
        Panel1.Controls.Remove(ModeSelect)

        For i = 1 To 4
            'Save to MAPDATA macth index         
            If LB.Name = "Label" & (i) Then
                row(i + index) = LB.Text                                        'Index MAPData =9 Index Label.Name=i
            End If
        Next


    End Sub

    Private Sub lbAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAll.Click
        'All A Select
        If DBxDataSet.MAPALData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        Dim row As DataRow = Me.DBxDataSet.MAPALData.Rows(0)
        Dim index As Integer = Me.DBxDataSet.MAPALData.Columns.IndexOf("LabelPosChkBe") - 1    'Get offset index of work column
        For Each l In Panel1.Controls
            If TypeOf l Is Label Then                              'Type Mode focus filter
                Dim Lno As Integer = l.NAME.ToString.Remove(0, 5)  'Get Label No.in Panel1
                If (Lno Mod 2 = 1) And Lno < 4 Then         '1st Line
                    row(Lno + index) = "A"
                End If

            End If
        Next

        DBxDataSet.MAPALData.Rows(0)("Andon") = "N"
        DBxDataSet.MAPALData.Rows(0)("ReissueLabel") = "N"
        DBxDataSet.MAPALData.Rows(0)("LabelChange") = "N"
        DBxDataSet.MAPALData.Rows(0)("StickLabelChange") = "N"
    End Sub
    Private Sub Label1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAll.MouseHover, Label4.MouseHover, Label3.MouseHover, Label2.MouseHover, Label1.MouseHover

        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAll.MouseLeave, Label4.MouseLeave, Label3.MouseLeave, Label2.MouseLeave, Label1.MouseLeave
        sender.BorderStyle = BorderStyle.None
    End Sub
    'Priority data keys check ----
    'This function when call need anyobject sender for reference target object
    ' Like >> LB = CType(sender, Label);

    Private Function DataPrioity() As Boolean                       'Return False > Exit sub(Prohibit)


        'Default set ----
        Dim Inst(9) As Boolean


        'data check index is label.name  no. ---------
        Dim LBNo As Integer = -1                                    'Check if sender isnot Label
        If LB.Name.Length > 5 Then
            LBNo = LB.Name.ToString.Remove(0, 5)                    'Get LB No
        End If

        For Each l In Panel1.Controls
            If TypeOf l Is Label Then                              'Type Mode focus filter
                Dim Lno As Integer = l.NAME.ToString.Remove(0, 5)  'Get Label No.in Panel1

                '1. Lock Afer if Before is A Mode or empty ----
                If (l.Text = "A" Or l.text = "") And (Lno = 1 Or Lno = 3) Then
                    If LBNo = Lno + 1 Then                          'Click LB is After
                        Return False
                        Exit Function
                    End If
                End If

                '2. Check data Empty(First condition prohibit check) ---
                If l.text = "" Then                                 'Empty = false ,Fill = true(defualt)
                    Inst(Lno) = True
                End If

            End If

        Next

        If Not LBNo = -1 Then                                   'Other no check mark
            Return True
            Exit Function
        End If
        For i = 1 To 9
            If Inst(i) Then 'Label =""
                Select Case i

                    Case 1
                        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Label Position")
                        Return False
                    Case 3
                        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Label Marking")
                        Return False
                    Case 5
                        If LB.Text = "lbLotJudge" Then
                            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ Label Change")
                            Return False
                        End If

                    Case 6
                        If LB.Text = "lbLotJudge" Then
                            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Sticker Label Change")
                            Return False
                        End If
                    Case 7
                        If LB.Text = "lbLotJudge" Then
                            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Re-issue Label")
                            Return False
                        End If
                    Case 8
                        If LB.Text = "lbLotJudge" Then
                            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Re-issue Label Quantity")
                            Return False
                        End If
                End Select
            End If
        Next




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
        WrDBX()
        If Not KYB Is Nothing Then
            KYB.Dispose()
        End If
    End Sub

    Private Sub btnFinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinal.Click
        If Label10.Text = "End" Then
            Exit Sub
        End If
        If DBxDataSet.MAPALData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        If lbGood.Text = "" Then
            MsgBox("ยังไม่มีจำนวนงาน Good")
            Exit Sub
        End If
        If lbLotJudge.Text = "" Then
            MsgBox("ยังไม่ได้ Judgement Lot")
            Exit Sub
        End If
        If MAPFormat = MAP.ROHM.ToString Then
            If Not lbNg.Text = CInt(lbInput.Text) - CInt(lbGood.Text) Then
                MsgBox("ใส่จำนวนรวม Good Ng ไม่เท่ากับ Input(Zero Control)")
                Exit Sub
            End If
        End If

        If lbLotJudge.Text = "NG" And lbGL.Text = "" Then
            MsgBox("Lot Judgement = NG ต้องใส่รหัส GLยืนยัน")
            Exit Sub

        End If

        If lbAndonJudge.Text = "Y" And lbGL.Text = "" Then
            MsgBox("Andon = Y ต้องใส่รหัส GLยืนยัน")
            Exit Sub
        End If

        Dim EndTime As String = Format(Now, "yyyy/MM/dd HH:mm:ss")
        If DBxDataSet.MAPALData.Rows(0)("LotStartTime") Is DBNull.Value Then
            MsgBox("ยังไม่มี LotStartTime กรุณารอ Machine run")
            Exit Sub
        End If
        If Master Then
            DBxDataSet.MAPALData.Rows(0)("LotEndTime") = DateTimePicker1.Value
        Else
            DBxDataSet.MAPALData.Rows(0)("LotEndTime") = EndTime 'Format(Now, "yyyy/MM/dd HH:mm:ss")
        End If

        DBxDataSet.MAPALData.Rows(0)("SelfConVersion") = lbRevision.Text.Remove(0, lbRevision.Text.IndexOf("Ver "))
        DBxDataSet.MAPALData.Rows(0)("NetVersion") = NetVer

        WrDBX() 'add to MAPALData

        'SendPostMessage("@LOTEND|" & ProcessHeader & lbMC.Text & "|" & lbLotNo.Text & "," & _
        ' lbEnd.Text & "," & lbGood.Text & "," & CInt(lbInput.Text) - CInt(lbGood.Text) & ",01") 'Lot End       'Normal

        ' Dim resEnd As TdcResponse = m_TdcService.LotEnd(ProcessHeader & lbMC.Text, lbLotNo.Text, Format(Now, "yyyy-MM-dd HH:mm:ss"), CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text), EndModeType.Normal, lbOp.Text)
        '  QRCode = Nothing


        Label10.Text = "End"
        If Parameter.LotNo Like "*F*" Then
            ConvertToMAP_MAPData(ProcessHeader & lbMC.Text, Parameter.LotNo, lbStart.Text, EndTime) 'add to Map_MapData
            'Parameter.QR = Nothing
            '  Parameter = Nothing

        End If
        '  If My.Settings.RunOffline = False Then
        EndLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text, CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text))
        ' Dim resEnd As TdcResponse = m_TdcService.LotEnd(ProcessHeader & lbMC.Text, lbLotNo.Text, DBxDataSet.MAPALData.Rows(0)("LotEndTime"), CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text), EndModeType.Normal, lbOp.Text)
        ' SaveLog(Message.Cellcon, lbLotNo.Text & ":" & lbOp.Text & ">>" & resEnd.ErrorCode & ":" & resEnd.ErrorMessage)
        '  End If

        'EMS end
        Try
            m_EmsClient.SetOutput(My.Settings.MCNo, CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text))
            m_EmsClient.SetLotEnd(My.Settings.MCNo) 'LA-01
            m_EmsClient.SetActivity(My.Settings.MCNo, "Stop", TmeCategory.StopLoss)
        Catch ex As Exception
            SaveLog(Message.Cellcon, "SetActivity Stop :" & ex.ToString)
        End Try



        DBxDataSet.MAPAlarmInfo.Clear()
        ' My.Settings.MAPFormat = Nothing
        MAPFormat = Nothing

    End Sub

#End Region


#Region "=== Good NG Input"
    Private Sub lbGood_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNg.Click, lbInput.Click, lbGood.Click
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

    Private Sub lbGood_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbNg.MouseHover, lbInput.MouseHover, lbGood.MouseHover
        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub lbGood_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbNg.MouseLeave, lbInput.MouseLeave, lbGood.MouseLeave
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
        LB.Font = New Font("Microsoft Sans Serif", 20, FontStyle.Regular)
        LB.Text = CInt(tbxCtrl.Text)

        Select Case LB.Name
            Case "lbGood"
                If LB.Text > CInt(lbInput.Text) Then
                    MsgBox("ใส่จำนวนเกินค่า Input ไม่ได้")
                    tbxCtrl.Text = ""
                    Exit Sub
                End If
                DBxDataSet.MAPALData.Rows(0)("TotalGood") = LB.Text
            Case "lbNg"
                If lbGood.Text = "" Then                         'Input Good the Ng
                    Exit Sub
                End If


                DBxDataSet.MAPALData.Rows(0)("TotalNG") = LB.Text

            Case "lbInput"
                DBxDataSet.MAPALData.Rows(0)("InputQty") = LB.Text


            Case Else
                Dim row As DataRow = Me.DBxDataSet.MAPALData.Rows(0)
                Dim index As Integer = Me.DBxDataSet.MAPALData.Columns.IndexOf("LabelPosChkBe") - 1    'Get offset index of work column
                For i = 8 To 8                                                              'Controls in panel1 WB inspection item 
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
    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        If DBxDataSet.MAPALData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
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

    Private Sub Label9_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseHover
        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseLeave
        sender.BorderStyle = BorderStyle.None
    End Sub
    Private Sub TextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxRemark.Enter
        If DBxDataSet.MAPALData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        If Not KYB Is Nothing Then
            KYB.Dispose()
        End If
        KeyBoardCall(sender, False)


    End Sub

    Private Sub TextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxRemark.Validated
        If DBxDataSet.MAPALData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If

        sender = CType(sender, TextBox)
        If sender.TextLength > 20 Then
            MsgBox("ใส่ข้อมูลได้ไม่เกิน 20 ตัวอักษร")
            sender.Text = ""
        End If


        If sender.Name = "tbxRemark" Then

            DBxDataSet.MAPALData.Rows(0)("Remark") = sender.Text
            cbxRemark.Text = sender.text
        End If
    End Sub
    Private Sub cbxRemark_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxRemark.Click
        If DBxDataSet.MAPALData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            lbMaster.Select()
            Exit Sub
        End If
    End Sub
    Private Sub cbxRemark_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxRemark.SelectedIndexChanged
        If DBxDataSet.MAPALData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        DBxDataSet.MAPALData.Rows(0)("Remark") = cbxRemark.SelectedItem
        tbxRemark.Text = cbxRemark.SelectedItem
    End Sub
#End Region
    'Alarm Freq
    'Remark

#Region "===OK/NG ,Yes/No Judge "

    Private Sub lbLotJudge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbLotJudge.Click
        '=== Data input incomplete check ------------------
        If DBxDataSet.MAPALData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        If Not KYB Is Nothing Then
            KYB.Dispose()
        End If

        Dim Btemp As New Label
        Btemp.Name = "Label-1"
        Btemp.Text = sender.name
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
        DBxDataSet.MAPALData.Rows(0)("LotJudgement") = lbLotJudge.Text
        If Master Then
            DBxDataSet.MAPALData.Rows(0)("LotEndTime") = DateTimePicker1.Value
            DBxDataSet.MAPALData.Rows(0)("Remark") = "INSERT LOT"
            tbxRemark.Text = "INSERT LOT"
            clickLb = True
            DateTimePicker1.Show()
        End If
    End Sub

    Private Sub lbAndonJudge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAndonJudge.Click

        If DBxDataSet.MAPALData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If

        If lbAndonJudge.Text = "Y" Then
            lbAndonJudge.Text = "N"
            DBxDataSet.MAPALData.Rows(0)("Andon") = "N"
        Else
            lbAndonJudge.Text = "Y"
            DBxDataSet.MAPALData.Rows(0)("Andon") = "Y"
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

    Private Sub lbAndonJudge_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbLotJudge.MouseHover, lbGL.MouseHover, lbAndonJudge.MouseHover, Label7.MouseHover, Label6.MouseHover, Label5.MouseHover
        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub lbAndonJudge_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbLotJudge.MouseLeave, lbGL.MouseLeave, lbAndonJudge.MouseLeave, Label7.MouseLeave, Label6.MouseLeave, Label5.MouseLeave
        sender.BorderStyle = BorderStyle.None
    End Sub
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click, Label6.Click, Label5.Click
        If DBxDataSet.MAPALData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If

        If sender.Text = "Y" Then

            Dim index As Integer = Me.DBxDataSet.MAPALData.Columns.IndexOf("LabelPosChkBe") - 1    'Get offset index of work column
            For i = 5 To 7
                If sender.Name = "Label" & (i) Then
                    DBxDataSet.MAPALData.Rows(0)(i + index) = "N"
                End If
            Next

        Else

            Dim index As Integer = Me.DBxDataSet.MAPALData.Columns.IndexOf("LabelPosChkBe") - 1    'Get offset index of work column
            For i = 5 To 7
                If sender.Name = "Label" & (i) Then
                    DBxDataSet.MAPALData.Rows(0)(i + index) = "Y"
                End If
            Next

        End If

    End Sub

#End Region
    'LotJudge
    'AndonJudge
    'GL Check
    'Y/N Label

#Region "===MC List"

    Private Sub MCSettingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCSettingToolStripMenuItem.Click
        Dim str As String = InputBox("ใสชื่อเครื่องจักร", "MC Name")
        'If Panel2.Controls.Count > 10 Then
        '    MsgBox("สามารถใส่เครื่องได้สูงสุด 10 เครื่อง")
        'End If

        If str <> "" Then
            Confg.MCList(UBound(Confg.MCList)) = str.ToUpper
            Dim L As Integer = Confg.MCList.Length
            Array.Resize(Confg.MCList, L + 1)
        End If
        BuildMCList()

    End Sub
    Private Sub BuildMCList()
        '  Panel2.Controls.Clear()

        If Confg.MCList(0) = "" Then                        ' Ver1.02 20141226 By Prasar783
            Array.Resize(Confg.MCList, 2)
            Confg.MCList(0) = My.Settings.MCNo

        End If


        For i = 0 To Confg.MCList.Count - 2
            Dim B As New Button
            '   Panel2.Controls.Add(B)
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
    Private Sub MCClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '=== Clear all display ------------
        If Not KYB Is Nothing Then                               'Cross type of object use miss protect
            KYB.Dispose()
        End If
        If Not ModeSelect Is Nothing Then
            ModeSelect.Dispose()
        End If

        DBxDataSet.MAPALData.Clear()
        DBxDataSet.TransactionData.Clear()
        'No Binding Controls ---------------
        lbStatus.Hide()
        tbxRemark.Text = ""
        lbMarkNo.Text = ""
        lbMC.Text = sender.text            'Set Click MC No.
        '=== Query 

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
                Me.MAPALDataTableAdapter.FillByMCno(DBxDataSet.MAPALData, ProcessHeader & sender.text)
            End If

        Else
            'Offline ReLoad Mapdata from PC ------- 
            'Offline can not get Device ,Package
            Me.DBxDataSet.MAPALData.Clear()
            If File.Exists(TempDataBasePath & "\" & sender.Text) Then                                         'Clear table for new query
                Me.DBxDataSet.MAPALData.ReadXml(TempDataBasePath & "\" & sender.text)
            End If

        End If
        If Not DBxDataSet.MAPALData.Count = 0 Then                                        'Binding Textbox
            On Error GoTo fin                                                             'DBNull ignore

            tbxRemark.Text = DBxDataSet.MAPALData.Rows(0)("Remark")
fin:
        End If

        'First input ------ Count =0 
        'Reload data ------ Count >0
        If DBxDataSet.MAPALData.Count = 0 Or (Confg.Offline And lbEnd.Text <> "") Then      'Case offline  lotendtime judge to continue

            If Confg.Offline And DBxDataSet.MAPALData.Count > 100 Then
                MsgBox("ไม่สารารถทำการผลิต แบบ OFFLINE ต่อเนื่องเกิน 100 Lots ")
                Exit Sub
            End If

            'For Each b As Button In Panel2.Controls                'Clear Err if New Input
            '    If b.Text = lbMC.Text Then
            '        ErrorProvider1.SetError(b, "")

            '    End If
            'Next

            Dim QRInput As New frmInputQrCode
            QRInput.lbCaption.Text = "Input QR Code"
            QRInput.ShowDialog()
            If Not lbLotNo.Text = "" Then
                '  SendPostMessage("@LOTREQ" & "|" & ProcessHeader & lbMC.Text & "|" & lbLotNo.Text & "," & lbOp.Text & ",00")   'Normal

                ' Dim resSet As TdcResponse = m_TdcService.LotSet(ProcessHeader & lbMC.Text, lbLotNo.Text, CDate(lbStart.Text), lbOp.Text, RunModeType.Normal)             
                'WrDBX()                                            'Save to dbx
            End If

        End If


        'Query Package(Binding) , Device(Binding) , Mark No.(Set)
        If lbLotNo.Text <> "" And Not Confg.Offline Then
            Me.TransactionDataTableAdapter.Fill(DBxDataSet.TransactionData, lbLotNo.Text)
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
        'For Each M In Panel2.Controls
        '    If M.text = cms.SourceControl.Text Then
        '        Panel2.Controls.Remove(M)
        '        Exit For
        '    End If
        'Next
        'For Each M In Panel2.Controls
        '    mc.Add(M.text)
        'Next
        mc.Add(Nothing)                               '+ Notthing 
        Confg.MCList = mc.ToArray()
        BuildMCList()
    End Sub

    Private Sub lbStatus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbStatus.TextChanged
        'If Not lbStatus.Text = "" Then
        '    For Each b As Button In Panel2.Controls
        '        If b.Text = lbMC.Text Then
        '            ErrorProvider1.SetError(b, lbStatus.Text)
        '            ErrorProvider1.SetIconAlignment(b, ErrorIconAlignment.TopRight)
        '        End If
        '    Next
        'End If
    End Sub

#End Region


    'M/C Name Click
    'ErrorProvider1

#Region "Master Option"
    Public Insert As Boolean
    Dim clickLb As Boolean

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        DBxDataSet.MAPALData.Clear()
        DBxDataSet.TransactionData.Clear()
        lbMarkNo.Text = ""
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
                DBxDataSet.MAPALData.Rows(0)("LotEndTime") = DateTimePicker1.Value
            End If
        Else
            DBxDataSet.MAPALData.Rows(0)("LotStartTime") = DateTimePicker1.Value
        End If
    End Sub


    Private Sub lb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbGood.TextChanged, Label1.TextChanged
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

    'Private Sub TDCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDCToolStripMenuItem.Click
    '    Dim frmTDC As SettingTDC = New SettingTDC
    '    frmTDC.ShowDialog()
    'End Sub
#Region "========================================SerialPort==============================================="
    Dim buffer As String
    'Dim file_Log As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath & "\Log.txt", True)
    '  Dim file As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter("D:\NewIPB\ipb\MAPLabel_150612\WindowsApplication1\bin\Debug\log.txt", True)
    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) _
    Handles SerialPort1.DataReceived


        buffer = buffer & SerialPort1.ReadExisting.ToString
        '  Debug.Print(SerialPort1.ReadExisting.ToString)
        Dim iret As Integer
        iret = InStr(1, buffer, vbCr)

        If iret <> 0 Then
            SaveLog(Message.Rcv, buffer)


            ProcessCmdThreadSafe(buffer)
            buffer = ""

        End If
    End Sub
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
    Private Delegate Sub ProcessCmdDelegate(ByVal buff As String)
    Public Log As ViewLog = New ViewLog
    Dim ringID As New Dictionary(Of String, String)
    Dim MachineStatus As String
    Enum StatusMC
        Setup
        Running
        StopMC
    End Enum
    Private Sub ProcessCmdThreadSafe(ByVal buff As String)

        If Me.InvokeRequired Then
            Me.Invoke(New ProcessCmdDelegate(AddressOf ProcessCmdThreadSafe), buff)
            Exit Sub
        End If
        buff = buff.Replace(vbCr, "")

        Log.TextBox1.Text &= Format(Now, "yyyy-MM-dd HH:mm:ss") & " : Rcv >> " & buff & vbCrLf
        buffer = buff
        Dim RevData() As String = Split(buffer, vbCr)
        Dim SplitData() As String = Split(RevData(0).ToUpper, ",")
        Dim HEADER As String = SplitData(0)

        Select Case HEADER
            Case "SQC"
                ScanQR()
            Case "LR" 'LR,OPNO,INPUT,KANANO,QR CODE,ShotCount
                Try

                    If SplitData(1) = "00" Then
                        'file.WriteLine("RELEASE")
                        'file.Close()
                        SaveLog(Message.Send, "RELEASE")
                        ' SerialPort1.Write("RELEASE" + Chr(13))
                        SendPLC("RELEASE")
                        Log.TextBox1.Text &= Format(Now, "yyyy-MM-dd HH:mm:ss") & " : Send >> " & "RELEASE" & vbCrLf
                    Else
                        MsgBox(SplitData(1))
                    End If

                Catch ex As Exception
                    '    addlogfile(CellConData.LotNo & " : LR :" & ex.Message)
                End Try
            Case "LS"
                Dim LotNo As String = SplitData(1)
                Label10.Text = "Running"
                Alarm = "START"

                Try
                    If DBxDataSet.MAPALData.Rows(0)("LotStartTime") Is DBNull.Value Then
                        DBxDataSet.MAPALData.Rows(0)("LotStartTime") = Format(Now, "yyyy/MM/dd HH:mm:ss")
                    Else
                        SaveLog(Message.Rcv, "Rerun")
                    End If
                Catch ex As Exception
                    SaveLog(Message.Rcv, ex.Message.ToString)
                End Try

                WrDBX() 'add to MAPALData
                StartLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text)
                'Dim resSet As TdcResponse = m_TdcService.LotSet(ProcessHeader & lbMC.Text, lbLotNo.Text, DBxDataSet.MAPALData.Rows(0)("LotStartTime"), lbOp.Text, RunModeType.Normal)



                'EMS monitor
                Try
                    m_EmsClient.SetCurrentLot(My.Settings.MCNo, lbLotNo.Text, 0)
                    m_EmsClient.SetActivity(My.Settings.MCNo, "Running", TmeCategory.NetOperationTime)
                Catch ex As Exception
                    SaveLog(Message.Cellcon, "SetActivity Running:" & ex.ToString)
                End Try
                ' End If

                '  End If


            Case "RC"

                'ringID.Add("275-00796-01", "1234F1111V01")
                'ringID.Add("275-00796-02", "1234F1111V02")
                'ringID.Add("275-00796-03", "1234F1111V03")
                'ringID.Add("275-00796-04", "1234F1111V04")

            Case "SA"
                Try
                    Label10.Text = "Running"
                Catch ex As Exception
                    '    addlogfile(CellConData.LotNo & " : SA :" & ex.Message)
                End Try

            Case "SB"
                Label10.Text = "Stop"
            Case "SC" 'SC,AlarmNo

                Try
                    If Alarm = "STOP" Or SplitData(1) = "21" Then
                        Exit Select
                    End If



                    MapAlarmTableTableAdapter1.Fill(DBxDataSet.MAPAlarmTable, CInt(SplitData(1)), My.Settings.MachineType)
                    If SplitData(2) = "01" Then

                        Dim row As DBxDataSet.MAPAlarmInfoRow = DBxDataSet.MAPAlarmInfo.NewRow
                        row.RecordTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
                        row.AlarmID = DBxDataSet.MAPAlarmTable.Rows(0).Item("ID")
                        row.LotNo = Parameter.LotNo
                        row.MCNo = ProcessHeader & My.Settings.MCNo
                        DBxDataSet.MAPAlarmInfo.Rows.Add(row)
                        ' MapAlarmInfoTableAdapter1.Update(DBxDataSet.MAPAlarmInfo)
                        '   DBxDataSet.MAPAlarmInfo.WriteXml(My.Application.Info.DirectoryPath & "\MAPAlarmInfo.xml")
                    ElseIf SplitData(2) = "00" Then
                        For Each data As DBxDataSet.MAPAlarmInfoRow In DBxDataSet.MAPAlarmInfo
                            If DBxDataSet.MAPAlarmTable.Rows(0).Item("ID") = data.AlarmID Then
                                data.ClearTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
                            End If

                        Next
                        ' MapAlarmInfoTableAdapter1.Update(DBxDataSet.MAPAlarmInfo)
                        'DBxDataSet.MAPAlarmInfo.Clear()
                    End If
                    MapAlarmInfoTableAdapter1.Update(DBxDataSet.MAPAlarmInfo)
                    ' DBxDataSet.MAPAlarmInfo.ReadXml(My.Application.Info.DirectoryPath & "\MAPAlarmInfo.xml")
                Catch ex As Exception
                    MsgBox("SC>>" & ex.Message.ToString)
                    '   addlogfile(CellConData.LotNo & " : SC :" & ex.Message)
                End Try

            Case "SD" 'SD,Goodpcs,ShotCount


                Try


                    'file.WriteLine("RELEASE")
                    'file.Close()

                    ' Log.TextBox1.Text &= Format(Now, "yyyy-MM-dd HH:mm:ss") & " : Send >> " & vbCrLf
                    'SerialPort1.Write("True" + Chr(13))
                    'Log.TextBox1.Text &= Format(Now, "yyyy-MM-dd HH:mm:ss") & " : Send >> " & "OK" & vbCrLf
                    'Exit Sub
                    ' Dim listError As List(Of String) = New List(Of String)

                    Dim ans As String
                    Dim ringList As New Dictionary(Of String, String)
                    Dim AssyLotNo As String = SplitData(1)

                    For i = 2 To (SplitData.Length - 3) Step 2
                        If SplitData(i + 1).Trim = "" Then
                            Continue For
                        End If
                        If Not ringList.ContainsKey(SplitData(i + 2).Trim.ToUpper) Then

                            'SD,1234F1111V,01,01,276-00266-02    ,02,276-00266-01    ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                ,  ,                
                            ringList.Add(SplitData(i + 2).Trim.ToUpper, SplitData(1).Trim.ToUpper & SplitData(i + 1).Trim.ToUpper) 'ASE,LOT,RingID
                            'Dim aa = ChkASEStripID(SplitData(i + 1).Trim.ToUpper)
                            'If aa Like "*Error*" Then
                            '    MsgBox(aa)
                            '    Exit Sub
                            'End If
                        End If
                        ' ans = "Error"
                    Next

                    ans = ASE_MAPConvert(ringList, AssyLotNo, lbMC.Text, lbDevice.Text, lbPackage.Text)
                    SaveLog(Message.Send, ans)
                    If ans Like "Error*" Then

                        'SerialPort1.Write("Error" + Chr(13))
                        SendPLC("Error")
                        Log.TextBox1.Text &= Format(Now, "yyyy-MM-dd HH:mm:ss") & " : Send >> " & ans & vbCrLf
                    Else

                        ' SerialPort1.Write("True" + Chr(13))
                        SendPLC("True")
                        Log.TextBox1.Text &= Format(Now, "yyyy-MM-dd HH:mm:ss") & " : Send >> " & "True" & vbCrLf

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                End Try

                'If My.Settings.Debug = True Then
                '    MsgBox(ASE_MAPConvert(ringList, AssyLotNo, "A-01", "BU52272NUZ-Z(8A)", "VSON04Z111"))
                'Else
                '    MsgBox(ASE_MAPConvert(ringList, AssyLotNo, lbMC.Text, lbDevice.Text, lbPackage.Text))
                'End If




                Dim GetData = MapDataInformGet(SplitData(1).Trim.ToUpper)

                DBxDataSet.MAPALData.Rows(0)("TotalGood") = GetData.PassTotal
                DBxDataSet.MAPALData.Rows(0)("TotalNG") = GetData.MeasureFailTotal
            Case "LE" 'LE,GOODpcs,ShotCount
                Try
                    Alarm = "STOP"
                    SaveLog(Message.Send, "LOCK")
                    '  SerialPort1.Write("LOCK" + Chr(13))
                    SendPLC("LOCK")
                    Log.TextBox1.Text &= Format(Now, "yyyy-MM-dd HH:mm:ss") & " : Send >> " & "LOCK" & vbCrLf
                Catch ex As Exception
                    ' addlogfile("LE ShotCount :" & ex.Message)
                End Try

        End Select
    End Sub
    Function ChkASEStripID(ByVal ASERingID As String) As String  'Cheeck AssyLotNo from tbl_StripMap

        Dim ans As String
        Using connect As New System.Data.SqlClient.SqlConnection
            Dim transact As System.Data.SqlClient.SqlTransaction = Nothing

            connect.ConnectionString = My.Settings.StripMapConnStr
            connect.Open()
            transact = connect.BeginTransaction
            Try
                ans = MapConvert.clsShareSub.ChkASEStripID(connect, transact, ASERingID)
                If ans Like "Error*" Then
                    If ans <> "Error: No Record Found" Then
                        transact.Rollback()
                        connect.Close()
                        Return ans
                    Else
                        transact.Rollback()
                        connect.Close()
                        Return "Error: No Data"
                    End If
                End If
                transact.Commit()
                connect.Close()

            Catch ex As Exception
                transact.Rollback()
                Return "Error : Catch Err"
            End Try
        End Using

        Return ans

    End Function
    Public Sub addErrLogfile(ByVal m As String)
        Dim logfile As String = My.Application.Info.DirectoryPath & "\LOG\ErrLog.txt"
        Try
            Dim outfile As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(logfile, True)
            outfile.WriteLine(Date.Now & " : " & m)
            outfile.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ScanQR()
        MAPFormat = Nothing
InputQr:
        Dim frm As frmInputQrCode = New frmInputQrCode
        frm.lbCaption.Text = "Input QR Code"
        ' frm.ShowDialog()
        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

            If frm.IsPass = False OrElse SetupLot(frm.LotNo, ProcessHeader & lbMC.Text, frm.OpNo, "MAP", "0288") Then
                GoTo InputQr
            End If

            Dim dr As DBxDataSet.MAPALDataRow = DBxDataSet.MAPALData.NewRow
            dr.MCNo = ProcessHeader & lbMC.Text
            dr.LotNo = frm.LotNo
            dr.InputQty = frm.InputQty
            dr.OPNo = frm.OpNo

            ' dr.LotStartTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
            DBxDataSet.MAPALData.Rows.InsertAt(dr, 0)
            MAPALDataBindingSource.Position = 0          'Update new data 


            '  Dim WorkSlipQR As New WorkingSlipQRCode
            '  WorkSlipQR.SplitQRCode(Parameter.QR)
            Dim frmRing As InputRing = New InputRing
            RingNumberAlot = My.Settings.RingNumberAlot
            RingNumberFlot = My.Settings.RingNumberFlot
            If frmRing.ShowDialog = DialogResult.OK Then

            Else
                Exit Sub
            End If
            lbLotNo.Text = Parameter.LotNo
            lbPackage.Text = Parameter.Package
            lbDevice.Text = Parameter.Device
            lbOp.Text = Parameter.OpNo
            lbInput.Text = Parameter.Input

            If Parameter.QR <> Nothing Then
                'If ChkAssyLotNo(Parameter.LotNo) Like "Error*" Then
                '    MsgBox("Check Assy Lot No.")
                '    Exit Sub
                'End If

                ' Dim b As Byte() = BitConverter.GetBytes(9)
                Dim RingQty As String
                If Parameter.LotNo.ToUpper Like "*F*" Then
                    lbRingQty.Text = RingNumberFlot
                    RingQty = ConvertDecToHex(RingNumberFlot)

                    SaveLog(Message.Send, "LR ," + RingQty + " ," + Parameter.QR)
                    '  SerialPort1.Write("LR ," + RingQty + " ," + Parameter.QR + Chr(13))
                    SendPLC("LR ," + RingQty + " ," + Parameter.QR)
                    Log.TextBox1.Text &= Format(Now, "yyyy-MM-dd HH:mm:ss") & " :Send >>> LR ," & RingQty & " ," & Parameter.QR & vbCrLf

                    MAPFormat = MAP.ASE.ToString
                    lbGood.Enabled = False
                    lbNg.Enabled = False
                    lbInput.Enabled = False


                Else
                    lbRingQty.Text = RingNumberAlot
                    RingQty = ConvertDecToHex(RingNumberAlot)
                    lbGood.Enabled = True
                    lbNg.Enabled = True
                    SaveLog(Message.Send, "LR ," + RingQty + " ," + Parameter.QR)
                    ' SerialPort1.Write("LR ," + RingQty + " ," + Parameter.QR + Chr(13))
                    SendPLC("LR ," + RingQty + " ," + Parameter.QR)
                    Log.TextBox1.Text &= Format(Now, "yyyy-MM-dd HH:mm:ss") & " :Send >>> LR ," & RingQty & " ," & Parameter.QR & vbCrLf
                    MAPFormat = MAP.ROHM.ToString
                    '  My.Settings.MAPFormat = MAP.ROHM.ToString
                End If
                'Query Package(Binding) , Device(Binding) , Mark No.(Set)
                '  If lbLotNo.Text <> "" And Not Confg.Offline Then
                Me.TransactionDataTableAdapter.Fill(DBxDataSet.TransactionData, Parameter.LotNo)
                If DBxDataSet.TransactionData.Count <> 0 Then
                    lbMarkNo.Text = DBxDataSet.TransactionData(0)("MarkTextLine1") & " " & DBxDataSet.TransactionData(0)("MarkTextLine2") _
                                   & " " & DBxDataSet.TransactionData(0)("MarkTextLine3")
                End If

                'End If
                Label10.Text = "LOTSET"
                lbLotJudge.Text = Nothing
                'Parameter.QR = Nothing
            End If

            If RunMode.Text = "Manual" Then
                If Parameter.LotNo Like "*F*" Then
                    Dim frmASE As ScanASEID = New ScanASEID
                    frmASE.AssyLot = Parameter.LotNo
                    If frmASE.ShowDialog() = DialogResult.OK Then
                        ProcessCmdThreadSafe("LS," & Parameter.LotNo & Chr(13))
                        ProcessCmdThreadSafe(frmASE.Message & Chr(13))
                    End If
                Else
                    ProcessCmdThreadSafe("LS," & Parameter.LotNo & Chr(13))
                End If

            End If
        End If




    End Sub
    Function ConvertDecToHex(Number As Integer) As String

        'Dim Unit As String = (Number Mod 16).ToString
        'Select Case Unit
        '    Case "10"
        '        Unit = "A"
        '    Case "11"
        '        Unit = "B"
        '    Case "12"
        '        Unit = "C"
        '    Case "13"
        '        Unit = "D"
        '    Case "14"
        '        Unit = "E"
        '    Case "15"
        '        Unit = "F"
        'End Select
        'Dim Result As Double = 0
        'Result = Number \ 16
        'Return (Result & Unit).ToString
        Dim Result As String
        Result = Hex(Number).ToString
        If Result.Length <= 1 Then
            Result = "0" & Result
        End If

        Return Result
    End Function

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        If (lbEnd.Text = "" AndAlso lbStart.Text <> "") Or (lbLotNo.Text <> "" AndAlso lbStart.Text = "" AndAlso lbEnd.Text = "") Then '
            Dim result As Integer = MessageBox.Show("Lot นี้ยังไม่จบต้องการ Rerun หรือไม่ ?", "Confirm", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                ScanQR()
            ElseIf result = DialogResult.Yes Then
                Dim RingQty As String
                If Parameter.LotNo.ToUpper Like "*F*" Then
                    lbRingQty.Text = RingNumberFlot
                    RingQty = ConvertDecToHex(RingNumberFlot)
                Else
                    lbRingQty.Text = RingNumberAlot
                    RingQty = ConvertDecToHex(RingNumberAlot)
                End If
                SaveLog(Message.Send, "LR ," + RingQty + " ," + Parameter.QR)
                '  SerialPort1.Write("LR ," + RingQty + " ," + Parameter.QR + Chr(13))
                SendPLC("LR ," + RingQty + " ," + Parameter.QR)
                Log.TextBox1.Text &= Format(Now, "yyyy-MM-dd HH:mm:ss") & " :Send >>> LR ," & RingQty & " ," & Parameter.QR & vbCrLf
            End If
        Else
            ScanQR()
        End If



    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem1.Click
        Log = New ViewLog
        Log.Show()
    End Sub

#End Region
#Region "ASE MapConvert"

    Dim ZIP_TEMP_PATH As String = My.Application.Info.DirectoryPath & "\Zip_TEMP"
    Dim RECIPE_PATH As String = My.Application.Info.DirectoryPath & "\RECIPE"
    ' RingID As Dictionary(ASE_RingID, Rohm_RingID)
    Public Function ASE_MAPConvert(ByVal RingID As Dictionary(Of String, String), ByVal AssyLotNo As String, ByVal McNo As String, ByVal Device As String, ByVal Package As String) As String
        If Not AssyLotNo Like "*F*" Then
            Return "Error : Lot is not F Lot"
        End If
        Dim ans As String
        Using connect As New System.Data.SqlClient.SqlConnection           'tbl_stripMap table on stripMapdb
            Dim transact As System.Data.SqlClient.SqlTransaction = Nothing
            connect.ConnectionString = My.Settings.StripMapConnStr
            connect.Open()
            transact = connect.BeginTransaction
            Try

                For Each item In RingID
                    Debug.Print("MapConvert")
                    ans = MapConvert.clsShareSub.GetASEStripMapData(connect, transact, item.Key, AssyLotNo, item.Value)
                    If ans Like "Error*" Then
                        transact.Rollback()
                        connect.Close()
                        Return ans & "_GetASEStripMapData"
                    End If
                Next
                transact.Commit()
                connect.Close()
            Catch ex As Exception
                transact.Rollback()
                Return "Error : Catch Err"
            End Try

            ans = MapConvert.clsShareSub.XML_Marge(McNo, AssyLotNo, Device, Package.ToUpper.Trim, RingID.Count, RECIPE_PATH, ZIP_TEMP_PATH)
            If ans Like "Error*" Then
                Return ans & "_XML_Marge"
            End If
        End Using


        'Using Dbxconnect As New System.Data.SqlClient.SqlConnection             'MapMapdata table on dbx
        '    Dim transact As System.Data.SqlClient.SqlTransaction = Nothing
        '    Dbxconnect.ConnectionString = My.Settings.DBxConnectionString
        '    Dbxconnect.Open()
        '    transact = Dbxconnect.BeginTransaction
        '    Try
        '        ans = MapConvert.clsShareSub.ASEStripInputLot(Dbxconnect, transact, McNo, AssyLotNo, "OS", "OS_NEW", ZIP_TEMP_PATH & "\" & AssyLotNo & ".zip", AssyLotStartTime, AssyLotEndTime, Remark)
        '        If ans Like "Error*" Then
        '            transact.Rollback()
        '            Dbxconnect.Close()
        '            MsgBox("ASEStripInputLot :" & ans)
        '            Return ans & "_ASEStripInputLot"
        '        End If
        '        transact.Commit()
        '        Dbxconnect.Close()
        '    Catch ex As Exception
        '        transact.Rollback()
        '        Return "Error : Catch Err"
        '    End Try

        'End Using
        Return ans

    End Function
    Private Function ConvertToMAP_MAPData(ByVal McNo As String, ByVal AssyLotNo As String, ByVal AssyLotStartTime As Date, ByVal AssyLotEndTime As Date, Optional ByVal Remark As String = "") As String
        Dim ans As String
        Using Dbxconnect As New System.Data.SqlClient.SqlConnection             'MapMapdata table on dbx
            Dim transact As System.Data.SqlClient.SqlTransaction = Nothing
            Dbxconnect.ConnectionString = My.Settings.DBxConnectionString
            Dbxconnect.Open()
            transact = Dbxconnect.BeginTransaction
            Try
                ans = MapConvert.clsShareSub.ASEStripInputLot(Dbxconnect, transact, McNo, AssyLotNo, "OS", "OS_NEW", ZIP_TEMP_PATH & "\" & AssyLotNo & ".zip", AssyLotStartTime, AssyLotEndTime, Remark)
                If ans Like "Error*" Then
                    transact.Rollback()
                    Dbxconnect.Close()
                    MsgBox("ASEStripInputLot :" & ans)
                    Return ans & "_ASEStripInputLot"
                End If
                transact.Commit()
                Dbxconnect.Close()
            Catch ex As Exception
                transact.Rollback()
                Return "Error : Catch Err"
            End Try

        End Using
        Return ans
    End Function
    Private Sub GetData()
        Dim aa = MapDataInformGet("1234F1111V")
aa:
    End Sub
    Function MapDataInformGet(ByVal AssyLotNo As String) As MapConvert.clsMapData

        Try
            Dim mapclass As MapConvert.clsMapData = MapConvert.clsMap.getMapData(ZIP_TEMP_PATH & "\" & AssyLotNo & ".zip")
            Return mapclass
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    'Cancel before rerun ASE Ring
    Public Function CancelASEStrip(ByVal AssyLotNo As String) As String
        If Not AssyLotNo Like "*F*" Then
            Return "Error : Lot is not F Lot"
        End If
        Dim ans As String
        Using connect As New System.Data.SqlClient.SqlConnection
            Dim transact As System.Data.SqlClient.SqlTransaction = Nothing
            connect.ConnectionString = My.Settings.StripMapConnStr
            connect.Open()
            transact = connect.BeginTransaction
            Try
                ans = MapConvert.clsShareSub.CancelASEStrip(connect, transact, AssyLotNo)
                If ans Like "Error*" Then
                    transact.Rollback()
                    connect.Close()
                    Return ans & "_CancelASEStrip"
                End If
                transact.Commit()
                connect.Close()

            Catch ex As Exception
                transact.Rollback()
                Return "Error : Catch Err"
            End Try
        End Using

        Try
            'Delete All in ZipFile Path
            For Each deleteFile In IO.Directory.GetFiles(ZIP_TEMP_PATH, "*.*", IO.SearchOption.TopDirectoryOnly)
                IO.File.Delete(deleteFile)
            Next

        Catch ex As Exception

        End Try

        Return ans

    End Function
    Function ChkAssyLotNo(ByVal AssyLotNo As String) As String   'Cheeck AssyLotNo from tbl_StripMap
        If Not AssyLotNo Like "*F*" Then
            Return "Error : Lot is not F Lot"
        End If
        Dim ans As String
        Using connect As New System.Data.SqlClient.SqlConnection
            Dim transact As System.Data.SqlClient.SqlTransaction = Nothing

            connect.ConnectionString = My.Settings.StripMapConnStr
            connect.Open()
            transact = connect.BeginTransaction
            Try
                ans = MapConvert.clsShareSub.ChkAssyLotNo(connect, transact, AssyLotNo)
                If ans Like "Error*" Then
                    If ans <> "Error: No Record Found" Then
                        transact.Rollback()
                        connect.Close()
                        Return ans
                    Else
                        transact.Rollback()
                        connect.Close()
                        Return "Error: No Data"
                    End If
                End If
                transact.Commit()
                connect.Close()

            Catch ex As Exception
                transact.Rollback()
                Return "Error : Catch Err"
            End Try
        End Using
        Return ans
    End Function
#End Region

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        CancelASEStrip("1910F4057V")
        Dim ringList As New Dictionary(Of String, String)
        ringList.Add("28Z-01311-05", "1910F4057V01")
        ringList.Add("28Z-01311-06", "1910F4057V02")
        ringList.Add("28Z-01311-07", "1910F4057V03")
        ringList.Add("28Z-01311-08", "1910F4057V04")
        MsgBox(ASE_MAPConvert(ringList, "1910F4057V", "A-01", "BU52272NUZ-ZA(X8G)", "VSON04Z111"))


        '     ProcessCmdThreadSafe(TextBox1.Text & Chr(13))
        'SerialPort1.PortName = "COM14"
        'If SerialPort1.IsOpen Then
        '    SerialPort1.Close()
        'End If
        'SerialPort1.Open()
        'SerialPort1.BaudRate = 9600
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        GetData()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        CancelASEStrip("1910F4057V")
        If Parameter.LotNo = Nothing Then
            MsgBox("กรุณา Scan QR Code ที่จะทำการ Cancel Lot")
        Else
            MsgBox(CancelASEStrip(Parameter.LotNo))
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        MsgBox(TextBox1.Text.Length)
        'ProcessCmdThreadSafe(TextBox1.Text & Chr(13))
        'TextBox1.Text = Nothing
    End Sub

    'Private Sub LoadLotToolStripButton_Click(sender As Object, e As EventArgs)
    '    Try
    '        Me.MAPALDataTableAdapter.LoadLot(Me.DBxDataSet.MAPALData, LotnoToolStripTextBox.Text, McnoToolStripTextBox.Text, New System.Nullable(Of Date)(CType(StartTimeToolStripTextBox.Text, Date)))
    '    Catch ex As System.Exception
    '        System.Windows.Forms.MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'CHECK ASE LOT NO.
        'if ...
        'MsgBox("No ASE Lot No.")
        'Parameter = Nothing
        'MAPFormat=Nothing

        Dim frm As CHECK_ASE_LOT = New CHECK_ASE_LOT
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'set val
        End If
    End Sub


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        '   Dim Point As Point = New Point(500, 500)
        '   Me.Size = Point
        '  CancelASEStrip(Parameter.LotNo)
        frmInputQrCode.CheckLot()

        ''DBxDataSet.MAPALData.WriteXml(My.Application.Info.DirectoryPath & "\MAPALData.xml")
        ''DBxDataSet.MAPALData.ReadXml(My.Application.Info.DirectoryPath & "\MAPALData.xml")
        'If DBxDataSet.MAPALData.Count = 0 Then
        '    MsgBox("No Lot Data")
        '    Exit Sub
        'End If
        'Dim QRInput As New frmInputQrCode
        'QRInput.lbCaption.Text = "Input OP No. CANCEL LOT"
        'If QRInput.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    ' QRInput.lbCaption.Text=
        '    SaveLog(Message.Cellcon, lbLotNo.Text & ":" & lbOp.Text & ">>" & "Cancel Lot")
        '    DBxDataSet.MAPALData.Rows(0)("SelfConVersion") = lbRevision.Text.Remove(0, lbRevision.Text.IndexOf("Ver "))
        '    DBxDataSet.MAPALData.Rows(0)("NetVersion") = NetVer
        '    DBxDataSet.MAPALData.Rows(0)("LotEndTime") = Format(Now, "yyyy-MM-dd HH:mm:ss")
        '    DBxDataSet.MAPALData.Rows(0)("Remark") = "CANCELLOT"
        '    WrDBX()
        '    '  If My.Settings.RunOffline = False Then
        '    Dim resEnd As TdcResponse = m_TdcService.LotEnd(ProcessHeader & lbMC.Text, lbLotNo.Text, Format(Now, "yyyy-MM-dd HH:mm:ss"), 0, 0, EndModeType.AbnormalEndReset, lbOp.Text)
        '    SaveLog(Message.Cellcon, lbLotNo.Text & ":" & lbOp.Text & ">>" & resEnd.ErrorCode & ":" & resEnd.ErrorMessage)
        '    'End If
        '    'CancelASEStrip("1234F1111V")
        '    If Parameter.LotNo = Nothing Then
        '        MsgBox("กรุณา Scan QR Code ที่จะทำการ Cancel Lot")
        '        Exit Sub
        '    ElseIf Parameter.LotNo Like "*F*" Then
        '        Dim aa As String = CancelASEStrip(Parameter.LotNo)
        '        If aa Like "*True*" Then
        '            '   MsgBox(CancelASEStrip(Parameter.LotNo))
        '            MsgBox("Cancel F Lot สำเร็จ")
        '        Else
        '            MsgBox(aa)
        '        End If
        '    Else
        '        MsgBox("Cancel A Lot สำเร็จ")
        '    End If

        'End If

    End Sub



    Private Sub OnlineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnlineToolStripMenuItem.Click
        My.Settings.RunMode = "Auto"
        My.Settings.Save()
        RunMode.Text = My.Settings.RunMode
    End Sub

    Private Sub OfflineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OfflineToolStripMenuItem.Click
        '    My.Settings.RunMode = "Manual"
        ' My.Settings.Save()
        RunMode.Text = "Manual" 'My.Settings.RunMode
    End Sub
    Private Function SendPLC(Message As String) As Boolean
        Try
            If RunMode.Text = "Manual" Then

            Else
                SerialPort1.Write(Message + Chr(13))
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Return True
    End Function
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    '  Dim rs As New Resizer
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        '   rs.ResizeAllControls(Me)
    End Sub









    ' Dim MAPAlarmInfo As DBxDataSet.MAPAlarmInfoDataTable
    'Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
    '    Alarm = "START"
    '    'MapAlarmTableTableAdapter1.Fill(DBxDataSet.MAPAlarmTable, "5", My.Settings.MachineType)
    '    ''   Dim aa As String = DBxDataSet.MAPAlarmTable.Rows(0).Item("ID")
    '    '' Dim MAPAlarmInfo As DBxDataSet.MAPAlarmInfoDataTable = New DBxDataSet.MAPAlarmInfoDataTable
    '    ''  MAPAlarmInfo = New DBxDataSet.MAPAlarmInfoDataTable

    '    'Dim row As DBxDataSet.MAPAlarmInfoRow = DBxDataSet.MAPAlarmInfo.NewRow
    '    'row.RecordTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
    '    '    row.AlarmID = DBxDataSet.MAPAlarmTable.Rows(0).Item("ID")
    '    '    row.LotNo = "17215A562V" ' Parameter.LotNo
    '    'row.MCNo = ProcessHeader & My.Settings.MCNo
    '    'DBxDataSet.MAPAlarmInfo.Rows.Add(row)
    '    'DBxDataSet.MAPAlarmInfo.WriteXml(My.Application.Info.DirectoryPath & "\MAPAlarmInfo.xml")
    '    ''   MapAlarmInfoTableAdapter1.Update(MAPAlarmInfo)
    '    ''  DataGridView1.DataSource = MAPAlarmInfo
    'End Sub

    'Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
    '    Alarm = "STOP"
    '    'For Each data As DBxDataSet.MAPAlarmInfoRow In DBxDataSet.MAPAlarmInfo
    '    '    data.ClearTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
    '    'Next
    '    'MapAlarmInfoTableAdapter1.Update(DBxDataSet.MAPAlarmInfo)
    '    'DBxDataSet.MAPAlarmInfo.Clear()
    '    '' DataGridView1.DataSource = MAPAlarmInfo
    'End Sub

    'Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

    '    DBxDataSet.MAPAlarmInfo.ReadXml(My.Application.Info.DirectoryPath & "\MAPAlarmInfo.xml")
    '    ' DataGridView1.DataSource = MAPAlarmInfo
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
            Minimize()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ByManualToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ByManualToolStripMenuItem.Click
        Try
            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/andontmn", AppWinStyle.NormalFocus) 'Web andon for manual M/C     'Maual input
            Minimize()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BMRequestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BMRequestToolStripMenuItem.Click
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
        Minimize()
        Process.Start("C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe")

    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        On Error Resume Next
        '   Process.Start(Application.StartupPath & "\MapLaserManualx.pdf")
        Process.Start(Application.StartupPath & "\MapAutoLabelerManualx.pdf")
        Minimize()
    End Sub

    Private Sub WorkRecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkRecordToolStripMenuItem.Click
        Try
            Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/ERECORD/", AppWinStyle.NormalFocus)
            Minimize()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PMRepairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PMRepairToolStripMenuItem.Click
        Dim MCNo As String = "MAP-" & lbMC.Text
        Process.Start("C:\WINDOWS\system32\osk.exe")
        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainPMlogin.asp?" & "MCNo=" & MCNo, vbNormalFocus)

        Minimize()
    End Sub

    Private Sub APCSStaffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles APCSStaffToolStripMenuItem.Click
        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/ApcsStaff", AppWinStyle.NormalFocus)
        ' Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv/ERECORD/", AppWinStyle.NormalFocus)
        '  Minimize()
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

    'Private Sub MCSettingToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MCSettingToolStripMenuItem1.Click
    '    Dim str As String = InputBox("ใสชื่อเครื่องจักร", "MC Name")
    '    If Panel2.Controls.Count > 10 Then
    '        MsgBox("สามารถใส่เครื่องได้สูงสุด 10 เครื่อง")
    '    End If

    '    If str <> "" Then
    '        Confg.MCList(UBound(Confg.MCList)) = str.ToUpper
    '        Dim L As Integer = Confg.MCList.Length
    '        Array.Resize(Confg.MCList, L + 1)
    '    End If
    '    BuildMCList()
    'End Sub

    Private Sub TDCToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TDCToolStripMenuItem1.Click
        Dim frmTDC As SettingTDC = New SettingTDC
        frmTDC.ShowDialog()
    End Sub

    Private Sub lbRevision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbRevision.Click
        On Error Resume Next
        Process.Start(Application.StartupPath & "\Revision.txt")
        Minimize()
    End Sub

    'Private Sub lbMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbMinimize.Click
    '    Me.WindowState = FormWindowState.Minimized
    'End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        '  Me.Close()

        Dim result As Integer = MessageBox.Show("ต้องการออกจากโปรแกรมหรือไม่ ?", "Message", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then
            MachineOnline("MAP-" & My.Settings.MCNo, iLibraryService.MachineOnline.Offline)
            Me.Close()
        End If
    End Sub
    Public CellConData As New ParameterTC
    Private Sub ComportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComportToolStripMenuItem.Click
        SerialPort1.Close()
        Dim frm As SettingComport = New SettingComport
        frm.ShowDialog()
        CellConData.ComPort = SerialPort1.PortName.ToString
    End Sub
    Private Sub Minimize()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub AutoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoToolStripMenuItem.Click
        My.Settings.RunMode = "Auto"
        My.Settings.Save()
        RunMode.Text = My.Settings.RunMode
    End Sub

    Private Sub ManaulToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManaulToolStripMenuItem.Click
        RunMode.Text = "Manual" 'My.Settings.RunMode
    End Sub

    Private Sub ONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ONToolStripMenuItem.Click
        My.Settings.AuthenticationUser = True
        My.Settings.Save()
    End Sub

    Private Sub OFFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OFFToolStripMenuItem.Click
        My.Settings.AuthenticationUser = False
        My.Settings.Save()
    End Sub
    Dim KeyInput As Boolean = False
    Private Sub SettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingToolStripMenuItem.Click
        If My.Settings.AuthenticationUser = True Then
            ONToolStripMenuItem.CheckState = CheckState.Checked
            OFFToolStripMenuItem.CheckState = CheckState.Unchecked
        Else
            ONToolStripMenuItem.CheckState = CheckState.Unchecked
            OFFToolStripMenuItem.CheckState = CheckState.Checked
        End If
        If My.Settings.RunMode = "Auto" Then
            AutoToolStripMenuItem.CheckState = CheckState.Checked
            ManaulToolStripMenuItem.CheckState = CheckState.Unchecked
        Else
            AutoToolStripMenuItem.CheckState = CheckState.Unchecked
            ManaulToolStripMenuItem.CheckState = CheckState.Checked
        End If

        If KeyInput = False Then
            KeysToolStripMenuItem1.CheckState = CheckState.Unchecked
            DatabaseToolStripMenuItem.CheckState = CheckState.Checked
        Else
            KeysToolStripMenuItem1.CheckState = CheckState.Checked
            DatabaseToolStripMenuItem.CheckState = CheckState.Unchecked
        End If



    End Sub

    Private Sub KeysToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KeysToolStripMenuItem1.Click
        ' PassWord("ENGINEER")
        '  If Not Pbx.Level = "ENGINEER" Then
        '      Exit Sub
        '  End If
        KeysToolStripMenuItem1.CheckState = CheckState.Checked
        DatabaseToolStripMenuItem.CheckState = CheckState.Unchecked
        KeyInput = True
        '    KeysToolStripMenuItem.Checked = True
        '   DBxDatabaseToolStripMenuItem.Checked = False
    End Sub

    Private Sub DatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseToolStripMenuItem.Click
        '  If Not Confg.Offline Then
        '  KeysToolStripMenuItem.Checked = False
        '  DBxDatabaseToolStripMenuItem.Checked = True
        KeysToolStripMenuItem1.CheckState = CheckState.Unchecked
        DatabaseToolStripMenuItem.CheckState = CheckState.Checked
        KeyInput = False
        '  End If
    End Sub






#End Region


End Class
