Option Explicit On
Option Infer Off

Public Class cSimplePoint

    '----- Constructor ----------------------------------------------------

    Public Sub New()
        X = 0
        Y = 0
        Z = 0
        m_Annotation = ""
    End Sub

    Public Sub New(X As Double)
        X = X
        Y = 0.0
        Z = 0.0
        m_Annotation = ""
    End Sub

    Public Sub New(X As Double, Y As Double)
        X = X
        Y = Y
        Z = 0.0
        m_Annotation = ""
    End Sub

    Public Sub New(X As Double, Y As Double, Z As Double)
        X = X
        Y = Y
        Z = Z
        m_Annotation = ""
    End Sub

    Public Sub New(X As Double, Y As Double, Annotation As String)
        X = X
        Y = Y
        Z = 0.0
        m_Annotation = Annotation
    End Sub

    Public Sub New(X As Double, Y As Double, Z As Double, Annotation As String)
        m_X = X
        m_Y = Y
        m_Z = Z
        m_Annotation = Annotation
    End Sub

    Public Sub New(SimplePoint As cSimplePoint)
        m_X = SimplePoint.m_X
        m_Y = SimplePoint.m_Y
        m_Z = SimplePoint.m_Z
        m_Annotation = SimplePoint.Annotation
    End Sub

    '----- Begin member variables and constants -----------------------------------------------

    Public m_X As Double
    Public m_Y As Double
    Public m_Z As Double
    Public m_Annotation As String

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

    Public Property Annotation() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Annotation
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_Annotation = Value
        End Set
    End Property

    '----- End member variables, begin member methodes ----------------------

End Class
