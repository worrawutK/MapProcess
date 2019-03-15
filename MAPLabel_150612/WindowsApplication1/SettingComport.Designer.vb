<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingComport
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CbSelectcomp = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(65, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 20)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Please Select Comport"
        '
        'CbSelectcomp
        '
        Me.CbSelectcomp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbSelectcomp.FormattingEnabled = True
        Me.CbSelectcomp.Items.AddRange(New Object() {"COM1**Used", "COM2**Used", "COM3**Used", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10"})
        Me.CbSelectcomp.Location = New System.Drawing.Point(51, 52)
        Me.CbSelectcomp.Name = "CbSelectcomp"
        Me.CbSelectcomp.Size = New System.Drawing.Size(219, 21)
        Me.CbSelectcomp.TabIndex = 44
        '
        'SettingComport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 99)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbSelectcomp)
        Me.Name = "SettingComport"
        Me.Text = "SettingComport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents CbSelectcomp As ComboBox
End Class
