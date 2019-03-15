
Imports System.Data

Public Class clsMapData

    Friend m_machine As String
    Friend m_lotno As String
    Friend m_product As String
    Friend m_package As String
    Friend m_autono As String
    Friend m_testmode As String
    Friend m_waferlist As String
    Friend m_ringtotal As Integer
    Friend m_passtotal As Integer
    Friend m_failtotal As Integer
    Friend m_measurefailtotal As Integer
    Friend m_passwa(25) As Integer
    Friend m_failwa(25) As Integer
    Friend m_allunmeasure_check As Boolean
    Friend m_allmeasure_check As Boolean
    Friend m_starttime As String
    Friend m_endtime As String
    Friend m_bincount(33) As Integer

    Property Machine() As String
        Get
            Return m_machine
        End Get
        Set(ByVal Value As String)
            ' m_machine = Value
        End Set
    End Property

    Property LotNo() As String
        Get
            Return m_lotno
        End Get
        Set(ByVal Value As String)
            ' m_lotno = Value
        End Set
    End Property

    Property Product() As String
        Get
            Return m_product
        End Get
        Set(ByVal Value As String)
            'm_product = Value
        End Set
    End Property

    Property Package() As String
        Get
            Return m_package
        End Get
        Set(ByVal Value As String)
            'm_package = Value
        End Set
    End Property

    Property WaferList() As String
        Get
            Return m_waferlist
        End Get
        Set(ByVal Value As String)
            'm_waferlist = Value
        End Set
    End Property

    Property RingTotal() As Integer
        Get
            Return m_ringtotal
        End Get
        Set(ByVal Value As Integer)
            'm_ringtotal = Value
        End Set
    End Property

    Property PassTotal() As Integer
        Get
            Return m_passtotal
        End Get
        Set(ByVal Value As Integer)
            'm_passtotal = Value
        End Set
    End Property

    Property FailTotal() As Integer
        Get
            Return m_failtotal
        End Get
        Set(ByVal Value As Integer)
            'm_failtotal = Value
        End Set
    End Property

    Property MeasureFailTotal() As Integer
        Get
            Return m_measurefailtotal
        End Get
        Set(ByVal Value As Integer)
            'm_failtotal = Value
        End Set
    End Property

    Property PassWA(ByVal intWaCount As Integer) As Integer
        Get
            Return m_passwa(intWaCount)
        End Get
        Set(ByVal Value As Integer)
            'm_passwa(intWaCount) = Value
        End Set
    End Property

    Property FailWA(ByVal intWaCount As Integer) As Integer
        Get
            Return m_failwa(intWaCount)
        End Get
        Set(ByVal Value As Integer)
            'm_failwa(intWaCount) = Value
        End Set
    End Property

    Property AutoNo() As String
        Get
            Return m_autono
        End Get
        Set(ByVal Value As String)
            ' m_autono = Value
        End Set
    End Property

    Property TestMode() As String
        Get
            Return m_testmode
        End Get
        Set(ByVal Value As String)
            ' m_autono = Value
        End Set
    End Property

    Property AllUnMeasure_check() As String 'True = All UnMeasure
        Get
            Return m_allunmeasure_check
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    Property AllMeasure_check() As String  'True = All Measure
        Get
            Return m_allmeasure_check
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    Property Bin_Counter(ByVal strBin As String) As Integer
        Get
            Return m_bincount(strBin)
        End Get
        Set(ByVal Value As Integer)
        End Set
    End Property

    Property starttime() As String
        Get
            Return m_starttime
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    Property endtime() As String
        Get
            Return m_endtime
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    Public Shadows Function readMapData(ByVal strPath As String) As Boolean

        Dim xDocument As System.Xml.XmlDocument = New System.Xml.XmlDocument
        Dim xlotdata As System.Xml.XmlElement
        Dim xloglist As System.Xml.XmlNodeList
        Dim xMaplist As System.Xml.XmlNodeList
        ' Dim xblocklist As System.Xml.XmlNodeList
        Dim xrowlist As System.Xml.XmlNodeList
        Dim strXMLFile As String = strPath & "_LOT.xml"

        Dim strpass As String = ""
        Dim strfail As String = ""
        Dim strmeasurefail As String = ""
        Dim strAuto As String = ""
        Dim strTestMode As String = ""
        Dim useWfBin As String = ""
        Dim strMachine As String = ""
        Dim strStarttime As String = ""
        Dim strEndtime As String = ""
        Dim i As Integer

        Try
            Initial()
            m_allunmeasure_check = True
            m_allmeasure_check = True
            xDocument.Load(strXMLFile)
            xlotdata = xDocument.DocumentElement
            If xlotdata Is Nothing Then
                Initial()
                Return False
            End If
            'Product
            If Not xlotdata.Item("product_id") Is Nothing Then
                m_product = xlotdata.Item("product_id").InnerText
            Else
                Initial()
                Return False
            End If
            'Package
            If Not xlotdata.Item("package_id") Is Nothing Then
                m_package = xlotdata.Item("package_id").InnerText
            Else
                Initial()
                Return False
            End If
            'LotNo
            If Not xlotdata.Item("lot_id") Is Nothing Then
                m_lotno = xlotdata.Item("lot_id").InnerText
            Else
                Initial()
                Return False
            End If
            'Ring Total
            If Not xlotdata.Item("ring_total") Is Nothing Then
                m_ringtotal = xlotdata.Item("ring_total").InnerText
            Else
                Initial()
                Return False
            End If

            xloglist = xlotdata.GetElementsByTagName("log")
            If xloglist.Count <= 0 Then
                Return Nothing
            End If
            For Each xElement As System.Xml.XmlElement In xloglist
                'Machine
                If Not xElement.Item("machine_id") Is Nothing Then
                    strMachine = xElement.Item("machine_id").InnerText
                Else
                    Initial()
                    Return False
                End If
                'Pass Total
                If Not xElement.Item("pass_total") Is Nothing Then
                    strpass = xElement.Item("pass_total").InnerText
                Else
                    Initial()
                    Return False
                End If
                'Fail Total
                If Not xElement.Item("fail_total") Is Nothing Then
                    strfail = xElement.Item("fail_total").InnerText
                Else
                    Initial()
                    Return False
                End If
                'Measure Fail Total
                If Not xElement.Item("measure_fail_total") Is Nothing Then
                    strmeasurefail = xElement.Item("measure_fail_total").InnerText
                Else
                    Initial()
                    Return False
                End If

                'Start Time
                If Not xElement.Item("start_time") Is Nothing Then
                    strStarttime = xElement.Item("start_time").InnerText
                Else
                    Initial()
                    Return False
                End If
                'End Time
                If Not xElement.Item("end_time") Is Nothing Then
                    strEndtime = xElement.Item("end_time").InnerText
                Else
                    Initial()
                    Return False
                End If
                'AutoNo
                If Not xElement.Item("test_type") Is Nothing Then
                    Select Case xElement.Item("test_type").InnerText
                        Case "0"
                            strAuto = "OS"
                        Case "1"
                            strAuto = "AUTO1"
                        Case "2"
                            strAuto = "AUTO2"
                        Case "3"
                            strAuto = "AUTO3"
                        Case "4"
                            strAuto = "AUTO4"
                        Case "5"
                            strAuto = "OSFT"
                        Case Else
                            Initial()
                            Return False
                    End Select
                End If
                'TestMode
                If Not xElement.Item("test_mode") Is Nothing Then
                    Select Case xElement.Item("test_mode").InnerText
                        Case "0"
                            strTestMode = strAuto + "_NEW"
                        Case "1"
                            strTestMode = strAuto + "_ADD"
                        Case "2"
                            strTestMode = strAuto + "_RGOOD"
                        Case "3"
                            strTestMode = strAuto + "_RNG"
                        Case "4"
                            strTestMode = strAuto + "_ASI"
                        Case Else
                            Initial()
                            Return False
                    End Select
                End If
            Next
            m_machine = strMachine
            m_passtotal = CInt(strpass)
            m_failtotal = CInt(strfail)
            m_measurefailtotal = CInt(strmeasurefail)
            m_autono = strAuto
            m_testmode = strTestMode
            m_starttime = strStarttime
            m_endtime = strEndtime
            'PassWa,FailWa
            xMaplist = xlotdata.GetElementsByTagName("map")
            If xMaplist.Count <> CInt(m_ringtotal) Then
                Initial()
                Return False
            End If
            For Each xElement As System.Xml.XmlElement In xMaplist
                If Not xElement.Item("ring_id") Is Nothing Then
                    m_passwa(CInt(xElement.Item("ring_id").InnerText)) = CInt(xElement.Item("pass_total").InnerText)
                    m_failwa(CInt(xElement.Item("ring_id").InnerText)) = CInt(xElement.Item("fail_total").InnerText)
                Else
                    Initial()
                    Return False
                End If
            Next
            xrowlist = xlotdata.GetElementsByTagName("row")
            If xrowlist.Count <= 0 Then
                Initial()
                Return False
            End If
            For Each xElement As System.Xml.XmlElement In xrowlist
                Dim row_text As String = xElement.ChildNodes(0).InnerText
                Dim data As String() = row_text.Split(",")
                For i = 0 To data.Length - 1
                    If Convert.ToInt32(data(i).Substring(4, 2), 16) And 2 Then '‘ª’èÏ
                        Select Case strAuto
                            Case "OS"
                                If data(i).Substring(2, 2) = "01" Then
                                    m_allunmeasure_check = False
                                Else
                                    m_allmeasure_check = False
                                End If
                                If data(i).Substring(0, 2) = "01" Then
                                    bin_count(data(i).Substring(6, 2))
                                End If
                            Case "AUTO1", "OSFT"
                                If data(i).Substring(2, 2) = "03" Then
                                    m_allunmeasure_check = False
                                Else
                                    m_allmeasure_check = False
                                End If
                                If data(i).Substring(0, 2) = "02" Then
                                    bin_count(data(i).Substring(6, 2))
                                End If
                            Case "AUTO2"
                                If data(i).Substring(2, 2) = "07" Then
                                    m_allunmeasure_check = False
                                Else
                                    m_allmeasure_check = False
                                End If
                                If data(i).Substring(0, 2) = "04" Then
                                    bin_count(data(i).Substring(6, 2))
                                End If
                            Case "AUTO3"
                                If data(i).Substring(2, 2) = "0F" Then
                                    m_allunmeasure_check = False
                                Else
                                    m_allmeasure_check = False
                                End If
                                If data(i).Substring(0, 2) = "08" Then
                                    bin_count(data(i).Substring(6, 2))
                                End If
                            Case "AUTO4"
                                If data(i).Substring(2, 2) = "1F" Then
                                    m_allunmeasure_check = False
                                Else
                                    m_allmeasure_check = False
                                End If
                                If data(i).Substring(0, 2) = "10" Then
                                    bin_count(data(i).Substring(6, 2))
                                End If
                            Case Else
                                m_allmeasure_check = False
                        End Select
                    End If
                Next
            Next

            'WfList
            For i = 1 To 25
                If m_passwa(i) = 0 And m_failwa(i) = 0 Then
                    useWfBin += "0"
                Else
                    useWfBin += "1"
                End If
            Next
            m_waferlist = StrReverse(useWfBin)

        Catch ex As Exception
            Initial()
            Return False
        End Try
        Return True
    End Function

    Public Shadows Sub Initial()
        m_machine = ""
        m_lotno = ""
        m_product = ""
        m_package = ""
        m_autono = ""
        m_testmode = ""
        m_waferlist = "0000000000000000000000000"
        m_ringtotal = 0
        m_passtotal = 0
        m_failtotal = 0
        m_measurefailtotal = 0
        Dim i As Integer
        For i = 1 To 25
            m_passwa(i) = 0
            m_failwa(i) = 0
        Next
        For i = 0 To 32
            m_bincount(i) = 0
        Next
    End Sub

    Private Sub bin_count(ByVal strBin As String)
        Select Case strBin
            Case "2C"
                m_bincount(0) = m_bincount(0) + 1
            Case "31"
                m_bincount(1) = m_bincount(1) + 1
            Case "32"
                m_bincount(2) = m_bincount(2) + 1
            Case "33"
                m_bincount(3) = m_bincount(3) + 1
            Case "34"
                m_bincount(4) = m_bincount(4) + 1
            Case "35"
                m_bincount(5) = m_bincount(5) + 1
            Case "41"
                m_bincount(6) = m_bincount(6) + 1
            Case "42"
                m_bincount(7) = m_bincount(7) + 1
            Case "43"
                m_bincount(8) = m_bincount(8) + 1
            Case "44"
                m_bincount(9) = m_bincount(9) + 1
            Case "45"
                m_bincount(10) = m_bincount(10) + 1
            Case "46"
                m_bincount(11) = m_bincount(11) + 1
            Case "47"
                m_bincount(12) = m_bincount(12) + 1
            Case "48"
                m_bincount(13) = m_bincount(13) + 1
            Case "49"
                m_bincount(14) = m_bincount(14) + 1
            Case "4A"
                m_bincount(15) = m_bincount(15) + 1
            Case "4B"
                m_bincount(16) = m_bincount(16) + 1
            Case "4C"
                m_bincount(17) = m_bincount(17) + 1
            Case "4D"
                m_bincount(18) = m_bincount(18) + 1
            Case "4E"
                m_bincount(19) = m_bincount(19) + 1
            Case "4F"
                m_bincount(20) = m_bincount(20) + 1
            Case "50"
                m_bincount(21) = m_bincount(21) + 1
            Case "51"
                m_bincount(22) = m_bincount(22) + 1
            Case "52"
                m_bincount(23) = m_bincount(23) + 1
            Case "53"
                m_bincount(24) = m_bincount(24) + 1
            Case "54"
                m_bincount(25) = m_bincount(25) + 1
            Case "55"
                m_bincount(26) = m_bincount(26) + 1
            Case "56"
                m_bincount(27) = m_bincount(27) + 1
            Case "57"
                m_bincount(28) = m_bincount(28) + 1
            Case "78"
                m_bincount(29) = m_bincount(29) + 1
            Case "59"
                m_bincount(30) = m_bincount(30) + 1
            Case "5A"
                m_bincount(31) = m_bincount(31) + 1
            Case "7A"
                m_bincount(32) = m_bincount(32) + 1
        End Select
    End Sub

End Class
