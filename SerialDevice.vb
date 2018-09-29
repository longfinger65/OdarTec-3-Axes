
Option Strict On
Option Explicit On
Option Infer Off

Imports System.IO.Ports
Imports System.Collections.Concurrent
Imports System.Threading

''' <summary>
''' Provides a wrapper for a SerialPort which automatically reads data from the port and processes it via assigned Func(Of Byte(), Integer, Integer) delegates.
''' Also provides "Send" methods for writing character, byte, hex, and string data to the port.
''' </summary>
''' <remarks></remarks>
Public Class SerialDevice

    '----- Begin constructors -----------------------------------------------

    Public Sub New(ByRef ToolLibrary As cToolManagement)

        m_DataQueue = New ConcurrentQueue(Of Byte)

        '----- Initial settings -----

    End Sub

    '----- End constructors, begin member Variables and constants -----------------------------

    Private WithEvents m_Port As SerialPort
    Private m_DataQueue As ConcurrentQueue(Of Byte)
    Private m_CancelSource As CancellationTokenSource
    Private m_Task As System.Threading.Tasks.Task
    Private m_Waiter As System.Threading.ManualResetEventSlim

    '----- Get and set properties -----

    Public Property Port() As SerialPort
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Port
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As SerialPort)
            m_Port = Value
        End Set
    End Property

    Public Property DataQueue() As ConcurrentQueue(Of Byte)
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_DataQueue
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As ConcurrentQueue(Of Byte))
            m_DataQueue = Value
        End Set
    End Property

    Public Property Task() As System.Threading.Tasks.Task
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Task
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As System.Threading.Tasks.Task)
            m_Task = Value
        End Set
    End Property

    Public Property CancelSource() As CancellationTokenSource
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CancelSource
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As CancellationTokenSource)
            m_CancelSource = Value
        End Set
    End Property

    Public Property Waiter() As System.Threading.ManualResetEventSlim
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Waiter
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As System.Threading.ManualResetEventSlim)
            m_Waiter = Value
        End Set
    End Property

    ''' <summary>
    ''' Gets a value determining if the serial port is open.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Connected As Boolean
        Get
            Return m_Port.IsOpen
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the COM Port name that the physical device is connected to, or virtual COM Port name created by the physical device.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ComPort As String
        Get
            Return m_Port.PortName
        End Get
        Set(value As String)
            m_Port.PortName = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value determining whether or not the serial port will use data-terminal-ready signals (default is False).
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DtrEnable As Boolean
        Get
            Return m_Port.DtrEnable
        End Get
        Set(value As Boolean)
            m_Port.DtrEnable = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the text encoding used to convert between character strings and byte data (default is ASCII).
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Encoding As System.Text.Encoding
        Get
            Return m_Port.Encoding
        End Get
        Set(value As System.Text.Encoding)
            m_Port.Encoding = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the string used to represent a line terminator (default CrLf).
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NewLine As String
        Get
            Return m_Port.NewLine
        End Get
        Set(value As String)
            m_Port.NewLine = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value specifying the baud rate to use.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Baud As Integer
        Get
            Return m_Port.BaudRate
        End Get
        Set(value As Integer)
            m_Port.BaudRate = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value specifying the data bits to use.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataBits As Integer
        Get
            Return m_Port.DataBits
        End Get
        Set(value As Integer)
            m_Port.DataBits = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value specifying the stop bits to use.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StopBits As StopBits
        Get
            Return m_Port.StopBits
        End Get
        Set(value As StopBits)
            m_Port.StopBits = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value specifying the parity to use.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Parity As Parity
        Get
            Return m_Port.Parity
        End Get
        Set(value As Parity)
            m_Port.Parity = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value specifying the hardware handshaking to use.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FlowControl As Handshake
        Get
            Return m_Port.Handshake
        End Get
        Set(value As Handshake)
            m_Port.Handshake = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets a value determining whether or not the serial port uses ready-to-send signals (default False).
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RtsEnable As Boolean
        Get
            Return m_Port.RtsEnable
        End Get
        Set(value As Boolean)
            m_Port.RtsEnable = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the processing mode. In ByteMode, the CheckMessageComplete delegate will be invoked for every byte received.
    ''' In BlockMode, available data will be read at once and sent to CheckMessageComplete in chunks, as available.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MessageMode As MessageProcessingMode

    ''' <summary>
    ''' Gets or sets a delegate function which will be called to determine if a complete message has been queued.
    ''' This function must return zero if the bytes received so far do not constitute a complete message, or a positive
    ''' integer value representing the number of bytes which make up the complete message.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <example>
    ''' The following example defines a simple check message delegate function and sets it
    ''' to the CheckMessageComplete property.
    ''' <code>
    ''' mySerialDevice.CheckMessageComplete = AddressOf(DoCheckMessage)
    '''
    ''' Function DoCheckMessage(data As Byte(), count As Integer) As Integer
    '''    '1) Determine if data contains complete message
    '''    '2) Return number of bytes in message if complete, or return 0 if not complete
    ''' End Function
    ''' </code>
    ''' </example>
    Public Property CheckMessageComplete As Func(Of Byte(), Integer, Integer)

    ''' <summary>
    ''' An optional Action(Of PortState, SerialError) delegate to be invoked when a serial port error occurs.
    ''' Only as reliable as the SerialPort.ErrorReceived event. See MSDN documentation for details.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ProcessError As Action(Of PortState, SerialError)
    ''' <summary>
    ''' A required Action(Of Byte(), Integer) delegate to be invoked when the CheckMessageComplete delegate call returns a positive value.
    ''' This delegate method performs the actual work of processing the message data received from the serial device.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ProcessMessage As Action(Of Byte(), Integer)
    ''' <summary>
    ''' An optional Action(Of PortState, SerialPinChange) delegate to be invokde when a serial pin change event occurs.
    ''' See the MSDN documentation for SerialPort.PinChanged event for more information.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ProcessPinChange As Action(Of PortState, SerialPinChange)

    ''' <summary>
    ''' Configures the serial port with the default baud rate (9800), 8 data bits, no parity, one stop bit, and no flow control.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ConfigurePort()
        ConfigurePort(CommonBaudRate.Default, 8, Parity.None, StopBits.One, Handshake.None)
    End Sub

    Public Sub ConfigurePort(baud As CommonBaudRate)
        ConfigurePort(CInt(baud), 8, Parity.None, StopBits.One, Handshake.None)
    End Sub

    Public Sub ConfigurePort(baud As Integer)
        ConfigurePort(baud, 8, Parity.None, StopBits.One, Handshake.None)
    End Sub

    Public Sub ConfigurePort(baud As CommonBaudRate, dataBits As Integer, parity As Parity, stopBits As StopBits, flowControl As Handshake)
        ConfigurePort(CInt(baud), dataBits, parity, stopBits, flowControl)
    End Sub

    Public Sub ConfigurePort(baud As Integer, dataBits As Integer, parity As Parity, stopBits As StopBits, flowControl As Handshake)
        Me.Baud = baud
        Me.DataBits = dataBits
        Me.FlowControl = flowControl
        Me.Parity = parity
        Me.StopBits = stopBits
    End Sub

    ''' <summary>
    ''' Creates a new instance of SerialDevice using the specified existing SerialPort instance.
    ''' </summary>
    ''' <param name="serialPort"></param>
    ''' <remarks></remarks>
    Public Sub New(serialPort As SerialPort)
        Port = serialPort
        ConfigurePort()
    End Sub

    ''' <summary>
    ''' Creates a new instance of SerialDevice with its own internal SerialPort.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Me.New(New SerialPort())
    End Sub

    ''' <summary>
    ''' Opens the SerialPort and connects to the physical device if the PortName, CheckMessageComplete delegate, and ProcessMessage delegate have all been specified.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Connect()
        If Task Is Nothing Then
            If String.IsNullOrEmpty(ComPort) Then Throw New InvalidOperationException("Cannot connect when COM Port is not specified.")
            If CheckMessageComplete Is Nothing Then Throw New InvalidOperationException("Cannot connect when no IsMessageComplete delegate has been specified.")
            If ProcessMessage Is Nothing Then Throw New InvalidOperationException("Cannot connect when no ProcessMessage delegate has been specified.")

            Port.Open()
            If Connected Then
                CancelSource = New CancellationTokenSource
                Waiter = New ManualResetEventSlim
                Task = System.Threading.Tasks.Task.Factory.StartNew(New Action(Of Object)(AddressOf ProcessData), _MessageMode, CancelSource.Token)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Ends processing of the SerialDevice and closes the underlying serial port.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Disconnect()
        If Task IsNot Nothing Then
            CancelSource.Cancel()
            Waiter.Set()
            Task.Wait()
            Port.Close()
            Task.Dispose()
            CancelSource.Dispose()
            Waiter.Dispose()
            Task = Nothing
            CancelSource = Nothing
            Waiter = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Sends a single character to the serial port.
    ''' </summary>
    ''' <param name="c"></param>
    ''' <remarks></remarks>
    Public Sub SendChar(c As Char)
        Port.Write({c}, 0, 1)
    End Sub

    ''' <summary>
    ''' Sends a byte or series of bytes to the serial port.
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <remarks></remarks>
    Public Sub SendData(ParamArray bytes() As Byte)
        If Connected Then
            Port.Write(bytes, 0, bytes.Length)
        Else
            MessageBox.Show("The port is not open.", "Not Connected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ''' <summary>
    ''' Sends a byte or series of bytes in hexadecimal format to the serial port.
    ''' </summary>
    ''' <param name="hexString"></param>
    ''' <remarks></remarks>
    Public Sub SendHex(hexString As String)
        hexString = hexString.Replace(" ", "").ToUpper
        If Not hexString.Length Mod 2 = 0 Then
            hexString = "0" & hexString
        End If
        Dim result(CInt(hexString.Length / 2) - 1) As Byte
        Dim delta As Byte
        For i As Integer = 0 To result.Length - 1
            If Byte.TryParse(hexString.Substring(i * 2, 2), Globalization.NumberStyles.AllowHexSpecifier, Nothing, delta) Then
                result(i) = delta
            Else
                Throw New ArgumentException("Invalid hex string.")
            End If
        Next
        SendData(result)
    End Sub

    ''' <summary>
    ''' Sends a string to the serial port using the current text encoding.
    ''' </summary>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Public Sub SendString(text As String)
        Port.Write(text)
    End Sub

    Private Sub _Port_DataReceived(sender As Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles m_Port.DataReceived
        Dim portRef As SerialPort = DirectCast(sender, SerialPort)
        Dim data(portRef.BytesToRead - 1) As Byte
        Dim count As Integer = portRef.Read(data, 0, data.Length)
        For i As Integer = 0 To count - 1
            DataQueue.Enqueue(data(i))
        Next
        Waiter.Set()
    End Sub

    Private Sub _Port_Disposed(sender As Object, e As System.EventArgs) Handles m_Port.Disposed
        CancelSource.Cancel()
    End Sub

    Private Sub _Port_ErrorReceived(sender As Object, e As System.IO.Ports.SerialErrorReceivedEventArgs) Handles m_Port.ErrorReceived
        If ProcessError IsNot Nothing Then
            _ProcessError(New PortState(Port), e.EventType)
        End If
    End Sub

    Private Sub _Port_PinChanged(sender As Object, e As System.IO.Ports.SerialPinChangedEventArgs) Handles m_Port.PinChanged
        If ProcessPinChange IsNot Nothing Then
            _ProcessPinChange(New PortState(Port), e.EventType)
        End If
    End Sub

    Protected Sub ProcessData(modeObj As Object)
        Dim mode As MessageProcessingMode = DirectCast(modeObj, MessageProcessingMode)
        Dim currentMessage As New List(Of Byte)
        Do While Not CancelSource.IsCancellationRequested
            Dim delta As Integer = currentMessage.Count
            Dim available As Integer = DataQueue.Count
            If available > 0 Then
                Dim b As Byte
                If mode = MessageProcessingMode.ByteMode Then
                    If DataQueue.TryDequeue(b) Then
                        currentMessage.Add(b)
                        CheckAndProcess(currentMessage)
                    End If
                ElseIf mode = MessageProcessingMode.BlockMode Then
                    While available > 0
                        If DataQueue.TryDequeue(b) Then
                            currentMessage.Add(b)
                            available -= 1
                        End If
                    End While
                    If Not delta = currentMessage.Count Then
                        CheckAndProcess(currentMessage)
                    End If
                End If
            Else
                Waiter.Wait()
                Waiter.Reset()
            End If
        Loop
    End Sub

    Protected Sub CheckAndProcess(currentMessage As List(Of Byte))
        Dim removeCount As Integer = _CheckMessageComplete(currentMessage.ToArray, currentMessage.Count)
        If removeCount > 0 Then
            _ProcessMessage(currentMessage.Take(removeCount).ToArray, removeCount)
            currentMessage.RemoveRange(0, removeCount)
        End If
    End Sub
End Class

''' <summary>
''' Provides information about the state of a serial port.
''' </summary>
''' <remarks></remarks>
Public Structure PortState
    Public ReadOnly BreakState As Boolean
    Public ReadOnly CDHolding As Boolean
    Public ReadOnly CTSHolding As Boolean
    Public ReadOnly DSRHolding As Boolean
    Public ReadOnly IsOpen As Boolean

    Public Sub New(port As SerialPort)
        BreakState = port.BreakState
        CDHolding = port.CDHolding
        CTSHolding = port.CtsHolding
        DSRHolding = port.DsrHolding
        IsOpen = port.IsOpen
    End Sub
End Structure

''' <summary>
''' Provides a list of common serial baud rates.
''' </summary>
''' <remarks></remarks>
Public Enum CommonBaudRate
    [Default] = 9600
    bps2400 = 2400
    bps4800 = 4800
    bps9600 = 9600
    bps14400 = 14400
    bps19200 = 19200
    bps28800 = 28800
    bps38400 = 38400
    bps57600 = 57600
    bps115200 = 115200
End Enum

''' <summary>
''' Specifies the processing mode for messages.
''' </summary>
''' <remarks></remarks>
Public Enum MessageProcessingMode
    ''' <summary>
    ''' The CheckMessageComplete delegate will be invoked for every byte received.
    ''' </summary>
    ''' <remarks></remarks>
    ByteMode
    ''' <summary>
    ''' The CheckMessageComplete delegate will be invoked after all available data is read on each data received event.
    ''' </summary>
    ''' <remarks></remarks>
    BlockMode
End Enum

