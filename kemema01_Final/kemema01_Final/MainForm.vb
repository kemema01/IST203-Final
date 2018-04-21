Option Explicit On
Option Strict On

Public Class MainForm

    'Begin decision making process.
    Private Sub btnBegin_Click(sender As Object, e As EventArgs) Handles btnBegin.Click
        AttendanceForm.ShowDialog()
        If Not DecisionControl.PeoplePresentList.Count > 0 Then
            Beep()
            Return
        Else
            'Label2.Text
        End If

        SoundsGoodForm.ShowDialog()
        If Not DecisionControl.TagWantedList.Count > 0 Then
            Beep()
            Return
        End If

        SoundsBadForm.ShowDialog()
        If DecisionControl.Progress = 6 Then
            Beep()
            Return
        End If

        FinalForm.ShowDialog()

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
