Imports OdarTec3Axes.cObjectRepresentation

Public Class CamPocket

    Public Sub New(ByRef ObjectRepresentation As cObjectRepresentation, ByRef WHFocus As cWhoHasTheFocus, ByRef ToolLibrary As cToolManagement, ByRef WhatIsActive As String, ByRef DrawingPanel As Panel)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        '----- Initialization -----

        Me.ObjectRepresentation = ObjectRepresentation
        Focuss = WHFocus
        Overlap = 70
        Me.ToolLibrary = ToolLibrary
        Me.WhatIsActive = WhatIsActive
        Me.drawingPanel = DrawingPanel

    End Sub

    '----- Member Variables and constants -----------------------------

    Private m_ObjectRepresentation As cObjectRepresentation
    Private m_Focus As New cWhoHasTheFocus
    Private m_Overlap As Integer ' Overlapping of two adjacent path elements
    Private m_ToolLibrary As cToolManagement
    Private m_WhatIsActive As String
    Private m_DrawingPanel As Panel
    Private m_State As String

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

    Public Property Focuss() As cWhoHasTheFocus
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Focus
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cWhoHasTheFocus)
            m_Focus = Value
        End Set
    End Property

    Public Property Overlap() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Overlap
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_Overlap = Value
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

    Public Property DrawingPanel() As Panel
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_DrawingPanel
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Panel)
            m_DrawingPanel = Value
        End Set
    End Property

    Public Property State() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_State
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_State = Value
        End Set
    End Property

    '----- End member variables, begin member methodes ----------------------

    Private Sub on_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim i As Integer

        CoBo_ToolChooser.Items.Clear()
        If ToolLibrary.ToolsList.Count > 0 Then
            For i = 1 To ToolLibrary.ToolsList.Count
                CoBo_ToolChooser.Items.Add(CStr(ToolLibrary.ToolsList.Item(i).ToolNumber) + ", " + ToolLibrary.ToolsList.Item(i).ToolName)
            Next
            CoBo_ToolChooser.Text = CStr(ToolLibrary.ToolsList.Item(1).ToolNumber) + ", " + ToolLibrary.ToolsList.Item(1).ToolName
            TeBo_D1.Text = CDbl(ToolLibrary.ToolsList.Item(1).ToolDiameter)
        End If

    End Sub

    Private Sub CircularPocket_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Origin_Click(sender As Object, e As EventArgs) Handles Origin.Click

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub ListView1_MouseMove(sender As Object, e As MouseEventArgs)

        ConfigureListView1Content()

    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub ListView1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Public Sub ConfigureListView1Content()
        Dim i, j As Integer
        'System.Console.WriteLine("Test")
        For i = 1 To ObjectRepresentation.Objects.Count
            System.Console.WriteLine("Test1")
            If ObjectRepresentation.Objects.Item(i).GetType = GetType(cCamPocket) Then
                System.Console.WriteLine("Pocket")
                For j = 1 To ObjectRepresentation.Objects.Item(i).CamElements.Count
                    If LiBo_PocketElements.FindString(ObjectRepresentation.Objects.Item(i).CamElements.Item(j).NameOfEntity + "@" + ObjectRepresentation.Objects.Item(i).CamElements.Item(j).SketchName) = ListBox.NoMatches Then
                        LiBo_PocketElements.Items.Add(ObjectRepresentation.Objects.Item(i).CamElements.Item(j).NameOfEntity + "@" + ObjectRepresentation.Objects.Item(i).CamElements.Item(j).SketchName)
                        System.Console.WriteLine("Elementname: " + ObjectRepresentation.Objects.Item(i).CamElements.Item(j).NameOfEntity + ", ")
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub ListBox2_MouseMove(sender As Object, e As MouseEventArgs) Handles LiBo_PocketElements.MouseMove

        ConfigureListView1Content()

    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TeBo_OriginChooser.Click

    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TeBo_OriginChooser.MouseClick

        setFocusedElementBackGround("TeBo_OriginChooser")
        Focuss.Focus = "PocketOriginChooser"
        System.Console.WriteLine(Focuss.Focus)

        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left

            Case Windows.Forms.MouseButtons.Right
        End Select

    End Sub

    Private Sub ListBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles LiBo_PocketElements.MouseClick

        setFocusedElementBackGround("LiBo_PocketElements")
        Focuss.Focus = "CamElementChooser"

    End Sub

    Private Sub Button_Ok_Click(sender As Object, e As EventArgs) Handles Button_Ok.Click

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose:  Shows a preview of the cam path according to the input values.
        ' Input Parameter:
        '       sender      - The button that was clicked
        '       e           - The kind of the event (in this case a click event)
        ' Return Value:
        '       CamPreview      - s.a.
        '       CamPath         - s.a.
        '
        '----- Steps -------------------------------------------------------------------
        '
        ' 1.    Calls the function "actualizePocketPropertiesWithInputValues()"
        ' 2.    Sets the focus
        ' 3.    Refreshes the drawing area
        '
        '----- End description ---------------------------------------------------------

        actualizePocketPropertiesWithInputValues("Release")
        Focuss.Focus = "nothing"
        LiBo_PocketElements.Items.Clear()
        Me.Visible = False
        WhatIsActive = "none"
        DrawingPanel.Refresh()
    End Sub

    Private Sub Button_ShowCamPath_Click(sender As Object, e As EventArgs) Handles Button_ShowCamPath.Click

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose:  Shows a preview of the cam path according to the input values.
        ' Input Parameter:
        '       sender      - The button that was clicked
        '       e           - The kind of the event (in this case a click event)
        ' Return Value:
        '       CamPreview      - s.a.
        '       CamPath         - s.a.
        '
        '----- Steps -------------------------------------------------------------------
        '
        ' 1.    Calls the function "actualizePocketPropertiesWithInputValues()"
        ' 2.    Sets the focus
        ' 3.    Refreshes the drawing area
        '
        '----- End description ---------------------------------------------------------

        setElementState("IsPreviewing")

        actualizePocketPropertiesWithInputValues("PreView")
        Focuss.Focus = "ShowCamPath"
        DrawingPanel.Refresh()

        setElementState("Previewed")

    End Sub

    Private Function fun_GenerateCamPath() As String

        Return 1
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TeBo_OriginChooser.TextChanged

    End Sub

    Private Sub TextBox_StartPointChooser_MouseClick(sender As Object, e As MouseEventArgs) Handles TeBo_StaPoiChooser.MouseClick

        setFocusedElementBackGround("TeBo_StaPoiChooser")
        Focuss.Focus = "PocketStartPointChooser"
        System.Console.WriteLine(Focuss.Focus)
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left

            Case Windows.Forms.MouseButtons.Right
        End Select

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NuUpDo_WorkFeed.ValueChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Visible = False
        WhatIsActive = "none"
    End Sub

    Private Sub CamPocket_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Dim i, k As Integer

        For i = 1 To ObjectRepresentation.Objects.Count
            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cCamPocket) Then
                If ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 And ObjectRepresentation.Objects.Item(i).Tool.ToolName = "nothing" Then
                    ObjectRepresentation.Objects.Item(i).Tool = ToolLibrary.ToolsList.Item(1)
                    Console.WriteLine(CStr(ObjectRepresentation.Objects.Item(i).Tool.ToolDiameter))
                Else
                    For k = 0 To CoBo_ToolChooser.Items.Count - 1
                        If CoBo_ToolChooser.Items.Item(k) = (CStr(ObjectRepresentation.Objects.Item(i).Tool.ToolNumber) + ", " + ObjectRepresentation.Objects.Item(i).Tool.ToolName) Then
                            CoBo_ToolChooser.SelectedIndex = k
                        End If
                    Next
                End If
            End If
        Next

    End Sub

    Private Sub CoBo_ToolChooser_TextChanged(sender As Object, e As EventArgs) Handles CoBo_ToolChooser.TextChanged

        Dim Buffer() As String

        Try
            Buffer = Split(CoBo_ToolChooser.Text, ",")
            TeBo_D1.Text = CStr(ToolLibrary.ToolsList.Item(CInt(Buffer(0))).ToolDiameter)
        Catch ex As System.NullReferenceException

        End Try

    End Sub

    Public Function setFocusedElementBackGround(ElementName As String) As Boolean

        For k As Integer = 0 To Me.Controls.Count - 1
            For i As Integer = 0 To Me.Controls.Item(k).Controls.Count - 1
                If Me.Controls.Item(k).Controls.Item(i).Name = ElementName Then
                    Me.Controls.Item(k).Controls.Item(i).BackColor = Color.LightYellow
                ElseIf Me.Controls.Item(k).Controls.Item(i).BackColor = Color.LightYellow Then
                    Me.Controls.Item(k).Controls.Item(i).BackColor = Color.WhiteSmoke
                End If
            Next
        Next
        Return True
    End Function

    Private Sub NuUpDo_DephthOfPocket_Click(sender As Object, e As EventArgs) Handles NuUpDo_DephthOfPocket.Click

        setFocusedElementBackGround("NuUpDo_DephthOfPocket")
        Focuss.Focus = "DephthOfPocketChooser"

    End Sub

    Public Function refreshDisplay() As Boolean

        ConfigureListView1Content()
        LiBo_PocketElements.Refresh()

        Return True
    End Function

    Public Function actualizePocketPropertiesWithInputValues(KindOfActualization As String) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose:  Actualizes the pocket properties with the input values of the pocket
        '           property manager.
        ' Input Parameter:
        '       CamPreview      - the collection that contains the preview entities
        '       CamPath         - the collection that contains the campath entities
        '       ToolDiameter    - the tool diameter incl. a correction value
        '       ToolOverlap     - the overlap in percent of the tool diameter from
        '                         circular path to circular path
        '       PocketRadius    - the radius of the pocket to be milled
        '       Preview         - is true if the preview should be calculated
        ' Return Value:
        '       CamPreview      - s.a.
        '       CamPath         - s.a.
        '
        '----- Steps -------------------------------------------------------------------
        '
        ' 1.    Calculate the amount of circular pathes (RadiusSteps)
        ' 2.    Calculate the step wide according to tool diameter and tool overlap
        ' 3.    Calculate the milling pathes or the preview entities according to the
        '       value of the "Preview"  
        '
        '----- End description ---------------------------------------------------------


        Dim ToolBuffer() As String

        For i As Integer = 1 To ObjectRepresentation.Objects.Count
            If ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                ObjectRepresentation.Objects.Item(i).FeedRateWork = NuUpDo_WorkFeed.Value
                ObjectRepresentation.Objects.Item(i).FeedRateRapid = NuUpDo_RapidFeed.Value
                ObjectRepresentation.Objects.Item(i).FeedRateInfeed = NuUpDo_InFeed.Value
                ObjectRepresentation.Objects.Item(i).StartPoint_X = CDbl(TextBox_PocketStartPointX.Text)
                ObjectRepresentation.Objects.Item(i).StartPoint_Y = CDbl(TextBox_PocketStartPointY.Text)
                ObjectRepresentation.Objects.Item(i).StartPoint_Z = CDbl(TextBox_PocketStartPointZ.Text)
                ObjectRepresentation.Objects.Item(i).Origin_X = CDbl(TextBox_OriginX.Text)
                ObjectRepresentation.Objects.Item(i).Origin_Y = CDbl(TextBox_OriginY.Text)
                ObjectRepresentation.Objects.Item(i).Origin_Z = CDbl(TextBox_OriginZ.Text)
                ObjectRepresentation.Objects.Item(i).DepthOfCamEntity = NuUpDo_DephthOfPocket.Value
                ObjectRepresentation.Objects.Item(i).SideSteps = NuUpDo_BorderSteps.Value
                ObjectRepresentation.Objects.Item(i).GroundSteps = NuUpDo_GroundSteps.Value
                ObjectRepresentation.Objects.Item(i).CuttingSpeed = NuUpDo_CuttingSpeed.Value
                ObjectRepresentation.Objects.Item(i).InfeedSide = NuUpDo_SideInFeed.Value
                ObjectRepresentation.Objects.Item(i).InfeedZ = NuUpDo_ZInFeed.Value
                ObjectRepresentation.Objects.Item(i).InfeedGround = NuUpDo_GroundInFeed.Value
                ObjectRepresentation.Objects.Item(i).ToolOverlap = NuUpDo_ToolOverlap.Value
                ObjectRepresentation.Objects.Item(i).ToolRadiusCorrection = NuUpDo_DCorr.Value / 2
                ObjectRepresentation.Objects.Item(i).ToolWorkRetractHeight = NuUpDo_ToolWorkRetractHeight.Value
                ObjectRepresentation.Objects.Item(i).ToolStartStopRetractHeight = NuUpDo_ToolStartStopRetractHeight.Value
                ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = True
                ToolBuffer = Split(CStr(CoBo_ToolChooser.Text), ",")
                ToolBuffer(1) = "Tool " + ToolBuffer(0)
                ObjectRepresentation.Objects.Item(i).Tool = ToolLibrary.ToolsList.Item(ToolBuffer(1))
                If RaBu_RR.Checked = True Then
                    ObjectRepresentation.Objects.Item(i).RadiusCorrection = "RR"
                End If
                If RaBu_RL.Checked = True Then
                    ObjectRepresentation.Objects.Item(i).RadiusCorrection = "RL"
                End If
                If RaBu_R0.Checked = True Then
                    ObjectRepresentation.Objects.Item(i).RadiusCorrection = "R0"
                End If
                If KindOfActualization = "Release" Then
                    ObjectRepresentation.Objects.Item(i).StateOfEntity = 2
                    ObjectRepresentation.Objects.Item(i).PreviewSignal = False
                Else
                    ObjectRepresentation.Objects.Item(i).PreviewSignal = True
                End If
                If ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = True Then
                    '----- Path recalculation because it was changed -----
                    ObjectRepresentation.Objects.Item(i).calculateMillingPath()
                    ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = False
                Else
                    ObjectRepresentation.Objects.Item(i).UpdateCamPath()
                End If
            End If
        Next
        Return True
    End Function

    Private Sub setElementState(ByVal State As String)

        Select Case State
            Case "NewlyOpend"
            Case "IsPreviewing"
                OdarTec3Axes.ToolStriProBa_Main.Visible = True
            Case "Previewed"
                OdarTec3Axes.ToolStriProBa_Main.Visible = False
        End Select
    End Sub

End Class
