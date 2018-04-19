Option Strict On
Option Explicit On
'TODO HANDLE CHECKBOXES
Public Class SoundsGoodForm

    Private Sub WhatSoundsGoodForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'main decision progress
        If DecisionControl.Progress = 2 Then
            DecisionControl.TagMasterList = DBUtilities.GetTagList()
            DecisionControl.Progress = 3
        End If

        'reset/load lists
        LoadLists()

        lstDesiredTags.Sorted = True
        lstAllTags.Sorted = True
    End Sub

    'reset and re-load local lists from decisioncontrol lists
    Private Sub LoadLists()
        lstAllTags.Items.Clear()
        lstDesiredTags.Items.Clear()

        'if dc.tagswanted has tags, add them to the local list
        If DecisionControl.TagWantedList.Count > 0 Then
            For Each item In DecisionControl.TagWantedList
                lstDesiredTags.Items.Add(item)
            Next
        End If
        'load the local tagsall list - if local tagswanted contains specific items, don't add those to tagsAll
        If lstDesiredTags.Items.Count > 0 Then
            For Each item In DecisionControl.TagMasterList
                If Not lstDesiredTags.Items.Contains(item) Then
                    lstAllTags.Items.Add(item)
                End If
            Next
        Else
            For Each item In DecisionControl.TagMasterList
                lstAllTags.Items.Add(item)
            Next
        End If
    End Sub

    'move tag from master list to wanted list
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        errprov.Clear()
        If Not lstAllTags.SelectedIndex = -1 Then
            lstDesiredTags.Items.Add(lstAllTags.SelectedItem)
            lstAllTags.Items.Remove(lstAllTags.SelectedItem)
        Else
            Beep()
            errprov.SetError(btnAdd, "Select a tag to add!")
            Return
        End If
    End Sub

    'move tag from wanted list to master list
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        errprov.Clear()
        If Not lstDesiredTags.SelectedIndex = -1 Then
            lstAllTags.Items.Add(lstDesiredTags.SelectedItem)
            lstDesiredTags.Items.Remove(lstDesiredTags.SelectedItem)
        Else
            Beep()
            errprov.SetError(btnRemove, "Select a person to remove!")
            Return
        End If
    End Sub

    'reset local lists and controls
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        errprov.Clear()
        LoadLists()
    End Sub

    'update decisioncontrol.tagswanted
    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        errprov.Clear()
        If lstDesiredTags.Items.Count > 0 Then
            DecisionControl.TagWantedList.Clear()
            For Each item As Tag In lstDesiredTags.Items
                DecisionControl.TagWantedList.Add(item)
            Next
        Else
            Beep()
            errprov.SetError(btnContinue, "List can't be empty!")
            Return
        End If
        If DecisionControl.Progress < 4 Then
            DecisionControl.Progress = 4
        End If

        Me.Close()
    End Sub

End Class