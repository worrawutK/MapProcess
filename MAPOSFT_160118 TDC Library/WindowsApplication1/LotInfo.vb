Public Class Lotinfo

    Private c_TesterProgram As String
    Public Property TesterProgram() As String
        Get
            Return c_TesterProgram
        End Get
        Set(ByVal value As String)
            c_TesterProgram = value
        End Set
    End Property
    Private c_LotNo As String
    Public Property LotNo() As String
        Get
            Return c_LotNo
        End Get
        Set(ByVal value As String)
            c_LotNo = value
        End Set
    End Property
    Private c_MachineNo As String
    Public Property MachineNo() As String
        Get
            Return c_MachineNo
        End Get
        Set(ByVal value As String)
            c_MachineNo = value
        End Set
    End Property
    Private c_OpNo As String
    Public Property OpNo() As String
        Get
            Return c_OpNo
        End Get
        Set(ByVal value As String)
            c_OpNo = value
        End Set
    End Property
End Class
