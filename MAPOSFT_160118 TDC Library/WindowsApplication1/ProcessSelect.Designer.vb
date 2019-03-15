<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessSelect
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.lbprocess = New System.Windows.Forms.Label
        Me.lbBxName = New System.Windows.Forms.Label
        Me.tbxInput = New System.Windows.Forms.TextBox
        Me.btnConfirm = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioButton4)
        Me.Panel1.Controls.Add(Me.RadioButton3)
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(63, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(234, 36)
        Me.Panel1.TabIndex = 21
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(172, 7)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(58, 17)
        Me.RadioButton4.TabIndex = 18
        Me.RadioButton4.Text = "OS/FT"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(104, 7)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(61, 17)
        Me.RadioButton3.TabIndex = 18
        Me.RadioButton3.Text = "AUTO2"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(41, 7)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(61, 17)
        Me.RadioButton2.TabIndex = 18
        Me.RadioButton2.Text = "AUTO1"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(3, 7)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(40, 17)
        Me.RadioButton1.TabIndex = 18
        Me.RadioButton1.Text = "OS"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'lbprocess
        '
        Me.lbprocess.AutoSize = True
        Me.lbprocess.Location = New System.Drawing.Point(11, 54)
        Me.lbprocess.Name = "lbprocess"
        Me.lbprocess.Size = New System.Drawing.Size(45, 13)
        Me.lbprocess.TabIndex = 20
        Me.lbprocess.Text = "Process"
        '
        'lbBxName
        '
        Me.lbBxName.AutoSize = True
        Me.lbBxName.Location = New System.Drawing.Point(1, 130)
        Me.lbBxName.Name = "lbBxName"
        Me.lbBxName.Size = New System.Drawing.Size(56, 13)
        Me.lbBxName.TabIndex = 23
        Me.lbBxName.Text = "Box Name"
        '
        'tbxInput
        '
        Me.tbxInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxInput.Location = New System.Drawing.Point(81, 119)
        Me.tbxInput.Name = "tbxInput"
        Me.tbxInput.Size = New System.Drawing.Size(139, 35)
        Me.tbxInput.TabIndex = 24
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(226, 119)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(71, 35)
        Me.btnConfirm.TabIndex = 25
        Me.btnConfirm.Text = "ยืนยัน"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'ProcessSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 170)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.tbxInput)
        Me.Controls.Add(Me.lbBxName)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbprocess)
        Me.Name = "ProcessSelect"
        Me.Text = "ProcessSelect"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents lbprocess As System.Windows.Forms.Label
    Friend WithEvents lbBxName As System.Windows.Forms.Label
    Friend WithEvents tbxInput As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
End Class
