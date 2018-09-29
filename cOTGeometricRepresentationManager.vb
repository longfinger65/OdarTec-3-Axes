Public Class cOTGeometricRepresentationManager

    Public Sub New()

        m_Angle = New cPoint(0, 0, 0)
        m_Displacement = New cPoint(0, 0, 0)
        m_ZoomStart = New cPoint()
        m_MoveStart = New cPoint()

        '----- Initialization -----

        ZoomFactor = 1
        ZoomFactorOld = 1

    End Sub


    Private m_Angle As cPoint
    Private m_Displacement As cPoint
    Private m_ZoomStart As cPoint
    Private m_MoveStart As cPoint
    Private m_ZoomFactor As Double
    Private m_ZoomFactorOld As Double

    '----- Get and set properties -----

    Public Property Angle() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Angle
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_Angle = Value
        End Set
    End Property

    Public Property Displacement() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_Displacement
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_Displacement = Value
        End Set
    End Property

    Public Property ZoomStart() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ZoomStart
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            ZoomFactorOld = 0
            m_ZoomStart = Value
        End Set
    End Property

    Public Property MoveStart() As cPoint
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_MoveStart
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As cPoint)
            m_MoveStart = Value
        End Set
    End Property

    Public Property ZoomFactor() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ZoomFactor
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ZoomFactor = Value
        End Set
    End Property

    Public Property ZoomFactorOld() As Double
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ZoomFactorOld
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Double)
            m_ZoomFactorOld = Value
        End Set
    End Property

    '----- End member variables and constants, begin member methodes -----


    Public Function TransformationStart(StartPoint As Point) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Sets the start points for the actual transformation.
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        ZoomStart.X = StartPoint.X
        ZoomStart.Y = StartPoint.Y
        MoveStart.X = StartPoint.X
        MoveStart.Y = StartPoint.Y

        Return True
    End Function

    Public Function transformPoint(X As Double, Y As Double, Z As Double) As Double()

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Check if the pocket outline intersects the tool outline
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim TransformedPoint(2) As Double

        '----- Rotate about x-axis -----

        TransformedPoint(0) = 1 * X + 0 * Y + 0 * Z
        TransformedPoint(1) = 0 * X + Math.Cos(Angle.X * 2 * Math.PI / 360) * Y - Math.Sin(Angle.X * 2 * Math.PI / 360) * Z
        TransformedPoint(2) = 0 * X + Math.Sin(Angle.X * 2 * Math.PI / 360) * Y + Math.Cos(Angle.X * 2 * Math.PI / 360) * Z

        '----- Rotate about y-axis -----

        TransformedPoint(0) = Math.Cos(Angle.Y * 2 * Math.PI / 360) * TransformedPoint(0) + 0 * TransformedPoint(1) + Math.Sin(Angle.Y * 2 * Math.PI / 360) * TransformedPoint(2)
        TransformedPoint(1) = 0 * TransformedPoint(0) + 1 * TransformedPoint(1) + 0 * TransformedPoint(2)
        TransformedPoint(2) = (-Math.Sin(Angle.Y * 2 * Math.PI / 360)) * TransformedPoint(0) + 0 * TransformedPoint(1) + Math.Cos(Angle.Y * 2 * Math.PI / 360) * TransformedPoint(2)

        '----- Rotate about z-axis -----

        TransformedPoint(0) = Math.Cos(Angle.Z * 2 * Math.PI / 360) * TransformedPoint(0) - Math.Sin(Angle.Z * 2 * Math.PI / 360) * TransformedPoint(1) + 0 * TransformedPoint(2)
        TransformedPoint(1) = Math.Sin(Angle.Z * 2 * Math.PI / 360) * TransformedPoint(0) + Math.Cos(Angle.Z * 2 * Math.PI / 360) * TransformedPoint(1) + 0 * TransformedPoint(2)
        TransformedPoint(2) = 0 * TransformedPoint(0) + 0 * TransformedPoint(1) + 1 * TransformedPoint(2)

        TransformedPoint(0) = TransformedPoint(0) * ZoomFactor
        TransformedPoint(1) = TransformedPoint(1) * ZoomFactor
        TransformedPoint(2) = TransformedPoint(2) * ZoomFactor

        TransformedPoint(0) = (TransformedPoint(0) + Displacement.X) '* ZoomFactor
        TransformedPoint(1) = (TransformedPoint(1) + Displacement.Y) '* ZoomFactor
        TransformedPoint(2) = (TransformedPoint(2) + Displacement.Z) '* ZoomFactor

        Return TransformedPoint
    End Function

    Public Function tP(X As Double, Y As Double, Z As Double) As Double()


        Return transformPoint(X, Y, Z)
    End Function

    Public Function tPX(PointX As Double) As Double

        Return transformPoint(PointX, 0, 0)(0)
    End Function

    Public Function tPY(PointY As Double) As Double

        Return transformPoint(PointY, 0, 0)(1)
    End Function

    Public Function tPZ(PointZ As Double) As Double

        Return transformPoint(PointZ, 0, 0)(2)
    End Function

    Public Function tPB(X As Double, Y As Double, Z As Double) As Double()

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: transformPointBackward
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Dim UntransformedPoint(2) As Double

        UntransformedPoint(0) = X - Displacement.X
        UntransformedPoint(1) = Y - Displacement.Y
        UntransformedPoint(2) = Z - Displacement.Z

        UntransformedPoint(0) = UntransformedPoint(0) / ZoomFactor
        UntransformedPoint(1) = UntransformedPoint(1) / ZoomFactor
        UntransformedPoint(2) = UntransformedPoint(2) / ZoomFactor

        '----- Rotate about x-axis -----

        UntransformedPoint(0) = 1 * UntransformedPoint(0) + 0 * UntransformedPoint(1) + 0 * UntransformedPoint(2)
        UntransformedPoint(1) = 0 * UntransformedPoint(0) + Math.Cos(Angle.X * 2 * Math.PI / 360) * UntransformedPoint(1) - Math.Sin(Angle.X * 2 * Math.PI / 360) * UntransformedPoint(2)
        UntransformedPoint(2) = 0 * UntransformedPoint(2) - Math.Sin(Angle.X * 2 * Math.PI / 360) * UntransformedPoint(1) + Math.Cos(Angle.X * 2 * Math.PI / 360) * UntransformedPoint(2)

        '----- Rotate about y-axis -----

        UntransformedPoint(0) = Math.Cos(Angle.Y * 2 * Math.PI / 360) * UntransformedPoint(0) + 0 * UntransformedPoint(1) + (-Math.Sin(Angle.Y * 2 * Math.PI / 360)) * UntransformedPoint(2)
        UntransformedPoint(1) = 0 * UntransformedPoint(0) + 1 * UntransformedPoint(1) + 0 * UntransformedPoint(2)
        UntransformedPoint(2) = Math.Sin(Angle.Y * 2 * Math.PI / 360) * UntransformedPoint(0) + 0 * UntransformedPoint(1) + Math.Cos(Angle.Y * 2 * Math.PI / 360) * UntransformedPoint(2)

        '----- Rotate about z-axis -----

        UntransformedPoint(0) = Math.Cos(Angle.Z * 2 * Math.PI / 360) * UntransformedPoint(0) + Math.Sin(Angle.Z * 2 * Math.PI / 360) * UntransformedPoint(1) + 0 * UntransformedPoint(2)
        UntransformedPoint(1) = (-Math.Sin(Angle.Z * 2 * Math.PI / 360)) * UntransformedPoint(0) + Math.Cos(Angle.Z * 2 * Math.PI / 360) * UntransformedPoint(1) + 0 * UntransformedPoint(2)
        UntransformedPoint(2) = 0 * UntransformedPoint(0) + 0 * UntransformedPoint(1) + 1 * UntransformedPoint(2)

        Return UntransformedPoint
    End Function

    Public Function tPBX(TransformedPointX As Double) As Double

        Return tPB(TransformedPointX, 0, 0)(0)
    End Function

    Public Function tPBY(TransformedPointY As Double) As Double

        Return tPB(TransformedPointY, 0, 0)(1)
    End Function

    Public Function tPBZ(TransformedPointZ As Double) As Double

        Return tPB(TransformedPointZ, 0, 0)(2)
    End Function

    Public Function actualizeTransformation(MousePosition As Point, KindOfMove As String) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Check if the pocket outline intersects the tool outline
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        '----- End description ---------------------------------------------------------

        Select Case KindOfMove
            Case "none"
                Displacement.X = Displacement.X + (MousePosition.X - MoveStart.X) / ZoomFactor
                Displacement.Y = Displacement.Y + (MousePosition.Y - MoveStart.Y) / ZoomFactor
                MoveStart.X = MousePosition.X
                MoveStart.Y = MousePosition.Y
            Case "rotate"
                If MousePosition.Y > MoveStart.Y Then
                    Angle.X -= 7
                    If Angle.X < 0 Then
                        Angle.X = 360 - Math.Abs(Angle.X)
                    End If
                Else
                    Angle.X += 7
                    If Angle.X > 360 Then
                        Angle.X = Angle.X - 360
                    End If
                End If
                If MousePosition.X > MoveStart.X Then
                    Angle.Y += 7
                    If Angle.Y > 360 Then
                        Angle.Y = Angle.Y - 360
                    End If
                Else
                    Angle.Y -= 7
                    If Angle.Y < 0 Then
                        Angle.Y = 360 - Math.Abs(Angle.Y)
                    End If
                End If
                MoveStart.X = MousePosition.X
                MoveStart.Y = MousePosition.Y
            Case "zoom"
                If MousePosition.Y > MoveStart.Y Then
                    ZoomFactor -= 0.1
                Else
                    ZoomFactor += 0.1
                End If
                If ZoomFactorOld <> 0 Then
                    Displacement.X = Displacement.X + (ZoomStart.X - ZoomStart.X / ZoomFactorOld)
                    Displacement.Y = Displacement.Y + (ZoomStart.X - ZoomStart.Y / ZoomFactorOld)
                End If
                Displacement.X = Displacement.X - (ZoomStart.X - ZoomStart.X / ZoomFactor)
                Displacement.Y = Displacement.Y - (ZoomStart.X - ZoomStart.Y / ZoomFactor)
                ZoomFactorOld = ZoomFactor
                MoveStart.Y = MousePosition.Y
        End Select

        Return True
    End Function

End Class
