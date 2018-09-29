Imports System.Threading

Public Class cScanPreviewThread

    Public Sub New(myScanPropertyDialog As cOTCam)

        m_ScanCam = myScanPropertyDialog
        StoppPreview = False

    End Sub 'NewNew

    '--- Begin member variables ---

    Private m_StoppPreview As Boolean
    Public m_ScanCam As cOTCam

    '----- Begin properties -----

    Public Property StoppPreview() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_StoppPreview
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_StoppPreview = Value
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

    '----- End member variables and constants, begin member methodes -----

    Public Sub previewScanArea()

        '----- Begin initial settings --------------------------------------

        '----- End initial settings ---------------------------------

        Do While StoppPreview = False

            ScanCam.m_CamScanPropertyDialog.Invoke(ScanCam.m_myDelegate, New Object() {})
            ScanCam.m_CamScanPropertyDialog.Invoke(ScanCam.m_myDelegate2, New Object() {})



        Loop

    End Sub

End Class
