Option Explicit On
Option Infer Off

Public Class cCam3D
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
    Private m_Advance1 As Double
    Private m_Advance2 As Double
    Private m_Advance3 As Double
    Public m_FeedRate As Integer
    Public m_CamPathArray() As cSimplePoint = New cSimplePoint() {}
    Public m_CamContourGroundPlaneDepthValue As Double
    Public m_CamContour(0, 0) As Double
    Public m_UpperRightBorderPoint As New cSimplePoint()
    Public m_LowerLeftBorderPoint As New cSimplePoint()
    Private m_PreviewSignal As Boolean
    Private m_HeighestPoint As Double                                                   ' The heighest contour point to calculate the retract heights from

    ' Member that describes the infeeds and feedrates

    Private m_SideStepSizeRough As Double                                           ' Stepsize for roughing in the direction perpendiculare to the main machining direction
    Private m_SideStepSizeFine As Double                                             ' Stepsize for finishing in the direction perpendiculare to the main machining direction
    Private m_RoughMachiningInfeedGround As Double                           ' The cutting depth during the rough machining steps
    Private m_FineCuts As Integer                                                           ' Amount of steps with the fine machining offset
    Private m_FineMachiningOffset As Double                                         ' The cutting depth during the fine machining steps
    Private m_FinalCuts As Integer                                                          ' Amount of final machining steps where the offset is 0
    Private m_FeedRateRetractMove As Integer
    Private m_ForwardStepSize As Double

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

    Public Property SideStepSizeRough() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_SideStepSizeRough
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_SideStepSizeRough = Value
        End Set
    End Property

    Public Property SideStepSizeFine() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_SideStepSizeFine
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_SideStepSizeFine = Value
        End Set
    End Property

    Public Property ForwardStepSize() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ForwardStepSize
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ForwardStepSize = Value
        End Set
    End Property

    Public Property PreviewSignal() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PreviewSignal
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_PreviewSignal = Value
        End Set
    End Property

    Public Property RoughMachiningInfeedGround() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_RoughMachiningInfeedGround
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_RoughMachiningInfeedGround = Value
        End Set
    End Property

    Public Property HeighestPoint() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_HeighestPoint
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_HeighestPoint = Value
        End Set
    End Property

    Public Property FineCuts() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_FineCuts
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_FineCuts = Value
        End Set
    End Property

    Public Property FineMachiningOffset() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_FineMachiningOffset
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_FineMachiningOffset = Value
        End Set
    End Property

    Public Property FinalCuts() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_FinalCuts
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_FinalCuts = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----

    Public Function calculateCamPath() As Boolean

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
        Dim BufferPoint1, BufferPoint2 As New cPoint
        Dim MainLookAtDirection As New cSimplePoint
        Dim ToolOutlineSpacing As Double
        Dim ToolOutline(0) As cSimplePoint
        Dim CamContourSpacing As Double
        Dim RasterizedTriangle(0, 0) As Double
        Dim IsInside As Boolean
        Dim StartIndexXY As New Point()
        Dim EndIndexXY As New Point()
        Dim Triangle(2) As cSimplePoint

        '----- Initial settings -----

        Triangle(0) = New cSimplePoint(0, 0, 0)
        Triangle(1) = New cSimplePoint(0, 0, 0)
        Triangle(2) = New cSimplePoint(0, 0, 0)
        m_ForwardStepSize = 0.2
        IsInside = False
        CamContourSpacing = 0.05
        MainLookAtDirection = New cSimplePoint(0, 0, -1)
        ToolOutlineSpacing = 0.05
        StartIndexXY = New Point(0, 0)
        HeighestPoint = m_LowerLeftBorderPoint.Z

        '--- 1. redim the "CamContour" according to the upper right and lower left border points and refine the "CamContourSpacing" to the ceiling value. Fill
        '        the array with 100000. ---

        ReDim m_CamContour(Math.Ceiling((m_UpperRightBorderPoint.X - m_LowerLeftBorderPoint.X) / CamContourSpacing),
                                        Math.Ceiling((m_UpperRightBorderPoint.Y - m_LowerLeftBorderPoint.Y) / CamContourSpacing))

        For y As Integer = 0 To m_CamContour.GetLength(1) - 1
            For x As Integer = 0 To m_CamContour.GetLength(0) - 1
                m_CamContour(x, y) = -100000
            Next
        Next

        '--- 2. Raster the "ToolOutline" ("ToolOutlineSpacing" will be updated to a value near by to divide the tool radius in even segments) ---

        Utilities.rasterARotationSymetricContourToContourArray(ToolOutline, Tool.ToolDiameter / 2, ToolOutlineSpacing)

