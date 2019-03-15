Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Xml
Imports System.Text

Public Class clsDeviceDataXml
    Friend m_package As String
    Friend m_block_columns As String
    Friend m_block_rows As String
    Friend m_device_columns As String
    Friend m_device_rows As String
    Friend m_device_size_x As String
    Friend m_device_size_y As String
    Friend m_supplier As String

    Property Package() As String
        Get
            Return m_package
        End Get
        Set(ByVal Value As String)
            m_package = Value
        End Set
    End Property

    Property Block_Columns() As String
        Get
            Return m_block_columns
        End Get
        Set(ByVal Value As String)
            m_block_columns = Value
        End Set
    End Property

    Property Block_Rows() As String
        Get
            Return m_block_rows
        End Get
        Set(ByVal Value As String)
            m_block_rows = Value
        End Set
    End Property

    Property Device_Columns() As String
        Get
            Return m_device_columns
        End Get
        Set(ByVal Value As String)
            m_device_columns = Value
        End Set
    End Property

    Property Device_Rows() As String
        Get
            Return m_device_rows
        End Get
        Set(ByVal Value As String)
            m_device_rows = Value
        End Set
    End Property

    Property Device_Size_X() As String
        Get
            Return m_device_size_x
        End Get
        Set(ByVal Value As String)
            m_device_size_x = Value
        End Set
    End Property

    Property Device_Size_Y() As String
        Get
            Return m_device_size_y
        End Get
        Set(ByVal Value As String)
            m_device_size_y = Value
        End Set
    End Property

    Property Supplier() As String
        Get
            Return m_supplier
        End Get
        Set(ByVal Value As String)
            m_supplier = Value
        End Set
    End Property

    Public Shadows Function LoadData(ByVal strPath As String) As Boolean

        Dim xDocument As XmlDocument = New XmlDocument
        Dim xpackagedata As XmlElement
        Dim strXMLFile As String = strPath

        xDocument.Load(strXMLFile)
        xpackagedata = xDocument.DocumentElement
        If xpackagedata Is Nothing Then    '<packagedata>
            Return False
        End If
        'Package
        If Not xpackagedata.Item("package_id") Is Nothing Then
            m_package = xpackagedata.Item("package_id").InnerText
        Else
            Initial()
            Return False
        End If
        'Block_Columns
        If Not xpackagedata.Item("block_columns") Is Nothing Then
            m_block_columns = xpackagedata.Item("block_columns").InnerText
        Else
            Initial()
            Return False
        End If
        'Block_Rows
        If Not xpackagedata.Item("block_rows") Is Nothing Then
            m_block_rows = xpackagedata.Item("block_rows").InnerText
        Else
            Initial()
            Return False
        End If
        'Device_Columns
        If Not xpackagedata.Item("device_columns") Is Nothing Then
            m_device_columns = xpackagedata.Item("device_columns").InnerText
        Else
            Initial()
            Return False
        End If
        'Device_Rows
        If Not xpackagedata.Item("device_rows") Is Nothing Then
            m_device_rows = xpackagedata.Item("device_rows").InnerText
        Else
            Initial()
            Return False
        End If
        'Device_Size_X 
        If Not xpackagedata.Item("device_size_x") Is Nothing Then
            m_device_size_x = xpackagedata.Item("device_size_x").InnerText
        Else
            Initial()
            Return False
        End If
        'Device_Size_Y
        If Not xpackagedata.Item("device_size_y") Is Nothing Then
            m_device_size_y = xpackagedata.Item("device_size_y").InnerText
        Else
            Initial()
            Return False
        End If
        'Supplier
        If Not xpackagedata.Item("supplier") Is Nothing Then
            m_supplier = xpackagedata.Item("supplier").InnerText
        Else
            Initial()
            Return False
        End If
        Return True
    End Function

    Public Shadows Function SaveData() As Boolean

        If m_package = "" Or m_package.Length > 10 Then Return False
        If m_block_columns = "" Or CInt(m_block_columns) > 2 Or CInt(m_block_columns) <= 0 Then Return False
        If m_block_rows = "" Or CInt(m_block_rows) > 4 Or CInt(m_block_rows) <= 0 Then Return False
        If m_device_columns = "" Then Return False
        If m_device_rows = "" Then Return False
        If m_device_size_x = "" Or m_device_size_x.Length <> 4 Then Return False
        If m_device_size_y = "" Or m_device_size_y.Length <> 4 Then Return False
        Dim strpath As String = System.Configuration.ConfigurationManager.AppSettings("RECIPE_PATH") & "\" & m_package & ".xml"
        Dim xmlwriter As New XmlTextWriter(strpath, System.Text.Encoding.GetEncoding("Shift_Jis"))

        Try          
            xmlwriter.Formatting = Formatting.Indented
            xmlwriter.Indentation = 2
            xmlwriter.WriteStartDocument()
            xmlwriter.WriteStartElement("packagedata")
            xmlwriter.WriteStartElement("package_id")
            xmlwriter.WriteString(m_package)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("block_columns")
            xmlwriter.WriteString(m_block_columns)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("block_rows")
            xmlwriter.WriteString(m_block_rows)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("device_columns")
            xmlwriter.WriteString(m_device_columns)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("device_rows")
            xmlwriter.WriteString(m_device_rows)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("device_size_x")
            xmlwriter.WriteString(m_device_size_x)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("device_size_y")
            xmlwriter.WriteString(m_device_size_y)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteStartElement("supplier")
            xmlwriter.WriteString(m_supplier)
            xmlwriter.WriteEndElement()
            xmlwriter.WriteEndElement()
            xmlwriter.WriteEndDocument()

        Catch ex As Exception
            xmlwriter.Flush()
            xmlwriter.Close()
            Return False
        End Try
        xmlwriter.Flush()
        xmlwriter.Close()
        Return True
    End Function

    Private Shadows Sub Initial()
        m_package = ""
        m_block_columns = ""
        m_block_rows = ""
        m_device_columns = ""
        m_device_rows = ""
        m_device_size_x = ""
        m_device_size_y = ""
        m_supplier = ""
    End Sub
End Class




