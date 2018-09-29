Public Class cTerms

    Sub New()

    End Sub

    '----- Begin member variables, begin member methodes ----------------------

    Private m_InterfaceStateTerm As Collection
    Const BUTTONPRESSED As String = "ButtonPressed"

    '----- Begin properties -----

    Public Property InterfaceStateTerm() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_InterfaceStateTerm
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_InterfaceStateTerm = Value
        End Set
    End Property

    '----- End member variables, begin member methodes ----------------------

End Class
