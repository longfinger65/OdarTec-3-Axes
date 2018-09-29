Imports OdarTec3Axes.cObjectRepresentation

Public Class CamPath

    Public Sub New(ByRef ObjectRepresentation As cObjectRepresentation, ByRef WHFocus As cWhoHasTheFocus, ByRef ToolLibrary As cToolManagement, ByRef WhatIsActive As String, ByRef DrawingPanel As Panel)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        m_DrawingPanel = New Panel()

        '----- Initialization -----

        Me.ObjectRepresentation = ObjectRepresentation
        Focuss = WHFocus
        Overlap = 70
        Me.ToolLibrary = ToolLibrary
        Me.WhatIsActive = WhatIsActive
        Me.DrawingPanel = DrawingPanel

    End Sub

    '----- Member Variables and constants -----------------------------

    Private m_ObjectRepresentation As cObjectRepresentation
    Private m_Focus As New cWhoHasTheFocus
    Private m_Overlap As Integer ' Overlapping of two adjacent path elements
    Private m_ToolLibrary As cToolManagement
    Private m_WhatIsActive As String
    Private m_DrawingPanel As Panel

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

#If DEBUG Then
            System.Console.WriteLine("Test1")
#End If

            If ObjectRepresentation.Objects.Item(i).GetType = GetType(cCamPath) Then

#If DEBUG Then
                System.Console.WriteLine("Path")
#End If

                For j = 1 To ObjectRepresentation.Objects.Item(i).CamElements.Count
                    If LiBo_PathElements.FindString(ObjectRepresentation.Objects.Item(i).CamElements.Item(j).NameOfEntity + "@" + ObjectRepresentation.Objects.Item(i).CamElements.Item(j).SketchName) = ListBox.NoMatches Then
                        LiBo_PathElements.Items.Add(ObjectRepresentation.Objects.Item(i).CamElements.Item(j).NameOfEntity + "@" + ObjectRepresentation.Objects.Item(i).CamElements.Item(j).SketchName)

#If DEBUG Then
                        System.Console.WriteLine("Elementname: " + ObjectRepresentation.Objects.Item(i).CamElements.Item(j).NameOfEntity + ", ")
#End If

                    End If
                Next
            End If
        Next
    End Sub

    Private Sub ListBox2_MouseMove(sender As Object, e As MouseEventArgs) Handles LiBo_PathElements.MouseMove

        ConfigureListView1Content()

    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TeBo_OriginChooser.Click

    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TeBo_OriginChooser.MouseClick

        setFocusedElementBackGround("TeBo_OriginChooser")
        Focuss.Focus = "PathOriginChooser"

#If DEBUG Then
        System.Console.WriteLine(Focuss.Focus)
