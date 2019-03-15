'Client socket

'command option/ as _commandList
'"COMMANDKEY","S tab [message] tab R tab tab [S|R] [message] tab ..." 

Imports System
Imports System.Net
Imports System.Net.Sockets
Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Threading

Public Class ClientSocket
    Private Shared testmode As Boolean = False
    Private Shared testmodeDeep As Boolean = False
    Private Shared logOutput As Boolean = False
    Private Shared sockType As SocketType = SocketType.Stream
    Private Shared sockProtocol As ProtocolType = ProtocolType.Tcp
    Private Shared remotePort As Integer = 26000
    Private Shared bufferSize As Integer = 1024
    Const ENDSEPARATOR As String = vbCrLf

    'returnMessageMode/ テスト用作業返答モード
    'Dim waitSecondReturn As Double = 0.5

    Private Shared timeoutForSend As Integer = 6 'sec
    Private Shared timeoutForReceive As Integer = 6 'sec
    Private Shared timeoutForConnect As Integer = 6 'sec
    Private Shared ReceiveWaitSecond As Integer = 0.4
    Private Shared CommandWaitSecond As Integer = 0.4
    Const LOGGROUP As String = "Client"

    'ソケット受信する (チェックサムの追加は呼び出し側で行う事)
    'Fail時、Falseを返す
    Private Shared Function socketReceive(ByRef childsocket As Socket, ByRef strRecv As String) As Boolean
        If testmodeDeep Then clsOperLog.addlog("Recv11", "Socket" & LOGGROUP)
        If childsocket Is Nothing Then Return False
        If testmodeDeep Then clsOperLog.addlog("Recv12", "Socket" & LOGGROUP)
        Dim receiveBuffer(bufferSize) As Byte
        Dim rc As Integer
        strRecv = ""
        Dim tnow As Long = Now.Ticks
        While (True)
            If testmodeDeep Then clsOperLog.addlog("Recv21", "Socket" & LOGGROUP)
            Try
                If testmodeDeep Then clsOperLog.addlog("Recv22", "Socket" & LOGGROUP)
                If testmodeDeep Then clsOperLog.addlog(childsocket.Connected, "Socket" & LOGGROUP)
                If testmodeDeep Then clsOperLog.addlog(childsocket.LocalEndPoint.ToString, "Socket" & LOGGROUP)
                If testmodeDeep Then clsOperLog.addlog(childsocket.ReceiveTimeout.ToString, "Socket" & LOGGROUP)
                If testmodeDeep Then clsOperLog.addlog(childsocket.RemoteEndPoint.ToString, "Socket" & LOGGROUP)
                If testmodeDeep Then clsOperLog.addlog(childsocket.Ttl.ToString, "Socket" & LOGGROUP)
                If testmodeDeep Then clsOperLog.addlog(Now.ToLongTimeString, "Socket" & LOGGROUP)
                rc = childsocket.Receive(receiveBuffer)

            Catch ex As SocketException
                If testmodeDeep Then clsOperLog.addlog(Now.ToLongTimeString, "Socket" & LOGGROUP)
                If testmodeDeep Then clsOperLog.addlog("Recv23", "Socket" & LOGGROUP)
                'If logOutput Then clsErrorLog.addlogWT(LOGGROUP & ": sockettimeout0 " & ex.ToString, "Socket" & LOGGROUP)
                'Return False 'socket timeout      need to wait until data comes!!!
            End Try
            If testmodeDeep Then clsOperLog.addlog("Recv24", "Socket" & LOGGROUP)
            If (rc = 0) Then
                If testmodeDeep Then clsOperLog.addlog("Recv25", "Socket" & LOGGROUP)
                If tnow < Now.AddSeconds(-1 * timeoutForReceive).Ticks Then
                    If testmodeDeep Then clsOperLog.addlog("Recv26", "Socket" & LOGGROUP)
                    If logOutput Then clsErrorLog.addlogWT(LOGGROUP & ": sockettimeout byTicks", "Socket" & LOGGROUP)
                    Return False 'socket timeout
                End If
                'Exit While
                If testmodeDeep Then clsOperLog.addlog("Recv27", "Socket" & LOGGROUP)
                Thread.Sleep(ReceiveWaitSecond * 1000)
            Else
                If testmodeDeep Then clsOperLog.addlog("Recv28", "Socket" & LOGGROUP)
                If testmode Then clsOperLog.addlog(LOGGROUP & ": Read " & rc.ToString & " bytes", "Socket" & LOGGROUP)
            End If
            If testmodeDeep Then clsOperLog.addlog("Recv29", "Socket" & LOGGROUP)
            Dim d As System.Text.Decoder = System.Text.Encoding.ASCII.GetDecoder
            If testmodeDeep Then clsOperLog.addlog("Recv30", "Socket" & LOGGROUP)
            Dim ans(bufferSize) As Char
            If testmodeDeep Then clsOperLog.addlog("Recv31", "Socket" & LOGGROUP)
            d.GetChars(receiveBuffer, 0, receiveBuffer.Length, ans, 0)
            If testmodeDeep Then clsOperLog.addlog("Recv32", "Socket" & LOGGROUP)
            ReDim Preserve ans(rc - 1)
            If testmodeDeep Then clsOperLog.addlog("Recv33", "Socket" & LOGGROUP)
            strRecv &= New String(ans)
            If testmodeDeep Then clsOperLog.addlog("Recv34", "Socket" & LOGGROUP)
            If testmodeDeep Then clsOperLog.addlog("Recv35:" & strRecv, "Socket" & LOGGROUP)
            If strRecv.IndexOf(ENDSEPARATOR) > -1 Then
                strRecv = strRecv.Substring(0, strRecv.IndexOf(ENDSEPARATOR))
                Exit While
            End If

        End While

        If testmode Then clsOperLog.addlog(LOGGROUP & ": Read [" & strRecv & "]", "Socket" & LOGGROUP)

        Return True
    End Function

    'ソケット送信する (チェックサムの追加は呼び出し側で行う事)
    'Fail時、Falseを返す
    Private Shared Function socketSend(ByRef childsocket As Socket, ByVal strSend As String) As Boolean
        If childsocket Is Nothing Then Return False
        Dim sendBuffer(bufferSize) As Byte
        Dim rc As Integer

        ' Send the indicated number of response messages
        If testmode Then clsOperLog.addlogWT(LOGGROUP & ": Ready to send using Send()...", "Socket" & LOGGROUP)

        sendBuffer = System.Text.Encoding.ASCII.GetBytes(strSend)
        Try
            rc = childsocket.Send(sendBuffer)
        Catch ex As SocketException
            If logOutput Then clsErrorLog.addlogWT(LOGGROUP & ": sockettimeout " & ex.ToString, "Socket" & LOGGROUP)
            Return False 'socket timeout
        End Try
        If testmode Then clsOperLog.addlogWT(LOGGROUP & ": Sent {" & rc.ToString & "} bytes", "Socket" & LOGGROUP)

        Return True
    End Function


    'Usage
    'SendCommands(ByVal remoteName As String, ByVal strCommands As String) As List(Of String)
    '
    '   remoteName:    set target's Hostname or IP address
    '   strCommands:   set Command(s) with direction. S as send, R as receive. Use as pair. 
    '                   S need a message but R no need. So typical 1 cycle routine is like
    '                   S vbtab [message] vbtab R vbtab vbtab
    '
    '                  (Automatically add/remove the checksum and messageEndTerminator:CrLf)
    '
    '   return:        The List(Of String). [message],[reply],[message],[reply]...
    '                  If connection no good, returns blank list.


    Shared Function SendCommands(ByVal remoteName As String, ByVal strCommands As String) As List(Of String)
        Dim ans As New List(Of String)
        If remoteName = "" Then remoteName = "localhost"
        Dim clientSocket As Socket = Nothing
        Dim resolvedHost As IPHostEntry = Nothing
        Dim destination As IPEndPoint = Nothing
        Dim theCommands() As String = strCommands.Split(vbTab)
        Dim strSend As String = ""
        Dim strRecv As String = ""
        Dim myCmd As New clsCommandEncode

        Try
            ' Try to resolve the remote host name or address
            resolvedHost = Dns.GetHostEntry(remoteName)
            If testmode Then clsOperLog.addlogWT(LOGGROUP & ": GetHostEntry() is OK...", "SocketClient")

            ' Try each address returned
            Dim addr As IPAddress
            For Each addr In resolvedHost.AddressList
                'IPv4 Only
                If addr.AddressFamily = AddressFamily.InterNetwork Then


                    ' Create a socket corresponding to the address family of the resolved address
                    clientSocket = New Socket(addr.AddressFamily, sockType, sockProtocol)
                    If testmode Then clsOperLog.addlogWT(LOGGROUP & ": Socket() is OK...", "SocketClient")

                    Try
                        ' Create the endpoint that describes the destination
                        destination = New IPEndPoint(addr, remotePort)
                        If testmode Then clsOperLog.addlogWT(LOGGROUP & ": IPEndPoint() for the destination is OK...", "SocketClient")

                        If testmode Then clsOperLog.addlogWT(LOGGROUP & ": Attempting connection to: {" & destination.ToString() & "}", "SocketClient")

                        'clientSocket.Connect(destination)
                        clientSocket.Blocking = False
                        Dim asr As IAsyncResult = clientSocket.BeginConnect(destination, Nothing, Nothing)
                        If asr.AsyncWaitHandle.WaitOne(1000 * timeoutForConnect, True) = False Then
                            clientSocket.Close()
                            If logOutput Then clsErrorLog.addlogWT(LOGGROUP & ": Socket error occurred: timeout [" & addr.ToString & "]", "SocketClient")
                            If testmode Then clsOperLog.addlogWT(LOGGROUP & ": Close() is OK...", "SocketClient")
                            clientSocket = Nothing
                            GoTo ContinueConnectLoop
                        End If
                        clientSocket.Blocking = True

                        If testmode Then clsOperLog.addlogWT(LOGGROUP & ": Connect() is OK...", "SocketClient")
                        GoTo BreakConnectLoop

                    Catch err As SocketException
                        ' Connect failed so close the socket and try the next address
                        clientSocket.Close()
                        If testmode Then clsOperLog.addlogWT(LOGGROUP & ": Close() is OK...", "SocketClient")
                        clientSocket = Nothing
                        GoTo ContinueConnectLoop
                    End Try
