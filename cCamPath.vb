Option Explicit On
Option Infer Off

Public Class cCamPath
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
    Private m_Approach As Boolean
    Private m_PatternAmountX As Integer
    Private m_PatternDistanceX As Double
    Private m_PatternAmountY As Integer
    Private m_PatternDistanceY As Double
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

    Public Property Approach() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Approach
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_Approach = Value
        End Set
    End Property

    Public Property PatternAmountX() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PatternAmountX
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_PatternAmountX = Value
        End Set
    End Property

    Public Property PatternDistanceX() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PatternDistanceX
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_PatternDistanceX = Value
        End Set
    End Property

    Public Property PatternAmountY() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PatternAmountY
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_PatternAmountY = Value
        End Set
    End Property

    Public Property PatternDistanceY() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PatternDistanceY
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_PatternDistanceY = Value
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
        Dim collToolOutlineMoved, collPartOfPocketOutline As New Collection()
        Dim bolFreeToFindPathStart, bolFindPath As Boolean
        Dim strLastMoveDirection, strNewMoveDirection As String ' Up, Down, Left, Right
        Dim cptPathStart As New cPoint()
        Dim cptMinimalDistanceFromPathStart As New cPoint()
        Dim dblPoint1_X, dblPoint1_Y, dblPoint2_X, dblPoint2_Y, dblPoint3_X, dblPoint3_Y As Double
        Dim ActualClosedCamPathFragment As New Collection()
        Dim Direction As Integer
        Dim Outline1Length, Outline2Length As Integer
        Dim Outline1X(1), Outline1Y(1), Outline2X(1), Outline2Y(1), Outline3X(1), Outline3Y(1) As Double
        Dim DistanceBetweenBorderPoints As Double                                                           'Distance between border points
        Dim CircularBorder, RasteredBorder, RasteredBorderBuffer As New Collection()
        Dim HorizontalRasterCount, VerticalRasterCount As Integer
        Dim LowerLeft As Point
        Dim RasterX, RasterY As Integer
        Dim RasteredBorderA(,) As Collection = New Collection(1, 1) {}
        Dim CantGo As Integer
        Dim ToolWorkRadius As Double = Tool.ToolDiameter / 2 + ToolRadiusCorrection
        Dim CamPathBuffer As New Collection() 'To buffer the sorted cam path if R0 is selected
        'Dim Point2 As New cPoint


        '----- Initial settings -----

        'Point2.X = 0
        'Point2.Y = 0

        CantGo = 0
        dblPoint1_X = 0.0
        dblPoint1_Y = ToolWorkRadius
        m_ToolOutline.Add(New cPoint(dblPoint1_X, dblPoint1_Y))
        DistanceBetweenBorderPoints = 0.05
        CamPathCount = 0
        m_CamPath.Clear()

        Select Case RadiusCorrection
            Case "RL"

                '----- 1. Create the outline of the tool ---------------------------------------

                Utilities.createCrirclarOutline(m_ToolOutline, ToolWorkRadius)


                '----- Add start coordinates to the tool --------------------------------------

                For x As Integer = 1 To m_ToolOutline.Count
                    collToolOutlineMoved.Add(New cPoint(m_ToolOutline.Item(x).X + StartPoint.X, m_ToolOutline.Item(x).Y + StartPoint.Y))
                Next

                ReDim Outline3X(collToolOutlineMoved.Count), Outline3Y(collToolOutlineMoved.Count)
                ReDim Outline1X(collToolOutlineMoved.Count), Outline1Y(collToolOutlineMoved.Count)

                For x As Integer = 1 To collToolOutlineMoved.Count
                    Outline3X(x) = collToolOutlineMoved.Item(x).X
                    Outline3Y(x) = collToolOutlineMoved.Item(x).Y
                Next

                Outline1Length = collToolOutlineMoved.Count

                '----- End create tool outline ------------------------------------------------

                '----- 2. Create the outline of the pocket by converting the pocket elements in a collection of points ------------------------------------

                Utilities.createContourList(m_CamElements, m_PocketOutline, DistanceBetweenBorderPoints)

                '----- 3. Find max and min of the enveloping rectangle -------------------------

#If DEBUG Then
                Console.WriteLine("3. Find max and min of the enveloping rectangle")
