<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputCarrierLoad
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
        Me.TextBoxCarrierLoad = New System.Windows.Forms.TextBox()
        Me.lbClose = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBoxCarrierLoad
        '
        Me.TextBoxCarrierLoad.Location = New System.Drawing.Point(13, 207)
        Me.TextBoxCarrierLoad.Name = "TextBoxCarrierLoad"
        Me.TextBoxCarrierLoad.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxCarrierLoad.TabIndex = 0
        '
        'lbClose
        '
        Me.lbClose.BackColor = System.Drawing.Color.Transparent
        Me.lbClose.Location = New System.Drawing.Point(520, 9)
        Me.lbClose.Name = "lbClose"
        Me.lbClose.Size = New System.Drawing.Size(51, 46)
        Me.lbClose.TabIndex = 103
        '
        'frmInputCarrierLoad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.MAP_LM.My.Resources.Resources.LoadGIF
        Me.ClientSize = New System.Drawing.Size(584, 261)
        Me.Controls.Add(Me.lbClose)
        Me.Controls.Add(Me.TextBoxCarrierLoad)
        Me.Name = "frmInputCarrierLoad"
        Me.Text = "frmInputCarrierLoad"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxCarrierLoad As TextBox
    Friend WithEvents lbClose As Label
End Class
