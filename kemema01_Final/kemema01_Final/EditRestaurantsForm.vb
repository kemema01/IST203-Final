Public Class EditRestaurantsForm
    Private formLoaded As Boolean = False
    Private Sub EditRestaurantsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OptionsControl.TagMasterList = DBUtilities.GetTagList
        ResetLists()
        cmbName.DataSource = OptionsControl.RestMasterList
        formLoaded = True
        cmbName.SelectedIndex = -1
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        'create
        'validate name
        'validate tags > 0
        'temp rest -> id -1, name = txt
        'list items -> temp.tags
        'temp -> db
        'tags -> db

        'consult people updating procedure

        'delete
        OptionsControl.ChangesMade = True
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'move tag from wanted list to master list
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        errProv.Clear()
        If Not lstUsedTags.SelectedIndex = -1 Then
            lstAllTags.Items.Add(lstUsedTags.SelectedItem)
            lstUsedTags.Items.Remove(lstUsedTags.SelectedItem)
        Else
            Beep()
            errProv.SetError(btnRemove, "Select a tag to remove!")
            Return
        End If
    End Sub

    'move tag from master list to wanted list
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        errProv.Clear()
        If Not lstAllTags.SelectedIndex = -1 Then
            lstUsedTags.Items.Add(lstAllTags.SelectedItem)
            lstAllTags.Items.Remove(lstAllTags.SelectedItem)
        Else
            Beep()
            errProv.SetError(btnAdd, "Select a tag to add!")
            Return
        End If
    End Sub

    Private Sub ResetLists()
        OptionsControl.RestMasterList.Clear()
        OptionsControl.RestMasterList = DBUtilities.GetRestList

    End Sub

    Private Sub cmbName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbName.SelectedIndexChanged

        If (formLoaded = True) And (Not cmbName.SelectedIndex = -1) Then
            txtName.Text = CType(cmbName.SelectedValue, Restaurant).Name
            lstAllTags.Items.Clear()
            lstUsedTags.Items.Clear()
            For Each item In CType(cmbName.SelectedValue, Restaurant).GetTags
                lstUsedTags.Items.Add(item)
            Next
            For Each item In OptionsControl.TagMasterList
                If Not lstUsedTags.Items.Contains(item) Then
                    lstAllTags.Items.Add(item)
                End If
            Next
        End If
    End Sub

    Private Sub cmbMenu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMenu.SelectedIndexChanged
        If cmbMenu.SelectedItem Is "Create" Then
            txtName.Enabled = True

        ElseIf cmbMenu.SelectedItem Is "Update" Then
            txtName.Enabled = True
        Else 'if cmbMenu.SelectedItem Is "Delete" Then
            txtName.Enabled = False
        End If
    End Sub
End Class