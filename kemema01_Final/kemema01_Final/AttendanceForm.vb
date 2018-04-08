Option Explicit On
Option Strict On

Public Class AttendanceForm
    Private formLoaded As Boolean = False
    Private peoplePresent As New List(Of Person)
    Private peopleAll As New List(Of Person)

    Private Sub AttendanceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'reset/load lists
        LoadLists()

        'wire control datasources to local lists
        lstAllPeople.DataSource = peopleAll
        lstPresent.DataSource = peoplePresent

        formLoaded = True
    End Sub

    'reset and re-load local lists from decisioncontrol lists
    Private Sub LoadLists()
        peopleAll.Clear()
        peoplePresent.Clear()

        If DecisionControl.Progress > 0 Then
            For Each buddy In DecisionControl.PeoplePresentList
                peoplePresent.Add(buddy)
            Next
        End If
        If DecisionControl.Progress > 0 Then
            For Each buddy In DecisionControl.PeopleMasterList
                If Not peoplePresent.Contains(buddy) Then
                    peopleAll.Add(buddy)
                End If
            Next
        Else
            For Each buddy In DecisionControl.PeopleMasterList
                peopleAll.Add(buddy)
            Next
        End If
    End Sub

    'move person from master list to present list
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not lstAllPeople.SelectedIndex = -1 Then
            lstPresent.Items.Add(lstAllPeople.SelectedItem)
            lstAllPeople.Items.Remove(lstAllPeople.SelectedItem)
        Else
            Beep()
            errProv.SetError(lstAllPeople, "Select a person to add!")
            Return
        End If
    End Sub

    'move person from present list to master list
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If Not lstPresent.SelectedIndex = -1 Then
            lstAllPeople.Items.Add(lstPresent.SelectedItem)
            lstPresent.Items.Remove(lstPresent.SelectedItem)
        Else
            Beep()
            errProv.SetError(lstPresent, "Select a person to remove!")
            Return
        End If
    End Sub

    'reset local lists and controls
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        LoadLists()
    End Sub

    'update decisioncontrol.peoplepresentlist
    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        If peoplePresent.Count > 0 Then
            DecisionControl.PeoplePresentList.Clear()
            For Each buddy In peoplePresent
                DecisionControl.PeoplePresentList.Add(buddy)
            Next
        Else
            Beep()
            errProv.SetError(lstPresent, "List can't be empty!")
            Return
        End If
        If DecisionControl.Progress < 1 Then
            DecisionControl.Progress = 1
        End If
    End Sub
End Class