'class for wrong text check - sql injection
'
'varid char: 0-9, A-Z, a-z,
'            -, ., $, /, +, \, (space)
'            -- is NG (sql comment-out)
'            
Imports Microsoft.VisualBasic
Imports System.Text.RegularExpressions

Public Class clsAntiInjection
    Public Shared Function test() As Boolean
        Dim ans As String = ""

        ans = clsAntiInjection.isGoodText("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ")
        If ans = "False" Then Return False
        ans = clsAntiInjection.isGoodText("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-.$/+\ ")
        If ans = "False" Then Return False
        ans = clsAntiInjection.isGoodText("0!0")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("!0")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("0!")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("!")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText(Chr(34)) '["]
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("#")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("&")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("'")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("(")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText(")")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("=")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("~")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("^")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("\")
        If ans = "False" Then Return False
        ans = clsAntiInjection.isGoodText("|")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("@")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("`")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("@")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("[")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("]")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("{")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("}")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText(";")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("*")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText(":")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("<")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText(">")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText(",")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("?")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("_")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText(vbCr)
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText(vbCrLf)
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText(vbLf)
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText(vbTab)
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText(vbBack)
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText(" ")
        If ans = "False" Then Return False
        ans = clsAntiInjection.isGoodText("--")
        If ans = "True" Then Return False
        ans = clsAntiInjection.isGoodText("-")
        If ans = "False" Then Return False
        'ans = clsAntiInjection.isGoodText("myERROR")
        'If ans = "True" Then Return False

        ans = clsAntiInjection.getMismatchText("0!0")
        If ans <> "char[!]at[1]" Then Return False
        ans = clsAntiInjection.getMismatchText("!0")
        If ans <> "char[!]at[0]" Then Return False
        ans = clsAntiInjection.getMismatchText("0!")
        If ans <> "char[!]at[1]" Then Return False
        ans = clsAntiInjection.getMismatchText("!")
        If ans <> "char[!]at[0]" Then Return False
        ans = clsAntiInjection.getMismatchText("--")
        If ans <> "char[--]at[0]" Then Return False
        'ans = clsAntiInjection.getMismatchText("myERROR")
        'If ans <> "char[ERROR]at[2]" Then Return False

        ans = clsAntiInjection.purifyText("0!0")
        If ans <> "00" Then Return False
        ans = clsAntiInjection.purifyText("!0")
        If ans <> "0" Then Return False
        ans = clsAntiInjection.purifyText("0!")
        If ans <> "0" Then Return False
        ans = clsAntiInjection.purifyText("!")
        If ans <> "" Then Return False
        ans = clsAntiInjection.purifyText("--")
        If ans <> "" Then Return False
        ans = clsAntiInjection.purifyText("---!-----")
        If ans <> "" Then Return False
        ans = clsAntiInjection.purifyText("---1--2----3--")
        If ans <> "-123" Then Return False
        ans = clsAntiInjection.purifyText("ABCXYZ \\abcxyz")
        If ans <> "ABCXYZ \\abcxyz" Then Return False
        ans = clsAntiInjection.purifyTextByChangeTo2byte("ABCXYZ \\--*//*=;',><()*?""abcxyz" & vbCrLf)
        If ans <> "ABCXYZ ￥￥－－＝；’，＞＜（）＊？’’abcxyz" Then Return False


        Return True
    End Function

    'regex 使いまわし(速度対策)
    Private Shared lstRegex As New System.Collections.Generic.Dictionary(Of String, Regex)
    Private Shared Function factRegex(ByVal strKey As String) As Regex
        If lstRegex.ContainsKey(strKey) Then
            Return lstRegex.Item(strKey)
        Else
            Dim myRegex As New Regex(strKey)
            lstRegex.Add(strKey, myRegex)
            Return myRegex
        End If
    End Function

    Public Shared Function isGoodText(ByVal strText As String, Optional ByVal isStrict As Boolean = True) As Boolean
        Dim strCapText As String = " " & strText.ToUpper & " "

        Dim myRegex As Regex
        Dim M As Match
        If isStrict = True Then
            myRegex = factRegex("[^0-9A-Za-z\-\.\$/\+\\ ]")
            M = myRegex.Match(strCapText)
            If M.Success Then
                Return False
            End If
        End If

        myRegex = factRegex("\-\-")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If

        myRegex = factRegex("/\*")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If

        myRegex = factRegex("\*/")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If


        myRegex = factRegex("DELETE")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If

        myRegex = factRegex("INSERT")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If

        myRegex = factRegex("UPDATE")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If

        myRegex = factRegex("WHERE")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If

        myRegex = factRegex(" LIKE ")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If

        myRegex = factRegex(" OR ")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If

        myRegex = factRegex("=")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If

        myRegex = factRegex(";")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If

        myRegex = factRegex("'")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If

        myRegex = factRegex("\x22") '["]
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If

        myRegex = factRegex("\x0D")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If

        myRegex = factRegex("\x0A")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return False
        End If

        Return True

    End Function
    Public Shared Function getMismatchText(ByVal strText As String, Optional ByVal isStrict As Boolean = True) As String
        'return code char[x]at[yy]  
        Dim strCapText As String = strText.ToUpper
        If isGoodText(strCapText) Then Return "char[]at[]"

        Dim myRegex As Regex
        Dim M As Match
        If isStrict = True Then
            myRegex = factRegex("[^0-9A-Za-z\-\.\$/\+\\ ]")
            M = myRegex.Match(strCapText)
            If M.Success Then
                Return "char[" & M.ToString & "]at[" & M.Index & "]"
            End If
        End If

        myRegex = factRegex("\-\-")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If

        myRegex = factRegex("/\*")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If

        myRegex = factRegex("\*/")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If


        myRegex = factRegex("DELETE")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If

        myRegex = factRegex("UPDATE")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If

        myRegex = factRegex("INSERT")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If

        myRegex = factRegex("WHERE")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If



        myRegex = factRegex(" LIKE ")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If

        myRegex = factRegex(" OR ")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If

        myRegex = factRegex("=")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If

        myRegex = factRegex(";")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If

        myRegex = factRegex("'")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If

        myRegex = factRegex("\x22") '["]
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If

        myRegex = factRegex("\x0D")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If

        myRegex = factRegex("\x0A")
        M = myRegex.Match(strCapText)
        If M.Success Then
            Return "char[" & M.ToString & "]at[" & M.Index & "]"
        End If



        Return "char[]at[]"

    End Function
    Public Shared Function purifyText(ByVal strText As String, Optional ByVal isStrict As Boolean = True) As String
        'return code: delete unwanted char

        'Dim strCapText As String = strText.ToUpper
        Dim strCapText As String = strText

        Dim myRegex As Regex
        If isStrict = True Then
            myRegex = factRegex("[^0-9A-Za-z\-\.\$/\+\\ ]")
            strCapText = myRegex.Replace(strCapText, "")
        End If

        'myRegex = factRegex("\-\-")
        'strCapText = myRegex.Replace(strCapText, "")
        'myRegex = factRegex("\*/")
        'strCapText = myRegex.Replace(strCapText, "")
        'myRegex = factRegex("/\*")
        'strCapText = myRegex.Replace(strCapText, "")
        'myRegex = factRegex("=")
        'strCapText = myRegex.Replace(strCapText, "")
        'myRegex = factRegex(";")
        'strCapText = myRegex.Replace(strCapText, "")
        'myRegex = factRegex("'")
        'strCapText = myRegex.Replace(strCapText, "")
        'myRegex = factRegex("\x22") '["]
        'strCapText = myRegex.Replace(strCapText, "")
        'myRegex = factRegex("\x0D")
        'strCapText = myRegex.Replace(strCapText, "")
        'myRegex = factRegex("\x0A")
        'strCapText = myRegex.Replace(strCapText, "")
        strCapText = strCapText.Replace("--", "").Replace("*/", "").Replace("/*", "").Replace("=", "").Replace(";", "").Replace("'", "").Replace(Chr(34), "").Replace(vbCr, "").Replace(vbLf, "")

        Return strCapText

    End Function
    Public Shared Function purifyTextByChangeTo2byte(ByVal strText As String) As String
        'return code: delete unwanted char

        'Dim strCapText As String = strText.ToUpper
        Dim strCapText As String = strText

        'Dim myRegex As Regex
        'myRegex = factRegex("\\")
        'strCapText = myRegex.Replace(strCapText, "￥")
        'myRegex = factRegex("\-\-")
        'strCapText = myRegex.Replace(strCapText, "－－")
        'myRegex = factRegex("\*/")
        'strCapText = myRegex.Replace(strCapText, "")
        'myRegex = factRegex("/\*")
        'strCapText = myRegex.Replace(strCapText, "")
        'myRegex = factRegex("=")
        'strCapText = myRegex.Replace(strCapText, "＝")
        'myRegex = factRegex(";")
        'strCapText = myRegex.Replace(strCapText, "；")
        'myRegex = factRegex("'")
        'strCapText = myRegex.Replace(strCapText, "’")
        'myRegex = factRegex(",")
        'strCapText = myRegex.Replace(strCapText, "，")
        'myRegex = factRegex(">")
        'strCapText = myRegex.Replace(strCapText, "＞")
        'myRegex = factRegex("<")
        'strCapText = myRegex.Replace(strCapText, "＜")
        'myRegex = factRegex("\)")
        'strCapText = myRegex.Replace(strCapText, "）")
        'myRegex = factRegex("\(")
        'strCapText = myRegex.Replace(strCapText, "（")
        'myRegex = factRegex("\*")
        'strCapText = myRegex.Replace(strCapText, "＊")
        'myRegex = factRegex("\?")
        'strCapText = myRegex.Replace(strCapText, "？")
        'myRegex = factRegex("\%")
        'strCapText = myRegex.Replace(strCapText, "％")
        'myRegex = factRegex("\x22") '["]
        'strCapText = myRegex.Replace(strCapText, "’’")
        'myRegex = factRegex("\x0D")
        'strCapText = myRegex.Replace(strCapText, "")
        'myRegex = factRegex("\x0A")
        'strCapText = myRegex.Replace(strCapText, "")

        strCapText = strCapText.Replace("\", "￥").Replace("--", "－－").Replace("*/", _
             "").Replace("/*", "").Replace("=", "＝").Replace(";", "；").Replace("'", _
             "’").Replace(",", "，").Replace(">", "＞").Replace("<", "＜").Replace(")", _
             "）").Replace("(", "（").Replace("*", "＊").Replace("?", "？").Replace("%", _
             "％").Replace(Chr(34), "’’").Replace(vbCr, "").Replace(vbLf, "")

        Return strCapText

    End Function


    'Public Shared Sub checkID(ByRef strLotNo As String, ByRef strUser As String)
    '    If clsAntiInjection.isGoodText(strLotNo) = False Then
    '        Throw New System.Exception("Error:LotNoFormatCheck:[" & strLotNo & "]")
    '    End If
    '    strLotNo = clsAntiInjection.purifyText(strLotNo)
    '    If clsAntiInjection.isGoodText(strUser) = False Then
    '        Throw New System.Exception("Error:UserFormatCheck:[" & strUser & "]")
    '    End If
    '    strUser = clsAntiInjection.purifyText(strUser)
    'End Sub
    'Public Shared Sub checkID(ByRef strText As String, ByRef strUser As String, ByVal strSignature As String)
    '    If clsAntiInjection.isGoodText(strText) = False Then
    '        Throw New System.Exception("Error:TextFormatCheck:[" & strText & "]" & strSignature)
    '    End If
    '    strText = clsAntiInjection.purifyText(strText)
    '    If clsAntiInjection.isGoodText(strUser) = False Then
    '        Throw New System.Exception("Error:UserFormatCheck:[" & strUser & "]")
    '    End If
    '    strUser = clsAntiInjection.purifyText(strUser)
    'End Sub

    Public Shared Sub checkID(ByRef strLotNo As String, ByRef strUser As String)
        If clsAntiInjection.isGoodText(strLotNo) = False Then
            Throw New System.Exception("Error:LotNoFormatCheck:[" & strLotNo & "]")
        End If
        strLotNo = clsAntiInjection.purifyText(strLotNo)
        If clsAntiInjection.isGoodText(strUser, False) = False Then
            Throw New System.Exception("Error:UserFormatCheck:[" & strUser & "]")
        End If
        strUser = clsAntiInjection.purifyTextByChangeTo2byte(strUser)
    End Sub
    Public Shared Sub checkID(ByRef strText As String, ByRef strUser As String, ByVal strSignature As String)
        If clsAntiInjection.isGoodText(strText) = False Then
            Throw New System.Exception("Error:TextFormatCheck:[" & strText & "]" & strSignature)
        End If
        strText = clsAntiInjection.purifyText(strText)
        If clsAntiInjection.isGoodText(strUser, False) = False Then
            Throw New System.Exception("Error:UserFormatCheck:[" & strUser & "]")
        End If
        strUser = clsAntiInjection.purifyTextByChangeTo2byte(strUser)
    End Sub

    Public Shared Sub checkText(ByRef strText As String, ByVal strSignature As String, Optional ByVal isStrict As Boolean = True)
        If clsAntiInjection.isGoodText(strText, isStrict) = False Then
            Throw New System.Exception("Error:TextFormatCheck:[" & strText & "]" & strSignature)
        End If
        strText = clsAntiInjection.purifyText(strText, isStrict)
    End Sub

    'Public Shared Sub checkOption(ByRef cOptions As clsOptions)
    '    Dim strCol() As String = {"BoxBoard", "Probe", "Card", "Option"}
    '    For Each strC As String In strCol
    '        If clsAntiInjection.isGoodText(cOptions.Status(strC), False) = False Then
    '            Throw New System.Exception("Error:TextFormatCheck:[" & cOptions.Status(strC) & "]" & strC)
    '        End If
    '    Next
    'End Sub

End Class

