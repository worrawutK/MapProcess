Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Net.Sockets
Imports System.Threading
Imports System.Net
'Imports Rohm.Apcs.Tdc
'Imports MAP_OSFT.RohmService
Imports Rohm.Ems



' IPBC Connect -----------------
' 1. DIABLE ONLine /OFFLine Mode (Use Online Only)

Public Class frmMain
    Public m_EmsClient As EmsServiceClient = New EmsServiceClient("MAP", "http://webserv.thematrix.net:7777/EmsService")
    Private f2 As New Form2
    '  Private m_TdcService As TdcService
    'One event per load
    Private Sub lbAndon_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim str As String = My.Computer.Name
        Dim F1 As New Font("ARIAL", 11, FontStyle.Regular)
        Dim sbrush As New SolidBrush(Color.Black)
        Dim g As Graphics = Me.CreateGraphics()
        g.DrawString(str, F1, sbrush, lbMinimize.Left, lbMinimize.Bottom + 15)
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        m_LotData = ReadXml(Of LotData)(m_PathFileLotData)
        If m_LotData Is Nothing Then
            m_LotData = New LotData
        End If
        '!! Check Comment at [On Error Resume Next] of [ Protected Overrides Sub WndProc] for test this Sub afer new edit
        initial()
        BuildMCList()
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
        StartSock()                               'Start IPBC Socket

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        WrXml(SelPath & "Config.xml", Confg)
    End Sub



#Region "===Initial"
    'Dim TargetWinTitle As String

    Private Sub initial()

        'm_TdcService = TdcService.GetInstance()
        'm_TdcService.ConnectionString = My.Settings.APCSDBConnectionString

        If Directory.Exists(TempDataBasePath) = False Then                          'AutoDirectory Create
            Directory.CreateDirectory(TempDataBasePath)
            Directory.CreateDirectory(TempPath)
        End If
        If Directory.Exists(MapZipDestin) = False Then
            Directory.CreateDirectory(MapZipDestin)
            Directory.CreateDirectory(MapZipDestin & "BackUp\")
        End If



        ''Label.text clear ----------------------------------------------------------------------------------------------
        For Each lb As Label In Panel1.Controls
            lb.Text = ""
        Next
        For Each CTL In Panel3.Controls
            CTL.Text = ""
        Next
        For Each l As Label In Panel4.Controls
            l.Text = ""
        Next
        lbInput.Text = ""
        lbGood.Text = ""

        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then        'One application run only 130205
            Me.Close()
        End If
        txtPostMSGRecv.Hide()

        'Config Load
        Try

            Confg = RdXml(SelPath & "Config.xml")
        Catch ex As Exception
            MsgBox("Config.xml:" & ex.Message.ToString)
        End Try
        Try
            LotInfos = ReadXml(Of List(Of Lotinfo))(m_PathFileLotInfos)
        Catch ex As Exception
            MsgBox("LotInfo.xml:" & ex.Message.ToString)
        End Try
        Try
            For i = 0 To Confg.TesterName.Length - 1                     'Confg.tester to Array List
                LST.Add(Confg.TesterName(i))
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        If Confg.Offline Then
            lbOffline.Visible = True
        Else
            lbOffline.Visible = False
        End If

        ProgressBar1.Hide()

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
    Private Function WrDBX() As String

        'DB.X disconnect save to PC
        If Confg.Offline Then
            OfflineLoop()
            Return "Error:Offline Loop"                            'IPBC Mode Can not OFFLine Use 
            Exit Function
        End If
        ' == Online  ----
        If Not My.Computer.Network.IsAvailable Then
            MsgBox("PC Nework point not Open")
            clsErrorLog.addlogWT("Error:WrDBX/PC Nework point not Open", "Form1")
            Return "Error:PC Nework point not Open"

        End If
        If Not My.Computer.Network.Ping(_ipDbxUser) Then            'Can Pink if Computer Connect only
            MsgBox("การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้")
            clsErrorLog.addlogWT("Error:WrDBX/การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้", "Form1")
            Return "Error:การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้"
        End If
        DBxDataSet.MAPOSFTData.WriteXml(TempDataBasePath & "\" & lbMC.Text)

        Me.Validate()
        Me.MAPOSFTDataBindingSource.EndEdit()

        If MAPOSFTDataTableAdapter.Update(DBxDataSet.MAPOSFTData.Rows(0)) = 1 Then
            If Not lbEnd.Text = "" Then                 'Del tempdatabase if lot end
                If File.Exists(TempDataBasePath & "\" & lbMC.Text) Then
                    File.Delete(TempDataBasePath & "\" & lbMC.Text)
                End If
            End If
            Return "True"

        Else    'Can not save

            clsErrorLog.addlogWT("Error:WrDBX/Can not Save_ " & lbLotNo.Text, "Form1")
            Return "Error:Can not Save"

        End If


    End Function

    Private Sub OfflineLoop()

        DBxDataSet.MAPOSFTData.WriteXml(TempDataBasePath & "\" & lbMC.Text)         'Save data to PC
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
            Dim dt As New DBxDataSet.MAPOSFTDataDataTable
            dt = ds.MAPOSFTData


            'Resync Loop -------------------
            For i = 0 To dt.Count - 1
                Me.MAPOSFTDataTableAdapter.LoadLot(DBxDataSet.MAPOSFTData, dt.Rows(i)("LotNo"), dt.Rows(i)("MCNo"), dt.Rows(i)("LotStartTime"))
                If DBxDataSet.MAPOSFTData.Count = 0 Then                            'If no record
                    If Me.MAPOSFTDataTableAdapter.Update(dt.Rows(i)) > 0 Then
                        'Kill(f)
                    End If
                Else
                    Me.DBxDataSet.MAPOSFTData.Rows(0).ItemArray = dt.Rows(i).ItemArray
                    If Me.MAPOSFTDataTableAdapter.Update(DBxDataSet.MAPOSFTData.Rows(0)) > 0 Then
                        'Kill(f)
                    End If
                End If
            Next
        Next


    End Sub
#End Region

    '#Region "===ToolBar & Common Button"
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
    '        ContextMenuStrip3.Show(lbHelp, New Point(0, lbHelp.Height))
    '    End Sub

    '    Private Sub lbMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbMinimize.Click
    '        Me.WindowState = FormWindowState.Minimized
    '    End Sub
    '    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
    '        Me.Close()
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
    '        Process.Start(Application.StartupPath & "\Revision.pdf")
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



    '    Private Sub BMRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMRequest.Click
    '        Dim tmpStr As String
    '        Dim MCNo As String = "MAP-" & lbMC.Text
    '        tmpStr = "MCNo=" & MCNo
    '        tmpStr = tmpStr & "&LotNo=" & lbLotNo.Text
    '        If lbStart.Text <> "" AndAlso lbEnd.Text = "" Then
    '            tmpStr = tmpStr & "&MCStatus=Running"
    '        Else
    '            tmpStr = tmpStr & "&MCStatus=Stop"
    '        End If

    '        tmpStr = tmpStr & "&AlarmNo="
    '        tmpStr = tmpStr & "&AlarmName="

    '        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainloginPD.asp?" & tmpStr, vbNormalFocus)
    '        Process.Start("C:\WINDOWS\system32\osk.exe")
    '    End Sub
    '    Private Sub lbPMRepairing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbPMRepairing.Click
    '        Dim MCNo As String = "MAP-" & lbMC.Text
    '        Process.Start("C:\WINDOWS\system32\osk.exe")
    '        Call Shell("C:\Program Files\Internet Explorer\iexplore.exe http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainPMlogin.asp?" & "MCNo=" & MCNo, vbNormalFocus)

    '    End Sub
    '    Private Sub ManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualToolStripMenuItem.Click
    '        On Error Resume Next
    '        Process.Start(Application.StartupPath & "\MapOSFTManualx.pdf")
    '    End Sub
    '    Private Sub LogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogToolStripMenuItem.Click
    '        If IsNothing(f2) OrElse f2.IsDisposed Then
    '            f2 = New Form2
    '        End If
    '        f2.Show()
    '    End Sub

    '    Private Sub NewSetUpCheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewSetUpCheckToolStripMenuItem.Click
    '        If Panel2.Controls.Count = 0 Then
    '            MsgBox("ไม่พบ ชื่อเครื่องจักร ให้ ทำการเพิ่มเครื่อง แล้วลองใหม่อีกครั้ง")
    '            Exit Sub
    '        End If
    '        PassWord("ENGINEER")
    '        If Not Pbx.Level = "ENGINEER" Then
    '            Exit Sub
    '        End If
    '        Form3.ShowDialog()
    '    End Sub

    '#End Region
    'Andon
    'Setting
    'Help
    'WorkRecord
    'Minimize
    'close

#Region "===Inspection MODE A,B,C"
    Dim ModeSelect As Mode
    Dim LB As New Label
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click, Label2.Click, Label4.Click, Label3.Click
        If Not KYB Is Nothing Then                               'Cross type of object use miss protect
            KYB.Dispose()
        End If
        If DBxDataSet.MAPOSFTData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If

        If cbTestBoardNo.Text = "" Then
            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Test Board No.")
            Exit Sub
        ElseIf cbSocket.Text = "" Then
            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  SocketNo.")
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
        Dim row As DataRow = Me.DBxDataSet.MAPOSFTData.Rows(0)
        Dim index As Integer = Me.DBxDataSet.MAPOSFTData.Columns.IndexOf("SocketCheckBe") - 1    'Get offset index of work column
        LB.Text = ModeSelect.Mode
        LB.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
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
        If DBxDataSet.MAPOSFTData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        If cbTestBoardNo.Text = "" Then
            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  BoxNo.")
            Exit Sub
        End If
        DBxDataSet.MAPOSFTData.Rows(0)("SocketCheckBe") = "-"

        DBxDataSet.MAPOSFTData.Rows(0)("BariCheckBe") = "A"

        DBxDataSet.MAPOSFTData.Rows(0)("Andon") = "N"
        DBxDataSet.MAPOSFTData.Rows(0)("GoodNGSampleChk") = "-"
        If lbProcess.Text = "OS" Then
            DBxDataSet.MAPOSFTData.Rows(0)("LCL") = 99.0
        End If

    End Sub
    Private Sub Label1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseHover, Label2.MouseHover, Label4.MouseHover, Label3.MouseHover, lbAll.MouseHover

        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave, Label2.MouseLeave, Label4.MouseLeave, Label3.MouseLeave, lbAll.MouseLeave
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

        If cbTestBoardNo.Text = "" Then
            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Test Board No.")
            Return False
        End If
        For Each l As Label In Panel4.Controls                 'Panel4 empty check

            If lbProcess.Text Like "AUTO*" Then                      'If FT MAPOS is null _130904
                If l.Name = Label9.Name Then
                    Continue For
                End If

                If l.Name = Label14.Name Then                   ''If FT MAPOS Yield is null
                    Continue For
                End If

            End If


            If l.Text = "" Then
                Inst(7) = True
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
                        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Socket Check")
                        Return False
                    Case 3
                        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Bari Check")
                        Return False
                    Case 5

                        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Good/Ng Sample Check")
                        Return False

                    Case 7
                        If LB.Text = "lbLotJudge" Then
                            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  จำนวนงาน ng ต่างๆ  และ  Yeild")
                            Return False
                        End If
                    Case 6
                        If LB.Text = "lbLotJudge" Then
                            MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Map Confirm")
                            Return False
                        End If
                        ''Case 8
                        ''    If LB.Text = "lbLotJudge" Then
                        ''        MsgBox("ยังไม่ ลงข้อมูลตรวจสอบ  Re-issue Label Quantity")
                        ''        Return False
                        ''    End If
                End Select
            End If
        Next




        Return True
    End Function


#End Region
    'Mode ABC User control Display 

#Region "===Inspection Save"
    Private Sub FstSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FstSave.Click
        Dim Btemp As New Label
        'Dim Alm As String = ""
        Btemp.Name = "Label-1"
        LB = Btemp
        If Not DataPrioity() Then
            Exit Sub
        End If

        If lbGood.Text > 0 Then
            MsgBox("ไม่สารามารถบันทึกข้อมูล 1st Save ได้เนื่องจากอยู่ในขบวนการ จบLot")
            Exit Sub
        End If

        If cbTestBoardNo.Text = "" Then
            MsgBox("กรุณาเลือก Test Board No.")
            Exit Sub
        End If
        If cbSocket.Text = "" Then
            MsgBox("กรุณาเลือก Socket No.")
            Exit Sub
        End If


        'For Each strDataRow As DBxDataSet.MAPOSFTDataRow In DBxDataSet.MAPOSFTData.Rows
        '    strDataRow.BoxNo = cbTestBoardNo.Text
        '    strDataRow.SocketNo = cbSocket.Text
        '    strDataRow.InputQty = lbInput.Text
        '    strDataRow.LCL = lbLCL.Text
        '    strDataRow.initialYield = lbIniYe.Text
        'Next


        Dim ans As String
        ans = WrDBX()
        If ans Like "Error*" Then
            clsErrorLog.addlogWT("Error:/ FstSave_Click_" & lbMC.Text & "," & lbLotNo.Text, "Form1")
        End If
        If Not KYB Is Nothing Then
            KYB.Dispose()
        End If
    End Sub

    Private Sub btnFinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinal.Click

        If DBxDataSet.MAPOSFTData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        If lbLotJudge.Text = "" Then
            MsgBox("ยังไม่ได้ Judgement Lot")
            Exit Sub
        End If

        If cbTestBoardNo.Text = "" Then
            MsgBox("กรุณาเลือก Test Board No.")
            Exit Sub
        End If

        If cbSocket.Text = "" Then
            MsgBox("กรุณาเลือก Socket No.")
            Exit Sub
        End If

        Dim alm As String
        alm = CheckA_ModeInspOneTime(lbMC.Text, True)  'Test Socket
        If alm.Contains("False") = True Then
            MsgBox(alm)
            Exit Sub
        End If

        alm = CheckA_ModeInspOneTime(lbMC.Text, False) 'Good/NG Sample
        If alm.Contains("False") = True Then
            MsgBox(alm)
            Exit Sub
        End If


        ''If Not lbNg.Text = CInt(lbInput.Text) - CInt(lbGood.Text) Then
        ''    MsgBox("ใส่จำนวนรวม Good Ng ไม่เท่ากับ Input(Zero Control)")
        ''    Exit Sub
        ''End If

        If lbLotJudge.Text <> "OK" And lbGL.Text = "" Then
            MsgBox("Lot Judgement = ผิดปกติ ต้องใส่รหัส GLยืนยัน")
            Exit Sub

        End If

        If lbAndonJudge.Text = "Y" And lbGL.Text = "" Then
            MsgBox("Andon = Y ต้องใส่รหัส GLยืนยัน")
            Exit Sub
        End If

        If Not My.Computer.Network.IsAvailable Then
            MsgBox("PC Nework point not Open")
            clsErrorLog.addlogWT("Error:WrDBX/PC Nework point not Open", "Form1")
            Exit Sub

        End If
        If Not My.Computer.Network.Ping(_ipDbxUser) Then            'Can Pink if Computer Connect only
            MsgBox("การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้")
            clsErrorLog.addlogWT("Error:WrDBX/การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้", "Form1")
            Exit Sub
        End If

        Dim endtime As DateTime = Format(Format(Now, "yyyy/MM/dd HH:mm:ss"))

        Dim dialogEnd As New DialogEndConfirm()
        If dialogEnd.ShowDialog() = DialogResult.OK Then
            ' Dim resEnd As TdcResponse
            If dialogEnd.EndLot = DialogEndConfirm.Status.EndNomal Then
                FinalLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text)
                Dim result As Boolean = EndLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text, CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text))
                If Not result Then
                    Return
                End If
                ' resEnd = m_TdcService.LotEnd(ProcessHeader & lbMC.Text, lbLotNo.Text, CDate(lbEnd.Text), CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text), EndModeType.Normal, lbOp.Text)
            ElseIf dialogEnd.EndLot = DialogEndConfirm.Status.EndRetest Then
                Dim result As Boolean = RetestLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text)
                If Not result Then
                    Return
                End If
                ' resEnd = m_TdcService.LotEnd(ProcessHeader & lbMC.Text, lbLotNo.Text, CDate(lbEnd.Text), CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text), EndModeType.AbnormalEndReset, lbOp.Text)
            End If
        End If

        If MAP_MAPDataTableAdapter.EndSerch(DBxDataSet.MAP_MAPData, "MAP-" & lbMC.Text, lbLotNo.Text) = 1 Then
            'DBxDataSet.MAP_MAPData.Rows(0)("LotEndTime") = endtime
            For Each strDataRow As DBxDataSet.MAP_MAPDataRow In DBxDataSet.MAP_MAPData.Rows
                strDataRow.LotEndTime = endtime
            Next

            If Not MAP_MAPDataTableAdapter.Update(DBxDataSet.MAP_MAPData) = 1 Then
                clsErrorLog.addlogWT("Error:btnFinal_Click/Map_MapData Update Error" & lbMC.Text & "," & lbLotNo.Text, "Form1")
            End If
        Else
            MAP_MAPDataTableAdapter.FillMapEnd(DBxDataSet.MAP_MAPData, lbLotNo.Text, lbStart.Text, "MAP-" & lbMC.Text)
            If DBxDataSet.MAP_MAPData.Rows.Count = 0 Then
                MsgBox("ไม่สามารถจบ LOT ให้ไป ทำการจบ Lotที่ IPBC ก่อน")
                clsErrorLog.addlogWT("Error:btnFinal_Click/Map_MapData.EndSerch() not found result" & lbMC.Text & "," & lbLotNo.Text, "Form1")
                Exit Sub
            End If
        End If

        Dim row As DataRow = Me.DBxDataSet.MAPOSFTData.Rows(0)
        'For Each strDataRow As DBxDataSet.MAPOSFTDataRow In DBxDataSet.MAPOSFTData.Rows
        '    If Master Then
        '        strDataRow.LotEndTime = DateTimePicker1.Value
        '    Else
        '        strDataRow.LotEndTime = endtime
        '    End If
        '    strDataRow.TesterName = lbTestName.Text
        '    strDataRow.SelfConVersion = lbRevision.Text.Remove(0, lbRevision.Text.IndexOf("Ver "))
        '    strDataRow.NetVersion = NetVer
        '    strDataRow.LotJudgement = lbLotJudge.Text
        '    strDataRow.TotalGood = lbGood.Text

        '    strDataRow.BoxNo = cbTestBoardNo.Text
        '    strDataRow.SocketNo = cbSocket.Text

        '    strDataRow.LCL = lbLCL.Text
        '    strDataRow.initialYield = lbIniYe.Text
        'Next



        If Master Then
            row("LotEndTime") = DateTimePicker1.Value
        Else
            row("LotEndTime") = endtime
        End If

        row("TesterName") = lbTestName.Text
        row("SelfConVersion") = lbRevision.Text.Remove(0, lbRevision.Text.IndexOf("Ver "))
        row("NetVersion") = NetVer
        row("SocketNo") = cbSocket.Text
        row("LCL") = lbLCL.Text
        row("initialYield") = lbIniYe.Text


        Dim ans As String
        ans = WrDBX()

        'SendPostMessage("@LOTEND|" & ProcessHeader & lbMC.Text & "|" & lbLotNo.Text & "," & _
        ' lbEnd.Text & "," & lbGood.Text & "," & CInt(lbInput.Text) - CInt(lbGood.Text) & ",01") 'Lot End       'Normal
        'Dim dialogEnd As New DialogEndConfirm()
        'If dialogEnd.ShowDialog() = DialogResult.OK Then
        '    ' Dim resEnd As TdcResponse
        '    If dialogEnd.EndLot = DialogEndConfirm.Status.EndNomal Then
        '        FinalLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text)
        '        EndLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text, CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text))
        '        ' resEnd = m_TdcService.LotEnd(ProcessHeader & lbMC.Text, lbLotNo.Text, CDate(lbEnd.Text), CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text), EndModeType.Normal, lbOp.Text)
        '    ElseIf dialogEnd.EndLot = DialogEndConfirm.Status.EndRetest Then
        '        RetestLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text)
        '        ' resEnd = m_TdcService.LotEnd(ProcessHeader & lbMC.Text, lbLotNo.Text, CDate(lbEnd.Text), CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text), EndModeType.AbnormalEndReset, lbOp.Text)
        '    End If
        'End If

        'EMS end
        Try
            m_EmsClient.SetOutput(lbMC.Text, CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text))
            m_EmsClient.SetLotEnd(lbMC.Text) 'LA-01
            m_EmsClient.SetActivity(lbMC.Text, "Stop", TmeCategory.StopLoss)
        Catch ex As Exception
            SaveLog(Message.Cellcon, "SetActivity Stop:" & ex.ToString)
        End Try

        btnFinal.BackColor = System.Drawing.SystemColors.ActiveCaption
        If ans Like "Error*" Then
            clsErrorLog.addlogWT("Error:btnFinal_Click บันทึกข้อมูล Workrecord ไม่ได้/" & lbMC.Text & "," & lbLotNo.Text & "," & ans, "Form1")
            MsgBox("บันทึกข้อมูล Workrecord ไม่ได้")
        Else
            MsgBox("LotEnd Success")
        End If

    End Sub

