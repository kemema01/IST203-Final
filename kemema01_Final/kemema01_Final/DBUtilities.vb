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

    Public Shared ReadOnly Property LastStatus As String
        Get
            Return mLastStatus
        End Get
    End Property

    'FILL
    Public Shared Function GetNewHistoryEntry() As Integer
        SQL = "SELECT h.entryid, count(a.perid) as n " +
            "FROM history_entry_t h LEFT JOIN attendance_line_t a ON h.entryid = a.entryid " +
            "GROUP BY h.entryid " +
            "HAVING n = 0;"
        Dim output As Integer = -1
        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            command = New MySqlCommand(SQL, conn)
            reader = command.ExecuteReader

            While reader.Read
                output = reader.GetInt32(0)
            End While
        Catch ex As Exception
            Beep()
        Finally
            conn.Close()
        End Try
        Return output
    End Function

    Public Shared Function GetNewPersonEntry() As Integer
        SQL = "SELECT p.PerID, count(l.tagID) as n FROM person_t p LEFT JOIN like_line_t l ON p.PerID = l.perID GROUP BY p.perid HAVING n = 0;"
        Dim output As Integer = -1
        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            command = New MySqlCommand(SQL, conn)
            reader = command.ExecuteReader

            While reader.Read
                output = reader.GetInt32(0)
            End While
        Catch ex As Exception
            Beep()
        Finally
            conn.Close()
        End Try
        Return output
    End Function
    'Public Shared Function GetMembersTable() As DataTable
    '    Dim table As DataTable
    '    SQL = "SELECT * FROM person_t" 'TABLE

    '    Try
    '        conn.Open()

    '        Dim dataset As New DataSet
    '        adapter = New MySqlDataAdapter(SQL, conn)
    '        adapter.Fill(dataset)

    '        table = dataset.Tables(0)
    '    Catch ex As Exception
    '        table = Nothing
    '    Finally
    '        conn.Close()
    '    End Try
    '    Return table
    'End Function

    Public Shared Function GetMembersList() As List(Of Person)
        Dim list As New List(Of Person)

        SQL = "SELECT * FROM person_t ORDER BY PerName;" '+ ID, Name FROM Table ORDER BY Name

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

    Public Shared Function GetRestList() As List(Of Restaurant)
        Dim list As New List(Of Restaurant)

        SQL = "SELECT * FROM restaurant_t ORDER BY RestName;" '+ ID, Name FROM Table ORDER BY Name

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            command = New MySqlCommand(SQL, conn)
            reader = command.ExecuteReader

            While (reader.Read)
                Dim ID As Integer = reader.GetInt32(0)
                Dim name As String = reader.GetString(1)
                Dim cost As Integer = reader.GetInt32(2)
                Dim dineIn As Boolean = reader.GetBoolean(3)
                Dim carryOut As Boolean = reader.GetBoolean(4)
                Dim delivery As Boolean = reader.GetBoolean(5)
                Dim temp As New Restaurant(ID, name, cost, dineIn, carryOut, delivery)
                list.Add(temp)
            End While
        Catch ex As Exception
            list = Nothing
        Finally
            conn.Close()
        End Try

        For Each rest In list
            rest.CopyTags(GetRestTagLines(rest))
        Next
        Return list
    End Function

    Public Shared Function GetTagList() As List(Of Tag)
        Dim list As New List(Of Tag)

        SQL = "SELECT * FROM tags_t ORDER BY TagValue;" '+ ID, Name FROM Table ORDER BY Name

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

    Public Shared Function GetRestTagLines(rest As Restaurant) As List(Of Tag)
        Dim list As New List(Of Tag)

        'SQL = "SELECT tag_line_t.TagID, tag_line_t.TagValue FROM tag_line_t, tags_t WHERE tag_line_t.RestID = " + rest.ID.ToString() +
        '   " AND tag_line_t.TagID = tags_t.TagID ORDER BY TagValue;"
        SQL = "SELECT t.tagid, t.tagvalue FROM tags_t t, tag_line_t WHERE t.tagid = tag_line_t.tagid AND tag_line_t.restid = " + rest.ID.ToString() +
            " ORDER BY TagValue;"

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            command = New MySqlCommand(SQL, conn)
            reader = command.ExecuteReader

            While (reader.Read)
                Dim ID As Integer = reader.GetInt32(0)
                Dim tagValue As String = reader.GetString(1)
                Dim temp As New Tag(ID, tagValue)
                list.Add(temp)
            End While
        Catch ex As Exception
            list = Nothing
        Finally
            conn.Close()
        End Try
        Return list
    End Function

    Public Shared Sub GetLikeLines(buddy As Person)
        Dim list As New List(Of Tag)

        'SQL = "SELECT tag_line_t.TagID, tag_line_t.TagValue FROM tag_line_t, tags_t WHERE tag_line_t.RestID = " + rest.ID.ToString() +
        '   " AND tag_line_t.TagID = tags_t.TagID ORDER BY TagValue;"
        SQL = "SELECT l.tagid, t.tagvalue FROM like_line_t l, tags_t t WHERE l.tagid = t.tagid AND l.perid = " + buddy.ID.ToString() +
            " ORDER BY TagValue;"

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            command = New MySqlCommand(SQL, conn)
            reader = command.ExecuteReader

            While (reader.Read)
                Dim ID As Integer = reader.GetInt32(0)
                Dim tagValue As String = reader.GetString(1)
                Dim temp As New Tag(ID, tagValue)
                list.Add(temp)
            End While
        Catch ex As Exception
            list = Nothing
        Finally
            conn.Close()
        End Try
        buddy.Likes = list
    End Sub

    Public Shared Sub GetDislikeLines(buddy As Person)
        Dim list As New List(Of Tag)

        'SQL = "SELECT tag_line_t.TagID, tag_line_t.TagValue FROM tag_line_t, tags_t WHERE tag_line_t.RestID = " + rest.ID.ToString() +
        '   " AND tag_line_t.TagID = tags_t.TagID ORDER BY TagValue;"
        SQL = "SELECT d.tagid, t.tagvalue FROM dislike_line_t d, tags_t t WHERE d.tagid = t.tagid AND d.perid = " + buddy.ID.ToString() +
            " ORDER BY TagValue;"

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            command = New MySqlCommand(SQL, conn)
            reader = command.ExecuteReader

            While (reader.Read)
                Dim ID As Integer = reader.GetInt32(0)
                Dim tagValue As String = reader.GetString(1)
                Dim temp As New Tag(ID, tagValue)
                list.Add(temp)
            End While
        Catch ex As Exception
            list = Nothing
        Finally
            conn.Close()
        End Try
        buddy.Dislikes = list
    End Sub

    Public Shared Function GetHistoryEntries() As List(Of HistoryEntry)
        Dim list As New List(Of HistoryEntry)

        SQL = "SELECT EntryID, EntryDate, restaurant_t.RestID, restaurant_t.RestName " +
            "FROM history_entry_t, restaurant_t " +
            "WHERE history_entry_t.RestID = restaurant_t.RestID " +
            "ORDER BY EntryDate DESC;"

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            command = New MySqlCommand(SQL, conn)
            reader = command.ExecuteReader

            While reader.Read
                Dim EntryID As Integer = reader.GetInt32(0)
                Dim EntryDate As Date = reader.GetDateTime(1)
                Dim RestID As Integer = reader.GetInt32(2)
                Dim RestName As String = reader.GetString(3)
                Dim temp As New HistoryEntry(EntryID, RestID, RestName, EntryDate)
                list.Add(temp)
            End While
        Catch ex As Exception
            list = Nothing
        Finally
            conn.Close()
        End Try
        Return list
    End Function

    Public Shared Sub GetAttendanceLines(list As List(Of HistoryEntry))

        For Each item In list
            Dim attendance As New List(Of Person)
            SQL = "SELECT person_t.PerID, person_t.PerName " +
                "FROM person_t, attendance_line_t " +
                "WHERE person_t.PerID = attendance_line_t.PerID " +
                "AND attendance_line_t.EntryID = " + item.EntryID.ToString() + " " +
                "ORDER BY PerName;"

            Try
                conn = New MySqlConnection(CONNECTION_STRING)
                conn.Open()
                command = New MySqlCommand(SQL, conn)
                reader = command.ExecuteReader

                While reader.Read
                    Dim PerID As Integer = reader.GetInt32(0)
                    Dim PerName As String = reader.GetString(1)
                    Dim temp As New Person(PerID, PerName)
                    attendance.Add(temp)
                End While
            Catch ex As Exception
                attendance = Nothing
            Finally
                conn.Close()
            End Try
            item.Attendance = attendance
        Next
    End Sub

    Public Shared Function CountLikes(buddy As Person) As Integer
        Dim result As Integer

        SQL = "SELECT COUNT(TagID) FROM Like_line_t WHERE PerID = " + buddy.ID.ToString()

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            command = New MySqlCommand(SQL, conn)
            result = CInt(command.ExecuteScalar)

        Catch ex As Exception
            result = Nothing
        Finally
            conn.Close()
        End Try
        Return result
    End Function

    Public Shared Function CountDislikes(buddy As Person) As Integer
        Dim result As Integer

        SQL = "SELECT COUNT(TagID) FROM Dislike_line_t WHERE PerID = " + buddy.ID.ToString()

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            command = New MySqlCommand(SQL, conn)
            result = CInt(command.ExecuteScalar)

        Catch ex As Exception
            result = Nothing
        Finally
            conn.Close()
        End Try
        Return result
    End Function

    'INSERT
    Public Shared Function InsertPerson(buddy As Person) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error adding record: Person."

        SQL = "INSERT INTO person_t (PerName) VALUES (@PerName);" 'Table(Name) VALUES(@Name)

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()

            command = New MySqlCommand(SQL, conn)
            command.Parameters.AddWithValue("@PerName", buddy.Name)

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

    'INSERT LIKE LINES - RELATED TO SPECIFIC PERSON
    Public Shared Function InsertLikeLines(buddy As Person) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error adding record: Like Lines - " + buddy.Name + "."

        'If CountLikes(buddy) > 0 Then
        '    DeleteLikeLines(buddy)
        'End If

        SQL = "INSERT INTO Like_line_t (PerID, TagID) VALUES "

        For Each descriptor In buddy.Likes
            SQL += "(" + buddy.ID.ToString + ", " + descriptor.ID.ToString + ")"
            If buddy.Likes.IndexOf(descriptor) < buddy.Likes.Count - 1 Then
                SQL += ", "
            Else
                SQL += ";"
            End If
        Next

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()

            command = New MySqlCommand(SQL, conn)

            If command.ExecuteNonQuery > 0 Then
                result = True
                mLastStatus = "Record successfully added: Like Lines - " + buddy.Name + "."
            End If
        Catch ex As Exception
            mLastStatus += " " + ex.Message
        Finally
            conn.Close()
        End Try

        Return result
    End Function

    'INSERT DISLIKE LINES - RELATED TO SPECIFIC PERSON
    Public Shared Function InsertDislikeLines(buddy As Person) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error adding record: Disike Lines - " + buddy.Name + "."

        'If CountDislikes(buddy) > 0 Then
        '    DeleteDislikeLines(buddy)
        'End If

        SQL = "INSERT INTO Dislike_line_t (PerID, TagID) VALUES "

        For Each descriptor In buddy.Dislikes
            SQL += "(" + buddy.ID.ToString + ", " + descriptor.ID.ToString + ")"
            If buddy.Likes.IndexOf(descriptor) < buddy.Likes.Count - 1 Then
                SQL += ", "
            Else
                SQL += ";"
            End If
        Next

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()

            command = New MySqlCommand(SQL, conn)

            If command.ExecuteNonQuery > 0 Then
                result = True
                mLastStatus = "Record successfully added: Dislike Lines - " + buddy.Name + "."
            End If
        Catch ex As Exception
            mLastStatus += " " + ex.Message
        Finally
            conn.Close()
        End Try

        Return result
    End Function
    Public Shared Function InsertRestaurant(rest As Restaurant) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error adding record: Restaurant."

        SQL = "INSERT INTO restaurant_t (RestName, RestPrice) VALUES (@RestName, @RestPrice);" 'Table(Name) VALUES(@Name)

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()

            command = New MySqlCommand(SQL, conn)
            command.Parameters.AddWithValue("@RestName", rest.Name)
            command.Parameters.AddWithValue("RestPrice", rest.Cost)

            If command.ExecuteNonQuery > 0 Then
                result = True
                mLastStatus = "Record successfully added: Restaurant."
            End If
        Catch ex As Exception
            mLastStatus += " " + ex.Message
        Finally
            conn.Close()
        End Try

        Return result
    End Function

    'INSERT: TAG LINES
    Public Shared Function InsertTagLines(rest As Restaurant) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error adding record: Tag Line(s) - " + rest.Name + "."

        SQL = "INSERT INTO tag_line_t (RestID, TagID) VALUES "

        Dim tempList As List(Of Tag) = rest.GetTags

        For i As Integer = 0 To tempList.Count - 1 Step 1
            SQL += "(" + rest.ID.ToString + ", " + tempList(i).ID.ToString + ")"
            If i < tempList.Count - 1 Then
                SQL += ", "
            Else
                SQL += ";"
            End If
        Next

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()
            'TODO FIX COMMAND SEQUENCE
            command = New MySqlCommand(SQL, conn)
            'command.Parameters.AddWithValue("@Name", rest.Name)


            If command.ExecuteNonQuery > 0 Then
                result = True
                mLastStatus = "Record successfully added: Tag Line(s)."
            End If
        Catch ex As Exception
            mLastStatus += " " + ex.Message
        Finally
            conn.Close()
        End Try
        Return result
    End Function
    'INSERT: HISTORY ENTRY
    Public Shared Function InsertHistoryEntry(rest As Restaurant) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error adding record: History Entry."

        SQL = "INSERT INTO history_entry_t (EntryDate, RestID) VALUES (CURDATE(), @RestID);"

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()

            command = New MySqlCommand(SQL, conn)
            command.Parameters.AddWithValue("@RestID", rest.ID)

            If command.ExecuteNonQuery > 0 Then
                result = True
                mLastStatus = "Record successfully added: History Entry."
            End If
        Catch ex As Exception
            mLastStatus += " " + ex.Message
        Finally
            conn.Close()
        End Try

        Return result
    End Function
    'INSERT: ATTENDANCE ENTRY - WHO WAS PRESENT AT GIVEN HISTORY ENTRY
    Public Shared Function InsertAttendanceEntries(list As List(Of Person), entryID As Integer) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error adding records: History Entry - Attendance."

        SQL = "INSERT INTO attendance_line_t (PerID, EntryID) VALUES "

        For Each buddy In list
            SQL += "(" + buddy.ID.ToString() + "," + entryID.ToString() + ")"
            If list.IndexOf(buddy) < list.Count - 1 Then
                SQL += ", "
            Else
                SQL += ";"
            End If
        Next
        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()

            command = New MySqlCommand(SQL, conn)

            If command.ExecuteNonQuery > 0 Then
                result = True
                mLastStatus = "Record successfully added: History Entry - Attendance."
            End If
        Catch ex As Exception
            mLastStatus += " " + ex.Message
        Finally
            conn.Close()
        End Try

        Return result
    End Function

    'UPDATE
    'PERSON
    Public Shared Function UpdatePerson(pOld As Person, pNew As Person) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error updating record: Person"

        SQL = "UPDATE person_t SET PerName = @NewName WHERE PerID = @OldID;"

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()

            command = New MySqlCommand(SQL, conn)
            command.Parameters.AddWithValue("@NewName", pNew.Name)
            command.Parameters.AddWithValue("@OldID", pOld.ID)

            If command.ExecuteNonQuery > 0 Then
                result = True
                mLastStatus = "Record successfully updated: Person"
            End If
        Catch ex As Exception
            mLastStatus += " " + ex.Message
        Finally
            conn.Close()

        End Try
        Return result
    End Function
    'RESTAURANT

    'DELETE:
    'Person
    Public Shared Function DeletePerson(buddy As Person) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error removing record: Person."

        SQL = "DELETE FROM person_t WHERE PerID = @PerID;"

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()

            command = New MySqlCommand(SQL, conn)
            command.Parameters.AddWithValue("@PerID", buddy.ID)

            If command.ExecuteNonQuery > 0 Then
                result = True
                mLastStatus = "Record successfully removed: Person."
            End If
        Catch ex As Exception
            mLastStatus += " " + ex.Message
        Finally
            conn.Close()
        End Try

        Return result
    End Function
    'Like Lines
    Public Shared Function DeleteLikeLines(buddy As Person) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error removing record: Like Lines - " + buddy.Name + "."

        SQL = "DELETE FROM like_line_t WHERE PerID = @PerID;"

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()

            command = New MySqlCommand(SQL, conn)
            command.Parameters.AddWithValue("@PerID", buddy.ID)

            If command.ExecuteNonQuery > 0 Then
                result = True
                mLastStatus = "Record successfully removed: Like Lines - " + buddy.Name + "."
            End If
        Catch ex As Exception
            mLastStatus += " " + ex.Message
        Finally
            conn.Close()
        End Try

        Return result
    End Function
    'Dislike Lines
    Public Shared Function DeleteDislikeLines(buddy As Person) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error removing record: Dislike Lines - " + buddy.Name + "."

        SQL = "DELETE FROM dislike_line_t WHERE PerID = @PerID;"

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()

            command = New MySqlCommand(SQL, conn)
            command.Parameters.AddWithValue("@PerID", buddy.ID)

            If command.ExecuteNonQuery > 0 Then
                result = True
                mLastStatus = "Record successfully removed: Dislike Lines - " + buddy.Name + "."
            End If
        Catch ex As Exception
            mLastStatus += " " + ex.Message
        Finally
            conn.Close()
        End Try

        Return result
    End Function

    'Attendance Lines
    Public Shared Function DeleteAttendanceLines(buddy As Person) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error removing record: Attendance Lines - " + buddy.Name + "."

        SQL = "DELETE FROM attendance_line_t WHERE PerID = @PerID;"

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()

            command = New MySqlCommand(SQL, conn)
            command.Parameters.AddWithValue("@PerID", buddy.ID)

            If command.ExecuteNonQuery > 0 Then
                result = True
                mLastStatus = "Record successfully removed: Attendance Lines - " + buddy.Name + "."
            End If
        Catch ex As Exception
            mLastStatus += " " + ex.Message
        Finally
            conn.Close()
        End Try

        Return result
    End Function
    'RESTAURANT
    Public Shared Function DeleteRestaurant(rest As Restaurant) As Boolean
        Dim result As Boolean = False
        mLastStatus = "Error removing record: Restaurant"

        SQL = "DELETE FROM restaurant_t WHERE RestID = @RestID;"

        Try
            conn = New MySqlConnection(CONNECTION_STRING)
            conn.Open()

            command = New MySqlCommand(SQL, conn)
            command.Parameters.AddWithValue("@RestID", rest.ID)

            If command.ExecuteNonQuery > 0 Then
                result = True
                mLastStatus = "Record successfully removed: Restaurant."
            End If
        Catch ex As Exception
            mLastStatus += " " + ex.Message
        Finally
            conn.Close()
        End Try

        Return result
    End Function
    ' / TAG LINES

End Class
