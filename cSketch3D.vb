Option Explicit On
Option Infer Off

Imports System.Collections

Public Class cSketch3D
    Inherits cObjectEntity

    '----- Constructor ----------------------------------------------------

    Public Sub New()

        m_Sketch = New Collection()
        m_Path = New System.Drawing.Drawing2D.GraphicsPath()
        m_UpperLeftPoint = New cPoint()
        m_LowerRightPoint = New cPoint()

        '----- Initializations -----

        IsActive = False
        SketchName = ""

    End Sub

    Public Sub New(SketchNumber As Integer)
        Me.New()
        Me.SketchNumber = SketchNumber
    End Sub


    '----- Begin member variables and constants -----------------------------------------------

    Private m_SketchNumber As Integer
    Private m_SketchName As String
    Private m_IsActive As Boolean
    Private m_Sketch As Collection
    Private m_Path As System.Drawing.Drawing2D.GraphicsPath
    Private m_UpperLeftPoint As cPoint
    Private m_LowerRightPoint As cPoint

    '----- Get and set properties -----

    Public Property SketchNumber() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_SketchNumber
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_SketchNumber = Value
        End Set
    End Property

    Public Property SketchName() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_SketchName
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_SketchName = Value
        End Set
    End Property

    Public Property IsActive() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_IsActive
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_IsActive = Value
        End Set
    End Property

    Public Property Sketch() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Sketch
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_Sketch = Value
        End Set
    End Property

    Public Property Path() As System.Drawing.Drawing2D.GraphicsPath
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Path
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As System.Drawing.Drawing2D.GraphicsPath)
            m_Path = Value
        End Set
    End Property

    Public Property UpperLeftPoint() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_UpperLeftPoint
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_UpperLeftPoint = Value
        End Set
    End Property

    Public Property LowerRightPoint() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_LowerRightPoint
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_LowerRightPoint = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----

    Public Function fun_ReorganizePath() As Boolean
        Dim i As Integer
        Path.Reset()
        For i = 1 To Sketch.Count
            Select Case Sketch.Item(i).GetType
                Case GetType(cLine)
                    Path.StartFigure()
                    Path.AddLine(CSng(Sketch.Item(i).m_X1), CSng(Sketch.Item(i).m_Y1), CSng(Sketch.Item(i).m_X2), CSng(Sketch.Item(i).m_Y2))
                    Path.CloseFigure()
                Case GetType(cArc)
                    Path.StartFigure()
                    Path.AddArc(CSng(Sketch.Item(i).m_XC) - CSng(Sketch.Item(i).Radius), CSng(Sketch.Item(i).m_YC) - CSng(Sketch.Item(i).Radius), CSng(Sketch.Item(i).Radius) * 2, CSng(Sketch.Item(i).Radius) * 2, CSng(Sketch.Item(i).StartAngle), CSng(Sketch.Item(i).EndAngle) - CSng(Sketch.Item(i).StartAngle))
                    Path.CloseFigure()
                Case GetType(cCircle)
                    Path.StartFigure()
                    Path.AddArc(CSng(Sketch.Item(i).m_XC) - CSng(Sketch.Item(i).Radius), CSng(Sketch.Item(i).m_YC) - CSng(Sketch.Item(i).Radius), CSng(Sketch.Item(i).Radius) * 2, CSng(Sketch.Item(i).Radius) * 2, 0, 360)
                    Path.CloseFigure()
            End Select
        Next
        Return False
    End Function

    Public Function addElement(Element As cCADObject) As String

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose:  Adds an element to this sketch and sets the "NameOfEntity" and "TypeOfEntity
        '           property.
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim k As Integer
        Dim ElementKey As String

        '----- Begin initial settings -----

        k = 0
        ElementKey = ""

        '----- End initial settings -----

        Select Case Element.GetType()
            Case GetType(cLine)
                Do
                    k += 1
                Loop Until (Sketch.Contains("Line" + CStr(k)) = False)
                Sketch.Add(Element, "Line" + CStr(k))
                Sketch.Item(Sketch.Count).SketchName = NameOfEntity
                Sketch.Item(Sketch.Count).NameOfEntity = "Line" + CStr(k)
                Sketch.Item(Sketch.Count).TypeOfEntity = "Line"
                ElementKey = "Line" + CStr(k)

            Case GetType(cCircle)
                Do
                    k += 1
                Loop Until (Sketch.Contains("Circle" + CStr(k)) = False)
                Sketch.Add(Element, "Circle" + CStr(k))
                Sketch.Item(Sketch.Count).SketchName = NameOfEntity
                Sketch.Item(Sketch.Count).NameOfEntity = "Circle" + CStr(k)
                Sketch.Item(Sketch.Count).TypeOfEntity = "Circle"
                ElementKey = "Circle" + CStr(k)

            Case GetType(cArc)
                Do
                    k += 1
                Loop Until (Sketch.Contains("Arc" + CStr(k)) = False)
                Sketch.Add(Element, "Arc" + CStr(k))
                Sketch.Item(Sketch.Count).SketchName = NameOfEntity
                Sketch.Item(Sketch.Count).NameOfEntity = "Arc" + CStr(k)
                Sketch.Item(Sketch.Count).TypeOfEntity = "Arc"
                ElementKey = "Arc" + CStr(k)

            Case GetType(cPoint)
                Do
                    k += 1
                Loop Until (Sketch.Contains("Point" + CStr(k)) = False)
                Sketch.Add(Element, "Point" + CStr(k))
                Sketch.Item(Sketch.Count).SketchName = NameOfEntity
                Sketch.Item(Sketch.Count).NameOfEntity = "Point" + CStr(k)
                Sketch.Item(Sketch.Count).TypeOfEntity = "Point"
                ElementKey = "Point" + CStr(k)

            Case GetType(cPointarray)
                Do
                    k += 1
                Loop Until (Sketch.Contains("PointArray" + CStr(k)) = False)
                Sketch.Add(Element, "PointArray" + CStr(k))
                Sketch.Item(Sketch.Count).SketchName = NameOfEntity
                Sketch.Item(Sketch.Count).NameOfEntity = "PointArray" + CStr(k)
                Sketch.Item(Sketch.Count).TypeOfEntity = "PointArray"
                ElementKey = "PointArray" + CStr(k)

        End Select
        getSketchSize()
        Return ElementKey
    End Function

    Public Function removeElementFromSketch(ElementKey As String) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose:  Removes an element to this sketch and sets the "NameOfEntity" and "TypeOfEntity
        '           property.
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Try
            Sketch.Remove(ElementKey)
            Return True
        Catch e As KeyNotFoundException
        End Try
        getSketchSize()
        Return False
    End Function

    Public Function checkLastElement() As Boolean

        Select Case Sketch.Item(Sketch.Count).GetType()
            Case GetType(cLine)
                If Sketch.Item(Sketch.Count).m_X1 = Sketch.Item(Sketch.Count).m_X2 And _
                    Sketch.Item(Sketch.Count).m_Y1 = Sketch.Item(Sketch.Count).m_Y2 And _
                    Sketch.Item(Sketch.Count).m_Z1 = Sketch.Item(Sketch.Count).m_Z2 Then
                    Sketch.Remove(Sketch.Count)
                    Return False
                End If
            Case GetType(cCircle)
                If Sketch.Item(Sketch.Count).Radius = 0 Then
                    Sketch.Remove(Sketch.Count)
                    Return False
                End If

        End Select
        Return True
    End Function

    Private Function getSketchSize() As Boolean

        Try
            Select Case Sketch.Item(1).GetType
                Case GetType(cLine)
                    If Sketch.Item(1).m_X1 < Sketch.Item(1).m_X2 Then
                        UpperLeftPoint.X = Sketch.Item(1).m_X1
                        LowerRightPoint.X = Sketch.Item(1).m_X2
                    Else
                        UpperLeftPoint.X = Sketch.Item(1).m_X2
                        LowerRightPoint.X = Sketch.Item(1).m_X1
                    End If
                    If Sketch.Item(1).m_Y1 < Sketch.Item(1).m_Y2 Then
                        UpperLeftPoint.Y = Sketch.Item(1).m_Y1
                        LowerRightPoint.Y = Sketch.Item(1).m_Y2
                    Else
                        UpperLeftPoint.Y = Sketch.Item(1).m_Y2
                        LowerRightPoint.Y = Sketch.Item(1).m_Y1
                    End If
                Case GetType(cArc), GetType(cCircle)
                    UpperLeftPoint.X = Sketch.Item(1).m_XC - Sketch.Item(1).Radius
                    LowerRightPoint.X = Sketch.Item(1).m_XC + Sketch.Item(1).Radius
                    UpperLeftPoint.Y = Sketch.Item(1).m_YC - Sketch.Item(1).Radius
                    LowerRightPoint.Y = Sketch.Item(1).m_YC + Sketch.Item(1).Radius
            End Select


            For i As Integer = 2 To Sketch.Count
                Select Case Sketch.Item(i).GetType
                    Case GetType(cLine)
                        If Sketch.Item(i).m_X1 < Sketch.Item(i).m_X2 Then
                            If Sketch.Item(i).m_X1 < UpperLeftPoint.X Then
                                UpperLeftPoint.X = Sketch.Item(i).m_X1
                            End If
                            If Sketch.Item(i).m_X2 > LowerRightPoint.X Then
                                LowerRightPoint.X = Sketch.Item(i).m_X2
                            End If
                        Else
                            If Sketch.Item(i).m_X2 < UpperLeftPoint.X Then
                                UpperLeftPoint.X = Sketch.Item(i).m_X2
                            End If
                            If Sketch.Item(i).m_X1 > LowerRightPoint.X Then
                                LowerRightPoint.X = Sketch.Item(i).m_X1
                            End If
                        End If
                        If Sketch.Item(i).m_Y1 < Sketch.Item(i).m_Y2 Then
                            If Sketch.Item(i).m_Y1 < UpperLeftPoint.Y Then
                                UpperLeftPoint.Y = Sketch.Item(i).m_Y1
                            End If
                            If Sketch.Item(i).m_Y2 > LowerRightPoint.Y Then
                                LowerRightPoint.Y = Sketch.Item(i).m_Y2
                            End If
                        Else
                            If Sketch.Item(i).m_Y2 < UpperLeftPoint.Y Then
                                UpperLeftPoint.Y = Sketch.Item(i).m_Y2
                            End If
                            If Sketch.Item(i).m_Y1 > LowerRightPoint.Y Then
                                LowerRightPoint.Y = Sketch.Item(i).m_Y1
                            End If
                        End If
                    Case GetType(cArc), GetType(cCircle)
                        If (Sketch.Item(i).m_XC - Sketch.Item(i).Radius) < UpperLeftPoint.X Then
                            UpperLeftPoint.X = Sketch.Item(i).m_XC - Sketch.Item(i).Radius
                        End If
                        If (Sketch.Item(i).m_XC + Sketch.Item(i).Radius) > LowerRightPoint.X Then
                            LowerRightPoint.X = Sketch.Item(i).m_XC + Sketch.Item(i).Radius
                        End If
                        If (Sketch.Item(i).m_YC - Sketch.Item(i).Radius) < UpperLeftPoint.Y Then
                            UpperLeftPoint.Y = Sketch.Item(i).m_YC - Sketch.Item(i).Radius
                        End If
                        If (Sketch.Item(i).m_YC + Sketch.Item(i).Radius) > LowerRightPoint.Y Then
                            LowerRightPoint.Y = Sketch.Item(i).m_YC + Sketch.Item(i).Radius
                        End If
                End Select
            Next
        Catch e As System.IndexOutOfRangeException

            Return False

        End Try

        Return True
    End Function

End Class
