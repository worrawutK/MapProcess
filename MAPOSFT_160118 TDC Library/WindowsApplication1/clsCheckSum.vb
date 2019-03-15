'checksum (sum ascii code and mod 256, hex2digit)
'
'function
' check (if it is OK)
' create
'

Public Class clsCheckSum
    Const ENDSEPARATOR As String = vbCrLf

    'チェックサムがあっているかチェックする関数
    Private Shared Function IsMatchChecksum(ByVal strToBeChecked() As Byte) As Boolean
        Dim sumAtAppended As Byte
        Dim sumAtCalculated As Byte
        Try
            If strToBeChecked.Length <= 2 Then Return False

            Dim d As System.Text.Decoder = System.Text.Encoding.ASCII.GetDecoder
            Dim ans(1) As Char
            d.GetChars(strToBeChecked, strToBeChecked.Length - 2, 2, ans, 0)
            sumAtAppended = Convert.ToByte(New String(ans), 16)

            ReDim Preserve strToBeChecked(strToBeChecked.Length - 3)
            sumAtCalculated = getChecksum(strToBeChecked)
        Catch
            Return False
        End Try

        '末尾の2文字のByte値と集計結果があっていればTrue
        If sumAtAppended = sumAtCalculated Then
            Return True
        Else
            Return False
        End If

    End Function
    Friend Shared Function IsMatchChecksum(ByVal strToBeChecked As String) As Boolean
        strToBeChecked = purifyText(strToBeChecked)
        Dim buff() As Byte = System.Text.Encoding.ASCII.GetBytes(strToBeChecked)
        Return IsMatchChecksum(buff)
    End Function

    'チェックサム剰余を計算する関数
    Private Shared Function getChecksum(ByVal strToBeChecked() As Byte) As Byte
        Dim ans As Integer = 0
        For i As Integer = 0 To strToBeChecked.Length - 1
            ans += strToBeChecked(i)
        Next
        Return Convert.ToByte(ans Mod 256)
    End Function
    Private Shared Function getChecksum(ByVal strToBeChecked As String) As Byte
        Dim buff() As Byte = System.Text.Encoding.ASCII.GetBytes(strToBeChecked)
        Return getChecksum(buff)
    End Function

    'チェックサム剰余から2文字作成
    Friend Shared Function appendCheckSumStr(ByVal strToBeAdd As String) As String
        strToBeAdd = purifyText(strToBeAdd)

        Dim checksum As String = "00" & Hex(getChecksum(strToBeAdd))
        Return strToBeAdd & checksum.Substring(checksum.Length - 2, 2)
    End Function

    '使用禁止文字を除去 (ASCII 32-126以外)
    Friend Shared Function purifyText(ByVal strToBePurified As String) As String
        If strToBePurified.IndexOf(ENDSEPARATOR) > -1 Then
            strToBePurified = strToBePurified.Substring(0, strToBePurified.IndexOf(ENDSEPARATOR))
        End If
        Dim recvBuffer() As Byte
        recvBuffer = System.Text.Encoding.ASCII.GetBytes(strToBePurified)
        Dim stbr As New System.Text.StringBuilder
        For i As Integer = 0 To recvBuffer.Length - 1
            If recvBuffer(i) >= 32 And recvBuffer(i) <= 126 Then
                stbr.Append(Chr(recvBuffer(i)))
            Else
            End If
        Next
        Return stbr.ToString
    End Function
    Friend Shared Function IsContainCtrlcode(ByVal strToBePurified As String) As Boolean
        Dim recvBuffer() As Byte
        recvBuffer = System.Text.Encoding.ASCII.GetBytes(strToBePurified)
        For i As Integer = 0 To recvBuffer.Length - 1
            If recvBuffer(i) >= 32 And recvBuffer(i) <= 126 Then
            Else
                Return True
            End If
        Next
        Return False
    End Function



    Public Shared Function test(ByVal intTestcount As Integer) As String
        Dim maxchar As Integer = 100
        For i As Integer = 0 To intTestcount - 1
            Dim testchar As Integer = Int(maxchar * Rnd()) + 1
            Dim testStr As New System.Text.StringBuilder
            For j As Integer = 0 To testchar - 1
                Dim iasc As Integer
                Do
                    iasc = Int(128 * Rnd())
                    If iasc >= 32 And iasc <= 126 And iasc <> 34 Then Exit Do
                Loop
                testStr.Append(Chr(iasc))
            Next
            If Not IsMatchChecksum(appendCheckSumStr(testStr.ToString)) Then
                Return "Error:" & testStr.ToString
            End If
        Next
        Return "True"
    End Function

End Class
