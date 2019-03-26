Public Class StripMapView

    Dim Qry As New StripMapDBDataSetTableAdapters.tbl_StripMapTableAdapter
    Dim tbl As New StripMapDBDataSet.tbl_StripMapDataTable
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Not tbRohmLotNo.Text Like "*F*" Then
                MsgBox("LotNo ไม่ใช่ F Lot")
                Exit Sub
            End If
            DataGridView1.Rows.Clear()

            If tbRohmLotNo.Text = "" Then
                MsgBox("ยังไม่ได้ใส่ LotNo")
                Exit Sub
            End If


            If Not My.Computer.Network.IsAvailable Then
                MsgBox("ยังไม่ได้ต่อสาย Lan หรือ PortLan ของ PC ไม่พร้อมใช้งาน")
                Exit Sub
            End If
            If Not My.Computer.Network.Ping("172.16.0.102") Then
                MsgBox("ไม่สามารถ เชื่อมต่อกับ Server ได้  Ping 172.16.0.102 fail")
                Exit Sub
            End If
            Dim a = Qry.FillRohmLot(tbl, tbRohmLotNo.Text)
            tbRohmLotNo.Text = ""
            DataGridView1.DataSource = tbl
            '            If a = 0 Then
            '                MsgBox("LotNo : " & EarnTextBox1.Text & " ยังไม่ได้ Run IBLB")
            '                'MsgBox("ไม่พบข้อมูล ASE LotNo : " & EarnTextBox1.Text & " ในระบบฐานข้อมูล ติดต่อผู้รับผิดชอบ ในกรณี ไม่มีข้อมูลทาง Email ติดต่อ สีฟ้า PC(83345) ในกรณี มีข้อมูล Email ติดต่อ จีนะ(83114)")
            '                Exit Sub
            '            End If

            '            For Each row As StripMapDBDataSet.tbl_StripMapRow In tbl   'ตรวจสอบความผิดปกติ ในกรณี ASE LotNo ถูกใช้งานแล้ว
            '                If row.CompleteFlag = 1 Then
            '                    MsgBox("ASE LotNo " & row.ASELotNo & " ได้มีประวัติการผลิต จาก IBLB ในวันเวลา " & row.UseTime & " กรุณาตรวจสอบความผิดปกติ")
            '                    DataGridView1.Columns("Column7").DefaultCellStyle.BackColor = Color.Red
            '                    GoTo Loop1
            '                End If
            '            Next
            '            DataGridView1.Columns("Column7").DefaultCellStyle.BackColor = Color.White
            'Loop1:
            '            DataGridView1.Rows.Add(a)
            '            Dim datex As New Date(2017, 1, 1)         'defualt usetimeColumn in data base  2000-01-01 00:00:000
            '            For i = 0 To a - 1
            '                DataGridView1.Rows(i).Height = 30
            '                For j = 0 To tbl.Columns.Count - 2  ' Not include last 1 rows
            '                    DataGridView1.Rows(i).Cells(j).Value = tbl.Rows(i)(j)
            '                Next
            '                DataGridView1.Rows(i).Cells("Column6").Value = False
            '                If tbl.Rows(i)(5) > datex Then       ' datagridview will not show if defualt value
            '                    DataGridView1.Rows(i).Cells("Column7").Value = tbl.Rows(i)(5)
            '                End If
            '                '  lbTotalPass.Text = CInt(DataGridView1.Rows(i).Cells("Column3").Value) + CInt(lbTotalPass.Text)
            '            Next

        Catch ex As Exception
            MsgBox("LoadData()" & ex.ToString)
        End Try
    End Sub

    Private Sub EarnTextBox1_LostFocus(sender As Object, e As EventArgs)
        Panel1.BackColor = Color.Transparent
    End Sub

    Private Sub StripMapView_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        tbRohmLotNo.Focus()
        Panel1.BackColor = Color.Blue
    End Sub

    Private Sub EarnTextBox1_Click(sender As Object, e As EventArgs)
        MsgBox(tbRohmLotNo.Text)

    End Sub

    Private Sub EarnTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles tbRohmLotNo.Click
        tbRohmLotNo.Text = ""
        tbRohmLotNo.Focus()
        '   Panel1.BackColor = Color.Blue

        KeyBoardCall(tbRohmLotNo, False, My.Resources.EPGPackageLotNo)
        Panel1.BackColor = Color.Blue
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles tbRohmLotNo.LostFocus
        Panel1.BackColor = Color.Transparent
    End Sub
