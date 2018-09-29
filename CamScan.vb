Imports OdarTec3Axes.cObjectRepresentation
Imports System.ComponentModel
Imports System.Threading

Public Class CamScan

    Public Sub New(ByRef ObjectRepresentation As cObjectRepresentation, ByRef WHFocus As cWhoHasTheFocus, ByRef ToolLibrary As cToolManagement, ByRef WhatIsActive As String, ByRef DrawingPanel As Panel, ByRef FeatureManager As TabControl)
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        disposed = False

        m_DrawingPanel = New Panel()
        m_ScanCam = New cOTCam(LiBo_ScanCam, PiBo_ScanView)
        BGWor_Preview.WorkerReportsProgress = True
        BGWor_Preview.WorkerSupportsCancellation = True
        'AddHandler BGWor_Preview.DoWork, AddressOf takePicture

        '----- Initialization -----

        Me.ObjectRepresentation = ObjectRepresentation
        Focuss = WHFocus
        Me.WhatIsActive = WhatIsActive
        Me.DrawingPanel = DrawingPanel
        Me.FeatureManager = FeatureManager
        m_Test = True
        LaserIsOn = False
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
    Protected m_disposed As Boolean

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

    Public Property disposed() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_disposed
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_disposed = Value
        End Set
    End Property

    '---Begin delegates ---

    ' Delegate Sub takePictureDel()
    'Delegate Sub refreshPictureDel()

    '----- End member variables, begin member methodes ----------------------

    Private Sub on_Load(sender As Object, e As EventArgs) Handles Me.Load

        PiBo_Reticle.Parent = PiBo_ScanView

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

        ObjectRepresentation.addElement(New cImported())

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
        Me.Dispose(True)
    End Sub

    Private Sub Button_TestYScanArea_Click(sender As Object, e As EventArgs) Handles Bu_TestYScanArea.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Bu_Cancel.Click

        Me.Visible = False
        FeatureManager.Width = 120
        WhatIsActive = "none"
        Me.Dispose(True)

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

        Dim LaserPicture As Bitmap
        Dim PurePicture As Bitmap
        Dim Counter As Integer
        Dim ZeroLineLocationsCounter As Integer
        Dim YStart As Integer
        Dim FoundLaser As Boolean
        Dim Utilities As New cOdarTecUtilities()
        Dim ZeroLineLocation As Double
        Dim ZeroLineLocations(10) As Integer
        Dim ScannedPoints() As List(Of cSimplePoint)
        Dim ScanPoint As New cSimplePoint()                          'The scanned point that is actual calculated
        Dim ActualMachineY As Double
        Dim ActualMMProPixel As Double

        '--- Initial settings ---

        setElementState("IsScanning")
        ZeroLineLocationsCounter = 0
        m_FeedRateBackup = OdarTec3Axes.MachinePanel.TraBa_FeedRate.Value     'Backup the feedrate from machine for incremental steps
        If LaserIsOn = True Then
            OdarTec3Axes.MachinePanel.switchSpindelOff()                        'Performs the buttons click event to switch on the laser
            LaserIsOn = False
        End If

        OdarTec3Axes.MachinePanel.makeAStepRemoteControlled("-Y", NuUpDo_ScanDepth.Value / 2, 25)  'Move y axis to the scan start position

        '--- Find the parameters of the scan picture ---

        If BGWor_Preview.WorkerSupportsCancellation = True Then
            BGWor_Preview.CancelAsync()
        End If

        m_ScanCam.stopPreview()
        m_ScanCam.startPreview()
        m_ScanCam.SaveIt()                                                                             'Takes the "PurePicture"
        PurePicture = PiBo_ScanView.BackgroundImage
        OdarTec3Axes.MachinePanel.Bu_SpindleOn.PerformClick()                          'Performs the buttons click event to switch on the laser
        m_ScanCam.startPreview()
        m_ScanCam.SaveIt()                                                                             'Takes the "LaserPicture"
        OdarTec3Axes.MachinePanel.Bu_SpindleOff.PerformClick()                          'Performs the buttons click event to switch off the laser
        LaserPicture = PiBo_ScanView.BackgroundImage

        ReDim ScannedPoints(LaserPicture.Width)

        For i As Integer = 0 To ScannedPoints.Length - 1
            ScannedPoints(i) = New List(Of cSimplePoint)
        Next

        '--- Check where the laser line is at the right borders of the "LaserPicture" to set one point  ---

        For x As Integer = 10 To LaserPicture.Width - 1

            Counter = -1
            FoundLaser = False
            FoundLaser = False

            For y As Integer = 0 To LaserPicture.Height - 1
                If (Utilities.getRGBColor(LaserPicture.GetPixel(x, y))(0) > (Utilities.getRGBColor(PurePicture.GetPixel(x, y))(0) + 30)) Then
                    If FoundLaser = False Then
                        YStart = y
                        FoundLaser = True
                    End If
                    Counter += 1
                Else
                    If FoundLaser = True Then
                        y = LaserPicture.Height - 1
                    End If
                End If
            Next
            If FoundLaser = True And Counter > 3 Then
                ZeroLineLocations(ZeroLineLocationsCounter) = YStart + (Counter / 2)
                ZeroLineLocationsCounter += 1
            End If
            If ZeroLineLocationsCounter = 10 Then
                Exit For
            End If
        Next

        For i As Integer = 0 To 9
            ZeroLineLocation += ZeroLineLocations(i)
        Next
        ZeroLineLocation = CInt(ZeroLineLocation / 10)

        OdarTec3Axes.ToolStriProBa_Main.Value = 5

