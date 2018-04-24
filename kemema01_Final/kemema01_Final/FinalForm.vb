Public Class FinalForm
    Private Sub FinalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DecisionControl.FinalFlag = True
        'Load Likes/Dislikes
        DecisionControl.LoadPrefs()
        'Load candidates list
        DecisionControl.LoadCandidates()
        'Remove those that sound bad
        DecisionControl.FilterCandidates()
        'determine score increases - exits to try to help balance score influence of many tags
        'determine score penalties - exits to help balance score influence as above
        DecisionControl.ProcessScores()
        'create "weighted" list of restaurants
        DecisionControl.WeightList()
        'randomly select the winner
        lblWInner.Text = DecisionControl.Winner.ToString()
        'create top 5 list of restaurants according to score
        DecisionControl.RunnersUp()
        lstScoreBoard.DataSource = DecisionControl.ScoreBoard
        lstScoreBoard.SelectedIndex = -1
        DecisionControl.FinalFlag = False
        DecisionControl.Progress = 7
    End Sub

    Private Sub chkReject_CheckedChanged(sender As Object, e As EventArgs) Handles chkReject.CheckedChanged
        If chkReject.Checked = True Then
            btnWinner.Enabled = False
            btnList.Enabled = True
            lstScoreBoard.Enabled = True
            btnRandom.Enabled = True
        Else
            btnWinner.Enabled = True
            btnList.Enabled = False
            lstScoreBoard.Enabled = False
            btnRandom.Enabled = False

        End If
    End Sub

    Private Sub btnWinner_Click(sender As Object, e As EventArgs) Handles btnWinner.Click
        DBUtilities.InsertHistoryEntry(DecisionControl.Winner)
        DBUtilities.InsertAttendanceEntries(DecisionControl.PeoplePresentList, DBUtilities.GetNewHistoryEntry)
        DecisionControl.Progress = 8
        MessageBox.Show("Success.")
        Me.Close()
    End Sub

    Private Sub btnList_Click(sender As Object, e As EventArgs) Handles btnList.Click
        DBUtilities.InsertHistoryEntry(CType(lstScoreBoard.SelectedItem, Restaurant))
        DBUtilities.InsertAttendanceEntries(DecisionControl.PeoplePresentList, DBUtilities.GetNewHistoryEntry)
        DecisionControl.Progress = 8
        MessageBox.Show("Success")
        Me.Close()
    End Sub

    Private Sub btnRandom_Click(sender As Object, e As EventArgs) Handles btnRandom.Click
        Dim randal As New Random
        lstScoreBoard.SelectedIndex = randal.Next(0, lstScoreBoard.Items.Count - 1)
        DBUtilities.InsertHistoryEntry(CType(lstScoreBoard.SelectedItem, Restaurant))
        DBUtilities.InsertAttendanceEntries(DecisionControl.PeoplePresentList, DBUtilities.GetNewHistoryEntry)
        DecisionControl.Progress = 8
        MessageBox.Show("Success. Choice was: " + CType(lstScoreBoard.SelectedItem, Restaurant).Name)
        Me.Close()
    End Sub

    'NONE OF THE FOLLOWING BEHAVE AS EXPECTED. WORKAROUND IN LOAD EVENT.
    'Private Sub FinalForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
    '    DecisionControl.FinalFlag = True
    '    Beep()
    'End Sub

    'Private Sub FinalForm_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
    '    DecisionControl.FinalFlag = False

    'End Sub

    'Private Sub FinalForm_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
    '    DecisionControl.FinalFlag = True
    'End Sub

    'Private Sub FinalForm_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
    '    DecisionControl.FinalFlag = False

    'End Sub
End Class