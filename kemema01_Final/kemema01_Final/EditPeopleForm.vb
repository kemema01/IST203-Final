﻿Public Class EditPeopleForm
    Private formLoaded As Boolean = False
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        errProv.Clear()

        If cmbMenu.SelectedItem Is "Create" Then
            'NEW PERSON
            'Error handling: name must exist
            If txtName.Text = "" Then
                Beep()
                errProv.SetError(txtName, "Name field cannot be blank.")
                txtName.Focus()
                Return
            End If
            'temp person
            Dim temp As New Person(-1, txtName.Text)
            'error handling: likes > 0
            If clstLikes.CheckedItems.Count = 0 Then
                Beep()
                errProv.SetError(clstLikes, "Select at least one Like.")
            End If
            'logic handling: likes/dislikes can't share items
            For Each item In clstLikes.CheckedItems
                If clstDislikes.CheckedItems.Contains(item) Then
                    Beep()
                    errProv.SetError(btnConfirm, "Likes/Dislikes lists cannot share items.")
                    Return
                End If
            Next
            'copy likes from chklst to temp person
            Dim hate As New List(Of Tag)
            For Each item In clstLikes.CheckedItems
                'temp.Likes.Add(CType(item, Tag))
                hate.Add(CType(item, Tag))
            Next
            temp.Likes = hate
            'ditto dislikes
            Dim hate2 As New List(Of Tag)
            If clstDislikes.CheckedItems.Count > 0 Then
                For Each item In clstDislikes.CheckedItems
                    'temp.Dislikes.Add(CType(item, Tag))
                    hate2.Add(CType(item, Tag))
                Next
            End If
            temp.Dislikes = hate2
            'error out if person record can't be entered, else continue
            If Not DBUtilities.InsertPerson(temp) Then
                Beep()
                errProv.SetError(btnConfirm, DBUtilities.LastStatus)
                Return
            End If
            OptionsControl.ChangesMade = True
            'get the new record's id
            temp.ID = DBUtilities.GetNewPersonEntry
            'use that id to enter like lines -
            DBUtilities.InsertLikeLines(temp)
            '- and, if the person has dislikes, enter those too.
            If temp.Dislikes.Count > 0 Then
                DBUtilities.InsertDislikeLines(temp)
            End If
        ElseIf cmbMenu.SelectedItem Is "Update" Then
            'EDIT PERSON
            'error handling: name must exist
            If txtName.Text = "" Then
                Beep()
                errProv.SetError(txtName, "Name field cannot be blank.")
                txtName.Focus()
                Return
            End If
            'temp person
            Dim temp As New Person(CType(cmbName.SelectedItem, Person).ID, txtName.Text)
            'error handling: likes > 0
            If clstLikes.CheckedItems.Count = 0 Then
                Beep()
                errProv.SetError(clstLikes, "Select at least one Like.")
            End If
            'logic handling: likes/dislikes can't share items
            For Each item In clstLikes.CheckedItems
                If clstDislikes.CheckedItems.Contains(item) Then
                    Beep()
                    errProv.SetError(btnConfirm, "Likes/Dislikes lists cannot share items.")
                    Return
                End If
            Next
            'copy likes from chklst to temp person and -
            Dim hatred As New List(Of Tag)
            For Each item In clstLikes.CheckedItems
                hatred.Add(CType(item, Tag))
            Next
            temp.Likes = hatred
            '- ditto dislikes
            Dim moreHatred As New List(Of Tag)
            If clstDislikes.CheckedItems.Count > 0 Then
                For Each item In clstDislikes.CheckedItems
                    moreHatred.Add(CType(item, Tag))
                Next
                temp.Dislikes = moreHatred
            End If
            'If the names are different, update the name
            If Not txtName.Text.Equals(CType(cmbName.SelectedItem, Person).Name) Then
                'error out if person record can't be updated, else continue
                If Not DBUtilities.UpdatePerson(CType(cmbName.SelectedValue, Person), temp) Then
                    Beep()
                    errProv.SetError(btnConfirm, DBUtilities.LastStatus)
                    Return
                End If
                OptionsControl.ChangesMade = True
            End If
            'if temp's likes don't equal the selected person's likes, delete the
            'like lines from the db and replace them.
            If Not temp.Likes.Equals(CType(cmbName.SelectedItem, Person).Likes) Then
                DBUtilities.DeleteLikeLines(CType(cmbName.SelectedItem, Person))
                DBUtilities.InsertLikeLines(temp)
            End If
            'ditto dislikes
            If Not temp.Dislikes.Equals(CType(cmbName.SelectedItem, Person).Dislikes) Then
                DBUtilities.DeleteDislikeLines(CType(cmbName.SelectedItem, Person))
                DBUtilities.InsertDislikeLines(temp)
            End If
        Else 'if cmbMenu.SelectedItem Is "Delete" Then
            Dim temp As New Person(CType(cmbName.SelectedItem, Person))
            'delete like lines
            DBUtilities.DeleteLikeLines(temp)
            'delete dislike lines
            DBUtilities.DeleteDislikeLines(temp)
            'delete attendance lines
            DBUtilities.DeleteAttendanceLines(temp)
            'delete person
            DBUtilities.DeletePerson(temp)
            OptionsControl.ChangesMade = True
        End If
        MessageBox.Show("Success.")
        ResetLists()
        cmbName.SelectedIndex = 0
    End Sub

    Private Sub cmbMenu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMenu.SelectedIndexChanged
        If formLoaded = True Then

            If cmbMenu.SelectedItem Is "Create" Then
                'txtName.Visible = True
                txtName.Enabled = True
                cmbName.Enabled = False
                'cmbName.Visible = False
                txtName.Text = ""
                clstLikes.Enabled = True
                clstDislikes.Enabled = True
            ElseIf cmbMenu.SelectedItem Is "Update" Then
                'txtName.Visible = False
                txtName.Enabled = True
                txtName.Text = ""
                'cmbName.Visible = True
                cmbName.Enabled = True
                cmbName.SelectedIndex = -1
                clstDislikes.Enabled = True
                clstLikes.Enabled = True
            Else 'if cmbMenu.SelectedItem = "Delete" then
                'txtName.Visible = False
                txtName.Enabled = False
                txtName.Text = ""
                'cmbName.Visible = True
                cmbName.Enabled = True
                clstLikes.SelectedItems.Clear()
                clstDislikes.SelectedItems.Clear()
                cmbName.SelectedIndex = -1

            End If
        End If
    End Sub

    Private Sub EditPeopleForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'OptionsControl.PeopleMasterList = DBUtilities.GetMembersList()
        'OptionsControl.LoadPrefs()
        ResetLists()

        OptionsControl.TagMasterList = DBUtilities.GetTagList()
        'cmbName.DataSource = OptionsControl.PeopleMasterList
        formLoaded = True

        For Each item In OptionsControl.TagMasterList
            clstDislikes.Items.Add(item)
            clstLikes.Items.Add(item)
        Next
        ResetLists()
        cmbName.SelectedIndex = -1
    End Sub

    Private Sub ResetLists()
        OptionsControl.PeopleMasterList.Clear()
        OptionsControl.PeopleMasterList = DBUtilities.GetMembersList
        cmbName.Items.Clear()

        For Each buddy In OptionsControl.PeopleMasterList
            cmbName.Items.Add(buddy)
        Next
        OptionsControl.LoadPrefs()

    End Sub

    Private Sub cmbName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbName.SelectedIndexChanged
        If formLoaded = True And Not cmbName.SelectedIndex = -1 Then
            For i As Integer = 0 To clstLikes.Items.Count - 1
                If (CType(cmbName.SelectedItem, Person).Likes.Contains(CType(clstLikes.Items(i), Tag))) Then
                    clstLikes.SetItemChecked(i, True)
                Else
                    clstLikes.SetItemChecked(i, False)
                End If
            Next
            For i As Integer = 0 To clstDislikes.Items.Count - 1
                If (CType(cmbName.SelectedItem, Person).Dislikes.Contains(CType(clstDislikes.Items(i), Tag))) Then
                    clstDislikes.SetItemChecked(i, True)
                Else
                    clstDislikes.SetItemChecked(i, False)
                End If
            Next
            txtName.Text = CType(cmbName.SelectedItem, Person).Name
        End If

    End Sub
End Class