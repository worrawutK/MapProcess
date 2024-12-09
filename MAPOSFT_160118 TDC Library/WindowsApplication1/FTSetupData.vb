Public Class FTSetupData
    Private c_McNo As String
    Public Property McNo() As String
        Get
            Return c_McNo
        End Get
        Set(ByVal value As String)
            c_McNo = value
        End Set
    End Property
    Private c_Device As String
    Public Property Device() As String
        Get
            Return c_Device
        End Get
        Set(ByVal value As String)
            c_Device = value
        End Set
    End Property
    Private c_Package As String
    Public Property Package() As String
        Get
            Return c_Package
        End Get
        Set(ByVal value As String)
            c_Package = value
        End Set
    End Property
    Private c_SetupFlow As String
    Public Property SetupFlow() As String
        Get
            Return c_SetupFlow
        End Get
        Set(ByVal value As String)
            c_SetupFlow = value
        End Set
    End Property

End Class