#If DEBUG Then
        Console.WriteLine(ToolOutline.Length)
#End If

        '--- 3. Raster the Elements to be machined ---

        For x As Integer = 0 To CamElements.Item(1).m_PointArray.Length - 3 Step 3
#If DEBUG Then
            Console.WriteLine("Array length ")
            Console.WriteLine(CamElements.Item(1).m_PointArray.Length)
#End If

            ' Check if the triangle is partly inside the milling area border. If so than rasterize it.

            For y As Integer = 0 To 2
                If (CamElements.Item(1).m_PointArray(x + y).X > m_LowerLeftBorderPoint.X) And (CamElements.Item(1).m_PointArray(x + y).X < m_UpperRightBorderPoint.X) And (CamElements.Item(1).m_PointArray(x + y).Y > m_LowerLeftBorderPoint.Y) And (CamElements.Item(1).m_PointArray(x + y).Y < m_UpperRightBorderPoint.Y) Then
                    IsInside = True
                End If
                Triangle(y) = CamElements.Item(1).m_PointArray(x + y)
#If DEBUG Then
                Console.WriteLine("Triangle Z value  ")
                Console.WriteLine(Triangle(y).Z)
#End If
            Next
            If IsInside = True Then
                Utilities.rasterOneTriangleToBorderArray(RasterizedTriangle, m_LowerLeftBorderPoint, StartIndexXY, Triangle, CamContourSpacing, MainLookAtDirection)


                ' Put the "RasterizedTriangle" in the "m_CamContour". Doing this by checking if all the indices of "RasterizedTriangle" are inside the
                ' "CamContour" indices and set the "EndIndex" accordingly.

                If (StartIndexXY.X + RasterizedTriangle.GetLength(0) - 1) > m_CamContour.GetLength(0) Then ' Check the first index
                    EndIndexXY.X = m_CamContour.GetLength(0)
                Else
                    EndIndexXY.X = StartIndexXY.X + RasterizedTriangle.GetLength(0) - 1
                End If
                '---
                If (StartIndexXY.Y + RasterizedTriangle.GetLength(1) - 1) > m_CamContour.GetLength(1) Then ' Check the second index
                    EndIndexXY.Y = m_CamContour.GetLength(1)
                Else
                    EndIndexXY.Y = StartIndexXY.Y + RasterizedTriangle.GetLength(1) - 1
                End If
                '---
                For yy As Integer = StartIndexXY.Y To EndIndexXY.Y ' Transfer the "RasterizedTriangle" to the "CamContour"
                    For xx As Integer = StartIndexXY.X To EndIndexXY.X
                        If RasterizedTriangle(xx - StartIndexXY.X, yy - StartIndexXY.Y) > m_CamContour(xx, yy) Then
                            m_CamContour(xx, yy) = RasterizedTriangle(xx - StartIndexXY.X, yy - StartIndexXY.Y)
                            If m_CamContour(xx, yy) > HeighestPoint Then
                                HeighestPoint = m_CamContour(xx, yy)
                            End If
                        End If
#If DEBUG Then
                        'Console.WriteLine(RasterizedTriangle(xx - StartIndexXY.X, yy - StartIndexXY.Y))
#End If

                    Next
                Next
                '---
                IsInside = False ' Set it for the next loop
            End If
        Next

        '--- 4. Fill the non set array values with the z values of the bottom plane. ---

        For y As Integer = 0 To m_CamContour.GetLength(1) - 1
            For x As Integer = 0 To m_CamContour.GetLength(0) - 1
                If CInt(m_CamContour(x, y)) < m_LowerLeftBorderPoint.Z Then ' Value is not yet set
                    m_CamContour(x, y) = m_LowerLeftBorderPoint.Z
                End If
            Next
        Next

        '--- 5. Generate the tool path. ---

        Utilities.rasterA3DPathToCamPathArray(m_CamContour, CamContourSpacing, m_LowerLeftBorderPoint, ToolWorkRetractHeight, ToolStartStopRetractHeight, HeighestPoint, ToolOutline, ToolOutlineSpacing, m_CamPathArray, RoughMachiningInfeedGround, FineMachiningOffset, FineCuts, FinalCuts, SideStepSizeRough, SideStepSizeFine, ForwardStepSize, " ", m_CamContourGroundPlaneDepthValue)

        '--- 4. Complete the tool path ---

        completeCamPath() ' Does nothing in the moment

        Return True
    End Function

    Private Function completeCamPath() As Boolean

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
        'Return True

        ' Will be defined in the next step

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
