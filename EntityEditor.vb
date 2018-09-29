Imports System.Windows.Forms

Public Class EntityEditor

    Public Sub New(ByRef ObjectToEdit As Object, WhatEntityToEdit As String)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        Me.ObjectToEdit = ObjectToEdit
        Me.WhatEntityToEdit = WhatEntityToEdit

    End Sub

    '----- Member Variables and constants -----------------------------

    Private m_ObjectToEdit As cCADObject
    Private m_WhatEntityToEdit As String

    '----- Begin properties -----

    Public Property ObjectToEdit() As Object
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ObjectToEdit
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Object)
            m_ObjectToEdit = Value
        End Set
    End Property

    Public Property WhatEntityToEdit() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_WhatEntityToEdit
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_WhatEntityToEdit = Value
        End Set
    End Property

    '----- End member variables, begin member methodes ----------------------

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Select Case WhatEntityToEdit
            Case "Startpoint"
                ObjectToEdit.m_X1 = CDbl(TeBo_EditEntityX.Text)
                ObjectToEdit.m_Y1 = CDbl(TeBo_EditEntityY.Text)
                ObjectToEdit.m_Z1 = CDbl(TeBo_EditEntityZ.Text)
            Case "Endpoint"
                ObjectToEdit.m_X2 = CDbl(TeBo_EditEntityX.Text)
                ObjectToEdit.m_Y2 = CDbl(TeBo_EditEntityY.Text)
                ObjectToEdit.m_Z2 = CDbl(TeBo_EditEntityZ.Text)
            Case "Circle"
                ObjectToEdit.m_XC = CDbl(TeBo_EditEntityX.Text)
                ObjectToEdit.m_YC = CDbl(TeBo_EditEntityY.Text)
                ObjectToEdit.m_ZC = CDbl(TeBo_EditEntityZ.Text)
                ObjectToEdit.m_Radius = CDbl(TeBo_EditEntityRadius.Text)
            Case "Point"
                ObjectToEdit.m_X = CDbl(TeBo_EditEntityX.Text)
                ObjectToEdit.m_Y = CDbl(TeBo_EditEntityY.Text)
                ObjectToEdit.m_Z = CDbl(TeBo_EditEntityZ.Text)
        End Select
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EntityEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case WhatEntityToEdit
            Case "Startpoint"
                TeBo_EditEntityX.Text = ObjectToEdit.m_X1
                TeBo_EditEntityY.Text = ObjectToEdit.m_Y1
                TeBo_EditEntityZ.Text = ObjectToEdit.m_Z1
                TeBo_EditEntityRadius.Visible = False
                Lab_Radius.Visible = False
            Case "Endpoint"
                TeBo_EditEntityX.Text = ObjectToEdit.m_X2
                TeBo_EditEntityY.Text = ObjectToEdit.m_Y2
                TeBo_EditEntityZ.Text = ObjectToEdit.m_Z2
                TeBo_EditEntityRadius.Visible = False
                Lab_Radius.Visible = False
            Case "Circle"
                TeBo_EditEntityX.Text = ObjectToEdit.m_XC
                TeBo_EditEntityY.Text = ObjectToEdit.m_YC
                TeBo_EditEntityZ.Text = ObjectToEdit.m_ZC
                TeBo_EditEntityRadius.Text = ObjectToEdit.m_Radius
                TeBo_EditEntityRadius.Visible = True
                Lab_Radius.Visible = True
            Case "Point"
                TeBo_EditEntityX.Text = ObjectToEdit.m_X
                TeBo_EditEntityY.Text = ObjectToEdit.m_Y
                TeBo_EditEntityZ.Text = ObjectToEdit.m_Z
                TeBo_EditEntityRadius.Visible = False
                Lab_Radius.Visible = False
        End Select

    End Sub
End Class
