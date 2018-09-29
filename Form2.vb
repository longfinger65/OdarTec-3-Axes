Imports System.Globalization
Imports System
Imports System.IO
Imports System.Collections
Imports System.Threading

Public Class MachinePanel

    '----- Begin constructors -----------------------------------------------

    Public Sub New(ByRef ToolLibrary As cToolManagement)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        m_SP = New cProgramSendThread(Me)
        m_myDelegate = New Actualize(AddressOf UpdateDisplay)
        m_myDelegate2 = New Reconn(AddressOf Reconnect)
        m_readThread = New Thread(AddressOf Read)

        '----- Initial settings -----

    End Sub

    '----- End constructors, begin member Variables and constants -----------------------------

    Private m_LineContent(11) As String
    Private m_ProgramFileName As String
    Private m_Stopp As Boolean = False
    Private m_SentenceNumber As Integer
    Private m_SP As cProgramSendThread
    Private m_T1 As Thread
    Public m_myDelegate As Actualize
    Public m_myDelegate2 As Reconn
    Private m_MMProStep(6) As Double
    Private m_MMProStepOld(6) As Double
    Private m_ISteps As Double
    Private m_StateOfMachine As String
    Private m_COMPortName As String
    Private m_readThread As Thread
    Private m_continuee As Boolean
    Private m_Commands() As String
    Private m_A As cPoint
    Private m_Steps As Double
    Private m_Answer As String
    Private m_sLine As String
    Private m_Text As ArrayList
    Private m_MachineDescription() As String
    Private m_Model() As String

    '----- Get and set properties -----

    Public Property LineContent() As String()
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_LineContent
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String())
            m_LineContent = Value
        End Set
    End Property

    Public Property ProgramFileName() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ProgramFileName
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_ProgramFileName = Value
        End Set
    End Property

    Public Property Stopp() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Stopp
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_Stopp = Value
        End Set
    End Property

    Public Property SentenceNumber() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_SentenceNumber
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_SentenceNumber = Value
        End Set
    End Property

    Public Property SP() As cProgramSendThread
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_SP
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cProgramSendThread)
            m_SP = Value
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

    Public Property myDelegate() As Actualize
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_myDelegate
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Actualize)
            m_myDelegate = Value
        End Set
    End Property

    Public Property myDelegate2() As Reconn
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_myDelegate2
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Reconn)
            m_myDelegate2 = Value
        End Set
    End Property

    Public Property MMProStep() As Double()
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_MMProStep
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double())
            m_MMProStep = Value
        End Set
    End Property

    Private Property MMProStepOld() As Double()
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_MMProStepOld
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double())
            m_MMProStepOld = Value
        End Set
    End Property

    Public Property ISteps() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ISteps
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ISteps = Value
        End Set
    End Property

    Public Property StateOfMachine() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_StateOfMachine
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_StateOfMachine = Value
        End Set
    End Property

    Public Property COMPortName() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_COMPortName
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_COMPortName = Value
        End Set
    End Property

    Public Property readThread() As Thread
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_readThread
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Thread)
            m_readThread = Value
        End Set
    End Property

    Public Property Continuee() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_continuee
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_continuee = Value
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

    Public Property Model() As String()
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Model
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String())
            m_Model = Value
        End Set
    End Property


    '----- End member variables and constants, begin member methodes -----

    Delegate Sub Actualize(Line6 As String, Line7 As String, x As Double, y As Double, z As Double)
    Delegate Sub Reconn()

    Public Sub MachinePanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LineContent(9) = "x =   y =    z =   M "
        actualizeDisplayLines()
        NuUpDo_StepSize.Value = 1
        ISteps = NuUpDo_StepSize.Value

        ' Show all available COM ports

        For Each sp As String In My.Computer.Ports.SerialPortNames
            CoBo_COMPort.Items.Add(sp)
        Next
        CoBo_BaudRate.Text = "57600"
        CoBo_Parity.Text = "None"
        CoBo_DataBits.Text = "8"
        CoBo_StopBits.Text = "1"
        CoBo_FlowControl.Text = "None"
    End Sub

    Public Sub UpdateDisplay(Line6 As String, Line7 As String, x As Double, y As Double, z As Double)
        OdarTec3Axes.A.X = x
        OdarTec3Axes.A.Y = y
        OdarTec3Axes.A.Z = z
        LineContent(6) = Line6
        LineContent(7) = Line7
        actualizeDisplayLines()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click

    End Sub

    Private Sub Button_Delete_Click(sender As Object, e As EventArgs) Handles Button_Delete.Click

    End Sub

    Private Sub Button_StepMinusX_Click(sender As Object, e As EventArgs) Handles Bu_StepMinusX.Click

        ' Inkremetal step X-

        StateOfMachine = "Busy"
        If (SerPo_Machine.IsOpen <> True) Then
            Reconnect()
        End If
        If (SerPo_Machine.IsOpen = True) Then
            Dim strBuffer As String
            Dim strStepsXYZ() As String
            SerPo_Machine.ReadExisting()

            If ((OdarTec3Axes.A.X - ISteps) >= 0) Then
                If (SerPo_Machine.IsOpen = True) Then
                    SerPo_Machine.WriteLine("cmdProgramExecute")

                    'Wait until machine is ready to receive data

                    Do While (SerPo_Machine.ReadExisting()).Contains(Chr(37)) <> True
                    Loop

                    'Step sequence

                    SerPo_Machine.WriteLine("G1 X" + CStr(OdarTec3Axes.A.X - ISteps) + " F" + CStr(TraBa_FeedRate.Value))

                    Do While (1)
                        strBuffer = SerPo_Machine.ReadLine()
                        If (strBuffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                    Loop

                    SerPo_Machine.WriteLine("M02")
                    Do While (1)
                        strBuffer = SerPo_Machine.ReadLine()
                        If (strBuffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                        strStepsXYZ = strBuffer.Split(",")
                        OdarTec3Axes.A.X = MMProStep(0) * CInt(Val(strStepsXYZ(0)))
                        OdarTec3Axes.A.Y = MMProStep(1) * CInt(Val(strStepsXYZ(1)))
                        OdarTec3Axes.A.Z = MMProStep(2) * CInt(Val(strStepsXYZ(2)))
                        actualizeDisplayLines()
                    Loop
                End If
            End If
        End If
        StateOfMachine = "Ready"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ' Home X

        If (SerPo_Machine.IsOpen = True) Then
            SerPo_Machine.Write(Chr(99))
            SerPo_Machine.Write(Chr(109))
            SerPo_Machine.Write(Chr(100))
            SerPo_Machine.Write(Chr(72))
            SerPo_Machine.Write(Chr(111))
            SerPo_Machine.Write(Chr(109))
            SerPo_Machine.Write(Chr(101))
            SerPo_Machine.Write(Chr(88))
            SerPo_Machine.Write(Chr(10))
        End If
        OdarTec3Axes.A.X = 185
        actualizeDisplayLines()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        ' Home Y

        If (SerPo_Machine.IsOpen = True) Then
            SerPo_Machine.Write(Chr(99))
            SerPo_Machine.Write(Chr(109))
            SerPo_Machine.Write(Chr(100))
            SerPo_Machine.Write(Chr(72))
            SerPo_Machine.Write(Chr(111))
            SerPo_Machine.Write(Chr(109))
            SerPo_Machine.Write(Chr(101))
            SerPo_Machine.Write(Chr(89))
            SerPo_Machine.Write(Chr(10))
        End If
        OdarTec3Axes.A.Y = 0
        actualizeDisplayLines()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        ' Home Z

        If (SerPo_Machine.IsOpen = True) Then
            SerPo_Machine.Write(Chr(99))
            SerPo_Machine.Write(Chr(109))
            SerPo_Machine.Write(Chr(100))
            SerPo_Machine.Write(Chr(72))
            SerPo_Machine.Write(Chr(111))
            SerPo_Machine.Write(Chr(109))
            SerPo_Machine.Write(Chr(101))
            SerPo_Machine.Write(Chr(90))
            SerPo_Machine.Write(Chr(10))
        End If
        OdarTec3Axes.A.Z = 165
        actualizeDisplayLines()

    End Sub

    Private Sub Button_StepPlusX_Click(sender As Object, e As EventArgs) Handles Bu_StepPlusX.Click

        ' Inkremetal step X+

        StateOfMachine = "Busy"
        If (SerPo_Machine.IsOpen <> True) Then
            Reconnect()
        End If
        If (SerPo_Machine.IsOpen = True) Then
            Dim strBuffer As String
            Dim strStepsXYZ() As String
            SerPo_Machine.ReadExisting()

            If ((OdarTec3Axes.A.X + ISteps) <= 185) Then
                If (SerPo_Machine.IsOpen = True) Then
                    SerPo_Machine.WriteLine("cmdProgramExecute")

                    'Wait until machine is ready to receive data

                    Do While (SerPo_Machine.ReadExisting()).Contains(Chr(37)) <> True
                    Loop

                    'Step sequence

                    SerPo_Machine.WriteLine("G1 X" + CStr(OdarTec3Axes.A.X + ISteps) + " F" + CStr(TraBa_FeedRate.Value))

                    Do While (1)
                        strBuffer = SerPo_Machine.ReadLine()
                        If (strBuffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                    Loop

                    SerPo_Machine.WriteLine("M02")
                    Do While (1)
                        strBuffer = SerPo_Machine.ReadLine()
                        If (strBuffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                        strStepsXYZ = strBuffer.Split(",")
                        OdarTec3Axes.A.X = MMProStep(0) * CInt(Val(strStepsXYZ(0)))
                        OdarTec3Axes.A.Y = MMProStep(1) * CInt(Val(strStepsXYZ(1)))
                        OdarTec3Axes.A.Z = MMProStep(2) * CInt(Val(strStepsXYZ(2)))
                        actualizeDisplayLines()
                    Loop
                End If
            End If
        End If
        StateOfMachine = "Ready"
    End Sub

    Private Sub Button_StepPlusY_Click(sender As Object, e As EventArgs) Handles Bu_StepPlusY.Click

        ' Inkremetal step Y+

        StateOfMachine = "Busy"
        If (SerPo_Machine.IsOpen <> True) Then
            Reconnect()
        End If

        Dim strBuffer As String
        Dim strStepsXYZ() As String
        SerPo_Machine.ReadExisting()

        If ((OdarTec3Axes.A.Y + ISteps) <= 180) Then
            If (SerPo_Machine.IsOpen = True) Then
                SerPo_Machine.WriteLine("cmdProgramExecute")

                'Wait until machine is ready to receive data

                Do While (SerPo_Machine.ReadExisting()).Contains(Chr(37)) <> True
                Loop

                'Step sequence


                SerPo_Machine.WriteLine("G1 Y" + CStr(OdarTec3Axes.A.Y + ISteps) + " F" + CStr(TraBa_FeedRate.Value))

                Do While (1)
                    strBuffer = SerPo_Machine.ReadLine()
                    If (strBuffer.Contains(Chr(37))) Then
                        Exit Do
                    End If
                Loop

                SerPo_Machine.WriteLine("M02")

                Do While (1)
                    strBuffer = SerPo_Machine.ReadLine()
                    If (strBuffer.Contains(Chr(37))) Then
                        Exit Do
                    End If
                    strStepsXYZ = strBuffer.Split(",")
                    OdarTec3Axes.A.X = MMProStep(0) * CInt(Val(strStepsXYZ(0)))
                    OdarTec3Axes.A.Y = MMProStep(1) * CInt(Val(strStepsXYZ(1)))
                    OdarTec3Axes.A.Z = MMProStep(2) * CInt(Val(strStepsXYZ(2)))
                    actualizeDisplayLines()
                Loop
            End If
        End If
        StateOfMachine = "Ready"
    End Sub

    Private Sub NumericUpDown_StepSize_ValueChanged(sender As Object, e As EventArgs) Handles NuUpDo_StepSize.ValueChanged
        ISteps = NuUpDo_StepSize.Value
    End Sub

    Public Sub writeNumberSerial(dblNumber As Double)
        Dim strBuffer As String
        strBuffer = dblNumber.ToString(CultureInfo.CreateSpecificCulture("de-DE"))

#If DEBUG Then
        Console.WriteLine(dblNumber.ToString(CultureInfo.CreateSpecificCulture("de-DE")))
#End If

        SerPo_Machine.Write(strBuffer)
    End Sub

    Public Sub actualizeDisplayLines()
        LineContent(9) = "x = " + CStr(OdarTec3Axes.A.X) + "   y = " + CStr(OdarTec3Axes.A.Y) + "   z = " + CStr(OdarTec3Axes.A.Z) + "     " + ProgramFileName
        TextBox1.Lines = LineContent
        TextBox1.Update()    'Refresh()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OdarTec3Axes.myText.Clear()
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim objReader As New StreamReader(OpenFileDialog1.FileName)
            ProgramFileName = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
            Do
                OdarTec3Axes.sLine = objReader.ReadLine()
                If Not OdarTec3Axes.sLine Is Nothing Then
                    OdarTec3Axes.myText.Add(OdarTec3Axes.sLine)
                End If
            Loop Until OdarTec3Axes.sLine Is Nothing
            objReader.Close()
        End If
        actualizeDisplayLines()
    End Sub

    ''' <summary>
    ''' Handles the Click event of the Button_Auto control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub Button_Auto_Click(sender As Object, e As EventArgs) Handles Button_Auto.Click

        SerPo_Machine.Close()
        m_SP.m_Program = OdarTec3Axes.myText
        Try
            ' Einen Thread fuer Shared Sub Thread1 anlegen 
            m_SP.setComPortName(m_COMPortName)
            m_T1 = New Thread(AddressOf m_SP.SendProgram)
            m_T1.SetApartmentState(ApartmentState.STA)
            ' Die Thread-Priorität festlegen 
            m_T1.Priority = ThreadPriority.Normal
            ' Den Thread starten 
            m_T1.Start()
            ' Neben den beiden gestarteten Threads zur Demonstration 
            ' auch an dieser Stelle weiter nebenläufigen Code aus- 
            ' führen: 

        Catch exc As Exception
            MsgBox(exc.ToString)
        End Try
    End Sub


    Private Sub Button_StepMinusY_Click(sender As Object, e As EventArgs) Handles Bu_StepMinusY.Click

        ' Inkremetal step Y-

        StateOfMachine = "Busy"
        If (SerPo_Machine.IsOpen <> True) Then
            Reconnect()
        End If
        If (SerPo_Machine.IsOpen = True) Then
            Dim strBuffer As String
            Dim strStepsXYZ() As String
            SerPo_Machine.ReadExisting()

            If ((OdarTec3Axes.A.Y - ISteps) >= 0) Then
                If (SerPo_Machine.IsOpen = True) Then
                    SerPo_Machine.WriteLine("cmdProgramExecute")

                    'Wait until machine is ready to receive data

                    Do While (SerPo_Machine.ReadExisting()).Contains(Chr(37)) <> True
                    Loop

                    'Step sequence

                    SerPo_Machine.WriteLine("G1 Y" + CStr(OdarTec3Axes.A.Y - ISteps) + " F" + CStr(TraBa_FeedRate.Value))

                    Do While (1)
                        strBuffer = SerPo_Machine.ReadLine()
                        If (strBuffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                    Loop
                    SerPo_Machine.WriteLine("M02")
                    Do While (1)
                        strBuffer = SerPo_Machine.ReadLine()
                        If (strBuffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                        strStepsXYZ = strBuffer.Split(",")
                        OdarTec3Axes.A.X = MMProStep(0) * CInt(Val(strStepsXYZ(0)))
                        OdarTec3Axes.A.Y = MMProStep(1) * CInt(Val(strStepsXYZ(1)))
                        OdarTec3Axes.A.Z = MMProStep(2) * CInt(Val(strStepsXYZ(2)))
                        actualizeDisplayLines()
                    Loop
                End If
            End If
        End If
        StateOfMachine = "Ready"
    End Sub

    Private Sub Button_Stop_Click(sender As Object, e As EventArgs) Handles Button_Stop.Click

        SP.Stopp = True

    End Sub

    Public Sub Reconnect()

        SerPo_Machine.PortName = m_ComPortName
        SerPo_Machine.BaudRate = 57600
        SerPo_Machine.Parity = System.IO.Ports.Parity.None
        SerPo_Machine.DataBits = 8
        SerPo_Machine.StopBits = 1
        SerPo_Machine.Handshake = System.IO.Ports.Handshake.None
        SerPo_Machine.Encoding = System.Text.Encoding.ASCII
        SerPo_Machine.ReadBufferSize = 600
        SerPo_Machine.WriteBufferSize = 600
        SerPo_Machine.ReadTimeout = 200000
        SerPo_Machine.WriteTimeout = 200000
        Try
            SerPo_Machine.Open()
        Catch ex As Exception
            MsgBox("Can't open the COM port" & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub Button_StepPlusZ_Click(sender As Object, e As EventArgs) Handles Bu_StepPlusZ.Click

        ' Inkremetal step Z+

        StateOfMachine = "Busy"
        If (SerPo_Machine.IsOpen <> True) Then
            Reconnect()
        End If
        If (SerPo_Machine.IsOpen = True) Then
            Dim strBuffer As String
            Dim strStepsXYZ() As String
            SerPo_Machine.ReadExisting()

            If ((OdarTec3Axes.A.Z + ISteps) <= 165) Then
                If (SerPo_Machine.IsOpen = True) Then
                    SerPo_Machine.WriteLine("cmdProgramExecute")

                    'Wait until machine is ready to receive data

                    Do While (SerPo_Machine.ReadExisting()).Contains(Chr(37)) <> True
                    Loop

                    'Step sequence

                    SerPo_Machine.WriteLine("G1 Z" + CStr(OdarTec3Axes.A.Z + ISteps) + " F" + CStr(TraBa_FeedRate.Value))

                    Do While (1)
                        strBuffer = SerPo_Machine.ReadLine()
                        If (strBuffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                    Loop
                    SerPo_Machine.WriteLine("M02")
                    Do While (1)
                        strBuffer = SerPo_Machine.ReadLine()
                        If (strBuffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                        strStepsXYZ = strBuffer.Split(",")
                        OdarTec3Axes.A.X = MMProStep(0) * CInt(Val(strStepsXYZ(0)))
                        OdarTec3Axes.A.Y = MMProStep(1) * CInt(Val(strStepsXYZ(1)))
                        OdarTec3Axes.A.Z = MMProStep(2) * CInt(Val(strStepsXYZ(2)))
                        actualizeDisplayLines()
                    Loop
                End If
            End If
        End If
        StateOfMachine = "Ready"
    End Sub

    Private Sub Button_StepMinusZ_Click(sender As Object, e As EventArgs) Handles Bu_StepMinusZ.Click

        ' Inkremetal step Z-

        StateOfMachine = "Busy"
        If (SerPo_Machine.IsOpen <> True) Then
            Reconnect()
        End If
        If (SerPo_Machine.IsOpen = True) Then
            Dim strBuffer As String
            Dim strStepsXYZ() As String
            SerPo_Machine.ReadExisting()

            If ((OdarTec3Axes.A.Z - ISteps) >= 0) Then
                If (SerPo_Machine.IsOpen = True) Then
                    SerPo_Machine.WriteLine("cmdProgramExecute")

                    'Wait until machine is ready to receive data

                    Do While (SerPo_Machine.ReadExisting()).Contains(Chr(37)) <> True
                    Loop

                    'Step sequence

                    SerPo_Machine.WriteLine("G1 Z" + CStr(OdarTec3Axes.A.Z - ISteps) + " F" + CStr(TraBa_FeedRate.Value))

                    Do While (1)
                        strBuffer = SerPo_Machine.ReadLine()
                        If (strBuffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                    Loop
                    SerPo_Machine.WriteLine("M02")
                    Do While (1)
                        strBuffer = SerPo_Machine.ReadLine()
                        If (strBuffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                        strStepsXYZ = strBuffer.Split(",")
                        OdarTec3Axes.A.X = MMProStep(0) * CInt(Val(strStepsXYZ(0)))
                        OdarTec3Axes.A.Y = MMProStep(1) * CInt(Val(strStepsXYZ(1)))
                        OdarTec3Axes.A.Z = MMProStep(2) * CInt(Val(strStepsXYZ(2)))
                        actualizeDisplayLines()
                    Loop
                End If
            End If
        End If

        StateOfMachine = "Ready"

    End Sub

    Private Sub Bu_SpindleOn_Click(sender As Object, e As EventArgs) Handles Bu_SpindleOn.Click

        '----- Spindel on -----

        StateOfMachine = "Busy"
        If (SerPo_Machine.IsOpen <> True) Then
            Reconnect()
        End If
        If (SerPo_Machine.IsOpen = True) Then
            Dim strBuffer As String
            Dim strStepsXYZ() As String


            SerPo_Machine.ReadExisting()

            If (SerPo_Machine.IsOpen = True) Then
                SerPo_Machine.WriteLine("cmdProgramExecute")

                '----- Wait until machine is ready to receive data -----

                Do While (SerPo_Machine.ReadExisting()).Contains(Chr(37)) <> True
                Loop

                '----- Send command -----

                SerPo_Machine.WriteLine("M03")

                Do While (1)
                    strBuffer = SerPo_Machine.ReadLine()
                    If (strBuffer.Contains(Chr(37))) Then
                        Exit Do
                    End If
                Loop

                SerPo_Machine.WriteLine("M02")
                Do While (1)
                    strBuffer = SerPo_Machine.ReadLine()
                    If (strBuffer.Contains(Chr(37))) Then
                        Exit Do
                    End If
                    strStepsXYZ = strBuffer.Split(",")
                    OdarTec3Axes.A.X = MMProStep(0) * CInt(Val(strStepsXYZ(0)))
                    OdarTec3Axes.A.Y = MMProStep(1) * CInt(Val(strStepsXYZ(1)))
                    OdarTec3Axes.A.Z = MMProStep(2) * CInt(Val(strStepsXYZ(2)))
                    actualizeDisplayLines()
                Loop
            End If
        End If
        StateOfMachine = "Ready"
    End Sub

    Private Sub Button_SpindleOff_Click(sender As Object, e As EventArgs) Handles Bu_SpindleOff.Click

        '----- Spindel off -----

        StateOfMachine = "Busy"
        If (SerPo_Machine.IsOpen <> True) Then
            Reconnect()
        End If
        If (SerPo_Machine.IsOpen = True) Then
            Dim strBuffer As String
            Dim strStepsXYZ() As String


            SerPo_Machine.ReadExisting()

            If (SerPo_Machine.IsOpen = True) Then
                SerPo_Machine.WriteLine("cmdProgramExecute")

                '----- Wait until machine is ready to receive data -----

                Do While (SerPo_Machine.ReadExisting()).Contains(Chr(37)) <> True
                Loop

                '----- Send command -----

                SerPo_Machine.WriteLine("M05")

                Do While (1)
                    strBuffer = SerPo_Machine.ReadLine()
                    If (strBuffer.Contains(Chr(37))) Then
                        Exit Do
                    End If
                Loop

                SerPo_Machine.WriteLine("M02")
                Do While (1)
                    strBuffer = SerPo_Machine.ReadLine()
                    If (strBuffer.Contains(Chr(37))) Then
                        Exit Do
                    End If
                    strStepsXYZ = strBuffer.Split(",")
                    OdarTec3Axes.A.X = MMProStep(0) * CInt(Val(strStepsXYZ(0)))
                    OdarTec3Axes.A.Y = MMProStep(1) * CInt(Val(strStepsXYZ(1)))
                    OdarTec3Axes.A.Z = MMProStep(2) * CInt(Val(strStepsXYZ(2)))
                    actualizeDisplayLines()
                Loop
            End If
        End If
        StateOfMachine = "Ready"
    End Sub

    Private Sub Bu_SetLaser_Click(sender As Object, e As EventArgs) Handles Bu_SetLaser.Click

        '----- Spindel on -----

        StateOfMachine = "Busy"
        If (SerPo_Machine.IsOpen <> True) Then
            Reconnect()
        End If
        If (SerPo_Machine.IsOpen = True) Then
            Dim strBuffer As String
            Dim strStepsXYZ() As String


            SerPo_Machine.ReadExisting()

            If (SerPo_Machine.IsOpen = True) Then
                SerPo_Machine.WriteLine("cmdProgramExecute")

                '----- Wait until machine is ready to receive data -----

                Do While (SerPo_Machine.ReadExisting()).Contains(Chr(37)) <> True
                Loop

                '----- Send command -----

                SerPo_Machine.WriteLine("G05 F0010")

                Do While (1)
                    strBuffer = SerPo_Machine.ReadLine()
                    If (strBuffer.Contains(Chr(37))) Then
                        Exit Do
                    End If
                Loop

                SerPo_Machine.WriteLine("M07")

                Do While (1)
                    strBuffer = SerPo_Machine.ReadLine()
                    If (strBuffer.Contains(Chr(37))) Then
                        Exit Do
                    End If
                Loop

                SerPo_Machine.WriteLine("M02")
                Do While (1)
                    strBuffer = SerPo_Machine.ReadLine()
                    If (strBuffer.Contains(Chr(37))) Then
                        Exit Do
                    End If
                    strStepsXYZ = strBuffer.Split(",")
                    OdarTec3Axes.A.X = MMProStep(0) * CInt(Val(strStepsXYZ(0)))
                    OdarTec3Axes.A.Y = MMProStep(1) * CInt(Val(strStepsXYZ(1)))
                    OdarTec3Axes.A.Z = MMProStep(2) * CInt(Val(strStepsXYZ(2)))
                    actualizeDisplayLines()
                Loop
            End If
        End If
        StateOfMachine = "Ready"
    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TraBa_FeedRate.ValueChanged
        Label2.Text = CStr(TraBa_FeedRate.Value)
    End Sub

    ''' <summary>
    ''' Makes a step remote controlled.
    ''' </summary>
    ''' <param name="Direction">The direction.</param>
    ''' <param name="Stepsize">The stepsize.</param>
    ''' <param name="FeedRate">The feed rate.</param>
    Public Sub makeAStepRemoteControlled(ByVal Direction As String, ByVal Stepsize As Double, ByVal FeedRate As Double)

        NuUpDo_StepSize.Value = Stepsize
        TraBa_FeedRate.Value = FeedRate
        Select Case Direction
            Case "-X"
                Bu_StepMinusX.PerformClick()
            Case "+X"
                Bu_StepPlusX.PerformClick()
            Case "-Y"
                Bu_StepMinusY.PerformClick()
            Case "+Y"
                Bu_StepPlusY.PerformClick()
            Case "-Z"
                Bu_StepMinusZ.PerformClick()
            Case "+Z"
                Bu_StepPlusZ.PerformClick()
        End Select
        Do While StateOfMachine <> "Ready"

        Loop
    End Sub

    Public Sub switchSpindelOn()
        Bu_SpindleOn.PerformClick()
        Do While StateOfMachine <> "Ready"

        Loop
    End Sub

    Public Sub switchSpindelOff()
        Bu_SpindleOff.PerformClick()
        Do While StateOfMachine <> "Ready"

        Loop
    End Sub

    Private Sub getMachineInfo()

        ' Inkremetal step X-

        StateOfMachine = "Busy"
        If (SerPo_Machine.IsOpen <> True) Then
            Reconnect()
        End If
        If (SerPo_Machine.IsOpen = True) Then
            Dim strBuffer As String
            Dim strStepsXYZ() As String
            SerPo_Machine.ReadExisting()

            If ((OdarTec3Axes.A.X - ISteps) >= 0) Then
                If (SerPo_Machine.IsOpen = True) Then
                    SerPo_Machine.WriteLine("cmdProgramExecute")

                    'Wait until machine is ready to receive data

                    Do While (SerPo_Machine.ReadExisting()).Contains(Chr(37)) <> True
                    Loop

                    'Step sequence

                    SerPo_Machine.WriteLine("G1 X" + CStr(OdarTec3Axes.A.X - ISteps) + " F" + CStr(TraBa_FeedRate.Value))

                    Do While (1)
                        strBuffer = SerPo_Machine.ReadLine()
                        If (strBuffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                    Loop

                    SerPo_Machine.WriteLine("M02")
                    Do While (1)
                        strBuffer = SerPo_Machine.ReadLine()
                        If (strBuffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                        strStepsXYZ = strBuffer.Split(",")
                        OdarTec3Axes.A.X = MMProStep(0) * CInt(Val(strStepsXYZ(0)))
                        OdarTec3Axes.A.Y = MMProStep(1) * CInt(Val(strStepsXYZ(1)))
                        OdarTec3Axes.A.Z = MMProStep(2) * CInt(Val(strStepsXYZ(2)))
                        actualizeDisplayLines()
                    Loop
                End If
            End If
        End If
        StateOfMachine = "Ready"
    End Sub

    Private Sub Bu_Connect_Click(sender As Object, e As EventArgs) Handles Bu_Connect.Click

        'Connects to the choosen COM-port

        Dim strBuffer As String
        strBuffer = ""

        If (CoBo_COMPort.Text <> "" And CoBo_BaudRate.Text <> "" And CoBo_Parity.Text <> "" And CoBo_DataBits.Text <> "" And CoBo_StopBits.Text <> "" And CoBo_FlowControl.Text <> "") Then
            m_COMPortName = CoBo_COMPort.Text
            SerPo_Machine.PortName = m_COMPortName
            SerPo_Machine.BaudRate = CInt(CoBo_BaudRate.Text)
            SerPo_Machine.Parity = System.IO.Ports.Parity.None 'Me.ToolStripComboBox3.SelectedItem
            SerPo_Machine.DataBits = CInt(CoBo_DataBits.Text)
            SerPo_Machine.StopBits = CInt(CoBo_StopBits.Text)
            SerPo_Machine.Handshake = System.IO.Ports.Handshake.None 'Me.ToolStripComboBox6.SelectedItem
            SerPo_Machine.Encoding = System.Text.Encoding.ASCII
            SerPo_Machine.ReadBufferSize = 600
            SerPo_Machine.WriteBufferSize = 600
            SerPo_Machine.ReadTimeout = 200000
            SerPo_Machine.WriteTimeout = 200000
            Try
                SerPo_Machine.Open()
            Catch ex As Exception
                MsgBox("Can't open the COM port" & vbCrLf & ex.Message)
            End Try

            'Get the Interface of the machine

            If (SerPo_Machine.IsOpen = True) Then
                continuee = True
                SerPo_Machine.ReadExisting()
                SerPo_Machine.WriteLine("cmdGetDeviceInterface")
                Do While SerPo_Machine.BytesToRead = 0

                Loop
                strBuffer = SerPo_Machine.ReadLine()
                MachineDescription = strBuffer.Split("<")
                Commands = MachineDescription(1).Split(",")
                Model = MachineDescription(0).Split(",")
                Model(0) = Model(0).Remove(0, 1)
                Me.Text = Model(0)
            End If
            MMProStep(0) = CDbl(Model(2))   'Set the "MMProStep" for the x-axis
            MMProStep(1) = CDbl(Model(3))   'Set the "MMProStep" for the y-axis
            MMProStep(2) = CDbl(Model(4))   'Set the "MMProStep" for the z-axis
            Model(2) = Model(2).Replace(".", ",")
            NuUpDo_XAxisMMProStep.Value = CDbl(Model(2))
            MMProStep(0) = CDbl(Model(2))
            Model(3) = Model(3).Replace(".", ",")
            NuUpDo_YAxisMMProStep.Value = CDbl(Model(3))
            MMProStep(1) = CDbl(Model(3))
            Model(4) = Model(4).Replace(".", ",")
            NuUpDo_ZAxisMMProStep.Value = CDbl(Model(4))
            MMProStep(2) = CDbl(Model(4))

        Else
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            Dim response As MsgBoxResult
            msg = "Not all COM port settings are defined yet."   ' Define message.
            style = MsgBoxStyle.DefaultButton2 Or
               MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly
            title = "Not possible to connect to COM port"   ' Define title.
            ' Display message.
            response = MsgBox(msg, style, title)
        End If
    End Sub

    Public Sub Read()
        Dim strBuffer As String
        strBuffer = ""
        While Me.continuee
            Try
                strBuffer = SerPo_Machine.ReadExisting()
            Catch generatedExceptionName As TimeoutException
            End Try
            If strBuffer.Contains(Chr(37)) Then         ' %

#If DEBUG Then
                Console.WriteLine(strBuffer)
#End If
                readThread.Join()
            End If
        End While
    End Sub

    Private Sub CoBo_COMPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CoBo_COMPort.SelectedIndexChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GrouBo_AxesStepRatio.Enter

    End Sub

    Private Sub Button_Left_Click(sender As Object, e As EventArgs) Handles Button_Left.Click

    End Sub

    Private Sub TaPa_MachineConnection_Click(sender As Object, e As EventArgs) Handles TaPa_MachineConnection.Click

    End Sub

    Private Sub Button_Enter_Click(sender As Object, e As EventArgs) Handles Button_Enter.Click

    End Sub

    ''' <summary>
    ''' Handles the Click event of the Bu_LoadValuesFromMachine control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    Private Sub Bu_LoadValuesFromMachine_Click(sender As Object, e As EventArgs) Handles Bu_LoadValuesFromMachine.Click

        Dim strBuffer As String
        Dim SettingsPath As String
        Dim Reader As StreamReader

        '--- Initial settings ---

        SettingsPath = "D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\settings\" + Model(0) + ".txt"

        '--- Open the file and read the values

        If Model(0) <> "" And (SerPo_Machine.IsOpen = True) Then
            Try
                Reader = New StreamReader(SettingsPath)
                Reader.ReadLine()
                Reader.ReadLine()
                OdarTec3Axes.A.X = CDbl(Reader.ReadLine())
                OdarTec3Axes.A.Y = CDbl(Reader.ReadLine())
                OdarTec3Axes.A.Z = CDbl(Reader.ReadLine())
            Catch ex As Exception

            End Try

            SerPo_Machine.ReadExisting()

            SerPo_Machine.WriteLine("cmdProgramExecute")

            'Wait until machine is ready to receive data

            Do While (SerPo_Machine.ReadExisting()).Contains(Chr(37)) <> True
            Loop

            'Step sequence

            SerPo_Machine.WriteLine("G98 X" + CStr(OdarTec3Axes.A.X) + " Y" + CStr(OdarTec3Axes.A.Y) + " Z" + CStr(OdarTec3Axes.A.Z))

            Do While (1)
                strBuffer = SerPo_Machine.ReadLine()
                If (strBuffer.Contains(Chr(37))) Then
                    Exit Do
                End If
            Loop

            SerPo_Machine.WriteLine("M02")
            Do While (1)
                strBuffer = SerPo_Machine.ReadLine()
                If (strBuffer.Contains(Chr(37))) Then
                    Exit Do
                End If
                actualizeDisplayLines()
            Loop

        Else

        End If



    End Sub

    Private Sub MachineInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MachineInfoToolStripMenuItem.Click

        Dim Message As String
        Dim CommandBuffer As String
        Dim Caption As String

        '--- Initial settings ---

        CommandBuffer = ""

        '---

        Caption = "Maschineninfo"

        Try

            For i As Integer = 0 To Commands.Length - 1
                CommandBuffer += Commands(i) + vbNewLine
            Next

            Message = "Maschine:" + Model(0) + vbNewLine + "Firmwareversion: " + Model(1) + vbNewLine + "X-Achse mm / Step: " + Model(2) + vbNewLine + "Y-Achse mm / Step: " + Model(3) + vbNewLine + "Z-Achse mm / Step: " + Model(4) + vbNewLine + "Befehle: " + CommandBuffer

        Catch ex As Exception

            Message = "Es wurde keine Verbindung zur Maschine gefunden."

        End Try

        Dim Buttons As MessageBoxButtons = MessageBoxButtons.OK


        'Displays the MessageBox

        MessageBox.Show(Message, Caption, Buttons)


    End Sub

    Private Sub Bu_TakeOverAxesStepRatio_Click(sender As Object, e As EventArgs) Handles Bu_TakeOverAxesStepRatio.Click

        StateOfMachine = "Busy"
        If (SerPo_Machine.IsOpen <> True) Then
            Reconnect()
        End If
        If (SerPo_Machine.IsOpen = True) Then
            Dim strBuffer As String
            Dim strStepsXYZ() As String

            SerPo_Machine.ReadExisting()

            If (SerPo_Machine.IsOpen = True) Then
                SerPo_Machine.WriteLine("cmdProgramExecute")

                'Wait until machine is ready to receive data

                Do While (SerPo_Machine.ReadExisting()).Contains(Chr(37)) <> True
                Loop

                'Send mm / step - values to machine

                SerPo_Machine.WriteLine("G99 X" + CStr(NuUpDo_XAxisMMProStep.Value) + " Y" + CStr(NuUpDo_YAxisMMProStep.Value) + " Z" + CStr(NuUpDo_ZAxisMMProStep.Value))

                Do While (1)
                    strBuffer = SerPo_Machine.ReadLine()
                    If (strBuffer.Contains(Chr(37))) Then
                        Exit Do
                    End If
                Loop

                SerPo_Machine.WriteLine("M02")
                Do While (1)
                    strBuffer = SerPo_Machine.ReadLine()
                    If (strBuffer.Contains(Chr(37))) Then
                        Exit Do
                    End If

                    MMProStep(0) = NuUpDo_XAxisMMProStep.Value
                    MMProStep(1) = NuUpDo_YAxisMMProStep.Value
                    MMProStep(2) = NuUpDo_ZAxisMMProStep.Value

                Loop
            Else

                NuUpDo_XAxisMMProStep.Value = MMProStepOld(0)
                NuUpDo_YAxisMMProStep.Value = MMProStepOld(1)
                NuUpDo_ZAxisMMProStep.Value = MMProStepOld(2)

            End If
        End If
        StateOfMachine = "Ready"

    End Sub

    Private Sub NuUpDo_XAxisMMProStep_ValueChanged(sender As Object, e As EventArgs) Handles NuUpDo_XAxisMMProStep.ValueChanged
        MMProStepOld(0) = NuUpDo_XAxisMMProStep.Value
    End Sub

    Private Sub NuUpDo_YAxisMMProStep_ValueChanged(sender As Object, e As EventArgs) Handles NuUpDo_YAxisMMProStep.ValueChanged
        MMProStepOld(1) = NuUpDo_YAxisMMProStep.Value
    End Sub

    Private Sub NuUpDo_ZAxisMMProStep_ValueChanged(sender As Object, e As EventArgs) Handles NuUpDo_ZAxisMMProStep.ValueChanged
        MMProStepOld(2) = NuUpDo_ZAxisMMProStep.Value
    End Sub

    Private Sub NuUpDo_Axis4AxisMMProStep_ValueChanged(sender As Object, e As EventArgs) Handles NuUpDo_Axis4MMProStep.ValueChanged
        MMProStepOld(3) = NuUpDo_Axis4MMProStep.Value
    End Sub

    Private Sub NuUpDo_Axis5AxisMMProStep_ValueChanged(sender As Object, e As EventArgs) Handles NuUpDo_Axis5MMProStep.ValueChanged
        MMProStepOld(4) = NuUpDo_Axis5MMProStep.Value
    End Sub
End Class