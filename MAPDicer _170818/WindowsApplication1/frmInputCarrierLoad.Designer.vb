﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lbClose = New System.Windows.Forms.Label()
        Me.TextBoxCarrierInput = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(136, 193)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(398, 34)
        Me.ProgressBar1.TabIndex = 5
        '
        'lbClose
        '
        Me.lbClose.BackColor = System.Drawing.Color.Transparent
        Me.lbClose.Location = New System.Drawing.Point(522, 9)
        Me.lbClose.Name = "lbClose"
        Me.lbClose.Size = New System.Drawing.Size(47, 45)
        Me.lbClose.TabIndex = 4
        '
        'TextBoxCarrierInput
        '
        Me.TextBoxCarrierInput.Location = New System.Drawing.Point(15, 207)
        Me.TextBoxCarrierInput.Name = "TextBoxCarrierInput"
        Me.TextBoxCarrierInput.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxCarrierInput.TabIndex = 3
        '
        'frmInputCarrierLoad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.MAP_Dicer.My.Resources.Resources.LoadGIF
        Me.ClientSize = New System.Drawing.Size(584, 261)
        Me.ControlBox = False
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.lbClose)
        Me.Controls.Add(Me.TextBoxCarrierInput)
        Me.Name = "frmInputCarrierLoad"
        Me.Text = "frmInputCarrierLoad"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lbClose As Label
    Friend WithEvents TextBoxCarrierInput As TextBox
End Class
