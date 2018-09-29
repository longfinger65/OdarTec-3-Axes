Imports System.IO

Public Class cOdarTecNCProg

    '----- Constructor ----------------------------------------------------

    Public Sub New()

    End Sub


    '----- Member Variables and constants -----------------------------------------------

    Private m_StartPoint As cPoint
    Private m_EndPoint As cPoint
    Private m_SketchName As String
    Private m_SortedCamPath As New Collection

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

    Public Property EndPoint() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_EndPoint
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_EndPoint = Value
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

    Public Property SortedCamPath() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_SortedCamPath
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_SortedCamPath = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----

    Public Function fun_GenerateNCProg(ByRef Path As Object) As Boolean

        Dim NCProg() As String = New String() {}
        Dim i As Integer
        Dim x, y, z As Double
        Dim FeedRate As String
        Dim CamDescription As String
        Dim ArrayCountOffset As Integer

        '----- Initial settings -----

        FeedRate = Path.m_FeedRateRapid.ToString("0000")
        CamDescription = ""
        ArrayCountOffset = 0

        '----- Generate NC-Prog -----

        Select Case Path.GetType
            Case GetType(cCamPocket), GetType(cCamFaceMilling), GetType(cCam3D)
                If Path.Tool.ToolTyp <> "Laser" Then
                    ReDim NCProg(Path.m_CamPathArray.length + 4)
                Else
                    ReDim NCProg(Path.m_CamPathArray.length + 3)
                End If

                '--- First move to ToolStartStopHeight ---

                z = (Path.m_CamPathArray(0).Z - Path.Origin.Z)
                FeedRate = Path.m_FeedRateRapid.ToString("0000")
                NCProg(0) = New String("G1" + " Z" + z.ToString("000.00") + " F" + FeedRate)
                ArrayCountOffset += 1
                If Path.Tool.ToolTyp <> "Laser" Then
                    NCProg(1) = New String("M03")
                    ArrayCountOffset += 1
                End If

                '--- Add all other pathes ---

                For i = 0 To Path.m_CamPathArray.Length - 1
                    x = (Path.m_CamPathArray(i).X - Path.Origin.X)
                    y = (Path.m_CamPathArray(i).Y - Path.Origin.Y)
                    z = (Path.m_CamPathArray(i).Z - Path.Origin.Z)
                    If Path.m_CamPathArray(i).Annotation <> "" Then
                        CamDescription = Path.m_CamPathArray(i).Annotation
                    End If
                    Select Case CamDescription
                        Case "Work"
                            FeedRate = Path.m_FeedRateWork.ToString("0000")
                        Case "Rapid"
                            FeedRate = Path.m_FeedRateRapid.ToString("0000")
                        Case "InfeedSide"
                            FeedRate = Path.m_FeedRateInfeed.ToString("0000")
                        Case "InfeedGround"
                            FeedRate = Path.m_FeedRateInfeed.ToString("0000")
                    End Select
                    NCProg(i + ArrayCountOffset) = New String("G1 X" + x.ToString("000.00") + " Y" + y.ToString("000.00") + " Z" + z.ToString("000.00") + " F" + FeedRate)
                    If i = Path.m_CamPathArray.Length - 1 Then
                        ArrayCountOffset += (i + 1)
                    End If
                Next
            Case GetType(cCamPath)
                If Path.Tool.ToolTyp <> "Laser" Then
                    ReDim NCProg(Path.m_CamPathArray.length + 4)
                Else
                    ReDim NCProg(Path.m_CamPathArray.length + 3)
                End If

                z = (Path.m_CamPathArray(0).Z - Path.Origin.Z)
                FeedRate = Path.m_FeedRateRapid.ToString("0000")
                NCProg(0) = New String("G1" + " Z" + z.ToString("000.00") + " F" + FeedRate)
                ArrayCountOffset += 1
                If Path.Tool.ToolTyp <> "Laser" Then
                    NCProg(1) = New String("M03")
                    ArrayCountOffset += 1
                End If

                '--- Add all other pathes ---

                For i = 0 To Path.m_CamPathArray.length - 1
                    x = (Path.m_CamPathArray(i).X - Path.Origin.X)
                    y = (Path.m_CamPathArray(i).Y - Path.Origin.Y)
                    z = (Path.m_CamPathArray(i).Z - Path.Origin.Z)
                    If Path.m_CamPathArray(i).Annotation <> "" Then
                        CamDescription = Path.m_CamPathArray(i).Annotation
                    End If
                    Select Case CamDescription
                        Case "Work"
                            FeedRate = Path.m_FeedRateWork.ToString("0000.")
                            If Path.Tool.ToolTyp = "Laser" Then
                                NCProg(i + ArrayCountOffset) = New String("M07")
                                ArrayCountOffset += 1
                            End If
                        Case "Rapid"
                            FeedRate = Path.m_FeedRateRapid.ToString("0000.")
                            If Path.Tool.ToolTyp = "Laser" Then
                                NCProg(i + ArrayCountOffset) = New String("M05")
                                ArrayCountOffset += 1
                            End If
                        Case "InFeedSide"
                            FeedRate = Path.m_FeedRateInfeed.ToString("0000.")
                        Case "InfeedGround"
                            FeedRate = Path.m_FeedRateInfeed.ToString("0000.")
                    End Select
                    NCProg(i + ArrayCountOffset) = New String("G1 X" + x.ToString("000.00") + " Y" + y.ToString("000.00") + " Z" + z.ToString("000.00") + " F" + FeedRate)
                Next

