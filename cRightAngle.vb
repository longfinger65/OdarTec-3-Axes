Option Explicit On
Option Infer Off


Public Class cRightAngle
    Inherits cCADObject

    '----- Constructor ----------------------------------------------------

    Public Sub New()
        m_StartPoint = New cPoint
        m_EndPoint = New cPoint
    End Sub

    Public Sub New(StartPoint As cPoint, EndPoint As cPoint)
        Me.New()
        StartPoint_X = StartPoint.X
        StartPoint_Y = StartPoint.Y
        EndPoint_X = EndPoint.X
        EndPoint_Y = EndPoint.Y
        CamDescription = ""
    End Sub

    Public Sub New(StartPoint As cPoint, EndPoint As cPoint, LineCamDescription As String)
        Me.New()
        StartPoint_X = StartPoint.X
        StartPoint_Y = StartPoint.Y
        EndPoint_X = EndPoint.X
        EndPoint_Y = EndPoint.Y
        CamDescription = LineCamDescription
    End Sub

    Public Sub New(StartPointX As Double, StartPointY As Double, EndPointX As Double, EndPointY As Double)
        Me.New()
        StartPoint_X = StartPointX
        StartPoint_Y = StartPointY
        EndPoint_X = EndPointX
        EndPoint_Y = EndPointY
        CamDescription = ""
    End Sub

    Public Sub New(StartPointX As Double, StartPointY As Double, EndPointX As Double, EndPointY As Double, LineCamDescription As String)
        Me.New()
        StartPoint_X = StartPointX
        StartPoint_Y = StartPointY
        EndPoint_X = EndPointX
        EndPoint_Y = EndPointY
        CamDescription = LineCamDescription
    End Sub


    '----- Begin member variables and constants -----------------------------------------------

    Private m_StartPoint As cPoint
    Private m_EndPoint As cPoint
    Private m_SketchName As String
    Private m_CamDescription As String

    '----- Get and set properties -----

    Public Property StartPoint() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_StartPoint
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_StartPoint = Value
        End Set
    End Property

    Public Property StartPoint_X() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_StartPoint.X
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_StartPoint.X = Value
        End Set
    End Property

    Public Property StartPoint_Y() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_StartPoint.Y
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_StartPoint.Y = Value
        End Set
    End Property

    Public Property StartPoint_Z() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_StartPoint.Z
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_StartPoint.Z = Value
        End Set
    End Property

    Public Property EndPoint() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_EndPoint
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_EndPoint = Value
        End Set
    End Property

    Public Property EndPoint_X() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_EndPoint.X
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_EndPoint.X = Value
        End Set
    End Property

    Public Property EndPoint_Y() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_EndPoint.Y
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_EndPoint.Y = Value
        End Set
    End Property

    Public Property EndPoint_Z() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_EndPoint.Z
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_EndPoint.Z = Value
        End Set
    End Property

    Public Property SketchName() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_SketchName
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_SketchName = Value
        End Set
    End Property

    Public Property CamDescription() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CamDescription
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_CamDescription = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes ---------------------------

End Class
