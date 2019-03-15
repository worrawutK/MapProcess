'共通ロギングクラス：share only
'Web:LogFileName をConst化
'追加:ヘッダ(Namespace)区分、月別ファイル化

Public Class clsOperLog


    Const LogFileName As String = "~/App_Data/OperLog"
    Private Shared isDetail As Boolean = True             'True:logging detail mode ON   False:OFF

    Public Shared Sub addlogDetail(ByVal strTEXT As String, ByVal strHead As String)
        If Not isDetail Then Exit Sub
        addlog(strTEXT, strHead)
    End Sub
    Public Shared Sub addlogWTDetail(ByVal strTEXT As String, ByVal strHead As String)
        If Not isDetail Then Exit Sub
        addlogWT(strTEXT, strHead)
    End Sub

    Public Shared Sub addlog(ByVal strTEXT As String, ByVal strHead As String) '汎用メッセージロガー
        If LogFileName = Nothing Then Exit Sub
        Dim strLogFileName As String = SelPath & "\LOG\OperLog" & "_" & strHead & "_" & Format(Now(), "yyyyMM") & ".txt"
        Dim MappedLogFileName As String = Environment.CurrentDirectory & "\" & strLogFileName
        Try
            My.Computer.FileSystem.WriteAllText(MappedLogFileName, strTEXT & vbCrLf, True)
        Catch
        Finally
        End Try
        If FileLen(MappedLogFileName) > (1 * 1024 * 1024) Then
            System.IO.File.Delete(MappedLogFileName & ".bak")
            System.IO.File.Move(MappedLogFileName, MappedLogFileName & ".bak")
        End If
    End Sub

    Public Shared Sub addlogWT(ByVal strTEXT As String, ByVal strHead As String) 'addlog With Time
        If LogFileName Is Nothing OrElse LogFileName = "" Then
            Dim e As New System.Exception("clsErrorLog: Not initialized error")
            Throw e
        End If
        If LogFileName = Nothing Then Exit Sub
        Dim strLogFileName As String = LogFileName & "_" & strHead & "_" & Format(Now(), "yyyyMM") & ".txt"
        Dim MappedLogFileName As String = Environment.CurrentDirectory & "\" & strLogFileName
        Try
            My.Computer.FileSystem.WriteAllText(MappedLogFileName, strTEXT & " " & Format(Now(), "yyyy-MM-dd HH:mm:ss") & vbCrLf, True)
           
        Catch ex As Exception

        Finally
        End Try
        If FileLen(MappedLogFileName) > (10 * 1024 * 1024) Then
            System.IO.File.Delete(MappedLogFileName & ".bak")
            System.IO.File.Move(MappedLogFileName, LogFileName & ".bak")
        End If
    End Sub

    Public Shared Sub saveEx(ByVal ex As Exception, ByVal strHead As String)
        If LogFileName Is Nothing OrElse LogFileName = "" Then
            Dim e As New System.Exception("clsErrorLog: Not initialized error")
            Throw e
        End If
        Try
            addlog(ex.Message.ToString & ex.Source.ToString & ex.TargetSite.ToString & _
                ex.StackTrace.ToString & Now.ToShortDateString & " " & Now.ToShortTimeString & _
                "---------------------------------------", strHead)
        Catch
        End Try
    End Sub

End Class
