Option Explicit On
Option Infer Off

Imports System.Runtime.InteropServices


Public Class cCamPocket
    Inherits cCamEntity

    '----- Begin description -----------------------------------------------------------


    '----- End description -------------------------------------------------------------

    '----- Constructor -----------------------------------------------------------------

    Public Sub New()

        m_SortedCamElements = New Collection()
        m_PocketOutline = New Collection()
        m_ToolOutline = New Collection()
        m_EnveloopLowerRight = New cPoint()
        m_EnveloopUpperLeft = New cPoint()

        '----- Initialization -----

    End Sub

    Public Sub New(PathRecalculation As Boolean)

        Me.New()

        NeedsPathRecalculation = PathRecalculation
    End Sub


    '----- Member Variables and constants ----------------------------------------------

    Private m_SortedCamElements As Collection
    Private m_PocketOutline As Collection
    Private m_ToolOutline As Collection
    Private m_PathNumber As Integer
    Private m_SideSteps As Integer
    Private m_InfeedSide As Double
    Private m_EnveloopUpperLeft As cPoint
    Private m_EnveloopLowerRight As cPoint
    Private m_PreviewSignal As Boolean
    Public m_CamPathArray() As cSimplePoint = New cSimplePoint() {}


    '----- Get and set properties -----


    Public Property SortedCamElements() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_SortedCamElements
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_SortedCamElements = Value
        End Set
    End Property

    Public Property PocketOutline() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PocketOutline
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_PocketOutline = Value
        End Set
    End Property

    Public Property ToolOutline() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolOutline
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_ToolOutline = Value
        End Set
    End Property

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

    Public Property SideSteps() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_SideSteps
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_SideSteps = Value
        End Set
    End Property

    Public Property InfeedSide() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_InfeedSide
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_InfeedSide = Value
        End Set
    End Property

    Public Property EnveloopUpperLeft() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_EnveloopUpperLeft
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_EnveloopUpperLeft = Value
        End Set
    End Property

    Public Property EnveloopLowerRight() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_EnveloopLowerRight
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_EnveloopLowerRight = Value
        End Set
    End Property

    Public Property PreviewSignal() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PreviewSignal
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_PreviewSignal = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----

    Public Function calculateMillingPath() As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Calulates the milling path
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        ' 1. Create the outline of the tool
        ' 2. Create the outline of the pocket
        ' 3. Find max and min of the enveloping rectangle
        ' 4. Evaluate that the choosen arbitrary start point is inside the pocket
        ' 5. Check if the whole tool is inside the pocket and if this is not the
        '    case try to move the start point according 
        ' 6. According to the radius correction (RL or RR) find the path along the
        '    border
        ' 7. Simplify the milling path
        '
        '----- End description ---------------------------------------------------------

        Dim dblX, dblY, dblMovedDeltaX, dblMovedDeltaY As Double
        Dim intDirectionCount, intPointCount, intX, intY, Z, zz, zzz, zzzz, intCount, intBorderCountRight, intBorderCountLeft, intBorderCountAbove, intBorderCountBeneeth As Integer
        Dim intPathCount As Integer
        Dim TanAlpha As Double
        Dim collToolOutlineMoved, collPartOfPocketOutline As New Collection
        Dim bolFreeToFindPathStart, bolFindPath As Boolean
        Dim strLastMoveDirection, strNewMoveDirection As String ' Up, Down, Left, Right
        Dim cptPathStart As New cPoint
        Dim cptMinimalDistanceFromPathStart As New cPoint
        Dim dblPoint1_X, dblPoint1_Y, dblPoint2_X, dblPoint2_Y, dblPoint3_X, dblPoint3_Y As Double
        Dim ActualClosedCamPathFragment As New Collection
        Dim Direction As Integer
        Dim Outline1Length, Outline2Length As Integer
        Dim Outline1X(1), Outline1Y(1), Outline2X(1), Outline2Y(1), Outline3X(1), Outline3Y(1) As Double
        Dim DistanceBetweenBorderPoints As Double 'Distance between border points
        Dim CircularBorder, RasteredBorder, RasteredBorderBuffer As New Collection
        Dim HorizontalRasterCount, VerticalRasterCount As Integer
        Dim LowerLeft As Point
        Dim RasterX, RasterY As Integer
        Dim RasteredBorderA(,) As Collection = New Collection(1, 1) {}
        Dim CantGo As Integer
        Dim ToolWorkRadius As Double = Tool.ToolDiameter / 2 + ToolRadiusCorrection
        'Dim Point2 As New cPoint


        '----- Initial settings -----

        'Point2.X = 0
        'Point2.Y = 0

        CantGo = 0
        dblPoint1_X = 0.0
        dblPoint1_Y = ToolWorkRadius
        ToolOutline.Add(New cPoint(dblPoint1_X, dblPoint1_Y))
        DistanceBetweenBorderPoints = 0.05
        CamPathCount = 0
        m_CamPath.Clear()

        '--- Check if there is only a single contour element of type circle. If it is so branche to the apropriate sub. ---

        If CamElements.Item(1).GetType = GetType(cCircle) Then

#If DEBUG Then
            Console.WriteLine(ToolWorkRadius)
            Console.WriteLine(ToolOverlap)
            Console.WriteLine(CamElements.Item(1).Radius)
#End If

            If m_RadiusCorrection = "RL" Then
                Utilities.createCircularPocketPathLines(m_CamPreview, m_CamPathArray, ToolWorkRadius * 2, ToolOverlap, CamElements.Item(1).Radius, m_PreviewSignal, "CounterClockWise")
            ElseIf m_RadiusCorrection = "RR" Then
                Utilities.createCircularPocketPathLines(m_CamPreview, m_CamPathArray, ToolWorkRadius * 2, ToolOverlap, CamElements.Item(1).Radius, m_PreviewSignal, "ClockWise")
            Else
                Utilities.createCircularPocketPathLines(m_CamPreview, m_CamPathArray, ToolWorkRadius * 2, ToolOverlap, CamElements.Item(1).Radius, m_PreviewSignal, "CounterClockWise")
            End If

            '--- Add center point coordinates to the path and/or preview elements ---

            If m_PreviewSignal = True Then
                For i As Integer = 1 To m_CamPreview.Count
                    Select Case m_CamPreview.Item(i).GetType
                        Case GetType(cLine)
                            m_CamPreview.Item(i).m_X1 += CamElements.Item(1).m_XC
                            m_CamPreview.Item(i).m_Y1 += CamElements.Item(1).m_YC
                            m_CamPreview.Item(i).m_X2 += CamElements.Item(1).m_XC
                            m_CamPreview.Item(i).m_Y2 += CamElements.Item(1).m_YC
                        Case GetType(cCircle)
                            m_CamPreview.Item(i).m_XC += CamElements.Item(1).m_XC
                            m_CamPreview.Item(i).m_YC += CamElements.Item(1).m_YC
                    End Select
                Next
            Else

                Dim BufferPoint As New cSimplePoint(0, 0)
                For i As Integer = 0 To m_CamPathArray.Length - 1
                    m_CamPathArray(i).X = m_CamPathArray(i).X + CamElements.Item(1).m_XC
                    m_CamPathArray(i).Y = m_CamPathArray(i).Y + CamElements.Item(1).m_YC
                Next
            End If

            '--- Set the start point of the tool to the center of the pocket (overwrite the values of CamPocket) ---

            StartPoint_X = CamElements.Item(1).m_XC
            StartPoint_Y = CamElements.Item(1).m_YC
            StartPoint_Z = CamElements.Item(1).m_ZC
        Else

            '----- 1. Create the outline of the tool ---------------------------------------

            Utilities.createCrirclarOutline(ToolOutline, ToolWorkRadius)

            '----- Add start coordinates to the tool --------------------------------------

            For intX = 1 To ToolOutline.Count
                collToolOutlineMoved.Add(New cPoint(ToolOutline.Item(intX).X + StartPoint.X, ToolOutline.Item(intX).Y + StartPoint.Y))
            Next

            ReDim Outline3X(collToolOutlineMoved.Count), Outline3Y(collToolOutlineMoved.Count)
            ReDim Outline1X(collToolOutlineMoved.Count), Outline1Y(collToolOutlineMoved.Count)

            For intX = 1 To collToolOutlineMoved.Count
                Outline3X(intX) = collToolOutlineMoved.Item(intX).X
                Outline3Y(intX) = collToolOutlineMoved.Item(intX).Y
            Next

            Outline1Length = collToolOutlineMoved.Count

            '----- End create tool outline ------------------------------------------------

            '----- 2. Create the outline of the pocket ------------------------------------

            Utilities.createContourList(CamElements, PocketOutline, DistanceBetweenBorderPoints)

            '----- 3. Find max and min of the enveloping rectangle -------------------------

