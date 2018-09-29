Public Class ObjectFang

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        '----- Initialization -----

    End Sub

    Public Sub New(TreeViewNodeName As String)

        Me.New()

        TreeNodeName = TreeViewNodeName

    End Sub

    Private m_TreeNodeName As String

    '----- Get and set properties -----

    Public Property TreeNodeName() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_TreeNodeName
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_TreeNodeName = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----


    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
