<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInputCarrierRegis
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
        Me.lbClose = New System.Windows.Forms.Label()
        Me.TextBoxCarrierRegis = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbClose
        '
        Me.lbClose.BackColor = System.Drawing.Color.Transparent
        Me.lbClose.Location = New System.Drawing.Point(520, 8)
        Me.lbClose.Name = "lbClose"
        Me.lbClose.Size = New System.Drawing.Size(51, 46)
        Me.lbClose.TabIndex = 104
        '
        'TextBoxCarrierRegis
        '
        Me.TextBoxCarrierRegis.Location = New System.Drawing.Point(15, 207)
        Me.TextBoxCarrierRegis.Name = "TextBoxCarrierRegis"
        Me.TextBoxCarrierRegis.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxCarrierRegis.TabIndex = 105
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(134, 194)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(380, 40)
        Me.ProgressBar1.TabIndex = 106
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.MAP_LM.My.Resources.Resources.RegisGIF
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(584, 261)
        Me.PictureBox1.TabIndex = 107
        Me.PictureBox1.TabStop = False
        '
        'FrmInputCarrierRegis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 261)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TextBoxCarrierRegis)
        Me.Controls.Add(Me.lbClose)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FrmInputCarrierRegis"
        Me.Text = "FrmInputCarrierRegis"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbClose As Label
    Friend WithEvents TextBoxCarrierRegis As TextBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents PictureBox1 As PictureBox
End Class
