Option Explicit On
Option Strict On

Public NotInheritable Class OptionsControl
    Private Shared mHistoryEntries As New List(Of HistoryEntry)

    Private Sub New()

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
End Class
