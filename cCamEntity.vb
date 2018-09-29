Public Class cCamEntity
    Inherits cObjectEntity

    '----- Begin description -----------------------------------------------------------


    '----- End description -------------------------------------------------------------

    '----- Constructor -----------------------------------------------------------------

    Public Sub New()

        m_StartPoint = New cPoint()
        m_Origin = New cPoint()
        m_CamElements = New Collection()
        m_CamPath = New Collection()
        m_CamPreview = New Collection()
        m_Tool = New cTool()
        m_Utilities = New cOdarTecUtilities()

        '----- Initialization -----

        UpdateCamPath = False

    End Sub

    '----- Member Variables and constants ----------------------------------------------

    Protected m_StartPoint As cPoint
    Protected m_Origin As cPoint
    Protected m_CamElements As Collection
    Protected m_CamPath As Collection
    Public m_CamPreview As Collection
    Protected m_ZSteps As Integer
    Protected m_GroundSteps As Integer
    Protected m_InfeedZ As Double
    Protected m_InfeedGround As Double
    Protected m_DepthOfCamEntity As Double  'Depth of pocket, bath, bore
    Public m_FeedRateWork As Integer
    Public m_FeedRateRapid As Integer
    Public m_FeedRateInfeed As Integer
    Public m_FeedRateGround As Integer
    Protected m_CuttingSpeed As Integer
    Protected m_NeedsPathRecalculation As Boolean
    Protected m_CamPathCount As Integer            'Needed to connect two cam path segments
    Protected m_IsActive As Boolean
    Protected m_Tool As cTool
    Protected m_Utilities As cOdarTecUtilities
    Protected m_UpdateCamPath As Boolean
    Protected m_RetractHeight As Double
    Protected m_ToolOverlap As Integer
    Protected m_RadiusCorrection As String
    Protected m_ToolRadiusCorrection As Double
    Protected m_ToolStartStopRetractHeight As Double
    Protected m_ToolWorkRetractHeight As Double

    '----- Get and set properties -----

    Public Property StartPoint() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_StartPoint
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_StartPoint = Value
        End Set
    End Property

    Public Property StartPoint_X() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_StartPoint.X
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_StartPoint.X = Value
        End Set
    End Property

    Public Property StartPoint_Y() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_StartPoint.Y
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_StartPoint.Y = Value
        End Set
    End Property

    Public Property StartPoint_Z() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_StartPoint.Z
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_StartPoint.Z = Value
        End Set
    End Property

    Public Property Origin() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Origin
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_Origin = Value
        End Set
    End Property

    Public Property Origin_X() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Origin.X
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_Origin.X = Value
        End Set
    End Property

    Public Property Origin_Y() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Origin.Y
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_Origin.Y = Value
        End Set
    End Property

    Public Property Origin_Z() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Origin.Z
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_Origin.Z = Value
        End Set
    End Property

    Public Property CamElements() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CamElements
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_CamElements = Value
        End Set
    End Property

    Public Property CamPath() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CamPath
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_CamPath = Value
        End Set
    End Property

    Public Property ZSteps() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ZSteps
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_ZSteps = Value
        End Set
    End Property

    Public Property GroundSteps() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_GroundSteps
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_GroundSteps = Value
        End Set
    End Property

    Public Property InfeedZ() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_InfeedZ
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_InfeedZ = Value
        End Set
    End Property

    Public Property InfeedGround() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_InfeedGround
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_InfeedGround = Value
        End Set
    End Property

    Public Property DepthOfCamEntity() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_DepthOfCamEntity
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_DepthOfCamEntity = Value
        End Set
    End Property

    Public Property FeedRateWork() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_FeedRateWork
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_FeedRateWork = Value
        End Set
    End Property

    Public Property FeedRateRapid() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_FeedRateRapid
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_FeedRateRapid = Value
        End Set
    End Property

    Public Property FeedRateInfeed() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_FeedRateInfeed
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_FeedRateInfeed = Value
        End Set
    End Property

    Public Property FeedRateGround() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_FeedRateGround
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_FeedRateGround = Value
        End Set
    End Property

    Public Property CuttingSpeed() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CuttingSpeed
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_CuttingSpeed = Value
        End Set
    End Property

    Public Property NeedsPathRecalculation() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_NeedsPathRecalculation
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_NeedsPathRecalculation = Value
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

    Public Property Tool() As cTool
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Tool
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cTool)
            m_Tool = Value
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

    Public Property UpdateCamPath() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_UpdateCamPath
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_UpdateCamPath = Value
        End Set
    End Property

    Public Property RetractHeight() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_RetractHeight
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_RetractHeight = Value
        End Set
    End Property

    Public Property ToolOverlap() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolOverlap
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_ToolOverlap = Value
        End Set
    End Property

    Public Property RadiusCorrection() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_RadiusCorrection
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_RadiusCorrection = Value
        End Set
    End Property

    Public Property ToolRadiusCorrection() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolRadiusCorrection
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ToolRadiusCorrection = Value
        End Set
    End Property

    Public Property ToolStartStopRetractHeight() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolStartStopRetractHeight
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ToolStartStopRetractHeight = Value
        End Set
    End Property

    Public Property ToolWorkRetractHeight() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolWorkRetractHeight
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ToolWorkRetractHeight = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----

    Public Function cainsortElements(ByRef ElementsToSort As Collection, ByRef SortedElements As Collection, CainingTolerance As Double) As String

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose:  Creates a cain of elements from a given collection where the end point
        '           of each element is the start point of the next element.
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim ElementsToSortBuffer As New Collection()
        Dim StartPointToTest As New cPoint()
        Dim EndPointToTest As New cPoint()
        Dim CainIsOpen As Boolean

        '----- Initial settings -----

        CainIsOpen = True

        '----- Beginn check if there are elemets to sort -----

        Try
            ElementsToSort.Item(1).GetType()
        Catch e As System.IndexOutOfRangeException
            Return "NoElementsToSort"
        End Try