#If DEBUG Then
        Console.Write("Zerolinelocation: ")
        Console.WriteLine(ZeroLineLocation)
#End If
        '--- Start the scan process ---

        For ScanStep As Double = 0 To NuUpDo_ScanDepth.Value Step NuUpDo_StepWidth.Value

            m_ScanCam.startPreview()
            m_ScanCam.SaveIt()                                                                             'Takes the "PurePicture"
            PurePicture = PiBo_ScanView.BackgroundImage
            OdarTec3Axes.MachinePanel.Bu_SpindleOn.PerformClick()                          'Performs the buttons click event to switch on the laser
            m_ScanCam.startPreview()
            m_ScanCam.SaveIt()                                                                             'Takes the "LaserPicture"
            OdarTec3Axes.MachinePanel.Bu_SpindleOff.PerformClick()                          'Performs the buttons click event to switch off the laser
            LaserPicture = PiBo_ScanView.BackgroundImage

            ActualMachineY = OdarTec3Axes.A.Y
            OdarTec3Axes.MachinePanel.makeAStepRemoteControlled("+Y", NuUpDo_StepWidth.Value, 25)    'Make a step in the -y direction
            If OdarTec3Axes.A.Y > (ActualMachineY + NuUpDo_StepWidth.Value / 2) Then

                PiBo_Reticle.Image = LaserPicture
                PiBo_Reticle.Invalidate()
                PiBo_ScanView.Invalidate()

                'For x As Integer = 0 To LaserPicture.Width - 1
                '    For y As Integer = 0 To LaserPicture.Height - 1
                '        ResultPicture.SetPixel(x, y, Color.Black)
                '    Next
                'Next

                '--- Trace the laser over the specimen and calculate the height values  ---

                For x As Integer = 0 To LaserPicture.Width - 1

                    Counter = -1
                    FoundLaser = False

                    For y As Integer = 0 To LaserPicture.Height - 1
                        If (Utilities.getRGBColor(LaserPicture.GetPixel(x, y))(0) > (Utilities.getRGBColor(PurePicture.GetPixel(x, y))(0) + 30)) Then
                            If FoundLaser = False Then
                                YStart = y
                                FoundLaser = True
                            End If
                            Counter += 1
                        Else
                            If FoundLaser = True Then
                                y = LaserPicture.Height - 1
                            End If
                        End If
                    Next
                    If FoundLaser = True And Counter > 3 Then
                        ActualMMProPixel = MMProPixel * YLengthAtPassHeight / ScanPoint.Y
                        ScanPoint.Y = (ScanStep + ((YStart + (Counter / 2)) * MMProPixel)) * NuUpDo_ScalingFactor.Value
                        ScanPoint.Z = ((ZeroLineLocation - (YStart + (Counter / 2))) * MMProPixel) * LaserAngleTangens * NuUpDo_ScalingFactor.Value
                        ScanPoint.X = x * MMProPixel * NuUpDo_ScalingFactor.Value
                        If ScanPoint.Z > NuUpDo_ZTreshold.Value Then
                            ScannedPoints(x).Add(New cSimplePoint(ScanPoint))
                        End If
                    End If
                Next
            Else
                ScanStep -= NuUpDo_StepWidth.Value
            End If
            OdarTec3Axes.ToolStriProBa_Main.Value = ScanStep * 80 / NuUpDo_ScanDepth.Value + 5
        Next

        ReDim Triangles.m_PointArray(0)

        Utilities.sortPointListArray(ScannedPoints)             'Sort according to y value
        Utilities.smoothingPointListArray(ScannedPoints)    'Smoothing in the y direction
        Utilities.createMeshFromPointArray(Triangles, ScannedPoints, NuUpDo_StepWidth.Value, MMProPixel)

        '--- Move the result to the origin ---

        Dim MinX, MinY As Double
        MinX = 100000
        MinY = 100000
        For i As Integer = 0 To Triangles.m_PointArray.Length - 1
            If Triangles.m_PointArray(i).X < MinX Then MinX = Triangles.m_PointArray(i).X
            If Triangles.m_PointArray(i).Y < MinY Then MinY = Triangles.m_PointArray(i).Y
        Next

        For i As Integer = 0 To Triangles.m_PointArray.Length - 1
            Triangles.m_PointArray(i).X = Triangles.m_PointArray(i).X - MinX
            Triangles.m_PointArray(i).Y = Triangles.m_PointArray(i).Y - MinY
        Next

        '--- Move machine back to start and restore the feedrate ---

        OdarTec3Axes.MachinePanel.makeAStepRemoteControlled("-Y", NuUpDo_ScanDepth.Value / 2, 25)    'Make a step in the -y direction
        OdarTec3Axes.MachinePanel.TraBa_FeedRate.Value = m_FeedRateBackup     'Restore the feedrate of the machine for incremental steps

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
    Private Sub Bu_Calibration_Click(sender As Object, e As EventArgs) Handles Bu_Calibration.Click
        Dim PurePicture As Bitmap
        Dim LaserPicture As Bitmap
        Dim ResultPicture As Bitmap
        Dim Counter As Integer
        Dim FoundLaser As Boolean
        Dim YStart As Integer
        Dim m_Utilities As New cOdarTecUtilities()
        Dim Toggler As String
        Dim MinX1, MinX2 As Integer
        Dim MaxX1, MaxX2 As Integer
        Dim MinY1, MinY2 As Integer
        Dim MaxY1, MaxY2 As Integer
        Dim GapWatchCounter As Integer
        Dim ActualMachineZ As Double
        Dim Direction As String

        '--- Initial settings ---

        OdarTec3Axes.ToolStriProBa_Main.Value = 0
        setElementState("IsCalibrating")
        Toggler = " "
        MinX1 = 100000
        MaxX1 = -1
        MinY1 = 100000
        MaxY1 = -1
        MinX2 = 100000
        MaxX2 = -1
        MinY2 = 100000
        MaxY2 = -1
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
            OdarTec3Axes.MachinePanel.makeAStepRemoteControlled("-Z", NuUpDo_PassHeight.Value, 300)    'Make a step in the -y direction
            Direction = "+Z"
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

        ResultPicture = New Bitmap(PurePicture.Width, PurePicture.Height)
        For x As Integer = 0 To PurePicture.Width - 1
            For y As Integer = 0 To PurePicture.Height - 1
                ResultPicture.SetPixel(x, y, Color.Black)
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
                ResultPicture.SetPixel(x, CInt(YStart + (Counter / 2)), Color.Red)
            End If
        Next

        OdarTec3Axes.ToolStriProBa_Main.Value = 45

        'Threading.Thread.Sleep(5000)

        '--- Find "PassLength2"  ---

        For x As Integer = 80 To LaserPicture.Width - 81
            For y As Integer = 80 To LaserPicture.Height - 81

                If (m_Utilities.getRGBColor(LaserPicture.GetPixel(x, y))(0)) = 255 Then
                    If y > MaxY2 And Toggler = " " Then
                        MaxY2 = y
                    End If
                    If y < MinY2 And Toggler = " " Then
                        MinY2 = y
                    End If
                    If (MinY2 < 100000) And (MaxY2 > (-1)) And ((MaxY2 - MinY2) > 15) And Toggler = " " Then
                        MinX2 = x
                        Toggler = "FoundMinX"
                    End If
                    If (((y - MinY2) ^ 2) < 100) And (Toggler = "FoundMinX") Then
                        MaxX2 = x
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

        If MinY2 > 25 And MinY2 < ResultPicture.Height - 26 And MinX2 > 0 And MinX2 < ResultPicture.Width And MaxX2 > -1 And MaxX2 < (ResultPicture.Width - 1) Then 'Check if the lines would be inside the "ResultPicture"
            For i As Integer = 0 To 50
                ResultPicture.SetPixel(MinX2 - 1, MinY2 + 25 - i, Color.LightSeaGreen)
                ResultPicture.SetPixel(MaxX2 + 1, MinY2 + 25 - i, Color.LightSeaGreen)
                ResultPicture.SetPixel(MinX2, MinY2 + 25, Color.LightSeaGreen)
                ResultPicture.SetPixel(MaxX2, MinY2 + 25, Color.LightSeaGreen)
            Next
            For i As Integer = MinX2 - 20 To MaxX2 + 20
                ResultPicture.SetPixel(i, MinY2 + 5, Color.White)
                ResultPicture.SetPixel(i, MinY2 - 5, Color.White)
            Next
            For i As Integer = 0 To MinX2 + 20
                ResultPicture.SetPixel(i, MaxY2 + 5, Color.White)
                ResultPicture.SetPixel(i, MaxY2 - 5, Color.White)
            Next
            For i As Integer = MaxX2 - 20 To ResultPicture.Width - 1
                ResultPicture.SetPixel(i, MaxY2 + 5, Color.White)
                ResultPicture.SetPixel(i, MaxY2 - 5, Color.White)
            Next
        End If

        PiBo_Reticle.Image = ResultPicture

        PiBo_Reticle.Invalidate()
        PiBo_ScanView.Invalidate()

        OdarTec3Axes.MachinePanel.makeAStepRemoteControlled(Direction, NuUpDo_PassHeight.Value, 300)    'Make a step in the -y direction

        OdarTec3Axes.ToolStriProBa_Main.Value = 70

        '--- Take the pictures ---

        Toggler = " "

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
        TeBo_PictureWidth.Text = CStr(LaserPicture.Width)
        TeBo_PictureHeight.Text = CStr(LaserPicture.Height)

        OdarTec3Axes.ToolStriProBa_Main.Value = 80

        '--- Find the laser line ---

        ResultPicture = New Bitmap(PurePicture.Width, PurePicture.Height)
        For x As Integer = 0 To PurePicture.Width - 1
            For y As Integer = 0 To PurePicture.Height - 1
                ResultPicture.SetPixel(x, y, Color.Black)
            Next
        Next

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
                ResultPicture.SetPixel(x, CInt(YStart + (Counter / 2)), Color.Red)
            End If
        Next

        OdarTec3Axes.ToolStriProBa_Main.Value = 85

        '--- Find "MMProPixel" and "LaserAngleTangens" ---

        For x As Integer = 80 To LaserPicture.Width - 81
            For y As Integer = 80 To LaserPicture.Height - 81

                If (m_Utilities.getRGBColor(LaserPicture.GetPixel(x, y))(0)) = 255 Then
                    If y > MaxY1 And Toggler = " " Then
                        MaxY1 = y
                    End If
                    If y < MinY1 And Toggler = " " Then
                        MinY1 = y
                    End If
                    If (MinY1 < 100000) And (MaxY1 > (-1)) And ((MaxY1 - MinY1) > 15) And Toggler = " " Then
                        MinX1 = x
                        Toggler = "FoundMinX"
                    End If
                    If (((y - MinY1) ^ 2) < 100) And (Toggler = "FoundMinX") Then
                        MaxX1 = x
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

        OdarTec3Axes.ToolStriProBa_Main.Value = 95

        If MinY1 > 25 And MinY1 < ResultPicture.Height - 26 And MinX1 > 0 And MinX1 < ResultPicture.Width And MaxX1 > -1 And MaxX1 < ResultPicture.Width - 1 Then 'Check if the lines would be inside the "ResultPicture"
            For i As Integer = 0 To 50
                ResultPicture.SetPixel(MinX1 - 1, MinY1 + 25 - i, Color.LightSeaGreen)
                ResultPicture.SetPixel(MaxX1 + 1, MinY1 + 25 - i, Color.LightSeaGreen)
                ResultPicture.SetPixel(MinX1, MinY1 + 25, Color.LightSeaGreen)
                ResultPicture.SetPixel(MaxX1, MinY1 + 25, Color.LightSeaGreen)
            Next
            For i As Integer = MinX1 - 20 To MaxX1 + 20
                ResultPicture.SetPixel(i, MinY1 + 5, Color.White)
                ResultPicture.SetPixel(i, MinY1 - 5, Color.White)
            Next
            For i As Integer = 0 To MinX1 + 20
                ResultPicture.SetPixel(i, MaxY1 + 5, Color.White)
                ResultPicture.SetPixel(i, MaxY1 - 5, Color.White)
            Next
            For i As Integer = MaxX1 - 20 To ResultPicture.Width - 1
                ResultPicture.SetPixel(i, MaxY1 + 5, Color.White)
                ResultPicture.SetPixel(i, MaxY1 - 5, Color.White)
            Next
        End If

        OdarTec3Axes.ToolStriProBa_Main.Value = 98

        Try
            MMProPixel = NuUpDo_PassWidth.Value / (MaxX2 - MinX2)
            MMProPixelAtPassHeight = NuUpDo_PassWidth.Value / (MaxX1 - MinX1)
            YLengthAtPassHeight = (MaxY1 - MinY1)
            LaserAngleTangens = (NuUpDo_PassHeight.Value / MMProPixel) / ((MaxY1 - MinY1) * (MaxX2 - MinX2) / (MaxX1 - MinX1))
            TeBo_LaserAngle.Text = CStr(Math.Atan(LaserAngleTangens) * 360 / (2 * Math.PI))
            PiBo_Reticle.Image = ResultPicture
            TeBo_MMProPixel.Text = CStr(MMProPixel)
            CamFocusHeight = ((MaxX1 - LaserPicture.Width / 2) * MMProPixel) / (((MaxX1 - MaxX2) * MMProPixel) / NuUpDo_PassHeight.Value)
        Catch

        End Try

        OdarTec3Axes.ToolStriProBa_Main.Value = 100

        TeBo_CamFocusHeight.Text = CStr(CamFocusHeight)
