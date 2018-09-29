Imports System.Math
Imports System.Linq
Imports System.Runtime.InteropServices

Public Class Win32
    'Declare Function test_array Lib "D:\softwaredevelopement\3-Axis\software\dynamic_link_libraries\ot3autils\Debug\ot3autils.dll" (ByVal a As Integer, ByVal b As Integer) As IntPtr
    ' Declares managed prototype for an array of integers by reference.
    ' The array size can change, but the array is not copied back 
    ' automatically because the marshaler does not know the resulting size.
    ' The copy must be performed manually.
    Declare Function test_array Lib "D:\softwaredevelopement\3-Axis\software\dynamic_link_libraries\ot3autils\Debug\ot3autils.dll" (
       ByRef myArray As IntPtr, ByVal size As Integer) As Integer
End Class

Public Class cOdarTecUtilities

    '----- constructors -------------------------------------------------

    Sub New()
        'Dim Result As IntPtr = Marshal.AllocHGlobal(4)
        'Dim dbl As Double
        'Dim testarray(2, 2) As Double
        'Result = Win32.test_array(2, 2)
        ''derefference the double pointer, i(integer) Is actually the index in the array of doubles
        'For i As Integer = 0 To 3
        '    dbl = CType(Marshal.PtrToStructure(IntPtr.Add(Result, i * 8), GetType(Double)), Double)
        '    Console.WriteLine("The result of array index {0} = {1}", i, dbl)
        'Next
        Dim array2(9) As Double
        Dim arraySize As Integer = array2.Length
        Dim size As Integer = Marshal.SizeOf(array2(0)) * array2.Length

        Console.WriteLine(ControlChars.CrLf & ControlChars.CrLf & "double array passed ByRef before call:")
        For i = 0 To array2.Length - 1
            array2(i) = i
            Console.Write(" " & array2(i))
        Next i
        Dim buffer As IntPtr = Marshal.AllocHGlobal(size)   'Marshal.AllocCoTaskMem(Marshal.SizeOf(arraySize) * array2.Length)
        Marshal.Copy(array2, 0, buffer, arraySize)
        Win32.test_array(buffer, arraySize)

        If arraySize > 0 Then
            Dim arrayRes(arraySize) As Double
            Marshal.Copy(buffer, arrayRes, 0, arraySize)


            Console.WriteLine(ControlChars.CrLf & "Double array passed ByRef after call:")
            For Each i In arrayRes
                Console.Write(" " & i)
            Next i
            Marshal.FreeCoTaskMem(buffer)
        Else
            Console.WriteLine(ControlChars.CrLf & "Array after call is empty")
        End If
    End Sub


    '----- member variables ---------------------------------------------

    Structure dblPoint
        Public X As Double
        Public Y As Double
    End Structure


    '----- member methodes ----------------------------------------------

    Public Function chrarrfGetCharFromInteger(iValue As Integer)
        Dim chrarrValue(8) As Char
        Dim iBuffer As Integer
        Dim iDivisor As Integer = 10000000
        For x As Integer = 7 To 0 Step -1
            iBuffer = iValue \ iDivisor
            Select Case iBuffer
                Case 0
                    chrarrValue(x) = "0"
                Case 1
                    chrarrValue(x) = "1"
                    iValue = iValue - iDivisor
                Case 2
                    chrarrValue(x) = "2"
                    iValue = iValue - 2 * iDivisor
                Case 3
                    chrarrValue(x) = "3"
                    iValue = iValue - 3 * iDivisor
                Case 4
                    chrarrValue(x) = "4"
                    iValue = iValue - 4 * iDivisor
                Case 5
                    chrarrValue(x) = "5"
                    iValue = iValue - 5 * iDivisor
                Case 6
                    chrarrValue(x) = "6"
                    iValue = iValue - 6 * iDivisor
                Case 7
                    chrarrValue(x) = "7"
                    iValue = iValue - 7 * iDivisor
                Case 8
                    chrarrValue(x) = "8"
                    iValue = iValue - 8 * iDivisor
                Case 9
                    chrarrValue(x) = "9"
                    iValue = iValue - 9 * iDivisor
            End Select
            iDivisor = iDivisor / 10
        Next x
        'For z = 7 To 0 Step -1
        'Console.Write(chrarrValue(z))
        'Next
        Return chrarrValue
    End Function

    Public Function createCrirclarOutline(ByRef CircularOutline As Collection, Radius As Double) As Boolean

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

        Dim x, y, Point1_X, Point1_Y, Point2_X, Point2_Y, Point3_X, Point3_Y As Double
        Dim Count As Integer


        For x = 0 To (Radius + 0.0005) Step 0.02 '0.015 'DistanceBetweenBorderPoints
            If x > Radius Then
                x = Radius
            End If
            Point2_Y = Math.Sqrt(Radius ^ 2 - x ^ 2)
            If (Point1_Y - Point2_Y) <= 0.015 Then
                CircularOutline.Add(New cPoint(x, Point2_Y))
            Else
                For y = 0 To (Point1_Y - Point2_Y) Step 0.015 'DistanceBetweenBorderPoints
                    CircularOutline.Add(New cPoint(x, Point1_Y - y))

#If DEBUG Then
                    Console.Write("X = ")
                    Console.Write(Point3_X)
                    Console.WriteLine(" ")
                    Console.Write("Y = ")
                    Console.Write(Point3_Y)
                    Console.WriteLine(" ")
#End If

                Next
            End If
            Point1_X = Point2_X
            Point1_Y = Point2_Y

#If DEBUG Then
            Console.Write("X = ")
            Console.Write(Point2_X)
            Console.WriteLine(" ")
            Console.Write("Y = ")
            Console.Write(Point2_Y)
            Console.WriteLine(" ")
#End If

        Next

        '----- Second 90° -----

        Count = CircularOutline.Count

        For intX = (Count - 1) To 1 Step (-1)
            Point1_X = CircularOutline.Item(intX).X
            Point1_Y = (CircularOutline.Item(intX).Y) / (-1)
            CircularOutline.Add(New cPoint(CircularOutline.Item(intX).X, (CircularOutline.Item(intX).Y) / (-1)))

#If DEBUG Then
            Console.Write("X = ")
            Console.Write(Point1_X)
            Console.WriteLine(" ")
            Console.Write("Y = ")
            Console.Write(Point1_Y)
            Console.WriteLine(" ")
#End If

        Next

        '----- Third 90° -----

        For intX = 1 To Count
            CircularOutline.Add(New cPoint((CircularOutline.Item(intX).X) / (-1), (CircularOutline.Item(intX).Y) / (-1)))
        Next

        '----- Fourth 90° -----

        For intX = (Count - 1) To 2 Step -1
            CircularOutline.Add(New cPoint((CircularOutline.Item(intX).X) / (-1), CircularOutline.Item(intX).Y))
        Next

        Return True
    End Function

    Public Function checkToolToBorderCollision(ByRef Outline1 As Collection, ByRef Outline2 As Collection, Direction As String) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Check if the pocket outline intersects the tool outline
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim intX, intX2, intY, intY2 As Integer

        Select Case Direction
            Case "Right"
                For intY = 1 To ((Outline1.Count / 4) - 1)
                    For intY2 = 1 To Outline2.Count
                        If (Outline2.Item(intY2).Y < Outline1.Item(intY).Y) And (Outline2.Item(intY2).Y > Outline1.Item(Outline1.Count / 2 + 1 - intY).Y) And (Outline2.Item(intY2).X > (Outline1.Item(intY).X - 0.05)) And (Outline2.Item(intY2).X < (Outline1.Item(intY).X + 0.05)) Then
                            Return True
                        End If
                    Next
                Next
            Case "Down"
                For intX = (Outline1.Count / 4) To (Outline1.Count / 2 - 1)
                    For intX2 = 1 To Outline2.Count
                        If (Outline2.Item(intX2).X > Outline1.Item(Outline1.Count + 1 - intX).X) And (Outline2.Item(intX2).X < Outline1.Item(intX).X) And (Outline2.Item(intX2).Y > (Outline1.Item(intX).Y - 0.05)) And (Outline2.Item(intX2).Y < (Outline1.Item(intX).Y + 0.05)) Then
                            Return True
                        End If
                    Next
                Next
            Case "Left"
                intX = 0
                For intY = (Outline1.Count / 2) To ((Outline1.Count / 4) * 3 - 1)
                    For intY2 = 1 To Outline2.Count
                        If (Outline2.Item(intY2).Y > Outline1.Item(intY).Y) And (Outline2.Item(intY2).Y < Outline1.Item(Outline1.Count - intX).Y) And (Outline2.Item(intY2).X > (Outline1.Item(intY).X - 0.05)) And (Outline2.Item(intY2).X < (Outline1.Item(intY).X + 0.05)) Then
                            Return True
                        End If
                    Next
                    intX += 1
                Next
            Case "Up"
                For intX = 2 To (Outline1.Count / 4)
                    For intX2 = 1 To Outline2.Count
                        If (Outline2.Item(intX2).X > Outline1.Item(Outline1.Count + 1 - intX).X) And (Outline2.Item(intX2).X < Outline1.Item(intX).X) And (Outline2.Item(intX2).Y > (Outline1.Item(intX).Y - 0.05)) And (Outline2.Item(intX2).Y < (Outline1.Item(intX).Y + 0.05)) Then
                            Return True
                        End If
                    Next
                Next
        End Select
        Return False
    End Function

    Public Function getCircularBorder(ByRef Border As Collection, Arc As cArc, Distance As Double) As Boolean
        getCircularBorder(Border, Arc.StartAngle, Arc.EndAngle, Arc.Radius, Distance)
        Return False
    End Function

    Public Function getCircularBorder(ByRef Border As Collection, Radius As Double, Distance As Double) As Boolean
        getCircularBorder(Border, 0, 360, Radius, Distance)
        Return False
    End Function

    Public Function getCircularBorder(ByRef Border As Collection, StartAngle As Double, EndAngle As Double, Radius As Double, Distance As Double) As Boolean

        '----- Begin Description -----------------------------------------------------------------------------------------------------
        '
        ' Purpose:  Creates a collection "B o r d e r" of points where the points lie at the circumference of a circle with the
        '           given "R a d i u s". The maximal deviation of a line between two such points and the circumfrence is determined
        '           by the "D i s t a n c e". The calculation starts at the "S t a r t A n g e l" and stops at the "E n d A n g e l".
        '           An vector wit an angle of 0° has horizontal direction and points to the right. Angles get bigger counterclockwise.
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -----------------------------------------------------------------------------------------------------------------
        '
        '----- End description -------------------------------------------------------------------------------------------------------

        getCircularBorder(Border, StartAngle, EndAngle, Radius, Distance, "Clockwise")
        Return True

    End Function

    Public Function getCircularBorder(ByRef Border As Collection, StartAngle As Double, EndAngle As Double, Radius As Double, Distance As Double, Direction As String) As Boolean

        '----- Begin Description -----------------------------------------------------------------------------------------------------
        '
        ' Purpose:  Creates a collection "B o r d e r" of points where the points lie at the circumference of a circle with the
        '           given "R a d i u s". The maximal deviation of a line between two such points and the circumfrence is determined
        '           by the "D i s t a n c e". The calculation starts at the "S t a r t A n g e l" and stops at the "E n d A n g e l".
        '           An vector wit an angle of 0° has horizontal direction and points to the right. Angles get bigger counterclockwise.
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -----------------------------------------------------------------------------------------------------------------
        '
        '----- End description -------------------------------------------------------------------------------------------------------

        Dim x As Double
        Dim Point1 As New cPoint()
        Dim AngleStep As Double

        AngleStep = ((Math.Atan(Distance / 2 / Radius)) / (2 * Math.PI) * 360) * 2

#If DEBUG Then
        Console.WriteLine(AngleStep)