#End Region


#Region "===Good NG Input"
    Private Sub lbGood_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbInput.Click, lbGood.Click, Label7.Click, Label9.Click, Label8.Click, Label11.Click, Label10.Click, lbLCL.Click, lbIniYe.Click
        Dim Btemp As New Label                                  'First inspec empty check
        Btemp.Name = "Label-1"
        LB = Btemp

        If lbProcess.Text Like "AUTO*" Then                           'Check IF FT MAPOS will be NULL  _130904
            If sender.name = Label9.Name Then
                Exit Sub
            End If
        End If

        If Not DataPrioity() Then
            Exit Sub
        End If



        LB = CType(sender, Label)                                'Text change display label
        If Not ModeSelect Is Nothing Then                        'Cross type of object use miss protect
            ModeSelect.Dispose()
        End If

        'Select Case LB.Name
        '    Case "lbLCL", "lbIniYe"
        '        If IsNumeric(LB.Text) Then          'Decimal Display 
        '            tbxCtrl.Text = LB.Text * 10
        '        Else
        '            tbxCtrl.Text = LB.Text
        '        End If
        '    Case Else
        '        tbxCtrl.Text = LB.Text              'Interger Display
        'End Select

        tbxCtrl.Text = LB.Text              'Interger Display
        'Defult 0 when click
        tbxCtrl.Select(tbxCtrl.Text.Length, 0)
        KeyBoardCall(tbxCtrl, True)
    End Sub

    Private Sub lbGood_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbInput.MouseHover, lbGood.MouseHover, Label7.MouseHover, Label9.MouseHover, Label8.MouseHover, Label11.MouseHover, Label10.MouseHover, lbLCL.MouseHover, lbIniYe.MouseHover, lbBxName.MouseHover _
    , lbTestName.MouseHover

        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub lbGood_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbInput.MouseLeave, lbGood.MouseLeave, Label7.MouseLeave, Label9.MouseLeave, Label8.MouseLeave, Label11.MouseLeave, Label10.MouseLeave, lbLCL.MouseLeave, lbIniYe.MouseLeave, lbBxName.MouseLeave _
    , lbTestName.MouseLeave
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
        LB.Text = CSng(tbxCtrl.Text)

        Select Case LB.Name
            Case "lbGood"
                If LB.Text > CInt(lbInput.Text) Then
                    MsgBox("ใส่จำนวนเกินค่า Input ไม่ได้")
                    tbxCtrl.Text = ""
                    Exit Sub
                End If
                DBxDataSet.MAPOSFTData.Rows(0)("TotalGood") = LB.Text
                Dim row As DataRow = Me.DBxDataSet.MAPOSFTData.Rows(0)
                row("Diff") = row("InputQty") - row("TotalGood") - row("TotalNG")

            Case "lbInput"
                DBxDataSet.MAPOSFTData.Rows(0)("InputQty") = LB.Text
                Dim row As DataRow = Me.DBxDataSet.MAPOSFTData.Rows(0)

                row("Diff") = row("InputQty") - row("TotalGood") - row("TotalNG")


            Case "lbLCL" 'Decimal

                DBxDataSet.MAPOSFTData.Rows(0)("LCL") = FormatNumber(LB.Text, 1)


            Case "lbIniYe" 'Decimal

                DBxDataSet.MAPOSFTData.Rows(0)("initialYield") = FormatNumber(LB.Text, 1)

            Case Else
                Dim row As DataRow = Me.DBxDataSet.MAPOSFTData.Rows(0)
                Dim index As Integer = Me.DBxDataSet.MAPOSFTData.Columns.IndexOf("FTNG")    'Get offset index of work column
                Dim Sum As Integer = 0
                For i = 7 To 11                                                             'Controls in panel1 WB inspection item 
                    If LB.Name = "Label" & (i) Then
                        row(i + index - 7) = LB.Text
                    End If
                    If IsNumeric(row(i + index - 7)) Then
                        Sum += row(i + index - 7)
                    End If
                Next

                row("TotalNG") = Sum

                If IsNumeric(lbGood.Text) Then
                    row("Diff") = row("InputQty") - row("TotalGood") - row("TotalNG")
                End If

                If Not Label7.Text = "" Then

                    row("FTYield") = FormatNumber((row("InputQty") - row("FTNG")) * 100 / row("InputQty"), 1)

                End If
                If Not Label9.Text = "" Then
                    row("MAPOSYield") = FormatNumber((row("InputQty") - row("MAPOS")) * 100 / row("InputQty"), 1)

                End If

        End Select



    End Sub





#End Region
    'Good
    'ng
    'input adjust
    'LCL, InitialYeild (Decimal xx.x)

