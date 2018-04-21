Option Strict On
Option Explicit On
'TODO HANDLE CHECKBOXES
Public Class SoundsBadForm
    Dim formLoaded As Boolean = False
    Private Sub WhatSoundsGoodForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'main decision progress
        If DecisionControl.Progress = 4 Then
            DecisionControl.RestMasterList = DBUtilities.GetRestList()
            DecisionControl.Progress = 5
        End If
        formLoaded = False
        'reset/load lists
        LoadLists()

        clstRest.Sorted = True
        clstTags.Sorted = True

        If DecisionControl.CatGood(0) = True Then
            chkDineIn.Checked = False
            chkDineIn.Enabled = False
        Else
            chkDineIn.Enabled = True
            If DecisionControl.CatBad(0) = True Then
                chkDineIn.Checked = True
            Else
                chkDineIn.Checked = False
            End If
        End If

        If DecisionControl.CatGood(1) = True Then
            chkCarryOut.Checked = False
            chkCarryOut.Enabled = False
        Else
            chkCarryOut.Enabled = True
            If DecisionControl.CatBad(1) = True Then
                chkCarryOut.Checked = True
            Else
                chkCarryOut.Checked = False
            End If
        End If

        If DecisionControl.CatGood(2) = True Then
            chkDelivery.Checked = False
            chkDelivery.Enabled = False
        Else
            chkDelivery.Enabled = True
            If DecisionControl.CatBad(2) = True Then
                chkDelivery.Checked = True
            Else
                chkDelivery.Checked = False
            End If
        End If
        formLoaded = True
    End Sub

    'reset and re-load local lists from decisioncontrol lists
    Private Sub LoadLists()
        clstTags.Items.Clear()
        clstRest.Items.Clear()

        'to avoid confusion, if an item is on 'sounds good' lists, don't let it be a candidate for
        'sounds bad lists
        For Each item In DecisionControl.RestMasterList
            clstRest.Items.Add(item)
        Next
        For Each item In DecisionControl.TagMasterList
            If Not DecisionControl.TagWantedList.Contains(item) Then
                clstTags.Items.Add(item)
            End If
        Next

        'if dc.restsoundsbad has restaurants, check them in this control
        If DecisionControl.RestSoundsBad.Count > 0 Then
            For Each item In clstRest.Items
                If DecisionControl.RestSoundsBad.Contains(CType(item, Restaurant)) Then
                    clstRest.SetItemChecked(clstRest.Items.IndexOf(item), True)
                End If

            Next
        End If
        'if dc.tagsoundsbad has tags, check them in this control
        If DecisionControl.TagsSoundsBad.Count > 0 Then
            For Each item In clstTags.Items
                If DecisionControl.TagsSoundsBad.Contains(CType(item, Tag)) Then
                    clstTags.SetItemChecked(clstTags.Items.IndexOf(item), True)
                End If
            Next
        End If

    End Sub

    'update decisioncontrol.restsoundsbad,tagssoundsbad
    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        errprov.Clear()

        If (clstRest.CheckedItems.Count = DecisionControl.RestMasterList.Count) Or
            (clstTags.CheckedItems.Count = DecisionControl.TagMasterList.Count) Then
            Beep()
            errprov.SetError(btnContinue, "You can't exclude everything!")
            Return
        End If
        DecisionControl.RestSoundsBad.Clear()
        For Each item In clstRest.CheckedItems
            DecisionControl.RestSoundsBad.Add(CType(item, Restaurant))
        Next

        DecisionControl.TagsSoundsBad.Clear()
        For Each item In clstTags.CheckedItems
            DecisionControl.TagsSoundsBad.Add(CType(item, Tag))
        Next

        If chkDineIn.Checked = True Then
            DecisionControl.CatBad(0) = True
        Else
            DecisionControl.CatBad(0) = False
        End If

        If chkCarryOut.Checked = True Then
            DecisionControl.CatBad(1) = True
        Else
            DecisionControl.CatBad(1) = False
        End If

        If chkDelivery.Checked = True Then
            DecisionControl.CatBad(2) = True
        Else
            DecisionControl.CatBad(2) = False
        End If

        If DecisionControl.Progress < 6 Then
            DecisionControl.Progress = 6
        End If

        Me.Close()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        errprov.Clear()
        LoadLists()
    End Sub

    'Private Sub clstRest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clstRest.SelectedIndexChanged
    '    If formLoaded = True Then
    '        If clstRest.CheckedItems.Contains(clstRest.SelectedItem) Then
    '            clstRest.SetItemChecked(clstRest.Items.IndexOf(clstRest.SelectedItem), False)
    '        Else
    '            clstRest.SetItemChecked(clstRest.Items.IndexOf(clstRest.SelectedItem), True)
    '        End If
    '    End If
    'End Sub
End Class