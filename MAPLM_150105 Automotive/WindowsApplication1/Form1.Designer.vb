<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtPostMSGRecv = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.bgwWrDbx = New System.ComponentModel.BackgroundWorker()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelfConModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OnLineModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OffLineModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MCSettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TDCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbMinimize = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MAPLMDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DBxDataSet = New MAP_LM.DBxDataSet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbxCtrl = New System.Windows.Forms.TextBox()
        Me.lbRevision = New System.Windows.Forms.Label()
        Me.lbMspec = New System.Windows.Forms.Label()
        Me.lbAndonJudge = New System.Windows.Forms.Label()
        Me.lbLotJudge = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbMC = New System.Windows.Forms.Label()
        Me.lbOp = New System.Windows.Forms.Label()
        Me.lbDevice = New System.Windows.Forms.Label()
        Me.TransactionDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbPackage = New System.Windows.Forms.Label()
        Me.lbInput = New System.Windows.Forms.Label()
        Me.lbLotNo = New System.Windows.Forms.Label()
        Me.lbGood = New System.Windows.Forms.Label()
        Me.lbNg = New System.Windows.Forms.Label()
        Me.lbStart = New System.Windows.Forms.Label()
        Me.lbEnd = New System.Windows.Forms.Label()
        Me.lbMarkNo = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.FstSave = New System.Windows.Forms.Button()
        Me.btnFinal = New System.Windows.Forms.Button()
        Me.tmbgwWrDbxSyn = New System.Windows.Forms.Timer(Me.components)
        Me.lbGL = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbOffline = New System.Windows.Forms.Label()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tbxAlarmName = New System.Windows.Forms.TextBox()
        Me.tbxRemark = New System.Windows.Forms.TextBox()
        Me.lbAll = New System.Windows.Forms.Label()
        Me.lbMaster = New System.Windows.Forms.Label()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.cbxRemark = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AndonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ByAutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ByManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.APCSStaffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BMRequestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PMRepairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkRecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelfConModeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OnLineModeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OffLineModeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MCSettingToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TDCToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuthenticationUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OFFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionDataTableAdapter = New MAP_LM.DBxDataSetTableAdapters.TransactionDataTableAdapter()
        Me.MaplmDataTableAdapter1 = New MAP_LM.DBxDataSetTableAdapters.MAPLMDataTableAdapter()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.MAPLMDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.TransactionDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPostMSGRecv
        '
        Me.txtPostMSGRecv.Location = New System.Drawing.Point(16, 12)
        Me.txtPostMSGRecv.Name = "txtPostMSGRecv"
        Me.txtPostMSGRecv.Size = New System.Drawing.Size(10, 20)
        Me.txtPostMSGRecv.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(370, 681)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(106, 66)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "ปิด"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'bgwWrDbx
        '
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelfConModeToolStripMenuItem, Me.MCSettingToolStripMenuItem, Me.TDCToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(150, 70)
        '
        'SelfConModeToolStripMenuItem
        '
        Me.SelfConModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OnLineModeToolStripMenuItem, Me.OffLineModeToolStripMenuItem})
        Me.SelfConModeToolStripMenuItem.Name = "SelfConModeToolStripMenuItem"
        Me.SelfConModeToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.SelfConModeToolStripMenuItem.Text = "SelfCon Mode"
        '
        'OnLineModeToolStripMenuItem
        '
        Me.OnLineModeToolStripMenuItem.Name = "OnLineModeToolStripMenuItem"
        Me.OnLineModeToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.OnLineModeToolStripMenuItem.Text = "On Line Mode"
        '
        'OffLineModeToolStripMenuItem
        '
        Me.OffLineModeToolStripMenuItem.Name = "OffLineModeToolStripMenuItem"
        Me.OffLineModeToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.OffLineModeToolStripMenuItem.Text = "Off Line Mode"
        '
        'MCSettingToolStripMenuItem
        '
        Me.MCSettingToolStripMenuItem.Name = "MCSettingToolStripMenuItem"
        Me.MCSettingToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.MCSettingToolStripMenuItem.Text = "M/C Setting"
        '
        'TDCToolStripMenuItem
        '
        Me.TDCToolStripMenuItem.Name = "TDCToolStripMenuItem"
        Me.TDCToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.TDCToolStripMenuItem.Text = "TDC"
        '
        'lbMinimize
        '
        Me.lbMinimize.BackColor = System.Drawing.Color.Transparent
        Me.lbMinimize.Location = New System.Drawing.Point(897, 34)
        Me.lbMinimize.Name = "lbMinimize"
        Me.lbMinimize.Size = New System.Drawing.Size(92, 67)
        Me.lbMinimize.TabIndex = 102
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "NoMarkBe", True))
        Me.Label1.Location = New System.Drawing.Point(6, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 17)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "  1  "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MAPLMDataBindingSource
        '
        Me.MAPLMDataBindingSource.DataMember = "MAPLMData"
        Me.MAPLMDataBindingSource.DataSource = Me.DBxDataSet
        '
        'DBxDataSet
        '
        Me.DBxDataSet.DataSetName = "DBxDataSet"
        Me.DBxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "NoMarkAf", True))
        Me.Label2.Location = New System.Drawing.Point(46, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 17)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "  2  "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(495, 250)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(186, 107)
        Me.Panel1.TabIndex = 106
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "DoubleMarkAf", True))
        Me.Label4.Location = New System.Drawing.Point(47, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 17)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "  4  "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "CutThinMarkAf", True))
        Me.Label6.Location = New System.Drawing.Point(47, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 17)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "  6  "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "MarkMisalightMissPosAf", True))
        Me.Label8.Location = New System.Drawing.Point(48, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 17)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = " 8  "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "MarkMisalightMissPosBe", True))
        Me.Label7.Location = New System.Drawing.Point(5, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 17)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = " 7  "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "CutThinMarkBe", True))
        Me.Label5.Location = New System.Drawing.Point(5, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 17)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "  5  "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "DoubleMarkBe", True))
        Me.Label3.Location = New System.Drawing.Point(5, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 17)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "  3  "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbxCtrl
        '
        Me.tbxCtrl.ForeColor = System.Drawing.Color.White
        Me.tbxCtrl.Location = New System.Drawing.Point(31, 32)
        Me.tbxCtrl.Name = "tbxCtrl"
        Me.tbxCtrl.Size = New System.Drawing.Size(1, 20)
        Me.tbxCtrl.TabIndex = 107
        '
        'lbRevision
        '
        Me.lbRevision.AutoSize = True
        Me.lbRevision.BackColor = System.Drawing.Color.White
        Me.lbRevision.Location = New System.Drawing.Point(735, 708)
        Me.lbRevision.Name = "lbRevision"
        Me.lbRevision.Size = New System.Drawing.Size(260, 13)
        Me.lbRevision.TabIndex = 108
        Me.lbRevision.Text = "SelCon MAP Laser Mark  Software Ver 1.10 Apcs Pro"
        '
        'lbMspec
        '
        Me.lbMspec.BackColor = System.Drawing.Color.Transparent
        Me.lbMspec.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "MarkingSpec", True))
        Me.lbMspec.Location = New System.Drawing.Point(498, 218)
        Me.lbMspec.Name = "lbMspec"
        Me.lbMspec.Size = New System.Drawing.Size(73, 19)
        Me.lbMspec.TabIndex = 109
        Me.lbMspec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbAndonJudge
        '
        Me.lbAndonJudge.BackColor = System.Drawing.Color.Transparent
        Me.lbAndonJudge.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "Andon", True))
        Me.lbAndonJudge.Location = New System.Drawing.Point(497, 400)
        Me.lbAndonJudge.Name = "lbAndonJudge"
        Me.lbAndonJudge.Size = New System.Drawing.Size(73, 19)
        Me.lbAndonJudge.TabIndex = 109
        Me.lbAndonJudge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbLotJudge
        '
        Me.lbLotJudge.BackColor = System.Drawing.Color.Transparent
        Me.lbLotJudge.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "LotJudgement", True))
        Me.lbLotJudge.Location = New System.Drawing.Point(755, 480)
        Me.lbLotJudge.Name = "lbLotJudge"
        Me.lbLotJudge.Size = New System.Drawing.Size(100, 19)
        Me.lbLotJudge.TabIndex = 109
        Me.lbLotJudge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Location = New System.Drawing.Point(31, 570)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(964, 51)
        Me.Panel2.TabIndex = 112
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'lbMC
        '
        Me.lbMC.AutoSize = True
        Me.lbMC.BackColor = System.Drawing.Color.Transparent
        Me.lbMC.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbMC.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbMC.Location = New System.Drawing.Point(181, 188)
        Me.lbMC.Name = "lbMC"
        Me.lbMC.Size = New System.Drawing.Size(95, 37)
        Me.lbMC.TabIndex = 114
        Me.lbMC.Text = "lbMC"
        '
        'lbOp
        '
        Me.lbOp.AutoSize = True
        Me.lbOp.BackColor = System.Drawing.Color.Transparent
        Me.lbOp.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "OPNo", True))
        Me.lbOp.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbOp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbOp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbOp.Location = New System.Drawing.Point(181, 252)
        Me.lbOp.Name = "lbOp"
        Me.lbOp.Size = New System.Drawing.Size(125, 37)
        Me.lbOp.TabIndex = 115
        Me.lbOp.Text = "000000"
        '
        'lbDevice
        '
        Me.lbDevice.AutoSize = True
        Me.lbDevice.BackColor = System.Drawing.Color.Transparent
        Me.lbDevice.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionDataBindingSource, "Device", True))
        Me.lbDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDevice.Location = New System.Drawing.Point(6, 49)
        Me.lbDevice.Name = "lbDevice"
        Me.lbDevice.Size = New System.Drawing.Size(62, 16)
        Me.lbDevice.TabIndex = 118
        Me.lbDevice.Text = "lbDevice"
        '
        'TransactionDataBindingSource
        '
        Me.TransactionDataBindingSource.DataMember = "TransactionData"
        Me.TransactionDataBindingSource.DataSource = Me.DBxDataSet
        '
        'lbPackage
        '
        Me.lbPackage.AutoSize = True
        Me.lbPackage.BackColor = System.Drawing.Color.Transparent
        Me.lbPackage.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbPackage.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TransactionDataBindingSource, "Package", True))
        Me.lbPackage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPackage.Location = New System.Drawing.Point(6, 29)
        Me.lbPackage.Name = "lbPackage"
        Me.lbPackage.Size = New System.Drawing.Size(74, 16)
        Me.lbPackage.TabIndex = 120
        Me.lbPackage.Text = "lbPackage"
        '
        'lbInput
        '
        Me.lbInput.AutoSize = True
        Me.lbInput.BackColor = System.Drawing.Color.Transparent
        Me.lbInput.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbInput.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "InputQty", True))
        Me.lbInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbInput.Location = New System.Drawing.Point(7, 69)
        Me.lbInput.Name = "lbInput"
        Me.lbInput.Size = New System.Drawing.Size(47, 16)
        Me.lbInput.TabIndex = 119
        Me.lbInput.Text = "lbinput"
        '
        'lbLotNo
        '
        Me.lbLotNo.AutoSize = True
        Me.lbLotNo.BackColor = System.Drawing.Color.Transparent
        Me.lbLotNo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "LotNo", True))
        Me.lbLotNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLotNo.Location = New System.Drawing.Point(6, 10)
        Me.lbLotNo.Name = "lbLotNo"
        Me.lbLotNo.Size = New System.Drawing.Size(55, 16)
        Me.lbLotNo.TabIndex = 121
        Me.lbLotNo.Text = "lbLotNo"
        '
        'lbGood
        '
        Me.lbGood.BackColor = System.Drawing.Color.Transparent
        Me.lbGood.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "TotalGood", True))
        Me.lbGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbGood.Location = New System.Drawing.Point(7, 89)
        Me.lbGood.Name = "lbGood"
        Me.lbGood.Size = New System.Drawing.Size(53, 16)
        Me.lbGood.TabIndex = 116
        Me.lbGood.Text = "lbGood"
        '
        'lbNg
        '
        Me.lbNg.BackColor = System.Drawing.Color.Transparent
        Me.lbNg.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "TotalNG", True))
        Me.lbNg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNg.Location = New System.Drawing.Point(7, 110)
        Me.lbNg.Name = "lbNg"
        Me.lbNg.Size = New System.Drawing.Size(50, 16)
        Me.lbNg.TabIndex = 117
        Me.lbNg.Text = "lbNg"
        '
        'lbStart
        '
        Me.lbStart.BackColor = System.Drawing.Color.Transparent
        Me.lbStart.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "LotStartTime", True))
        Me.lbStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStart.Location = New System.Drawing.Point(6, 150)
        Me.lbStart.Name = "lbStart"
        Me.lbStart.Size = New System.Drawing.Size(125, 16)
        Me.lbStart.TabIndex = 123
        Me.lbStart.Text = "lbStart"
        '
        'lbEnd
        '
        Me.lbEnd.BackColor = System.Drawing.Color.Transparent
        Me.lbEnd.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "LotEndTime", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "G"))
        Me.lbEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEnd.Location = New System.Drawing.Point(7, 169)
        Me.lbEnd.Name = "lbEnd"
        Me.lbEnd.Size = New System.Drawing.Size(125, 16)
        Me.lbEnd.TabIndex = 122
        Me.lbEnd.Text = "lbEnd"
        '
        'lbMarkNo
        '
        Me.lbMarkNo.AutoSize = True
        Me.lbMarkNo.BackColor = System.Drawing.Color.Transparent
        Me.lbMarkNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMarkNo.Location = New System.Drawing.Point(8, 129)
        Me.lbMarkNo.Name = "lbMarkNo"
        Me.lbMarkNo.Size = New System.Drawing.Size(67, 16)
        Me.lbMarkNo.TabIndex = 117
        Me.lbMarkNo.Text = "lbMarkNo"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.lbStart)
        Me.Panel3.Controls.Add(Me.lbEnd)
        Me.Panel3.Controls.Add(Me.lbDevice)
        Me.Panel3.Controls.Add(Me.lbPackage)
        Me.Panel3.Controls.Add(Me.lbInput)
        Me.Panel3.Controls.Add(Me.lbLotNo)
        Me.Panel3.Controls.Add(Me.lbGood)
        Me.Panel3.Controls.Add(Me.lbMarkNo)
        Me.Panel3.Controls.Add(Me.lbNg)
        Me.Panel3.Location = New System.Drawing.Point(179, 314)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(135, 193)
        Me.Panel3.TabIndex = 125
        '
        'FstSave
        '
        Me.FstSave.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FstSave.Location = New System.Drawing.Point(504, 513)
        Me.FstSave.Name = "FstSave"
        Me.FstSave.Size = New System.Drawing.Size(82, 37)
        Me.FstSave.TabIndex = 126
        Me.FstSave.Text = "1st Save"
        Me.FstSave.UseVisualStyleBackColor = False
        '
        'btnFinal
        '
        Me.btnFinal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnFinal.Location = New System.Drawing.Point(778, 513)
        Me.btnFinal.Name = "btnFinal"
        Me.btnFinal.Size = New System.Drawing.Size(82, 37)
        Me.btnFinal.TabIndex = 126
        Me.btnFinal.Text = "End"
        Me.btnFinal.UseVisualStyleBackColor = False
        '
        'tmbgwWrDbxSyn
        '
        Me.tmbgwWrDbxSyn.Interval = 50
        '
        'lbGL
        '
        Me.lbGL.BackColor = System.Drawing.Color.Transparent
        Me.lbGL.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "GLCheck", True))
        Me.lbGL.Location = New System.Drawing.Point(752, 461)
        Me.lbGL.Name = "lbGL"
        Me.lbGL.Size = New System.Drawing.Size(100, 19)
        Me.lbGL.TabIndex = 109
        Me.lbGL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "AlmFrameDirectMissQty", True))
        Me.Label9.Location = New System.Drawing.Point(17, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 20)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = " 9  "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Location = New System.Drawing.Point(803, 194)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(79, 181)
        Me.Panel4.TabIndex = 127
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "AlmOtherQty", True))
        Me.Label15.Location = New System.Drawing.Point(16, 145)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 20)
        Me.Label15.TabIndex = 104
        Me.Label15.Text = " 15  "
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "AlmNoRadiationMissQty", True))
        Me.Label13.Location = New System.Drawing.Point(16, 107)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 20)
        Me.Label13.TabIndex = 104
        Me.Label13.Text = " 13  "
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "AlmTransPinMissQty", True))
        Me.Label12.Location = New System.Drawing.Point(16, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 20)
        Me.Label12.TabIndex = 104
        Me.Label12.Text = " 12  "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "AlmFramePushMissQty", True))
        Me.Label11.Location = New System.Drawing.Point(16, 68)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 20)
        Me.Label11.TabIndex = 104
        Me.Label11.Text = " 11  "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPLMDataBindingSource, "AlmFrameWorkNonQty", True))
        Me.Label10.Location = New System.Drawing.Point(16, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 20)
        Me.Label10.TabIndex = 104
        Me.Label10.Text = " 10  "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbOffline
        '
        Me.lbOffline.AutoSize = True
        Me.lbOffline.Location = New System.Drawing.Point(221, 73)
        Me.lbOffline.Name = "lbOffline"
        Me.lbOffline.Size = New System.Drawing.Size(51, 13)
        Me.lbOffline.TabIndex = 129
        Me.lbOffline.Text = "OFFLINE"
        Me.lbOffline.Visible = False
        '
        'lbStatus
        '
        Me.lbStatus.AutoSize = True
        Me.lbStatus.BackColor = System.Drawing.Color.Transparent
        Me.lbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbStatus.Location = New System.Drawing.Point(44, 526)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(0, 24)
        Me.lbStatus.TabIndex = 130
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'tbxAlarmName
        '
        Me.tbxAlarmName.Location = New System.Drawing.Point(649, 344)
        Me.tbxAlarmName.Name = "tbxAlarmName"
        Me.tbxAlarmName.Size = New System.Drawing.Size(129, 20)
        Me.tbxAlarmName.TabIndex = 131
        '
        'tbxRemark
        '
        Me.tbxRemark.Location = New System.Drawing.Point(719, 389)
        Me.tbxRemark.Name = "tbxRemark"
        Me.tbxRemark.Size = New System.Drawing.Size(147, 20)
        Me.tbxRemark.TabIndex = 131
        '
        'lbAll
        '
        Me.lbAll.BackColor = System.Drawing.Color.Transparent
        Me.lbAll.Location = New System.Drawing.Point(505, 240)
        Me.lbAll.Name = "lbAll"
        Me.lbAll.Size = New System.Drawing.Size(20, 20)
        Me.lbAll.TabIndex = 135
        '
        'lbMaster
        '
        Me.lbMaster.AutoSize = True
        Me.lbMaster.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMaster.ForeColor = System.Drawing.Color.Red
        Me.lbMaster.Location = New System.Drawing.Point(223, 52)
        Me.lbMaster.Name = "lbMaster"
        Me.lbMaster.Size = New System.Drawing.Size(49, 16)
        Me.lbMaster.TabIndex = 138
        Me.lbMaster.Text = "Master"
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(482, 681)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(106, 66)
        Me.btnInsert.TabIndex = 139
        Me.btnInsert.Text = "แทรก Lot "
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(180, 513)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(140, 20)
        Me.DateTimePicker1.TabIndex = 124
        '
        'cbxRemark
        '
        Me.cbxRemark.AutoCompleteCustomSource.AddRange(New String() {" -  ", "BM long time", "Ab. Q’ty miss", "Ab. Marking ng", "Ab. PKG.crack,Broken", "Ab. Ng over 0.5%"})
        Me.cbxRemark.FormattingEnabled = True
        Me.cbxRemark.Items.AddRange(New Object() {" -  ", "BM long time", "Ab. Q’ty miss", "Ab. Marking ng", "Ab. PKG.crack,Broken", "Ab. Ng over 0.5%"})
        Me.cbxRemark.Location = New System.Drawing.Point(719, 415)
        Me.cbxRemark.Name = "cbxRemark"
        Me.cbxRemark.Size = New System.Drawing.Size(147, 21)
        Me.cbxRemark.TabIndex = 140
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AndonToolStripMenuItem, Me.APCSStaffToolStripMenuItem, Me.BMRequestToolStripMenuItem, Me.PMRepairToolStripMenuItem, Me.WorkRecordToolStripMenuItem, Me.HelpToolStripMenuItem, Me.SettingToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(34, 107)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(854, 33)
        Me.MenuStrip1.TabIndex = 250
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AndonToolStripMenuItem
        '
        Me.AndonToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ByAutoToolStripMenuItem, Me.ByManualToolStripMenuItem})
        Me.AndonToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AndonToolStripMenuItem.Name = "AndonToolStripMenuItem"
        Me.AndonToolStripMenuItem.Size = New System.Drawing.Size(80, 29)
        Me.AndonToolStripMenuItem.Text = "Andon"
        '
        'ByAutoToolStripMenuItem
        '
        Me.ByAutoToolStripMenuItem.Name = "ByAutoToolStripMenuItem"
        Me.ByAutoToolStripMenuItem.Size = New System.Drawing.Size(173, 30)
        Me.ByAutoToolStripMenuItem.Text = "By Auto"
        '
        'ByManualToolStripMenuItem
        '
        Me.ByManualToolStripMenuItem.Name = "ByManualToolStripMenuItem"
        Me.ByManualToolStripMenuItem.Size = New System.Drawing.Size(173, 30)
        Me.ByManualToolStripMenuItem.Text = "By Manual"
        '
        'APCSStaffToolStripMenuItem
        '
        Me.APCSStaffToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.APCSStaffToolStripMenuItem.Name = "APCSStaffToolStripMenuItem"
        Me.APCSStaffToolStripMenuItem.Size = New System.Drawing.Size(114, 29)
        Me.APCSStaffToolStripMenuItem.Text = "APCS_Staff"
        '
        'BMRequestToolStripMenuItem
        '
        Me.BMRequestToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BMRequestToolStripMenuItem.Name = "BMRequestToolStripMenuItem"
        Me.BMRequestToolStripMenuItem.Size = New System.Drawing.Size(123, 29)
        Me.BMRequestToolStripMenuItem.Text = "BM Request"
        '
        'PMRepairToolStripMenuItem
        '
        Me.PMRepairToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PMRepairToolStripMenuItem.Name = "PMRepairToolStripMenuItem"
        Me.PMRepairToolStripMenuItem.Size = New System.Drawing.Size(137, 29)
        Me.PMRepairToolStripMenuItem.Text = "PM Repairing"
        '
        'WorkRecordToolStripMenuItem
        '
        Me.WorkRecordToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkRecordToolStripMenuItem.Name = "WorkRecordToolStripMenuItem"
        Me.WorkRecordToolStripMenuItem.Size = New System.Drawing.Size(126, 29)
        Me.WorkRecordToolStripMenuItem.Text = "WorkRecord"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(63, 29)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelfConModeToolStripMenuItem1, Me.MCSettingToolStripMenuItem1, Me.TDCToolStripMenuItem1, Me.AuthenticationUserToolStripMenuItem})
        Me.SettingToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(83, 29)
        Me.SettingToolStripMenuItem.Text = "Setting"
        '
        'SelfConModeToolStripMenuItem1
        '
        Me.SelfConModeToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OnLineModeToolStripMenuItem1, Me.OffLineModeToolStripMenuItem1})
        Me.SelfConModeToolStripMenuItem1.Name = "SelfConModeToolStripMenuItem1"
        Me.SelfConModeToolStripMenuItem1.Size = New System.Drawing.Size(246, 30)
        Me.SelfConModeToolStripMenuItem1.Text = "SelfCon Mode"
        '
        'OnLineModeToolStripMenuItem1
        '
        Me.OnLineModeToolStripMenuItem1.Name = "OnLineModeToolStripMenuItem1"
        Me.OnLineModeToolStripMenuItem1.Size = New System.Drawing.Size(204, 30)
        Me.OnLineModeToolStripMenuItem1.Text = "On Line Mode"
        '
        'OffLineModeToolStripMenuItem1
        '
        Me.OffLineModeToolStripMenuItem1.Name = "OffLineModeToolStripMenuItem1"
        Me.OffLineModeToolStripMenuItem1.Size = New System.Drawing.Size(204, 30)
        Me.OffLineModeToolStripMenuItem1.Text = "Off Line Mode"
        '
        'MCSettingToolStripMenuItem1
        '
        Me.MCSettingToolStripMenuItem1.Name = "MCSettingToolStripMenuItem1"
        Me.MCSettingToolStripMenuItem1.Size = New System.Drawing.Size(246, 30)
        Me.MCSettingToolStripMenuItem1.Text = "M/C Setting"
        '
        'TDCToolStripMenuItem1
        '
        Me.TDCToolStripMenuItem1.Name = "TDCToolStripMenuItem1"
        Me.TDCToolStripMenuItem1.Size = New System.Drawing.Size(246, 30)
        Me.TDCToolStripMenuItem1.Text = "TDC"
        '
        'AuthenticationUserToolStripMenuItem
        '
        Me.AuthenticationUserToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ONToolStripMenuItem, Me.OFFToolStripMenuItem})
        Me.AuthenticationUserToolStripMenuItem.Name = "AuthenticationUserToolStripMenuItem"
        Me.AuthenticationUserToolStripMenuItem.Size = New System.Drawing.Size(246, 30)
        Me.AuthenticationUserToolStripMenuItem.Text = "AuthenticationUser"
        '
        'ONToolStripMenuItem
        '
        Me.ONToolStripMenuItem.Name = "ONToolStripMenuItem"
        Me.ONToolStripMenuItem.Size = New System.Drawing.Size(116, 30)
        Me.ONToolStripMenuItem.Text = "ON"
        '
        'OFFToolStripMenuItem
        '
        Me.OFFToolStripMenuItem.Name = "OFFToolStripMenuItem"
        Me.OFFToolStripMenuItem.Size = New System.Drawing.Size(116, 30)
        Me.OFFToolStripMenuItem.Text = "OFF"
        '
        'TransactionDataTableAdapter
        '
        Me.TransactionDataTableAdapter.ClearBeforeFill = True
        '
        'MaplmDataTableAdapter1
        '
        Me.MaplmDataTableAdapter1.ClearBeforeFill = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImage = Global.MAP_LM.My.Resources.Resources.MAPLM2
        Me.ClientSize = New System.Drawing.Size(1024, 776)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cbxRemark)
        Me.Controls.Add(Me.btnInsert)
        Me.Controls.Add(Me.lbMaster)
        Me.Controls.Add(Me.lbAll)
        Me.Controls.Add(Me.lbOffline)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.tbxAlarmName)
        Me.Controls.Add(Me.lbStatus)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.tbxRemark)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.lbOp)
        Me.Controls.Add(Me.lbMC)
        Me.Controls.Add(Me.FstSave)
        Me.Controls.Add(Me.btnFinal)
        Me.Controls.Add(Me.lbAndonJudge)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lbLotJudge)
        Me.Controls.Add(Me.lbGL)
        Me.Controls.Add(Me.lbRevision)
        Me.Controls.Add(Me.tbxCtrl)
        Me.Controls.Add(Me.lbMinimize)
        Me.Controls.Add(Me.lbMspec)
        Me.Controls.Add(Me.txtPostMSGRecv)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "Self Controller"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.MAPLMDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.TransactionDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPostMSGRecv As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents bgwWrDbx As System.ComponentModel.BackgroundWorker
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelfConModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OnLineModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OffLineModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbMinimize As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tbxCtrl As System.Windows.Forms.TextBox
    Friend WithEvents lbRevision As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbMspec As System.Windows.Forms.Label
    Friend WithEvents lbAndonJudge As System.Windows.Forms.Label
    Friend WithEvents lbLotJudge As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MCSettingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbMC As System.Windows.Forms.Label
    Friend WithEvents lbOp As System.Windows.Forms.Label
    Friend WithEvents lbDevice As System.Windows.Forms.Label
    Friend WithEvents lbPackage As System.Windows.Forms.Label
    Friend WithEvents lbInput As System.Windows.Forms.Label
    Friend WithEvents lbLotNo As System.Windows.Forms.Label
    Friend WithEvents lbGood As System.Windows.Forms.Label
    Friend WithEvents lbNg As System.Windows.Forms.Label
    Friend WithEvents lbStart As System.Windows.Forms.Label
    Friend WithEvents lbEnd As System.Windows.Forms.Label
    Friend WithEvents lbMarkNo As System.Windows.Forms.Label
    ' Friend WithEvents DBxDataSet As MAP_LM.DBxDataSet
    Friend WithEvents MAPLMDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MAPLMDataTableAdapter As MAP_LM.DBxDataSetTableAdapters.MAPLMDataTableAdapter
    Friend WithEvents TableAdapterManager As MAP_LM.DBxDataSetTableAdapters.TableAdapterManager
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionDataTableAdapter1 As MAP_LM.DBxDataSetTableAdapters.TransactionDataTableAdapter
    Friend WithEvents TransactionDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents FstSave As System.Windows.Forms.Button
    Friend WithEvents btnFinal As System.Windows.Forms.Button
    Friend WithEvents tmbgwWrDbxSyn As System.Windows.Forms.Timer
    Friend WithEvents lbGL As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbOffline As System.Windows.Forms.Label
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents tbxAlarmName As System.Windows.Forms.TextBox
    Friend WithEvents tbxRemark As System.Windows.Forms.TextBox
    Friend WithEvents TransactionDataTableAdapter2 As MAP_LM.DBxDataSetTableAdapters.TransactionDataTableAdapter
    Friend WithEvents lbAll As System.Windows.Forms.Label
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents lbMaster As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbxRemark As System.Windows.Forms.ComboBox
    Friend WithEvents TDCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AndonToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ByAutoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ByManualToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BMRequestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PMRepairToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkRecordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents APCSStaffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelfConModeToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OnLineModeToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OffLineModeToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MCSettingToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TDCToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DBxDataSet As DBxDataSet
    Friend WithEvents TransactionDataTableAdapter As DBxDataSetTableAdapters.TransactionDataTableAdapter
    Friend WithEvents AuthenticationUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ONToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OFFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MaplmDataTableAdapter1 As DBxDataSetTableAdapters.MAPLMDataTableAdapter
End Class