#If DEBUG Then
                Console.WriteLine(Path.m_FeedRateWork)
#End If
            Case GetType(cCamBore)

                ReDim NCProg(Path.m_CamPathArray.length + 4)

                z = (Path.m_CamPathArray(0).Z - Path.Origin.Z)
                FeedRate = Path.m_FeedRateRapid.ToString("0000")
                NCProg(0) = New String("G1" + " Z" + z.ToString("000.00") + " F" + FeedRate)
                ArrayCountOffset += 1
                NCProg(1) = New String("M03")
                ArrayCountOffset += 1

                '--- Add all other pathes ---
                For i = 1 To Path.CamPath.Count
                    x = (Path.CamPath.Item(i).m_X2 - Path.Origin.X)
                    y = (Path.CamPath.Item(i).m_Y2 - Path.Origin.Y)
                    z = (Path.CamPath.Item(i).m_Z2 - Path.Origin.Z)
                    Select Case Path.CamPath.Item(i).CamDescription
                        Case "Work"
                            FeedRate = Path.m_FeedRateWork.ToString("0000")
                        Case "Rapid"
                            FeedRate = Path.m_FeedRateRapid.ToString("0000")
                        Case "Retract"
                            FeedRate = Path.m_FeedRateRetractMove.ToString("0000")
                    End Select
                    NCProg(i + ArrayCountOffset) = New String("G1 X" + x.ToString("000.00") + " Y" + y.ToString("000.00") + " Z" + z.ToString("000.00") + " F" + FeedRate)
                Next

                '--- Picture ---

            Case GetType(cCamPicture)
                If Path.Tool.ToolTyp <> "Laser" Then
                    ReDim NCProg((Path.m_CamPathArray.length) * 4 + 5)
                Else
                    ReDim NCProg((Path.m_CamPathArray.length) * 4 + 4)
                End If

                x = (Path.m_CamPathArray(0).X - Path.Origin.X)
                y = (Path.m_CamPathArray(0).Y - Path.Origin.Y)
                z = (Path.Origin.Z + Path.ToolStartStopRetractHeight)
                FeedRate = Path.FeedRateRapid.ToString("0000")
                NCProg(0) = New String("G1" + " Z" + z.ToString("000.00") + " F" + FeedRate)
                ArrayCountOffset += 1
                If Path.Tool.ToolTyp <> "Laser" Then
                    z = (Path.ToolWorkRetractHeight + Path.Origin.Z)
                    NCProg(1) = New String("M03")
                    ArrayCountOffset += 1
                    NCProg(2) = New String("G1 X" + x.ToString("000.00") + " Y" + y.ToString("000.00") + " Z" + z.ToString("000.00") + " F" + FeedRate)
                    ArrayCountOffset += 1
                Else
                    z = (Path.m_CamPathArray(0).Z + Path.Origin.Z)
                    NCProg(1) = New String("G1 X" + x.ToString("000.00") + " Y" + y.ToString("000.00") + " Z" + z.ToString("000.00") + " F" + FeedRate)
                    ArrayCountOffset += 1
                End If

                '--- Add all other pathes ---

                For i = 0 To Path.m_CamPathArray.length - 1
                    If Path.Tool.ToolTyp.contains("Laser") Then
                        x = (Path.m_CamPathArray(i).X - Path.Origin.X)
                        y = (Path.m_CamPathArray(i).Y - Path.Origin.Y)
                        z = (Path.m_CamPathArray(i).Z + Path.Origin.Z)

                        NCProg(i + ArrayCountOffset) = New String("M07")
                        FeedRate = Path.RestingTime.ToString("0000")
                        NCProg(i + ArrayCountOffset + 1) = New String("G04 F" + FeedRate) 'Resting time
                        NCProg(i + ArrayCountOffset + 2) = New String("M05")
                        FeedRate = Path.FeedRateWork.ToString("0000")
                        NCProg(i + ArrayCountOffset + 3) = New String("G1 X" + x.ToString("000.00") + " Y" + y.ToString("000.00") + " Z" + z.ToString("000.00") + " F" + FeedRate)
                        ArrayCountOffset += 3
                        If i = Path.m_CamPathArray.length - 1 Then
                            ArrayCountOffset += i
                        End If
                    Else
                        x = (Path.m_CamPathArray(i).X - Path.Origin.X)
                        y = (Path.m_CamPathArray(i).Y - Path.Origin.Y)
                        z = (Path.m_CamPathArray(i).Z + Path.Origin.Z)
                        FeedRate = Path.FeedRateGround.ToString("0000")
                        NCProg(i + ArrayCountOffset) = New String("G1 X" + x.ToString("000.00") + " Y" + y.ToString("000.00") + " Z" + z.ToString("000.00") + " F" + FeedRate)
                        ArrayCountOffset += 1
                        z = (Path.ToolWorkRetractHeight + Path.Origin.Z)
                        FeedRate = Path.FeedRateRapid.ToString("0000")
                        NCProg(i + ArrayCountOffset) = New String("G1 X" + x.ToString("000.00") + " Y" + y.ToString("000.00") + " Z" + z.ToString("000.00") + " F" + FeedRate)
                        ArrayCountOffset += 1
                        If i < Path.m_CamPathArray.length - 1 Then
                            x = (Path.m_CamPathArray(i + 1).X - Path.Origin.X)
                            y = (Path.m_CamPathArray(i + 1).Y - Path.Origin.Y)
                            FeedRate = Path.FeedRateWork.ToString("0000")
                            NCProg(i + ArrayCountOffset) = New String("G1 X" + x.ToString("000.00") + " Y" + y.ToString("000.00") + " Z" + z.ToString("000.00") + " F" + FeedRate)
                        Else
                            ArrayCountOffset += i
                        End If
                    End If
                Next
                x = (Path.m_CamPathArray(Path.m_CamPathArray.length - 1).X - Path.Origin.X)
                y = (Path.m_CamPathArray(Path.m_CamPathArray.length - 1).Y - Path.Origin.Y)
                z = (Path.Origin.Z + Path.ToolStartStopRetractHeight)
                FeedRate = Path.FeedRateRapid.ToString("0000")
                NCProg(ArrayCountOffset) = New String("G1 X" + x.ToString("000.00") + " Y" + y.ToString("000.00") + " Z" + z.ToString("000.00") + " F" + FeedRate)
                ArrayCountOffset += 1

#If DEBUG Then
                Console.WriteLine(Path.m_FeedRateWork)
#End If

        End Select

        NCProg(ArrayCountOffset) = New String("M05")
        NCProg(ArrayCountOffset + 1) = New String("G53")
        NCProg(ArrayCountOffset + 2) = New String("M02")

        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Textdateien (*.gcode)|*.gcode|Alle Dateien (*.*)|*.*"
        SaveFileDialog.Title = "Save NC-Program"
        SaveFileDialog.ShowDialog()

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim sw As StreamWriter = New StreamWriter(SaveFileDialog.OpenFile())
            If (sw IsNot Nothing) Then
                For i = 0 To NCProg.Length - 1
                    sw.WriteLine(NCProg(i))
                Next
                sw.Close()
            End If
        End If

        Return False
    End Function

End Class
