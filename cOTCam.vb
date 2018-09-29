Imports System.Runtime.InteropServices
Imports System.Threading

Public Class cOTCam

    Public Sub New(ByRef myList As ListBox, ByRef PicBo As PictureBox)

        lstDevices = myList
        picCapture = PicBo
        loadIt()

    End Sub


    Const WM_CAP As Short = &H400S
    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Public Const WM_CAP_GET_STATUS As Integer = WM_CAP + 54
    Public Const WM_CAP_DLG_VIDEOFORMAT As Integer = WM_CAP + 41
    Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1

    Private DeviceID As Integer = 0 ' Current device ID
    Public hHwnd As Integer ' Handle to preview window

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
        ByRef lParam As CAPSTATUS) As Boolean
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
       (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Boolean, _
       ByRef lParam As Integer) As Boolean
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
         (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
         ByRef lParam As Integer) As Boolean
    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, _
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean
    Structure POINTAPI
        Dim x As Integer
        Dim y As Integer
    End Structure

    Public lstDevices As ListBox
    Public picCapture As PictureBox

    Public Structure CAPSTATUS
        Dim uiImageWidth As Integer                    '// Width of the image
        Dim uiImageHeight As Integer                   '// Height of the image
        Dim fLiveWindow As Integer                     '// Now Previewing video?
        Dim fOverlayWindow As Integer                  '// Now Overlaying video?
        Dim fScale As Integer                          '// Scale image to client?
        Dim ptScroll As POINTAPI                    '// Scroll position
        Dim fUsingDefaultPalette As Integer            '// Using default driver palette?
        Dim fAudioHardware As Integer                  '// Audio hardware present?
        Dim fCapFileExists As Integer                  '// Does capture file exist?
        Dim dwCurrentVideoFrame As Integer             '// # of video frames cap'td
        Dim dwCurrentVideoFramesDropped As Integer     '// # of video frames dropped
        Dim dwCurrentWaveSamples As Integer            '// # of wave samples cap'td
        Dim dwCurrentTimeElapsedMS As Integer          '// Elapsed capture duration
        Dim hPalCurrent As Integer                     '// Current palette in use
        Dim fCapturingNow As Integer                   '// Capture in progress?
        Dim dwReturn As Integer                        '// Error value after any operation
        Dim wNumVideoAllocated As Integer              '// Actual number of video buffers
        Dim wNumAudioAllocated As Integer              '// Actual number of audio buffers
    End Structure

    Declare Function capCreateCaptureWindowA Lib "D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\avicap32.dll" _
         (ByVal lpszWindowName As String, ByVal dwStyle As Integer,
         ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer,
         ByVal nHeight As Short, ByVal hWndParent As Integer,
         ByVal nID As Integer) As Integer

    Declare Function capGetDriverDescriptionA Lib "D:\softwaredevelopement\3-Axis\software\PC programs\OdarTec 3-Axes\avicap32.dll" (ByVal wDriver As Short,
        ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String,
        ByVal cbVer As Integer) As Boolean

    '--- Begin properties ---

    '---Begin delegates ---

    '--- Begin functions ---

    Public Sub loadIt()
        LoadDeviceList()
        If lstDevices.Items.Count > 0 Then
            lstDevices.SelectedIndex = 0
            DeviceID = lstDevices.SelectedIndex
            OpenPreviewWindow()

        Else
            lstDevices.Items.Add("No Capture Device")
        End If
        'Me.AutoScrollMinSize = New Size(100, 100)
        picCapture.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub LoadDeviceList()
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim bReturn As Boolean
        Dim x As Short = 0
        ' 
        ' Load name of all avialable devices into the lstDevices
        '
        Do
            '
            'Get Driver name and version
            '
            bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
            '
            ' If there was a device add device name to the list
            '
            If bReturn Then lstDevices.Items.Add(strName.Trim)
            x += CType(1, Short)
        Loop Until bReturn = False
    End Sub

    Public Sub OpenPreviewWindow()
        Dim iHeight As Integer = picCapture.Height
        Dim iWidth As Integer = picCapture.Width
        '
        ' Open Preview window in picturebox
        '
        hHwnd = capCreateCaptureWindowA(DeviceID.ToString, WS_VISIBLE Or WS_CHILD, 0, 0, 1280, 1024, picCapture.Handle.ToInt32, 0)
        '
        ' Connect to device
        '
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, DeviceID, 0) Then
            '
            'Set the preview scale
            '
            SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)

            '
            'Set the preview rate in milliseconds
            '
            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)

            '
            'Start previewing the image from the camera
            '
            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)

            '
            ' Resize window to fit in picturebox
            '
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, picCapture.Width, picCapture.Height,
                    SWP_NOMOVE Or SWP_NOZORDER)


        Else
            '
            ' Error connecting to device close window
            ' 
            DestroyWindow(hHwnd)

        End If
    End Sub

    Public Sub takePicture()

        OpenPreviewWindow()

        Dim bReturn As Boolean
        Dim s As CAPSTATUS

        bReturn = SendMessage(hHwnd, WM_CAP_GET_STATUS, Marshal.SizeOf(s), s)
        Debug.WriteLine(String.Format("Video Size {0} x {1}", s.uiImageWidth, s.uiImageHeight))
    End Sub

    Public Sub startPreview()
        OpenPreviewWindow()
    End Sub

    Public Sub stopPreview()

        Try
            SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, DeviceID, 0)   'Disconnect from device
            DestroyWindow(hHwnd)                                                                          'Close window
        Catch
        End Try

    End Sub

    Public Sub SaveIt()

        Dim data As IDataObject
        Dim bmap As Bitmap

        'Copy image to clipboard
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

            'Get image from clipboard and convert it to a bitmap

            data = Clipboard.GetDataObject()
            If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then

                bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Bitmap)
                picCapture.BackgroundImage = bmap
                stopPreview()
                Trace.Assert(Not (bmap Is Nothing))
                Clipboard.Clear()
            End If
#If DEBUG Then
            Console.WriteLine("test")
#End If

    End Sub

    'Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    '    If btnStop.Enabled Then
    '        ClosePreviewWindow()
    '    End If
    'End Sub

    Public Sub getVideoFormat()
        'SendMessage(hHwnd, WM_CAP_DLG_VIDEOFORMAT, 0&, 0&)
    End Sub

End Class