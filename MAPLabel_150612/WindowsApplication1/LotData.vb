Public Class LotData
    Sub New()
        c_CarrierInfo = New iLibraryService.CarrierInfo
    End Sub
    Private c_OpNo As String
    Public Property OpNo() As String
        Get
            Return c_OpNo
        End Get
        Set(ByVal value As String)
            c_OpNo = value
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
    Private c_Recipe As String
    Public Property Recipe() As String
        Get
            Return c_Recipe
        End Get
        Set(ByVal value As String)
            c_Recipe = value
        End Set
    End Property
    Private c_CarrierInfo As MAP_Label.iLibraryService.CarrierInfo
    Public Property CarrierInfo() As MAP_Label.iLibraryService.CarrierInfo
        Get
            Return c_CarrierInfo
        End Get
        Set(ByVal value As MAP_Label.iLibraryService.CarrierInfo)
            c_CarrierInfo = value
        End Set
    End Property
End Class
