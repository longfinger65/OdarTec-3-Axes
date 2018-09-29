Option Explicit On
Option Infer Off

Public Class cTool
    '----- Begin description -----------------------------------------------------------


    '----- End description -------------------------------------------------------------

    '----- Constructor ----------------------------------------------------

    Public Sub New()

    End Sub

    Public Sub New(ToolDiameter As Double)
        m_ToolDiameter = ToolDiameter

    End Sub

    Public Sub New(ToolNumber As Integer, _
                   ToolName As String, _
                   ToolTyp As String, _
                   ToolDiameter As Double, _
                   ShaftDiameter1 As Double, _
                   ShaftDiameter2 As Double, _
                   CornerRadius As Double, _
                   ChamferSize As Double,
                   ChamferAngle As Double,
                   NumberOfCuttingEdges As Integer, _
                   CuttingLength As Double, _
                   ToolMaterial As String, _
                   ToolCoating As String, _
                   CenterCut As Boolean, _
                   InnerCooling As Boolean, _
                   MaxWorkPieceHardness As Integer)

        Me.ToolNumber = ToolNumber
        Me.ToolName = ToolName
        Me.ToolTyp = ToolTyp
        Me.ToolLength = ToolLength
        Me.ToolDiameter = ToolDiameter
        Me.ShaftDiameter1 = ShaftDiameter1
        Me.ShaftDiameter2 = ShaftDiameter2
        Me.CornerRadius = CornerRadius
        Me.ChamferSize = ChamferSize
        Me.ChamferAngle = ChamferAngle
        Me.NumberOfCuttingEdges = NumberOfCuttingEdges
        Me.CuttingLength = CuttingLength
        Me.ToolMaterial = ToolMaterial
        Me.ToolCoating = ToolCoating
        Me.CenterCut = CenterCut
        Me.InnerCooling = InnerCooling
        Me.MaxWorkPieceHardness = MaxWorkPieceHardness

    End Sub


    '----- Member Variables and constants -----------------------------------------------

    Private m_ToolNumber As Integer
    Private m_ToolName As String
    Private m_ToolTyp As String
    Private m_ToolDiameter As Double
    Private m_ToolLength As Double
    Private m_ShaftDiameter1 As Double
    Private m_ShaftDiameter2 As Double
    Private m_CornerRadius As Double
    Private m_ChamferSize As Double
    Private m_ChamferAngle As Double
    Private m_NumberOfCuttingEdges As Integer
    Private m_CuttingLength As Double
    Private m_ToolMaterial As String
    Private m_ToolCoating As String
    Private m_CenterCut As Boolean
    Private m_InnerCooling As Boolean
    Private m_MaxWorkPieceHardness As Integer
    Private UseForPockets As Boolean

    '----- Get and set properties -----

    Public Property ToolNumber() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolNumber
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_ToolNumber = Value
        End Set
    End Property

    Public Property ToolName() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolName
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_ToolName = Value
        End Set
    End Property

    Public Property ToolTyp() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolTyp
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_ToolTyp = Value
        End Set
    End Property

    Public Property ToolLength() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolLength
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ToolLength = Value
        End Set
    End Property

    Public Property ToolDiameter() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolDiameter
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ToolDiameter = Value
        End Set
    End Property

    Public Property ShaftDiameter1() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ShaftDiameter1
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ShaftDiameter1 = Value
        End Set
    End Property

    Public Property ShaftDiameter2() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ShaftDiameter2
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ShaftDiameter2 = Value
        End Set
    End Property

    Public Property CornerRadius() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CornerRadius
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_CornerRadius = Value
        End Set
    End Property

    Public Property ChamferSize() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ChamferSize
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ChamferSize = Value
        End Set
    End Property

    Public Property ChamferAngle() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ChamferAngle
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ChamferAngle = Value
        End Set
    End Property

    Public Property NumberOfCuttingEdges() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_NumberOfCuttingEdges
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_NumberOfCuttingEdges = Value
        End Set
    End Property

    Public Property CuttingLength() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CuttingLength
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_CuttingLength = Value
        End Set
    End Property

    Public Property ToolMaterial() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolMaterial
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_ToolMaterial = Value
        End Set
    End Property

    Public Property ToolCoating() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolCoating
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_ToolCoating = Value
        End Set
    End Property

    Public Property CenterCut() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_CenterCut
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)

            m_CenterCut = Value
        End Set
    End Property

    Public Property InnerCooling() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_InnerCooling
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_InnerCooling = Value
        End Set
    End Property

    Public Property MaxWorkPieceHardness() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_MaxWorkPieceHardness
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_MaxWorkPieceHardness = Value
        End Set
    End Property

    '----- End member variables ----------------------------------------------


End Class
