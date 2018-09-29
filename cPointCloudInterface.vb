Option Explicit On
Option Infer Off
Imports System
Imports System.IO
Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.Integration

Public Class cPointCloudInterface

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

    Public Function importPointCloud(ByRef colGeoBase As cSketch3D, ByRef Reader As StreamReader, ByVal SketchNumber As String) As Boolean

        '----- Beginn Description ------------------------------------------------

        'This function takes line by line of a dxf-file and fills a collection
        'with the recognized entities like lines and arcs

        '----- End Description ---------------------------------------------------

        Dim InputLine() As String

        While 1

            Try
                InputLine = Split(CStr(Reader.ReadLine()), Chr(9))
                colGeoBase.addElement(New cPoint(CDbl(InputLine(0)) * 10, CDbl(InputLine(1)) * 9, CDbl(InputLine(2)) * 10))
            Catch ex As Exception
                Return True
            End Try

            ReDim InputLine(0)

        End While


        Return False
    End Function

End Class
