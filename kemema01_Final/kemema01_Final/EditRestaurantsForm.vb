Public Class EditRestaurantsForm
    Private formLoaded As Boolean = False
    Private Sub EditRestaurantsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OptionsControl.TagMasterList = DBUtilities.GetTagList
        ResetLists()
        lstAllTags.Sorted = True
        lstUsedTags.Sorted = True
        cmbName.Sorted = True
        formLoaded = True
        cmbName.SelectedIndex = -1
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        errProv.Clear()

        If cmbMenu.SelectedItem Is "Create" Then
            'NEW RESTAURANT
            'Error handling: name must exist
            If txtName.Text = "" Then
                Beep()
                errProv.SetError(txtName, "Name field cannot be blank.")
                txtName.Focus()
                Return
            End If
            'error handling: cost must be set
            If cmbCost.SelectedIndex = -1 Then
                Beep()
                errProv.SetError(cmbCost, "Select a relative cost.")
                Return
            End If
            'temp restaurant
            Dim temp As New Restaurant(-1, txtName.Text, cmbCost.SelectedIndex + 1, chkDineIn.Checked, chkCarryOut.Checked, chkDelivery.Checked)
            'error handling: tags > 0
            If lstUsedTags.Items.Count = 0 Then
                Beep()
                errProv.SetError(lstUsedTags, "Select at least one Tag.")
            End If
            'copy tags from lstUsedTags to temp restaurant
            Dim ph As New List(Of Tag)
            For Each item In lstUsedTags.Items
                ph.Add(CType(item, Tag))
            Next
            temp.CopyTags(ph)
            'error out if restaurant record can't be entered, else continue
            If Not DBUtilities.InsertRestaurant(temp) Then
                Beep()
                errProv.SetError(btnConfirm, DBUtilities.LastStatus)
                Return
            End If
            OptionsControl.ChangesMade = True
            'get the new record's id
            temp.ID = DBUtilities.GetNewRestEntry
            'use that id to enter like lines -
            DBUtilities.InsertTagLines(temp)

        ElseIf cmbMenu.SelectedItem Is "Update" Then
            'EDIT REST
            'Error handling: name must exist
            If txtName.Text = "" Then
                Beep()
                errProv.SetError(txtName, "Name field cannot be blank.")
                txtName.Focus()
                Return
            End If
            'error handling: cost must be set
            If cmbCost.SelectedIndex = -1 Then
                Beep()
                errProv.SetError(cmbCost, "Select a relative cost.")
                Return
            End If
            'error handling: tags > 0
            If lstUsedTags.Items.Count = 0 Then
                Beep()
                errProv.SetError(lstUsedTags, "Select at least one Tag.")
            End If
            'temp restaurant
            Dim temp As New Restaurant(CType(cmbName.SelectedItem, Restaurant).ID, txtName.Text, cmbCost.SelectedIndex + 1, chkDineIn.Checked, chkCarryOut.Checked, chkDelivery.Checked)
            'copy tags from lstUsedTags to temp restaurant
            Dim ph As New List(Of Tag)
            For Each item In lstUsedTags.Items
                ph.Add(CType(item, Tag))
            Next
            temp.CopyTags(ph)
            'Update the record
            If Not DBUtilities.UpdateRestaurant(CType(cmbName.SelectedItem, Restaurant), temp) Then
                Beep()
                errProv.SetError(btnConfirm, DBUtilities.LastStatus)
                Return
            End If
            'delete and replace tag lines associated with the ID inherited from cmbName.selectedvalue
            DBUtilities.DeleteTagLines(temp)
            DBUtilities.InsertTagLines(temp)
        Else 'if cmbMenu.SelectedItem Is "Delete" Then
            Dim temp As New Restaurant(CType(cmbName.SelectedItem, Restaurant))
            'delete tags
            DBUtilities.DeleteTagLines(temp)
            'delete attendance lines
            DBUtilities.DeleteAttendanceLines(temp)
            'delete person
            DBUtilities.DeleteRestaurant(temp)
            OptionsControl.ChangesMade = True
        End If
        MessageBox.Show("Success.")
        ResetLists()
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
        cmbName.Items.Clear()
        OptionsControl.RestMasterList = DBUtilities.GetRestList
        For Each rest In OptionsControl.RestMasterList
            cmbName.Items.Add(rest)
        Next
        cmbName.SelectedIndex = 0
    End Sub

    Private Sub cmbName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbName.SelectedIndexChanged

        If (formLoaded = True) And (Not cmbName.SelectedIndex = -1) Then
            txtName.Text = CType(cmbName.SelectedItem, Restaurant).Name
            chkDineIn.Checked = CType(cmbName.SelectedItem, Restaurant).DineIn
            chkCarryOut.Checked = CType(cmbName.SelectedItem, Restaurant).CarryOut
            chkDelivery.Checked = CType(cmbName.SelectedItem, Restaurant).Delivery
            cmbCost.SelectedIndex = CType(cmbName.SelectedItem, Restaurant).Cost - 1
            lstAllTags.Items.Clear()
            lstUsedTags.Items.Clear()
            For Each item In CType(cmbName.SelectedItem, Restaurant).GetTags
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
            cmbCost.Enabled = True
            lstAllTags.Items.Clear()
            lstUsedTags.Items.Clear()
            For Each item In OptionsControl.TagMasterList
                lstAllTags.Items.Add(item)
            Next
            btnAdd.Enabled = True
            btnRemove.Enabled = True
        ElseIf cmbMenu.SelectedItem Is "Update" Then
            txtName.Enabled = True
            cmbCost.Enabled = True
            btnRemove.Enabled = True
            btnAdd.Enabled = True
        Else 'if cmbMenu.SelectedItem Is "Delete" Then
            txtName.Enabled = False
            cmbCost.Enabled = False
            btnAdd.Enabled = False
            btnRemove.Enabled = False
        End If
    End Sub
End Class