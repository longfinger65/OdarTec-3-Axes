Imports System.Runtime.InteropServices


Public Class PartViewer

    '----- Begin constructors -----------------------------------------------

    Public Sub New(ByRef ToolLibrary As cToolManagement)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        'OpenTK.Toolkit.Init()
        RegisterEventHandler()

        Panel_GraphicArea = New cBufferedPanel()
        m_GeoRepManager = New cOTGeometricRepresentationManager()
        m_ObjectRepresentation = New cObjectRepresentation(m_GeoRepManager)
        m_WhoHasFocus = New cWhoHasTheFocus()
        m_NCProg = New cOdarTecNCProg()
        m_Pocket = New cCamPocket()
        m_UserInterfaceState = New cUserInterfaceState()
        m_CamPathProperties = New CamPath(m_ObjectRepresentation, WhoHasFocus, ToolLibrary, WhatIsActive, Panel_GraphicArea)
        m_CamPocketProperties = New CamPocket(m_ObjectRepresentation, WhoHasFocus, ToolLibrary, WhatIsActive, Panel_GraphicArea)
        m_CamBoreProperties = New CamBore(m_ObjectRepresentation, WhoHasFocus, ToolLibrary, WhatIsActive, Panel_GraphicArea)
        m_CamPictureProperties = New CamPicture(m_ObjectRepresentation, WhoHasFocus, ToolLibrary, WhatIsActive, Panel_GraphicArea, FeatureManager)
        m_CamFaceMillingProperties = New CamFaceMilling(m_ObjectRepresentation, WhoHasFocus, ToolLibrary, WhatIsActive, Panel_GraphicArea)
        m_Cam3DProperties = New Cam3D(m_ObjectRepresentation, WhoHasFocus, ToolLibrary, WhatIsActive, Panel_GraphicArea)
        m_CamTestProperties = New CamTest(m_ObjectRepresentation, WhoHasFocus, ToolLibrary, WhatIsActive, Panel_GraphicArea, FeatureManager)
        m_StartPoint = New cPoint()
        m_EndPoint = New cPoint()
        m_HighlightedPoint = New cPoint()
        m_CatchPoint = New cPoint()
        m_TangentEndPoint = New cPoint()
        m_CamStartPoint = New cPoint()
        'm_Path = New System.Drawing.Drawing2D.GraphicsPath()
        m_LastAction = New cOTString("none")
        m_MouseStart = New Point()
        m_MouseStop = New Point()
        m_Filter = New cOTString("none")
        'm_EntityEditor = New EntityEdit(m_ObjectRepresentation, WhoHasFocus, WhatIsActive, Panel_GraphicArea)

        '----- Initial settings -----

        Panel_GraphicArea.Parent = Me
        Panel_GraphicArea.Visible = True
        Panel_GraphicArea.BackColor = System.Drawing.Color.Lavender
        Panel_GraphicArea.BorderStyle = BorderStyle.FixedSingle
        Status_SomethingIsInProcess = False
        Status_SketchIsInProcess = False
        GM.ZoomFactor = 1
        MouseState = ""
        ViewChange = ""
        Me.ToolLibrary = ToolLibrary
        CatchFlag = False
        MouseDownn = False
        CamPathProperties.Visible = False
        CamPocketProperties.Visible = False
        CamBoreProperties.Visible = False
        CamPictureProperties.Visible = False
        CamFaceMillingProperties.Visible = False
        Cam3DProperties.Visible = False
        CamTestProperties.Visible = False
        m_LastChoosenElement = ""

    End Sub

    '----- End constructors, begin member Variables and constants -----------------------------

    Friend WithEvents Panel_GraphicArea As cBufferedPanel

    Public m_ObjectRepresentation As cObjectRepresentation
    Private m_WhoHasFocus As cWhoHasTheFocus

    Private m_NCProg As cOdarTecNCProg
    Private m_Pocket As cCamPocket

    Private m_MouseDown As Boolean

    Private m_StartPoint As cPoint
    Private m_EndPoint As cPoint
    Private m_HighlightedPoint As cPoint
    Private m_CatchPoint As cPoint
    Private m_TangentEndPoint As cPoint
    Private m_CatchFlag As Boolean = False
    Private m_CamStartPoint As cPoint
    Private m_WhichModul As Integer
    Private m_Path As System.Drawing.Drawing2D.GraphicsPath
    Private m_ClickedTreeViewNode As TreeNode
    Private m_ActiveElementType As Type
    Private m_CamPathProperties As CamPath
    Private m_CamPocketProperties As CamPocket
    Private m_CamBoreProperties As CamBore
    Private m_CamPictureProperties As CamPicture
    Private m_CamFaceMillingProperties As CamFaceMilling
    Private m_Cam3DProperties As Cam3D
    Private m_ToolLibrary As cToolManagement
    Private m_LastAction As cOTString
    Private m_WhatIsActive As String
    Private m_Filter As cOTString
    Private m_LastChoosenElement As String
    Private m_CamTestProperties As CamTest

    'Private m_EntityEditor As EntityEdit

    '----- Begin sketch element related variables -----



    '----- Begin view state variables -----

    Private m_MouseStart As Point
    Private m_MouseStop As Point
    Private m_MouseState As String
    Private m_ViewChange As String
    Private m_UserInterfaceState As cUserInterfaceState
    Private m_Cursor As Cursor
    Private m_GeoRepManager As cOTGeometricRepresentationManager

    '----- End view state variables -----

    Public Structure StateStruct
        Public SomethingIsInProcess As Boolean
        Public SketchIsInProcess As Boolean
        Public CamPathIsInProcess As Boolean
    End Structure
    Public m_Status As StateStruct

    '----- Begin properties -----

    Public Property ObjectRepresentation() As cObjectRepresentation
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ObjectRepresentation
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cObjectRepresentation)
            m_ObjectRepresentation = Value
        End Set
    End Property

    Public Property WhoHasFocus() As cWhoHasTheFocus
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_WhoHasFocus
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cWhoHasTheFocus)
            m_WhoHasFocus = Value
        End Set
    End Property

    Public Property NCProg() As cOdarTecNCProg
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_NCProg
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cOdarTecNCProg)
            m_NCProg = Value
        End Set
    End Property

    Public Property Pocket() As cCamPocket
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Pocket
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cCamPocket)
            m_Pocket = Value
        End Set
    End Property

    Public Property MouseDownn() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_MouseDown
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_MouseDown = Value
        End Set
    End Property

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

    Public Property HighlightedPoint() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_HighlightedPoint
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_HighlightedPoint = Value
        End Set
    End Property

    Public Property CatchPoint() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CatchPoint
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_CatchPoint = Value
        End Set
    End Property

    Public Property TangentEndPoint() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_TangentEndPoint
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_TangentEndPoint = Value
        End Set
    End Property

    Public Property CatchFlag() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CatchFlag
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_CatchFlag = Value
        End Set
    End Property

    Public Property CamStartPoint() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CamStartPoint
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_CamStartPoint = Value
        End Set
    End Property

    Public Property WhichModul() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_WhichModul
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_WhichModul = Value
        End Set
    End Property

    Public Property Filter() As cOTString
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Filter
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cOTString)
            m_Filter = Value
        End Set
    End Property

    Public Property Path() As System.Drawing.Drawing2D.GraphicsPath
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Path
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As System.Drawing.Drawing2D.GraphicsPath)
            m_Path = Value
        End Set
    End Property

    Public Property ClickedTreeViewNode() As TreeNode
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ClickedTreeViewNode
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As TreeNode)
            m_ClickedTreeViewNode = Value
        End Set
    End Property

    Public Property ActiveElementType() As Type
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ActiveElementType
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Type)
            m_ActiveElementType = Value
        End Set
    End Property

    Public Property CamPathProperties() As CamPath
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CamPathProperties
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As CamPath)
            m_CamPathProperties = Value
        End Set
    End Property

    Public Property CamPocketProperties() As CamPocket
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CamPocketProperties
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As CamPocket)
            m_CamPocketProperties = Value
        End Set
    End Property

    Public Property CamBoreProperties() As CamBore
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CamBoreProperties
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As CamBore)
            m_CamBoreProperties = Value
        End Set
    End Property

    Public Property CamPictureProperties() As CamPicture
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CamPictureProperties
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As CamPicture)
            m_CamPictureProperties = Value
        End Set
    End Property

    Public Property CamFaceMillingProperties() As CamFaceMilling
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CamFaceMillingProperties
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As CamFaceMilling)
            m_CamFaceMillingProperties = Value
        End Set
    End Property

    Public Property Cam3DProperties() As Cam3D
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Cam3DProperties
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Cam3D)
            m_Cam3DProperties = Value
        End Set
    End Property

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

    Public Property LastAction() As cOTString
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_LastAction
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cOTString)
            m_LastAction = Value
        End Set
    End Property

    Public Property WhatIsActive() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_WhatIsActive
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_WhatIsActive = Value
        End Set
    End Property

    Public Property MouseStart() As Point
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_MouseStart
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Point)
            m_MouseStart = Value
        End Set
    End Property

    Public Property MouseStop() As Point
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_MouseStop
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Point)
            m_MouseStop = Value
        End Set
    End Property

    Public Property MouseState() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_MouseState
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_MouseState = Value
        End Set
    End Property

    Public Property ViewChange() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ViewChange
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_ViewChange = Value
        End Set
    End Property

    Public Property UserInterfaceState() As cUserInterfaceState
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_UserInterfaceState
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cUserInterfaceState)
            m_UserInterfaceState = Value
        End Set
    End Property

    Public Property Status_SomethingIsInProcess() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Status.SomethingIsInProcess
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_Status.SomethingIsInProcess = Value
        End Set
    End Property

    Public Property Status_SketchIsInProcess() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Status.SketchIsInProcess
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_Status.SketchIsInProcess = Value
        End Set
    End Property

    Public Property Status_CamPathIsInProcess() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Status.CamPathIsInProcess
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_Status.CamPathIsInProcess = Value
        End Set
    End Property

    Public Property GM() As cOTGeometricRepresentationManager
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_GeoRepManager
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cOTGeometricRepresentationManager)
            m_GeoRepManager = Value
        End Set
    End Property

    Public Property CamTestProperties() As CamTest
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CamTestProperties
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As CamTest)
            m_CamTestProperties = Value
        End Set
    End Property

    '----- End member variables, begin member methodes --------------------------------------------

    Private Sub RegisterEventHandler()
        AddHandler Me.SizeChanged, AddressOf GraphicPanel_SizeChanged
    End Sub 'RegisterEventHandler

    Public Sub GraphicPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CamPathProperties.Visible = False
        CamPocketProperties.Visible = False
        CamBoreProperties.Visible = False
        CamPictureProperties.Visible = False
        CamTestProperties.Visible = False
        FeatureManager.TabPages("TabPage_Properties").Controls.Add(CamPathProperties)
        FeatureManager.TabPages("TabPage_Properties").Controls.Add(CamPocketProperties)
        FeatureManager.TabPages("TabPage_Properties").Controls.Add(CamBoreProperties)
        FeatureManager.TabPages("TabPage_Properties").Controls.Add(CamPictureProperties)
        FeatureManager.TabPages("TabPage_Properties").Controls.Add(CamFaceMillingProperties)
        FeatureManager.TabPages("TabPage_Properties").Controls.Add(Cam3DProperties)
        'FeatureManager.TabPages("TabPage_Properties").Controls.Add(CamScanProperties)
        FeatureManager.TabPages("TabPage_Properties").Controls.Add(CamTestProperties)
        setLayout()
    End Sub

    Private Sub GraphicPanel_SizeChanged(sender As Object, e As EventArgs)

        actualizeElementSize()

    End Sub

    Public Sub GraphicPanel_Paint(sender As Object, e As EventArgs) Handles Panel_GraphicArea.Paint
        Panel1_Paint(sender, e)
        actualizeElementSize()
    End Sub


    Private Sub ComListenerToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComSenderToolStripMenuItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub ControlPanelToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TerminalToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

        Dim myPen As New Pen(System.Drawing.Color.Black)

        ObjectRepresentation.sub_ShowMe(e, TreVi_Feature, TreeView2, ContextMenuStrip1, GM)
        Select Case LastAction.getValue()
            Case LastAction.getValue("none")

            Case LastAction.getValue("choose")
                myPen.DashStyle = Drawing2D.DashStyle.Dot
                e.Graphics.DrawRectangle(myPen, MouseStart.X, MouseStart.Y, MouseStop.X - MouseStart.X, MouseStop.Y - MouseStart.Y)
        End Select
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel_GraphicArea.MouseDown


        MouseStart = e.Location
        GM.TransformationStart(e.Location)
        Select Case e.Button
            Case System.Windows.Forms.MouseButtons.Left
                MouseState = "left"

                Select Case LastAction.getValue()
                    Case LastAction.getValue("SketchLine")
                        For i As Integer = 1 To ObjectRepresentation.Objects.Count
                            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cSketch) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                ObjectRepresentation.Objects.Item(i).addElement(New cLine(GM.tPB(e.X, e.Y, 0)(0), GM.tPB(e.X, e.Y, 0)(1), GM.tPB(e.X, e.Y, 0)(0), GM.tPB(e.X, e.Y, 0)(1)))
                            End If
                        Next
                    Case LastAction.getValue("SketchCircleCenterPoint")
                        For i As Integer = 1 To ObjectRepresentation.Objects.Count
                            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cSketch) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                ObjectRepresentation.Objects.Item(i).addElement(New cCircle(GM.tPB(e.X, e.Y, 0)(0), GM.tPB(e.X, e.Y, 0)(1), 0))
                            End If
                        Next
                    Case LastAction.getValue("none")
                        For i As Integer = 1 To ObjectRepresentation.Objects.Count
                            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cSketch) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                m_LastChoosenElement = ObjectRepresentation.getNearestElement(GM.tPBX(e.X), GM.tPBY(e.Y))
                                LastAction.addValue("moveElement")
                            End If
                        Next

                End Select
            Case System.Windows.Forms.MouseButtons.Right
                MouseState = "right"
            Case System.Windows.Forms.MouseButtons.Middle
                MouseState = "middle"
        End Select
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel_GraphicArea.MouseMove

        Select Case e.Button
            Case (System.Windows.Forms.MouseButtons.Left)
                Select Case LastAction.getValue()

                    Case LastAction.getValue("none")

                        For i As Integer = 1 To ObjectRepresentation.Objects.Count
                            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cSketch) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                ObjectRepresentation.moveElement()
                            End If
                        Next

                        GM.actualizeTransformation(e.Location, "none")
                    Case LastAction.getValue("SketchLine")
                        For i = 1 To ObjectRepresentation.Objects.Count
                            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cSketch) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                ObjectRepresentation.Objects.Item(i).Sketch.item(ObjectRepresentation.Objects.Item(i).Sketch.count).m_X2 = GM.tPB(e.X, e.Y, 0)(0)
                                ObjectRepresentation.Objects.Item(i).Sketch.item(ObjectRepresentation.Objects.Item(i).Sketch.count).m_Y2 = GM.tPB(e.X, e.Y, 0)(1)
                            End If
                        Next
                    Case LastAction.getValue("SketchCircleCenterPoint")
                        For i = 1 To ObjectRepresentation.Objects.Count
                            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cSketch) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                ObjectRepresentation.Objects.Item(i).Sketch.item(ObjectRepresentation.Objects.Item(i).Sketch.count).Radius = Math.Sqrt((ObjectRepresentation.Objects.Item(i).Sketch.item(ObjectRepresentation.Objects.Item(i).Sketch.count).m_XC - GM.tPB(e.X, e.Y, 0)(0)) ^ 2 + (ObjectRepresentation.Objects.Item(i).Sketch.item(ObjectRepresentation.Objects.Item(i).Sketch.count).m_YC - GM.tPB(e.X, e.Y, 0)(1)) ^ 2)
                            End If
                        Next
                    Case LastAction.getValue("choose")
                        MouseStop = e.Location
                        Panel_GraphicArea.Invalidate()
                    Case LastAction.getValue("moveElement")

                End Select
            Case (System.Windows.Forms.MouseButtons.Right)
                Select Case LastAction.getValue()
                    Case LastAction.getValue("rotate")
                        GM.actualizeTransformation(e.Location, "rotate")
                    Case LastAction.getValue("none")
                        GM.actualizeTransformation(e.Location, "zoom")
                End Select

            Case Else
                ObjectRepresentation.fun_HighlightSketchElement(e.X, e.Y, 2, GM)

        End Select
        Panel_GraphicArea.Refresh()
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel_GraphicArea.MouseUp
        MouseState = ""
        Select Case LastAction.getValue()
            Case LastAction.getValue("SketchLine")
                For i As Integer = 1 To ObjectRepresentation.Objects.Count
                    If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cSketch) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                        ObjectRepresentation.Objects.Item(i).checkLastElement()
                    End If
                Next
            Case LastAction.getValue("SketchCircleCenterPoint")
                For i As Integer = 1 To ObjectRepresentation.Objects.Count
                    If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cSketch) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                        ObjectRepresentation.Objects.Item(i).checkLastElement()
                    End If
                Next
            Case LastAction.getValue("choose")
                Select Case WhatIsActive
                    Case "Sketch"

                    Case "CamBore"
                        For i = 1 To ObjectRepresentation.Objects.Count
                            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cCamBore) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = True
                                ObjectRepresentation.getElementsInChooserRectangle(GM.tPB(MouseStart.X, MouseStart.Y, 0)(0), GM.tPB(MouseStart.X, MouseStart.Y, 0)(1), GM.tPB(MouseStop.X, MouseStop.Y, 0)(0), GM.tPB(MouseStop.X, MouseStop.Y, 0)(1), Filter)
                                CamBoreProperties.refreshDisplay()
                            End If
                        Next
                    Case "CamPath"
                        For i = 1 To ObjectRepresentation.Objects.Count
                            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cCamPath) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = True
                                ObjectRepresentation.getElementsInChooserRectangle(GM.tPB(MouseStart.X, MouseStart.Y, 0)(0), GM.tPB(MouseStart.X, MouseStart.Y, 0)(1), GM.tPB(MouseStop.X, MouseStop.Y, 0)(0), GM.tPB(MouseStop.X, MouseStop.Y, 0)(1), Filter)
                                CamPathProperties.refreshDisplay()
                            End If
                        Next
                    Case "CamPocket"
                        For i = 1 To ObjectRepresentation.Objects.Count
                            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cCamPocket) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = True
                                ObjectRepresentation.getElementsInChooserRectangle(GM.tPB(MouseStart.X, MouseStart.Y, 0)(0), GM.tPB(MouseStart.X, MouseStart.Y, 0)(1), GM.tPB(MouseStop.X, MouseStop.Y, 0)(0), GM.tPB(MouseStop.X, MouseStop.Y, 0)(1), Filter)
                                CamPocketProperties.refreshDisplay()
                            End If
                        Next
                    Case "CamPicture"
                        For i = 1 To ObjectRepresentation.Objects.Count
                            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cCamPicture) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = True
                                ObjectRepresentation.getElementsInChooserRectangle(GM.tPB(MouseStart.X, MouseStart.Y, 0)(0), GM.tPB(MouseStart.X, MouseStart.Y, 0)(1), GM.tPB(MouseStop.X, MouseStop.Y, 0)(0), GM.tPB(MouseStop.X, MouseStop.Y, 0)(1), Filter)
                                CamPictureProperties.refreshDisplay()
                            End If
                        Next

                End Select

        End Select
        MouseStop = MouseStart
        LastAction.VString = "none"
    End Sub

    Private Sub Panel1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel_GraphicArea.MouseClick


