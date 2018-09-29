Option Explicit On
Option Infer Off

Public Class cDXFInterface

    '----- Constructor ----------------------------------------------------

    Public Sub New()
        EntitySwitch = 0
        DimensionSwitch = 0
        LineCount = 0
        ArcCount = 0
        CircleCount = 0
        IsSectionEntities = False
    End Sub

    '----- Member Variables and constants -----------------------------------------------

    Private m_EntitySwitch As Integer
    Private m_DimensionSwitch As Integer
    Private m_LineCount As Integer
    Private m_ArcCount As Integer
    Private m_CircleCount As Integer
    Private m_IsSectionEntities As Boolean
    Private m_ElementKey As String

    '----- Get and set properties -----

    Public Property EntitySwitch() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_EntitySwitch
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_EntitySwitch = Value
        End Set
    End Property

    Public Property DimensionSwitch() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_DimensionSwitch
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_DimensionSwitch = Value
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

    Public Property IsSectionEntities() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_IsSectionEntities
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_IsSectionEntities = Value
        End Set
    End Property

    Public Property Elementkey() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ElementKey
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_ElementKey = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes ---------------------------

    Public Function sub_ConvertDxfToOdtPrt(ByRef colGeoBase As cSketch, ByVal strInputLin As String, ByVal SketchNumber As String) As Boolean

        '----- Beginn Description ------------------------------------------------

        'This function takes line by line of a dxf-file and fills a collection
        'with the recognized entities like lines and arcs

        '----- End Description ---------------------------------------------------

        Dim strInputLine As New String(strInputLin)
 
        If strInputLine = "ENTITIES" Then
            IsSectionEntities = True
        End If

        If IsSectionEntities = True Then
            If strInputLine = "LINE" Then
                Elementkey = colGeoBase.addElement(New cLine())
                EntitySwitch = 1
                Return False
            End If
            If strInputLine = "ARC" Then
                Elementkey = colGeoBase.addElement(New cArc)
                EntitySwitch = 2
                Return False
            End If
            If strInputLine = "CIRCLE" Then
                Elementkey = colGeoBase.addElement(New cCircle)
                EntitySwitch = 3
                Return False
            End If
            If strInputLine = "EOF" Then
                IsSectionEntities = False
                colGeoBase.fun_ReorganizePath()
                Return True
            End If

            If strInputLine = " 10" Then
                DimensionSwitch = 10
                Return False
            End If
            If strInputLine = " 11" Then
                DimensionSwitch = 11
                Return False
            End If
            If strInputLine = " 20" Then
                DimensionSwitch = 20
                Return False
            End If
            If strInputLine = " 21" Then
                DimensionSwitch = 21
                Return False
            End If
            If strInputLine = " 30" Then
                DimensionSwitch = 30
                Return False
            End If
            If strInputLine = " 31" Then
                DimensionSwitch = 31
                Return False
            End If
            If strInputLine = " 40" Then
                DimensionSwitch = 40
                Return False
            End If
            If strInputLine = " 50" Then
                DimensionSwitch = 50
                Return False
            End If
            If strInputLine = " 51" Then
                DimensionSwitch = 51
                Return False
            End If
            'Console.WriteLine("test")
            If strInputLine.Contains(".") = True Then
                strInputLine = strInputLine.Replace(".", ",") 'To make sure the conversion to double is correct
            End If
            Select Case EntitySwitch
                Case 1
                    Select Case DimensionSwitch
                        Case 10
                            colGeoBase.Sketch.Item(Elementkey).m_X1 = CDbl(strInputLine)
                            DimensionSwitch = 0
                        Case 11
                            colGeoBase.Sketch.Item(Elementkey).m_X2 = CDbl(strInputLine)
                            DimensionSwitch = 0
                        Case 20
                            colGeoBase.Sketch.Item(Elementkey).m_Y1 = CDbl(strInputLine)
                            DimensionSwitch = 0
                        Case 21
                            colGeoBase.Sketch.Item(Elementkey).m_Y2 = CDbl(strInputLine)
                            DimensionSwitch = 0
                        Case 30
                            colGeoBase.Sketch.Item(Elementkey).m_Z1 = CDbl(strInputLine)
                            DimensionSwitch = 0
                        Case 31
                            colGeoBase.Sketch.Item(Elementkey).m_Z2 = CDbl(strInputLine)
                            DimensionSwitch = 0
                            EntitySwitch = 0
                    End Select
                Case 2
                    Select Case DimensionSwitch
                        Case 10
                            colGeoBase.Sketch.Item(Elementkey).m_XC = CDbl(strInputLine)
                            DimensionSwitch = 0
                        Case 20
                            colGeoBase.Sketch.Item(Elementkey).m_YC = CDbl(strInputLine)
                            DimensionSwitch = 0
                        Case 30
                            colGeoBase.Sketch.Item(Elementkey).m_ZC = CDbl(strInputLine)
                            DimensionSwitch = 0
                        Case 40
                            colGeoBase.Sketch.Item(Elementkey).Radius = CDbl(strInputLine)
                            DimensionSwitch = 0
                        Case 50
                            colGeoBase.Sketch.Item(Elementkey).StartAngle = CDbl(strInputLine)
                            DimensionSwitch = 0
                        Case 51
                            colGeoBase.Sketch.Item(Elementkey).EndAngle = CDbl(strInputLine)
                            DimensionSwitch = 0
                            EntitySwitch = 0
                    End Select
                Case 3
                    Select Case DimensionSwitch
                        Case 10
                            colGeoBase.Sketch.Item(Elementkey).m_XC = CDbl(strInputLine)
                            DimensionSwitch = 0
                        Case 20
                            colGeoBase.Sketch.Item(Elementkey).m_YC = CDbl(strInputLine)
                            DimensionSwitch = 0
                        Case 30
                            colGeoBase.Sketch.Item(Elementkey).m_ZC = CDbl(strInputLine)
                            DimensionSwitch = 0
                        Case 40
                            colGeoBase.Sketch.Item(Elementkey).Radius = CDbl(strInputLine)
                            DimensionSwitch = 0
                            EntitySwitch = 0
                    End Select
            End Select
        End If
        Return False
    End Function

End Class
