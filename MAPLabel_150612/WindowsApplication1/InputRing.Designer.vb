<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputRing
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
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.tbxInput = New System.Windows.Forms.TextBox()
        Me.lbInputPcs = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(179, 122)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(71, 35)
        Me.btnConfirm.TabIndex = 23
        Me.btnConfirm.Text = "ยืนยัน"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'tbxInput
        '
        Me.tbxInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxInput.Location = New System.Drawing.Point(27, 122)
        Me.tbxInput.Name = "tbxInput"
        Me.tbxInput.Size = New System.Drawing.Size(118, 35)
        Me.tbxInput.TabIndex = 22
        '
        'lbInputPcs
        '
        Me.lbInputPcs.AutoSize = True
        Me.lbInputPcs.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbInputPcs.Location = New System.Drawing.Point(20, 22)
        Me.lbInputPcs.Name = "lbInputPcs"
        Me.lbInputPcs.Size = New System.Drawing.Size(237, 39)
        Me.lbInputPcs.TabIndex = 21
        Me.lbInputPcs.Text = "Input Ring Qty"
        '
        'InputRing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 194)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.tbxInput)
        Me.Controls.Add(Me.lbInputPcs)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InputRing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InputRing"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnConfirm As Button
    Friend WithEvents tbxInput As TextBox
    Friend WithEvents lbInputPcs As Label
End Class
