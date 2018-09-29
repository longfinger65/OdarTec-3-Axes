Public Class cOTString


    '----- Begin description -----------------------------------------------------------


    '----- End description -------------------------------------------------------------

    '----- Constructor -----------------------------------------------------------------


    Public Sub New(InitialValue As String)


        '----- Initial settings -----

        VString = InitialValue
    End Sub


    '----- Member Variables and constants ----------------------------------------------

    Private m_VString As String

    '----- Get and set properties -----


    Public Property VString() As String
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_VString
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As String)
            m_VString = Value
        End Set
    End Property


    '----- End member variables and constants, begin member methodes -----

    Public Function getValue() As String

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Calulates the milling path
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        ' 1. Create the outline of the tool
        ' 2. Create the outline of the pocket
        ' 3. Find max and min of the enveloping rectangle
        ' 4. Evaluate that the choosen arbitrary start point is inside the pocket
        ' 5. Check if the whole tool is inside the pocket and if this is not the
        '    case try to move the start point according 
        ' 6. According to the radius correction (RL or RR) find the path along the
        '    border
        ' 7. Simplify the milling path
        '
        '----- End description ---------------------------------------------------------

        Return VString
    End Function

    Public Function getValue(ValueToCompareWith As String) As String

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Calulates the milling path
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        ' 1. Create the outline of the tool
        ' 2. Create the outline of the pocket
        ' 3. Find max and min of the enveloping rectangle
        ' 4. Evaluate that the choosen arbitrary start point is inside the pocket
        ' 5. Check if the whole tool is inside the pocket and if this is not the
        '    case try to move the start point according 
        ' 6. According to the radius correction (RL or RR) find the path along the
        '    border
        ' 7. Simplify the milling path
        '
        '----- End description ---------------------------------------------------------

 
        '----- Initial settings -----

 
        If VString.Contains(ValueToCompareWith) Then
            Return VString
        End If


        Return "false"
    End Function


    Public Function addValue(ValueToAdd As String) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Calulates the milling path
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        ' 1. Create the outline of the tool
        ' 2. Create the outline of the pocket
        ' 3. Find max and min of the enveloping rectangle
        ' 4. Evaluate that the choosen arbitrary start point is inside the pocket
        ' 5. Check if the whole tool is inside the pocket and if this is not the
        '    case try to move the start point according 
        ' 6. According to the radius correction (RL or RR) find the path along the
        '    border
        ' 7. Simplify the milling path
        '
        '----- End description ---------------------------------------------------------

        VString = VString + ValueToAdd


        Return True
    End Function

    Public Function removeValue(ValueToRemove As String) As Boolean

        '----- Begin Description -------------------------------------------------------
        '
        ' Purpose: Calulates the milling path
        ' Input Parameter:
        ' Return Value:
        '
        '----- Steps -------------------------------------------------------------------
        '
        ' 1. Create the outline of the tool
        ' 2. Create the outline of the pocket
        ' 3. Find max and min of the enveloping rectangle
        ' 4. Evaluate that the choosen arbitrary start point is inside the pocket
        ' 5. Check if the whole tool is inside the pocket and if this is not the
        '    case try to move the start point according 
        ' 6. According to the radius correction (RL or RR) find the path along the
        '    border
        ' 7. Simplify the milling path
        '
        '----- End description ---------------------------------------------------------

        VString.Replace(ValueToRemove, "")

        Return True
    End Function

End Class