#End If

        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left

            Case Windows.Forms.MouseButtons.Right
        End Select

    End Sub

    Private Sub ListBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles LiBo_PathElements.MouseClick

        setFocusedElementBackGround("LiBo_PathElements")
        Focuss.Focus = "CamElementChooser"

    End Sub

    Private Sub Button_Ok_Click(sender As Object, e As EventArgs) Handles Button_Ok.Click

        Dim ToolBuffer() As String

        Focuss.Focus = "nothing"
        For m As Integer = 1 To ObjectRepresentation.Objects.Count
            If ObjectRepresentation.Objects.Item(m).StateOfEntity = 1 Then
                ObjectRepresentation.Objects.Item(m).m_FeedRateWork = NuUpDo_WorkFeed.Value
                ObjectRepresentation.Objects.Item(m).m_FeedRateRapid = NuUpDo_RapidFeed.Value
                ObjectRepresentation.Objects.Item(m).FeedRateInfeed = NuUpDo_InFeed.Value
                ObjectRepresentation.Objects.Item(m).StartPoint.X = CDbl(TeBo_PocketStartPointX.Text)
                ObjectRepresentation.Objects.Item(m).StartPoint.Y = CDbl(TeBo_PocketStartPointY.Text)
                ObjectRepresentation.Objects.Item(m).StartPoint.Z = CDbl(TeBo_PocketStartPointZ.Text)
                ObjectRepresentation.Objects.Item(m).Origin.X = CDbl(TextBox_OriginX.Text)
                ObjectRepresentation.Objects.Item(m).Origin.Y = CDbl(TextBox_OriginY.Text)
                ObjectRepresentation.Objects.Item(m).Origin.Z = CDbl(TextBox_OriginZ.Text)
                ObjectRepresentation.Objects.Item(m).DepthOfCamEntity = NuUpDo_DephthOfPocket.Value
                ObjectRepresentation.Objects.Item(m).SideSteps = NuUpDo_BorderSteps.Value
                ObjectRepresentation.Objects.Item(m).GroundSteps = NuUpDo_GroundSteps.Value
                ObjectRepresentation.Objects.Item(m).CuttingSpeed = NuUpDo_CuttingSpeed.Value
                ObjectRepresentation.Objects.Item(m).InfeedSide = NuUpDo_SideInFeed.Value
                ObjectRepresentation.Objects.Item(m).InfeedZ = NuUpDo_ZInFeed.Value
                ObjectRepresentation.Objects.Item(m).InfeedGround = NuUpDo_GroundInFeed.Value
                ObjectRepresentation.Objects.Item(m).ToolOverlap = NuUpDo_ToolOverlap.Value
                ObjectRepresentation.Objects.Item(m).ToolRadiusCorrection = NuUpDo_DCorr.Value
                ObjectRepresentation.Objects.Item(m).Approach = CheBo_Approach.Checked
                ObjectRepresentation.Objects.Item(m).PatternAmountX = NuUpDo_PatternAmountX.Value
                ObjectRepresentation.Objects.Item(m).PatternDistanceX = NuUpDo_PatternDistanceX.Value
                ObjectRepresentation.Objects.Item(m).PatternAmountY = NuUpDo_PatternAmountY.Value
                ObjectRepresentation.Objects.Item(m).PatternDistanceY = NuUpDo_PatternDistanceY.Value
                ToolBuffer = Split(CStr(CoBo_ToolChooser.Text), ",")
                ToolBuffer(1) = "Tool " + ToolBuffer(0)
                ObjectRepresentation.Objects.Item(m).Tool = ToolLibrary.ToolsList.Item(ToolBuffer(1))
                If RaBu_RR.Checked = True Then
                    ObjectRepresentation.Objects.Item(m).RadiusCorrection = "RR"
                End If
                If RaBu_RL.Checked = True Then
                    ObjectRepresentation.Objects.Item(m).RadiusCorrection = "RL"
                End If
                If RaBu_R0.Checked = True Then
                    ObjectRepresentation.Objects.Item(m).RadiusCorrection = "R0"
                End If
                removeDoubleElements()
                If ObjectRepresentation.Objects.Item(m).NeedsPathRecalculation = True Then
                    '----- Path recalculation because it was changed -----
                    ObjectRepresentation.Objects.Item(m).calculateMillingPath()
                Else
                    ObjectRepresentation.Objects.Item(m).UpdateCamPath()
                End If
            End If
            ObjectRepresentation.Objects.Item(m).StateOfEntity = 2
        Next
        Me.Visible = False
        Me.resetSettings()
        WhatIsActive = "none"
        DrawingPanel.Refresh()
    End Sub

    Private Sub Button_ShowCamPath_Click(sender As Object, e As EventArgs) Handles Button_ShowCamPath.Click

        Dim ToolBuffer() As String

        For m As Integer = 1 To ObjectRepresentation.Objects.Count
            If ObjectRepresentation.Objects.Item(m).StateOfEntity = 1 Then
                ObjectRepresentation.Objects.Item(m).FeedRateWork = NuUpDo_WorkFeed.Value
                ObjectRepresentation.Objects.Item(m).FeedRateRapid = NuUpDo_RapidFeed.Value
                ObjectRepresentation.Objects.Item(m).FeedRateInfeed = NuUpDo_InFeed.Value
                ObjectRepresentation.Objects.Item(m).StartPoint.X = CDbl(TeBo_PocketStartPointX.Text)
                ObjectRepresentation.Objects.Item(m).StartPoint.Y = CDbl(TeBo_PocketStartPointY.Text)
                ObjectRepresentation.Objects.Item(m).StartPoint.Z = CDbl(TeBo_PocketStartPointZ.Text)
                ObjectRepresentation.Objects.Item(m).Origin.X = CDbl(TextBox_OriginX.Text)
                ObjectRepresentation.Objects.Item(m).Origin.Y = CDbl(TextBox_OriginY.Text)
                ObjectRepresentation.Objects.Item(m).Origin.Z = CDbl(TextBox_OriginZ.Text)
                ObjectRepresentation.Objects.Item(m).DepthOfCamEntity = NuUpDo_DephthOfPocket.Value
                ObjectRepresentation.Objects.Item(m).SideSteps = NuUpDo_BorderSteps.Value
                ObjectRepresentation.Objects.Item(m).GroundSteps = NuUpDo_GroundSteps.Value
                ObjectRepresentation.Objects.Item(m).CuttingSpeed = NuUpDo_CuttingSpeed.Value
                ObjectRepresentation.Objects.Item(m).InfeedSide = NuUpDo_SideInFeed.Value
                ObjectRepresentation.Objects.Item(m).InfeedZ = NuUpDo_ZInFeed.Value
                ObjectRepresentation.Objects.Item(m).InfeedGround = NuUpDo_GroundInFeed.Value
                ObjectRepresentation.Objects.Item(m).ToolOverlap = NuUpDo_ToolOverlap.Value
                ObjectRepresentation.Objects.Item(m).ToolRadiusCorrection = NuUpDo_DCorr.Value
                ObjectRepresentation.Objects.Item(m).Approach = CheBo_Approach.Checked
                ObjectRepresentation.Objects.Item(m).PatternAmountX = NuUpDo_PatternAmountX.Value
                ObjectRepresentation.Objects.Item(m).PatternDistanceX = NuUpDo_PatternDistanceX.Value
                ObjectRepresentation.Objects.Item(m).PatternAmountY = NuUpDo_PatternAmountY.Value
                ObjectRepresentation.Objects.Item(m).PatternDistanceY = NuUpDo_PatternDistanceY.Value
                ToolBuffer = Split(CStr(CoBo_ToolChooser.Text), ",")
                ToolBuffer(1) = "Tool " + ToolBuffer(0)
                ObjectRepresentation.Objects.Item(m).Tool = ToolLibrary.ToolsList.Item(ToolBuffer(1))

