Option Strict On
Option Explicit On

Imports MySql.Data.MySqlClient

Public NotInheritable Class DBUtilities
    'Connection Objects
    Private Shared CONNECTION_STRING As String = "server=localhost;user id=root;password=decider;database=decider"
    Private Shared conn As New MySqlConnection(CONNECTION_STRING)
    Private Shared command As MySqlCommand
    Private Shared adapter As MySqlDataAdapter
    Private Shared reader As MySqlDataReader
    Private Shared SQL As String

    Private Shared mLastStatus As String

    Private Sub New()
        'Can't instanstiate this class.
    End Sub

    'FILL
    Public Shared Function GetMembersTable() As DataTable
        Dim table As DataTable
        SQL = "SELECT * FROM person_t" 'TABLE

        Try
            conn.Open()

            Dim dataset As New DataSet
            adapter = New MySqlDataAdapter(SQL, conn)
            adapter.Fill(dataset)

            table = dataset.Tables(0)
        Catch ex As Exception
            table = Nothing
        Finally
            conn.Close()
        End Try
        Return table
    End Function

    Public Shared Function GetMembersList() As List(Of Person)
        Dim list As New List(Of Person)

        SQL = "SELECT * FROM person_t ORDER BY PerName" '+ ID, Name FROM Table ORDER BY Name

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            command = New MySqlCommand(SQL, conn)
            reader = command.ExecuteReader

            While (reader.Read)
                Dim ID As Integer = reader.GetInt32(0)
                Dim name As String = reader.GetString(1)
                Dim temp As New Person(ID, name)
                list.Add(temp)
            End While
        Catch ex As Exception
            list = Nothing
        Finally
            conn.Close()
        End Try
        Return list
    End Function

    Public Shared Function GetTagList() As List(Of Tag)
        Dim list As New List(Of Tag)

        SQL = "SELECT * FROM tags_t ORDER BY TagValue" '+ ID, Name FROM Table ORDER BY Name

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            command = New MySqlCommand(SQL, conn)
            reader = command.ExecuteReader

            While (reader.Read)
                Dim ID As Integer = reader.GetInt32(0)
                Dim name As String = reader.GetString(1)
                Dim temp As New Tag(ID, name)
                list.Add(temp)
            End While
        Catch ex As Exception
            list = Nothing
        Finally
            conn.Close()
        End Try
        Return list
    End Function

    'INSERT
    Public Shared Function InsertMember(pPerson As Person) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error adding record: Member."

        SQL = "INSERT INTO " 'Table(Name) VALUES(@Name)

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()

            command = New MySqlCommand(SQL, conn)
            command.Parameters.AddWithValue("@Name", pPerson.Name)

            If command.ExecuteNonQuery > 0 Then
                result = True
                mLastStatus = "Record successfully added: Member."
            End If
        Catch ex As Exception
            mLastStatus += " " + ex.Message
        Finally
            conn.Close()
        End Try

        Return result
    End Function
    'UPDATE

    'DELETE

End Class
