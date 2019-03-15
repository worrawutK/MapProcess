Imports System.Xml.Serialization

<Serializable()>
Public Class ParameterTC

    Private _MCNo As String
    Public Property MCNo() As String
        Get
            Return _MCNo
        End Get
        Set(ByVal value As String)
            _MCNo = value
        End Set
    End Property

    Private _LotNo As String
    Public Property LotNo() As String
        Get
            Return _LotNo
        End Get
        Set(ByVal value As String)
            _LotNo = value
        End Set
    End Property


    Private _Device As String
    Public Property Device() As String
        Get
            Return _Device
        End Get
        Set(ByVal value As String)
            _Device = value
        End Set
    End Property
    Private _Package As String
    Public Property Package() As String
        Get
            Return _Package
        End Get
        Set(ByVal value As String)
            _Package = value
        End Set
    End Property

    Private _OpNo As String
    Public Property OpNo() As String
        Get
            Return _OpNo
        End Get
        Set(ByVal value As String)
            _OpNo = value
        End Set
    End Property

    Private StartTimeData As Date
    Public Property LotStartTime() As Date
        Get
            Return StartTimeData
        End Get
        Set(ByVal value As Date)
            StartTimeData = value
        End Set
    End Property
    Private EndTimeData As Date
    Public Property LotEndTime() As Date
        Get
            Return EndTimeData
        End Get
        Set(ByVal value As Date)
            EndTimeData = value
        End Set
    End Property

    Private LotStatusData As String
    Public Property LotStatus() As String
        Get
            Return LotStatusData
        End Get
        Set(ByVal value As String)
            LotStatusData = value
        End Set
    End Property

    Private InputData As Integer
    Public Property Input() As Integer
        Get
            Return InputData
        End Get
        Set(ByVal value As Integer)
            InputData = value
        End Set
    End Property
    Private _GoodQty As Integer
    Public Property GoodQty() As Integer
        Get
            Return _GoodQty
        End Get
        Set(ByVal value As Integer)
            _GoodQty = value
        End Set
    End Property

    Private _NGQty As Integer
    Public Property NGQty() As Integer
        Get
            Return _NGQty
        End Get
        Set(ByVal value As Integer)
            _NGQty = value
        End Set
    End Property

    Private _RunTimeCount As TimeSpan
    <XmlIgnore()>
    Public Property RunTimeCount() As TimeSpan
        Get
            Return _RunTimeCount
        End Get
        Set(ByVal value As TimeSpan)
            _RunTimeCount = value
        End Set
    End Property

    Property RunTimeTick() As Long
        Get
            Return _RunTimeCount.Ticks
        End Get
        Set(ByVal value As Long)
            _RunTimeCount = TimeSpan.FromTicks(value)
        End Set
    End Property


    Private _StopTimeCount As TimeSpan
    <XmlIgnore()>
    Public Property StopTimeCount() As TimeSpan
        Get
            Return _StopTimeCount
        End Get
        Set(ByVal value As TimeSpan)
            _StopTimeCount = value
        End Set
    End Property
    Property StopTimeTick() As Long
        Get
            Return _StopTimeCount.Ticks
        End Get
        Set(ByVal value As Long)
            _StopTimeCount = TimeSpan.FromTicks(value)
        End Set
    End Property

    Private _AlarmTimeCount As TimeSpan
    <XmlIgnore()>
    Public Property AlarmTimeCount() As TimeSpan
        Get
            Return _AlarmTimeCount
        End Get
        Set(ByVal value As TimeSpan)
            _AlarmTimeCount = value
        End Set
    End Property
    Property AlarmTimeTick() As Long
        Get
            Return _AlarmTimeCount.Ticks
        End Get
        Set(ByVal value As Long)
            _AlarmTimeCount = TimeSpan.FromTicks(value)
        End Set
    End Property

    Private AlarmTotalData As Integer
    Public Property AlarmTotal() As Integer
        Get
            Return AlarmTotalData
        End Get
        Set(ByVal value As Integer)
            AlarmTotalData = value
        End Set
    End Property

    Private AlarmNoData As String
    Public Property AlarmNo() As String
        Get
            Return AlarmNoData
        End Get
        Set(ByVal value As String)
            AlarmNoData = value
        End Set
    End Property

    Private LotInforData As String
    Public Property LotInfor() As String
        Get
            Return LotInforData
        End Get
        Set(ByVal value As String)
            LotInforData = value
        End Set
    End Property
    Private Frame As Integer
    Public Property GoodFrame() As Integer
        Get
            Return Frame
        End Get
        Set(ByVal value As Integer)
            Frame = value
        End Set
    End Property
    Private _PerFrame As Integer
    Public Property PerFrame() As Integer
        Get
            Return _PerFrame
        End Get
        Set(ByVal value As Integer)
            _PerFrame = value
        End Set
    End Property
    Private _FrameType As String
    Public Property FrameType() As String
        Get
            Return _FrameType
        End Get
        Set(ByVal value As String)
            _FrameType = value
        End Set
    End Property

    Private QRCode As String
    Public Property QR() As String
        Get
            Return QRCode
        End Get
        Set(ByVal value As String)
            QRCode = value
        End Set
    End Property
    Private MajorAlarm As Integer
    Public Property MajorAlm() As Integer
        Get
            Return MajorAlarm
        End Get
        Set(ByVal value As Integer)
            MajorAlarm = value
        End Set
    End Property
    Private Series As String
    Public Property ComPort() As String
        Get
            Return Series
        End Get
        Set(ByVal value As String)
            Series = value
        End Set
    End Property
    Private GL As String
    Public Property GLCheck() As String
        Get
            Return GL
        End Get
        Set(ByVal value As String)
            GL = value
        End Set
    End Property
    Private AlarmMes As String
    Public Property AlarmMessage() As String
        Get
            Return AlarmMes
        End Get
        Set(ByVal value As String)
            AlarmMes = value
        End Set
    End Property

    Private AlmID As Integer
    Public Property AlarmID() As Integer
        Get
            Return AlmID
        End Get
        Set(ByVal value As Integer)
            AlmID = value
        End Set
    End Property

    'Paperless

    Private _KanaCleaning As String
    Public Property KanaCleaning() As String
        Get
            Return _KanaCleaning
        End Get
        Set(ByVal value As String)
            _KanaCleaning = value
        End Set
    End Property

    Private _StartInsMode As String
    Public Property StartInsMode() As String
        Get
            Return _StartInsMode
        End Get
        Set(ByVal value As String)
            _StartInsMode = value
        End Set
    End Property

    Private _StartInsItem As String
    Public Property StartInsItem() As String
        Get
            Return _StartInsItem
        End Get
        Set(ByVal value As String)
            _StartInsItem = value
        End Set
    End Property

    Private _EndInsAdjust As String
    Public Property EndInsAdjust() As String
        Get
            Return _EndInsAdjust
        End Get
        Set(ByVal value As String)
            _EndInsAdjust = value
        End Set
    End Property

    Private _EndInsMode As String
    Public Property EndInsMode() As String
        Get
            Return _EndInsMode
        End Get
        Set(ByVal value As String)
            _EndInsMode = value
        End Set
    End Property

    Private _EndInsItem As String
    Public Property EndInsItem() As String
        Get
            Return _EndInsItem
        End Get
        Set(ByVal value As String)
            _EndInsItem = value
        End Set
    End Property

    Private _StartInsAdjust As String
    Public Property StartInsAdjust() As String
        Get
            Return _StartInsAdjust
        End Get
        Set(ByVal value As String)
            _StartInsAdjust = value
        End Set
    End Property


    Private _ShapeInsMode As String
    Public Property ShapeInsMode() As String
        Get
            Return _ShapeInsMode
        End Get
        Set(ByVal value As String)
            _ShapeInsMode = value
        End Set
    End Property

    Private _ShapeInsAfter As String
    Public Property ShapeInsAfter() As String
        Get
            Return _ShapeInsAfter
        End Get
        Set(ByVal value As String)
            _ShapeInsAfter = value
        End Set
    End Property

    Private _CutBari40X As Double
    Public Property CutBari40X() As Double
        Get
            Return _CutBari40X
        End Get
        Set(ByVal value As Double)
            _CutBari40X = value
        End Set
    End Property

    Private _CutBari120X As Double
    Public Property CutBari120X() As Double
        Get
            Return _CutBari120X
        End Get
        Set(ByVal value As Double)
            _CutBari120X = value
        End Set
    End Property

    Private _CutBariAfter As Double
    Public Property CutBariAfter() As Double
        Get
            Return _CutBariAfter
        End Get
        Set(ByVal value As Double)
            _CutBariAfter = value
        End Set
    End Property

    Private _KanagataUnit As String
    Public Property KanagataUnit() As String
        Get
            Return _KanagataUnit
        End Get
        Set(ByVal value As String)
            _KanagataUnit = value
        End Set
    End Property

    Private _BMStartTime As Date
    Public Property BMStartTime() As Date
        Get
            Return _BMStartTime
        End Get
        Set(ByVal value As Date)
            _BMStartTime = value
        End Set
    End Property

    Private _BMFinishTime As Date
    Public Property BMFinishTime() As Date
        Get
            Return _BMFinishTime
        End Get
        Set(ByVal value As Date)
            _BMFinishTime = value
        End Set
    End Property

    Private _Lotjudement As String
    Public Property Lotjudement() As String
        Get
            Return _Lotjudement
        End Get
        Set(ByVal value As String)
            _Lotjudement = value
        End Set
    End Property

    Private _OPjudement As String
    Public Property OPjudement() As String
        Get
            Return _OPjudement
        End Get
        Set(ByVal value As String)
            _OPjudement = value
        End Set
    End Property

    Private _Magazine As String
    Public Property Magazine() As String
        Get
            Return _Magazine
        End Get
        Set(ByVal value As String)
            _Magazine = value
        End Set
    End Property

    Private _GoodAdjust As Integer
    Public Property GoodAdjust() As Integer
        Get
            Return _GoodAdjust
        End Get
        Set(ByVal value As Integer)
            _GoodAdjust = value
        End Set
    End Property

    Private _NGAdjust As Integer
    Public Property NGAdjust() As Integer
        Get
            Return _NGAdjust
        End Get
        Set(ByVal value As Integer)
            _NGAdjust = value
        End Set
    End Property

    Private _InputAdjust As Integer
    Public Property InputAdjust() As Integer
        Get
            Return _InputAdjust
        End Get
        Set(ByVal value As Integer)
            _InputAdjust = value
        End Set
    End Property

    Private _cbxRemark As String
    Public Property Remark() As String
        Get
            Return _cbxRemark
        End Get
        Set(ByVal value As String)
            _cbxRemark = value
        End Set
    End Property

    Private _MCLock As Integer
    Public Property MCLock() As Integer
        Get
            Return _MCLock
        End Get
        Set(ByVal value As Integer)
            _MCLock = value
        End Set
    End Property


    'AlarmMajor
    Private _AlmNo348 As Integer
    Public Property AlmNo348() As Integer
        Get
            Return _AlmNo348
        End Get
        Set(ByVal value As Integer)
            _AlmNo348 = value
        End Set
    End Property

    Private _AlmNo349 As Integer
    Public Property AlmNo349() As Integer
        Get
            Return _AlmNo349
        End Get
        Set(ByVal value As Integer)
            _AlmNo349 = value
        End Set
    End Property

    Private _AlmNo361 As Integer
    Public Property AlmNo361() As Integer
        Get
            Return _AlmNo361
        End Get
        Set(ByVal value As Integer)
            _AlmNo361 = value
        End Set
    End Property

    Private _AlmNo370 As Integer
    Public Property AlmNo370() As Integer
        Get
            Return _AlmNo370
        End Get
        Set(ByVal value As Integer)
            _AlmNo370 = value
        End Set
    End Property

    Private _AlmNo377 As Integer
    Public Property AlmNo377() As Integer
        Get
            Return _AlmNo377
        End Get
        Set(ByVal value As Integer)
            _AlmNo377 = value
        End Set
    End Property

    Private _AlmNo378 As Integer
    Public Property AlmNo378() As Integer
        Get
            Return _AlmNo378
        End Get
        Set(ByVal value As Integer)
            _AlmNo378 = value
        End Set
    End Property

    Private _KanagataPackage As List(Of String)
    Public Property KanagataPackage() As List(Of String)
        Get
            Return _KanagataPackage
        End Get
        Set(ByVal value As List(Of String))
            _KanagataPackage = value
        End Set
    End Property

    Private _KanagataFrameType As List(Of String)
    Public Property KanagataFrameType() As List(Of String)
        Get
            Return _KanagataFrameType
        End Get
        Set(ByVal value As List(Of String))
            _KanagataFrameType = value
        End Set
    End Property

    Private _KanagataNo As String
    Public Property KanagataNo() As String
        Get
            Return _KanagataNo
        End Get
        Set(ByVal value As String)
            _KanagataNo = value
        End Set
    End Property

    Private _LotStartMode As Integer
    Public Property LotStartMode() As Integer
        Get
            Return _LotStartMode
        End Get
        Set(ByVal value As Integer)
            _LotStartMode = value
        End Set
    End Property


    Private _LotEndMode As Integer
    Public Property LotEndMode() As Integer
        Get
            Return _LotEndMode
        End Get
        Set(ByVal value As Integer)
            _LotEndMode = value
        End Set
    End Property

    Private _CurrentShotCount As Integer
    Public Property CurrentShotCount() As Integer
        Get
            Return _CurrentShotCount
        End Get
        Set(ByVal value As Integer)
            _CurrentShotCount = value
        End Set
    End Property

    Private _StartShotCount As Integer
    Public Property StartShotCount() As Integer
        Get
            Return _StartShotCount
        End Get
        Set(ByVal value As Integer)
            _StartShotCount = value
        End Set
    End Property


    Private _LotConfirmTime As Date
    Public Property LotConfirmTime() As Date
        Get
            Return _LotConfirmTime
        End Get
        Set(ByVal value As Date)
            _LotConfirmTime = value
        End Set
    End Property


End Class


