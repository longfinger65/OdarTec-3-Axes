Option Explicit On
Option Infer Off

Public Class cB_Spline
    Inherits cCADObject

    '----- Constructor ----------------------------------------------------

    Public Sub New()

        '----- Initialization -----

        m_Points(1) = New Point()

    End Sub

    Public Sub New(Points As cPoint())
        Me.New()

    End Sub

    Public Sub New(Line As cB_Spline)
        Me.New()

    End Sub


    '----- Begin member variables and constants -----------------------------------------------

    Public m_Points As Point()
    Public m_X2 As Double
    Public m_Y1 As Double
    Public m_Y2 As Double
    Public m_Z1 As Double
    Public m_Z2 As Double
    Private m_SketchName As String
    Private m_CamDescription As String

    '----- Get and set properties -----

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

