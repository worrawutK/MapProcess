Imports System.IO
Imports System.Xml
Imports System.Text
Imports MapConvert.clsASEformat
Public Class clsXmlConvert

    Public Structure LotData
        Public LotNo As String
        Public Device As String
        Public Package As String
        Public Block_columns As Integer
        Public Block_rows As Integer
        Public Device_columns As Integer
        Public Device_rows As Integer
        Public Device_size_x As Integer
        Public Device_size_y As Integer
        Public Ring_Qty As Integer
        Public Machine As String
    End Structure

    Private Structure Ringdata
        Dim ring_ID As Integer
        Dim mapd(,) As String
        Dim pass As Integer
        Dim fail As Integer
    End Structure

    Public Function XmlConvert(ByVal dLotdata As LotData, ByVal strSerchpath As String, ByVal strResultpath As String, ByVal strAssyLotNo As String) As String

        Dim dtNow = Now
        Dim strNow As String = Format(dtNow, "yyyy/MM/dd HH:mm:ss")
        Dim pass_fail As Integer = 0
        Dim bcol As Integer = 0
        Dim brow As Integer = 0
        Dim dcol As Integer = 0
        Dim drow As Integer = 0
        Dim ring(Ring_Max) As Ringdata
        Dim ring_No As Integer    

        Dim pass_total As Integer = 0
        Dim fail_total As Integer = 0
        Dim total As Integer = 0
        For ring_No = 1 To Ring_Max
            ring(ring_No).ring_ID = 0
        Next
        Dim filecount As Integer = System.IO.Directory.GetFiles(strSerchpath, "T" & strAssyLotNo & "*.MAP").Length
        If filecount = 0 Then Return "Error:No Files"

        For Each strfile As String In System.IO.Directory.GetFiles(strSerchpath & "\", "T" & strAssyLotNo & "*.MAP")
            ring_No = strfile.Substring(strfile.Length - 6, 2)
            ReDim Preserve ring(ring_No).mapd(dLotdata.Device_rows * dLotdata.Block_rows - 1, dLotdata.Device_columns * dLotdata.Block_columns - 1)
            If ConvertMapdata(strfile, dLotdata.LotNo, ring_No, dLotdata.Device_columns, dLotdata.Device_rows, dLotdata.Block_columns, dLotdata.Block_rows, ring(ring_No).mapd, ring(ring_No).pass, ring(ring_No).fail) = True Then
                ring(ring_No).ring_ID = ring_No
                pass_total += ring(ring_No).pass
                fail_total += ring(ring_No).fail
                total = pass_total + fail_total
            Else
                ring(ring_No).ring_ID = 0
                clsErrorLog.addlogWT("Error:XmlConvert:NoGoodFormat", "XmlConvert")
                Return "Error:XmlConvert:No Good Format"
            End If
        Next
        Dim xmlwriter As New XmlTextWriter(strResultpath & "\" & dLotdata.LotNo & "_LOT.XML", System.Text.Encoding.GetEncoding("Shift_Jis"))

        Try
            xmlwriter.Formatting = Formatting.Indented
            xmlwriter.Indentation = 2
            xmlwriter.WriteStartDocument()
            xmlwriter.WriteStartElement("lotdata")
            xmlwriter.WriteStartElement("product_id")
            xmlwriter.WriteString(dLotdata.Device)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("package_id")
            xmlwriter.WriteString(dLotdata.Package)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("lot_id")
            xmlwriter.WriteString(dLotdata.LotNo)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("device_size_x")
            xmlwriter.WriteString(dLotdata.Device_size_x.ToString)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("device_size_y")
            xmlwriter.WriteString(dLotdata.Device_size_y.ToString)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("block_columns")
            xmlwriter.WriteString(dLotdata.Block_columns.ToString)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("block_rows")
            xmlwriter.WriteString(dLotdata.Block_rows.ToString)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("device_columns")
            xmlwriter.WriteString(dLotdata.Device_columns.ToString)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("device_rows")
            xmlwriter.WriteString(dLotdata.Device_rows.ToString)
            xmlwriter.WriteEndElement()

            xmlwriter.WriteStartElement("orientation")
            xmlwriter.WriteString("270")
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("ring_total")
            xmlwriter.WriteString(dLotdata.Ring_Qty.ToString)
            xmlwriter.WriteEndElement()

            xmlwriter.WriteStartElement("log")

            xmlwriter.WriteStartElement("machine_id")
            xmlwriter.WriteString(dLotdata.Machine)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("test_type")
            xmlwriter.WriteString("0")
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("tester")
            xmlwriter.WriteString("1")
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("test_mode")
            xmlwriter.WriteString("0")
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("prefail_total")
            xmlwriter.WriteString(fail_total.ToString)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("measure_total")
            xmlwriter.WriteString(total.ToString)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("measure_fail_total")
            xmlwriter.WriteString(fail_total.ToString)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("pass_total")
            xmlwriter.WriteString(pass_total.ToString)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("fail_total")
            xmlwriter.WriteString(fail_total.ToString)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("fail_os_total")
            xmlwriter.WriteString(fail_total.ToString)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("start_time")
            xmlwriter.WriteString(strNow)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("end_time")
            xmlwriter.WriteString(strNow)
            xmlwriter.WriteEndElement()

            xmlwriter.WriteEndElement() 'log

            For ring_No = 1 To Ring_Max
                If ring(ring_No).ring_ID <> 0 Then
                    xmlwriter.WriteStartElement("map")

                    xmlwriter.WriteStartElement("ring_id")
                    xmlwriter.WriteString(ring(ring_No).ring_ID.ToString)
                    xmlwriter.WriteEndElement()
                    xmlwriter.WriteStartElement("slot")
                    xmlwriter.WriteString(ring(ring_No).ring_ID.ToString)
                    xmlwriter.WriteEndElement()
                    xmlwriter.WriteStartElement("pass_total")
                    xmlwriter.WriteString(ring(ring_No).pass.ToString)
                    xmlwriter.WriteEndElement()
                    xmlwriter.WriteStartElement("fail_total")
                    xmlwriter.WriteString(ring(ring_No).fail.ToString)
                    xmlwriter.WriteEndElement()
                    xmlwriter.WriteStartElement("fail_os_total")
                    xmlwriter.WriteString(ring(ring_No).fail.ToString)
                    xmlwriter.WriteEndElement()
                    xmlwriter.WriteStartElement("start_time")
                    xmlwriter.WriteString(strNow)
                    xmlwriter.WriteEndElement()
                    xmlwriter.WriteStartElement("end_time")
                    xmlwriter.WriteString(strNow)
                    xmlwriter.WriteEndElement()

                    For brow = 0 To dLotdata.Block_rows - 1
                        For bcol = 0 To dLotdata.Block_columns - 1
                            xmlwriter.WriteStartElement("block")
                            xmlwriter.WriteStartElement("x")
                            xmlwriter.WriteString(bcol.ToString)
                            xmlwriter.WriteEndElement()
                            xmlwriter.WriteStartElement("y")
                            xmlwriter.WriteString(brow.ToString)
                            xmlwriter.WriteEndElement()
                            For drow = 0 To dLotdata.Device_rows - 1
                                xmlwriter.WriteStartElement("row")
                                Dim rowdata As String = ""
                                For dcol = 0 To dLotdata.Device_columns - 1
                                    Dim bin As String = ring(ring_No).mapd(brow * dLotdata.Device_rows + drow, bcol * dLotdata.Device_columns + dcol)
                                    Select Case bin
                                        Case "0"
                                            rowdata += "00010253,"
                                        Case "1"
                                            rowdata += "0101034C,"
                                        Case "2"
                                            rowdata += "0000082E,"
                                        Case Else
                                            rowdata += "0101034C,"
                                    End Select
                                Next
                                rowdata = rowdata.TrimEnd(",")
                                xmlwriter.WriteString(rowdata)

                                xmlwriter.WriteEndElement() 'row
                            Next
                            xmlwriter.WriteEndElement() 'block
                        Next
                    Next
                    xmlwriter.WriteEndElement() 'map
                    MakePickupFile(dLotdata, ring(ring_No).ring_ID.ToString, ring(ring_No).mapd, strResultpath & "\" & dLotdata.LotNo & Format(ring(ring_No).ring_ID, "00") & ".MAP")
                End If
            Next
            xmlwriter.WriteEndElement() 'lotdata
            xmlwriter.WriteEndDocument()

        Catch ex As Exception
            xmlwriter.Flush()
            xmlwriter.Close()
            clsErrorLog.addlogWT("Error:XmlConvert:" & ex.ToString & "," & "XmlConvert", "XmlConvert")
            Return "Error:XmlConvert:" & ex.ToString
        End Try
        xmlwriter.Flush()
        xmlwriter.Close()
        Return "True"
    End Function

    Private Function MakePickupFile(ByVal dlotdata As LotData, ByVal strRingID As String, ByVal mapd(,) As String, ByVal path As String) As String

        Dim bcol As Integer = 0
        Dim brow As Integer = 0
        Dim dcol As Integer = 0
        Dim drow As Integer = 0

        Try
            Using writer As New StreamWriter(path)
                writer.WriteLine("ProductId=" & dlotdata.Device)
                writer.WriteLine("PkgId=" & dlotdata.Package)
                writer.WriteLine("LotId=" & dlotdata.LotNo)
                writer.WriteLine("Barcode=" & dlotdata.LotNo & Format(CInt(strRingID), "00"))
                writer.WriteLine("DeviceSizeX=" & dlotdata.Device_size_x)
                writer.WriteLine("DeviceSizeY=" & dlotdata.Device_size_y)
                writer.WriteLine("BlockColumns=" & dlotdata.Block_columns.ToString)
                writer.WriteLine("BlockRows=" & dlotdata.Block_rows.ToString)
                writer.WriteLine("Columns=" & dlotdata.Device_columns.ToString)
                writer.WriteLine("Rows=" & dlotdata.Device_rows.ToString)
                writer.WriteLine("Orientation=270")
                For brow = 0 To dlotdata.Block_rows - 1
                    For bcol = 0 To dlotdata.Block_columns - 1
                        writer.WriteLine("START")
                        writer.WriteLine(bcol.ToString & "," & brow.ToString & ",S")
                        For drow = 0 To dlotdata.Device_rows - 1
                            Dim rowdata As String = ""
                            For dcol = 0 To dlotdata.Device_columns - 1
                                Dim bin As String = mapd(brow * dlotdata.Device_rows + drow, bcol * dlotdata.Device_columns + dcol)
                                Select Case bin
                                    Case "0"
                                        rowdata += "S"
                                    Case "1"
                                        rowdata += "L"
                                    Case "2"
                                        rowdata += "X"
                                    Case Else
                                        rowdata += "L"
                                End Select
                            Next
                            writer.WriteLine(rowdata)
                        Next
                        writer.WriteLine("SEND")
                    Next
                Next
            End Using

        Catch ex As Exception
            Return "Error"
        End Try
        Return "True"
    End Function
End Class