#If DEBUG Then
            Console.WriteLine("3. Find max and min of the enveloping rectangle")
#End If

            EnveloopUpperLeft.X = PocketOutline.Item(1).X
            EnveloopUpperLeft.Y = PocketOutline.Item(1).Y
            EnveloopLowerRight.X = PocketOutline.Item(1).X
            EnveloopLowerRight.Y = PocketOutline.Item(1).Y

            For intX = 2 To PocketOutline.Count
                If PocketOutline.Item(intX).X < EnveloopUpperLeft.X Then
                    EnveloopUpperLeft.X = PocketOutline.Item(intX).X
                ElseIf PocketOutline.Item(intX).X > EnveloopLowerRight.X Then
                    EnveloopLowerRight.X = PocketOutline.Item(intX).X
                End If
                If PocketOutline.Item(intX).Y > EnveloopUpperLeft.Y Then
                    EnveloopUpperLeft.Y = PocketOutline.Item(intX).Y
                ElseIf PocketOutline.Item(intX).Y < EnveloopLowerRight.Y Then
                    EnveloopLowerRight.Y = PocketOutline.Item(intX).Y
                End If
            Next

            '----- 4. Raster the border of the pocket --------------------------------------

            HorizontalRasterCount = CInt((EnveloopLowerRight.X - EnveloopUpperLeft.X) / (2 * ToolWorkRadius + 0.5)) + 4
            VerticalRasterCount = CInt((EnveloopUpperLeft.Y - EnveloopLowerRight.Y) / (2 * ToolWorkRadius + 0.5)) + 4
            ReDim RasteredBorderA(HorizontalRasterCount, VerticalRasterCount)
            For intX = 0 To HorizontalRasterCount
                For intY = 0 To VerticalRasterCount
                    RasteredBorderA(intX, intY) = New Collection
                Next
            Next

#If DEBUG Then
            Console.WriteLine(HorizontalRasterCount)
            Console.WriteLine(VerticalRasterCount)
#End If

            Utilities.rasterTheBorder(RasteredBorderA, PocketOutline, EnveloopUpperLeft.X, EnveloopLowerRight.Y, ToolWorkRadius, HorizontalRasterCount, VerticalRasterCount)

            '----- 4. Evaluate that the choosen arbitrary start point is inside the pocket -

            'Console.WriteLine("4. Evaluate that the choosen arbitrary start point is inside the pocket")

            'intBorderCountRight = 0
            'intBorderCountLeft = 0
            'intBorderCountAbove = 0
            'intBorderCountBeneeth = 0

            ''----- Find Borders right of the start point -------------------------------

            'ptPoint1.Y = Math.Round(StartPoint.Y, 1)

            'For dblX = Math.Round(StartPoint.X, 1) To dbl_EnveloopLowerRight.X Step 0.1

            '    For intX = 1 To PocketOutline.Count
            '        If PocketOutline.Item(intX).X = dblX And PocketOutline.Item(intX).Y = ptPoint1.Y Then
            '            intBorderCountRight += 1
            '            Console.WriteLine("Border count right = ")
            '            Console.Write(intBorderCountRight)
            '        End If
            '    Next
            'Next

            ''----- Find Borders left of the start point -------------------------------

            'For dblX = dbl_EnveloopUpperLeft.X To Math.Round(StartPoint.X, 1) Step 0.1

            '    For intX = 1 To PocketOutline.Count
            '        If PocketOutline.Item(intX).X = dblX And PocketOutline.Item(intX).Y = ptPoint1.Y Then
            '            intBorderCountLeft += 1
            '            Console.WriteLine("Border count left = ")
            '            Console.Write(intBorderCountLeft)
            '        End If
            '    Next

            'Next

            ''----- Find Borders above the start point -------------------------------

            'ptPoint1.X = Math.Round(StartPoint.X, 1)

            'For dblY = Math.Round(StartPoint.Y, 1) To dbl_EnveloopUpperLeft.Y Step 0.1

            '    For intX = 1 To PocketOutline.Count
            '        If PocketOutline.Item(intX).Y = dblY And PocketOutline.Item(intX).X = ptPoint1.X Then
            '            intBorderCountAbove += 1
            '            Console.WriteLine("Border count above = ")
            '            Console.Write(intBorderCountAbove)
            '        End If
            '    Next
            'Next

            ''----- Find Borders beneeth the start point -------------------------------

            'For dblY = dbl_EnveloopLowerRight.Y To Math.Round(StartPoint.Y, 1) Step 0.1

            '    For intX = 1 To PocketOutline.Count
            '        If PocketOutline.Item(intX).Y = dblY And PocketOutline.Item(intX).X = ptPoint1.X Then
            '            intBorderCountBeneeth += 1
            '            Console.WriteLine("Border count beneeth = ")
            '            Console.Write(intBorderCountBeneeth)
            '        End If
            '    Next
            'Next

            'If (intBorderCountLeft = intBorderCountRight And intBorderCountLeft <> 1) Or (intBorderCountAbove = intBorderCountBeneeth And intBorderCountAbove <> 1) Then
            '    Return False
            'End If

            '----- 5. Check if the whole tool is inside the pocket and if this is not the
            '         case try to move the start point according ---------------------------

            'For intX = 1 To ToolOutline.Count
            '    For intY = 1 To PocketOutline.Count
            '        If (ToolOutline.Item(intX).X = PocketOutline.Item(intY).X) Or (ToolOutline.Item(intX).Y = PocketOutline.Item(intY).Y) Then


            '        End If
            '    Next
            'Next

            '----- 6. According to the radius correction (RL or RR) find the path along the
            '    border --------------------------------------------------------------------

#If DEBUG Then
            Console.WriteLine(" 6. According to the radius correction (RL or RR) find the path along the border")
#End If

            bolFindPath = True
            dblMovedDeltaX = 0
            dblMovedDeltaY = 0
            intPointCount = 0
            RadiusCorrection = "RL"

            Select Case RadiusCorrection
                Case "RL"

                    ' Find the border at the right side

                    Utilities.findBorder(collPartOfPocketOutline, ToolOutline, RasteredBorderA, collToolOutlineMoved, ToolWorkRadius, DistanceBetweenBorderPoints, dblMovedDeltaX, dblMovedDeltaY, StartPoint, EnveloopUpperLeft, EnveloopLowerRight)

#If DEBUG Then
                    Console.WriteLine("Find cam path")
