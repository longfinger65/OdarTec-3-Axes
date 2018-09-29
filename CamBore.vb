Imports OdarTec3Axes.cObjectRepresentation


Public Class CamBore


    Public Sub New(ByRef mObjectRepresentation As cObjectRepresentation, ByRef WHFocus As cWhoHasTheFocus, ByRef ToolLibrary As cToolManagement, ByRef WhatIsActive As String, ByRef DrawingPanel As Panel)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Me.ObjectRepresentation = mObjectRepresentation
        Me.Focuss = WHFocus
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

    Private Sub CamBore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            If ObjectRepresentation.Objects.Item(i).GetType = GetType(cCamBore) Then

#If DEBUG Then
                System.Console.WriteLine("Bore")
#End If

                For j = 1 To ObjectRepresentation.Objects.Item(i).CamElements.Count
                    If LiBo_BoreElements.FindString(ObjectRepresentation.Objects.Item(i).CamElements.Item(j).NameOfEntity + "@" + ObjectRepresentation.Objects.Item(i).CamElements.Item(j).SketchName) = ListBox.NoMatches Then
                        LiBo_BoreElements.Items.Add(ObjectRepresentation.Objects.Item(i).CamElements.Item(j).NameOfEntity + "@" + ObjectRepresentation.Objects.Item(i).CamElements.Item(j).SketchName)

#If DEBUG Then
                        System.Console.WriteLine("Elementname: " + ObjectRepresentation.Objects.Item(i).CamElements.Item(j).NameOfEntity + ", ")
#End If

                    End If
                Next
            End If
        Next
    End Sub

    Private Sub ListBox2_MouseMove(sender As Object, e As MouseEventArgs) Handles LiBo_BoreElements.MouseMove

        ConfigureListView1Content()

    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TeBo_OriginChooser.Click

    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TeBo_OriginChooser.MouseClick

        setFocusedElementBackGround("TeBo_OriginChooser")
        Focuss.Focus = "BoreOriginChooser"

#If DEBUG Then
        System.Console.WriteLine(Focuss.Focus)
