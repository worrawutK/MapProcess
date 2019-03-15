<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DialogEndConfirm
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
        Me.ButtonEndRetest = New System.Windows.Forms.Button()
        Me.ButtonEndNomal = New System.Windows.Forms.Button()
        Me.LabelText = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'ButtonEndRetest
        '
        Me.ButtonEndRetest.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ButtonEndRetest.Location = New System.Drawing.Point(44, 89)
        Me.ButtonEndRetest.Name = "ButtonEndRetest"
        Me.ButtonEndRetest.Size = New System.Drawing.Size(128, 79)
        Me.ButtonEndRetest.TabIndex = 0
        Me.ButtonEndRetest.Text = "Retest"
        Me.ButtonEndRetest.UseVisualStyleBackColor = True
        '
        'ButtonEndNomal
        '
        Me.ButtonEndNomal.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ButtonEndNomal.Location = New System.Drawing.Point(228, 89)
        Me.ButtonEndNomal.Name = "ButtonEndNomal"
        Me.ButtonEndNomal.Size = New System.Drawing.Size(128, 79)
        Me.ButtonEndNomal.TabIndex = 0
        Me.ButtonEndNomal.Text = "End"
        Me.ButtonEndNomal.UseVisualStyleBackColor = True
        '
        'LabelText
        '
        Me.LabelText.AutoSize = True
        Me.LabelText.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.LabelText.Location = New System.Drawing.Point(81, 27)
        Me.LabelText.Name = "LabelText"
        Me.LabelText.Size = New System.Drawing.Size(240, 33)
        Me.LabelText.TabIndex = 1
        Me.LabelText.Text = "Confirm End Lot"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(44, 57)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(312, 5)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 2
        '
        'DialogEndConfirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 185)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.LabelText)
        Me.Controls.Add(Me.ButtonEndNomal)
        Me.Controls.Add(Me.ButtonEndRetest)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "DialogEndConfirm"
        Me.Text = "DialogEndConfirm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonEndRetest As Button
    Friend WithEvents ButtonEndNomal As Button
    Friend WithEvents LabelText As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
