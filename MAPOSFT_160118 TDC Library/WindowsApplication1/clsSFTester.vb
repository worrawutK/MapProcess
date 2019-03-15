'Tester Operation function

'clsDegrade.CommandMode.Primary  :   socket command　　+  DB update
'clsDegrade.CommandMode.Secondary:   (no socket command)  copy DB record from Primary
'
Imports Microsoft.VisualBasic
'Imports clsDBTZTesterStatus

Public Class clsSFTester
    Const HEADER As String = "clsSFTester"
    Const TEMP_PATH_ROOT As String = "\TESTER"

    Const enPowerON As String = "ON"
    Const enPowerOFF As String = "OFF"
    Const enProductYES As String = "YES"
    Const enProductNO As String = "NO"


    Public Shared Function Power(ByVal strTesterName As String, ByVal modeON As Boolean, ByVal strUser As String, ByVal dtNow As DateTime) As String

        'PowerOn/PowerOff:　	[※]PowerOn/Offコマンドを送る
        '                   　	

        'return value 
        '"True": no error
        '"other": failure

        Dim strErrSig As String = "[Power:" & modeON & "/" & strTesterName & "]:" & strUser & ":"

        Try
            clsAntiInjection.checkID(strTesterName, strUser, "Tester")

            Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")

            'Dim c As New clsDBTZTesterStatus(connect, transact)
            Dim ans As String = ""
            Dim strFrom As String = ""
            Dim strTo As String = ""

            'strFrom = getTesterStatus(connect, transact, strTesterName, columns.Power)
            'Select Case strFrom
            '    Case enPowerON
            '        If modeON = True Then Return True
            '    Case enPowerOFF
            '        If modeON = False Then Return True
            '    Case Else
            '        clsErrorLog.addlogWT("Error:Power[" & modeON & "]/TesterNotFound[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
            '        Return "Error:Power[" & modeON & "]/TesterNotFound[" & strTesterName & "]:" & strFrom & ":" & strErrSig
            'End Select

            '　	[※]PowerOn/Offコマンドを送る
            Dim tmpTesterProgramName As String = ""
            Dim tmpProductionMode As String = ""
            Dim tmpPower As String = ""
            Dim tmpID As String = ""
            ans = getTesterCondition(strTesterName, tmpTesterProgramName, tmpProductionMode, tmpPower, tmpID)
            If ans <> "True" Then
                clsErrorLog.addlogWT("Error:TesterConditionCheck/TesterNotReady[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
                Return "Error:TesterConditionCheck/TesterNotReady[" & strTesterName & "]:" & ans & ":" & strErrSig
            End If
            If modeON = True Then
                '既にPowerOnならスキップ
                If tmpPower = enPowerON Then
                    clsErrorLog.addlogWT("Error:Power[" & modeON & "]/AlreadyOn[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
                Else
                    'ProductONならエラー
                    If tmpProductionMode = enProductYES Then
                        clsErrorLog.addlogWT("Error:Power[" & modeON & "]/ProductModeOn[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
                        Return "Error:Power[" & modeON & "]/ProductModeOn[" & strTesterName & "]:" & strFrom & ":" & strErrSig
                    Else
                        Dim strCode As String = "POWER,ON,"
                        Dim strCmd As String = "S" & vbTab & strCode & vbTab & "R" & vbTab & vbTab

                        Dim res As System.Collections.Generic.List(Of String) = ClientSocket.SendCommands(strTesterName, strCmd)
                        Dim MyCmd As New clsCommandEncode
                        If res Is Nothing OrElse res.Count < 1 OrElse (Not res(1).ToUpper Like "SUCCESS," & strCode & "*" And Not res(1).ToUpper Like "START," & strCode & "*") Then
                            clsErrorLog.addlogWT("Error:Power:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig, HEADER)
                            Return "Error:Power:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig
                        End If
                    End If
                End If
            Else
                '既にPowerOnならスキップ
                If tmpPower = enPowerOFF Then
                    clsErrorLog.addlogWT("Error:Power[" & modeON & "]/AlreadyOff[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
                Else
                    'ProductONならエラー
                    If tmpProductionMode = enProductYES Then
                        clsErrorLog.addlogWT("Error:Power[" & modeON & "]/ProductModeOn[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
                        Return "Error:Power[" & modeON & "]/ProductModeOn[" & strTesterName & "]:" & strFrom & ":" & strErrSig
                    Else
                        Dim strCode As String = "POWER,OFF,"
                        Dim strCmd As String = "S" & vbTab & strCode & vbTab & "R" & vbTab & vbTab

                        Dim res As System.Collections.Generic.List(Of String) = ClientSocket.SendCommands(strTesterName, strCmd)
                        Dim MyCmd As New clsCommandEncode
                        If res Is Nothing OrElse res.Count < 1 OrElse (Not res(1).ToUpper Like "SUCCESS," & strCode & "*" And Not res(1).ToUpper Like "START," & strCode & "*") Then
                            clsErrorLog.addlogWT("Error:Power:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig, HEADER)
                            Return "Error:Power:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig
                        End If
                    End If
                End If
            End If


            ''　	DBのPowerステータスを変更する
            'c.setValue(Keys.TesterName, strTesterName, "=")
            'ans = c.DBselect
            'If ans = "Error: No Record Found" Then
            '    clsErrorLog.addlogWT("Error:Power[" & modeON & "]/TesterNotFound[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
            '    Return "Error:Power[" & modeON & "]/TesterNotFound[" & strTesterName & "]:" & ans & ":" & strErrSig
            'ElseIf ans <> "True" Then
            '    clsErrorLog.addlogWT("Error:Power[" & modeON & "]/TesterDBreadError[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
            '    Return "Error:Power[" & modeON & "]/TesterDBreadError[" & strTesterName & "]:" & ans & ":" & strErrSig
            'End If
            'Select Case modeON
            '    Case True
            '        strTo = enPowerON
            '    Case False
            '        strTo = enPowerOFF
            'End Select
            'c.setValue(columns.Power, strTo, "w")

            'ans = c.DBupdate
            'If ans <> "True" Then
            '    clsErrorLog.addlogWT("Error:Power[" & strTo & "]/TesterDBUpdateError[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
            '    Return "Error:Power[" & strTo & "]/TesterDBUpdateError[" & strTesterName & "]:" & ans & ":" & strErrSig
            'End If

            '	SFTRecordログ出力
            addSFTRecord(strTesterName, "Power", strFrom, strTo, strNow, strUser)

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & ex.ToString & "," & "clsSFTester/Power" & strErrSig, HEADER)
            Return "Error:" & ex.ToString
        Finally

        End Try

        Return "True"

    End Function


    Public Shared Function ProductionMode(ByVal strTesterName As String, ByVal modeON As Boolean, ByVal strUser As String, ByVal dtNow As DateTime) As String

        'ProductionModeOn/ProductionModeOff:　	[※]ProductionModeOn/Offコマンドを送る
        '                                   　	

        'return value 
        '"True": no error
        '"other": failure


        Dim strErrSig As String = "[ProductionMode:" & modeON & "/" & strTesterName & "]:" & strUser & ":"

        Try
            clsAntiInjection.checkID(strTesterName, strUser, "Tester")

            Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")

            'Dim c As New clsDBTZTesterStatus(connect, transact)
            Dim ans As String = ""
            Dim strFrom As String = ""
            Dim strTo As String = ""

            'strFrom = getTesterStatus(connect, transact, strTesterName, columns.ProductionMode)
            'Select Case strFrom
            '    Case enProductYES
            '        If modeON = True Then Return True
            '    Case enProductNO
            '        If modeON = False Then Return True
            '    Case Else
            '        clsErrorLog.addlogWT("Error:ProductionMode[" & modeON & "]/TesterNotFound[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
            '        Return "Error:ProductionMode[" & modeON & "]/TesterNotFound[" & strTesterName & "]:" & strFrom & ":" & strErrSig
            'End Select

            '　	[※]ProductionModeOn/Offコマンドを送る
            Dim tmpTesterProgramName As String = ""
            Dim tmpProductionMode As String = ""
            Dim tmpPower As String = ""
            Dim tmpID As String = ""
            ans = getTesterCondition(strTesterName, tmpTesterProgramName, tmpProductionMode, tmpPower, tmpID)
            If ans <> "True" Then
                clsErrorLog.addlogWT("Error:TesterConditionCheck/TesterNotReady[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
                Return "Error:TesterConditionCheck/TesterNotReady[" & strTesterName & "]:" & ans & ":" & strErrSig
            End If
            If modeON = True Then
                '既にProductionModeOnならスキップ
                If tmpProductionMode = enProductYES Then
                    clsErrorLog.addlogWT("Error:Production[" & modeON & "]/AlreadyOn[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
                Else
                    'PowerOFFならエラー
                    If tmpPower = enPowerOFF Then
                        clsErrorLog.addlogWT("Error:Production[" & modeON & "]/PowerOff[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
                        Return "Error:Production[" & modeON & "]/PowerOff[" & strTesterName & "]:" & strFrom & ":" & strErrSig
                    Else
                        Dim strCode As String = "MODECHANGE,PRODUCTION,"
                        Dim strCmd As String = "S" & vbTab & strCode & vbTab & "R" & vbTab & vbTab

                        Dim res As System.Collections.Generic.List(Of String) = ClientSocket.SendCommands(strTesterName, strCmd)
                        Dim MyCmd As New clsCommandEncode
                        If res Is Nothing OrElse res.Count < 1 OrElse (Not res(1).ToUpper Like "SUCCESS," & strCode & "*" And Not res(1).ToUpper Like "START," & strCode & "*") Then
                            clsErrorLog.addlogWT("Error:Production:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig, HEADER)
                            Return "Error:Production:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig
                        End If
                    End If
                End If
            Else
                '既にProductionModeOffならスキップ
                If tmpProductionMode = enProductNO Then
                    clsErrorLog.addlogWT("Error:Production[" & modeON & "]/AlreadyOff[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
                Else
                    'PowerOFFならエラー
                    If tmpPower = enPowerOFF Then
                        clsErrorLog.addlogWT("Error:Production[" & modeON & "]/PowerOff[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
                        Return "Error:Production[" & modeON & "]/PowerOff[" & strTesterName & "]:" & strFrom & ":" & strErrSig
                    Else
                        Dim strCode As String = "MODECHANGE,NONPRODUCTION,"
                        Dim strCmd As String = "S" & vbTab & strCode & vbTab & "R" & vbTab & vbTab

                        Dim res As System.Collections.Generic.List(Of String) = ClientSocket.SendCommands(strTesterName, strCmd)
                        Dim MyCmd As New clsCommandEncode
                        If res Is Nothing OrElse res.Count < 1 OrElse (Not res(1).ToUpper Like "SUCCESS," & strCode & "*" And Not res(1).ToUpper Like "START," & strCode & "*") Then
                            clsErrorLog.addlogWT("Error:Production:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig, HEADER)
                            Return "Error:Production:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig
                        End If
                    End If
                End If
            End If


            ''　	DBのProductionModeステータスを変更する
            'c.setValue(Keys.TesterName, strTesterName, "=")
            'ans = c.DBselect
            'If ans = "Error: No Record Found" Then
            '    clsErrorLog.addlogWT("Error:ProductionMode[" & modeON & "]/TesterNotFound[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
            '    Return "Error:ProductionMode[" & modeON & "]/TesterNotFound[" & strTesterName & "]:" & ans & ":" & strErrSig
            'ElseIf ans <> "True" Then
            '    clsErrorLog.addlogWT("Error:ProductionMode[" & modeON & "]/TesterDBreadError[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
            '    Return "Error:ProductionMode[" & modeON & "]/TesterDBreadError[" & strTesterName & "]:" & ans & ":" & strErrSig
            'End If
            'Select Case modeON
            '    Case True
            '        strTo = enProductYES
            '    Case False
            '        strTo = enProductNO
            'End Select
            'c.setValue(columns.ProductionMode, strTo, "w")

            'ans = c.DBupdate
            'If ans <> "True" Then
            '    clsErrorLog.addlogWT("Error:ProductionMode[" & strTo & "]/TesterDBUpdateError[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
            '    Return "Error:ProductionMode[" & strTo & "]/TesterDBUpdateError[" & strTesterName & "]:" & ans & ":" & strErrSig
            'End If

            '	SFTRecordログ出力
            addSFTRecord(strTesterName, "ProductionMode", strFrom, strTo, strNow, strUser)

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & ex.ToString & "," & "clsSFTester/ProductionMode" & strErrSig, HEADER)
            Return "Error:" & ex.ToString
        Finally

        End Try

        Return "True"

    End Function


    Public Shared Function ProgramLoad(ByVal strTesterName As String, ByVal strProgramName As String, ByVal strUser As String, ByVal dtNow As DateTime) As String

        'ProgramLoad:	[※]ProgramLoadコマンドを送る 

        'return value 
        '"True": no error
        '"other": failure

        strProgramName = strProgramName.ToUpper

        Dim strErrSig As String = "[ProgramLoad:" & strProgramName & "/" & strTesterName & "]:" & strUser & ":"

        Try
            clsAntiInjection.checkID(strTesterName, strUser, "Tester")
            clsAntiInjection.checkText(strProgramName, "ProgramName")

            Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")

            ' Dim c As New clsDBTZTesterStatus(connect, transact)
            Dim ans As String = ""
            Dim strFrom As String = ""
            Dim strTo As String = ""

            'strFrom = getTesterStatus(connect, transact, strTesterName, columns.LoadedProgram)
            'If strFrom = "Error" Then
            '    clsErrorLog.addlogWT("Error:ProgramLoad[" & strProgramName & "]/TesterNotFound[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
            '    Return "Error:ProgramLoad[" & strProgramName & "]/TesterNotFound[" & strTesterName & "]:" & strFrom & ":" & strErrSig
            'ElseIf strFrom Like "Error*" Then
            '    clsErrorLog.addlogWT("Error:ProgramLoad[" & strProgramName & "]/TesterError[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
            '    Return "Error:ProgramLoad[" & strProgramName & "]/TesterError[" & strTesterName & "]:" & strFrom & ":" & strErrSig
            'End If


            '　	[※]ProgramLoadコマンドを送る

            Dim tmpTesterProgramName As String = ""
            Dim tmpProductionMode As String = ""
            Dim tmpPower As String = ""
            Dim tmpID As String = ""
            ans = getTesterCondition(strTesterName, tmpTesterProgramName, tmpProductionMode, tmpPower, tmpID)
            If ans <> "True" Then
                clsErrorLog.addlogWT("Error:TesterConditionCheck/TesterNotReady[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
                Return "Error:TesterConditionCheck/TesterNotReady[" & strTesterName & "]:" & ans & ":" & strErrSig
            End If
            '既にTesterProgram一致ならスキップ
            If tmpTesterProgramName = strProgramName Then
                'clsErrorLog.addlogWT("Error:TesterProgram[" & strProgramName & "]/AlreadyLoaded[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
            Else
                'PowerOFFならエラー
                If tmpPower = enPowerOFF Then
                    clsErrorLog.addlogWT("Error:TesterProgram[" & strProgramName & "]/PowerOff[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
                    Return "Error:TesterProgram[" & strProgramName & "]/PowerOff[" & strTesterName & "]:" & strFrom & ":" & strErrSig
                Else
                    'ProductModeONならエラー
                    If tmpProductionMode = enProductYES Then
                        clsErrorLog.addlogWT("Error:TesterProgram[" & strProgramName & "]/ProductModeOn[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
                        Return "Error:TesterProgram[" & strProgramName & "]/ProductModeOn[" & strTesterName & "]:" & strFrom & ":" & strErrSig
                    Else
                        Dim strCode As String = "LOADPROGRAM," & strProgramName.ToUpper & ","
                        Dim strCmd As String = "S" & vbTab & strCode & vbTab & "R" & vbTab & vbTab

                        Dim res As System.Collections.Generic.List(Of String) = ClientSocket.SendCommands(strTesterName, strCmd)
                        Dim MyCmd As New clsCommandEncode
                        If res Is Nothing OrElse res.Count < 1 OrElse (Not res(1).ToUpper Like "SUCCESS," & strCode & "*" And Not res(1).ToUpper Like "START," & strCode & "*") Then
                            clsErrorLog.addlogWT("Error:ProgramLoad:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig, HEADER)
                            Return "Error:ProgramLoad:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig
                        End If
                    End If
                End If
            End If

            '	SFTRecordログ出力
            addSFTRecord(strTesterName, "ProgramName", strFrom, strProgramName, strNow, strUser)

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & ex.ToString & "," & "clsSFTester/ProgramLoad : " & strErrSig, HEADER)
            Return "Error:" & ex.ToString
        Finally

        End Try

        Return "True"
    End Function

    Public Shared Function ProgramLoadAuto(ByVal strTesterName As String, ByVal strProgramName As String, ByVal strUser As String, ByVal dtNow As DateTime) As String

        'ProgramLoad:	[※]ProgramLoadAutoコマンドを送る (setmenu)
        '
        '   Power   Mode            Action
        '   OFF     OFF     PWR_ON/ LOAD/PRD_ON
        '   ON      ON      PRD_OFF/LOAD/PRD_ON
        '   ON      OFF             LOAD/PRD_ON

        'return value 
        '"True": no error
        '"other": failure

        strProgramName = strProgramName.ToUpper

        Dim strErrSig As String = "[ProgramLoadAuto:" & strProgramName & "/" & strTesterName & "]:" & strUser & ":"

        Try
            clsAntiInjection.checkID(strTesterName, strUser, "Tester")
            clsAntiInjection.checkText(strProgramName, "ProgramName")

            Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")

            'Dim c As New clsDBTZTesterStatus(connect, transact)
            Dim ans As String = ""
            Dim strFrom As String = ""
            Dim strTo As String = ""

            'strFrom = getTesterStatus(connect, transact, strTesterName, columns.LoadedProgram)
            'If strFrom = "Error" Then
            '    clsErrorLog.addlogWT("Error:ProgramLoadAuto[" & strProgramName & "]/TesterNotFound[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
            '    Return "Error:ProgramLoadAuto[" & strProgramName & "]/TesterNotFound[" & strTesterName & "]:" & strFrom & ":" & strErrSig
            'ElseIf strFrom Like "Error*" Then
            '    clsErrorLog.addlogWT("Error:ProgramLoadAuto[" & strProgramName & "]/TesterError[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
            '    Return "Error:ProgramLoadAuto[" & strProgramName & "]/TesterError[" & strTesterName & "]:" & strFrom & ":" & strErrSig
            'End If


            '　	[※]ProgramLoadコマンドを送る
            Dim tmpTesterProgramName As String = ""
            Dim tmpProductionMode As String = ""
            Dim tmpPower As String = ""
            Dim tmpID As String = ""
            ans = getTesterCondition(strTesterName, tmpTesterProgramName, tmpProductionMode, tmpPower, tmpID)
            If ans <> "True" Then
                clsErrorLog.addlogWT("Error:TesterConditionCheck/TesterNotReady[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
                Return "Error:TesterConditionCheck/TesterNotReady[" & strTesterName & "]:" & ans & ":" & strErrSig
            End If
            '既にTesterProgram一致ならスキップ
            If tmpTesterProgramName = strProgramName Then
                'clsErrorLog.addlogWT("Error:TesterProgram[" & strProgramName & "]/AlreadyLoaded[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
                If tmpProductionMode = enProductNO Then
                    Dim strCode As String = "MODECHANGE,PRODUCTION,"
                    Dim strCmd As String = "S" & vbTab & strCode & vbTab & "R" & vbTab & vbTab

                    Dim res As System.Collections.Generic.List(Of String) = ClientSocket.SendCommands(strTesterName, strCmd)
                    Dim MyCmd As New clsCommandEncode
                    If res Is Nothing OrElse res.Count < 1 OrElse (Not res(1).ToUpper Like "SUCCESS," & strCode & "*" And Not res(1).ToUpper Like "START," & strCode & "*") Then
                        clsErrorLog.addlogWT("Error:ProgramLoadAuto(PdON):" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig, HEADER)
                        Return "Error:ProgramLoadAuto(PdON):" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig
                    End If
                    addSFTRecord(strTesterName, "ProductionMode", enProductNO, enProductYES, strNow, strUser)
                End If
            Else
                '   Power   Mode            Action
                '   OFF     OFF     PWR_ON/ LOAD/PRD_ON
                '   ON      ON      PRD_OFF/LOAD/PRD_ON
                '   ON      OFF             LOAD/PRD_ON

                '3-mode
                If tmpPower = enPowerOFF Then
                    Dim strCode As String = "LOADPROGRAM4," & strProgramName.ToUpper & ","
                    Dim strCmd As String = "S" & vbTab & strCode & vbTab & "R" & vbTab & vbTab

                    Dim res As System.Collections.Generic.List(Of String) = ClientSocket.SendCommands(strTesterName, strCmd)
                    Dim MyCmd As New clsCommandEncode
                    If res Is Nothing OrElse res.Count < 1 OrElse (Not res(1).ToUpper Like "SUCCESS," & strCode & "*" And Not res(1).ToUpper Like "START," & strCode & "*") Then
                        clsErrorLog.addlogWT("Error:ProgramLoadAuto4:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig, HEADER)
                        Return "Error:ProgramLoadAuto4:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig
                    End If
                    addSFTRecord(strTesterName, "Power", enPowerOFF, enPowerON, strNow, strUser)
                    addSFTRecord(strTesterName, "ProductionMode", enProductNO, enProductYES, strNow, strUser)
                ElseIf tmpProductionMode = enProductYES Then
                    Dim strCode As String = "LOADPROGRAM3," & strProgramName.ToUpper & ","
                    Dim strCmd As String = "S" & vbTab & strCode & vbTab & "R" & vbTab & vbTab

                    Dim res As System.Collections.Generic.List(Of String) = ClientSocket.SendCommands(strTesterName, strCmd)
                    Dim MyCmd As New clsCommandEncode
                    If res Is Nothing OrElse res.Count < 1 OrElse (Not res(1).ToUpper Like "SUCCESS," & strCode & "*" And Not res(1).ToUpper Like "START," & strCode & "*") Then
                        clsErrorLog.addlogWT("Error:ProgramLoadAuto3:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig, HEADER)
                        Return "Error:ProgramLoadAuto3:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig
                    End If
                Else
                    Dim strCode As String = "LOADPROGRAM2," & strProgramName.ToUpper & ","
                    Dim strCmd As String = "S" & vbTab & strCode & vbTab & "R" & vbTab & vbTab

                    Dim res As System.Collections.Generic.List(Of String) = ClientSocket.SendCommands(strTesterName, strCmd)
                    Dim MyCmd As New clsCommandEncode
                    If res Is Nothing OrElse res.Count < 1 OrElse (Not res(1).ToUpper Like "SUCCESS," & strCode & "*" And Not res(1).ToUpper Like "START," & strCode & "*") Then
                        clsErrorLog.addlogWT("Error:ProgramLoadAuto2:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig, HEADER)
                        Return "Error:ProgramLoadAuto2:" & strCode & "/TesterNotSuccess[" & strTesterName & "]:" & res(1) & ":" & strErrSig
                    End If
                    addSFTRecord(strTesterName, "ProductionMode", enProductNO, enProductYES, strNow, strUser)
                End If
            End If

            ''　	DBのステータスを変更する
            'c.setValue(Keys.TesterName, strTesterName, "=")
            'ans = c.DBselect
            'If ans = "Error: No Record Found" Then
            '    clsErrorLog.addlogWT("Error:ProgramLoadAuto[" & strProgramName & "]/TesterNotFound[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
            '    Return "Error:ProgramLoadAuto[" & strProgramName & "]/TesterNotFound[" & strTesterName & "]:" & ans & ":" & strErrSig
            'ElseIf ans <> "True" Then
            '    clsErrorLog.addlogWT("Error:ProgramLoadAuto[" & strProgramName & "]/TesterDBreadError[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
            '    Return "Error:ProgramLoadAuto[" & strProgramName & "]/TesterDBreadError[" & strTesterName & "]:" & ans & ":" & strErrSig
            'End If
            'c.setValue(columns.ProductionMode, enProductYES, "w")
            'c.setValue(columns.Power, enPowerON, "w")
            'c.setValue(columns.LoadedProgram, strProgramName, "w")

            'ans = c.DBupdate
            'If ans <> "True" Then
            '    clsErrorLog.addlogWT("Error:ProgramLoadAuto[" & strProgramName & "]/TesterDBUpdateError[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
            '    Return "Error:ProgramLoadAuto[" & strProgramName & "]/TesterDBUpdateError[" & strTesterName & "]:" & ans & ":" & strErrSig
            'End If


            '	SFTRecordログ出力
            addSFTRecord(strTesterName, "ProgramLoadAuto : ", strFrom, strProgramName, strNow, strUser)

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & ex.ToString & "," & "clsSFTester/ProgramLoadAuto : " & strErrSig, HEADER)
            Return "Error:" & ex.ToString
        Finally

        End Try

        Return "True"
    End Function


    'Public Shared Function ProgramLoadAccept(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '            ByVal strTesterName As String, ByVal strProgramName As String, ByVal strUser As String, ByVal dtNow As DateTime) As String

    '    'ProgramLoadAccept:	DBのLoadedProgramを変更する
    '    '	（Socketサービスから使用）

    '    'return value 
    '    '"True": no error
    '    '"other": failure

    '    Dim strErrSig As String = "[ProgramLoadAccept:" & strProgramName & "/" & strTesterName & "]:" & strUser & ":"

    '    Try
    '        clsAntiInjection.checkID(strTesterName, strUser, "Tester")
    '        clsAntiInjection.checkText(strProgramName, "ProgramName")

    '        Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")

    '        Dim c As New clsDBTZTesterStatus(connect, transact)
    '        Dim ans As String = ""
    '        Dim strFrom As String = ""

    '        strFrom = getTesterStatus(connect, transact, strTesterName, columns.LoadedProgram)
    '        If strFrom = "Error" Then
    '            clsErrorLog.addlogWT("Error:ProgramLoadAccept[" & strProgramName & "]/TesterNotFound[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
    '            Return "Error:ProgramLoadAccept[" & strProgramName & "]/TesterNotFound[" & strTesterName & "]:" & strFrom & ":" & strErrSig
    '        ElseIf strFrom Like "Error*" Then
    '            clsErrorLog.addlogWT("Error:ProgramLoadAccept[" & strProgramName & "]/TesterError[" & strTesterName & "]:" & strFrom & ":" & strErrSig, HEADER)
    '            Return "Error:ProgramLoadAccept[" & strProgramName & "]/TesterError[" & strTesterName & "]:" & strFrom & ":" & strErrSig
    '        End If


    '        '　	DBのLoadedProgramを変更する
    '        c.setValue(Keys.TesterName, strTesterName, "=")
    '        ans = c.DBselect
    '        If ans = "Error: No Record Found" Then
    '            clsErrorLog.addlogWT("Error:ProgramLoadAccept[" & strProgramName & "]/TesterNotFound[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:ProgramLoadAccept[" & strProgramName & "]/TesterNotFound[" & strTesterName & "]:" & ans & ":" & strErrSig
    '        ElseIf ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:ProgramLoadAccept[" & strProgramName & "]/TesterDBreadError[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:ProgramLoadAccept[" & strProgramName & "]/TesterDBreadError[" & strTesterName & "]:" & ans & ":" & strErrSig
    '        End If
    '        c.setValue(columns.LoadedProgram, strProgramName, "w")

    '        ans = c.DBupdate
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:ProgramLoadAccept[" & strProgramName & "]/TesterDBUpdateError[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:ProgramLoadAccept[" & strProgramName & "]/TesterDBUpdateError[" & strTesterName & "]:" & ans & ":" & strErrSig
    '        End If


    '        '	SFTRecordログ出力
    '        addSFTRecord(strTesterName, "ProgramLoadAccept", strFrom, strProgramName, strNow, strUser)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & ex.ToString & "," & "clsSFTester/ProgramLoadAccept" & strErrSig, HEADER)
    '        Return "Error:" & ex.ToString
    '    Finally

    '    End Try

    '    Return "True"
    'End Function



    'Public Shared Function RefreshStatus(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '            ByVal strTesterName As String, ByRef TesterStatus As clsTesterStatus, ByVal strUser As String, ByVal dtNow As DateTime) As String

    '    'RefreshStatus:	[※]RequestStatusコマンドを送る
    '    '	DBのステータスを変更する

    '    'return value 
    '    '"True": no error
    '    '"other": failure

    '    Dim strErrSig As String = "[RefreshStatus:" & strTesterName & "]:" & strUser & ":"

    '    Try
    '        clsAntiInjection.checkID(strTesterName, strUser, "Tester")

    '        Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")

    '        Dim c As New clsDBTZTesterStatus(connect, transact)
    '        Dim ans As String = ""
    '        Dim TesterStatus0 As New clsTesterStatus

    '        ans = getTesterStatus(connect, transact, strTesterName, TesterStatus0)
    '        If ans = "Error" Then
    '            clsErrorLog.addlogWT("Error:RefreshStatus/TesterNotFound[" & strTesterName & "]" & strErrSig, HEADER)
    '            Return "Error:RefreshStatus/TesterNotFound[" & strTesterName & "]" & strErrSig
    '        ElseIf ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:RefreshStatus/TesterError[" & strTesterName & "]" & strErrSig, HEADER)
    '            Return "Error:RefreshStatus/TesterError[" & strTesterName & "]" & strErrSig
    '        End If
    '        If TesterStatus Is Nothing Then
    '            TesterStatus = New clsTesterStatus
    '            For Each strKey As String In TesterStatus0.Status.Keys
    '                TesterStatus.Status(strKey) = TesterStatus0.Status(strKey)
    '            Next
    '        End If

    '        '　	[※]RequestStatusコマンドを送る
    '        Dim tmpProgramName As String = ""
    '        Dim tmpProductionMode As String = ""
    '        Dim tmpPower As String = ""
    '        Dim tmpTesterID As String = ""
    '        ans = getTesterCondition(strTesterName, tmpProgramName, tmpProductionMode, tmpPower, tmpTesterID)
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:TesterConditionCheck/TesterNotReady[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:TesterConditionCheck/TesterNotReady[" & strTesterName & "]:" & ans & ":" & strErrSig
    '        End If

    '        TesterStatus.Status(clsDBTZTesterStatus.columns.LoadedProgram.ToString) = tmpProgramName
    '        TesterStatus.Status(clsDBTZTesterStatus.columns.ProductionMode.ToString) = tmpProductionMode
    '        TesterStatus.Status(clsDBTZTesterStatus.columns.Power.ToString) = tmpPower
    '        End If

    '        For Each MyKey As clsDBTZTesterStatus.columns In [Enum].GetValues(GetType(clsDBTZTesterStatus.columns))
    '            '　	DBを変更する
    '            If TesterStatus0.Status(MyKey.ToString) <> TesterStatus.Status(MyKey.ToString) Then

    '                c.setValue(Keys.TesterName, strTesterName, "=")
    '                ans = c.DBselect
    '                If ans = "Error: No Record Found" Then
    '                    clsErrorLog.addlogWT("Error:RefreshStatus/TesterNotFound[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
    '                    Return "Error:RefreshStatus/TesterNotFound[" & strTesterName & "]:" & ans & ":" & strErrSig
    '                ElseIf ans <> "True" Then
    '                    clsErrorLog.addlogWT("Error:RefreshStatus/TesterDBreadError[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
    '                    Return "Error:RefreshStatus[/TesterDBreadError[" & strTesterName & "]:" & ans & ":" & strErrSig
    '                End If
    '                c.setValue(MyKey, TesterStatus.Status(MyKey.ToString), "w")

    '                ans = c.DBupdate
    '                If ans <> "True" Then
    '                    clsErrorLog.addlogWT("Error:RefreshStatus/TesterDBUpdateError[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
    '                    Return "Error:RefreshStatus[/TesterDBUpdateError[" & strTesterName & "]:" & ans & ":" & strErrSig
    '                End If
    '                c.setValue(MyKey, "", "")
    '            End If

    '            '	SFTRecordログ出力
    '            addSFTRecord(strTesterName, "RefreshStatus", TesterStatus0.Status(MyKey.ToString), _
    '                TesterStatus.Status(MyKey.ToString), strNow, strUser, modeMainSub, modePriSec)

    '        Next


    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & ex.ToString & "," & "clsSFTester/RefreshStatus" & strErrSig, HEADER)
    '        Return "Error:" & ex.ToString
    '    Finally

    '    End Try

    '    Return "True"
    'End Function

    'Public Shared Function RegistTester(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '            ByVal strTesterName As String, ByVal strUser As String, ByVal dtNow As DateTime) As String

    '    'RegistTester:	テスタを登録する

    '    'return value 
    '    '"True": no error
    '    '"other": failure

    '    Dim strErrSig As String = "[RegistTester:" & strTesterName & "]:" & strUser & ":"

    '    Try
    '        clsAntiInjection.checkID(strTesterName, strUser, "Tester")

    '        Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")

    '        Dim c As New clsDBTZTesterStatus(connect, transact)
    '        Dim ans As String = ""
    '        Dim TesterStatus0 As New clsTesterStatus

    '        ans = getTesterStatus(connect, transact, strTesterName, TesterStatus0)
    '        If ans <> "Error" Then
    '            clsErrorLog.addlogWT("Error:RegistTester/TesterAlreadyExist[" & strTesterName & "]" & strErrSig, HEADER)
    '            Return "Error:RegistTester/TesterAlreadyExist[" & strTesterName & "]" & strErrSig
    '        End If

    '        Dim strIsUsed As String = clsInventoryConverter.getManageType(connect, transact, strTesterName)
    '        If strIsUsed <> "" Then
    '            clsErrorLog.addlogWT("Error:" & strTesterName & " is used as [" & strIsUsed & "]" & ":" & strErrSig, HEADER)
    '            Return "Error:" & strTesterName & " is used as [" & strIsUsed & "]"
    '        End If

    '        c.setValue(Keys.TesterName, strTesterName, "=")
    '        c.setValue(columns.Power, enPowerOFF, "w")
    '        c.setValue(columns.ProductionMode, enProductNO, "w")

    '        ans = c.DBinsert
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:RegistTester/TesterDBInsertError[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:RegistTester/TesterDBInsertError[" & strTesterName & "]:" & ans & ":" & strErrSig
    '        End If

    '        '	SFTRecordログ出力
    '        addSFTRecord(strTesterName, "RegistTester", "", strTesterName, strNow, strUser, modeMainSub)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & ex.ToString & "," & "clsSFTester/RegistTester" & strErrSig, HEADER)
    '        Return "Error:" & ex.ToString
    '    Finally

    '    End Try

    '    Return "True"

    'End Function

    'Public Shared Function UnRegistTester(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '    ByVal modeMainSub As clsDegrade.ServerSite, _
    '    ByVal strTesterName As String, ByVal strUser As String, ByVal dtNow As DateTime) As String

    '    'RegistTester:	テスタを登録解除する

    '    'return value 
    '    '"True": no error
    '    '"other": failure

    '    Dim strErrSig As String = "[UnRegistTester:" & strTesterName & "(" & modeMainSub.ToString & _
    '        ")]:" & strUser & ":"

    '    Try
    '        clsAntiInjection.checkID(strTesterName, strUser, "Tester")

    '        Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")

    '        Dim c As New clsDBTZTesterStatus(connect, transact)
    '        Dim ans As String = ""
    '        Dim TesterStatus0 As New clsTesterStatus

    '        ans = getTesterStatus(connect, transact, strTesterName, TesterStatus0)
    '        If ans = "Error" Then
    '            clsErrorLog.addlogWT("Error:UnRegistTester/TesterNotExist[" & strTesterName & "]" & strErrSig, HEADER)
    '            Return "Error:UnRegistTester/TesterNotExist[" & strTesterName & "]" & strErrSig
    '        End If


    '        c.setValue(keys.TesterName, strTesterName, "=")

    '        ans = c.DBdelete
    '        If ans <> "True" Then
    '            clsErrorLog.addlogWT("Error:UnRegistTester/TesterDBDeleteError[" & strTesterName & "]:" & ans & ":" & strErrSig, HEADER)
    '            Return "Error:UnRegistTester/TesterDBDeleteError[" & strTesterName & "]:" & ans & ":" & strErrSig
    '        End If

    '        '	SFTRecordログ出力
    '        addSFTRecord(strTesterName, "UnRegistTester", "", strTesterName, strNow, strUser, modeMainSub)

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & ex.ToString & "," & "clsSFTester/UnRegistTester" & strErrSig, HEADER)
    '        Return "Error:" & ex.ToString
    '    Finally

    '    End Try

    '    Return "True"

    'End Function



    'Public Shared Function Test(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction) As Boolean
    '    'test mode: Secondary mode (no tester request) only

    '    Dim strTesterName As String = "ICT80-000"
    '    Dim strUser As String = "TESTUSER"
    '    Dim strProgramName As String = "DUMMYPROGRAM"
    '    Dim dtNow As DateTime = Now
    '    Dim ans As String = ""
    '    Dim c As New clsDBTZTesterStatus(connect, transact)
    '    c.setValue(keys.TesterName, strTesterName, "=")
    '    ans = c.DBdelete

    '    Try
    '        UnRegistTester(connect, transact, clsDegrade.ServerSite.MainMachine, _
    '                strTesterName, strUser, dtNow)

    '        '****** UnRegistTester
    '        If UnRegistTester(connect, transact, clsDegrade.ServerSite.MainMachine, _
    '             strTesterName, strUser, dtNow) = "True" Then Return False
    '        If RegistTester(connect, transact, clsDegrade.ServerSite.MainMachine, _
    '                strTesterName, strUser, dtNow) <> "True" Then Return False
    '        If UnRegistTester(connect, transact, clsDegrade.ServerSite.MainMachine, _
    '             strTesterName, strUser, dtNow) <> "True" Then Return False

    '        '****** RegistTester
    '        'OK case
    '        If RegistTester(connect, transact, clsDegrade.ServerSite.MainMachine, _
    '                strTesterName, strUser, dtNow) <> "True" Then Return False
    '        'duplicate error
    '        If RegistTester(connect, transact, clsDegrade.ServerSite.MainMachine, _
    '                 strTesterName, strUser, dtNow) = "True" Then Return False


    '        '****** PowerOn
    '        'Tester not exist
    '        If Power(connect, transact, clsDegrade.ServerSite.MainMachine, clsDegrade.CommandMode.Secondary, _
    '            strTesterName & "-X", True, strUser, dtNow) = "True" Then Return False
    '        'OK case
    '        If Power(connect, transact, clsDegrade.ServerSite.MainMachine, clsDegrade.CommandMode.Secondary, _
    '             strTesterName, True, strUser, dtNow) <> "True" Then Return False

    '        c.setValue(keys.TesterName, strTesterName, "=")
    '        If c.DBselect <> "True" Then Return False
    '        If c.getValue(columns.Power) <> enPowerON Then Return False

    '        '****** PowerOff
    '        'Tester not exist
    '        If Power(connect, transact, clsDegrade.ServerSite.MainMachine, clsDegrade.CommandMode.Secondary, _
    '            strTesterName & "-X", False, strUser, dtNow) = "True" Then Return False
    '        'OK case
    '        If Power(connect, transact, clsDegrade.ServerSite.MainMachine, clsDegrade.CommandMode.Secondary, _
    '            strTesterName, False, strUser, dtNow) <> "True" Then Return False

    '        c.setValue(keys.TesterName, strTesterName, "=")
    '        If c.DBselect <> "True" Then Return False
    '        If c.getValue(columns.Power) <> enPowerOFF Then Return False


    '        '****** ProductionModeYes
    '        'Tester not exist
    '        If ProductionMode(connect, transact, clsDegrade.ServerSite.MainMachine, clsDegrade.CommandMode.Secondary, _
    '            strTesterName & "-X", True, strUser, dtNow) = "True" Then Return False
    '        'OK case
    '        If ProductionMode(connect, transact, clsDegrade.ServerSite.MainMachine, clsDegrade.CommandMode.Secondary, _
    '             strTesterName, True, strUser, dtNow) <> "True" Then Return False

    '        c.setValue(keys.TesterName, strTesterName, "=")
    '        If c.DBselect <> "True" Then Return False
    '        If c.getValue(columns.ProductionMode) <> enProductYES Then Return False

    '        '****** ProductionModeNo
    '        'Tester not exist
    '        If ProductionMode(connect, transact, clsDegrade.ServerSite.MainMachine, clsDegrade.CommandMode.Secondary, _
    '            strTesterName & "-X", False, strUser, dtNow) = "True" Then Return False
    '        'OK case
    '        If ProductionMode(connect, transact, clsDegrade.ServerSite.MainMachine, clsDegrade.CommandMode.Secondary, _
    '            strTesterName, False, strUser, dtNow) <> "True" Then Return False

    '        c.setValue(keys.TesterName, strTesterName, "=")
    '        If c.DBselect <> "True" Then Return False
    '        If c.getValue(columns.ProductionMode) <> enProductNO Then Return False

    '        '****** ProgramLoad
    '        'Tester not exist
    '        If ProgramLoad(connect, transact, clsDegrade.ServerSite.MainMachine, clsDegrade.CommandMode.Secondary, _
    '            strTesterName & "-X", strProgramName, strUser, dtNow) = "True" Then Return False
    '        'OK case
    '        If ProgramLoad(connect, transact, clsDegrade.ServerSite.MainMachine, clsDegrade.CommandMode.Secondary, _
    '            strTesterName, strProgramName, strUser, dtNow) <> "True" Then Return False

    '        '****** ProgramLoadAccept
    '        'Tester not exist
    '        If ProgramLoadAccept(connect, transact, clsDegrade.ServerSite.MainMachine, _
    '            strTesterName & "-X", strProgramName, strUser, dtNow) = "True" Then Return False
    '        'OK case
    '        If ProgramLoadAccept(connect, transact, clsDegrade.ServerSite.MainMachine, _
    '            strTesterName, strProgramName, strUser, dtNow) <> "True" Then Return False

    '        c.setValue(keys.TesterName, strTesterName, "=")
    '        If c.DBselect <> "True" Then Return False
    '        If c.getValue(columns.LoadedProgram) <> strProgramName Then Return False

    '        '****** RefreshStatus
    '        Dim MyTesterStatus As clsTesterStatus
    '        'Status not set yet
    '        If RefreshStatus(connect, transact, clsDegrade.ServerSite.MainMachine, clsDegrade.CommandMode.Secondary, _
    '            strTesterName, Nothing, strUser, dtNow) = "True" Then Return False
    '        MyTesterStatus = New clsTesterStatus
    '        MyTesterStatus.Status("LoadedProgram") = strProgramName & "A"
    '        MyTesterStatus.Status("ErrorStatus") = "ERR"
    '        MyTesterStatus.Status("Power") = enPowerON
    '        MyTesterStatus.Status("ProductionMode") = enProductYES

    '        'Tester not exist
    '        If RefreshStatus(connect, transact, clsDegrade.ServerSite.MainMachine, clsDegrade.CommandMode.Secondary, _
    '            strTesterName & "-X", MyTesterStatus, strUser, dtNow) = "True" Then Return False
    '        'OK case
    '        If RefreshStatus(connect, transact, clsDegrade.ServerSite.MainMachine, clsDegrade.CommandMode.Secondary, _
    '            strTesterName, MyTesterStatus, strUser, dtNow) <> "True" Then Return False

    '        c.setValue(keys.TesterName, strTesterName, "=")
    '        If c.DBselect <> "True" Then Return False
    '        If c.getValue(columns.LoadedProgram) <> strProgramName & "A" Then Return False
    '        If c.getValue(columns.ErrorStatus) <> "ERR" Then Return False
    '        If c.getValue(columns.Power) <> enPowerON Then Return False
    '        If c.getValue(columns.ProductionMode) <> enProductYES Then Return False


    '    Catch ex As Exception
    '        Return False
    '    Finally
    '    End Try

    '    Return True

    'End Function


    'Private Shared Function getTesterStatus(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '    ByVal strTesterName As String, ByVal statusType As clsDBTZTesterStatus.columns) As String
    '    'return value 
    '    '"": no exist
    '    '"Error:*": failure
    '    'other: the status
    '    Dim c As New clsDBTZTesterStatus(connect, transact)
    '    clsAntiInjection.checkText(strTesterName, "strTesterName")

    '    Dim ans As String = ""
    '    c.setValue(keys.TesterName, strTesterName, "=")

    '    ans = c.DBselect
    '    If ans = "Error: No Record Found" Then
    '        Return "Error"
    '    ElseIf ans <> "True" Then
    '        clsErrorLog.addlogWT("Error:getTesterStatus/CanNotCheck[" & statusType & "]:" & ans, HEADER)
    '        Return "Error:getTesterStatus/CanNotCheck[" & statusType & "]:" & ans
    '    End If

    '    Return c.getValue(statusType)
    'End Function

    'Public Shared Function getTesterStatus(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '     ByVal strTesterName As String, ByRef currentStatus As clsTesterStatus) As String
    '    'return value 
    '    '"": no exist
    '    '"Error:*": failure
    '    'true: success
    '    Dim c As New clsDBTZTesterStatus(connect, transact)
    '    clsAntiInjection.checkText(strTesterName, "strTesterName")

    '    Dim ans As String = ""
    '    c.setValue(keys.TesterName, strTesterName, "=")

    '    ans = c.DBselect
    '    If ans = "Error: No Record Found" Then
    '        currentStatus = Nothing
    '        Return "Error"
    '    ElseIf ans <> "True" Then
    '        currentStatus = Nothing
    '        clsErrorLog.addlogWT("Error:getTesterStatus/CanNotCheck[allStatus]:" & ans, HEADER)
    '        Return "Error:getTesterStatus/CanNotCheck[allStatus]:" & ans
    '    End If

    '    currentStatus = New clsTesterStatus
    '    For Each myKey As clsDBTZTesterStatus.allcolumns In [Enum].GetValues(GetType(clsDBTZTesterStatus.allcolumns))
    '        currentStatus.Status(myKey.ToString) = c.getValue(myKey)
    '    Next

    '    Return "True"
    'End Function

    'Public Shared Function IsExist(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction, _
    '    ByVal strTesterName As String) As String

    '    '存在チェック

    '    'return value 
    '    '"True":  Exist
    '    '"False":  Not Exist
    '    '"other": failure
    '    Dim strErrSig As String = "[" & strTesterName & "]:"

    '    Dim c As New clsDBTZTesterStatus(connect, transact)
    '    Dim ans As String = ""


    '    Try
    '        clsAntiInjection.checkID(strTesterName, "DUMMY")

    '        c.setValue(keys.TesterName, strTesterName, "=")

    '        ans = c.DBselect
    '        If ans = "Error: No Record Found" Then
    '            Return "False"
    '        ElseIf ans = "True" Then
    '            Return "True"
    '        Else
    '            Return ans
    '        End If

    '    Catch ex As Exception
    '        clsErrorLog.addlogWT("Error:" & ex.ToString & "," & "clsSFTester/IsExist" & strErrSig, HEADER)
    '        Return "Error:" & ex.ToString
    '    End Try

    'End Function


    Public Shared Function getTesterCondition(ByVal strTesterName As String, ByRef strTesterProgramName As String, _
        ByRef strProductionMode As String, ByRef Power As String, ByRef TesterID As String) As String
        Dim strCmd As String = "S" & vbTab & "REQUESTSTATUS,ALL," & vbTab & "R" & vbTab & vbTab

        Dim res As System.Collections.Generic.List(Of String) = ClientSocket.SendCommands(strTesterName, strCmd)
        Dim MyCmd As New clsCommandEncode
        If res Is Nothing OrElse res.Count < 2 Then
            Dim ans As String = ""
            For Each strC As String In res
                ans &= strC & ":"
            Next
            Return "Error:CannotGetTesterCondition1:" & ans
        ElseIf Not res(1).ToUpper Like "MESSAGE*" Then
            Return "Error:CannotGetProberCondition2:" & res(1)
        Else
            Dim msg As String() = res(1).Split(",")
            If msg Is Nothing OrElse msg.Length < 5 Then
                Dim ans As String = ""
                For Each strC As String In res
                    ans &= strC & ":"
                Next
                Return "Error:CannotGetTesterCondition3:" & ans
            Else
                strTesterProgramName = msg(1)
                strProductionMode = msg(2)
                If strProductionMode.ToUpper = "PRODUCTION" Then
                    strProductionMode = enProductYES
                ElseIf strProductionMode.ToUpper = "NONPRODUCTION" Then
                    strProductionMode = enProductNO
                Else
                    strProductionMode = "ERR"
                End If
                Power = msg(3)
                TesterID = msg(4)
                Return "True"
            End If
        End If
    End Function
    Private Shared Sub addSFTRecord(ByVal strTesterName As String, ByVal strColumnName As String, _
        ByVal strFrom As String, ByVal strTo As String, ByVal InDate As String, _
        ByVal InOperator As String)
        Dim YMfolder As String = Format(Now(), "yyyyMM")

        Dim strLogFileName As String = TEMP_PATH_ROOT & "\TesterRecord_" & YMfolder & ".txt"
        Dim MappedLogFileName As String = Environment.CurrentDirectory & "\" & strLogFileName
        If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(MappedLogFileName)) Then
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(MappedLogFileName))
        End If

        Dim stbr As New System.Text.StringBuilder
        Try
            stbr.Append(strTesterName)
            stbr.Append(",")
            stbr.Append(strColumnName)
            stbr.Append(",")
            stbr.Append(strFrom)
            stbr.Append(",")
            stbr.Append(strTo)
            stbr.Append(",")
            stbr.Append(InDate)
            stbr.Append(",")
            stbr.Append(InOperator)
            stbr.Append(",")
            My.Computer.FileSystem.WriteAllText(MappedLogFileName, stbr.ToString & vbCrLf, True)
        Catch ex As Exception
            clsErrorLog.addlogWT("Error:addSFTRecord/[" & stbr.ToString & "]:" & ex.ToString, HEADER)
        Finally
        End Try

    End Sub


End Class
