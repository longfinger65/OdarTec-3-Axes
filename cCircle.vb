Option Explicit On
Option Infer Off

Public Class cCircle
    Inherits cCADObject

    '----- Constructor ----------------------------------------------------

    Public Sub New()

        '----- Initializations -----

        Radius = 0
        m_XC = 0
        m_YC = 0
        m_ZC = 0
        m_CamDescription = ""
        For i As Integer = 0 To 3
            m_PointsForSplineRepresentation(i) = New cSimplePoint()
        Next
    End Sub

    Public Sub New(CenterPoint As cPoint)
        Me.New()

        m_XC = CenterPoint.X
        m_YC = CenterPoint.Y
        m_ZC = CenterPoint.Z

    End Sub

    Public Sub New(CenterPointX As Double, CenterPointY As Double, CenterPointZ As Double)
        Me.New()

        m_XC = CenterPointX
        m_YC = CenterPointY
        m_ZC = CenterPointZ

    End Sub

    Public Sub New(CenterPointX As Double, CenterPointY As Double, CenterPointZ As Double, Radius As Double)
        Me.New()

        m_XC = CenterPointX
        m_YC = CenterPointY
        m_ZC = CenterPointZ
        m_Radius = Radius

    End Sub

    Public Sub New(CenterPointX As Double, CenterPointY As Double, CenterPointZ As Double, Radius As Double, Description As String)
        Me.New()

        m_XC = CenterPointX
        m_YC = CenterPointY
        m_ZC = CenterPointZ
        m_Radius = Radius
        m_CamDescription = Description

    End Sub

    Public Sub New(Circle As Object)
        Me.New()

        m_XC = Circle.m_XC
        m_YC = Circle.m_YC
        m_ZC = Circle.m_ZC
        m_Radius = Circle.Radius
        m_CamDescription = Circle.CamDescription

    End Sub


    '----- Member Variables and constants -----------------------------------------------

    Public m_Radius As Double
    Private m_SketchName As String
    Public m_XC As Double
    Public m_YC As Double
    Public m_ZC As Double
    Private m_PointsForSplineRepresentation(3) As cSimplePoint
    Private m_CamDescription As String

    '----- Get and set properties -----


    Public Property Radius() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Radius
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_Radius = Value
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

    Public Property PointsForSplineRepresentation() As cSimplePoint()
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PointsForSplineRepresentation
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cSimplePoint())
            m_PointsForSplineRepresentation = Value
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

    Public Function checkIfPointIsNearby(PointToCheck As cPoint, MaxDistance As Double) As Boolean
        If Math.Sqrt((m_XC - PointToCheck.X) ^ 2 + (m_YC - PointToCheck.Y) ^ 2) > (Radius - MaxDistance) And Math.Sqrt((m_XC - PointToCheck.X) ^ 2 + (m_YC - PointToCheck.Y) ^ 2) < (Radius + MaxDistance) Then
            Return True
        End If

        Return False
    End Function

    Public Function getCenterPointMinusRadius(Axis As String) As cPoint

        Dim Point As New cPoint

        If Axis = "X" Then
            Point.X = m_XC - m_Radius
            Point.Y = m_YC
        Else
            Point.X = m_XC
            Point.Y = m_YC - m_Radius
        End If
        Point.Z = m_ZC

        Return Point
    End Function

    Public Function getCenterPointPlusRadius(Axis As String) As cPoint

        Dim Point As New cPoint

        If Axis = "X" Then
            Point.X = m_XC + m_Radius
            Point.Y = m_YC
        Else
            Point.X = m_XC
            Point.Y = m_YC + m_Radius
        End If
        Point.Z = m_ZC

        Return Point
    End Function

    Public Function getSplineRepresentationPoints() As cSimplePoint()

        m_PointsForSplineRepresentation(0).X = m_XC + m_Radius
        m_PointsForSplineRepresentation(0).Y = m_YC
        m_PointsForSplineRepresentation(0).Z = m_ZC
        m_PointsForSplineRepresentation(1).X = m_XC
        m_PointsForSplineRepresentation(1).Y = m_YC + m_Radius
        m_PointsForSplineRepresentation(1).Z = m_ZC
        m_PointsForSplineRepresentation(2).X = m_XC - m_Radius
        m_PointsForSplineRepresentation(2).Y = m_YC
        m_PointsForSplineRepresentation(2).Z = m_ZC
        m_PointsForSplineRepresentation(3).X = m_XC
        m_PointsForSplineRepresentation(3).Y = m_YC - m_Radius
        m_PointsForSplineRepresentation(3).Z = m_ZC

        Return m_PointsForSplineRepresentation
    End Function

End Class
