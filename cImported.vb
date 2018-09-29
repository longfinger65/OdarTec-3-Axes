Option Explicit On
Option Infer Off

Imports System.Collections

Public Class cImported
    Inherits cObjectEntity

    '----- Constructor ----------------------------------------------------

    Public Sub New()

        m_Imported = New Collection()

        '----- Initializations -----

        IsActive = False
        Name = ""

    End Sub

    Public Sub New(Number As Integer)
        Me.New()
        Me.Number = Number
    End Sub


    '----- Begin member variables and constants -----------------------------------------------

    Private m_Number As Integer
    Private m_Name As String
    Private m_IsActive As Boolean
    Private m_Imported As Collection

    '----- Get and set properties -----

    Public Property Number() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Number
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_Number = Value
        End Set
    End Property

    Public Property Name() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Name
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_Name = Value
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

    Public Property Imported() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Imported
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_Imported = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----

    Public Function addElement(Element As cCADObject) As String

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose:  Adds triangles to this imported feature and sets the "NameOfEntity" and "TypeOfEntity
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

            Case GetType(cPointArray)
                Do
                    k += 1
                Loop Until (Imported.Contains("PointArray" + CStr(k)) = False)
                Imported.Add(Element, "PointArray" + CStr(k))
                Imported.Item(Imported.Count).Name = NameOfEntity
                Imported.Item(Imported.Count).NameOfEntity = "PointArray" + CStr(k)
                Imported.Item(Imported.Count).TypeOfEntity = "PointArray"
                ElementKey = "PointArray" + CStr(k)

        End Select

        Return ElementKey
    End Function

End Class
