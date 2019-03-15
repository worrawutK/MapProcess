<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputQrCode
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.lbCaption = New System.Windows.Forms.Label
        Me.TbQRInput = New System.Windows.Forms.MaskedTextBox
        Me.LbLotNo = New System.Windows.Forms.Label
        Me.LbPKG = New System.Windows.Forms.Label
        Me.LbDevice = New System.Windows.Forms.Label
        Me.LbOPNo = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lbInputPcs = New System.Windows.Forms.Label
        Me.tbxInput = New System.Windows.Forms.TextBox
        Me.btnConfirm = New System.Windows.Forms.Button
        Me.lbprocess = New System.Windows.Forms.Label
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.lbProName = New System.Windows.Forms.Label
        Me.lbBxName = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.DBxDataSet = New MAP_OSFT.DBxDataSet
        Me.TransactionDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TransactionDataTableAdapter = New MAP_OSFT.DBxDataSetTableAdapters.TransactionDataTableAdapter
        Me.TableAdapterManager = New MAP_OSFT.DBxDataSetTableAdapters.TableAdapterManager
        Me.MAPALDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MAPALDataTableAdapter = New MAP_OSFT.DBxDataSetTableAdapters.MAPALDataTableAdapter
        Me.MAPOSFTDataTableAdapter = New MAP_OSFT.DBxDataSetTableAdapters.MAPOSFTDataTableAdapter
        Me.Panel1.SuspendLayout()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MAPALDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 60)
        Me.ProgressBar1.Maximum = 252
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(307, 25)
        Me.ProgressBar1.TabIndex = 13
        '
        'lbCaption
        '
        Me.lbCaption.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCaption.Location = New System.Drawing.Point(8, 19)
        Me.lbCaption.Name = "lbCaption"
        Me.lbCaption.Size = New System.Drawing.Size(227, 24)
        Me.lbCaption.TabIndex = 12
        Me.lbCaption.Text = "Caption"
        Me.lbCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TbQRInput
        '
        Me.TbQRInput.Location = New System.Drawing.Point(300, 6)
        Me.TbQRInput.Name = "TbQRInput"
        Me.TbQRInput.PasswordChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TbQRInput.Size = New System.Drawing.Size(20, 20)
        Me.TbQRInput.TabIndex = 11
        '
        'LbLotNo
        '
        Me.LbLotNo.AutoSize = True
        Me.LbLotNo.Location = New System.Drawing.Point(12, 108)
        Me.LbLotNo.Name = "LbLotNo"
        Me.LbLotNo.Size = New System.Drawing.Size(36, 13)
        Me.LbLotNo.TabIndex = 14
        Me.LbLotNo.Text = "LotNo"
        '
        'LbPKG
        '
        Me.LbPKG.AutoSize = True
        Me.LbPKG.Location = New System.Drawing.Point(12, 134)
        Me.LbPKG.Name = "LbPKG"
        Me.LbPKG.Size = New System.Drawing.Size(26, 13)
        Me.LbPKG.TabIndex = 14
        Me.LbPKG.Text = "Pkg"
        '
        'LbDevice
        '
        Me.LbDevice.AutoSize = True
        Me.LbDevice.Location = New System.Drawing.Point(12, 160)
        Me.LbDevice.Name = "LbDevice"
        Me.LbDevice.Size = New System.Drawing.Size(41, 13)
        Me.LbDevice.TabIndex = 14
        Me.LbDevice.Text = "Device"
        '
        'LbOPNo
        '
        Me.LbOPNo.AutoSize = True
        Me.LbOPNo.Location = New System.Drawing.Point(12, 186)
        Me.LbOPNo.Name = "LbOPNo"
        Me.LbOPNo.Size = New System.Drawing.Size(42, 13)
        Me.LbOPNo.TabIndex = 14
        Me.LbOPNo.Text = "OP No."
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'lbInputPcs
        '
        Me.lbInputPcs.AutoSize = True
        Me.lbInputPcs.Location = New System.Drawing.Point(11, 335)
        Me.lbInputPcs.Name = "lbInputPcs"
        Me.lbInputPcs.Size = New System.Drawing.Size(53, 13)
        Me.lbInputPcs.TabIndex = 14
        Me.lbInputPcs.Text = "Input Qty."
        '
        'tbxInput
        '
        Me.tbxInput.Enabled = False
        Me.tbxInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxInput.Location = New System.Drawing.Point(103, 320)
        Me.tbxInput.Name = "tbxInput"
        Me.tbxInput.Size = New System.Drawing.Size(139, 35)
        Me.tbxInput.TabIndex = 16
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(248, 320)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(71, 35)
        Me.btnConfirm.TabIndex = 17
        Me.btnConfirm.Text = "ยืนยัน"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'lbprocess
        '
        Me.lbprocess.AutoSize = True
        Me.lbprocess.Location = New System.Drawing.Point(12, 264)
        Me.lbprocess.Name = "lbprocess"
        Me.lbprocess.Size = New System.Drawing.Size(45, 13)
        Me.lbprocess.TabIndex = 14
        Me.lbprocess.Text = "Process"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(17, 6)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(40, 17)
        Me.RadioButton1.TabIndex = 18
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "OS"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(57, 7)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(61, 17)
        Me.RadioButton2.TabIndex = 18
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "AUTO1"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(115, 7)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(58, 17)
        Me.RadioButton3.TabIndex = 18
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "OS/FT"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'lbProName
        '
        Me.lbProName.AutoSize = True
        Me.lbProName.Location = New System.Drawing.Point(9, 212)
        Me.lbProName.Name = "lbProName"
        Me.lbProName.Size = New System.Drawing.Size(77, 13)
        Me.lbProName.TabIndex = 14
        Me.lbProName.Text = "Program Name"
        '
        'lbBxName
        '
        Me.lbBxName.AutoSize = True
        Me.lbBxName.Location = New System.Drawing.Point(11, 238)
        Me.lbBxName.Name = "lbBxName"
        Me.lbBxName.Size = New System.Drawing.Size(56, 13)
        Me.lbBxName.TabIndex = 14
        Me.lbBxName.Text = "Box Name"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioButton3)
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Location = New System.Drawing.Point(86, 255)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(185, 36)
        Me.Panel1.TabIndex = 19
        '
        'DBxDataSet
        '
        Me.DBxDataSet.DataSetName = "DBxDataSet"
        Me.DBxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TransactionDataBindingSource
        '
        Me.TransactionDataBindingSource.DataMember = "TransactionData"
        Me.TransactionDataBindingSource.DataSource = Me.DBxDataSet
        '
        'TransactionDataTableAdapter
        '
        Me.TransactionDataTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.MAP_MAPDataTableAdapter = Nothing
        Me.TableAdapterManager.MAPALDataTableAdapter = Nothing
        Me.TableAdapterManager.MAPOSFTDataTableAdapter = Nothing
        Me.TableAdapterManager.TransactionDataTableAdapter = Me.TransactionDataTableAdapter
        Me.TableAdapterManager.UpdateOrder = MAP_OSFT.DBxDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'MAPALDataBindingSource
        '
        Me.MAPALDataBindingSource.DataMember = "MAPALData"
        Me.MAPALDataBindingSource.DataSource = Me.DBxDataSet
        '
        'MAPALDataTableAdapter
        '
        Me.MAPALDataTableAdapter.ClearBeforeFill = True
        '
        'MAPOSFTDataTableAdapter
        '
        Me.MAPOSFTDataTableAdapter.ClearBeforeFill = True
        '
        'frmInputQrCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(346, 375)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.tbxInput)
        Me.Controls.Add(Me.lbInputPcs)
        Me.Controls.Add(Me.lbBxName)
        Me.Controls.Add(Me.lbProName)
        Me.Controls.Add(Me.lbprocess)
        Me.Controls.Add(Me.LbOPNo)
        Me.Controls.Add(Me.LbDevice)
        Me.Controls.Add(Me.LbPKG)
        Me.Controls.Add(Me.LbLotNo)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lbCaption)
        Me.Controls.Add(Me.TbQRInput)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInputQrCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "QR Code"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MAPALDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lbCaption As System.Windows.Forms.Label
    Friend WithEvents TbQRInput As System.Windows.Forms.MaskedTextBox
    Friend WithEvents LbLotNo As System.Windows.Forms.Label
    Friend WithEvents LbPKG As System.Windows.Forms.Label
    Friend WithEvents LbDevice As System.Windows.Forms.Label
    Friend WithEvents LbOPNo As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lbInputPcs As System.Windows.Forms.Label
    Friend WithEvents tbxInput As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents DBxDataSet As MAP_OSFT.DBxDataSet
    Friend WithEvents TransactionDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TransactionDataTableAdapter As MAP_OSFT.DBxDataSetTableAdapters.TransactionDataTableAdapter
    Friend WithEvents TableAdapterManager As MAP_OSFT.DBxDataSetTableAdapters.TableAdapterManager
    Friend WithEvents MAPALDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MAPALDataTableAdapter As MAP_OSFT.DBxDataSetTableAdapters.MAPALDataTableAdapter
    Friend WithEvents lbprocess As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents lbProName As System.Windows.Forms.Label
    Friend WithEvents lbBxName As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MAPOSFTDataTableAdapter As MAP_OSFT.DBxDataSetTableAdapters.MAPOSFTDataTableAdapter
End Class
