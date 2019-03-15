<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TBoxReciveMessage = New System.Windows.Forms.TextBox
        Me.TBoxLog = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "TBoxLog"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "TBoxReciveMessage"
        '
        'TBoxReciveMessage
        '
        Me.TBoxReciveMessage.Location = New System.Drawing.Point(5, 146)
        Me.TBoxReciveMessage.Multiline = True
        Me.TBoxReciveMessage.Name = "TBoxReciveMessage"
        Me.TBoxReciveMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBoxReciveMessage.Size = New System.Drawing.Size(415, 184)
        Me.TBoxReciveMessage.TabIndex = 5
        '
        'TBoxLog
        '
        Me.TBoxLog.Location = New System.Drawing.Point(5, 19)
        Me.TBoxLog.Multiline = True
        Me.TBoxLog.Name = "TBoxLog"
        Me.TBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBoxLog.Size = New System.Drawing.Size(415, 113)
        Me.TBoxLog.TabIndex = 4
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 332)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TBoxReciveMessage)
        Me.Controls.Add(Me.TBoxLog)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TBoxReciveMessage As System.Windows.Forms.TextBox
    Friend WithEvents TBoxLog As System.Windows.Forms.TextBox
End Class
