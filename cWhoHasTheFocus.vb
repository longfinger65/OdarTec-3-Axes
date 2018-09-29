Public Class cWhoHasTheFocus

    '----- Constructor ----------------------------------------------------

    Public Sub New()
        Focus = "nothing"
    End Sub


    '----- Member Variables and constants -----------------------------------------------

    Private m_Focus As String

    '----- Get and set properties -----

    Public Property Focus() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Focus
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_Focus = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----

End Class
