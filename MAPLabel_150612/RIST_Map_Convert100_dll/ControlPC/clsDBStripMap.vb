'general purpose interface class for DB operation with Transaction (not shared)
'need to set key, columns, allcolumns (keys+columns)
'
'DBinsert
'DBupdate
'DBdelete
'DBselect
'
'
'change to another table...?
'set keys
'set columns
'set allcolumns as keys+columns
'change tableName
'set tableinfo
'
'update test code (if necessary)

'option 
'  [=]:match                                          -                     insert
'  [!=][<>]:not match [%]:like [!%]:not like          -   select, isexist, (ignore) update, delete
'    (**** [lt,le,gt,ge]...TBD)
'  [W][w][I][i]: use as write-in                      -                     insert, update
'  [R][r][O][o]: use as read-out                      -   select           (ignore)
'  "": use as read-out                                -   select           (ignore)

'2011/09/09 for WEB
'ReadMode:don't care on Value (func isReadOption - sub SetValue is modified 2011/12/1)
'2012/10/17 modify for varcharMax (skip sizecheck if tableinfo definition >8000 )
'2012/10/18 add for binary (please use as >8000)  Note: binary data can not used for match key       (internal data: string '0xXXYYZZ')

Public Class clsDBStripMap
    Private importLetterCapitalize As Boolean = False
    Const HEADER As String = "clsDBStripMap"
    Enum keys
        StripID
    End Enum
    Enum columns
        ASELotNo
        AssyLotNo
        RingID
        Columns
        Rows
        Pass
        Ng
        InTime
        UseTime
        StripMap
        Coments
        CompleteFlag
    End Enum
    Enum allcolumns
        StripID
        ASELotNo
        AssyLotNo
        RingID
        Columns
        Rows
        Pass
        Ng
        InTime
        UseTime
        StripMap
        Coments
        CompleteFlag
    End Enum

    Const tableName As String = "tbl_StripMap"
    Public Shared Function test(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction) As Boolean
        Dim DB As New clsDBStripMap(connect, transact)

        DB.setValue(keys.StripID, "xxxxx", "=")
        DB.DBdelete()

        DB.setValue(keys.StripID, "xxxxx", "=")
        DB.setValue(columns.ASELotNo, "zzzzz", "w")
        If DB.DBinsert() <> "True" Then Return False

        DB.setValue(keys.StripID, "xxxxx", "=")
        DB.setValue(columns.ASELotNo, "yyyyy", "w")
        If DB.DBupdate() <> "True" Then Return False
        Return True
    End Function
    Public Sub New(ByRef connect As System.Data.SqlClient.SqlConnection, ByRef transact As System.Data.SqlClient.SqlTransaction)
        _sqlcn = connect
        _sqltran = transact
        initHashtable()
    End Sub

    Private Function tableinfo() As String()
        '[column name],[type],[digit-1],[digit-2],[init value]

        'usable type: varchar, decimal, datetime, binary

        Dim ans() As String = New String() { _
        "StripID", "varchar", 30, 0, "Unknown", _
        "ASELotNo", "varchar", 30, 0, "Unknown", _
        "AssyLotNo", "varchar", 30, 0, "Unknown", _
        "RingID", "varchar", 30, "", "Unknown", _
        "Columns", "varchar", 10, "", "Unknown", _
        "Rows", "varchar", 10, "", "Unknown", _
        "Pass", "varchar", 10, "", "Unknown", _
        "Ng", "varchar", 10, "", "Unknown", _
        "InTime", "datetime", "", "", "2000-01-01 00:00:00", _
        "UseTime", "datetime", "", "", "2000-01-01 00:00:00", _
        "StripMap", "binary", 9999, "", "0x00", _
        "Coments", "varchar", 100, "", "", _
        "CompleteFlag", "varchar", 1, "", "" _
         }
        Return ans
    End Function
    Public _errmsg As String
    Property ErrorMessage() As String
        Get
            Return _errmsg
        End Get
        Set(ByVal value As String)
            _errmsg = value
        End Set
    End Property
    Private htType As Hashtable
    Private htDigit1 As Hashtable
    Private htDigit2 As Hashtable
    Private htValue As Hashtable
    Private htOption As Hashtable
    Private _sqlcn As System.Data.SqlClient.SqlConnection
    Private _sqltran As System.Data.SqlClient.SqlTransaction
    Property SqlCn() As System.Data.SqlClient.SqlConnection
        Get
            Return _sqlcn
        End Get
        Set(ByVal value As System.Data.SqlClient.SqlConnection)
            _sqlcn = value
        End Set
    End Property
    Property SqlTran() As System.Data.SqlClient.SqlTransaction
        Get
            Return _sqltran
        End Get
        Set(ByVal value As System.Data.SqlClient.SqlTransaction)
            _sqltran = value
        End Set
    End Property
    Private Sub initHashtable()
        Dim tbl() As String = tableinfo()
        If tbl.Length Mod 5 <> 0 Then
            clsErrorLog.addlogWT("column init table format error!" & vbCrLf & "count is " & tbl.Length, HEADER)
            Exit Sub
        End If
        htType = New Hashtable
        htDigit1 = New Hashtable
        htDigit2 = New Hashtable
        htValue = New Hashtable
        htOption = New Hashtable
        Dim i As Integer = 0
        Do
            htType.Add(tbl(i), tbl(i + 1))
            htDigit1.Add(tbl(i), tbl(i + 2))
            htDigit2.Add(tbl(i), tbl(i + 3))
            htadd(tbl(i), tbl(i + 4))
            i = i + 5
            If i >= tbl.Length Then Exit Do
        Loop
    End Sub
    Public Function getValue(ByVal strColname As String) As String
        If htValue(strColname) Is Nothing Then
            Return Nothing
        ElseIf htValue(strColname).GetType.Name = "DateTime" Then
            Return Format(htValue(strColname), "yyyy-MM-dd HH:mm:ss")
        Else
            Return htValue(strColname)
        End If
    End Function
    Public Function getValue(ByVal col As allcolumns) As String
        Dim colname As String
        colname = [Enum].GetName(GetType(allcolumns), col)
        If htValue(colname) Is Nothing Then
            Return Nothing
        ElseIf htValue(colname).GetType.Name = "DateTime" Then
            Return Format(htValue(colname), "yyyy-MM-dd HH:mm:ss")
        Else
            Return htValue(colname)
        End If
    End Function
    Public Function getValue(ByVal col As columns) As String
        Dim colname As String
        colname = [Enum].GetName(GetType(columns), col)
        If htValue(colname) Is Nothing Then
            Return Nothing
        ElseIf htValue(colname).GetType.Name = "DateTime" Then
            Return Format(htValue(colname), "yyyy-MM-dd HH:mm:ss")
        Else
            Return htValue(colname)
        End If
    End Function
    Public Function getValue(ByVal col As keys) As String
        Dim colname As String
        colname = [Enum].GetName(GetType(keys), col)
        If htValue(colname) Is Nothing Then
            Return Nothing
        ElseIf htValue(colname).GetType.Name = "DateTime" Then
            Return Format(htValue(colname), "yyyy-MM-dd HH:mm:ss")
        Else
            Return htValue(colname)
        End If
    End Function
    Private Function isReadOption(ByVal strOption As String) As Boolean
        Select Case strOption
            Case "", "R", "r", "O", "o"
                Return True
            Case Else
                Return False
        End Select
    End Function
    Public Sub setValue(ByVal col As allcolumns, ByVal value As String, ByVal strOption As String)
        If Not isReadOption(strOption) Then _setValue(col, value)
        _setOption(col, strOption)
    End Sub
    Public Sub setValue(ByVal col As columns, ByVal value As String, ByVal strOption As String)
        If Not isReadOption(strOption) Then _setValue(col, value)
        _setOption(col, strOption)
    End Sub
    Public Sub setValue(ByVal col As keys, ByVal value As String, ByVal strOption As String)
        If Not isReadOption(strOption) Then _setValue(col, value)
        _setOption(col, strOption)
    End Sub
    Private Sub _setValue(ByVal col As allcolumns, ByVal value As String)
        Dim colname As String
        colname = [Enum].GetName(GetType(allcolumns), col)
        htadd(colname, strTrim(colname, value))
    End Sub
    Private Sub _setValue(ByVal col As columns, ByVal value As String)
        Dim colname As String
        colname = [Enum].GetName(GetType(columns), col)
        htadd(colname, strTrim(colname, value))
    End Sub
    Private Sub _setValue(ByVal col As keys, ByVal value As String)
        Dim colname As String
        colname = [Enum].GetName(GetType(keys), col)
        htadd(colname, strTrim(colname, value))
    End Sub
    Private Function strTrim(ByVal colname As String, ByVal value As String) As String
        If Me.htType(colname) <> "varchar" Then Return value
        If Convert.ToInt32(Me.htDigit1(colname)) > 8000 Then Return value
        If Me.htDigit1(colname) < clsShiftJISChar.LenB(value) Then
            Return clsShiftJISChar.LeftByte(value, Me.htDigit1(colname))
        Else
            Return value
        End If
    End Function
    Private Sub _setOption(ByVal col As allcolumns, ByVal strOption As String)
        Dim colname As String
        colname = [Enum].GetName(GetType(allcolumns), col)
        htoadd(colname, strOption)
    End Sub
    Private Sub _setOption(ByVal col As columns, ByVal strOption As String)
        Dim colname As String
        colname = [Enum].GetName(GetType(columns), col)
        htoadd(colname, strOption)
    End Sub
    Private Sub _setOption(ByVal col As keys, ByVal strOption As String)
        Dim colname As String
        colname = [Enum].GetName(GetType(keys), col)
        htoadd(colname, strOption)
    End Sub
    Private Sub htadd(ByVal col As String, ByVal objvalue As Object)
        Dim dmy As String = objvalue.GetType.ToString
        If objvalue Is System.DBNull.Value Then
            If htValue.ContainsKey(col) Then
                htValue(col) = Nothing
            Else
                htValue.Add(col, Nothing)
            End If
        ElseIf objvalue.GetType.ToString = "System.Byte[]" Then
            htadd(col, "0x" & BitConverter.ToString(objvalue).Replace("-", ""))
        Else
            If importLetterCapitalize Then
                htadd(col, objvalue.ToString.ToUpper)
            Else
                htadd(col, objvalue.ToString)
            End If
        End If
    End Sub
    Private Sub htadd(ByVal col As String, ByVal value As String)
        If htValue.ContainsKey(col) Then
            htValue(col) = getTrimmedValue(col, value)
        Else
            htValue.Add(col, getTrimmedValue(col, value))
        End If
    End Sub
    Private Sub htoadd(ByVal col As String, ByVal strOption As String)
        If htOption.ContainsKey(col) Then
            htOption(col) = strOption
        Else
            htOption.Add(col, strOption)
        End If
    End Sub
    Private Function getTrimmedValue(ByVal col As String, ByVal value As String) As Object
        If value Is Nothing Then Return Nothing
        If value.ToLower = "null" Then Return Nothing
        If value.ToLower = "nothing" Then Return Nothing
        If importLetterCapitalize Then value = value.ToUpper
        Try
            Select Case htType(col)
                Case "string", "varchar"
                    Dim strDigit1 As String = htDigit1(col)
                    If strDigit1 > 8000 Then Return value
                    Return value.Substring(0, System.Math.Min(Convert.ToInt32(strDigit1), value.Length))
                Case "decimal"
                    Dim strDigit1 As String = htDigit1(col)
                    Dim strDigit2 As String = htDigit2(col)
                    Dim ansDec As Decimal = Convert.ToDecimal(value)
                    If ansDec > (10 ^ strDigit1 - 1) + (1 - (0.1) ^ strDigit2) Then
                        ansDec = (10 ^ strDigit1 - 1) + (1 - (0.1) ^ strDigit2)
                    End If
                    'If ansDec < ((0.1) ^ strDigit2) Then
                    '    ansDec = ((0.1) ^ strDigit2)
                    'End If
                    Return ansDec
                Case "datetime"
                    Return Convert.ToDateTime(value)
                Case Else
                    Return value
            End Select
        Catch ex As Exception
            Dim strErr As String = "conversion error!" & vbCrLf & "col= " & col & vbCrLf & "value= " & value & vbCrLf & "type= " & htType(col)
            clsErrorLog.addlogWT(strErr & ":" & Me.GetType.ToString & "/getTrimmedValue" & ex.ToString, HEADER)
            Return Nothing
        End Try
    End Function
    Private Function isExist() As Boolean

        Dim sqlcmd As New System.Data.SqlClient.SqlCommand
        sqlcmd.Connection = _sqlcn
        sqlcmd.Transaction = _sqltran

        Try
            Dim i As Integer
            sqlcmd.CommandText = "SELECT count(*) FROM " & tableName & " WHERE "
            For Each strCol As String In [Enum].GetNames(GetType(allcolumns))
                Select Case htOption(strCol)
                    Case "="
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " = null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " = '" & htValue(strCol) & "' AND "
                        End If
                    Case "!=", "<>"
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " != null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " != '" & htValue(strCol) & "' AND "
                        End If
                    Case "%"
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " = null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " like '" & htValue(strCol) & "' AND "
                        End If
                    Case "!%"
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " != null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " not like '" & htValue(strCol) & "' AND "
                        End If
                End Select
            Next
            sqlcmd.CommandText = sqlcmd.CommandText.Substring(0, sqlcmd.CommandText.Length - "AND ".Length)
            i = sqlcmd.ExecuteScalar
            If i = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        Finally
        End Try
    End Function
    Public Function DBselect() As String
        'return value 
        '"True": success
        '"other": failure
        If isExist() = False Then
            Return "Error: No Record Found"
        End If

        Dim sqlcmd As New System.Data.SqlClient.SqlCommand
        sqlcmd.Connection = _sqlcn
        sqlcmd.Transaction = _sqltran

        Dim ans As String = "Error"
        Dim reader As System.Data.SqlClient.SqlDataReader = Nothing
        Try
            sqlcmd.CommandText = "SELECT * FROM " & tableName & " WHERE "
            For Each strCol As String In [Enum].GetNames(GetType(allcolumns))
                Select Case htOption(strCol)
                    Case "="
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " = null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " = '" & htValue(strCol) & "' AND "
                        End If
                    Case "!=", "<>"
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " != null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " != '" & htValue(strCol) & "' AND "
                        End If
                    Case "%"
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " = null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " like '" & htValue(strCol) & "' AND "
                        End If
                    Case "!%"
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " != null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " not like '" & htValue(strCol) & "' AND "
                        End If
                End Select
            Next
            sqlcmd.CommandText = sqlcmd.CommandText.Substring(0, sqlcmd.CommandText.Length - "AND ".Length)
            reader = sqlcmd.ExecuteReader
            reader.Read()

            For Each strCol As String In [Enum].GetNames(GetType(allcolumns))
                Select Case htOption(strCol)
                    Case "R", "r", "O", "o", "", Nothing
                        htadd(strCol, reader.Item(strCol))
                End Select
            Next
            reader.Close()

            Return "True"
        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & ex.ToString & "," & Me.GetType.ToString & "/DBSelect", HEADER)
            Return "Error:" & ex.ToString
        Finally
            If Not reader Is Nothing Then
                If reader.IsClosed = False Then
                    reader.Close()
                End If
                reader = Nothing
            End If
        End Try
        Return ans
    End Function
    Public Function DBinsert() As String
        'return value 
        '"True": success
        '"other": failure
        If isExist() = True Then
            Return "Error: Record Already Exist"
        End If

        Dim sqlcmd As New System.Data.SqlClient.SqlCommand
        sqlcmd.Connection = _sqlcn
        sqlcmd.Transaction = _sqltran

        Dim ans As String = "Error:undefined error"
        Try

            Dim strColList As String = "( "
            Dim strValueList As String = "( "

            For Each strCol As String In [Enum].GetNames(GetType(allcolumns))
                'Select Case htOption(strCol)
                '    Case "=", "W", "w", "I", "i"
                If htValue(strCol) Is Nothing Then
                    strColList &= strCol & ", "
                    strValueList &= "null, "
                ElseIf htType(strCol) = "binary" Then
                    strColList &= strCol & ", "
                    strValueList &= htValue(strCol) & ", "
                Else
                    strColList &= strCol & ", "
                    strValueList &= "'" & htValue(strCol) & "', "
                End If
                'End Select
            Next
            strColList = strColList.Substring(0, strColList.Length - ", ".Length) & " )"
            strValueList = strValueList.Substring(0, strValueList.Length - ", ".Length) & " )"
            sqlcmd.CommandText = "INSERT INTO " & tableName & strColList & _
                             " VALUES " & strValueList
            sqlcmd.ExecuteNonQuery()
            Return "True"

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & ex.ToString & "," & Me.GetType.ToString & "/DBinsert", HEADER)
            Return "Error:" & ex.ToString
        Finally
        End Try
        Return ans
    End Function
    Public Function DBupdate() As String
        'return value 
        '"True": success
        '"other": failure
        If isExist() = False Then
            Return "Error:  No Record Found"
        End If

        Dim sqlcmd As New System.Data.SqlClient.SqlCommand
        sqlcmd.Connection = _sqlcn
        sqlcmd.Transaction = _sqltran

        Dim ans As String = "Error:undefined error"
        Try

            Dim strColumnsList As String = ""
            Dim strKeysList As String = ""

            For Each strCol As String In [Enum].GetNames(GetType(allcolumns))
                Select Case htOption(strCol)
                    Case "W", "w", "I", "i"
                        If htValue(strCol) Is Nothing Then
                            strColumnsList &= strCol & " = null, "
                        ElseIf htType(strCol) = "binary" Then
                            strColumnsList &= strCol & " = " & htValue(strCol) & ", "
                        Else
                            strColumnsList &= strCol & " = '" & htValue(strCol) & "', "
                        End If
                End Select
            Next
            strColumnsList = strColumnsList.Substring(0, strColumnsList.Length - ", ".Length) & " "

            For Each strCol As String In [Enum].GetNames(GetType(allcolumns))
                Select Case htOption(strCol)
                    Case "="
                        If htValue(strCol) Is Nothing Then
                            strKeysList &= strCol & " = null AND "
                        ElseIf htType(strCol) = "binary" Then
                        Else
                            strKeysList &= strCol & "= '" & htValue(strCol) & "' AND "
                        End If
                    Case "!=", "<>"
                        If htValue(strCol) Is Nothing Then
                            strKeysList &= strCol & " != null AND "
                        ElseIf htType(strCol) = "binary" Then
                        Else
                            strKeysList &= strCol & " != '" & htValue(strCol) & "' AND "
                        End If
                    Case "%"
                        If htValue(strCol) Is Nothing Then
                            strKeysList &= strCol & " = null AND "
                        ElseIf htType(strCol) = "binary" Then
                        Else
                            strKeysList &= strCol & " like '" & htValue(strCol) & "' AND "
                        End If
                    Case "!%"
                        If htValue(strCol) Is Nothing Then
                            strKeysList &= strCol & " != null AND "
                        ElseIf htType(strCol) = "binary" Then
                        Else
                            strKeysList &= strCol & " not like '" & htValue(strCol) & "' AND "
                        End If
                End Select
            Next

            strKeysList = strKeysList.Substring(0, strKeysList.Length - "AND ".Length)

            sqlcmd.CommandText = "UPDATE " & tableName & " SET " & _
                                strColumnsList & _
                             " WHERE " & strKeysList
            sqlcmd.ExecuteNonQuery()
            Return "True"

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & ex.ToString & "," & Me.GetType.ToString & "/DBupdate", HEADER)
            Return "Error:" & ex.ToString
        Finally
        End Try
        Return ans
    End Function
    Public Function DBinsertORupdate() As String
        If isExist() Then
            Return DBupdate()
        Else
            Return DBinsert()
        End If
    End Function
    Public Function DBdelete() As String
        'return value 
        '"True": success
        '"other": failure
        If isExist() = False Then
            Return "Error:  No Record Found"
        End If

        Dim sqlcmd As New System.Data.SqlClient.SqlCommand
        sqlcmd.Connection = _sqlcn
        sqlcmd.Transaction = _sqltran

        Dim ans As String = "Error:undefined error"
        Try

            Dim strKeysList As String = ""

            For Each strCol As String In [Enum].GetNames(GetType(allcolumns))
                Select Case htOption(strCol)
                    Case "="
                        If htValue(strCol) Is Nothing Then
                            strKeysList &= strCol & " = null AND "
                        ElseIf htType(strCol) = "binary" Then
                        Else
                            strKeysList &= strCol & " = '" & htValue(strCol) & "' AND "
                        End If
                    Case "!=", "<>"
                        If htValue(strCol) Is Nothing Then
                            strKeysList &= strCol & " != null AND "
                        ElseIf htType(strCol) = "binary" Then
                        Else
                            strKeysList &= strCol & " != '" & htValue(strCol) & "' AND "
                        End If
                    Case "%"
                        If htValue(strCol) Is Nothing Then
                            strKeysList &= strCol & "= null AND "
                        ElseIf htType(strCol) = "binary" Then
                        Else
                            strKeysList &= strCol & " like '" & htValue(strCol) & "' AND "
                        End If
                    Case "!%"
                        If htValue(strCol) Is Nothing Then
                            strKeysList &= strCol & " != null AND "
                        ElseIf htType(strCol) = "binary" Then
                        Else
                            strKeysList &= strCol & " not like '" & htValue(strCol) & "' AND "
                        End If
                End Select
            Next
            strKeysList = strKeysList.Substring(0, strKeysList.Length - "AND ".Length)

            sqlcmd.CommandText = "DELETE " & tableName & _
                             " WHERE " & strKeysList
            sqlcmd.ExecuteNonQuery()

            initHashtable()
            Return "True"

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & ex.ToString & "," & Me.GetType.ToString & "/DBdelete", HEADER)
            Return "Error:" & ex.ToString
        Finally
        End Try
        Return ans
    End Function
    Public Function getDataCSV(ByVal coltype As String, Optional ByVal withHeader As Boolean = False) As String
        Dim ans As New System.Text.StringBuilder
        Select Case coltype.ToLower
            Case "key", "keys"
                If withHeader Then
                    For Each strCol As String In [Enum].GetNames(GetType(keys))
                        ans.Append(strCol & ",")
                    Next
                    ans.Append(vbCrLf)
                End If
                For Each strCol As String In [Enum].GetNames(GetType(keys))
                    ans.Append(getValue(strCol) & ",")
                Next
                ans.Append(vbCrLf)
            Case "column", "columns"
                If withHeader Then
                    For Each strCol As String In [Enum].GetNames(GetType(columns))
                        ans.Append(strCol & ",")
                    Next
                    ans.Append(vbCrLf)
                End If
                For Each strCol As String In [Enum].GetNames(GetType(columns))
                    ans.Append(getValue(strCol) & ",")
                Next
                ans.Append(vbCrLf)
            Case Else
                If withHeader Then
                    For Each strCol As String In [Enum].GetNames(GetType(allcolumns))
                        ans.Append(strCol & ",")
                    Next
                    ans.Append(vbCrLf)
                End If
                For Each strCol As String In [Enum].GetNames(GetType(allcolumns))
                    ans.Append(getValue(strCol) & ",")
                Next
                ans.Append(vbCrLf)
        End Select
        Return ans.ToString
    End Function
    Public Shared Function HexStringToBytes(ByVal strHex As String) As Byte()
        'strHex format: must be 0xXXYYZZ (XX,YY,ZZ: hex char 00-FF)

        Dim lngLength As Long = strHex.Length / 2 - "0x".Length / 2
        Dim ans As Byte()
        ReDim ans(lngLength - 1)

        For intI As Integer = 0 To lngLength - 1
            ans(intI) = Convert.ToByte(strHex.Substring("0x".Length + intI * 2, 2), 16)
        Next

        Return ans

    End Function
    Public Function DBselectCount() As String
        'return value 
        '"True": success
        '"other": failure
        ' If isExist() = False Then
        'Return "Error: No Record Found"
        'End If

        Dim sqlcmd As New System.Data.SqlClient.SqlCommand
        sqlcmd.Connection = _sqlcn
        sqlcmd.Transaction = _sqltran

        Dim ans As String = "Error"
        Try
            Dim i As Integer
            sqlcmd.CommandText = "SELECT count(*) FROM " & tableName & " WHERE "
            For Each strCol As String In [Enum].GetNames(GetType(allcolumns))
                Select Case htOption(strCol)
                    Case "="
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " = null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " = '" & htValue(strCol) & "' AND "
                        End If
                    Case "!=", "<>"
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " != null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " != '" & htValue(strCol) & "' AND "
                        End If
                    Case "%"
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & "= null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " like '" & htValue(strCol) & "' AND "
                        End If
                    Case "!%"
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " != null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " not like '" & htValue(strCol) & "' AND "
                        End If
                End Select
            Next
            sqlcmd.CommandText = sqlcmd.CommandText.Substring(0, sqlcmd.CommandText.Length - "AND ".Length)
            i = sqlcmd.ExecuteScalar

            Return CStr(i)

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & ex.ToString & "," & Me.GetType.ToString & "/DBSelectCount", HEADER)
            Return "Error:" & ex.ToString
        Finally
        End Try
        Return ans
    End Function
    Public Function DBselectItem(ByVal strItem As String) As String
        'return value 
        '"True": success
        '"other": failure
        If isExist() = False Then
            Return "Error: No Record Found"
        End If

        Dim sqlcmd As New System.Data.SqlClient.SqlCommand
        sqlcmd.Connection = _sqlcn
        sqlcmd.Transaction = _sqltran

        Dim ans As String = "Error"
        Dim reader As System.Data.SqlClient.SqlDataReader = Nothing
        Try
            sqlcmd.CommandText = "SELECT * FROM " & tableName & " WHERE "
            For Each strCol As String In [Enum].GetNames(GetType(allcolumns))
                Select Case htOption(strCol)
                    Case "="
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " = null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " = '" & htValue(strCol) & "' AND "
                        End If
                    Case "!=", "<>"
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " != null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " != '" & htValue(strCol) & "' AND "
                        End If
                    Case "%"
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " = null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " like '" & htValue(strCol) & "' AND "
                        End If
                    Case "!%"
                        If htValue(strCol) Is Nothing Then
                            sqlcmd.CommandText &= strCol & " != null AND "
                        Else
                            sqlcmd.CommandText &= strCol & " not like '" & htValue(strCol) & "' AND "
                        End If
                End Select
            Next
            sqlcmd.CommandText = sqlcmd.CommandText.Substring(0, sqlcmd.CommandText.Length - "AND ".Length)
            reader = sqlcmd.ExecuteReader
            Dim value As String = ""
            Do While (reader.Read())
                value = value & reader.Item(strItem) & ","
            Loop
            reader.Close()
            value = value.TrimEnd(",")

            Return value

        Catch ex As Exception
            clsErrorLog.addlogWT("Error:" & ex.ToString & "," & Me.GetType.ToString & "/DBSelectItem", HEADER)
            Return "Error:" & ex.ToString
        Finally
            If Not reader Is Nothing Then
                If reader.IsClosed = False Then
                    reader.Close()
                End If
                reader = Nothing
            End If
        End Try
        Return ans
    End Function
End Class
