Imports kemema01_Final

Public Class HistoryEntry
    Implements IComparable(Of HistoryEntry)
    Private mEntryID As Integer
    Private mRestID As Integer
    Private mRestName As String
    Private mDate As Date
    Private mList As List(Of Person)

    Public Sub New(pEntryID As Integer, pRestID As Integer, pRestName As String, pDate As Date)
        mEntryID = pEntryID
        mRestID = pRestID
        mRestName = pRestName
        mDate = pDate
        mList = New List(Of Person)

    End Sub

    Public ReadOnly Property EntryID As Integer
        Get
            Return mEntryID
        End Get
    End Property
    Public Property EntryDate As Date
        Get
            Return mDate
        End Get
        Set(value As Date)
            mDate = value
        End Set
    End Property

    Public Property RestName As String
        Get
            Return mRestName
        End Get
        Set(value As String)
            mRestName = value
        End Set
    End Property

    Public Property Attendance As List(Of Person)
        Get
            Dim tempList As New List(Of Person)
            For Each item In mList
                tempList.Add(item)
            Next
            Return tempList
        End Get
        Set(value As List(Of Person))
            mList.Clear()
            For Each item In value
                mList.Add(item)
            Next
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return EntryDate.ToShortDateString + " - " + RestName
    End Function

    Public Function CompareTo(other As HistoryEntry) As Integer Implements IComparable(Of HistoryEntry).CompareTo
        Dim result As Integer = Me.entryid.CompareTo(other.entryid)
        If result = 0 Then
            result = Me.RestName.CompareTo(other.RestName)
        End If

        Return result
    End Function
End Class
