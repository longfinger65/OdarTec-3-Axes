Imports OdarTec3Axes.cObjectRepresentation
Imports System.ComponentModel
Imports System.Threading

Public Class CamTest

    Public Sub New(ByRef ObjectRepresentation As cObjectRepresentation, ByRef WHFocus As cWhoHasTheFocus, ByRef ToolLibrary As cToolManagement, ByRef WhatIsActive As String, ByRef DrawingPanel As Panel, ByRef FeatureManager As TabControl)
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        m_ScanCam = New cOTCam(LiBo_ScanCam, PiBo_ScanView)

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

    '---Begin delegates ---

    ' Delegate Sub takePictureDel()
    'Delegate Sub refreshPictureDel()

    '----- End member variables, begin member methodes ----------------------

    Private Sub on_Load(sender As Object, e As EventArgs) Handles Me.Load

        Bu_Calibration.BackColor = Color.LightCoral
        PiBo_ScanView.Image = Nothing
        previewPicture()

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

    Private Sub Button_Ok_Click(sender As Object, e As EventArgs) Handles Bu_Ok.Click

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

    Private Sub Bu_LaserOnOff_Click(sender As Object, e As EventArgs) Handles Bu_LaserOnOff.Click

        If LaserIsOn = False Then
            OdarTec3Axes.MachinePanel.switchSpindelOn()                         'Performs the buttons click event to switch on the laser
            LaserIsOn = True
        Else
            OdarTec3Axes.MachinePanel.switchSpindelOff()                       'Performs the buttons click event to switch on the laser
            LaserIsOn = False
        End If

    End Sub


    Public Sub previewPicture()
        setElementState("IsPreviewing")
        Try 'If there is an image destroy it
            PiBo_ScanView.BackgroundImage = Nothing
        Catch
        End Try
        m_ScanCam.stopPreview()
        m_ScanCam.startPreview()

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim m_Utilities As New cOdarTecUtilities()
        Dim DCTMatrix(,) As Double
        Dim Direction As String
        Dim NewSumOfHighFrequencyValues As Double
        Dim OldSumOfHighFrequencyValues As Double
        Dim ZStepValue As Double
        Dim ToggleCounter As Integer    'To detect the sharpest point

        '--- Initial settings ---

        ZStepValue = 1
        ToggleCounter = 0

        m_ScanCam.stopPreview()                                                                             'Stops the preview
        m_ScanCam.startPreview()
        m_ScanCam.SaveIt()                                                                             'Takes the "PurePicture"
        ReDim DCTMatrix(PiBo_ScanView.BackgroundImage.Width - 1, PiBo_ScanView.BackgroundImage.Height - 1)

        '--- Take the first sum ---

        m_Utilities.executeDCT(DCTMatrix, PiBo_ScanView.BackgroundImage, "Test")
        For x As Integer = CInt(PiBo_ScanView.BackgroundImage.Width / 2) To PiBo_ScanView.BackgroundImage.Width - 1
            OldSumOfHighFrequencyValues += DCTMatrix(x, PiBo_ScanView.BackgroundImage.Height - 1)
        Next
        For y As Integer = CInt(PiBo_ScanView.BackgroundImage.Height / 2) To PiBo_ScanView.BackgroundImage.Height - 1
            OldSumOfHighFrequencyValues += DCTMatrix(PiBo_ScanView.BackgroundImage.Width - 1, y)
        Next
        Direction = "+Z"

        Do While 1

            If (OdarTec3Axes.A.Z < 165) And Direction = "+Z" Then
                OdarTec3Axes.MachinePanel.makeAStepRemoteControlled("+Z", ZStepValue, 300)    'Make a step in the -y direction
            ElseIf (OdarTec3Axes.A.Z > 0) And Direction = "-Z" Then
                OdarTec3Axes.MachinePanel.makeAStepRemoteControlled("-Z", ZStepValue, 300)    'Make a step in the -y direction
            End If

            '--- Take a new picture ---

            m_ScanCam.stopPreview()                                                                             'Stops the preview
            m_ScanCam.startPreview()
            m_ScanCam.SaveIt()                                                                             'Takes the "PurePicture"
            PiBo_ScanView.Invalidate()

            m_Utilities.executeDCT(DCTMatrix, PiBo_ScanView.BackgroundImage, "Test")

            For x As Integer = CInt(PiBo_ScanView.BackgroundImage.Width / 2) To PiBo_ScanView.BackgroundImage.Width - 1
                NewSumOfHighFrequencyValues += DCTMatrix(x, PiBo_ScanView.BackgroundImage.Height - 1)
            Next
            For y As Integer = CInt(PiBo_ScanView.BackgroundImage.Height / 2) To PiBo_ScanView.BackgroundImage.Height - 1
                NewSumOfHighFrequencyValues += DCTMatrix(PiBo_ScanView.BackgroundImage.Width - 1, y)
            Next

            '--- Check if the newly taken picture is mor sharp than the older one and set the direction according ---

            If NewSumOfHighFrequencyValues > OldSumOfHighFrequencyValues And Direction = "+Z" Then
                ZStepValue = 1
            ElseIf NewSumOfHighFrequencyValues < OldSumOfHighFrequencyValues And Direction = "+Z" Then
                Direction = "-Z"
                ZStepValue = 2
                ToggleCounter += 1
            ElseIf NewSumOfHighFrequencyValues > OldSumOfHighFrequencyValues And Direction = "-Z" Then
                ZStepValue = 1
            ElseIf NewSumOfHighFrequencyValues < OldSumOfHighFrequencyValues And Direction = "-Z" Then
                Direction = "+Z"
                ZStepValue = 2
                ToggleCounter += 1
            End If

            If ToggleCounter > 5 Then
                Exit Do
            End If
            OldSumOfHighFrequencyValues = NewSumOfHighFrequencyValues
            NewSumOfHighFrequencyValues = 0

        Loop
    End Sub

End Class
