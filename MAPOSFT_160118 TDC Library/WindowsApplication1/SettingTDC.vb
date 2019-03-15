Public Class SettingTDC

    Private Sub btOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOk.Click
        My.Settings.NotFound = cb01.SelectedIndex
        My.Settings.Running = cb02.SelectedIndex
        My.Settings.NotRun = cb03.SelectedIndex
        My.Settings.MachineNotFound = cb04.SelectedIndex
        My.Settings.ErrorLotStatus = cb05.SelectedIndex
        My.Settings.ErrorFlow = cb06.SelectedIndex
        My.Settings.ErrorConnectDatabase = cb70.SelectedIndex
        My.Settings.ErrorReadDatabase = cb71.SelectedIndex
        My.Settings.ErrorWriteDatabase = cb72.SelectedIndex
        My.Settings.ErrorOther = cb99.SelectedIndex
        My.Settings.RunOffline = cbRunOffline.SelectedIndex
        My.Settings.Save()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub SettingTDC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cb01.SelectedIndex = My.Settings.NotFound
        cb02.SelectedIndex = My.Settings.Running
        cb03.SelectedIndex = My.Settings.NotRun
        cb04.SelectedIndex = My.Settings.MachineNotFound
        cb05.SelectedIndex = My.Settings.ErrorLotStatus
        cb06.SelectedIndex = My.Settings.ErrorFlow
        cb70.SelectedIndex = My.Settings.ErrorConnectDatabase
        cb71.SelectedIndex = My.Settings.ErrorReadDatabase
        cb72.SelectedIndex = My.Settings.ErrorWriteDatabase
        cb99.SelectedIndex = My.Settings.ErrorOther
        cbRunOffline.SelectedIndex = My.Settings.RunOffline
    End Sub
End Class