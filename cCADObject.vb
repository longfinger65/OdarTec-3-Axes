Public Class cCADObject

    '----- Constructor ----------------------------------------------------

    Public Sub New()

        m_Constraints = New Collection

        '----- Initialization -----
        IsHeighlighted = False
        IsSelected = False
    End Sub


    '----- Member Variables and constants -----------------------------------------------

    Private m_TypeOfEntity As String
    Private m_NameOfEntity As String
    Private m_StateOfEntity As Integer
    Private m_IsHeighlighted As Boolean
    Private m_IsSelected As Boolean
    Private m_Constraints As Collection
    Private m_ObjectRGBColor(3) As Integer

    '----- Get and set properties -----

    Public Property TypeOfEntity() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_TypeOfEntity
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_TypeOfEntity = Value
        End Set
    End Property

    Public Property NameOfEntity() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_NameOfEntity
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_NameOfEntity = Value
        End Set
    End Property

    Public Property StateOfEntity() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_StateOfEntity
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_StateOfEntity = Value
        End Set
    End Property

    Public Property IsHeighlighted() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_IsHeighlighted
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_IsHeighlighted = Value
        End Set
    End Property

    Public Property IsSelected() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_IsSelected
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_IsSelected = Value
        End Set
    End Property

    Public Property Constraints() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Constraints
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_Constraints = Value
        End Set
    End Property

    Public Property ObjectRGBColor() As Integer()
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ObjectRGBColor
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer())
            m_ObjectRGBColor = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes ---------------------------



End Class
