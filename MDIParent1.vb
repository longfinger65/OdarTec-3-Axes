Imports System.Windows.Forms
Imports System.Threading
Imports System
Imports System.IO
Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.Integration

Public Class OdarTec3Axes

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.

        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        m_UIState = New cUserInterfaceState
        m_ToolLibrary = New cToolManagement()
        m_MachinePanel = New MachinePanel(ToolLibrary)
        m_sampleVisualBasicColl = New Collection()
        m_OdarTec3AxesOptions = New FM_Options(ToolLibrary, UIState)
        m_Text = New ArrayList()
        m_Import = New ArrayList()
        m_A = New cPoint()

        '----- Initial settings -----

        HelpPath = Path.Combine(Application.StartupPath, "Help\documentation for customers\3-AxesDocumentation.chm")
        sLine = ""

    End Sub

    '<STAThread()> _
    'Shared Sub Main()
    '    Dim mainWindow As OdarTec3Axes = New OdarTec3Axes()
    '    Application.Run(mainWindow)

    'End Sub

    '----- Begin member variables and constants -----------------------------------------

    Private m_ChildFormNumber As Integer
    Private m_MachinePanel As MachinePanel
    Private m_Commands() As String
    Private m_A As cPoint
    Private m_Steps As Double
    Private m_Answer As String
    Private m_sLine As String
    Private m_Text As ArrayList
    Private m_MachineDescription() As String
    Private m_Import As ArrayList
    Private m_sampleVisualBasicColl As Collection
    Private m_HelpPath As String
    Private m_ToolLibrary As cToolManagement
    Private m_OdarTec3AxesOptions As FM_Options
    Private m_UIState As cUserInterfaceState

    '----- Get and set properties -----

    Public Property ChildFormNumber() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ChildFormNumber
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_ChildFormNumber = Value
        End Set
    End Property

    Public Property MachinePanel() As MachinePanel
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_MachinePanel
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As MachinePanel)
            m_MachinePanel = Value
        End Set
    End Property

    Public Property Commands() As String()
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Commands
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String())
            m_Commands = Value
        End Set
    End Property

    Public Property A() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_A
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_A = Value
        End Set
    End Property

    Public Property Steps() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Steps
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_Steps = Value
        End Set
    End Property

    Public Property Answer() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Answer
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_Answer = Value
        End Set
    End Property

    Public Property sLine() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_sLine
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_sLine = Value
        End Set
    End Property

    Public Property myText() As ArrayList
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Text
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As ArrayList)
            m_Text = Value
        End Set
    End Property

    Public Property MachineDescription() As String()
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_MachineDescription
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String())
            m_MachineDescription = Value
        End Set
    End Property

    Public Property Import() As ArrayList
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Import
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As ArrayList)
            m_Import = Value
        End Set
    End Property

    Public Property sampleVisualBasicColl() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_sampleVisualBasicColl
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_sampleVisualBasicColl = Value
        End Set
    End Property

    Public Property HelpPath() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_HelpPath
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_HelpPath = Value
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

    Public Property OdarTec3AxesOptions() As FM_Options
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_OdarTec3AxesOptions
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As FM_Options)
            m_OdarTec3AxesOptions = Value
        End Set
    End Property

    Public Property UIState() As cUserInterfaceState
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_UIState
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cUserInterfaceState)
            m_UIState = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewWindowToolStripMenuItem.Click
        makeNewMDIChild()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click
        importDXF()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Hier Code einfügen, um den aktuellen Inhalt des Formulars in einer Datei zu speichern
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click

        Dim SettingsPath As String
        Dim Writer As StreamWriter

        '--- Initial settings ---

        If MachinePanel.SerPo_Machine.IsOpen = True Then
            Try
                SettingsPath = "D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\settings\" + MachinePanel.Model(0) + ".txt"
                Writer = New StreamWriter(SettingsPath)
                Writer.WriteLine("'Values of the X-, Y- and Z-axis in mm")
                Writer.WriteLine("")
                Writer.WriteLine(A.X.ToString("F3"))
                Writer.WriteLine(A.Y.ToString("F3"))
                Writer.WriteLine(A.Z.ToString("F3"))
                Writer.WriteLine("")
                Writer.WriteLine("'Values of the mm / step ratio of the axes beginning with the x-axis")
                Writer.WriteLine("")
                For i As Integer = 0 To MachinePanel.MMProStep.Length - 1
                    Writer.WriteLine(MachinePanel.MMProStep(i).ToString("F4"))
                Next
                Writer.WriteLine("")
                Writer.WriteLine("'---------------------------------------------------")
                Writer.Close()

            Catch ex As Exception

            End Try
        End If
        Me.Close()

    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Mithilfe von My.Computer.Clipboard den ausgewählten Text bzw. die ausgewählten Bilder in die Zwischenablage kopieren
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Mithilfe von My.Computer.Clipboard den ausgewählten Text bzw. die ausgewählten Bilder in die Zwischenablage kopieren
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Mithilfe von My.Computer.Clipboard.GetText() oder My.Computer.Clipboard.GetData Informationen aus der Zwischenablage abrufen
    End Sub


    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Alle untergeordneten Formulare des übergeordneten Formulars schließen
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        m_MachinePanel.Show()
    End Sub


    Private Sub ToolStripComboBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub OdarTec3Axes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '----- Add event handler for the wpf control -----

        AddHandler UserControl11.OnMenuItemClick, AddressOf Me.RibbonEventHandler

        HelpProvider1.HelpNamespace = HelpPath
        UserControl11.MyRibbon.Width = ElementHost1.Width
        ToolStriProBa_Main.Visible = False

    End Sub

    Private Sub OdarTec3Axes_Paint(sender As Object, e As EventArgs) Handles MyBase.Paint
        UserControl11.MyRibbon.Width = ElementHost1.Width
    End Sub

    Private Sub BahnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BahnToolStripMenuItem.Click
        createNewCamPath()
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub NeueSkizzeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeueSkizzeToolStripMenuItem.Click
        Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        myGP.Status_SomethingIsInProcess = True
        myGP.Status_SketchIsInProcess = True
        myGP.ObjectRepresentation.addElement(New cSketch())
    End Sub

    Private Sub MenuStrip_MouseClick(sender As Object, e As MouseEventArgs) Handles MenuStrip.MouseClick

    End Sub

    Private Sub MenuStrip_Paint(sender As Object, e As PaintEventArgs) Handles MenuStrip.Paint

        sub_ConfigureMenuStrip(sender, e)

    End Sub

    Private Sub NeueSkizzeToolStripMenuItem_Paint(sender As Object, e As PaintEventArgs) Handles NeueSkizzeToolStripMenuItem.Paint
        Try
            Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
            myGP.GraphicPanel_Paint(sender, e)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub OdarTec3Axes_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Try
            Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
            myGP.GraphicPanel_Paint(sender, e)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub LinieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinieToolStripMenuItem.Click

    End Sub

    Public Sub sub_ConfigureMenuStrip(sender As Object, e As PaintEventArgs)

        Try
            Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
            myGP.GraphicPanel_Paint(sender, e)
            If myGP.Status_SketchIsInProcess = True Then
                NeueSkizzeToolStripMenuItem.Enabled = False
                BahnToolStripMenuItem.Enabled = False
            Else
                NeueSkizzeToolStripMenuItem.Enabled = True
            End If
        Catch ex As Exception
            NeueSkizzeToolStripMenuItem.Enabled = False
        End Try
        Try
            Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
            myGP.GraphicPanel_Paint(sender, e)
            If myGP.Status_CamPathIsInProcess = True Then
                BahnToolStripMenuItem.Enabled = False
            Else
                NeueSkizzeToolStripMenuItem.Enabled = True
                BahnToolStripMenuItem.Enabled = True
            End If
        Catch ex As Exception
            BahnToolStripMenuItem.Enabled = False
        End Try

    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GeneriereCNCProgrammToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneriereCNCProgrammToolStripMenuItem.Click
        Import.Clear()
        Dim mTypeString As String = ""
        Dim DXFI As New cDXFInterface
        Dim SketchNumber As String
        Dim i As Integer
        Dim OpenFileDialog As New OpenFileDialog
        Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Textdateien (*.dxf)|*.dxf|Alle Dateien (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim objReader As New StreamReader(OpenFileDialog.FileName)
            Dim FileName As String = OpenFileDialog.FileName
            For i = 1 To myGP.ObjectRepresentation.Objects.Count
                If myGP.ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                    SketchNumber = myGP.ObjectRepresentation.Objects.Item(i).NameOfEntity
                End If
            Next
            'str_ProgramFileName = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
            Do
                'DXFI.sub_ConvertDxfToOdtPrt(myGP.ObjectRepresentation.Objects, objReader.ReadLine())
            Loop Until DXFI.sub_ConvertDxfToOdtPrt(myGP.ObjectRepresentation.Objects.Item(myGP.ObjectRepresentation.Objects.Count), objReader.ReadLine(), SketchNumber) = True
            objReader.Close()
        End If

    End Sub

    Private Sub TascheToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TascheToolStripMenuItem.Click
        createNewCamPocket()

    End Sub

    Private Sub MenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Private Sub ContentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContentsToolStripMenuItem.Click
#If DEBUG Then
        Console.WriteLine(HelpPath)
#End If

        Help.ShowHelp(Me, HelpProvider1.HelpNamespace, HelpNavigator.TableOfContents, "")
    End Sub


    Private Sub DllTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DllTestToolStripMenuItem.Click
        ' Console.WriteLine(Test2(6))
    End Sub

    <DllImport("D:\Bibliothek-2\Projekte\WorkingDirectory\3-Axis\software\PC programs\OdarTecUtility1\Debug\Win32Project1.dll", EntryPoint:="#1", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function Test2(a As Integer) As Integer
    End Function

    Private Sub ZoomToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ZoomToolStripMenuItem1.Click
        Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        myAC.GM.ZoomFactor += 0.2
    End Sub

    Private Sub ZoomToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ZoomToolStripMenuItem2.Click
        Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        If myAC.GM.ZoomFactor > 0.1 Then
            myAC.GM.ZoomFactor -= 0.1
        End If

    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        OdarTec3AxesOptions.ShowDialog()
    End Sub


    Private Sub ElementHost1_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs) Handles ElementHost1.ChildChanged

    End Sub

    Private Sub RibbonEventHandler(sender As Object, e As UserControl1EventArgs)
        Select Case e.mEvent
            Case "MeI_NewPart_Clicked"
                makeNewMDIChild()
            Case "RiBu_DXFImport_Clicked"
                importDXF()
            Case "RiBu_PointCloudImport_Clicked"
                importPointCloud()
            Case "RiBu_STLImport_Clicked"
                importSTL()
            Case "MeI_New2DSketch_Clicked"
                createNew2DSketch()
            Case "MeI_New3DSketch_Clicked"
                createNew3DSketch()
            Case "RiBu_SketchPoint_Clicked"
                Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
                myAC.LastAction.VString = "SketchPoint"
            Case "RiSpliBu_SketchLine_Clicked"
                Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
                myAC.LastAction.VString = "SketchLine"
            Case "RiSpliBu_SketchCircleCenterPoint_Clicked"
                Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
                myAC.LastAction.VString = "SketchCircleCenterPoint"
            Case "RiSpliBu_SketchCircle3Points_Clicked"
                Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
                myAC.LastAction.VString = "SketchCircle3Points"

                '----- CAM -----

            Case "RiBu_CamPocket_Clicked"
                createNewCamPocket()
            Case "RiBu_CamPath_Clicked"
                createNewCamPath()
            Case "RiBu_CamBore_Clicked"
                createNewCamBore()
            Case "RiBu_CamPicture_Clicked"
                createNewCamPicture()
            Case "RiBu_CamFaceMilling_Clicked"
                createNewCamFaceMilling()
            Case "RiBu_CamScan_Clicked"
                createNewCamScan()
            Case "RiBu_CamScan2D_Clicked"
                createNewCamScan2D()
            Case "RiBu_Cam3D_Clicked"
                createNewCam3D()
        End Select

    End Sub

    Private Sub makeNewMDIChild()

        ' Neue Instanz des untergeordneten Formulars erstellen.
        'Dim ChildForm As New System.Windows.Forms.Form
        Dim GraphicPanel1 As New PartViewer(ToolLibrary)
        ' Vor der Anzeige dem MDI-Formular unterordnen.
        'ChildForm.MdiParent = Me
        GraphicPanel1.MdiParent = Me

        ChildFormNumber += 1
        GraphicPanel1.Text = "Fenster " & m_ChildFormNumber
        sampleVisualBasicColl.Add(GraphicPanel1, "Teil " & ChildFormNumber)
        GraphicPanel1.Show()

    End Sub

    Public Sub importDXF()

        Import.Clear()
        Dim mTypeString As String = ""
        Dim DXFI As New cDXFInterface
        Dim SketchNumber As String
        Dim i As Integer
        Dim OpenFileDialog As New OpenFileDialog
        Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Textdateien (*.dxf)|*.dxf|Alle Dateien (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim objReader As New StreamReader(OpenFileDialog.FileName)
            Dim FileName As String = OpenFileDialog.FileName
            For i = 1 To myGP.ObjectRepresentation.Objects.Count
                If myGP.ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                    SketchNumber = myGP.ObjectRepresentation.Objects.Item(i).NameOfEntity
                End If
            Next
            'str_ProgramFileName = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
            Do
                'DXFI.sub_ConvertDxfToOdtPrt(myGP.ObjectRepresentation.Objects.Item(myGP.ObjectRepresentation.Objects.Count), objReader.ReadLine(), SketchNumber)
            Loop Until DXFI.sub_ConvertDxfToOdtPrt(myGP.ObjectRepresentation.Objects.Item(myGP.ObjectRepresentation.Objects.Count), objReader.ReadLine(), SketchNumber) = True
            objReader.Close()
        End If
    End Sub

    Public Sub importPointCloud()
        Import.Clear()
        Dim mTypeString As String = ""
        Dim PCI As New cPointCloudInterface
        Dim SketchNumber As String
        Dim i As Integer
        Dim OpenFileDialog As New OpenFileDialog
        Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Punktewolkendateien (*.xyz)|*.xyz|Alle Dateien (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim objReader As New StreamReader(OpenFileDialog.FileName)
            Dim FileName As String = OpenFileDialog.FileName
            For i = 1 To myGP.ObjectRepresentation.Objects.Count
                If myGP.ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                    SketchNumber = myGP.ObjectRepresentation.Objects.Item(i).NameOfEntity
                End If
            Next
            PCI.importPointCloud(myGP.ObjectRepresentation.Objects.Item(myGP.ObjectRepresentation.Objects.Count), objReader, SketchNumber)
            objReader.Close()
        End If
    End Sub

    ''' <summary>
    ''' Imports the STL.
    ''' </summary>
    Public Sub importSTL()

        Import.Clear()
        Dim mTypeString As String = ""
        Dim STLI As New cStlInterface
        Dim Number As String
        Dim OpenFileDialog As New OpenFileDialog
        Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)

        ' Add a new imported feature

        myGP.Status_SomethingIsInProcess = True
        myGP.Status_SketchIsInProcess = True
        myGP.ObjectRepresentation.addElement(New cImported())
        myGP.Panel_GraphicArea.Refresh()
        myGP.WhatIsActive = "Imported"

        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "STL-Dateien (*.stl)|*.stl|Alle Dateien (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim objReader As New StreamReader(OpenFileDialog.FileName)
            Dim FileName As String = OpenFileDialog.FileName
            For i As Integer = 1 To myGP.ObjectRepresentation.Objects.Count
                If myGP.ObjectRepresentation.Objects.Item(i).StateOfEntity = 1 Then
                    Number = myGP.ObjectRepresentation.Objects.Item(i).NameOfEntity
                    myGP.ObjectRepresentation.Objects.Item(i).StateOfEntity = 0
                End If
            Next
            STLI.importSTL(myGP.ObjectRepresentation.Objects.Item(myGP.ObjectRepresentation.Objects.Count), objReader, Number)
            objReader.Close()
        End If
    End Sub

    Public Sub createNew2DSketch()
        Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        myGP.Status_SomethingIsInProcess = True
        myGP.Status_SketchIsInProcess = True
        myGP.ObjectRepresentation.addElement(New cSketch())
        myGP.Panel_GraphicArea.Refresh()
        myGP.WhatIsActive = "Sketch"
    End Sub

    Public Sub createNew3DSketch()
        Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        myGP.Status_SomethingIsInProcess = True
        myGP.Status_SketchIsInProcess = True
        myGP.ObjectRepresentation.addElement(New cSketch3D())
        myGP.Panel_GraphicArea.Refresh()
        myGP.WhatIsActive = "3D-Sketch"
    End Sub

    '----- CAM -----

    Public Sub createNewCamPocket()
        Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        myAC.Status_CamPathIsInProcess = True
        myAC.ObjectRepresentation.addElement(New cCamPocket(True))
        myAC.FeatureManager.SelectTab("TabPage_Properties")
        myAC.FeatureManager.Width = myAC.CamPocketProperties.Width + myAC.FeatureManager.Padding.X * 2 + SystemInformation.VerticalScrollBarWidth
        myAC.CamPocketProperties.Visible = True
        myAC.WhatIsActive = "CamPocket"
    End Sub

    Public Sub createNewCamPath()
        Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        myAC.Status_CamPathIsInProcess = True
        myAC.ObjectRepresentation.addElement(New cCamPath())
        myAC.FeatureManager.SelectTab("TabPage_Properties")
        myAC.FeatureManager.Width = myAC.CamPathProperties.Width + myAC.FeatureManager.Padding.X * 2 + SystemInformation.VerticalScrollBarWidth
        myAC.CamPathProperties.Visible = True
        myAC.WhatIsActive = "CamPath"
    End Sub

    Public Sub createNewCamBore()
        Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        myAC.Status_CamPathIsInProcess = True
        myAC.ObjectRepresentation.addElement(New cCamBore())
        myAC.FeatureManager.SelectTab("TabPage_Properties")
        myAC.FeatureManager.Width = myAC.CamBoreProperties.Width + myAC.FeatureManager.Padding.X * 2 + SystemInformation.VerticalScrollBarWidth
        myAC.CamBoreProperties.Visible = True
        myAC.WhatIsActive = "CamBore"

    End Sub

    Public Sub createNewCamPicture()
        Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        myAC.Status_CamPathIsInProcess = True
        myAC.ObjectRepresentation.addElement(New cCamPicture())
        myAC.FeatureManager.SelectTab("TabPage_Properties")
        myAC.FeatureManager.Width = myAC.CamPictureProperties.Width + myAC.FeatureManager.Padding.X * 2 + SystemInformation.VerticalScrollBarWidth
        myAC.CamPictureProperties.Visible = True
        myAC.WhatIsActive = "CamPicture"

    End Sub

    Public Sub createNewCamFaceMilling()
        Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        myAC.Status_CamPathIsInProcess = True
        myAC.ObjectRepresentation.addElement(New cCamFaceMilling())
        myAC.FeatureManager.SelectTab("TabPage_Properties")
        myAC.FeatureManager.Width = myAC.CamFaceMillingProperties.Width + myAC.FeatureManager.Padding.X * 2 + SystemInformation.VerticalScrollBarWidth
        myAC.CamFaceMillingProperties.Visible = True
        myAC.WhatIsActive = "CamFaceMilling"

    End Sub

    ''' <summary>
    ''' Creates the new cam scan.
    ''' </summary>
    Public Sub createNewCamScan()

        '----- Begin Description ---------------------------------------------------------------------------------------------------------------------
        '
        ' Purpose:  Adds a new imported feature to the cad feature tree and scans over a given object to create a triangle mesh.
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps ------------------------------------------------------------------------------------------------------------------------------------
        '
        ' 1. Create the imported feature and add it to the collection.
        ' 2. Show the scan property panel which shows the actual cam picture with a reticle.
        '
        '----- End description ------------------------------------------------------------------------------------------------------------------------

        Import.Clear()
        Dim mTypeString As String = ""
        Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)

        '--- Open the scan property dialog ---

        myGP.Status_SomethingIsInProcess = True
        myGP.Status_SketchIsInProcess = True
        myGP.Panel_GraphicArea.Refresh()
        myGP.WhatIsActive = "Imported"
        myGP.FeatureManager.SelectTab("TabPage_Properties")
        myGP.WhatIsActive = "CamScan"
        myGP.showCamScanProperty()

    End Sub

    Public Sub createNewCamScan2D()

        '----- Begin Description ---------------------------------------------------------------------------------------------------------------------
        '
        ' Purpose:  Adds a new imported feature to the cad feature tree and scans over a given object to create a triangle mesh.
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps ------------------------------------------------------------------------------------------------------------------------------------
        '
        ' 1. Create the imported feature and add it to the collection.
        ' 2. Show the scan property panel which shows the actual cam picture with a reticle.
        '
        '----- End description ------------------------------------------------------------------------------------------------------------------------

        Dim mTypeString As String = ""
        Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)

        '--- Open the scan property dialog ---

        myGP.Status_SomethingIsInProcess = True
        myGP.Status_SketchIsInProcess = True
        myGP.ObjectRepresentation.addElement(New cSketch())
        myGP.Panel_GraphicArea.Refresh()
        myGP.FeatureManager.SelectTab("TabPage_Properties")
        myGP.WhatIsActive = "CamScan2D"
        myGP.showCamScan2DProperty()

    End Sub

    Public Sub createNewCam3D()
        Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        myAC.Status_CamPathIsInProcess = True
        myAC.ObjectRepresentation.addElement(New cCam3D())
        myAC.FeatureManager.SelectTab("TabPage_Properties")
        myAC.FeatureManager.Width = myAC.Cam3DProperties.Width + myAC.FeatureManager.Padding.X * 2 + SystemInformation.VerticalScrollBarWidth
        myAC.Cam3DProperties.Visible = True
        myAC.WhatIsActive = "Cam3D"

    End Sub

    Private Sub ZoomAllesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomAllesToolStripMenuItem.Click
        Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        Dim View As Rectangle

        View.Height = myAC.Panel_GraphicArea.Height
        View.Width = myAC.Panel_GraphicArea.Width

        myAC.ObjectRepresentation.zoomAll(View)

    End Sub

    Private Sub DrehenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DrehenToolStripMenuItem.Click
        Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        myAC.LastAction.VString = "rotate"
    End Sub

    Private Sub ViewMenu_Click(sender As Object, e As EventArgs) Handles ViewMenu.Click

    End Sub

    Private Sub ObenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObenToolStripMenuItem.Click
        Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        myAC.GM.Angle.X = 0
        myAC.GM.Angle.Y = 0
    End Sub

    Private Sub AuswahlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuswahlToolStripMenuItem.Click
        Dim myAC As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)
        myAC.LastAction.VString = "choose"
    End Sub

    Private Sub BSplineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BSplineToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripMenuItem_Connection_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

        Dim saveFileDialog1 As New SaveFileDialog()
        Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)

        '--- Initial settings ---

        saveFileDialog1.Filter = "STL-Format|*.stl"
        saveFileDialog1.Title = "OdarTec Datei speichern"
        'saveFileDialog1.ShowDialog()

        '--- If the file name is not an empty string open it for saving. ---
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then


            If saveFileDialog1.FileName <> "" Then
                Select Case saveFileDialog1.FilterIndex
                    Case 1
                        Dim sw As StreamWriter = New StreamWriter(saveFileDialog1.OpenFile())
                        Dim FileName As String = saveFileDialog1.FileName
                            Dim STLConverter As New cStlInterface()
                            For i As Integer = 1 To myGP.ObjectRepresentation.Objects.Count
                                If myGP.ObjectRepresentation.Objects.Item(i).GetType = GetType(cImported) Then
                                    STLConverter.exportSTL(myGP.ObjectRepresentation.Objects.Item(i).Imported.item(1), sw)
                                End If
                            Next
                        sw.Close()
                End Select
            End If
        End If
    End Sub

    Private Sub TestpanelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestpanelToolStripMenuItem.Click

        '----- Begin Description ---------------------------------------------------------------------------------------------------------------------
        '
        ' Purpose:  Adds a new imported feature to the cad feature tree and scans over a given object to create a triangle mesh.
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps ------------------------------------------------------------------------------------------------------------------------------------
        '
        ' 1. Create the imported feature and add it to the collection.
        ' 2. Show the scan property panel which shows the actual cam picture with a reticle.
        '
        '----- End description ------------------------------------------------------------------------------------------------------------------------

        Dim myGP As PartViewer = DirectCast(Me.ActiveMdiChild, PartViewer)

        '--- Open the scan property dialog ---

        myGP.Status_SomethingIsInProcess = True
        myGP.Panel_GraphicArea.Refresh()
        myGP.WhatIsActive = "Test"
        myGP.FeatureManager.SelectTab("TabPage_Properties")
        myGP.FeatureManager.Width = myGP.CamTestProperties.Width + myGP.FeatureManager.Padding.X * 2 + SystemInformation.VerticalScrollBarWidth
        myGP.CamTestProperties.Visible = True
        myGP.WhatIsActive = "CamTest"

    End Sub

End Class
