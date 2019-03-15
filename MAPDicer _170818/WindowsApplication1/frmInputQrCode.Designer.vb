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
        Me.lbInputPcs = New System.Windows.Forms.Label
        Me.tbxInput = New System.Windows.Forms.TextBox
        Me.btnConfirm = New System.Windows.Forms.Button
        Me.DBxDataSet = New MAP_Dicer.DBxDataSet
        Me.MAPPKGMTDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MAPPKGMTDataTableAdapter = New MAP_Dicer.DBxDataSetTableAdapters.MAPPKGMTDataTableAdapter
        Me.TableAdapterManager = New MAP_Dicer.DBxDataSetTableAdapters.TableAdapterManager
        Me.TransactionDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TransactionDataTableAdapter = New MAP_Dicer.DBxDataSetTableAdapters.TransactionDataTableAdapter
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MAPPKGMTDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'MAPPKGMTDataBindingSource
        '
        Me.MAPPKGMTDataBindingSource.DataMember = "MAPPKGMTData"
        Me.MAPPKGMTDataBindingSource.DataSource = Me.DBxDataSet
        '
        'MAPPKGMTDataTableAdapter
        '
        Me.MAPPKGMTDataTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.MAPPKGDCDataTableAdapter = Nothing
        Me.TableAdapterManager.TransactionDataTableAdapter = Me.TransactionDataTableAdapter
        Me.TableAdapterManager.UpdateOrder = MAP_Dicer.DBxDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
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
        'frmInputQrCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(355, 301)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.tbxInput)
        Me.Controls.Add(Me.lbInputPcs)
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
        CType(Me.MAPPKGMTDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lbInputPcs As System.Windows.Forms.Label
    Friend WithEvents tbxInput As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents DBxDataSet As MAP_Dicer.DBxDataSet
    Friend WithEvents MAPPKGMTDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MAPPKGMTDataTableAdapter As MAP_Dicer.DBxDataSetTableAdapters.MAPPKGMTDataTableAdapter
    Friend WithEvents TableAdapterManager As MAP_Dicer.DBxDataSetTableAdapters.TableAdapterManager
    Friend WithEvents TransactionDataTableAdapter As MAP_Dicer.DBxDataSetTableAdapters.TransactionDataTableAdapter
    Friend WithEvents TransactionDataBindingSource As System.Windows.Forms.BindingSource
End Class
