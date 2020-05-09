<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputCarrier
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
        Me.labelTextScan = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.PictureboxQrCodeInput = New System.Windows.Forms.PictureBox()
        Me.TextBoxQrCodeInput = New System.Windows.Forms.TextBox()
        Me.lbDisplay = New System.Windows.Forms.Label()
        Me.panel4 = New System.Windows.Forms.Panel()
        Me.pictureBox2 = New System.Windows.Forms.PictureBox()
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.PictureboxQrCodeInputCheck = New System.Windows.Forms.PictureBox()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.panel1.SuspendLayout()
        Me.panel2.SuspendLayout()
        CType(Me.PictureboxQrCodeInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel4.SuspendLayout()
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureboxQrCodeInputCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelTextScan
        '
        Me.labelTextScan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labelTextScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTextScan.ForeColor = System.Drawing.Color.DarkOrange
        Me.labelTextScan.Location = New System.Drawing.Point(0, 0)
        Me.labelTextScan.Name = "labelTextScan"
        Me.labelTextScan.Size = New System.Drawing.Size(365, 56)
        Me.labelTextScan.TabIndex = 63
        Me.labelTextScan.Text = "Please scan qr code"
        Me.labelTextScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.panel2)
        Me.panel1.Location = New System.Drawing.Point(9, 108)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(58, 57)
        Me.panel1.TabIndex = 75
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.PictureboxQrCodeInput)
        Me.panel2.Location = New System.Drawing.Point(8, 8)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(42, 42)
        Me.panel2.TabIndex = 59
        '
        'PictureboxQrCodeInput
        '
        Me.PictureboxQrCodeInput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureboxQrCodeInput.Image = Global.MAP_Label.My.Resources.Resources.PictureBoxQrCode
        Me.PictureboxQrCodeInput.Location = New System.Drawing.Point(0, 0)
        Me.PictureboxQrCodeInput.Name = "PictureboxQrCodeInput"
        Me.PictureboxQrCodeInput.Size = New System.Drawing.Size(42, 42)
        Me.PictureboxQrCodeInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureboxQrCodeInput.TabIndex = 55
        Me.PictureboxQrCodeInput.TabStop = False
        '
        'TextBoxQrCodeInput
        '
        Me.TextBoxQrCodeInput.Location = New System.Drawing.Point(7, 174)
        Me.TextBoxQrCodeInput.Name = "TextBoxQrCodeInput"
        Me.TextBoxQrCodeInput.Size = New System.Drawing.Size(60, 20)
        Me.TextBoxQrCodeInput.TabIndex = 74
        '
        'lbDisplay
        '
        Me.lbDisplay.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDisplay.ForeColor = System.Drawing.Color.Black
        Me.lbDisplay.Location = New System.Drawing.Point(102, 33)
        Me.lbDisplay.Name = "lbDisplay"
        Me.lbDisplay.Size = New System.Drawing.Size(370, 60)
        Me.lbDisplay.TabIndex = 76
        Me.lbDisplay.Text = "-"
        Me.lbDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panel4
        '
        Me.panel4.Controls.Add(Me.labelTextScan)
        Me.panel4.Controls.Add(Me.pictureBox2)
        Me.panel4.Location = New System.Drawing.Point(73, 108)
        Me.panel4.Name = "panel4"
        Me.panel4.Size = New System.Drawing.Size(365, 56)
        Me.panel4.TabIndex = 79
        '
        'pictureBox2
        '
        Me.pictureBox2.Location = New System.Drawing.Point(-70, 0)
        Me.pictureBox2.Name = "pictureBox2"
        Me.pictureBox2.Size = New System.Drawing.Size(70, 53)
        Me.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox2.TabIndex = 62
        Me.pictureBox2.TabStop = False
        '
        'timer1
        '
        Me.timer1.Enabled = True
        Me.timer1.Interval = 250
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(80, 174)
        Me.ProgressBar1.Maximum = 11
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(376, 23)
        Me.ProgressBar1.TabIndex = 80
        '
        'PictureboxQrCodeInputCheck
        '
        Me.PictureboxQrCodeInputCheck.Image = Global.MAP_Label.My.Resources.Resources.PictureBoxWrong
        Me.PictureboxQrCodeInputCheck.Location = New System.Drawing.Point(478, 22)
        Me.PictureboxQrCodeInputCheck.Name = "PictureboxQrCodeInputCheck"
        Me.PictureboxQrCodeInputCheck.Size = New System.Drawing.Size(40, 40)
        Me.PictureboxQrCodeInputCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureboxQrCodeInputCheck.TabIndex = 78
        Me.PictureboxQrCodeInputCheck.TabStop = False
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = Global.MAP_Label.My.Resources.Resources.PicturBoxRohmLogo
        Me.pictureBox1.Location = New System.Drawing.Point(7, 33)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(77, 60)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureBox1.TabIndex = 77
        Me.pictureBox1.TabStop = False
        '
        'InputCarrier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 218)
        Me.ControlBox = False
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.TextBoxQrCodeInput)
        Me.Controls.Add(Me.lbDisplay)
        Me.Controls.Add(Me.panel4)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.PictureboxQrCodeInputCheck)
        Me.Controls.Add(Me.pictureBox1)
        Me.Name = "InputCarrier"
        Me.Text = "InputCarrier"
        Me.panel1.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        CType(Me.PictureboxQrCodeInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel4.ResumeLayout(False)
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureboxQrCodeInputCheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents labelTextScan As Label
    Private WithEvents panel1 As Panel
    Private WithEvents panel2 As Panel
    Private WithEvents PictureboxQrCodeInput As PictureBox
    Private WithEvents TextBoxQrCodeInput As TextBox
    Friend WithEvents lbDisplay As Label
    Private WithEvents panel4 As Panel
    Private WithEvents pictureBox2 As PictureBox
    Private WithEvents timer1 As Timer
    Friend WithEvents ProgressBar1 As ProgressBar
    Private WithEvents PictureboxQrCodeInputCheck As PictureBox
    Private WithEvents pictureBox1 As PictureBox
End Class