#End If

                m_PocketOutline.Add(StartPoint)   'Add start point to get the right raster (has to be removed after the rasterization)

                EnveloopUpperLeft.X = m_PocketOutline.Item(1).X
                EnveloopUpperLeft.Y = m_PocketOutline.Item(1).Y
                EnveloopLowerRight.X = m_PocketOutline.Item(1).X
                EnveloopLowerRight.Y = m_PocketOutline.Item(1).Y

                For x As Integer = 2 To m_PocketOutline.Count
                    If m_PocketOutline.Item(x).X < EnveloopUpperLeft.X Then
                        EnveloopUpperLeft.X = m_PocketOutline.Item(x).X
                    ElseIf m_PocketOutline.Item(x).X > EnveloopLowerRight.X Then
                        EnveloopLowerRight.X = m_PocketOutline.Item(x).X
                    End If
                    If m_PocketOutline.Item(x).Y > EnveloopUpperLeft.Y Then
                        EnveloopUpperLeft.Y = m_PocketOutline.Item(x).Y
                    ElseIf m_PocketOutline.Item(x).Y < EnveloopLowerRight.Y Then
                        EnveloopLowerRight.Y = m_PocketOutline.Item(x).Y
                    End If
                Next

                m_PocketOutline.Remove(m_PocketOutline.Count)   'remove the startpoint again

                '----- 4. Raster the border of the pocket --------------------------------------

                HorizontalRasterCount = CInt((EnveloopLowerRight.X - EnveloopUpperLeft.X) / (2 * (ToolWorkRadius) + 0.5)) + 4
                VerticalRasterCount = CInt((EnveloopUpperLeft.Y - EnveloopLowerRight.Y) / (2 * (ToolWorkRadius) + 0.5)) + 4

#If DEBUG Then
                Console.WriteLine(HorizontalRasterCount)
                Console.WriteLine(VerticalRasterCount)
#End If

                'Redim the Rastered-Border-Array

                ReDim RasteredBorderA(HorizontalRasterCount, VerticalRasterCount)
                For x As Integer = 0 To HorizontalRasterCount
                    For y As Integer = 0 To VerticalRasterCount
                        RasteredBorderA(x, y) = New Collection
                    Next
                Next

                Utilities.rasterTheBorder(RasteredBorderA, m_PocketOutline, EnveloopUpperLeft.X, EnveloopLowerRight.Y, ToolWorkRadius, HorizontalRasterCount, VerticalRasterCount)

                '----- 6. According to the radius correction (RL or RR) find the path along the border -----

#If DEBUG Then
                Console.WriteLine(" 6. According to the radius correction (RL or RR) find the path along the border")
