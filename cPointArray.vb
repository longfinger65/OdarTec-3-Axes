Option Explicit On
Option Infer Off

Public Class cPointArray
    Inherits cCADObject

    '----- Constructor ----------------------------------------------------

    Public Sub New()

        '----- Initialization -----

        m_X1 = 0.0
        m_Y1 = 0.0
        m_Z1 = 0.0
        m_X2 = 0.0
        m_Y2 = 0.0
        m_Z2 = 0.0

    End Sub

    Public Sub New(StartPoint As cPoint, EndPoint As cPoint)
        Me.New()
        m_X1 = StartPoint.m_X
        m_Y1 = StartPoint.m_Y
        m_Z1 = StartPoint.m_Z
        m_X2 = EndPoint.m_X
        m_Y2 = EndPoint.m_Y
        m_Z2 = EndPoint.m_Z
        CamDescription = ""
    End Sub

    Public Sub New(StartPoint As cPoint, EndPoint As cPoint, LineCamDescription As String)
        Me.New()
        m_X1 = StartPoint.X
        m_Y1 = StartPoint.Y
        m_Z1 = StartPoint.Z
        m_X2 = EndPoint.X
        m_Y2 = EndPoint.Y
        m_Z2 = EndPoint.Z
        CamDescription = LineCamDescription
    End Sub

    Public Sub New(StartPointX As Double, StartPointY As Double, EndPointX As Double, EndPointY As Double)
        Me.New()
        m_X1 = StartPointX
        m_Y1 = StartPointY
        m_X2 = EndPointX
        m_Y2 = EndPointY
        CamDescription = ""
    End Sub

    Public Sub New(StartPointX As Double, StartPointY As Double, EndPointX As Double, EndPointY As Double, LineCamDescription As String)
        Me.New()
        m_X1 = StartPointX
        m_Y1 = StartPointY
        m_X2 = EndPointX
        m_Y2 = EndPointY
        CamDescription = LineCamDescription
    End Sub

    Public Sub New(StartPointX As Double, StartPointY As Double, StartPointZ As Double, EndPointX As Double, EndPointY As Double, EndPointZ As Double, LineCamDescription As String)
        Me.New()
        m_X1 = StartPointX
        m_Y1 = StartPointY
        m_Z1 = StartPointZ
        m_X2 = EndPointX
        m_Y2 = EndPointY
        m_Z2 = EndPointZ
        CamDescription = LineCamDescription
    End Sub

    Public Sub New(StartPoint As cPoint, EndPointX As Double, EndPointY As Double, EndPointZ As Double)
        Me.New()
        m_X1 = StartPoint.X
        m_Y1 = StartPoint.Y
        m_Z1 = StartPoint.Z
        m_X2 = EndPointX
        m_Y2 = EndPointY
        m_Z2 = EndPointZ
    End Sub

    Public Sub New(StartPointX As Double, StartPointY As Double, StartPointZ As Double, EndPoint As cPoint)
        Me.New()
        m_X1 = StartPointX
        m_Y1 = StartPointY
        m_Z1 = StartPointZ
        m_X2 = EndPoint.X
        m_Y2 = EndPoint.Y
        m_Z2 = EndPoint.Z
    End Sub

    Public Sub New(StartPointX As Double, StartPointY As Double, StartPointZ As Double, EndPointX As Double, EndPointY As Double, EndPointZ As Double)
        Me.New()
        m_X1 = StartPointX
        m_Y1 = StartPointY
        m_Z1 = StartPointZ
        m_X2 = EndPointX
        m_Y2 = EndPointY
        m_Z2 = EndPointZ
        CamDescription = ""
    End Sub

    Public Sub New(Line As cLine)
        Me.New()
        m_X1 = Line.m_X1
        m_Y1 = Line.m_Y1
        m_Z1 = Line.m_Z1
        m_X2 = Line.m_X2
        m_Y2 = Line.m_Y2
        m_Z2 = Line.m_Z2
        CamDescription = Line.CamDescription
    End Sub


    '----- Begin member variables and constants -----------------------------------------------

    Public m_X1 As Double
    Public m_X2 As Double
    Public m_Y1 As Double
    Public m_Y2 As Double
    Public m_Z1 As Double
    Public m_Z2 As Double
    Private m_Name As String
    Private m_CamDescription As String
    Public m_PointArray(1000) As cSimplePoint

    '----- Get and set properties -----

    Public Property Name() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Name
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_Name = Value
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
