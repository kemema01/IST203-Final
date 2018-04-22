Option Explicit On
Option Strict On

Public Class OptionsForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        If cmbSelection.SelectedItem Is "People" Then
            EditPeopleForm.ShowDialog()
        End If
    End Sub

    Private Sub OptionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSelection.SelectedIndex = -1
    End Sub
End Class