#End If

                bolFindPath = True
                dblMovedDeltaX = 0
                dblMovedDeltaY = 0
                intPointCount = 0


                ' Find the border at the right side

                Utilities.findBorder(collPartOfPocketOutline, m_ToolOutline, RasteredBorderA, collToolOutlineMoved, ToolWorkRadius, DistanceBetweenBorderPoints, dblMovedDeltaX, dblMovedDeltaY, StartPoint, EnveloopUpperLeft, EnveloopLowerRight)

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
                    m_ToolOutline.Clear()
                    For intY = 1 To collToolOutlineMoved.Count
                        m_ToolOutline.Add(New cPoint(collToolOutlineMoved.Item(intY).X + dblMovedDeltaX, collToolOutlineMoved.Item(intY).Y + dblMovedDeltaY))
                    Next
                    'Console.WriteLine("Test 2")

                    '----- Select the partly border points -----

                    Z = 0
                    collPartOfPocketOutline.Clear()
                    RasteredBorderBuffer.Clear()

                    RasterX = CInt((StartPoint.X + dblMovedDeltaX - EnveloopUpperLeft.X) / (2 * (ToolWorkRadius) + 0.5)) + 2
                    RasterY = CInt((StartPoint.Y + dblMovedDeltaY - EnveloopLowerRight.Y) / (2 * (ToolWorkRadius) + 0.5)) + 2

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
                                If (RasteredBorderBuffer.Item(intX).X >= (StartPoint.X + dblMovedDeltaX - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).X <= (StartPoint.X + dblMovedDeltaX + (ToolWorkRadius) + 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).Y >= ((StartPoint.Y + dblMovedDeltaY - (ToolWorkRadius)) - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).Y <= (StartPoint.Y + dblMovedDeltaY + (ToolWorkRadius) + 2 * DistanceBetweenBorderPoints)) Then
                                    collPartOfPocketOutline.Add(RasteredBorderBuffer.Item(intX))
                                End If
                            Next
                            Direction = 1 'Right
                        Case "Down"
                            For intX = 1 To RasteredBorderBuffer.Count
                                If (RasteredBorderBuffer.Item(intX).X >= ((StartPoint.X + dblMovedDeltaX - (ToolWorkRadius)) - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).X <= (StartPoint.X + dblMovedDeltaX + (ToolWorkRadius) + 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).Y >= ((StartPoint.Y + dblMovedDeltaY - (ToolWorkRadius)) - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).Y <= (StartPoint.Y + dblMovedDeltaY)) Then
                                    collPartOfPocketOutline.Add(RasteredBorderBuffer.Item(intX))
                                End If
                            Next
                            Direction = 2 'Down
                        Case "Left"
                            For intX = 1 To RasteredBorderBuffer.Count
                                If (RasteredBorderBuffer.Item(intX).X >= ((StartPoint.X + dblMovedDeltaX - (ToolWorkRadius)) - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).X <= (StartPoint.X + dblMovedDeltaX)) And (RasteredBorderBuffer.Item(intX).Y >= ((StartPoint.Y + dblMovedDeltaY - (ToolWorkRadius)) - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).Y <= (StartPoint.Y + dblMovedDeltaY + (ToolWorkRadius) + 2 * DistanceBetweenBorderPoints)) Then
                                    collPartOfPocketOutline.Add(RasteredBorderBuffer.Item(intX))
                                End If
                            Next
                            Direction = 3 'Left
                        Case "Up"
                            For intX = 1 To RasteredBorderBuffer.Count
                                If (RasteredBorderBuffer.Item(intX).X >= ((StartPoint.X + dblMovedDeltaX - (ToolWorkRadius)) - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).X <= (StartPoint.X + dblMovedDeltaX + (ToolWorkRadius) + 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(intX).Y >= (StartPoint.Y + dblMovedDeltaY)) And (RasteredBorderBuffer.Item(intX).Y <= (StartPoint.Y + dblMovedDeltaY + (ToolWorkRadius) + 2 * DistanceBetweenBorderPoints)) Then
                                    collPartOfPocketOutline.Add(RasteredBorderBuffer.Item(intX))
                                End If
                            Next
                            Direction = 4 'Up
                    End Select
                    Outline2Length = Z
                    Z = 1
                    'Console.WriteLine("Test 4")

                    If Utilities.checkToolToBorderCollision(m_ToolOutline, collPartOfPocketOutline, strLastMoveDirection) = True Then
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

                    If CantGo > 7 Then
                        bolFindPath = False
                    End If

                    If ((StartPoint.X + dblMovedDeltaX) >= (cptPathStart.X - 3 * DistanceBetweenBorderPoints)) And ((StartPoint.X + dblMovedDeltaX) <= (cptPathStart.X + 3 * DistanceBetweenBorderPoints)) And ((StartPoint.Y + dblMovedDeltaY) >= (cptPathStart.Y - 3 * DistanceBetweenBorderPoints)) And ((StartPoint.Y + dblMovedDeltaY) <= (cptPathStart.Y + 3 * DistanceBetweenBorderPoints)) And bolFreeToFindPathStart = True Then
                        'If intPointCount > 100 Then
                        bolFindPath = False
                        'End If
                        intPathCount += 1
                        If intPathCount > 1 Then
                            DistanceBetweenBorderPoints = 0.1
                        End If
                        m_PocketOutline.Clear()
                        For intX = 1 To ActualClosedCamPathFragment.Count
                            m_PocketOutline.Add(ActualClosedCamPathFragment.Item(intX))
                        Next
                        ActualClosedCamPathFragment.Add(New cPoint(ActualClosedCamPathFragment.Item(1).X, ActualClosedCamPathFragment.Item(1).Y, "Border")) 'Close the fragment
                        Utilities.rasterTheBorder(RasteredBorderA, m_PocketOutline, EnveloopUpperLeft.X, EnveloopLowerRight.Y, (ToolWorkRadius), HorizontalRasterCount, VerticalRasterCount)

#If DEBUG Then
                        Console.WriteLine(intPathCount)
#End If

                        simplifyPocketMillingPath(ActualClosedCamPathFragment, DistanceBetweenBorderPoints)
                        ActualClosedCamPathFragment.Clear()

                        dblMovedDeltaX = 0 'Old: dblMovedDeltaX - (Tool.ToolDiameter /2 + 0.05)
                        dblMovedDeltaY = 0

                        '----- Begin check if toolpath is complete -----

                        m_ToolOutline.Clear()
                        For intY = 1 To collToolOutlineMoved.Count
                            m_ToolOutline.Add(New cPoint(collToolOutlineMoved.Item(intY).X + dblMovedDeltaX, collToolOutlineMoved.Item(intY).Y + dblMovedDeltaY))
                        Next

                        collPartOfPocketOutline.Clear()
                        For intX = 1 To m_PocketOutline.Count
                            If (m_PocketOutline.Item(intX).X >= ((StartPoint.X + dblMovedDeltaX - (ToolWorkRadius)) - 2 * DistanceBetweenBorderPoints)) And (m_PocketOutline.Item(intX).X <= (StartPoint.X + dblMovedDeltaX + (ToolWorkRadius) + 2 * DistanceBetweenBorderPoints)) And (m_PocketOutline.Item(intX).Y >= ((StartPoint.Y + dblMovedDeltaY - (ToolWorkRadius)) - 2 * DistanceBetweenBorderPoints)) And (m_PocketOutline.Item(intX).Y <= (StartPoint.Y + dblMovedDeltaY + (ToolWorkRadius) + 2 * DistanceBetweenBorderPoints)) Then
                                collPartOfPocketOutline.Add(m_PocketOutline.Item(intX))
                            End If
                        Next

                        If CheckIfToolBorderIsWithin(m_ToolOutline, collPartOfPocketOutline) = False Or intPathCount = 6 Then
                            bolFindPath = False
                        Else
                            Utilities.findBorder(collPartOfPocketOutline, m_ToolOutline, RasteredBorderA, collToolOutlineMoved, (ToolWorkRadius), DistanceBetweenBorderPoints, dblMovedDeltaX, dblMovedDeltaY, StartPoint, EnveloopUpperLeft, EnveloopLowerRight)
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
                    intPointCount += 1
                    'Console.WriteLine(CStr(intPointCount))
                Loop
            Case "RR"

            Case "R0"
                If Tool.ToolTyp <> "Laser" Then
                    cainsortElements(m_CamElements, CamPathBuffer, 0.1)
                Else
                    For i As Integer = 1 To m_CamElements.Count
                        CamPathBuffer.Add(New cLine(m_CamElements.Item(i)))
                    Next
                End If
                createCamPathForR0(CamPathBuffer)
        End Select

#If DEBUG Then
        Console.WriteLine("habe fertig")
#End If

        '----- 6. Complete the milling path --------------------------------------------

        completeCamPath()

        '----- 7. For test reasons show the milling path by adding it to the pocket elements ----------

        'm_CamElements.Add(New cLine(New cPoint(dblPoint3_X, dblPoint3_Y), New cPoint(dblPoint2_X, dblPoint2_Y)))


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

                'Console.WriteLine("CamPath.Count = " + CStr(m_CamPath.Count))

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

        Dim CamPathBuffer As New Collection()
        Dim x, y, z As Integer
        Dim ActualZ, LastZBeforGroundSteps As Double
        Dim BorderCount As Integer
        Dim BufferPoint As New cPoint
        Dim PatternDistanceCounterX As Double
        Dim PatternDistanceCounterY As Double

        '----- Initial settings -----

        PatternDistanceCounterX = 0
        PatternDistanceCounterY = 0
        ActualZ = StartPoint.Z
        ZSteps = CInt(((DepthOfCamEntity - (GroundSteps * InfeedGround)) / InfeedZ))
        If (ZSteps * InfeedZ + GroundSteps * InfeedGround) > DepthOfCamEntity Then
            ZSteps -= 1
        End If
        LastZBeforGroundSteps = DepthOfCamEntity - (GroundSteps * InfeedGround) - (ZSteps * InfeedZ)
        BorderCount = 0

#If DEBUG Then
        Console.WriteLine("ZSteps: " + CStr(ZSteps))
#End If

        '-----

        For x = 1 To m_CamPath.Count
            If m_CamPath.Item(x).CamDescription = "Border" Then
                BorderCount += 1
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

        m_CamPath.Clear()

        If Approach = True And Tool.ToolTyp <> "Laser" Then
            m_CamPath.Add(New cLine(StartPoint.X, StartPoint.Y, StartPoint.Z + 50, _
                                    StartPoint.X, StartPoint.Y, StartPoint.Z + 5, "Rapid"))
        Else
            m_CamPath.Add(New cLine(CamPathBuffer.Item(CamPathBuffer.Count).m_X1, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1, StartPoint.Z + 50, _
                                    CamPathBuffer.Item(CamPathBuffer.Count).m_X1, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1, StartPoint.Z + 5, "Rapid"))
        End If

        For py As Integer = 1 To PatternAmountY
            For px As Integer = 1 To PatternAmountX
                For y = 1 To ZSteps Step 1
                    ActualZ = ActualZ - InfeedZ
                    If Approach = True And Tool.ToolTyp <> "Laser" Then
                        m_CamPath.Add(New cLine(StartPoint.X + PatternDistanceCounterX, StartPoint.Y + PatternDistanceCounterY, StartPoint.Z + 5, _
                                                StartPoint.X + PatternDistanceCounterX, StartPoint.Y + PatternDistanceCounterY, ActualZ, "InfeedGround"))
                        m_CamPath.Add(New cLine(StartPoint.X + PatternDistanceCounterX, StartPoint.Y + PatternDistanceCounterY, ActualZ, _
                                                CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, ActualZ, "InfeedGround"))
                    ElseIf Tool.ToolTyp <> "Laser" Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, StartPoint.Z + 5, _
                                                CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, ActualZ, "InfeedGround"))
                    End If
                    For x = CamPathBuffer.Count To 1 Step (-1)
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(x)))
                        m_CamPath.Item(m_CamPath.Count).m_X1 = m_CamPath.Item(m_CamPath.Count).m_X1 + PatternDistanceCounterX
                        m_CamPath.Item(m_CamPath.Count).m_X2 = m_CamPath.Item(m_CamPath.Count).m_X2 + PatternDistanceCounterX
                        m_CamPath.Item(m_CamPath.Count).m_Y1 = m_CamPath.Item(m_CamPath.Count).m_Y1 + PatternDistanceCounterY
                        m_CamPath.Item(m_CamPath.Count).m_Y2 = m_CamPath.Item(m_CamPath.Count).m_Y2 + PatternDistanceCounterY
                        If Tool.ToolTyp <> "Laser" Then
                            m_CamPath.Item(m_CamPath.Count).m_Z1 = ActualZ
                            m_CamPath.Item(m_CamPath.Count).m_Z2 = ActualZ
                        Else
                            m_CamPath.Item(m_CamPath.Count).m_Z1 = StartPoint.Z
                            m_CamPath.Item(m_CamPath.Count).m_Z2 = StartPoint.Z
                        End If
                        m_CamPath.Item(m_CamPath.Count).CamDescription = "Work"
                    Next
                    If Approach = True And Tool.ToolTyp <> "Laser" Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, ActualZ, _
                                                CamPathBuffer.Item(1).m_X2, CamPathBuffer.Item(1).m_Y2, StartPoint.Z + 5, "Work"))
                        'If x > 1 Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, StartPoint.Z + 5, _
                                                StartPoint.X, StartPoint.Y, StartPoint.Z + 5, "Rapid"))
                        'End If
                    ElseIf Tool.ToolTyp <> "Laser" Then
                    m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, ActualZ, _
                                            CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, StartPoint.Z + 5, "Work"))
                    'If x > 1 Then
                    m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, StartPoint.Z + 5, _
                                            CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, StartPoint.Z + 5, "Rapid"))
                    'End If
                    Else
                    'If x > 1 Then
                    m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, ActualZ, _
                                             CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, ActualZ, "Rapid"))
                    'End If
                    End If
                Next

                '----- If dephth of pocket - GroundSteps * InfeedGround - ZSteps * InfeedZ is not even -----

                If LastZBeforGroundSteps > 0 Then
                    ActualZ = ActualZ - LastZBeforGroundSteps
                    If Approach = True And Tool.ToolTyp <> "Laser" Then
                        m_CamPath.Add(New cLine(StartPoint.X + PatternDistanceCounterX, StartPoint.Y + PatternDistanceCounterY, StartPoint.Z + 5, _
                                                StartPoint.X + PatternDistanceCounterX, StartPoint.Y + PatternDistanceCounterY, ActualZ, "InfeedGround"))
                        m_CamPath.Add(New cLine(StartPoint.X + PatternDistanceCounterX, StartPoint.Y + PatternDistanceCounterY, ActualZ, _
                                                CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, ActualZ, "InfeedGround"))
                    ElseIf Tool.ToolTyp <> "Laser" Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, StartPoint.Z + 5, _
                                                CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, ActualZ, "InfeedGround"))
                    End If
                    For x = CamPathBuffer.Count To 1 Step (-1)
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(x)))
                        m_CamPath.Item(m_CamPath.Count).m_X1 = m_CamPath.Item(m_CamPath.Count).m_X1 + PatternDistanceCounterX
                        m_CamPath.Item(m_CamPath.Count).m_X2 = m_CamPath.Item(m_CamPath.Count).m_X2 + PatternDistanceCounterX
                        m_CamPath.Item(m_CamPath.Count).m_Y1 = m_CamPath.Item(m_CamPath.Count).m_Y1 + PatternDistanceCounterY
                        m_CamPath.Item(m_CamPath.Count).m_Y2 = m_CamPath.Item(m_CamPath.Count).m_Y2 + PatternDistanceCounterY
                        If Tool.ToolTyp <> "Laser" Then
                            m_CamPath.Item(m_CamPath.Count).m_Z1 = ActualZ
                            m_CamPath.Item(m_CamPath.Count).m_Z2 = ActualZ
                        Else
                            m_CamPath.Item(m_CamPath.Count).m_Z1 = StartPoint.Z
                            m_CamPath.Item(m_CamPath.Count).m_Z2 = StartPoint.Z
                        End If
                        m_CamPath.Item(m_CamPath.Count).CamDescription = "Work"
                    Next
                    If Approach = True And Tool.ToolTyp <> "Laser" Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, ActualZ, _
                                                CamPathBuffer.Item(1).m_X2, CamPathBuffer.Item(1).m_Y2, StartPoint.Z + 5, "Work"))
                        'If x > 1 Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, StartPoint.Z + 5, _
                                                StartPoint.X, StartPoint.Y, StartPoint.Z + 5, "Rapid"))
                        'End If
                    ElseIf Tool.ToolTyp <> "Laser" Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, ActualZ, _
                                                CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, StartPoint.Z + 5, "Work"))
                        'If x > 1 Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, StartPoint.Z + 5, _
                                                CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, StartPoint.Z + 5, "Rapid"))
                        'End If
                    Else
                        'If x > 1 Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, ActualZ, _
                                                 CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, ActualZ, "Rapid"))
                        'End If
                    End If
                End If

                '----- Ground steps -----

                For y = 1 To GroundSteps
                    ActualZ = ActualZ - InfeedGround
                    If Approach = True And Tool.ToolTyp <> "Laser" Then
                        m_CamPath.Add(New cLine(StartPoint.X + PatternDistanceCounterX, StartPoint.Y + PatternDistanceCounterY, StartPoint.Z + 5, _
                                                StartPoint.X + PatternDistanceCounterX, StartPoint.Y + PatternDistanceCounterY, ActualZ, "InfeedGround"))
                        m_CamPath.Add(New cLine(StartPoint.X + PatternDistanceCounterX, StartPoint.Y + PatternDistanceCounterY, ActualZ, _
                                                CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, ActualZ, "InfeedGround"))
                    ElseIf Tool.ToolTyp <> "Laser" Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, StartPoint.Z + 5, _
                                                CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, ActualZ, "InfeedGround"))
                    End If
                    For x = CamPathBuffer.Count To 1 Step (-1)
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(x)))
                        m_CamPath.Item(m_CamPath.Count).m_X1 = m_CamPath.Item(m_CamPath.Count).m_X1 + PatternDistanceCounterX
                        m_CamPath.Item(m_CamPath.Count).m_X2 = m_CamPath.Item(m_CamPath.Count).m_X2 + PatternDistanceCounterX
                        m_CamPath.Item(m_CamPath.Count).m_Y1 = m_CamPath.Item(m_CamPath.Count).m_Y1 + PatternDistanceCounterY
                        m_CamPath.Item(m_CamPath.Count).m_Y2 = m_CamPath.Item(m_CamPath.Count).m_Y2 + PatternDistanceCounterY
                        If Tool.ToolTyp <> "Laser" Then
                            m_CamPath.Item(m_CamPath.Count).m_Z1 = ActualZ
                            m_CamPath.Item(m_CamPath.Count).m_Z2 = ActualZ
                        Else
                            m_CamPath.Item(m_CamPath.Count).m_Z1 = StartPoint.Z
                            m_CamPath.Item(m_CamPath.Count).m_Z2 = StartPoint.Z
                        End If
                        m_CamPath.Item(m_CamPath.Count).CamDescription = "Work"
                    Next
                    If Approach = True And Tool.ToolTyp <> "Laser" Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, ActualZ, _
                                                CamPathBuffer.Item(1).m_X2, CamPathBuffer.Item(1).m_Y2, StartPoint.Z + 5, "Work"))
                        'If x > 1 Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, StartPoint.Z + 5, _
                                                StartPoint.X, StartPoint.Y, StartPoint.Z + 5, "Rapid"))
                        'End If
                    ElseIf Tool.ToolTyp <> "Laser" Then
                    m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, ActualZ, _
                                            CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, StartPoint.Z + 5, "Work"))
                        ' If x > 1 Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, StartPoint.Z + 5, _
                                                CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, StartPoint.Z + 5, "Rapid"))
                        'End If
                    Else
                        'If x > 1 Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, ActualZ, _
                                                 CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, ActualZ, "Rapid"))
                        'End If
                    End If
                Next
                If PatternAmountX > 1 And px < PatternAmountX Then
                    If Approach = True And Tool.ToolTyp <> "Laser" Then
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, StartPoint.Z + 5, _
                                               StartPoint.X + PatternDistanceCounterX + PatternDistanceX, StartPoint.Y + PatternDistanceCounterY, StartPoint.Z + 5, "Rapid"))
                    Else
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, StartPoint.Z + 5, _
                                              CamPathBuffer.Item(CamPathBuffer.Count).m_X1 + PatternDistanceCounterX + PatternDistanceX, CamPathBuffer.Item(CamPathBuffer.Count).m_Y1 + PatternDistanceCounterY, StartPoint.Z + 5, "Rapid"))
                    End If
                    PatternDistanceCounterX += PatternDistanceX
                End If
                ActualZ = StartPoint.Z
            Next
            If py < PatternAmountY Then
                PatternDistanceCounterY += PatternDistanceY
            End If
        Next

        If Approach = True And Tool.ToolTyp <> "Laser" Then
            m_CamPath.Add(New cLine(StartPoint.X + PatternDistanceCounterX, StartPoint.Y + PatternDistanceCounterY, StartPoint.Z + 5, _
                                    StartPoint.X + PatternDistanceCounterX, StartPoint.Y + PatternDistanceCounterY, StartPoint.Z + 50, "Rapid"))
        Else
            m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, StartPoint.Z + 5, _
                                    CamPathBuffer.Item(1).m_X2 + PatternDistanceCounterX, CamPathBuffer.Item(1).m_Y2 + PatternDistanceCounterY, StartPoint.Z + 50, "Rapid"))
        End If
        Return True
    End Function


    Public Function createCamPathForR0(ByRef CamPathBuffer As Collection) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Creates the cam path if R0 is selected
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim CircularBorder As New Collection()

        '----- Initial settings -----

        m_CamPath.Clear()

        '-----

        '----- Add the first element to the cam path -----

        If CamPathBuffer.Count > 1 Then
            Select Case CamPathBuffer.Item(1).GetType()
                Case GetType(cLine)
                    If Tool.ToolTyp <> "Laser" Then
                        If (CamPathBuffer.Item(1).m_X1 = CamPathBuffer.Item(2).m_X1 And _
                            CamPathBuffer.Item(1).m_Y1 = CamPathBuffer.Item(2).m_Y1) Or _
                            (CamPathBuffer.Item(1).m_X1 = CamPathBuffer.Item(2).m_X2 And _
                            CamPathBuffer.Item(1).m_Y1 = CamPathBuffer.Item(2).m_Y2) Then

                            m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X1, CamPathBuffer.Item(1).m_Y1, CamPathBuffer.Item(1).m_Z1, CamPathBuffer.Item(1).m_X2, CamPathBuffer.Item(1).m_Y2, CamPathBuffer.Item(1).m_Z2))

                        ElseIf (CamPathBuffer.Item(1).m_X2 = CamPathBuffer.Item(2).m_X1 And _
                            CamPathBuffer.Item(1).m_Y2 = CamPathBuffer.Item(2).m_Y1) Or _
                            (CamPathBuffer.Item(1).m_X2 = CamPathBuffer.Item(2).m_X2 And _
                            CamPathBuffer.Item(1).m_Y2 = CamPathBuffer.Item(2).m_Y2) Then

                            m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2, CamPathBuffer.Item(1).m_Y2, CamPathBuffer.Item(1).m_Z2, CamPathBuffer.Item(1).m_X1, CamPathBuffer.Item(1).m_Y1, CamPathBuffer.Item(1).m_Z1))

                        End If
                    Else
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1)))
                    End If
                Case GetType(cArc)
                    If (CamPathBuffer.Item(1).m_X1 = CamPathBuffer.Item(2).m_X1 And _
                        CamPathBuffer.Item(1).m_Y1 = CamPathBuffer.Item(2).m_Y1) Or _
                        (CamPathBuffer.Item(1).m_X1 = CamPathBuffer.Item(2).m_X2 And _
                        CamPathBuffer.Item(1).m_Y1 = CamPathBuffer.Item(2).m_Y2) Then

                        Utilities.getCircularBorder(CircularBorder, CamPathBuffer.Item(1), 0.02)
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2, CamPathBuffer.Item(1).m_Y2, CamPathBuffer.Item(1).m_Z2, New cPoint(CircularBorder.Item(CircularBorder.Count - 1))))
                        For j As Integer = CircularBorder.Count - 1 To 3 Step (-1)
                            m_CamPath.Add(New cLine(CircularBorder.Item(j), CircularBorder.Item(j - 1)))
                        Next
                        m_CamPath.Add(New cLine(New cPoint(CircularBorder.Item(2)), CamPathBuffer.Item(1).m_X1, CamPathBuffer.Item(1).m_Y1, CamPathBuffer.Item(1).m_Z1))
                        CircularBorder.Clear()

                    ElseIf (CamPathBuffer.Item(1).m_X2 = CamPathBuffer.Item(2).m_X1 And _
                        CamPathBuffer.Item(1).m_Y2 = CamPathBuffer.Item(2).m_Y1) Or _
                        (CamPathBuffer.Item(1).m_X2 = CamPathBuffer.Item(2).m_X2 And _
                        CamPathBuffer.Item(1).m_Y2 = CamPathBuffer.Item(2).m_Y2) Then

                        Utilities.getCircularBorder(CircularBorder, CamPathBuffer.Item(1), 0.02)
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X1, CamPathBuffer.Item(1).m_Y1, CamPathBuffer.Item(1).m_Z1, New cPoint(CircularBorder.Item(2))))
                        For j As Integer = 2 To CircularBorder.Count - 1
                            m_CamPath.Add(New cLine(CircularBorder.Item(j), CircularBorder.Item(j + 1)))
                        Next
                        m_CamPath.Add(New cLine(New cPoint(CircularBorder.Item(CircularBorder.Count - 1)), CamPathBuffer.Item(1).m_X2, CamPathBuffer.Item(1).m_Y2, CamPathBuffer.Item(1).m_Z2))
                        CircularBorder.Clear()
                    End If
            End Select
        Else
             Select CamPathBuffer.Item(1).GetType()
                Case GetType(cLine)
                    m_CamPath.Add(New cLine(CamPathBuffer.Item(1)))
                Case GetType(cCircle)

                Case GetType(cArc)
            End Select
            Return True
        End If
        CamPathBuffer.Remove(1)

        Do While (CamPathBuffer.Count >= 1)
            Select Case CamPathBuffer.Item(1).GetType()
                Case GetType(cLine)
                    If Tool.ToolTyp <> "Laser" Then
                        If (CamPathBuffer.Item(1).m_X1 = m_CamPath.Item(m_CamPath.Count).m_X1 And _
                            CamPathBuffer.Item(1).m_Y1 = m_CamPath.Item(m_CamPath.Count).m_Y1) Then

                            m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2, CamPathBuffer.Item(1).m_Y2, CamPathBuffer.Item(1).m_Z2, CamPathBuffer.Item(1).m_X1, CamPathBuffer.Item(1).m_Y1, CamPathBuffer.Item(1).m_Z1))

                        ElseIf (CamPathBuffer.Item(1).m_X2 = m_CamPath.Item(m_CamPath.Count).m_X1 And _
                            CamPathBuffer.Item(1).m_Y2 = m_CamPath.Item(m_CamPath.Count).m_Y1) Then

                            m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X1, CamPathBuffer.Item(1).m_Y1, CamPathBuffer.Item(1).m_Z1, CamPathBuffer.Item(1).m_X2, CamPathBuffer.Item(1).m_Y2, CamPathBuffer.Item(1).m_Z2))

                        End If
                    Else
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1)))
                    End If
                    CamPathBuffer.Remove(1)
                Case GetType(cArc)
                    If (CamPathBuffer.Item(1).StartPoint.X = m_CamPath.Item(m_CamPath.Count).EndPoint.X And _
                        CamPathBuffer.Item(1).StartPoint.Y = m_CamPath.Item(m_CamPath.Count).EndPoint.Y) Then

                        Utilities.getCircularBorder(CircularBorder, CamPathBuffer.Item(1), 0.02)
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X2, CamPathBuffer.Item(1).m_Y2, CamPathBuffer.Item(1).m_Z2, New cPoint(CircularBorder.Item(CircularBorder.Count - 1))))
                        For j As Integer = CircularBorder.Count - 1 To 3 Step (-1)
                            m_CamPath.Add(New cLine(CircularBorder.Item(j), CircularBorder.Item(j - 1)))
                        Next
                        m_CamPath.Add(New cLine(New cPoint(CircularBorder.Item(2)), CamPathBuffer.Item(1).m_X1, CamPathBuffer.Item(1).m_Y1, CamPathBuffer.Item(1).m_Z1))
                        CircularBorder.Clear()

                    ElseIf (CamPathBuffer.Item(1).EndPoint.X = m_CamPath.Item(m_CamPath.Count).EndPoint.X And _
                        CamPathBuffer.Item(1).EndPoint.Y = m_CamPath.Item(m_CamPath.Count).EndPoint.Y) Then

                        Utilities.getCircularBorder(CircularBorder, CamPathBuffer.Item(1), 0.02)
                        m_CamPath.Add(New cLine(CamPathBuffer.Item(1).m_X1, CamPathBuffer.Item(1).m_Y1, CamPathBuffer.Item(1).m_Z1, New cPoint(CircularBorder.Item(2))))
                        For j As Integer = 2 To CircularBorder.Count - 1
                            m_CamPath.Add(New cLine(CircularBorder.Item(j), CircularBorder.Item(j + 1)))
                        Next
                        m_CamPath.Add(New cLine(New cPoint(CircularBorder.Item(CircularBorder.Count - 1)), CamPathBuffer.Item(1).m_X2, CamPathBuffer.Item(1).m_Y2, CamPathBuffer.Item(1).m_Z2))
                        CircularBorder.Clear()
                    End If

            End Select
        Loop

        Return True
    End Function
End Class
