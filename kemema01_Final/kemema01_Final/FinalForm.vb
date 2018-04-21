Public Class FinalForm
    Private Sub FinalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load Likes/Dislikes
        For Each buddy In DecisionControl.PeoplePresentList
            DBUtilities.GetLikeLines(buddy)
            DBUtilities.GetDislikeLines(buddy)
        Next

        'Load candidates list
        Dim candidates As New List(Of Restaurant)
        For Each restaurant In DecisionControl.RestMasterList
            candidates.Add(restaurant)
        Next

        'Remove those that sound bad
        For Each rest In candidates
            If DecisionControl.RestSoundsBad.Contains(rest) Then
                candidates.Remove(rest)
                Exit For
            End If
            'index 0=dine in, 1=carryout, 2=delivery
            If DecisionControl.CatBad(0) = True And rest.DineIn = True Then
                If Not (rest.CarryOut = True Or rest.Delivery = True) Then
                    candidates.Remove(rest)
                    Exit For
                End If
            End If
            If DecisionControl.CatBad(1) = True And rest.CarryOut = True Then
                If Not (rest.DineIn = True Or rest.Delivery = True) Then
                    candidates.Remove(rest)
                    Exit For
                End If
            End If
            If DecisionControl.CatBad(2) = True And rest.Delivery = True Then
                If Not (rest.DineIn = True Or rest.CarryOut = True) Then
                    candidates.Remove(rest)
                    Exit For
                End If
            End If
        Next

        'determine score increases - exits to try to help balance score influence of many tags
        For Each restaurant In candidates
            For Each person In DecisionControl.PeoplePresentList
                For Each item In person.Likes
                    If restaurant.GetTags.Contains(item) Then
                        restaurant.Score += 1
                        Exit For
                    End If
                Next
            Next
            For Each item In DecisionControl.TagWantedList
                If restaurant.GetTags.Contains(item) Then
                    restaurant.Score += 1
                    Exit For
                End If
            Next
            'index 0=dine in, 1=carryout, 2=delivery
            If DecisionControl.CatGood(0) = True And restaurant.DineIn = True Then
                restaurant.Score += 1
            End If
            If DecisionControl.CatGood(1) = True And restaurant.CarryOut = True Then
                restaurant.Score += 1
            End If
            If DecisionControl.CatGood(2) = True And restaurant.Delivery = True Then
                restaurant.Score += 1
            End If
        Next

        'determine score penalties - exits to help balance score influence as above
        For Each restaurant In candidates
            For Each person In DecisionControl.PeoplePresentList
                If person.Dislikes.Count = 0 Then
                    Exit For
                Else
                    For Each item In person.Dislikes
                        If restaurant.GetTags.Contains(item) Then
                            restaurant.Score -= 2
                            Exit For
                        End If
                    Next
                End If
            Next
            For Each item In DecisionControl.TagsSoundsBad
                If restaurant.GetTags.Contains(item) Then
                    Dim ph As Double = restaurant.Score
                    ph = Math.Round(ph / 2)
                    restaurant.Score -= CInt(ph)
                    Exit For
                End If
            Next
        Next

        'create "weighted" list of restaurants
        Dim bigList As New List(Of Restaurant)
        For Each rest In candidates
            If rest.Score > 0 Then
                For i As Integer = 1 To rest.Score Step 1
                    bigList.Add(rest)
                Next
            End If
        Next

        'randomly select the winner
        Dim randal As New Random
        Dim indexWinner As Integer = randal.Next(0, bigList.Count - 1)
        DecisionControl.Winner = New Restaurant(bigList(indexWinner))
        lblWInner.Text = DecisionControl.Winner.ToStringScore

        'create top 5 list of restaurants according to score
        Dim shortList As New List(Of Restaurant)
        Dim max As Integer = -1
        Dim indexList As Integer = -1
        For i As Integer = 1 To 5 Step 1
            max = -1
            indexList = -1
            For Each rest In candidates
                If rest.Score > max Then
                    max = rest.Score
                    indexList = candidates.IndexOf(rest)
                End If
            Next
            Dim ph As New Restaurant(candidates(indexList))
            DecisionControl.ScoreBoard.Add(ph)
            candidates.RemoveAt(indexList)
        Next

        Dim listDictionary As New Dictionary(Of String, Restaurant)
        For Each rest In DecisionControl.ScoreBoard
            listDictionary.Add("(" + rest.Score.ToString + ") " + rest.Name, rest)
        Next
        lstScoreBoard.DataSource = New BindingSource(listDictionary, Nothing)
        lstScoreBoard.DisplayMember = "Value.ToStringScore"
        lstScoreBoard.ValueMember = "Key"
        lstScoreBoard.SelectedIndex = -1
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
    End Sub

    Private Sub btnList_Click(sender As Object, e As EventArgs) Handles btnList.Click
        'Dim ph As New Restaurant(CType(lstScoreBoard.SelectedValue, Restaurant))
    End Sub
End Class