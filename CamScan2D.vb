Imports OdarTec3Axes.cObjectRepresentation
Imports System.ComponentModel
Imports System.Threading

Public Class CamScan2D

    Public Sub New(ByRef ObjectRepresentation As cObjectRepresentation, ByRef WHFocus As cWhoHasTheFocus, ByRef ToolLibrary As cToolManagement, ByRef WhatIsActive As String, ByRef DrawingPanel As Panel, ByRef FeatureManager As TabControl)
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        m_DrawingPanel = New Panel()
        m_ScanCam = New cOTCam(LiBo_ScanCam, PiBo_ScanView)
        BGWor_Preview.WorkerReportsProgress = True
        BGWor_Preview.WorkerSupportsCancellation = True
        'AddHandler BGWor_Preview.DoWork, AddressOf takePicture

        '----- Initialization -----

        PiBo_Reticle.Parent = PiBo_ScanView
        Me.ObjectRepresentation = ObjectRepresentation
        Focuss = WHFocus
        Me.WhatIsActive = WhatIsActive
        Me.DrawingPanel = DrawingPanel
        Me.FeatureManager = FeatureManager
        m_Test = True
        LaserIsOn = False
        ReticleColor = Color.FromArgb(100, 100, 100)
        TraBa_ReticleBrightness.Value = 100
        RaBu_CameraPicture.Select()
        MMProPixel = 0.22
        State = "NewlyOpend"

    End Sub

    '----- Member Variables and constants -----------------------------

    Private m_ObjectRepresentation As cObjectRepresentation
    Private m_Focus As New cWhoHasTheFocus
    Private m_WhatIsActive As String
    Private m_DrawingPanel As Panel
    Private m_FeatureManager As TabControl
    Private m_ScanCam As cOTCam
    Private m_Test As Boolean
    Private m_ObjectItem As Object
    Private m_ScanWidth As Integer
    Private m_ScanHeight As Integer
    Private m_LaserAngleTangens As Double
    Private m_MMProPixel As Double
    Private m_MMProPixelAtPassHeight As Double
    Private m_YLengthAtPassHeight As Double
    Private m_CamFocusHeight As Double          'To correct the perspective
    Private m_T1 As Thread
    Private Triangles As New cPointArray()      'The array containing all the triangles that was scanned
    Private m_LaserIsOn As Boolean                  'Indicates wether the laser is on or off
    Private m_FeedRateBackup As Integer
    Private m_State As String
    Private m_HoughPicture As Bitmap
    Private m_EdgePicture As Bitmap
    Private m_GaugePicture As Bitmap
    Private m_ReticleColor As Color

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

    Public Property ObjectItem() As Object
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ObjectItem
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Object)
            m_ObjectItem = Value
        End Set
    End Property

    Public Property ScanWidth() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ScanWidth
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_ScanWidth = Value
        End Set
    End Property

    Public Property ScanHeight() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ScanHeight
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_ScanHeight = Value
        End Set
    End Property

    Public Property LaserAngleTangens() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_LaserAngleTangens
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_LaserAngleTangens = Value
        End Set
    End Property

    Public Property MMProPixel() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_MMProPixel
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_MMProPixel = Value
        End Set
    End Property

    Public Property MMProPixelAtPassHeight() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_MMProPixelAtPassHeight
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_MMProPixelAtPassHeight = Value
        End Set
    End Property

    Public Property YLengthAtPassHeight() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_YLengthAtPassHeight
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_YLengthAtPassHeight = Value
        End Set
    End Property

    Public Property ScanCam() As cOTCam
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ScanCam
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cOTCam)
            m_ScanCam = Value
        End Set
    End Property

    Public Property T1() As Thread
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_T1
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Thread)
            m_T1 = Value
        End Set
    End Property

    Public Property LaserIsOn() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_LaserIsOn
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_LaserIsOn = Value
        End Set
    End Property

    Public Property CamFocusHeight() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CamFocusHeight
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_CamFocusHeight = Value
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

    Public Property HoughPicture() As Bitmap
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_HoughPicture
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Bitmap)
            m_HoughPicture = Value
        End Set
    End Property

    Public Property EdgePicture() As Bitmap
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_EdgePicture
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Bitmap)
            m_EdgePicture = Value
        End Set
    End Property

    Public Property GaugePicture() As Bitmap
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_GaugePicture
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Bitmap)
            m_GaugePicture = Value
        End Set
    End Property

    Public Property ReticleColor() As Color
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ReticleColor
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Color)
            m_ReticleColor = Value
        End Set
    End Property

    '---Begin delegates ---

    ' Delegate Sub takePictureDel()
    'Delegate Sub refreshPictureDel()

    '----- End member variables, begin member methodes ----------------------

    Private Sub on_Load(sender As Object, e As EventArgs) Handles Me.Load

        Bu_Calibration.BackColor = Color.LightCoral
    End Sub

    Private Sub Origin_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub ListView1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs)

        setFocusedElementBackGround("TeBo_OriginChooser")
        Focuss.Focus = "PictureOriginChooser"
        System.Console.WriteLine(Focuss.Focus)
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left

            Case Windows.Forms.MouseButtons.Right
        End Select

    End Sub

    Private Sub Button_Ok_Click(sender As Object, e As EventArgs) Handles Bu_Ok.Click

        For i As Integer = 1 To ObjectRepresentation.Objects.Count
            If ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then      'Look for the newly created "cImported".
                ObjectRepresentation.Objects.Item(i).addElement(Triangles)      'Put the new surface in the newly created "cImported".
                ObjectRepresentation.Objects.Item(i).StateOfEntity = 2             'Set the new imported inactive and invisible.
            End If
        Next

        Focuss.Focus = "nothing"
        Me.Visible = False
        Me.resetSettings()
        FeatureManager.Width = 120
        WhatIsActive = "none"
        DrawingPanel.Refresh()
    End Sub

    Private Sub Button_TestYScanArea_Click(sender As Object, e As EventArgs) Handles Bu_ScanPreview.Click

        '--- If there are some scanned elements in the sketch, delete these. ---

        ObjectRepresentation.Objects.Item(ObjectRepresentation.Objects.Count).Sketch.Clear()

        '---

        Dim ScannedPicture As Bitmap
        Dim Utilities As New cOdarTecUtilities()
        Dim ZeroLineLocations(10) As Integer
        Dim ScanPoint As New cSimplePoint()                          'The scanned point that is actual calculated
        Dim Result As New Collection()

        '--- Initial settings ---

        setElementState("IsEdgePreviewing")
        If LaserIsOn = True Then
            OdarTec3Axes.MachinePanel.switchSpindelOff()                        'Performs the buttons click event to switch on the laser
            LaserIsOn = False
        End If

        '--- Find the parameters of the scan picture ---

        If BGWor_Preview.WorkerSupportsCancellation = True Then
            BGWor_Preview.CancelAsync()
        End If

        m_ScanCam.stopPreview()
        m_ScanCam.startPreview()
        m_ScanCam.SaveIt()                                                                             'Takes the "PurePicture"
        ScannedPicture = PiBo_ScanView.BackgroundImage

        Utilities.makePictureBinary(ScannedPicture, NuUpDo_BrightnessTreshold.Value)
        PiBo_ScanView.BackgroundImage = ScannedPicture
        PiBo_ScanView.Invalidate()
        'Threading.Thread.Sleep(5000)
        Utilities.filterMatrixByFolding(ScannedPicture, EdgePicture, "Sobel")
        For x As Integer = 0 To EdgePicture.Width - 1
            EdgePicture.SetPixel(x, 0, Color.Black)
            EdgePicture.SetPixel(x, 1, Color.Black)
            EdgePicture.SetPixel(x, EdgePicture.Height - 2, Color.Black)
            EdgePicture.SetPixel(x, EdgePicture.Height - 1, Color.Black)
        Next
        For y As Integer = 0 To EdgePicture.Height - 1
            EdgePicture.SetPixel(0, y, Color.Black)
            EdgePicture.SetPixel(1, y, Color.Black)
            EdgePicture.SetPixel(EdgePicture.Width - 2, y, Color.Black)
            EdgePicture.SetPixel(EdgePicture.Width - 1, y, Color.Black)
        Next
        PiBo_Reticle.Image = EdgePicture
        PiBo_Reticle.Invalidate()
        PiBo_ScanView.Invalidate()


        setElementState("EdgePreviewed")

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Bu_Cancel.Click

        ObjectRepresentation.deleteActiveElement()
        Me.Visible = False
        FeatureManager.Width = 120
        WhatIsActive = "none"

    End Sub


    Private Sub CamScan_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged

        If Me.Visible = True Then
            previewPicture()
        End If

    End Sub

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

    '-----------------------------------------------------------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Handles the Click event of the Bu_Scan control.
    ''' Starts the scanning process.
    ''' Steps:
    '''  - taking the "PurePicture",
    '''  - switching on the laser,
    '''  - taking the "LaserPicture",
    '''  - switching off the laser,
    '''  - making the next step in the y direction, 
    '''  - calculating the z values and putting these values into a field,
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    ''' 
    Private Sub Bu_Scan_Click(sender As Object, e As EventArgs) Handles Bu_Scan.Click

        '--- If there are some scanned elements in the sketch, delete these. ---

        ObjectRepresentation.Objects.Item(ObjectRepresentation.Objects.Count).Sketch.Clear()

        '---

        Dim ScannedPicture As Bitmap
        Dim Utilities As New cOdarTecUtilities()
        Dim ZeroLineLocations(10) As Integer
        Dim ScanPoint As New cSimplePoint()                          'The scanned point that is actual calculated
        Dim Result As New Collection()

        '--- Initial settings ---

        setElementState("IsScanning")
        If LaserIsOn = True Then
            OdarTec3Axes.MachinePanel.switchSpindelOff()                        'Performs the buttons click event to switch on the laser
            LaserIsOn = False
        End If

        '--- Find the parameters of the scan picture ---

        If BGWor_Preview.WorkerSupportsCancellation = True Then
            BGWor_Preview.CancelAsync()
        End If

        m_ScanCam.stopPreview()
        m_ScanCam.startPreview()
        m_ScanCam.SaveIt()                                                                             'Takes the "PurePicture"
        ScannedPicture = PiBo_ScanView.BackgroundImage

        Utilities.makePictureBinary(ScannedPicture, NuUpDo_BrightnessTreshold.Value)
        PiBo_ScanView.BackgroundImage = ScannedPicture
        PiBo_ScanView.Invalidate()
        'Threading.Thread.Sleep(5000)
        Utilities.filterMatrixByFolding(ScannedPicture, EdgePicture, "Sobel")
        For x As Integer = 0 To EdgePicture.Width - 1
            EdgePicture.SetPixel(x, 0, Color.Black)
            EdgePicture.SetPixel(x, 1, Color.Black)
            EdgePicture.SetPixel(x, EdgePicture.Height - 2, Color.Black)
            EdgePicture.SetPixel(x, EdgePicture.Height - 1, Color.Black)
        Next
        For y As Integer = 0 To EdgePicture.Height - 1
            EdgePicture.SetPixel(0, y, Color.Black)
            EdgePicture.SetPixel(1, y, Color.Black)
            EdgePicture.SetPixel(EdgePicture.Width - 2, y, Color.Black)
            EdgePicture.SetPixel(EdgePicture.Width - 1, y, Color.Black)
        Next
        Utilities.transformMatrixHough(EdgePicture, 0.1, 1, Result, HoughPicture, "Line")
        PiBo_Reticle.Image = HoughPicture
        PiBo_Reticle.Invalidate()
        PiBo_ScanView.Invalidate()

        For i As Integer = 0 To Result.Count / 2 - 1
            If Result.Item(i * 2 + 1).Annotation <> "Circle" Then
                ObjectRepresentation.Objects.Item(ObjectRepresentation.Objects.Count).Sketch.Add(New cLine(CDbl(Result.Item(i * 2 + 1).X * MMProPixel), CDbl(Result.Item(i * 2 + 1).Y * MMProPixel), CDbl(Result.Item(i * 2 + 2).X * MMProPixel), CDbl(Result.Item(i * 2 + 2).Y * MMProPixel)))
            End If
        Next
        setElementState("Scanned")

    End Sub

    Private Sub Bu_LaserOnOff_Click(sender As Object, e As EventArgs) Handles Bu_LaserOnOff.Click

        If LaserIsOn = False Then
            OdarTec3Axes.MachinePanel.switchSpindelOn()                         'Performs the buttons click event to switch on the laser
            LaserIsOn = True
        Else
            OdarTec3Axes.MachinePanel.switchSpindelOff()                       'Performs the buttons click event to switch on the laser
            LaserIsOn = False
        End If

    End Sub

    ''' <summary>
    ''' Handles the Click event of the Bu_Calibration control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Function Bu_Calibration_Click(sender As Object, e As EventArgs) As String Handles Bu_Calibration.Click

        Dim PurePicture As Bitmap
        Dim LaserPicture As Bitmap
        Dim Counter As Integer
        Dim FoundLaser As Boolean
        Dim YStart As Integer
        Dim m_Utilities As New cOdarTecUtilities()
        Dim Toggler As String
        Dim MinX As Integer
        Dim MaxX As Integer
        Dim MinY As Integer
        Dim MaxY As Integer
        Dim GapWatchCounter As Integer
        Dim ActualMachineZ As Double
        Dim Direction As String

        '--- Initial settings ---

        OdarTec3Axes.ToolStriProBa_Main.Value = 0
        setElementState("IsCalibrating")
        Toggler = " "
        MinX = 100000
        MaxX = -1
        MinY = 100000
        MaxY = -1
        GapWatchCounter = 0

        If LaserIsOn = True Then
            OdarTec3Axes.MachinePanel.switchSpindelOff()                      'Performs the buttons click event to switch on the laser
            LaserIsOn = False
        End If

        '--- Take the pictures at first height (other than the scan height) for calculating the "MMProPixel" ---

        ActualMachineZ = OdarTec3Axes.A.Z                                                                                               'Store the machines Z-Value bevore stepping up- or downward

        If ActualMachineZ < (165 - NuUpDo_PassHeight.Value) Then
            OdarTec3Axes.MachinePanel.makeAStepRemoteControlled("+Z", NuUpDo_PassHeight.Value, 300)    'Make a step in the -y direction
            Direction = "-Z"
        Else
            Return "Error: The +Z end switch would be reached during calibration."
        End If

        OdarTec3Axes.ToolStriProBa_Main.Value = 25
        BGWor_Preview.CancelAsync()
        m_ScanCam.stopPreview()                                                                             'Stops the preview
        m_ScanCam.startPreview()
        m_ScanCam.SaveIt()                                                                             'Takes the "PurePicture"
        PurePicture = PiBo_ScanView.BackgroundImage
        OdarTec3Axes.MachinePanel.switchSpindelOn()                       'Performs the buttons click event to switch on the laser
        m_ScanCam.startPreview()
        m_ScanCam.SaveIt()                                                                           'Takes the "LaserPicture"
        OdarTec3Axes.MachinePanel.switchSpindelOff()                         'Performs the buttons click event to switch off the laser
        LaserPicture = PiBo_ScanView.BackgroundImage

        '--- Find the laser line ---

        If GaugePicture Is Nothing Then
            GaugePicture = New Bitmap(PurePicture.Width, PurePicture.Height)
        End If
        For x As Integer = 0 To PurePicture.Width - 1
            For y As Integer = 0 To PurePicture.Height - 1
                GaugePicture.SetPixel(x, y, Color.Black)
            Next
        Next

        OdarTec3Axes.ToolStriProBa_Main.Value = 35

        For x As Integer = 0 To LaserPicture.Width - 1

            Counter = -1
            FoundLaser = False

            For y As Integer = 0 To LaserPicture.Height - 1
                If (m_Utilities.getRGBColor(LaserPicture.GetPixel(x, y))(0) > (m_Utilities.getRGBColor(PurePicture.GetPixel(x, y))(0) + 40)) Then
                    If FoundLaser = False Then
                        YStart = y
                        FoundLaser = True
                    End If
                    Counter += 1
                Else
                    If FoundLaser = True Then
                        Exit For
                    End If
                End If
            Next
            If FoundLaser = True And Counter > 2 Then
                GaugePicture.SetPixel(x, CInt(YStart + (Counter / 2)), Color.Red)
            End If
        Next

        OdarTec3Axes.ToolStriProBa_Main.Value = 45

        'Threading.Thread.Sleep(5000)

        '--- Find "PassLength2"  ---

        For x As Integer = 80 To LaserPicture.Width - 81
            For y As Integer = 80 To LaserPicture.Height - 81

                If (m_Utilities.getRGBColor(LaserPicture.GetPixel(x, y))(0)) = 255 Then
                    If y > MaxY And Toggler = " " Then
                        MaxY = y
                    End If
                    If y < MinY And Toggler = " " Then
                        MinY = y
                    End If
                    If (MinY < 100000) And (MaxY > (-1)) And ((MaxY - MinY) > 15) And Toggler = " " Then
                        MinX = x
                        Toggler = "FoundMinX"
                    End If
                    If (((y - MinY) ^ 2) < 100) And (Toggler = "FoundMinX") Then
                        MaxX = x
                        GapWatchCounter = 0
                    End If
                End If
            Next
            If Toggler = "FoundMinX" Then
                GapWatchCounter += 1
                If GapWatchCounter > 10 Then
                    Exit For
                End If
            End If
        Next

        OdarTec3Axes.ToolStriProBa_Main.Value = 50

        If MinY > 25 And MinY < GaugePicture.Height - 26 And MinX > 0 And MinX < GaugePicture.Width And MaxX > -1 And MaxX < (GaugePicture.Width - 1) Then 'Check if the lines would be inside the "GaugePicture"
            For i As Integer = 0 To 50
                GaugePicture.SetPixel(MinX - 1, MinY + 25 - i, Color.LightSeaGreen)
                GaugePicture.SetPixel(MaxX + 1, MinY + 25 - i, Color.LightSeaGreen)
                GaugePicture.SetPixel(MinX, MinY + 25, Color.LightSeaGreen)
                GaugePicture.SetPixel(MaxX, MinY + 25, Color.LightSeaGreen)
            Next
            For i As Integer = MinX - 20 To MaxX + 20
                GaugePicture.SetPixel(i, MinY + 5, Color.White)
                GaugePicture.SetPixel(i, MinY - 5, Color.White)
            Next
            For i As Integer = 0 To MinX + 20
                GaugePicture.SetPixel(i, MaxY + 5, Color.White)
                GaugePicture.SetPixel(i, MaxY - 5, Color.White)
            Next
            For i As Integer = MaxX - 20 To GaugePicture.Width - 1
                GaugePicture.SetPixel(i, MaxY + 5, Color.White)
                GaugePicture.SetPixel(i, MaxY - 5, Color.White)
            Next
        End If

        PiBo_Reticle.Image = GaugePicture

        PiBo_Reticle.Invalidate()
        PiBo_ScanView.Invalidate()

        OdarTec3Axes.MachinePanel.makeAStepRemoteControlled(Direction, NuUpDo_PassHeight.Value, 300)    'Make a step in the -y direction

        OdarTec3Axes.ToolStriProBa_Main.Value = 98

        Try
            MMProPixel = NuUpDo_PassWidth.Value / (MaxX - MinX)
            TeBo_MMProPixel.Text = CStr(MMProPixel)
        Catch

        End Try

        OdarTec3Axes.ToolStriProBa_Main.Value = 100

        TeBo_CamFocusHeight.Text = CStr(CamFocusHeight)

        setElementState("Calibrated")

        Return "Ok."
    End Function

    Public Sub previewPicture()
        setElementState("IsPreviewing")
        Try 'If there is an image destroy it
            'PiBo_Reticle.Image = Nothing
            'PiBo_ScanView.BackgroundImage = Nothing
        Catch
        End Try
        m_ScanCam.stopPreview()
        m_ScanCam.startPreview()
        BGWor_Preview.RunWorkerAsync()

    End Sub

    Private Sub BGWor_Preview_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BGWor_Preview.DoWork
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim g As Graphics = PiBo_Reticle.CreateGraphics()
        Dim ReticleDrawPen As New Pen(ReticleColor)

        Do While (BGWor_Preview.CancellationPending = False)

            ' Perform a time consuming operation and report progress.

            '--- Draw the reticle ---

            g.DrawLine(ReticleDrawPen, 0, CInt(PiBo_Reticle.Height / 2 - 25), PiBo_Reticle.Width, CInt(PiBo_Reticle.Height / 2 - 25))
            g.DrawLine(ReticleDrawPen, CInt(PiBo_Reticle.Width / 2 - 11), 0, CInt(PiBo_Reticle.Width / 2 - 11), PiBo_Reticle.Height)

            '--- Draw the scan area borders ---

            g.DrawLine(Pens.BlueViolet, 0, CInt((PiBo_Reticle.Height / 2 - 25) - (ScanHeight / 2)), PiBo_Reticle.Width, CInt((PiBo_Reticle.Height / 2 - 25) - (ScanHeight / 2)))
            g.DrawLine(Pens.BlueViolet, 0, CInt((PiBo_Reticle.Height / 2 - 25) + (ScanHeight / 2)), PiBo_Reticle.Width, CInt((PiBo_Reticle.Height / 2 - 25) + (ScanHeight / 2)))
            g.DrawLine(Pens.BlueViolet, CInt((PiBo_Reticle.Width / 2 - 11) - (ScanWidth / 2)), 0, CInt((PiBo_Reticle.Width / 2 - 11) - (ScanWidth / 2)), PiBo_Reticle.Height)
            g.DrawLine(Pens.BlueViolet, CInt((PiBo_Reticle.Width / 2 - 11) + (ScanWidth / 2)), 0, CInt((PiBo_Reticle.Width / 2 - 11) + (ScanWidth / 2)), PiBo_Reticle.Height)

        Loop
    End Sub

    Private Sub Bu_Preview_Click(sender As Object, e As EventArgs)
        previewPicture()
    End Sub

    Private Sub NuUpDo_ScanWidth_ValueChanged(sender As Object, e As EventArgs) Handles NuUpDo_ScanWidth.ValueChanged
        ScanWidth = NuUpDo_ScanWidth.Value
    End Sub

    Private Sub NuUpDo_ScanDepth_ValueChanged(sender As Object, e As EventArgs) Handles NuUpDo_ScanDepth.ValueChanged
        ScanHeight = NuUpDo_ScanDepth.Value
    End Sub

    Private Sub BGWor_Preview_RunWorkerCompleted(ByVal sender As System.Object,
ByVal e As RunWorkerCompletedEventArgs) Handles BGWor_Preview.RunWorkerCompleted
        If e.Cancelled = True Then
            Console.WriteLine("Canceled!")
        ElseIf e.Error IsNot Nothing Then
            Console.WriteLine("Error: " & e.Error.Message)
        Else
            Console.WriteLine("Done!")
        End If
    End Sub

    Private Sub setElementState(ByVal State As String)

        Select Case State
            Case "NewlyOpend"
                Bu_Calibration.BackColor = Color.LightCoral
                Bu_Calibration.Enabled = True
                Bu_Scan.BackColor = Color.GhostWhite
                Bu_Scan.ForeColor = Color.LightGray
                Bu_Scan.Enabled = False
                Bu_Ok.BackColor = Color.GhostWhite
                Bu_Ok.ForeColor = Color.LightGray
                Bu_Ok.Enabled = False
                Bu_LaserOnOff.BackColor = Color.GhostWhite
                Bu_LaserOnOff.Enabled = True
            Case "IsCalibrating"
                Bu_Calibration.BackColor = Color.OrangeRed
                Bu_Calibration.Enabled = True
                Bu_Scan.BackColor = Color.GhostWhite
                Bu_Scan.ForeColor = Color.LightGray
                Bu_Scan.Enabled = False
                Bu_Ok.BackColor = Color.GhostWhite
                Bu_Ok.ForeColor = Color.LightGray
                Bu_Ok.Enabled = False
                Bu_LaserOnOff.BackColor = Color.GhostWhite
                Bu_LaserOnOff.ForeColor = Color.LightGray
                Bu_LaserOnOff.Enabled = False
                OdarTec3Axes.ToolStriProBa_Main.Visible = True
            Case "Calibrated"
                Bu_Calibration.BackColor = Color.LightGreen
                Bu_Calibration.Enabled = True
                Bu_Scan.BackColor = Color.GhostWhite
                Bu_Scan.ForeColor = Color.MidnightBlue
                Bu_Scan.Enabled = True
                Bu_Ok.BackColor = Color.GhostWhite
                Bu_Ok.ForeColor = Color.MidnightBlue
                Bu_Ok.Enabled = False
                Bu_LaserOnOff.BackColor = Color.GhostWhite
                Bu_LaserOnOff.Enabled = True
                OdarTec3Axes.ToolStriProBa_Main.Visible = False
                RaBu_GaugePicture.Select()
            Case "IsScanning"
                Bu_Calibration.BackColor = Color.GhostWhite
                Bu_Calibration.Enabled = False
                Bu_Scan.BackColor = Color.OrangeRed
                Bu_Scan.Enabled = True
                Bu_Ok.BackColor = Color.GhostWhite
                Bu_Ok.Enabled = False
                Bu_LaserOnOff.BackColor = Color.GhostWhite
                Bu_LaserOnOff.Enabled = False
                OdarTec3Axes.ToolStriProBa_Main.Visible = True
            Case "Scanned"
                Bu_Calibration.BackColor = Color.LightCoral
                Bu_Calibration.Enabled = True
                Bu_Scan.BackColor = Color.GhostWhite
                Bu_Scan.Enabled = True
                Bu_Ok.BackColor = Color.LightGreen
                Bu_Ok.Enabled = True
                Bu_LaserOnOff.BackColor = Color.GhostWhite
                Bu_LaserOnOff.Enabled = True
                OdarTec3Axes.ToolStriProBa_Main.Visible = False
                RaBu_ShowHoughPicture.Select()
            Case "IsPreviewing"
            Case "IsEdgePreviewing"
            Case "EdgePreviewed"
                RaBu_EdgePicture.Select()
        End Select
    End Sub

    Private Sub RaBu_CameraPicture_CheckedChanged(sender As Object, e As EventArgs) Handles RaBu_CameraPicture.CheckedChanged

        BGWor_Preview.CancelAsync()
        m_ScanCam.stopPreview()                                                                             'Stops the preview

        If RaBu_CameraPicture.Checked = True Then
            previewPicture()
        End If
    End Sub

    Private Sub RaBu_ShowHoughPicture_CheckedChanged(sender As Object, e As EventArgs) Handles RaBu_ShowHoughPicture.CheckedChanged

        BGWor_Preview.CancelAsync()
        m_ScanCam.stopPreview()                                                                             'Stops the preview

        Try
            PiBo_Reticle.Image = HoughPicture
            PiBo_Reticle.Invalidate()
            PiBo_ScanView.Invalidate()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RaBu_EdgePicture_CheckedChanged(sender As Object, e As EventArgs) Handles RaBu_EdgePicture.CheckedChanged

        BGWor_Preview.CancelAsync()
        m_ScanCam.stopPreview()                                                                             'Stops the preview

        Try
            PiBo_Reticle.Image = EdgePicture
            PiBo_Reticle.Invalidate()
            PiBo_ScanView.Invalidate()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RaBu_GaugePicture_CheckedChanged(sender As Object, e As EventArgs) Handles RaBu_GaugePicture.CheckedChanged

        BGWor_Preview.CancelAsync()
        m_ScanCam.stopPreview()                                                                             'Stops the preview

        Try
            PiBo_Reticle.Image = GaugePicture
            PiBo_Reticle.Invalidate()
            PiBo_ScanView.Invalidate()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TraBa_ReticleBrightness_Scroll(sender As Object, e As EventArgs) Handles TraBa_ReticleBrightness.Scroll
        ReticleColor = Color.FromArgb(TraBa_ReticleBrightness.Value, TraBa_ReticleBrightness.Value, TraBa_ReticleBrightness.Value)
        PiBo_Reticle.Invalidate()
    End Sub
End Class