ContinueConnectLoop:

                End If

            Next
BreakConnectLoop:

        Catch err As SocketException
            If logOutput Then clsErrorLog.addlogWT(LOGGROUP & ": Socket error occurred: {" & err.Message & "}", "SocketClient")
        End Try
        If clientSocket Is Nothing OrElse clientSocket.Connected = False Then
            If logOutput Then clsErrorLog.addlogWT(LOGGROUP & ": Socket error occurred: target not found", "SocketClient")
            Return ans
        End If

        If testmode Then clsOperLog.addlogWT("total command[" & strCommands & "]", "SocketClient")

        Try
            Dim iloop As Integer = 0
            clientSocket.ReceiveTimeout = timeoutForReceive * 1000 / 2 'change to ms, half size for quit
            clientSocket.SendTimeout = timeoutForSend * 1000 / 2 'change to ms, half size for quit
            Dim isMissmatch As Boolean = False
            Do
                If theCommands.Length - 2 < iloop Then Exit Do
                Thread.Sleep(CommandWaitSecond * 1000)
                If testmode Then clsOperLog.addlogWT(LOGGROUP & ": loop " & iloop.ToString, "Socket" & LOGGROUP)
                If theCommands(iloop) = "S" Then
                    strSend = myCmd.getSendString(theCommands(iloop + 1))
                    If testmode Then clsOperLog.addlogWT("send command[" & strSend & "]", "SocketClient")
                    If socketSend(clientSocket, strSend) = False Then GoTo TheRecovery
                    ans.Add(theCommands(iloop + 1))
                    If isMissmatch Then GoTo TheRecovery 'at least, after response
                ElseIf theCommands(iloop) = "R" Then
            	    If testmodeDeep Then clsOperLog.addlog("Recv1", "Socket" & LOGGROUP)
                    If socketReceive(clientSocket, strRecv) = False Then GoTo TheRecovery
            	    If testmodeDeep Then clsOperLog.addlog("Recv2", "Socket" & LOGGROUP)
                    If clsCommandEncode.IsMatchChecksum(strRecv) Then
                        If testmodeDeep Then clsOperLog.addlog("Recv3", "Socket" & LOGGROUP)

                        strRecv = strRecv.Substring(0, strRecv.Length - 2)
                    Else
                        If testmodeDeep Then clsOperLog.addlog("Recv4", "Socket" & LOGGROUP)
                        strRecv = ""
                        If logOutput Then clsErrorLog.addlogWT(LOGGROUP & ": childsocket receive-mismatch " & strRecv, "Socket" & LOGGROUP)
                        isMissmatch = True
                        'GoTo TheRecovery
                    End If
                    ans.Add(strRecv)
                End If
                iloop += 2
            Loop

        Catch err As SocketException
            If logOutput Then clsErrorLog.addlogWT(LOGGROUP & ": Socket send/revc error occurred: {" & err.Message & "}", "SocketClient")
            GoTo TheRecovery
        End Try

Therecovery:
        ' Shutdown the client connection
        Try
            If testmodeDeep Then clsOperLog.addlog("Recv91", "Socket" & LOGGROUP)
            clientSocket.Shutdown(SocketShutdown.Send)
            If testmode Then clsOperLog.addlog(LOGGROUP & ": Shutdown() is OK...", "Socket" & LOGGROUP)
        Catch ex As Exception
            If logOutput Then clsErrorLog.addlogWT(LOGGROUP & ": childsocket shutdown error " & ex.ToString, "Socket" & LOGGROUP)
        End Try
        Try
            If testmodeDeep Then clsOperLog.addlog("Recv92", "Socket" & LOGGROUP)
            clientSocket.Close()
            If testmode Then clsOperLog.addlog(LOGGROUP & ": Close() is OK", "Socket" & LOGGROUP)
        Catch ex As Exception
            If logOutput Then clsErrorLog.addlogWT(LOGGROUP & ": childsocket close error " & ex.ToString, "Socket" & LOGGROUP)
        End Try


        Return ans
    End Function


End Class