#End If

        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left

            Case Windows.Forms.MouseButtons.Right
        End Select

    End Sub

    Private Sub ListBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles LiBo_BoreElements.MouseClick

        setFocusedElementBackGround("LiBo_BoreElements")
        Focuss.Focus = "CamElementChooser"

    End Sub

    Private Sub Button_Ok_Click(sender As Object, e As EventArgs) Handles Button_Ok.Click

        Dim ToolBuffer() As String

        Focuss.Focus = "nothing"
        For i As Integer = 1 To ObjectRepresentation.Objects.Count
            If ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                ObjectRepresentation.Objects.Item(i).FeedRateWork = NuUpDo_FeedWork.Value
                ObjectRepresentation.Objects.Item(i).FeedRateRapid = NuUpDo_FeedRapid.Value
                ObjectRepresentation.Objects.Item(i).FeedRateRetractMove = NuUpDo_FeedRetractMove.Value
                ObjectRepresentation.Objects.Item(i).Origin_X = CDbl(TeBo_OriginX.Text)
                ObjectRepresentation.Objects.Item(i).Origin_Y = CDbl(TeBo_OriginY.Text)
                ObjectRepresentation.Objects.Item(i).Origin_Z = CDbl(TeBo_OriginZ.Text)
                ObjectRepresentation.Objects.Item(i).DepthOfCamEntity = NuUpDo_DephthOfBore.Value
                ObjectRepresentation.Objects.Item(i).CuttingSpeed = NuUpDo_CuttingSpeed.Value
                ObjectRepresentation.Objects.Item(i).ZInfeed = NuUpDo_ZInFeed.Value
                ToolBuffer = Split(CStr(CoBo_ToolChooser.Text), ",")
                ToolBuffer(1) = "Tool " + ToolBuffer(0)
                ObjectRepresentation.Objects.Item(i).Tool = ToolLibrary.ToolsList.Item(ToolBuffer(1))
                If ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = True Then
                    '----- Path recalculation because it was changed -----
                    ObjectRepresentation.Objects.Item(i).calculateBorePath()
                Else
                    ObjectRepresentation.Objects.Item(i).UpdateCamPath()
                End If
                LiBo_BoreElements.Items.Clear()
                LiBo_BoreElements.Refresh()
                LiBo_BoreElements.Text = ""
                ObjectRepresentation.Objects.Item(i).StateOfEntity = 2
            End If
        Next
        Me.Visible = False
        resetSettings()
        DrawingPanel.Refresh()
        WhatIsActive = "none"
    End Sub

    Private Sub Button_ShowCamPath_Click(sender As Object, e As EventArgs) Handles Button_ShowCamPath.Click

        Dim ToolBuffer() As String

        For i As Integer = 1 To ObjectRepresentation.Objects.Count
            If ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                ObjectRepresentation.Objects.Item(i).FeedRateWork = NuUpDo_FeedWork.Value
                ObjectRepresentation.Objects.Item(i).FeedRateRapid = NuUpDo_FeedRapid.Value
                ObjectRepresentation.Objects.Item(i).FeedRateRetractMove = NuUpDo_FeedRetractMove.Value
                ObjectRepresentation.Objects.Item(i).Origin_X = CDbl(TeBo_OriginX.Text)
                ObjectRepresentation.Objects.Item(i).Origin_Y = CDbl(TeBo_OriginY.Text)
                ObjectRepresentation.Objects.Item(i).Origin_Z = CDbl(TeBo_OriginZ.Text)
                ObjectRepresentation.Objects.Item(i).DepthOfCamEntity = NuUpDo_DephthOfBore.Value
                ObjectRepresentation.Objects.Item(i).CuttingSpeed = NuUpDo_CuttingSpeed.Value
                ObjectRepresentation.Objects.Item(i).ZInfeed = NuUpDo_ZInFeed.Value
                ToolBuffer = Split(CStr(CoBo_ToolChooser.Text), ",")
                ToolBuffer(1) = "Tool " + ToolBuffer(0)
                ObjectRepresentation.Objects.Item(i).Tool = ToolLibrary.ToolsList.Item(ToolBuffer(1))
                If ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = True Then
                    '----- Path recalculation because it was changed -----
                    ObjectRepresentation.Objects.Item(i).calculateBorePath()
                    ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = False
                Else
                    ObjectRepresentation.Objects.Item(i).UpdateCamPath()
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
        Focuss.Focus = "BoreOriginChooser"
    End Sub

    Private Sub TextBox_StartPointChooser_MouseClick(sender As Object, e As MouseEventArgs)
        Focuss.Focus = "BoreStartPointChooser"

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

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NuUpDo_FeedWork.ValueChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles La_D1.Click

    End Sub

    Private Sub La_LCorr_Click(sender As Object, e As EventArgs) Handles La_LCorr.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Visible = False
        resetSettings()

        For i As Integer = 1 To ObjectRepresentation.Objects.Count
            If ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                ObjectRepresentation.Objects.Remove(i)
            End If
        Next

        WhatIsActive = "none"
    End Sub

    Private Sub CoBo_ToolChooser_SelectedValueChanged(sender As Object, e As EventArgs) Handles CoBo_ToolChooser.SelectedValueChanged

    End Sub

    Private Sub ListBox2_VisibleChanged(sender As Object, e As EventArgs) Handles LiBo_BoreElements.VisibleChanged

    End Sub

    Private Sub CamBore_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Dim i, k As Integer

        For i = 1 To ObjectRepresentation.Objects.Count
            If ObjectRepresentation.Objects.Item(i).GetType() = GetType(cCamBore) Then
                If ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 And ObjectRepresentation.Objects.Item(i).Tool.ToolName = "nothing" Then
                    ObjectRepresentation.Objects.Item(i).Tool = ToolLibrary.ToolsList.Item(1)
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

    Private Function resetSettings() As Boolean
        LiBo_BoreElements.Items.Clear()
        LiBo_BoreElements.Text = ""
        Return True
    End Function

    Private Sub LiBo_BoreElements_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LiBo_BoreElements.SelectedIndexChanged

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

    Private Sub NuUpDo_DephthOfBore_Click(sender As Object, e As EventArgs) Handles NuUpDo_DephthOfBore.Click

        setFocusedElementBackGround("NuUpDo_DephthOfBore")
        Focuss.Focus = "DephthOfBoreChooser"

    End Sub

    Public Function refreshDisplay() As Boolean

        ConfigureListView1Content()
        LiBo_BoreElements.Refresh()

        Return True
    End Function

End Class
