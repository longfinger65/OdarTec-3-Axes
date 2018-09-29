Option Explicit On
Option Infer Off

Public Class cPoint
    Inherits cCADObject

    '----- Constructor ----------------------------------------------------

    Public Sub New()
        X = 0.0
        Y = 0.0
        Z = 0.0
        X = 0
        Y = 0
        Z = 0
        IsMember = False
        Description = ""
    End Sub

    Public Sub New(X As Double, Y As Double)
        Me.X = X
        Me.Y = Y
        Z = 0.0
        Description = ""
    End Sub

    Public Sub New(X As Double, Y As Double, Z As Double)
        Me.New()
        Me.X = X
        Me.Y = Y
        Me.Z = Z
        Description = ""
    End Sub

    Public Sub New(X As Double, Y As Double, PointDescription As String)
        Me.X = X
        Me.Y = Y
        Z = 0.0
        Description = PointDescription
    End Sub

    Public Sub New(X As Double, Y As Double, Z As Double, PointDescription As String, Optional CamDescription As String = "")
        Me.X = X
        Me.Y = Y
        Me.Z = Z
        Description = PointDescription
        CamDescription = CamDescription
    End Sub

    Public Sub New(X As Double, Y As Double, Z As Double, CamDescription As String)
        Me.X = X
        Me.Y = Y
        Me.Z = Z
        CamDescription = CamDescription
    End Sub

    Public Sub New(Point As cPoint)
        Me.New()
        X = Point.X
        Y = Point.Y
        Z = Point.Z
    End Sub


    '----- Begin member variables and constants -----------------------------------------------

    Public m_X As Double
    Public m_Y As Double
    Public m_Z As Double
    Private m_IsMember As Boolean
    Private m_Description As String
    Private m_SketchName As String
    Public m_CamDescription As String

    '----- Begin properties -----

    Public Property X() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_X
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_X = Value
        End Set
    End Property

    Public Property Y() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Y
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_Y = Value
        End Set
    End Property

    Public Property Z() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Z
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_Z = Value
        End Set
    End Property

     Public Property IsMember() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_IsMember
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_IsMember = Value
        End Set
    End Property

    Public Property Description() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Description
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_Description = Value
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

    '----- End member variables, begin member methodes ----------------------

    Public Function gLRP(Edge As String, DistanzeFromPoint As Double) As Double()

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose:  To provide the line end points to present the point with a 45° cross
        '           thats line size can be determined at run time. gLRP stands for:
        '           getLeneRepresentationPoint.
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim Point(2) As Double

        Select Case Edge
            Case "LU"
                Point(0) = X - DistanzeFromPoint
                Point(1) = Y + DistanzeFromPoint
                Point(2) = Z
            Case "LD"
                Point(0) = X - DistanzeFromPoint
                Point(1) = Y - DistanzeFromPoint
                Point(2) = Z
            Case "RU"
                Point(0) = X + DistanzeFromPoint
                Point(1) = Y + DistanzeFromPoint
                Point(2) = Z
            Case "RD"
                Point(0) = X + DistanzeFromPoint
                Point(1) = Y - DistanzeFromPoint
                Point(2) = Z
        End Select

        Return Point
    End Function

End Class
