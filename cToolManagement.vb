Imports MySql
Imports MySql.Data
Imports MySql.Data.MySqlClient


Public Class cToolManagement

    Public Sub New()

        m_ToolsList = New Collection()

        '----- Initialization -----

        setDBaseProvider()
        readinAllExistingToolsFromDBase()

    End Sub

    '----- Member variables ---------------------------------

    '----- Database related -----

    Private m_con As New MySqlConnection
    Private m_cmd As New MySqlCommand
    Private m_reader As MySqlDataReader

    '----------------------------

    Private m_ToolsList As Collection

    '----- Begin properties -----

    Public Property con() As MySqlConnection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_con
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As MySqlConnection)
            m_con = Value
        End Set
    End Property

    Public Property cmd() As MySqlCommand
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_cmd
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As MySqlCommand)
            m_cmd = Value
        End Set
    End Property

    Public Property reader() As MySqlDataReader
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_reader
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As MySqlDataReader)
            m_reader = Value
        End Set
    End Property

    Public Property ToolsList() As Collection
        ' Abholen des Eigenschaftenwerts 
        Get
            Return m_ToolsList
        End Get
        ' Setzen des Eigenschaftenwerts 
        Set(ByVal Value As Collection)
            m_ToolsList = Value
        End Set
    End Property

    '----- End member variables, begin member methodes ----------------------

    Public Sub setDBaseProvider()
        Console.WriteLine("Connect to DBase")
        con.ConnectionString = "server=127.0.0.1;user id=root;password=Dumm.1234;database=odartectools;"
        cmd.Connection = con
    End Sub

    Private Function readinAllExistingToolsFromDBase() As Boolean

        Return True
    End Function

    Public Function getSpecifiedToolFromDBase(ToolInLibraryTable As Integer) As cTool

        Dim Tool As New cTool

        Try
            con.Open()
            cmd.CommandText = "SELECT * FROM tools WHERE 1"
            reader = cmd.ExecuteReader
            Do While reader.Read
                ToolsList.Add(New cTool(reader("toolnumber"), _
                                        reader("toolname"), _
                                        reader("tooltype"), _
                                        reader("D1"), _
                                        reader("D2"), _
                                        reader("D3"), _
                                        reader("cornerradius"), _
                                        reader("chamfersize"), _
                                        reader("chamferangle"), _
                                        reader("numberofcuttingedges"), _
                                        reader("cuttinglength"), _
                                        reader("toolmaterial"), _
                                        reader("toolcoating"), _
                                        CBool(reader("centercut")), _
                                        CBool(reader("innercooling")), _
                                        reader("maxworkpiecehardness")), "Tool " + CStr(reader("toolnumber")))
                Console.WriteLine("Tool " + CStr(reader("toolnumber")))
            Loop
            reader.Close()
            con.Close()
        Catch ex As Exception
            con.Close()
            Console.WriteLine(ex)

        End Try

        Return ToolsList.Item(1)
    End Function

    Public Function addToolToDBase(Tool As cTool) As Boolean
        Dim CenterCut, InnerCooling, Anzahl As Integer

        If Tool.CenterCut = True Then
            CenterCut = 1
        Else
            CenterCut = 0
        End If
        If Tool.InnerCooling = True Then
            InnerCooling = 1
        Else
            InnerCooling = 0
        End If
        Try
            con.Open()
            cmd.CommandText = "INSERT INTO tools (toolnumber, toolname, tooltype, toollength, D1, D2, D3, cornerradius, chamfersize, chamferangle, numberofcuttingedges, cuttinglength, toolmaterial, toolcoating, centercut, innercooling, maxworkpiecehardness) VALUES (NULL, '" & Tool.ToolName & "', '" & Tool.ToolName & "' , '" & Tool.ToolLength & "', '" & Tool.ToolDiameter & "', '" & Tool.ShaftDiameter1 & "', '" & Tool.ShaftDiameter2 & "', '" & Tool.CornerRadius & "', '" & Tool.ChamferSize & "', '" & Tool.ChamferAngle & "', '" & Tool.NumberOfCuttingEdges & "', '" & Tool.CuttingLength & "', '" & Tool.ToolMaterial & "', '" & Tool.ToolCoating & "', '" & CenterCut & "', '" & InnerCooling & "', '" & Tool.MaxWorkPieceHardness & "');"
            Anzahl = cmd.ExecuteNonQuery
            con.Close()
        Catch ex As Exception
            con.Close()
            Console.WriteLine(ex)

        End Try

        Return True
    End Function

    Public Function removeToolFromDBase() As Boolean

        Return True
    End Function

    Private Function actualizeToolsList() As Boolean

        Return True
    End Function

End Class