#If DEBUG Then
                Console.WriteLine(ObjectRepresentation.Objects.Item(m).Tool.ToolTyp)
#End If

                If RaBu_RR.Checked = True Then
                    ObjectRepresentation.Objects.Item(m).RadiusCorrection = "RR"
                End If
                If RaBu_RL.Checked = True Then
                    ObjectRepresentation.Objects.Item(m).RadiusCorrection = "RL"
                End If
                If RaBu_R0.Checked = True Then
                    ObjectRepresentation.Objects.Item(m).RadiusCorrection = "R0"
                End If
                removeDoubleElements()
                If ObjectRepresentation.Objects.Item(m).NeedsPathRecalculation = True Then
                    '----- Path recalculation because it was changed -----

                    ObjectRepresentation.Objects.Item(m).calculateMillingPath()
                    ObjectRepresentation.Objects.Item(m).NeedsPathRecalculation = False
                Else
                    ObjectRepresentation.Objects.Item(m).UpdateCamPath()
                End If
            End If
        Next
        Focuss.Focus = "ShowCamPath"
        DrawingPanel.Refresh()
    End Sub

    Private Function fun_GenerateCamPath() As String

        Return 1
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TeBo_OriginChooser.TextChanged
        setFocusedElementBackGround("TeBo_OriginChooser")
        Focuss.Focus = "PathOriginChooser"
    End Sub

    Private Sub TextBox_StartPointChooser_MouseClick(sender As Object, e As MouseEventArgs) Handles TeBo_StaPoiChooser.MouseClick
        setFocusedElementBackGround("TeBo_StaPoiChooser")
        Focuss.Focus = "PathStartPointChooser"

#If DEBUG Then
        System.Console.WriteLine(Focuss.Focus)
#End If

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

#If DEBUG Then
                    Console.WriteLine(CStr(ObjectRepresentation.Objects.Item(i).Tool.ToolDiameter))
#End If

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

    Private Function removeDoubleElements() As Boolean

        Return True
    End Function

    Private Function resetSettings() As Boolean
        LiBo_PathElements.Items.Clear()
        LiBo_PathElements.Text = ""
        Return True
    End Function


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

    Private Sub LiBo_PathElements_Click(sender As Object, e As EventArgs) Handles LiBo_PathElements.Click

        setFocusedElementBackGround("LiBo_PathElements")
        Focuss.Focus = "DephthOfPocketChooser"

    End Sub

    Public Function refreshDisplay() As Boolean

        ConfigureListView1Content()
        LiBo_PathElements.Refresh()

        Return True
    End Function

End Class