#End If

                    strNewMoveDirection = "Up"
                    intDirectionCount = 0
                    bolFindPath = True
                    dblPoint3_X = StartPoint.X + dblMovedDeltaX
                    dblPoint3_Y = StartPoint.Y + dblMovedDeltaY
                    cptPathStart.X = StartPoint.X + dblMovedDeltaX
                    cptPathStart.Y = StartPoint.Y + dblMovedDeltaY

                    '-----

                    intPathCount = 0
                    bolFreeToFindPathStart = False

                    Do While bolFindPath = True
                        'Console.WriteLine("Test 1")

                        Select Case strNewMoveDirection
                            Case "Right"
                                strLastMoveDirection = "Right"
                                dblMovedDeltaX += DistanceBetweenBorderPoints
                            Case "Up"
                                strLastMoveDirection = "Up"
                                dblMovedDeltaY += DistanceBetweenBorderPoints
                            Case "Left"
                                strLastMoveDirection = "Left"
                                dblMovedDeltaX -= DistanceBetweenBorderPoints
                            Case "Down"
                                strLastMoveDirection = "Down"
                                dblMovedDeltaY -= DistanceBetweenBorderPoints
                        End Select

                        ReDim Outline2X(1), Outline2Y(1)
                        ToolOutline.Clear()
                        For intY = 1 To collToolOutlineMoved.Count
                            ToolOutline.Add(New cPoint(collToolOutlineMoved.Item(intY).X + dblMovedDeltaX, collToolOutlineMoved.Item(intY).Y + dblMovedDeltaY))
                        Next
                        'Console.WriteLine("Test 2")

                        '----- Select the partly border points -----

                        Z = 0
                        collPartOfPocketOutline.Clear()
                        RasteredBorderBuffer.Clear()

                        RasterX = CInt((StartPoint.X + dblMovedDeltaX - EnveloopUpperLeft.X) / (2 * ToolWorkRadius + 0.5)) + 2
                        RasterY = CInt((StartPoint.Y + dblMovedDeltaY - EnveloopLowerRight.Y) / (2 * ToolWorkRadius + 0.5)) + 2

                        For zzz = -1 To 1
                            For zzzz = -1 To 1
                                If RasteredBorderA(RasterX - zzzz, RasterY - zzz).Count > 0 Then
                                    For zz = 1 To CInt(RasteredBorderA(RasterX - zzzz, RasterY - zzz).Count)
                                        RasteredBorderBuffer.Add(RasteredBorderA(RasterX - zzzz, RasterY - zzz).Item(zz))
                                    Next
                                End If
                            Next
                        Next
                        'Console.WriteLine("Test 3")

                        Select Case strLastMoveDirection
                            Case "Right"
                                For intX = 1 To RasteredBorderBuffer.Count
                                    If (RasteredBorderBuffer.Item(intX).X >= (StartPoint.X + dblMovedDeltaX - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).X <= (StartPoint.X + dblMovedDeltaX + ToolWorkRadius + 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).Y >= ((StartPoint.Y + dblMovedDeltaY - ToolWorkRadius) - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).Y <= (StartPoint.Y + dblMovedDeltaY + ToolWorkRadius + 2 * DistanceBetweenBorderPoints)) Then
                                        collPartOfPocketOutline.Add(RasteredBorderBuffer.Item(intX))
                                    End If
                                Next
                                Direction = 1 'Right
                            Case "Down"
                                For intX = 1 To RasteredBorderBuffer.Count
                                    If (RasteredBorderBuffer.Item(intX).X >= ((StartPoint.X + dblMovedDeltaX - ToolWorkRadius) - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).X <= (StartPoint.X + dblMovedDeltaX + ToolWorkRadius + 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).Y >= ((StartPoint.Y + dblMovedDeltaY - ToolWorkRadius) - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).Y <= (StartPoint.Y + dblMovedDeltaY)) Then
                                        collPartOfPocketOutline.Add(RasteredBorderBuffer.Item(intX))
                                    End If
                                Next
                                Direction = 2 'Down
                            Case "Left"
                                For intX = 1 To RasteredBorderBuffer.Count
                                    If (RasteredBorderBuffer.Item(intX).X >= ((StartPoint.X + dblMovedDeltaX - ToolWorkRadius) - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).X <= (StartPoint.X + dblMovedDeltaX)) And (RasteredBorderBuffer.Item(intX).Y >= ((StartPoint.Y + dblMovedDeltaY - ToolWorkRadius) - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).Y <= (StartPoint.Y + dblMovedDeltaY + ToolWorkRadius + 2 * DistanceBetweenBorderPoints)) Then
                                        collPartOfPocketOutline.Add(RasteredBorderBuffer.Item(intX))
                                    End If
                                Next
                                Direction = 3 'Left
                            Case "Up"
                                For intX = 1 To RasteredBorderBuffer.Count
                                    If (RasteredBorderBuffer.Item(intX).X >= ((StartPoint.X + dblMovedDeltaX - ToolWorkRadius) - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).X <= (StartPoint.X + dblMovedDeltaX + ToolWorkRadius + 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).Y >= (StartPoint.Y + dblMovedDeltaY)) And (RasteredBorderBuffer.Item(intX).Y <= (StartPoint.Y + dblMovedDeltaY + ToolWorkRadius + 2 * DistanceBetweenBorderPoints)) Then
                                        collPartOfPocketOutline.Add(RasteredBorderBuffer.Item(intX))
                                    End If
                                Next
                                Direction = 4 'Up
                        End Select
                        Outline2Length = Z
                        Z = 1
                        'Console.WriteLine("Test 4")

                        If Utilities.checkToolToBorderCollision(ToolOutline, collPartOfPocketOutline, strLastMoveDirection) = True Then
                            'If BorderTest(Outline1X(Outline1Length), Outline1Y(Outline1Length), Outline1Length + 1, Outline2X(Outline2Length), Outline2Y(Outline2Length), Outline2Length + 1, Direction) = 1 Then
                            ' Reverse the maked tool move in case of collision
                            'Console.WriteLine("Test 5")

                            Select Case strLastMoveDirection
                                Case "Left"
                                    dblMovedDeltaX += DistanceBetweenBorderPoints
                                    strNewMoveDirection = "Down"
                                Case "Right"
                                    dblMovedDeltaX -= DistanceBetweenBorderPoints
                                    strNewMoveDirection = "Up"
                                Case "Up"
                                    dblMovedDeltaY -= DistanceBetweenBorderPoints
                                    strNewMoveDirection = "Left"
                                Case "Down"
                                    dblMovedDeltaY += DistanceBetweenBorderPoints
                                    strNewMoveDirection = "Right"
                            End Select
                            intDirectionCount = 0
                        Else
                            'Console.WriteLine("Test 6")

                            CantGo = 0
                            dblPoint2_X = StartPoint.X + dblMovedDeltaX
                            dblPoint2_Y = StartPoint.Y + dblMovedDeltaY
                            If intPathCount = 0 Then
                                ActualClosedCamPathFragment.Add(New cPoint(dblPoint3_X, dblPoint3_Y, "Border"))
                            Else
                                ActualClosedCamPathFragment.Add(New cPoint(dblPoint3_X, dblPoint3_Y, "Inner"))
                            End If
                            'Console.WriteLine(CStr(ActualClosedCamPathFragment.Count))
                            'Console.Write(dblPoint2_X)
                            'Console.Write(" ; ")
                            'Console.Write("PY = ")
                            'Console.Write(dblPoint2_Y)
                            'Console.WriteLine(" ")

                            dblPoint3_X = dblPoint2_X
                            dblPoint3_Y = dblPoint2_Y
                            intDirectionCount += 1
                            If intDirectionCount = 3 Then
                                intDirectionCount = 0
                                Select Case strLastMoveDirection
                                    Case "Right"
                                        strNewMoveDirection = "Up"
                                    Case "Up"
                                        strNewMoveDirection = "Left"
                                    Case "Down"
                                        strNewMoveDirection = "Right"
                                    Case "Left"
                                        strNewMoveDirection = "Down"
                                End Select
                            Else
                                Select Case strLastMoveDirection
                                    Case "Right"
                                        strNewMoveDirection = "Down"
                                    Case "Up"
                                        strNewMoveDirection = "Right"
                                    Case "Left"
                                        strNewMoveDirection = "Up"
                                    Case "Down"
                                        strNewMoveDirection = "Left"
                                End Select
                            End If
                            'Console.WriteLine("oh jeeeh")
                        End If

                        If ((StartPoint.X + dblMovedDeltaX) >= (cptPathStart.X + 4 * DistanceBetweenBorderPoints)) Or ((StartPoint.X + dblMovedDeltaX) <= (cptPathStart.X - 4 * DistanceBetweenBorderPoints)) Or ((StartPoint.Y + dblMovedDeltaY) >= (cptPathStart.Y + 4 * DistanceBetweenBorderPoints)) Or ((StartPoint.Y + dblMovedDeltaY) <= (cptPathStart.Y - 4 * DistanceBetweenBorderPoints)) Then
                            bolFreeToFindPathStart = True
                        End If

                        'If CantGo > 7 Then
                        '    bolFindPath = False
                        'End If

                        If ((StartPoint.X + dblMovedDeltaX) >= (cptPathStart.X - 3 * DistanceBetweenBorderPoints)) And ((StartPoint.X + dblMovedDeltaX) <= (cptPathStart.X + 3 * DistanceBetweenBorderPoints)) And ((StartPoint.Y + dblMovedDeltaY) >= (cptPathStart.Y - 3 * DistanceBetweenBorderPoints)) And ((StartPoint.Y + dblMovedDeltaY) <= (cptPathStart.Y + 3 * DistanceBetweenBorderPoints)) And bolFreeToFindPathStart = True Then
                            'If intPointCount > 100 Then
                            'bolFindPath = False
                            'End If
                            intPathCount += 1
                            If intPathCount > 1 Then
                                DistanceBetweenBorderPoints = 0.1
                            End If
                            PocketOutline.Clear()
                            For intX = 1 To ActualClosedCamPathFragment.Count
                                PocketOutline.Add(ActualClosedCamPathFragment.Item(intX))
                            Next
                            ActualClosedCamPathFragment.Add(New cPoint(ActualClosedCamPathFragment.Item(1).X, ActualClosedCamPathFragment.Item(1).Y, "Border")) 'Close the fragment
                            Utilities.rasterTheBorder(RasteredBorderA, PocketOutline, EnveloopUpperLeft.X, EnveloopLowerRight.Y, ToolWorkRadius, HorizontalRasterCount, VerticalRasterCount)

