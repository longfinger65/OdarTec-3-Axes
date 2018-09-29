Public Class FM_Options

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Public Sub New(ByRef ToolLibrary As cToolManagement, ByRef UIStateManager As cUserInterfaceState)

        Me.New()

        m_TreeView1PageCollection = New Collection()

        '----- Initial settings -----

        m_ToolLibrary = ToolLibrary
        initializeControlsWithToolData()

        TreeView1PageCollection.Add(New ObjectFang("TreViI_ConstraintsFang"))
        TreeView1PageCollection.Item(TreeView1PageCollection.Count).Visible = False
        TreeView1PageCollection.Item(TreeView1PageCollection.Count).Parent = Me.TabPage1
        TreeView1PageCollection.Add(New UC_TreeViewPageSketch("TreViI_Sketch"))
        TreeView1PageCollection.Item(TreeView1PageCollection.Count).Visible = False
        TreeView1PageCollection.Item(TreeView1PageCollection.Count).Parent = Me.TabPage1
        TreeView1PageCollection.Add(New UC_General("TreViI_General"))
        TreeView1PageCollection.Item(TreeView1PageCollection.Count).Visible = False
        TreeView1PageCollection.Item(TreeView1PageCollection.Count).Parent = Me.TabPage1

    End Sub

    Private m_ToolLibrary As cToolManagement
    Private m_TreeView1PageCollection As Collection

    '----- Get and set properties -----

    Public Property ToolLibrary() As cToolManagement
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolLibrary
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cToolManagement)
            m_ToolLibrary = Value
        End Set
    End Property

    Public Property TreeView1PageCollection() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_TreeView1PageCollection
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_TreeView1PageCollection = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NuUpDo_ToolDiameter.ValueChanged

    End Sub

    Private Sub FM_Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CoBo_Tools.SelectedIndexChanged

    End Sub

    '----- Methodes belonging to TP_ToolLibrary -----

    Public Function initializeControlsWithToolData() As Boolean

        fillControlsWithToolData(m_ToolLibrary.getSpecifiedToolFromDBase(1))

        Return True
    End Function

    Public Function fillControlsWithToolData(Tool As cTool) As Boolean

        NuUpDo_ToolNumber.Value = Tool.ToolNumber
        TeBo_ToolName.Text = Tool.ToolName
        NuUpDo_ToolLength.Value = Tool.ToolLength
        NuUpDo_ToolDiameter.Value = Tool.ToolDiameter
        NuUpDo_ShaftDiameter1.Value = Tool.ShaftDiameter1
        NuUpDo_ShaftDiameter2.Value = Tool.ShaftDiameter2
        NuUpDo_NumberOfCuttingEdges.Value = Tool.NumberOfCuttingEdges
        NuUpDo_CuttingLength.Value = Tool.CuttingLength
        CheBo_CenterCut.Checked = Tool.CenterCut
        CheBo_InnerCooling.Checked = Tool.InnerCooling
        setCheLiBo_WorkPieceHardness(Tool.MaxWorkPieceHardness)


        Return True
    End Function

    Public Sub setCheLiBo_WorkPieceHardness(Hardness As Integer)
        Dim i As Integer
        Dim WorkPieceHardness As Integer
        Dim BufferArray(), Buffer As String

        For i = 0 To CheLiBo_WorkPieceHardness.Items.Count - 1
            BufferArray = Split(CheLiBo_WorkPieceHardness.Items.Item(i).ToString, ",")
            Buffer = BufferArray(1).Replace("HRC", "")
            WorkPieceHardness = CInt(Buffer.TrimStart(" "))

            If WorkPieceHardness < Hardness Then
                CheLiBo_WorkPieceHardness.SetItemChecked(i, True)
            End If
        Next

    End Sub

    Private Sub Bu_NewTool_Click(sender As Object, e As EventArgs) Handles Bu_NewTool.Click
        Dim Tool As New cTool

        '----- Set tool properties -----

        Tool.ToolName = TeBo_ToolName.Text
        Tool.ToolTyp = CoBo_ToolType.Text
        Tool.ToolLength = NuUpDo_ToolLength.Value
        Tool.ToolDiameter = NuUpDo_ToolDiameter.Value
        Tool.ShaftDiameter1 = NuUpDo_ShaftDiameter1.Value
        Tool.ShaftDiameter2 = NuUpDo_ShaftDiameter2.Value
        Tool.CornerRadius = 0
        Tool.ChamferSize = 0
        Tool.ChamferAngle = 0
        Tool.NumberOfCuttingEdges = NuUpDo_NumberOfCuttingEdges.Value
        Tool.CuttingLength = NuUpDo_CuttingLength.Value
        Tool.ToolMaterial = CoBo_ToolMaterial.Text
        Tool.ToolCoating = CoBo_ToolCoating.Text
        Tool.CenterCut = CheBo_CenterCut.Checked
        Tool.InnerCooling = CheBo_InnerCooling.Checked
        Tool.MaxWorkPieceHardness = getSelectedHardness()

        ToolLibrary.addToolToDBase(Tool)
    End Sub

    Private Sub TB_ToolName_TextChanged(sender As Object, e As EventArgs) Handles TeBo_ToolName.TextChanged

    End Sub

    Private Function getSelectedHardness() As Integer
        Dim WorkPieceHardness, Hardness, i As Integer
        Dim BufferArray(), Buffer As String

        '----- Begin Initial settings -----

        Hardness = 0

        '----- End initial settings -----

        For i = 0 To CheLiBo_WorkPieceHardness.Items.Count - 1
            BufferArray = Split(CheLiBo_WorkPieceHardness.Items.Item(i).ToString, ",")
            Buffer = BufferArray(1).Replace("HRC", "")
            WorkPieceHardness = CInt(Buffer.TrimStart(" "))

            If WorkPieceHardness > Hardness Then
                Hardness = WorkPieceHardness
            End If
        Next

        Return Hardness
    End Function


    Private Sub TreeView1_Click(sender As Object, e As EventArgs) Handles TreeView1.Click
    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick

        Dim ControlName As String

        Select Case e.Node.Name

            Case "TreViI_ConstraintsFang"
                ControlName = "TreViI_ConstraintsFang"
            Case "TreViI_Sketch"
                ControlName = "TreViI_Sketch"
            Case "TreViI_General"
                ControlName = "TreViI_General"

        End Select
        For i As Integer = 1 To TreeView1PageCollection.Count
            If TreeView1PageCollection.Item(i).TreeNodeName <> ControlName Then
                TreeView1PageCollection.Item(i).Visible = False
            Else
                TreeView1PageCollection.Item(i).Visible = True
                TreeView1PageCollection.Item(i).Left = TreeView1.Width
            End If

        Next


    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        actualizeUIState()
    End Sub

    Private Function actualizeUIState() As Boolean


        Return True
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub


    'Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click
    '    m_CamBox.showIt()
    'End Sub
End Class