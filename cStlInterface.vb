Option Explicit On
Option Infer Off
Imports System
Imports System.IO
Imports System.Collections
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.Integration


Public Class cStlInterface

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

    ''' <summary>
    ''' Imports the STL.
    ''' </summary>
    ''' <param name="colGeoBase">The col geo base.</param>
    ''' <param name="Reader">The reader.</param>
    ''' <param name="Number">The number.</param>
    ''' <returns></returns>
    Public Function importSTL(ByRef colGeoBase As cImported, ByRef Reader As StreamReader, ByVal Number As String) As Boolean

        '----- Beginn Description ------------------------------------------------

        'This function takes line by line of a stl-file and fills a collection of points
        'with the recognized entities like lines and arcs

        '----- End Description ---------------------------------------------------

        Dim InputLine As String
        Dim TriangleCounter As Integer
        Dim i As Integer
        Dim BufferPoint As New cPoint()
        Dim Triangle As New cPointArray()
        Dim ArrayCounter As Integer

        '--- Initial settings ---

        TriangleCounter = 0
        ArrayCounter = 0
        colGeoBase.addElement(Triangle)
        ReDim Triangle.m_PointArray(2000)

        If Reader.ReadLine().Contains("solid ascii") Then
            Do
                InputLine = CStr(Reader.ReadLine())
                If InputLine.Contains("outer loop") Then
                    Try
                        Dim InputStrings() As String
                        Dim BufferStringX() As String
                        Dim BufferStringY() As String
                        Dim BufferStringZ() As String
                        For i = 0 To 2
                            InputLine = CStr(Reader.ReadLine())
                            If InputLine.Contains(".") = True Then
                                InputLine = InputLine.Replace(".", ",") 'To make sure the conversion to double is correct
                            End If
                            InputLine = InputLine.Remove(0, 15) ' Throw away everything bevore the x value
                            'Console.WriteLine(InputLine)
                            InputStrings = Split(InputLine, Chr(32))
#If DEBUG Then
                            'Console.WriteLine(InputStrings(0))
                            'Console.WriteLine(InputStrings(1))
                            'Console.WriteLine(InputStrings(2))
                            'Console.WriteLine("---")
#End If
                            BufferStringX = Split(InputStrings(0), Chr(101))
                            BufferPoint.X = CDbl(BufferStringX(0)) * 10 ^ CDbl(BufferStringX(1)) + 40
                            BufferStringY = Split(InputStrings(1), Chr(101))
                            BufferPoint.Y = CDbl(BufferStringY(0)) * 10 ^ CDbl(BufferStringY(1)) + 40
                            BufferStringZ = Split(InputStrings(2), Chr(101))
                            BufferPoint.Z = CDbl(BufferStringZ(0)) * 10 ^ CDbl(BufferStringZ(1)) + 2
                            Console.WriteLine("Bufferpoint x = {0}", BufferPoint.X)
                            Console.WriteLine("Bufferpoint y =  {0}", BufferPoint.Y)
                            Console.WriteLine("Bufferpoint z =  {0}", BufferPoint.Z)
                            If ArrayCounter < Triangle.m_PointArray.Length - 1 Then
                                Triangle.m_PointArray(ArrayCounter) = New cSimplePoint(BufferPoint.X, BufferPoint.Y, BufferPoint.Z, ("Triangle " + CStr(TriangleCounter)))
                                Console.WriteLine(Triangle.m_PointArray(ArrayCounter).m_X)
                                Console.WriteLine(Triangle.m_PointArray(ArrayCounter).m_Y)
                                Console.WriteLine(Triangle.m_PointArray(ArrayCounter).m_Z)
                                ArrayCounter += 1
                            Else
                                ReDim Preserve Triangle.m_PointArray(ArrayCounter + 2000)
                                Triangle.m_PointArray(ArrayCounter) = New cSimplePoint(BufferPoint.X, BufferPoint.Y, BufferPoint.Z, ("Triangle " + CStr(TriangleCounter)))
                                ArrayCounter += 1
                            End If
                        Next
                        TriangleCounter += 1
                    Catch ex As Exception
                        Console.WriteLine("Fehler " + ex.Message)
                        Return True
                    End Try
                End If
            Loop Until InputLine.Contains("endsolid")
            ReDim Preserve Triangle.m_PointArray(ArrayCounter - 1)

#If DEBUG Then
            Console.WriteLine("Arraycounter ")
            Console.WriteLine(ArrayCounter)
#End If

        End If

        colGeoBase.IsActive = False
        colGeoBase.StateOfEntity = 0 ' Set it to not active but visible

        Return False
    End Function

    Public Function exportSTL(ByRef Vertices As cPointArray, ByRef Writer As StreamWriter) As String

        Dim Line As String
        Dim FacetNormal As New cSimplePoint()
        Dim V1 As New cSimplePoint()
        Dim V2 As New cSimplePoint()

        '--- Write the first line of the STL-file ---

        Writer.WriteLine("solid ascii")

        For i As Integer = 0 To Vertices.m_PointArray.Length - 1 Step 3

            '--- Calculate the facet normal ---

            V1.X = Vertices.m_PointArray(i + 1).X - Vertices.m_PointArray(i).X
            V1.Y = Vertices.m_PointArray(i + 1).Y - Vertices.m_PointArray(i).Y
            V1.Z = Vertices.m_PointArray(i + 1).Z - Vertices.m_PointArray(i).Z
            V2.X = Vertices.m_PointArray(i + 2).X - Vertices.m_PointArray(i).X
            V2.Y = Vertices.m_PointArray(i + 2).Y - Vertices.m_PointArray(i).Y
            V2.Z = Vertices.m_PointArray(i + 2).Z - Vertices.m_PointArray(i).Z

            FacetNormal.X = V1.Y * V2.Z - V1.Z * V2.Y
            FacetNormal.Y = V1.Z * V2.X - V1.X * V2.Z
            FacetNormal.Z = V1.X * V2.Y - V1.Y * V2.X

            Line = "  facet normal " + FacetNormal.X.ToString("e6", CultureInfo.InvariantCulture) + " " + FacetNormal.Y.ToString("e6", CultureInfo.InvariantCulture) + " " + FacetNormal.Z.ToString("e6", CultureInfo.InvariantCulture)
            Writer.WriteLine(Line)
            Writer.WriteLine("    outer loop")
            Line = "      vertex   " + Vertices.m_PointArray(i).X.ToString("e6", CultureInfo.InvariantCulture) + " " + Vertices.m_PointArray(i).Y.ToString("e6", CultureInfo.InvariantCulture) + " " + Vertices.m_PointArray(i).Z.ToString("e6", CultureInfo.InvariantCulture)
            Writer.WriteLine(Line)
            Line = "      vertex   " + Vertices.m_PointArray(i + 1).X.ToString("e6", CultureInfo.InvariantCulture) + " " + Vertices.m_PointArray(i + 1).Y.ToString("e6", CultureInfo.InvariantCulture) + " " + Vertices.m_PointArray(i + 1).Z.ToString("e6", CultureInfo.InvariantCulture)
            Writer.WriteLine(Line)
            Line = "      vertex   " + Vertices.m_PointArray(i + 2).X.ToString("e6", CultureInfo.InvariantCulture) + " " + Vertices.m_PointArray(i + 2).Y.ToString("e6", CultureInfo.InvariantCulture) + " " + Vertices.m_PointArray(i + 2).Z.ToString("e6", CultureInfo.InvariantCulture)
            Writer.WriteLine(Line)
            Writer.WriteLine("    endloop")
            Writer.WriteLine("  endfacet")
        Next

        '--- Write the last line of the STL-file ---

        Writer.WriteLine("endsolid")

        Return ""
    End Function
End Class