#If DEBUG Then
                            Console.WriteLine(intPathCount)
#End If

                            simplifyPocketMillingPath(ActualClosedCamPathFragment, DistanceBetweenBorderPoints)
                            ActualClosedCamPathFragment.Clear()

                            dblMovedDeltaX = 0 'Old: dblMovedDeltaX - (Tool.ToolDiameter /2 + 0.05)
                            dblMovedDeltaY = 0

                            '----- Begin check if toolpath is complete -----

                            ToolOutline.Clear()
                            For intY = 1 To collToolOutlineMoved.Count
                                ToolOutline.Add(New cPoint(collToolOutlineMoved.Item(intY).X + dblMovedDeltaX, collToolOutlineMoved.Item(intY).Y + dblMovedDeltaY))
                            Next

                            collPartOfPocketOutline.Clear()
                            For intX = 1 To PocketOutline.Count
                                If (PocketOutline.Item(intX).X >= ((StartPoint.X + dblMovedDeltaX - ToolWorkRadius) - 2 * DistanceBetweenBorderPoints)) And (PocketOutline.Item(intX).X <= (StartPoint.X + dblMovedDeltaX + ToolWorkRadius + 2 * DistanceBetweenBorderPoints)) And (PocketOutline.Item(intX).Y >= ((StartPoint.Y + dblMovedDeltaY - ToolWorkRadius) - 2 * DistanceBetweenBorderPoints)) And (PocketOutline.Item(intX).Y <= (StartPoint.Y + dblMovedDeltaY + ToolWorkRadius + 2 * DistanceBetweenBorderPoints)) Then
                                    collPartOfPocketOutline.Add(PocketOutline.Item(intX))
                                End If
                            Next

                            If CheckIfToolBorderIsWithin(ToolOutline, collPartOfPocketOutline) = False Or intPathCount = 6 Then
                                bolFindPath = False
                            Else
                                Utilities.findBorder(collPartOfPocketOutline, ToolOutline, RasteredBorderA, collToolOutlineMoved, ToolWorkRadius, DistanceBetweenBorderPoints, dblMovedDeltaX, dblMovedDeltaY, StartPoint, EnveloopUpperLeft, EnveloopLowerRight)
                                cptPathStart.X = StartPoint.X + dblMovedDeltaX
                                cptPathStart.Y = StartPoint.Y + dblMovedDeltaY
                                bolFreeToFindPathStart = False
                                strNewMoveDirection = "Up"
                                intDirectionCount = 0
                                dblPoint3_X = StartPoint.X + dblMovedDeltaX
                                dblPoint3_Y = StartPoint.Y + dblMovedDeltaY
                            End If

                            '----- End check if toolpath is complete -----

                        End If
                        CantGo += 1
                        'intPointCount += 1
                        'Console.WriteLine(CStr(intPointCount))
                    Loop
                Case "RR"
            End Select

#If DEBUG Then
            Console.WriteLine("habe fertig")
