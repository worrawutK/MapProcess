<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mode
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.rbtA = New System.Windows.Forms.RadioButton
        Me.rbtC = New System.Windows.Forms.RadioButton
        Me.rbtB = New System.Windows.Forms.RadioButton
        Me.rbtD = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'rbtA
        '
        Me.rbtA.AutoSize = True
        Me.rbtA.Location = New System.Drawing.Point(7, 9)
        Me.rbtA.Name = "rbtA"
        Me.rbtA.Size = New System.Drawing.Size(32, 17)
        Me.rbtA.TabIndex = 0
        Me.rbtA.TabStop = True
        Me.rbtA.Text = "A"
        Me.rbtA.UseVisualStyleBackColor = True
        '
        'rbtC
        '
        Me.rbtC.AutoSize = True
        Me.rbtC.Location = New System.Drawing.Point(76, 9)
        Me.rbtC.Name = "rbtC"
        Me.rbtC.Size = New System.Drawing.Size(32, 17)
        Me.rbtC.TabIndex = 0
        Me.rbtC.TabStop = True
        Me.rbtC.Text = "C"
        Me.rbtC.UseVisualStyleBackColor = True
        '
        'rbtB
        '
        Me.rbtB.AutoSize = True
        Me.rbtB.Location = New System.Drawing.Point(41, 9)
        Me.rbtB.Name = "rbtB"
        Me.rbtB.Size = New System.Drawing.Size(32, 17)
        Me.rbtB.TabIndex = 0
        Me.rbtB.TabStop = True
        Me.rbtB.Text = "B"
        Me.rbtB.UseVisualStyleBackColor = True
        '
        'rbtD
        '
        Me.rbtD.AutoSize = True
        Me.rbtD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.rbtD.Location = New System.Drawing.Point(110, 10)
        Me.rbtD.Name = "rbtD"
        Me.rbtD.Size = New System.Drawing.Size(29, 17)
        Me.rbtD.TabIndex = 0
        Me.rbtD.TabStop = True
        Me.rbtD.Text = "-"
        Me.rbtD.UseVisualStyleBackColor = True
        '
        'Mode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.rbtB)
        Me.Controls.Add(Me.rbtD)
        Me.Controls.Add(Me.rbtC)
        Me.Controls.Add(Me.rbtA)
        Me.Name = "Mode"
        Me.Size = New System.Drawing.Size(146, 36)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbtA As System.Windows.Forms.RadioButton
    Friend WithEvents rbtC As System.Windows.Forms.RadioButton
    Friend WithEvents rbtB As System.Windows.Forms.RadioButton
    Friend WithEvents rbtD As System.Windows.Forms.RadioButton

End Class
