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
        Me.components = New System.ComponentModel.Container()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lbCaption = New System.Windows.Forms.Label()
        Me.TbQRInput = New System.Windows.Forms.MaskedTextBox()
        Me.LbLotNo = New System.Windows.Forms.Label()
        Me.LbPKG = New System.Windows.Forms.Label()
        Me.LbDevice = New System.Windows.Forms.Label()
        Me.LbOPNo = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lbInputPcs = New System.Windows.Forms.Label()
        Me.tbxInput = New System.Windows.Forms.TextBox()
        Me.lbMarkNo = New System.Windows.Forms.Label()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.DBxDataSet = New MAP_Label.DBxDataSet()
        Me.TransactionDataTableAdapter = New MAP_Label.DBxDataSetTableAdapters.TransactionDataTableAdapter()
        Me.MapalDataTableAdapter1 = New MAP_Label.DBxDataSetTableAdapters.MAPALDataTableAdapter()
        Me.TransactionDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableAdapterManager = New MAP_Label.DBxDataSetTableAdapters.TableAdapterManager()
        Me.MAPPKGDCDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MAPPKGDCDataTableAdapter = New MAP_Label.DBxDataSetTableAdapters.MAPPKGDCDataTableAdapter()
        Me.TableAdapterManager1 = New MAP_Label.DBxDataSetTableAdapters.TableAdapterManager()
        Me.MapalDataTableAdapter2 = New MAP_Label.DBxDataSetTableAdapters.MAPALDataTableAdapter()
        Me.RecipeHeaderMapXTableAdapter1 = New MAP_Label.DBxDataSetTableAdapters.RecipeHeaderMapXTableAdapter()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MAPPKGDCDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lbCaption.Size = New System.Drawing.Size(327, 24)
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
        Me.LbPKG.Location = New System.Drawing.Point(12, 129)
        Me.LbPKG.Name = "LbPKG"
        Me.LbPKG.Size = New System.Drawing.Size(26, 13)
        Me.LbPKG.TabIndex = 14
        Me.LbPKG.Text = "Pkg"
        '
        'LbDevice
        '
        Me.LbDevice.AutoSize = True
        Me.LbDevice.Location = New System.Drawing.Point(12, 155)
        Me.LbDevice.Name = "LbDevice"
        Me.LbDevice.Size = New System.Drawing.Size(41, 13)
        Me.LbDevice.TabIndex = 14
        Me.LbDevice.Text = "Device"
        '
        'LbOPNo
        '
        Me.LbOPNo.AutoSize = True
        Me.LbOPNo.Location = New System.Drawing.Point(12, 179)
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
        Me.lbInputPcs.Location = New System.Drawing.Point(10, 252)
        Me.lbInputPcs.Name = "lbInputPcs"
        Me.lbInputPcs.Size = New System.Drawing.Size(53, 13)
        Me.lbInputPcs.TabIndex = 14
        Me.lbInputPcs.Text = "Input Qty."
        '
        'tbxInput
        '
        Me.tbxInput.Enabled = False
        Me.tbxInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxInput.Location = New System.Drawing.Point(140, 237)
        Me.tbxInput.Name = "tbxInput"
        Me.tbxInput.Size = New System.Drawing.Size(118, 35)
        Me.tbxInput.TabIndex = 16
        '
        'lbMarkNo
        '
        Me.lbMarkNo.AutoSize = True
        Me.lbMarkNo.Location = New System.Drawing.Point(12, 204)
        Me.lbMarkNo.Name = "lbMarkNo"
        Me.lbMarkNo.Size = New System.Drawing.Size(51, 13)
        Me.lbMarkNo.TabIndex = 14
        Me.lbMarkNo.Text = "Mark No."
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(264, 237)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(71, 35)
        Me.btnConfirm.TabIndex = 17
        Me.btnConfirm.Text = "ยืนยัน"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'DBxDataSet
        '
        Me.DBxDataSet.DataSetName = "DBxDataSet"
        Me.DBxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TransactionDataTableAdapter
        '
        Me.TransactionDataTableAdapter.ClearBeforeFill = True
        '
        'MapalDataTableAdapter1
        '
        Me.MapalDataTableAdapter1.ClearBeforeFill = True
        '
        'TransactionDataBindingSource
        '
        Me.TransactionDataBindingSource.DataMember = "TransactionData"
        Me.TransactionDataBindingSource.DataSource = Me.DBxDataSet
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
        'MAPPKGDCDataBindingSource
        '
        Me.MAPPKGDCDataBindingSource.DataMember = "MAPPKGDCData"
        Me.MAPPKGDCDataBindingSource.DataSource = Me.DBxDataSet
        '
        'MAPPKGDCDataTableAdapter
        '
        Me.MAPPKGDCDataTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.MAPAlarmInfoTableAdapter = Nothing
        Me.TableAdapterManager1.MAPAlarmTableTableAdapter = Nothing
        Me.TableAdapterManager1.MAPALDataTableAdapter = Me.MapalDataTableAdapter2
        Me.TableAdapterManager1.RecipeHeaderMapXTableAdapter = Nothing
        Me.TableAdapterManager1.TransactionDataTableAdapter = Nothing
        Me.TableAdapterManager1.UpdateOrder = MAP_Label.DBxDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'MapalDataTableAdapter2
        '
        Me.MapalDataTableAdapter2.ClearBeforeFill = True
        '
        'RecipeHeaderMapXTableAdapter1
        '
        Me.RecipeHeaderMapXTableAdapter1.ClearBeforeFill = True
        '
        'frmInputQrCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(398, 301)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.tbxInput)
        Me.Controls.Add(Me.lbInputPcs)
        Me.Controls.Add(Me.lbMarkNo)
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
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MAPPKGDCDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lbMarkNo As System.Windows.Forms.Label
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents DBxDataSet As MAP_Label.DBxDataSet
    Friend WithEvents TransactionDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TransactionDataTableAdapter As MAP_Label.DBxDataSetTableAdapters.TransactionDataTableAdapter
    Friend WithEvents TableAdapterManager As MAP_Label.DBxDataSetTableAdapters.TableAdapterManager
    Friend WithEvents MAPPKGDCDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MAPPKGDCDataTableAdapter As MAP_Label.DBxDataSetTableAdapters.MAPPKGDCDataTableAdapter
    Friend WithEvents MapalDataTableAdapter1 As MAP_Label.DBxDataSetTableAdapters.MAPALDataTableAdapter
    Friend WithEvents TableAdapterManager1 As DBxDataSetTableAdapters.TableAdapterManager
    Friend WithEvents MapalDataTableAdapter2 As DBxDataSetTableAdapters.MAPALDataTableAdapter
    Friend WithEvents RecipeHeaderMapXTableAdapter1 As DBxDataSetTableAdapters.RecipeHeaderMapXTableAdapter
End Class
