Option Explicit On
Option Infer Off

Public Class cArc
    Inherits cCADObject

    '----- Begin Description -------------------------------------------------------
    '
    ' Purpose:  This class describes an arc by StartAngle, EndAngle, Radius and Center-
    '           Point that goes couterclockwise from StartAngle to EndAngle.
    '
    '----- End description ---------------------------------------------------------

    '----- Constructor ----------------------------------------------------

    Public Sub New()

        m_StartPoint = New cPoint
        m_EndPoint = New cPoint

        '----- Initialization -----

        m_XC = Nothing
        m_YC = Nothing
        StartPoint.X = Nothing
        StartPoint.Y = Nothing
        EndPoint.X = Nothing
        EndPoint.Y = Nothing
        StartAngle = Nothing
        EndAngle = Nothing
        For i As Integer = 0 To 3
            m_PointsForSplineRepresentation(i) = New cSimplePoint()
        Next

    End Sub

    Public Sub New(CenterPoint As cPoint, StartAngle As Double, EndAngle As Double)
        Me.New()

        '----- Initialization -----

        Me.StartAngle = StartAngle
        Me.EndAngle = EndAngle

    End Sub

    Public Sub New(X As Double, Y As Double, Z As Double, StartAngle As Double, EndAngle As Double)
        Me.New()

        '----- Initialization -----

        Me.m_XC = X
        Me.m_YC = Y
        Me.m_ZC = Z

        Me.StartAngle = StartAngle
        Me.EndAngle = EndAngle

    End Sub

    Public Sub New(Arc As cArc)
        Me.New()

        '----- Initialization -----
        Me.m_XC = Arc.m_XC
        Me.m_YC = Arc.m_YC
        Me.m_ZC = Arc.m_ZC
        Me.StartAngle = Arc.StartAngle
        Me.EndAngle = Arc.EndAngle

    End Sub

    '----- Member Variables and constants -----------------------------------------------

    Public m_XC As Double
    Public m_YC As Double
    Public m_ZC As Double
    Private m_StartPoint As cPoint
    Private m_EndPoint As cPoint
    Private m_StartAngle As Double
    Private m_EndAngle As Double
    Private m_Radius As Double
    Private m_SketchName As String
    Private m_PointsForSplineRepresentation(3) As cSimplePoint

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

    Public Property StartAngle() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_StartAngle
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_StartAngle = Value
            setStartAndEndPoint()
        End Set
    End Property

    Public Property EndAngle() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_EndAngle
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_EndAngle = Value
            setStartAndEndPoint()
        End Set
    End Property

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

    '----- End member variables and constants, begin member methodes ---------------------------

    Public Function checkIfPointIsNearby(PointToCheck As cPoint, MaxDistance As Double) As Boolean

        Dim Angle, IntermideateAngle As Double

        If Math.Sqrt((m_XC - PointToCheck.X) ^ 2 + (m_YC - PointToCheck.Y) ^ 2) > (Radius - MaxDistance) And Math.Sqrt((m_XC - PointToCheck.X) ^ 2 + (m_YC - PointToCheck.Y) ^ 2) < (Radius + MaxDistance) Then
            IntermideateAngle = Math.Acos(Math.Sqrt((m_XC - PointToCheck.X) ^ 2) / Radius) * 360 / (2 * Math.PI)

            If PointToCheck.X >= m_XC And PointToCheck.Y >= m_YC Then
                Angle = IntermideateAngle
            End If
            If PointToCheck.X < m_XC And PointToCheck.Y >= m_YC Then
                Angle = 180 - IntermideateAngle
            End If
            If PointToCheck.X < m_XC And PointToCheck.Y < m_YC Then
                Angle = 180 + IntermideateAngle
            End If
            If PointToCheck.X >= m_XC And PointToCheck.Y < m_YC Then
                Angle = 360 - IntermideateAngle
            End If

            'Console.WriteLine("StartAngle = " + CStr(StartAngle) + ", EndAngle = " + CStr(EndAngle) + ", Angle = " + CStr(Angle))

            Select Case StartAngle
                Case Is > EndAngle
                    Select Case Angle
                        Case Is < EndAngle
                            Return True
                        Case Is > EndAngle
                            If Angle >= StartAngle Then
                                Return True
                            End If
                    End Select
                Case Is < EndAngle
                    If Angle >= StartAngle And Angle <= EndAngle Then
                        Return True
                    End If
            End Select
        End If
        Return False
    End Function

    Private Sub setStartAndEndPoint()

        If StartAngle <> Nothing And m_XC <> Nothing And m_YC <> Nothing Then
            Select Case StartAngle
                Case Is <= 90
                    StartPoint.X = m_XC + Radius * Math.Cos(StartAngle * 2 * Math.PI / 360)
                    StartPoint.Y = m_YC + Radius * Math.Sin(StartAngle * 2 * Math.PI / 360)
                Case Is > 90, Is <= 180
                    StartPoint.X = m_XC - Radius * Math.Cos((180 - StartAngle) * 2 * Math.PI / 360)
                    StartPoint.Y = m_YC + Radius * Math.Sin((180 - StartAngle) * 2 * Math.PI / 360)
                Case Is > 180, Is <= 270
                    StartPoint.X = m_XC - Radius * Math.Cos((StartAngle - 180) * 2 * Math.PI / 360)
                    StartPoint.Y = m_YC - Radius * Math.Sin((StartAngle - 180) * 2 * Math.PI / 360)
                Case Is > 270
                    StartPoint.X = m_XC + Radius * Math.Cos((360 - StartAngle) * 2 * Math.PI / 360)
                    StartPoint.Y = m_YC - Radius * Math.Sin((360 - StartAngle) * 2 * Math.PI / 360)
            End Select
        End If
        If EndAngle <> Nothing And m_XC <> Nothing And m_YC <> Nothing Then
            Select Case EndAngle
                Case Is <= 90
                    EndPoint.X = m_XC + Radius * Math.Cos(StartAngle * 2 * Math.PI / 360)
                    EndPoint.Y = m_YC + Radius * Math.Sin(StartAngle * 2 * Math.PI / 360)
                Case Is > 90, Is <= 180
                    EndPoint.X = m_XC - Radius * Math.Cos((180 - StartAngle) * 2 * Math.PI / 360)
                    EndPoint.Y = m_YC + Radius * Math.Sin((180 - StartAngle) * 2 * Math.PI / 360)
                Case Is > 180, Is <= 270
                    EndPoint.X = m_XC - Radius * Math.Cos((StartAngle - 180) * 2 * Math.PI / 360)
                    EndPoint.Y = m_YC - Radius * Math.Sin((StartAngle - 180) * 2 * Math.PI / 360)
                Case Is > 270
                    EndPoint.X = m_XC + Radius * Math.Cos((360 - StartAngle) * 2 * Math.PI / 360)
                    EndPoint.Y = m_YC - Radius * Math.Sin((360 - StartAngle) * 2 * Math.PI / 360)
            End Select

        End If

    End Sub

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
