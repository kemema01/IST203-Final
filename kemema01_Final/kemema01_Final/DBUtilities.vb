Option Strict On
Option Explicit On

Imports System.Data.SqlClient

Public NotInheritable Class DBUtilities
    'Connection Objects
    Private Shared CONNECTION_STRING As String = ""
    Private Shared conn As New SqlConnection(CONNECTION_STRING)
    Private Shared command As SqlCommand
    Private Shared adapter As SqlDataAdapter
    Private Shared reader As SqlDataReader
    Private Shared SQL As String

    Private Shared mLastStatus As String

    Private Sub New()
        'Can't instanstiate this.
    End Sub

    'FILL
    Public Shared Function GetMembersTable() As DataTable
        Dim table As DataTable
        SQL = "SELECT * FROM " 'TABLE

        Try
            conn.Open()

            Dim dataset As New DataSet
            adapter = New SqlDataAdapter(SQL, conn)
            adapter.Fill(dataset)

            table = dataset.Tables(0)
        Catch ex As Exception
            table = Nothing
        Finally
            conn.Close()
        End Try
        Return table
    End Function

    'INSERT
    Public Shared Function InsertMember(pPerson As Person) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error adding record: Member."

        SQL = "INSERT INTO " 'Table(Name) VALUES(@Name)

        Try
            conn = New SqlConnection(CONNECTION_STRING)
            conn.Open()

            command = New SqlCommand(SQL, conn)
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
