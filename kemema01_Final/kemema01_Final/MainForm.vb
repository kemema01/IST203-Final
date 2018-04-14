Option Explicit On
Option Strict On

Public Class MainForm

    'Begin decision making process.
    Private Sub btnBegin_Click(sender As Object, e As EventArgs) Handles btnBegin.Click
        AttendanceForm.ShowDialog()
        'maybe dump progress text somewhere?
        SoundsGoodForm.ShowDialog()

    End Sub

    'Display history.
    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        HistoryForm.ShowDialog()
    End Sub

    'Options - for CRUD operations.
    Private Sub btnOptions_Click(sender As Object, e As EventArgs) Handles btnOptions.Click
        OptionsForm.ShowDialog()
    End Sub

    'Exit.
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
