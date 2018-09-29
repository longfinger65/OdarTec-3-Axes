Public Class cCamPicture
    Inherits cCamEntity

    '----- Constructor ----------------------------------------------------

    Public Sub New()

        'PictureToMachine = New Bitmap(1, 1)

        '----- Initialization ----

        Tool.ToolName = "nothing"
        SQRTOfGrayValues = 4
        Brightness = 0.2
        RestingTime = 1
        m_EngravingThreshold = 0

    End Sub

    Public Sub New(PathRecalculation As Boolean)

        Me.New()

        NeedsPathRecalculation = PathRecalculation
    End Sub


    '----- Member Variables and constants -----------------------------------------------

    Private m_PathNumber As Integer
    Private m_ZInfeed As Double
    Private m_Advance1 As Double
    Private m_Advance2 As Double
    Private m_Advance3 As Double
    Public m_FeedRate As Integer
    Public m_FeedRateRetractMove As Integer
    Private m_PixelSize As Double
    Private m_Brightness As Double
    Private m_SQRTOfGrayValues As Integer
    Public m_RestingTime As Integer
    Public m_PictureToMachine As Bitmap
    Private m_PreviewPicture As Bitmap
    Private m_PreviewBackgroundColor As Color
    Private m_PreviewEngraveColor As Color
    Private m_DepthOfEngraving As Double
    Private m_PositivePictureRepresentation As Boolean = True
    Private m_ToolTipAngle As Double
    Public m_CamPathArray() As cSimplePoint = New cSimplePoint() {}
    Private m_EngravingThreshold As Double                      'The "DepthOfEngraving" value is bigger (means less deep) the "DepthOfEngraving is set to 0

    '----- Get and set properties -----

    Public Property PathNumber() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PathNumber
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_PathNumber = Value
        End Set
    End Property

    Public Property ZInfeed() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ZInfeed
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ZInfeed = Value
        End Set
    End Property

    Public Property PixelSize() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PixelSize
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_PixelSize = Value
        End Set
    End Property

    Public Property Brightness() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Brightness
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_Brightness = Value
        End Set
    End Property

    Public Property SQRTOfGrayValues() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_SQRTOfGrayValues
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_SQRTOfGrayValues = Value
        End Set
    End Property

    Public Property RestingTime() As Integer
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_RestingTime
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Integer)
            m_RestingTime = Value
        End Set
    End Property

    Public Property PictureToMachine() As Bitmap
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PictureToMachine
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Bitmap)
            m_PictureToMachine = Value
        End Set
    End Property

    Public Property PreviewPicture() As Bitmap
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PreviewPicture
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Bitmap)
            m_PreviewPicture = Value
        End Set
    End Property

    Public Property PreviewBackgroundColor() As Color
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PreviewBackgroundColor
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Color)
            m_PreviewBackgroundColor = Value
        End Set
    End Property

    Public Property PreviewEngraveColor() As Color
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PreviewEngraveColor
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Color)
            m_PreviewEngraveColor = Value
        End Set
    End Property

    Public Property DepthOfEngraving() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_DepthOfEngraving
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_DepthOfEngraving = Value
        End Set
    End Property

    Public Property PositivePictureRepresentation() As Boolean
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_PositivePictureRepresentation
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Boolean)
            m_PositivePictureRepresentation = Value
        End Set
    End Property

    Public Property ToolTipAngle() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolTipAngle
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ToolTipAngle = Value
        End Set
    End Property

    Public Property EngravingThreshold() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_EngravingThreshold
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_EngravingThreshold = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----

    Public Function calculateCamPath(KindOfCalculation As String) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Calulates the milling path
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------

        '----- Find the width of the picture -----

        Dim PictureWidth, PictureHeight As Integer
        Dim SinglePixelBuffer(255) As Integer
        Dim StepWidth As Double
        Dim CamPictureBuffer() As cSimplePoint = New cSimplePoint() {}
        Dim DirectionToggler As Integer
        Dim DirectionTogglerForLaser As Integer
        Dim GrayValue As Double
        Dim RealPixelProEngravingPixel As Integer
        Dim ActualEngravePixelSize As Integer
        Dim Offset As Integer                           'Offset in pixel for the dots if engraving with any other tool than laser is choosen
        Dim ActualDepthOfEgraving As Double
        Dim ArrayCount As Integer
        Dim HorizontalStart As Integer
        Dim HorizontalStop As Integer
        Dim HorizontalStartForLaser As Integer
        Dim HorizontalStopForLaser As Integer

        '----- Initial settings -----

        ArrayCount = -1
        DirectionToggler = 1
        DirectionTogglerForLaser = 1
        PictureWidth = PictureToMachine.Width
        PictureHeight = PictureToMachine.Height
        ToolTipAngle = 40
        RealPixelProEngravingPixel = CInt(PixelSize * 10)
        Offset = CInt(RealPixelProEngravingPixel / 2)
        HorizontalStart = 0
        HorizontalStop = PictureWidth - 1
        HorizontalStartForLaser = 0
        HorizontalStopForLaser = m_SQRTOfGrayValues * PictureWidth - 1

        ReDim CamPictureBuffer(PictureWidth * PictureHeight * m_SQRTOfGrayValues ^ 2 + 10)
        ReDim m_CamPathArray(PictureWidth * PictureHeight * m_SQRTOfGrayValues ^ 2 + 10)

        '-----

        Dim PixelLineBuffer(PictureWidth * m_SQRTOfGrayValues - 1, m_SQRTOfGrayValues - 1)

        For i As Integer = PictureHeight - 1 To 0 Step -1

            '----- Fill PixelLineBuffer with zeros -----

            ReDim PixelLineBuffer(0, 0)
            ReDim PixelLineBuffer(PictureWidth * m_SQRTOfGrayValues - 1, m_SQRTOfGrayValues - 1)

            For j As Integer = HorizontalStart To HorizontalStop Step DirectionToggler

                '--- Fill SinglePixelBuffer with zeros ---

                'ReDim SinglePixelBuffer(0)
                ReDim SinglePixelBuffer(m_SQRTOfGrayValues ^ 2 - 1)

                '--- Calculate gray values ---

                GrayValue = ((Utilities.getRGBColor(PictureToMachine.GetPixel(j, i))(0) + Utilities.getRGBColor(PictureToMachine.GetPixel(j, i))(1) + Utilities.getRGBColor(PictureToMachine.GetPixel(j, i))(2)) / 3) * m_Brightness
                If GrayValue > 256 Then
                    GrayValue = 256
                End If
                GrayValue = GrayValue * m_SQRTOfGrayValues ^ 2 / 256

                If (((Utilities.getRGBColor(PictureToMachine.GetPixel(j, i))(0) + Utilities.getRGBColor(PictureToMachine.GetPixel(j, i))(1) + Utilities.getRGBColor(PictureToMachine.GetPixel(j, i))(2)) / 3) * m_Brightness) <> 256 Then
                    StepWidth = m_SQRTOfGrayValues ^ 2 / (m_SQRTOfGrayValues ^ 2 - (((Utilities.getRGBColor(PictureToMachine.GetPixel(j, i))(0) + Utilities.getRGBColor(PictureToMachine.GetPixel(j, i))(1) + Utilities.getRGBColor(PictureToMachine.GetPixel(j, i))(2)) / 3)) * m_Brightness * m_SQRTOfGrayValues ^ 2 / 256)
                Else
                    StepWidth = m_SQRTOfGrayValues ^ 2
                End If

                If KindOfCalculation.Contains("Laser") Then

                    '--- Fill SinglePixelBuffer according to the gray value of a pixel ---

                    For k As Integer = 0 To m_SQRTOfGrayValues ^ 2 - 1 Step StepWidth
                        SinglePixelBuffer(CInt(k)) = 1
                    Next

                    '--- Transfer SinglePixelBuffer to PixelLineBuffer ---

                    For o As Integer = 0 To m_SQRTOfGrayValues - 1
                        For p As Integer = 0 To m_SQRTOfGrayValues - 1
                            PixelLineBuffer(j * m_SQRTOfGrayValues + p, o) = SinglePixelBuffer(o * m_SQRTOfGrayValues + p)
                        Next
                    Next
                Else 'If no laser tool is choosen

                    '--- Determine depth of engraving according to the gray value and save the result for this pixle ---

                    If KindOfCalculation = "OtherPreview" Then

                        '--- Calculate the preview picture ---

                        For v As Integer = 0 To RealPixelProEngravingPixel - 1
                            For w As Integer = 0 To RealPixelProEngravingPixel - 1
                                m_PreviewPicture.SetPixel(j * RealPixelProEngravingPixel + w, i * RealPixelProEngravingPixel + v, m_PreviewBackgroundColor)
                            Next
                        Next
                        If PositivePictureRepresentation = True Then
                            ActualEngravePixelSize = CInt(Math.Tan((ToolTipAngle / 2) / 360 * 2 * Math.PI) * (DepthOfEngraving - (DepthOfEngraving * GrayValue / SQRTOfGrayValues ^ 2)) * (-20))   '"-2" to make the result positive
                        Else
                            ActualEngravePixelSize = CInt(Math.Tan((ToolTipAngle / 2) / 360 * 2 * Math.PI) * ((DepthOfEngraving * GrayValue / SQRTOfGrayValues ^ 2)) * (-20))   '"-2" to make the result positive
                        End If
                        'Console.WriteLine(ActualEngravePixelSize)
                        For v As Integer = 0 To ActualEngravePixelSize - 1
                            For w As Integer = 0 To ActualEngravePixelSize - 1
                                m_PreviewPicture.SetPixel(j * RealPixelProEngravingPixel + CInt(Offset - ActualEngravePixelSize / 2) + w, i * RealPixelProEngravingPixel + CInt(Offset - ActualEngravePixelSize / 2) + v, m_PreviewEngraveColor)
                            Next
                        Next

                    Else

                        '--- Calculate the engraving points and fill the m_CamPathArray for milling ---

                        If PositivePictureRepresentation = True Then
                            ActualDepthOfEgraving = DepthOfEngraving - (DepthOfEngraving * GrayValue / SQRTOfGrayValues ^ 2)
                            If ActualDepthOfEgraving < EngravingThreshold Then
                                ArrayCount += 1
                                m_CamPathArray(ArrayCount) = New cSimplePoint((j * PixelSize), ((PictureHeight - 1 - i) * PixelSize), ActualDepthOfEgraving, "InfeedGround")
                            End If
                        Else
                            ActualDepthOfEgraving = (DepthOfEngraving * GrayValue / SQRTOfGrayValues ^ 2)
                            If ActualDepthOfEgraving < EngravingThreshold Then
                                ArrayCount += 1
                                m_CamPathArray(ArrayCount) = New cSimplePoint((j * PixelSize), ((PictureHeight - 1 - i) * PixelSize), ActualDepthOfEgraving, "InfeedGround")
                            End If
                        End If
                    End If
                End If
            Next

            '--- Calculate the preview picture or fill the m_CamPathArray to laser the picture if kind of tool contains laser ---

            If KindOfCalculation.Contains("Laser") Then
                For m As Integer = 0 To m_SQRTOfGrayValues - 1
                    For l As Integer = HorizontalStartForLaser To HorizontalStopForLaser Step DirectionTogglerForLaser
                        'Console.WriteLine("aha")
                        If PixelLineBuffer(l, m) = 1 Then
                            If KindOfCalculation = "Laser" Then
                                ArrayCount += 1
                                m_CamPathArray(ArrayCount) = New cSimplePoint((l * PixelSize / m_SQRTOfGrayValues) + (PixelSize / m_SQRTOfGrayValues), ((PictureHeight - 1 - i) * PixelSize + (m * PixelSize / m_SQRTOfGrayValues)), 0, "Work")
                            ElseIf KindOfCalculation = "LaserPreview" Then
                                m_PreviewPicture.SetPixel(l, i * m_SQRTOfGrayValues + m, m_PreviewEngraveColor)
                            End If
                        Else
                            If KindOfCalculation = "LaserPreview" Then
                                m_PreviewPicture.SetPixel(l, i * m_SQRTOfGrayValues + m, m_PreviewBackgroundColor)
                            End If
                        End If
                    Next

                    DirectionTogglerForLaser *= (-1) 'Change direction of calculation to shorten path ways
                    If DirectionTogglerForLaser = 1 Then
                        HorizontalStartForLaser = 0
                        HorizontalStopForLaser = m_SQRTOfGrayValues * PictureWidth - 1
                    Else
                        HorizontalStartForLaser = m_SQRTOfGrayValues * PictureWidth - 1
                        HorizontalStopForLaser = 0
                    End If
                Next
            End If

            DirectionToggler *= (-1) 'Change direction of calculation to shorten path ways
            If DirectionToggler = 1 Then
                HorizontalStart = 0
                HorizontalStop = PictureWidth - 1
            Else
                HorizontalStart = PictureWidth - 1
                HorizontalStop = 0
            End If
        Next

        If KindOfCalculation.Contains("Preview") Then
            Return True
        Else

            '--- Redim the CamPathArray so that it contains only valid values
#If DEBUG Then
            Console.WriteLine(m_CamPathArray.Length)
#End If
            ReDim Preserve m_CamPathArray(ArrayCount)
#If DEBUG Then
            Console.WriteLine(m_CamPathArray.Length)
#End If

            '---

        End If

        Return True
    End Function

End Class
