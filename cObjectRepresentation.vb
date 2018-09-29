Option Explicit On
Option Infer Off

Public Class cObjectRepresentation

    '----- Constructor ----------------------------------------------------

    Public Sub New(ByRef GeoManager As cOTGeometricRepresentationManager)

        m_Objects = New Collection()
        m_Utilities = New cOdarTecUtilities()
        m_GeoManager = GeoManager

        '-----Initial settings -----

        Objects.Add(New cPoint, "point 1") 'Add the origin as the first element
        Objects.Item(Objects.Count).NameOfEntity = "Ursprung"
        Objects.Item(Objects.Count).X = 0
        Objects.Item(Objects.Count).Y = 0
        Objects.Item(Objects.Count).Z = 0
        Objects.Item(Objects.Count).IsHeighlighted = False

        '--------------------------------------------------------------------------------
    End Sub


    '----- Begin member variables and constants -----------------------------------------------

    Private m_Objects As Collection
    Private m_LineCount As Integer
    Private m_ArcCount As Integer
    Private m_CircleCount As Integer
    Private m_SketchCount As Integer
    Private m_CamPathCount As Integer
    Private m_Utilities As cOdarTecUtilities
    Public m_GeoManager As cOTGeometricRepresentationManager

    '----- Get and set properties -----

    Public Property Objects() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Objects
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_Objects = Value
        End Set
    End Property

    Public Property LineCount() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_LineCount
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_LineCount = Value
        End Set
    End Property


    Public Property ArcCount() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ArcCount
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_ArcCount = Value
        End Set
    End Property


    Public Property CircleCount() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CircleCount
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_CircleCount = Value
        End Set
    End Property


    Public Property SketchCount() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_SketchCount
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_SketchCount = Value
        End Set
    End Property

    Public Property CamPathCount() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CamPathCount
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_CamPathCount = Value
        End Set
    End Property

    Public Property Utilities() As cOdarTecUtilities
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Utilities
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cOdarTecUtilities)
            m_Utilities = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----------------------------------------------


    Public Sub sub_ShowMe(ByRef e As PaintEventArgs, ByRef TreeViewCad As TreeView, ByRef TreeViewCam As TreeView, ByRef ContextMenu As ContextMenuStrip, ByRef GM As cOTGeometricRepresentationManager)

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

        Dim j As Integer
        Dim myPen As New Pen(Brushes.Black)
        Dim myColor As Color

        '----- Initial settings -----

        ContextMenu.Items.Item("SkizzeToolStripMenuItem").Enabled = True

        '----------------------------

        If TreeViewCad.Nodes.ContainsKey("Ursprung") = False And Objects.Item(1).NameOfEntity = "Ursprung" Then
            TreeViewCad.Nodes.Add(Objects.Item(1).NameOfEntity, Objects.Item(1).NameOfEntity)
            TreeViewCad.Nodes.Item(0).ImageIndex = 4
        End If

        For i As Integer = 1 To Objects.Count

            '---2D-Sketch---

            If Objects.Item(i).GetType = GetType(cSketch) Then
                myPen.Width = 2
                myPen.EndCap = Drawing2D.LineCap.Round
                myPen.Alignment = Drawing2D.PenAlignment.Center
                If Objects.Item(i).StateOfEntity <> 2 Then
                    If Objects.Item(i).Sketch.Count > 0 Then
                        For j = 1 To Objects.Item(i).Sketch.Count
                            myPen.Color = Color.Navy
                            If Objects.Item(i).Sketch.Item(j).IsSelected = True Then
                                myPen.Color = Color.White
                            End If
                            If Objects.Item(i).Sketch.Item(j).IsHeighlighted = True Then
                                Objects.Item(i).Sketch.Item(j).IsHeighlighted = False
                                myPen.Color = Color.Gold
                            End If
                            If Objects.Item(i).Sketch.Item(j).GetType = GetType(cLine) Then
                                e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_X1, Objects.Item(i).Sketch.Item(j).m_Y1, Objects.Item(i).Sketch.Item(j).m_Z1)(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_X1, Objects.Item(i).Sketch.Item(j).m_Y1, Objects.Item(i).Sketch.Item(j).m_Z1)(1)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_X2, Objects.Item(i).Sketch.Item(j).m_Y2, Objects.Item(i).Sketch.Item(j).m_Z2)(0) + 1), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_X2, Objects.Item(i).Sketch.Item(j).m_Y2, Objects.Item(i).Sketch.Item(j).m_Z2)(1)))
                            End If

                            If Objects.Item(i).Sketch.Item(j).GetType = GetType(cPoint) Then
                                'myColor = Color.FromArgb(Objects.Item(i).Sketch.Item(j).ObjectRGBColor(0), Objects.Item(i).Sketch.Item(j).ObjectRGBColor(1), Objects.Item(i).Sketch.Item(j).ObjectRGBColor(2))
                                'myPen.Color = myColor
                                'e.Graphics.FillRectangle(New SolidBrush(myColor), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).X, Objects.Item(i).Sketch.Item(j).Y, Objects.Item(i).Sketch.Item(j).Z)(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).X, Objects.Item(i).Sketch.Item(j).Y, Objects.Item(i).Sketch.Item(j).Z)(1)), 1, 1)
                                'e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LU", 2 / GM.ZoomFactor))(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LU", 2 / GM.ZoomFactor)).Y), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RD", 2 / GM.ZoomFactor)).X), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RD", 2 / GM.ZoomFactor)).Y))
                                'e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LD", 2 / GM.ZoomFactor)).X), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LD", 2 / GM.ZoomFactor)).Y), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RU", 2 / GM.ZoomFactor)).X), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RU", 2 / GM.ZoomFactor)).Y))
                                'e.Graphics.DrawBezier(myPen, new point(CInt(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LU", 10 )).X),CInt(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LU", 10)).Y))), new point(CInt(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RU",10)).X),cint(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RU", 10)).Y))),new point(CInt(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RD",10)).X), cint(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RD", 10)).Y))),new point(Cint(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LD",10)).X),Cint(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LD", 10)).Y))))
                                e.Graphics.DrawArc(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_X, Objects.Item(i).Sketch.Item(j).m_Y, Objects.Item(i).Sketch.Item(j).m_Z)(0) - 1), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_X, Objects.Item(i).Sketch.Item(j).m_Y, Objects.Item(i).Sketch.Item(j).m_Z)(1) + 1), 3, 3, 0, 360)
                            End If
                            If Objects.Item(i).Sketch.Item(j).GetType = GetType(cArc) Then
                                If Objects.Item(i).Sketch.Item(j).EndAngle > Objects.Item(i).Sketch.Item(j).StartAngle Then



                                    e.Graphics.DrawArc(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Z)(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Z)(1)), CSng(Math.Abs(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").Z)(0) - GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Z)(0))), CSng(Math.Abs(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").Z)(1) - GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Z)(1))), CSng(Objects.Item(i).Sketch.Item(j).StartAngle), CSng(Objects.Item(i).Sketch.Item(j).EndAngle - Objects.Item(i).Sketch.Item(j).StartAngle))
                                Else
                                    e.Graphics.DrawArc(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Z)(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Z)(1)), CSng(Math.Abs(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").Z)(0) - GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Z)(0))), CSng(Math.Abs(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").Z)(1) - GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Z)(1))), CSng(Objects.Item(i).Sketch.Item(j).StartAngle), 360 + CSng(Objects.Item(i).Sketch.Item(j).EndAngle - Objects.Item(i).Sketch.Item(j).StartAngle))
                                End If




                            End If
                            If Objects.Item(i).Sketch.Item(j).GetType = GetType(cCircle) Then
                                Dim myPoints(3) As Point

                                For ii As Integer = 0 To myPoints.Length - 1
                                    myPoints(ii) = New Point(CInt(GM.tP(Objects.Item(i).Sketch.Item(j).getSplineRepresentationPoints(ii).X, Objects.Item(i).Sketch.Item(j).getSplineRepresentationPoints(ii).Y, Objects.Item(i).Sketch.Item(j).getSplineRepresentationPoints(ii).Z)(0)), CInt(GM.tP(Objects.Item(i).Sketch.Item(j).getSplineRepresentationPoints(ii).X, Objects.Item(i).Sketch.Item(j).getSplineRepresentationPoints(ii).Y, Objects.Item(i).Sketch.Item(j).getSplineRepresentationPoints(ii).Z)(1)))
                                Next
                                e.Graphics.DrawClosedCurve(myPen, myPoints, 0.8, Drawing2D.FillMode.Alternate)

                                'e.Graphics.DrawArc(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Z)(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Z)(1)), CSng(Math.Abs(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").Z)(0) - GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Z)(0))), CSng(Math.Abs(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").Z)(1) - GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Z)(1))), 0, 360)
                            End If
                        Next
                    End If
                End If
                If TreeViewCad.Nodes.ContainsKey("Skizze" + CStr(Objects.Item(i).SketchNumber)) = False Then
                    TreeViewCad.Nodes.Add("Skizze" & Objects.Item(i).SketchNumber, "Skizze" & Objects.Item(i).SketchNumber)
                End If
                Select Case (Objects.Item(i).StateOfEntity)
                    Case 0
                        TreeViewCad.Nodes.Item("Skizze" + CStr(Objects.Item(i).SketchNumber)).ImageIndex = 5
                    Case 1
                        TreeViewCad.Nodes.Item("Skizze" + CStr(Objects.Item(i).SketchNumber)).ImageIndex = 6
                        ContextMenu.Items.Item("SkizzeToolStripMenuItem").Enabled = False
                    Case 2
                        TreeViewCad.Nodes.Item("Skizze" + CStr(Objects.Item(i).SketchNumber)).ImageIndex = 7
                    Case Else
                End Select
            End If

            '--- 3D-Sketch ---

            If Objects.Item(i).GetType = GetType(cSketch3D) Then
                myPen.Width = 2
                myPen.EndCap = Drawing2D.LineCap.Round
                myPen.Alignment = Drawing2D.PenAlignment.Center
                If Objects.Item(i).StateOfEntity <> 2 Then
                    If Objects.Item(i).Sketch.Count > 0 Then
                        For j = 1 To Objects.Item(i).Sketch.Count
                            myPen.Color = Color.Navy
                            If Objects.Item(i).Sketch.Item(j).IsSelected = True Then
                                myPen.Color = Color.White
                            End If
                            If Objects.Item(i).Sketch.Item(j).IsHeighlighted = True Then
                                Objects.Item(i).Sketch.Item(j).IsHeighlighted = False
                                myPen.Color = Color.Gold
                            End If
                            If Objects.Item(i).Sketch.Item(j).GetType = GetType(cLine) Then
                                e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_X1, Objects.Item(i).Sketch.Item(j).m_Y1, Objects.Item(i).Sketch.Item(j).m_Z1)(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_X1, Objects.Item(i).Sketch.Item(j).m_Y1, Objects.Item(i).Sketch.Item(j).m_Z1)(1)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_X2, Objects.Item(i).Sketch.Item(j).m_Y2, Objects.Item(i).Sketch.Item(j).m_Z2)(0) + 1), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_X2, Objects.Item(i).Sketch.Item(j).m_Y2, Objects.Item(i).Sketch.Item(j).m_Z2)(1)))
                            End If

                            If Objects.Item(i).Sketch.Item(j).GetType = GetType(cPoint) Then
                                'myColor = Color.FromArgb(Objects.Item(i).Sketch.Item(j).ObjectRGBColor(0), Objects.Item(i).Sketch.Item(j).ObjectRGBColor(1), Objects.Item(i).Sketch.Item(j).ObjectRGBColor(2))
                                'myPen.Color = myColor
                                'e.Graphics.FillRectangle(New SolidBrush(myColor), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).X, Objects.Item(i).Sketch.Item(j).Y, Objects.Item(i).Sketch.Item(j).Z)(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).X, Objects.Item(i).Sketch.Item(j).Y, Objects.Item(i).Sketch.Item(j).Z)(1)), 1, 1)
                                'e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LU", 2 / GM.ZoomFactor))(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LU", 2 / GM.ZoomFactor)).Y), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RD", 2 / GM.ZoomFactor)).X), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RD", 2 / GM.ZoomFactor)).Y))
                                'e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LD", 2 / GM.ZoomFactor)).X), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LD", 2 / GM.ZoomFactor)).Y), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RU", 2 / GM.ZoomFactor)).X), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RU", 2 / GM.ZoomFactor)).Y))
                                'e.Graphics.DrawBezier(myPen, new point(CInt(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LU", 10 )).X),CInt(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LU", 10)).Y))), new point(CInt(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RU",10)).X),cint(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RU", 10)).Y))),new point(CInt(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RD",10)).X), cint(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("RD", 10)).Y))),new point(Cint(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LD",10)).X),Cint(GM.tP(Objects.Item(i).Sketch.Item(j).gLRP("LD", 10)).Y))))
                                e.Graphics.DrawArc(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_X, Objects.Item(i).Sketch.Item(j).m_Y, Objects.Item(i).Sketch.Item(j).m_Z)(0) - 1), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_X, Objects.Item(i).Sketch.Item(j).m_Y, Objects.Item(i).Sketch.Item(j).m_Z)(1) + 1), 3, 3, 0, 360)
                            End If
                            If Objects.Item(i).Sketch.Item(j).GetType = GetType(cPointArray) Then

                                For z As Integer = 0 To Objects.Item(i).Sketch.Item(j).m_PointArray.length - 1 Step 3
                                    Dim myPoints(2) As PointF
                                    myPoints(0) = New PointF(CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_X, Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_Y, Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_Z)(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_X, Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_Y, Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_Z)(1)))
                                    myPoints(1) = New PointF(CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_PointArray(z + 1).m_X, Objects.Item(i).Sketch.Item(j).m_PointArray(z + 1).m_Y, Objects.Item(i).Sketch.Item(j).m_PointArray(z + 1).m_Z)(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_PointArray(z + 1).m_X, Objects.Item(i).Sketch.Item(j).m_PointArray(z + 1).m_Y, Objects.Item(i).Sketch.Item(j).m_PointArray(z + 1).m_Z)(1)))
                                    myPoints(2) = New PointF(CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_PointArray(z + 2).m_X, Objects.Item(i).Sketch.Item(j).m_PointArray(z + 2).m_Y, Objects.Item(i).Sketch.Item(j).m_PointArray(z + 2).m_Z)(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_PointArray(z + 2).m_X, Objects.Item(i).Sketch.Item(j).m_PointArray(z + 2).m_Y, Objects.Item(i).Sketch.Item(j).m_PointArray(z + 2).m_Z)(1)))

                                    'myColor = Color.FromArgb(Objects.Item(i).Sketch.Item(j).ObjectRGBColor(0), Objects.Item(i).Sketch.Item(j).ObjectRGBColor(1), Objects.Item(i).Sketch.Item(j).ObjectRGBColor(2))
                                    'myPen.Color = myColor

                                    e.Graphics.DrawPolygon(myPen, myPoints)
                                    'e.Graphics.DrawClosedCurve(myPen, myPoints)


                                    'e.Graphics.DrawArc(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_X, Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_Y, Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_Z)(0) - 1), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_X, Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_Y, Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_Z)(1) + 1), 3, 3, 0, 360)
                                Next
                            End If
                            If Objects.Item(i).Sketch.Item(j).GetType = GetType(cArc) Then
                                If Objects.Item(i).Sketch.Item(j).EndAngle > Objects.Item(i).Sketch.Item(j).StartAngle Then
                                    e.Graphics.DrawArc(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Z)(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Z)(1)), CSng(Math.Abs(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").Z)(0) - GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Z)(0))), CSng(Math.Abs(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").Z)(1) - GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Z)(1))), CSng(Objects.Item(i).Sketch.Item(j).StartAngle), CSng(Objects.Item(i).Sketch.Item(j).EndAngle - Objects.Item(i).Sketch.Item(j).StartAngle))
                                Else
                                    e.Graphics.DrawArc(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Z)(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Z)(1)), CSng(Math.Abs(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").Z)(0) - GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Z)(0))), CSng(Math.Abs(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").Z)(1) - GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Z)(1))), CSng(Objects.Item(i).Sketch.Item(j).StartAngle), 360 + CSng(Objects.Item(i).Sketch.Item(j).EndAngle - Objects.Item(i).Sketch.Item(j).StartAngle))
                                End If
                            End If
                            If Objects.Item(i).Sketch.Item(j).GetType = GetType(cCircle) Then
                                e.Graphics.DrawArc(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Z)(0)), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Z)(1)), CSng(Math.Abs(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X").Z)(0) - GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X").Z)(0))), CSng(Math.Abs(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y").Z)(1) - GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").X, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Y, Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y").Z)(1))), 0, 360)
                                'e.Graphics.DrawArc(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X")).X), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y")).Y), CSng(Math.Abs(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("X")).X - GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("X")).X)), CSng(Math.Abs(GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointPlusRadius("Y")).Y - GM.tP(Objects.Item(i).Sketch.Item(j).getCenterPointMinusRadius("Y")).Y)), 0, 360)
                            End If
                        Next
                    End If
                End If
                If TreeViewCad.Nodes.ContainsKey("3D-Skizze" + CStr(Objects.Item(i).SketchNumber)) = False Then
                    TreeViewCad.Nodes.Add("3D-Skizze" & Objects.Item(i).SketchNumber, "3D-Skizze" & Objects.Item(i).SketchNumber)
                End If
                Select Case (Objects.Item(i).StateOfEntity)
                    Case 0
                        TreeViewCad.Nodes.Item("3D-Skizze" + CStr(Objects.Item(i).SketchNumber)).ImageIndex = 5
                    Case 1
                        TreeViewCad.Nodes.Item("3D-Skizze" + CStr(Objects.Item(i).SketchNumber)).ImageIndex = 6
                        ContextMenu.Items.Item("SkizzeToolStripMenuItem").Enabled = False
                    Case 2
                        TreeViewCad.Nodes.Item("3D-Skizze" + CStr(Objects.Item(i).SketchNumber)).ImageIndex = 7
                    Case Else
                End Select
            End If

            '--- Imported ---

            If Objects.Item(i).GetType = GetType(cImported) Then
                myPen.Width = 2
                myPen.EndCap = Drawing2D.LineCap.Round
                myPen.Alignment = Drawing2D.PenAlignment.Center
                If Objects.Item(i).StateOfEntity <> 2 Then
                    If Objects.Item(i).Imported.Count > 0 Then
                        For j = 1 To Objects.Item(i).Imported.Count
                            myPen.Color = Color.Navy
                            If Objects.Item(i).Imported.Item(j).IsSelected = True Then
                                myPen.Color = Color.White
                            End If
                            If Objects.Item(i).Imported.Item(j).IsHeighlighted = True Then
                                Objects.Item(i).Imported.Item(j).IsHeighlighted = False
                                myPen.Color = Color.Gold
                            End If

                            If Objects.Item(i).Imported.Item(j).GetType = GetType(cPointArray) Then

                                For z As Integer = 0 To Objects.Item(i).Imported.Item(j).m_PointArray.length - 3 Step 3
                                    Dim myPoints(2) As PointF
                                    myPoints(0) = New PointF(CSng(GM.tP(Objects.Item(i).Imported.Item(j).m_PointArray(z).m_X, Objects.Item(i).Imported.Item(j).m_PointArray(z).m_Y, Objects.Item(i).Imported.Item(j).m_PointArray(z).m_Z)(0)), CSng(GM.tP(Objects.Item(i).Imported.Item(j).m_PointArray(z).m_X, Objects.Item(i).Imported.Item(j).m_PointArray(z).m_Y, Objects.Item(i).Imported.Item(j).m_PointArray(z).m_Z)(1)))
                                    myPoints(1) = New PointF(CSng(GM.tP(Objects.Item(i).Imported.Item(j).m_PointArray(z + 1).m_X, Objects.Item(i).Imported.Item(j).m_PointArray(z + 1).m_Y, Objects.Item(i).Imported.Item(j).m_PointArray(z + 1).m_Z)(0)), CSng(GM.tP(Objects.Item(i).Imported.Item(j).m_PointArray(z + 1).m_X, Objects.Item(i).Imported.Item(j).m_PointArray(z + 1).m_Y, Objects.Item(i).Imported.Item(j).m_PointArray(z + 1).m_Z)(1)))
                                    myPoints(2) = New PointF(CSng(GM.tP(Objects.Item(i).Imported.Item(j).m_PointArray(z + 2).m_X, Objects.Item(i).Imported.Item(j).m_PointArray(z + 2).m_Y, Objects.Item(i).Imported.Item(j).m_PointArray(z + 2).m_Z)(0)), CSng(GM.tP(Objects.Item(i).Imported.Item(j).m_PointArray(z + 2).m_X, Objects.Item(i).Imported.Item(j).m_PointArray(z + 2).m_Y, Objects.Item(i).Imported.Item(j).m_PointArray(z + 2).m_Z)(1)))

                                    'myColor = Color.FromArgb(Objects.Item(i).Sketch.Item(j).ObjectRGBColor(0), Objects.Item(i).Sketch.Item(j).ObjectRGBColor(1), Objects.Item(i).Sketch.Item(j).ObjectRGBColor(2))
                                    'myPen.Color = myColor
                                    'e.Graphics.DrawLine(myPen, 0, 0, CInt(Objects.Item(i).Imported.Item(j).m_PointArray(z).m_X), CInt(Objects.Item(i).Imported.Item(j).m_PointArray(z).m_Y))
                                    e.Graphics.DrawPolygon(myPen, myPoints)
                                    'Console.WriteLine(Objects.Item(i).Imported.Item(j).m_PointArray(z).m_X)
                                    'e.Graphics.FillClosedCurve(Brushes.Beige, myPoints, Drawing2D.FillMode.Alternate, 0)
                                    'e.Graphics.DrawClosedCurve(myPen, myPoints)


                                    'e.Graphics.DrawArc(myPen, CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_X, Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_Y, Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_Z)(0) - 1), CSng(GM.tP(Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_X, Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_Y, Objects.Item(i).Sketch.Item(j).m_PointArray(z).m_Z)(1) + 1), 3, 3, 0, 360)
                                Next
                            End If
                        Next
                    End If
                End If
                If TreeViewCad.Nodes.ContainsKey("Imported" + CStr(Objects.Item(i).Number)) = False Then
                    TreeViewCad.Nodes.Add("Imported" & Objects.Item(i).Number, "Imported" & Objects.Item(i).Number)
                End If
                Select Case (Objects.Item(i).StateOfEntity)
                    Case 0
                        TreeViewCad.Nodes.Item("Imported" + CStr(Objects.Item(i).Number)).ImageIndex = 8 ' Not active but visible
                    Case 1
                        TreeViewCad.Nodes.Item("Imported" + CStr(Objects.Item(i).Number)).ImageIndex = 8 ' Imported is active
                        ContextMenu.Items.Item("SkizzeToolStripMenuItem").Enabled = False
                    Case 2
                        TreeViewCad.Nodes.Item("Imported" + CStr(Objects.Item(i).Number)).ImageIndex = 9 ' Non visible
                    Case Else
                End Select
            End If

            '--- cCamPath ---

            If Objects.Item(i).GetType = GetType(cCamPath) Then
                myPen.Width = 1
                myPen.EndCap = Drawing2D.LineCap.Round
                myPen.Alignment = Drawing2D.PenAlignment.Center
                If Objects.Item(i).StateOfEntity <> 2 Then
                    If Objects.Item(i).CamPath.Count > 0 Then
                        For j = 1 To Objects.Item(i).CamPath.Count
                            Select Case Objects.Item(i).CamPath.Item(j).CamDescription
                                Case "Work"
                                    myPen.Color = Color.DarkMagenta
                                Case "Rapid"
                                    myPen.Color = Color.Magenta
                                Case "InfeedGround"
                                    myPen.Color = Color.MediumVioletRed
                            End Select
                            If Objects.Item(i).CamPath.Item(j).IsSelected = True Then
                                myPen.Color = Color.White
                            End If
                            If Objects.Item(i).CamPath.Item(j).IsHeighlighted = True Then
                                Objects.Item(i).CamPath.Item(j).IsHeighlighted = False
                                myPen.Color = Color.Orange
                            End If
                            If Objects.Item(i).CamPath.Item(j).GetType = GetType(cLine) Then
                                e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).CamPath.Item(j).m_X1, Objects.Item(i).CamPath.Item(j).m_Y1, Objects.Item(i).CamPath.Item(j).m_Z1)(0)), CSng(GM.tP(Objects.Item(i).CamPath.Item(j).m_X1, Objects.Item(i).CamPath.Item(j).m_Y1, Objects.Item(i).CamPath.Item(j).m_Z1)(1)), CSng(GM.tP(Objects.Item(i).CamPath.Item(j).m_X2, Objects.Item(i).CamPath.Item(j).m_Y2, Objects.Item(i).CamPath.Item(j).m_Z2)(0)), CSng(GM.tP(Objects.Item(i).CamPath.Item(j).m_X2, Objects.Item(i).CamPath.Item(j).m_Y2, Objects.Item(i).CamPath.Item(j).m_Z2)(1)))
                            End If
                            If Objects.Item(i).CamPath.Item(j).GetType = GetType(cArc) Then
                                If Objects.Item(i).CamPath.Item(j).EndAngle > Objects.Item(i).CamPath.Item(j).StartAngle Then
                                    e.Graphics.DrawArc(myPen, CSng(GM.tPX(Objects.Item(i).CamPath.Item(j).CenterPoint.X - Objects.Item(i).CamPath.Item(j).Radius)), CSng(GM.tPY(Objects.Item(i).CamPath.Item(j).CenterPoint.Y - Objects.Item(i).CamPath.Item(j).Radius)), CSng((Objects.Item(i).CamPath.Item(j).Radius * 2) * GM.ZoomFactor), CSng((Objects.Item(i).CamPath.Item(j).Radius * 2) * GM.ZoomFactor), CSng(Objects.Item(i).CamPath.Item(j).StartAngle), CSng(Objects.Item(i).CamPath.Item(j).EndAngle - Objects.Item(i).CamPath.Item(j).StartAngle))
                                Else
                                    e.Graphics.DrawArc(myPen, CSng(GM.tPX(Objects.Item(i).CamPath.Item(j).CenterPoint.X - Objects.Item(i).CamPath.Item(j).Radius)), CSng(GM.tPY(Objects.Item(i).CamPath.Item(j).CenterPoint.Y - Objects.Item(i).CamPath.Item(j).Radius)), CSng((Objects.Item(i).CamPath.Item(j).Radius * 2) * GM.ZoomFactor), CSng((Objects.Item(i).CamPath.Item(j).Radius * 2) * GM.ZoomFactor), CSng(Objects.Item(i).CamPath.Item(j).StartAngle), 360 + CSng(Objects.Item(i).CamPath.Item(j).EndAngle - Objects.Item(i).CamPath.Item(j).StartAngle))
                                End If
                            End If
                            If Objects.Item(i).CamPath.Item(j).GetType = GetType(cCircle) Then
                                e.Graphics.DrawArc(myPen, CSng(GM.tPX(Objects.Item(i).CamPath.Item(j).CenterPoint.X - Objects.Item(i).CamPath.Item(j).Radius)), CSng(GM.tPY(Objects.Item(i).CamPath.Item(j).CenterPoint.Y - Objects.Item(i).CamPath.Item(j).Radius)), Math.Abs(CSng(GM.tPX(Objects.Item(i).CamPath.Item(j).CenterPoint.X + Objects.Item(i).CamPath.Item(j).Radius)) - CSng(GM.tPX(Objects.Item(i).CamPath.Item(j).CenterPoint.X - Objects.Item(i).CamPath.Item(j).Radius))), Math.Abs(CSng(GM.tPY(Objects.Item(i).CamPath.Item(j).CenterPoint.Y + Objects.Item(i).CamPath.Item(j).Radius)) - CSng(GM.tPY(Objects.Item(i).CamPath.Item(j).CenterPoint.Y - Objects.Item(i).CamPath.Item(j).Radius))), 0, 360)
                            End If
                        Next
                    End If

                    '----- Highlight choosen path elements -----

                    If Objects.Item(i).CamElements.Count > 0 Then
                        For j = 1 To Objects.Item(i).CamElements.Count
                            myPen.Color = Color.Coral
                            myPen.Width = 2
                            myPen.EndCap = Drawing2D.LineCap.Round
                            myPen.Alignment = Drawing2D.PenAlignment.Center
                            If Objects.Item(i).CamElements.Item(j).GetType = GetType(cLine) Then
                                e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).CamElements.Item(j).m_X1, Objects.Item(i).CamElements.Item(j).m_Y1, Objects.Item(i).CamElements.Item(j).m_Z1)(0)), CSng(GM.tP(Objects.Item(i).CamElements.Item(j).m_X1, Objects.Item(i).CamElements.Item(j).m_Y1, Objects.Item(i).CamElements.Item(j).m_Z1)(1)), CSng(GM.tP(Objects.Item(i).CamElements.Item(j).m_X2, Objects.Item(i).CamElements.Item(j).m_Y2, Objects.Item(i).CamElements.Item(j).m_Z2)(0)), CSng(GM.tP(Objects.Item(i).CamElements.Item(j).m_X2, Objects.Item(i).CamElements.Item(j).m_Y2, Objects.Item(i).CamElements.Item(j).m_Z2)(1)))
                            End If
                            If Objects.Item(i).CamElements.Item(j).GetType = GetType(cArc) Then
                                If Objects.Item(i).CamElements.Item(j).EndAngle > Objects.Item(i).CamElements.Item(j).StartAngle Then
                                    e.Graphics.DrawArc(myPen, CSng(GM.tPX(Objects.Item(i).CamElements.Item(j).CenterPoint.X - Objects.Item(i).CamElements.Item(j).Radius)), CSng(GM.tPY(Objects.Item(i).CamElements.Item(j).CenterPoint.Y - Objects.Item(i).CamElements.Item(j).Radius)), CSng((Objects.Item(i).CamElements.Item(j).Radius * 2) * GM.ZoomFactor), CSng((Objects.Item(i).CamElements.Item(j).Radius * 2) * GM.ZoomFactor), CSng(Objects.Item(i).CamElements.Item(j).StartAngle), CSng(Objects.Item(i).CamElements.Item(j).EndAngle - Objects.Item(i).CamElements.Item(j).StartAngle))
                                Else
                                    e.Graphics.DrawArc(myPen, CSng(GM.tPX(Objects.Item(i).CamElements.Item(j).CenterPoint.X - Objects.Item(i).CamElements.Item(j).Radius)), CSng(GM.tPY(Objects.Item(i).CamElements.Item(j).CenterPoint.Y - Objects.Item(i).CamElements.Item(j).Radius)), CSng((Objects.Item(i).CamElements.Item(j).Radius * 2) * GM.ZoomFactor), CSng((Objects.Item(i).CamElements.Item(j).Radius * 2) * GM.ZoomFactor), CSng(Objects.Item(i).CamElements.Item(j).StartAngle), 360 + CSng(Objects.Item(i).CamElements.Item(j).EndAngle - Objects.Item(i).CamElements.Item(j).StartAngle))
                                End If
                            End If
                            If Objects.Item(i).CamElements.Item(j).GetType = GetType(cCircle) Then
                                e.Graphics.DrawArc(myPen, CSng(GM.tP(Objects.Item(i).CamElements.Item(j).getCenterPointMinusRadius("X").X, Objects.Item(i).CamElements.Item(j).getCenterPointMinusRadius("X").Y, Objects.Item(i).CamElements.Item(j).getCenterPointMinusRadius("X").Z)(0)), CSng(GM.tP(Objects.Item(i).CamElements.Item(j).getCenterPointMinusRadius("Y").X, Objects.Item(i).CamElements.Item(j).getCenterPointMinusRadius("Y").Y, Objects.Item(i).CamElements.Item(j).getCenterPointMinusRadius("Y").Z)(1)), CSng(Math.Abs(GM.tP(Objects.Item(i).CamElements.Item(j).getCenterPointPlusRadius("X").X, Objects.Item(i).CamElements.Item(j).getCenterPointPlusRadius("X").Y, Objects.Item(i).CamElements.Item(j).getCenterPointPlusRadius("X").Z)(0) - GM.tP(Objects.Item(i).CamElements.Item(j).getCenterPointMinusRadius("X").X, Objects.Item(i).CamElements.Item(j).getCenterPointMinusRadius("X").Y, Objects.Item(i).CamElements.Item(j).getCenterPointMinusRadius("X").Z)(0))), CSng(Math.Abs(GM.tP(Objects.Item(i).CamElements.Item(j).getCenterPointPlusRadius("Y").X, Objects.Item(i).CamElements.Item(j).getCenterPointPlusRadius("Y").Y, Objects.Item(i).CamElements.Item(j).getCenterPointPlusRadius("Y").Z)(1) - GM.tP(Objects.Item(i).CamElements.Item(j).getCenterPointMinusRadius("Y").X, Objects.Item(i).CamElements.Item(j).getCenterPointMinusRadius("Y").Y, Objects.Item(i).CamElements.Item(j).getCenterPointMinusRadius("Y").Z)(1))), 0, 360)
                            End If
                        Next
                    End If
                End If

                If TreeViewCam.Nodes.ContainsKey("CAM-Kontur" + CStr(Objects.Item(i).PathNumber)) = False Then
                    TreeViewCam.Nodes.Add("CAM-Kontur" & Objects.Item(i).PathNumber, "CAM-Kontur" & Objects.Item(i).PathNumber)
                End If
                Select Case (Objects.Item(i).StateOfEntity)
                    Case 0
                        TreeViewCam.Nodes.Item("CAM-Kontur" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 5
                    Case 1
                        TreeViewCam.Nodes.Item("CAM-Kontur" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 6
                    Case 2
                        TreeViewCam.Nodes.Item("CAM-Kontur" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 7
                    Case Else
                End Select
            End If

            '--- cCamPocket ---

            If Objects.Item(i).GetType = GetType(cCamPocket) Then
                myPen.Width = 1
                myPen.EndCap = Drawing2D.LineCap.Round
                myPen.Alignment = Drawing2D.PenAlignment.Center
                Dim points(3) As Point
                If Objects.Item(i).m_CamPreview.Count > 0 Then
                    If Objects.Item(i).StateOfEntity <> 2 Then
                        For j = 1 To Objects.Item(i).m_CamPreview.Count

                            Select Case Objects.Item(i).m_CamPreview.Item(j).CamDescription
                                Case "Work"
                                    myPen.Color = Color.DarkMagenta
                                Case "Rapid"
                                    myPen.Color = Color.Magenta
                                Case "InfeedGround"
                                    myPen.Color = Color.MediumVioletRed
                            End Select
                            If Objects.Item(i).m_CamPreview.Item(j).GetType = GetType(cLine) Then
                                e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).m_CamPreview.Item(j).m_X1, Objects.Item(i).m_CamPreview.Item(j).m_Y1, Objects.Item(i).m_CamPreview.Item(j).m_Z1)(0)), CSng(GM.tP(Objects.Item(i).m_CamPreview.Item(j).m_X1, Objects.Item(i).m_CamPreview.Item(j).m_Y1, Objects.Item(i).m_CamPreview.Item(j).m_Z1)(1)), CSng(GM.tP(Objects.Item(i).m_CamPreview.Item(j).m_X2, Objects.Item(i).m_CamPreview.Item(j).m_Y2, Objects.Item(i).m_CamPreview.Item(j).m_Z2)(0)), CSng(GM.tP(Objects.Item(i).m_CamPreview.Item(j).m_X2, Objects.Item(i).m_CamPreview.Item(j).m_Y2, Objects.Item(i).m_CamPreview.Item(j).m_Z2)(1)))
                            End If
                            If Objects.Item(i).m_CamPreview.Item(j).GetType = GetType(cCircle) Then
                                Dim myPoints(3) As Point
                                For ii As Integer = 0 To 3
                                    myPoints(ii) = New Point(CInt(GM.tP(Objects.Item(i).m_CamPreview.Item(j).getSplineRepresentationPoints(ii).X, Objects.Item(i).m_CamPreview.Item(j).getSplineRepresentationPoints(ii).Y, Objects.Item(i).m_CamPreview.Item(j).getSplineRepresentationPoints(ii).Z)(0)), CInt(GM.tP(Objects.Item(i).m_CamPreview.Item(j).getSplineRepresentationPoints(ii).X, Objects.Item(i).m_CamPreview.Item(j).getSplineRepresentationPoints(ii).Y, Objects.Item(i).m_CamPreview.Item(j).getSplineRepresentationPoints(ii).Z)(1)))
                                Next
                                e.Graphics.DrawClosedCurve(myPen, myPoints, 0.8, Drawing2D.FillMode.Alternate)
                            End If
                        Next
                    End If
                    'If Objects.Item(i).StateOfEntity <> 2 Then
                    '    If Objects.Item(i).CamPath.Count > 0 Then
                    '        For j = 1 To Objects.Item(i).CamPath.Count
                    '            Select Case Objects.Item(i).CamPath.Item(j).CamDescription
                    '                Case "Work"
                    '                    myPen.Color = Color.DarkMagenta
                    '                Case "Rapid"
                    '                    myPen.Color = Color.Magenta
                    '                Case "InfeedGround"
                    '                    myPen.Color = Color.MediumVioletRed
                    '            End Select
                    '            If Objects.Item(i).CamPath.Item(j).IsSelected = True Then
                    '                myPen.Color = Color.White
                    '            End If
                    '            If Objects.Item(i).CamPath.Item(j).IsHeighlighted = True Then
                    '                Objects.Item(i).CamPath.Item(j).IsHeighlighted = False
                    '                myPen.Color = Color.Orange
                    '            End If
                    '            If Objects.Item(i).CamPath.Item(j).GetType = GetType(cLine) Then
                    '                e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).CamPath.Item(j).m_X1, Objects.Item(i).CamPath.Item(j).m_Y1, Objects.Item(i).CamPath.Item(j).m_Z1)(0)), CSng(GM.tP(Objects.Item(i).CamPath.Item(j).m_X1, Objects.Item(i).CamPath.Item(j).m_Y1, Objects.Item(i).CamPath.Item(j).m_Z1)(1)), CSng(GM.tP(Objects.Item(i).CamPath.Item(j).m_X2, Objects.Item(i).CamPath.Item(j).m_Y2, Objects.Item(i).CamPath.Item(j).m_Z2)(0)), CSng(GM.tP(Objects.Item(i).CamPath.Item(j).m_X2, Objects.Item(i).CamPath.Item(j).m_Y2, Objects.Item(i).CamPath.Item(j).m_Z2)(1)))
                    '            End If
                    '            If Objects.Item(i).CamPath.Item(j).GetType = GetType(cArc) Then
                    '                If Objects.Item(i).CamPath.Item(j).EndAngle > Objects.Item(i).CamPath.Item(j).StartAngle Then
                    '                    e.Graphics.DrawArc(myPen, CSng(GM.tPX(Objects.Item(i).CamPath.Item(j).CenterPoint.X - Objects.Item(i).CamPath.Item(j).Radius)), CSng(GM.tPY(Objects.Item(i).CamPath.Item(j).CenterPoint.Y - Objects.Item(i).CamPath.Item(j).Radius)), CSng((Objects.Item(i).CamPath.Item(j).Radius * 2) * GM.ZoomFactor), CSng((Objects.Item(i).CamPath.Item(j).Radius * 2) * GM.ZoomFactor), CSng(Objects.Item(i).CamPath.Item(j).StartAngle), CSng(Objects.Item(i).CamPath.Item(j).EndAngle - Objects.Item(i).CamPath.Item(j).StartAngle))
                    '                Else
                    '                    e.Graphics.DrawArc(myPen, CSng(GM.tPX(Objects.Item(i).CamPath.Item(j).CenterPoint.X - Objects.Item(i).CamPath.Item(j).Radius)), CSng(GM.tPY(Objects.Item(i).CamPath.Item(j).CenterPoint.Y - Objects.Item(i).CamPath.Item(j).Radius)), CSng((Objects.Item(i).CamPath.Item(j).Radius * 2) * GM.ZoomFactor), CSng((Objects.Item(i).CamPath.Item(j).Radius * 2) * GM.ZoomFactor), CSng(Objects.Item(i).CamPath.Item(j).StartAngle), 360 + CSng(Objects.Item(i).CamPath.Item(j).EndAngle - Objects.Item(i).CamPath.Item(j).StartAngle))
                    '                End If
                    '            End If
                    '            If Objects.Item(i).CamPath.Item(j).GetType = GetType(cCircle) Then
                    '                e.Graphics.DrawArc(myPen, CSng(GM.tPX(Objects.Item(i).CamPath.Item(j).CenterPoint.X - Objects.Item(i).CamPath.Item(j).Radius)), CSng(GM.tPY(Objects.Item(i).CamPath.Item(j).CenterPoint.Y - Objects.Item(i).CamPath.Item(j).Radius)), CSng((Objects.Item(i).CamPath.Item(j).Radius * 2) * GM.ZoomFactor), CSng((Objects.Item(i).CamPath.Item(j).Radius * 2) * GM.ZoomFactor), 0, 360)
                    '            End If
                    '        Next
                    '    End If

                    '----- Highlight choosen pocket elements -----

                    If Objects.Item(i).CamElements.Count > 0 Then
                        For j = 1 To Objects.Item(i).CamElements.Count
                            myPen.Color = Color.Coral
                            myPen.Width = 2
                            myPen.EndCap = Drawing2D.LineCap.Round
                            myPen.Alignment = Drawing2D.PenAlignment.Center
                            If Objects.Item(i).CamElements.Item(j).GetType = GetType(cLine) Then
                                e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).CamElements.Item(j).m_X1, Objects.Item(i).CamElements.Item(j).m_Y1, Objects.Item(i).CamElements.Item(j).m_Z1)(0)), CSng(GM.tP(Objects.Item(i).CamElements.Item(j).m_X1, Objects.Item(i).CamElements.Item(j).m_Y1, Objects.Item(i).CamElements.Item(j).m_Z1)(1)), CSng(GM.tP(Objects.Item(i).CamElements.Item(j).m_X2, Objects.Item(i).CamElements.Item(j).m_Y2, Objects.Item(i).CamElements.Item(j).m_Z2)(0)), CSng(GM.tP(Objects.Item(i).CamElements.Item(j).m_X2, Objects.Item(i).CamElements.Item(j).m_Y2, Objects.Item(i).CamElements.Item(j).m_Z2)(1)))
                            End If
                            If Objects.Item(i).CamElements.Item(j).GetType = GetType(cArc) Then
                                If Objects.Item(i).CamElements.Item(j).EndAngle > Objects.Item(i).CamElements.Item(j).StartAngle Then
                                    e.Graphics.DrawArc(myPen, CSng(GM.tPX(Objects.Item(i).CamElements.Item(j).CenterPoint.X - Objects.Item(i).CamElements.Item(j).Radius)), CSng(GM.tPY(Objects.Item(i).CamElements.Item(j).CenterPoint.Y - Objects.Item(i).CamElements.Item(j).Radius)), CSng((Objects.Item(i).CamElements.Item(j).Radius * 2) * GM.ZoomFactor), CSng((Objects.Item(i).CamElements.Item(j).Radius * 2) * GM.ZoomFactor), CSng(Objects.Item(i).CamElements.Item(j).StartAngle), CSng(Objects.Item(i).CamElements.Item(j).EndAngle - Objects.Item(i).CamElements.Item(j).StartAngle))
                                Else
                                    e.Graphics.DrawArc(myPen, CSng(GM.tPX(Objects.Item(i).CamElements.Item(j).CenterPoint.X - Objects.Item(i).CamElements.Item(j).Radius)), CSng(GM.tPY(Objects.Item(i).CamElements.Item(j).CenterPoint.Y - Objects.Item(i).CamElements.Item(j).Radius)), CSng((Objects.Item(i).CamElements.Item(j).Radius * 2) * GM.ZoomFactor), CSng((Objects.Item(i).CamElements.Item(j).Radius * 2) * GM.ZoomFactor), CSng(Objects.Item(i).CamElements.Item(j).StartAngle), 360 + CSng(Objects.Item(i).CamElements.Item(j).EndAngle - Objects.Item(i).CamElements.Item(j).StartAngle))
                                End If
                            End If
                            If Objects.Item(i).CamElements.Item(j).GetType = GetType(cCircle) Then
                                Dim myPoints(3) As Point

                                For ii As Integer = 0 To myPoints.Length - 1
                                    myPoints(ii) = New Point(CInt(GM.tP(Objects.Item(i).CamElements.Item(j).getSplineRepresentationPoints(ii).X, Objects.Item(i).CamElements.Item(j).getSplineRepresentationPoints(ii).Y, Objects.Item(i).CamElements.Item(j).getSplineRepresentationPoints(ii).Z)(0)), CInt(GM.tP(Objects.Item(i).CamElements.Item(j).getSplineRepresentationPoints(ii).X, Objects.Item(i).CamElements.Item(j).getSplineRepresentationPoints(ii).Y, Objects.Item(i).CamElements.Item(j).getSplineRepresentationPoints(ii).Z)(1)))
                                Next
                                e.Graphics.DrawClosedCurve(myPen, myPoints, 0.8, Drawing2D.FillMode.Alternate)
                            End If
                        Next
                    End If
                End If

                If TreeViewCam.Nodes.ContainsKey("CAM-Tasche" + CStr(Objects.Item(i).PathNumber)) = False Then
                    TreeViewCam.Nodes.Add("CAM-Tasche" & Objects.Item(i).PathNumber, "CAM-Tasche" & Objects.Item(i).PathNumber)
                End If
                Select Case (Objects.Item(i).StateOfEntity)
                    Case 0
                        TreeViewCam.Nodes.Item("CAM-Tasche" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 7
                    Case 1
                        TreeViewCam.Nodes.Item("CAM-Tasche" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 7
                    Case 2
                        TreeViewCam.Nodes.Item("CAM-Tasche" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 6
                    Case Else
                End Select
            End If

            '----- cCamBore -----

            If Objects.Item(i).GetType = GetType(cCamBore) Then
                myPen.Width = 1
                myPen.EndCap = Drawing2D.LineCap.Round
                myPen.Alignment = Drawing2D.PenAlignment.Center
                If Objects.Item(i).StateOfEntity <> 2 Then
                    If Objects.Item(i).CamPath.Count > 0 Then
                        For j = 1 To Objects.Item(i).CamPath.Count
                            Select Case Objects.Item(i).CamPath.Item(j).CamDescription
                                Case "Work"
                                    myPen.Color = Color.DarkMagenta
                                Case "Rapid"
                                    myPen.Color = Color.Magenta
                                Case "InfeedGround"
                                    myPen.Color = Color.MediumVioletRed
                            End Select
                            If Objects.Item(i).CamPath.Item(j).IsSelected = True Then
                                myPen.Color = Color.White
                            End If
                            If Objects.Item(i).CamPath.Item(j).IsHeighlighted = True Then
                                Objects.Item(i).CamPath.Item(j).IsHeighlighted = False
                                myPen.Color = Color.Orange
                            End If
                            If Objects.Item(i).CamPath.Item(j).GetType = GetType(cLine) Then
                                e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).CamPath.Item(j).m_X1, Objects.Item(i).CamPath.Item(j).m_Y1, Objects.Item(i).CamPath.Item(j).m_Z1)(0)), CSng(GM.tP(Objects.Item(i).CamPath.Item(j).m_X1, Objects.Item(i).CamPath.Item(j).m_Y1, Objects.Item(i).CamPath.Item(j).m_Z1)(1)), CSng(GM.tP(Objects.Item(i).CamPath.Item(j).m_X2, Objects.Item(i).CamPath.Item(j).m_Y2, Objects.Item(i).CamPath.Item(j).m_Z2)(0)), CSng(GM.tP(Objects.Item(i).CamPath.Item(j).m_X2, Objects.Item(i).CamPath.Item(j).m_Y2, Objects.Item(i).CamPath.Item(j).m_Z2)(1)))
                            End If
                        Next
                    End If

                    '----- Highlight choosen bore elements -----

                    If Objects.Item(i).CamElements.Count > 0 Then
                        For j = 1 To Objects.Item(i).CamElements.Count
                            myPen.Color = Color.Coral
                            myPen.Width = 2
                            myPen.EndCap = Drawing2D.LineCap.Round
                            myPen.Alignment = Drawing2D.PenAlignment.Center
                            e.Graphics.DrawArc(myPen, CSng(GM.tP(Objects.Item(i).CamElements.Item(j).m_X, Objects.Item(i).CamElements.Item(j).m_Y, Objects.Item(i).CamElements.Item(j).m_Z)(0) - 1), CSng(GM.tP(Objects.Item(i).CamElements.Item(j).m_X, Objects.Item(i).CamElements.Item(j).m_Y, Objects.Item(i).CamElements.Item(j).m_Z)(1) + 1), 3, 3, 0, 360)
                            'e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).CamElements.Item(j).gLRP("LU", 2 / GM.ZoomFactor)(0), Objects.Item(i).CamElements.Item(j).gLRP("LU", 2 / GM.ZoomFactor)(1), Objects.Item(i).CamElements.Item(j).gLRP("LU", 2 / GM.ZoomFactor)(2))(0)), CSng(GM.tP(Objects.Item(i).CamElements.Item(j).gLRP("LU", 2 / GM.ZoomFactor)(0), Objects.Item(i).CamElements.Item(j).gLRP("LU", 2 / GM.ZoomFactor)(1), Objects.Item(i).CamElements.Item(j).gLRP("LU", 2 / GM.ZoomFactor)(2))(1)), CSng(GM.tP(Objects.Item(i).CamElements.Item(j).gLRP("RD", 2 / GM.ZoomFactor)(0), Objects.Item(i).CamElements.Item(j).gLRP("RD", 2 / GM.ZoomFactor)(1), Objects.Item(i).CamElements.Item(j).gLRP("RD", 2 / GM.ZoomFactor)(2))(0)), CSng(GM.tP(Objects.Item(i).CamElements.Item(j).gLRP("RD", 2 / GM.ZoomFactor)(0), Objects.Item(i).CamElements.Item(j).gLRP("RD", 2 / GM.ZoomFactor)(1), Objects.Item(i).CamElements.Item(j).gLRP("RD", 2 / GM.ZoomFactor)(2))(1)))
                            'e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).CamElements.Item(j).gLRP("LD", 2 / GM.ZoomFactor)(0), Objects.Item(i).CamElements.Item(j).gLRP("LD", 2 / GM.ZoomFactor)(1), Objects.Item(i).CamElements.Item(j).gLRP("LD", 2 / GM.ZoomFactor)(2))(0)), CSng(GM.tP(Objects.Item(i).CamElements.Item(j).gLRP("LD", 2 / GM.ZoomFactor)(0), Objects.Item(i).CamElements.Item(j).gLRP("LD", 2 / GM.ZoomFactor)(1), Objects.Item(i).CamElements.Item(j).gLRP("LD", 2 / GM.ZoomFactor)(2))(1)), CSng(GM.tP(Objects.Item(i).CamElements.Item(j).gLRP("RU", 2 / GM.ZoomFactor)(0), Objects.Item(i).CamElements.Item(j).gLRP("RU", 2 / GM.ZoomFactor)(1), Objects.Item(i).CamElements.Item(j).gLRP("RU", 2 / GM.ZoomFactor)(2))(0)), CSng(GM.tP(Objects.Item(i).CamElements.Item(j).gLRP("RU", 2 / GM.ZoomFactor)(0), Objects.Item(i).CamElements.Item(j).gLRP("RU", 2 / GM.ZoomFactor)(1), Objects.Item(i).CamElements.Item(j).gLRP("RU", 2 / GM.ZoomFactor)(2))(1)))
                        Next
                    End If
                End If
                If TreeViewCam.Nodes.ContainsKey("CAM-Bohrung" + CStr(Objects.Item(i).PathNumber)) = False Then
                    TreeViewCam.Nodes.Add("CAM-Bohrung" & Objects.Item(i).PathNumber, "CAM-Bohrung" & Objects.Item(i).PathNumber)
                End If
                Select Case (Objects.Item(i).StateOfEntity)
                    Case 0
                        TreeViewCam.Nodes.Item("CAM-Bohrung" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 3
                    Case 1
                        TreeViewCam.Nodes.Item("CAM-Bohrung" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 3
                    Case 2
                        TreeViewCam.Nodes.Item("CAM-Bohrung" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 2
                    Case Else
                End Select
            End If

            '----- cCamPicture -----

            If Objects.Item(i).GetType = GetType(cCamPicture) Then
                '    myPen.Width = 1
                '    myPen.EndCap = Drawing2D.LineCap.Round
                '    myPen.Alignment = Drawing2D.PenAlignment.Center
                '    If Objects.Item(i).StateOfEntity <> 2 Then
                '        If Objects.Item(i).CamPath.Count > 0 Then
                '            For j = 1 To Objects.Item(i).CamPath.Count
                '                Select Case Objects.Item(i).CamPath.Item(j).CamDescription
                '                    Case "Work"
                '                        myPen.Color = Color.DarkMagenta
                '                    Case "Rapid"
                '                        myPen.Color = Color.Magenta
                '                    Case "InfeedGround"
                '                        myPen.Color = Color.MediumVioletRed
                '                End Select
                '                If Objects.Item(i).CamPath.Item(j).IsSelected = True Then
                '                    myPen.Color = Color.White
                '                End If
                '                If Objects.Item(i).CamPath.Item(j).IsHeighlighted = True Then
                '                    Objects.Item(i).CamPath.Item(j).IsHeighlighted = False
                '                    myPen.Color = Color.Orange
                '                End If
                '                If Objects.Item(i).CamPath.Item(j).GetType = GetType(cLine) Then
                '                    e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).CamPath.Item(j).StartPoint).X), CSng(GM.tP(Objects.Item(i).CamPath.Item(j).StartPoint).Y), CSng(GM.tP(Objects.Item(i).CamPath.Item(j).EndPoint).X), CSng(GM.tP(Objects.Item(i).CamPath.Item(j).EndPoint).Y))
                '                End If
                '            Next
                '        End If
                '    End If
                If TreeViewCam.Nodes.ContainsKey("CAM-Bild" + CStr(Objects.Item(i).PathNumber)) = False Then
                    TreeViewCam.Nodes.Add("CAM-Bild" & Objects.Item(i).PathNumber, "CAM-Bild" & Objects.Item(i).PathNumber)
                End If
                Select Case (Objects.Item(i).StateOfEntity)
                    Case 0
                        TreeViewCam.Nodes.Item("CAM-Bild" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 5
                    Case 1
                        TreeViewCam.Nodes.Item("CAM-Bild" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 6
                    Case 2
                        TreeViewCam.Nodes.Item("CAM-Bild" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 7
                    Case Else
                End Select
            End If

            '----- cCamFaceMilling -----

            If Objects.Item(i).GetType = GetType(cCamFaceMilling) Then
                myPen.Width = 1
                myPen.EndCap = Drawing2D.LineCap.Round
                myPen.Alignment = Drawing2D.PenAlignment.Center
                If Objects.Item(i).StateOfEntity <> 2 Then
                    If Objects.Item(i).m_CamPathArray.length > 0 Then
                        For j = 1 To Objects.Item(i).m_CamPathArray.length - 1
                            Select Case Objects.Item(i).m_CamPathArray(j).Annotation
                                Case "Work"
                                    myPen.Color = Color.DarkMagenta
                                Case "Rapid"
                                    myPen.Color = Color.Magenta
                                Case "InfeedGround"
                                    myPen.Color = Color.MediumVioletRed
                            End Select
                            'If Objects.Item(i).CamPath.Item(j).IsSelected = True Then
                            '    myPen.Color = Color.White
                            'End If
                            'If Objects.Item(i).CamPath.Item(j).IsHeighlighted = True Then
                            '    Objects.Item(i).CamPath.Item(j).IsHeighlighted = False
                            '    myPen.Color = Color.Orange
                            'End If
                            e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).m_CamPathArray(j - 1).X, Objects.Item(i).m_CamPathArray(j - 1).Y, Objects.Item(i).m_CamPathArray(j - 1).Z)(0)), CSng(GM.tP(Objects.Item(i).m_CamPathArray(j - 1).X, Objects.Item(i).m_CamPathArray(j - 1).Y, Objects.Item(i).m_CamPathArray(j - 1).Z)(1)), CSng(GM.tP(Objects.Item(i).m_CamPathArray(j).X, Objects.Item(i).m_CamPathArray(j).Y, Objects.Item(i).m_CamPathArray(j).Z)(0)), CSng(GM.tP(Objects.Item(i).m_CamPathArray(j).X, Objects.Item(i).m_CamPathArray(j).Y, Objects.Item(i).m_CamPathArray(j).Z)(1)))
                        Next
                    End If


                End If
                If TreeViewCam.Nodes.ContainsKey("CAM-Abzeilen" + CStr(Objects.Item(i).PathNumber)) = False Then
                    TreeViewCam.Nodes.Add("CAM-Abzeilen" & Objects.Item(i).PathNumber, "CAM-Abzeilen" & Objects.Item(i).PathNumber)
                End If
                Select Case (Objects.Item(i).StateOfEntity)
                    Case 0
                        TreeViewCam.Nodes.Item("CAM-Abzeilen" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 5
                    Case 1
                        TreeViewCam.Nodes.Item("CAM-Abzeilen" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 5
                    Case 2
                        TreeViewCam.Nodes.Item("CAM-Abzeilen" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 4
                    Case Else
                End Select
            End If

            '--- cCam3D ---

            If Objects.Item(i).GetType = GetType(cCam3D) Then
                myPen.Width = 1
                myPen.EndCap = Drawing2D.LineCap.Round
                myPen.Alignment = Drawing2D.PenAlignment.Center
                If Objects.Item(i).StateOfEntity <> 2 Then
                    If Objects.Item(i).m_CamPathArray.length > 0 Then
                        For j = 1 To Objects.Item(i).m_CamPathArray.length - 1
                            Select Case Objects.Item(i).m_CamPathArray(j).Annotation
                                Case "Work"
                                    myPen.Color = Color.DarkMagenta
                                Case "Rapid"
                                    myPen.Color = Color.Azure
                                Case "InfeedGround"
                                    myPen.Color = Color.CadetBlue
                            End Select
                            e.Graphics.DrawLine(myPen, CSng(GM.tP(Objects.Item(i).m_CamPathArray(j - 1).X, Objects.Item(i).m_CamPathArray(j - 1).Y, Objects.Item(i).m_CamPathArray(j - 1).Z)(0)), CSng(GM.tP(Objects.Item(i).m_CamPathArray(j - 1).X, Objects.Item(i).m_CamPathArray(j - 1).Y, Objects.Item(i).m_CamPathArray(j - 1).Z)(1)), CSng(GM.tP(Objects.Item(i).m_CamPathArray(j).X, Objects.Item(i).m_CamPathArray(j).Y, Objects.Item(i).m_CamPathArray(j).Z)(0)), CSng(GM.tP(Objects.Item(i).m_CamPathArray(j).X, Objects.Item(i).m_CamPathArray(j).Y, Objects.Item(i).m_CamPathArray(j).Z)(1)))
                        Next

                        '---

                    End If

                    '---

                End If

                '---

                If TreeViewCam.Nodes.ContainsKey("CAM-3D" + CStr(Objects.Item(i).PathNumber)) = False Then
                    TreeViewCam.Nodes.Add("CAM-3D" & Objects.Item(i).PathNumber, "CAM-3D" & Objects.Item(i).PathNumber)
                End If
                Select Case (Objects.Item(i).StateOfEntity)
                    Case 0
                        TreeViewCam.Nodes.Item("CAM-3D" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 0
                    Case 1
                        TreeViewCam.Nodes.Item("CAM-3D" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 0
                    Case 2
                        TreeViewCam.Nodes.Item("CAM-3D" + CStr(Objects.Item(i).PathNumber)).ImageIndex = 1
                    Case Else
                End Select
            End If

        Next i

    End Sub

    Public Function getNewEntityNumber(EntityType As Type) As Integer

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

        Dim i As Integer

        Select Case EntityType
            Case GetType(cSketch)
                Do While 1
                    If Objects.Contains("Sketch " + CStr(i)) Then
                        i += 1
                    Else
                        Return i
                    End If
                Loop
            Case GetType(cSketch3D)
                Do While 1
                    If Objects.Contains("3D-Sketch " + CStr(i)) Then
                        i += 1
                    Else
                        Return i
                    End If
                Loop
            Case GetType(cImported)
                Do While 1
                    If Objects.Contains("Imported " + CStr(i)) Then
                        i += 1
                    Else
                        Return i
                    End If
                Loop
            Case GetType(cCamPath)
                Do While 1
                    If Objects.Contains("Path " + CStr(i)) Then
                        i += 1
                    Else
                        Return i
                    End If
                Loop
            Case GetType(cCamPocket)
                Do While 1

                    If Objects.Contains("Pocket " + CStr(i)) Then
                        i += 1
                    Else
                        Return i
                    End If
                Loop
            Case GetType(cCamBore)
                Do While 1

                    If Objects.Contains("Bore " + CStr(i)) Then
                        i += 1
                    Else
                        Return i
                    End If
                Loop
            Case GetType(cCamPicture)
                Do While 1

                    If Objects.Contains("picture " + CStr(i)) Then
                        i += 1
                    Else
                        Return i
                    End If
                Loop
            Case GetType(cCamFaceMilling)
                Do While 1

                    If Objects.Contains("FaceMilling " + CStr(i)) Then
                        i += 1
                    Else
                        Return i
                    End If
                Loop
            Case GetType(cCam3D)
                Do While 1

                    If Objects.Contains("3D " + CStr(i)) Then
                        i += 1
                    Else
                        Return i
                    End If
                Loop
        End Select
        Return 0
    End Function

    Public Function addElement(ByRef Element As cObjectEntity) As Boolean

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

        Dim NumberBuffer As Integer

        If Element.GetType = GetType(cSketch) Then
            NumberBuffer = getNewEntityNumber(GetType(cSketch))
            Objects.Add(Element, "Sketch " + CStr(NumberBuffer))
            Objects.Item(Objects.Count).SketchNumber = NumberBuffer
            Objects.Item(Objects.Count).StateOfEntity = 1
            Objects.Item(Objects.Count).EntityName = "Skizze" + CStr(Objects.Item(Objects.Count).SketchNumber)
            Objects.Item(Objects.Count).NameOfEntity = "Skizze" + CStr(Objects.Item(Objects.Count).SketchNumber)
        End If
        If Element.GetType = GetType(cSketch3D) Then
            NumberBuffer = getNewEntityNumber(GetType(cSketch3D))
            Objects.Add(Element, "3D-Sketch " + CStr(NumberBuffer))
            Objects.Item(Objects.Count).SketchNumber = NumberBuffer
            Objects.Item(Objects.Count).StateOfEntity = 1
            Objects.Item(Objects.Count).EntityName = "3D-Skizze" + CStr(Objects.Item(Objects.Count).SketchNumber)
            Objects.Item(Objects.Count).NameOfEntity = "3D-Skizze" + CStr(Objects.Item(Objects.Count).SketchNumber)
        End If

        ' cImported

        If Element.GetType = GetType(cImported) Then
            NumberBuffer = getNewEntityNumber(GetType(cImported))
            Objects.Add(Element, "Imported " + CStr(NumberBuffer))
            Objects.Item(Objects.Count).Number = NumberBuffer
            Objects.Item(Objects.Count).StateOfEntity = 1 ' Set it active
            Objects.Item(Objects.Count).EntityName = "Importiert" + CStr(Objects.Item(Objects.Count).Number)
            Objects.Item(Objects.Count).NameOfEntity = "Importiert" + CStr(Objects.Item(Objects.Count).Number)
        End If

        ' CamPath

        If Element.GetType = GetType(cCamPath) Then
            NumberBuffer = getNewEntityNumber(GetType(cCamPath))
            Objects.Add(Element, "Path " + CStr(NumberBuffer))
            Objects.Item(Objects.Count).PathNumber = NumberBuffer
            Objects.Item(Objects.Count).StateOfEntity = 1
            Objects.Item(Objects.Count).EntityName = "CAM-Kontur" + CStr(Objects.Item(Objects.Count).PathNumber)
            Objects.Item(Objects.Count).NameOfEntity = "CAM-Kontur" + CStr(Objects.Item(Objects.Count).PathNumber)
        End If

        ' CamPocket

        If Element.GetType = GetType(cCamPocket) Then
            NumberBuffer = getNewEntityNumber(GetType(cCamPocket))
            Objects.Add(Element, "Pocket " + CStr(NumberBuffer))
            Objects.Item(Objects.Count).PathNumber = NumberBuffer
            Objects.Item(Objects.Count).StateOfEntity = 1
            Objects.Item(Objects.Count).EntityName = "CAM-Tasche" + CStr(Objects.Item(Objects.Count).PathNumber)
            Objects.Item(Objects.Count).NameOfEntity = "CAM-Tasche" + CStr(Objects.Item(Objects.Count).PathNumber)
        End If

        ' CamBore

        If Element.GetType = GetType(cCamBore) Then
            NumberBuffer = getNewEntityNumber(GetType(cCamBore))
            Objects.Add(Element, "Bore " + CStr(NumberBuffer))
            Objects.Item(Objects.Count).PathNumber = NumberBuffer
            Objects.Item(Objects.Count).StateOfEntity = 1
            Objects.Item(Objects.Count).EntityName = "CAM-Bohrung" + CStr(Objects.Item(Objects.Count).PathNumber)
            Objects.Item(Objects.Count).NameOfEntity = "CAM-Bohrung" + CStr(Objects.Item(Objects.Count).PathNumber)
        End If

        ' CamPicture

        If Element.GetType = GetType(cCamPicture) Then
            NumberBuffer = getNewEntityNumber(GetType(cCamPicture))
            Objects.Add(Element, "Picture " + CStr(NumberBuffer))
            Objects.Item(Objects.Count).PathNumber = NumberBuffer
            Objects.Item(Objects.Count).StateOfEntity = 1
            Objects.Item(Objects.Count).EntityName = "CAM-Bild" + CStr(Objects.Item(Objects.Count).PathNumber)
            Objects.Item(Objects.Count).NameOfEntity = "CAM-Bild" + CStr(Objects.Item(Objects.Count).PathNumber)
        End If

        ' CamFaceMilling

        If Element.GetType = GetType(cCamFaceMilling) Then
            NumberBuffer = getNewEntityNumber(GetType(cCamFaceMilling))
            Objects.Add(Element, "FaceMilling " + CStr(NumberBuffer))
            Objects.Item(Objects.Count).PathNumber = NumberBuffer
            Objects.Item(Objects.Count).StateOfEntity = 1
            Objects.Item(Objects.Count).EntityName = "CAM-Abzeilen" + CStr(Objects.Item(Objects.Count).PathNumber)
            Objects.Item(Objects.Count).NameOfEntity = "CAM-Abzeilen" + CStr(Objects.Item(Objects.Count).PathNumber)
        End If

        ' Cam3D

        If Element.GetType = GetType(cCam3D) Then
            NumberBuffer = getNewEntityNumber(GetType(cCam3D))
            Objects.Add(Element, "3D " + CStr(NumberBuffer))
            Objects.Item(Objects.Count).PathNumber = NumberBuffer
            Objects.Item(Objects.Count).StateOfEntity = 1
            Objects.Item(Objects.Count).EntityName = "CAM-3D" + CStr(Objects.Item(Objects.Count).PathNumber)
            Objects.Item(Objects.Count).NameOfEntity = "CAM-3D" + CStr(Objects.Item(Objects.Count).PathNumber)
#If DEBUG Then

            Console.WriteLine("So")
#End If

        End If

        Return True
    End Function

    Public Function fun_EndSketch() As Boolean

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

        For i As Integer = 1 To Objects.Count

            If Objects.Item(i).StateOfEntity = 1 Then
                Objects.Item(i).StateOfEntity = 2
            End If
        Next
        Return True
    End Function

    Public Function deleteElement(ByRef TreeView As TreeView, ByRef Node As TreeNode) As Boolean

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

        Dim i As Integer

        For i = 1 To Objects.Count
            If Objects.Item(i).EntityName = Node.Name Then
                Objects.Remove(i)
                TreeView.Nodes.Remove(Node)
                Return True
            End If
        Next
        Return False
    End Function

    Public Function fun_HideElement(ElementName As String, Visible As Boolean) As Boolean

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

        Dim i As Integer
        For i = 1 To Objects.Count
            If Objects.Item(i).NameOfEntity = ElementName Then
                If Visible = True Then
                    Objects.Item(i).StateOfEntity = 0
                Else
                    Objects.Item(i).StateOfEntity = 2
                End If
                Return True
            End If
        Next
        Return False
    End Function

    Public Function fun_GetStateOfEntity(ElementName As String) As Integer

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

        Dim i As Integer
        For i = 1 To Objects.Count
            If Objects.Item(i).NameOfEntity = ElementName Then
                Return Objects.Item(i).StateOfEntity
            End If
        Next
        Return 0
    End Function

    Public Function fun_HighlightSketchElement(X As Integer, Y As Integer, Toggle As Integer, GeoMan As cOTGeometricRepresentationManager) As String

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

        Dim i, j As Integer
        Dim strEntityName As String = ""
        Select Case Toggle
            Case 1, 2
                For i = 1 To Objects.Count
                    If Objects.Item(i).StateOfEntity = 1 Then 'And Objects.Item(i).GetType = GetType(cSketch)
                        Select Case Objects.Item(i).GetType
                            Case GetType(cSketch)
                                Utilities.getNearestElement(Objects.Item(i).Sketch, X, Y, Toggle, GeoMan)
                            Case GetType(cCamPath), GetType(cCamPocket), GetType(cCamBore)
                                Utilities.getNearestElement(Objects.Item(i).CamPath, X, Y, Toggle, GeoMan)
                                For j = 1 To Objects.Count
                                    If Objects.Item(j).StateOfEntity <> 2 And Objects.Item(j).GetType = GetType(cSketch) Then
                                        Utilities.getNearestElement(Objects.Item(j).Sketch, X, Y, Toggle, GeoMan)
                                    End If
                                Next
                        End Select
                        Return ""
                    End If
                Next
            Case 3
                For i = 1 To Objects.Count
                    If Objects.Item(i).GetType = GetType(cSketch) And Objects.Item(i).StateOfEntity <> 2 Then
                        strEntityName = Utilities.getNearestElement(Objects.Item(i).Sketch, X, Y, Toggle, GeoMan)
                        'System.Console.WriteLine("Element: " + strEntityName + ", ")
                        If strEntityName <> "" Then
                            For j = 1 To Objects.Count
                                If Objects.Item(j).GetType = GetType(cCamPath) And Objects.Item(j).StateOfEntity = 1 Then
                                    Objects.Item(j).CamElements.Add(Objects.Item(i).Sketch.Item(strEntityName))
                                    'System.Console.WriteLine("Elementnombre: " + Objects.Item(j).CamElements.Item(Objects.Item(j).CamElements.Count).NameOfEntity + "@" + Objects.Item(j).CamElements.Item(Objects.Item(j).CamElements.Count).str_SketchName + ", ")
                                    Return ""
                                End If
                            Next

                            For j = 1 To Objects.Count
                                If Objects.Item(j).GetType = GetType(cCamPocket) And Objects.Item(j).StateOfEntity = 1 Then
                                    Objects.Item(j).CamElements.Add(Objects.Item(i).Sketch.Item(strEntityName))
                                    'System.Console.WriteLine("Elementnombre: " + Objects.Item(j).CamElements.Item(Objects.Item(j).CamElements.Count).NameOfEntity + "@" + Objects.Item(j).CamElements.Item(Objects.Item(j).CamElements.Count).str_SketchName + ", ")
                                    Return ""
                                End If
                            Next
                            For j = 1 To Objects.Count
                                If Objects.Item(j).GetType = GetType(cCamBore) And Objects.Item(j).StateOfEntity = 1 Then
                                    Objects.Item(j).CamElements.Add(Objects.Item(i).Sketch.Item(strEntityName))
                                    'System.Console.WriteLine("Elementnombre: " + Objects.Item(j).CamElements.Item(Objects.Item(j).CamElements.Count).NameOfEntity + "@" + Objects.Item(j).CamElements.Item(Objects.Item(j).CamElements.Count).str_SketchName + ", ")
                                    Return ""
                                End If
                            Next
                        End If
                    End If
                Next
            Case 99
                Dim ElementNearby As String
                For i = 1 To Objects.Count
                    If Objects.Item(i).StateOfEntity = 1 Then 'And Objects.Item(i).GetType = GetType(cSketch)
                        Select Case Objects.Item(i).GetType
                            Case GetType(cSketch)
                                ElementNearby = Utilities.getNearestElement(Objects.Item(i).Sketch, X, Y, Toggle, GeoMan)
                        End Select
                        Return ElementNearby
                    End If
                Next

        End Select
        Return ""
    End Function

    Public Function addElementToCamPath(X As Integer, Y As Integer) As Boolean

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


        Return False
    End Function

    Public Function zoomAll(ViewSize As Rectangle) As Boolean

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

        Dim LUPoint As cPoint
        Dim RDPoint As cPoint
        Dim ZoomFactor As New cPoint()

        '----- Initial settings -----

        LUPoint.X = 0
        LUPoint.Y = 0
        LUPoint.Z = 0
        RDPoint.X = 0
        RDPoint.Y = 0
        RDPoint.Z = 0

        '-----

        For j As Integer = 1 To Objects.Count
            If Objects.Item(j).tateOfEntity <> 2 Then
                Select Case Objects.Item(j).GetType

                    Case GetType(cSketch)
                        For i As Integer = 1 To Objects.Item(j).Sketch.count
                            Select Case Objects.Item(j).GetType
                                Case GetType(cLine)
                                    If m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X1, Objects.Item(j).Sketch.Item(i).m_Y1, Objects.Item(j).Sketch.Item(i).m_Z1)(0) < LUPoint.X Then
                                        LUPoint.X = m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X1, Objects.Item(j).Sketch.Item(i).m_Y1, Objects.Item(j).Sketch.Item(i).m_Z1)(0)
                                    End If
                                    If m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X2, Objects.Item(j).Sketch.Item(i).m_Y2, Objects.Item(j).Sketch.Item(i).m_Z2)(0) < LUPoint.X Then
                                        LUPoint.X = m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X2, Objects.Item(j).Sketch.Item(i).m_Y2, Objects.Item(j).Sketch.Item(i).m_Z2)(0)
                                    End If
                                    If m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X1, Objects.Item(j).Sketch.Item(i).m_Y1, Objects.Item(j).Sketch.Item(i).m_Z1)(1) < LUPoint.Y Then
                                        LUPoint.Y = m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X1, Objects.Item(j).Sketch.Item(i).m_Y1, Objects.Item(j).Sketch.Item(i).m_Z1)(1)
                                    End If
                                    If m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X2, Objects.Item(j).Sketch.Item(i).m_Y2, Objects.Item(j).Sketch.Item(i).m_Z2)(1) < LUPoint.Y Then
                                        LUPoint.Y = m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X2, Objects.Item(j).Sketch.Item(i).m_Y2, Objects.Item(j).Sketch.Item(i).m_Z2)(1)
                                    End If
                                    If m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X1, Objects.Item(j).Sketch.Item(i).m_Y1, Objects.Item(j).Sketch.Item(i).m_Z1)(2) < LUPoint.Z Then
                                        LUPoint.Y = m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X1, Objects.Item(j).Sketch.Item(i).m_Y1, Objects.Item(j).Sketch.Item(i).m_Z1)(2)
                                    End If
                                    If m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X2, Objects.Item(j).Sketch.Item(i).m_Y2, Objects.Item(j).Sketch.Item(i).m_Z2)(2) < LUPoint.Z Then
                                        LUPoint.Y = m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X2, Objects.Item(j).Sketch.Item(i).m_Y2, Objects.Item(j).Sketch.Item(i).m_Z2)(2)
                                    End If
                                    If m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X1, Objects.Item(j).Sketch.Item(i).m_Y1, Objects.Item(j).Sketch.Item(i).m_Z1)(0) > RDPoint.X Then
                                        RDPoint.X = m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X1, Objects.Item(j).Sketch.Item(i).m_Y1, Objects.Item(j).Sketch.Item(i).m_Z1)(0)
                                    End If
                                    If m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X2, Objects.Item(j).Sketch.Item(i).m_Y2, Objects.Item(j).Sketch.Item(i).m_Z2)(0) > RDPoint.X Then
                                        RDPoint.X = m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X2, Objects.Item(j).Sketch.Item(i).m_Y2, Objects.Item(j).Sketch.Item(i).m_Z2)(0)
                                    End If
                                    If m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X1, Objects.Item(j).Sketch.Item(i).m_Y1, Objects.Item(j).Sketch.Item(i).m_Z1)(1) > RDPoint.Y Then
                                        RDPoint.Y = m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X1, Objects.Item(j).Sketch.Item(i).m_Y1, Objects.Item(j).Sketch.Item(i).m_Z1)(1)
                                    End If
                                    If m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X2, Objects.Item(j).Sketch.Item(i).m_Y2, Objects.Item(j).Sketch.Item(i).m_Z2)(1) > RDPoint.Y Then
                                        RDPoint.Y = m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X2, Objects.Item(j).Sketch.Item(i).m_Y2, Objects.Item(j).Sketch.Item(i).m_Z2)(1)
                                    End If
                                    If m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X1, Objects.Item(j).Sketch.Item(i).m_Y1, Objects.Item(j).Sketch.Item(i).m_Z1)(2) > RDPoint.Z Then
                                        RDPoint.Y = m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X1, Objects.Item(j).Sketch.Item(i).m_Y1, Objects.Item(j).Sketch.Item(i).m_Z1)(2)
                                    End If
                                    If m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X2, Objects.Item(j).Sketch.Item(i).m_Y2, Objects.Item(j).Sketch.Item(i).m_Z2)(2) > RDPoint.Z Then
                                        RDPoint.Y = m_GeoManager.tP(Objects.Item(j).Sketch.Item(i).m_X2, Objects.Item(j).Sketch.Item(i).m_Y2, Objects.Item(j).Sketch.Item(i).m_Z2)(2)
                                    End If
                                Case GetType(cArc)
                                Case GetType(cPoint)
                            End Select
                        Next
                    Case GetType(cCamPath)

                    Case GetType(cCamPocket)


                    Case GetType(cCamBore)

                End Select

            End If
        Next

        ZoomFactor.X = ViewSize.Width / Math.Sqrt((RDPoint.X - LUPoint.X) ^ 2)
        ZoomFactor.Y = ViewSize.Height / Math.Sqrt((LUPoint.Y - RDPoint.Y) ^ 2)

        If ZoomFactor.X > ZoomFactor.Y Then

            m_GeoManager.ZoomFactor = ZoomFactor.Y

        Else

            m_GeoManager.ZoomFactor = ZoomFactor.X

        End If

        Return True
    End Function

    Function getElementsInChooserRectangle(X1 As Double, Y1 As Double, X2 As Double, Y2 As Double, ByRef Filter As cOTString) As Boolean

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

        Dim strEntityName As String = ""

        For i As Integer = 1 To Objects.Count
            If Objects.Item(i).GetType = GetType(cSketch) And Objects.Item(i).StateOfEntity <> 2 Then

                For j As Integer = 1 To Objects.Count
                    If Objects.Item(j).GetType = GetType(cCamPath) And Objects.Item(j).StateOfEntity = 1 Then
                        Utilities.getElementInRectangle(X1, Y1, X2, Y2, Objects.Item(i).Sketch, Objects.Item(j).CamElements, Filter)
                        Return True
                    End If
                Next

                For j As Integer = 1 To Objects.Count
                    If Objects.Item(j).GetType = GetType(cCamPocket) And Objects.Item(j).StateOfEntity = 1 Then
                        Utilities.getElementInRectangle(X1, Y1, X2, Y2, Objects.Item(i).Sketch, Objects.Item(j).CamElements, Filter)
                        Return True
                    End If
                Next
                For j As Integer = 1 To Objects.Count
                    If Objects.Item(j).GetType = GetType(cCamBore) And Objects.Item(j).StateOfEntity = 1 Then
                        Utilities.getElementInRectangle(X1, Y1, X2, Y2, Objects.Item(i).Sketch, Objects.Item(j).CamElements, Filter)
                        Return True
                    End If
                Next
                For j As Integer = 1 To Objects.Count
                    If Objects.Item(j).GetType = GetType(cCamPicture) And Objects.Item(j).StateOfEntity = 1 Then
                        Utilities.getElementInRectangle(X1, Y1, X2, Y2, Objects.Item(i).Sketch, Objects.Item(j).CamElements, Filter)
                        Return True
                    End If
                Next
            End If
        Next

        Return True
    End Function

    Public Function moveElement() As Boolean

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

    Public Function getNearestElement(X As Integer, Y As Integer) As String

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


        Return ""
    End Function

    ''' <summary>
    ''' Deletes the active element from the "Objects"-collection.
    ''' </summary>
    ''' <returns></returns>
    Public Function deleteActiveElement() As String

        If Objects.Count = 0 Then
            Return "Error: No Elements found."
        End If

        Dim ItemCount As Integer
        Dim ItemIndex As Integer

        '--- Initial settings. ---

        ItemCount = 0

        '---

        For i As Integer = 1 To Objects.Count
            If Objects.Item(i).StateOfEntity = 1 Then
                ItemIndex = i
                ItemCount += 1
            End If
        Next

        Select Case ItemCount
            Case 0
                Return "Error: Nothing was active."
            Case 1
                Objects.Remove(ItemIndex)
            Case > 1
                Return "Error: More than one item were active. Nothing was deleted."
        End Select

        Return "Ok."
    End Function

End Class
