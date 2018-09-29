Option Explicit On
Option Infer Off

Public Class cCamFaceMilling
    Inherits cCamEntity

    '----- Constructor ----------------------------------------------------

    Public Sub New()

        '----- Initialization ----

        m_FaceMillingBorderPoint1 = New cSimplePoint()
        m_FaceMillingBorderPoint2 = New cSimplePoint()

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
    Private m_KindOfFaceMillingBorder As String
    Private m_FaceMillingBorderPoint1 As cSimplePoint
    Private m_FaceMillingBorderPoint2 As cSimplePoint
    Public m_CamPathArray() As cSimplePoint = New cSimplePoint() {}

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

    Public Property KindOfFaceMillingBorder() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_KindOfFaceMillingBorder
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_KindOfFaceMillingBorder = Value
        End Set
    End Property

    Public Property FaceMillingBorderPoint1() As cSimplePoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_FaceMillingBorderPoint1
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cSimplePoint)
            m_FaceMillingBorderPoint1 = Value
        End Set
    End Property

    Public Property FaceMillingBorderPoint2() As cSimplePoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_FaceMillingBorderPoint2
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cSimplePoint)
            m_FaceMillingBorderPoint2 = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----

    Public Function calculateFaceMillingPath() As Boolean

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

        Dim x, y, z, ZSteps As Integer
        Dim ActualZ, LastZStepSize As Double
        Dim BufferPoint1 As New cSimplePoint
        Dim StepIncrement As Double
        Dim AmountOfSteps As Double
        Dim Border_Y As Double
        Dim ArrayCount As Integer                       'To preserve the length of the m_CamPathArray

        '----- Initial settings -----

#If DEBUG Then
        Console.WriteLine(Origin.X)
        Console.WriteLine(Origin.Y)
        Console.WriteLine(Origin.Z)
#End If

        ReDim m_CamPathArray(2000)

        CamPath.Clear()
        LastZStepSize = (DepthOfCamEntity - GroundSteps * InfeedGround) Mod ZInfeed
        ZSteps = (DepthOfCamEntity - GroundSteps * InfeedGround) / ZInfeed
        If ZSteps * ZInfeed > (DepthOfCamEntity - GroundSteps * InfeedGround) Then
            ZSteps -= 1
        End If

        AmountOfSteps = 0

        BufferPoint1.X = FaceMillingBorderPoint1.X
        BufferPoint1.Y = FaceMillingBorderPoint1.Y
        BufferPoint1.Z = FaceMillingBorderPoint1.Z

        If FaceMillingBorderPoint1.X > FaceMillingBorderPoint2.X Then
            FaceMillingBorderPoint1.X = FaceMillingBorderPoint2.X
            FaceMillingBorderPoint2.X = BufferPoint1.X
        End If
        If FaceMillingBorderPoint1.Y > FaceMillingBorderPoint2.Y Then
            FaceMillingBorderPoint1.Y = FaceMillingBorderPoint2.Y
            FaceMillingBorderPoint2.Y = BufferPoint1.Y
        End If

        FaceMillingBorderPoint1.Y = FaceMillingBorderPoint1.Y - Tool.ToolDiameter / 2
        FaceMillingBorderPoint2.Y = FaceMillingBorderPoint2.Y + Tool.ToolDiameter / 2
        FaceMillingBorderPoint1.X = FaceMillingBorderPoint1.X - Tool.ToolDiameter / 2
        FaceMillingBorderPoint2.X = FaceMillingBorderPoint2.X + Tool.ToolDiameter / 2
        FaceMillingBorderPoint1.Z = Origin.Z
        FaceMillingBorderPoint2.Z = Origin.Z

        Border_Y = FaceMillingBorderPoint2.Y - FaceMillingBorderPoint1.Y

#If DEBUG Then
        Console.WriteLine(FaceMillingBorderPoint1.X)
        Console.WriteLine(FaceMillingBorderPoint1.Y)
        Console.WriteLine(FaceMillingBorderPoint1.Z)
        Console.WriteLine(FaceMillingBorderPoint2.X)
        Console.WriteLine(FaceMillingBorderPoint2.Y)
        Console.WriteLine(FaceMillingBorderPoint2.Z)
#End If

        '----- Calculate the step increment between path segments

        StepIncrement = Tool.ToolDiameter * ToolOverlap / 100

#If DEBUG Then
        Console.WriteLine(StepIncrement)
