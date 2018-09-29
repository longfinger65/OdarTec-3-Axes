Imports System.Threading

Public Class cProgramSendThread

    Public Sub New(myForm As MachinePanel)
        MachinePanel1 = myForm
        Stopp = False
        Line = ""
        m_MMProStep = 0.001
    End Sub 'NewNew

    Public m_Program As New ArrayList()
    Private m_Line As String
    Private m_Stopp As Boolean
    Private m_A As New cPoint()
    Public m_MachinePanel1 As MachinePanel
    Private m_MMProStep As Double
    Private m_ComPortName As String

    '----- Get and set properties -----

    Public Property Program() As ArrayList
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Program
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As ArrayList)
            m_Program = Value
        End Set
    End Property

    Public Property Line() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Line
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_Line = Value
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

    Public Property MachinePanel1() As MachinePanel
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_MachinePanel1
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As MachinePanel)
            m_MachinePanel1 = Value
        End Set
    End Property

    Public Property MMProStep() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_MMProStep
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_MMProStep = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----

    Public Sub SendProgram()

        OdarTec3Axes.MachinePanel.SerPo_Machine.PortName = m_ComPortName
        OdarTec3Axes.MachinePanel.SerPo_Machine.BaudRate = 57600
        OdarTec3Axes.MachinePanel.SerPo_Machine.Parity = System.IO.Ports.Parity.None
        OdarTec3Axes.MachinePanel.SerPo_Machine.DataBits = 8
        OdarTec3Axes.MachinePanel.SerPo_Machine.StopBits = 1
        OdarTec3Axes.MachinePanel.SerPo_Machine.Handshake = System.IO.Ports.Handshake.None
        OdarTec3Axes.MachinePanel.SerPo_Machine.Encoding = System.Text.Encoding.ASCII
        OdarTec3Axes.MachinePanel.SerPo_Machine.ReadBufferSize = 600
        OdarTec3Axes.MachinePanel.SerPo_Machine.WriteBufferSize = 600
        OdarTec3Axes.MachinePanel.SerPo_Machine.ReadTimeout = 200000
        OdarTec3Axes.MachinePanel.SerPo_Machine.WriteTimeout = 200000
        Try
            OdarTec3Axes.MachinePanel.SerPo_Machine.Open()
        Catch ex As Exception
            MsgBox("Can't open the COM port" & vbCrLf & ex.Message)
        End Try
        Dim Buffer As String = ""
        Dim StepsXYZ() As String
        Dim LineCount As Integer
        Dim LineContent6 As String = ""
        Dim LineContent7 As String = ""

        '----- Begin initial settings --------------------------------------

        LineCount = 0

        '----- End initial settings ---------------------------------

        OdarTec3Axes.MachinePanel.SerPo_Machine.ReadExisting()

        If (OdarTec3Axes.MachinePanel.SerPo_Machine.IsOpen = True) Then
            OdarTec3Axes.MachinePanel.SerPo_Machine.WriteLine("cmdProgramExecute")

            'Wait until machine is ready to receive data

            Do While (OdarTec3Axes.MachinePanel.SerPo_Machine.ReadExisting()).Contains(Chr(37)) <> True
            Loop
            'OdarTec3Axes.MachinePanel.SerPo_Machine.WriteLine("G1 X10 F2000\n")


            For Each Me.m_Line In m_Program
                LineCount += 1
                If (Stopp = False) Then
                    OdarTec3Axes.MachinePanel.SerPo_Machine.WriteLine(Line)
                    Do While (1)
                        Buffer = OdarTec3Axes.MachinePanel.SerPo_Machine.ReadLine()
                        If (Buffer.Contains(Chr(37))) Then
                            If (Buffer.Contains("=")) Then
                                LineContent6 = "Position out of range"
                                Stopp = True
                            End If
                            Exit Do
                        End If
                        StepsXYZ = Buffer.Split(",")
                        A.X = m_MMProStep * CInt(Val(StepsXYZ(0)))
                        A.Y = m_MMProStep * CInt(Val(StepsXYZ(1)))
                        A.Z = m_MMProStep * CInt(Val(StepsXYZ(2)))
                        LineContent7 = "N" + CStr(LineCount) + " " + Line
                        m_MachinePanel1.Invoke(m_MachinePanel1.m_myDelegate, New Object() {LineContent6, LineContent7, A.X, A.Y, A.Z})
                    Loop
                End If
                If Stopp = True Then
                    OdarTec3Axes.MachinePanel.SerPo_Machine.WriteLine("M05")
                    Do While (1)
                        Buffer = OdarTec3Axes.MachinePanel.SerPo_Machine.ReadLine()
                        If (Buffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                    Loop
                    OdarTec3Axes.MachinePanel.SerPo_Machine.WriteLine("G53")
                    Do While (1)
                        Buffer = OdarTec3Axes.MachinePanel.SerPo_Machine.ReadLine()
                        If (Buffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                    Loop
                    OdarTec3Axes.MachinePanel.SerPo_Machine.WriteLine("M02")
                    Do While (1)
                        Buffer = OdarTec3Axes.MachinePanel.SerPo_Machine.ReadLine()
                        If (Buffer.Contains(Chr(37))) Then
                            Exit Do
                        End If
                        StepsXYZ = Buffer.Split(",")
                        A.X = m_MMProStep * CInt(Val(StepsXYZ(0)))
                        A.Y = m_MMProStep * CInt(Val(StepsXYZ(1)))
                        A.Z = m_MMProStep * CInt(Val(StepsXYZ(2)))
                        LineContent7 = "N" + CStr(LineCount) + " " + Line
                        m_MachinePanel1.Invoke(m_MachinePanel1.m_myDelegate, New Object() {LineContent6, LineContent7, A.X, A.Y, A.Z})
                    Loop
                    Exit For
                End If
            Next
        End If
        Stopp = False
        OdarTec3Axes.MachinePanel.SerPo_Machine.Close()
        m_MachinePanel1.Invoke(m_MachinePanel1.m_myDelegate2, New Object() {})
    End Sub

    Public Sub setComPortName(ComPortName)
        m_ComPortName = ComPortName
    End Sub
End Class
