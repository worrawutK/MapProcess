Imports Microsoft.VisualBasic.Devices

Public Class SettingComport
    Private Sub CbSelectcomp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbSelectcomp.SelectedIndexChanged

        Try
            ' Dim ComPortNo As String
            My.Settings.Comport = CbSelectcomp.Text.ToString
            My.Settings.Save()
            ' ComPortNo =
            Form1.SerialPort1.PortName = My.Settings.Comport 'CbSelectcomp.Text.ToString
            If Form1.SerialPort1.IsOpen Then
                Form1.SerialPort1.Close()
            End If
            Form1.SerialPort1.Open()
            MsgBox("SelfCon Connection Complete", CType(64, MsgBoxStyle), "Connect SelfCon")
            Me.Close()
        Catch ex As Exception
            MsgBox("Please Select New Comport", CType(48, MsgBoxStyle), "Not Connect")
        End Try

    End Sub
    Private Sub frmSettingComport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CbSelectcomp.Items.Clear()
        Try
            For Each COMName As String In My.Computer.Ports.SerialPortNames
                Try
                    Form1.SerialPort1.PortName = COMName
                    Form1.SerialPort1.Open()
                    Form1.SerialPort1.Close()
                    CbSelectcomp.Items.Add(COMName)
                Catch ex As Exception

                End Try



            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

End Class