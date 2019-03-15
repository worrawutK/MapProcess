<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputQty
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
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.MAPPKGDCDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DBxDataSet = New MAP_Label.DBxDataSet()
        Me.tbxInput = New System.Windows.Forms.TextBox()
        Me.TableAdapterManager = New MAP_Label.DBxDataSetTableAdapters.TableAdapterManager()
        Me.TransactionDataTableAdapter = New MAP_Label.DBxDataSetTableAdapters.TransactionDataTableAdapter()
        Me.TransactionDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MAPPKGDCDataTableAdapter = New MAP_Label.DBxDataSetTableAdapters.MAPPKGDCDataTableAdapter()
        Me.lbCaption = New System.Windows.Forms.Label()
        CType(Me.MAPPKGDCDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(12, 113)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(71, 35)
        Me.btnConfirm.TabIndex = 28
        Me.btnConfirm.Text = "ยืนยัน"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'MAPPKGDCDataBindingSource
        '
        Me.MAPPKGDCDataBindingSource.DataMember = "MAPPKGDCData"
        Me.MAPPKGDCDataBindingSource.DataSource = Me.DBxDataSet
        '
        'DBxDataSet
        '
        Me.DBxDataSet.DataSetName = "DBxDataSet"
        Me.DBxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tbxInput
        '
        Me.tbxInput.Enabled = False
        Me.tbxInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxInput.Location = New System.Drawing.Point(13, 60)
        Me.tbxInput.MaxLength = 6
        Me.tbxInput.Name = "tbxInput"
        Me.tbxInput.Size = New System.Drawing.Size(118, 35)
        Me.tbxInput.TabIndex = 27
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.MAPALDataTableAdapter = Nothing
        Me.TableAdapterManager.TransactionDataTableAdapter = Me.TransactionDataTableAdapter
        Me.TableAdapterManager.UpdateOrder = MAP_Label.DBxDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'TransactionDataTableAdapter
        '
        Me.TransactionDataTableAdapter.ClearBeforeFill = True
        '
        'TransactionDataBindingSource
        '
        Me.TransactionDataBindingSource.DataMember = "TransactionData"
        Me.TransactionDataBindingSource.DataSource = Me.DBxDataSet
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'MAPPKGDCDataTableAdapter
        '
        Me.MAPPKGDCDataTableAdapter.ClearBeforeFill = True
        '
        'lbCaption
        '
        Me.lbCaption.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCaption.Location = New System.Drawing.Point(8, 16)
        Me.lbCaption.Name = "lbCaption"
        Me.lbCaption.Size = New System.Drawing.Size(227, 24)
        Me.lbCaption.TabIndex = 19
        Me.lbCaption.Text = "Input Qty"
        Me.lbCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InputQty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(239, 162)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.tbxInput)
        Me.Controls.Add(Me.lbCaption)
        Me.Name = "InputQty"
        Me.Text = "InputQty"
        CType(Me.MAPPKGDCDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DBxDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents MAPPKGDCDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DBxDataSet As MAP_Label.DBxDataSet
    Friend WithEvents tbxInput As System.Windows.Forms.TextBox
    Friend WithEvents TableAdapterManager As MAP_Label.DBxDataSetTableAdapters.TableAdapterManager
    Friend WithEvents TransactionDataTableAdapter As MAP_Label.DBxDataSetTableAdapters.TransactionDataTableAdapter
    Friend WithEvents TransactionDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MAPPKGDCDataTableAdapter As MAP_Label.DBxDataSetTableAdapters.MAPPKGDCDataTableAdapter
    Friend WithEvents lbCaption As System.Windows.Forms.Label
End Class