#End If

        If RadiusCorrection = "RL" Then
            m_CamPathArray(0) = New cSimplePoint(FaceMillingBorderPoint2.X, FaceMillingBorderPoint1.Y, StartPoint.Z + m_ToolStartStopRetractHeight, "Rapid")
            m_CamPathArray(1) = New cSimplePoint(FaceMillingBorderPoint2.X, FaceMillingBorderPoint1.Y, StartPoint.Z + m_ToolWorkRetractHeight, "Rapid")
            ArrayCount = 1

            ActualZ = ZInfeed
            For i As Integer = 1 To ZSteps

                'Add one milling loop

                While AmountOfSteps <= Border_Y

                    'Check if m_CamPathArray is big enough. If not than reserve 2000 new memory units but preserve the values in the old ones

                    If ArrayCount > m_CamPathArray.Length - 6 Then
                        ReDim Preserve m_CamPathArray(ArrayCount + 2000)
                    End If

                    '---

                    m_CamPathArray(ArrayCount) = New cSimplePoint(FaceMillingBorderPoint2.X, FaceMillingBorderPoint1.Y + AmountOfSteps, ActualZ, "InfeedGround")
                    ArrayCount += 1
                    m_CamPathArray(ArrayCount) = New cSimplePoint(FaceMillingBorderPoint1.X, FaceMillingBorderPoint1.Y + AmountOfSteps, ActualZ, "Work")
                    ArrayCount += 1
                    m_CamPathArray(ArrayCount) = New cSimplePoint(FaceMillingBorderPoint1.X, FaceMillingBorderPoint1.Y + AmountOfSteps, m_ToolWorkRetractHeight, "Rapid")
                    ArrayCount += 1
                    m_CamPathArray(ArrayCount) = New cSimplePoint(FaceMillingBorderPoint2.X, FaceMillingBorderPoint1.Y + AmountOfSteps + StepIncrement, m_ToolWorkRetractHeight, "Rapid")
                    ArrayCount += 1
                    AmountOfSteps = AmountOfSteps + StepIncrement
                End While
                m_CamPathArray(ArrayCount - 1).X = FaceMillingBorderPoint2.X
                m_CamPathArray(ArrayCount - 1).Y = FaceMillingBorderPoint1.Y
                ActualZ = ActualZ + ZInfeed
                AmountOfSteps = 0
            Next

            '--- If there is a last step before reaching the ground step height than do it

            ActualZ = ActualZ + LastZStepSize - ZInfeed
            While AmountOfSteps <= Border_Y

                'Check if m_CamPathArray is big enough. If not than reserve 2000 new memory units but preserve the values in the old ones

                If ArrayCount > m_CamPathArray.Length - 6 Then
                    ReDim Preserve m_CamPathArray(ArrayCount + 2000)
                End If

                '---
                m_CamPathArray(ArrayCount) = New cSimplePoint(FaceMillingBorderPoint2.X, FaceMillingBorderPoint1.Y + AmountOfSteps, ActualZ, "InfeedGround")
                ArrayCount += 1
                m_CamPathArray(ArrayCount) = New cSimplePoint(FaceMillingBorderPoint1.X, FaceMillingBorderPoint1.Y + AmountOfSteps, ActualZ, "Work")
                ArrayCount += 1
                m_CamPathArray(ArrayCount) = New cSimplePoint(FaceMillingBorderPoint1.X, FaceMillingBorderPoint1.Y + AmountOfSteps, m_ToolWorkRetractHeight, "Rapid")
                ArrayCount += 1
                m_CamPathArray(ArrayCount) = New cSimplePoint(FaceMillingBorderPoint2.X, FaceMillingBorderPoint1.Y + AmountOfSteps + StepIncrement, m_ToolWorkRetractHeight, "Rapid")
                ArrayCount += 1
                AmountOfSteps = AmountOfSteps + StepIncrement
            End While
            m_CamPathArray(ArrayCount - 1).X = FaceMillingBorderPoint2.X
            m_CamPathArray(ArrayCount - 1).Y = FaceMillingBorderPoint1.Y

            '--- Groundsteps ---

            ActualZ = ActualZ + InfeedGround
            For i As Integer = 1 To GroundSteps

                'Check if m_CamPathArray is big enough. If not than reserve 2000 new memory units but preserve the values in the old ones

                If ArrayCount > m_CamPathArray.Length - 6 Then
                    ReDim Preserve m_CamPathArray(ArrayCount + 2000)
                End If

                While AmountOfSteps <= Border_Y
                    m_CamPathArray(ArrayCount) = New cSimplePoint(FaceMillingBorderPoint2.X, FaceMillingBorderPoint1.Y + AmountOfSteps, ActualZ, "InfeedGround")
                    ArrayCount += 1
                    m_CamPathArray(ArrayCount) = New cSimplePoint(FaceMillingBorderPoint1.X, FaceMillingBorderPoint1.Y + AmountOfSteps, ActualZ, "Work")
                    ArrayCount += 1
                    m_CamPathArray(ArrayCount) = New cSimplePoint(FaceMillingBorderPoint1.X, FaceMillingBorderPoint1.Y + AmountOfSteps, m_ToolWorkRetractHeight, "Rapid")
                    ArrayCount += 1
                    m_CamPathArray(ArrayCount) = New cSimplePoint(FaceMillingBorderPoint2.X, FaceMillingBorderPoint1.Y + AmountOfSteps + StepIncrement, m_ToolWorkRetractHeight, "Rapid")
                    ArrayCount += 1
                    AmountOfSteps = AmountOfSteps + StepIncrement
                End While
                m_CamPathArray(ArrayCount - 1).X = FaceMillingBorderPoint2.X
                m_CamPathArray(ArrayCount - 1).Y = FaceMillingBorderPoint1.Y
                ActualZ = ActualZ + InfeedGround
                AmountOfSteps = 0
            Next

        Else

            '--- The code for RR goes here

        End If

        m_CamPathArray(ArrayCount) = New cSimplePoint(FaceMillingBorderPoint2.X, FaceMillingBorderPoint1.Y, m_ToolStartStopRetractHeight, "Rapid")

        '--- Make the m_CamPathArray only as long as valid points are avaylable

        ReDim Preserve m_CamPathArray(ArrayCount)

        '---

        Return True
    End Function

End Class