#End If

        If Direction = "ClockWise" Then

            If StartAngle > EndAngle Then
                For x = StartAngle To 360 Step AngleStep
                    Select Case x
                        Case Is <= 90
                            Point1.X = Math.Cos(x * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin(x * 2 * Math.PI / 360) * Radius
                        Case Is > 90, Is <= 180
                            Point1.X = Math.Cos((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((180 - x) * 2 * Math.PI / 360) * Radius
                        Case Is > 180, Is <= 270
                            Point1.X = Math.Cos((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 270
                            Point1.X = Math.Cos((360 - x) * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin((360 - x) * 2 * Math.PI / 360) * Radius / (-1)
                    End Select
                    Border.Add(New cPoint(Point1.X, Point1.Y))
                Next
                For x = 0 To EndAngle Step AngleStep
                    Select Case x
                        Case Is <= 90
                            Point1.X = Math.Cos(x * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin(x * 2 * Math.PI / 360) * Radius
                        Case Is > 90, Is <= 180
                            Point1.X = Math.Cos((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((180 - x) * 2 * Math.PI / 360) * Radius
                        Case Is > 180, Is <= 270
                            Point1.X = Math.Cos((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 270
                            Point1.X = Math.Cos((360 - x) * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin((360 - x) * 2 * Math.PI / 360) * Radius / (-1)
                    End Select
                    Border.Add(New cPoint(Point1.X, Point1.Y))
                Next
            Else
                For x = StartAngle To EndAngle Step AngleStep
                    Select Case x
                        Case Is <= 90
                            Point1.X = Math.Cos(x * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin(x * 2 * Math.PI / 360) * Radius
                        Case Is > 90, Is <= 180
                            Point1.X = Math.Cos((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((180 - x) * 2 * Math.PI / 360) * Radius
                        Case Is > 180, Is <= 270
                            Point1.X = Math.Cos((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 270
                            Point1.X = Math.Cos((360 - x) * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin((360 - x) * 2 * Math.PI / 360) * Radius / (-1)
                    End Select
                    Border.Add(New cPoint(Point1.X, Point1.Y))
                Next

#If DEBUG Then
                Console.WriteLine(Border.Count)
#End If

            End If

        ElseIf Direction = "CounterClockWise" Then

            If StartAngle > EndAngle Then
                For x = StartAngle To 360 Step AngleStep
                    Select Case x
                        Case Is <= 90
                            Point1.X = Math.Cos(x * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin(x * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 90, Is <= 180
                            Point1.X = Math.Cos((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 180, Is <= 270
                            Point1.X = Math.Cos((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((x - 180) * 2 * Math.PI / 360) * Radius
                        Case Is > 270
                            Point1.X = Math.Cos((360 - x) * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin((360 - x) * 2 * Math.PI / 360) * Radius
                    End Select
                    Border.Add(New cPoint(Point1.X, Point1.Y))
                Next
                For x = 0 To EndAngle Step AngleStep
                    Select Case x
                        Case Is <= 90
                            Point1.X = Math.Cos(x * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin(x * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 90, Is <= 180
                            Point1.X = Math.Cos((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 180, Is <= 270
                            Point1.X = Math.Cos((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((x - 180) * 2 * Math.PI / 360) * Radius
                        Case Is > 270
                            Point1.X = Math.Cos((360 - x) * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin((360 - x) * 2 * Math.PI / 360) * Radius
                    End Select
                    Border.Add(New cPoint(Point1.X, Point1.Y))
                Next
            Else
                For x = StartAngle To EndAngle Step AngleStep
                    Select Case x
                        Case Is <= 90
                            Point1.X = Math.Cos(x * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin(x * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 90, Is <= 180
                            Point1.X = Math.Cos((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 180, Is <= 270
                            Point1.X = Math.Cos((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((x - 180) * 2 * Math.PI / 360) * Radius
                        Case Is > 270
                            Point1.X = Math.Cos((360 - x) * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin((360 - x) * 2 * Math.PI / 360) * Radius
                    End Select
                    Border.Add(New cPoint(Point1.X, Point1.Y))
                Next

#If DEBUG Then
                Console.WriteLine(Border.Count)
#End If

            End If

        End If

        Return False
    End Function

    Public Function rasterTheBorder(ByRef RasteredBorder(,) As Collection, ByRef PocketOutline As Collection, X As Double, Y As Double, Radius As Double, Collums As Integer, Rows As Integer) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Check if the pocket outline intersects the tool outline
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim z, zz As Integer

        For z = 0 To Collums
            For zz = 0 To Rows
                RasteredBorder(z, zz).Clear()
            Next
        Next

        If PocketOutline.Count > 0 Then
            For z = 1 To PocketOutline.Count

#If DEBUG Then
                Console.WriteLine(z)
#End If

                RasteredBorder(CInt((PocketOutline.Item(z).X - X) / (2 * Radius + 0.5)) + 2, CInt((PocketOutline.Item(z).Y - Y) / (2 * Radius + 0.5)) + 2).Add(PocketOutline.Item(z))
            Next
            Return True
        End If
        Return False
    End Function

    Public Function findBorder(ByRef collPartOfPocketOutline As Collection, ByRef ToolOutline As Collection, ByRef RasteredBorderA(,) As Collection, ByRef collToolOutlineMoved As Collection, ToolRadius As Double, DistanceBetweenBorderPoints As Double, ByRef MovedDeltaX As Double, ByRef MovedDeltaY As Double, StartPoint As cPoint, EnveloopUpperLeft As cPoint, EnveloopLowerRight As cPoint) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Check if the pocket outline intersects the tool outline
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim Point2_X, point2_Y As Double
        Dim x, y, z, zz, zzz, zzzz, RasterX, RasterY As Integer
        Dim RasteredBorderBuffer As New Collection

        Do While 1

            MovedDeltaX += 0.1
            collPartOfPocketOutline.Clear()
            RasteredBorderBuffer.Clear()

            RasterX = CInt((StartPoint.X + MovedDeltaX - EnveloopUpperLeft.X) / (2 * ToolRadius + 0.5)) + 2
            RasterY = CInt((StartPoint.Y + MovedDeltaY - EnveloopLowerRight.Y) / (2 * ToolRadius + 0.5)) + 2

            For zzz = -1 To 1
                For zzzz = -1 To 1
                    If RasteredBorderA(RasterX - zzzz, RasterY - zzz).Count > 0 Then
                        For zz = 1 To CInt(RasteredBorderA(RasterX - zzzz, RasterY - zzz).Count)
                            RasteredBorderBuffer.Add(RasteredBorderA(RasterX - zzzz, RasterY - zzz).Item(zz))
                        Next
                    End If
                Next
            Next

            ToolOutline.Clear()
            For y = 1 To collToolOutlineMoved.Count
                ToolOutline.Add(New cPoint(collToolOutlineMoved.Item(y).X + MovedDeltaX, collToolOutlineMoved.Item(y).Y + MovedDeltaY))
            Next
            collPartOfPocketOutline.Clear()
            For x = 1 To RasteredBorderBuffer.Count
                If (RasteredBorderBuffer.Item(x).X >= (StartPoint.X + MovedDeltaX - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(x).X <= (StartPoint.X + MovedDeltaX + ToolRadius + 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(x).Y >= ((StartPoint.Y + MovedDeltaY - ToolRadius) - 2 * DistanceBetweenBorderPoints)) And (RasteredBorderBuffer.Item(x).Y <= (StartPoint.Y + MovedDeltaY + ToolRadius + 2 * DistanceBetweenBorderPoints)) Then
                    collPartOfPocketOutline.Add(RasteredBorderBuffer.Item(x))
                End If
            Next

            If checkToolToBorderCollision(ToolOutline, collPartOfPocketOutline, "Right") = True Then
                MovedDeltaX -= DistanceBetweenBorderPoints
                Return True
            End If
            Point2_X = StartPoint.X + MovedDeltaX
            point2_Y = StartPoint.Y + MovedDeltaY

#If DEBUG Then
            Console.Write("dblMovedDeltaX = ")
            Console.Write(MovedDeltaX)
            Console.WriteLine(" ")
            Console.Write("PX = ")
            Console.Write(Point2_X)
            Console.Write(" ; ")
            Console.Write("PY = ")
            Console.Write(point2_Y)
            Console.WriteLine(" ")
#End If

        Loop
        Return False
    End Function

    Public Function getNearestElement(ByRef CollectionToTest As Collection, MouseX As Integer, MouseY As Integer, Toggle As Integer, GeoMan As cOTGeometricRepresentationManager) As String

        Return getNearestElement(CollectionToTest, MouseX, MouseY, Toggle, "none", GeoMan)
    End Function

    Public Function getNearestElement(ByRef CollectionToTest As Collection, MouseX As Integer, MouseY As Integer, Toggle As Integer, Filter As String, GeoMan As cOTGeometricRepresentationManager) As String
        Dim i As Integer
        Dim x, y, NewDistanceX, OldDistanceX, NewDistanceY, OldDistanceY As Double
        Dim tanAlpha As Double
        Dim NearestElement As String = ""
        Dim Point1 As Point
        Dim Point2 As New cPoint
        Dim AngleStep As Double
        Dim Accuracy As Double

        '----- Initial settings -----

        OldDistanceX = 3
        OldDistanceY = 3
        Accuracy = 0.1

        For i = 1 To CollectionToTest.Count
            Select Case CollectionToTest.Item(i).GetType()
                Case GetType(cLine)
                    Dim WhatWasNearby As String
                    WhatWasNearby = checkIfPointIsNearby(CollectionToTest.Item(i), New cPoint(MouseX, MouseY), OldDistanceX, GeoMan)
                    If WhatWasNearby = "Line" Or WhatWasNearby = "Endpoint" Or WhatWasNearby = "Startpoint" Then
                        NearestElement = CollectionToTest.Item(i).NameOfEntity
                        Select Case Toggle
                            Case 1
                                CollectionToTest.Item(i).IsSelected = True
                            Case 2, 3
                                CollectionToTest.Item(i).IsHeighlighted = True
                            Case 99
                                If WhatWasNearby <> "Line" Then
                                    NearestElement = WhatWasNearby + "@" + NearestElement
                                End If
                        End Select
                        Return NearestElement
                    End If
                Case GetType(cArc)
                    If checkIfPointIsNearby(CollectionToTest.Item(i), New cPoint(MouseX, MouseY), OldDistanceX, GeoMan) = "Arc" Then
                        NearestElement = CollectionToTest.Item(i).NameOfEntity
                        Select Case Toggle
                            Case 1
                                CollectionToTest.Item(i).IsSelected = True
                            Case 2, 3
                                CollectionToTest.Item(i).IsHeighlighted = True
                        End Select
                        Return NearestElement
                    End If
                Case GetType(cCircle)
                    If checkIfPointIsNearby(CollectionToTest.Item(i), New cPoint(MouseX, MouseY), OldDistanceX, GeoMan) = "Circle" Then
                        NearestElement = CollectionToTest.Item(i).NameOfEntity
                        Select Case Toggle
                            Case 1
                                CollectionToTest.Item(i).IsSelected = True
                            Case 2, 3
                                CollectionToTest.Item(i).IsHeighlighted = True
                        End Select
                        Return NearestElement
                    End If

                Case GetType(cPoint)
                    If checkIfPointIsNearby(CollectionToTest.Item(i), New cPoint(MouseX, MouseY), OldDistanceX, GeoMan) = "Point" Then
                        NearestElement = CollectionToTest.Item(i).NameOfEntity
                        Select Case Toggle
                            Case 1
                                CollectionToTest.Item(i).IsSelected = True
                            Case 2, 3
                                CollectionToTest.Item(i).IsHeighlighted = True
                        End Select
                        Return NearestElement
                    End If
            End Select
        Next
        Return NearestElement
    End Function

    Public Function createContourList(ByRef ContourElements As Collection, ByRef ContourList As Collection, DistanceBetweenContourPoints As Double) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Converts the contour elements in a collection of points
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim TanAlpha As Double
        Dim CircularBorder As New Collection()

        For intX = 1 To ContourElements.Count
            CircularBorder.Clear()
            Select Case ContourElements.Item(intX).GetType()
                Case GetType(cLine)

#If DEBUG Then
                    System.Console.WriteLine("cLine entdeckt")
#End If

                    If ((ContourElements.Item(intX).m_X1 - ContourElements.Item(intX).m_X2) ^ 2) > ((ContourElements.Item(intX).m_Y1 - ContourElements.Item(intX).m_Y2) ^ 2) Then
                        If ContourElements.Item(intX).m_X1 < ContourElements.Item(intX).m_X2 Then
                            TanAlpha = (ContourElements.Item(intX).m_Y2 - ContourElements.Item(intX).m_Y1) / (ContourElements.Item(intX).m_X2 - ContourElements.Item(intX).m_X1)
                            For dblX = 0 To (ContourElements.Item(intX).m_X2 - ContourElements.Item(intX).m_X1) Step DistanceBetweenContourPoints
                                ContourList.Add(New cPoint(dblX + ContourElements.Item(intX).m_X1, (ContourElements.Item(intX).m_Y1 + (dblX * TanAlpha))))
                                ContourList.Item(ContourList.Count).Description = ContourElements.Item(intX).NameOfEntity
                            Next

#If DEBUG Then
                            Console.WriteLine("x> , SP<")
#End If

                        Else
                            TanAlpha = (ContourElements.Item(intX).m_Y1 - ContourElements.Item(intX).m_Y2) / (ContourElements.Item(intX).m_X1 - ContourElements.Item(intX).m_X2)
                            For dblX = 0 To (ContourElements.Item(intX).m_X1 - ContourElements.Item(intX).m_X2) Step DistanceBetweenContourPoints
                                ContourList.Add(New cPoint(dblX + ContourElements.Item(intX).m_X2, (ContourElements.Item(intX).m_Y2 + (dblX * TanAlpha))))
                                ContourList.Item(ContourList.Count).Description = ContourElements.Item(intX).NameOfEntity
                            Next

                        End If
                    Else
                        If ContourElements.Item(intX).m_Y1 < ContourElements.Item(intX).m_Y2 Then
                            TanAlpha = (ContourElements.Item(intX).m_X2 - ContourElements.Item(intX).m_X1) / (ContourElements.Item(intX).m_Y2 - ContourElements.Item(intX).m_Y1)
                            For dblY = 0 To (ContourElements.Item(intX).m_Y2 - ContourElements.Item(intX).m_Y1) Step DistanceBetweenContourPoints
                                ContourList.Add(New cPoint((ContourElements.Item(intX).m_X1 + (dblY * TanAlpha)), dblY + ContourElements.Item(intX).m_Y1))
                            Next
                        Else
                            TanAlpha = (ContourElements.Item(intX).m_X1 - ContourElements.Item(intX).m_X2) / (ContourElements.Item(intX).m_Y1 - ContourElements.Item(intX).m_Y2)
                            For dblY = 0 To (ContourElements.Item(intX).m_Y1 - ContourElements.Item(intX).m_Y2) Step DistanceBetweenContourPoints
                                ContourList.Add(New cPoint((ContourElements.Item(intX).m_X2 + (dblY * TanAlpha)), dblY + ContourElements.Item(intX).m_Y2))
                            Next
                        End If
                    End If
                    If ContourElements.Item(intX).m_X1 = ContourElements.Item(intX).m_X2 Then
                        If ContourElements.Item(intX).m_Y1 < ContourElements.Item(intX).m_Y2 Then
                            For dblY = 0 To (ContourElements.Item(intX).m_Y2 - ContourElements.Item(intX).m_Y1) Step DistanceBetweenContourPoints
                                ContourList.Add(New cPoint(ContourElements.Item(intX).m_X1, dblY + ContourElements.Item(intX).m_Y1))
                            Next
                        Else
                            For dblY = 0 To (ContourElements.Item(intX).m_Y1 - ContourElements.Item(intX).m_Y2) Step DistanceBetweenContourPoints
                                ContourList.Add(New cPoint(ContourElements.Item(intX).m_X1, dblY + ContourElements.Item(intX).m_Y2))
                            Next
                        End If
                    End If
                    If ContourElements.Item(intX).m_Y1 = ContourElements.Item(intX).m_Y2 Then
                        If ContourElements.Item(intX).m_X1 < ContourElements.Item(intX).m_X2 Then
                            For dblX = 0 To (ContourElements.Item(intX).m_X2 - ContourElements.Item(intX).m_X1) Step DistanceBetweenContourPoints
                                ContourList.Add(New cPoint(dblX + ContourElements.Item(intX).m_X1, ContourElements.Item(intX).m_Y1))
                            Next
                        Else
                            For dblX = 0 To (ContourElements.Item(intX).m_X1 - ContourElements.Item(intX).m_X2) Step DistanceBetweenContourPoints
                                ContourList.Add(New cPoint(dblX + ContourElements.Item(intX).m_X2, ContourElements.Item(intX).m_Y1))
                            Next
                        End If
                    End If
                Case GetType(cArc)

#If DEBUG Then
                    System.Console.WriteLine("cArc entdeckt")
#End If

                    getCircularBorder(CircularBorder, ContourElements.Item(intX).StartAngle, ContourElements.Item(intX).EndAngle, ContourElements.Item(intX).Radius, DistanceBetweenContourPoints)
                    For intY = 1 To CircularBorder.Count
                        ContourList.Add(New cPoint(ContourElements.Item(intX).m_XC + CircularBorder.Item(intY).X, ContourElements.Item(intX).m_YC + CircularBorder.Item(intY).Y))
                        'CamPath.Add(New cLine(ContourElements.Item(intX).CenterPoint_X + CircularBorder.Item(intY).X, ContourElements.Item(intX).CenterPoint_Y + CircularBorder.Item(intY).Y, Point2.X, Point2.Y, "InfeedSide"))
                        'Point2.X = ContourElements.Item(intX).CenterPoint_X + CircularBorder.Item(intY).X
                        'Point2.Y = ContourElements.Item(intX).CenterPoint_Y + CircularBorder.Item(intY).Y
                    Next
                Case GetType(cCircle)

#If DEBUG Then
                    System.Console.WriteLine("cCircle entdeckt")
#End If

                    getCircularBorder(CircularBorder, ContourElements.Item(intX).Radius, DistanceBetweenContourPoints)
                    For intY = 1 To CircularBorder.Count
                        ContourList.Add(New cPoint(ContourElements.Item(intX).m_XC + CircularBorder.Item(intY).X, ContourElements.Item(intX).m_YC + CircularBorder.Item(intY).Y))
                        'CamPath.Add(New cLine(ContourElements.Item(intX).CenterPoint_X + CircularBorder.Item(intY).X, ContourElements.Item(intX).CenterPoint_Y + CircularBorder.Item(intY).Y, Point2.X, Point2.Y, "InfeedSide"))
                        'Point2.X = ContourElements.Item(intX).CenterPoint_X + CircularBorder.Item(intY).X
                        'Point2.Y = ContourElements.Item(intX).CenterPoint_Y + CircularBorder.Item(intY).Y
                    Next
            End Select

        Next

        Return False
    End Function

    Public Function sortOutline(ByRef Outline As Collection) As Boolean

        Return True
    End Function

    Public Function getElementInRectangle(X1 As Double, Y1 As Double, X2 As Double, Y2 As Double, ByRef CollectionToTest As Collection, ByRef CollectionToAddTo As Collection, Filter As cOTString) As Boolean


        '----- Initial settings -----

        For i As Integer = 1 To CollectionToTest.Count
            Select Case CollectionToTest.Item(i).GetType()
                Case GetType(cLine)
                    If CollectionToTest.Item(i).m_X1 > X1 And
                        CollectionToTest.Item(i).m_X1 < X2 And
                        CollectionToTest.Item(i).m_Y1 > Y1 And
                        CollectionToTest.Item(i).m_Y1 < Y2 And
                        CollectionToTest.Item(i).m_X2 > X1 And
                        CollectionToTest.Item(i).m_X2 < X2 And
                        CollectionToTest.Item(i).m_Y2 > Y1 And
                        CollectionToTest.Item(i).m_Y2 < Y2 Then

                        CollectionToAddTo.Add(CollectionToTest.Item(i))

                    End If

                Case GetType(cPoint)
                    If CollectionToTest.Item(i).X > X1 And
                        CollectionToTest.Item(i).X < X2 And
                        CollectionToTest.Item(i).Y > Y1 And
                        CollectionToTest.Item(i).Y < Y2 Then

                        CollectionToAddTo.Add(CollectionToTest.Item(i))
                    End If
            End Select
        Next

        Return True
    End Function

    Public Function getRGBColor(ColorToTranslate As Color) As Integer()
        Dim myColor(2) As Integer

        myColor(0) = ColorToTranslate.R
        myColor(1) = ColorToTranslate.G
        myColor(2) = ColorToTranslate.B

        Return myColor
    End Function

    Public Function checkIfPointIsNearby(ByRef ObjectToCheck As Object, PointToCheck As cPoint, MaxDistance As Double, GeoMan As cOTGeometricRepresentationManager) As String

        Dim a, b, c, d, e As Double
        Dim myGeoMan As New cOTGeometricRepresentationManager()

        '----- Initial settings -----

        myGeoMan = GeoMan


        Select Case ObjectToCheck.GetType()
            Case GetType(cLine)

                If Math.Sqrt((myGeoMan.tP(ObjectToCheck.m_X1, ObjectToCheck.m_Y1, ObjectToCheck.m_Z1)(0) - PointToCheck.X) ^ 2 + (myGeoMan.tP(ObjectToCheck.m_X1, ObjectToCheck.m_Y1, ObjectToCheck.m_Z1)(1) - PointToCheck.Y) ^ 2) <= MaxDistance Then
                    Return "Startpoint"
                End If
                If Math.Sqrt((myGeoMan.tP(ObjectToCheck.m_X2, ObjectToCheck.m_Y2, ObjectToCheck.m_Z2)(0) - PointToCheck.X) ^ 2 + (myGeoMan.tP(ObjectToCheck.m_X2, ObjectToCheck.m_Y2, ObjectToCheck.m_Z2)(1) - PointToCheck.Y) ^ 2) <= MaxDistance Then
                    Return "Endpoint"
                End If

                a = Math.Sqrt((myGeoMan.tP(ObjectToCheck.m_X1, ObjectToCheck.m_Y1, ObjectToCheck.m_Z1)(0) - PointToCheck.X) ^ 2 + (myGeoMan.tP(ObjectToCheck.m_X1, ObjectToCheck.m_Y1, ObjectToCheck.m_Z1)(1) - PointToCheck.Y) ^ 2)
                c = Math.Sqrt((myGeoMan.tP(ObjectToCheck.m_X1, ObjectToCheck.m_Y1, ObjectToCheck.m_Z1)(0) - myGeoMan.tP(ObjectToCheck.m_X2, ObjectToCheck.m_Y2, ObjectToCheck.m_Z2)(0)) ^ 2 + (myGeoMan.tP(ObjectToCheck.m_X1, ObjectToCheck.m_Y1, ObjectToCheck.m_Z1)(1) - myGeoMan.tP(ObjectToCheck.m_X2, ObjectToCheck.m_Y2, ObjectToCheck.m_Z2)(1)) ^ 2)
                e = Math.Sqrt((myGeoMan.tP(ObjectToCheck.m_X2, ObjectToCheck.m_Y2, ObjectToCheck.m_Z2)(0) - PointToCheck.X) ^ 2 + (myGeoMan.tP(ObjectToCheck.m_X2, ObjectToCheck.m_Y2, ObjectToCheck.m_Z2)(1) - PointToCheck.Y) ^ 2)
                b = (c ^ 2 + e ^ 2 - a ^ 2) / (2 * c)
                d = Math.Sqrt(e ^ 2 - b ^ 2)

                If d <= MaxDistance And e < c And a < c Then
                    Return "Line"
                End If
            Case GetType(cCircle)
                If Math.Sqrt((myGeoMan.tP(ObjectToCheck.m_XC, ObjectToCheck.m_YC, ObjectToCheck.m_ZC)(0) - PointToCheck.X) ^ 2 + (myGeoMan.tP(ObjectToCheck.m_XC, ObjectToCheck.m_YC, ObjectToCheck.m_ZC)(1) - PointToCheck.Y) ^ 2) > (ObjectToCheck.Radius - MaxDistance) And Math.Sqrt((myGeoMan.tP(ObjectToCheck.m_XC, ObjectToCheck.m_YC, ObjectToCheck.m_ZC)(0) - PointToCheck.X) ^ 2 + (myGeoMan.tP(ObjectToCheck.m_XC, ObjectToCheck.m_YC, ObjectToCheck.m_ZC)(1) - PointToCheck.Y) ^ 2) < (ObjectToCheck.Radius + MaxDistance) Then
                    Return "Circle"
                End If

            Case GetType(cArc)

            Case GetType(cPoint)

                If Math.Sqrt((myGeoMan.tP(ObjectToCheck.m_X, ObjectToCheck.m_Y, ObjectToCheck.m_Z)(0) - PointToCheck.X) ^ 2 + (myGeoMan.tP(ObjectToCheck.m_X, ObjectToCheck.m_Y, ObjectToCheck.m_Z)(1) - PointToCheck.Y) ^ 2) <= MaxDistance Then
                    Return "Point"
                End If
                'Point(1) = Math.Sqrt((ObjectToCheck.m_Y - PointToVerifyY) ^ 2)
                'Point(2) = Math.Sqrt((ObjectToCheck.m_Z - PointToVerifyZ) ^ 2)


        End Select
        Return "none"
    End Function

    Public Function createCircularPocketPathLines(ByRef CamPreview As Collection, ByRef CamPathArray As cSimplePoint(), ToolDiameter As Double, ToolOverlap As Integer, PocketRadius As Double, Preview As Boolean, Direction As String) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose:  Creates the pathlines for a circular pocket or the drawing entities
        '           to display the pathes.
        ' Input Parameter:
        '       CamPreview      - the collection that contains the preview entities
        '       CamPath         - the collection that contains the campath entities
        '       ToolDiameter    - the tool diameter incl. a correction value
        '       ToolOverlap     - the overlap in percent of the tool diameter from
        '                         circular path to circular path
        '       PocketRadius    - the radius of the pocket to be milled
        '       Preview         - is true if the preview should be calculated
        ' Return Value:
        '       CamPreview      - s.a.
        '       CamPath         - s.a.
        '
        '----- Steps -------------------------------------------------------------------
        '
        ' 1.    Calculate the amount of circular pathes (RadiusSteps)
        ' 2.    Calculate the step wide according to tool diameter and tool overlap
        ' 3.    Calculate the milling pathes or the preview entities according to the
        '       value of the "Preview"  
        '
        '----- End description ---------------------------------------------------------

        Dim RadiusStepWide As Double            'Distance between the circular pathes
        Dim RadiusSteps As Integer              'Amount of circular pathes
        Dim StepCount As Double                 'A variable that is count down from step to step
        Dim LineCircumferenceDistance As Double 'Tolerance between circumference and sehne

        '--- Initial settings ---

        LineCircumferenceDistance = 0.02
        StepCount = 0

        RadiusSteps = CInt((PocketRadius - ToolDiameter / 2) / (ToolDiameter - (ToolDiameter * ToolOverlap / 100)))
        RadiusStepWide = (PocketRadius - ToolDiameter / 2) / RadiusSteps

#If DEBUG Then
        Console.WriteLine(RadiusSteps)
#End If

        StepCount = (PocketRadius - ToolDiameter / 2)

        For j As Integer = 1 To RadiusSteps
            If Preview = True Then
                CamPreview.Add(New cCircle(0, 0, 0, StepCount, "Work"))
                If j < RadiusSteps Then
                    'To avoid the X-value beeing negative
                    CamPreview.Add(New cLine(StepCount - RadiusStepWide, 0, StepCount, 0, "InfeedSide"))
                Else
                    CamPreview.Add(New cLine(0, 0, StepCount, 0, "InfeedSide"))
                End If
            Else
                getCircularBorderWithSimplePoints(CamPathArray, 0, 360, StepCount, LineCircumferenceDistance, Direction)
                If j = 1 Then
                    CamPathArray(CamPathArray.Length - 1).Annotation = "Border"
                    CamPathArray(CamPathArray.Length - 2).Annotation = "Work"
                Else
                    CamPathArray(CamPathArray.Length - 1).Annotation = "InfeedSide"
                    CamPathArray(CamPathArray.Length - 2).Annotation = "Work"
                End If
                LineCircumferenceDistance = 0.2 'Make the tolerance bigger for the inner path lines (has to be reworked later to cope with little radii)

                If j = RadiusSteps Then
                    ReDim Preserve CamPathArray(CamPathArray.Length)
                    CamPathArray(CamPathArray.Length - 1) = New cSimplePoint(0, 0, 0, "InfeedGround")
                End If

                'PartlyPocketPathPoints.Clear()
            End If
            StepCount = StepCount - RadiusStepWide
        Next

        Return False
    End Function

    Public Function getCircularBorderWithSimplePoints(ByRef Border As cSimplePoint(), StartAngle As Double, EndAngle As Double, Radius As Double, Distance As Double, Direction As String) As Boolean

        '----- Begin Description -----------------------------------------------------------------------------------------------------
        '
        ' Purpose:  Creates a collection "B o r d e r" of points where the points lie at the circumference of a circle with the
        '           given "R a d i u s". The maximal deviation of a line between two such points and the circumfrence is determined
        '           by the "D i s t a n c e". The calculation starts at the "S t a r t A n g e l" and stops at the "E n d A n g e l".
        '           An vector wit an angle of 0° has horizontal direction and points to the right. Angles get bigger counterclockwise.
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -----------------------------------------------------------------------------------------------------------------
        '
        '----- End description -------------------------------------------------------------------------------------------------------

        Dim x As Double
        Dim Point1 As New cSimplePoint()
        Dim AngleStep As Double
        Dim ArrayCount As Integer

        '--- Initial steps ---

        ArrayCount = Border.Length - 1

        '---------------------

        AngleStep = ((Math.Atan(Distance / 2 / Radius)) / (2 * Math.PI) * 360) * 2

#If DEBUG Then
        Console.WriteLine(AngleStep)
#End If

        If Direction = "ClockWise" Then

            If StartAngle > EndAngle Then
                For x = StartAngle To 360 Step AngleStep
                    If ArrayCount = Border.Length - 1 Then
                        ReDim Preserve Border(ArrayCount + 2000)
                    End If
                    ArrayCount += 1
                    Select Case x
                        Case Is <= 90
                            Point1.X = Math.Cos(x * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin(x * 2 * Math.PI / 360) * Radius
                        Case Is > 90, Is <= 180
                            Point1.X = Math.Cos((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((180 - x) * 2 * Math.PI / 360) * Radius
                        Case Is > 180, Is <= 270
                            Point1.X = Math.Cos((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 270
                            Point1.X = Math.Cos((360 - x) * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin((360 - x) * 2 * Math.PI / 360) * Radius / (-1)
                    End Select
                    Border(ArrayCount) = New cSimplePoint(Point1)
                Next
                For x = 0 To EndAngle Step AngleStep
                    If ArrayCount = Border.Length - 1 Then
                        ReDim Preserve Border(ArrayCount + 2000)
                    End If
                    ArrayCount += 1
                    Select Case x
                        Case Is <= 90
                            Point1.X = Math.Cos(x * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin(x * 2 * Math.PI / 360) * Radius
                        Case Is > 90, Is <= 180
                            Point1.X = Math.Cos((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((180 - x) * 2 * Math.PI / 360) * Radius
                        Case Is > 180, Is <= 270
                            Point1.X = Math.Cos((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 270
                            Point1.X = Math.Cos((360 - x) * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin((360 - x) * 2 * Math.PI / 360) * Radius / (-1)
                    End Select
                    Border(ArrayCount) = New cSimplePoint(Point1)
                Next
            Else
                For x = StartAngle To EndAngle Step AngleStep
                    If ArrayCount = Border.Length - 1 Then
                        ReDim Preserve Border(ArrayCount + 2000)
                    End If
                    ArrayCount += 1
                    Select Case x
                        Case Is <= 90
                            Point1.X = Math.Cos(x * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin(x * 2 * Math.PI / 360) * Radius
                        Case Is > 90, Is <= 180
                            Point1.X = Math.Cos((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((180 - x) * 2 * Math.PI / 360) * Radius
                        Case Is > 180, Is <= 270
                            Point1.X = Math.Cos((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 270
                            Point1.X = Math.Cos((360 - x) * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin((360 - x) * 2 * Math.PI / 360) * Radius / (-1)
                    End Select
                    Border(ArrayCount) = New cSimplePoint(Point1)
                Next

#If DEBUG Then
                Console.WriteLine(Border.Count)
#End If

            End If

        ElseIf Direction = "CounterClockWise" Then

            If StartAngle > EndAngle Then
                For x = StartAngle To 360 Step AngleStep
                    If ArrayCount = Border.Length - 1 Then
                        ReDim Preserve Border(ArrayCount + 2000)
                    End If
                    ArrayCount += 1
                    Select Case x
                        Case Is <= 90
                            Point1.X = Math.Cos(x * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin(x * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 90, Is <= 180
                            Point1.X = Math.Cos((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 180, Is <= 270
                            Point1.X = Math.Cos((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((x - 180) * 2 * Math.PI / 360) * Radius
                        Case Is > 270
                            Point1.X = Math.Cos((360 - x) * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin((360 - x) * 2 * Math.PI / 360) * Radius
                    End Select
                    Border(ArrayCount) = New cSimplePoint(Point1)
                Next
                For x = 0 To EndAngle Step AngleStep
                    If ArrayCount = Border.Length - 1 Then
                        ReDim Preserve Border(ArrayCount + 2000)
                    End If
                    ArrayCount += 1
                    Select Case x
                        Case Is <= 90
                            Point1.X = Math.Cos(x * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin(x * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 90, Is <= 180
                            Point1.X = Math.Cos((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 180, Is <= 270
                            Point1.X = Math.Cos((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((x - 180) * 2 * Math.PI / 360) * Radius
                        Case Is > 270
                            Point1.X = Math.Cos((360 - x) * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin((360 - x) * 2 * Math.PI / 360) * Radius
                    End Select
                    Border(ArrayCount) = New cSimplePoint(Point1)
                Next
            Else
                For x = StartAngle To EndAngle Step AngleStep
                    If ArrayCount = Border.Length - 1 Then
                        ReDim Preserve Border(ArrayCount + 2000)
                    End If
                    ArrayCount += 1
                    Select Case x
                        Case Is <= 90
                            Point1.X = Math.Cos(x * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin(x * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 90, Is <= 180
                            Point1.X = Math.Cos((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((180 - x) * 2 * Math.PI / 360) * Radius / (-1)
                        Case Is > 180, Is <= 270
                            Point1.X = Math.Cos((x - 180) * 2 * Math.PI / 360) * Radius / (-1)
                            Point1.Y = Math.Sin((x - 180) * 2 * Math.PI / 360) * Radius
                        Case Is > 270
                            Point1.X = Math.Cos((360 - x) * 2 * Math.PI / 360) * Radius
                            Point1.Y = Math.Sin((360 - x) * 2 * Math.PI / 360) * Radius
                    End Select
                    Border(ArrayCount) = New cSimplePoint(Point1)
                Next
            End If

        End If

        ReDim Preserve Border(ArrayCount)

#If DEBUG Then
        Console.WriteLine(Border.Length)
#End If

        Return False
    End Function

    Public Function rasterOneTriangleToBorderArray(ByRef RasterizedTriangle As Double(,), LowerLeftOriginPointOfBorder As cSimplePoint, ByRef StartIndexXY As Point, Triangle As cSimplePoint(), Spacing As Single, MainLookAtDirection As cSimplePoint) As String

        '----- Begin Description ------------------------------------------------------------------------------------------------------------------------------------------
        '
        ' Purpose:  Rasterizes a triangle that is described by 3 vert
        '           are changed (like feed rates or step counts).
        ' Input Parameter:  RasterizedTriangle                          : The array that contains the rasterized triangle
        '                             LowerLeftOriginPointOfBorder       : The whole array containing the points of the geometry that will be machined
        '                             StartIndexXY                                 : The lower left x- y- values of the "RasterizedTriangle"
        '                             Triangle                                          :  A Triangle in form of tree vertices that should be added as points to the "Border"
        '                             Spacing                                           : The horizontal and vertical distance between the projected array points of the "BorderPatch"
        '                             MainLookAtDirection                       : A vector given by a point (the startpoint of the vector is 0 , 0 , 0) pointing in the
        '                                                                                      main machining direction.
        ' Return Value:       RasterizedTriangle (ByRef)              : The array containing the rastered triangle
        '                            LowerLeftTrianglePatchOriginPoint  : The x- y- values of the lower left "RasterizedTriangle" (Index 0)
        '                            Result  - In case of a not normal end of function a string describing the problem
        '
        '----- Steps ---------------------------------------------------------------------------------------------------------------------------------------------------------
        '
        ' 1. Dimension the RasterizedTriangle according to the size of the triangle
        ' 1. Convert the edges of the triangle to points in the array
        ' 5. Put the points from RasterizedTriangle to the Border
        '
        '----- End description --------------------------------------------------------------------------------------------------------------------------------------------

        ' Dim RasterizedTriangle As Single(,)             ' The buffer for the points of the triangle during rasterization
        Dim BorderPatchMinX As Double
        Dim BorderPatchMaxX As Double
        Dim BorderPatchMinY As Double
        Dim BorderPatchMaxY As Double
        Dim BorderPatchMinZ As Double
        Dim BorderPatchMaxZ As Double
        Dim IndexCountX, IndexCountY As Integer
        Dim Result As String() = {"IsNotRelevant",
                                            "NotAValidParameter",
                                            "ok"}

        '--- Initializations ---


        '--- Check if the input parameters are valid ---

        If Spacing < 0.001 Then
            Return Result(1)
        End If

        '--- 1. Find the "LowerLeftTrianglePatchOriginPoint" and "BorderPatchMax"

        BorderPatchMinX = Triangle(0).X
        BorderPatchMaxX = Triangle(0).X
        BorderPatchMinY = Triangle(0).Y
        BorderPatchMaxY = Triangle(0).Y
        BorderPatchMinZ = Triangle(0).Z
        BorderPatchMaxZ = Triangle(0).Z

        For i As Integer = 1 To 2
            If Triangle(i).X < BorderPatchMinX Then
                BorderPatchMinX = Triangle(i).X
            End If
            If Triangle(i).Y < BorderPatchMinY Then
                BorderPatchMinY = Triangle(i).Y
            End If
            If Triangle(i).X > BorderPatchMaxX Then
                BorderPatchMaxX = Triangle(i).X
            End If
            If Triangle(i).Y > BorderPatchMaxY Then
                BorderPatchMaxY = Triangle(i).Y
            End If
            If Triangle(i).Z < BorderPatchMinZ Then
                BorderPatchMinZ = Triangle(i).Z
            End If
            If Triangle(i).Z > BorderPatchMaxZ Then
                BorderPatchMaxZ = Triangle(i).Z
            End If
        Next

        '--- 1. Dimension the RasterizedTriangle according to the size of the triangle

        StartIndexXY.X = CInt((BorderPatchMinX - LowerLeftOriginPointOfBorder.X) / Spacing)
        StartIndexXY.Y = CInt((BorderPatchMinY - LowerLeftOriginPointOfBorder.Y) / Spacing)
        IndexCountX = CInt((BorderPatchMaxX - BorderPatchMinX) / Spacing)
        IndexCountY = CInt((BorderPatchMaxY - BorderPatchMinY) / Spacing)

        ReDim RasterizedTriangle(IndexCountX, IndexCountY)

        For y As Integer = 0 To IndexCountY
            For x As Integer = 0 To IndexCountX
                RasterizedTriangle(x, y) = -100000
            Next
        Next

#If DEBUG Then
        Console.WriteLine(IndexCountX)
        Console.WriteLine(IndexCountY)
#End If

        ' If the size of the "RasterizedTriangle" array is only one value set this value to the biggest z value of the triangle

        If IndexCountX = 0 And IndexCountY = 0 Then
            RasterizedTriangle(0, 0) = BorderPatchMaxZ
            Return Result(2)
        End If

        '--- 2. Convert the edges of the triangle to points in the "RasterizedTriangle" array ---
#If DEBUG Then
        Console.WriteLine(Triangle(0).Annotation)
        Console.WriteLine(Triangle(0).X)
        Console.WriteLine(Triangle(0).Y)
        Console.WriteLine(Triangle(0).Z)
        Console.WriteLine(" ")
        Console.WriteLine(Triangle(1).Annotation)
        Console.WriteLine(Triangle(1).X)
        Console.WriteLine(Triangle(1).Y)
        Console.WriteLine(Triangle(1).Z)
        Console.WriteLine("---")
#End If
        rasterOneLine(Triangle(0), Triangle(1), RasterizedTriangle, Spacing, BorderPatchMinX, BorderPatchMinY)
#If DEBUG Then
        Console.WriteLine(Triangle(1).Annotation)
        Console.WriteLine(Triangle(1).X)
        Console.WriteLine(Triangle(1).Y)
        Console.WriteLine(Triangle(1).Z)
        Console.WriteLine(" ")
        Console.WriteLine(Triangle(2).Annotation)
        Console.WriteLine(Triangle(2).X)
        Console.WriteLine(Triangle(2).Y)
        Console.WriteLine(Triangle(2).Z)
        Console.WriteLine("---")
#End If
        rasterOneLine(Triangle(1), Triangle(2), RasterizedTriangle, Spacing, BorderPatchMinX, BorderPatchMinY)
#If DEBUG Then
        Console.WriteLine(Triangle(2).Annotation)
        Console.WriteLine(Triangle(2).X)
        Console.WriteLine(Triangle(2).Y)
        Console.WriteLine(Triangle(2).Z)
        Console.WriteLine(" ")
        Console.WriteLine(Triangle(0).Annotation)
        Console.WriteLine(Triangle(0).X)
        Console.WriteLine(Triangle(0).Y)
        Console.WriteLine(Triangle(0).Z)
        Console.WriteLine("---")
#End If
        rasterOneLine(Triangle(2), Triangle(0), RasterizedTriangle, Spacing, BorderPatchMinX, BorderPatchMinY)
#If DEBUG Then

        Console.WriteLine("Edges are calculated")
#End If

        '--- 3. Raster the inner of theTriangle (Actual only for MainLookAtDirection Z solved). ---

        Dim StartOfLineX As Integer = 0
        Dim EndOfLineX As Integer = 0
        Dim InterLock As Boolean
        Dim StartPoint As New cSimplePoint()
        Dim EndPoint As New cSimplePoint()

        For y As Integer = 0 To IndexCountY
            InterLock = False
            For x As Integer = 0 To IndexCountX
                If RasterizedTriangle(x, y) > -90000 And InterLock = True Then
                    EndOfLineX = x
                End If
                If RasterizedTriangle(x, y) > -90000 And InterLock = False Then
                    StartOfLineX = x
                    InterLock = True
                End If
            Next
            If StartOfLineX < EndOfLineX Then
                StartPoint.X = StartOfLineX * Spacing + BorderPatchMinX
                StartPoint.Y = y * Spacing + BorderPatchMinY
                StartPoint.Z = RasterizedTriangle(StartOfLineX, y)
                EndPoint.X = EndOfLineX * Spacing + BorderPatchMinX
                EndPoint.Y = StartPoint.Y
                EndPoint.Z = RasterizedTriangle(EndOfLineX, y)
                rasterOneLine(StartPoint, EndPoint, RasterizedTriangle, Spacing, BorderPatchMinX, BorderPatchMinY)
            End If
        Next

        Return Result(2)
    End Function

    Public Function rasterOneLine(Point1 As cSimplePoint, Point2 As cSimplePoint, ByRef CubicRaster As Double(,), Spacing As Double, MinX As Double, MinY As Double) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose:  Rasterizes a line that is given as two points in points of a cubic point array by a given raster point distance. 
        ' Input Parameter:    Point1               : The first end point of a line
        '                               Point2              : The second end point of a line
        '                               CubicRaster(,)  : The array that gets filled up with the raster points
        '                               Spacing            : The distance between raster points
        '                               MinX                : The x value of the "CubicRaster(0, 0)"
        '                               MinY                : The y value of the "CubicRaster(0, 0)"
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim TanAlpha As Double
        Dim TanGamma As Double
        Dim Z As Double

        '--- Initial steps

        '--- Fill the matrix ---

        ' If the projected length in the x direction is bigger than or equal to the projected length of the y direction

        'If Point1.X <> Point2.X And Point1.Y <> Point2.Y Then
        If ((Point1.X - Point2.X) ^ 2) >= ((Point1.Y - Point2.Y) ^ 2) Then

                ' If the x coordinate of point1 is smaller than the x coordinate of point2

                If Point1.X < Point2.X Then
                    TanAlpha = (Point2.Y - Point1.Y) / (Point2.X - Point1.X)
                    TanGamma = (Point2.Z - Point1.Z) / (Point2.X - Point1.X)
                For x As Double = 0 To (Point2.X - Point1.X) Step Spacing
                    Z = Point1.Z + (x * TanGamma)
                    If Z <> 0 Then
                        CubicRaster(CInt((Point1.X + x - MinX) / Spacing), CInt((Point1.Y + (x * TanAlpha) - MinY) / Spacing)) = Z
                    Else
                        CubicRaster(CInt((Point1.X + x - MinX) / Spacing), CInt((Point1.Y + (x * TanAlpha) - MinY) / Spacing)) = 0.0001
                    End If

#If DEBUG Then
                    'Console.WriteLine("CubicRaster")
                    'Console.WriteLine(CubicRaster(CInt((Point1.X + x - MinX) / Spacing), CInt((Point1.Y + (x * TanAlpha) - MinY) / Spacing)))
#End If

                Next

                ' If the x coordinate of point2 is smaller than the x coordinate of point1

            Else
                    TanAlpha = (Point1.Y - Point2.Y) / (Point1.X - Point2.X)
                    TanGamma = (Point1.Z - Point2.Z) / (Point1.X - Point2.X)
                For x As Double = 0 To (Point1.X - Point2.X) Step Spacing
                    Z = Point2.Z + (x * TanGamma)
                    If Z <> 0 Then
                        CubicRaster(CInt((Point2.X + x - MinX) / Spacing), CInt((Point2.Y + (x * TanAlpha) - MinY) / Spacing)) = Z
                    Else
                        CubicRaster(CInt((Point2.X + x - MinX) / Spacing), CInt((Point2.Y + (x * TanAlpha) - MinY) / Spacing)) = 0.0001
                    End If

#If DEBUG Then
                    'Console.WriteLine("CubicRaster")
                    'Console.WriteLine(CubicRaster(CInt((Point2.X + x - MinX) / Spacing), CInt((Point2.Y + (x * TanAlpha) - MinY) / Spacing)))
#End If
                Next
            End If

                ' If the projected length in the y direction is bigger than the projected length of the x direction

            Else

            ' If the y coordinate of point1 is smaller than the y coordinate of point2

            If Point1.Y < Point2.Y Then
                If ((Point2.X - Point1.X) ^ 2) > 0.00000001 Then
                    TanAlpha = (Point2.X - Point1.X) / (Point2.Y - Point1.Y)
                Else
                    TanAlpha = 0
                End If
                TanGamma = (Point2.Z - Point1.Z) / (Point2.Y - Point1.Y)
                For y As Double = 0 To (Point2.Y - Point1.Y) Step Spacing
                    Z = Point1.Z + (y * TanGamma)
                    If Z <> 0 Then
                        CubicRaster(CInt((Point1.X - MinX + (y * TanAlpha)) / Spacing), CInt((Point1.Y + y - MinY) / Spacing)) = Z
                    Else
                        CubicRaster(CInt((Point1.X - MinX + (y * TanAlpha)) / Spacing), CInt((Point1.Y + y - MinY) / Spacing)) = 0.0001
                    End If

#If DEBUG Then
                    'Console.WriteLine("CubicRaster")
                    'Console.WriteLine(CubicRaster(CInt((Point1.X - MinX + (y * TanAlpha)) / Spacing), CInt((Point1.Y + y - MinY) / Spacing)))
#End If
                Next

                ' If the y coordinate of point2 is smaller than the y coordinate of point1

            Else
                If ((Point1.X - Point2.X) ^ 2) > 0.00000001 Then
                    TanAlpha = (Point1.X - Point2.X) / (Point1.Y - Point2.Y)
                Else
                    TanAlpha = 0
                End If
                TanGamma = (Point1.Z - Point2.Z) / (Point1.Y - Point2.Y)
                For y As Double = 0 To (Point1.Y - Point2.Y) Step Spacing
                    Z = Point2.Z + (y * TanGamma)
                    If Z <> 0 Then
                        CubicRaster(CInt((Point2.X - MinX + (y * TanAlpha)) / Spacing), CInt((Point2.Y + y - MinY) / Spacing)) = Z
                    Else
                        CubicRaster(CInt((Point2.X - MinX + (y * TanAlpha)) / Spacing), CInt((Point2.Y + y - MinY) / Spacing)) = 0.0001
                    End If

#If DEBUG Then
                    'Console.WriteLine("CubicRaster")
                    'Console.WriteLine(CubicRaster(CInt((Point2.X - MinX + (y * TanAlpha)) / Spacing), CInt((Point2.Y + y - MinY) / Spacing)))
#End If
                Next
            End If
            End If
        ' End If

        ' If the line is vertical

        '        If Point1.X = Point2.X Then

        '            '  If the y coordinate of point1 is smaller than the y coordinate of point2

        '            If Point1.Y < Point2.Y Then
        '                TanGamma = (Point2.Z - Point1.Z) / (Point2.Y - Point1.Y)
        '                For y As Double = 0 To (Point2.Y - Point1.Y) + Spacing / 2 Step Spacing
        '                    Z = Point1.Z + (y * TanGamma)

        '                    If Z <> 0 Then
        '                        CubicRaster(CInt((Point1.X - MinX) / Spacing), CInt((Point1.Y + y - MinY) / Spacing)) = Z
        '                    Else
        '                        CubicRaster(CInt((Point1.X - MinX) / Spacing), CInt((Point1.Y + y - MinY) / Spacing)) = 0.0001
        '                    End If
        '#If DEBUG Then
        '                    ' Console.WriteLine("Vertical If the y coordinate of point1 is smaller than the y coordinate of point2: ")
        '                    'Console.WriteLine(CubicRaster(CInt((Point1.X - MinX) / Spacing), CInt((Point1.Y + y - MinY) / Spacing)))
        '#End If
        '                Next

        '                '  If the y coordinate of point2 is smaller than the y coordinate of point1

        '            Else
        '                TanGamma = (Point1.Z - Point2.Z) / (Point1.Y - Point2.Y)
        '                For y As Double = 0 To (Point1.Y - Point2.Y) + Spacing / 2 Step Spacing
        '                    Z = Point2.Z + (y * TanGamma)
        '                    If Z <> 0 Then
        '                        CubicRaster(CInt((Point1.X - MinX) / Spacing), CInt((Point2.Y + y - MinY) / Spacing)) = Z
        '                    Else
        '                        CubicRaster(CInt((Point1.X - MinX) / Spacing), CInt((Point2.Y + y - MinY) / Spacing)) = 0.0001
        '                    End If
        '#If DEBUG Then
        '                    'Console.WriteLine("Vertical If the y coordinate of point2 is smaller than the y coordinate of point1: ")
        '                    'Console.WriteLine(CubicRaster(CInt((Point1.X - MinX) / Spacing), CInt((Point2.Y + y - MinY) / Spacing)))
        '#End If
        '                Next
        '            End If
        '        End If

        '        ' If the line is horizontal

        '        If Point1.Y = Point2.Y Then

        '            '  If the x coordinate of point1 is smaller than the x coordinate of point2

        '            If Point1.X < Point2.X Then
        '                TanGamma = (Point2.Z - Point1.Z) / (Point2.X - Point1.X)
        '                For x As Double = 0 To (Point2.X - Point1.X) + Spacing / 2 Step Spacing
        '                    Z = Point1.Z + (x * TanGamma)

        '                    If Z <> 0 Then
        '                        CubicRaster(CInt((Point1.X + x - MinX) / Spacing), CInt((Point1.Y - MinY) / Spacing)) = Z
        '                    Else
        '                        CubicRaster(CInt((Point1.X + x - MinX) / Spacing), CInt((Point1.Y - MinY) / Spacing)) = 0.0001
        '                    End If
        '#If DEBUG Then
        '                    'Console.WriteLine("Horizontal If the x coordinate of point1 is smaller than the x coordinate of point2: ")
        '                    ' Console.WriteLine(CubicRaster(CInt((Point1.X + x - MinX) / Spacing), CInt((Point1.Y + (x * TanAlpha) - MinY) / Spacing)))
        '#End If
        '                Next

        '                '  If the x coordinate of point2 is smaller than the x coordinate of point1

        '            Else
        '                TanGamma = (Point1.Z - Point2.Z) / (Point1.X - Point2.X)
        '                For x As Double = 0 To (Point1.X - Point2.X) + Spacing / 2 Step Spacing
        '                    Z = Point2.Z + (x * TanGamma)
        '                    If Z <> 0 Then
        '                        CubicRaster(CInt((Point2.X + x - MinX) / Spacing), CInt((Point1.Y - MinY) / Spacing)) = Z
        '                    Else
        '                        CubicRaster(CInt((Point2.X + x - MinX) / Spacing), CInt((Point1.Y - MinY) / Spacing)) = 0.0001
        '                    End If
        '#If DEBUG Then
        '                    'Console.WriteLine("Horizontal If the x coordinate of point2 is smaller than the x coordinate of point1: ")
        '                    'Console.WriteLine(CubicRaster(CInt((Point2.X + x - MinX) / Spacing), CInt((Point1.Y - MinY) / Spacing)))
        '#End If
        '                Next
        '            End If
        '        End If
        Return True
    End Function

    Public Function rasterARotationSymetricContourToContourArray(ByRef Contour As cSimplePoint(), Radius As Double, ByRef Distance As Double) As String

        '----- Begin Description -----------------------------------------------------------------------------------------------------
        '
        ' Purpose:  Creates an Array "Contour" of where each point specifies the negative x value with the points .X property, the positive x value
        '                with the points .Z property and the y value with the points .Y property. The points lie at the circumference of a circle with the
        '           given "R a d i u s". The maximal deviation of a line between two such points and the circumfrence is determined
        '           by the "D i s t a n c e". The calculation starts at the "S t a r t A n g e l" and stops at the "E n d A n g e l".
        '           An vector wit an angle of 0° has horizontal direction and points to the right. Angles get bigger counterclockwise.
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -----------------------------------------------------------------------------------------------------------------
        '
        '----- End description -------------------------------------------------------------------------------------------------------

        Dim IntermediateResult As Integer
        Dim Result As String() = {"IsNotRelevant",
                                            "NotAValidParameter",
                                            "ok"}

        '--- Initial settings ---

        ' Check if "Radius" / "Distance" results in an integer. If not adapt the "Distance" to the next value that results in an integer

        IntermediateResult = CInt(Radius / Distance)
        Distance = Radius / IntermediateResult

        ReDim Contour(IntermediateResult * 2)

#If DEBUG Then
        Console.WriteLine("Tool contour length ")
        Console.WriteLine(Contour.Length)
#End If

        '--- First 90° ---

        For y As Double = IntermediateResult * Distance To (-Distance / 2) Step -Distance  '0.015 'DistanceBetweenBorderPoints
            If y > (Distance / 2) Then ' To avoid errors if y is not precise 0
                Contour(CInt(IntermediateResult - y / Distance)) = (New cSimplePoint(-Math.Sqrt(Radius ^ 2 - y ^ 2), IntermediateResult * Distance, Math.Sqrt(Radius ^ 2 - y ^ 2)))
                Contour(CInt(IntermediateResult + y / Distance)) = (New cSimplePoint(-Math.Sqrt(Radius ^ 2 - y ^ 2), IntermediateResult * Distance, Math.Sqrt(Radius ^ 2 - y ^ 2))) ' The second 90°
            Else
                Contour(CInt(IntermediateResult - y / Distance)) = (New cSimplePoint(-Math.Sqrt(Radius ^ 2 - y ^ 2), IntermediateResult * Distance, Math.Sqrt(Radius ^ 2 - y ^ 2)))
            End If
#If DEBUG Then
            Console.WriteLine("Tool contour points ")
            Console.WriteLine(Contour(CInt(IntermediateResult + y / Distance)).X)
            Console.WriteLine(Contour(CInt(IntermediateResult + y / Distance)).Z)
#End If
        Next

        Return Result(2)
    End Function

    Public Function rasterA3DPathToCamPathArray(ByRef CamContour As Double(,), CamContourSpacing As Double, CamContourOrigin As cSimplePoint, WorkRetractHeight As Double, StartStopRetractHeight As Double, HeighestPoint As Double, ByRef ToolOutline As cSimplePoint(), ToolOutlineSpacing As Double, ByRef CamPath As cSimplePoint(), RoughMachiningInfeedGround As Double, FineMachiningOffset As Double, FineMachiningSteps As Integer, FinalCuts As Integer, InfeedSideRough As Double, InfeedSideFine As Double, InfeedForward As Double, MillingMethod As String, CamContourGroundPlane As Double) As String

        '----- Begin Description ----------------------------------------------------------------------------------------------------------------------------------------
        '
        ' Purpose:  Creates a "C a m P a t h" array  from a given "C a m C o n t o u r" and a given "T o o l O u t l i n e" by checking for collision
        '                between "C a m C o n t o u r" and "T o o l O u t l i n e". In the actual version of the program the calculation starts in the lower 
        '                right corner (the center point of the tool is a tool radius length away from the outline. 
        ' Input Parameter: CamContour             : The contour to be milled in the form of a Z-value-array.
        '                            CamContourSpacing : The x or y distance between to neighboredpoints in the CamContour array.
        '                            CamContourOrigin    : A point containing the xyz coordinates  of the CamContours first element (with index 0).
        '                            ToolOutline             : The outline of the tool that will be collision detected.
        '                            ToolOutlineSpacing : The Distance between outline points in one direction (actual in y direction)
        '                            CamPath                  : The resulting milling path.
        '                            InfeedSide             : The amount of the sideward infeed.
        '                            InfeedForward       :
        '                            MillingMethod         : A string describing if the tools milling move goes only in one direction or goes forward and
        '                                                             backward without moving to a retract plane.
        '                            RetractHeight         : Safety height where the tool is retracted to after one milling path in x direction  is completed.
        '                            CamContourGroundPlane: The deepest z value
        ' Return Value:       Result                     : Describing the result of the method.
        '
        '----- Steps -----------------------------------------------------------------------------------------------------------------------------------------------------
        '
        '----- End description -----------------------------------------------------------------------------------------------------------------------------------------

        Dim Point1 As New cPoint()
        Dim ArrayCount As Integer
        Dim IterationEndX, IterationEndY As Double
        Dim ToolRadius As Double
        Dim ActualPoint As New cSimplePoint()
        Dim NotDefined As Boolean
        Dim FinalToolWorkRetractHeight As Double
        Dim InfeedGround As Double
        Dim InfeedSide As Double
        Dim m As Double
        Dim IsAtToolWorkRetractHeight As Boolean
        Dim Result As String() = {"IsNotRelevant",
                                            "NotAValidParameter",
                                            "ok"}

        '--- Initial settings ---

        ToolRadius = 0
        ActualPoint.X = 0
        ActualPoint.Y = 0
        ActualPoint.Z = 0
        NotDefined = True
        InfeedSide = InfeedSideRough
        FinalToolWorkRetractHeight = WorkRetractHeight + HeighestPoint
        IsAtToolWorkRetractHeight = False

        If InfeedGround >= -HeighestPoint Then ' Check if "InfeedGround" is smaller as or equal to "HeighestPoint"
            InfeedGround = RoughMachiningInfeedGround
            m = HeighestPoint + InfeedGround
        Else
            InfeedGround = -HeighestPoint
            m = HeighestPoint + InfeedGround
        End If

        ' Find the tool radius and set the start point accordingly

        ToolRadius = ToolOutline(2).Y

        ' Find the end values for the "for to next" cycles that iterate the tool over the "CamContour"

        IterationEndX = CamContour.GetLength(0) * CamContourSpacing - ToolRadius
        IterationEndY = CamContour.GetLength(1) * CamContourSpacing - ToolRadius
        ActualPoint.X = CamContour.GetLength(0) * CamContourSpacing - ToolRadius

        '---

        ReDim CamPath(2000)
        ArrayCount = 0

        '---

        If ArrayCount > CamPath.Length - 10 Then ' Check if array is big enough
            ReDim Preserve CamPath(CamPath.Length + 2000)
        End If
        CamPath(ArrayCount) = New cSimplePoint(IterationEndX, ToolRadius, StartStopRetractHeight + HeighestPoint, "Rapid") ' Add the first sentence
        ArrayCount += 1

        Do While m >= CamContourGroundPlane ' Calculate the cam path

            If m = CamContourGroundPlane Then
                InfeedSide = InfeedSideFine
            End If
            For y As Double = ToolRadius To IterationEndY Step InfeedSide
                ActualPoint.Y = y
                If ArrayCount > CamPath.Length - 10 Then
                    ReDim Preserve CamPath(CamPath.Length + 2000)
                End If
                CamPath(ArrayCount) = New cSimplePoint(IterationEndX, ActualPoint.Y, FinalToolWorkRetractHeight, "Rapid")
                CamPath(ArrayCount + 1) = New cSimplePoint(IterationEndX, ActualPoint.Y, m, "InfeedGround")
                ArrayCount += 2

                For x As Double = IterationEndX To ToolRadius Step -InfeedForward
                    ActualPoint.X = x

                    ' Find the Z value for the "ActualPoint" by finding the highest z value of the "CamContour" under the tool

                    For w As Integer = Math.Ceiling((ActualPoint.Y - ToolRadius) / CamContourSpacing) To Math.Floor((ActualPoint.Y + ToolRadius) / CamContourSpacing)  ' Iterate over the "CamContour" inside a square thats length of edges is twice the "ToolRadius"
                        For v As Integer = Math.Ceiling((ActualPoint.X - ToolRadius) / CamContourSpacing) To Math.Floor((ActualPoint.X + ToolRadius) / CamContourSpacing)

                            ' Check if the "CamContour" point is inside the projected "ToolOutline"

                            If v < CamContour.GetLength(0) And w < CamContour.GetLength(1) Then
                                'ActualPoint.Z = CamContour(v, w)
                                'End If

                                If ((v * CamContourSpacing - ActualPoint.X) >= ToolOutline(CInt(((ActualPoint.Y + ToolRadius) - w * CamContourSpacing) / ToolOutlineSpacing)).X) And ((v * CamContourSpacing - ActualPoint.X) <= ToolOutline(CInt(((ActualPoint.Y + ToolRadius) - w * CamContourSpacing) / ToolOutlineSpacing)).Z) Then

                                    If NotDefined = True Then ' Take over the first z value 
                                        ActualPoint.Z = CamContour(v, w)
                                        NotDefined = False
                                    End If

                                    If CamContour(v, w) > ActualPoint.Z Then ' Check if the z value of the "CamContour" point is bigger than the "ActualPoint" z value
                                        ActualPoint.Z = CamContour(v, w)
                                    End If
#If DEBUG Then
                                    'Console.WriteLine("ActualPoint z: ")
                                    'Console.WriteLine(CamContour(v, w))
                                    'Console.WriteLine("ActualPoint x: ")
                                    'Console.WriteLine(ActualPoint.X)
                                    'Console.WriteLine("Tool outline x: ")
                                    'Console.WriteLine(ToolOutline(CInt(((ActualPoint.Y + ToolRadius) - w * CamContourSpacing) / ToolOutlineSpacing)).X)
                                    'Console.WriteLine("Tool outline z: ")
                                    'Console.WriteLine(ToolOutline(CInt(((ActualPoint.Y + ToolRadius) - w * CamContourSpacing) / ToolOutlineSpacing)).Z)
#End If
                                End If
                            End If
                        Next
                    Next
                    NotDefined = True

                    ' To let the tool only move as deep as the intermidiate groud plane

                    If ActualPoint.Z < m Then
                        ActualPoint.Z = m
                    End If

                    ' Check if tool should retract to move rapid over milled contour

                    If ActualPoint.Z > m - InfeedGround And m > CamContourGroundPlane Then ' Retract only if the cutting depth is smaller than the difference between "HeighestPoint" and "CamContourGroundPlane"

                        ActualPoint.Z = FinalToolWorkRetractHeight

                        ' Check if array is big enough

                        If ArrayCount > CamPath.Length - 10 Then
                            ReDim Preserve CamPath(CamPath.Length + 2000)
                        End If

                        If IsAtToolWorkRetractHeight = False Then
                            IsAtToolWorkRetractHeight = True
                            CamPath(ArrayCount) = New cSimplePoint(CamPath(ArrayCount - 1))
                            CamPath(ArrayCount).Z = ActualPoint.Z
                            CamPath(ArrayCount).Annotation = "Rapid"
                            ArrayCount += 1
                        End If

                    End If

                    If ActualPoint.Z = FinalToolWorkRetractHeight Then
                        If ActualPoint.Z = CamPath(ArrayCount - 1).Z And ActualPoint.Z = CamPath(ArrayCount - 2).Z And CamPath(ArrayCount - 1).Annotation = "Rapid" Then ' Check if the last point z value is the same as the "ActualPoint" z value to omit the last one to make a longer G1
                            CamPath(ArrayCount - 1).X = ActualPoint.X
                            CamPath(ArrayCount - 1).Y = ActualPoint.Y
                        Else

                            ' Check if array is big enough

                            If ArrayCount > CamPath.Length - 10 Then
                                ReDim Preserve CamPath(CamPath.Length + 2000)
                            End If

                            CamPath(ArrayCount) = New cSimplePoint(ActualPoint.X, ActualPoint.Y, ActualPoint.Z, "Rapid")
                            ArrayCount += 1
                        End If

                    Else

                        ' Tool is machining the cam contour

                        If IsAtToolWorkRetractHeight = True Then ' Check if tool comes from "FinalToolWorkRetractHeight"
                            IsAtToolWorkRetractHeight = False ' Set it back for the next time the tool moves to "FinalToolWorkRetractHeight"
                            If ArrayCount > CamPath.Length - 10 Then ' Check if array is big enough
                                ReDim Preserve CamPath(CamPath.Length + 2000)
                            End If
                            CamPath(ArrayCount) = New cSimplePoint(ActualPoint.X, ActualPoint.Y, FinalToolWorkRetractHeight, "Work") ' Add a "perpenticular move from "FinalToolWorkRetractHeight" to the next cam conour machining point
                            ArrayCount += 1
                        End If

                        If ActualPoint.Z = CamPath(ArrayCount - 1).Z And ActualPoint.Z = CamPath(ArrayCount - 2).Z And CamPath(ArrayCount - 1).Annotation = "Work" Then ' Check if the last point z value is the same as the "ActualPoint" z value to omit the last one to make a longer G1
                            CamPath(ArrayCount - 1).X = ActualPoint.X
                            CamPath(ArrayCount - 1).Y = ActualPoint.Y
                        Else

                            ' Check if array is big enough

                            If ArrayCount > CamPath.Length - 10 Then
                                ReDim Preserve CamPath(CamPath.Length + 2000)
                            End If

                            CamPath(ArrayCount) = New cSimplePoint(ActualPoint.X, ActualPoint.Y, ActualPoint.Z, "Work")
                            ArrayCount += 1
                        End If
                    End If
                Next
                CamPath(ArrayCount) = New cSimplePoint(ActualPoint.X, ActualPoint.Y, FinalToolWorkRetractHeight, "Rapid")
                ArrayCount += 1
            Next

            If m = CamContourGroundPlane Then
                Exit Do
            End If

            If m + InfeedGround < CamContourGroundPlane Then ' Set "InfeedGround" for the last step
                m = CamContourGroundPlane
            Else
                m += InfeedGround
            End If
        Loop

        If ArrayCount > CamPath.Length - 10 Then ' Check if array is big enough
            ReDim Preserve CamPath(CamPath.Length + 2000)
        End If
        CamPath(ArrayCount) = New cSimplePoint(CamPath(ArrayCount - 1)) ' Add the last sentence
        CamPath(ArrayCount).Z = StartStopRetractHeight + HeighestPoint
        CamPath(ArrayCount).Annotation = "Rapid"

        ReDim Preserve CamPath(ArrayCount) ' Redim CamPath to indicies with valid values

        Return Result(2)
    End Function

    ''' <summary>
    ''' Creates the mesh from point array.
    ''' </summary>
    ''' <param name="Mesh">The mesh.</param>
    ''' <param name="ZValues">The z values.</param>
    ''' <param name="StepWidthX">The step width x.</param>
    Public Sub createMeshFromPointArray(ByRef Mesh As cPointArray, ByRef ZValues() As List(Of cSimplePoint), ByVal StepWidthX As Double, ByVal MMProP As Double)

        Dim IndexX As Integer
        Dim ActualStepWidth As Integer
        Dim ColumnStartIndex1, ColumnStartIndex2 As Integer
        Dim MeshArrayIndex As Integer
        Dim ColumnActualIndex1, ColumnActualIndex2 As Integer
        Dim SortedScanPoints(ZValues.Length - 1) As List(Of cSimplePoint)

        '-----------------------------------------------------------------------------------------------------------
        Dim KindOfTriangulation As String

        'The kind how vertices are added to the mesh array. Vertices are extracted counter clockwise. In the
        'upward direction "Upward1" is the first. In the downward direction "Downward1" is the first.
        'There are 4 kinds to extract vertices from columns. 2 in the upward direction and 2 in the downward
        'direction.In upward direction:
        '
        '   "Upward1" means to start with a vertex in column1 and take the next two vertices of column2.                                                       
        '   "Upward2" means to start with a vertex in column1 than take a verticex of column2 and again
        '   a vertex of column1.                                                       
        '   "Downward1" means to start with a vertex in column1 and take the next two vertices of column2.                                                       

        '--- Initial settings ---

        KindOfTriangulation = " "
        IndexX = 0
        ActualStepWidth = 0
        MeshArrayIndex = 0
        ReDim Mesh.m_PointArray(2000)

        '--- Sort the scan points by Y ---

        'For i As Integer = 0 To ZValues.Length - 1
        '    SortedScanPoints(i) = New List(Of cSimplePoint)
        '    SortedScanPoints(i) = From v In ZValues(i) Order By v.Y
        'Next

        '--- Mesh the points by creating triangle corner points ---

        Do While ZValues(IndexX).Count < 3 And IndexX <= (ZValues.Length - 2) 'Find the first column that contains any scan point
            IndexX += 1
        Loop

        Do While 1

            '--- Find a column in the approx. distance of "StepWidthX" from actual "IndexX" ---

            ActualStepWidth = CInt(StepWidthX / MMProP)

            Try
                Do While (ZValues(IndexX + ActualStepWidth).Count < 3)
                    ActualStepWidth += 1
                Loop
            Catch e As IndexOutOfRangeException
#If DEBUG Then
                Console.WriteLine("Not enough scan points available.")
#End If
                Exit Do
            End Try

            '--- Find the "ColumnStartIndex" ---

            If ZValues(IndexX).Count = 3 Then
                ColumnStartIndex1 = 1
            Else
                ColumnStartIndex1 = CInt(ZValues(IndexX).Count / 2)
            End If
            If ZValues(IndexX + ActualStepWidth).Count = 3 Then
                ColumnStartIndex2 = 1
            Else
                ColumnStartIndex2 = CInt(ZValues(IndexX + ActualStepWidth).Count / 2)
            End If

            '--- Triangulize upwards ---

            ColumnActualIndex1 = ColumnStartIndex1
            ColumnActualIndex2 = ColumnStartIndex2
            KindOfTriangulation = "Upward1"

            Do While 1
                If Mesh.m_PointArray.Length < MeshArrayIndex + 4 Then 'Check if the array can take another triangle
                    ReDim Preserve Mesh.m_PointArray(Mesh.m_PointArray.Length + 2000)
                End If
                Select Case KindOfTriangulation
                    Case "Upward1"
                        Mesh.m_PointArray(MeshArrayIndex) = New cSimplePoint(ZValues(IndexX).Item(ColumnActualIndex1))
                        MeshArrayIndex += 1
                        Mesh.m_PointArray(MeshArrayIndex) = New cSimplePoint(ZValues(IndexX + ActualStepWidth).Item(ColumnActualIndex2))
                        ColumnActualIndex2 += 1
                        MeshArrayIndex += 1
                        Mesh.m_PointArray(MeshArrayIndex) = New cSimplePoint(ZValues(IndexX + ActualStepWidth).Item(ColumnActualIndex2))
                        MeshArrayIndex += 1
                    Case "Upward2"
                        Mesh.m_PointArray(MeshArrayIndex) = New cSimplePoint(ZValues(IndexX).Item(ColumnActualIndex1))
                        MeshArrayIndex += 1
                        Mesh.m_PointArray(MeshArrayIndex) = New cSimplePoint(ZValues(IndexX + ActualStepWidth).Item(ColumnActualIndex2))
                        ColumnActualIndex1 += 1
                        MeshArrayIndex += 1
                        Mesh.m_PointArray(MeshArrayIndex) = New cSimplePoint(ZValues(IndexX).Item(ColumnActualIndex1))
                        MeshArrayIndex += 1
                End Select
                Select Case KindOfTriangulation
                    Case "Upward1"
                        If ColumnActualIndex1 < (ZValues(IndexX).Count - 1) And ColumnActualIndex2 <= (ZValues(IndexX + ActualStepWidth).Count - 1) Then
                            KindOfTriangulation = "Upward2"
                        End If
                        If ColumnActualIndex1 = (ZValues(IndexX).Count - 1) And ColumnActualIndex2 < (ZValues(IndexX + ActualStepWidth).Count - 1) Then
                            KindOfTriangulation = "Upward1"
                        End If
                        Exit Select
                    Case "Upward2"
                        If ColumnActualIndex2 < (ZValues(IndexX + ActualStepWidth).Count - 1) And ColumnActualIndex1 <= (ZValues(IndexX).Count - 1) Then
                            KindOfTriangulation = "Upward1"
                        End If
                        If ColumnActualIndex2 = (ZValues(IndexX + ActualStepWidth).Count - 1) And ColumnActualIndex1 < (ZValues(IndexX).Count - 1) Then
                            KindOfTriangulation = "Upward2"
                        End If
                End Select
                If ColumnActualIndex1 = (ZValues(IndexX).Count - 1) And ColumnActualIndex2 = (ZValues(IndexX + ActualStepWidth).Count - 1) Then
                    '--- Check if the end in the upward direction was reached ---
                    Exit Do
                End If
            Loop

            '--- Triangulize downwards ---

            ColumnActualIndex1 = ColumnStartIndex1
            ColumnActualIndex2 = ColumnStartIndex2 - 1
            KindOfTriangulation = "Downward1"

            Do While 1
                If Mesh.m_PointArray.Length < MeshArrayIndex + 4 Then 'Check if the array can take another triangle
                    ReDim Preserve Mesh.m_PointArray(Mesh.m_PointArray.Length + 2000)
                End If
                Select Case KindOfTriangulation
                    Case "Downward1"
                        Mesh.m_PointArray(MeshArrayIndex) = New cSimplePoint(ZValues(IndexX).Item(ColumnActualIndex1))
                        MeshArrayIndex += 1
                        Mesh.m_PointArray(MeshArrayIndex) = New cSimplePoint(ZValues(IndexX + ActualStepWidth).Item(ColumnActualIndex2))
                        ColumnActualIndex2 += 1
                        MeshArrayIndex += 1
                        Mesh.m_PointArray(MeshArrayIndex) = New cSimplePoint(ZValues(IndexX + ActualStepWidth).Item(ColumnActualIndex2))
                        MeshArrayIndex += 1
                        ColumnActualIndex2 -= 1
                    Case "Downward2"
                        Mesh.m_PointArray(MeshArrayIndex) = New cSimplePoint(ZValues(IndexX).Item(ColumnActualIndex1))
                        MeshArrayIndex += 1
                        ColumnActualIndex1 -= 1
                        Mesh.m_PointArray(MeshArrayIndex) = New cSimplePoint(ZValues(IndexX).Item(ColumnActualIndex1))
                        MeshArrayIndex += 1
                        Mesh.m_PointArray(MeshArrayIndex) = New cSimplePoint(ZValues(IndexX + ActualStepWidth).Item(ColumnActualIndex2))
                        MeshArrayIndex += 1
                End Select
                Select Case KindOfTriangulation
                    Case "Downward1"
                        If ColumnActualIndex1 > 0 And ColumnActualIndex2 >= 0 Then
                            KindOfTriangulation = "Downward2"
                        End If
                        If ColumnActualIndex1 = 0 And ColumnActualIndex2 > 0 Then
                            ColumnActualIndex2 -= 1
                            KindOfTriangulation = "Downward1"
                        End If
                        Exit Select
                    Case "Downward2"
                        If ColumnActualIndex2 > 0 And ColumnActualIndex1 >= 0 Then
                            ColumnActualIndex2 -= 1
                            KindOfTriangulation = "Downward1"
                        End If
                        If ColumnActualIndex2 = 0 And ColumnActualIndex1 > 0 Then
                            KindOfTriangulation = "Downward2"
                        End If
                End Select
                If ColumnActualIndex1 = 0 And ColumnActualIndex2 = 0 Then
                    '--- Check if the end in the upward direction was reached ---
                    Exit Do
                End If
            Loop

            IndexX += ActualStepWidth
            If (IndexX + CInt(StepWidthX / MMProP)) >= ZValues.Count Then
                Exit Do
            End If
        Loop

        '--- Redim the mesh array to only valuable values ---

        ReDim Preserve Mesh.m_PointArray(MeshArrayIndex - 1)

    End Sub

    Public Sub executeDCT(ByRef DCTMatrix(,) As Double, ByRef Picture As Bitmap, ByVal Parameter As String)

        Dim cm, factor As Double 'width and brigth of the picture
        Dim Matrix(Picture.Width - 1, Picture.Height - 1) As Double
        Dim M As Integer

        ReDim DCTMatrix(Picture.Width - 1, Picture.Height - 1)


        M = Matrix.GetLength(0) - 1
        factor = 1

        'DCT for rows
        For t As Integer = 0 To Matrix.GetLength(1) / 8 - 2
            For v As Integer = 0 To Matrix.GetLength(0) / 8 - 2
                For y As Integer = 0 To 7
                    For x As Integer = 0 To 7
                        If x = 0 Then
                            cm = 1 / Sqrt(2)
                        Else
                            cm = 1
                        End If
                        For u As Integer = 0 To 7
                            DCTMatrix(x + v * 8, y + t * 8) += Matrix(u + v * 8, y + t * 8) * cm * Cos(PI * x * (2 * u + 1) / (2 * M))
                        Next u
                        DCTMatrix(x, y) *= Sqrt(2 / M)
                    Next x
                Next y
            Next v
        Next t

        'DCT for columns

        For x As Integer = 0 To 7
            For y As Integer = 0 To 7
                Matrix(x, y) = 0
            Next
        Next

        M = Matrix.GetLength(1) - 1

        For t As Integer = 0 To Matrix.GetLength(0) / 8 - 2
            For v As Integer = 0 To Matrix.GetLength(1) / 8 - 2
                For x As Integer = 0 To 7
                    For y As Integer = 0 To 7
                        If y = 0 Then
                            cm = 1 / Sqrt(2)
                        Else
                            cm = 1
                        End If
                        For u As Integer = 0 To 7
                            Matrix(x + t * 8, y + v * 8) += DCTMatrix(x + t * 8, u + v * 8) * cm * Cos(PI * y * (2 * u + 1) / (2 * M))
                        Next u
                        Matrix(x, y) *= Sqrt(2 / M)
                    Next y
                Next x
            Next v
        Next t

        'DCT to picture


        'logarithmieren

        'For x = 0 To mMatrix.GetLength(0) - 2
        '    For y = 0 To mMatrix.GetLength(1) - 2
        '        mMatrix(x, y) = Log(mMatrix(x, y))
        '    Next
        'Next

        'dblBufferMin = mMatrix(0, 0)
        'dblBufferMax = mMatrix(0, 0)

        'For x = 0 To mMatrix.GetLength(0) - 2
        '    For y = 0 To mMatrix.GetLength(1) - 2
        '        If mMatrix(x, y) > dblBufferMax Then
        '            dblBufferMax = mMatrix(x, y)
        '        End If
        '        If mMatrix(x, y) < dblBufferMin Then
        '            dblBufferMin = mMatrix(x, y)
        '        End If
        '    Next
        'Next
        'Console.Write(dblBufferMax)
        'Console.Write("---")
        'Console.Write(dblBufferMin)

        'dblBufferMax += dblBufferMin / (-1)

        'For x = 0 To mMatrix.GetLength(0) - 2
        '    For y = 0 To mMatrix.GetLength(1) - 2
        '        mMatrix(x, y) += dblBufferMin / (-1)
        '        mMatrix(x, y) = mMatrix(x, y) * 255 / dblBufferMax
        '        'Console.Write(mMatrix(x, y))
        '        'Console.Write("....")
        '    Next
        'Next

    End Sub

    Public Sub executeIDCT(ByRef Matrix(,) As Double, ByRef Picture As Bitmap)

        Dim cm, factor As Double 'width and brigth of the picture
        Dim M As Integer
        Dim NewPictureMatrix(,) As Double
        Dim DCTMatrix(Matrix.GetLength(0) - 1, Matrix.GetLength(1) - 1)
        Dim PixelColor As Color

        'IDCT for columns

        For x As Integer = 0 To Matrix.GetLength(0) - 2
            For y As Integer = 0 To Matrix.GetLength(1) - 2
                DCTMatrix(x, y) = 0
            Next
        Next

        For t As Integer = 0 To Matrix.GetLength(0) / 8 - 2
            For v As Integer = 0 To Matrix.GetLength(1) / 8 - 2
                For x As Integer = 0 To 7
                    For y As Integer = 0 To 7
                        For z As Integer = 0 To 7
                            If z = 0 Then
                                cm = 1 / Sqrt(2)
                            Else
                                cm = 1
                            End If
                            DCTMatrix(x + t * 8, y + v * 8) += Matrix(x + t * 8, z + v * 8) * cm * Cos(PI * z * (2 * y + 1) / (2 * M)) * factor
                        Next z
                        DCTMatrix(x, y) *= Sqrt(2 / M)
                    Next y
                Next x
            Next v
        Next t

        'IDCT for rows

        For x As Integer = 0 To Matrix.GetLength(0) - 2
            For y As Integer = 0 To Matrix.GetLength(1) - 2
                Matrix(x, y) = 0
            Next
        Next

        M = Matrix.GetLength(0) - 1

        For t As Integer = 0 To Matrix.GetLength(1) / 8 - 2
            For v As Integer = 0 To Matrix.GetLength(0) / 8 - 7
                For y As Integer = 0 To 7
                    For x As Integer = 0 To 7
                        factor = 1
                        For z As Integer = 0 To 7
                            If z = 0 Then
                                cm = 1 / Sqrt(2)
                            Else
                                cm = 1
                            End If
                            Matrix(x + v * 8, y + t * 8) += DCTMatrix(z + v * 8, y + t * 8) * cm * Cos(PI * z * (2 * x + 1) / (2 * M)) * factor
                        Next z
                        Matrix(x, y) *= Sqrt(2 / M)
                    Next x
                Next y
            Next v
        Next t

        ReDim NewPictureMatrix(Matrix.GetLength(0) - 1, Matrix.GetLength(1) - 1)

        For i As Integer = 0 To Picture.Width - 1
            For j As Integer = 0 To Picture.Height - 1
                If Matrix(i, j) <= 255 And Matrix(i, j) >= 0 Then
                    NewPictureMatrix(i, j) = CByte(Matrix(i, j))
                ElseIf Matrix(i, j) < 0 Then
                    NewPictureMatrix(i, j) = 0
                ElseIf Matrix(i, j) > 255 Then
                    NewPictureMatrix(i, j) = 255
                End If
            Next
        Next

        For i As Integer = 0 To NewPictureMatrix.GetLength(0) - 1
            For j As Integer = 0 To NewPictureMatrix.GetLength(1) - 1
                PixelColor = Color.FromArgb(NewPictureMatrix(i, j), NewPictureMatrix(i, j), NewPictureMatrix(i, j))
                Picture.SetPixel(i, j, PixelColor)
            Next
        Next

    End Sub

    ''' <summary>
    ''' Filters a matrix by transforming the matrix with dct than filter these matrix by the given "MatrixFilter" and transforming the
    ''' matrix back by idct.
    ''' </summary>
    ''' <param name="Matrix">The matrix.</param>
    ''' <param name="MatrixFilter">The matrix filter.</param>
    ''' <returns></returns>
    Public Function filterAMatrix(ByRef Matrix(,) As Double, ByVal KindOfFilter As String) As String

        Dim cm As Double 'width and brigth of the picture
        Dim u, length As Integer
        Dim m88(,) As Double
        Dim Buffer(,) As Double

        '--- Initial settings ---

        length = Matrix.GetLength(0)
        ReDim m88(length, length)

        'DCT for rows

        For i As Integer = 0 To length - 1         'Set all elements to 0
            For j As Integer = 0 To length - 1
                m88(i, j) = 0
            Next
        Next

        For y As Integer = 0 To length - 1
            For x As Integer = 0 To length - 1
                If x = 0 Then
                    cm = 1 / Sqrt(2)
                Else
                    cm = 1
                End If
                For u = 0 To length - 1
                    m88(x, y) += Buffer(u, y) * cm * Cos(PI * x * (2 * u + 1) / (2 * length))
                Next u
                m88(x, y) *= Sqrt(2 / length)
            Next x
        Next y

        'DCT for columns

        For i As Integer = 0 To length - 1
            For j As Integer = 0 To length - 1
                Buffer(i, j) = 0
            Next
        Next

        For x As Integer = 0 To length - 1
            For y As Integer = 0 To length - 1
                If y = 0 Then
                    cm = 1 / Sqrt(2)
                Else
                    cm = 1
                End If
                For u = 0 To length - 1
                    Buffer(x, y) += m88(x, u) * cm * Cos(PI * y * (2 * u + 1) / (2 * length))
                Next u
                Buffer(x, y) *= Sqrt(2 / length)
            Next y
        Next x

        filterIt(Buffer, KindOfFilter)

        'IDCT for columns

        For i = 0 To 12
            For j = 0 To 12
                m88(i, j) = 0
            Next
        Next

        For x = 0 To 7
            For y = 0 To 7
                For z = 0 To 7
                    If z = 0 Then
                        cm = 1 / Sqrt(2)
                    Else
                        cm = 1
                    End If
                    m88(x, y) += Buffer(x, z) * cm * Cos(PI * z * (2 * y + 1) / (2 * 8))
                Next z
                m88(x, y) *= Sqrt(2 / 8)
            Next y
        Next x

        'IDCT for rows

        For i = 0 To 12
            For j = 0 To 12
                Buffer(i, j) = 0
            Next
        Next

        For y = 0 To 7
            For x = 0 To 7
                For z = 0 To 7
                    If z = 0 Then
                        cm = 1 / Sqrt(2)
                    Else
                        cm = 1
                    End If
                    Buffer(x, y) += m88(z, y) * cm * Cos(PI * z * (2 * x + 1) / (2 * 8))
                Next z
                Buffer(x, y) *= Sqrt(2 / 8)
            Next x
        Next y

        Return "Ok"
    End Function

    Private Sub dimMatrix(ByRef Picture As Bitmap, ByRef Matrix(,) As Double, Optional iFlag As Integer = 0)

        'dimension the matrix to fitin 8 x 8 blocks

        Dim dblWidth, dblHeigth As Double 'width and brigth of the picture
        Dim w, h As Integer

        dblWidth = Picture.Width
        dblHeigth = Picture.Height

        If dblWidth Mod 8 > 0 Then
            w = (dblWidth \ 8 + 1) * 8
        Else
            w = (dblWidth \ 8) * 8
        End If
        Console.Write(w)
        If dblHeigth Mod 8 > 0 Then
            h = (dblHeigth \ 8 + 1) * 8
        Else
            h = (dblHeigth \ 8) * 8
        End If
        Console.Write(h)
        ReDim Matrix(w, h)

        'set all matrix members to 0

        Select Case iFlag
            Case 0
                For x = 0 To w - 1
                    For y = 0 To h - 1
                        Matrix(x, y) = 0
                    Next
                Next
        End Select

    End Sub

    Public Function filterPicture(ByRef Picture As Bitmap, ByRef FilteredPicture As Bitmap, ByVal KindOfFilter As String) As String

        Dim Buffer(8, 8) As Double
        Dim PixelColor As Color
        Dim NewPictureMatrix(,) As Double
        Dim Matrix(,) As Double
        Dim PictureWidthBuffer As Integer
        Dim PictureHeightBuffer As Integer

        '--- Check if the parameter are valid ---

        If FilteredPicture Is Nothing Or Picture Is Nothing Then
            Return "No picture object available"
        End If

        '--- Redim the matrix so that it's width and height is a multiple of 8 (add indicies if necessary) ---

        PictureWidthBuffer = Picture.Width Mod 8
        If PictureWidthBuffer <> 0 Then
            PictureWidthBuffer = 8 - PictureWidthBuffer
        End If
        PictureHeightBuffer = Picture.Height Mod 8
        If PictureHeightBuffer <> 0 Then
            PictureHeightBuffer = 8 - PictureHeightBuffer
        End If
        ReDim Matrix(Picture.Width - 1 + PictureWidthBuffer, Picture.Height - 1 + PictureHeightBuffer)



        For x As Integer = 0 To Picture.Width - 1
            For y As Integer = 0 To Picture.Height - 1
                Matrix(x, y) = (getRGBColor(Picture.GetPixel(x, y))(0) + getRGBColor(Picture.GetPixel(x, y))(1) + getRGBColor(Picture.GetPixel(x, y))(2)) / 3
            Next
        Next

        For w As Integer = 0 To Matrix.GetLength(0) - 2 Step 8
            For h As Integer = 0 To Matrix.GetLength(1) - 2 Step 8
                For x As Integer = 0 To 7
                    For y As Integer = 0 To 7
                        Buffer(x, y) = Matrix(x + w, y + h)
                    Next
                Next
                filterAMatrix(Buffer, KindOfFilter)
                For x = 0 To 7
                    For y = 0 To 7
                        Matrix(x + w, y + h) = Buffer(x, y)
                    Next
                Next
            Next
        Next

        ReDim NewPictureMatrix(Matrix.GetLength(0) - 1, Matrix.GetLength(1) - 1)

        For i = 0 To Picture.Width - 1
            For j = 0 To Picture.Height - 1
                If Matrix(i, j) <= 255 And Matrix(i, j) >= 0 Then
                    NewPictureMatrix(i, j) = CByte(Matrix(i, j))
                ElseIf Matrix(i, j) < 0 Then
                    NewPictureMatrix(i, j) = 0
                ElseIf Matrix(i, j) > 255 Then
                    NewPictureMatrix(i, j) = 255
                End If
            Next
        Next

        For i As Integer = 0 To Picture.Width - 1
            For j As Integer = 0 To Picture.Height - 1
                PixelColor = Color.FromArgb(NewPictureMatrix(i, j), NewPictureMatrix(i, j), NewPictureMatrix(i, j))
                FilteredPicture.SetPixel(i, j, PixelColor)
            Next
        Next

        Return "Ready"
    End Function

    Public Sub createFilter(ByRef Filter(,) As Double, ByVal KindOfFilter As String)

        Select Case KindOfFilter
            Case "Median"
            Case "SobelX"
                ReDim Filter(2, 2)
                Dim MyFilter(,) As Double = New Double(2, 2) {{1, 2, 1},
                           {0, 0, 0},
                           {-1, -2, -1}}
                Array.Copy(MyFilter, Filter, 9)
            Case "SobelY"
                ReDim Filter(2, 2)
                Dim MyFilter(,) As Double = New Double(2, 2) {{-1, 0, 1},
                           {-2, 0, 2},
                           {-1, 0, 1}}
                Array.Copy(MyFilter, Filter, 9)
        End Select

    End Sub

    Public Function filterIt(ByRef Matrix(,) As Double, ByVal KindOfFilter As String) As String

        Dim MatrixFilterX(,) As Double
        Dim MatrixFilterY(,) As Double
        Dim ResultBuffer(Matrix.GetLength(0), Matrix.GetLength(1)) As Double
        Dim MatrixBuffer(,) As Double


        '--- Create the "MatrixFilter". ---

        Select Case KindOfFilter
            Case "Sobel"
                createFilter(MatrixFilterX, "SobelX")
                createFilter(MatrixFilterY, "SobelY")
                If MatrixFilterX.GetLength(0) >= Matrix.GetLength(0) Then
                    Return "Filter to big or matrix to small."
#If DEBUG Then
                    Console.WriteLine("Filter to big or matrix to small.")
#End If
                End If
                If MatrixFilterX.GetLength(0) <> MatrixFilterY.GetLength(1) Or Matrix.GetLength(0) <> Matrix.GetLength(1) Then
                    Return "Filter or matrix not quadratic."
#If DEBUG Then
                    Console.WriteLine("Filter or matrix not quadratic.")
#End If
                End If
                ReDim MatrixBuffer(Matrix.GetLength(0) + MatrixFilterX.GetLength(0) - 1, Matrix.GetLength(0) + MatrixFilterX.GetLength(0) - 1)

                '--- Begin filtering. ---

                For x As Integer = 0 To Matrix.GetLength(0) - 1
                    For y As Integer = 0 To Matrix.GetLength(0) - 1
                        For i As Integer = 0 To MatrixFilterX.GetLength(0) - 1
                            For j As Integer = 0 To MatrixFilterX.GetLength(0) - 1
                                'ResultBuffer(i, j) *= Filter(i, j)
                            Next
                        Next
                    Next
                Next

                '--- Put the result in the "Matrix". ---

                For x As Integer = 0 To Matrix.GetLength(0) - 1
                    For y As Integer = 0 To Matrix.GetLength(0) - 1
                        Matrix(x, y) = ResultBuffer(x, y)
                    Next
                Next
        End Select

        Return "Ok."
    End Function

    Public Sub makePictureBinary(ByRef Picture As Bitmap, ByVal Threshold As Integer)

        Dim PictureMatrix(Picture.Width - 1, Picture.Height - 1) As Integer
        Dim PicturePixelColor(3) As Integer

        For x As Integer = 0 To Picture.Width - 1
            For y As Integer = 0 To Picture.Height - 1
                PicturePixelColor(0) = getRGBColor(Picture.GetPixel(x, y))(0)
                PicturePixelColor(1) = getRGBColor(Picture.GetPixel(x, y))(1)
                PicturePixelColor(2) = getRGBColor(Picture.GetPixel(x, y))(2)
                If ((PicturePixelColor(0) + PicturePixelColor(1) + PicturePixelColor(2)) / 3) <= Threshold Then
                    Picture.SetPixel(x, y, Color.Black)
                Else
                    Picture.SetPixel(x, y, Color.White)
                End If
            Next
        Next

    End Sub

    Public Function filterMatrixByFolding(ByRef OriginalPicture As Bitmap, ByRef ResultPicture As Bitmap, ByVal KindOfFilter As String) As String

        Dim ResultMatrix1(OriginalPicture.Width, OriginalPicture.Height) As Double    'For picture filtered in the x-direction
        Dim ResultMatrix2(OriginalPicture.Width, OriginalPicture.Height) As Double   'For picture filtered in the y-direction
        Dim PictureBufferMatrix(,) As Double
        Dim FilterMatrixX(,) As Double
        Dim FilterMatrixY(,) As Double
        Dim PictureWidthBuffer As Integer
        Dim PictureHeightBuffer As Integer
        Dim Middle As Integer                               'The middle point of the filter matrix
        Dim ResultColor As Color
        Dim MaxValue As Double

        '--- Initial settings. ---

        MaxValue = -100000

        Select Case KindOfFilter
            Case "Sobel"
                createFilter(FilterMatrixX, "SobelX")
                createFilter(FilterMatrixY, "SobelY")

                '--- Find the distance of the centerpoint of the filter matrix from one of it's edges. ---

                If FilterMatrixY.GetLength(0) Mod 2 <> 0 Then
                    Middle = FilterMatrixY.GetLength(0) / 2
                Else
                    Middle = FilterMatrixY.GetLength(0) / 2 - 1
                End If

                '--- Redim the matrix so that it's width and height is a multiple of 8 (add indicies if necessary) ---

                PictureWidthBuffer = OriginalPicture.Width Mod FilterMatrixX.GetLength(0)
                If PictureWidthBuffer <> 0 Then
                    PictureWidthBuffer = FilterMatrixX.GetLength(0) - PictureWidthBuffer
                End If
                PictureHeightBuffer = OriginalPicture.Height Mod FilterMatrixX.GetLength(0)
                If PictureHeightBuffer <> 0 Then
                    PictureHeightBuffer = FilterMatrixX.GetLength(0) - PictureHeightBuffer
                End If

                ReDim PictureBufferMatrix(OriginalPicture.Width + PictureWidthBuffer + FilterMatrixX.GetLength(0), OriginalPicture.Height + PictureHeightBuffer + FilterMatrixX.GetLength(0))

                For x As Integer = Middle To OriginalPicture.Width
                    For y As Integer = Middle To OriginalPicture.Height

                        '--- Fill the "PictureBufferMatrix" with gray scale values of the "OriginalPicture". ---

                        PictureBufferMatrix(x, y) = (getRGBColor(OriginalPicture.GetPixel(x - Middle, y - Middle))(0) + getRGBColor(OriginalPicture.GetPixel(x - Middle, y - Middle))(1) + getRGBColor(OriginalPicture.GetPixel(x - Middle, y - Middle))(2)) / 3
                    Next
                Next

                '--- Fold the result matricies with the filter matricies. ---
                For z As Integer = 0 To 1
                    For x As Integer = 0 To OriginalPicture.Width - 1
                        For y As Integer = 0 To OriginalPicture.Height - 1
                            For i As Integer = 0 To FilterMatrixX.GetLength(0) - 1
                                For j As Integer = 0 To FilterMatrixX.GetLength(0) - 1
                                    If z = 0 Then
                                        ResultMatrix1(x, y) += PictureBufferMatrix(x + i, y + j) * FilterMatrixX(i, j)
                                    Else
                                        ResultMatrix2(x, y) += PictureBufferMatrix(x + i, y + j) * FilterMatrixY(i, j)
                                    End If
                                Next
                            Next
                        Next
                    Next
                Next

                '--- Sum all pixel values to unite the x and the y folding result. ---

                For x As Integer = 0 To OriginalPicture.Width - 1
                    For y As Integer = 0 To OriginalPicture.Height - 1
                        ResultMatrix1(x, y) = Math.Sqrt(ResultMatrix1(x, y) ^ 2 + ResultMatrix2(x, y) ^ 2)
                    Next
                Next

                '--- Normalize the values. ---

                For x As Integer = 0 To OriginalPicture.Width - 1
                    For y As Integer = 0 To OriginalPicture.Height - 1
                        If ResultMatrix1(x, y) > MaxValue Then
                            MaxValue = ResultMatrix1(x, y)
                        End If
                    Next
                Next

                '--- Put the result in the "ResultPicture". ---

                ResultPicture = New Bitmap(OriginalPicture.Width, OriginalPicture.Height)
                For x As Integer = 0 To OriginalPicture.Width - 1
                    For y As Integer = 0 To OriginalPicture.Height - 1
                        'Console.WriteLine(CStr(ResultMatrix1(x, y)))

                        ResultMatrix1(x, y) = ResultMatrix1(x, y) / MaxValue * 255
                        If ResultMatrix1(x, y) > 150 Then
                            ResultPicture.SetPixel(x, y, Color.White)
                        End If
                    Next
                Next

        End Select

        Return "Ok."
    End Function

    ''' <summary>
    ''' Transforms the matrix hough.
    ''' </summary>
    ''' <param name="PictureToTransform">The picture to transform.</param>
    ''' <param name="AngleStep">The angle step.</param>
    ''' <param name="DecimalPlacesOfRho">The decimal places of rho.</param>
    ''' <param name="Result">The result.</param>
    ''' <returns></returns>
    Public Function transformMatrixHough(ByRef PictureToTransform As Bitmap, ByVal AngleStep As Double, ByVal DecimalPlacesOfRho As Integer, ByRef Result As Collection, ByRef ResultPicture As Bitmap, WhatToExtract As String) As String

        '--- Check parameters to be valid. ---

        If AngleStep < 0 And AngleStep > 179 Then
            Return ("AngleStep not valid.")
        End If
        If DecimalPlacesOfRho < 0 And DecimalPlacesOfRho > 4 Then
            Return ("DecimalPlacesOfRho not valid.")
        End If

        '---

        Dim MinVote(2) As Integer
        Dim LengthOfR As Integer            'The length of the array holding the rho values
        Dim LengthOfAngle As Integer    'The length of the array vector holding marking the angle values
        Dim PicturePixelColor(2) As Integer
        Dim MaxLocation As New Point()
        Dim MaxVote As Integer
        Dim StartPoint As New Point()
        Dim EndPoint As New Point()
        Dim Buffer As Integer
        Dim BufferPoint As New Point()

        Select Case WhatToExtract
            Case "Line"

                '--- Initial settings ---

                Dim AngleIndex As Integer
                Dim DistanceIndex As Integer
                MinVote(0) = 5 'Minimum amount of pixle voting for one line
                LengthOfR = CInt(Math.Sqrt(PictureToTransform.Width ^ 2 + PictureToTransform.Height ^ 2) * DecimalPlacesOfRho * 10) + 100
                LengthOfAngle = CInt(180 / AngleStep) + 100

                Dim HoughMatrix(LengthOfR - 1, LengthOfAngle - 1) As List(Of Point)
                For x As Integer = 0 To HoughMatrix.GetLength(0) - 1
                    For y As Integer = 0 To HoughMatrix.GetLength(1) - 1
                        HoughMatrix(x, y) = New List(Of Point)
                    Next
                Next
                Dim rho As Double
                ResultPicture = New Bitmap(LengthOfR - 1, LengthOfAngle - 1)

                '---

                For w As Integer = 0 To 3

                    For x As Integer = 0 To HoughMatrix.GetLength(0) - 1
                        For y As Integer = 0 To HoughMatrix.GetLength(1) - 1
                            If HoughMatrix(x, y).Count > 0 Then
                                HoughMatrix(x, y).Clear()
                            End If
                            HoughMatrix(x, y).Add(New Point(0, 0))
                        Next
                    Next
                    For x As Integer = 0 To PictureToTransform.Width - 1
                        For y As Integer = 0 To PictureToTransform.Height - 1

                            If PictureToTransform.GetPixel(x, y) = Color.White Then

                                For theta = -89.99 To 89.99 Step AngleStep
                                    rho = Math.Round((x * Math.Cos(theta * Math.PI / 180) + y * Math.Sin(theta * Math.PI / 180)), DecimalPlacesOfRho)
                                    If rho >= 0 Then
                                        DistanceIndex = CInt(rho * 10 * DecimalPlacesOfRho)
                                    Else
                                        DistanceIndex = CInt(rho * 10 * DecimalPlacesOfRho * -1)
                                    End If
                                    AngleIndex = CInt((theta + 90) / AngleStep)
                                    BufferPoint = HoughMatrix(DistanceIndex, AngleIndex).Item(0)
                                    BufferPoint.X += 1
                                    HoughMatrix(DistanceIndex, AngleIndex).Item(0) = BufferPoint
                                    HoughMatrix(DistanceIndex, AngleIndex).Add(New Point(x, y))
                                Next
                            End If
                        Next
                    Next

                    '--- Find the maximal vote. ---

                    MaxVote = 0
                    For x As Integer = 0 To HoughMatrix.GetLength(0) - 1
                        For y As Integer = 0 To HoughMatrix.GetLength(1) - 1
                            If HoughMatrix(x, y).Count > 0 Then
                                If HoughMatrix(x, y).Item(0).X > MaxVote Then
                                    MaxVote = HoughMatrix(x, y).Item(0).X
                                    MaxLocation.X = x
                                    MaxLocation.Y = y
                                End If
                            End If
                        Next
                    Next

                    '--- Delete the pixles that voted for the "MaxLocation". ---

                    StartPoint.X = HoughMatrix(MaxLocation.X, MaxLocation.Y).Item(1).X
                    StartPoint.Y = HoughMatrix(MaxLocation.X, MaxLocation.Y).Item(1).Y
                    EndPoint.X = HoughMatrix(MaxLocation.X, MaxLocation.Y).Item(1).X
                    EndPoint.Y = HoughMatrix(MaxLocation.X, MaxLocation.Y).Item(1).Y
                    For x As Integer = MaxLocation.X - 10 To MaxLocation.X + 10
                        For y As Integer = MaxLocation.Y - 10 To MaxLocation.Y + 10
                            For z As Integer = 1 To HoughMatrix(x, y).Count - 1
                                PictureToTransform.SetPixel(HoughMatrix(x, y).Item(z).X, HoughMatrix(x, y).Item(z).Y, Color.Red)
                                If x > MaxLocation.X - 2 And x < MaxLocation.X + 2 And y > MaxLocation.Y - 2 And y < MaxLocation.Y + 2 Then
                                    If HoughMatrix(x, y).Item(z).X < StartPoint.X Then
                                        StartPoint.X = HoughMatrix(x, y).Item(z).X
                                        StartPoint.Y = HoughMatrix(x, y).Item(z).Y
                                    End If
                                    If HoughMatrix(x, y).Item(z).X > EndPoint.X Then
                                        EndPoint.X = HoughMatrix(x, y).Item(z).X
                                        EndPoint.Y = HoughMatrix(x, y).Item(z).Y
                                    End If
                                End If
                            Next
                        Next
                    Next
                    Result.Add(New cSimplePoint(StartPoint.X, StartPoint.Y))
                    Result.Add(New cSimplePoint(EndPoint.X, EndPoint.Y))
                Next

                '--- Make the "ResultPicture ---

                For x As Integer = 0 To ResultPicture.Width - 1
                    For y As Integer = 0 To ResultPicture.Height - 1
                        If HoughMatrix(x, y).Item(0).X < 13 Then
                            ResultPicture.SetPixel(x, y, Color.FromArgb(HoughMatrix(x, y).Item(0).X * 20, HoughMatrix(x, y).Item(0).X * 20, HoughMatrix(x, y).Item(0).X * 20))
                        Else
                            ResultPicture.SetPixel(x, y, Color.FromArgb(765))
                        End If
                    Next
                Next

            Case "Circle"

                '--- Initial settings ---

                Dim MinRadius As Double = 5
                Dim MaxRadius As Double = 20
                Dim BufferForRadius As Double

                MinVote(0) = 5 'Minimum amount of pixle voting for one line

                Dim HoughMatrix(PictureToTransform.Width - 1, PictureToTransform.Height - 1) As List(Of cSimplePoint)

                '---

                For x As Integer = 0 To PictureToTransform.Width - 1
                    For y As Integer = 0 To PictureToTransform.Height - 1
                        For r As Double = CDbl(MinRadius) To MaxRadius Step 0.1
                            For xx As Integer = 0 To PictureToTransform.Width - 1
                                For yy As Integer = 0 To PictureToTransform.Height - 1
                                    If PictureToTransform.GetPixel(x, y) = Color.White Then
                                        BufferForRadius = Math.Sqrt((xx - x) ^ 2 + (yy - y) ^ 2)
                                    End If
                                    If BufferForRadius >= MinRadius And BufferForRadius >= MaxRadius Then
                                        If HoughMatrix(x, y).Count = 0 Then
                                            For i As Integer = 0 To ((MaxRadius - MinRadius * 10))
                                                HoughMatrix(x, y).Add(New cSimplePoint(MinRadius + i / 10))
                                            Next
                                        End If

                                        HoughMatrix(x, y).Item(CInt(BufferForRadius * 10)).Y += 1    'The vote for the radius

                                    End If
                                Next
                            Next
                        Next

                    Next
                Next

                '--- Evaluate the radii. ---

                For x As Integer = 0 To HoughMatrix.GetLength(0) - 1
                    For y As Integer = 0 To HoughMatrix.GetLength(1) - 1
                        If HoughMatrix(x, y).Count > 0 Then
                            For i As Integer = 0 To HoughMatrix(x, y).Count - 1
                                If HoughMatrix(x, y).Item(i).Y >= MinVote(0) Then
                                    Result.Add(New cSimplePoint(x, y, HoughMatrix(x, y).Item(i).X / 10 + MinRadius, "Circle"))
                                    '--- Make the "ResultPicture ---

                                    For k As Integer = 0 To ResultPicture.Width - 1
                                        For l As Integer = 0 To ResultPicture.Height - 1
                                            If HoughMatrix(x, y).Item(0).X < 13 Then
                                                ResultPicture.SetPixel(k, l, Color.FromArgb(HoughMatrix(x, y).Item(0).X * 20, HoughMatrix(x, y).Item(0).X * 20, HoughMatrix(x, y).Item(0).X * 20))
                                            Else
                                                ResultPicture.SetPixel(k, l, Color.FromArgb(765))
                                            End If
                                        Next
                                    Next

                                End If
                            Next
                        End If
                    Next
                Next

        End Select


        Return "Ok."
    End Function

    ''' <summary>
    ''' Smoothings the point list array.
    ''' </summary>
    ''' <param name="PointListArray">The point list array.</param>
    ''' <returns></returns>
    Public Function smoothingPointListArray(ByRef PointListArray() As List(Of cSimplePoint)) As String

        Dim MedianBuffer(4) As Double

        For x As Integer = 0 To PointListArray.Length - 1
            For y As Integer = 0 To PointListArray(x).Count - 1
                For i As Integer = -2 To 2
                    If i < 0 Or (i + y) > (PointListArray(x).Count - 1) Then
                        MedianBuffer(i + 2) = 0
                    Else
                        MedianBuffer(i + 2) = PointListArray(x).Item(y + i).Z
                    End If
                Next
                sortDoubleArray(MedianBuffer)
                PointListArray(x).Item(y).Z = MedianBuffer(2)
            Next
        Next

        Return "Ok."
    End Function

    Public Function sortPointListArray(ByRef PointListArray() As List(Of cSimplePoint)) As String

        Dim BufferPoint As New cSimplePoint()
        Dim Indicator As Boolean                            'Indicates if min one point was put at a new location

        For x As Integer = 0 To PointListArray.Length - 1
            Do While 1
                For i As Integer = 0 To PointListArray(x).Count - 2
                    If PointListArray(x).Item(i).Y > PointListArray(x).Item(i + 1).Y Then
                        Indicator = True
                        BufferPoint.X = PointListArray(x).Item(i).X
                        BufferPoint.Y = PointListArray(x).Item(i).Y
                        BufferPoint.Z = PointListArray(x).Item(i).Z
                        PointListArray(x).Item(i).X = PointListArray(x).Item(i + 1).X
                        PointListArray(x).Item(i).Y = PointListArray(x).Item(i + 1).Y
                        PointListArray(x).Item(i).Z = PointListArray(x).Item(i + 1).Z
                        PointListArray(x).Item(i + 1).X = BufferPoint.X
                        PointListArray(x).Item(i + 1).Y = BufferPoint.Y
                        PointListArray(x).Item(i + 1).Z = BufferPoint.Z
                    End If
                Next
                If Indicator = False Then
                    Exit Do
                Else
                    Indicator = False
                End If
            Loop
        Next

        Return "Ok."
    End Function


    ''' <summary>
    ''' Sorts the double array.
    ''' </summary>
    ''' <param name="DoubleArray">The double array.</param>
    ''' <returns></returns>
    Public Function sortDoubleArray(ByRef DoubleArray() As Double) As String

        Dim Buffer As Double
        Dim Indicator As Boolean                            'Indicates if min one point was put at a new location

        Do While 1
            For i As Integer = 0 To DoubleArray.Length - 2
                If DoubleArray(i) > DoubleArray(i + 1) Then
                    Indicator = True
                    Buffer = DoubleArray(i)
                    DoubleArray(i) = DoubleArray(i + 1)
                    DoubleArray(i + 1) = Buffer
                End If
            Next
            If Indicator = False Then
                Exit Do
            Else
                Indicator = False
            End If
        Loop

        Return "Ok."
    End Function

End Class