#End If

        End If

        If m_PreviewSignal = True Then
            completeCamPreview()
        Else

            '----- 6. Complete the milling path --------------------------------------------

            completeCamPathNew()

        End If

        '----- 7. For test reasons show the milling path by adding it to the pocket elements ----------

        'CamElements.Add(New cLine(New cPoint(dblPoint3_X, dblPoint3_Y), New cPoint(dblPoint2_X, dblPoint2_Y)))

        OdarTec3Axes.ToolStriProBa_Main.Value = 70
        Return False
    End Function

    Private Function simplifyPocketMillingPath(ByRef ClosedCamPathFragment As Collection, DistanceBetweenPoints As Double) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Connect the points of the milling path to arcs and lines
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim intW, intX, intY, intCount As Integer
        'Dim LoopStop As Integer
        Dim SpaceBetweenStartAndEnd As Integer
        Dim MaxQuadraticError, dblZ As Double
        Dim LineStart As New cPoint
        Dim LineEnd As New cPoint
        Dim ToTest As New cPoint
        Dim ActualLinePoint As New cPoint
        Dim TanAlpha As Double
        Dim PuT As New Collection
        Dim LineIsUnderConstruction As Boolean
        Dim StepWidth As Double

        '----- Initial settings -----

        StepWidth = DistanceBetweenPoints / 2

        MaxQuadraticError = (DistanceBetweenPoints * 1.5) ^ 2
        intCount = ClosedCamPathFragment.Count
        If m_CamPath.Count > 0 Then
            m_CamPath.Add(New cLine(ClosedCamPathFragment.Item(ClosedCamPathFragment.Count).X, ClosedCamPathFragment.Item(ClosedCamPathFragment.Count).Y, (m_CamPath.Item(CamPathCount).StartPoint.X), (m_CamPath.Item(CamPathCount).StartPoint.Y), "InfeedSide"))
        Else
            'Return False
        End If

        '----- 2. Simplify the campath ------------------------------------

        Do While intCount > 0

            SpaceBetweenStartAndEnd = 1
            LineEnd.X = ClosedCamPathFragment.Item(intCount).X
            LineEnd.Y = ClosedCamPathFragment.Item(intCount).Y

            LineIsUnderConstruction = True

            Do While LineIsUnderConstruction = True

                If (intCount - SpaceBetweenStartAndEnd - 1) > 0 Then
                    LineStart.X = ClosedCamPathFragment.Item(intCount - SpaceBetweenStartAndEnd - 1).X
                    LineStart.Y = ClosedCamPathFragment.Item(intCount - SpaceBetweenStartAndEnd - 1).Y
                Else
                    m_CamPath.Add(New cLine(ClosedCamPathFragment.Item(1), LineEnd, ClosedCamPathFragment.Item(intCount).Description))
                    intCount = 0
                    Exit Do
                End If

                PuT.Clear()
                For intX = intCount - 1 To (intCount - SpaceBetweenStartAndEnd) Step (-1)
                    PuT.Add(ClosedCamPathFragment.Item(intX))
                Next


                '----- If distance in X between start and end is bigger as the distance in Y -----

                If ((LineStart.X - LineEnd.X) ^ 2) > ((LineStart.Y - LineEnd.Y) ^ 2) Then

                    '----- If startpoint X is lesser than endpoint X -----------------------------

                    If LineStart.X < LineEnd.X Then

                        TanAlpha = (LineEnd.Y - LineStart.Y) / (LineEnd.X - LineStart.X)
                        For dblZ = 0 To (LineEnd.X - LineStart.X) Step StepWidth
                            ActualLinePoint.X = LineStart.X + dblZ
                            ActualLinePoint.Y = LineStart.Y + (dblZ * TanAlpha)
                            fun_TestIfMember(PuT, ActualLinePoint, MaxQuadraticError)
                        Next
                        'Console.WriteLine("End point x is bigger than start point x")
                    Else

                        '----- Startpoint is bigger than endpoint -----

                        TanAlpha = (LineStart.Y - LineEnd.Y) / (LineStart.X - LineEnd.X)
                        For dblZ = 0 To (LineStart.X - LineEnd.X) Step StepWidth
                            ActualLinePoint.X = LineEnd.X + dblZ
                            ActualLinePoint.Y = LineEnd.Y + (dblZ * TanAlpha)
                            fun_TestIfMember(PuT, ActualLinePoint, MaxQuadraticError)
                        Next
                        'Console.WriteLine("Start point x is bigger than end point x")
                    End If

                    '----- If distance in Y between start and end is bigger as the distance in X -----

                Else

                    '----- If startpoint X is lesser than endpoint X -----------------------------

                    If LineStart.Y < LineEnd.Y Then

                        TanAlpha = (LineEnd.X - LineStart.X) / (LineEnd.Y - LineStart.Y)
                        For dblZ = 0 To (LineEnd.X - LineStart.X) Step StepWidth
                            ActualLinePoint.X = LineStart.X + (dblZ * TanAlpha)
                            ActualLinePoint.Y = LineStart.Y + dblZ
                            fun_TestIfMember(PuT, ActualLinePoint, MaxQuadraticError)
                        Next

                    Else

                        '----- Startpoint is bigger than endpoint -----

                        TanAlpha = (LineStart.X - LineEnd.X) / (LineStart.Y - LineEnd.Y)
                        For dblZ = 0 To (LineStart.Y - LineEnd.Y) Step StepWidth
                            ActualLinePoint.X = LineEnd.X + (dblZ * TanAlpha)
                            ActualLinePoint.Y = LineEnd.Y + dblZ
                            fun_TestIfMember(PuT, ActualLinePoint, MaxQuadraticError)
                        Next

                    End If
                End If

                If LineStart.X = LineEnd.X Then
                    ActualLinePoint.X = LineStart.X
                    If LineStart.Y < LineEnd.Y Then
                        For dblZ = 0 To (LineEnd.Y - LineStart.Y) Step StepWidth
                            ActualLinePoint.Y = LineStart.Y + dblZ
                            fun_TestIfMember(PuT, ActualLinePoint, MaxQuadraticError)
                        Next
                    Else
                        For dblZ = 0 To (LineStart.Y - LineEnd.Y) Step StepWidth
                            ActualLinePoint.Y = LineEnd.Y + dblZ
                            fun_TestIfMember(PuT, ActualLinePoint, MaxQuadraticError)
                        Next
                    End If
                End If
                If LineStart.Y = LineEnd.Y Then
                    ActualLinePoint.Y = LineStart.Y
                    If LineStart.X < LineEnd.X Then
                        For dblZ = 0 To (LineEnd.X - LineStart.X) Step StepWidth
                            ActualLinePoint.X = LineStart.X + dblZ
                            fun_TestIfMember(PuT, ActualLinePoint, MaxQuadraticError)
                        Next
                    Else
                        For dblZ = 0 To (LineStart.X - LineEnd.X) Step StepWidth
                            ActualLinePoint.X = LineEnd.X + dblZ
                            fun_TestIfMember(PuT, ActualLinePoint, MaxQuadraticError)
                        Next
                    End If
                End If

                '----- Add line (from start to lastfittinglineend) to campath and set new startpoint to lastfittinglineend

                For intW = 1 To PuT.Count

                    If SpaceBetweenStartAndEnd > 20 Then
                        intCount = intCount - SpaceBetweenStartAndEnd
                        m_CamPath.Add(New cLine(ClosedCamPathFragment.Item(intCount), LineEnd, ClosedCamPathFragment.Item(intCount).Description))
                        For intY = 1 To ClosedCamPathFragment.Count
                            ClosedCamPathFragment.Item(intY).IsMember = False
                        Next
                        LineIsUnderConstruction = False
                        Exit For
                    ElseIf PuT.Item(intW).IsMember = False Then
                        intCount = intCount - SpaceBetweenStartAndEnd
                        m_CamPath.Add(New cLine(ClosedCamPathFragment.Item(intCount), LineEnd, ClosedCamPathFragment.Item(intCount).Description))
                        For intY = 1 To ClosedCamPathFragment.Count
                            ClosedCamPathFragment.Item(intY).IsMember = False
                        Next
                        LineIsUnderConstruction = False
                        Exit For
                    Else
                        PuT.Item(intW).IsMember = False
                    End If
                Next

                SpaceBetweenStartAndEnd += 1

#If DEBUG Then
                Console.WriteLine("CamPath.Count = " + CStr(m_CamPath.Count))
#End If

            Loop
        Loop
        CamPathCount = m_CamPath.Count

#If DEBUG Then
        Console.Write(m_CamPath.Count)
