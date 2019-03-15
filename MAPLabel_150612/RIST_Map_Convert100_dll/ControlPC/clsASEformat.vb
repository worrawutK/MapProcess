

Public Class clsASEformat
    Public Shared Function ConvertMapdata(ByVal strpath As String, ByVal LotNo As String, ByVal RingNo As Integer, ByVal Device_columns As Integer, _
                                          ByVal Device_rows As Integer, ByVal Block_columns As Integer, ByVal Block_rows As Integer, ByRef mapd(,) As String, ByRef pass As Integer, ByRef fail As Integer) As Boolean
        Dim path As String = ""
        Dim textfile As IO.StreamReader = Nothing
        Dim stripmap As String
        If IO.File.Exists(strpath) = False Then Return False

        Try
            textfile = New IO.StreamReader(strpath, System.Text.Encoding.Default)
            stripmap = textfile.ReadLine
            textfile.Dispose()
            textfile = Nothing
            If stripmap.Length <> Device_columns * Device_rows * Block_columns * Block_rows Then
                Return False
            End If
            Dim dir As Boolean
            Dim brow As Integer = 0
            Dim bcol As Integer = 0
            Dim drow As Integer = 0
            Dim dcol As Integer = 0
            Dim c As Integer = 0
            dir = True

            For bcol = Block_columns - 1 To 0 Step -1
                For brow = Block_rows - 1 To 0 Step -1
                    For drow = Device_rows - 1 To 0 Step -1
                        If dir Then
                            For dcol = 0 To Device_columns - 1
                                mapd(brow * Device_rows + drow, bcol * Device_columns + dcol) = stripmap.Chars(c)
                                If stripmap.Chars(c) = "0" Then pass += 1
                                If stripmap.Chars(c) = "1" Then fail += 1
                                c += 1
                            Next
                            dir = False
                        Else
                            For dcol = Device_columns - 1 To 0 Step -1
                                mapd(brow * Device_rows + drow, bcol * Device_columns + dcol) = stripmap.Chars(c)
                                If stripmap.Chars(c) = "0" Then pass += 1
                                If stripmap.Chars(c) = "1" Then fail += 1
                                c += 1
                            Next
                            dir = True
                        End If
                    Next
                Next
            Next
            'fail = Device_columns * Block_columns * Device_rows * Block_rows - pass

        Catch ex As Exception
            If textfile IsNot Nothing Then
                textfile.Dispose()
            End If
            Return False
        End Try
        Return True
    End Function
End Class
