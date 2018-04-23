Option Explicit On
Option Strict On

Public Class HistoryForm
    Dim formloaded As Boolean = False
    Private Sub HistoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OptionsControl.HistoryEntries.Clear()
        OptionsControl.HistoryEntries = DBUtilities.GetHistoryEntries
        DBUtilities.GetAttendanceLines(OptionsControl.HistoryEntries)

        lstHistory.Items.Clear()
        lstAttendance.Items.Clear()

        For Each item In OptionsControl.HistoryEntries
            lstHistory.Items.Add(item)
        Next

        formloaded = True
        lstHistory.SelectedIndex = 0
    End Sub

    Private Sub lstHistory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstHistory.SelectedIndexChanged
        If formloaded Then
            lstAttendance.Items.Clear()
            For Each item In CType(lstHistory.SelectedItem, HistoryEntry).Attendance
                lstAttendance.Items.Add(item)
            Next
        End If
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.Close()
    End Sub
End Class