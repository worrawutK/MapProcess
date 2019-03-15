<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ScanASEID
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbAssyLotNo = New System.Windows.Forms.Label()
        Me.RingID = New System.Windows.Forms.Button()
        Me.StripID01 = New System.Windows.Forms.Button()
        Me.btRegister = New System.Windows.Forms.Button()
        Me.QRCode = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(23, 113)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(1, 10)
        Me.TextBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "AssyLotNo :"
        '
        'lbAssyLotNo
        '
        Me.lbAssyLotNo.AutoSize = True
        Me.lbAssyLotNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbAssyLotNo.Location = New System.Drawing.Point(141, 9)
        Me.lbAssyLotNo.Name = "lbAssyLotNo"
        Me.lbAssyLotNo.Size = New System.Drawing.Size(125, 25)
        Me.lbAssyLotNo.TabIndex = 1
        Me.lbAssyLotNo.Text = "AssyLotNo"
        '
        'RingID
        '
        Me.RingID.BackColor = System.Drawing.Color.Silver
        Me.RingID.Enabled = False
        Me.RingID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.RingID.Location = New System.Drawing.Point(12, 166)
        Me.RingID.Name = "RingID"
        Me.RingID.Size = New System.Drawing.Size(163, 63)
        Me.RingID.TabIndex = 3
        Me.RingID.Text = "RingID"
        Me.RingID.UseVisualStyleBackColor = False
        '
        'StripID01
        '
        Me.StripID01.BackColor = System.Drawing.Color.Silver
        Me.StripID01.Enabled = False
        Me.StripID01.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.StripID01.Location = New System.Drawing.Point(234, 166)
        Me.StripID01.Name = "StripID01"
        Me.StripID01.Size = New System.Drawing.Size(179, 63)
        Me.StripID01.TabIndex = 3
        Me.StripID01.UseVisualStyleBackColor = False
        '
        'btRegister
        '
        Me.btRegister.BackColor = System.Drawing.Color.Silver
        Me.btRegister.Location = New System.Drawing.Point(293, 239)
        Me.btRegister.Name = "btRegister"
        Me.btRegister.Size = New System.Drawing.Size(119, 44)
        Me.btRegister.TabIndex = 3
        Me.btRegister.Text = "Register ASE"
        Me.btRegister.UseVisualStyleBackColor = False
        '
        'QRCode
        '
        Me.QRCode.BackColor = System.Drawing.Color.Silver
        Me.QRCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.QRCode.Location = New System.Drawing.Point(73, 60)
        Me.QRCode.Name = "QRCode"
        Me.QRCode.Size = New System.Drawing.Size(258, 63)
        Me.QRCode.TabIndex = 3
        Me.QRCode.Text = "Scan QR Code"
        Me.QRCode.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(182, 177)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 31)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = ">>"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 25)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "RingID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(288, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 25)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "StriplD"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Silver
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(12, 239)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 44)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ScanASEID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 295)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btRegister)
        Me.Controls.Add(Me.QRCode)
        Me.Controls.Add(Me.StripID01)
        Me.Controls.Add(Me.RingID)
        Me.Controls.Add(Me.lbAssyLotNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ScanASEID"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ScanASEID"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbAssyLotNo As Label
    Friend WithEvents RingID As Button
    Friend WithEvents StripID01 As Button
    Friend WithEvents btRegister As Button
    Friend WithEvents QRCode As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
End Class
