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
        Me.bgwWrDbx = New System.ComponentModel.BackgroundWorker()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelfConModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OnLineModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OffLineModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MCSettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InputModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DBxDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TDCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OfflineModeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OnlineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OfflineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MAPALDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DBxDataSet = New MAP_Label.DBxDataSet()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbAll = New System.Windows.Forms.Label()
        Me.tbxCtrl = New System.Windows.Forms.TextBox()
        Me.lbRevision = New System.Windows.Forms.Label()
        Me.lbAndonJudge = New System.Windows.Forms.Label()
        Me.lbLotJudge = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MCNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotStartTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotEndTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OPNoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InputQtyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalGoodDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalNGDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelPosChkBeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelPosChkAfDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelMarkChkBeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelMarkChkAfDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelChangeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StickLabelChangeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReissueLabelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReissueLabelQtyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AndonDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OPJudgementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotJudgementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SelfConVersionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GLCheckDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemarkDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NetVersionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbMC = New System.Windows.Forms.Label()
        Me.lbOp = New System.Windows.Forms.Label()
        Me.FstSave = New System.Windows.Forms.Button()
        Me.btnFinal = New System.Windows.Forms.Button()
        Me.tmbgwWrDbxSyn = New System.Windows.Forms.Timer(Me.components)
        Me.lbGL = New System.Windows.Forms.Label()
        Me.lbOffline = New System.Windows.Forms.Label()
        Me.lbStatus = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tbxRemark = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbEnd = New System.Windows.Forms.Label()
        Me.lbStart = New System.Windows.Forms.Label()
        Me.lbMarkNo = New System.Windows.Forms.Label()
        Me.lbNg = New System.Windows.Forms.Label()
        Me.lbGood = New System.Windows.Forms.Label()
        Me.lbRingQty = New System.Windows.Forms.Label()
        Me.lbInput = New System.Windows.Forms.Label()
        Me.lbDevice = New System.Windows.Forms.Label()
        Me.lbPackage = New System.Windows.Forms.Label()
        Me.lbLotNo = New System.Windows.Forms.Label()
        Me.lbMaster = New System.Windows.Forms.Label()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.cbxRemark = New System.Windows.Forms.ComboBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.RunMode = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
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
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TDCToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManaulToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuthenticationUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OFFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InputModeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeysToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TransactionDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MAPAlarmInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TransactionDataTableAdapter = New MAP_Label.DBxDataSetTableAdapters.TransactionDataTableAdapter()
        Me.MAPALDataTableAdapter = New MAP_Label.DBxDataSetTableAdapters.MAPALDataTableAdapter()
        Me.TableAdapterManager = New MAP_Label.DBxDataSetTableAdapters.TableAdapterManager()
        Me.MapAlarmTableTableAdapter1 = New MAP_Label.DBxDataSetTableAdapters.MAPAlarmTableTableAdapter()
        Me.MapAlarmInfoTableAdapter1 = New MAP_Label.DBxDataSetTableAdapters.MAPAlarmInfoTableAdapter()
        Me.MAPALDataBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.MappkgdcDataTableAdapter1 = New MAP_Label.DBxDataSetTableAdapters.MAPPKGDCDataTableAdapter()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.MAPALDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MAPAlarmInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MAPALDataBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPostMSGRecv
        '
        Me.txtPostMSGRecv.Location = New System.Drawing.Point(31, 60)
        Me.txtPostMSGRecv.Name = "txtPostMSGRecv"
        Me.txtPostMSGRecv.Size = New System.Drawing.Size(1, 20)
        Me.txtPostMSGRecv.TabIndex = 1
        '
        'bgwWrDbx
        '
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelfConModeToolStripMenuItem, Me.MCSettingToolStripMenuItem, Me.InputModeToolStripMenuItem, Me.TDCToolStripMenuItem, Me.OfflineModeToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(150, 114)
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
        'InputModeToolStripMenuItem
        '
        Me.InputModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DBxDatabaseToolStripMenuItem, Me.KeysToolStripMenuItem})
        Me.InputModeToolStripMenuItem.Name = "InputModeToolStripMenuItem"
        Me.InputModeToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.InputModeToolStripMenuItem.Text = "Input Mode"
        '
        'DBxDatabaseToolStripMenuItem
        '
        Me.DBxDatabaseToolStripMenuItem.Name = "DBxDatabaseToolStripMenuItem"
        Me.DBxDatabaseToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.DBxDatabaseToolStripMenuItem.Text = "DBxDataBase"
        '
        'KeysToolStripMenuItem
        '
        Me.KeysToolStripMenuItem.Name = "KeysToolStripMenuItem"
        Me.KeysToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.KeysToolStripMenuItem.Text = "Keys"
        '
        'TDCToolStripMenuItem
        '
        Me.TDCToolStripMenuItem.Name = "TDCToolStripMenuItem"
        Me.TDCToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.TDCToolStripMenuItem.Text = "TDC"
        '
        'OfflineModeToolStripMenuItem1
        '
        Me.OfflineModeToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OnlineToolStripMenuItem, Me.OfflineToolStripMenuItem})
        Me.OfflineModeToolStripMenuItem1.Name = "OfflineModeToolStripMenuItem1"
        Me.OfflineModeToolStripMenuItem1.Size = New System.Drawing.Size(149, 22)
        Me.OfflineModeToolStripMenuItem1.Text = "Run Mode"
        '
        'OnlineToolStripMenuItem
        '
        Me.OnlineToolStripMenuItem.Name = "OnlineToolStripMenuItem"
        Me.OnlineToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.OnlineToolStripMenuItem.Text = "Auto"
        '
        'OfflineToolStripMenuItem
        '
        Me.OfflineToolStripMenuItem.Name = "OfflineToolStripMenuItem"
        Me.OfflineToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.OfflineToolStripMenuItem.Text = "Manual"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "LabelPosChkBe", True))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 28)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "  1  "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MAPALDataBindingSource
        '
        Me.MAPALDataBindingSource.DataMember = "MAPALData"
        Me.MAPALDataBindingSource.DataSource = Me.DBxDataSet
        '
        'DBxDataSet
        '
        Me.DBxDataSet.DataSetName = "DBxDataSet"
        Me.DBxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "LabelPosChkAf", True))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(83, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 28)
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
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(939, 256)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(201, 400)
        Me.Panel1.TabIndex = 106
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "LabelMarkChkAf", True))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(83, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 28)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "  4  "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "StickLabelChange", True))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 28)
        Me.Label6.TabIndex = 136
        Me.Label6.Text = "6"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "LabelMarkChkBe", True))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 28)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "  3  "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "ReissueLabelQty", True))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 311)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 28)
        Me.Label8.TabIndex = 136
        Me.Label8.Text = "8"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "LabelChange", True))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 28)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "5"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "ReissueLabel", True))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 271)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 28)
        Me.Label7.TabIndex = 136
        Me.Label7.Text = "7"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbAll
        '
        Me.lbAll.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lbAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbAll.Location = New System.Drawing.Point(946, 225)
        Me.lbAll.Name = "lbAll"
        Me.lbAll.Size = New System.Drawing.Size(70, 28)
        Me.lbAll.TabIndex = 135
        Me.lbAll.Text = "Be"
        Me.lbAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbxCtrl
        '
        Me.tbxCtrl.ForeColor = System.Drawing.Color.White
        Me.tbxCtrl.Location = New System.Drawing.Point(24, 62)
        Me.tbxCtrl.Name = "tbxCtrl"
        Me.tbxCtrl.Size = New System.Drawing.Size(1, 20)
        Me.tbxCtrl.TabIndex = 107
        '
        'lbRevision
        '
        Me.lbRevision.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbRevision.AutoSize = True
        Me.lbRevision.BackColor = System.Drawing.Color.Transparent
        Me.lbRevision.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbRevision.Location = New System.Drawing.Point(1480, 1040)
        Me.lbRevision.Name = "lbRevision"
        Me.lbRevision.Size = New System.Drawing.Size(407, 20)
        Me.lbRevision.TabIndex = 108
        Me.lbRevision.Text = "SelCon MAP Labeler  Mark  Software Ver 2.21 Apcs Pro."
        '
        'lbAndonJudge
        '
        Me.lbAndonJudge.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lbAndonJudge.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "Andon", True))
        Me.lbAndonJudge.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbAndonJudge.Location = New System.Drawing.Point(1469, 262)
        Me.lbAndonJudge.Name = "lbAndonJudge"
        Me.lbAndonJudge.Size = New System.Drawing.Size(119, 31)
        Me.lbAndonJudge.TabIndex = 109
        Me.lbAndonJudge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbLotJudge
        '
        Me.lbLotJudge.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lbLotJudge.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbLotJudge.Location = New System.Drawing.Point(1469, 457)
        Me.lbLotJudge.Name = "lbLotJudge"
        Me.lbLotJudge.Size = New System.Drawing.Size(119, 31)
        Me.lbLotJudge.TabIndex = 109
        Me.lbLotJudge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MCNoDataGridViewTextBoxColumn, Me.LotNoDataGridViewTextBoxColumn, Me.LotStartTimeDataGridViewTextBoxColumn, Me.LotEndTimeDataGridViewTextBoxColumn, Me.OPNoDataGridViewTextBoxColumn, Me.InputQtyDataGridViewTextBoxColumn, Me.TotalGoodDataGridViewTextBoxColumn, Me.TotalNGDataGridViewTextBoxColumn, Me.LabelPosChkBeDataGridViewTextBoxColumn, Me.LabelPosChkAfDataGridViewTextBoxColumn, Me.LabelMarkChkBeDataGridViewTextBoxColumn, Me.LabelMarkChkAfDataGridViewTextBoxColumn, Me.LabelChangeDataGridViewTextBoxColumn, Me.StickLabelChangeDataGridViewTextBoxColumn, Me.ReissueLabelDataGridViewTextBoxColumn, Me.ReissueLabelQtyDataGridViewTextBoxColumn, Me.AndonDataGridViewTextBoxColumn, Me.OPJudgementDataGridViewTextBoxColumn, Me.LotJudgementDataGridViewTextBoxColumn, Me.SelfConVersionDataGridViewTextBoxColumn, Me.GLCheckDataGridViewTextBoxColumn, Me.RemarkDataGridViewTextBoxColumn, Me.NetVersionDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.MAPALDataBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(1437, 748)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(423, 154)
        Me.DataGridView1.TabIndex = 259
        Me.DataGridView1.Visible = False
        '
        'MCNoDataGridViewTextBoxColumn
        '
        Me.MCNoDataGridViewTextBoxColumn.DataPropertyName = "MCNo"
        Me.MCNoDataGridViewTextBoxColumn.HeaderText = "MCNo"
        Me.MCNoDataGridViewTextBoxColumn.Name = "MCNoDataGridViewTextBoxColumn"
        '
        'LotNoDataGridViewTextBoxColumn
        '
        Me.LotNoDataGridViewTextBoxColumn.DataPropertyName = "LotNo"
        Me.LotNoDataGridViewTextBoxColumn.HeaderText = "LotNo"
        Me.LotNoDataGridViewTextBoxColumn.Name = "LotNoDataGridViewTextBoxColumn"
        '
        'LotStartTimeDataGridViewTextBoxColumn
        '
        Me.LotStartTimeDataGridViewTextBoxColumn.DataPropertyName = "LotStartTime"
        Me.LotStartTimeDataGridViewTextBoxColumn.HeaderText = "LotStartTime"
        Me.LotStartTimeDataGridViewTextBoxColumn.Name = "LotStartTimeDataGridViewTextBoxColumn"
        '
        'LotEndTimeDataGridViewTextBoxColumn
        '
        Me.LotEndTimeDataGridViewTextBoxColumn.DataPropertyName = "LotEndTime"
        Me.LotEndTimeDataGridViewTextBoxColumn.HeaderText = "LotEndTime"
        Me.LotEndTimeDataGridViewTextBoxColumn.Name = "LotEndTimeDataGridViewTextBoxColumn"
        '
        'OPNoDataGridViewTextBoxColumn
        '
        Me.OPNoDataGridViewTextBoxColumn.DataPropertyName = "OPNo"
        Me.OPNoDataGridViewTextBoxColumn.HeaderText = "OPNo"
        Me.OPNoDataGridViewTextBoxColumn.Name = "OPNoDataGridViewTextBoxColumn"
        '
        'InputQtyDataGridViewTextBoxColumn
        '
        Me.InputQtyDataGridViewTextBoxColumn.DataPropertyName = "InputQty"
        Me.InputQtyDataGridViewTextBoxColumn.HeaderText = "InputQty"
        Me.InputQtyDataGridViewTextBoxColumn.Name = "InputQtyDataGridViewTextBoxColumn"
        '
        'TotalGoodDataGridViewTextBoxColumn
        '
        Me.TotalGoodDataGridViewTextBoxColumn.DataPropertyName = "TotalGood"
        Me.TotalGoodDataGridViewTextBoxColumn.HeaderText = "TotalGood"
        Me.TotalGoodDataGridViewTextBoxColumn.Name = "TotalGoodDataGridViewTextBoxColumn"
        '
        'TotalNGDataGridViewTextBoxColumn
        '
        Me.TotalNGDataGridViewTextBoxColumn.DataPropertyName = "TotalNG"
        Me.TotalNGDataGridViewTextBoxColumn.HeaderText = "TotalNG"
        Me.TotalNGDataGridViewTextBoxColumn.Name = "TotalNGDataGridViewTextBoxColumn"
        '
        'LabelPosChkBeDataGridViewTextBoxColumn
        '
        Me.LabelPosChkBeDataGridViewTextBoxColumn.DataPropertyName = "LabelPosChkBe"
        Me.LabelPosChkBeDataGridViewTextBoxColumn.HeaderText = "LabelPosChkBe"
        Me.LabelPosChkBeDataGridViewTextBoxColumn.Name = "LabelPosChkBeDataGridViewTextBoxColumn"
        '
        'LabelPosChkAfDataGridViewTextBoxColumn
        '
        Me.LabelPosChkAfDataGridViewTextBoxColumn.DataPropertyName = "LabelPosChkAf"
        Me.LabelPosChkAfDataGridViewTextBoxColumn.HeaderText = "LabelPosChkAf"
        Me.LabelPosChkAfDataGridViewTextBoxColumn.Name = "LabelPosChkAfDataGridViewTextBoxColumn"
        '
        'LabelMarkChkBeDataGridViewTextBoxColumn
        '
        Me.LabelMarkChkBeDataGridViewTextBoxColumn.DataPropertyName = "LabelMarkChkBe"
        Me.LabelMarkChkBeDataGridViewTextBoxColumn.HeaderText = "LabelMarkChkBe"
        Me.LabelMarkChkBeDataGridViewTextBoxColumn.Name = "LabelMarkChkBeDataGridViewTextBoxColumn"
        '
        'LabelMarkChkAfDataGridViewTextBoxColumn
        '
        Me.LabelMarkChkAfDataGridViewTextBoxColumn.DataPropertyName = "LabelMarkChkAf"
        Me.LabelMarkChkAfDataGridViewTextBoxColumn.HeaderText = "LabelMarkChkAf"
        Me.LabelMarkChkAfDataGridViewTextBoxColumn.Name = "LabelMarkChkAfDataGridViewTextBoxColumn"
        '
        'LabelChangeDataGridViewTextBoxColumn
        '
        Me.LabelChangeDataGridViewTextBoxColumn.DataPropertyName = "LabelChange"
        Me.LabelChangeDataGridViewTextBoxColumn.HeaderText = "LabelChange"
        Me.LabelChangeDataGridViewTextBoxColumn.Name = "LabelChangeDataGridViewTextBoxColumn"
        '
        'StickLabelChangeDataGridViewTextBoxColumn
        '
        Me.StickLabelChangeDataGridViewTextBoxColumn.DataPropertyName = "StickLabelChange"
        Me.StickLabelChangeDataGridViewTextBoxColumn.HeaderText = "StickLabelChange"
        Me.StickLabelChangeDataGridViewTextBoxColumn.Name = "StickLabelChangeDataGridViewTextBoxColumn"
        '
        'ReissueLabelDataGridViewTextBoxColumn
        '
        Me.ReissueLabelDataGridViewTextBoxColumn.DataPropertyName = "ReissueLabel"
        Me.ReissueLabelDataGridViewTextBoxColumn.HeaderText = "ReissueLabel"
        Me.ReissueLabelDataGridViewTextBoxColumn.Name = "ReissueLabelDataGridViewTextBoxColumn"
        '
        'ReissueLabelQtyDataGridViewTextBoxColumn
        '
        Me.ReissueLabelQtyDataGridViewTextBoxColumn.DataPropertyName = "ReissueLabelQty"
        Me.ReissueLabelQtyDataGridViewTextBoxColumn.HeaderText = "ReissueLabelQty"
        Me.ReissueLabelQtyDataGridViewTextBoxColumn.Name = "ReissueLabelQtyDataGridViewTextBoxColumn"
        '
        'AndonDataGridViewTextBoxColumn
        '
        Me.AndonDataGridViewTextBoxColumn.DataPropertyName = "Andon"
        Me.AndonDataGridViewTextBoxColumn.HeaderText = "Andon"
        Me.AndonDataGridViewTextBoxColumn.Name = "AndonDataGridViewTextBoxColumn"
        '
        'OPJudgementDataGridViewTextBoxColumn
        '
        Me.OPJudgementDataGridViewTextBoxColumn.DataPropertyName = "OPJudgement"
        Me.OPJudgementDataGridViewTextBoxColumn.HeaderText = "OPJudgement"
        Me.OPJudgementDataGridViewTextBoxColumn.Name = "OPJudgementDataGridViewTextBoxColumn"
        '
        'LotJudgementDataGridViewTextBoxColumn
        '
        Me.LotJudgementDataGridViewTextBoxColumn.DataPropertyName = "LotJudgement"
        Me.LotJudgementDataGridViewTextBoxColumn.HeaderText = "LotJudgement"
        Me.LotJudgementDataGridViewTextBoxColumn.Name = "LotJudgementDataGridViewTextBoxColumn"
        '
        'SelfConVersionDataGridViewTextBoxColumn
        '
        Me.SelfConVersionDataGridViewTextBoxColumn.DataPropertyName = "SelfConVersion"
        Me.SelfConVersionDataGridViewTextBoxColumn.HeaderText = "SelfConVersion"
        Me.SelfConVersionDataGridViewTextBoxColumn.Name = "SelfConVersionDataGridViewTextBoxColumn"
        '
        'GLCheckDataGridViewTextBoxColumn
        '
        Me.GLCheckDataGridViewTextBoxColumn.DataPropertyName = "GLCheck"
        Me.GLCheckDataGridViewTextBoxColumn.HeaderText = "GLCheck"
        Me.GLCheckDataGridViewTextBoxColumn.Name = "GLCheckDataGridViewTextBoxColumn"
        '
        'RemarkDataGridViewTextBoxColumn
        '
        Me.RemarkDataGridViewTextBoxColumn.DataPropertyName = "Remark"
        Me.RemarkDataGridViewTextBoxColumn.HeaderText = "Remark"
        Me.RemarkDataGridViewTextBoxColumn.Name = "RemarkDataGridViewTextBoxColumn"
        '
        'NetVersionDataGridViewTextBoxColumn
        '
        Me.NetVersionDataGridViewTextBoxColumn.DataPropertyName = "NetVersion"
        Me.NetVersionDataGridViewTextBoxColumn.HeaderText = "NetVersion"
        Me.NetVersionDataGridViewTextBoxColumn.Name = "NetVersionDataGridViewTextBoxColumn"
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
        Me.lbMC.BackColor = System.Drawing.Color.Transparent
        Me.lbMC.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbMC.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbMC.Location = New System.Drawing.Point(162, 201)
        Me.lbMC.Name = "lbMC"
        Me.lbMC.Size = New System.Drawing.Size(221, 37)
        Me.lbMC.TabIndex = 114
        Me.lbMC.Text = "lbMC"
        '
        'lbOp
        '
        Me.lbOp.BackColor = System.Drawing.Color.Transparent
        Me.lbOp.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "OPNo", True))
        Me.lbOp.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbOp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbOp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbOp.Location = New System.Drawing.Point(162, 245)
        Me.lbOp.Name = "lbOp"
        Me.lbOp.Size = New System.Drawing.Size(125, 37)
        Me.lbOp.TabIndex = 115
        Me.lbOp.Text = "000000"
        '
        'FstSave
        '
        Me.FstSave.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.FstSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FstSave.Location = New System.Drawing.Point(939, 662)
        Me.FstSave.Name = "FstSave"
        Me.FstSave.Size = New System.Drawing.Size(121, 52)
        Me.FstSave.TabIndex = 126
        Me.FstSave.Text = "1st Save"
        Me.FstSave.UseVisualStyleBackColor = False
        '
        'btnFinal
        '
        Me.btnFinal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnFinal.Location = New System.Drawing.Point(1468, 507)
        Me.btnFinal.Name = "btnFinal"
        Me.btnFinal.Size = New System.Drawing.Size(120, 58)
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
        Me.lbGL.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lbGL.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "GLCheck", True))
        Me.lbGL.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbGL.Location = New System.Drawing.Point(1608, 458)
        Me.lbGL.Name = "lbGL"
        Me.lbGL.Size = New System.Drawing.Size(120, 31)
        Me.lbGL.TabIndex = 109
        Me.lbGL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbOffline
        '
        Me.lbOffline.AutoSize = True
        Me.lbOffline.Location = New System.Drawing.Point(427, 96)
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
        Me.lbStatus.Location = New System.Drawing.Point(11, 489)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(0, 24)
        Me.lbStatus.TabIndex = 130
        Me.lbStatus.Tag = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'tbxRemark
        '
        Me.tbxRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.tbxRemark.Location = New System.Drawing.Point(1468, 323)
        Me.tbxRemark.Name = "tbxRemark"
        Me.tbxRemark.Size = New System.Drawing.Size(211, 35)
        Me.tbxRemark.TabIndex = 131
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.lbEnd)
        Me.Panel3.Controls.Add(Me.lbStart)
        Me.Panel3.Controls.Add(Me.lbMarkNo)
        Me.Panel3.Controls.Add(Me.lbNg)
        Me.Panel3.Controls.Add(Me.lbGood)
        Me.Panel3.Controls.Add(Me.lbRingQty)
        Me.Panel3.Controls.Add(Me.lbInput)
        Me.Panel3.Controls.Add(Me.lbDevice)
        Me.Panel3.Controls.Add(Me.lbPackage)
        Me.Panel3.Controls.Add(Me.lbLotNo)
        Me.Panel3.Location = New System.Drawing.Point(280, 298)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(308, 416)
        Me.Panel3.TabIndex = 125
        '
        'lbEnd
        '
        Me.lbEnd.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lbEnd.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "LotEndTime", True))
        Me.lbEnd.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEnd.Location = New System.Drawing.Point(0, 320)
        Me.lbEnd.Name = "lbEnd"
        Me.lbEnd.Size = New System.Drawing.Size(308, 40)
        Me.lbEnd.TabIndex = 132
        Me.lbEnd.Text = "lbEnd"
        Me.lbEnd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbStart
        '
        Me.lbStart.BackColor = System.Drawing.Color.Transparent
        Me.lbStart.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "LotStartTime", True))
        Me.lbStart.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbStart.Location = New System.Drawing.Point(0, 280)
        Me.lbStart.Name = "lbStart"
        Me.lbStart.Size = New System.Drawing.Size(308, 40)
        Me.lbStart.TabIndex = 131
        Me.lbStart.Text = "lbStart"
        Me.lbStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbMarkNo
        '
        Me.lbMarkNo.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lbMarkNo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbMarkNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMarkNo.Location = New System.Drawing.Point(0, 240)
        Me.lbMarkNo.Name = "lbMarkNo"
        Me.lbMarkNo.Size = New System.Drawing.Size(308, 40)
        Me.lbMarkNo.TabIndex = 130
        Me.lbMarkNo.Text = "lbMarkNo"
        Me.lbMarkNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbNg
        '
        Me.lbNg.BackColor = System.Drawing.Color.Transparent
        Me.lbNg.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "TotalNG", True))
        Me.lbNg.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbNg.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNg.Location = New System.Drawing.Point(0, 200)
        Me.lbNg.Name = "lbNg"
        Me.lbNg.Size = New System.Drawing.Size(308, 40)
        Me.lbNg.TabIndex = 129
        Me.lbNg.Text = "lbNg"
        Me.lbNg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbGood
        '
        Me.lbGood.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lbGood.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "TotalGood", True))
        Me.lbGood.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbGood.Location = New System.Drawing.Point(0, 160)
        Me.lbGood.Name = "lbGood"
        Me.lbGood.Size = New System.Drawing.Size(308, 40)
        Me.lbGood.TabIndex = 128
        Me.lbGood.Text = "lbGood"
        Me.lbGood.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRingQty
        '
        Me.lbRingQty.BackColor = System.Drawing.Color.Transparent
        Me.lbRingQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRingQty.Location = New System.Drawing.Point(1, 362)
        Me.lbRingQty.Name = "lbRingQty"
        Me.lbRingQty.Size = New System.Drawing.Size(144, 40)
        Me.lbRingQty.TabIndex = 133
        Me.lbRingQty.Text = "-"
        Me.lbRingQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbInput
        '
        Me.lbInput.BackColor = System.Drawing.Color.Transparent
        Me.lbInput.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbInput.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "InputQty", True))
        Me.lbInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbInput.Location = New System.Drawing.Point(0, 120)
        Me.lbInput.Name = "lbInput"
        Me.lbInput.Size = New System.Drawing.Size(308, 40)
        Me.lbInput.TabIndex = 127
        Me.lbInput.Text = "lbinput"
        Me.lbInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbDevice
        '
        Me.lbDevice.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lbDevice.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDevice.Location = New System.Drawing.Point(0, 80)
        Me.lbDevice.Name = "lbDevice"
        Me.lbDevice.Size = New System.Drawing.Size(308, 40)
        Me.lbDevice.TabIndex = 126
        Me.lbDevice.Text = "lbDevice"
        Me.lbDevice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbPackage
        '
        Me.lbPackage.BackColor = System.Drawing.Color.Transparent
        Me.lbPackage.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbPackage.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbPackage.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPackage.Location = New System.Drawing.Point(0, 40)
        Me.lbPackage.Name = "lbPackage"
        Me.lbPackage.Size = New System.Drawing.Size(308, 40)
        Me.lbPackage.TabIndex = 125
        Me.lbPackage.Text = "lbPackage"
        Me.lbPackage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLotNo
        '
        Me.lbLotNo.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lbLotNo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "LotNo", True))
        Me.lbLotNo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbLotNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLotNo.Location = New System.Drawing.Point(0, 0)
        Me.lbLotNo.Name = "lbLotNo"
        Me.lbLotNo.Size = New System.Drawing.Size(308, 40)
        Me.lbLotNo.TabIndex = 124
        Me.lbLotNo.Text = "lbLotNo"
        Me.lbLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbMaster
        '
        Me.lbMaster.AutoSize = True
        Me.lbMaster.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMaster.ForeColor = System.Drawing.Color.Red
        Me.lbMaster.Location = New System.Drawing.Point(427, 80)
        Me.lbMaster.Name = "lbMaster"
        Me.lbMaster.Size = New System.Drawing.Size(49, 16)
        Me.lbMaster.TabIndex = 138
        Me.lbMaster.Text = "Master"
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(1613, 959)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(106, 66)
        Me.btnInsert.TabIndex = 139
        Me.btnInsert.Text = "แทรก Lot "
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(280, 720)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(140, 20)
        Me.DateTimePicker1.TabIndex = 141
        '
        'cbxRemark
        '
        Me.cbxRemark.AutoCompleteCustomSource.AddRange(New String() {" -  ", "BM long time", "Ab. Q’ty miss", "Ab. Marking ng", "Ab. PKG.crack,Broken", "Ab. Ng over 0.5%"})
        Me.cbxRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbxRemark.FormattingEnabled = True
        Me.cbxRemark.Items.AddRange(New Object() {"-", " BM long time", "  Ab. Q’ty miss", "  Ab. Label ng", "  Ab. IC off", "  Ab. Ng over 0.5%"})
        Me.cbxRemark.Location = New System.Drawing.Point(1468, 360)
        Me.cbxRemark.Name = "cbxRemark"
        Me.cbxRemark.Size = New System.Drawing.Size(211, 37)
        Me.cbxRemark.TabIndex = 142
        '
        'SerialPort1
        '
        Me.SerialPort1.DtrEnable = True
        Me.SerialPort1.PortName = "COM14"
        Me.SerialPort1.RtsEnable = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(793, 801)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(214, 101)
        Me.TextBox1.TabIndex = 255
        Me.TextBox1.Visible = False
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(95, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(94, 22)
        Me.ToolStripMenuItem1.Text = "Log"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(450, 765)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 257
        Me.Button3.Text = "Convert"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(535, 765)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 257
        Me.Button4.Text = "GetData"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(1027, 879)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 257
        Me.Button5.Text = "Cancel"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.Location = New System.Drawing.Point(1659, 184)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(219, 37)
        Me.Label10.TabIndex = 115
        Me.Label10.Text = "-"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1027, 850)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 258
        Me.Button1.Text = "Send"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(450, 794)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 257
        Me.Button6.Text = "Check ASE"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'RunMode
        '
        Me.RunMode.BackColor = System.Drawing.Color.Transparent
        Me.RunMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RunMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RunMode.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RunMode.Location = New System.Drawing.Point(1776, 134)
        Me.RunMode.Name = "RunMode"
        Me.RunMode.Size = New System.Drawing.Size(112, 32)
        Me.RunMode.TabIndex = 115
        Me.RunMode.Text = "Online"
        Me.RunMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(23, 201)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(126, 37)
        Me.Label11.TabIndex = 261
        Me.Label11.Text = "MC No."
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label12.Location = New System.Drawing.Point(23, 245)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(123, 37)
        Me.Label12.TabIndex = 261
        Me.Label12.Text = "OP No."
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label13.Location = New System.Drawing.Point(12, 307)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(260, 29)
        Me.Label13.TabIndex = 262
        Me.Label13.Text = "Lot No."
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label14.Location = New System.Drawing.Point(5, 202)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(2, 700)
        Me.Label14.TabIndex = 263
        Me.Label14.Text = "Lot No."
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label15.Location = New System.Drawing.Point(12, 347)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(260, 29)
        Me.Label15.TabIndex = 262
        Me.Label15.Text = "Package Name"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label21.Location = New System.Drawing.Point(13, 466)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(261, 29)
        Me.Label21.TabIndex = 269
        Me.Label21.Text = "Total Goods Qty (PCS)"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label22.Location = New System.Drawing.Point(13, 426)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(259, 29)
        Me.Label22.TabIndex = 269
        Me.Label22.Text = "Input Qty (PCS)"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label23.Location = New System.Drawing.Point(13, 387)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(261, 29)
        Me.Label23.TabIndex = 269
        Me.Label23.Text = "Device Name"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label24.Location = New System.Drawing.Point(13, 506)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(261, 29)
        Me.Label24.TabIndex = 269
        Me.Label24.Text = "Total NG Qty (PCS)"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label25.Location = New System.Drawing.Point(13, 546)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(259, 29)
        Me.Label25.TabIndex = 269
        Me.Label25.Text = "Mark No."
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label26.Location = New System.Drawing.Point(13, 585)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(259, 29)
        Me.Label26.TabIndex = 269
        Me.Label26.Text = "Start Time"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label27.Location = New System.Drawing.Point(13, 624)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(259, 29)
        Me.Label27.TabIndex = 269
        Me.Label27.Text = "End Time"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label18.Location = New System.Drawing.Point(13, 667)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(259, 29)
        Me.Label18.TabIndex = 266
        Me.Label18.Text = "Ring Qty"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Black
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label28.Location = New System.Drawing.Point(631, 199)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(2, 700)
        Me.Label28.TabIndex = 270
        Me.Label28.Text = "Lot No."
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label29.Location = New System.Drawing.Point(675, 307)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(265, 29)
        Me.Label29.TabIndex = 274
        Me.Label29.Text = "Label Marking"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label30.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label30.Location = New System.Drawing.Point(675, 356)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(258, 29)
        Me.Label30.TabIndex = 275
        Me.Label30.Text = "Replacement"
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label31.Location = New System.Drawing.Point(675, 564)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(258, 29)
        Me.Label31.TabIndex = 276
        Me.Label31.Text = "Quantity"
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label32.Location = New System.Drawing.Point(675, 524)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(124, 29)
        Me.Label32.TabIndex = 277
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label33.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label33.Location = New System.Drawing.Point(675, 484)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(258, 29)
        Me.Label33.TabIndex = 278
        Me.Label33.Text = "Re-issue Label"
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label34.Location = New System.Drawing.Point(675, 436)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(258, 29)
        Me.Label34.TabIndex = 279
        Me.Label34.Text = "Sticker Label Change"
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label35.Location = New System.Drawing.Point(675, 396)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(258, 29)
        Me.Label35.TabIndex = 280
        Me.Label35.Text = "Label Change"
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label37.Location = New System.Drawing.Point(675, 267)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(259, 29)
        Me.Label37.TabIndex = 271
        Me.Label37.Text = "Label Change"
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label38.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label38.Location = New System.Drawing.Point(675, 227)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(258, 29)
        Me.Label38.TabIndex = 272
        Me.Label38.Text = "1St Inspection"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label39.Location = New System.Drawing.Point(1022, 225)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(70, 28)
        Me.Label39.TabIndex = 281
        Me.Label39.Text = "Af"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label36.Location = New System.Drawing.Point(1210, 199)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(2, 700)
        Me.Label36.TabIndex = 282
        Me.Label36.Text = "Lot No."
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label42.Location = New System.Drawing.Point(1244, 263)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(82, 29)
        Me.Label42.TabIndex = 280
        Me.Label42.Text = "Andon"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label43.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label43.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label43.Location = New System.Drawing.Point(1244, 319)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(97, 29)
        Me.Label43.TabIndex = 279
        Me.Label43.Text = "Remark"
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label44.Location = New System.Drawing.Point(1244, 359)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(175, 29)
        Me.Label44.TabIndex = 278
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label45.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label45.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label45.Location = New System.Drawing.Point(1244, 418)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(158, 29)
        Me.Label45.TabIndex = 277
        Me.Label45.Text = "Judgment Lot"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label46.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label46.Location = New System.Drawing.Point(1244, 458)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(158, 29)
        Me.Label46.TabIndex = 276
        Me.Label46.Text = "Lot Judgment"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label47.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label47.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label47.Location = New System.Drawing.Point(1244, 223)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(148, 29)
        Me.Label47.TabIndex = 275
        Me.Label47.Text = "Andon Event"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.MenuStrip1)
        Me.Panel4.Controls.Add(Me.Label48)
        Me.Panel4.Controls.Add(Me.Label41)
        Me.Panel4.Controls.Add(Me.Label40)
        Me.Panel4.Controls.Add(Me.Label51)
        Me.Panel4.Controls.Add(Me.Label49)
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Controls.Add(Me.TextBox1)
        Me.Panel4.Controls.Add(Me.Label36)
        Me.Panel4.Controls.Add(Me.txtPostMSGRecv)
        Me.Panel4.Controls.Add(Me.Label39)
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.btnClose)
        Me.Panel4.Controls.Add(Me.Label29)
        Me.Panel4.Controls.Add(Me.Label47)
        Me.Panel4.Controls.Add(Me.Label30)
        Me.Panel4.Controls.Add(Me.Label50)
        Me.Panel4.Controls.Add(Me.Label46)
        Me.Panel4.Controls.Add(Me.Label31)
        Me.Panel4.Controls.Add(Me.lbAndonJudge)
        Me.Panel4.Controls.Add(Me.Label45)
        Me.Panel4.Controls.Add(Me.tbxCtrl)
        Me.Panel4.Controls.Add(Me.Label32)
        Me.Panel4.Controls.Add(Me.lbGL)
        Me.Panel4.Controls.Add(Me.Label44)
        Me.Panel4.Controls.Add(Me.lbRevision)
        Me.Panel4.Controls.Add(Me.Label33)
        Me.Panel4.Controls.Add(Me.FstSave)
        Me.Panel4.Controls.Add(Me.Label43)
        Me.Panel4.Controls.Add(Me.Label34)
        Me.Panel4.Controls.Add(Me.lbLotJudge)
        Me.Panel4.Controls.Add(Me.Label42)
        Me.Panel4.Controls.Add(Me.lbMC)
        Me.Panel4.Controls.Add(Me.Label35)
        Me.Panel4.Controls.Add(Me.lbOp)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label37)
        Me.Panel4.Controls.Add(Me.RunMode)
        Me.Panel4.Controls.Add(Me.btnFinal)
        Me.Panel4.Controls.Add(Me.Label38)
        Me.Panel4.Controls.Add(Me.lbStatus)
        Me.Panel4.Controls.Add(Me.Label28)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.Label23)
        Me.Panel4.Controls.Add(Me.tbxRemark)
        Me.Panel4.Controls.Add(Me.Label22)
        Me.Panel4.Controls.Add(Me.lbOffline)
        Me.Panel4.Controls.Add(Me.Label27)
        Me.Panel4.Controls.Add(Me.lbAll)
        Me.Panel4.Controls.Add(Me.Label26)
        Me.Panel4.Controls.Add(Me.lbMaster)
        Me.Panel4.Controls.Add(Me.Label25)
        Me.Panel4.Controls.Add(Me.btnInsert)
        Me.Panel4.Controls.Add(Me.Label24)
        Me.Panel4.Controls.Add(Me.cbxRemark)
        Me.Panel4.Controls.Add(Me.Label21)
        Me.Panel4.Controls.Add(Me.DataGridView1)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.Button2)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.Button3)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.Button6)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.DateTimePicker1)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Button4)
        Me.Panel4.Controls.Add(Me.Button7)
        Me.Panel4.Controls.Add(Me.Button5)
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Location = New System.Drawing.Point(14, 7)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1894, 1061)
        Me.Panel4.TabIndex = 284
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.SkyBlue
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AndonToolStripMenuItem, Me.APCSStaffToolStripMenuItem, Me.BMRequestToolStripMenuItem, Me.PMRepairToolStripMenuItem, Me.WorkRecordToolStripMenuItem, Me.HelpToolStripMenuItem, Me.SettingToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 133)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(734, 33)
        Me.MenuStrip1.TabIndex = 288
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
        Me.SettingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelfConModeToolStripMenuItem1, Me.TDCToolStripMenuItem1, Me.ComportToolStripMenuItem, Me.RunModeToolStripMenuItem, Me.AuthenticationUserToolStripMenuItem, Me.InputModeToolStripMenuItem1})
        Me.SettingToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(83, 29)
        Me.SettingToolStripMenuItem.Text = "Setting"
        '
        'SelfConModeToolStripMenuItem1
        '
        Me.SelfConModeToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OnLineModeToolStripMenuItem1, Me.ToolStripMenuItem2})
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
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(204, 30)
        Me.ToolStripMenuItem2.Text = "Off Line Mode"
        '
        'TDCToolStripMenuItem1
        '
        Me.TDCToolStripMenuItem1.Name = "TDCToolStripMenuItem1"
        Me.TDCToolStripMenuItem1.Size = New System.Drawing.Size(246, 30)
        Me.TDCToolStripMenuItem1.Text = "TDC"
        '
        'ComportToolStripMenuItem
        '
        Me.ComportToolStripMenuItem.Name = "ComportToolStripMenuItem"
        Me.ComportToolStripMenuItem.Size = New System.Drawing.Size(246, 30)
        Me.ComportToolStripMenuItem.Text = "Com Port"
        '
        'RunModeToolStripMenuItem
        '
        Me.RunModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoToolStripMenuItem, Me.ManaulToolStripMenuItem})
        Me.RunModeToolStripMenuItem.Name = "RunModeToolStripMenuItem"
        Me.RunModeToolStripMenuItem.Size = New System.Drawing.Size(246, 30)
        Me.RunModeToolStripMenuItem.Text = "RunMode"
        '
        'AutoToolStripMenuItem
        '
        Me.AutoToolStripMenuItem.Name = "AutoToolStripMenuItem"
        Me.AutoToolStripMenuItem.Size = New System.Drawing.Size(148, 30)
        Me.AutoToolStripMenuItem.Text = "Auto"
        '
        'ManaulToolStripMenuItem
        '
        Me.ManaulToolStripMenuItem.Name = "ManaulToolStripMenuItem"
        Me.ManaulToolStripMenuItem.Size = New System.Drawing.Size(148, 30)
        Me.ManaulToolStripMenuItem.Text = "Manual"
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
        'InputModeToolStripMenuItem1
        '
        Me.InputModeToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatabaseToolStripMenuItem, Me.KeysToolStripMenuItem1})
        Me.InputModeToolStripMenuItem1.Name = "InputModeToolStripMenuItem1"
        Me.InputModeToolStripMenuItem1.Size = New System.Drawing.Size(246, 30)
        Me.InputModeToolStripMenuItem1.Text = "Input Mode"
        '
        'DatabaseToolStripMenuItem
        '
        Me.DatabaseToolStripMenuItem.Name = "DatabaseToolStripMenuItem"
        Me.DatabaseToolStripMenuItem.Size = New System.Drawing.Size(162, 30)
        Me.DatabaseToolStripMenuItem.Text = "Database"
        '
        'KeysToolStripMenuItem1
        '
        Me.KeysToolStripMenuItem1.Name = "KeysToolStripMenuItem1"
        Me.KeysToolStripMenuItem1.Size = New System.Drawing.Size(162, 30)
        Me.KeysToolStripMenuItem1.Text = "Keys"
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label48.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label48.Location = New System.Drawing.Point(17, 286)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(571, 2)
        Me.Label48.TabIndex = 287
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label41.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label41.Location = New System.Drawing.Point(680, 478)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(488, 2)
        Me.Label41.TabIndex = 286
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label40.Location = New System.Drawing.Point(679, 347)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(488, 2)
        Me.Label40.TabIndex = 285
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label51.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label51.Location = New System.Drawing.Point(1237, 408)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(600, 2)
        Me.Label51.TabIndex = 284
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label49.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label49.Location = New System.Drawing.Point(1237, 307)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(600, 2)
        Me.Label49.TabIndex = 284
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = Global.MAP_Label.My.Resources.Resources.Logo_ROHM_svg
        Me.PictureBox1.Location = New System.Drawing.Point(1775, 36)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(115, 90)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 283
        Me.PictureBox1.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnClose.Location = New System.Drawing.Point(1750, 958)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(128, 66)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "ปิด"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label50.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label50.Location = New System.Drawing.Point(1614, 429)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(107, 25)
        Me.Label50.TabIndex = 276
        Me.Label50.Text = "GL Check"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.MAP_Label.My.Resources.Resources.unnamed
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(18, 720)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(153, 130)
        Me.Button2.TabIndex = 0
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button7.Location = New System.Drawing.Point(1607, 507)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(121, 39)
        Me.Button7.TabIndex = 260
        Me.Button7.Text = "Cancel Lot"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.SkyBlue
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label20.Location = New System.Drawing.Point(0, 130)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(1894, 40)
        Me.Label20.TabIndex = 272
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.White
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label19.Location = New System.Drawing.Point(0, 34)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(1894, 96)
        Me.Label19.TabIndex = 271
        Me.Label19.Text = "   MAP_LABELER"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label16.Location = New System.Drawing.Point(0, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(1894, 21)
        Me.Label16.TabIndex = 269
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.White
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Location = New System.Drawing.Point(0, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(1894, 13)
        Me.Label17.TabIndex = 270
        '
        'MAPAlarmInfoBindingSource
        '
        Me.MAPAlarmInfoBindingSource.DataMember = "MAPAlarmInfo"
        Me.MAPAlarmInfoBindingSource.DataSource = Me.DBxDataSet
        '
        'TransactionDataTableAdapter
        '
        Me.TransactionDataTableAdapter.ClearBeforeFill = True
        '
        'MAPALDataTableAdapter
        '
        Me.MAPALDataTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.MAPAlarmInfoTableAdapter = Nothing
        Me.TableAdapterManager.MAPAlarmTableTableAdapter = Nothing
        Me.TableAdapterManager.MAPALDataTableAdapter = Nothing
        Me.TableAdapterManager.RecipeHeaderMapXTableAdapter = Nothing
        Me.TableAdapterManager.TransactionDataTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = MAP_Label.DBxDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'MapAlarmTableTableAdapter1
        '
        Me.MapAlarmTableTableAdapter1.ClearBeforeFill = True
        '
        'MapAlarmInfoTableAdapter1
        '
        Me.MapAlarmInfoTableAdapter1.ClearBeforeFill = True
        '
        'MAPALDataBindingSource1
        '
        Me.MAPALDataBindingSource1.DataMember = "MAPALData"
        Me.MAPALDataBindingSource1.DataSource = Me.DBxDataSet
        '
        'MappkgdcDataTableAdapter1
        '
        Me.MappkgdcDataTableAdapter1.ClearBeforeFill = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1920, 1080)
        Me.ContextMenuStrip = Me.ContextMenuStrip3
        Me.Controls.Add(Me.Panel4)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MAPALDataBindingSource, "LotJudgement", True))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "Self Controller"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.MAPALDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MAPAlarmInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MAPALDataBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtPostMSGRecv As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents bgwWrDbx As System.ComponentModel.BackgroundWorker
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelfConModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OnLineModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OffLineModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tbxCtrl As System.Windows.Forms.TextBox
    Friend WithEvents lbRevision As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbAndonJudge As System.Windows.Forms.Label
    Friend WithEvents lbLotJudge As System.Windows.Forms.Label
    Friend WithEvents MCSettingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbMC As System.Windows.Forms.Label
    Friend WithEvents lbOp As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FstSave As System.Windows.Forms.Button
    Friend WithEvents btnFinal As System.Windows.Forms.Button
    Friend WithEvents tmbgwWrDbxSyn As System.Windows.Forms.Timer
    Friend WithEvents lbGL As System.Windows.Forms.Label
    Friend WithEvents lbOffline As System.Windows.Forms.Label
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents tbxRemark As System.Windows.Forms.TextBox
    Friend WithEvents lbAll As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TableAdapterManager As MAP_Label.DBxDataSetTableAdapters.TableAdapterManager
    Friend WithEvents TransactionDataTableAdapter As MAP_Label.DBxDataSetTableAdapters.TransactionDataTableAdapter
    Friend WithEvents TransactionDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InputModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DBxDatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeysToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbMaster As System.Windows.Forms.Label
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbxRemark As System.Windows.Forms.ComboBox
    Friend WithEvents TDCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents DBxDataSet As DBxDataSet
    Friend WithEvents MAPALDataBindingSource As BindingSource
    Friend WithEvents MAPALDataTableAdapter As DBxDataSetTableAdapters.MAPALDataTableAdapter
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents OfflineModeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OnlineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OfflineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunMode As System.Windows.Forms.Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lbEnd As Label
    Friend WithEvents lbStart As Label
    Friend WithEvents lbMarkNo As Label
    Friend WithEvents lbNg As Label
    Friend WithEvents lbGood As Label
    Friend WithEvents lbInput As Label
    Friend WithEvents lbDevice As Label
    Friend WithEvents lbPackage As Label
    Friend WithEvents lbLotNo As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lbRingQty As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents MapAlarmTableTableAdapter1 As DBxDataSetTableAdapters.MAPAlarmTableTableAdapter
    Friend WithEvents MapAlarmInfoTableAdapter1 As DBxDataSetTableAdapters.MAPAlarmInfoTableAdapter
    Friend WithEvents MAPAlarmInfoBindingSource As BindingSource
    Friend WithEvents MAPALDataBindingSource1 As BindingSource
    Friend WithEvents MCNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LotNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LotStartTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LotEndTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents OPNoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents InputQtyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotalGoodDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TotalNGDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LabelPosChkBeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LabelPosChkAfDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LabelMarkChkBeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LabelMarkChkAfDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LabelChangeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StickLabelChangeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ReissueLabelDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ReissueLabelQtyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AndonDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents OPJudgementDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LotJudgementDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SelfConVersionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents GLCheckDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RemarkDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NetVersionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MappkgdcDataTableAdapter1 As DBxDataSetTableAdapters.MAPPKGDCDataTableAdapter
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AndonToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ByAutoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ByManualToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents APCSStaffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BMRequestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PMRepairToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkRecordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelfConModeToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OnLineModeToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents TDCToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ComportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManaulToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AuthenticationUserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ONToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OFFToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InputModeToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KeysToolStripMenuItem1 As ToolStripMenuItem
End Class