#Region "===  KeyBoard Control"
    Dim KYB As KeyBoard

    Private Sub KeyBoardCall(ByVal OBJ As TextBox, ByVal NumpadKeys As Boolean, Optional ByVal infoImage As System.Drawing.Image = Nothing, Optional ByVal Tag As String = "")
        If KYB Is Nothing Then
            KYB = New KeyBoard
        ElseIf KYB.IsDisposed Then
            KYB = New KeyBoard
        End If
        KYB.TargetTextBox = OBJ
        KYB.tbxMonitorx.Text = OBJ.Text
        KYB.tbxMonitorx.Select(KYB.tbxMonitorx.Text.Length, 0)
        KYB.Owner = Me
        KYB.StartPosition = FormStartPosition.Manual
        Dim xsize As Rectangle = Screen.PrimaryScreen.Bounds
        KYB.Left = 10
        KYB.Top = 0
        KYB.TopMost = True
        KYB.NumPad = NumpadKeys                        'Numpad =True , Keyboard = False
        KYB.pbxHelper.BackgroundImage = infoImage
        KYB.TagID = Tag
        KYB.Location = New Point(100, Me.Top + 100)
        KYB.Show()
        AddHandler KYB.FormClosed, AddressOf KYB_close

    End Sub


    Private Sub KeyBoardCall(ByVal OBJ As Label, ByVal NumpadKeys As Boolean, Optional ByVal infoImage As System.Drawing.Image = Nothing, Optional ByVal Tag As String = "")

        If KYB Is Nothing Then
            KYB = New KeyBoard
        ElseIf KYB.IsDisposed Then
            KYB = New KeyBoard
        End If
        KYB.TargetLabel = OBJ
        KYB.tbxMonitorx.Text = OBJ.Text
        KYB.tbxMonitorx.Select(KYB.tbxMonitorx.Text.Length, 0)
        KYB.Owner = Me
        KYB.StartPosition = FormStartPosition.Manual
        Dim xsize As Rectangle = Screen.PrimaryScreen.Bounds
        KYB.Left = 10
        KYB.Top = 0
        KYB.TopMost = True
        KYB.NumPad = NumpadKeys                        'Numpad =True , Keyboard = False
        KYB.pbxHelper.BackgroundImage = infoImage
        KYB.TagID = Tag
        KYB.Show()
        AddHandler KYB.FormClosed, AddressOf KYB_close

    End Sub

    Private Sub KeyBoardCallDialog(ByVal OBJ As Label, ByVal NumpadKeys As Boolean, Optional ByVal infoImage As System.Drawing.Image = Nothing, Optional ByVal Tag As String = "")

        If KYB Is Nothing Then
            KYB = New KeyBoard
        ElseIf KYB.IsDisposed Then
            KYB = New KeyBoard
        End If
        KYB.TargetLabel = OBJ
        KYB.tbxMonitorx.Text = OBJ.Text
        KYB.tbxMonitorx.Select(KYB.tbxMonitorx.Text.Length, 0)
        KYB.StartPosition = FormStartPosition.Manual
        Dim xsize As Rectangle = Screen.PrimaryScreen.Bounds
        KYB.Left = 10
        KYB.Top = 0
        KYB.TopMost = True
        KYB.NumPad = NumpadKeys                        'Numpad =True , Keyboard = False
        KYB.pbxHelper.BackgroundImage = infoImage
        KYB.TagID = Tag

        KYB.ShowDialog()
        KYB.Close()
        KYB.TagID = ""
    End Sub



    Private Sub KYB_close(sender As Object, e As FormClosedEventArgs)
        Label1.Focus()                   'tbxCtrl unfocus
        KYB.TagID = ""
    End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button.Click
    '    Dim frm As StripMapView = New StripMapView
    '    frm.ShowDialog()
    'End Sub





#End Region
End Class