#Region "=== Alarm data"
    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DBxDataSet.MAPOSFTData.Count = 0 Then
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

    Private Sub TextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxRemark.Enter
        If DBxDataSet.MAPOSFTData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            lbMaster.Select()
            Exit Sub                                           'No effect focus
        End If
        If Not KYB Is Nothing Then
            KYB.Dispose()
        End If
        KeyBoardCall(sender, False)


    End Sub

    Private Sub TextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxRemark.Validated
        If DBxDataSet.MAPOSFTData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If

        sender = CType(sender, TextBox)
        If sender.TextLength > 20 Then
            MsgBox("ใส่ข้อมูลได้ไม่เกิน 20 ตัวอักษร")
            sender.Text = ""
        End If

        Select Case sender.name
            Case "tbxRemark"
                DBxDataSet.MAPOSFTData.Rows(0)("Remark") = sender.Text         'dbx 50 Max
                cbxRemark.Text = sender.text
                'Case "tbxBxNo"
                '    DBxDataSet.MAPOSFTData.Rows(0)("BoxNo") = sender.Text

        End Select

    End Sub
    Private Sub cbxRemark_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxRemark.Click
        If DBxDataSet.MAPOSFTData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            lbMaster.Select()
            Exit Sub
        End If
    End Sub
    Private Sub cbxRemark_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxRemark.SelectedIndexChanged
        If DBxDataSet.MAPOSFTData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        DBxDataSet.MAPOSFTData.Rows(0)("Remark") = cbxRemark.SelectedItem
        tbxRemark.Text = cbxRemark.SelectedItem
    End Sub
#End Region
    'Alarm Freq
    'Remark



#Region "===Label KeysInput"
    Dim lbKeys As Label

    Private Sub lbTestName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbTestName.Click
        PassWord("MAP")
        If Not Pbx.Level = "MAP" Then
            Exit Sub
        End If
        lbKeys = CType(sender, Label)
        lbKeys.Text = ""
        KeyBoardCall(txtKeys, False)
        KYB.Location = New Point(10, lbKeys.Bottom + 10)

    End Sub

    Private Sub lbBxName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbBxName.Click
        If DBxDataSet.MAPOSFTData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If
        lbKeys = CType(sender, Label)
        txtKeys.Text = lbKeys.Text
        KeyBoardCall(txtKeys, False)
        KYB.Location = New Point(10, lbKeys.Bottom + 10)
    End Sub
    Private Sub txtKeys_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKeys.TextChanged
        lbKeys.Text = txtKeys.Text
        Select Case lbKeys.Name
            Case "lbTestName"
            Case "lbBxName"
                DBxDataSet.MAPOSFTData.Rows(0)("BoxName") = lbKeys.Text
            Case "lbBxNo"
                DBxDataSet.MAPOSFTData.Rows(0)("BoxNo") = lbKeys.Text
        End Select
    End Sub

    Private Sub txtKeys_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKeys.Validated
        Dim L As New Label           'Clear Binding lbKeys
        L.Name = "Label-1"
        lbKeys = L
        txtKeys.Text = ""
    End Sub
    'BoxNo
    'BoxName
    'TesterName





#End Region



#Region "===OK/NG ,Yes/No Judge "

    Private Sub lbLotJudge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbLotJudge.Click
        '=== Data input incomplete check ------------------
        If DBxDataSet.MAPOSFTData.Count = 0 Then
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
        If lbBxName.Text = "" Then
            MsgBox("ยังไม่ได้ใส่ค่า BoxName")
            Exit Sub
        End If

        Dim row As DataRow = Me.DBxDataSet.MAPOSFTData.Rows(0)
        If Not lbProcess.Text Like "AUTO*" Then            'AUTO* MAPOSYield is null
            row("MAPOSYield") = FormatNumber((row("InputQty") - row("MAPOS")) * 100 / row("InputQty"), 1)
        End If


        If lbLotJudge.Text = "OK" Then
            lbLotJudge.Text = "NG"
        Else
            lbLotJudge.Text = "OK"
        End If

        DBxDataSet.MAPOSFTData.Rows(0)("LotJudgement") = lbLotJudge.Text
        If Master Then
            DBxDataSet.MAPOSFTData.Rows(0)("LotEndTime") = DateTimePicker1.Value
            DBxDataSet.MAPOSFTData.Rows(0)("Remark") = "INSERT LOT"
            tbxRemark.Text = "INSERT LOT"
            clickLb = True
            DateTimePicker1.Show()
        End If
    End Sub

    Private Sub lbAndonJudge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbAndonJudge.Click

        If DBxDataSet.MAPOSFTData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If

        If lbAndonJudge.Text = "Y" Then
            lbAndonJudge.Text = "N"
            DBxDataSet.MAPOSFTData.Rows(0)("Andon") = "N"
        Else
            lbAndonJudge.Text = "Y"
            DBxDataSet.MAPOSFTData.Rows(0)("Andon") = "Y"
        End If


    End Sub

    Private Sub lbGL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbGL.Click
        '  Dim resSet As TdcResponse = m_TdcService.LotSet(ProcessHeader & "OSFT9", "1716A6269V", DateTime.Now, "000000", RunModeType.Normal)
        If Not lbLotJudge.Text = "NG" And Not lbAndonJudge.Text = "Y" Then
            Exit Sub
        End If

        Dim QRInput As New frmInputQrCode
        QRInput.lbCaption.Text = "Input GL No."
        QRInput.ShowDialog()

    End Sub

    Private Sub lbAndonJudge_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAndonJudge.MouseHover, lbLotJudge.MouseHover, lbGL.MouseHover, Label5.MouseHover, Label6.MouseHover
        sender.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub lbAndonJudge_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAndonJudge.MouseLeave, lbLotJudge.MouseLeave, lbGL.MouseLeave, Label5.MouseLeave, Label6.MouseLeave
        sender.BorderStyle = BorderStyle.None
    End Sub
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DBxDataSet.MAPOSFTData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If

        If sender.Text = "Y" Then

            Dim index As Integer = Me.DBxDataSet.MAPOSFTData.Columns.IndexOf("SocketCheckBe") - 1    'Get offset index of work column
            For i = 5 To 7
                If sender.Name = "Label" & (i) Then
                    DBxDataSet.MAPOSFTData.Rows(0)(i + index) = "N"
                End If
            Next

        Else

            Dim index As Integer = Me.DBxDataSet.MAPOSFTData.Columns.IndexOf("SocketCheckBe") - 1    'Get offset index of work column
            For i = 5 To 7
                If sender.Name = "Label" & (i) Then
                    DBxDataSet.MAPOSFTData.Rows(0)(i + index) = "Y"
                End If
            Next

        End If

    End Sub

    Private Sub OkngLabel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click, Label6.Click
        If DBxDataSet.MAPOSFTData.Count = 0 Then
            MsgBox("ไม่มีข้อมูลการผลิต")
            Exit Sub
        End If

        If sender.Text = "OK" Then

            Select Case sender.name
                Case "Label5"
                    DBxDataSet.MAPOSFTData.Rows(0)("GoodNGSampleChk") = "NG"
                Case "Label6"
                    DBxDataSet.MAPOSFTData.Rows(0)("MAPConfirm") = "NG"
            End Select
        ElseIf sender.Text = "NG" Then
            If sender.name = "Label5" Then
                DBxDataSet.MAPOSFTData.Rows(0)("GoodNGSampleChk") = "-"
            End If
        Else
            Select Case sender.name
                Case "Label5"
                    DBxDataSet.MAPOSFTData.Rows(0)("GoodNGSampleChk") = "OK"
                Case "Label6"
                    DBxDataSet.MAPOSFTData.Rows(0)("MAPConfirm") = "OK"
            End Select

        End If


    End Sub
#End Region
    'LotJudge
    'AndonJudge
    'GL Check
    'Y/N Label
    'OK/NG Label

