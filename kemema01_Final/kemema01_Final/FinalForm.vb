Public Class FinalForm
    Private Sub FinalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DecisionControl.FinalFlag = True
        'Load Likes/Dislikes
        'For Each buddy In DecisionControl.PeoplePresentList
        '    DBUtilities.GetLikeLines(buddy)
        '    DBUtilities.GetDislikeLines(buddy)
        'Next
        DecisionControl.LoadPrefs()
        DecisionControl.LoadCandidates()
        'Load candidates list
        'Dim candidates As New List(Of Restaurant)
        'For Each restaurant In DecisionControl.RestMasterList
        '    candidates.Add(restaurant)
        'Next
        DecisionControl.FilterCandidates()
        ''Remove those that sound bad
        'For Each rest In candidates
        '    If DecisionControl.RestSoundsBad.Contains(rest) Then
        '        candidates.Remove(rest)
        '        Exit For
        '    End If
        '    'index 0=dine in, 1=carryout, 2=delivery
        '    If DecisionControl.CatBad(0) = True And rest.DineIn = True Then
        '        If Not (rest.CarryOut = True Or rest.Delivery = True) Then
        '            candidates.Remove(rest)
        '            Exit For
        '        End If
        '    End If
        '    If DecisionControl.CatBad(1) = True And rest.CarryOut = True Then
        '        If Not (rest.DineIn = True Or rest.Delivery = True) Then
        '            candidates.Remove(rest)
        '            Exit For
        '        End If
        '    End If
        '    If DecisionControl.CatBad(2) = True And rest.Delivery = True Then
        '        If Not (rest.DineIn = True Or rest.CarryOut = True) Then
        '            candidates.Remove(rest)
        '            Exit For
        '        End If
        '    End If
        'Next
        DecisionControl.ProcessScores()
        ''determine score increases - exits to try to help balance score influence of many tags
        'For Each restaurant In candidates
        '    For Each person In DecisionControl.PeoplePresentList
        '        For Each item In person.Likes
        '            If restaurant.GetTags.Contains(item) Then
        '                restaurant.Score += 2
        '                Exit For
        '            End If
        '        Next
        '    Next
        '    For Each item In DecisionControl.TagWantedList
        '        If restaurant.GetTags.Contains(item) Then
        '            restaurant.Score += 1
        '            Exit For
        '        End If
        '    Next
        '    'index 0=dine in, 1=carryout, 2=delivery
        '    If DecisionControl.CatGood(0) = True And restaurant.DineIn = True Then
        '        restaurant.Score += 1
        '    End If
        '    If DecisionControl.CatGood(1) = True And restaurant.CarryOut = True Then
        '        restaurant.Score += 1
        '    End If
        '    If DecisionControl.CatGood(2) = True And restaurant.Delivery = True Then
        '        restaurant.Score += 1
        '    End If
        'Next

        ''determine score penalties - exits to help balance score influence as above
        'For Each restaurant In candidates
        '    For Each person In DecisionControl.PeoplePresentList
        '        If person.Dislikes.Count = 0 Then
        '            Exit For
        '        Else
        '            For Each item In person.Dislikes
        '                If restaurant.GetTags.Contains(item) Then
        '                    restaurant.Score -= 3
        '                    Exit For
        '                End If
        '            Next
        '        End If
        '    Next
        '    For Each item In DecisionControl.TagsSoundsBad
        '        If restaurant.GetTags.Contains(item) Then
        '            restaurant.Score -= 4
        '            Exit For
        '        End If
        '    Next
        'Next

        ''create "weighted" list of restaurants
        'Dim bigList As New List(Of Restaurant)
        'For Each rest In candidates
        '    If rest.Score > 0 Then
        '        For i As Integer = 1 To rest.Score Step 1
        '            bigList.Add(rest)
        '        Next
        '    End If
        'Next
        DecisionControl.WeightList()

        ''randomly select the winner
        'Dim randal As New Random
        'Dim indexWinner As Integer = randal.Next(0, bigList.Count - 1)
        'DecisionControl.Winner = New Restaurant(bigList(indexWinner))
        DecisionControl.Selection()
        lblWInner.Text = DecisionControl.Winner.ToString()

        ''create top 5 list of restaurants according to score
        'Dim shortList As New List(Of Restaurant)
        'Dim max As Integer = -1
        'Dim indexList As Integer = -1
        'For i As Integer = 1 To 5 Step 1
        '    max = -1
        '    indexList = -1
        '    For Each rest In candidates
        '        If rest.Score > max Then
        '            max = rest.Score
        '            indexList = candidates.IndexOf(rest)
        '        End If
        '    Next
        '    Dim ph As New Restaurant(candidates(indexList))
        '    DecisionControl.ScoreBoard.Add(ph)
        '    candidates.RemoveAt(indexList)
        'Next
        DecisionControl.RunnersUp()

        'Dim listDictionary As New Dictionary(Of String, Restaurant)
        'For Each rest In DecisionControl.ScoreBoard
        '    listDictionary.Add("(" + rest.Score.ToString + ") " + rest.Name, rest)
        'Next
        'lstScoreBoard.DataSource = New BindingSource(listDictionary, Nothing)
        'lstScoreBoard.DisplayMember = "Value.ToStringScore"
        'lstScoreBoard.ValueMember = "Value"
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
        Else
            btnWinner.Enabled = True
            btnList.Enabled = False
            lstScoreBoard.Enabled = False
        End If
    End Sub

    Private Sub btnWinner_Click(sender As Object, e As EventArgs) Handles btnWinner.Click
        DBUtilities.InsertHistoryEntry(DecisionControl.Winner)
        DBUtilities.InsertAttendanceEntries(DecisionControl.PeoplePresentList, DBUtilities.GetNewHistoryEntry)
        DecisionControl.Progress = 8
        Me.Close()
    End Sub

    Private Sub btnList_Click(sender As Object, e As EventArgs) Handles btnList.Click
        DBUtilities.InsertHistoryEntry(CType(lstScoreBoard.SelectedValue, Restaurant))
        DBUtilities.InsertAttendanceEntries(DecisionControl.PeoplePresentList, DBUtilities.GetNewHistoryEntry)
        DecisionControl.Progress = 8
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