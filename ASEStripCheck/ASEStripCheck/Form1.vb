Public Class Form1

    Dim Qry As New StripMapDBDataSetTableAdapters.tbl_StripMapTableAdapter
    Dim tbl As New StripMapDBDataSet.tbl_StripMapDataTable
  
    Private Sub Form1_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        TextBox1.Focus()
        Panel1.BackColor = Color.Blue

    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        LoadData()
    End Sub
    Private Sub LoadData()
        Try
            DataGridView1.Rows.Clear()
            lbTotalPass.Text = 0
            Label2.Text = 0
            lbSelNg.Text = 0
            If TextBox1.Text = "" Then
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
            Dim a = Qry.Fill(tbl, TextBox1.Text)
            TextBox1.Text = ""
            If a = 0 Then
                MsgBox("ไม่พบข้อมูล ASE LotNo : " & TextBox1.Text & " ในระบบฐานข้อมูล ติดต่อผู้รับผิดชอบ ในกรณี ไม่มีข้อมูลทาง Email ติดต่อ สีฟ้า PC(83345) ในกรณี มีข้อมูล Email ติดต่อ จีนะ(83114)")
                Exit Sub
            End If

            For Each row As StripMapDBDataSet.tbl_StripMapRow In tbl   'ตรวจสอบความผิดปกติ ในกรณี ASE LotNo ถูกใช้งานแล้ว
                If row.CompleteFlag = 1 Then
                    MsgBox("ASE LotNo " & row.ASELotNo & " ได้มีประวัติการผลิต จาก IBLB ในวันเวลา " & row.UseTime & " กรุณาตรวจสอบความผิดปกติ")
                    DataGridView1.Columns("Column7").DefaultCellStyle.BackColor = Color.Red
                    GoTo Loop1
                End If
            Next
            DataGridView1.Columns("Column7").DefaultCellStyle.BackColor = Color.White
Loop1:
            DataGridView1.Rows.Add(a)
            Dim datex As New Date(2017, 1, 1)         'defualt usetimeColumn in data base  2000-01-01 00:00:000
            For i = 0 To a - 1
                DataGridView1.Rows(i).Height = 30
                For j = 0 To tbl.Columns.Count - 3  ' Not include last 1 rows
                    DataGridView1.Rows(i).Cells(j).Value = tbl.Rows(i)(j)
                Next
                DataGridView1.Rows(i).Cells("Column6").Value = False
                If tbl.Rows(i)(5) > datex Then       ' datagridview will not show if defualt value
                    DataGridView1.Rows(i).Cells("Column7").Value = tbl.Rows(i)(5)
                End If
                lbTotalPass.Text = CInt(DataGridView1.Rows(i).Cells("Column3").Value) + CInt(lbTotalPass.Text)
            Next

        Catch ex As Exception
            MsgBox("LoadData()" & ex.ToString)
        End Try


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        DataGridView1.CurrentCell = DataGridView1.Rows(e.RowIndex).Cells(0)

    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If DataGridView1.Columns(e.ColumnIndex).Name = "Column6" Then
            Label2.Text = 0
            lbSelNg.Text = 0

            For i = 0 To DataGridView1.Rows.Count - 1
                If CType(DataGridView1.Rows(i).Cells("Column6").Value, Boolean) Then
                    Label2.Text = CInt(DataGridView1.Rows(i).Cells("Column3").Value) + CInt(Label2.Text)
                    lbSelNg.Text = CInt(DataGridView1.Rows(i).Cells("Column4").Value) + CInt(lbSelNg.Text)
                End If
            Next
        End If
    End Sub
    Private Sub TextBox1_Click(sender As Object, e As System.EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
        TextBox1.Focus()
        Panel1.BackColor = Color.Blue
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Panel1.BackColor = Color.Blue
        KeyBoardCall(TextBox1, False, My.Resources.EPGPackageLotNo)
    End Sub

    Dim tXtEndFlag As Boolean
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If tXtEndFlag Then
            TextBox1.Text = ""
            tXtEndFlag = False

        End If

        If e.KeyChar = vbCr Then
            Label5.Text = ""
            If TextBox1.Text.Length = 9 Then     'If ASE LotNo. XXX-XXXXX
                LoadData()
            Else
                Label5.Text = "ไม่ใช่ ASE Lot No"
            End If
            tXtEndFlag = True
        End If
    End Sub
    Private Sub TextBox1_LostFocus(sender As Object, e As System.EventArgs) Handles TextBox1.LostFocus
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







#End Region



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim frm As StripMapView = New StripMapView
        frm.ShowDialog()
    End Sub








End Class
