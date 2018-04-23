<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditRestaurantsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.grpMenu = New System.Windows.Forms.GroupBox()
        Me.cmbMenu = New System.Windows.Forms.ComboBox()
        Me.grpName = New System.Windows.Forms.GroupBox()
        Me.cmbName = New System.Windows.Forms.ComboBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.grpTags = New System.Windows.Forms.GroupBox()
        Me.grpRest = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstAllTags = New System.Windows.Forms.ListBox()
        Me.lstUsedTags = New System.Windows.Forms.ListBox()
        Me.grpMenu.SuspendLayout()
        Me.grpName.SuspendLayout()
        Me.grpTags.SuspendLayout()
        Me.grpRest.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(18, 387)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 18
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(348, 387)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirm.TabIndex = 13
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'grpMenu
        '
        Me.grpMenu.Controls.Add(Me.cmbMenu)
        Me.grpMenu.Location = New System.Drawing.Point(12, 55)
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Size = New System.Drawing.Size(205, 80)
        Me.grpMenu.TabIndex = 15
        Me.grpMenu.TabStop = False
        Me.grpMenu.Text = "Operation"
        '
        'cmbMenu
        '
        Me.cmbMenu.FormattingEnabled = True
        Me.cmbMenu.Items.AddRange(New Object() {"Create", "Update", "Delete"})
        Me.cmbMenu.Location = New System.Drawing.Point(6, 22)
        Me.cmbMenu.Name = "cmbMenu"
        Me.cmbMenu.Size = New System.Drawing.Size(194, 24)
        Me.cmbMenu.TabIndex = 0
        '
        'grpName
        '
        Me.grpName.Controls.Add(Me.cmbName)
        Me.grpName.Controls.Add(Me.txtName)
        Me.grpName.Location = New System.Drawing.Point(223, 55)
        Me.grpName.Name = "grpName"
        Me.grpName.Size = New System.Drawing.Size(205, 80)
        Me.grpName.TabIndex = 14
        Me.grpName.TabStop = False
        Me.grpName.Text = "Restaurant"
        '
        'cmbName
        '
        Me.cmbName.Enabled = False
        Me.cmbName.FormattingEnabled = True
        Me.cmbName.Location = New System.Drawing.Point(6, 22)
        Me.cmbName.Name = "cmbName"
        Me.cmbName.Size = New System.Drawing.Size(194, 24)
        Me.cmbName.TabIndex = 1
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(6, 52)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(194, 22)
        Me.txtName.TabIndex = 0
        '
        'grpTags
        '
        Me.grpTags.Controls.Add(Me.lstUsedTags)
        Me.grpTags.Location = New System.Drawing.Point(223, 141)
        Me.grpTags.Name = "grpTags"
        Me.grpTags.Size = New System.Drawing.Size(205, 240)
        Me.grpTags.TabIndex = 17
        Me.grpTags.TabStop = False
        Me.grpTags.Text = "Associated Tags"
        '
        'grpRest
        '
        Me.grpRest.Controls.Add(Me.lstAllTags)
        Me.grpRest.Location = New System.Drawing.Point(12, 141)
        Me.grpRest.Name = "grpRest"
        Me.grpRest.Size = New System.Drawing.Size(205, 240)
        Me.grpRest.TabIndex = 16
        Me.grpRest.TabStop = False
        Me.grpRest.Text = "All Tags"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(416, 29)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "The power to change a restaurant without all the reponsibility."
        '
        'lstAllTags
        '
        Me.lstAllTags.FormattingEnabled = True
        Me.lstAllTags.ItemHeight = 16
        Me.lstAllTags.Location = New System.Drawing.Point(6, 21)
        Me.lstAllTags.Name = "lstAllTags"
        Me.lstAllTags.Size = New System.Drawing.Size(193, 212)
        Me.lstAllTags.TabIndex = 0
        '
        'lstUsedTags
        '
        Me.lstUsedTags.FormattingEnabled = True
        Me.lstUsedTags.ItemHeight = 16
        Me.lstUsedTags.Location = New System.Drawing.Point(6, 21)
        Me.lstUsedTags.Name = "lstUsedTags"
        Me.lstUsedTags.Size = New System.Drawing.Size(193, 212)
        Me.lstUsedTags.TabIndex = 1
        '
        'EditRestaurantsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 414)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.grpMenu)
        Me.Controls.Add(Me.grpName)
        Me.Controls.Add(Me.grpTags)
        Me.Controls.Add(Me.grpRest)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditRestaurantsForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Restaurats"
        Me.grpMenu.ResumeLayout(False)
        Me.grpName.ResumeLayout(False)
        Me.grpName.PerformLayout()
        Me.grpTags.ResumeLayout(False)
        Me.grpRest.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnConfirm As Button
    Friend WithEvents grpMenu As GroupBox
    Friend WithEvents cmbMenu As ComboBox
    Friend WithEvents grpName As GroupBox
    Friend WithEvents cmbName As ComboBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents grpTags As GroupBox
    Friend WithEvents grpRest As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lstUsedTags As ListBox
    Friend WithEvents lstAllTags As ListBox
End Class