#If DEBUG Then
        Console.WriteLine(MinX1)
        Console.WriteLine(MaxX1)
        Console.WriteLine(MinY1)
        Console.WriteLine(MaxY1)
#End If

        setElementState("Calibrated")

    End Sub

    Public Sub previewPicture()
        setElementState("IsPreviewing")
        Try 'If there is an image destroy it
            PiBo_Reticle.Image = Nothing
            PiBo_ScanView.BackgroundImage = Nothing
        Catch
        End Try
        m_ScanCam.stopPreview()
        m_ScanCam.startPreview()
        BGWor_Preview.RunWorkerAsync()

    End Sub

    Private Sub BGWor_Preview_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BGWor_Preview.DoWork
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim g As Graphics = PiBo_Reticle.CreateGraphics()

        Do While (BGWor_Preview.CancellationPending = False)

            ' Perform a time consuming operation and report progress.

            '--- Draw the reticle ---

            g.DrawLine(Pens.Black, 0, CInt(PiBo_Reticle.Height / 2 - 25), PiBo_Reticle.Width, CInt(PiBo_Reticle.Height / 2 - 25))
            g.DrawLine(Pens.Black, CInt(PiBo_Reticle.Width / 2 - 11), 0, CInt(PiBo_Reticle.Width / 2 - 11), PiBo_Reticle.Height)

            '--- Draw the scan area borders ---

            g.DrawLine(Pens.BlueViolet, 0, CInt((PiBo_Reticle.Height / 2 - 25) - (ScanHeight / 2)), PiBo_Reticle.Width, CInt((PiBo_Reticle.Height / 2 - 25) - (ScanHeight / 2)))
            g.DrawLine(Pens.BlueViolet, 0, CInt((PiBo_Reticle.Height / 2 - 25) + (ScanHeight / 2)), PiBo_Reticle.Width, CInt((PiBo_Reticle.Height / 2 - 25) + (ScanHeight / 2)))
            g.DrawLine(Pens.BlueViolet, CInt((PiBo_Reticle.Width / 2 - 11) - (ScanWidth / 2)), 0, CInt((PiBo_Reticle.Width / 2 - 11) - (ScanWidth / 2)), PiBo_Reticle.Height)
            g.DrawLine(Pens.BlueViolet, CInt((PiBo_Reticle.Width / 2 - 11) + (ScanWidth / 2)), 0, CInt((PiBo_Reticle.Width / 2 - 11) + (ScanWidth / 2)), PiBo_Reticle.Height)

        Loop
    End Sub

    Private Sub Bu_Preview_Click(sender As Object, e As EventArgs) Handles Bu_Preview.Click
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
                Bu_Preview.BackColor = Color.OrangeRed
                Bu_Preview.Enabled = True
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
                Bu_Preview.BackColor = Color.GhostWhite
                Bu_Preview.ForeColor = Color.LightGray
                Bu_Preview.Enabled = False
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
                Bu_Preview.BackColor = Color.GhostWhite
                Bu_Preview.Enabled = True
                Bu_LaserOnOff.BackColor = Color.GhostWhite
                Bu_LaserOnOff.Enabled = True
                OdarTec3Axes.ToolStriProBa_Main.Visible = False
            Case "IsScanning"
                Bu_Calibration.BackColor = Color.GhostWhite
                Bu_Calibration.Enabled = False
                Bu_Scan.BackColor = Color.OrangeRed
                Bu_Scan.Enabled = True
                Bu_Ok.BackColor = Color.GhostWhite
                Bu_Ok.Enabled = False
                Bu_Preview.BackColor = Color.GhostWhite
                Bu_Preview.Enabled = False
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
                Bu_Preview.BackColor = Color.GhostWhite
                Bu_Preview.Enabled = True
                Bu_LaserOnOff.BackColor = Color.GhostWhite
                Bu_LaserOnOff.Enabled = True
                OdarTec3Axes.ToolStriProBa_Main.Visible = False
            Case "IsPreviewing"
                Bu_Preview.BackColor = Color.OrangeRed
        End Select
    End Sub

End Class
