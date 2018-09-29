Public Class cUserInterfaceState

    '----- Constructors ------

    Sub New()

    End Sub

    '----- Member variables -----

    Private m_States As Collection
    Private Structure StateStructure
        Dim InterfaceObject As Object
        Dim ObjectState As String
    End Structure
    Private m_ObjectState As New StateStructure
    Private m_ObjectFang() As String


    '----- Get and set properties -----

    Private Property States() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_States
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_States = Value
        End Set
    End Property

    Private Property ObjectState() As StateStructure
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ObjectState
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As StateStructure)
            m_ObjectState = Value
        End Set
    End Property

    Private Property ObjectFang() As String()
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ObjectFang
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String())
            m_ObjectFang = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----

    Public Sub getState()

    End Sub

    Public Sub setState(ByRef InterfaceObject As Object, ObjectState As String)

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose:  Sets the state of the choosen object.
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim x As Integer
        For x = 1 To States.Count

        Next
    End Sub

    Public Sub addState(ByRef InterfaceObject As Object, State As String)

    End Sub

End Class