#If DEBUG Then
        System.Console.WriteLine(WhoHasFocus.Focus)
#End If

        Select Case WhatIsActive
            Case "Sketch"
                Select Case LastAction.getValue()
                    Case LastAction.getValue("SketchPoint")
                        LastAction.VString = "none"
                        For i As Integer = 1 To ObjectRepresentation.Objects.Count
                            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cSketch) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                ObjectRepresentation.Objects.Item(i).addElement(New cPoint(GM.tPB(e.X, e.Y, 0)(0), GM.tPB(e.X, e.Y, 0)(1)))
                            End If
                        Next
                End Select
            Case "CamPocket", "CamPath", "CamBore", "CamPicture", "Cam3D"

                Select Case e.Button
                    Case System.Windows.Forms.MouseButtons.Left
                        Select Case WhoHasFocus.Focus
                            Case "PathStartPointChooser"
                                CamPathProperties.TeBo_PocketStartPointX.Text = CStr(GM.tPB(e.X, e.Y, 0)(0))
                                CamPathProperties.TeBo_PocketStartPointY.Text = CStr(GM.tPB(e.X, e.Y, 0)(1))
                            Case "PathOriginChooser"
                                CamPathProperties.TextBox_OriginX.Text = CStr(GM.tPB(e.X, e.Y, 0)(0))
                                CamPathProperties.TextBox_OriginY.Text = CStr(GM.tPB(e.X, e.Y, 0)(1))
                            Case "PocketStartPointChooser"
                                CamPocketProperties.TextBox_PocketStartPointX.Text = CStr(GM.tPB(e.X, e.Y, 0)(0))
                                CamPocketProperties.TextBox_PocketStartPointY.Text = CStr(GM.tPB(e.X, e.Y, 0)(1))
                            Case "PocketOriginChooser"
                                CamPocketProperties.TextBox_OriginX.Text = CStr(GM.tPB(e.X, e.Y, 0)(0))
                                CamPocketProperties.TextBox_OriginY.Text = CStr(GM.tPB(e.X, e.Y, 0)(1))
                            Case "BoreOriginChooser"
                                CamBoreProperties.TeBo_OriginX.Text = CStr(GM.tPB(e.X, e.Y, 0)(0))
                                CamBoreProperties.TeBo_OriginY.Text = CStr(GM.tPB(e.X, e.Y, 0)(1))
                            Case "PictureOriginChooser"
                                CamPictureProperties.TeBo_OriginX.Text = CStr(GM.tPB(e.X, e.Y, 0)(0))
                                CamPictureProperties.TeBo_OriginY.Text = CStr(GM.tPB(e.X, e.Y, 0)(1))
                            Case "Cam3DLowerLeftBorderPointChooser"
                                Cam3DProperties.TeBo_LoLeBoEdgeX.Text = CStr(GM.tPB(e.X, e.Y, 0)(0))
                                Cam3DProperties.TeBo_LoLeBoEdgeY.Text = CStr(GM.tPB(e.X, e.Y, 0)(1))
                            Case "Cam3DUpperRightBorderPointChooser"
                                Cam3DProperties.TeBo_UpRiBoEdgeX.Text = CStr(GM.tPB(e.X, e.Y, 0)(0))
                                Cam3DProperties.TeBo_UpRiBoEdgeY.Text = CStr(GM.tPB(e.X, e.Y, 0)(1))
                            Case "CamElementChooser"
                                For i = 1 To ObjectRepresentation.Objects.Count
                                    If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cCamPath) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                        ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = True
                                        ObjectRepresentation.fun_HighlightSketchElement(e.X, e.Y, 3, GM)
                                        CamPathProperties.refreshDisplay()
                                    End If
                                Next
                                For i = 1 To ObjectRepresentation.Objects.Count
                                    If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cCamPocket) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                        ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = True
                                        ObjectRepresentation.fun_HighlightSketchElement(e.X, e.Y, 3, GM)
                                        CamPocketProperties.refreshDisplay()
                                    End If
                                Next
                                For i = 1 To ObjectRepresentation.Objects.Count
                                    If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cCamBore) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                        ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = True
                                        ObjectRepresentation.fun_HighlightSketchElement(e.X, e.Y, 3, GM)
                                        CamBoreProperties.refreshDisplay()
                                    End If
                                Next
                                For i = 1 To ObjectRepresentation.Objects.Count
                                    If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cCamPicture) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                        ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = True
                                        ObjectRepresentation.fun_HighlightSketchElement(e.X, e.Y, 3, GM)
                                        CamPictureProperties.refreshDisplay()
                                    End If
                                Next
                            Case "nothing"
                                For i = 1 To ObjectRepresentation.Objects.Count
                                    Select Case ObjectRepresentation.Objects.Item(i).GetType()
                                        Case GetType(cSketch)
                                            ObjectRepresentation.fun_HighlightSketchElement(e.X, e.Y, 1, GM)
                                    End Select
                                Next
                        End Select
                    Case System.Windows.Forms.MouseButtons.Right
                End Select
        End Select
    End Sub

    Private Sub Panel1_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel_GraphicArea.MouseDoubleClick

        Select Case WhatIsActive
            Case "Sketch"
                Select Case LastAction.getValue()
                    Case LastAction.getValue("SketchPoint")
                        LastAction.VString = "none"
                        For i As Integer = 1 To ObjectRepresentation.Objects.Count
                            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cSketch) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                ObjectRepresentation.Objects.Item(i).addElement(New cPoint(GM.tPB(e.X, e.Y, 0)(0), GM.tPB(e.X, e.Y, 0)(1)))
                            End If
                        Next
                    Case LastAction.getValue("none")
                        Dim ElementNearby As String
                        For i As Integer = 1 To ObjectRepresentation.Objects.Count
                            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cSketch) And ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                                ElementNearby = ObjectRepresentation.fun_HighlightSketchElement(e.X, e.Y, 99, GM)
                                Dim Element() As String
                                If ElementNearby.Contains("Startpoint") Then
                                    Element = Split(ElementNearby, "@")
                                    Dim myEntityEditor As New EntityEditor(ObjectRepresentation.Objects.Item(i).sketch.item(Element(1)), "Startpoint")
                                    myEntityEditor.Location = e.Location
                                    myEntityEditor.ShowDialog()
                                End If
                                If ElementNearby.Contains("Endpoint") Then
                                    Element = Split(ElementNearby, "@")
                                    Dim myEntityEditor As New EntityEditor(ObjectRepresentation.Objects.Item(i).sketch.item(Element(1)), "Endpoint")
                                    myEntityEditor.Location = e.Location
                                    myEntityEditor.ShowDialog()
                                End If
                                If ElementNearby.Contains("Circle") Then
                                    Element = Split(ElementNearby, "@")
                                    Dim myEntityEditor As New EntityEditor(ObjectRepresentation.Objects.Item(i).sketch.item(Element(0)), "Circle")
                                    myEntityEditor.Location = e.Location
                                    myEntityEditor.ShowDialog()
                                End If
                                If ElementNearby.Contains("Point") Then
                                    Element = Split(ElementNearby, "@")
                                    Dim myEntityEditor As New EntityEditor(ObjectRepresentation.Objects.Item(i).sketch.item(Element(0)), "Point")
                                    myEntityEditor.Location = e.Location
                                    myEntityEditor.ShowDialog()
                                End If
                            End If
                        Next

                End Select
        End Select

    End Sub

    Private Sub CAMToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreVi_Feature.AfterSelect

    End Sub

    Private Sub treeView1_NodeMouseClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs) Handles TreVi_Feature.NodeMouseClick
        ClickedTreeViewNode = e.Node
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            If ObjectRepresentation.fun_GetStateOfEntity(ClickedTreeViewNode.Name) <> 2 Then
                ToolStripMenuItem1.Checked = True
            Else
                ToolStripMenuItem1.Checked = False
            End If
            ContextMenuStrip1.Show(TreVi_Feature, e.Location)
        End If

        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            If ClickedTreeViewNode.Name.Contains("3D") = True Then
                ClickedTreeViewNode.SelectedImageIndex = 10
            End If
        End If

    End Sub 'treeView1_NodeMouseClick

    Private Sub SkizzeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SkizzeToolStripMenuItem.Click

        Status_SomethingIsInProcess = True

        For i As Integer = 1 To ObjectRepresentation.Objects.Count
            If ObjectRepresentation.Objects.Item(i).GetType = GetType(cSketch) Then
                If ObjectRepresentation.Objects.Item(i).NameOfEntity = ClickedTreeViewNode.Name Then
                    ObjectRepresentation.Objects.Item(i).StateOfEntity = 1
                End If
            End If
        Next i
        WhatIsActive = "Sketch"
        Panel_GraphicArea.Refresh()
    End Sub

    Private Sub SkizzeBeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SkizzeBeendenToolStripMenuItem.Click
        ObjectRepresentation.fun_EndSketch()
        Status_SomethingIsInProcess = False
        WhatIsActive = "none"
        Panel_GraphicArea.Refresh()
    End Sub

    Private Sub LöschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LöschenToolStripMenuItem.Click
        ObjectRepresentation.deleteElement(TreVi_Feature, ClickedTreeViewNode)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If ToolStripMenuItem1.Checked = True Then
            ToolStripMenuItem1.Checked = False
            ObjectRepresentation.fun_HideElement(ClickedTreeViewNode.Name, False)
        Else
            ToolStripMenuItem1.Checked = True
            ObjectRepresentation.fun_HideElement(ClickedTreeViewNode.Name, True)
        End If
        Panel_GraphicArea.Refresh()
    End Sub

    Public Sub sub_ConfigureContextMenuStrip1()

        If Status_CamPathIsInProcess = True Then

        Else

        End If

    End Sub

    Private Sub NCProgrammErstellenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NCProgrammErstellenToolStripMenuItem.Click
        Status_SomethingIsInProcess = True
        Dim i As Integer
        For i = 1 To ObjectRepresentation.Objects.Count
            Select Case ObjectRepresentation.Objects.Item(i).GetType
                Case GetType(cCamPath)
                    If ObjectRepresentation.Objects.Item(i).NameOfEntity = ClickedTreeViewNode.Name Then
                        NCProg.fun_GenerateNCProg(m_ObjectRepresentation.Objects.Item(i))
                    End If
                Case GetType(cCamPocket)
                    If ObjectRepresentation.Objects.Item(i).NameOfEntity = ClickedTreeViewNode.Name Then
                        NCProg.fun_GenerateNCProg(m_ObjectRepresentation.Objects.Item(i))
                    End If
                Case GetType(cCamBore)
                    If ObjectRepresentation.Objects.Item(i).NameOfEntity = ClickedTreeViewNode.Name Then
                        NCProg.fun_GenerateNCProg(m_ObjectRepresentation.Objects.Item(i))
                    End If
                Case GetType(cCamPicture)
                    If ObjectRepresentation.Objects.Item(i).NameOfEntity = ClickedTreeViewNode.Name Then
                        NCProg.fun_GenerateNCProg(m_ObjectRepresentation.Objects.Item(i))
                    End If
                Case GetType(cCamFaceMilling)
                    If ObjectRepresentation.Objects.Item(i).NameOfEntity = ClickedTreeViewNode.Name Then
                        NCProg.fun_GenerateNCProg(m_ObjectRepresentation.Objects.Item(i))
                    End If
                Case GetType(cCam3D)
                    If ObjectRepresentation.Objects.Item(i).NameOfEntity = ClickedTreeViewNode.Name Then
                        NCProg.fun_GenerateNCProg(m_ObjectRepresentation.Objects.Item(i))
                    End If
                Case GetType(cCam3D)
                    If ObjectRepresentation.Objects.Item(i).NameOfEntity = ClickedTreeViewNode.Name Then
                        NCProg.fun_GenerateNCProg(m_ObjectRepresentation.Objects.Item(i))
                    End If
            End Select
        Next i

    End Sub

    Private Sub TreeView2_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView2.NodeMouseClick
        ClickedTreeViewNode = e.Node
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            'If ObjectRepresentation.fun_GetStateOfEntity(ClickedTreeViewNode.Name) <> 2 Then
            '    ToolStripMenuItem1.Checked = True
            'Else
            '    ToolStripMenuItem1.Checked = False
            'End If
            ContextMenuStrip1.Show(TreeView2, e.Location)
        End If

    End Sub

    Private Sub ZeigeTaschenbahnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZeigeTaschenbahnToolStripMenuItem.Click
        Status_SomethingIsInProcess = True
        Dim i As Integer
        For i = 1 To ObjectRepresentation.Objects.Count
            Select Case ObjectRepresentation.Objects.Item(i).GetType
                Case GetType(cCamPath)
                    If ObjectRepresentation.Objects.Item(i).NameOfEntity = ClickedTreeViewNode.Name Then
                        NCProg.fun_GenerateNCProg(ObjectRepresentation.Objects.Item(i))
                    End If
                Case GetType(cCamPocket)
                    If ObjectRepresentation.Objects.Item(i).NameOfEntity = ClickedTreeViewNode.Name Then
                        ObjectRepresentation.Objects.Item(i).sub_ShowCamPath()
                    End If
            End Select
        Next i

    End Sub

    Private Sub fillInterfaceStateCollection(ByRef InterfaceObject As Object)

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose:  Is needed if path parameters that do not change the calculated path 
        '           are changed (like feed rates or step counts).
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        UserInterfaceState.addState(InterfaceObject, "Test")

    End Sub

    Private Sub Panel_GraphicArea_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GraphicPanel_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        'setLayout()
    End Sub

    Private Function setLayout() As Boolean
        If FeatureManager.Visible = True Then

            Panel_GraphicArea.Left = Me.ClientRectangle.Left
            Panel_GraphicArea.Top = Me.ClientRectangle.Top
            Panel_GraphicArea.Size = Me.ClientRectangle.Size
        Else
            Panel_GraphicArea.Left = Me.ClientRectangle.Left + FeatureManager.Width
            Panel_GraphicArea.Top = Me.ClientRectangle.Top
            Panel_GraphicArea.Width = Me.ClientRectangle.Width - FeatureManager.Width
            Panel_GraphicArea.Height = Me.Height
        End If
        'm_Cursor.
        Return True
    End Function

    Private Sub Panel_GraphicArea_Resize(sender As Object, e As EventArgs)


    End Sub

    Public Function drawChooserRectangle() As Boolean

        Return True
    End Function

    Public Function testDrawingElements(sender As Object, e As PaintEventArgs) As Boolean
        Dim myPointss() As PointF = New PointF() {New PointF(120, 100), New PointF(100, 120), New PointF(80, 100), New PointF(100, 80), New PointF(120, 100)}
        e.Graphics.DrawCurve(Pens.Coral, myPointss, 1, 3, 0.8)
        e.Graphics.DrawArc(Pens.Black, 85, 85, 40, 40, 0, 360)
        'declare local variables
        Dim myPen As Pen
        Dim myPoints(3) As Point

        'create a 4-item array of point structures
        myPoints(0) = New Point(120, 100)
        myPoints(1) = New Point(120, 80)
        myPoints(2) = New Point(80, 80)
        myPoints(3) = New Point(100, 80)

        'instantiate a new pen object using the color structure
        myPen = New Pen(System.Drawing.Color.Blue, 2)

        'draw bezier using the points defined in the array
        e.Graphics.DrawBezier(pen:=myPen, pt1:=myPoints(0), pt2:=myPoints(1),
           pt3:=myPoints(2), pt4:=myPoints(3))
        Return True
    End Function

    ''' <summary>
    ''' Actualizes the size of the element.
    ''' 
    ''' Manages the size of the "Panel_GraphicArea"
    ''' </summary>
    Sub actualizeElementSize()

        Try
            Panel_GraphicArea.Height = Me.ClientSize.Height
            Panel_GraphicArea.Width = Me.ClientSize.Width - FeatureManager.Width
            Panel_GraphicArea.Left = FeatureManager.Width
        Catch ex As Exception
            'Catch the exception during start up when the "Panel_GraphicArea" is not yet existing
        End Try

    End Sub

    Public Sub showCamScanProperty()

        Dim CamScanPropertyDialog As New CamScan(m_ObjectRepresentation, WhoHasFocus, ToolLibrary, WhatIsActive, Panel_GraphicArea, FeatureManager)
        FeatureManager.TabPages("TabPage_Properties").Controls.Add(CamScanPropertyDialog)
        FeatureManager.Width = CamScanPropertyDialog.Width + FeatureManager.Padding.X * 2 + SystemInformation.VerticalScrollBarWidth
        CamScanPropertyDialog.Visible = True

    End Sub

    Public Sub showCamScan2DProperty()

        Dim CamScan2DPropertyDialog As New CamScan2D(m_ObjectRepresentation, WhoHasFocus, ToolLibrary, WhatIsActive, Panel_GraphicArea, FeatureManager)
        FeatureManager.TabPages("TabPage_Properties").Controls.Add(CamScan2DPropertyDialog)
        FeatureManager.Width = CamScan2DPropertyDialog.Width + FeatureManager.Padding.X * 2 + SystemInformation.VerticalScrollBarWidth
        CamScan2DPropertyDialog.Visible = True

    End Sub

    <DllImport("D:\softwaredevelopement\3-Axis\software\PC programs\Odartec Utilities\Odartecutilities.dll", EntryPoint:="?Add@MyUtilities@UtilityFuncs@@SANNN@Z", CallingConvention:=CallingConvention.Cdecl)>
    Public Shared Function Add(a As Double, b As Double) As Double
    End Function

    <DllImport("D:\softwaredevelopement\3-Axis\software\PC programs\Odartec Utilities\Odartecutilities.dll", EntryPoint:="#2", CallingConvention:=CallingConvention.StdCall, SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function Subtract(a As Double, b As Double) As Double
    End Function

    <DllImport("D:\softwaredevelopement\3-Axis\software\PC programs\Odartec Utilities\Odartecutilities.dll", EntryPoint:="#3", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function Multiply(a As Double, b As Double) As Double
    End Function

    Private Sub PartViewer_ClientSizeChanged(sender As Object, e As EventArgs) Handles MyBase.ClientSizeChanged
        actualizeElementSize()
    End Sub

    Private Sub FeatureManager_SizeChanged(sender As Object, e As EventArgs) Handles FeatureManager.SizeChanged
        actualizeElementSize()
    End Sub
End Class
