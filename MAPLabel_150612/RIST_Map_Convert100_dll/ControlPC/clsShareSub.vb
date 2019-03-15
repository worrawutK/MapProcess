Imports System.IO
Imports Microsoft.VisualBasic
Imports MapConvert.clsFileOpe

Public Class clsShareSub

    Const HEADER As String = "clsShareSub"
    Friend Shared Langtran As LanguageTranslationClass

    ''ロット検索
    'Public Shared Sub LOTSerchToolStripMenu()
    '    Dim frmLotSerch As New FormProgress
    '    frmLotSerch.TopMost = True
    '    frmLotSerch.ShowDialog()
    '    frmLotSerch.Dispose()
    'End Sub

    ''Strip ロット検索
    'Public Shared Sub StripSerchToolStripMenu()
    '    Dim frmStripSerch As New FormStripProgress
    '    frmStripSerch.TopMost = True
    '    frmStripSerch.ShowDialog()
    '    frmStripSerch.Dispose()
    'End Sub

    ''FLOW Delete
    'Public Shared Sub FlowDeleteToolStripMenu(ByVal strOperatorName As String)
    '    Dim frmFlowDelete As New FormFlowDelete
    '    frmFlowDelete.LblOperatorName.Text = strOperatorName
    '    frmFlowDelete.TopMost = True
    '    frmFlowDelete.ShowDialog()
    '    frmFlowDelete.Dispose()
    'End Sub

    ''Device Data 登録
    'Public Shared Sub DevicedataToolStripMenu()
    '    Dim frmDeviceData As New FormDevice
    '    frmDeviceData.TopMost = True
    '    frmDeviceData.ShowDialog()
    '    frmDeviceData.Dispose()
    'End Sub

    ' ''Monitor
    ''Public Shared Sub MonitorToolStripMenu()
    ''    Dim frmMonitor As New Form_Monitor
    ''    frmMonitor.TopMost = True
    ''    frmMonitor.ShowDialog()
    ''    frmMonitor.Dispose()
    ''End Sub

    ''装置登録
    'Public Shared Sub MachineRegistrationToolStripMenu()
    '    Dim frmMac As New FormMachine
    '    frmMac.Text = "Machine Registration"
    '    frmMac.Label1.Text = "Machine"
    '    frmMac.Label3.Text = "Group"
    '    frmMac.Label4.Text = "Control PC"
    '    frmMac.Label2.Text = "Tester"
    '    frmMac.Label5.Text = "Position"
    '    frmMac.Label6.Text = "Destination"
    '    frmMac.Registration_Bt.Text = "Registration"
    '    frmMac.Cancel_Bt.Text = "Cancel"
    '    frmMac.Delete_Bt.Text = "Delete"
    '    frmMac.Display_Bt.Text = "Display"
    '    frmMac.TopMost = True
    '    frmMac.ShowDialog()
    '    frmMac.Dispose()
    'End Sub

    ''オペレータ登録
    'Public Shared Sub OperatorRegistrationToolStripMenu()
    '    Dim frmOpe As New FormOperator
    '    frmOpe.Text = "Operator Registration"
    '    frmOpe.Label1.Text = "Number"
    '    frmOpe.Label2.Text = "Name"
    '    frmOpe.Registration_Bt.Text = "Registration"
    '    frmOpe.Cancel_Bt.Text = "Cancel"
    '    frmOpe.Delete_Bt.Text = "Delete"
    '    frmOpe.Display_Bt.Text = "Display"
    '    frmOpe.TopMost = True
    '    frmOpe.ShowDialog()
    '    frmOpe.Dispose()
    'End Sub

    ''オペレータパスワード
    'Public Shared Function OperatorPassWord(ByVal strLebel As String) As String
    '    Dim frmOpe2 As New FormOperator2
    '    frmOpe2.Text = "Operator"
    '    frmOpe2.Label1.Text = "Operator"
    '    frmOpe2.TopMost = True
    '    frmOpe2.ShowDialog()
    '    frmOpe2.Dispose()
    '    If strLebel = "1" Then
    '        If frmOpe2.AcceptedUser() = "Admin" Or frmOpe2.AcceptedUser() = "GLeader" Or frmOpe2.AcceptedUser() = "Operator" Then
    '            Return frmOpe2.AcceptedUserName()
    '        Else
    '            Return "Error"
    '        End If
    '    Else
    '        If frmOpe2.AcceptedUser() = "Admin" Or frmOpe2.AcceptedUser() = "GLeader" Then
    '            Return frmOpe2.AcceptedUserName()
    '        Else
    '            Return "Error"
    '        End If
    '    End If
    'End Function

    ''ＦＤＤモード切替
    'Public Shared Sub FDDPathToolStripMenu()
    '    Dim frmPath As New FormFDDMode
    '    If StrUseFdd = "1" Then
    '        frmPath.CheckBox1.Checked = True
    '        frmPath.TBoxPath.Enabled = True
    '    Else
    '        frmPath.CheckBox1.Checked = False
    '        frmPath.TBoxPath.Enabled = False
    '    End If
    '    frmPath.ShowDialog()
    '    If frmPath.CheckBox1.Checked = True Then
    '        appConfigValueSet("USE_FDD", "1")
    '        StrUseFdd = "1"
    '    Else
    '        appConfigValueSet("USE_FDD", "0")
    '        StrUseFdd = "0"
    '    End If
    '    If StrFDDPath <> frmPath.TBoxPath.Text Then
    '        StrFDDPath = frmPath.TBoxPath.Text
    '        appConfigValueSet("FDD_PATH", StrFDDPath)
    '    End If
    '    frmPath.Dispose()
    'End Sub

    'ＭＡＰ ＵｐＬｏａｄ/ＤｏｗｎＬｏａｄ
    'Public Shared Sub MapDLULToolStripMenu(ByVal strOperatorName As String)
    '    Dim frmMapDLUL As New FormMapDLUL
    '    frmMapDLUL.Text = "Map DownLoad/UpLoad"
    '    frmMapDLUL.Label1.Text = "Operator"
    '    frmMapDLUL.TBoxOperator.Text = strOperatorName
    '    frmMapDLUL.Label2.Text = "Assy LotNo"
    '    frmMapDLUL.Bt_DownLoad.Text = "DownLoad"
    '    frmMapDLUL.Bt_UpLoad.Text = "UpLoad"
    '    frmMapDLUL.TopMost = True
    '    frmMapDLUL.ShowDialog()
    '    frmMapDLUL.Dispose()
    'End Sub

    ''ＭＡＰ Ｉｎｐｕｔ
    'Public Shared Sub MapInputToolStripMenu(ByVal strOperatorName As String)
    '    Dim frmMapInput As New FormMapInput
    '    frmMapInput.Text = "Map Input"
    '    frmMapInput.Text = "Operator"
    '    frmMapInput.TBoxOperator.Text = strOperatorName
    '    frmMapInput.Label2.Text = "Assy LotNo"
    '    frmMapInput.Bt_Input.Text = "Input"
    '    frmMapInput.TopMost = True
    '    frmMapInput.ShowDialog()
    '    frmMapInput.Dispose()
    'End Sub

    ''Version情報表示
    'Public Shared Sub VersionToolStripMenu()
    '    Dim frmVersion As New FormVersion
    '    frmVersion.TopMost = True
    '    frmVersion.ShowDialog()
    '    frmVersion.Dispose()
    'End Sub

    ''装置名チェック
    'Public Shared Function ChkMachineName(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                      ByVal strControlPC As String, ByVal strMachineName As String, ByVal strMode As String) As String
    '    'return value 
    '    'Machine Name CSV : no error
    '    '"other": fail

    '    Dim strErrSig As String = "[" & StrControlPC & "]"
    '    Dim dtNow = Now
    '    Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    '    Dim ans As String = ""

    '    Try
    '        Dim DB As New clsDBMachine(connect, transact)
    '        If strMode = "0" Then   '同じControlPCのマシン名をすべて検出
    '            DB.setValue(clsDBMachine.keys.MachineName, "%", "%")
    '            DB.setValue(clsDBMachine.allcolumns.ControlPC, strControlPC, "=")
    '        Else                    'CBOXMachineに表示しているのマシン名を検出
    '            DB.setValue(clsDBMachine.keys.MachineName, strMachineName, "=")
    '            DB.setValue(clsDBMachine.allcolumns.ControlPC, strControlPC, "=")
    '        End If
    '        ans = DB.DBselectItem("ControlPC")
    '        If ans Like "Error*" Then
    '            If ans <> "Error: No Record Found" Then  'Machine name なし
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/ChkMachineName/Don'tMakeMachineList[" & StrControlPC & "]:" & ans, HEADER)
    '                Return "Error:Don't Make MachineList[" & StrControlPC & "]"
    '            Else
    '                Return "Error: No Record Found" 'Machine name なし
    '            End If
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/ChkMachineName", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/ChkMachineName"
    '    End Try
    '    Return ans
    'End Function

    ''オペレータＮＯ　⇒ オペレータ名
    'Public Shared Function OperatorNameDisp(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                        ByVal strInOperatorNo As String) As String
    '    'return value 
    '    '"Operetor Name": no error
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strInOperatorNo & "]"
    '    Dim dtNow = Now
    '    Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    '    Dim ans As String = ""
    '    Dim DB As New clsDBOperator(connect, transact)

    '    Try
    '        DB.setValue(clsDBOperator.keys.Number, strInOperatorNo, "=")
    '        DB.setValue(clsDBOperator.allcolumns.Name, "", "")
    '        ans = DB.DBselect()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/OperatorNameDisp/NoRegistrationOperator[" & strInOperatorNo & "]:" & ans, HEADER)
    '            Return "Error:No Registration Operator[" & strInOperatorNo & "]"
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/OperatorNameDisp", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/OperatorNameDisp"
    '    End Try
    '    Return DB.getValue(clsDBOperator.allcolumns.Name)
    'End Function

    ''装置名取得
    'Public Shared Function GetMachineName(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                      ByVal strControlPC As String, ByVal strPosition As String) As String
    '    'return value 
    '    '"Machine Name": no error
    '    '"False": No Record Found
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strControlPC & "/" & strPosition & "]"
    '    Dim ans As String = ""
    '    Dim DB As New clsDBMachine(connect, transact)

    '    Try
    '        DB.setValue(clsDBMachine.allcolumns.ControlPC, strControlPC, "=")
    '        DB.setValue(clsDBMachine.allcolumns.Position, strPosition, "=")
    '        DB.setValue(clsDBMachine.allcolumns.MachineName, "", "")
    '        DB.setValue(clsDBMachine.allcolumns.Destnation, "", "")
    '        DB.setValue(clsDBMachine.allcolumns.TesterName, "", "")
    '        ans = DB.DBselect()
    '        If ans Like "Error*" Then
    '            If ans = "Error: No Record Found" Then  'DATA なし
    '                Return "False"
    '            Else
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/GetMachineName/CanNotCheckControlPC:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check ControlPC."
    '            End If
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/GetMachineName", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/GetMachineName"
    '    End Try
    '    Return DB.getValue(clsDBMachine.allcolumns.MachineName) & "," & DB.getValue(clsDBMachine.allcolumns.Destnation) & "," & DB.getValue(clsDBMachine.allcolumns.TesterName)
    'End Function

    ''プロセス名取得
    'Public Shared Function GetProcessName(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                      ByVal strAssyLotNo As String) As String
    '    'return value 
    '    'Process Name : True
    '    '"False": No Record Found
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strAssyLotNo & "]"
    '    Dim ans As String = ""
    '    Dim DB As New clsDBNfdMap(connect, transact)

    '    Try
    '        DB.setValue(clsDBNfdMap.keys.LotID, strAssyLotNo, "=")
    '        DB.setValue(clsDBNfdMap.allcolumns.Process, "", "")
    '        ans = DB.DBselect()
    '        If ans Like "Error*" Then
    '            If ans = "Error: No Record Found" Then  'DATA なし
    '                Return "False"
    '            Else
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/GetProcessName/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/GetProcessName", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/GetProcessName"
    '    End Try
    '    Return DB.getValue(clsDBNfdMap.allcolumns.Process)
    'End Function

    ''Machine NO の工程を取得(Netfd)
    'Public Shared Function GetLotNoProcess(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                       ByVal strMachineName As String) As String
    '    'return value 
    '    '"AssyLotNo","Process" : no error
    '    '"False": No Record Found
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strMachineName & "]"
    '    Dim ans As String = ""
    '    Dim DB As New clsDBNfdMap(connect, transact)

    '    Try
    '        DB.setValue(clsDBNfdMap.allcolumns.MapStatus, strMachineName, "=")
    '        DB.setValue(clsDBNfdMap.allcolumns.LotID, "", "")
    '        DB.setValue(clsDBNfdMap.allcolumns.Process, "", "")
    '        ans = DB.DBselect()
    '        If ans Like "Error*" Then
    '            If ans = "Error: No Record Found" Then  '同じLotNoのMAP DATA なし
    '                Return "False"
    '            Else
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/GetLotNoProcess/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/GetLotNoProcess", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/GetLotNoProcess"
    '    End Try
    '    Return DB.getValue(clsDBNfdMap.allcolumns.LotID) & "," & DB.getValue(clsDBNfdMap.allcolumns.Process)
    'End Function

    ''Machine Noの LotNo Progress を取得(Progress)
    'Public Shared Function GetLotNoProgress(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                        ByVal strMachineName As String) As String
    '    'return value 
    '    '"AssyLotNo","WfLotNo","Device","Package","FlowName","Progress","Program","Tester","StartPass","StartTime": no error
    '    '"False": No Record Found
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strMachineName & "]"
    '    Dim ans As String = ""
    '    Dim strFD As String = ""
    '    Dim DB2 As New clsDBProgress(connect, transact)

    '    Try
    '        DB2.setValue(clsDBProgress.keys.LotID, "%", "%")
    '        DB2.setValue(clsDBProgress.keys.FlowNo, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.Machine, strMachineName, "=")
    '        DB2.setValue(clsDBProgress.allcolumns.Progress, "OnGoing", "=")
    '        DB2.setValue(clsDBProgress.allcolumns.AssyLotNo, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.WfLotNo, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.Device, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.Package, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.FlowName, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.Program, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.Tester, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.StartPass, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.StartTime, "", "")
    '        ans = DB2.DBselect()
    '        If ans Like "Error*" Then
    '            If ans <> "Error: No Record Found" Then  '同じLotNoのProgress なし
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/GetLotNoProgress/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '            DB2.setValue(clsDBProgress.keys.LotID, "%", "%")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.Machine, strMachineName, "=")
    '            DB2.setValue(clsDBProgress.allcolumns.Progress, "OnGoingFD", "=")
    '            DB2.setValue(clsDBProgress.allcolumns.AssyLotNo, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.WfLotNo, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.Device, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.Package, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.FlowName, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.Program, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.Tester, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.StartPass, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.StartTime, "", "")
    '            ans = DB2.DBselect()
    '            If ans Like "Error*" Then
    '                If ans <> "Error: No Record Found" Then  '同じLotNoのProgress なし
    '                    clsErrorLog.addlogWT("Error:" & HEADER & "/GetLotNoProgress/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                    Return "Error:Can Not Check AssyLotNo."
    '                Else
    '                    Return "False"
    '                End If
    '            End If
    '            strFD = "(USEFD)"
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/GetLotNoProgress", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/GetLotNoProgress"
    '    End Try
    '    Return DB2.getValue(clsDBProgress.allcolumns.AssyLotNo) & "," & DB2.getValue(clsDBProgress.allcolumns.WfLotNo) & "," & _
    '           DB2.getValue(clsDBProgress.allcolumns.Device) & "," & DB2.getValue(clsDBProgress.allcolumns.Package) & "," & _
    '           DB2.getValue(clsDBProgress.allcolumns.FlowName) & strFD & "," & DB2.getValue(clsDBProgress.allcolumns.Progress) & "," & _
    '           DB2.getValue(clsDBProgress.allcolumns.Program) & "," & DB2.getValue(clsDBProgress.allcolumns.Tester) & "," & _
    '           DB2.getValue(clsDBProgress.allcolumns.StartPass) & "," & DB2.getValue(clsDBProgress.allcolumns.StartTime) & "," & _
    '           DB2.getValue(clsDBProgress.allcolumns.FlowNo)
    'End Function

    ''LotNoの LotNo Progress を取得(Progress)
    'Public Shared Function GetAssyLotNoProgress(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                            ByVal strAssyLotNo As String) As String
    '    'return value 
    '    '"AssyLotNo","WfLotNo","Device","Package","FlowName","Progress","Program","Tester": no error
    '    '"False": No Record Found
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strAssyLotNo & "]"
    '    Dim ans As String = ""
    '    Dim strFD As String = ""
    '    Dim DB2 As New clsDBProgress(connect, transact)

    '    Try
    '        DB2.setValue(clsDBProgress.keys.LotID, strAssyLotNo, "=")
    '        DB2.setValue(clsDBProgress.keys.FlowNo, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.Progress, "OnGoing", "=")
    '        DB2.setValue(clsDBProgress.allcolumns.AssyLotNo, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.WfLotNo, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.Device, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.Package, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.FlowName, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.Program, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.Tester, "", "")
    '        ans = DB2.DBselect()
    '        If ans Like "Error*" Then
    '            If ans <> "Error: No Record Found" Then  '同じLotNoのProgress なし
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/GetAssyLotNoProgress/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '            DB2.setValue(clsDBProgress.keys.LotID, strAssyLotNo, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.Progress, "OnGoingFD", "=")
    '            DB2.setValue(clsDBProgress.allcolumns.AssyLotNo, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.WfLotNo, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.Device, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.Package, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.FlowName, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.Program, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.Tester, "", "")
    '            ans = DB2.DBselect()
    '            If ans Like "Error*" Then
    '                If ans <> "Error: No Record Found" Then  '同じLotNoのProgress なし
    '                    clsErrorLog.addlogWT("Error:" & HEADER & "/GetAssyLotNoProgress/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                    Return "Error:Can Not Check AssyLotNo."
    '                Else
    '                    Return "False"
    '                End If
    '            End If
    '            strFD = "(USEFD)"
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/GetAssyLotNoProgress", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/GetAssyLotNoProgress"
    '    End Try
    '    Return DB2.getValue(clsDBProgress.allcolumns.AssyLotNo) & "," & DB2.getValue(clsDBProgress.allcolumns.WfLotNo) & "," & _
    '           DB2.getValue(clsDBProgress.allcolumns.Device) & "," & DB2.getValue(clsDBProgress.allcolumns.Package) & "," & _
    '           DB2.getValue(clsDBProgress.allcolumns.FlowName) & strFD & "," & DB2.getValue(clsDBProgress.allcolumns.Progress) & "," & _
    '           DB2.getValue(clsDBProgress.allcolumns.Program) & "," & DB2.getValue(clsDBProgress.allcolumns.Tester)
    'End Function

    ''LotNoの  Status取得
    'Public Shared Function GetStatus(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                 ByVal strAssyLotNo As String) As String
    '    'return value 
    '    '"MapStatus" : no error
    '    '"False": No Record Found
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strAssyLotNo & "]"
    '    Dim ans As String = ""
    '    Dim DB As New clsDBMap_MapData(connect, transact)

    '    Try
    '        DB.setValue(clsDBMap_MapData.keys.LotNo, strAssyLotNo, "=")
    '        DB.setValue(clsDBMap_MapData.allcolumns.MapStatus, "", "")
    '        ans = DB.DBselect()
    '        If ans Like "Error*" Then
    '            If ans = "Error: No Record Found" Then  '
    '                Return "False"
    '            Else
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/GetStatus/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/GetStatus", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/GetStatus"
    '    End Try
    '    Return DB.getValue(clsDBMap_MapData.allcolumns.MapStatus)
    'End Function

    'Assy LotNo有無取得
    Public Shared Function ChkAssyLotNo(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
                                     ByVal strAssyLotNo As String) As String
        'return value
        '"True": no error 
        '"other": fail

        Dim strErrSig As String = "[" & strAssyLotNo & "]"
        Dim ans As String = ""
        Dim DB As New clsDBStripMap(connect, transact)

        Try
            DB.setValue(clsDBStripMap.allcolumns.AssyLotNo, strAssyLotNo, "=")
            ans = DB.DBselect()
            If ans Like "Error*" Then
                If ans = "Error: No Record Found" Then  '
                    Return "Error: No Record Found"
                Else
                    clsErrorLog.addlogWT("Error:" & HEADER & "/ChkAssyLotNo/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
                    Return "Error:Can Not Check AssyLotNo."
                End If
            End If

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/ChkAssyLotNo", HEADER)
            Return "Error:" & ex.ToString & "," & HEADER & "/ChkAssyLotNo"
        End Try
        Return "True"
    End Function

    'Ase StripID有無取得
    Public Shared Function ChkASEStripID(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
                                     ByVal strAseStripID As String) As String
        'return value
        '"True": no error 
        '"other": fail

        Dim strErrSig As String = "[" & strAseStripID & "]"
        Dim ans As String = ""
        Dim DB As New clsDBStripMap(connect, transact)

        Try
            DB.setValue(clsDBStripMap.keys.StripID, strAseStripID, "=")
            ans = DB.DBselect()
            If ans Like "Error*" Then
                If ans = "Error: No Record Found" Then  '
                    Return "Error: No Record Found"
                Else
                    clsErrorLog.addlogWT("Error:" & HEADER & "/ChkASEStripID/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
                    Return "Error:Can Not Check AssyLotNo."
                End If
            End If

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/ChkASEStripID", HEADER)
            Return "Error:" & ex.ToString & "," & HEADER & "/ChkASEStripID"
        End Try
        Return "True"
    End Function


    ''前工程のフロー確認(直前のフロー名を返す)
    'Public Shared Function BeforFlowCheck(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                      ByVal strLotID As String) As String
    '    'return value 
    '    '"FlowName","Process" : no error
    '    '"other": fail

    '    Dim ans As String = ""
    '    Dim i As Integer
    '    Dim strTmp As String = ""
    '    Dim strFlowName As String = ""
    '    Dim strProcess As String = ""
    '    Dim DB2 As New clsDBProgress(connect, transact)

    '    Try
    '        For i = 1 To MAXFLOW
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            DB2.setValue(clsDBProgress.allcolumns.FlowName, "", "")
    '            DB2.setValue(clsDBProgress.allcolumns.Progress, "", "")
    '            ans = DB2.DBselect()
    '            If ans = "Error: No Record Found" Then
    '                Exit For
    '            End If
    '            If ans Like "Error*" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/BeforFlowCheck/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '            strTmp = DB2.getValue(clsDBProgress.allcolumns.FlowName)
    '            If strTmp <> "DownLoad" Then
    '                strFlowName = strTmp
    '                strProcess = DB2.getValue(clsDBProgress.allcolumns.Progress)
    '            End If
    '            System.Windows.Forms.Application.DoEvents()
    '        Next
    '        If i = 1 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/BeforFlowCheck/NoInput", HEADER) 'ERROR
    '            Return "Error: No Input"
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/BeforFlowCheck", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/BeforFlowCheck"
    '    End Try
    '    Return strFlowName & "," & strProcess
    'End Function

    ''FD使用確認
    'Public Shared Function BeforUseFDCheck(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                       ByVal strLotID As String) As String
    '    'return value 
    '    '"Process" : no error
    '    '"other": fail

    '    Dim ans As String = ""
    '    Dim i As Integer
    '    Dim strProgress As String = ""
    '    Dim DB2 As New clsDBProgress(connect, transact)

    '    Try
    '        For i = 1 To MAXFLOW
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            DB2.setValue(clsDBProgress.allcolumns.Progress, "", "")
    '            ans = DB2.DBselect()
    '            If ans = "Error: No Record Found" Then
    '                Exit For
    '            End If
    '            If ans Like "Error*" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/BeforUseFDCheck/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '            strProgress = DB2.getValue(clsDBProgress.allcolumns.Progress)
    '        Next
    '        If i = 1 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/BeforUseFDCheck/IllegalFlowNo:" & ans, HEADER) 'ERROR
    '            Return "Error:Illegal FlowNo."
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/BeforUseFDCheck", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/BeforUseFDCheck"
    '    End Try
    '    Return strProgress
    'End Function

    ''Lot.DATを作りなおす(Input時使用)
    'Public Shared Function MakeLotDat(ByVal strSourceFolder As String, ByVal strWfLotNo As String)
    '    'return value 
    '    '"True" : no error
    '    '"other": fail

    '    Dim strCs As String()
    '    Dim arCw As New ArrayList
    '    Dim strC As String
    '    Dim strWano As String
    '    Dim intwacount As Integer
    '    Dim waferlist As String = "0000000000000000000000000"
    '    Dim bytOpenfile() As Byte
    '    Dim strVarInput As String = ""
    '    Dim strVarInput2 As String = ""
    '    Dim intInAddress As Integer
    '    Dim intI As Integer
    '    Dim bytInput As Byte
    '    Dim ex2mode As Boolean
    '    Dim lngPass As Integer
    '    Dim lngFail As Integer
    '    Dim lngPassTotal As Integer
    '    Dim lngFailTotal As Integer
    '    Dim lotNo As String
    '    Dim intwaNo As Integer
    '    Dim waferInch
    '    Dim ans As String = ""

    '    Try
    '        If Not System.IO.File.Exists(strSourceFolder & "\LOT.DAT") Then Throw New System.Exception

    '        bytOpenfile = My.Computer.FileSystem.ReadAllBytes(strSourceFolder & "\LOT.DAT")

    '        strVarInput = ""
    '        For intI = 1 To 20
    '            myFileGet(bytOpenfile, bytInput, intI)
    '            strVarInput = strVarInput + Chr(bytInput)
    '        Next intI
    '        strVarInput = strVarInput.Replace(Chr(0), "")
    '        lotNo = Trim(strVarInput)
    '        If lotNo Like strWfLotNo & "?" Or lotNo Like "M" & strWfLotNo & "?" Or lotNo Like "M" & strWfLotNo Or lotNo = strWfLotNo Then
    '            lotNo = strWfLotNo
    '        Else
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/MakeLotDat/DiffrentLotNo", HEADER)
    '            Return "Error:Different wfLotNo"
    '        End If
    '        strVarInput = Space(1)
    '        intInAddress = 138 + 12 + 1
    '        myFileGet(bytOpenfile, strVarInput, intInAddress)
    '        If strVarInput = "C" Then
    '            waferInch = 12
    '        Else
    '            waferInch = CInt(strVarInput)
    '        End If

    '        strVarInput = Space(5)
    '        intInAddress = 138 + 16 + 1
    '        myFileGet(bytOpenfile, strVarInput, intInAddress)
    '        Dim intXchip As Integer = CInt(strVarInput.Trim)

    '        strVarInput = Space(5)
    '        intInAddress = 138 + 21 + 1
    '        myFileGet(bytOpenfile, strVarInput, intInAddress)
    '        Dim intYchip As Integer = CInt(strVarInput.Trim)

    '        ex2mode = IsMapSizeEx2(intXchip, intYchip, waferInch)

    '        strCs = System.IO.Directory.GetFiles(strSourceFolder, "w-no-??.dat")

    '        For Each strC In strCs
    '            strWano = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(strC, 6), 2)
    '            If strWano Like "##" Then
    '                lngPass = 0
    '                lngFail = 0
    '                intwaNo = Val(strWano)
    '                Mid(waferlist, 26 - Val(strWano), 1) = "1"
    '                intwacount = intwacount + 1
    '                If Not System.IO.File.Exists(strSourceFolder & "\w-no-" & strWano & ".dat") Then Throw New System.Exception
    '                bytOpenfile = My.Computer.FileSystem.ReadAllBytes(strSourceFolder & "\w-no-" & strWano & ".dat")
    '                If ex2mode = True Then
    '                    For intI = 1 To 3
    '                        lngPass = lngPass * 256
    '                        lngFail = lngFail * 256
    '                        intInAddress = 6 + 1 + 2 + 1 - intI
    '                        myFileGet(bytOpenfile, bytInput, intInAddress)
    '                        lngPass = lngPass + bytInput
    '                        intInAddress = intInAddress + 3
    '                        myFileGet(bytOpenfile, bytInput, intInAddress)
    '                        lngFail = lngFail + bytInput
    '                    Next intI
    '                Else
    '                    For intI = 1 To 2
    '                        lngPass = lngPass * 256
    '                        lngFail = lngFail * 256
    '                        intInAddress = 6 + 1 + 2 - intI
    '                        myFileGet(bytOpenfile, bytInput, intInAddress)
    '                        lngPass = lngPass + bytInput
    '                        intInAddress = intInAddress + 2
    '                        myFileGet(bytOpenfile, bytInput, intInAddress)
    '                        lngFail = lngFail + bytInput
    '                    Next intI
    '                End If
    '                lngPassTotal += lngPass
    '                lngFailTotal += lngFail
    '            End If
    '        Next
    '        If intwacount = 0 Then
    '            Throw New System.Exception(Langtran.tranword("w-no-**.datファイルがひとつもありません。DISKが壊れていないか確認してください"))
    '            Return "Error"
    '        End If

    '        ans = MapData.overwriteLotDatwithLotNo(strSourceFolder & "\LOT.DAT", lotNo, waferlist, lngPassTotal, lngFailTotal)
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/MakeLotDat/CanNotMakeLotDat", HEADER)
    '            Return "Error:Can Not Make LOT.DAT"
    '        End If

    '    Catch ex As System.Threading.ThreadAbortException
    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/MakeLotDat", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/MakeLotDat"
    '    End Try
    '    Return "True"
    'End Function

    ''使用しているWfをチェックする。
    'Public Shared Function ChkUseWf(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                       ByVal strWfLotNo As String, ByVal strUseWfHex As String, ByVal dtNow As DateTime, ByVal strInOperator As String) As String
    '    'return value 
    '    '"True" : no error
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strWfLotNo & "/" & strUseWfHex & "]:" & strInOperator
    '    Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    '    Dim ans As String = ""

    '    Try
    '        If clsWaHexConverter.HexValidFormat(strUseWfHex) = False Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/ChkUseWf[" & strUseWfHex & "]/HexNotValidFormat:" & strErrSig, HEADER)
    '            Return "Error:Hex Not Valid Format."
    '        End If
    '        Dim strUseWfBin As String = clsWaHexConverter.HexToBin(strUseWfHex)
    '        Dim DB As New clsDBNfdMap(connect, transact)
    '        DB.setValue(clsDBNfdMap.keys.LotID, "%", "%")
    '        DB.setValue(clsDBNfdMap.allcolumns.LotNo, strWfLotNo, "=")
    '        ans = DB.DBselectItem("wf")
    '        If ans Like "Error*" Then
    '            If ans = "Error: No Record Found" Then  '同じLotNoのMAP DATA なし
    '                Return "True"
    '            Else
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/ChkUseWf/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '        Else
    '            Dim a() As String
    '            a = ans.Split(",")
    '            Dim lotid(a.Length / 2 - 1) As String
    '            Dim wf(a.Length / 2 - 1) As String
    '            For i As Integer = 0 To lotid.Length - 1
    '                lotid(i) = a(i * 2)
    '                wf(i) = a(i * 2 + 1)
    '            Next
    '            Dim tempWfBin As String
    '            Dim useWfBin As String = "0000000000000000000000000"
    '            Dim j As Integer
    '            For f As Integer = 0 To lotid.Length - 1
    '                tempWfBin = ""
    '                For j = 0 To 24
    '                    If clsWaHexConverter.HexToBin(wf(f)).Substring(j, 1) = "1" _
    '                       Or useWfBin.Substring(j, 1) = "1" Then
    '                        tempWfBin += "1"
    '                    Else
    '                        tempWfBin += "0"
    '                    End If
    '                Next
    '                useWfBin = tempWfBin
    '            Next

    '            Dim chkUseWfNo As String = ""
    '            For j = 0 To 24
    '                If strUseWfBin.Substring(j, 1) = "1" And useWfBin.Substring(j, 1) = "1" Then
    '                    chkUseWfNo += "1"
    '                Else
    '                    chkUseWfNo += "0"
    '                End If
    '            Next
    '            For j = 0 To 24
    '                If chkUseWfNo.Substring(j, 1) = "1" Then
    '                    clsErrorLog.addlogWT("Error:" & HEADER & "/ChkUseWf/AlreadyUseWf:[" & chkUseWfNo & "]", HEADER) 'ERROR
    '                    Return "Error:Already Use Wf:[" & chkUseWfNo & "]"
    '                End If
    '            Next
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/ChkUseWf", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/ChkUseWf"
    '    End Try
    '    Return "True"
    'End Function

    ''ＭＡＰサーバーにＭＡＰを登録する。(Input時)
    'Public Shared Function SetLot(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                       ByVal strLotID As String, ByVal strLotNo As String, ByVal strWfHex As String, ByVal strMapStatus As String, _
    '                       ByVal strProcess As String, ByVal strDevice As String, ByVal strPackage As String, ByVal dtNow As DateTime, _
    '                       ByVal strInOperator As String) As String
    '    'return value 
    '    '"Device","AssyLotNo","FlowNo","FlowName","Progress","Program","Machine","Tester","StartTime","EndTime","StartOp","EndOp","StartPass","EndPass": no error
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strLotID & "/" & strLotNo & "]:" & strInOperator
    '    Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    '    Dim strText As String = ""
    '    Dim ans As String = ""
    '    Dim strInUseFolder As String = Nfd_mappath_root("NFD_PATH") & "\" & strMapStatus
    '    Dim strPass As String = ""

    '    Try
    '        Dim DB As New clsDBNfdMap(connect, transact)
    '        DB.setValue(clsDBNfdMap.keys.LotID, strLotID, "=")
    '        ans = DB.DBselect()
    '        If ans = "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/AlreadyUseAssyLotNo:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Already Use AssyLotNo."
    '        End If
    '        If ans <> "Error: No Record Found" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/CanNotCheck:" & ans, HEADER)
    '            Return "Error:Can Not Check."
    '        End If

    '        Dim PathZipFolder As String = Temp_mappath_root() & "\NFD"
    '        Dim PathZipFile As String = PathZipFolder & "\" & strLotID & ".zip"

    '        If System.IO.Directory.Exists(PathZipFolder) Then
    '            deleteFolderAll(PathZipFolder)
    '            If System.IO.Directory.Exists(PathZipFolder) Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/CanNotDeleteZipFolder:" & strErrSig, HEADER)
    '                Return "Error:Can Not Delete ZipFolder."
    '            End If
    '        End If
    '        createFolder(PathZipFolder)
    '        If System.IO.Directory.GetFiles(PathZipFolder).Length > 0 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/AlreadyExistZipFolder:" & strErrSig, HEADER)
    '            Return "Error:Already Exist ZipFolder."
    '        End If

    '        If Not zipFiles(strInUseFolder, PathZipFile) Then
    '            deleteFile(PathZipFile)
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/CanNotzipFile:" & strErrSig, HEADER)
    '            Return "Error:Can Not zipFile."
    '        End If

    '        '   ロットデータの整合性チェック（共通）         
    '        Dim mapclass As clsMapData = clsMapDataValidateCheck.getMapdata(PathZipFile)
    '        If mapclass Is Nothing Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/CanNotReadMapdata[" & strInUseFolder & "]:" & strErrSig, HEADER)
    '            If Not unzipFiles(PathZipFile, strInUseFolder) Then
    '                deleteFile(PathZipFile)
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/CanNotUnzipFile:" & strErrSig, HEADER)
    '                Return "Error:Can Not UnzipFile."
    '            End If
    '            Return "Error:Can Not Read Mapdata[" & strInUseFolder & "]"
    '        End If
    '        If mapclass.LotNo.ToUpper <> strLotNo.ToUpper Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/WfLotNoMismatch[map:" & mapclass.LotNo & "]:" & strErrSig, HEADER)
    '            If Not unzipFiles(PathZipFile, strInUseFolder) Then
    '                deleteFile(PathZipFile)
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/CanNotUnzipFile:" & strErrSig, HEADER)
    '                Return "Error:Can Not UnzipFile."
    '            End If
    '            Return "Error:Wf LotNo Mismatch[map:" & mapclass.LotNo & "]"
    '        End If

    '        strErrSig = "[" & strLotID & "/" & strLotNo & "]to[ SetMap]:" & strInOperator

    '        '   ＭＡＰデータ BackUp
    '        ans = BackUpLot(strLotID, strProcess, PathZipFolder, dtNow, strInOperator)
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/CanNotBackUpFile:" & ans & ":" & strErrSig, HEADER)
    '            MessageBox.Show("Can not Backup. Please contact administrator.", "BACKUP ERROR", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
    '            If Not unzipFiles(PathZipFile, strInUseFolder) Then
    '                deleteFile(PathZipFile)
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/CanNotUnzipFile:" & strErrSig, HEADER)
    '                Return "Error:Can Not UnzipFile."
    '            End If
    '            Return "Error:Can Not BackUp File."
    '        End If
    '        Dim binDatab As Byte() = My.Computer.FileSystem.ReadAllBytes(PathZipFile)
    '        deleteFolderAll(PathZipFolder)
    '        If System.IO.Directory.Exists(PathZipFolder) Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/CanNotDeleteZipFolder:" & strErrSig, HEADER)
    '            Return "Error:Can Not Delete ZipFolder."
    '        End If
    '        strPass = CStr(mapclass.PassTotal)

    '        DB.setValue(clsDBNfdMap.keys.LotID, strLotID, "=")
    '        DB.setValue(clsDBNfdMap.allcolumns.LotNo, strLotNo, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.Serial, "0", "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.Pass, strPass, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.Wf, strWfHex, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.MapStatus, "Stock", "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.Process, strProcess, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.InDate, strNow, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.InOperater, strInOperator, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.MapData, "0x" & BitConverter.ToString(binDatab).Replace("-", ""), "W")
    '        DB.setValue(clsDBNfdMap.allcolumns.STATUS, "00", "w")
    '        ans = DB.DBinsert()
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/CanNotUpdate:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Can Not Update."
    '        End If
    '        strErrSig = "[" & strLotID & "]"
    '        Dim i As Integer
    '        Dim DB2 As New clsDBProgress(connect, transact)
    '        For i = 1 To MAXFLOW
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            ans = DB2.DBselect()
    '            If ans = "Error: No Record Found" Then
    '                Exit For
    '            End If
    '            If ans Like "Error*" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '        Next
    '        If i <> 1 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/AlreadyUseAssyLotNo:" & ans, HEADER) 'ERROR
    '            Return "Error:Already Use AssyLotNo."
    '        End If
    '        DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '        DB2.setValue(clsDBProgress.keys.FlowNo, "1", "=")
    '        DB2.setValue(clsDBProgress.allcolumns.AssyLotNo, strLotID, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.FlowName, strProcess, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.Progress, "Finish", "w")
    '        DB2.setValue(clsDBProgress.allcolumns.WfLotNo, strLotNo, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.Device, strDevice, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.Package, strPackage, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.StartTime, strNow, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndTime, strNow, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.StartOp, strInOperator, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndOp, strInOperator, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.Program, "NoUse", "w")
    '        DB2.setValue(clsDBProgress.allcolumns.Machine, strMapStatus, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.Tester, "NoUse", "w")
    '        DB2.setValue(clsDBProgress.allcolumns.StartPass, strPass, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndPass, strPass, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndMapData, "0x" & BitConverter.ToString(binDatab).Replace("-", ""), "W")
    '        DB2.setValue(clsDBProgress.allcolumns.Status, "00", "w")
    '        ans = DB2.DBinsert()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/SetLot/CanNotSetProgress:" & ans, HEADER) 'ERROR
    '            Return "Error:Can Not Set Progress."
    '        End If
    '        strText = DB2.getValue(clsDBProgress.allcolumns.Device) & "," & DB2.getValue(clsDBProgress.allcolumns.AssyLotNo) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.FlowNo) & "," & DB2.getValue(clsDBProgress.allcolumns.FlowName) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.Progress) & "," & DB2.getValue(clsDBProgress.allcolumns.Program) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.Machine) & "," & DB2.getValue(clsDBProgress.allcolumns.Tester) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartTime) & "," & DB2.getValue(clsDBProgress.allcolumns.EndTime) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartOp) & "," & DB2.getValue(clsDBProgress.allcolumns.EndOp) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartPass) & "," & DB2.getValue(clsDBProgress.allcolumns.EndPass)
    '        '	NFDRecordログ出力
    '        addNFDRecord(strLotID, strLotNo, "INPUT", "Stock", strNow, strInOperator)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/SetLot", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/SetLot"
    '    End Try
    '    Return strText
    'End Function

    ''登録する。
    'Public Shared Function CreateLot(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                 ByVal strLotID As String, ByVal strLotNo As String, ByVal strMapStatus As String, ByVal strProcess As String, _
    '                                 ByVal strDevice As String, ByVal strPackage As String, ByVal strProgram As String, ByVal strStatus As String, _
    '                                 ByVal dtNow As DateTime, ByVal strInOperator As String) As String
    '    'return value 
    '    '"Device","AssyLotNo","FlowNo","FlowName","Progress","Program","Machine","Tester","StartTime","EndTime","StartOp","EndOp","StartPass","EndPass": no error
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strLotID & "]:" & strInOperator
    '    Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    '    Dim strText As String = ""
    '    Dim strTester As String = ""
    '    Dim strPass As String = "0"
    '    Dim ans As String = ""
    '    Dim strInUseFolder As String = Nfd_mappath_root("NFD_PATH") & "\" & strMapStatus

    '    Try
    '        '   宛先レコード(MapStatus=MachineName)が既にあるときはエラー
    '        ans = clsNfdMap.getMapStatus(connect, transact, strMapStatus)
    '        If ans <> "" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "//CreateLot/DestinationMachineRecordAlreadyInUse:MapStatus[" & strMapStatus & "]:" & strErrSig, HEADER)
    '            Return "Error:Destination MachineRecord Already InUse:MapStatus[" & strMapStatus & "]"
    '        End If

    '        '   宛先フォルダーが使用中のときはエラー
    '        If Not System.IO.Directory.Exists(strInUseFolder) Then createFolder(strInUseFolder)
    '        If clsNfdMap.ChkExistReadOnly(strInUseFolder) = False Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "//CreateLot/DestinationMachineFolderAlreadyInUse:" & strErrSig, HEADER)
    '            Return "Error:Destination Machine Folder Already InUse."
    '        End If
    '        clsAntiInjection.checkID(strLotID, strInOperator) '後ろはチェックあまい(日本語とかに使用)
    '        clsAntiInjection.checkID(strLotNo, "DUMMY")
    '        clsAntiInjection.checkID(strMapStatus, "DUMMY")
    '        clsAntiInjection.checkID(strProcess, "DUMMY")
    '        If Not System.IO.Directory.Exists(strInUseFolder) Then createFolder(strInUseFolder)
    '        Dim DB As New clsDBNfdMap(connect, transact)
    '        If StrUseFdd = "1" Then 'FDD Mode
    '            '	MapStatus：Stock -> 'DownLoad'　にデータレコードUpdate
    '            DB.setValue(clsDBNfdMap.keys.LotID, strLotID, "=")
    '            DB.setValue(clsDBNfdMap.allcolumns.LotNo, "NoUse", "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.Serial, "0", "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.Wf, "0000000", "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.Pass, strPass, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.MapStatus, "DownLoad", "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.Process, strProcess, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.ProcessFlag, "00000000", "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.InDate, strNow, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.InOperater, strInOperator, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.STATUS, "00", "w")
    '        Else
    '            '	MapStatus：Stock -> '場所'　にデータレコードUpdate
    '            DB.setValue(clsDBNfdMap.keys.LotID, strLotID, "=")
    '            DB.setValue(clsDBNfdMap.allcolumns.LotNo, "NoUse", "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.Serial, "0", "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.Wf, "0000000", "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.Pass, "0", "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.MapStatus, strMapStatus, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.Process, strProcess, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.ProcessFlag, "00000000", "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.InDate, strNow, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.InOperater, strInOperator, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.STATUS, "00", "w")
    '        End If
    '        ans = DB.DBinsert()
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/CreateLot/CanNotUpdate:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Can Not Update:" & ans
    '        End If

    '        Dim DB3 As New clsDBMachine(connect, transact)
    '        DB3.setValue(clsDBMachine.keys.MachineName, strMapStatus, "=")
    '        DB3.setValue(clsDBMachine.allcolumns.TesterName, "", "")
    '        ans = DB3.DBselect()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/CreateLot/CanNoGetTesterName:" & ans, HEADER) 'ERROR
    '            Return "Error:Can Not Get Tester Name."
    '        End If
    '        strTester = DB3.getValue(clsDBMachine.allcolumns.TesterName)

    '        Dim DB2 As New clsDBProgress(connect, transact)
    '        Dim strFLowNo As String = "1"
    '        Dim strProgress As String = "OnGoing"
    '        Dim strEndTime As String = "2000-01-01 00:00:00"
    '        If StrUseFdd = "1" Then 'FDD Mode
    '            strProgress = "OnGoingFD"
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, strFLowNo, "=")
    '            DB2.setValue(clsDBProgress.allcolumns.AssyLotNo, strLotID, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.FlowName, strProcess, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Progress, strProgress, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.WfLotNo, strLotNo, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Device, strDevice, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Package, strPackage, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Program, strProgram, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Machine, strMapStatus, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Tester, strTester, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartTime, strNow, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndTime, strEndTime, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartOp, strInOperator, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndOp, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartPass, strPass, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Program, strProgram, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndPass, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Status, strStatus, "w")
    '        Else
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, strFLowNo, "=")
    '            DB2.setValue(clsDBProgress.allcolumns.AssyLotNo, strLotID, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.FlowName, strProcess, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Progress, strProgress, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.WfLotNo, strLotNo, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Device, strDevice, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Package, strPackage, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Program, strProgram, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Machine, strMapStatus, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Tester, strTester, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartTime, strNow, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndTime, strEndTime, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartOp, strInOperator, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndOp, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartPass, strPass, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndPass, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Status, strStatus, "w")
    '        End If
    '        ans = DB2.DBinsert()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/CreateLot/CanNotSetProgress:" & ans, HEADER) 'ERROR
    '            Return "Error:Can Not Set Progress."
    '        End If
    '        strText = strDevice & "," & strLotID & "," & strFLowNo & "," & strProcess & "," & _
    '                  strProgress & "," & strProgram & "," & strMapStatus & "," & strTester & "," & _
    '                  strNow & "," & strEndTime & "," & strInOperator & "," & "" & "," & _
    '                  strPass & "," & ""

    '        '	NFDRecordログ出力
    '        addNFDRecord(strLotID, strLotNo, "Stock", strMapStatus, strNow, strInOperator)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/CreateLot", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/Createlot"
    '    End Try
    '    Return strText
    'End Function

    'Public Shared Function InputLot(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                ByVal strLotID As String, ByVal strLotNo As String, ByVal strMachine As String, ByVal strProcess As String, _
    '                                ByVal strDevice As String, ByVal strPackage As String, ByVal strProgram As String, ByVal strStatus As String, _
    '                                ByVal strWf As String, ByVal strPass As String, ByVal strPathzipfile As String, ByVal dtNow As DateTime, _
    '                                ByVal strInOperator As String) As String
    '    'return value
    '    '"True": no error 
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strLotID & "]:" & strInOperator
    '    Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    '    Dim strText As String = ""
    '    Dim strTester As String = "Unknown"
    '    Dim ans As String = ""

    '    Try
    '        clsAntiInjection.checkID(strLotID, strInOperator) '後ろはチェックあまい(日本語とかに使用)
    '        clsAntiInjection.checkID(strLotNo, "DUMMY")
    '        clsAntiInjection.checkID(strMachine, "DUMMY")
    '        clsAntiInjection.checkID(strProcess, "DUMMY")
    '        Dim binDatab As Byte() = My.Computer.FileSystem.ReadAllBytes(strPathzipfile)
    '        Dim strWfHex As String = (clsWaHexConverter.BinToHex(strWf))
    '        Dim DB As New clsDBNfdMap(connect, transact)
    '        DB.setValue(clsDBNfdMap.keys.LotID, strLotID, "=")
    '        DB.setValue(clsDBNfdMap.allcolumns.LotNo, strLotNo, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.Serial, "0", "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.Wf, strWfHex, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.Pass, strPass, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.MapStatus, "Stock", "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.Process, strProcess, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.ProcessFlag, "00000000", "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.InDate, strNow, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.InOperater, strInOperator, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.MapData, "0x" & BitConverter.ToString(binDatab).Replace("-", ""), "W")
    '        DB.setValue(clsDBNfdMap.allcolumns.STATUS, "00", "w")
    '        ans = DB.DBinsert()
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/InputLot/CanNotUpdate:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Can Not Update:" & ans
    '        End If

    '        Dim DB2 As New clsDBProgress(connect, transact)
    '        Dim strFLowNo As String = "1"
    '        Dim strProgress As String = "Finish"
    '        DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '        DB2.setValue(clsDBProgress.keys.FlowNo, strFLowNo, "=")
    '        DB2.setValue(clsDBProgress.allcolumns.AssyLotNo, strLotID, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.FlowName, strProcess, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.Progress, strProgress, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.WfLotNo, strLotNo, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.Device, strDevice, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.Package, strPackage, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.Program, strProgram, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.Machine, strMachine, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.Tester, strTester, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.StartTime, strNow, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndTime, strNow, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.StartOp, strInOperator, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndOp, strInOperator, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.StartPass, strPass, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.Program, strProgram, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndPass, strPass, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndMapData, "0x" & BitConverter.ToString(binDatab).Replace("-", ""), "W")
    '        DB2.setValue(clsDBProgress.allcolumns.Status, strStatus, "w")
    '        ans = DB2.DBinsert()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/InputLot/CanNotSetProgress:" & ans, HEADER) 'ERROR
    '            Return "Error:Can Not Set Progress."
    '        End If
    '        strText = strDevice & "," & strLotID & "," & strFLowNo & "," & strProcess & "," & _
    '                  strProgress & "," & strProgram & "," & strMachine & "," & strTester & "," & _
    '                  strNow & "," & strNow & "," & strInOperator & "," & "" & "," & _
    '                  strPass & "," & ""

    '        '	NFDRecordログ出力
    '        addNFDRecord(strLotID, strLotNo, "Stock", strMachine, strNow, strInOperator)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/InputLot", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/InputLot"
    '    End Try
    '    Return "True"
    'End Function

    Public Shared Function ASEStripInputLot(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
                                       ByVal strMachine As String, ByVal strAssyLotNo As String, ByVal strProcess As String, ByVal strProcessMode As String, _
                                       ByVal strPathzipfile As String, ByVal dtLotstarttime As DateTime, ByVal dtLotEndTime As DateTime, _
                                       ByVal strRemark As String) As String
        'return value
        '"True": no error 
        '"other": fail

        Dim strErrSig As String = "[" & strAssyLotNo & "]:"
        Dim strLotStartTime As String = Format(dtLotstarttime, "yyyy-MM-dd HH:mm:ss")
        Dim strLotEndTime As String = Format(dtLotEndTime, "yyyy-MM-dd HH:mm:ss")
        Dim ans As String = ""

        Try
            '後ろはチェックあまい(日本語とかに使用)
            clsAntiInjection.checkID(strAssyLotNo, "DUMMY")
            clsAntiInjection.checkID(strMachine, "DUMMY")
            clsAntiInjection.checkID(strProcess, "DUMMY")
            Dim binDatab As Byte() = My.Computer.FileSystem.ReadAllBytes(strPathzipfile)
            Dim DB As New clsDBMap_MapData(connect, transact)

            DB.setValue(clsDBMap_MapData.keys.LotNo, strAssyLotNo, "=")
            DB.setValue(clsDBMap_MapData.keys.MCNo, "", "")
            DB.setValue(clsDBMap_MapData.keys.LotStartTime, "", "")
            DB.setValue(clsDBMap_MapData.allcolumns.Process, "OS", "<>")
            DB.setValue(clsDBMap_MapData.allcolumns.ProcessMode, "", "")
            DB.setValue(clsDBMap_MapData.allcolumns.LotEndTime, "", "")
            DB.setValue(clsDBMap_MapData.allcolumns.MAPData, "", "")
            DB.setValue(clsDBMap_MapData.allcolumns.Remark, "", "")
            ans = DB.DBselect()
            If ans <> "Error: No Record Found" Then
                If ans = "Error*" Then  '
                    clsErrorLog.addlogWT("Error:" & HEADER & "/ASEStripInputLot/CanNotCheckLotNo:" & ans, HEADER) 'ERROR
                Else
                    clsErrorLog.addlogWT("Error:" & HEADER & "/ASEStripInputLot/AllReadyExist:[" & strAssyLotNo & "]" & ans, HEADER) 'ERROR
                    Return "Error:Allready Exist:[" & strAssyLotNo & "]"
                End If
            End If

            DB.setValue(clsDBMap_MapData.keys.MCNo, strMachine, "=")
            DB.setValue(clsDBMap_MapData.keys.LotNo, strAssyLotNo, "=")
            DB.setValue(clsDBMap_MapData.keys.LotStartTime, strLotStartTime, "=")
            DB.setValue(clsDBMap_MapData.allcolumns.Process, strProcess, "w")
            DB.setValue(clsDBMap_MapData.allcolumns.ProcessMode, strProcessMode, "w")
            DB.setValue(clsDBMap_MapData.allcolumns.LotEndTime, strLotEndTime, "w")
            DB.setValue(clsDBMap_MapData.allcolumns.MAPData, "0x" & BitConverter.ToString(binDatab).Replace("-", ""), "w")
            DB.setValue(clsDBMap_MapData.allcolumns.Remark, strRemark, "w")
            ans = DB.DBinsertORupdate()
            If ans <> "True" Then
                clsErrorLog.addlogWT("Error:" & HEADER & "/ASEStripInputLot/CanNotInsertorUpdate:" & ans & ":" & strErrSig, HEADER)
                Return "Error:Can Not Update:[" & strAssyLotNo & "]"
            End If

            '	NFDRecordログ出力
            addNFDRecord(strAssyLotNo, strAssyLotNo, "Stock", strMachine, strLotStartTime)

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/ASEStripInputLot", HEADER)
            Return "Error:" & ex.ToString & "," & HEADER & "/ASEStripInputLot"
        End Try
        Return "True"
    End Function

    ''ＭＡＰサーバーからＭＡＰを取得する。(Input以外)
    'Public Shared Function StartInUseLot(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                     ByVal strLotID As String, ByVal strLotNo As String, ByVal strMapStatus As String, ByVal strProcess As String, _
    '                                     ByVal strDevice As String, ByVal strPackage As String, ByVal strProgram As String, ByVal strStatus As String, _
    '                                     ByVal dtNow As DateTime, ByVal strInOperator As String) As String
    '    'return value 
    '    '"Device","AssyLotNo","FlowNo","FlowName","Progress","Program","Machine","Tester","StartTime","EndTime","StartOp","EndOp","StartPass","EndPass": no error
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strLotID & "]:" & strInOperator
    '    Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    '    Dim strText As String = ""
    '    Dim ans As String = ""
    '    Dim strInUseFolder As String = Nfd_mappath_root("NFD_PATH") & "\" & strMapStatus
    '    Dim PathZipFolder As String = Temp_mappath_root() & "\" & strMapStatus & "\" & strLotID
    '    Dim PathZipFile As String = PathZipFolder & "\" & strLotID & ".zip"
    '    Dim fas As FileAttribute

    '    Try
    '        clsAntiInjection.checkID(strLotID, strInOperator) '後ろはチェックあまい(日本語とかに使用)
    '        clsAntiInjection.checkID(strLotNo, "DUMMY")
    '        clsAntiInjection.checkID(strMapStatus, "DUMMY")
    '        clsAntiInjection.checkID(strProcess, "DUMMY")

    '        '	指定ロット無かった時はエラー
    '        ans = clsNfdMap.getLotIDStatus(connect, transact, strLotID)
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/GetLotIDStatusError:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Get LotID Status Error:" & ans
    '        ElseIf ans = "" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/LotNotExist:Status[" & ans & "]:" & strErrSig, HEADER)
    '            Return "Error:Lot Not Exist:Status[" & ans & "]"
    '        ElseIf ans <> "Stock" Then  '	Stock以外はエラー
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/LotNotInStock:Status[" & ans & "]:" & strErrSig, HEADER)
    '            Return "Error:Lot Not InStock:Status[" & ans & "]"
    '        End If

    '        '   宛先レコード(MapStatus=MachineName)が既にあるときはエラー
    '        ans = clsNfdMap.getMapStatus(connect, transact, strMapStatus)
    '        If ans <> "" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/DestinationMachineRecordAlreadyInUse:MapStatus[" & strMapStatus & "]:" & strErrSig, HEADER)
    '            Return "Error:Destination MachineRecord Already InUse:MapStatus[" & strMapStatus & "]"
    '        End If

    '        '   宛先フォルダーが使用中のときはエラー
    '        If Not System.IO.Directory.Exists(strInUseFolder) Then createFolder(strInUseFolder)
    '        If clsNfdMap.ChkExistReadOnly(strInUseFolder) = False Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/DestinationMachineFolderAlreadyInUse:" & strErrSig, HEADER)
    '            Return "Error:Destination Machine Folder Already InUse."
    '        End If

    '        '   ＭＡＰ データ 取得
    '        If System.IO.Directory.Exists(PathZipFolder) Then
    '            deleteFolderAll(PathZipFolder)
    '            If System.IO.Directory.Exists(PathZipFolder) Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/CanNotDeleteZipFolder:" & strErrSig, HEADER)
    '                Return "Error:Can Not Delete ZipFolder."
    '            End If
    '        End If
    '        createFolder(PathZipFolder)
    '        If System.IO.Directory.GetFiles(PathZipFolder).Length > 0 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/ExistZipFolderAlready:" & strErrSig, HEADER)
    '            Return "Error:Exist ZipFolder Already."
    '        End If
    '        ans = clsNfdMap.getMapData(connect, transact, strLotID, PathZipFolder, PathZipFile)
    '        If ans <> "True" Then
    '            If ans = "" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/LotNotExist:" & ans & ":" & strErrSig, HEADER)
    '                Return "Error:Lot Not Exist:" & ans
    '            Else
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/GetMapDataError:" & ans & ":" & strErrSig, HEADER)
    '                Return "Error:Get MapData Error:" & ans
    '            End If
    '        End If

    '        ''   ロットデータの整合性チェック（共通）
    '        Dim mapclass As clsMapData = clsMap.getMapData(PathZipFile)
    '        'Dim mapclass As MapData = clsMapDataValidateCheck.getMapdata(PathZipFile)
    '        If mapclass Is Nothing Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/CanNotReadMapdata[" & PathZipFile & "]:" & strErrSig, HEADER)
    '            Return "Error:Can Not Read Mapdata[" & PathZipFile & "]"
    '        End If
    '        If mapclass.LotNo.ToUpper <> strLotID.ToUpper Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/LotNoMismatch[map:" & mapclass.LotNo & "]:" & strErrSig, HEADER)
    '            Return "Error:LotNo Mismatch[map:" & mapclass.LotNo & "]"
    '        End If

    '        strErrSig = "[" & strLotID & "]to[" & strMapStatus & "]:" & strInOperator

    '        '   '場所'へ移動　(unzip)
    '        If Not unzipFiles(PathZipFile, strInUseFolder) Then
    '            deleteFile(PathZipFile)
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/CanNotUnzipFile:" & strErrSig, HEADER)
    '            Return "Error:Can Not UnzipFile."
    '        End If
    '        Dim DB As New clsDBNfdMap(connect, transact)
    '        If StrUseFdd = "1" Then 'FDD Mode
    '            For Each f As String In System.IO.Directory.GetFiles(strInUseFolder)
    '                fas = System.IO.File.GetAttributes(f)
    '                If ((fas And FileAttribute.ReadOnly) <> FileAttribute.ReadOnly) Then
    '                    System.IO.File.Copy(f, StrFDDPath & "\" & System.IO.Path.GetFileName(f), True)
    '                    System.IO.File.Delete(f)
    '                End If
    '            Next
    '            '	MapStatus：Stock -> 'DownLoad'　にデータレコードUpdate
    '            DB.setValue(clsDBNfdMap.keys.LotID, strLotID, "=")
    '            DB.setValue(clsDBNfdMap.allcolumns.MapStatus, "DownLoad", "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.Process, strProcess, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.InDate, strNow, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.InOperater, strInOperator, "w")
    '        Else
    '            For Each f As String In System.IO.Directory.GetFiles(strInUseFolder)
    '                If f Like "*.MAP" Then
    '                    ' FileSystem.Rename(f, f & ".bak")
    '                    FileSystem.FileCopy(f, f & ".bak")
    '                End If
    '            Next
    '            '	MapStatus：Stock -> '場所'　にデータレコードUpdate
    '            DB.setValue(clsDBNfdMap.keys.LotID, strLotID, "=")
    '            DB.setValue(clsDBNfdMap.allcolumns.MapStatus, strMapStatus, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.Process, strProcess, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.InDate, strNow, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.InOperater, strInOperator, "w")
    '        End If
    '        ans = DB.DBupdate()
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/CanNotUpdate:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Can Not Update:" & ans
    '        End If
    '        deleteFolderAll(PathZipFolder)
    '        If System.IO.Directory.Exists(PathZipFolder) Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/CanNotDeleteZipFolder:" & strErrSig, HEADER)
    '            Return "Error:Can Not Delete ZipFolder."
    '        End If
    '        Dim strPass As String = CStr(mapclass.PassTotal)
    '        Dim strTester As String = ""
    '        'If strProcess Like "*PAT" Then
    '        'Else
    '        Dim DB3 As New clsDBMachine(connect, transact)
    '        DB3.setValue(clsDBMachine.keys.MachineName, strMapStatus, "=")
    '        DB3.setValue(clsDBMachine.allcolumns.TesterName, "", "")
    '        ans = DB3.DBselect()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/CanNoGetTesterName:" & ans, HEADER) 'ERROR
    '            Return "Error:Can Not Get Tester Name."
    '        End If
    '        strTester = DB3.getValue(clsDBMachine.allcolumns.TesterName)
    '        'End If
    '        Dim i As Integer
    '        Dim DB2 As New clsDBProgress(connect, transact)
    '        For i = 1 To MAXFLOW
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            ans = DB2.DBselect()
    '            If ans = "Error: No Record Found" Then
    '                Exit For
    '            End If
    '            If ans Like "Error*" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '            System.Windows.Forms.Application.DoEvents()
    '        Next
    '        If i = 1 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/IllegalFlowNo:" & ans, HEADER) 'ERROR
    '            Return "Error:Illegal FlowNo."
    '        End If
    '        If StrUseFdd = "1" Then 'FDD Mode
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            DB2.setValue(clsDBProgress.allcolumns.AssyLotNo, strLotID, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.FlowName, strProcess, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Progress, "OnGoingFD", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.WfLotNo, strLotNo, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Device, strDevice, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Package, strPackage, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Program, strProgram, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Machine, strMapStatus, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Tester, strTester, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartTime, strNow, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndTime, "2000-01-01 00:00:00", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartOp, strInOperator, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndOp, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Program, strProgram, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndPass, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Status, strStatus, "w")
    '        Else
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            DB2.setValue(clsDBProgress.allcolumns.AssyLotNo, strLotID, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.FlowName, strProcess, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Progress, "OnGoing", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.WfLotNo, strLotNo, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Device, strDevice, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Package, strPackage, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Program, strProgram, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Machine, strMapStatus, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Tester, strTester, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartTime, strNow, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndTime, "2000-01-01 00:00:00", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartOp, strInOperator, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndOp, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartPass, strPass, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndPass, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Status, strStatus, "w")
    '        End If
    '        ans = DB2.DBinsert()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/StartInUseLot/CanNotSetProgress:" & ans, HEADER) 'ERROR
    '            Return "Error:Can Not Set Progress."
    '        End If
    '        strText = DB2.getValue(clsDBProgress.allcolumns.Device) & "," & DB2.getValue(clsDBProgress.allcolumns.AssyLotNo) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.FlowNo) & "," & DB2.getValue(clsDBProgress.allcolumns.FlowName) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.Progress) & "," & DB2.getValue(clsDBProgress.allcolumns.Program) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.Machine) & "," & DB2.getValue(clsDBProgress.allcolumns.Tester) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartTime) & "," & DB2.getValue(clsDBProgress.allcolumns.EndTime) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartOp) & "," & DB2.getValue(clsDBProgress.allcolumns.EndOp) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartPass) & "," & DB2.getValue(clsDBProgress.allcolumns.EndPass)

    '        '	NFDRecordログ出力
    '        addNFDRecord(strLotID, strLotNo, "Stock", strMapStatus, strNow, strInOperator)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/StartInUseLot", HEADER)
    '        If StrUseFdd = "1" Then
    '            For Each f As String In System.IO.Directory.GetFiles(strInUseFolder)
    '                fas = System.IO.File.GetAttributes(f)
    '                If ((fas And FileAttribute.Hidden) = FileAttribute.Hidden) Then
    '                    fas = System.IO.FileAttributes.Normal
    '                    System.IO.File.Delete(f)
    '                End If
    '            Next
    '        End If
    '        Return "Error:" & ex.ToString & "," & HEADER & "/StartInUseLot"
    '    End Try
    '    Return strText
    'End Function

    ''ＭＡＰサーバーからＭＡＰを取得する。(Tp)
    'Public Shared Function TpStartInUseLot(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                       ByVal strLotID As String, ByVal strLotNo As String, ByVal strMapStatus As String, ByVal strProcess As String, _
    '                                       ByVal strDevice As String, ByVal strPackage As String, ByVal strProgram As String, ByVal strStatus As String, _
    '                                       ByVal dtNow As DateTime, ByVal strInOperator As String) As String
    '    'return value 
    '    '"Device","AssyLotNo","FlowNo","FlowName","Progress","Program","Machine","Tester","StartTime","EndTime","StartOp","EndOp","StartPass","EndPass": no error
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strLotID & "]:" & strInOperator
    '    Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    '    Dim strText As String = ""
    '    Dim ans As String = ""
    '    Dim strInUseFolder As String = Nfd_mappath_root("NFD_PATH") & "\" & strMapStatus
    '    Dim PathZipFolder As String = Temp_mappath_root() & "\" & strMapStatus & "\" & strLotID
    '    Dim PathZipFile As String = PathZipFolder & "\" & strLotID & ".zip"
    '    Dim fas As FileAttribute

    '    Try
    '        clsAntiInjection.checkID(strLotID, strInOperator) '後ろはチェックあまい(日本語とかに使用)
    '        clsAntiInjection.checkID(strLotNo, "DUMMY")
    '        clsAntiInjection.checkID(strMapStatus, "DUMMY")
    '        clsAntiInjection.checkID(strProcess, "DUMMY")

    '        '	指定ロット無かった時はエラー
    '        ans = clsNfdMap.getLotIDStatus(connect, transact, strLotID)
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/GetLotIDStatusError:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Get LotID Status Error:" & ans
    '        ElseIf ans = "" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/LotNotExist:Status[" & ans & "]:" & strErrSig, HEADER)
    '            Return "Error:Lot Not Exist:Status[" & ans & "]"
    '        ElseIf ans <> "Stock" Then  '	Stock以外はエラー
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/LotNotInStock:Status[" & ans & "]:" & strErrSig, HEADER)
    '            Return "Error:Lot Not InStock:Status[" & ans & "]"
    '        End If

    '        '   宛先レコード(MapStatus=MachineName)が既にあるときはエラー
    '        ans = clsNfdMap.getMapStatus(connect, transact, strMapStatus)
    '        If ans <> "" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/DestinationMachineRecordAlreadyInUse:MapStatus[" & strMapStatus & "]:" & strErrSig, HEADER)
    '            Return "Error:Destination MachineRecord Already InUse:MapStatus[" & strMapStatus & "]"
    '        End If
    '        '   宛先フォルダーが使用中のときはエラー
    '        If Not System.IO.Directory.Exists(strInUseFolder) Then createFolder(strInUseFolder)
    '        If clsNfdMap.ChkExistReadOnly(strInUseFolder) = False Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/DestinationMachineFolderAlreadyInUse:" & strErrSig, HEADER)
    '            Return "Error:Destination Machine Folder Already InUse."
    '        End If
    '        '   ＭＡＰ データ 取得
    '        If System.IO.Directory.Exists(PathZipFolder) Then
    '            deleteFolderAll(PathZipFolder)
    '            If System.IO.Directory.Exists(PathZipFolder) Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/CanNotDeleteZipFolder:" & strErrSig, HEADER)
    '                Return "Error:Can Not Delete ZipFolder."
    '            End If
    '        End If
    '        createFolder(PathZipFolder)
    '        If System.IO.Directory.GetFiles(PathZipFolder).Length > 0 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/ExistZipFolderAlready:" & strErrSig, HEADER)
    '            Return "Error:Exist ZipFolder Already."
    '        End If
    '        ans = clsNfdMap.getMapData(connect, transact, strLotID, PathZipFolder, PathZipFile)
    '        If ans <> "True" Then
    '            If ans = "" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/LotNotExist:" & ans & ":" & strErrSig, HEADER)
    '                Return "Error:Lot Not Exist:" & ans
    '            Else
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/GetMapDataError:" & ans & ":" & strErrSig, HEADER)
    '                Return "Error:Get MapData Error:" & ans
    '            End If
    '        End If

    '        ''   ロットデータの整合性チェック（共通）
    '        Dim mapclass As clsMapData = clsMap.getMapData(PathZipFile)
    '        'Dim mapclass As MapData = clsMapDataValidateCheck.getMapdata(PathZipFile)
    '        If mapclass Is Nothing Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/CanNotReadMapdata[" & PathZipFile & "]:" & strErrSig, HEADER)
    '            Return "Error:Can Not Read Mapdata[" & PathZipFile & "]"
    '        End If
    '        If mapclass.LotNo.ToUpper <> strLotID.ToUpper Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/LotNoMismatch[map:" & mapclass.LotNo & "]:" & strErrSig, HEADER)
    '            Return "Error:LotNo Mismatch[map:" & mapclass.LotNo & "]"
    '        End If
    '        If mapclass.AutoNo = "OS" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/This Mapdata is OS ]:" & strErrSig, HEADER)
    '            Return "Error:This Mapdata is OS"
    '        End If
    '        strErrSig = "[" & strLotID & "]to[" & strMapStatus & "]:" & strInOperator

    '        '   '場所'へ移動　(unzip)
    '        If Not unzipFiles(PathZipFile, strInUseFolder) Then
    '            deleteFile(PathZipFile)
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/CanNotUnzipFile:" & strErrSig, HEADER)
    '            Return "Error:Can Not UnzipFile."
    '        End If
    '        Dim DB As New clsDBNfdMap(connect, transact)
    '        If StrUseFdd = "1" Then 'FDD Mode
    '            For Each f As String In System.IO.Directory.GetFiles(strInUseFolder)
    '                fas = System.IO.File.GetAttributes(f)
    '                If ((fas And FileAttribute.ReadOnly) <> FileAttribute.ReadOnly) Then
    '                    System.IO.File.Copy(f, StrFDDPath & "\" & System.IO.Path.GetFileName(f), True)
    '                    System.IO.File.Delete(f)
    '                End If
    '            Next
    '            '	MapStatus：Stock -> 'DownLoad'　にデータレコードUpdate
    '            DB.setValue(clsDBNfdMap.keys.LotID, strLotID, "=")
    '            DB.setValue(clsDBNfdMap.allcolumns.MapStatus, "DownLoad", "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.Process, strProcess, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.InDate, strNow, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.InOperater, strInOperator, "w")
    '        Else
    '            For Each f As String In System.IO.Directory.GetFiles(strInUseFolder)
    '                If f Like "*.MAP" Then
    '                    FileSystem.Rename(f, f & ".bak")
    '                End If
    '            Next
    '            '	MapStatus：Stock -> '場所'　にデータレコードUpdate
    '            DB.setValue(clsDBNfdMap.keys.LotID, strLotID, "=")
    '            DB.setValue(clsDBNfdMap.allcolumns.MapStatus, strMapStatus, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.Process, strProcess, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.InDate, strNow, "w")
    '            DB.setValue(clsDBNfdMap.allcolumns.InOperater, strInOperator, "w")
    '        End If
    '        ans = DB.DBupdate()
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/CanNotUpdate:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Can Not Update:" & ans
    '        End If
    '        deleteFolderAll(PathZipFolder)
    '        If System.IO.Directory.Exists(PathZipFolder) Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/CanNotDeleteZipFolder:" & strErrSig, HEADER)
    '            Return "Error:Can Not Delete ZipFolder."
    '        End If
    '        Dim strPass As String = CStr(mapclass.PassTotal)
    '        Dim strTester As String = ""
    '        'If strProcess Like "*PAT" Then
    '        'Else
    '        Dim DB3 As New clsDBMachine(connect, transact)
    '        DB3.setValue(clsDBMachine.keys.MachineName, strMapStatus, "=")
    '        DB3.setValue(clsDBMachine.allcolumns.TesterName, "", "")
    '        ans = DB3.DBselect()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/CanNoGetTesterName:" & ans, HEADER) 'ERROR
    '            Return "Error:Can Not Get Tester Name."
    '        End If
    '        strTester = DB3.getValue(clsDBMachine.allcolumns.TesterName)
    '        'End If
    '        Dim i As Integer
    '        Dim DB2 As New clsDBProgress(connect, transact)
    '        For i = 1 To MAXFLOW
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            ans = DB2.DBselect()
    '            If ans = "Error: No Record Found" Then
    '                Exit For
    '            End If
    '            If ans Like "Error*" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '            System.Windows.Forms.Application.DoEvents()
    '        Next
    '        If i = 1 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/IllegalFlowNo:" & ans, HEADER) 'ERROR
    '            Return "Error:Illegal FlowNo."
    '        End If
    '        If StrUseFdd = "1" Then 'FDD Mode
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            DB2.setValue(clsDBProgress.allcolumns.AssyLotNo, strLotID, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.FlowName, strProcess, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Progress, "OnGoingFD", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.WfLotNo, strLotNo, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Device, strDevice, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Package, strPackage, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Program, strProgram, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Machine, strMapStatus, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Tester, strTester, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartTime, strNow, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndTime, "2000-01-01 00:00:00", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartOp, strInOperator, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndOp, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Program, strProgram, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndPass, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Status, strStatus, "w")
    '        Else
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            DB2.setValue(clsDBProgress.allcolumns.AssyLotNo, strLotID, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.FlowName, strProcess, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Progress, "OnGoing", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.WfLotNo, strLotNo, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Device, strDevice, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Package, strPackage, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Program, strProgram, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Machine, strMapStatus, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Tester, strTester, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartTime, strNow, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndTime, "2000-01-01 00:00:00", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartOp, strInOperator, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndOp, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartPass, strPass, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndPass, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Status, strStatus, "w")
    '        End If
    '        ans = DB2.DBinsert()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpStartInUseLot/CanNotSetProgress:" & ans, HEADER) 'ERROR
    '            Return "Error:Can Not Set Progress."
    '        End If
    '        strText = DB2.getValue(clsDBProgress.allcolumns.Device) & "," & DB2.getValue(clsDBProgress.allcolumns.AssyLotNo) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.FlowNo) & "," & DB2.getValue(clsDBProgress.allcolumns.FlowName) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.Progress) & "," & DB2.getValue(clsDBProgress.allcolumns.Program) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.Machine) & "," & DB2.getValue(clsDBProgress.allcolumns.Tester) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartTime) & "," & DB2.getValue(clsDBProgress.allcolumns.EndTime) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartOp) & "," & DB2.getValue(clsDBProgress.allcolumns.EndOp) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartPass) & "," & DB2.getValue(clsDBProgress.allcolumns.EndPass)

    '        '	NFDRecordログ出力
    '        addNFDRecord(strLotID, strLotNo, "Stock", strMapStatus, strNow, strInOperator)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/TpStartInUseLot", HEADER)
    '        If StrUseFdd = "1" Then
    '            For Each f As String In System.IO.Directory.GetFiles(strInUseFolder)
    '                fas = System.IO.File.GetAttributes(f)
    '                If ((fas And FileAttribute.Hidden) = FileAttribute.Hidden) Then
    '                    fas = System.IO.FileAttributes.Normal
    '                    System.IO.File.Delete(f)
    '                End If
    '            Next
    '        End If
    '        Return "Error:" & ex.ToString & "," & HEADER & "/TpStartInUseLot"
    '    End Try
    '    Return strText
    'End Function

    ''ＭＡＰサーバーへＭＡＰを返却する。(Input以外)
    'Public Shared Function EndInUseLot(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                   ByVal strLotID As String, ByVal strLotNo As String, ByVal strMapStatus As String, ByVal strProcess As String, _
    '                                   ByVal strDevice As String, ByVal strPackage As String, ByVal strStatus As String, _
    '                                   ByVal dtNow As DateTime, ByVal strInOperator As String) As String
    '    'return value 
    '    '"Device","AssyLotNo","FlowNo","FlowName","Progress","Program","Machine","Tester","StartTime","EndTime","StartOp","EndOp","StartPass","EndPass": no error
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strLotID & "]:" & strInOperator
    '    Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    '    Dim strText As String = ""
    '    Dim ans As String = ""
    '    Dim strInUseFolder As String = Nfd_mappath_root("NFD_PATH") & "\" & strMapStatus
    '    Dim PathZipFolder As String = Temp_mappath_root() & "\" & strMapStatus & "\" & strLotID
    '    Dim PathZipFile As String = PathZipFolder & "\" & strLotID & ".zip"
    '    Dim fas As FileAttribute

    '    Try
    '        If strMapStatus = "" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/No MapStatus:" & strErrSig, HEADER)
    '            Return "Error:No MapStatus."
    '        End If
    '        If strProcess = "" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/No Process:" & strErrSig, HEADER)
    '            Return "Error:No Process."
    '        End If

    '        clsAntiInjection.checkID(strLotID, strInOperator) '後ろはチェックあまい(日本語とかに使用)
    '        clsAntiInjection.checkID(strLotNo, "DUMMY")
    '        clsAntiInjection.checkID(strMapStatus, "DUMMY")
    '        clsAntiInjection.checkID(strProcess, "DUMMY")

    '        '	指定ロット無かった時はエラー
    '        ans = clsNfdMap.getLotIDStatus(connect, transact, strLotID)
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/GetLotIDStatusError:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Get LotID Status Error:" & ans
    '        ElseIf ans = "" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/LotNotExist:Status[" & ans & "]:" & strErrSig, HEADER)
    '            Return "Error:Lot Not Exist:Status[" & ans & "]"
    '            '	指定ロットがMapStatusに無ければエラー
    '        ElseIf ans <> strMapStatus Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/NoMapStatus:Status[" & ans & "]:" & strErrSig, HEADER)
    '            Return "Error:No Map Status:Status[" & ans & "]"
    '        End If

    '        If System.IO.Directory.Exists(PathZipFolder) Then
    '            deleteFolderAll(PathZipFolder)
    '            If System.IO.Directory.Exists(PathZipFolder) Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotDeleteZipFolder:" & strErrSig, HEADER)
    '                Return "Error:Can Not Delete ZipFolder."
    '            End If
    '        End If
    '        createFolder(PathZipFolder)
    '        If System.IO.Directory.GetFiles(PathZipFolder).Length > 0 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/ExistZipFolderAlready:" & strErrSig, HEADER)
    '            Return "Error:Exist ZipFolder Already."
    '        End If

    '        If Not System.IO.Directory.Exists(strInUseFolder) Then createFolder(strInUseFolder)
    '        If System.IO.File.Exists(strInUseFolder & "Log_Sorter_Inorder.txt") Then
    '            deleteFile(strInUseFolder & "Log_Sorter_Inorder.txt")
    '        End If
    '        For Each f As String In System.IO.Directory.GetFiles(strInUseFolder)
    '            fas = System.IO.File.GetAttributes(f)
    '            If ((fas And FileAttribute.ReadOnly) <> FileAttribute.ReadOnly) Then
    '                If f Like "*.MAP.bak" Then
    '                    System.IO.File.Delete(f)
    '                End If
    '            End If
    '        Next

    '        If Not zipFiles(strInUseFolder, PathZipFile) Then
    '            deleteFile(PathZipFile)
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotzipFile:" & strErrSig, HEADER)
    '            Return "Error:Can Not zipFile."
    '        End If

    '        '   ロットデータの整合性チェック（共通）         
    '        Dim mapclass As clsMapData = clsMap.getMapData(PathZipFile)
    '        'Dim mapclass As MapData = clsMapDataValidateCheck.getMapdata(PathZipFile)
    '        If mapclass Is Nothing Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotReadMapdata[" & strInUseFolder & "]:" & strErrSig, HEADER)
    '            If Not unzipFiles(PathZipFile, strInUseFolder) Then
    '                deleteFile(PathZipFile)
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotUnzipFile:" & strErrSig, HEADER)
    '                Return "Error:Can Not UnzipFile."
    '            End If
    '            Return "Error:Can Not Read Mapdata[" & strInUseFolder & "]"
    '        End If
    '        If mapclass.LotNo.ToUpper <> strLotID.ToUpper Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/LotNoMismatch[map:" & mapclass.LotNo & "]:" & strErrSig, HEADER)
    '            If Not unzipFiles(PathZipFile, strInUseFolder) Then
    '                deleteFile(PathZipFile)
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotUnzipFile:" & strErrSig, HEADER)
    '                Return "Error:Can Not UnzipFile."
    '            End If
    '            Return "Error:Lot No Mismatch[map:" & mapclass.LotNo & "]"
    '        End If

    '        strErrSig = "[" & strLotID & "/" & strLotNo & "]to[" & strMapStatus & "]:" & strInOperator

    '        '   ＭＡＰデータ BackUp
    '        ans = BackUpLot(strLotID, strProcess, PathZipFolder, dtNow, strInOperator)
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotBackUpFile:" & ans & ":" & strErrSig, HEADER)
    '            MessageBox.Show("Can not Backup. Please contact administrator.", "BACKUP ERROR", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
    '            If Not unzipFiles(PathZipFile, strInUseFolder) Then
    '                deleteFile(PathZipFile)
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotUnzipFile:" & strErrSig, HEADER)
    '                Return "Error:Can Not UnzipFile."
    '            End If
    '            Return "Error:Can Not BackUp File."
    '        End If
    '        Dim binDatab As Byte() = My.Computer.FileSystem.ReadAllBytes(PathZipFile)
    '        Dim strWfHex As String = (clsWaHexConverter.BinToHex(mapclass.WaferList()))
    '        Dim strPass As String = CStr(mapclass.PassTotal)
    '        deleteFolderAll(PathZipFolder)
    '        If System.IO.Directory.Exists(PathZipFolder) Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotDeleteZipFolder:" & strErrSig, HEADER)
    '            Return "Error:Can Not Delete ZipFolder."
    '        End If

    '        Dim DB As New clsDBNfdMap(connect, transact)
    '        DB.setValue(clsDBNfdMap.keys.LotID, strLotID, "=")
    '        DB.setValue(clsDBNfdMap.allcolumns.Wf, strWfHex, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.Pass, strPass, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.MapStatus, "Stock", "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.Process, strProcess, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.InDate, strNow, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.InOperater, strInOperator, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.MapData, "0x" & BitConverter.ToString(binDatab).Replace("-", ""), "W")
    '        DB.setValue(clsDBNfdMap.allcolumns.STATUS, "00", "w")
    '        ans = DB.DBupdate()
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotUpdate:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Can Not Update."
    '        End If

    '        Dim i As Integer
    '        Dim DB2 As New clsDBProgress(connect, transact)
    '        For i = 1 To MAXFLOW
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            ans = DB2.DBselect()
    '            If ans = "Error: No Record Found" Then
    '                Exit For
    '            End If
    '            If ans Like "Error*" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '        Next
    '        If i = 1 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/IllegalFlowNo:" & ans, HEADER) 'ERROR
    '            Return "Error:Illegal FlowNo."
    '        End If

    '        DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '        DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i - 1), "=")
    '        DB2.setValue(clsDBProgress.allcolumns.Progress, "Finish", "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndTime, strNow, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndOp, strInOperator, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndPass, strPass, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndMapData, "0x" & BitConverter.ToString(binDatab).Replace("-", ""), "W")
    '        DB2.setValue(clsDBProgress.allcolumns.Status, strStatus, "w")
    '        ans = DB2.DBupdate()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotSetProgress:" & ans, HEADER) 'ERROR
    '            Return "Error:Can Not Set Progress."
    '        End If
    '        strText = DB2.getValue(clsDBProgress.allcolumns.Device) & "," & DB2.getValue(clsDBProgress.allcolumns.AssyLotNo) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.FlowNo) & "," & DB2.getValue(clsDBProgress.allcolumns.FlowName) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.Progress) & "," & DB2.getValue(clsDBProgress.allcolumns.Program) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.Machine) & "," & DB2.getValue(clsDBProgress.allcolumns.Tester) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartTime) & "," & DB2.getValue(clsDBProgress.allcolumns.EndTime) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartOp) & "," & DB2.getValue(clsDBProgress.allcolumns.EndOp) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartPass) & "," & DB2.getValue(clsDBProgress.allcolumns.EndPass)
    '        '	NFDRecordログ出力
    '        addNFDRecord(strLotID, strLotNo, strMapStatus, "Stock", strNow, strInOperator)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/EndInUseLot:" & strErrSig, HEADER)
    '        If StrUseFdd = "1" Then
    '            For Each f As String In System.IO.Directory.GetFiles(strInUseFolder)
    '                fas = System.IO.File.GetAttributes(f)
    '                If ((fas And FileAttribute.Hidden) = FileAttribute.Hidden) Then
    '                    fas = System.IO.FileAttributes.Normal
    '                    System.IO.File.Delete(f)
    '                End If
    '            Next
    '        End If
    '        Return "Error:" & ex.ToString & "," & HEADER & "/EndInUseLot:" & strErrSig
    '    End Try
    '    Return strText
    'End Function

    'Public Shared Function TPEndInUseLot(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                     ByVal strLotID As String, ByVal strLotNo As String, ByVal strMapStatus As String, ByVal strProcess As String, _
    '                                     ByVal strDevice As String, ByVal strPackage As String, ByVal strStatus As String, _
    '                                     ByVal dtNow As DateTime, ByVal strInOperator As String) As String
    '    'return value 
    '    '"Device","AssyLotNo","FlowNo","FlowName","Progress","Program","Machine","Tester","StartTime","EndTime","StartOp","EndOp","StartPass","EndPass": no error
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strLotID & "]:" & strInOperator
    '    Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    '    Dim strText As String = ""
    '    Dim ans As String = ""
    '    Dim strInUseFolder As String = Nfd_mappath_root("NFD_PATH") & "\" & strMapStatus
    '    Dim PathZipFolder As String = Temp_mappath_root() & "\" & strMapStatus & "\" & strLotID
    '    Dim PathZipFile As String = PathZipFolder & "\" & strLotID & ".zip"
    '    Dim fas As FileAttribute

    '    Try
    '        If strMapStatus = "" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TPEndInUseLot/No MapStatus:" & strErrSig, HEADER)
    '            Return "Error:No MapStatus."
    '        End If
    '        If strProcess = "" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TPEndInUseLot/No Process:" & strErrSig, HEADER)
    '            Return "Error:No Process."
    '        End If

    '        clsAntiInjection.checkID(strLotID, strInOperator) '後ろはチェックあまい(日本語とかに使用)
    '        clsAntiInjection.checkID(strLotNo, "DUMMY")
    '        clsAntiInjection.checkID(strMapStatus, "DUMMY")
    '        clsAntiInjection.checkID(strProcess, "DUMMY")

    '        '	指定ロット無かった時はエラー
    '        ans = clsNfdMap.getLotIDStatus(connect, transact, strLotID)
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TPEndInUseLot/GetLotIDStatusError:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Get LotID Status Error:" & ans
    '        ElseIf ans = "" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TPEndInUseLot/LotNotExist:Status[" & ans & "]:" & strErrSig, HEADER)
    '            Return "Error:Lot Not Exist:Status[" & ans & "]"
    '            '	指定ロットがMapStatusに無ければエラー
    '        ElseIf ans <> strMapStatus Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TPEndInUseLot/NoMapStatus:Status[" & ans & "]:" & strErrSig, HEADER)
    '            Return "Error:No Map Status:Status[" & ans & "]"
    '        End If

    '        If System.IO.Directory.Exists(PathZipFolder) Then
    '            deleteFolderAll(PathZipFolder)
    '            If System.IO.Directory.Exists(PathZipFolder) Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/TPEndInUseLot/CanNotDeleteZipFolder:" & strErrSig, HEADER)
    '                Return "Error:Can Not Delete ZipFolder."
    '            End If
    '        End If
    '        createFolder(PathZipFolder)
    '        If System.IO.Directory.GetFiles(PathZipFolder).Length > 0 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TPEndInUseLot/ExistZipFolderAlready:" & strErrSig, HEADER)
    '            Return "Error:Exist ZipFolder Already."
    '        End If

    '        If Not System.IO.Directory.Exists(strInUseFolder) Then createFolder(strInUseFolder)
    '        If System.IO.File.Exists(strInUseFolder & "Log_Sorter_Inorder.txt") Then
    '            deleteFile(strInUseFolder & "Log_Sorter_Inorder.txt")
    '        End If
    '        For Each f As String In System.IO.Directory.GetFiles(strInUseFolder)
    '            fas = System.IO.File.GetAttributes(f)
    '            If ((fas And FileAttribute.ReadOnly) <> FileAttribute.ReadOnly) Then
    '                System.IO.File.Delete(f)
    '            End If
    '        Next

    '        'If Not zipFiles(strInUseFolder, PathZipFile) Then
    '        'deleteFile(PathZipFile)
    '        'clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotzipFile:" & strErrSig, HEADER)
    '        'Return "Error:Can Not zipFile."
    '        'End If

    '        '   ロットデータの整合性チェック（共通）         
    '        'Dim mapclass As clsMapData = clsMap.getMapData(PathZipFile)
    '        'Dim mapclass As MapData = clsMapDataValidateCheck.getMapdata(PathZipFile)
    '        'If mapclass Is Nothing Then
    '        'clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotReadMapdata[" & strInUseFolder & "]:" & strErrSig, HEADER)
    '        'If Not unzipFiles(PathZipFile, strInUseFolder) Then
    '        'deleteFile(PathZipFile)
    '        'clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotUnzipFile:" & strErrSig, HEADER)
    '        'Return "Error:Can Not UnzipFile."
    '        'End If
    '        'Return "Error:Can Not Read Mapdata[" & strInUseFolder & "]"
    '        'End If
    '        'If mapclass.LotNo.ToUpper <> strLotID.ToUpper Then
    '        'clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/LotNoMismatch[map:" & mapclass.LotNo & "]:" & strErrSig, HEADER)
    '        'If Not unzipFiles(PathZipFile, strInUseFolder) Then
    '        'deleteFile(PathZipFile)
    '        'clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotUnzipFile:" & strErrSig, HEADER)
    '        'Return "Error:Can Not UnzipFile."
    '        'End If
    '        'Return "Error:Lot No Mismatch[map:" & mapclass.LotNo & "]"
    '        'End If

    '        strErrSig = "[" & strLotID & "/" & strLotNo & "]to[" & strMapStatus & "]:" & strInOperator

    '        '   ＭＡＰデータ BackUp
    '        'ans = BackUpLot(strLotID, strProcess, PathZipFolder, dtNow, strInOperator)
    '        'If ans <> "True" Then
    '        'clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotBackUpFile:" & ans & ":" & strErrSig, HEADER)
    '        'MessageBox.Show("Can not Backup. Please contact administrator.", "BACKUP ERROR", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
    '        'If Not unzipFiles(PathZipFile, strInUseFolder) Then
    '        'deleteFile(PathZipFile)
    '        'clsErrorLog.addlogWT("Error:" & HEADER & "/EndInUseLot/CanNotUnzipFile:" & strErrSig, HEADER)
    '        'Return "Error:Can Not UnzipFile."
    '        'End If
    '        'Return "Error:Can Not BackUp File."
    '        'End If
    '        'Dim binDatab As Byte() = My.Computer.FileSystem.ReadAllBytes(PathZipFile)
    '        'Dim strWfHex As String = (clsWaHexConverter.BinToHex(mapclass.WaferList()))
    '        'Dim strPass As String = CStr(mapclass.PassTotal)
    '        deleteFolderAll(PathZipFolder)
    '        If System.IO.Directory.Exists(PathZipFolder) Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpEndInUseLot/CanNotDeleteZipFolder:" & strErrSig, HEADER)
    '            Return "Error:Can Not Delete ZipFolder."
    '        End If

    '        Dim DB As New clsDBNfdMap(connect, transact)
    '        DB.setValue(clsDBNfdMap.keys.LotID, strLotID, "=")
    '        'DB.setValue(clsDBNfdMap.allcolumns.Wf, strWfHex, "w")
    '        'DB.setValue(clsDBNfdMap.allcolumns.Pass, strPass, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.MapStatus, "Stock", "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.Process, strProcess, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.InDate, strNow, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.InOperater, strInOperator, "w")
    '        'DB.setValue(clsDBNfdMap.allcolumns.MapData, "0x" & BitConverter.ToString(binDatab).Replace("-", ""), "W")
    '        DB.setValue(clsDBNfdMap.allcolumns.STATUS, "00", "w")
    '        ans = DB.DBupdate()
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpEndInUseLot/CanNotUpdate:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Can Not Update."
    '        End If

    '        Dim i As Integer
    '        Dim DB2 As New clsDBProgress(connect, transact)
    '        For i = 1 To MAXFLOW
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            ans = DB2.DBselect()
    '            If ans = "Error: No Record Found" Then
    '                Exit For
    '            End If
    '            If ans Like "Error*" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/TpEndInUseLot/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '        Next
    '        If i = 1 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpEndInUseLot/IllegalFlowNo:" & ans, HEADER) 'ERROR
    '            Return "Error:Illegal FlowNo."
    '        End If

    '        DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '        DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i - 1), "=")
    '        DB2.setValue(clsDBProgress.allcolumns.Progress, "Finish", "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndTime, strNow, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndOp, strInOperator, "w")
    '        'DB2.setValue(clsDBProgress.allcolumns.EndPass, strPass, "w")
    '        'DB2.setValue(clsDBProgress.allcolumns.EndMapData, "0x" & BitConverter.ToString(binDatab).Replace("-", ""), "W")
    '        DB2.setValue(clsDBProgress.allcolumns.Status, strStatus, "w")
    '        ans = DB2.DBupdate()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/TpEndInUseLot/CanNotSetProgress:" & ans, HEADER) 'ERROR
    '            Return "Error:Can Not Set Progress."
    '        End If
    '        strText = DB2.getValue(clsDBProgress.allcolumns.Device) & "," & DB2.getValue(clsDBProgress.allcolumns.AssyLotNo) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.FlowNo) & "," & DB2.getValue(clsDBProgress.allcolumns.FlowName) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.Progress) & "," & DB2.getValue(clsDBProgress.allcolumns.Program) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.Machine) & "," & DB2.getValue(clsDBProgress.allcolumns.Tester) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartTime) & "," & DB2.getValue(clsDBProgress.allcolumns.EndTime) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartOp) & "," & DB2.getValue(clsDBProgress.allcolumns.EndOp) & "," & _
    '                  DB2.getValue(clsDBProgress.allcolumns.StartPass) & "," & DB2.getValue(clsDBProgress.allcolumns.EndPass)
    '        '	NFDRecordログ出力
    '        addNFDRecord(strLotID, strLotNo, strMapStatus, "Stock", strNow, strInOperator)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/TpEndInUseLot:" & strErrSig, HEADER)
    '        If StrUseFdd = "1" Then
    '            For Each f As String In System.IO.Directory.GetFiles(strInUseFolder)
    '                fas = System.IO.File.GetAttributes(f)
    '                If ((fas And FileAttribute.Hidden) = FileAttribute.Hidden) Then
    '                    fas = System.IO.FileAttributes.Normal
    '                    System.IO.File.Delete(f)
    '                End If
    '            Next
    '        End If
    '        Return "Error:" & ex.ToString & "," & HEADER & "/TpEndInUseLot:" & strErrSig
    '    End Try
    '    Return strText
    'End Function

    ''LotNo有無確認
    'Public Shared Function GetAssyLotNo(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                    ByVal strLotNo As String) As String
    '    'return value 
    '    '"True" : no error
    '    '"other": fail

    '    Dim ans As String = ""
    '    Dim DB As New clsDBMap_MapData(connect, transact)

    '    Try
    '        clsAntiInjection.checkText(strLotNo, "LotID")
    '        DB.setValue(clsDBMap_MapData.keys.LotNo, strLotNo, "=") 'AssyLotNoのMAP DATA探す
    '        ans = DB.DBselect()
    '        If ans Like "Error*" Then
    '            Return ans
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/GetAssyLotNo", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/GetAssyLotNo"
    '    End Try
    '    Return "True"
    'End Function

    ''登録したＭＡＰデータの削除
    'Public Shared Function CancelLot(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                 ByVal strLotNo As String, ByVal strMapStatus As String, ByVal strProcess As String, _
    '                                 ByVal strBackProcess As String, ByVal strFlowNo As String, ByVal dtNow As DateTime, ByVal strInOperator As String) As String
    '    '    Map削除
    '    '    CancelLot	
    '    '    指定ロット無かった時はエラー
    '    '    MapData削除
    '    '    MapStatus = "Stock"
    '    '    Process = "前工程Process"
    '    '    MapDataは返却しない
    '    'return value 
    '    '"True": no error
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strLotID & "]:" & strInOperator
    '    Dim strLotStartTime As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    '    Dim ans As String = ""

    '    Try
    '        clsAntiInjection.checkID(strLotID, strInOperator) '後ろはチェックあまい(日本語とかに使用)
    '        clsAntiInjection.checkID(strLotNo, "DUMMY")

    '        '	指定ロット無かった時はエラー
    '        Dim DB As New clsDBMap_MapData(connect, transact)
    '        DB.setValue(clsDBMap_MapData.keys.LotNo, strLotNo, "=") 'LotIDの MAP DATAを探す
    '        DB.setValue(clsDBMap_MapData.allcolumns.MapStatus, strMapStatus, "=") 'MapStatus の MAP DATAを探す
    '        DB.setValue(clsDBMap_MapData.allcolumns.Process, strProcess, "=") 'MapStatus strProcess の MAP DATAを探す
    '        ans = DB.DBselect() '上記条件に一致したLotIDを取得
    '        If ans Like "Error*" Then
    '            If ans = "Error: No Record Found" Then  '同じLotNoのMAP DATA なし
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/CancelLot/NotExistLotID:" & ans, HEADER)
    '                Return "Error:Not Exist LotID."
    '            Else
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/CancelLot/CanNotLotID:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not LotID."
    '            End If
    '        End If
    '        If strProcess.ToUpper Like "OS*" And strFlowNo = "0" Then
    '            DB.setValue(clsDBMap_MapData.keys.LotID, strLotID, "=")
    '            ans = DB.DBdelete
    '            If ans <> "True" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/CancelLot/CanNotDelete:" & ans & ":" & strErrSig, HEADER)
    '                Return "Error:Can Not Delete."
    '            End If
    '        Else
    '            DB.setValue(clsDBMap_MapData.keys.LotNo, strLotNo, "=")
    '            DB.setValue(clsDBMap_MapData.allcolumns.MapStatus, "Stock", "w")
    '            DB.setValue(clsDBMap_MapData.allcolumns.Process, strBackProcess, "w")
    '            ans = DB.DBupdate()
    '            If ans <> "True" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/CancelLot/CanNotDelete:" & ans & ":" & strErrSig, HEADER)
    '                Return "Error:Can Not Delete."
    '            End If
    '        End If
    '        '	NFDRecordログ出力
    '        addNFDRecord(strLotID, strLotNo, strMapStatus, "Stock", strStartTime)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/CancelLot:" & strErrSig, HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/CancelLot:" & strErrSig
    '    End Try
    '    Return "True"
    'End Function

    ' ''登録した進捗の削除
    ''Public Shared Function CancelProgress(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    ''                                      ByVal strLotID As String, ByVal strLotNo As String, ByVal strFlowName As String, _
    ''                                      ByVal dtNow As DateTime, ByVal strInOperator As String, ByRef strCancelData As String) As String
    ''    '    Progress削除
    ''    '    CancelProgress	
    ''    '    指定ロット無かった時はエラー
    ''    '    Progress Data削除
    ''    'return value 
    ''    '"Process": 前工程のProcess名
    ''    '"other": fail

    ''    Dim strErrSig As String = "[" & strLotID & "/" & strLotNo & "]:" & strInOperator
    ''    Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    ''    Dim ans As String = ""
    ''    Dim j As Integer = 0
    ''    Dim strBackupProgress = ""
    ''    Dim strinput As String = ""

    ''    Try
    ''        clsAntiInjection.checkID(strLotID, strInOperator) '後ろはチェックあまい(日本語とかに使用)
    ''        clsAntiInjection.checkID(strLotNo, "DUMMY")

    ''        Dim DB As New clsDBProgress(connect, transact)
    ''        For i As Integer = 1 To MAXFLOW
    ''            DB.setValue(clsDBProgress.keys.LotID, strLotID, "=") 'LotIDの Progressを探す
    ''            DB.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    ''            DB.setValue(clsDBProgress.allcolumns.FlowName, "", "")
    ''            ans = DB.DBselect() '上記条件に一致したFlowNoを取得
    ''            If ans Like "Error*" Then
    ''                If ans <> "Error: No Record Found" Then  '同じLotNoのProgress なし
    ''                    clsErrorLog.addlogWT("Error:" & HEADER & "/CancelProgress/CanNotSearchProgress:" & ans, HEADER) 'ERROR
    ''                    Return "Error:Can Not Serach Progress."
    ''                End If
    ''            End If
    ''            If ans = "True" Then
    ''                strinput = DB.getValue(clsDBProgress.allcolumns.FlowName)
    ''                j = j + 1
    ''            End If
    ''            'If strFlowName.ToUpper Like "INPUT" Then
    ''            '    If j > 1 Then
    ''            '        clsErrorLog.addlogWT("Error:" & HEADER & "/CancelProgress/AlreadyProgressThisLotID:" & ans, HEADER) 'ERROR
    ''            '        Return "Error:Already Progress This LotID."
    ''            '    End If
    ''            '    If j = 0 Then
    ''            '        Return strinput
    ''            '    End If
    ''            'Else
    ''            '    If j = 0 Then
    ''            '        Return strinput
    ''            '    End If
    ''            'End If
    ''        Next
    ''        If j > 1 Then
    ''            j = j - 1
    ''            DB.setValue(clsDBProgress.keys.LotID, strLotID, "=") 'LotIDの Progressを探す
    ''            DB.setValue(clsDBProgress.keys.FlowNo, CStr(j), "=")
    ''            ans = DB.DBselect() '上記条件に一致したFlowNoを取得
    ''            If ans Like "Error*" Then
    ''                If ans <> "Error: No Record Found" Then  '同じLotNoのProgress なし
    ''                    clsErrorLog.addlogWT("Error:" & HEADER & "/CancelProgress/CanNotSearchProgress:" & ans, HEADER) 'ERROR
    ''                    Return "Error:Can Not Serach Progress."
    ''                End If
    ''            Else
    ''                strBackupProgress = DB.getValue(clsDBProgress.allcolumns.FlowName)
    ''            End If
    ''        Else
    ''            strBackupProgress = strinput
    ''        End If
    ''        'If strFlowName = "INPUT" Then
    ''        '    strFlowName = strinput
    ''        'End If
    ''        DB.setValue(clsDBProgress.keys.LotID, strLotID, "=") 'LotIDの Progressを探す
    ''        DB.setValue(clsDBProgress.keys.FlowNo, "", "")
    ''        DB.setValue(clsDBProgress.allcolumns.FlowName, strFlowName, "=")
    ''        DB.setValue(clsDBProgress.allcolumns.Device, "", "")
    ''        DB.setValue(clsDBProgress.allcolumns.AssyLotNo, "", "")
    ''        DB.setValue(clsDBProgress.allcolumns.FlowName, "", "")
    ''        DB.setValue(clsDBProgress.allcolumns.Progress, "", "")
    ''        DB.setValue(clsDBProgress.allcolumns.Program, "", "")
    ''        DB.setValue(clsDBProgress.allcolumns.Machine, "", "")
    ''        DB.setValue(clsDBProgress.allcolumns.Tester, "", "")
    ''        DB.setValue(clsDBProgress.allcolumns.StartTime, "", "")
    ''        DB.setValue(clsDBProgress.allcolumns.EndTime, "", "")
    ''        DB.setValue(clsDBProgress.allcolumns.StartOp, "", "")
    ''        DB.setValue(clsDBProgress.allcolumns.EndOp, "", "")
    ''        DB.setValue(clsDBProgress.allcolumns.StartPass, "", "")
    ''        DB.setValue(clsDBProgress.allcolumns.EndPass, "", "")
    ''        ' DB.setValue(clsDBProgress.allcolumns.Progress, "OnGoing", "=")
    ''        ans = DB.DBselect()
    ''        If ans Like "Error*" Then
    ''            If ans = "Error: No Record Found" Then  '同じLotNoのProgressなし
    ''                clsErrorLog.addlogWT("Error:" & HEADER & "/CancelProgress/NotExistProgress:" & ans, HEADER)
    ''                Return "Error:Not Exist Progress."
    ''            Else
    ''                clsErrorLog.addlogWT("Error:" & HEADER & "/CancelProgress/CanNotSelectProgress:" & ans, HEADER) 'ERROR
    ''                Return "Error:Can Not Select Progress."
    ''            End If
    ''        End If
    ''        strCancelData = DB.getValue(clsDBProgress.allcolumns.Device) & "," & DB.getValue(clsDBProgress.allcolumns.AssyLotNo) & "," & _
    ''                        DB.getValue(clsDBProgress.allcolumns.FlowNo) & "," & DB.getValue(clsDBProgress.allcolumns.FlowName) & "," & _
    ''                        DB.getValue(clsDBProgress.allcolumns.Progress) & "," & DB.getValue(clsDBProgress.allcolumns.Program) & "," & _
    ''                        DB.getValue(clsDBProgress.allcolumns.Machine) & "," & DB.getValue(clsDBProgress.allcolumns.Tester) & "," & _
    ''                        DB.getValue(clsDBProgress.allcolumns.StartTime) & "," & DB.getValue(clsDBProgress.allcolumns.EndTime) & "," & _
    ''                        DB.getValue(clsDBProgress.allcolumns.StartOp) & "," & DB.getValue(clsDBProgress.allcolumns.EndOp) & "," & _
    ''                        DB.getValue(clsDBProgress.allcolumns.StartPass) & "," & DB.getValue(clsDBProgress.allcolumns.EndPass)

    ''        DB.setValue(clsDBProgress.keys.LotID, strLotID, "=") 'LotIDの Progressを探す
    ''        DB.setValue(clsDBProgress.keys.FlowNo, "", "")
    ''        DB.setValue(clsDBProgress.allcolumns.FlowName, strFlowName, "=")
    ''        '    DB.setValue(clsDBProgress.allcolumns.Progress, "OnGoing", "=")
    ''        ans = DB.DBdelete()
    ''        If ans Like "Error*" Then
    ''            If ans = "Error: No Record Found" Then  '同じLotNoのProgressなし
    ''                clsErrorLog.addlogWT("Error:" & HEADER & "/CancelProgress/NotExistProgress:" & ans, HEADER)
    ''                Return "Error:Not Exist Progress."
    ''            Else
    ''                clsErrorLog.addlogWT("Error:" & HEADER & "/CancelProgress/CanNotDeleteProgress:" & ans, HEADER) 'ERROR
    ''                Return "Error:Can Not Delete Progress."
    ''            End If
    ''        End If

    ''    Catch ex As Exception
    ''        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/CancelProgress:" & strErrSig, HEADER)
    ''        Return "Error:" & ex.ToString & "," & HEADER & "/CancelProgress:" & strErrSig
    ''    End Try
    ''    Return strBackupProgress
    ''End Function

    ' ''DELETE FLOW
    ''Public Shared Function DeleteFlow(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    ''                                  ByVal strAssyLotNo As String, ByVal strFlowName As String, ByVal strFlowNo As String, ByVal dtNow As DateTime, ByVal strInOperator As String) As String
    ''    'return value 
    ''    '"True" : no error
    ''    '"other": fail

    ''    Dim ans As String = ""
    ''    Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    ''    Dim PathZipFolder As String = Temp_mappath_root() & "\Delete"
    ''    Dim PathZipFile As String = PathZipFolder & "\" & strAssyLotNo & ".zip"

    ''    Try
    ''        If System.IO.Directory.Exists(PathZipFolder) Then
    ''            deleteFolderAll(PathZipFolder)
    ''        End If
    ''        createFolder(PathZipFolder)

    ''        clsAntiInjection.checkID(strAssyLotNo, strInOperator) '後ろはチェックあまい(日本語とかに使用)
    ''        Dim DB2 As New clsDBProgress(connect, transact)
    ''        DB2.setValue(clsDBProgress.keys.LotID, strAssyLotNo, "=") 'LotIDの Progressを探す
    ''        DB2.setValue(clsDBProgress.keys.FlowNo, strFlowNo, "=")
    ''        ans = DB2.DBselect() '上記条件に一致したFlowNoを取得
    ''        If ans Like "Error*" Then
    ''            clsErrorLog.addlogWT("Error:" & HEADER & "/DeleteFlow/CanNotSearchProgress:" & ans, HEADER) 'ERROR
    ''            Return "Error:Can Not Serach Progress."
    ''        End If
    ''        DB2.setValue(clsDBProgress.keys.LotID, strAssyLotNo, "=") 'LotIDの Progressを探す
    ''        DB2.setValue(clsDBProgress.keys.FlowNo, strFlowNo, "=")
    ''        ans = DB2.DBdelete '上記条件に一致したFlowNoを削除
    ''        If ans Like "Error*" Then
    ''            clsErrorLog.addlogWT("Error:" & HEADER & "/DeleteFlow/CanNotDeleteProgress:" & ans, HEADER) 'ERROR
    ''            Return "Error:Can Not Delete Progress."
    ''        End If
    ''        Dim strProcess As String
    ''        Dim DB As New clsDBNfdMap(connect, transact)
    ''        If strFlowNo <> "1" Then
    ''            DB2.setValue(clsDBProgress.keys.LotID, strAssyLotNo, "=") 'LotIDの Progressを探す
    ''            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(CInt(strFlowNo) - 1), "=")
    ''            DB2.setValue(clsDBProgress.allcolumns.FlowName, "", "")
    ''            ans = DB2.DBselect() '上記条件に一致したFlowNoを取得
    ''            If ans Like "Error*" Then
    ''                clsErrorLog.addlogWT("Error:" & HEADER & "/DeleteFlow/CanNotSearchProgress:" & ans, HEADER) 'ERROR
    ''                Return "Error:Can Not Serach Progress."
    ''            End If
    ''            strProcess = DB2.getValue(clsDBProgress.allcolumns.FlowName)
    ''            My.Computer.FileSystem.WriteAllBytes(PathZipFile, _
    ''                                        clsDBNfdMap.HexStringToBytes(DB2.getValue(clsDBProgress.allcolumns.EndMapData)), False)

    ''            ''   ロットデータの整合性チェック（共通）         
    ''            Dim mapclass As clsMapData = clsMap.getMapData(PathZipFile)
    ''            ' Dim mapclass As MapData = clsMapDataValidateCheck.getMapdata(PathZipFile)
    ''            If mapclass Is Nothing Then
    ''                clsErrorLog.addlogWT("Error:" & HEADER & "/DeleteFlow/CanNotReadMapdata[" & PathZipFile & "]", HEADER)
    ''                Return "Error:Can Not Read Mapdata[" & PathZipFolder & "\" & strAssyLotNo & ".xml" & "]"
    ''            End If
    ''            Dim binDatab As Byte() = My.Computer.FileSystem.ReadAllBytes(PathZipFile)
    ''            Dim strWfHex As String = (clsWaHexConverter.BinToHex(mapclass.WaferList()))
    ''            Dim strPass As String = CStr(mapclass.PassTotal)
    ''            DB.setValue(clsDBNfdMap.keys.LotID, strAssyLotNo, "=")
    ''            DB.setValue(clsDBNfdMap.allcolumns.Pass, strPass, "w")
    ''            DB.setValue(clsDBNfdMap.allcolumns.Wf, strWfHex, "w")
    ''            DB.setValue(clsDBNfdMap.allcolumns.MapStatus, "Stock", "w")
    ''            DB.setValue(clsDBNfdMap.allcolumns.Process, strProcess, "w")
    ''            DB.setValue(clsDBNfdMap.allcolumns.InDate, strNow, "w")
    ''            DB.setValue(clsDBNfdMap.allcolumns.InOperater, strInOperator, "w")
    ''            DB.setValue(clsDBNfdMap.allcolumns.MapData, "0x" & BitConverter.ToString(binDatab).Replace("-", ""), "W")
    ''            DB.setValue(clsDBNfdMap.allcolumns.STATUS, "00", "w")
    ''            ans = DB.DBupdate()
    ''            If ans <> "True" Then
    ''                clsErrorLog.addlogWT("Error:" & HEADER & "/DeleteFlow/CanNotUpdate:" & ans, HEADER)
    ''                Return "Error:Can Not Update."
    ''            End If
    ''        Else
    ''            DB.setValue(clsDBNfdMap.keys.LotID, strAssyLotNo, "=")
    ''            ans = DB.DBdelete
    ''            If ans <> "True" Then
    ''                clsErrorLog.addlogWT("Error:" & HEADER & "/DeleteFlow/CanNotDelete:" & ans, HEADER)
    ''                Return "Error:Can Not Delete."
    ''            End If
    ''        End If

    ''    Catch ex As Exception
    ''        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/DeleteFlow", HEADER)
    ''        Return "Error:" & ex.ToString & "," & HEADER & "/DeleteFlow"
    ''    End Try
    ''    Return "True"
    ''End Function

    'CancelStrip
    Public Shared Function CancelASEStrip(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
                                          ByVal strAssyLotNo As String) As String
        'return value 
        '"True" : no error
        '"other": fail

        Dim ans As String = ""
        Dim i As Integer = 0
        Dim j As Integer = 0

        Try
            Dim DB As New clsDBStripMap(connect, transact)

            DB.setValue(clsDBStripMap.allcolumns.AssyLotNo, strAssyLotNo, "=") 'LotIDの Progressを探す
            ans = DB.DBselectItem("StripID")
            If ans Like "Error*" Then
                If ans = "Error: No Record Found" Then Return "True"
                clsErrorLog.addlogWT("Error:" & HEADER & "/CancelStrip/CanNotSearchAssyLotNo:" & ans, HEADER) 'ERROR
                Return "Error:Can Not Serach AssyLotNo."
            End If
            Dim a As String()
            a = ans.Split(",")
            For i = 0 To a.Length - 1
                DB.setValue(clsDBStripMap.keys.StripID, a(i), "=")
                DB.setValue(clsDBStripMap.allcolumns.AssyLotNo, "", "w")
                DB.setValue(clsDBStripMap.allcolumns.RingID, "", "w")
                DB.setValue(clsDBStripMap.allcolumns.CompleteFlag, "0", "w")
                DB.setValue(clsDBStripMap.allcolumns.UseTime, "2000-01-01 00:00:00", "w")
                ans = DB.DBupdate()
                If ans Like "Error*" Then
                    If ans = "Error: No Record Found" Then Exit For
                    clsErrorLog.addlogWT("Error:" & HEADER & "/CancelStrip/CanNotSearchAssyLotNo:" & ans, HEADER) 'ERROR
                    Return "Error:Can Not Serach AssyLotNo."
                End If
            Next

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/CancelStrip", HEADER)
            Return "Error:" & ex.ToString & "," & HEADER & "/CancelStrip"
        End Try
        Return "True"
    End Function

    ''ダウンロードロット
    'Public Shared Function DownLoadLot(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                   ByVal strLotID As String, ByVal CBoxUseFdd As Boolean, ByVal dtNow As DateTime, ByVal strInOperator As String) As String
    '    '持ちだし	(Stock -> Download)
    '    'DownLoadLot	
    '    '	指定ロット無かった時はエラー
    '    '   宛先フォルダーが使用中のときはエラー
    '    '   MapData取得
    '    '   ロットデータの整合性チェック（共通）
    '    '	場所へ移動　(unzip)  NFD\DownLoadフォルダーに展開
    '    '	MapStatus：Stock -> DownLoad　にデータレコードUpdate
    '    '	NFDRecordログ出力
    '    'return value 
    '    '"True": no error
    '    '"other": fail

    '    Dim strErrSig As String = "[" & strLotID & "]:" & strInOperator
    '    Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    '    Dim ans As String = ""
    '    Dim strInUseFolder As String = Nfd_mappath_root("NFD_PATH") & "\DownLoad"
    '    Dim PathZipFolder As String = Temp_mappath_root() & "\DownLoad\" & strLotID
    '    Dim PathZipFile As String = PathZipFolder & "\" & strLotID & ".zip"

    '    Try
    '        If StrUseFdd = "1" Or CBoxUseFdd = True Then 'FDD Mode
    '            strInUseFolder = Nfd_mappath_root("NFD_PATH") & "\DownLoadFDD"
    '            If System.IO.Directory.Exists(strInUseFolder) Then
    '                deleteFolderAll(strInUseFolder)
    '            End If
    '            createFolder(strInUseFolder)
    '            If System.IO.Directory.GetFiles(StrFDDPath).Length > 0 Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/FDNotEmpty", HEADER)
    '                Return "Error:FD Not Empty"
    '            End If
    '        End If
    '        clsAntiInjection.checkID(strLotID, strInOperator) '後ろはチェックあまい(日本語とかに使用)

    '        '	指定ロット無かった時はエラー
    '        ans = clsNfdMap.getLotIDStatus(connect, transact, strLotID)
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/GetLotIDStatusError:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Get LotID Status Error."
    '        ElseIf ans = "" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/LotNotExist:Status[" & ans & "]:" & strErrSig, HEADER)
    '            Return "Error:Lot Not Exist:Status[" & ans & "]"
    '        ElseIf ans <> "Stock" Then  '	Stock以外はエラー
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/LotNotInStock:Status[" & ans & "]:" & strErrSig, HEADER)
    '            Return "Error:Lot Not InStock:Status[" & ans & "]"
    '        End If

    '        '   宛先フォルダーが使用中のときはエラー
    '        If Not System.IO.Directory.Exists(strInUseFolder) Then createFolder(strInUseFolder)
    '        Dim fas As FileAttribute
    '        For Each f As String In System.IO.Directory.GetFiles(strInUseFolder)
    '            fas = File.GetAttributes(f)
    '            If ((fas And FileAttribute.Hidden) = FileAttribute.Hidden) Then
    '                fas = System.IO.FileAttributes.Normal
    '                System.IO.File.Delete(f)
    '            End If
    '        Next
    '        If clsNfdMap.ChkExistReadOnly(strInUseFolder) = False Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/DestinationMachineFolderAlreadyInUse:" & strErrSig, HEADER)
    '            Return "Error:Destination Machine Folder Already InUse."
    '        End If

    '        '   ＭＡＰデータ 取得
    '        If System.IO.Directory.Exists(PathZipFolder) Then
    '            deleteFolderAll(PathZipFolder)
    '            If System.IO.Directory.Exists(PathZipFolder) Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/CanNotDeleteZipFolder:" & strErrSig, HEADER)
    '                Return "Error:Can Not Delete ZipFolder."
    '            End If
    '        End If
    '        createFolder(PathZipFolder)
    '        If System.IO.Directory.GetFiles(PathZipFolder).Length > 0 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/ExistZipFolderAlready:" & strErrSig, HEADER)
    '            Return "Error:Exist ZipFolder Already."
    '        End If
    '        ans = clsNfdMap.getMapData(connect, transact, strLotID, PathZipFolder, PathZipFile)
    '        If ans <> "True" Then
    '            If ans = "" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/LotNotExist:" & ans & ":" & strErrSig, HEADER)
    '                Return "Error:Lot Not Exist."
    '            Else
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/GetMapDataError:" & ans & ":" & strErrSig, HEADER)
    '                Return "Error:Get MapData Error."
    '            End If
    '        End If

    '        '   ロットデータの整合性チェック（共通）
    '        Dim mapclass As clsMapData = clsMap.getMapData(PathZipFile)
    '        'Dim mapclass As MapData = clsMapDataValidateCheck.getMapdata(PathZipFile)
    '        If mapclass Is Nothing Then
    '            deleteFile(PathZipFile)
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/CanNotReadMapdata[" & PathZipFile & "]:" & strErrSig, HEADER)
    '            Return "Error:Can Not Read Mapdata[" & PathZipFile & "]:" & strErrSig
    '        End If
    '        If mapclass.LotNo.ToUpper <> strLotID.ToUpper Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "//DownLoadLot/LotNoMismatch[map:" & mapclass.LotNo & "]:" & strErrSig, HEADER)
    '            Return "Error:Lot No Mismatch[map:" & mapclass.LotNo & "]"
    '        End If

    '        Dim strWfLotNo As String = "NoUse"
    '        'Dim strWfLotNo As String = mapclass.LotNo

    '        '   '場所'へ移動　(unzip)
    '        If Not unzipFiles(PathZipFile, strInUseFolder) Then
    '            deleteFile(PathZipFile)
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/CanNotUnzipFile:" & strErrSig, HEADER)
    '            Return "Error:Can Not UnzipFile."
    '        End If
    '        ''       LOTID.TXT作成
    '        'My.Computer.FileSystem.WriteAllText(strInUseFolder & "\LOTID.TXT", strLotID, False) '上書き
    '        'deleteFolderAll(PathZipFolder)
    '        'If System.IO.Directory.Exists(PathZipFolder) Then
    '        '    clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/CanNotDeleteZipFolder:" & strErrSig, HEADER)
    '        '    Return "Error:Can Not Delete ZipFolder."
    '        'End If

    '        Dim strpass As String = CStr(mapclass.PassTotal)
    '        '	MapStatus：Stock -> '場所'　にデータレコードUpdate
    '        Dim DB As New clsDBNfdMap(connect, transact)
    '        DB.setValue(clsDBNfdMap.keys.LotID, strLotID, "=")
    '        DB.setValue(clsDBNfdMap.allcolumns.MapStatus, "DownLoad", "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.InDate, strNow, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.InOperater, strInOperator, "w")
    '        ans = DB.DBupdate()
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/CanNotUpdate:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Can Not Update."
    '        End If
    '        If StrUseFdd = "1" Or CBoxUseFdd = True Then 'FDD Mode
    '            For Each f As String In System.IO.Directory.GetFiles(strInUseFolder)
    '                fas = System.IO.File.GetAttributes(f)
    '                If ((fas And FileAttribute.ReadOnly) <> FileAttribute.ReadOnly) Then
    '                    System.IO.File.Copy(f, StrFDDPath & "\" & System.IO.Path.GetFileName(f), True)
    '                    System.IO.File.Delete(f)
    '                End If
    '            Next
    '        End If

    '        Dim DB2 As New clsDBProgress(connect, transact)
    '        Dim i As Integer
    '        For i = 1 To MAXFLOW
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            ans = DB2.DBselect()
    '            If ans = "Error: No Record Found" Then
    '                Exit For
    '            End If
    '            If ans Like "Error*" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '        Next
    '        If i = 1 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/IllegalFlowNo:" & ans, HEADER) 'ERROR
    '            Return "Error:Illegal FlowNo."
    '        End If
    '        DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '        DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i - 1), "=")
    '        DB2.setValue(clsDBProgress.allcolumns.Device, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.Package, "", "")
    '        DB2.setValue(clsDBProgress.allcolumns.Status, "", "")
    '        ans = DB2.DBselect()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '            Return "Error:Can Not Check AssyLotNo."
    '        End If

    '        If StrUseFdd = "1" Or CBoxUseFdd = True Then 'FDD Mode
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            DB2.setValue(clsDBProgress.allcolumns.AssyLotNo, strLotID, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.FlowName, "DownLoad", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Progress, "OnGoingFD", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.WfLotNo, strWfLotNo, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Device, DB2.getValue(clsDBProgress.allcolumns.Device), "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Package, DB2.getValue(clsDBProgress.allcolumns.Package), "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Program, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Machine, StrControlPC, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Tester, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartTime, strNow, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndTime, "2000-01-01 00:00:00", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartOp, strInOperator, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndOp, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartPass, strpass, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndPass, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Status, DB2.getValue(clsDBProgress.allcolumns.Status), "w")
    '        Else
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            DB2.setValue(clsDBProgress.allcolumns.AssyLotNo, strLotID, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.FlowName, "DownLoad", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Progress, "OnGoing", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.WfLotNo, strWfLotNo, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Device, DB2.getValue(clsDBProgress.allcolumns.Device), "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Package, DB2.getValue(clsDBProgress.allcolumns.Package), "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Program, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Machine, StrControlPC, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Tester, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartTime, strNow, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndTime, "2000-01-01 00:00:00", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartOp, strInOperator, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndOp, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.StartPass, strpass, "w")
    '            DB2.setValue(clsDBProgress.allcolumns.EndPass, "", "w")
    '            DB2.setValue(clsDBProgress.allcolumns.Status, DB2.getValue(clsDBProgress.allcolumns.Status), "w")
    '        End If
    '        ans = DB2.DBinsert()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/DownLoadLot/CanNotSetProgress:" & ans, HEADER) 'ERROR
    '            Return "Error:DownLoadLot/CanNotSetProgress"
    '        End If

    '        '	NFDRecordログ出力
    '        addNFDRecord(strLotID, strWfLotNo, "Stock", "DownLoad", strNow, strInOperator)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/DownLoadLot:" & strErrSig, HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/DownLoadLot:" & strErrSig
    '    End Try
    '    Return "True"
    'End Function

    ''アップロードロット
    'Public Shared Function UpLoadLot(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                 ByVal strLotID As String, ByVal CBoxUseFdd As Boolean, ByVal dtNow As DateTime, ByVal strInOperator As String) As String
    '    '返却	(DownLoad -> Stock)
    '    'UploadLot	
    '    '   LotID.txt読込
    '    '   LotID.txtのLotIDにMapDataを戻す
    '    '   ロットデータの整合性チェック(共通)
    '    '   戻すべきロット無かった時はエラー
    '    '   指定ロットDownloadじゃない場合はエラー
    '    '   MapStatus：'場所'-> Stock　にデータレコードUpdate
    '    '   MapData Update
    '    '   NFDRecordログ出力

    '    'return value 
    '    '"True": no error
    '    '"other": fail
    '    Dim strErrSig As String = "[ UpLoad ]:" & strInOperator
    '    Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
    '    Dim ans As String = ""
    '    Dim strInUseFolder As String = Nfd_mappath_root("NFD_PATH") & "\" & "\DownLoad"
    '    Dim strPass As String = ""

    '    Try
    '        Dim strMode As String = "1"
    '        ans = BeforUseFDCheck(connect, transact, strLotID)
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/CanNotFlowCheck", HEADER)
    '            Return "Error:Can Not Flow Check."
    '        End If
    '        Dim fas As FileAttribute
    '        If StrUseFdd = "1" Or CBoxUseFdd = True Or ans.ToUpper = "ONGOINGFD" Then 'FDD Mode
    '            strInUseFolder = Nfd_mappath_root("NFD_PATH") & "\DownLoadFDD"
    '            If System.IO.Directory.Exists(strInUseFolder) Then
    '                deleteFolderAll(strInUseFolder)
    '            End If
    '            createFolder(strInUseFolder)
    '            If System.IO.Directory.GetFiles(StrFDDPath).Length = 0 Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/FDIsEmpty", HEADER)
    '                Return "Error:FD is Empty."
    '            End If
    '            '   宛先フォルダーが使用中のときはエラー
    '            If Not System.IO.Directory.Exists(strInUseFolder) Then createFolder(strInUseFolder)
    '            If clsNfdMap.ChkExistReadOnly(strInUseFolder) = False Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/DestinationMachineFolderAlreadyInUse", HEADER)
    '                Return "Error:Destination MachineFolder Already InUse"
    '            End If

    '            For Each f As String In System.IO.Directory.GetFiles(StrFDDPath)
    '                fas = System.IO.File.GetAttributes(f)
    '                If ((fas And FileAttribute.ReadOnly) <> FileAttribute.ReadOnly) Then
    '                    System.IO.File.Copy(f, strInUseFolder & "\" & System.IO.Path.GetFileName(f), True)
    '                End If
    '                System.Windows.Forms.Application.DoEvents()
    '            Next
    '        End If

    '        For Each f As String In System.IO.Directory.GetFiles(strInUseFolder)
    '            fas = System.IO.File.GetAttributes(f)
    '            If ((fas And FileAttribute.Hidden) = FileAttribute.Hidden) Then
    '                fas = System.IO.FileAttributes.Normal
    '                System.IO.File.Delete(f)
    '            End If
    '        Next

    '        '   LOTID.txt読込
    '        'If Not System.IO.File.Exists(strInUseFolder & "\" & "LOTID.txt") Then
    '        'clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/LotIDfileNotExist:" & strErrSig, HEADER)
    '        'Return "Error:LotID file Not Exist."
    '        'End If
    '        'Dim strLotIDFdd As String = My.Computer.FileSystem.ReadAllText(strInUseFolder & "\" & "LOTID.txt", System.Text.Encoding.Default)
    '        'If strLotIDFdd.ToUpper <> strLotID.ToUpper Then
    '        'clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/IllegalLotID", HEADER)
    '        'Return "Error:Illegal LotID."
    '        'End If
    '        Dim DB As New clsDBNfdMap(connect, transact)
    '        DB.setValue(clsDBNfdMap.keys.LotID, strLotID, "=")
    '        DB.setValue(clsDBNfdMap.allcolumns.MapStatus, "", "")
    '        ans = DB.DBselect()
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/NotLotID:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Not LotID."
    '        End If
    '        Dim strLotNo As String = "NoUse"
    '        'Dim strLotNo As String = DB.getValue(clsDBNfdMap.allcolumns.LotNo)
    '        ans = DB.getValue(clsDBNfdMap.allcolumns.MapStatus)

    '        '	指定ロットDownloadじゃない場合はエラー           
    '        If ans <> "DownLoad" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/No MapStatus:Status[" & ans & "]" & strErrSig, HEADER)
    '            Return "Error:No MapStatus:Status[" & ans & "]"
    '        End If

    '        Dim PathZipFolder As String = Temp_mappath_root() & "\DownLoad\" & strLotID
    '        Dim PathZipFile As String = PathZipFolder & "\" & strLotID & ".zip"

    '        If System.IO.Directory.Exists(PathZipFolder) Then
    '            deleteFolderAll(PathZipFolder)
    '            If System.IO.Directory.Exists(PathZipFolder) Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/CanNotDeleteZipFolder:" & strErrSig, HEADER)
    '                Return "Error:Can Not Delete ZipFolder."
    '            End If
    '        End If
    '        createFolder(PathZipFolder)
    '        If System.IO.Directory.GetFiles(PathZipFolder).Length > 0 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/ExistZipFolderAlready]" & strErrSig, HEADER)
    '            Return "Error:Exist ZipFolder Already."
    '        End If

    '        If Not zipFiles(strInUseFolder, PathZipFile) Then
    '            deleteFile(PathZipFile)
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/CanNotzipFile:" & strErrSig, HEADER)
    '            Return "Error:Can Not zipFile."
    '        End If

    '        '   ロットデータの整合性チェック（共通）         
    '        Dim mapclass As clsMapData = clsMap.getMapData(PathZipFile)
    '        'Dim mapclass As MapData = clsMapDataValidateCheck.getMapdata(PathZipFile)
    '        If mapclass Is Nothing Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/CanNotReadMapdata[" & strInUseFolder & "]" & strErrSig, HEADER)
    '            If Not unzipFiles(PathZipFile, strInUseFolder) Then
    '                deleteFile(PathZipFile)
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/CanNotUnzipFile:" & strErrSig, HEADER)
    '                Return "Error:Can Not UnzipFile."
    '            End If
    '            Return "Error:Can Not Read Mapdata[" & strInUseFolder & "]"
    '        End If
    '        Dim mlot As String = mapclass.LotNo.ToUpper
    '        Dim sss As String = strLotID.ToUpper
    '        Dim a As Integer = mapclass.LotNo.ToUpper.IndexOf(strLotID.ToUpper)
    '        Dim b As Integer = strLotID.ToUpper.IndexOf(mapclass.LotNo.ToUpper)
    '        If mapclass.LotNo.ToUpper.IndexOf(strLotID.ToUpper) < 0 And strLotID.ToUpper.IndexOf(mapclass.LotNo.ToUpper) < 0 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/LotNoMismatch[map:" & mapclass.LotNo & "]" & strErrSig, HEADER)
    '            'If Not unzipFiles(PathZipFile, strInUseFolder) Then
    '            '    deleteFile(PathZipFile)
    '            '    clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/CanNotUnzipFile:" & strErrSig, HEADER)
    '            '    Return "Error:Can Not UnzipFile."
    '            'End If
    '            Return "Error:LotNo Mismatch[map:" & mapclass.LotNo & "]"
    '        End If

    '        strErrSig = "[" & strLotID & "/" & strLotNo & "]to[ UpLoad ]:" & strInOperator

    '        Dim binDatab As Byte() = My.Computer.FileSystem.ReadAllBytes(PathZipFile)
    '        Dim strWfHex As String = (clsWaHexConverter.BinToHex(mapclass.WaferList()))
    '        Dim strProcess As String = mapclass.m_autono
    '        strPass = CStr(mapclass.PassTotal)
    '        DB = New clsDBNfdMap(connect, transact)
    '        DB.setValue(clsDBNfdMap.keys.LotID, strLotID, "=")
    '        DB.setValue(clsDBNfdMap.allcolumns.Pass, strPass, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.Wf, strWfHex, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.MapStatus, "Stock", "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.Process, strProcess, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.InDate, strNow, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.InOperater, strInOperator, "w")
    '        DB.setValue(clsDBNfdMap.allcolumns.MapData, "0x" & BitConverter.ToString(binDatab).Replace("-", ""), "W")
    '        DB.setValue(clsDBNfdMap.allcolumns.STATUS, "00", "w")
    '        ans = DB.DBupdate()
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/CanNotUpdate:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:Can Not Update."
    '        End If

    '        '   ＭＡＰデータ BackUp
    '        ans = BackUpLot(strLotID, "DownLoad", PathZipFolder, dtNow, strInOperator)
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/CanNotBackUpFile:" & ans & ":" & strErrSig, HEADER)
    '            MessageBox.Show("Can not Backup. Please contact administrator.", "BACKUP ERROR", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
    '            Return "Error:Can Not BackUpFile."
    '        End If
    '        deleteFolderAll(PathZipFolder)
    '        If System.IO.Directory.Exists(PathZipFolder) Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/CanNotDeleteZipFolder:" & strErrSig, HEADER)
    '            Return "Error:Can Not Delete ZipFolder."
    '        End If

    '        Dim i As Integer
    '        Dim DB2 As New clsDBProgress(connect, transact)
    '        For i = 1 To MAXFLOW
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            ans = DB2.DBselect()
    '            If ans = "Error: No Record Found" Then
    '                Exit For
    '            End If
    '            If ans Like "Error*" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '        Next
    '        If i = 1 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/IllegalFlowNo:" & ans, HEADER) 'ERROR             
    '            Return "Error:Illegal FlowNo."
    '        End If

    '        DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '        DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i - 1), "=")
    '        DB2.setValue(clsDBProgress.allcolumns.FlowName, strProcess & "(UP)", "w")
    '        DB2.setValue(clsDBProgress.allcolumns.Progress, "Finish", "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndTime, strNow, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndOp, strInOperator, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndPass, strPass, "w")
    '        DB2.setValue(clsDBProgress.allcolumns.EndMapData, "0x" & BitConverter.ToString(binDatab).Replace("-", ""), "W")
    '        DB2.setValue(clsDBProgress.allcolumns.Status, "01", "w")
    '        ans = DB2.DBupdate()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/UpLoadLot/CanNotSetProgress:" & ans, HEADER) 'ERROR         
    '            Return "Error:Can Not Set Progress."
    '        End If

    '        '	NFDRecordログ出力
    '        addNFDRecord(strLotID, strLotNo, "DownLoad", "Stock", strNow, strInOperator)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/UpLoadLot:" & strErrSig, HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/UpLoadLot:" & strErrSig
    '    End Try
    '    Return "True"
    'End Function

    ''使用するWfの確認
    'Public Shared Function ChkUseFd(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                ByVal strLotID As String) As String
    '    'return value 
    '    '"FlowName" : no error
    '    '"other": fail

    '    Dim DB2 As New clsDBProgress(connect, transact)
    '    Dim ans As String = ""
    '    Dim i As Integer
    '    Dim strFlowName As String = ""
    '    Dim strTmp As String = ""

    '    Try
    '        For i = 1 To MAXFLOW
    '            DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '            DB2.setValue(clsDBProgress.keys.FlowNo, CStr(i), "=")
    '            ans = DB2.DBselect()
    '            If ans = "Error: No Record Found" Then
    '                Exit For
    '            End If
    '            If ans Like "Error*" Then
    '                clsErrorLog.addlogWT("Error:" & HEADER & "/BeforFlowCheck/CanNotCheckAssyLotNo:" & ans, HEADER) 'ERROR
    '                Return "Error:Can Not Check AssyLotNo."
    '            End If
    '            strTmp = DB2.getValue(clsDBProgress.allcolumns.FlowName)
    '            If strTmp <> "DownLoad" And strTmp <> "UseFD" Then
    '                strFlowName = strTmp
    '            End If
    '        Next
    '        If i = 1 Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/BeforFlowCheck/IllegalFlowNo:" & ans, HEADER) 'ERROR
    '            Return "Error:Illegal FlowNo."
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/BeforFlowCheck", HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/BeforFlowCheck"
    '    End Try
    '    Return strFlowName
    'End Function

    'Public Shared Function ComentsUpDate(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                     ByVal intRow As Integer, ByVal strLotID As String, ByVal strFlowNo As String, ByRef strComents As String) As String

    '    'return value 
    '    '"True" : no error
    '    '"other": fail

    '    Dim ans As String = ""

    '    Try
    '        Dim DB2 As New clsDBProgress(connect, transact)
    '        DB2.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '        DB2.setValue(clsDBProgress.keys.FlowNo, strFlowNo, "=")
    '        DB2.setValue(clsDBProgress.allcolumns.Coments, strComents, "w")
    '        ans = DB2.DBupdate()
    '        If ans Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:" & HEADER & "/ComentsUpDate/CanNotUpDate:" & ans, HEADER) 'ERROR         
    '            Return "Error:CanNot UpDate."
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/ComentsUpDate", HEADER)
    '        Return "Error:CanNot UpDate."
    '    End Try
    '    Return "True"
    'End Function

    ''ログ作成
    'Public Shared Sub addNFDRecord(ByVal strLotID As String, ByVal strLotNo As String, _
    '                               ByVal strStatusFrom As String, ByVal strStatusTo As String, ByVal InDate As String, ByVal InOperator As String)

    '    Dim YMfolder As String = Format(Now(), "yyyyMM")
    '    Dim stbr As New System.Text.StringBuilder

    '    Try
    '        Dim strLogFileName As String = System.IO.Directory.GetCurrentDirectory & "\NFDRecord_" & YMfolder & ".txt"

    '        stbr.Append(strLotID)
    '        stbr.Append(",")
    '        stbr.Append(strLotNo)
    '        stbr.Append(",")
    '        stbr.Append(strStatusFrom)
    '        stbr.Append(",")
    '        stbr.Append(strStatusTo)
    '        stbr.Append(",")
    '        stbr.Append(strLotID)
    '        stbr.Append(",")
    '        stbr.Append(InDate)
    '        stbr.Append(",")
    '        stbr.Append(InOperator)

    '        My.Computer.FileSystem.WriteAllText(strLogFileName, stbr.ToString & vbCrLf, True)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & "/addNFDRecord/[" & stbr.ToString & "]:" & ex.ToString, HEADER)
    '    End Try
    'End Sub

    'オペレーションログ作成
    Private Sub addOpeRecord(ByVal strProcess As String, ByVal strOperationName As String, ByVal strLotNo As String, ByVal InDate As String, _
                                   ByVal InOperator As String)

        Dim YMfolder As String = Format(Now(), "yyyyMM")
        Dim stbr As New System.Text.StringBuilder

        Try
            Dim strLogFileName As String = System.IO.Directory.GetCurrentDirectory & "\OperationRecord_" & YMfolder & ".txt"
            stbr.Append(strProcess)
            stbr.Append(",")
            stbr.Append(strOperationName)
            stbr.Append(",")
            stbr.Append(strLotNo)
            stbr.Append(",")
            stbr.Append(InDate)
            stbr.Append(",")
            stbr.Append(InOperator)
            My.Computer.FileSystem.WriteAllText(strLogFileName, stbr.ToString & vbCrLf, True)

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & HEADER & "/addOpeRecord/[" & stbr.ToString & "]:" & ex.ToString, HEADER)
        End Try
    End Sub

    Private Sub myFileGet(ByRef bytContents As Byte(), ByRef bytInput As Byte, ByVal intAddress As Integer)
        bytInput = bytContents(intAddress - 1)
    End Sub

    Private Sub myFileGet(ByRef bytContents As Byte(), ByRef bytInput() As Byte, ByVal intAddress As Integer)
        Array.Copy(bytContents, intAddress - 1, bytInput, 0, bytInput.Length)
    End Sub

    '' Map Data 取得
    'Public Shared Function getMapData(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '                                  ByVal strLotID As String, ByVal strFlowNo As String, ByVal PathZipFolder As String, ByVal PathZipFile As String) As String
    '    'return value 
    '    '"True": no error
    '    '"other": fail

    '    Dim ans As String = ""

    '    Try
    '        Dim DB As New clsDBProgress(connect, transact)
    '        clsAntiInjection.checkText(strLotID, "LotID")
    '        DB.setValue(clsDBProgress.keys.LotID, strLotID, "=")
    '        DB.setValue(clsDBProgress.keys.FlowNo, strFlowNo, "=")
    '        ans = DB.DBselect()
    '        If ans = "Error: No Record Found" Then
    '            Return ""
    '        ElseIf ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:getMapData/CanNotCheck:" & ans, HEADER)
    '            Return "Error:getMapData/CanNotCheck:" & ans
    '        End If
    '        If System.IO.Directory.Exists(PathZipFolder) Then
    '            deleteFolderAll(PathZipFolder)
    '            If System.IO.Directory.Exists(PathZipFolder) Then
    '                clsErrorLog.addlogWT("Error:getMapData/CanNotDeleteZipFolder", HEADER)
    '                Return "Error:getMapData/CanNotDeleteZipFolder"
    '            End If
    '        End If
    '        createFolder(PathZipFolder)
    '        If System.IO.Directory.GetFiles(PathZipFolder).Length > 0 Then
    '            clsErrorLog.addlogWT("Error:getMapData/ExistZipFolderAlready", HEADER)
    '            Return "Error:getMapData/ExistZipFolderAlready"
    '        End If

    '        My.Computer.FileSystem.WriteAllBytes(PathZipFile, _
    '                                    clsDBNfdMap.HexStringToBytes(DB.getValue(clsDBProgress.allcolumns.EndMapData)), False)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/getMapData: " & strLotID, HEADER)
    '        Return "Error:" & ex.ToString & "," & HEADER & "/getMapData:" & strLotID
    '    End Try
    '    Return "True"
    'End Function

    Public Shared Function BackUpLot(ByVal strLotID As String, ByVal strProcess As String, _
                                     ByVal strFilePath As String, ByVal dtNow As DateTime) As String

        'バックアップ	(保存)
        'backUpLot	
        '	\BACKUP\YYYYMM\LotID\LotID.dtNow.strProcess.zipに保存
        '	NFDRecordログ出力
        'return value 
        '"True": no error
        '"other": failure

        Dim strErrSig As String = "[" & strLotID & "]:"
        Dim ym As String = Year(dtNow) & Month(dtNow)
        Dim ymdhms As String = Format(dtNow, "yyyyMMddHHmmss")
        'Dim ymdhms As String = ym & Day(dtNow) & Hour(dtNow) & Minute(dtNow) & Second(dtNow)
        Dim strBackUpFolder As String = Nfd_backup_root() & "\" & ym & "\" & strLotID
        Dim strBackUpFile As String = strBackUpFolder & "\" & strLotID & "." & ymdhms & "." & strProcess & ".zip"
        Dim strStockFile As String = strFilePath & "\" & strLotID & ".zip"
        Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")

        Try
            If strProcess = "" Then
                clsErrorLog.addlogWT("Error:BackUpLot/No MapStatus:" & strErrSig, HEADER)
                Return "Error:BackUpLot/No MapStatus:" & strErrSig
            End If

            If Not System.IO.Directory.Exists(strBackUpFolder) Then createFolder(strBackUpFolder)
            Dim ans As String = ""
            If Not System.IO.File.Exists(strStockFile) Then
                clsErrorLog.addlogWT("Error:BackUpLot/NotFile:" & strErrSig, HEADER)
                Return "Error:BackUpLot/NotFile:" & strErrSig
            End If

            copyFileToFile(strStockFile, strBackUpFile)
            If Not System.IO.File.Exists(strBackUpFile) Then
                clsErrorLog.addlogWT("Error:BackUpLot/CanNotCopyBackFile:" & strErrSig, HEADER)
                Return "Error:BackUpLot/CanNotCopyBackFile:" & strErrSig
            End If

            'NFDRecordログ出力()
            addNFDRecord(strLotID, strLotID, strProcess, "BackUp", strNow)

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & ex.ToString & "/BackUpLot" & strErrSig, HEADER)
            Return "Error:" & ex.ToString
        End Try
        Return "True"
    End Function

    ' Map Data 取得
    Public Shared Function GetASEStripMapData(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
                                         ByVal strStripID As String, ByVal strAssyLotNo As String, ByVal strRingID As String) As String
        'return value 
        '"True": no error
        '"other": fail
        Dim PathFile As String = Temp_Strip_root() & "\T" & strRingID & ".MAP"
        Dim dtNow = Now
        Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
        Dim ans As String = ""
        Dim strText As String = ""

        Try
            Dim DB As New clsDBStripMap(connect, transact)
            DB.setValue(clsDBStripMap.keys.StripID, strStripID, "=")
            'DB.setValue(clsDBAseStripMap.allcolumns.CompleteFlag, "1", "<>")
            ans = DB.DBselect()
            If ans = "Error: No Record Found" Then
                Return "Error: No Record Found"
            ElseIf ans <> "True" Then
                clsErrorLog.addlogWT("Error:GetASEStripMapData/CanNotCheck:" & ans, HEADER)
                Return "Error:GetASEStripMapData/CanNotCheck:" & ans
            End If
            DB.setValue(clsDBStripMap.keys.StripID, strStripID, "=")
            DB.setValue(clsDBStripMap.allcolumns.CompleteFlag, "1", "<>")
            ans = DB.DBselect()
            If ans = "Error: No Record Found" Then
                Return "Error: Already Use This StripID"
            ElseIf ans <> "True" Then
                clsErrorLog.addlogWT("Error:GetASEStripMapData/CanNotCheck:" & ans, HEADER)
                Return "Error:GetASEStripMapData/CanNotCheck:" & ans
            End If

            If Not System.IO.Directory.Exists(Temp_Strip_root()) Then
                createFolder(Temp_Strip_root())
            End If
            For Each strfile As String In System.IO.Directory.GetFiles(Temp_Strip_root(), "*.*")
                Dim chkchar As String = "T" & strAssyLotNo
                Dim fname As String = System.IO.Path.GetFileName(strfile)
                Dim a As String = fname.Substring(fname.Length - 3, 3).ToUpper
                If fname.Substring(fname.Length - 3, 3).ToUpper <> "MAP" Or fname.Length <= chkchar.Length Or fname.Substring(0, chkchar.Length).ToUpper <> chkchar.ToUpper Then
                    deleteFile(strfile)
                End If
            Next
            My.Computer.FileSystem.WriteAllBytes(PathFile, _
                                        clsDBMap_MapData.HexStringToBytes(DB.getValue(clsDBStripMap.allcolumns.StripMap)), False)
            DB.setValue(clsDBStripMap.keys.StripID, strStripID, "=")
            DB.setValue(clsDBStripMap.allcolumns.CompleteFlag, "1", "w")
            DB.setValue(clsDBStripMap.allcolumns.RingID, strRingID, "w")
            DB.setValue(clsDBStripMap.allcolumns.AssyLotNo, strAssyLotNo, "w")
            DB.setValue(clsDBStripMap.allcolumns.UseTime, strNow, "w")
            ans = DB.DBupdate()
            If ans <> "True" Then
                clsErrorLog.addlogWT("Error:GetASEStripMapData/CanNotCheck:" & ans, HEADER)
                Return "Error:GetASEStripMapData/CanNotCheck:" & ans
            End If

            strText = DB.getValue(clsDBStripMap.allcolumns.AssyLotNo) & "," & DB.getValue(clsDBStripMap.allcolumns.StripID) & "," & _
                                 DB.getValue(clsDBStripMap.allcolumns.ASELotNo) & "," & DB.getValue(clsDBStripMap.allcolumns.Columns) & "," & _
                                 DB.getValue(clsDBStripMap.allcolumns.Rows) & "," & DB.getValue(clsDBStripMap.allcolumns.RingID) & "," & _
                                 DB.getValue(clsDBStripMap.allcolumns.Pass) & "," & DB.getValue(clsDBStripMap.allcolumns.Ng) & "," & _
                                 DB.getValue(clsDBStripMap.allcolumns.InTime) & "," & DB.getValue(clsDBStripMap.allcolumns.UseTime) & "," & _
                                 DB.getValue(clsDBStripMap.allcolumns.Coments)

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & HEADER & ":" & ex.ToString & "," & HEADER & "/GetASEStripMapData: " & strStripID, HEADER)
            Return "Error:" & ex.ToString & "," & HEADER & "/GetASEStripMapData:" & strStripID
        End Try
        Return strText
    End Function

    'Public Shared Function GetASEStripMapDataAll(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, ByVal strStripID As String, _
    '                              ByVal strLotNo As String, ByVal strRingID As String, ByVal strSTRIP_TEMP_PATH As String) As String

    '    Dim AseLotNo As String = ""
    '    Dim AseStripID As String = ""
    '    Dim ans As String = ""
    '    Dim PathFolder As String = strSTRIP_TEMP_PATH
    '    If Not System.IO.Directory.Exists(PathFolder) Then createFolder(PathFolder)
    '    ans = GetASEStripMapData(connect, transact, strStripID, strLotNo, strRingID, PathFolder)
    '    If ans Like "Error:*" Then
    '        If ans = "Error: No Record Found" Then
    '            clsErrorLog.addlogWT("Error:GetStripMapData:" & ans & ": " & strStripID, HEADER)
    '            'clsErrorLog.addlogWT("Error:" & HEADER & "/GetStripMapData:" & ans & strStripID, HEADER)
    '            Return "Error:No Record Found."
    '        Else
    '            clsErrorLog.addlogWT("Error:GetStripMapData:" & ans & ": " & strStripID, HEADER)
    '            'clsErrorLog.addlogWT("Error:" & HEADER & ans & "  " & strStripID, HEADER)
    '            Return "Error::" & ans
    '        End If
    '    End If
    '    Return "True"
    'End Function

    Public Shared Function XML_Marge(ByVal strMachine As String, ByVal strAssyLotNo As String, ByVal strDevice As String, ByVal strPackage As String, ByVal IntRingQty As Integer, _
                                     ByVal RECIPE_PATH As String, ByVal ZIP_TEMP_PATH As String) As String

        Dim ans As String = ""
        Dim lot As New clsXmlConvert
        Dim lotdata As New clsXmlConvert.LotData
        Dim packagedata As New clsDeviceDataXml
        lotdata.Machine = strMachine
        lotdata.LotNo = strAssyLotNo
        lotdata.Device = strDevice
        lotdata.Package = strPackage
        lotdata.Ring_Qty = IntRingQty
        'If Not System.IO.File.Exists(System.Configuration.ConfigurationManager.AppSettings("RECIPE_PATH") & "\" & strPackage & ".xml") Then
        If Not System.IO.File.Exists(RECIPE_PATH & "\" & strPackage & ".xml") Then
            clsErrorLog.addlogWT("Error:No Package Recipi files./XML_Marge:" & ans, HEADER)
            Return "Error:No Package Recipe files."
        End If
        'If packagedata.LoadData(System.Configuration.ConfigurationManager.AppSettings("RECIPE_PATH") & "\" & strPackage & ".xml") = False Then
        If packagedata.LoadData(RECIPE_PATH & "\" & strPackage & ".xml") = False Then
            clsErrorLog.addlogWT("Error:No Package Recipi files./XML_Marge:" & ans, HEADER)
            Return "Error:No Package Recipe files."
        End If
        lotdata.Device_size_x = packagedata.Device_Size_X
        lotdata.Device_size_y = packagedata.Device_Size_Y
        lotdata.Block_columns = packagedata.Block_Columns
        lotdata.Block_rows = packagedata.Block_Rows
        lotdata.Device_columns = packagedata.Device_Columns
        lotdata.Device_rows = packagedata.Device_Rows

        'Dim strResultPath As String = Nfd_mappath_root(strMachine) & "\" & strLotNo
        Dim strResultPath As String = Strip_root() & "\" & strAssyLotNo
        If Not System.IO.Directory.Exists(strResultPath) Then createFolder(strResultPath)

        'Dim strSerchPath As String = System.Configuration.ConfigurationManager.AppSettings("STRIP_TEMP_PATH")
        Dim strSerchPath As String = Temp_Strip_root()
        If Not System.IO.Directory.Exists(strSerchPath) Then
            If System.IO.Directory.Exists(strResultPath) Then
                deleteFolderAll(strResultPath)
            End If
            clsErrorLog.addlogWT("Error:No SerchPath./XML_Marge:" & ans, HEADER)
            Return "Error:No SerchPath"
        End If
        Dim filecount As Integer = System.IO.Directory.GetFiles(strSerchPath).Length
        If filecount = 0 Then Return "Error:No Convert files."
        If filecount <> IntRingQty Then
            If System.IO.Directory.Exists(strSerchPath) Then
                deleteFolderAll(strSerchPath)
            End If
            If System.IO.Directory.Exists(strResultPath) Then
                deleteFolderAll(strResultPath)
            End If
            clsErrorLog.addlogWT("Error:No Convert files./XML_Marge:" & ans, HEADER)
            Return "Error:No Convert files."
        End If
        ans = lot.XmlConvert(lotdata, strSerchPath, strResultPath, strAssyLotNo)
        If ans Like "Error:*" Then
            If System.IO.Directory.Exists(strSerchPath) Then
                deleteFolderAll(strSerchPath)
            End If
            If System.IO.Directory.Exists(strResultPath) Then
                deleteFolderAll(strResultPath)
            End If
            clsErrorLog.addlogWT("Error:No Good Convert files./XML_Marge:" & ans, HEADER)
            Return "Error:No Good Convert files."
        End If

        Dim dtNow = Now
        Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
        Dim strAutoNo As String = ""
        Dim strpass As String = ""
        Dim strng As String = ""
        'Dim PathZipPath As String = Nfd_mappath_root(strMachine)
        Dim PathZipPath As String = ZIP_TEMP_PATH
        Dim PathZipFile As String = PathZipPath & "\" & strAssyLotNo & ".zip"

        Try
            If System.IO.Directory.Exists(PathZipPath) Then
                deleteFolderAll(PathZipPath)
            End If
            createFolder(PathZipPath)
            If Not zipFiles(strResultPath, PathZipFile) Then
                If System.IO.Directory.Exists(strSerchPath) Then
                    deleteFolderAll(strSerchPath)
                End If
                If System.IO.Directory.Exists(strResultPath) Then
                    deleteFolderAll(strResultPath)
                End If
                If System.IO.Directory.Exists(PathZipPath) Then
                    deleteFolderAll(PathZipPath)
                End If
                clsErrorLog.addlogWT("Error:CanNotzipFile/XML_Marge", HEADER)
                Return "Error:Can Not zipFile"
            End If
            '   ロットデータの整合性チェック（共通）         
            Dim mapclass As clsMapData = clsMap.getMapData(PathZipFile)
            If mapclass Is Nothing Then
                If System.IO.Directory.Exists(strSerchPath) Then
                    deleteFolderAll(strSerchPath)
                End If
                If System.IO.Directory.Exists(strResultPath) Then
                    deleteFolderAll(strResultPath)
                End If
                If System.IO.Directory.Exists(PathZipPath) Then
                    deleteFolderAll(PathZipPath)
                End If
                clsErrorLog.addlogWT("Error:CanNotReadMapdata/XML_Marge[" & strResultPath & "]", HEADER)
                Return "Error:Can Not Read Mapdata[" & strResultPath & "]"
            End If
            Dim strLotID As String = mapclass.LotNo.ToUpper
            If strAssyLotNo.ToUpper <> strLotID Then
                If System.IO.Directory.Exists(strSerchPath) Then
                    deleteFolderAll(strSerchPath)
                End If
                If System.IO.Directory.Exists(strResultPath) Then
                    deleteFolderAll(strResultPath)
                End If
                If System.IO.Directory.Exists(PathZipPath) Then
                    deleteFolderAll(PathZipPath)
                End If
                clsErrorLog.addlogWT("Error:LotNoMismatch/XML_Marge[map:" & mapclass.LotNo & "]", HEADER)
                Return "Error:LotNo Mismatch[map:" & mapclass.LotNo & "]"
            End If
            If System.IO.Directory.Exists(strSerchPath) Then
                deleteFolderAll(strSerchPath)
            End If
            If System.IO.Directory.Exists(strResultPath) Then
                deleteFolderAll(strResultPath)
            End If
        Catch ex As Exception
            If System.IO.Directory.Exists(strSerchPath) Then
                deleteFolderAll(strSerchPath)
            End If
            If System.IO.Directory.Exists(strResultPath) Then
                deleteFolderAll(strResultPath)
            End If
            If System.IO.Directory.Exists(PathZipPath) Then
                deleteFolderAll(PathZipPath)
            End If
            clsErrorLog.addlogWT("Error:" & ex.ToString & "/XML_Marge", HEADER)
            Return "Error:" & ex.ToString
        End Try
        Return "True"
    End Function

    Private Shared Sub addNFDRecord(ByVal strLotID As String, ByVal strLotNo As String, _
                ByVal strStatusFrom As String, ByVal strStatusTo As String, ByVal InDate As String)

        Dim YMfolder As String = Format(Now(), "yyyyMM")


        Dim stbr As New System.Text.StringBuilder
        Try
            Dim strLogFileName As String = Temp_mappath_root() & "\NFDRecord_" & YMfolder & ".txt"
            'Dim MappedLogFileName As String = System.Web.HttpContext.Current.Server.MapPath(strLogFileName)
            'If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(MappedLogFileName)) Then
            'System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(MappedLogFileName))
            'End If

            stbr.Append(strLotID)
            stbr.Append(",")
            stbr.Append(strLotNo)
            stbr.Append(",")
            stbr.Append(strStatusFrom)
            stbr.Append(",")
            stbr.Append(strStatusTo)
            stbr.Append(",")
            stbr.Append(strLotID)
            stbr.Append(",")
            stbr.Append(InDate)
            'stbr.Append(",")
            'stbr.Append(MainSub.ToString)
            'My.Computer.FileSystem.WriteAllText(MappedLogFileName, stbr.ToString & vbCrLf, True)
            My.Computer.FileSystem.WriteAllText(strLogFileName, stbr.ToString & vbCrLf, True)
        Catch ex As Exception
            clsErrorLog.addlogWT("Error:addNFDRecord/[" & stbr.ToString & "]:" & ex.ToString, HEADER)
        Finally
        End Try

    End Sub
End Class
