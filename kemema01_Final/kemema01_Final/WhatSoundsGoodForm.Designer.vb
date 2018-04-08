<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WhatSoundsGoodForm
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
        Me.lstAllTags = New System.Windows.Forms.ListBox()
        Me.lstDesiredTags = New System.Windows.Forms.ListBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.grpDesired = New System.Windows.Forms.GroupBox()
        Me.grpAllTags = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkDineIn = New System.Windows.Forms.CheckBox()
        Me.chkCarryOut = New System.Windows.Forms.CheckBox()
        Me.chkDelivery = New System.Windows.Forms.CheckBox()
        Me.errprov = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpDesired.SuspendLayout()
        Me.grpAllTags.SuspendLayout()
        CType(Me.errprov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstAllTags
        '
        Me.lstAllTags.FormattingEnabled = True
        Me.lstAllTags.ItemHeight = 16
        Me.lstAllTags.Location = New System.Drawing.Point(6, 21)
        Me.lstAllTags.Name = "lstAllTags"
        Me.lstAllTags.Size = New System.Drawing.Size(188, 164)
        Me.lstAllTags.TabIndex = 0
        '
        'lstDesiredTags
        '
        Me.lstDesiredTags.FormattingEnabled = True
        Me.lstDesiredTags.ItemHeight = 16
        Me.lstDesiredTags.Location = New System.Drawing.Point(6, 21)
        Me.lstDesiredTags.Name = "lstDesiredTags"
        Me.lstDesiredTags.Size = New System.Drawing.Size(188, 164)
        Me.lstDesiredTags.TabIndex = 1
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(165, 309)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(100, 25)
        Me.btnReset.TabIndex = 7
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnContinue
        '
        Me.btnContinue.Location = New System.Drawing.Point(318, 309)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(100, 25)
        Me.btnContinue.TabIndex = 8
        Me.btnContinue.Text = "Continue"
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(12, 309)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 25)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(224, 278)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(100, 25)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.Text = "< Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(106, 278)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 25)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add >"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'grpDesired
        '
        Me.grpDesired.Controls.Add(Me.lstDesiredTags)
        Me.grpDesired.Location = New System.Drawing.Point(218, 80)
        Me.grpDesired.Name = "grpDesired"
        Me.grpDesired.Size = New System.Drawing.Size(200, 192)
        Me.grpDesired.TabIndex = 4
        Me.grpDesired.TabStop = False
        Me.grpDesired.Text = "Desired Tags"
        '
        'grpAllTags
        '
        Me.grpAllTags.Controls.Add(Me.lstAllTags)
        Me.grpAllTags.Location = New System.Drawing.Point(12, 80)
        Me.grpAllTags.Name = "grpAllTags"
        Me.grpAllTags.Size = New System.Drawing.Size(200, 192)
        Me.grpAllTags.TabIndex = 3
        Me.grpAllTags.TabStop = False
        Me.grpAllTags.Text = "All Tags"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(406, 26)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Next, The Decider needs to know what the group is hungry for."
        '
        'chkDineIn
        '
        Me.chkDineIn.AutoSize = True
        Me.chkDineIn.Location = New System.Drawing.Point(12, 53)
        Me.chkDineIn.Name = "chkDineIn"
        Me.chkDineIn.Size = New System.Drawing.Size(74, 21)
        Me.chkDineIn.TabIndex = 0
        Me.chkDineIn.Text = "Dine In"
        Me.chkDineIn.UseVisualStyleBackColor = True
        '
        'chkCarryOut
        '
        Me.chkCarryOut.AutoSize = True
        Me.chkCarryOut.Location = New System.Drawing.Point(318, 53)
        Me.chkCarryOut.Name = "chkCarryOut"
        Me.chkCarryOut.Size = New System.Drawing.Size(91, 21)
        Me.chkCarryOut.TabIndex = 2
        Me.chkCarryOut.Text = "Carry Out"
        Me.chkCarryOut.UseVisualStyleBackColor = True
        '
        'chkDelivery
        '
        Me.chkDelivery.AutoSize = True
        Me.chkDelivery.Location = New System.Drawing.Point(165, 53)
        Me.chkDelivery.Name = "chkDelivery"
        Me.chkDelivery.Size = New System.Drawing.Size(81, 21)
        Me.chkDelivery.TabIndex = 1
        Me.chkDelivery.Text = "Delivery"
        Me.chkDelivery.UseVisualStyleBackColor = True
        '
        'errprov
        '
        Me.errprov.ContainerControl = Me
        '
        'WhatSoundsGoodForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 343)
        Me.Controls.Add(Me.chkDelivery)
        Me.Controls.Add(Me.chkCarryOut)
        Me.Controls.Add(Me.chkDineIn)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnContinue)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.grpDesired)
        Me.Controls.Add(Me.grpAllTags)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WhatSoundsGoodForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "WhatSoundsGoodForm"
        Me.grpDesired.ResumeLayout(False)
        Me.grpAllTags.ResumeLayout(False)
        CType(Me.errprov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstAllTags As ListBox
    Friend WithEvents lstDesiredTags As ListBox
    Friend WithEvents btnReset As Button
    Friend WithEvents btnContinue As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents grpDesired As GroupBox
    Friend WithEvents grpAllTags As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkDineIn As CheckBox
    Friend WithEvents chkCarryOut As CheckBox
    Friend WithEvents chkDelivery As CheckBox
    Friend WithEvents errprov As ErrorProvider
End Class
