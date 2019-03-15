Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading


'�X�̃N���C�A���g�ƌ�M���邽�߂̃N���X
Public Class clsSession
    Const HEADER As String = "clsSession"

    '�N���X�S�̂ŋ��p����ϐ��̐錾�Ə�����
    Shared myCount As Integer = 0
    Public Shared mySessionList As ArrayList = New ArrayList()

    '�C���X�^���X���ʂɎ��ϐ��̐錾
    Dim mySocket As Socket
    Dim myStream As NetworkStream
    Dim myReader As StreamReader
    Dim myWriter As StreamWriter
    Dim myWriteQueue As Queue
    Dim myWriteSignal As AutoResetEvent
    Dim myWriteLoopFlag As Boolean
    Dim myID As String

    '�C�x���g�̐錾
    Event Print(ByVal str As String)
    Event Quit(ByVal session As clsSession)

    'SessionClass�̐V�����C���X�^���X�����
    Sub New(ByVal sock As Socket)

        '�\�P�b�g��ǂݏ������鏀��
        mySocket = sock
        myStream = New NetworkStream(mySocket)
        myReader = New StreamReader(myStream, Encoding.UTF8)
        myWriter = New StreamWriter(myStream, Encoding.UTF8)
        myWriter.AutoFlush = True
        myWriter.NewLine = vbNewLine

        '���M�L���[�A�z�M�҂��t���O�A���s�t���O������������
        myWriteQueue = New Queue()
        myWriteSignal = New AutoResetEvent(False)
        myWriteLoopFlag = True

        '�Z�b�V����ID�̐ݒ�i�N���C�A���g��IP�A�h���X�j
        myCount = myCount + 1
        myID = String.Format("{0}", CType(mySocket.RemoteEndPoint, IPEndPoint).Address)

        '���̃N���C�A���g�����X�g�ɒǉ�����
        SyncLock mySessionList.SyncRoot
            mySessionList.Add(Me)
        End SyncLock
    End Sub

    '��M���J�n����
    Sub MyStartSession()
        '��M������ʃX���b�h�ŊJ�n����
        Dim readThread As Thread
        readThread = New Thread(AddressOf MyReadLoop)
        readThread.IsBackground = True
        readThread.Start()

        '���M������ʃX���b�h�ŊJ�n����
        Dim writeThread As Thread
        writeThread = New Thread(AddressOf MyWriteLoop)
        writeThread.IsBackground = True
        writeThread.Start()
    End Sub

    '��M�p�X���b�h�{��
    Sub MyReadLoop()

        '�ϐ��̐錾
        Dim myRecvData As String
        'Dim mySendData As String
        'Dim strCommand As String()
        'Dim strCmd As String
        'Dim strMachineNo As String

        Try
            Do
                '�N���C�A���g����f�[�^����M����
                myRecvData = myReader.ReadLine()
                Dim dtNow = Now
                Dim strNow As String = Format(dtNow, "yyyy-MM-dd HH:mm:ss")
                addRECIVERecord(myID, myRecvData, strNow)
                '��M�f�[�^��Nothing�Ȃ瑊�肪�V���b�g�_�E�������̂ŏI��
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
                ''��M�����f�[�^��\������
                ''RaiseEvent Print("Recive," & myRecvData)
                ''���ׂẴN���C�A���g�ɉ����f�[�^�𑗐M����
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
                '��M�����f�[�^��\������
                'If myRecvData <> """" Then
                If myRecvData.Length >= 2 Then
                    RaiseEvent Print("Recive," & myID & "," & myRecvData)
                    '��M�����f�[�^
                    'RaiseEvent Print("True," & myRecvData)
                    RaiseEvent Print("True," & myID & "," & myRecvData)
                End If
            Loop

            '�N���C�A���g�ɑ��M�V���b�g�_�E����`����
            mySocket.Shutdown(SocketShutdown.Send)
            'RaiseEvent Print("Error:shutdown ")
            RaiseEvent Print("Error:" & myID & "shutdown ")

            '�N���C�A���g�Ƃ̌�M�����
            RaiseEvent Print("Message:" & myID & "The recive thread was end")
            MyEndSession()

        Catch ex As Exception
            '�G���[����
            Select Case MyGetSocketErrorCode(ex)
                Case 10004, 10053 'WSAEINTR, WSAECONNABORTED
                    '�����Ń\�P�b�g������i�����M�X���b�h����O�Œ��f�j
                    'RaiseEvent Print("Error:" & myID & " �������܂���")
                    'RaiseEvent Print("Error:recive thread interrupted")
                    RaiseEvent Print("Error:" & myID & " recive thread interrupted")
                    MyEndSession()
                Case 10054 'WSAECONNRESET
                    '��M���肪������
                    'RaiseEvent Print("Error:" & myID & " �������܂���")
                    'RaiseEvent Print("Error:recive thread interrupted")
                    RaiseEvent Print("Error:" & myID & " recive thread interrupted")
                    MyEndSession()
                Case Else
                    '��L�ȊO�͗\�z�O�̃G���[�ł���
                    'RaiseEvent Print("Error:" & myID & " �̎�M�X���b�h�𒆒f���܂���")
                    'RaiseEvent Print("Error:" & ex.Message)
                    RaiseEvent Print("Error:" & myID & "�F " & ex.Message)
                    MyEndSession()
            End Select
        End Try
    End Sub

    '��M�X���b�h�I�����̋��ʏ���
    Sub MyEndSession()

        '���̃Z�b�V���������X�g����폜����
        SyncLock mySessionList.SyncRoot
            mySessionList.Remove(Me)
        End SyncLock

        '���M�X���b�h�����삵�Ă���ΏI��������
        myWriteLoopFlag = False
        myWriteSignal.Set()

        '�\�P�b�g�����
        mySocket.Close()
        'RaiseEvent Print("Error:close socket")
        RaiseEvent Print("Message:" & myID & " close socket")

        '�I���ʒm
        RaiseEvent Quit(Me)
    End Sub

    '���M�p�X���b�h�{��
    Sub MyWriteLoop()

        Try
            'myWriteSignal.Set()�����s����ƃ��[�v��1���
            Do While myWriteSignal.WaitOne() AndAlso myWriteLoopFlag
                '���M�L���[�ɓ����Ă���f�[�^���Ȃ��Ȃ�܂ő��M����
                Do While myWriteQueue.Count > 0
                    myWriter.WriteLine(myWriteQueue.Dequeue())
                Loop
            Loop

            '���M�X���b�h�������ɏI��
            RaiseEvent Print("Success:" & myID & " send thread was end")
            'RaiseEvent Print("Success:" & myID & " send thread was end")
        Catch ex As Exception
            '�G���[����
            'RaiseEvent Print("Error:" & myID & " : " & ex.Message)
            RaiseEvent Print("Error:" & myID & " send thread interrupted")

            '�\�P�b�g����邱�ƂŁA��M�X���b�h�����f����
            mySocket.Close()
        End Try
    End Sub

    '1�s�̕�����f�[�^�𑗐M����
    Sub MyWriteLine(ByVal line As String)
        '�f�[�^�𑗐M�L���[�ɒǉ����邾���B���Ƃ̎d���͑��M�X���b�h�ɂ܂�����
        myWriteQueue.Enqueue(line)
        myWriteSignal.Set()
    End Sub

    '�Z�b�V����ID��Ԃ�
    Function MyGetID() As String
        Return myID
    End Function

    '��O�����̌����ɂȂ����\�P�b�g�G���[�̃G���[�ԍ��𒲂ׂ郁�\�b�h
    Function MyGetSocketErrorCode(ByVal ex As Exception) As Integer
        If IsNothing(ex) Then
            Return -1
        ElseIf TypeOf ex Is SocketException Then
            Return CType(ex, SocketException).ErrorCode
        Else
            Return MyGetSocketErrorCode(ex.InnerException)
        End If
    End Function

    '	SFTRecord���O�o��
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
