Option Explicit On
Option Strict On

Public NotInheritable Class OptionsControl
    Private Shared mHistoryEntries As New List(Of HistoryEntry)
    Private Shared mPeopleMasterList As New List(Of Person)
    Private Shared mTagMasterList As New List(Of Tag)


    Private Sub New()

    End Sub

    Public Shared Sub LoadPrefs()
        For Each buddy In PeopleMasterList
            DBUtilities.GetLikeLines(buddy)
            DBUtilities.GetDislikeLines(buddy)
        Next
    End Sub

    Public Shared Property HistoryEntries As List(Of HistoryEntry)
        Get
            Return mHistoryEntries
        End Get
        Set(value As List(Of HistoryEntry))
            mHistoryEntries.Clear()
            mHistoryEntries = value
        End Set
    End Property

    Public Shared Property PeopleMasterList As List(Of Person)
        Get
            Return mPeopleMasterList
        End Get
        Set(value As List(Of Person))
            mPeopleMasterList = value
        End Set
    End Property

    Public Shared Property TagMasterList As List(Of Tag)
        Get
            Return mTagMasterList
        End Get
        Set(value As List(Of Tag))
            mTagMasterList = value
        End Set
    End Property
End Class