#Region "===MC Button"

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
        WrXml(SelPath & "Config.xml", Confg)
    End Sub
    Private Sub BuildMCList()
        Panel2.Controls.Clear()

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
            If Directory.Exists(MapdataPath & B.Text) = False Then
                Directory.CreateDirectory(MapdataPath & B.Text)
            End If
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

        DBxDataSet.MAPOSFTData.Clear()
        DBxDataSet.TransactionData.Clear()
        'No Binding Controls ---------------
        lbStatus.Hide()
        tbxRemark.Text = ""
        cbTestBoardNo.Text = ""
        lbMC.Text = sender.text            'Set Click MC No.
        MachineOnline("MAP-" & lbMC.Text, iLibraryService.MachineOnline.Online)
        'EMS
        Try
            If RegisterEMS = False Then
                Dim reg As EmsMachineRegisterInfo = New EmsMachineRegisterInfo(lbMC.Text, "MAP-" & lbMC.Text, "MAP", My.Settings.MachineType, "", 0, 0, 0, 0, 0)
                m_EmsClient.Register(reg)
                RegisterEMS = True
            End If

        Catch ex As Exception
            SaveLog(Message.Cellcon, "EmsMachineRegisterInfo:" & ex.ToString)
        End Try

        For i = 0 To Confg.TesterName.Length - 1          'Load tester name from config
            If lbMC.Text = Confg.TesterName(i).Split(",")(0) Then
                lbTestName.Text = Confg.TesterName(i).Split(",")(1)
                Exit For
            Else
                lbTestName.Text = ""
            End If

        Next


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
            If Insert Then
                Insert = False
            Else
                'Online  ReLoad Mapdata from dbx ------- 
                Me.MAPOSFTDataTableAdapter.FillByMCno(DBxDataSet.MAPOSFTData, ProcessHeader & sender.text)
            End If
        Else
            'Offline ReLoad Mapdata from PC ------- 
            'Offline can not get Device ,Package
            Me.DBxDataSet.MAPOSFTData.Clear()
            If File.Exists(TempDataBasePath & "\" & sender.Text) Then                                         'Clear table for new query
                Me.DBxDataSet.MAPOSFTData.ReadXml(TempDataBasePath & "\" & sender.text)
            End If

        End If
        If Not DBxDataSet.MAPOSFTData.Count = 0 Then                                        'Binding Textbox

            tbxRemark.Text = DBxDataSet.MAPOSFTData.Rows(0)("Remark")
            'tbxBxNo.Text = DBxDataSet.MAPOSFTData.Rows(0)("BoxNo")

        End If

        'First input ------ Count =0 
        'Reload data ------ Count >0
        If DBxDataSet.MAPOSFTData.Count = 0 Or (Confg.Offline And lbEnd.Text <> "") Then      'Case offline  lotendtime judge to continue

            For Each b As Button In Panel2.Controls                'Clear Err if New Input
                If b.Text = lbMC.Text Then
                    ErrorProvider1.SetError(b, "")
                End If
            Next

        End If


        'Query Package(Binding) , Device(Binding) , Mark No.(Set)

        If lbLotNo.Text <> "" And Not Confg.Offline Then
            Me.TransactionDataTableAdapter.Fill(DBxDataSet.TransactionData, lbLotNo.Text)
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
                If Directory.GetFiles(MapdataPath & M.Text).Count > 0 Then
                    MsgBox("ไม่สามารถ ลบ ได้เนื่่องจากมี Mapdata ที่กำลังใช้งานอยู่")
                    Exit Sub
                End If
                If Directory.Exists(MapdataPath & M.Text) = True Then
                    Directory.Delete(MapdataPath & M.Text)
                End If
                Panel2.Controls.Remove(M)
                Exit For
            End If
        Next

        For i = 0 To Confg.TesterName.Length - 1             'Remove testerName
            If cms.SourceControl.Text = Confg.TesterName(i).Split(",")(0) Then
                LST.Remove(Confg.TesterName(i))
                Exit For
            End If
        Next
        Array.Resize(Confg.TesterName, LST.Count)
        For i = 0 To LST.Count - 1                           'Update config
            Confg.TesterName(i) = LST(i)
        Next                                                 '-----------------

        For Each M In Panel2.Controls
            mc.Add(M.text)
        Next
        mc.Add(Nothing)                               '+ Notthing 
        Confg.MCList = mc.ToArray()
        BuildMCList()
        WrXml(SelPath & "Config.xml", Confg)
    End Sub

    Dim LST As List(Of String) = New List(Of String)

    Private Sub AToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AToolStripMenuItem.Click
        If lbMC.Text = "lbMC" Then
            MsgBox("กรุณาเลือกเครือง ")
            Exit Sub
        End If

        ' '' ''Find Object owner of contexstrip
        ''Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        ''Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        ''If Not lbMC.Text = cms.SourceControl.Text Then
        ''    MsgBox("กรุณาเลือกเครือง ให้ตรงกับ  M/C no.")
        ''    Exit Sub
        ''End If

        If lbTestName.Text = "" Or lbTestName.Text = "lbTesterName" Then
            MsgBox("กรุณาใส่ชื่อ Tester ")
            Exit Sub
        End If

        For i = 0 To Confg.TesterName.Length - 1                 'Remove Duplicate record
            If lbMC.Text = Confg.TesterName(i).Split(",")(0) Then
                LST.Remove(Confg.TesterName(i))
            End If

        Next

        LST.Add((lbMC.Text & "," & lbTestName.Text))
        Array.Resize(Confg.TesterName, LST.Count)

        For i = 0 To LST.Count - 1
            Confg.TesterName(i) = LST(i)
        Next

        WrXml(SelPath & "Config.xml", Confg)


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
    Private Sub ContextMenuStrip2_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening

        If Not lbMC.Text = ContextMenuStrip2.SourceControl.Text Then                   'Data on screen load finish
            AToolStripMenuItem.Enabled = False
            LotCacelToolStripMenuItem.Enabled = False
            ManualEndToolStripMenuItem.Enabled = False
        Else
            AToolStripMenuItem.Enabled = True
            LotCacelToolStripMenuItem.Enabled = True
            ManualEndToolStripMenuItem.Enabled = True
        End If

    End Sub


    Private Sub LotCacelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LotCacelToolStripMenuItem.Click
        If Not MsgBoxResult.Yes = MsgBox("การ Cancel Lot จะทำให้ข้อมูลปัจจุบันถูกล้าง  ต้องการยืนยันการ  Cancel Lot กด  YES", MsgBoxStyle.YesNo) Then
            Exit Sub
        End If
        PassWord("MAP")
        If Not Pbx.Level = "MAP" Then
            Exit Sub
        End If
        Dim ans As String
        ans = LotCancel(lbMC.Text, lbLotNo.Text)
        If ans Like "BError*" Then                   'Basic check Error
            lbStatus.Show()
            lbStatus.Text = ans
            Exit Sub
        End If
        ' SendPostMessage("@LOTEND|" & ProcessHeader & lbMC.Text & "|" & lbLotNo.Text & "," & _
        'lbEnd.Text & "," & lbGood.Text & "," & CInt(lbInput.Text) - CInt(lbGood.Text) & ",03") 'Lot End > Results reset type
        'Dim resEnd As TdcResponse = m_TdcService.LotEnd(ProcessHeader & lbMC.Text, lbLotNo.Text, CDate(lbEnd.Text), CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text), EndModeType.AbnormalEndReset, lbOp.Text)
        RetestLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text)
        'EMS end
        Try
            m_EmsClient.SetOutput(lbMC.Text, CInt(lbGood.Text), CInt(lbInput.Text) - CInt(lbGood.Text))
            m_EmsClient.SetLotEnd(lbMC.Text) 'LA-01
            m_EmsClient.SetActivity(lbMC.Text, "Stop", TmeCategory.StopLoss)
        Catch ex As Exception
            SaveLog(Message.Cellcon, "SetActivity Stop Cancel:" & ex.ToString)
        End Try

        DBxDataSet.TransactionData.Clear()
        DBxDataSet.MAPOSFTData.Clear()
        DBxDataSet.MAP_MAPData.Clear()
        MAPOSFTDataBindingSource.Position = 0          'Update new data 
        TransactionDataBindingSource.Position = 0
        If ans Like "Error*" Then
            lbStatus.Show()
            lbStatus.Text = ans
        End If
    End Sub
    Private Sub ManualEndToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualEndToolStripMenuItem.Click
        If Not MsgBoxResult.Yes = MsgBox("การทำ Manual LotEnd ไม่ควรทำขณะเครื่องผลิตอยู่  ยืนยัน กด  YES", MsgBoxStyle.YesNo) Then
            Exit Sub
        End If
        PassWord("MAP")
        If Not Pbx.Level = "MAP" Then
            Exit Sub
        End If
        If lbLotNo.Text = "" Then
            MsgBox("ไม่สามารถทำการ Manual End ได้เนื่องจาก ไม่มี  LotData ใน เครื่อง Selcon")
            Exit Sub
        End If
        Dim ans As String
        ans = clsNfdMap.GetProberInfo(lbMC.Text)
        If ans = "AUTO" Or ans = "STOP" Then
            'Cursor.Current = precursor
            MsgBox("ไม่สามารถทำการ Manual End ได้เนื่องจาก M/C กำลังผลิตอยู่ ให้ทำการ Initialize IPBC ใหม่ แล้วลองอีกครั้ง")
            Exit Sub
        End If

        If Not Directory.GetFiles(MapdataPath & lbMC.Text).Length > 0 Then
            MsgBox("ไม่สามารถทำการ Manual End ได้เนื่องจาก ไม่มี MAPDataใน เครื่อง Selcon")
            Exit Sub
        End If

        ans = DBxMapMAapdataSave(lbMC.Text, lbLotNo.Text)
        If ans Like "Error*" Then
            lbStatus.Show()
            lbStatus.Text = ans
            Exit Sub
        End If
        MsgBox("MAPdata Save End กรุณา กด END เพื่อทำการ SaveWorkRecord")
        btnFinal.BackColor = Color.Yellow

    End Sub

#End Region


    'M/C Name Button Click
    'ErrorProvider1
    'ToolStripmenu DEL,TESTER NAME SAVE


#Region "===Master Option"
    Public Insert As Boolean
    Dim clickLb As Boolean


    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        DBxDataSet.MAPOSFTData.Clear()
        DBxDataSet.TransactionData.Clear()
        Insert = True
        lbMaster.Select()                       'Focus at Master
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
                DBxDataSet.MAPOSFTData.Rows(0)("LotEndTime") = DateTimePicker1.Value
            End If
        Else
            DBxDataSet.MAPOSFTData.Rows(0)("LotStartTime") = DateTimePicker1.Value
        End If
    End Sub


    Private Sub lb_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.TextChanged
        DateTimePicker1.Hide()
    End Sub



#End Region

#Region "=== IPBC Auto Main"
    Private Delegate Sub AddItemDelegate(ByVal item As String)
    Private Delegate Sub OnPrintDelegate(ByVal str As String)

    Dim myListenSocket As Socket = Nothing
    Dim mySessionSocket As Socket = Nothing
    Private ready As New Object
    Private FlagExit As Boolean
    '//***********************************************************
    '//ソケット通信の開始処理
    '//***********************************************************   
    '//ソケット通信開始
    Private Sub StartSock()
        '//サーバースタート
        Dim OpenFlg As Boolean
        OpenFlg = ServerStart()
    End Sub

    '//***********************************************************
    '//セカンドスレッドの作成とサーバーのスタート
    '//***********************************************************
    Private Function ServerStart() As Boolean
        '//サーバーの接続の確立
        '//スレッドの作成と開始
        Dim myThread As Thread
        myThread = New Thread(AddressOf MyServiceLoop)
        myThread.IsBackground = True
        myThread.Start()
        Return True
    End Function

    'サーバーの処理
    Sub MyServiceLoop()

        '変数の宣言

        Dim myAddress As IPAddress
        Dim myPort As Integer
        Dim myEndPoint As EndPoint
        Dim mySession As clsSession
        Dim tex As String
        Try
            '待機ソケットを作成する
            myListenSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            '//メインスレッドのテキストボックスに書き込む

            'tex = "待機ソケットを作成しました。"
            'TBoxLogWriteText(tex)

            '自分のIPアドレスの55556番ポートを指定する
            myAddress = IPAddress.Any
            myPort = 55556
            myEndPoint = New IPEndPoint(myAddress, myPort)
            myListenSocket.Bind(myEndPoint)
            'tex = "バインドしました。"
            'TBoxLogWriteText(tex)

            '待機を開始する
            myListenSocket.Listen(10)
            tex = "Server Start"
            TBoxLogWriteText(tex)

            Do
                'クライアントの接続を待つ
                mySessionSocket = myListenSocket.Accept()

                '新しいSessionClassのインスタンスを作成する
                mySession = New clsSession(mySessionSocket)

                '接続メッセージの表示

                tex = mySession.MyGetID() & " is connected."
                TBoxLogWriteText(tex)
                tex = mySession.MyGetID() & " maked Socket."
                TBoxLogWriteText(tex)

                'イベントハンドラを設定する
                AddHandler mySession.Print, AddressOf OnPrint
                AddHandler mySession.Quit, AddressOf OnQuit

                '交信を別スレッドで開始する
                mySession.MyStartSession()
            Loop

        Catch ex As Exception
            'エラー処理
            If Not IsNothing(myListenSocket) Then
                myListenSocket.Close()
            End If
            If Not IsNothing(mySessionSocket) Then
                mySessionSocket.Close()
            End If
            'MessageBox.Show("Please restart this program?", PROCESS_NAME.ToUpper, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try
    End Sub

    'TDC
    '  Dim li As LotInfo
    Private m_LotReqQueue As String
    ' Private m_TdcService As TdcService
    '  Dim m_dlg As TdcAlarmMessageForm
    Enum MCLock
        Unlock
        Lock

    End Enum
    Private Structure TDC_Parameter
        Dim LotNo As String
        ' Dim StartMode As RunModeType
        Dim TimeStamp As Date
        Dim GoodPcs As Integer
        Dim NgPcs As Integer
        '   Dim EndMode As EndModeType
        Dim EqNo As String
        Dim OPID As String
    End Structure

    'Printイベントハンドラ
    Overloads Sub OnPrint(ByVal str As String)     'Recieve data

        If Me.InvokeRequired Then
            Me.Invoke(New OnPrintDelegate(AddressOf OnPrint), str)
            Exit Sub
        End If
        Try


            Dim strCommand As String()
            Dim strSendCmd As String = ""
            Dim tex As String
            Dim ans As String
            Dim errmess As String
            Dim strCmd As String = ""
            Dim strMachineNo As String = ""
            Dim strAssyLotNo As String = ""
            Dim strMyID As String = ""
            strCommand = str.Split(",")

            Select Case True
                Case str Like "Recive*"

                    tex = str

                    TBoxReciveMessageWriteText(tex)


                Case str Like "True*"
                    SyncLock ready
                        strMyID = strCommand(1)
                        If strCommand.Length <= 4 Then   'Cmd format Err detect
                            strCmd = "Unknown"
                            strMachineNo = "Unknown"
                            strAssyLotNo = "Unknown"
                            Select Case strCommand.Length - 1
                                Case 0, 1
                                    strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "No good Format"
                                Case 2
                                    If strCommand(2) <> "" Then
                                        strCmd = strCommand(2)
                                    End If
                                    strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "No good Format"
                                Case 3
                                    If strCommand(2) <> "" Then
                                        strCmd = strCommand(2)
                                    End If
                                    If strCommand(3) <> "" Then
                                        strMachineNo = strCommand(3)
                                    End If
                                    strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "No good Format"
                                Case 4
                                    If strCommand(2) <> "" Then
                                        strCmd = strCommand(2)
                                    End If
                                    If strCommand(3) <> "" Then
                                        strMachineNo = strCommand(3)
                                    End If
                                    If strCommand(4) <> "" Then
                                        strAssyLotNo = strCommand(4)
                                    End If
                                    strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "No good Format"
                            End Select
                        Else
                            tex = str
                            TBoxReciveMessageWriteText(tex)

                            Dim MCexist As Boolean
                            For Each MCno As Button In Panel2.Controls        'Link M/C Confirm with Selcon M/C List
                                If MCno.Text = strCommand(3) Then
                                    'If Not lbMC.Text = strCommand(3) Then      'If MC already select No mcclick
                                    MCClick(MCno, Nothing)
                                    'End If
                                    MCexist = True
                                    Exit For
                                End If
                                MCexist = False
                            Next
                            If Not MCexist Then
                                strSendCmd = "Error," & strCommand(2) & "," & strCommand(3) & "," & strCommand(4) & "," & "MC No. not found"
                                GoTo sendLoop
                            End If


                            Select Case strCommand(2)
                                Case "LOTSTART"
                                    strCmd = "Unknown"
                                    strMachineNo = "Unknown"
                                    strAssyLotNo = "Unknown"
                                    If strCommand(2) <> "" Then        'Cmd
                                        strCmd = strCommand(2)
                                    End If
                                    If strCommand(3) <> "" Then        'MCNo
                                        strMachineNo = strCommand(3)
                                    End If
                                    If strCommand(4) <> "" Then        'LotNo
                                        strAssyLotNo = strCommand(4)
                                    End If



                                    '------Set Display data to User interface---

                                    If strCommand.Length >= 10 Then                   'Cmd corrective check RIST Cmd = 12, REPI Cmd =10

                                        'Lot Request
                                        'TDC -------------------------------------------------------------------------------
                                        '   

                                        ' If My.Settings.RunOffline = False Then
                                        Try
                                            If PermissionGetDataAPCS(strCommand(7), strCommand(4)) = False Then
                                                strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "No Permiision "
                                                GoTo sendLoop
                                            End If
                                        Catch ex As Exception
                                            Dim frm As MsgShow = New MsgShow
                                            frm.txt = "Error:PermissionGetDataAPCS :" & ex.ToString
                                            frm.Show()
                                            clsErrorLog.addlogWT("Error:PermissionGetDataAPCS/" & strSendCmd & ">>" & ex.ToString)
                                        End Try

                                        If My.Settings.RetestMode = True And strCommand(10).ToUpper = "RNG" Then
                                                GoTo RunModeRetest
                                            End If

                                        '<0>,<Selcon IP>,<Cmd >,<M/Cno3>,<LotNo3>, <Package5>,<Devic6e>,<OPNo7>,<Process8>,<TestPro9>,<TestMode10>,<BoxName>

                                        'If Not SetupLot(strAssyLotNo, "MAP-" & lbMC.Text, strCommand(7), "MAP", "", strCommand, strSendCmd) Then
                                        '    strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "TDC Error "
                                        '    GoTo sendLoop
                                        'End If

                                        'If LotRequestTDC(strAssyLotNo, RunModeType.Normal, "MAP-" & lbMC.Text) = False Then
                                        '    'TbQRInput.Text = ""
                                        '    ' TbQRInput.Select()
                                        '    ' GoTo FailTDC
                                        '    strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "TDC Error "

                                        '    GoTo sendLoop
                                        'End If
RunModeRetest:

                                            ' End If

                                            Dim lotexist As New DBxDataSet.MAPOSFTDataDataTable

                                        lotexist = MAPOSFTDataTableAdapter.GetDataLotExist(strAssyLotNo)


                                        If lotexist.Count > 0 Then  'If Lot Exist Go to Error
                                            'If lotexist.Rows(0)("MCNo") = strMachineNo Then              'Same Lot,M/C and Mode=addition LOT Start can continue.  
                                            '    If strCommand(10) Like "addition" Then
                                            '        GoTo Loopnext1
                                            '    End If
                                            'End If

                                            strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "Lot already exist at" & lotexist.Rows(0)("MCNo")
                                            lbStatus.Show()
                                            lbStatus.Text = " : Lot (" & strAssyLotNo & ")กำลังผลิตอยู่ที่ " & lotexist.Rows(0)("MCNo") & "ไม่สามารถผลิต Lotซ้ำได้"
                                            GoTo sendLoop

                                        End If

                                        If Not lbLotNo.Text = "" Then  'If other Lot Exist at this MC Go to Error
                                            strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "Lot already exist "
                                            lbStatus.Text = lbMC.Text & " : Lot (" & lbLotNo.Text & ")กำลังผลิตอยู่ไม่สามารถผลิต Lotใหม่ได้(" & strAssyLotNo & ")"
                                            GoTo sendLoop

                                        End If
                                        ' ''------Tester Auto Load ---------

                                        ans = TestProLoadAuto(strMachineNo, strCommand(9), strCommand(7))     '(9)>Program Name , (7)> OPname

                                        ProgressBar1.Hide()
                                        If ans = "True" Then
                                            strSendCmd = "Success," & strCmd & "," & strMachineNo & "," & strAssyLotNo
                                        Else   'If test auto load fail continue with Manual load <warning> 
                                            errmess = ans.Substring(ans.IndexOf(":") + 1, ans.Length - ans.IndexOf(":") - 1)
                                            lbStatus.Show()
                                            lbStatus.Text = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & errmess
                                            clsErrorLog.addlogWT("Error:LOTSTART/" & strMachineNo & "," & strAssyLotNo & "," & errmess, "Form1")

                                        End If

                                        System.Threading.Thread.Sleep(1000)
                                        ' ''------Tester Auto Load -----


                                        ans = DBxMapMAapdataLoad(strMachineNo, strAssyLotNo, strCommand(8), strCommand(10))          'Load Map data Server to C;\NFD\MCNO
                                        If ans Like "Error*" Then
                                            strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "Dbx MAPData Load have some error"
                                            lbStatus.Show()
                                            lbStatus.Text = strMachineNo & "_" & strAssyLotNo & ans
                                            GoTo sendLoop

                                        End If


                                        If Not SetupLot(strAssyLotNo, "MAP-" & lbMC.Text, strCommand(7), "MAP", "", strCommand, strSendCmd) Then
                                            strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "TDC Error "
                                            GoTo sendLoop
                                        End If
                                        'Dim ETC2 As String = Trim(WorkSlipData.Substring(232, 20))
                                        'Dim QROpNo As String = TbQRInput.Text
                                        'If PermiisionCheck(ETC2, QROpNo, My.Settings.MC_MAPGroup, My.Settings.GL_MAPGroup, "MAP", ProcessHeader & Form1.lbMC.Text) = False Then
                                        '    MsgBox(ErrMesETG)
                                        '    TbQRInput.Text = ""
                                        '    TbQRInput.Select()
                                        'strSendCmd = "Error not Permission Please check Permission OP No. and Machine"
                                        'GoTo sendLoop
                                        '    Exit Sub
                                        'End If
                                        'CreateDBxMapT >> Lotset
                                        If CreateDBxMapT(str) Like "Error*" Then         'Save WorkRecord record tbl to DBx
                                            strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "Dbx MAPOSFT can not Save record"
                                            GoTo sendLoop
                                        End If

                                        'Query Package(Binding) , Device(Binding)
                                        If lbLotNo.Text <> "" And Not Confg.Offline Then
                                            Me.TransactionDataTableAdapter.Fill(DBxDataSet.TransactionData, lbLotNo.Text)
                                        End If

                                        ' ''------Tester Auto Load ---------
                                        ''System.Threading.Thread.Sleep(1000)

                                        ''ans = TestProLoadAuto(strMachineNo)

                                        ''ProgressBar1.Hide()
                                        ''If ans = "True" Then
                                        ''    strSendCmd = "Success," & strCmd & "," & strMachineNo & "," & strAssyLotNo
                                        ''Else   'If test auto load fail continue with Manual load <warning> 
                                        ''    errmess = ans.Substring(ans.IndexOf(":") + 1, ans.Length - ans.IndexOf(":") - 1)
                                        ''    lbStatus.Show()
                                        ''    lbStatus.Text = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & errmess
                                        ''    clsErrorLog.addlogWT("Error:LOTSTART/" & strMachineNo & "," & strAssyLotNo & "," & errmess, "Form1")

                                        ''End If
                                        ' ''------Tester Auto Load ---------

                                        strSendCmd = "Success," & strCmd & "," & strMachineNo & "," & strAssyLotNo
                                    Else
                                        strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "No good Format"
                                    End If


                                Case "LOTEND"
                                    strCmd = "Unknown"
                                    strMachineNo = "Unknown"
                                    strAssyLotNo = "Unknown"
                                    If strCommand(2) <> "" Then
                                        strCmd = strCommand(2)
                                    End If
                                    If strCommand(3) <> "" Then
                                        strMachineNo = strCommand(3)
                                    End If
                                    If strCommand(4) <> "" Then
                                        strAssyLotNo = strCommand(4)
                                    End If

                                    If strCommand.Length >= 10 Then
                                        If Not lbLotNo.Text = strAssyLotNo Then
                                            strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "Missing Lot No.End"
                                            lbStatus.Show()
                                            lbStatus.Text = lbMC.Text & " : การจบ  Lot (" & lbLotNo.Text & ")กำลังผลิตอยู่ไม่ตรง Lot (" & strAssyLotNo & ") จาก IPBC"
                                            clsErrorLog.addlogWT("Error:OnPrint.LotEnd / " & lbMC.Text & "_" & lbLotNo.Text & "Lot END No.Missing(" & strAssyLotNo & ")", "Form1")
                                            GoTo sendLoop
                                        End If

                                        ans = DBxMapMAapdataSave(strMachineNo, strAssyLotNo)    'Mapdata save with Out Endtime
                                        If ans Like "Error*" Then
                                            strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & ans
                                            GoTo sendLoop
                                        End If
                                        strSendCmd = "Success," & strCmd & "," & strMachineNo & "," & strAssyLotNo
                                    Else
                                        strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "No good Format"
                                    End If
                                Case Else
                                    strCmd = "Unknown"
                                    strMachineNo = "Unknown"
                                    strAssyLotNo = "Unknown"
                                    If strCommand(2) <> "" Then
                                        strCmd = strCommand(2)
                                    End If
                                    If strCommand(3) <> "" Then
                                        strMachineNo = strCommand(3)
                                    End If
                                    If strCommand(4) <> "" Then
                                        strAssyLotNo = strCommand(4)
                                    End If

                                    strSendCmd = "Error," & strCmd & "," & strMachineNo & "," & strAssyLotNo & "," & "No good Format"
                            End Select
                        End If

sendLoop:
                        SyncLock clsSession.mySessionList.SyncRoot              'Send return message
                            Dim session As clsSession
                            For Each session In clsSession.mySessionList
                                If strMyID = session.MyGetID Then
                                    session.MyWriteLine(strSendCmd)
                                End If
                            Next
                        End SyncLock
                        '送信したデータを表示する
                        tex = strSendCmd
                        TBoxReciveMessageWriteText(tex)
                    End SyncLock
                Case Else
                    tex = str
                    TBoxLogWriteText(tex)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    ' Dim dlg As TdcAlarmMessageForm
    'Function LotRequestTDC(ByVal LotNo As String, ByVal rm As RunModeType, ByVal MCNo As String) As Boolean
    '    ' Dim mc As String = "MAP-" & MCNo
    '    Dim strMess As String = ""
    '    Dim res As TdcLotRequestResponse = m_TdcService.LotRequest(MCNo, LotNo, rm)

    '    If res.HasError Then

    '        Using svError As ApcsWebServiceSoapClient = New ApcsWebServiceSoapClient
    '            If svError.LotRptIgnoreError(MCNo, res.ErrorCode) = False Then
    '                Dim li As LotInfo = Nothing
    '                li = m_TdcService.GetLotInfo(LotNo, MCNo)
    '                'Using dlg As TdcAlarmMessageForm = New TdcAlarmMessageForm(res.ErrorCode, res.ErrorMessage, LotNo, li)
    '                '    dlg.TopMost = True
    '                '    dlg.Show()
    '                '    Return False
    '                'End Using

    '                dlg = New TdcAlarmMessageForm(res.ErrorCode, res.ErrorMessage, LotNo, li)
    '                dlg.TopMost = True
    '                dlg.Show()
    '                Return False

    '            End If
    '        End Using
    '        strMess = res.ErrorCode & " : " & res.ErrorMessage
    '        Return True
    '    Else
    '        strMess = "00 : Run Normal"
    '        Return True
    '    End If
    'End Function
    ' TboxLog
    Private Sub TBoxLogWriteText(ByVal text As String)

        If Me.InvokeRequired Then
            Me.Invoke(New AddItemDelegate(AddressOf TBoxLogWriteText), New Object() {text})
        Else
            If IsNothing(f2) OrElse f2.IsDisposed Then
                f2 = New Form2
            End If
            text = text.Replace(Environment.NewLine, vbCrLf)
            f2.TBoxLog.AppendText(text & vbCrLf)
        End If
    End Sub

    ' TboxReciveMessage
    Private Sub TBoxReciveMessageWriteText(ByVal text As String)

        If Me.InvokeRequired Then
            Me.Invoke(New AddItemDelegate(AddressOf TBoxReciveMessageWriteText), New Object() {text})
        Else

            If IsNothing(f2) OrElse f2.IsDisposed Then
                f2 = New Form2
            End If
            text = text.Replace(Environment.NewLine, vbCrLf)
            f2.TBoxReciveMessage.AppendText(text & vbCrLf)
        End If
    End Sub


    'Quitイベントハンドラ
    Sub OnQuit(ByVal session As clsSession)
        'イベントハンドラを解除する
        RemoveHandler session.Print, AddressOf OnPrint
        RemoveHandler session.Quit, AddressOf OnQuit
    End Sub
    '<0>,<Selcon IP>,<Cmd >,<M/Cno3>,<LotNo3>, <Package5>,<Devic6e>,<OPNo7>,<Process8>,<TestPro9>,<TestMode10>,<BoxName>
    'True,10.28.32.70,LOTSTART,OS-02,1031A4054V,SSON004X12,BU52031NVX-S1(8A9),870391,OS,ABCDE,rgood,--  
    'True,10.28.32.70,LOTEND,OS-02,1031A4054V,SSON004X12,BU52031NVX-S1(8A9),870391,OS,ABCDE,addition,--
    'True,10.28.32.70,LOTSTART,OS-02,1031A4054V,SSON004X12,BU52031NVX-S1(8A9),870391,OS,ABCDE,new,--
    'True,10.28.32.70,LOTSTART,OS-02,1031A4054V,SSON004X12,BU52031NVX-S1(8A9),870391,OS,ABCDE,rng,--


    Private Function CreateDBxMapT(ByVal str As String) As String

        Try
            Dim dr As DBxDataSet.MAPOSFTDataRow = DBxDataSet.MAPOSFTData.NewRow
            Dim strCommand As String()
            Dim lotno As String
            Dim inputQty As Integer = 1                        'Calculate can not /0


            strCommand = str.Split(",")
            lotno = strCommand(4)

            'Input Qty Get --------

            If lotno.Length = 10 Then                      'Lotno blank check
                Dim goodTbl As New DBxDataSet.MAPOSFTDataDataTable
                If strCommand(8) Like "AUTO*" And lotno Like "*A*" Then         'FT Get goood from OS 'ถ้า F lot ค่า input มาจาก labeler

                    MAPOSFTDataTableAdapter.FillBy(goodTbl, lotno)
                    If goodTbl.Count > 0 Then
                        If Not IsNumeric(goodTbl.Rows(0)("TotalGood")) Then
                            lbStatus.Show()
                            lbStatus.Text = lbMC.Text & " : ไม่มีค่างาน Goods ของ  Process ก่อนหน้า ให้ใส่ค่า   Input Pcs โดยการคีย์"
                            'MsgBox("ไม่มีค่างาน Goods ของ  Process ก่อนหน้า ให้กลับไปตรวจสอบและทำการแก้ไขให้ถูกต้อง")
                            GoTo nextstep
                        End If

                        If strCommand(10) Like "rng" Then        'if AUOT* Rng input is not change
                            inputQty = goodTbl.Rows(0)("InputQty")
                        Else
                            inputQty = goodTbl.Rows(0)("TotalGood")
                        End If



                    Else
                        lbStatus.Show()
                        lbStatus.Text = lbMC.Text & " : ไม่สามารถทำการผลิตได้เนื่องจาก ใน Process OS ไม่มีประวัติ Lotนี้"
                        clsErrorLog.addlogWT("Error:CreateDBxMapT/ไม่สามารถทำการผลิตได้เนื่องจาก ใน Process OS ไม่มีประวัติ Lotนี้", "Form1")
                        Return "Error :"
                        ''MsgBox("ไม่สารถทำการผลิตได้เนื่องจาก ใน Process OS ไม่มีประวัติ Lotนี้")
                    End If
                Else                                       'OS OS/FT Get good from AUTO Label 

                    MAPALDataTableAdapter.FillBy(DBxDataSet.MAPALData, lotno)
                    If DBxDataSet.MAPALData.Count > 0 Then
                        If Not IsNumeric(DBxDataSet.MAPALData.Rows(0)("TotalGood")) Then
                            lbStatus.Show()
                            lbStatus.Text = lbMC.Text & " : ไม่มีค่างาน Goods ของ  Process ก่อนหน้า ให้ใส่ค่า   Input Pcs โดยการคีย์"
                            'MsgBox("ไม่มีค่างาน Goods ของ  Process ก่อนหน้า ให้กลับไปตรวจสอบและทำการแก้ไขให้ถูกต้อง")
                            GoTo nextstep
                        End If
                        inputQty = DBxDataSet.MAPALData.Rows(0)("TotalGood")
                    Else
                        lbStatus.Show()
                        lbStatus.Text = lbMC.Text & " : เนื่องจาก ใน Process Auto Label ไม่มีประวัติ Lotนี้ ให้ใส่ค่า   Input Pcs โดยการคีย์"
                        'MsgBox("ไม่สารถทำการผลิตได้เนื่องจาก ใน Process Auto Label ไม่มีประวัติ Lotนี้")
                    End If
                End If

            Else
                clsErrorLog.addlogWT("Error:CreateDBxMapT/Lot No. ไม่ถูกต้อง(" & lotno & ")", "Form1")
                Return "Error :"

            End If
            '--------------------------------Input Qty Get
nextstep:

            dr.MCNo = ProcessHeader & lbMC.Text
            dr.LotNo = lotno
            dr.InputQty = inputQty
            dr.OPNo = strCommand(7)
            dr.LotStartTime = Format(Now, "yyyy/MM/dd HH:mm:ss")
            dr.Process = strCommand(8)
            dr.ProgramName = strCommand(9)
            dr.BoxName = strCommand(11)
            If Not strCommand(8) Like "AUTO*" Then                      ''If FT MAPOS is null _130904
                dr.MAPOS = 0
            End If
            DBxDataSet.MAPOSFTData.Rows.InsertAt(dr, 0)
            MAPOSFTDataBindingSource.Position = 0          'Update new data 
            '---- Get by IPBC ----------
            '' ''ProceTempList.RemoveAll(Function(item) item.Txt = lbMC.Text)   'Remove save dbx item
            'DBx MAPOSFT Create record
            If Not lbLotNo.Text = "" Then

                'LotSet
                StartLot(lbLotNo.Text, ProcessHeader & lbMC.Text, lbOp.Text, m_Recipe)
                m_Recipe = Nothing

                ''    SendPostMessage("@LOTREQ" & "|" & ProcessHeader & lbMC.Text & "|" & lbLotNo.Text & "," & lbOp.Text & ",00")   'Normal
                'Dim resSet As TdcResponse = m_TdcService.LotSet(ProcessHeader & lbMC.Text, lbLotNo.Text, CDate(lbStart.Text), lbOp.Text, RunModeType.Normal)
                'EMS monitor
                Try
                    m_EmsClient.SetCurrentLot(lbMC.Text, lbLotNo.Text, 0)
                    m_EmsClient.SetActivity(lbMC.Text, "Running", TmeCategory.NetOperationTime)
                Catch ex As Exception
                    SaveLog(Message.Cellcon, "SetActivity Running:" & ex.ToString)
                End Try

                If WrDBX() Like "Error*" Then
                    Return "Error :"
                    clsErrorLog.addlogWT("Error:CreateDBxMapT/WrDBX()Err_" & lbLotNo.Text, "Form1")
                End If
            End If

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:CreateDBxMapT/" & ex.ToString, "Form1")
            Return "Error :"
        End Try
        Return "True"

    End Function

    '-----------------------------------------------------------DBxMapMAapdataSave
    '1. Get data from XML File  C:\NFD\MCNo ,6 item
    '2. Save Q'ty to DbxMapOSFTdata<Server>
    '3. Zip fr MapdataPath & MCNO to  ZipDir
    '4. Save DbxMAP_MAPData<Server>

    Private Function DBxMapMAapdataSave(ByVal MCNO As String, ByVal LOTNO As String) As String

        Dim DrMap As DBxDataSet.MAP_MAPDataRow = DBxDataSet.MAP_MAPData.NewRow
        Dim startPath As String = MapdataPath & MCNO
        Dim ZipDir As String = MapZipDestin
        Dim ZipDirBack As String = MapZipDestin & "BackUp\"
        Dim XmlCount As Integer = Directory.GetFiles(startPath, "*.Xml").Length
        Dim XMLDoc As New XDocument
        If XmlCount = 1 Then
            Dim FileName As String = Directory.GetFiles(startPath, "*.Xml")(0)
            'FileName = Path.GetFileNameWithoutExtension(FileName)                'GetFile Name without Ext
            XMLDoc = XDocument.Load(FileName)
            Dim log = From l In XMLDoc.Descendants("log") Select l                 '<Log> Child
            If log.Count > 0 Then                                                  '<Log> Exist is >0
                Dim TestType = From tt In log(log.Count - 1).Descendants("test_type") Select tt.Value       'Last<Log>,Test type get
                Dim TestMode = From tm In log(log.Count - 1).Descendants("test_mode") Select tm.Value       'Last<Log>,Test Mode get
                Dim Good = From gd In log(log.Count - 1).Descendants("pass_total") Select gd.Value
                Dim OSNG = From sn In log(log.Count - 1).Descendants("fail_os_total") Select sn.Value
                Dim Ftotal = From ft In log(log.Count - 1).Descendants("fail_total") Select ft.Value
                Dim DWBNG = From dw In log(log.Count - 1).Descendants("prefail_total") Select dw.Value

                Try


                    Dim row As DataRow = Me.DBxDataSet.MAPOSFTData.Rows(0)
                    row("TotalGood") = Good.First
                    If Not lbProcess.Text Like "AUTO*" Then                            'AUTO Test MAPOS is NULL
                        row("MAPOS") = OSNG.First - DWBNG.First                        'OSng = OS-DWBNg
                        row("D_WBNG") = DWBNG.First
                    End If

                    row("FTNG") = Ftotal.First - OSNG.First

                    ' Auto calculate Update
                    Dim index As Integer = Me.DBxDataSet.MAPOSFTData.Columns.IndexOf("FTNG")    'Get offset index of work column
                    Dim Sum As Integer = 0
                    For i = 7 To 11                                                             'Controls in panel1 WB inspection item                         
                        If IsNumeric(row(i + index - 7)) Then
                            Sum += row(i + index - 7)
                        End If
                    Next
                    row("TotalNG") = Sum

                    If IsNumeric(lbGood.Text) Then
                        row("Diff") = row("InputQty") - row("TotalGood") - row("TotalNG")
                    End If

                    row("FTYield") = FormatNumber((row("InputQty") - row("FTNG")) * 100 / row("InputQty"), 1)

                    If Not lbProcess.Text Like "AUTO*" Then
                        row("MAPOSYield") = FormatNumber((row("InputQty") - row("MAPOS")) * 100 / row("InputQty"), 1)    'AUTO Test MAPOS is NULL
                    End If


                    '-----------------------

                    If WrDBX() Like "Error*" Then 'Save to DBxMAPOSFT<Server>
                        clsErrorLog.addlogWT("Error:DBxMapMAapdataSave/" & MCNO & "_" & LOTNO & DrMap.ProcessMode, "Form1")
                    End If
                Catch ex As Exception
                    clsErrorLog.addlogWT("Warning:Form1/DBxMapMAapdataSave/MapOSFT Q'ty Save Error" & MCNO & "_" & LOTNO & DrMap.ProcessMode & ex.ToString, "Form1")
                End Try


                Dim StrProcessMode As String = ""
                Select Case TestType.First
                    Case 0 'OS
                        StrProcessMode = "OS"
                    Case 1
                        StrProcessMode = "AUTO1"
                    Case 2
                        StrProcessMode = "AUTO2"
                    Case 3
                        StrProcessMode = "AUTO3"
                    Case 4
                        StrProcessMode = "AUTO4"
                    Case 5
                        StrProcessMode = "OSFT"
                End Select


                If Not DBxDataSet.MAPOSFTData.Rows(0)("Process") = StrProcessMode Then
                    clsErrorLog.addlogWT("Error :Form1/DBxMapMAapdataSave/Process wrong " & MCNO & "_" & LOTNO _
                                         & " | OP Process : " & lbProcess.Text & " , MapProcess : " & StrProcessMode & " | ", "Form1")
                    Return "Error:Process wrong"
                    Exit Function
                End If


                Select Case TestMode.First
                    Case 0
                        StrProcessMode = StrProcessMode & "_NEW"
                    Case 1
                        StrProcessMode = StrProcessMode & "_RGood"
                    Case 2
                        StrProcessMode = StrProcessMode & "_RNG"
                    Case 3
                        StrProcessMode = StrProcessMode & "_ADD"
                End Select

                DrMap.ProcessMode = StrProcessMode
                ZipDir = ZipDir & LOTNO & "." & Format(Now, "yyyyMMddHHmm") & "." & StrProcessMode & ".zip"

            End If

        Else
            clsErrorLog.addlogWT("Error:DBxMapMAapdataSave/No file XML found or Exist XML more 1 file", " Form1")
            Return "Error:No file XML found or Exist XML more 1 file."
        End If


        ''Zip to Destination-------------------------

        If Not clsNfdMap.zipFiles(startPath, ZipDir) Then
            clsNfdMap.deleteFile(ZipDir)
            clsErrorLog.addlogWT("Error:DBxMapMAapdataSave/CanNotzipFile:", " Form1")
            Return "Error:Can Not zipFile."
            Exit Function
        End If

        'Save zip to DBx MAPdata -------------------
        If MCNO = lbMC.Text Then                                  'Final Comfirm MCNo
            Dim data As Byte() = File.ReadAllBytes(ZipDir)
            DrMap.MAPData = data
            DrMap.LotNo = LOTNO
            DrMap.MCNo = "MAP-" & MCNO
            DrMap.Process = lbProcess.Text
            DrMap.LotStartTime = DBxDataSet.MAPOSFTData.Rows(0).ItemArray(2)
            DBxDataSet.MAP_MAPData.Rows.InsertAt(DrMap, 0)

            Try
                If MAP_MAPDataTableAdapter.Update(DBxDataSet.MAP_MAPData) > 0 Then
                    DBxDataSet.MAP_MAPData.Clear()
                    clsNfdMap.copyFileToDir(ZipDir, ZipDirBack)
                    clsNfdMap.deleteFile(ZipDir)
                    ZipDir = ""
                End If

            Catch ex As Exception
                clsErrorLog.addlogWT("Error:" & MCNO & "_" & LOTNO & DrMap.ProcessMode & "DBxMapMAapdataSave/" & ex.ToString, "Form1")
                Return "Error:"
            End Try
        Else
            clsErrorLog.addlogWT("Error:DBxMapMAapdataSave/Active MC<" & lbMC.Text & "> Not Same IPBC Sender<" & MCNO & ">", "Form1")
            Return "Error:Active MC Not Same IPBC Sender"
        End If
        Return "True"

    End Function

    '-----------------------------------------------------------DBxMapMAapdataLoad
    '1. Load Map from DBx to Zip File <UnzipDir>
    '2. UnZip File <UnzipDir> to <C:\NFD\MCNo.>

    Private Function DBxMapMAapdataLoad(ByVal MCNO As String, ByVal LOTNO As String, ByVal PROCESS As String, ByVal ProcessMode As String) As String

        Dim UnZipDir As String = MapZipDestin
        Dim UnZipDirDestin As String = MapdataPath & MCNO
        Dim data As Byte()

        If Directory.GetFiles(UnZipDirDestin).Length > 0 Then        'Map file exist check
            clsErrorLog.addlogWT("Error:DBxMapMAapdataLoad/Already use" & UnZipDirDestin & "\" & MCNO & "_" & LOTNO, "Form1")
            Return "Error:Already use" & UnZipDirDestin
        End If

        MAP_MAPDataTableAdapter.FillLotNo(DBxDataSet.MAP_MAPData, LOTNO)

        If DBxDataSet.MAP_MAPData.Count = 0 Then                    'No Record Exit
            If PROCESS Like "OS*" Then       'OS,OS+FT No Record OK
                Return True
            End If
            '---Case AUTO*  Error
            clsErrorLog.addlogWT("Error:DBxMapMAapdataLoad/Target MapData not exist_" & MCNO & "_" & LOTNO, "Form1")
            Return "Error:Target MapData not exist"
        End If
        data = DBxDataSet.MAP_MAPData.Rows(0)("MAPData")
        'Dim ProcMode As String = DBxDataSet.MAP_MAPData.Rows(0)("ProcessMode")
        Dim ProcName As String = DBxDataSet.MAP_MAPData.Rows(0)("Process")

        Select Case PROCESS                             'From IPBC
            Case "OS"
                If Not ProcName Like "OS" Then
                    clsErrorLog.addlogWT("Error:DBxMapMAapdataLoad/Mapdata Miss Macth OS : <Select> OS / <MapData>" & ProcName & "_" & MCNO & "_" & LOTNO, "Form1")
                    Return "Error : ผิด Flow ข้อมูลจากเครื่องเป็น  OS ข้อมูลจากระบบMapdataเป็น" & ProcName
                End If
                If ProcessMode Like "new" Then              'OS_New  No load Mapdata 
                    Return True
                End If



            Case "AUTO1", "AUTO2", "AUTO3", "AUTO4"
                ' Change Flow OSFT -> AUTO* (OS+AUTO1) 140915
                'If ProcName Like "OSFT" Then
                '    clsErrorLog.addlogWT("Error:DBxMapMAapdataLoad/Mapdata Miss Macth AUTO* : <Select> AUTO* / <MapData>" & ProcName & "_" & MCNO & "_" & LOTNO, "Form1")
                '    Return "Error:ผิด Flow ข้อมูลจากเครื่องเป็น  AUTO* ข้อมูลจากระบบMapdataเป็น" & ProcName

                'End If

                If Not PROCESS = "AUTO1" Then
                    If ProcName Like "OS" Then    'IPBC Select AUTO2,3,4 but MapData OS
                        clsErrorLog.addlogWT("Error:DBxMapMAapdataLoad/Mapdata Miss Macth AUTO* : <Select>" & PROCESS & " / <MapData>" & ProcName & "_" & MCNO & "_" & LOTNO, "Form1")
                        Return "Error:ผิด Flow ข้อมูลจากเครื่องเป็น " & PROCESS & " ข้อมูลจากระบบMapdataเป็น" & ProcName

                    End If
                End If
                If Not ProcName Like "OS*" Then
                    If String.Compare(PROCESS, ProcName) < 0 Then
                        clsErrorLog.addlogWT("Error:DBxMapMAapdataLoad/Mapdata Miss Macth AUTO* : <Select>" & PROCESS & " / <MapData>" & ProcName & "_" & MCNO & "_" & LOTNO, "Form1")
                        Return "Error:ผิด Flow ข้อมูลจากเครื่องเป็น " & PROCESS & " ข้อมูลจากระบบMapdataเป็น" & ProcName

                    End If
                End If

            Case "OSFT"

                If Not ProcName Like "OSFT" Then
                    clsErrorLog.addlogWT("Error:DBxMapMAapdataLoad/Mapdata Miss Macth OSFT : <Select> OSFT / <MapData>" & ProcName & "_" & MCNO & "_" & LOTNO, "Form1")
                    Return "Error:ผิด Flow ข้อมูลจากเครื่องเป็น  OS+FT ข้อมูลจากระบบMapdataเป็น" & ProcName

                End If

                If ProcessMode Like "new" Then              'OSFT_New  No load Mapdata 
                    Return True
                End If

            Case Else
                clsErrorLog.addlogWT("Error:DBxMapMAapdataLoad/Mapdata Miss Macth Unknow : <Select>" & PROCESS & "  / <MapData>" & ProcName & "_" & MCNO & "_" & LOTNO, "Form1")
                Return "Error:Unknow Process ข้อมูลจากเครื่องเป็น " & PROCESS & "ข้อมูลจากระบบMapdataเป็น" & ProcName


        End Select


        UnZipDir = UnZipDir & DBxDataSet.MAP_MAPData.Rows(0)("LotNo") & "_" & ProcName & ".zip"
        File.WriteAllBytes(UnZipDir, data)
        DBxDataSet.MAP_MAPData.Clear()                               'Clear Data



        If Not clsNfdMap.unzipFiles(UnZipDir, UnZipDirDestin) Then
            clsNfdMap.deleteFile(UnZipDir)
            clsErrorLog.addlogWT("Error:DBxMapMAapdataLoad/CanNotUnzipFile", "Form1")
            Return "Error:CanNotUnzipFile"
        End If
        Return "True"
    End Function

    Public Function TestProLoadAuto(ByVal MCNO As String, ByVal ProName As String, ByVal OPName As String, Optional ByVal IsRunning As Boolean = False) As String

        '--- Check IPBC Staus
        Dim ans As String
        Dim dtNow = Now
        Dim max As Integer
        Dim tcnt As Integer
        Dim tmpTesterProgramName As String = ""
        Dim tmpProductionMode As String = ""
        Dim tmpPower As String = ""
        Dim tmpID As String = ""

        ProgressBar1.Show()
        ans = clsNfdMap.GetProberInfo(MCNO)
        If IsRunning And ans = "AUTO" Then
            Return "False:Can Not Conect IPBC <ON Running>"
        ElseIf IsRunning = False And (ans = "AUTO" Or ans = "STOP") Then
            'Cursor.Current = precursor
            Return "False:Can Not Conect IPBC <ON Running>"
        End If

        If Not MCNO = lbMC.Text Then
            Return "M/C Mathing ng"
        End If
        ans = clsSFTester.ProgramLoadAuto(lbTestName.Text.ToUpper, ProName, OPName, dtNow)
        If ans Like "Error*" Then
            MessageBox.Show("Can not Auto upload testprogram. Please manual upload " & vbCrLf & ans, lbProName.Text.ToUpper, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            Return "False:Auto Load Error"
        End If


        max = 80
        'FlagExit = False
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = max
        ProgressBar1.Value = 0


        For tcnt = 1 To max


            ans = clsSFTester.getTesterCondition(lbTestName.Text.ToUpper, tmpTesterProgramName, tmpProductionMode, tmpPower, tmpID)
            If tmpProductionMode = "YES" Then
                ProgressBar1.Value = 0
                Exit For
            End If
            Dim i As Integer
            For i = 1 To 25 ' 2.5sec
                t100wait()  ' 100msec
            Next
            ProgressBar1.Value = tcnt
            If FlagExit = True Then
                tcnt = max
                Exit For
            End If
        Next

        If tcnt >= max Then
            MessageBox.Show("Can not Auto upload testprogram. Please manual upload", lbProcess.Text.ToUpper, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End If
        ProgressBar1.Value = 0


        Return "True"

    End Function
    Private Sub t100wait()  '100msec
        System.Windows.Forms.Application.DoEvents()
        System.Threading.Thread.Sleep(100)
    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click
        Dim ans As DialogResult
        ans = MessageBox.Show("AutoDownLoad program Cancel ?", "AutoDownLoad Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        If ans = Windows.Forms.DialogResult.Yes Then
            FlagExit = True
        End If
    End Sub

    Private Function LotCancel(ByVal MCNO As String, ByVal LOTNO As String) As String

        Dim ans As String

        If Not My.Computer.Network.IsAvailable Then
            Return "BError : PC Nework point not Open"
        End If
        If Not My.Computer.Network.Ping(_ipDbxUser) Then            'Pink OK Exit
            Return "BError :การเชื่อมต่อกับฐานข้อมูล DB.X ล้มเหลวไม่สามารถดำเนินการต่อได้"
        End If

        ans = clsNfdMap.GetProberInfo(MCNO)
        If ans = "AUTO" Or ans = "STOP" Then
            'Cursor.Current = precursor
            Return "BError:Can Not Conect IPBC <ON Running>"
        End If

        Dim lotexist As New DBxDataSet.MAPOSFTDataDataTable
        lotexist = MAPOSFTDataTableAdapter.GetDataLotExist(LOTNO)
        If lotexist.Count = 0 Then
            Return "BError:Record Not found"
        End If

        If Not "MAP-" & MCNO = lotexist.Rows(0)("MCNo") Then
            Return "BError:Please Cancel with Macth M/C No."
        End If


        Try
            Dim endtime As DateTime = Format(Format(Now, "yyyy/MM/dd HH:mm:ss"))
            If IsDBNull(DBxDataSet.MAPOSFTData.Rows(0)("LotEndTime")) Then     'WorkRecTbl LotEndNull Check
                DBxDataSet.MAPOSFTData.Rows(0)("LotEndTime") = endtime
                DBxDataSet.MAPOSFTData.Rows(0)("Remark") = "LotCancel"
                MAPOSFTDataTableAdapter.Update(DBxDataSet.MAPOSFTData)         'WorkRecTbl Update<Lotcancel Mark>

            End If

            If MAP_MAPDataTableAdapter.EndSerch(DBxDataSet.MAP_MAPData, "MAP-" & MCNO, LOTNO) = 1 Then  'MapdataTbl LotExist Check with LotEnd Time isNull
                DBxDataSet.MAP_MAPData.Rows(0)("LotEndTime") = endtime
                DBxDataSet.MAP_MAPData.Rows(0)("Remark") = "LotCancel"
                MAP_MAPDataTableAdapter.Update(DBxDataSet.MAP_MAPData)          'MapdataTbl Update<Lotcancel Mark>
            Else
                If Directory.GetFiles(MapdataPath & lbMC.Text).Length > 0 Then  'if Lot no avialble check file in NFD folder

                    ans = DBxMapMAapdataSave(MCNO, LOTNO)                       'Save present data to MapdataTbl

                    If Not ans Like "Error*" Then
                        MAP_MAPDataTableAdapter.EndSerch(DBxDataSet.MAP_MAPData, "MAP-" & MCNO, LOTNO) 'MapdataTbl Updata<Lotcancel Mark>
                        DBxDataSet.MAP_MAPData.Rows(0)("LotEndTime") = endtime
                        DBxDataSet.MAP_MAPData.Rows(0)("Remark") = "LotCancel"
                        MAP_MAPDataTableAdapter.Update(DBxDataSet.MAP_MAPData)
                    Else                                                 'Just Load M/C Not run Process = Wrong , DBxMapMAapdataSave Will Error 

                        If System.IO.Directory.GetFiles(MapdataPath & MCNO).Length > 0 Then     'if can not save present data to MapdataTbl > Delete File in NFD Folder
                            For Each strfile As String In System.IO.Directory.GetFiles(MapdataPath & MCNO)
                                If clsNfdMap.deleteFile(strfile) = False Then Throw New System.Exception
                            Next
                        End If
                        clsErrorLog.addlogWT("Error : LotCancel/DBxMapMAapdataSave error  " & MCNO & "," & LOTNO, "Form1")
                        Return "Errror : MapdataSave" & ans
                        'clsNfdMap.deleteFolderAll(MapdataPath & MCNO)
                    End If

                End If
                clsErrorLog.addlogWT("Error : LotCancel/Map_MapData.EndSerch() not found result" & MCNO & "," & LOTNO, "Form1")
                Return "Errror :Map_MapData.EndSerch() not found result"
            End If


        Catch ex As Exception
            clsErrorLog.addlogWT("Error : LotCancel_" & MCNO & "_" & LOTNO & " /" & ex.ToString, "Form1")
            Return "Errror :LotCancel" & ex.ToString

        End Try
        clsErrorLog.addlogWT("LotCancel Complete" & MCNO & "_" & LOTNO, "Form1")

        Return "True"
    End Function

#End Region

    'LOT START
    'LOT END
    'Mapdata DownLoad
    'Mapdata UpLoadp)
    'Tester Auto Load
    'Lot Cancel
    Function CheckA_ModeInspOneTime(ByVal strMCno As String, ByVal booSocket As Boolean) As String
        Dim strTimeNow As String = Format(CDate(lbStart.Text), "HH:mm:ss")
        Dim strDay As Integer = Format(CDate(lbStart.Text), "dd")
        Dim strMonth As Integer = Format(CDate(lbStart.Text), "MM")
        Dim strYear As Integer = Format(CDate(lbStart.Text), "yyyy")
        Dim DateStart As Date
        Dim DateEnd As Date
        Dim ret As String
        Dim SocketHasAMode As Boolean = False
        Dim SampleHasAMode As Boolean = False
        Dim DeviceMatching As Boolean = False
        Dim FirstTime As Boolean = False

        If booSocket = True Then 'Test Socket
            'Test Socket วันละ 2 ครั้ง  ช่วง 08.00 - 19.59 1 ครั้ง และ 20.00 - 7.59 1 ครั้ง 
            If strTimeNow >= #8:00:00 AM# And strTimeNow <= #7:59:59 PM# Then 'ช่วง 08.00 - 19.59
                ret = "False : จำเป็นต้องตรวจสอบ Test Socket ความถี่  1 ครั้ง/กะ และทุกครั้งที่มี Low Yield"
                DateStart = New Date(strYear, strMonth, strDay, 8, 0, 0)
                DateEnd = New Date(strYear, strMonth, strDay, 19, 59, 59)
            ElseIf strTimeNow >= #8:00:00 PM# And strTimeNow <= #11:59:59 PM# Then 'ช่วง 08.00 - 11.59.59
                ret = "False :จำเป็นต้องตรวจสอบ Test Socket  ความถี่  1 ครั้ง/กะ  และทุกครั้งที่มี Low Yield"
                DateStart = New Date(strYear, strMonth, strDay, 20, 0, 0)
                DateEnd = New Date(strYear, strMonth, strDay, 7, 59, 59)
                DateEnd = DateEnd.AddDays(1)
            ElseIf strTimeNow >= #12:00:00 AM# And strTimeNow <= #7:59:59 AM# Then 'ช่วง 00.00 - 7.59
                ret = "False :จำเป็นต้องตรวจสอบ Test Socket  ความถี่  1 ครั้ง/กะ  และทุกครั้งที่มี Low Yield"
                DateStart = New Date(strYear, strMonth, strDay, 20, 0, 0)
                DateEnd = New Date(strYear, strMonth, strDay, 7, 59, 59)
                DateStart = DateStart.AddDays(-1)
            End If

            DateInpsCheckTableAdapter.FillInspDateCheck(DBxDataSet.DateInpsCheck, DateStart, DateEnd, "MAP-" & lbMC.Text)
            For Each rowData As DBxDataSet.DateInpsCheckRow In DBxDataSet.DateInpsCheck.Rows
                If rowData.IsSocketCheckBeNull = False AndAlso rowData.LotNo <> lbLotNo.Text Then
                    If rowData.SocketCheckBe = "A" Then
                        SocketHasAMode = True
                        Exit For
                    End If
                End If
            Next

            If SocketHasAMode = True Then 'กะนี้มีการเชค A แล้ว
                If Label1.Text = "A" Then
                    If MessageBox.Show("งานเป็น Low Yeild หรือไม่", "", MessageBoxButtons.YesNo) <> Windows.Forms.DialogResult.Yes Then 'ไม่ใช่  Low Yeild ไม่ผ่าน
                        Return "False :ไม่สามารถ End Lot ถ้างานไม่ใช่ Low Yeild กรุณา ใช้เครื่องหมาย >>  -  << "
                    End If
                    'งาน  Low Yeild ผ่าน
                End If
            Else
                If Label1.Text <> "A" Then
                    Return "False :จำเป็นต้องตรวจสอบ Test Socket  ความถี่  1 ครั้ง/กะ  และทุกครั้งที่มี Low Yield"
                End If
            End If

            Return "True" 'ต้องมี Socket = A   'กรณีที่ไม่มีการ เชค 

        Else  'Good/NG Sample
            'Good/NG Sample วันละ 1 ครั้ง 08.00- 07.59 วันต่อมา แต่ถ้าเปลี่ยน Device ต้องเชค 1 ครั้ง
            'วันละ 1 ครั้ง 08.00- 07.59 วันต่อมา
            'ret = "True : จำเป็นต้องตรวจสอบ Good/NG Sample ความถี่ 1 ครั้ง/วัน"
            If strTimeNow >= #8:00:00 AM# And strTimeNow <= #11:59:59 PM# Then 'ช่วง 08.00 - 23.59.59
                ret = "False :จำเป็นต้องตรวจสอบ Test Socket  ความถี่  1 ครั้ง/กะ  และทุกครั้งที่มี Low Yield"
                DateStart = New Date(strYear, strMonth, strDay, 8, 0, 0)
                DateEnd = New Date(strYear, strMonth, strDay, 7, 59, 59)
                DateEnd = DateEnd.AddDays(1)
            ElseIf strTimeNow >= #12:00:00 AM# And strTimeNow <= #7:59:59 AM# Then 'ช่วง 00.00 - 7.59
                ret = "False :จำเป็นต้องตรวจสอบ Test Socket  ความถี่  1 ครั้ง/กะ  และทุกครั้งที่มี Low Yield"
                DateStart = New Date(strYear, strMonth, strDay, 8, 0, 0)
                DateEnd = New Date(strYear, strMonth, strDay, 7, 59, 59)
                DateStart = DateStart.AddDays(-1)
            End If


            DateInpsCheckTableAdapter.FillInspDateCheck(DBxDataSet.DateInpsCheck, DateStart, DateEnd, "MAP-" & lbMC.Text)
            For Each rowData As DBxDataSet.DateInpsCheckRow In DBxDataSet.DateInpsCheck.Rows
                If rowData.IsGoodNGSampleChkNull = False AndAlso rowData.LotNo <> lbLotNo.Text Then
                    If FirstTime = False Then
                        If rowData.Device = lbDevice.Text Then
                            DeviceMatching = True
                        End If
                        FirstTime = True
                    End If

                    If rowData.GoodNGSampleChk = "OK" Then
                        SampleHasAMode = True
                    End If
                End If
            Next

            If SampleHasAMode = True Then 'มี A mode ในช่วงเวลา
                If DeviceMatching = True Then ' DeviceDBx = DeviceLabel
                    If Label5.Text = "OK" Then
                        Return "False ไม่สามารถตรวจสอบได้ เพราะตรวจสอบเรียบร้อยแล้ว"
                    End If
                Else
                    If Label5.Text <> "OK" Then
                        Return "False จำเป็นต้องตรวจสอบ Good/NG Sample ทุกวันหรือทุกครั้งที่เปลี่ยน Device"
                    End If
                End If
            Else 'ไม่มี A mode ในช่วงเวลา
                If Label5.Text <> "OK" Then
                    Return "False จำเป็นต้องตรวจสอบ Good/NG Sample ทุกวันหรือทุกครั้งที่เปลี่ยน Device"
                End If
            End If

            Return "True"

        End If
    End Function


    Private Sub cbTestBoardNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTestBoardNo.SelectedIndexChanged, cbSocket.SelectedIndexChanged
        Dim cb As ComboBox = CType(sender, ComboBox)
        If cb.Text <> "" Then
            If DBxDataSet.MAPOSFTData.Count = 0 Then
                cb.Text = ""
                MsgBox("ไม่มีข้อมูลการผลิต")
                Exit Sub
            End If
            Dim RowData As DataRow = DBxDataSet.MAPOSFTData.Rows(0)
            If cb.Name = "cbTestBoardNo" Then 'TestBoardNo
                RowData("BoxNo") = cb.Text
            Else 'Socket No
                RowData("SocketNo") = cb.Text
            End If
        End If
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


        Process.Start("C:\WINDOWS\system32\osk.exe")

    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        On Error Resume Next
        '   Process.Start(Application.StartupPath & "\MapLaserManualx.pdf")
        Process.Start(Application.StartupPath & "\MapOSFTManualx.pdf")
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

    'Private Sub TDCToolStripMenuItem1_Click(sender As Object, e As EventArgs) 
    '    Dim frmTDC As SettingTDC = New SettingTDC
    '    frmTDC.ShowDialog()
    'End Sub

    Private Sub lbRevision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbRevision.Click
        On Error Resume Next
        Process.Start(Application.StartupPath & "\Revision.txt")
    End Sub

    Private Sub lbMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbMinimize.Click
        'Dim lotinfoProgram As Lotinfo = New Lotinfo
        'lotinfoProgram.MachineNo = "MachineNo"
        'lotinfoProgram.LotNo = "LotNo"
        'lotinfoProgram.TesterProgram = "TesterProgram"
        'lotinfoProgram.OpNo = "007567"
        'lotinfoProgram.DateCreate = Now
        'If (LotInfos Is Nothing) Then
        '    LotInfos = New List(Of Lotinfo)
        'End If
        'Dim lotData As Lotinfo = LotInfos.Where(Function(x) x.MachineNo = lotinfoProgram.MachineNo).FirstOrDefault
        'If (lotData IsNot Nothing) Then
        '    LotInfos.Remove(lotData)
        '    LotInfos.Add(lotinfoProgram)
        'Else
        '    LotInfos.Add(lotinfoProgram)
        'End If

        'Try
        '    WriterXml(m_PathFileLotInfos, LotInfos)
        'Catch ex As Exception
        '    SaveLog("Exception", m_PathFileLotData & "=>" & ex.Message.ToString())
        'End Try
        'Exit Sub
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If lbMC.Text <> "lbMC" Then
            MachineOnline("MAP-" & lbMC.Text, iLibraryService.MachineOnline.Offline)
        End If
        Me.Close()
    End Sub



#End Region

    Function PermissionGetDataAPCS(OPNo As String, LotNo As String)
        Me.TransactionDataTableAdapter.Fill(DBxDataSet.TransactionData, LotNo)
        'PermiisionCheck()
        ' LcqW_UNION_WORK_DENPYO_PRINTTableAdapter1.Fill(DBxDataSet.LCQW_UNION_WORK_DENPYO_PRINT, LotNo)
        '   Dim QR_Code As String = DBxDataSet.LCQW_UNION_WORK_DENPYO_PRINT.Rows(0).Item("QR_CODE")

        Dim ETC2 As String = DBxDataSet.TransactionData.Rows(0).Item("ETC2") 'Trim(QR_Code.Substring(232, 20))
        '    Dim QROpNo As String = TbQRInput.Text
        If My.Settings.AuthenticationUser = True Then
            If PermiisionCheck(ETC2, OPNo, My.Settings.MC_MAPGroup, My.Settings.GL_MAPGroup, "MAP", lbMC.Text) = False Then 'lbMC.Text
                '  MsgBox(ErrMesETG)
                Dim frm As MsgShow = New MsgShow
                frm.txt = ErrMesETG
                frm.Show()
                '  TbQRInput.Text = ""
                '  TbQRInput.Select()
                DBxDataSet.TransactionData.Clear()
                Return False
            End If
        End If

        Return True
    End Function

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

    Private Sub SettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingToolStripMenuItem.Click
        If My.Settings.AuthenticationUser = True Then
            ONToolStripMenuItem.CheckState = CheckState.Checked
            OFFToolStripMenuItem.CheckState = CheckState.Unchecked
        Else
            ONToolStripMenuItem.CheckState = CheckState.Unchecked
            OFFToolStripMenuItem.CheckState = CheckState.Checked
        End If
        If My.Settings.RetestMode = True Then
            ONToolStripMenuItemRetest.CheckState = CheckState.Checked
            OFFToolStripMenuItemRetest.CheckState = CheckState.Unchecked
        Else
            ONToolStripMenuItemRetest.CheckState = CheckState.Unchecked
            OFFToolStripMenuItemRetest.CheckState = CheckState.Checked
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



    Private Sub NewSetUpCheckToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewSetUpCheckToolStripMenuItem.Click

    End Sub

    Private Sub SetUpCheckToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetUpCheckToolStripMenuItem.Click
        If Panel2.Controls.Count = 0 Then
            MsgBox("ไม่พบ ชื่อเครื่องจักร ให้ ทำการเพิ่มเครื่อง แล้วลองใหม่อีกครั้ง")
            Exit Sub
        End If
        PassWord("ENGINEER")
        If Not Pbx.Level = "ENGINEER" Then
            MsgBox("Password ไม่ถูกต้อง (MMyydd)")
            Exit Sub
        End If
        Form3.ShowDialog()
    End Sub

    Private Sub ONToolStripMenuItemRetest_Click(sender As Object, e As EventArgs) Handles ONToolStripMenuItemRetest.Click, OFFToolStripMenuItemRetest.Click
        Dim val As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        If val.Text = "OFF" Then
            My.Settings.RetestMode = False
        Else
            My.Settings.RetestMode = True
        End If
        My.Settings.Save()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OnPrint("True,10.1.1.50,LOTSTART,IPB-27,1951A5381V,VSON04Z111,BU52272NUZ-ZA(X8G),006584,AUTO1,FU52272M30A,rng,F2 BU52272M30 A1,2019-11-01 15:53:16")
        'If IsNothing(f2) OrElse f2.IsDisposed Then
        '    f2 = New Form2
        'End If
        'f2.Show()
    End Sub

    Private Sub TesterManualLoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TesterManualLoadToolStripMenuItem.Click
        Dim lotinfo As Lotinfo = LotInfos.Where(Function(x) x.LotNo = lbLotNo.Text.Trim.ToUpper).FirstOrDefault()
        If lotinfo Is Nothing Then
            MessageBox.Show("ไม่พบ lot ใน cellcon", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("ต้องการ manual load program tester หรือไม่? " & vbCrLf & "program name :" & lotinfo.TesterProgram, "Confrim", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim ans As String = TestProLoadAuto(lotinfo.MachineNo, lotinfo.TesterProgram, lotinfo.OpNo, True)
            If ans = "True" Then
                MessageBox.Show("Load program tester success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SaveLog(3, "TestProLoadAuto>> Pass :" & ans)
            Else   'If test auto load fail continue with Manual load <warning> 
                'MessageBox.Show("Load program tester fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ans, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SaveLog(3, "TestProLoadAuto>> Not Pass :" & ans)
            End If
        End If
    End Sub
End Class
