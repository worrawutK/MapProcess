'command encode (max 1024 bit )sum ascii code and mod 256, hex2digit)
'
'function
' getSendString (CrLfまでで止めるルール,使用可能文字以外は消すルール)
' getParseString (""のエスケープとパラメータの読み取り)
'
Imports System.Collections.Generic

Public Class clsCommandEncode
    Inherits clsCheckSum
    Const MAXBITS As Integer = 1024
    Const CHECKBITS As Integer = 2
    Const ENDSEPARATOR As String = vbCrLf

    Private _iserr As Boolean
    Public ReadOnly Property isErr() As Boolean
        Get
            Return _iserr
        End Get
    End Property

    Private _commandString As String
    Public ReadOnly Property CommandString() As String
        Get
            Return (_commandString)
        End Get
    End Property

    Private _optionList As List(Of String)
    Public ReadOnly Property OptionList() As List(Of String)
        Get
            Return (_optionList)
        End Get
    End Property

    Public Function getSendString(ByVal sendCommand As String) As String
        _iserr = False
        Dim ans As String = ""

        If sendCommand.IndexOf(ENDSEPARATOR) > -1 Then
            sendCommand = sendCommand.Substring(0, sendCommand.IndexOf(ENDSEPARATOR))
        End If

        If IsContainCtrlcode(sendCommand) Then _iserr = True
        sendCommand = purifyText(sendCommand)

        Dim sendBuffer() As Byte
        sendBuffer = System.Text.Encoding.ASCII.GetBytes(sendCommand)
        If sendBuffer.Length > MAXBITS - CHECKBITS Then
            _iserr = True
            Return "00" & ENDSEPARATOR
        End If

        Return appendCheckSumStr(sendCommand) & ENDSEPARATOR

    End Function


    Public Sub getParseString(ByVal recvCommand As String)
        _iserr = False
        _commandString = ""
        _optionList = New List(Of String)

        Dim ans As String = ""

        If recvCommand.IndexOf(ENDSEPARATOR) > -1 Then
            recvCommand = recvCommand.Substring(0, recvCommand.IndexOf(ENDSEPARATOR))
        End If

        If IsContainCtrlcode(recvCommand) Then _iserr = True
        recvCommand = purifyText(recvCommand)

        If IsMatchChecksum(recvCommand) = False Then
            _iserr = True
            Exit Sub
        Else
            recvCommand = recvCommand.Substring(0, recvCommand.Length - 2)
        End If

        _commandString = readcolumn(recvCommand)
        Do
            _optionList.Add(readcolumn(recvCommand))
            If recvCommand = "" Then Exit Do
        Loop

    End Sub

    Public Sub getParseStringWOcheck(ByVal recvCommand As String)
        _iserr = False
        _commandString = ""
        _optionList = New List(Of String)

        Dim ans As String = ""

        If recvCommand.IndexOf(ENDSEPARATOR) > -1 Then
            recvCommand = recvCommand.Substring(0, recvCommand.IndexOf(ENDSEPARATOR))
        End If

        If IsContainCtrlcode(recvCommand) Then _iserr = True
        recvCommand = purifyText(recvCommand)

        'If IsMatchChecksum(recvCommand) = False Then
        '    _iserr = True
        '    Exit Sub
        'Else
        '    recvCommand = recvCommand.Substring(0, recvCommand.Length - 2)
        'End If

        _commandString = readcolumn(recvCommand)
        Do
            _optionList.Add(readcolumn(recvCommand))
            If recvCommand = "" Then Exit Do
        Loop

    End Sub


    'readcolumnメソッド：入力引数stringを参照渡しする。入力引数の先頭からカンマまでを返り値とし、入力引数は返り値を切り取って更新する
    Private Shared Function readcolumn(ByRef strC As String) As String
        Dim strReturn As String
        If strC Is Nothing Then Return ""
        If strC.Length = 0 Then Return ""
        If strC.IndexOf(",") = -1 And strC.IndexOf(Chr(34)) = -1 Then
            strReturn = strC
            strC = ""
            Return strReturn
        End If
        If strC.IndexOf(",") = -1 And strC.Substring(0, 1) = Chr(34) Then
            strC = strC.Substring(1, strC.Length - 1)
            strReturn = strC.Substring(0, strC.IndexOf(Chr(34)))
            strC = ""
            Return strReturn
        End If

        If strC.Substring(0, 1) = Chr(34) Then
            strC = strC.Substring(1, strC.Length - 1)
            strReturn = strC.Substring(0, strC.IndexOf(Chr(34)))
            If strC.Length - strReturn.Length > 1 Then
                strC = strC.Substring(strC.IndexOf(Chr(34)) + 2, strC.Length - strC.IndexOf(Chr(34)) - 2)
            Else
                strC = ""
            End If
            Return strReturn
        Else
            strReturn = strC.Substring(0, strC.IndexOf(","))
            strC = strC.Substring(strC.IndexOf(",") + 1, strC.Length - strC.IndexOf(",") - 1)
            Return strReturn
        End If
    End Function

    Public Function testCommand() As String

        'get
        If Me.getSendString("") <> "00" & vbCrLf Then Return "Error:0"
        If Me.getSendString("Accept") <> "Accept50" & vbCrLf Then Return "Error:1"
        If isErr Then Return "Error:2"
        Me.getSendString(Microsoft.VisualBasic.StrDup(1021, " "))
        If isErr Then Return "Error:3"
        Me.getSendString(Microsoft.VisualBasic.StrDup(1022, " "))
        If isErr Then Return "Error:4"
        Me.getSendString(Microsoft.VisualBasic.StrDup(1023, " "))
        If Not isErr Then Return "Error:5"
        Me.getSendString(Microsoft.VisualBasic.StrDup(1024, " "))
        If Not isErr Then Return "Error:6"
        If Me.getSendString("OK" & vbTab & "OK") <> Me.getSendString("OKOK") Then Return "Error:7"

        'parse
        'getParseString("00" & vbCrLf)
        'If _iserr = True Then Return "Error:10"
        getParseString("Accept50" & vbCrLf)
        If _iserr = True Then Return "Error:11"
        If _commandString <> "Accept" Then Return "Error:12"
        getParseString("CMD,A,B,C,D,E,F,G,10" & vbCrLf)
        If _iserr = True Then Return "Error:13"
        If _commandString <> "CMD" Then Return "Error:14"
        If _optionList(0) <> "A" Then Return "Error:15"
        If _optionList(1) <> "B" Then Return "Error:16"
        If _optionList(2) <> "C" Then Return "Error:17"
        If _optionList(3) <> "D" Then Return "Error:18"
        If _optionList(4) <> "E" Then Return "Error:19"
        If _optionList(5) <> "F" Then Return "Error:20"
        If _optionList(6) <> "G" Then Return "Error:21"
        getParseString("CMD," & Chr(34) & "A,B,C,D,E,F,G" & Chr(34) & ",54" & vbCrLf)
        If _iserr = True Then Return "Error:22"
        If _commandString <> "CMD" Then Return "Error:23"
        If _optionList(0) <> "A,B,C,D,E,F,G" Then Return "Error:24"



        Return "True"
    End Function

End Class
