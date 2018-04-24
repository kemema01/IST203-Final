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
        Me.components = New System.ComponentModel.Container()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.grpMenu = New System.Windows.Forms.GroupBox()
        Me.cmbMenu = New System.Windows.Forms.ComboBox()
        Me.grpName = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCost = New System.Windows.Forms.ComboBox()
        Me.cmbName = New System.Windows.Forms.ComboBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.grpTags = New System.Windows.Forms.GroupBox()
        Me.lstUsedTags = New System.Windows.Forms.ListBox()
        Me.grpRest = New System.Windows.Forms.GroupBox()
        Me.lstAllTags = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.errProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.chkDelivery = New System.Windows.Forms.CheckBox()
        Me.chkCarryOut = New System.Windows.Forms.CheckBox()
        Me.chkDineIn = New System.Windows.Forms.CheckBox()
        Me.grpMenu.SuspendLayout()
        Me.grpName.SuspendLayout()
        Me.grpTags.SuspendLayout()
        Me.grpRest.SuspendLayout()
        CType(Me.errProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(12, 492)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 18
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(353, 492)
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
        Me.cmbMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMenu.FormattingEnabled = True
        Me.cmbMenu.Items.AddRange(New Object() {"Create", "Update", "Delete"})
        Me.cmbMenu.Location = New System.Drawing.Point(6, 22)
        Me.cmbMenu.Name = "cmbMenu"
        Me.cmbMenu.Size = New System.Drawing.Size(194, 24)
        Me.cmbMenu.TabIndex = 0
        '
        'grpName
        '
        Me.grpName.Controls.Add(Me.Label3)
        Me.grpName.Controls.Add(Me.Label2)
        Me.grpName.Controls.Add(Me.cmbCost)
        Me.grpName.Controls.Add(Me.cmbName)
        Me.grpName.Controls.Add(Me.txtName)
        Me.grpName.Location = New System.Drawing.Point(223, 55)
        Me.grpName.Name = "grpName"
        Me.grpName.Size = New System.Drawing.Size(205, 111)
        Me.grpName.TabIndex = 14
        Me.grpName.TabStop = False
        Me.grpName.Text = "Restaurant"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cost:"
        '
        'cmbCost
        '
        Me.cmbCost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCost.Enabled = False
        Me.cmbCost.FormattingEnabled = True
        Me.cmbCost.Items.AddRange(New Object() {"$", "$$", "$$$"})
        Me.cmbCost.Location = New System.Drawing.Point(61, 80)
        Me.cmbCost.Name = "cmbCost"
        Me.cmbCost.Size = New System.Drawing.Size(139, 24)
        Me.cmbCost.TabIndex = 2
        '
        'cmbName
        '
        Me.cmbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbName.FormattingEnabled = True
        Me.cmbName.Location = New System.Drawing.Point(6, 22)
        Me.cmbName.Name = "cmbName"
        Me.cmbName.Size = New System.Drawing.Size(194, 24)
        Me.cmbName.TabIndex = 1
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(61, 52)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(139, 22)
        Me.txtName.TabIndex = 0
        '
        'grpTags
        '
        Me.grpTags.Controls.Add(Me.lstUsedTags)
        Me.grpTags.Location = New System.Drawing.Point(223, 214)
        Me.grpTags.Name = "grpTags"
        Me.grpTags.Size = New System.Drawing.Size(205, 240)
        Me.grpTags.TabIndex = 17
        Me.grpTags.TabStop = False
        Me.grpTags.Text = "Associated Tags"
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
        'grpRest
        '
        Me.grpRest.Controls.Add(Me.lstAllTags)
        Me.grpRest.Location = New System.Drawing.Point(12, 214)
        Me.grpRest.Name = "grpRest"
        Me.grpRest.Size = New System.Drawing.Size(205, 240)
        Me.grpRest.TabIndex = 16
        Me.grpRest.TabStop = False
        Me.grpRest.Text = "All Tags"
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
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(416, 29)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "The power to change a restaurant without all the reponsibility."
        '
        'btnRemove
        '
        Me.btnRemove.Enabled = False
        Me.btnRemove.Location = New System.Drawing.Point(223, 460)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(100, 25)
        Me.btnRemove.TabIndex = 20
        Me.btnRemove.Text = "< Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(117, 460)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 25)
        Me.btnAdd.TabIndex = 19
        Me.btnAdd.Text = "Add >"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'errProv
        '
        Me.errProv.ContainerControl = Me
        '
        'chkDelivery
        '
        Me.chkDelivery.AutoSize = True
        Me.chkDelivery.Location = New System.Drawing.Point(345, 172)
        Me.chkDelivery.Name = "chkDelivery"
        Me.chkDelivery.Size = New System.Drawing.Size(81, 21)
        Me.chkDelivery.TabIndex = 22
        Me.chkDelivery.Text = "Delivery"
        Me.chkDelivery.UseVisualStyleBackColor = True
        '
        'chkCarryOut
        '
        Me.chkCarryOut.AutoSize = True
        Me.chkCarryOut.Location = New System.Drawing.Point(178, 172)
        Me.chkCarryOut.Name = "chkCarryOut"
        Me.chkCarryOut.Size = New System.Drawing.Size(91, 21)
        Me.chkCarryOut.TabIndex = 23
        Me.chkCarryOut.Text = "Carry Out"
        Me.chkCarryOut.UseVisualStyleBackColor = True
        '
        'chkDineIn
        '
        Me.chkDineIn.AutoSize = True
        Me.chkDineIn.Location = New System.Drawing.Point(18, 172)
        Me.chkDineIn.Name = "chkDineIn"
        Me.chkDineIn.Size = New System.Drawing.Size(74, 21)
        Me.chkDineIn.TabIndex = 21
        Me.chkDineIn.Text = "Dine In"
        Me.chkDineIn.UseVisualStyleBackColor = True
        '
        'EditRestaurantsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 528)
        Me.Controls.Add(Me.chkDelivery)
        Me.Controls.Add(Me.chkCarryOut)
        Me.Controls.Add(Me.chkDineIn)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
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
        CType(Me.errProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents errProv As ErrorProvider
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbCost As ComboBox
    Friend WithEvents chkDelivery As CheckBox
    Friend WithEvents chkCarryOut As CheckBox
    Friend WithEvents chkDineIn As CheckBox
    Friend WithEvents Label3 As Label
End Class