#If DEBUG Then
        Console.WriteLine("ElementCount =" + CStr(ElementsToSort.Count))
#End If

        '----- Beginn check if there are a circle and additional elements to sort -----

        For i As Integer = 1 To ElementsToSort.Count
            If ElementsToSort.Item(i).GetType() = GetType(cCircle) And ElementsToSort.Count > 1 Then
                Return "CircleWasFound"
            End If
        Next

        For i As Integer = 1 To ElementsToSort.Count
            Select Case ElementsToSort.Item(i).GetType()
                Case GetType(cLine)
                    ElementsToSortBuffer.Add(New cLine(ElementsToSort.Item(i)))
                Case GetType(cArc)
                    ElementsToSortBuffer.Add(New cArc(ElementsToSort.Item(i)))
            End Select
        Next

#If DEBUG Then
        Console.WriteLine("ElementsToSortBufferCount =" + CStr(ElementsToSortBuffer.Count))
#End If

        '----- Check if the cain is open -----

        For i As Integer = 1 To ElementsToSortBuffer.Count

            StartPointToTest.X = ElementsToSortBuffer.Item(i).m_X1
            StartPointToTest.Y = ElementsToSortBuffer.Item(i).m_Y1
            StartPointToTest.Z = ElementsToSortBuffer.Item(i).m_Z1
            EndPointToTest.X = ElementsToSortBuffer.Item(i).m_X2
            EndPointToTest.Y = ElementsToSortBuffer.Item(i).m_Y2
            EndPointToTest.Z = ElementsToSortBuffer.Item(i).m_Z2
            For j As Integer = 1 To ElementsToSortBuffer.Count
                If j <> i Then
                    If ((ElementsToSortBuffer.Item(j).m_X1 = StartPointToTest.X) And _
                       (ElementsToSortBuffer.Item(j).m_Y1 = StartPointToTest.Y) And _
                       (ElementsToSortBuffer.Item(j).m_Z1 = StartPointToTest.Z)) Or _
                       ((ElementsToSortBuffer.Item(j).m_X2 = StartPointToTest.X) And _
                       (ElementsToSortBuffer.Item(j).m_Y2 = StartPointToTest.Y) And _
                       (ElementsToSortBuffer.Item(j).m_Z2 = StartPointToTest.Z)) Then

                        CainIsOpen = False
                        Exit For
                    End If
                End If
            Next
            If CainIsOpen = True Then
                Select Case ElementsToSortBuffer.Item(i).GetType()
                    Case GetType(cLine)
                        SortedElements.Add(New cLine(ElementsToSortBuffer.Item(i)))
                    Case GetType(cArc)
                        SortedElements.Add(New cArc(ElementsToSortBuffer.Item(i)))
                End Select
                ElementsToSortBuffer.Remove(i)
                Exit For
            End If
            If CainIsOpen = False Then
                CainIsOpen = True
                For j As Integer = 1 To ElementsToSortBuffer.Count
                    If j <> i Then
                        If ((ElementsToSortBuffer.Item(j).m_X1 = EndPointToTest.X) And _
                           (ElementsToSortBuffer.Item(j).m_Y1 = EndPointToTest.Y) And _
                           (ElementsToSortBuffer.Item(j).m_Z1 = EndPointToTest.Z)) Or _
                           ((ElementsToSortBuffer.Item(j).m_X2 = EndPointToTest.X) And _
                            (ElementsToSortBuffer.Item(j).m_Y2 = EndPointToTest.Y) And _
                            (ElementsToSortBuffer.Item(j).m_Z2 = EndPointToTest.Z)) Then

                            CainIsOpen = False
                            Exit For
                        End If
                    End If
                Next
            End If
            If CainIsOpen = True Then
                Select Case ElementsToSortBuffer.Item(i).GetType()
                    Case GetType(cLine)
                        SortedElements.Add(New cLine(ElementsToSortBuffer.Item(i)))
                    Case GetType(cArc)
                        SortedElements.Add(New cArc(ElementsToSortBuffer.Item(i)))
                End Select
                ElementsToSortBuffer.Remove(i)
                Exit For
            End If
            CainIsOpen = True 'For the next round
        Next

