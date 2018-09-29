Option Explicit On
Option Infer Off

Public Class cCamBore
    Inherits cCamEntity

    '----- Constructor ----------------------------------------------------

    Public Sub New()

        '----- Initialization ----

        Tool.ToolName = "nothing"
    End Sub

    Public Sub New(PathRecalculation As Boolean)

        Me.New()

        NeedsPathRecalculation = PathRecalculation
    End Sub


    '----- Member Variables and constants -----------------------------------------------

    Private m_PathNumber As Integer
    Private m_ZInfeed As Double
    Private m_Advance1 As Double
    Private m_Advance2 As Double
    Private m_Advance3 As Double
    Public m_FeedRate As Integer
    Public m_FeedRateRetractMove As Integer
 
    '----- Get and set properties -----

     Public Property PathNumber() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PathNumber
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_PathNumber = Value
        End Set
    End Property

    Public Property ZInfeed() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ZInfeed
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ZInfeed = Value
        End Set
    End Property

    Public Property Advance1() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Advance1
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_Advance1 = Value
        End Set
    End Property

    Public Property Advance2() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Advance2
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_Advance2 = Value
        End Set
    End Property

    Public Property Advance3() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Advance3
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_Advance3 = Value
        End Set
    End Property

    Public Property FeedRate() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_FeedRate
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_FeedRate = Value
        End Set
    End Property

    Public Property FeedRateRetractMove() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_FeedRateRetractMove
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_FeedRateRetractMove = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----

    Public Function calculateBorePath() As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose:  Makes the cam path (at the place where it is in CAD, without including
        '           the origin)
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim CamPathBuffer As New Collection
        Dim x, y, z, ZSteps As Integer
        Dim ActualZ, LastZStepSize As Double
        Dim BufferPoint1, BufferPoint2 As New cPoint

        '----- Initial settings -----

        CamPath.Clear()
        LastZStepSize = (DepthOfCamEntity Mod ZInfeed) * (-1)
        ZSteps = DepthOfCamEntity / ZInfeed
        If ZSteps * ZInfeed > DepthOfCamEntity Then
            ZSteps -= 1
        End If

        '-----

        CamPath.Clear()
        BufferPoint1.X = CamElements.Item(1).X
        BufferPoint1.Y = CamElements.Item(1).Y
        BufferPoint1.Z = CamElements.Item(1).Z + 50
        BufferPoint2.X = CamElements.Item(1).X
        BufferPoint2.Y = CamElements.Item(1).Y
        BufferPoint2.Z = CamElements.Item(1).Z + 5
        CamPath.Add(New cLine(BufferPoint1, BufferPoint2))
        CamPath.Item(CamPath.Count).CamDescription = "Rapid"
        BufferPoint1.X = CamElements.Item(1).X
        BufferPoint1.Y = CamElements.Item(1).Y
        BufferPoint1.Z = CamElements.Item(1).Z + 1
        CamPath.Add(New cLine(BufferPoint2, BufferPoint1))
        CamPath.Item(CamPath.Count).CamDescription = "Work"

        For x = 1 To CamElements.Count
            ActualZ = 0
            For y = 1 To ZSteps
                ActualZ += ZInfeed
                CamPath.Add(New cLine(BufferPoint1, CamElements.Item(x), "Work"))
                CamPath.Item(CamPath.Count).m_Z2 = ActualZ
                CamPath.Add(New cLine(CamElements.Item(x), BufferPoint1, "Retract"))
                CamPath.Item(CamPath.Count).m_Z1 = ActualZ
            Next

            '----- Last Z-step before ground -----

            ActualZ += LastZStepSize
            CamPath.Add(New cLine(BufferPoint1, CamElements.Item(x), "Work"))
            CamPath.Item(CamPath.Count).m_Z2 = ActualZ
            CamPath.Add(New cLine(CamElements.Item(x), BufferPoint1, "Retract"))
            CamPath.Item(CamPath.Count).m_Z1 = ActualZ

            '----- Move to next point -----

            If x < CamElements.Count Then
                BufferPoint2.X = BufferPoint1.X
                BufferPoint2.Y = BufferPoint1.Y
                BufferPoint2.Z = BufferPoint1.Z
                BufferPoint1.X = CamElements.Item(x + 1).X
                BufferPoint1.Y = CamElements.Item(x + 1).Y
                BufferPoint1.Z = CamElements.Item(x + 1).Z + 1
                CamPath.Add(New cLine(BufferPoint2, BufferPoint1, "Rapid"))
            End If
        Next
        BufferPoint2 = BufferPoint1
        BufferPoint2.Z = 50
        CamPath.Add(New cLine(BufferPoint1, BufferPoint2, "Rapid"))

        Return True
    End Function

    Public Function UpdateCamPath() As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose:  Is needed if path parameters that do not change the calculated path 
        '           are changed (like feed rates or step counts).
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Return True
    End Function

End Class