#End If

        Return False
    End Function

    Private Function fun_TestIfMember(ByRef PossibleMembers As Collection, ActualLinePoint As cPoint, MaxError As Double) As Boolean

        Dim intW As Integer
        Dim ToTest As New cPoint

        For intW = 1 To PossibleMembers.Count
            ToTest.X = PossibleMembers.Item(intW).X
            ToTest.Y = PossibleMembers.Item(intW).Y
            If ((ToTest.X - ActualLinePoint.X) ^ 2 + (ToTest.Y - ActualLinePoint.Y) ^ 2) < MaxError Then
                PossibleMembers.Item(intW).IsMember = True
            End If
        Next
        Return True
    End Function

    Private Function fun_SortOutline() As Boolean



        Return False
    End Function


    '----- Test subs and functions --------------------------------------------------------

    Private Function fun_TestCamPath(StartPoint As Point, EndPoint As Point) As cLine

        Dim mLine As New cLine()

        mLine.m_X1 = StartPoint.X
        mLine.m_Y1 = StartPoint.Y
        mLine.m_X2 = EndPoint.X
        mLine.m_Y2 = EndPoint.Y

        Return mLine
    End Function

    Private Function CheckIfToolBorderIsWithin(ByRef Outline1 As Collection, ByRef Outline2 As Collection) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Check if the pocket outline intersects the tool outline
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim intY, intY2 As Integer
        For intY = 1 To (Outline1.Count / 2)
            For intY2 = 1 To Outline2.Count
                If (Outline2.Item(intY2).X < Outline1.Item(intY).X) And (Outline2.Item(intY2).X > Outline1.Item(Outline1.Count / 2 + 1 - intY).X) And (Outline2.Item(intY2).Y > (Outline1.Item(intY).Y - 0.25)) And (Outline2.Item(intY2).Y < (Outline1.Item(intY).Y + 0.25)) Then
                    Return False
                End If
            Next
        Next
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

        Dim CamPathBuffer As Collection
        Dim x, y, z As Integer
        Dim ActualZ, LastZBeforGroundSteps As Double
        Dim BorderCount As Integer
        Dim BufferPoint As New cPoint

        '----- Initial settings -----

        ActualZ = m_StartPoint.Z
        ZSteps = CInt(((DepthOfCamEntity - (GroundSteps * InfeedGround)) / InfeedZ))
        If (ZSteps * InfeedZ + GroundSteps * InfeedGround) > DepthOfCamEntity Then
            ZSteps -= 1
        End If
        LastZBeforGroundSteps = DepthOfCamEntity - (GroundSteps * InfeedGround) - (ZSteps * InfeedZ)
        BorderCount = 0

        '-----
        OdarTec3Axes.ToolStriProBa_Main.Value = 5

        For x = 1 To m_CamPath.Count
            If m_CamPath.Item(x).CamDescription = "Border" Then
                BorderCount += 1 'Counts the "Border" elements to put the correct amount of additional border lines (if needed) to the campaht
                CamPathBuffer.Add(New cLine(m_CamPath.Item(x)))
            Else
                If BorderCount > 0 And SideSteps > 1 Then
                    For z = 1 To SideSteps
                        For y = 1 To BorderCount
                            CamPathBuffer.Add(New cLine(m_CamPath.Item(y)))
                        Next
                    Next
                    BorderCount = 0 'BorderCount now used as a blocking variable after all border pathes are added
                End If
                CamPathBuffer.Add(New cLine(m_CamPath.Item(x)))
            End If
        Next
        OdarTec3Axes.ToolStriProBa_Main.Value = 10

        m_CamPath.Clear()
        BufferPoint.X = CamPathBuffer.Item(CamPathBuffer.Count).m_X1
        BufferPoint.Y = CamPathBuffer.Item(CamPathBuffer.Count).m_Y1
        BufferPoint.Z = CamPathBuffer.Item(CamPathBuffer.Count).m_Z1
        CamPathBuffer.Add(New cLine(New cPoint(StartPoint.X, StartPoint.Y, StartPoint.Z), New cPoint(BufferPoint.X, BufferPoint.Y, BufferPoint.Z), "Work"))
        m_CamPath.Add(New cLine(New cPoint(StartPoint.X, StartPoint.Y, StartPoint.Z + 50), New cPoint(StartPoint.X, StartPoint.Y, StartPoint.Z + 5), "Rapid"))
        m_CamPath.Add(New cLine(New cPoint(StartPoint.X, StartPoint.Y, StartPoint.Z + 5), New cPoint(StartPoint.X, StartPoint.Y, StartPoint.Z), "InfeedGround"))
        For y = 1 To ZSteps Step 1
            m_CamPath.Add(New cLine(New cPoint(StartPoint.X, StartPoint.Y, ActualZ), New cPoint(StartPoint.X, StartPoint.Y, ActualZ - InfeedZ), "InfeedGround"))
            ActualZ = ActualZ - InfeedZ
            For x = CamPathBuffer.Count To 1 Step (-1)
                m_CamPath.Add(New cLine(CamPathBuffer.Item(x)))
                m_CamPath.Item(m_CamPath.Count).m_Z1 = ActualZ
                m_CamPath.Item(m_CamPath.Count).m_Z2 = ActualZ
                m_CamPath.Item(m_CamPath.Count).CamDescription = "Work"
            Next
            BufferPoint.X = m_CamPath.Item(m_CamPath.Count).m_X2
            BufferPoint.Y = m_CamPath.Item(m_CamPath.Count).m_Y2
            m_CamPath.Add(New cLine(New cPoint(BufferPoint.X, BufferPoint.Y, ActualZ), New cPoint(StartPoint.X, StartPoint.Y, ActualZ), "Work"))
        Next
        OdarTec3Axes.ToolStriProBa_Main.Value = 75
        OdarTec3Axes.ToolStriProBa_Main.Invalidate()

        '----- If dephth of pocket - GroundSteps * InfeedGround - ZSteps * InfeedZ is not even -----

        If LastZBeforGroundSteps > 0 Then
            m_CamPath.Add(New cLine(New cPoint(StartPoint.X, StartPoint.Y, ActualZ), New cPoint(StartPoint.X, StartPoint.Y, ActualZ - LastZBeforGroundSteps), "InfeedGround"))
            ActualZ = ActualZ - LastZBeforGroundSteps
            For x = CamPathBuffer.Count To 1 Step (-1)
                m_CamPath.Add(CamPathBuffer.Item(x))
                m_CamPath.Item(m_CamPath.Count).m_Z1 = ActualZ
                m_CamPath.Item(m_CamPath.Count).m_Z2 = ActualZ
                m_CamPath.Item(m_CamPath.Count).CamDescription = "Work"
            Next
            BufferPoint.X = m_CamPath.Item(m_CamPath.Count).m_X2
            BufferPoint.Y = m_CamPath.Item(m_CamPath.Count).m_Y2
            m_CamPath.Add(New cLine(New cPoint(BufferPoint.X, BufferPoint.Y, ActualZ), New cPoint(StartPoint.X, StartPoint.Y, ActualZ), "Work"))
        End If

        '----- Ground steps -----

        For y = 1 To GroundSteps
            m_CamPath.Add(New cLine(New cPoint(StartPoint.X, StartPoint.Y, ActualZ), New cPoint(StartPoint.X, StartPoint.Y, ActualZ - InfeedGround), "InfeedGround"))
            ActualZ = ActualZ - InfeedGround
            For x = CamPathBuffer.Count To 1 Step (-1)
                m_CamPath.Add(CamPathBuffer.Item(x))
                m_CamPath.Item(m_CamPath.Count).m_Z1 = ActualZ
                m_CamPath.Item(m_CamPath.Count).m_Z2 = ActualZ
                m_CamPath.Item(m_CamPath.Count).CamDescription = "Work"
            Next
            BufferPoint.X = m_CamPath.Item(m_CamPath.Count).m_X2
            BufferPoint.Y = m_CamPath.Item(m_CamPath.Count).m_Y2
            m_CamPath.Add(New cLine(New cPoint(BufferPoint.X, BufferPoint.Y, ActualZ), New cPoint(StartPoint.X, StartPoint.Y, ActualZ), "Work"))
        Next

        m_CamPath.Add(New cLine(New cPoint(StartPoint.X, StartPoint.Y, ActualZ), New cPoint(StartPoint.X, StartPoint.Y, StartPoint.Z + 50), "Rapid"))

        Return True
    End Function

    Private Function completeCamPathNew() As Boolean

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

        Dim CamPathBuffer() As cSimplePoint
        Dim x, y, z As Integer
        Dim ActualZ, LastZBeforGroundSteps As Double
        Dim BorderCount As Integer
        Dim BufferPoint As New cSimplePoint
        Dim ArrayCount As Integer                       'To preserve the length of the m_CamPathArray

        '----- Initial settings -----

        ReDim CamPathBuffer(m_CamPathArray.Length - 1)
        ActualZ = m_StartPoint.Z
        LastZBeforGroundSteps = 0

        ZSteps = CInt((DepthOfCamEntity - GroundSteps * InfeedGround) / InfeedZ)
        If ZSteps * InfeedZ < (DepthOfCamEntity - GroundSteps * InfeedGround) Then
            ZSteps -= 1
        End If
        LastZBeforGroundSteps = (DepthOfCamEntity - GroundSteps * InfeedGround) - (ZSteps * InfeedZ)

        BorderCount = 0
        ArrayCount = 0

        '-----

        For x = 0 To m_CamPathArray.Length - 1

            CamPathBuffer(x) = New cSimplePoint(m_CamPathArray(x))
            If m_CamPathArray(x).Annotation = "Border" Then
                m_CamPathArray(x).Annotation = "InfeedSide"
                If m_SideSteps > 1 Then
                    BorderCount = x 'The m_CamPath.Count until all elements are border elements
                    ReDim Preserve CamPathBuffer(CamPathBuffer.Length + m_SideSteps - 1 * x) 'For the additional border elements
                    For i As Integer = 2 To m_SideSteps
                        For j As Integer = 0 To x
                            CamPathBuffer((i - 1) * x + j) = New cSimplePoint(m_CamPathArray(j))
                        Next
                    Next
                End If
            End If
        Next

        ReDim m_CamPathArray(CamPathBuffer.Length - 1 + 2000)
        m_CamPathArray(0) = New cSimplePoint(StartPoint.X, StartPoint.Y, StartPoint.Z + m_ToolStartStopRetractHeight, "Rapid")
        m_CamPathArray(1) = New cSimplePoint(StartPoint.X, StartPoint.Y, StartPoint.Z + m_ToolWorkRetractHeight, "Rapid")
        ArrayCount = 1
        For y = 1 To ZSteps Step 1
            ActualZ = ActualZ + InfeedZ
            For x = CamPathBuffer.Length - 1 To 0 Step (-1)
                If ArrayCount = m_CamPathArray.Length - 1 Then
                    ReDim Preserve m_CamPathArray(ArrayCount + 2000)
                End If
                ArrayCount += 1
                m_CamPathArray(ArrayCount) = New cSimplePoint(CamPathBuffer(x))
                m_CamPathArray(ArrayCount).Z = ActualZ
            Next
            If ArrayCount = m_CamPathArray.Length - 1 Then
                ReDim Preserve m_CamPathArray(ArrayCount + 2000)
            End If
            ArrayCount += 1
            m_CamPathArray(ArrayCount) = New cSimplePoint(m_CamPathArray(ArrayCount - 1))
            m_CamPathArray(ArrayCount).Z = m_ToolWorkRetractHeight
            m_CamPathArray(ArrayCount).Annotation = "Rapid"
            If ArrayCount = m_CamPathArray.Length - 1 Then
                ReDim Preserve m_CamPathArray(ArrayCount + 2000)
            End If
            ArrayCount += 1
            m_CamPathArray(ArrayCount) = New cSimplePoint(StartPoint.X, StartPoint.Y, StartPoint.Z + m_ToolWorkRetractHeight, "Rapid")
        Next

        '----- If dephth of pocket - GroundSteps * InfeedGround - ZSteps * InfeedZ is not even -----

        If LastZBeforGroundSteps < 0 Then
            ActualZ = ActualZ + LastZBeforGroundSteps
            For x = CamPathBuffer.Length - 1 To 0 Step (-1)
                If ArrayCount = m_CamPathArray.Length - 1 Then
                    ReDim Preserve m_CamPathArray(ArrayCount + 2000)
                End If
                ArrayCount += 1
                m_CamPathArray(ArrayCount) = New cSimplePoint(CamPathBuffer(x))
                m_CamPathArray(ArrayCount).Z = ActualZ
            Next
            If ArrayCount = m_CamPathArray.Length - 1 Then
                ReDim Preserve m_CamPathArray(ArrayCount + 2000)
            End If
            ArrayCount += 1
            m_CamPathArray(ArrayCount) = New cSimplePoint(m_CamPathArray(ArrayCount - 1))
            m_CamPathArray(ArrayCount).Z = m_ToolWorkRetractHeight
            m_CamPathArray(ArrayCount).Annotation = "Rapid"
            If ArrayCount = m_CamPathArray.Length - 1 Then
                ReDim Preserve m_CamPathArray(ArrayCount + 2000)
            End If
            ArrayCount += 1
            m_CamPathArray(ArrayCount) = New cSimplePoint(StartPoint.X, StartPoint.Y, StartPoint.Z + m_ToolWorkRetractHeight, "Rapid")
        End If

        '----- Ground steps -----

        For y = 1 To GroundSteps
            ActualZ = ActualZ + InfeedGround
            For x = CamPathBuffer.Length - 1 To 0 Step (-1)
                If ArrayCount = m_CamPathArray.Length - 1 Then
                    ReDim Preserve m_CamPathArray(ArrayCount + 2000)
                End If
                ArrayCount += 1
                m_CamPathArray(ArrayCount) = New cSimplePoint(CamPathBuffer(x))
                m_CamPathArray(ArrayCount).Z = ActualZ
            Next
            If ArrayCount = m_CamPathArray.Length - 1 Then
                ReDim Preserve m_CamPathArray(ArrayCount + 2000)
            End If
            ArrayCount += 1
            m_CamPathArray(ArrayCount) = New cSimplePoint(m_CamPathArray(ArrayCount - 1))
            m_CamPathArray(ArrayCount).Z = m_ToolWorkRetractHeight
            m_CamPathArray(ArrayCount).Annotation = "Rapid"
            If ArrayCount = m_CamPathArray.Length - 1 Then
                ReDim Preserve m_CamPathArray(ArrayCount + 2000)
            End If
            ArrayCount += 1
            m_CamPathArray(ArrayCount) = New cSimplePoint(StartPoint.X, StartPoint.Y, StartPoint.Z + m_ToolWorkRetractHeight, "Rapid")
        Next

        If ArrayCount = m_CamPathArray.Length - 1 Then
            ReDim Preserve m_CamPathArray(ArrayCount + 2000)
        End If
        ArrayCount += 1
        m_CamPathArray(ArrayCount) = New cSimplePoint(StartPoint.X, StartPoint.Y, StartPoint.Z + m_ToolStartStopRetractHeight, "Rapid")


        ReDim Preserve m_CamPathArray(ArrayCount)   'Make the m_CamPathArray only as long as valid points are avaylable

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

    Private Function completeCamPreview() As Boolean

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

        Dim CamPreviewBuffer As New Collection
        Dim x, y, z As Integer
        Dim ActualZ, LastZBeforGroundSteps As Double
        Dim BorderCount As Integer
        Dim BufferPoint As New cPoint

        '----- Initial settings -----

        ActualZ = m_StartPoint.Z
        ZSteps = CInt((DepthOfCamEntity - GroundSteps * InfeedGround) / InfeedZ)
        If ZSteps * InfeedZ < (DepthOfCamEntity - GroundSteps * InfeedGround) Then
            ZSteps -= 1
        End If
        LastZBeforGroundSteps = (DepthOfCamEntity - GroundSteps * InfeedGround) - (ZSteps * InfeedZ)
        BorderCount = 0

        '-----

        For x = 1 To m_CamPreview.Count
            Select Case m_CamPreview.Item(x).GetType
                Case GetType(cCircle)
                    CamPreviewBuffer.Add(New cCircle(m_CamPreview.Item(x)))

