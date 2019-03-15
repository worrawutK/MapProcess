Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading


'個々のクライアントと交信するためのクラス
Public Class clsSession
    Const HEADER As String = "clsSession"

    'クラス全体で共用する変数の宣言と初期化
    Shared myCount As Integer = 0
    Public Shared mySessionList As ArrayList = New ArrayList()

    'インスタンスが個別に持つ変数の宣言
    Dim mySocket As Socket
    Dim myStream As NetworkStream
    Dim myReader As StreamReader
    Dim myWriter As StreamWriter
    Dim myWriteQueue As Queue
    Dim myWriteSignal As AutoResetEvent
    Dim myWriteLoopFlag As Boolean
    Dim myID As String

    'イベントの宣言
    Event Print(ByVal str As String)
    Event Quit(ByVal session As clsSession)

    'SessionClassの新しいインスタンスを作る
    Sub New(ByVal sock As Socket)

        'ソケットを読み書きする準備
        mySocket = sock
        myStream = New NetworkStream(mySocket)
        myReader = New StreamReader(myStream, Encoding.UTF8)
        myWriter = New StreamWriter(myStream, Encoding.UTF8)
        myWriter.AutoFlush = True
        myWriter.NewLine = vbNewLine

        '送信キュー、配信待ちフラグ、続行フラグを初期化する
        myWriteQueue = New Queue()
        myWriteSignal = New AutoResetEvent(False)
        myWriteLoopFlag = True

        'セッションIDの設定（クライアントのIPアドレス）
        myCount = myCount + 1
        myID = String.Format("{0}", CType(mySocket.RemoteEndPoint, IPEndPoint).Address)

        'このクライアントをリストに追加する
        SyncLock mySessionList.SyncRoot
            mySessionList.Add(Me)
        End SyncLock
    End Sub

    '交信を開始する
    Sub MyStartSession()
        '受信処理を別スレッドで開始する
        Dim readThread As Thread
        readThread = New Thread(AddressOf MyReadLoop)
        readThread.IsBackground = True
        readThread.Start()

        '送信処理を別スレッドで開始する
        Dim writeThread As Thread
        writeThread = New Thread(AddressOf MyWriteLoop)
        writeThread.IsBackground = True
        writeThread.Start()
    End Sub

    '受信用スレッド本体
    Sub MyReadLoop()

        '変数の宣言
        Dim myRecvData As String
        'Dim mySendData As String
        'Dim strCommand As String()
        'Dim strCmd As String
        'Dim strMachineNo As String

        Try
            Do
                'クライアントからデータを受信する
                myRecvData = myReader.ReadLine()
                Dim dtNow = Now
                Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
                addRECIVERecord(myID, myRecvData, strNow)
                '受信データがNothingなら相手がシャットダウンしたので終了
                If IsNothing(myRecvData) Then
                    'RaiseEvent Print("Error:Client is ShutDown")
                    RaiseEvent Print("Error:" & myID & "Client is ShutDown")
                    Exit Do
                End If
                'strCommand = myRecvData.Split(",")
                'Select Case strCommand.Length
                '    Case 0
                '        strCmd = "Error"
                '        strMachineNo = "Error"
                '    Case 1
                '        strCmd = "Error"
                '        strMachineNo = "Error"
                '        If strCommand(0) <> "" Then
                '            strCmd = strCommand(0)
                '        End If
                '        strMachineNo = "Error"
                '    Case Else
                '        strCmd = "Error"
                '        strMachineNo = "Error"
                '        If strCommand(0) <> "" Then
                '            strCmd = strCommand(0)
                '        End If
                '        If strCommand(1) <> "" Then
                '            strMachineNo = strCommand(1)
                '        End If
                'End Select
                ''受信したデータを表示する
                ''RaiseEvent Print("Recive," & myRecvData)
                ''すべてのクライアントに応答データを送信する
                'mySendData = String.Format("True,{0},{1}", strCmd, strMachineNo)
                ''mySendData = String.Format("True,{0},{1}", myID, strCommand(0))
                'SyncLock mySessionList.SyncRoot
                'Dim session As clsSession
                'For Each session In mySessionList
                '    If myID = session.myID Then
                '        session.MyWriteLine(mySendData)
                '    End If
                '    Next
                'End SyncLock
                '受信したデータを表示する
                'If myRecvData <> """" Then
                If myRecvData.Length >= 2 Then
                    RaiseEvent Print("Recive," & myID & "," & myRecvData)
                    '受信したデータ
                    'RaiseEvent Print("True," & myRecvData)
                    RaiseEvent Print("True," & myID & "," & myRecvData)
                End If
            Loop

            'クライアントに送信シャットダウンを伝える
            mySocket.Shutdown(SocketShutdown.Send)
            'RaiseEvent Print("Error:shutdown ")
            RaiseEvent Print("Error:" & myID & "shutdown ")

            'クライアントとの交信を閉じる
            RaiseEvent Print("Message:" & myID & "The recive thread was end")
            MyEndSession()

        Catch ex As Exception
            'エラー処理
            Select Case MyGetSocketErrorCode(ex)
                Case 10004, 10053 'WSAEINTR, WSAECONNABORTED
                    '自分でソケットを閉じた（＝送信スレッドが例外で中断）
                    'RaiseEvent Print("Error:" & myID & " が落ちました")
                    'RaiseEvent Print("Error:recive thread interrupted")
                    RaiseEvent Print("Error:" & myID & " recive thread interrupted")
                    MyEndSession()
                Case 10054 'WSAECONNRESET
                    '交信相手が落ちた
                    'RaiseEvent Print("Error:" & myID & " が落ちました")
                    'RaiseEvent Print("Error:recive thread interrupted")
                    RaiseEvent Print("Error:" & myID & " recive thread interrupted")
                    MyEndSession()
                Case Else
                    '上記以外は予想外のエラーである
                    'RaiseEvent Print("Error:" & myID & " の受信スレッドを中断しました")
                    'RaiseEvent Print("Error:" & ex.Message)
                    RaiseEvent Print("Error:" & myID & "： " & ex.Message)
                    MyEndSession()
            End Select
        End Try
    End Sub

    '受信スレッド終了時の共通処理
    Sub MyEndSession()

        'このセッションをリストから削除する
        SyncLock mySessionList.SyncRoot
            mySessionList.Remove(Me)
        End SyncLock

        '送信スレッドが動作していれば終了させる
        myWriteLoopFlag = False
        myWriteSignal.Set()

        'ソケットを閉じる
        mySocket.Close()
        'RaiseEvent Print("Error:close socket")
        RaiseEvent Print("Message:" & myID & " close socket")

        '終了通知
        RaiseEvent Quit(Me)
    End Sub

    '送信用スレッド本体
    Sub MyWriteLoop()

        Try
            'myWriteSignal.Set()を実行するとループが1つ回る
            Do While myWriteSignal.WaitOne() AndAlso myWriteLoopFlag
                '送信キューに入っているデータがなくなるまで送信する
                Do While myWriteQueue.Count > 0
                    myWriter.WriteLine(myWriteQueue.Dequeue())
                Loop
            Loop

            '送信スレッドが無事に終了
            RaiseEvent Print("Success:" & myID & " send thread was end")
            'RaiseEvent Print("Success:" & myID & " send thread was end")
        Catch ex As Exception
            'エラー処理
            'RaiseEvent Print("Error:" & myID & " : " & ex.Message)
            RaiseEvent Print("Error:" & myID & " send thread interrupted")

            'ソケットを閉じることで、受信スレッドも中断する
            mySocket.Close()
        End Try
    End Sub

    '1行の文字列データを送信する
    Sub MyWriteLine(ByVal line As String)
        'データを送信キューに追加するだけ。あとの仕事は送信スレッドにまかせる
        myWriteQueue.Enqueue(line)
        myWriteSignal.Set()
    End Sub

    'セッションIDを返す
    Function MyGetID() As String
        Return myID
    End Function

    '例外発生の原因になったソケットエラーのエラー番号を調べるメソッド
    Function MyGetSocketErrorCode(ByVal ex As Exception) As Integer
        If IsNothing(ex) Then
            Return -1
        ElseIf TypeOf ex Is SocketException Then
            Return CType(ex, SocketException).ErrorCode
        Else
            Return MyGetSocketErrorCode(ex.InnerException)
        End If
    End Function

    '	SFTRecordログ出力
    Private Shared Sub addRECIVERecord(ByVal myID As String, ByVal Recivedata As String, ByVal InDate As String)
        Dim YMfolder As String = Format(Now(), "yyyyMM")

        Dim strLogFileName As String = "Recive\ReciceRecord_" & YMfolder & ".txt"
        Dim MappedLogFileName As String = SelPath & "\LOG\" & strLogFileName
        If Not System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(MappedLogFileName)) Then
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(MappedLogFileName))
        End If

        Dim stbr As New System.Text.StringBuilder
        Try
            stbr.Append(myID)
            stbr.Append(",")
            stbr.Append(Recivedata)
            stbr.Append(",")
            stbr.Append(InDate)
            My.Computer.FileSystem.WriteAllText(MappedLogFileName, stbr.ToString & vbCrLf, True)
        Catch ex As Exception
            MsgBox(ex)
            'clsErrorLog.addlogWT("Error:addSFTRecord/[" & stbr.ToString & "]:" & ex.ToString, HEADER)
        Finally
        End Try

    End Sub
End Class
