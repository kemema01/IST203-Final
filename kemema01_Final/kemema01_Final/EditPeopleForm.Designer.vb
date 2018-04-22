<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditPeopleForm
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpTags = New System.Windows.Forms.GroupBox()
        Me.clstDislikes = New System.Windows.Forms.CheckedListBox()
        Me.grpRest = New System.Windows.Forms.GroupBox()
        Me.clstLikes = New System.Windows.Forms.CheckedListBox()
        Me.grpName = New System.Windows.Forms.GroupBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.grpMenu = New System.Windows.Forms.GroupBox()
        Me.cmbMenu = New System.Windows.Forms.ComboBox()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.cmbName = New System.Windows.Forms.ComboBox()
        Me.errProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpTags.SuspendLayout()
        Me.grpRest.SuspendLayout()
        Me.grpName.SuspendLayout()
        Me.grpMenu.SuspendLayout()
        CType(Me.errProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(416, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "In life, you can't change your friends. In The Decider, you can."
        '
        'grpTags
        '
        Me.grpTags.Controls.Add(Me.clstDislikes)
        Me.grpTags.Location = New System.Drawing.Point(223, 141)
        Me.grpTags.Name = "grpTags"
        Me.grpTags.Size = New System.Drawing.Size(205, 240)
        Me.grpTags.TabIndex = 10
        Me.grpTags.TabStop = False
        Me.grpTags.Text = "Dislikes"
        '
        'clstDislikes
        '
        Me.clstDislikes.CheckOnClick = True
        Me.clstDislikes.Enabled = False
        Me.clstDislikes.FormattingEnabled = True
        Me.clstDislikes.Location = New System.Drawing.Point(6, 21)
        Me.clstDislikes.Name = "clstDislikes"
        Me.clstDislikes.Size = New System.Drawing.Size(194, 208)
        Me.clstDislikes.TabIndex = 1
        '
        'grpRest
        '
        Me.grpRest.Controls.Add(Me.clstLikes)
        Me.grpRest.Location = New System.Drawing.Point(12, 141)
        Me.grpRest.Name = "grpRest"
        Me.grpRest.Size = New System.Drawing.Size(205, 240)
        Me.grpRest.TabIndex = 9
        Me.grpRest.TabStop = False
        Me.grpRest.Text = "Likes"
        '
        'clstLikes
        '
        Me.clstLikes.CheckOnClick = True
        Me.clstLikes.Enabled = False
        Me.clstLikes.FormattingEnabled = True
        Me.clstLikes.Location = New System.Drawing.Point(6, 21)
        Me.clstLikes.Name = "clstLikes"
        Me.clstLikes.Size = New System.Drawing.Size(194, 208)
        Me.clstLikes.TabIndex = 0
        '
        'grpName
        '
        Me.grpName.Controls.Add(Me.cmbName)
        Me.grpName.Controls.Add(Me.txtName)
        Me.grpName.Location = New System.Drawing.Point(223, 55)
        Me.grpName.Name = "grpName"
        Me.grpName.Size = New System.Drawing.Size(205, 80)
        Me.grpName.TabIndex = 2
        Me.grpName.TabStop = False
        Me.grpName.Text = "Name"
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(6, 52)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(194, 22)
        Me.txtName.TabIndex = 0
        '
        'grpMenu
        '
        Me.grpMenu.Controls.Add(Me.cmbMenu)
        Me.grpMenu.Location = New System.Drawing.Point(12, 55)
        Me.grpMenu.Name = "grpMenu"
        Me.grpMenu.Size = New System.Drawing.Size(205, 80)
        Me.grpMenu.TabIndex = 3
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
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(348, 387)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirm.TabIndex = 1
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(18, 387)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
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
        'errProv
        '
        Me.errProv.ContainerControl = Me
        '
        'EditPeopleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 419)
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
        Me.Name = "EditPeopleForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EditPeople"
        Me.grpTags.ResumeLayout(False)
        Me.grpRest.ResumeLayout(False)
        Me.grpName.ResumeLayout(False)
        Me.grpName.PerformLayout()
        Me.grpMenu.ResumeLayout(False)
        CType(Me.errProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents grpTags As GroupBox
    Friend WithEvents clstDislikes As CheckedListBox
    Friend WithEvents grpRest As GroupBox
    Friend WithEvents clstLikes As CheckedListBox
    Friend WithEvents grpName As GroupBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents grpMenu As GroupBox
    Friend WithEvents cmbMenu As ComboBox
    Friend WithEvents btnConfirm As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents cmbName As ComboBox
    Friend WithEvents errProv As ErrorProvider
End Class
