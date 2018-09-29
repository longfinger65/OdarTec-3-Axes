Imports OdarTec3Axes.cObjectRepresentation

Public Class CamPicture

    Public Sub New(ByRef ObjectRepresentation As cObjectRepresentation, ByRef WHFocus As cWhoHasTheFocus, ByRef ToolLibrary As cToolManagement, ByRef WhatIsActive As String, ByRef DrawingPanel As Panel, ByRef FeatureManager As TabControl)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        m_DrawingPanel = New Panel()

        '----- Initialization -----

        Me.ObjectRepresentation = ObjectRepresentation
        Focuss = WHFocus
        Me.ToolLibrary = ToolLibrary
        Me.WhatIsActive = WhatIsActive
        Me.DrawingPanel = DrawingPanel
        Me.FeatureManager = FeatureManager

    End Sub

    '----- Member Variables and constants -----------------------------

    Private m_ObjectRepresentation As cObjectRepresentation
    Private m_Focus As New cWhoHasTheFocus
    Private m_Overlap As Integer ' Overlapping of two adjacent path elements
    Private m_ToolLibrary As cToolManagement
    Private m_WhatIsActive As String
    Private m_DrawingPanel As Panel
    Private m_FeatureManager As TabControl

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

    Public Property FeatureManager() As TabControl
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_FeatureManager
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As TabControl)
            m_FeatureManager = Value
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

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub ListView1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TeBo_OriginChooser.Click

    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TeBo_OriginChooser.MouseClick

        setFocusedElementBackGround("TeBo_OriginChooser")
        Focuss.Focus = "PictureOriginChooser"
        System.Console.WriteLine(Focuss.Focus)
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left

            Case Windows.Forms.MouseButtons.Right
        End Select

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
        Me.Visible = False
        Me.resetSettings()
        FeatureManager.Width = 120
        WhatIsActive = "none"
        DrawingPanel.Refresh()
    End Sub

    Private Sub Button_ShowCamPath_Click(sender As Object, e As EventArgs) Handles Bu_ShowPreviewPicture.Click

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

        actualizePocketPropertiesWithInputValues("Preview")
        Button_Ok.BackColor = Color.LightGreen
    End Sub

    Private Function fun_GenerateCamPath() As String

        Return 1
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TeBo_OriginChooser.TextChanged
        setFocusedElementBackGround("TeBo_OriginChooser")
        Focuss.Focus = "PictureOriginChooser"
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NuUpDo_WorkFeed.ValueChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Visible = False
        FeatureManager.Width = 120
        WhatIsActive = "none"
    End Sub

    Private Sub CamPicture_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
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

        LiBo_GraySteps.SetSelected(3, True)
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

    Public Function refreshDisplay() As Boolean


        Return True
    End Function

    Private Sub Bu_LoadPicture_Click(sender As Object, e As EventArgs) Handles Bu_LoadPicture.Click

        Dim mTypeString As String = ""
        Dim myWidth As Integer
        Dim myHeight As Integer
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Bilddateien (*.bmp)|*.bmp|Alle Dateien (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            'PI.BMPPicture = New Bitmap(OpenFileDialog.FileName)
            'Dim FileName As String = OpenFileDialog.FileName
            For i As Integer = 1 To ObjectRepresentation.Objects.Count
                If ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                    ObjectRepresentation.Objects.Item(i).PictureToMachine = New Bitmap(OpenFileDialog.FileName)
                    myWidth = ObjectRepresentation.Objects.Item(i).PictureToMachine.Width
                    myHeight = ObjectRepresentation.Objects.Item(i).PictureToMachine.Height
                    'ObjectRepresentation.Objects.Item(i).PreviewPicture = New Bitmap(myWidth, myHeight)
                    PicBo_PictureToMachine.BackgroundImage = ObjectRepresentation.Objects.Item(i).PictureToMachine
                    PicBo_PreviewPicture.BackgroundImage = ObjectRepresentation.Objects.Item(i).PreviewPicture
                    TeBo_PictureWidth.Text = CStr(ObjectRepresentation.Objects.Item(i).PictureToMachine.Width)
                    TeBo_PictureHeight.Text = CStr(ObjectRepresentation.Objects.Item(i).PictureToMachine.Height)
                    'TeBo_PictureColorDepth = ObjectRepresentation.Objects.Item(i).PictureToMachine.
                    ObjectRepresentation.Objects.Item(i).NeedsPathRecalculation = True
                End If
            Next

        End If

    End Sub

    Private Sub Bu_BackgroundColorChooser_Click(sender As Object, e As EventArgs) Handles Bu_PreviewBackgroundColorChooser.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            Bu_PreviewBackgroundColorChooser.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Bu_PreviewEngraveColorChooser_Click(sender As Object, e As EventArgs) Handles Bu_PreviewEngraveColorChooser.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            Bu_PreviewEngraveColorChooser.BackColor = ColorDialog1.Color
        End If

    End Sub

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
        Dim ToolType As String
        Dim myWidth As Integer
        Dim myHeight As Integer

        For m As Integer = 1 To ObjectRepresentation.Objects.Count
            If ObjectRepresentation.Objects.Item(m).StateOfEntity = 1 Then
                ObjectRepresentation.Objects.Item(m).FeedRateWork = NuUpDo_WorkFeed.Value
                ObjectRepresentation.Objects.Item(m).FeedRateRapid = NuUpDo_RapidFeed.Value
                ObjectRepresentation.Objects.Item(m).FeedRateGround = NuUpDo_FeedRateGround.Value
                ObjectRepresentation.Objects.Item(m).Origin.X = CDbl(TeBo_OriginX.Text)
                ObjectRepresentation.Objects.Item(m).Origin.Y = CDbl(TeBo_OriginY.Text)
                ObjectRepresentation.Objects.Item(m).Origin.Z = CDbl(TeBo_OriginZ.Text)
                ObjectRepresentation.Objects.Item(m).CuttingSpeed = NuUpDo_CuttingSpeed.Value
                ObjectRepresentation.Objects.Item(m).PixelSize = NuUpDo_Pixelsize.Value
                ObjectRepresentation.Objects.Item(m).RestingTime = NuUpDo_Contrast.Value
                ObjectRepresentation.Objects.Item(m).SQRTOfGrayValues = Math.Sqrt(CInt(LiBo_GraySteps.Text))
                ObjectRepresentation.Objects.Item(m).Brightness = CDbl(NuUpDo_Brightness.Value)
                ObjectRepresentation.Objects.Item(m).PreviewBackgroundColor = Bu_PreviewBackgroundColorChooser.BackColor
                ObjectRepresentation.Objects.Item(m).PreviewEngraveColor = Bu_PreviewEngraveColorChooser.BackColor
                ObjectRepresentation.Objects.Item(m).DepthOfEngraving = NuUpDo_DepthOfEngraving.Value
                ObjectRepresentation.Objects.Item(m).ToolWorkRetractHeight = NuUpDo_ToolWorkRetractHeight.Value
                ObjectRepresentation.Objects.Item(m).ToolStartStopRetractHeight = NuUpDo_ToolStartStopRetractHeight.Value
                ObjectRepresentation.Objects.Item(m).ToolTipAngle = NuUpDo_ToolTipAngle.Value
                ObjectRepresentation.Objects.Item(m).EngravingThreshold = NuUpDo_EngravingThreshold.Value
                If CheBo_Positive.Checked = True Then
                    ObjectRepresentation.Objects.Item(m).PositivePictureRepresentation = True
                Else
                    ObjectRepresentation.Objects.Item(m).PositivePictureRepresentation = False
                End If
                ToolBuffer = Split(CStr(CoBo_ToolChooser.Text), ",")
                ToolType = ToolBuffer(1)
                Console.WriteLine(ToolBuffer(0))
                Console.WriteLine(ToolBuffer(1))
                'Console.WriteLine(ToolBuffer(2))
                ToolBuffer(1) = "Tool " + ToolBuffer(0)
                ObjectRepresentation.Objects.Item(m).Tool = ToolLibrary.ToolsList.Item(ToolBuffer(1))
                Console.WriteLine(ObjectRepresentation.Objects.Item(m).Tool.ToolTyp)
                removeDoubleElements()
                If ToolType.Contains("Laser") Then
                    myWidth = ObjectRepresentation.Objects.Item(m).PictureToMachine.Width * Math.Sqrt(CInt(LiBo_GraySteps.Text))
                    myHeight = ObjectRepresentation.Objects.Item(m).PictureToMachine.Height * Math.Sqrt(CInt(LiBo_GraySteps.Text))
                Else
                    myWidth = ObjectRepresentation.Objects.Item(m).PictureToMachine.Width * NuUpDo_Pixelsize.Value * 10
                    myHeight = ObjectRepresentation.Objects.Item(m).PictureToMachine.Height * NuUpDo_Pixelsize.Value * 10
                End If
                If KindOfActualization = "Preview" Then
                    ObjectRepresentation.Objects.Item(m).PreviewPicture = New Bitmap(myWidth, myHeight)
                    PicBo_PreviewPicture.BackgroundImage = ObjectRepresentation.Objects.Item(m).PreviewPicture
                    If ToolType.Contains("Laser") Then
                        ObjectRepresentation.Objects.Item(m).calculateCamPath("LaserPreview")
                    Else
                        ObjectRepresentation.Objects.Item(m).calculateCamPath("OtherPreview")
                    End If
                Else
                    If ToolType.Contains("Laser") Then
                        ObjectRepresentation.Objects.Item(m).calculateCamPath("Laser")
                    Else
                        ObjectRepresentation.Objects.Item(m).calculateCamPath("Other")
                    End If
                End If
                'ObjectRepresentation.Objects.Item(m).makePreviewPicture()
                PicBo_PreviewPicture.Refresh()
            End If
                If KindOfActualization = "Release" Then
                    ObjectRepresentation.Objects.Item(m).StateOfEntity = 2
                End If
        Next

        Return True
    End Function

End Class
