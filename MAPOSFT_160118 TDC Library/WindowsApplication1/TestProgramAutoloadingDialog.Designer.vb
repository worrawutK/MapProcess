<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestProgramAutoloadingDialog
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
        Me.label28 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.LabelCurrentProgramName = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.LabelCurrentTestFlow = New System.Windows.Forms.Label()
        Me.label22 = New System.Windows.Forms.Label()
        Me.LabelCurrentPackage = New System.Windows.Forms.Label()
        Me.LabelCurrentFTDeviceName = New System.Windows.Forms.Label()
        Me.LabelCurrentLotNo = New System.Windows.Forms.Label()
        Me.label26 = New System.Windows.Forms.Label()
        Me.label27 = New System.Windows.Forms.Label()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.ButtonStopAll = New System.Windows.Forms.Button()
        Me.ButtonStartAll = New System.Windows.Forms.Button()
        Me.ButtonStop = New System.Windows.Forms.Button()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelSetupProgramName = New System.Windows.Forms.Label()
        Me.FTSetupRecordBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelSetupTestFlow = New System.Windows.Forms.Label()
        Me.label17 = New System.Windows.Forms.Label()
        Me.label18 = New System.Windows.Forms.Label()
        Me.LabelSetupPackage = New System.Windows.Forms.Label()
        Me.LabelSetupFTDevice = New System.Windows.Forms.Label()
        Me.LabelSetupLotNo = New System.Windows.Forms.Label()
        Me.LabelSetupTesterB = New System.Windows.Forms.Label()
        Me.LabelSetupTesterA = New System.Windows.Forms.Label()
        Me.LabelSetupTesterType = New System.Windows.Forms.Label()
        Me.LabelSetupStatus = New System.Windows.Forms.Label()
        Me.LabelSetupMachineNo = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.testProgramAutoloadingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.FTSetupRecordBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.testProgramAutoloadingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label28
        '
        Me.label28.AutoSize = True
        Me.label28.Location = New System.Drawing.Point(99, 22)
        Me.label28.Name = "label28"
        Me.label28.Size = New System.Drawing.Size(45, 13)
        Me.label28.TabIndex = 20
        Me.label28.Text = "Lot No :"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.LabelCurrentProgramName)
        Me.groupBox2.Controls.Add(Me.label10)
        Me.groupBox2.Controls.Add(Me.LabelCurrentTestFlow)
        Me.groupBox2.Controls.Add(Me.label22)
        Me.groupBox2.Controls.Add(Me.LabelCurrentPackage)
        Me.groupBox2.Controls.Add(Me.LabelCurrentFTDeviceName)
        Me.groupBox2.Controls.Add(Me.LabelCurrentLotNo)
        Me.groupBox2.Controls.Add(Me.label26)
        Me.groupBox2.Controls.Add(Me.label27)
        Me.groupBox2.Controls.Add(Me.label28)
        Me.groupBox2.Location = New System.Drawing.Point(11, 196)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(650, 116)
        Me.groupBox2.TabIndex = 15
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Lot Information"
        '
        'LabelCurrentProgramName
        '
        Me.LabelCurrentProgramName.BackColor = System.Drawing.Color.White
        Me.LabelCurrentProgramName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelCurrentProgramName.Location = New System.Drawing.Point(388, 79)
        Me.LabelCurrentProgramName.Name = "LabelCurrentProgramName"
        Me.LabelCurrentProgramName.Size = New System.Drawing.Size(184, 24)
        Me.LabelCurrentProgramName.TabIndex = 29
        Me.LabelCurrentProgramName.Text = "FU5753FVM A1"
        Me.LabelCurrentProgramName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(317, 85)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(52, 13)
        Me.label10.TabIndex = 28
        Me.label10.Text = "Program :"
        '
        'LabelCurrentTestFlow
        '
        Me.LabelCurrentTestFlow.BackColor = System.Drawing.Color.White
        Me.LabelCurrentTestFlow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelCurrentTestFlow.Location = New System.Drawing.Point(388, 46)
        Me.LabelCurrentTestFlow.Name = "LabelCurrentTestFlow"
        Me.LabelCurrentTestFlow.Size = New System.Drawing.Size(184, 24)
        Me.LabelCurrentTestFlow.TabIndex = 27
        Me.LabelCurrentTestFlow.Text = "AUTO1"
        Me.LabelCurrentTestFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.Location = New System.Drawing.Point(310, 52)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(59, 13)
        Me.label22.TabIndex = 26
        Me.label22.Text = "Test Flow :"
        '
        'LabelCurrentPackage
        '
        Me.LabelCurrentPackage.BackColor = System.Drawing.Color.White
        Me.LabelCurrentPackage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelCurrentPackage.Location = New System.Drawing.Point(161, 46)
        Me.LabelCurrentPackage.Name = "LabelCurrentPackage"
        Me.LabelCurrentPackage.Size = New System.Drawing.Size(116, 24)
        Me.LabelCurrentPackage.TabIndex = 25
        Me.LabelCurrentPackage.Text = "MSOP8"
        Me.LabelCurrentPackage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCurrentFTDeviceName
        '
        Me.LabelCurrentFTDeviceName.BackColor = System.Drawing.Color.White
        Me.LabelCurrentFTDeviceName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelCurrentFTDeviceName.Location = New System.Drawing.Point(388, 16)
        Me.LabelCurrentFTDeviceName.Name = "LabelCurrentFTDeviceName"
        Me.LabelCurrentFTDeviceName.Size = New System.Drawing.Size(184, 24)
        Me.LabelCurrentFTDeviceName.TabIndex = 24
        Me.LabelCurrentFTDeviceName.Text = "BU5753FVM-E2"
        Me.LabelCurrentFTDeviceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCurrentLotNo
        '
        Me.LabelCurrentLotNo.BackColor = System.Drawing.Color.White
        Me.LabelCurrentLotNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelCurrentLotNo.Location = New System.Drawing.Point(161, 16)
        Me.LabelCurrentLotNo.Name = "LabelCurrentLotNo"
        Me.LabelCurrentLotNo.Size = New System.Drawing.Size(116, 24)
        Me.LabelCurrentLotNo.TabIndex = 23
        Me.LabelCurrentLotNo.Text = "1833A4567V"
        Me.LabelCurrentLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label26
        '
        Me.label26.AutoSize = True
        Me.label26.Location = New System.Drawing.Point(88, 52)
        Me.label26.Name = "label26"
        Me.label26.Size = New System.Drawing.Size(56, 13)
        Me.label26.TabIndex = 22
        Me.label26.Text = "Package :"
        '
        'label27
        '
        Me.label27.AutoSize = True
        Me.label27.Location = New System.Drawing.Point(322, 22)
        Me.label27.Name = "label27"
        Me.label27.Size = New System.Drawing.Size(47, 13)
        Me.label27.TabIndex = 21
        Me.label27.Text = "Device :"
        '
        'ButtonClose
        '
        Me.ButtonClose.Location = New System.Drawing.Point(487, 335)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClose.TabIndex = 14
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'ButtonStopAll
        '
        Me.ButtonStopAll.Location = New System.Drawing.Point(393, 335)
        Me.ButtonStopAll.Name = "ButtonStopAll"
        Me.ButtonStopAll.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStopAll.TabIndex = 13
        Me.ButtonStopAll.Text = "Stop All"
        Me.ButtonStopAll.UseVisualStyleBackColor = True
        '
        'ButtonStartAll
        '
        Me.ButtonStartAll.Location = New System.Drawing.Point(300, 335)
        Me.ButtonStartAll.Name = "ButtonStartAll"
        Me.ButtonStartAll.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStartAll.TabIndex = 12
        Me.ButtonStartAll.Text = "Start All"
        Me.ButtonStartAll.UseVisualStyleBackColor = True
        '
        'ButtonStop
        '
        Me.ButtonStop.Location = New System.Drawing.Point(207, 335)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStop.TabIndex = 11
        Me.ButtonStop.Text = "Stop"
        Me.ButtonStop.UseVisualStyleBackColor = True
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(114, 335)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 10
        Me.ButtonStart.Text = "Start"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'backgroundWorker1
        '
        Me.backgroundWorker1.WorkerReportsProgress = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.LabelSetupProgramName)
        Me.groupBox1.Controls.Add(Me.LabelSetupTestFlow)
        Me.groupBox1.Controls.Add(Me.label17)
        Me.groupBox1.Controls.Add(Me.label18)
        Me.groupBox1.Controls.Add(Me.LabelSetupPackage)
        Me.groupBox1.Controls.Add(Me.LabelSetupFTDevice)
        Me.groupBox1.Controls.Add(Me.LabelSetupLotNo)
        Me.groupBox1.Controls.Add(Me.LabelSetupTesterB)
        Me.groupBox1.Controls.Add(Me.LabelSetupTesterA)
        Me.groupBox1.Controls.Add(Me.LabelSetupTesterType)
        Me.groupBox1.Controls.Add(Me.LabelSetupStatus)
        Me.groupBox1.Controls.Add(Me.LabelSetupMachineNo)
        Me.groupBox1.Controls.Add(Me.label7)
        Me.groupBox1.Controls.Add(Me.label8)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(11, 15)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(650, 175)
        Me.groupBox1.TabIndex = 8
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Setup Record Infomation"
        '
        'LabelSetupProgramName
        '
        Me.LabelSetupProgramName.BackColor = System.Drawing.Color.White
        Me.LabelSetupProgramName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSetupProgramName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTSetupRecordBindingSource, "ProgramName", True))
        Me.LabelSetupProgramName.Location = New System.Drawing.Point(388, 138)
        Me.LabelSetupProgramName.Name = "LabelSetupProgramName"
        Me.LabelSetupProgramName.Size = New System.Drawing.Size(184, 24)
        Me.LabelSetupProgramName.TabIndex = 20
        Me.LabelSetupProgramName.Text = "FU5753FVM A1"
        Me.LabelSetupProgramName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FTSetupRecordBindingSource
        '
        Me.FTSetupRecordBindingSource.DataSource = GetType(MAP_OSFT.FTSetupRecord)
        '
        'LabelSetupTestFlow
        '
        Me.LabelSetupTestFlow.BackColor = System.Drawing.Color.White
        Me.LabelSetupTestFlow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSetupTestFlow.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTSetupRecordBindingSource, "TestFlow", True))
        Me.LabelSetupTestFlow.Location = New System.Drawing.Point(388, 111)
        Me.LabelSetupTestFlow.Name = "LabelSetupTestFlow"
        Me.LabelSetupTestFlow.Size = New System.Drawing.Size(184, 24)
        Me.LabelSetupTestFlow.TabIndex = 19
        Me.LabelSetupTestFlow.Text = "AUTO1"
        Me.LabelSetupTestFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Location = New System.Drawing.Point(286, 144)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(83, 13)
        Me.label17.TabIndex = 18
        Me.label17.Text = "Program Name :"
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Location = New System.Drawing.Point(310, 117)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(59, 13)
        Me.label18.TabIndex = 17
        Me.label18.Text = "Test Flow :"
        '
        'LabelSetupPackage
        '
        Me.LabelSetupPackage.BackColor = System.Drawing.Color.White
        Me.LabelSetupPackage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSetupPackage.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTSetupRecordBindingSource, "PackageName", True))
        Me.LabelSetupPackage.Location = New System.Drawing.Point(388, 84)
        Me.LabelSetupPackage.Name = "LabelSetupPackage"
        Me.LabelSetupPackage.Size = New System.Drawing.Size(184, 24)
        Me.LabelSetupPackage.TabIndex = 16
        Me.LabelSetupPackage.Text = "MSOP8"
        Me.LabelSetupPackage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelSetupFTDevice
        '
        Me.LabelSetupFTDevice.BackColor = System.Drawing.Color.White
        Me.LabelSetupFTDevice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSetupFTDevice.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTSetupRecordBindingSource, "FTDevice", True))
        Me.LabelSetupFTDevice.Location = New System.Drawing.Point(388, 57)
        Me.LabelSetupFTDevice.Name = "LabelSetupFTDevice"
        Me.LabelSetupFTDevice.Size = New System.Drawing.Size(184, 24)
        Me.LabelSetupFTDevice.TabIndex = 15
        Me.LabelSetupFTDevice.Text = "BU5753FVM-E2"
        Me.LabelSetupFTDevice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelSetupLotNo
        '
        Me.LabelSetupLotNo.BackColor = System.Drawing.Color.White
        Me.LabelSetupLotNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSetupLotNo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTSetupRecordBindingSource, "LotNo", True))
        Me.LabelSetupLotNo.Location = New System.Drawing.Point(388, 30)
        Me.LabelSetupLotNo.Name = "LabelSetupLotNo"
        Me.LabelSetupLotNo.Size = New System.Drawing.Size(184, 24)
        Me.LabelSetupLotNo.TabIndex = 14
        Me.LabelSetupLotNo.Text = "1833A4567V"
        Me.LabelSetupLotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelSetupTesterB
        '
        Me.LabelSetupTesterB.BackColor = System.Drawing.Color.White
        Me.LabelSetupTesterB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSetupTesterB.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTSetupRecordBindingSource, "TesterChB", True))
        Me.LabelSetupTesterB.Location = New System.Drawing.Point(161, 138)
        Me.LabelSetupTesterB.Name = "LabelSetupTesterB"
        Me.LabelSetupTesterB.Size = New System.Drawing.Size(100, 24)
        Me.LabelSetupTesterB.TabIndex = 13
        Me.LabelSetupTesterB.Text = "1205 TN"
        Me.LabelSetupTesterB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelSetupTesterA
        '
        Me.LabelSetupTesterA.BackColor = System.Drawing.Color.White
        Me.LabelSetupTesterA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSetupTesterA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTSetupRecordBindingSource, "TesterChA", True))
        Me.LabelSetupTesterA.Location = New System.Drawing.Point(161, 111)
        Me.LabelSetupTesterA.Name = "LabelSetupTesterA"
        Me.LabelSetupTesterA.Size = New System.Drawing.Size(100, 24)
        Me.LabelSetupTesterA.TabIndex = 12
        Me.LabelSetupTesterA.Text = "1234 TN"
        Me.LabelSetupTesterA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelSetupTesterType
        '
        Me.LabelSetupTesterType.BackColor = System.Drawing.Color.White
        Me.LabelSetupTesterType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSetupTesterType.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTSetupRecordBindingSource, "TesterType", True))
        Me.LabelSetupTesterType.Location = New System.Drawing.Point(161, 84)
        Me.LabelSetupTesterType.Name = "LabelSetupTesterType"
        Me.LabelSetupTesterType.Size = New System.Drawing.Size(100, 24)
        Me.LabelSetupTesterType.TabIndex = 11
        Me.LabelSetupTesterType.Text = "ICT1800"
        Me.LabelSetupTesterType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelSetupStatus
        '
        Me.LabelSetupStatus.BackColor = System.Drawing.Color.White
        Me.LabelSetupStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSetupStatus.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTSetupRecordBindingSource, "Status", True))
        Me.LabelSetupStatus.Location = New System.Drawing.Point(161, 57)
        Me.LabelSetupStatus.Name = "LabelSetupStatus"
        Me.LabelSetupStatus.Size = New System.Drawing.Size(100, 24)
        Me.LabelSetupStatus.TabIndex = 10
        Me.LabelSetupStatus.Text = "CONFIRMED"
        Me.LabelSetupStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelSetupMachineNo
        '
        Me.LabelSetupMachineNo.BackColor = System.Drawing.Color.White
        Me.LabelSetupMachineNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSetupMachineNo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTSetupRecordBindingSource, "MCNo", True))
        Me.LabelSetupMachineNo.Location = New System.Drawing.Point(161, 30)
        Me.LabelSetupMachineNo.Name = "LabelSetupMachineNo"
        Me.LabelSetupMachineNo.Size = New System.Drawing.Size(100, 24)
        Me.LabelSetupMachineNo.TabIndex = 9
        Me.LabelSetupMachineNo.Text = "M-005"
        Me.LabelSetupMachineNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(74, 90)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(70, 13)
        Me.label7.TabIndex = 8
        Me.label7.Text = "Tester Type :"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(313, 90)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(56, 13)
        Me.label8.TabIndex = 7
        Me.label8.Text = "Package :"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(322, 63)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(47, 13)
        Me.label6.TabIndex = 5
        Me.label6.Text = "Device :"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(324, 36)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(45, 13)
        Me.label5.TabIndex = 4
        Me.label5.Text = "Lot No :"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(63, 63)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(81, 13)
        Me.label4.TabIndex = 3
        Me.label4.Text = "Confirm Status :"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(91, 144)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(53, 13)
        Me.label3.TabIndex = 2
        Me.label3.Text = "Tester B :"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(91, 117)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(53, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Tester A :"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(76, 36)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(68, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Machine No:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MAP_OSFT.My.Resources.Resources.loading
        Me.PictureBox1.Location = New System.Drawing.Point(11, 318)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 62)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'TestProgramAutoloadingDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 402)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.ButtonStopAll)
        Me.Controls.Add(Me.ButtonStartAll)
        Me.Controls.Add(Me.ButtonStop)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "TestProgramAutoloadingDialog"
        Me.Text = "TestProgramAutoloadingDialog"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.FTSetupRecordBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.testProgramAutoloadingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents label28 As Label
    Private WithEvents testProgramAutoloadingBindingSource As BindingSource
    Private WithEvents groupBox2 As GroupBox
    Private WithEvents LabelCurrentProgramName As Label
    Private WithEvents label10 As Label
    Private WithEvents LabelCurrentTestFlow As Label
    Private WithEvents label22 As Label
    Private WithEvents LabelCurrentPackage As Label
    Private WithEvents LabelCurrentFTDeviceName As Label
    Private WithEvents LabelCurrentLotNo As Label
    Private WithEvents label26 As Label
    Private WithEvents label27 As Label
    Private WithEvents ButtonClose As Button
    Private WithEvents ButtonStopAll As Button
    Private WithEvents ButtonStartAll As Button
    Private WithEvents ButtonStop As Button
    Private WithEvents ButtonStart As Button
    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents LabelSetupProgramName As Label
    Private WithEvents LabelSetupTestFlow As Label
    Private WithEvents label17 As Label
    Private WithEvents label18 As Label
    Private WithEvents LabelSetupPackage As Label
    Private WithEvents LabelSetupFTDevice As Label
    Private WithEvents LabelSetupLotNo As Label
    Private WithEvents LabelSetupTesterB As Label
    Private WithEvents LabelSetupTesterA As Label
    Private WithEvents LabelSetupTesterType As Label
    Private WithEvents LabelSetupStatus As Label
    Private WithEvents LabelSetupMachineNo As Label
    Private WithEvents label7 As Label
    Private WithEvents label8 As Label
    Private WithEvents label6 As Label
    Private WithEvents label5 As Label
    Private WithEvents label4 As Label
    Private WithEvents label3 As Label
    Private WithEvents label2 As Label
    Private WithEvents label1 As Label
    Friend WithEvents FTSetupRecordBindingSource As BindingSource
    Friend WithEvents PictureBox1 As PictureBox
End Class
