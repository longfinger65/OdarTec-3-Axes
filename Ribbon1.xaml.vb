Imports System.Windows

Public Class UserControl1

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

    End Sub

    Public Delegate Sub UserControl1EventHandler(sender As Object, args As UserControl1EventArgs)
    Public Event OnMenuItemClick As UserControl1EventHandler

    Public Sub MeI_New2DSketch_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("MeI_New2DSketch_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub MeI_New3DSketch_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("MeI_New3DSketch_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub MeI_Save_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("MeI_Save_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub MeI_NewPart_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("MeI_NewPart_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiBu_DXFImport_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiBu_DXFImport_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiBu_PointCloudImport_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiBu_PointCloudImport_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiBu_STLImport_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiBu_STLImport_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiBu_CamPocket_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiBu_CamPocket_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiBu_CamPath_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiBu_CamPath_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiBu_CamBore_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiBu_CamBore_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiBu_SketchPoint_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiBu_SketchPoint_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiSpliBu_SketchLine_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiSpliBu_SketchLine_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiSpliBu_SketchCircleCenterPoint_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiSpliBu_SketchCircleCenterPoint_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiSpliMeI_SketchCircleCenterPoint_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiSpliBu_SketchCircleCenterPoint_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiSpliMeI_SketchLineRiSpliBu_SketchCircle3Points_Clicked_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiSpliBu_SketchCircle3Points_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiBu_CamPicture_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiBu_CamPicture_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiBu_CamFaceMilling_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiBu_CamFaceMilling_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiBu_CamScan_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiBu_CamScan_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiBu_CamScan2D_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiBu_CamScan2D_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

    Public Sub RiBu_Cam3D_Clicked(sender As Object, e As RoutedEventArgs)
        Dim Args As New UserControl1EventArgs("RiBu_Cam3D_Clicked")
        RaiseEvent OnMenuItemClick(sender, Args)
    End Sub

End Class

Public Class UserControl1EventArgs
    Inherits EventArgs

    Public mEvent As String


    Public Sub New(NameOfEvent As String)
        mEvent = NameOfEvent
    End Sub

End Class