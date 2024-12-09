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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBoxCarrierLoad
        '
        Me.TextBoxCarrierLoad.Location = New System.Drawing.Point(15, 207)
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
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(134, 194)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(380, 40)
        Me.ProgressBar1.TabIndex = 107
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.MAP_LM.My.Resources.Resources.LoadGIF
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(584, 261)
        Me.PictureBox1.TabIndex = 108
        Me.PictureBox1.TabStop = False
        '
        'frmInputCarrierLoad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(584, 261)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lbClose)
        Me.Controls.Add(Me.TextBoxCarrierLoad)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "frmInputCarrierLoad"
        Me.Text = "frmInputCarrierLoad"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxCarrierLoad As TextBox
    Friend WithEvents lbClose As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents PictureBox1 As PictureBox
End Class
