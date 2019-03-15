'Hex: [Wa25]...[Wa01]
'Bin50: [Wa01]...[Wa25](26-50)

Imports system.Text.RegularExpressions

Public Class clsWaHexConverter
    Public Shared Function HexToBINCSV(ByVal strWaferListHex As String) As String
        Dim strWafersBIN As String = HexToBin(strWaferListHex)
        Dim ans As String = ""
        For i As Integer = 1 To 25
            If strWafersBIN.Substring(25 - i, 1) = "1" Then
                ans = ans & "1,"
            Else
                ans = ans & "0,"
            End If
        Next
        ans = ans.TrimEnd(",")
        Return ans
    End Function
    Public Shared Function CsvToHex(ByVal strWaferList_WaNoSeparatedByComma As String) As String
        Dim strWafers() As String = strWaferList_WaNoSeparatedByComma.Split(",")
        Dim htWaferList As New System.Collections.Generic.Dictionary(Of Integer, Boolean)
        For Each strWafer As String In strWafers
            Dim intWa As Integer
            If Integer.TryParse(strWafer, intWa) = True Then
                If Not htWaferList.ContainsKey(intWa) Then htWaferList.Add(intWa, True)
            End If
        Next
        Dim ans As String = ""
        For i As Integer = 1 To 25
            If htWaferList.ContainsKey(i) Then
                If htWaferList.Item(i) = True Then
                    ans = "1" & ans
                Else
                    ans = "0" & ans
                End If
            Else
                ans = "0" & ans
            End If
        Next
        ans = clsWaHexConverter.BinToHex(ans)
        Return ans
    End Function
    Public Shared Function BinToHex(ByVal strBin As String) As String
        If strBin.Length = 50 Then
            strBin = getReverse(strBin)
        End If
        Dim ans As String = ""
        Dim myRegex As Regex = New Regex("[0-1]{25}")
        Dim M As Match = myRegex.Match(strBin)
        If Not M.Success Or strBin.Length <> 25 Then
            Return Microsoft.VisualBasic.StrDup(7, " ")
        End If

        Dim lngAns As Long = Convert.ToInt64(strBin, 2)
        ans = Microsoft.VisualBasic.Hex(lngAns).PadLeft(7, "0")
        Return ans
    End Function
    Public Shared Function HexToBin(ByVal strHex As String) As String
        Dim ans As String = ""

        Dim myRegex As Regex = New Regex("[0-1][0-9A-F]{6}")
        Dim M As Match = myRegex.Match(strHex)
        If Not M.Success Or strHex.Length <> 7 Then
            Return Microsoft.VisualBasic.StrDup(25, " ")
        End If

        Dim lngAns As Long = Convert.ToInt64(strHex, 16)
        ans = Convert.ToString(lngAns, 2).PadLeft(25, "0")
        Return ans
    End Function
    Public Shared Function HexValidFormat(ByVal strHex As String) As Boolean
        Dim ans As String = ""

        Dim myRegex As Regex = New Regex("[0-1][0-9A-F]{6}")
        Dim M As Match = myRegex.Match(strHex)
        If Not M.Success Or strHex.Length <> 7 Then
            Return False
        End If

        Return True
    End Function
    Public Shared Function IsIncluded(ByVal strChildList As String, ByVal strMotherList As String) As Boolean
        Dim ans As String = ""

        strChildList = HexToBin(strChildList)
        strMotherList = HexToBin(strMotherList)
        If strChildList.Length <> 25 Then Return False
        If strMotherList.Length <> 25 Then Return False
        If strChildList = Microsoft.VisualBasic.StrDup(25, " ") Then Return False
        If strMotherList = Microsoft.VisualBasic.StrDup(25, " ") Then Return False
        For i As Integer = 0 To 24
            If strChildList(i) = "1" AndAlso strMotherList(i) = "0" Then Return False
        Next
        Return True
    End Function
    Public Shared Function IsAllOdd(ByVal strHex As String) As Boolean
        Dim strWaferList As String = HexToBin(strHex)
        For i As Integer = 1 To 23 Step 2
            If strWaferList(i) = "1" Then Return False
        Next
        Return True
    End Function
    Public Shared Function IsAllEven(ByVal strHex As String) As Boolean
        Dim strWaferList As String = HexToBin(strHex)
        For i As Integer = 0 To 24 Step 2
            If strWaferList(i) = "1" Then Return False
        Next
        Return True
    End Function
    Public Shared Function RejectedList(ByVal strChildList As String, ByVal strMotherList As String) As String
        Dim ans As String = ""

        strChildList = HexToBin(strChildList)
        strMotherList = HexToBin(strMotherList)
        If strChildList.Length <> 25 Then Return Microsoft.VisualBasic.StrDup(7, " ")
        If strMotherList.Length <> 25 Then Return Microsoft.VisualBasic.StrDup(7, " ")
        If strChildList = Microsoft.VisualBasic.StrDup(25, " ") Then Return Microsoft.VisualBasic.StrDup(7, " ")
        If strMotherList = Microsoft.VisualBasic.StrDup(25, " ") Then Return Microsoft.VisualBasic.StrDup(7, " ")
        For i As Integer = 0 To 24
            Select Case strChildList(i) & strMotherList(i)
                Case "11", "00"
                    ans &= "0"
                Case "01"
                    ans &= "1"
                Case Else
                    Return Microsoft.VisualBasic.StrDup(7, " ")
            End Select
        Next
        Return BinToHex(ans)
    End Function
    Public Shared Function InverseList(ByVal strWaferList As String) As String

        strWaferList = HexToBin(strWaferList)
        strWaferList = strWaferList.Replace("1", "x")
        strWaferList = strWaferList.Replace("0", "1")
        strWaferList = strWaferList.Replace("x", "0")

        Return BinToHex(strWaferList)
    End Function
    Public Shared Function WaferListMargeable(ByVal strWaferList1 As String, ByVal strWaferList2 As String) As String
        Dim ans As String = ""

        strWaferList1 = HexToBin(strWaferList1)
        strWaferList2 = HexToBin(strWaferList2)
        If strWaferList1.Length <> 25 Then Return "Error:WaferList1"
        If strWaferList2.Length <> 25 Then Return "Error:WaferList2"
        If strWaferList1 = Microsoft.VisualBasic.StrDup(25, " ") Then Return "Error:WaferList1"
        If strWaferList2 = Microsoft.VisualBasic.StrDup(25, " ") Then Return "Error:WaferList2"
        For i As Integer = 0 To 24
            'Dim c As String = strWaferList1(i)
            'Dim d As String = strWaferList2(i)
            If strWaferList1(i) = "1" And strWaferList2(i) = "1" Then
                Return "Error:Wa[" & (i + 1).ToString & "]MisMatch!"
            End If
        Next
        Return "True"
    End Function
    Public Shared Function MargeWaferList(ByVal strWaferList1 As String, ByVal strWaferList2 As String) As String
        Dim ans As String = ""

        strWaferList1 = HexToBin(strWaferList1)
        strWaferList2 = HexToBin(strWaferList2)
        If strWaferList1.Length <> 25 Then Return Microsoft.VisualBasic.StrDup(7, " ")
        If strWaferList2.Length <> 25 Then Return Microsoft.VisualBasic.StrDup(7, " ")
        If strWaferList1 = Microsoft.VisualBasic.StrDup(25, " ") Then Return Microsoft.VisualBasic.StrDup(7, " ")
        If strWaferList2 = Microsoft.VisualBasic.StrDup(25, " ") Then Return Microsoft.VisualBasic.StrDup(7, " ")
        For i As Integer = 0 To 24
            If strWaferList1(i) = "1" And strWaferList2(i) = "1" Then
                Return Microsoft.VisualBasic.StrDup(7, " ")
            End If
            If strWaferList1(i) = "1" Or strWaferList2(i) = "1" Then
                ans &= "1"
            Else
                ans &= "0"
            End If
        Next
        Return BinToHex(ans)
    End Function
    Public Shared Function GetWaCount(ByVal strWaferList As String) As Integer
        If strWaferList.Length = 7 Then strWaferList = HexToBin(strWaferList)
        If strWaferList.Length <> 25 Then Return 0
        Dim ans As Integer = 0
        For i As Integer = 0 To 24
            If strWaferList(i) = "1" Then ans += 1
        Next
        Return ans
    End Function
    Private Shared Function getReverse(ByVal strBinlist50 As String) As String
        Dim ans As New System.Text.StringBuilder
        For i As Integer = 24 To 0 Step -1
            ans.Append(strBinlist50(i))
        Next
        Return ans.ToString
    End Function
    Public Shared Function test() As String
        Dim ans As New System.Text.StringBuilder
        For i As Long = 0 To Convert.ToInt64(Microsoft.VisualBasic.StrDup(5, "1"), 2)
            Dim strBin As String = Convert.ToString(i, 2).PadLeft(25, "0")
            Dim strHex As String = BinToHex(strBin)
            Dim strReBin As String = HexToBin(strHex)
            If strBin <> strReBin Then Return False
            ans.Append(i.ToString & ",[" & strBin & "],[" & strHex & "],[" & strReBin & "]" & vbCrLf)
        Next
        Return ans.ToString
    End Function
    Public Shared Function test2() As Boolean
        If HexValidFormat("1FFFFFF") = False Then Return False
        If HexValidFormat("0000000") = False Then Return False
        If HexValidFormat("1000000") = False Then Return False
        If HexValidFormat("0000001") = False Then Return False
        If HexValidFormat("A000001") = True Then Return False
        If HexValidFormat("00000001") = True Then Return False
        If HexValidFormat("000001") = True Then Return False
        If HexValidFormat("000000Z") = True Then Return False
        If HexValidFormat("000000,") = True Then Return False

        If IsIncluded("1FFFFFF", "1FFFFFF") = False Then Return False
        If IsIncluded("1000000", "1000000") = False Then Return False
        If IsIncluded("0000001", "0000001") = False Then Return False
        If IsIncluded("0AAAAAA", "0AAAAAA") = False Then Return False
        If IsIncluded("1555555", "1555555") = False Then Return False
        If IsIncluded("10000000", "1000000") = True Then Return False
        If IsIncluded("0000001", "00000001") = True Then Return False
        If IsIncluded("1FFFFFF", "0FFFFFF") = True Then Return False
        If IsIncluded("1FFFFFF", "1FFFFFE") = True Then Return False
        If IsIncluded("1000000", "0000000") = True Then Return False
        If IsIncluded("0000001", "0000000") = True Then Return False
        If IsIncluded("0AAAAAA", "02AAAAA") = True Then Return False
        If IsIncluded("0AAAAAA", "0AAAAA2") = True Then Return False
        If IsIncluded("1555555", "0555555") = True Then Return False
        If IsIncluded("1555555", "1555554") = True Then Return False

        If RejectedList("1FFFFFF", "1FFFFFF") <> "0000000" Then Return False
        If RejectedList("1000000", "1000000") <> "0000000" Then Return False
        If RejectedList("0000001", "0000001") <> "0000000" Then Return False
        If RejectedList("0AAAAAA", "0AAAAAA") <> "0000000" Then Return False
        If RejectedList("1555555", "1555555") <> "0000000" Then Return False
        If RejectedList("10000000", "1000000") <> "       " Then Return False
        If RejectedList("0000001", "00000001") <> "       " Then Return False
        If RejectedList("1FFFFFF", "0FFFFFF") <> "       " Then Return False
        If RejectedList("1FFFFFF", "1FFFFFE") <> "       " Then Return False
        If RejectedList("1000000", "0000000") <> "       " Then Return False
        If RejectedList("0000001", "0000000") <> "       " Then Return False
        If RejectedList("0FFFFFF", "1FFFFFF") <> "1000000" Then Return False
        If RejectedList("1FFFFFE", "1FFFFFF") <> "0000001" Then Return False
        If RejectedList("0000000", "1000000") <> "1000000" Then Return False
        If RejectedList("0000000", "0000001") <> "0000001" Then Return False
        If RejectedList("02AAAAA", "0AAAAAA") <> "0800000" Then Return False
        If RejectedList("0AAAAA2", "0AAAAAA") <> "0000008" Then Return False
        If RejectedList("0555555", "1555555") <> "1000000" Then Return False
        If RejectedList("1555554", "1555555") <> "0000001" Then Return False

        If WaferListMargeable("1FFFFFF", "0000000") <> "True" Then Return False
        If WaferListMargeable("0000000", "1FFFFFF") <> "True" Then Return False
        If WaferListMargeable("1FFFFFE", "0000001") <> "True" Then Return False
        If WaferListMargeable("0000001", "1FFFFFE") <> "True" Then Return False
        If WaferListMargeable("0AAAAAA", "1555555") <> "True" Then Return False
        If WaferListMargeable("1555555", "0AAAAAA") <> "True" Then Return False
        If WaferListMargeable("0000000", "0000001") <> "True" Then Return False
        If WaferListMargeable("0000001", "0000000") <> "True" Then Return False
        If WaferListMargeable("0000000", "1000000") <> "True" Then Return False
        If WaferListMargeable("1000000", "0000000") <> "True" Then Return False
        If WaferListMargeable("1FFFFFF", "0000001") = "True" Then Return False
        If WaferListMargeable("0000001", "1FFFFFF") = "True" Then Return False
        If WaferListMargeable("1FFFFFE", "0000002") = "True" Then Return False
        If WaferListMargeable("0000002", "1FFFFFE") = "True" Then Return False
        If WaferListMargeable("0AAAAAA", "1555557") = "True" Then Return False
        If WaferListMargeable("1555557", "0AAAAAA") = "True" Then Return False
        If WaferListMargeable("0AAAAAB", "1555555") = "True" Then Return False
        If WaferListMargeable("1555555", "0AAAAAB") = "True" Then Return False
        If WaferListMargeable("0000001", "0000001") = "True" Then Return False
        If WaferListMargeable("1000000", "1000000") = "True" Then Return False

        If MargeWaferList("1FFFFFF", "0000000") <> "1FFFFFF" Then Return False
        If MargeWaferList("0000000", "1FFFFFF") <> "1FFFFFF" Then Return False
        If MargeWaferList("1FFFFFE", "0000001") <> "1FFFFFF" Then Return False
        If MargeWaferList("0000001", "1FFFFFE") <> "1FFFFFF" Then Return False
        If MargeWaferList("0AAAAAA", "1555555") <> "1FFFFFF" Then Return False
        If MargeWaferList("1555555", "0AAAAAA") <> "1FFFFFF" Then Return False
        If MargeWaferList("0000000", "0000001") <> "0000001" Then Return False
        If MargeWaferList("0000001", "0000000") <> "0000001" Then Return False
        If MargeWaferList("0000000", "1000000") <> "1000000" Then Return False
        If MargeWaferList("1000000", "0000000") <> "1000000" Then Return False

        If IsAllOdd("0000000") <> True Then Return False
        If IsAllEven("0000000") <> True Then Return False
        If IsAllOdd("1555555") <> True Then Return False
        If IsAllEven("0AAAAAA") <> True Then Return False
        If IsAllOdd("1FFFFFF") = True Then Return False
        If IsAllEven("1FFFFFF") = True Then Return False
        If IsAllOdd("0000002") = True Then Return False
        If IsAllOdd("0800000") = True Then Return False
        If IsAllEven("0000001") = True Then Return False
        If IsAllEven("1000000") = True Then Return False

        If InverseList("1FFFFFF") <> "0000000" Then Return False
        If InverseList("1000000") <> "0FFFFFF" Then Return False
        If InverseList("0000001") <> "1FFFFFE" Then Return False
        If InverseList("0AAAAAA") <> "1555555" Then Return False
        If InverseList("1555555") <> "0AAAAAA" Then Return False

        If InverseList("0FFFFFF") <> "1000000" Then Return False
        If InverseList("1FFFFFE") <> "0000001" Then Return False
        If InverseList("0000000") <> "1FFFFFF" Then Return False
        If InverseList("02AAAAA") <> "1D55555" Then Return False
        If InverseList("0AAAAA2") <> "155555D" Then Return False

        Return True
    End Function

End Class