#If DEBUG Then
                    Console.WriteLine("Juchhu")
#End If

                Case GetType(cLine)
                    CamPreviewBuffer.Add(New cLine(m_CamPreview.Item(x)))
            End Select
        Next

        m_CamPreview.Clear()
        BufferPoint.X = CamPreviewBuffer.Item(CamPreviewBuffer.Count).m_X1
        BufferPoint.Y = CamPreviewBuffer.Item(CamPreviewBuffer.Count).m_Y1
        BufferPoint.Z = CamPreviewBuffer.Item(CamPreviewBuffer.Count).m_Z1
        m_CamPreview.Add(New cLine(New cPoint(StartPoint.X, StartPoint.Y, StartPoint.Z + m_ToolStartStopRetractHeight), New cPoint(StartPoint.X, StartPoint.Y, StartPoint.Z + m_ToolWorkRetractHeight), "Rapid"))
        For y = 1 To ZSteps Step 1
            ActualZ = ActualZ + InfeedZ
            m_CamPreview.Add(New cLine(New cPoint(StartPoint.X, StartPoint.Y, m_ToolWorkRetractHeight), New cPoint(StartPoint.X, StartPoint.Y, ActualZ), "InfeedGround"))
            For x = 1 To CamPreviewBuffer.Count
                Select Case CamPreviewBuffer.Item(x).GetType
                    Case GetType(cCircle)
                        m_CamPreview.Add(New cCircle(CamPreviewBuffer.Item(x)))
                        m_CamPreview.Item(m_CamPreview.Count).m_ZC = ActualZ
                    Case GetType(cLine)
                        m_CamPreview.Add(New cLine(CamPreviewBuffer.Item(x)))
                        m_CamPreview.Item(m_CamPreview.Count).m_Z1 = ActualZ
                        m_CamPreview.Item(m_CamPreview.Count).m_Z2 = ActualZ
                End Select
            Next
            BufferPoint.X = m_CamPreview.Item(m_CamPreview.Count).m_X2
            BufferPoint.Y = m_CamPreview.Item(m_CamPreview.Count).m_Y2
            m_CamPreview.Add(New cLine(New cPoint(BufferPoint.X, BufferPoint.Y, ActualZ), New cPoint(StartPoint.X, StartPoint.Y, m_ToolWorkRetractHeight), "Rapid"))
            m_CamPreview.Add(New cLine(New cPoint(BufferPoint.X, BufferPoint.Y, m_ToolWorkRetractHeight), New cPoint(StartPoint.X, StartPoint.Y, m_ToolWorkRetractHeight), "Rapid"))
        Next

        '----- If dephth of pocket - GroundSteps * InfeedGround - ZSteps * InfeedZ is not even -----

        If LastZBeforGroundSteps <> 0 Then
            ActualZ = ActualZ + LastZBeforGroundSteps
            m_CamPath.Add(New cLine(New cPoint(StartPoint.X, StartPoint.Y, m_ToolWorkRetractHeight), New cPoint(StartPoint.X, StartPoint.Y, ActualZ), "InfeedGround"))
            For x = 1 To CamPreviewBuffer.Count
                Select Case CamPreviewBuffer.Item(x).GetType
                    Case GetType(cCircle)
                        m_CamPreview.Add(New cCircle(CamPreviewBuffer.Item(x)))
                        m_CamPreview.Item(m_CamPreview.Count).m_ZC = ActualZ
                    Case GetType(cLine)
                        m_CamPreview.Add(New cLine(CamPreviewBuffer.Item(x)))
                        m_CamPreview.Item(m_CamPreview.Count).m_Z1 = ActualZ
                        m_CamPreview.Item(m_CamPreview.Count).m_Z2 = ActualZ
                End Select
            Next
            BufferPoint.X = m_CamPreview.Item(m_CamPreview.Count).m_X2
            BufferPoint.Y = m_CamPreview.Item(m_CamPreview.Count).m_Y2
            m_CamPreview.Add(New cLine(New cPoint(BufferPoint.X, BufferPoint.Y, ActualZ), New cPoint(StartPoint.X, StartPoint.Y, m_ToolWorkRetractHeight), "Rapid"))
            m_CamPreview.Add(New cLine(New cPoint(BufferPoint.X, BufferPoint.Y, m_ToolWorkRetractHeight), New cPoint(StartPoint.X, StartPoint.Y, m_ToolWorkRetractHeight), "Rapid"))
        End If

        '----- Ground steps -----

        For y = 1 To GroundSteps
            ActualZ = ActualZ + InfeedGround
            m_CamPreview.Add(New cLine(New cPoint(StartPoint.X, StartPoint.Y, m_ToolWorkRetractHeight), New cPoint(StartPoint.X, StartPoint.Y, ActualZ), "InfeedGround"))
            For x = 1 To CamPreviewBuffer.Count
                Select Case CamPreviewBuffer.Item(x).GetType
                    Case GetType(cCircle)
                        m_CamPreview.Add(New cCircle(CamPreviewBuffer.Item(x)))
                        m_CamPreview.Item(m_CamPreview.Count).m_ZC = ActualZ
                    Case GetType(cLine)
                        m_CamPreview.Add(New cLine(CamPreviewBuffer.Item(x)))
                        m_CamPreview.Item(m_CamPreview.Count).m_Z1 = ActualZ
                        m_CamPreview.Item(m_CamPreview.Count).m_Z2 = ActualZ
                End Select
            Next
            BufferPoint.X = m_CamPreview.Item(m_CamPreview.Count).m_X2
            BufferPoint.Y = m_CamPreview.Item(m_CamPreview.Count).m_Y2
            m_CamPreview.Add(New cLine(New cPoint(BufferPoint.X, BufferPoint.Y, ActualZ), New cPoint(StartPoint.X, StartPoint.Y, m_ToolWorkRetractHeight), "Rapid"))
            m_CamPreview.Add(New cLine(New cPoint(BufferPoint.X, BufferPoint.Y, m_ToolWorkRetractHeight), New cPoint(StartPoint.X, StartPoint.Y, m_ToolWorkRetractHeight), "Rapid"))
        Next

        m_CamPreview.Add(New cLine(New cPoint(StartPoint.X, StartPoint.Y, m_ToolWorkRetractHeight), New cPoint(StartPoint.X, StartPoint.Y, StartPoint.Z + m_ToolStartStopRetractHeight), "Rapid"))

        Return True
    End Function

    <DllImport("D:\softwaredevelopement\3-Axis\software\PC programs\Odartec Utilities\Odartecutilities.dll", EntryPoint:="#1", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function Add(a As Double, b As Double) As Double
    End Function

    <DllImport("D:\softwaredevelopement\3-Axis\software\PC programs\Odartec Utilities\Odartecutilities.dll", EntryPoint:="#2", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function Subtract(a As Double, b As Double) As Double
    End Function

    <DllImport("D:\softwaredevelopement\3-Axis\software\PC programs\Odartec Utilities\Odartecutilities.dll", EntryPoint:="#3", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function Multiply(a As Double, b As Double) As Double
    End Function

End Class