#If DEBUG Then
        Console.WriteLine("SortedElementsCount =" + CStr(SortedElements.Count))
#End If

        '----- Add the first element from ElementsToSortBuffer to ElementsToSort if cain is closed. 
        '      It will be the element where the cam path starts -----

        If SortedElements.Count < 1 Then
            Select Case ElementsToSortBuffer.Item(1).GetType()
                Case GetType(cLine)
                    SortedElements.Add(New cLine(ElementsToSortBuffer.Item(1)))
                Case GetType(cArc)
                    SortedElements.Add(New cArc(ElementsToSortBuffer.Item(1)))
            End Select
            ElementsToSortBuffer.Remove(1)
        End If

        '----- Sort it -----

        Do While 1

            StartPointToTest.X = SortedElements.Item(SortedElements.Count).m_X1
            StartPointToTest.Y = SortedElements.Item(SortedElements.Count).m_Y1
            StartPointToTest.Z = SortedElements.Item(SortedElements.Count).m_Z1
            EndPointToTest.X = SortedElements.Item(SortedElements.Count).m_X2
            EndPointToTest.Y = SortedElements.Item(SortedElements.Count).m_Y2
            EndPointToTest.Z = SortedElements.Item(SortedElements.Count).m_Z2
            For j As Integer = 1 To ElementsToSortBuffer.Count
                If (ElementsToSortBuffer.Item(j).m_X1 = StartPointToTest.X And
                    ElementsToSortBuffer.Item(j).m_Y1 = StartPointToTest.Y) Or
                    (ElementsToSortBuffer.Item(j).m_X2 = StartPointToTest.X And
                    ElementsToSortBuffer.Item(j).m_Y2 = StartPointToTest.Y) Or
                    (ElementsToSortBuffer.Item(j).m_X1 = EndPointToTest.X And
                    ElementsToSortBuffer.Item(j).m_Y1 = EndPointToTest.Y) Or
                    (ElementsToSortBuffer.Item(j).m_X2 = EndPointToTest.X And
                    ElementsToSortBuffer.Item(j).m_Y2 = EndPointToTest.Y) Then

                    Select Case ElementsToSortBuffer.Item(j).GetType()
                        Case GetType(cLine)
                            SortedElements.Add(New cLine(ElementsToSortBuffer.Item(j)))
                        Case GetType(cArc)
                            SortedElements.Add(New cArc(ElementsToSortBuffer.Item(j)))
                    End Select
                    ElementsToSortBuffer.Remove(j)
                    Exit For
                End If
            Next
            If ElementsToSortBuffer.Count < 1 Then
                Exit Do
            End If
        Loop

#If DEBUG Then
        Console.WriteLine("Sortierte Elemente: " + CStr(SortedElements.Count))
#End If

        Return "Ok"
    End Function

End Class
