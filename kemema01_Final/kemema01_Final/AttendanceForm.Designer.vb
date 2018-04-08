<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AttendanceForm
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
        Me.lstAllPeople = New System.Windows.Forms.ListBox()
        Me.lstPresent = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpAll = New System.Windows.Forms.GroupBox()
        Me.grpPresent = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.errProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpAll.SuspendLayout()
        Me.grpPresent.SuspendLayout()
        CType(Me.errProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstAllPeople
        '
        Me.lstAllPeople.FormattingEnabled = True
        Me.lstAllPeople.ItemHeight = 16
        Me.lstAllPeople.Location = New System.Drawing.Point(6, 21)
        Me.lstAllPeople.Name = "lstAllPeople"
        Me.lstAllPeople.Size = New System.Drawing.Size(188, 164)
        Me.lstAllPeople.TabIndex = 0
        '
        'lstPresent
        '
        Me.lstPresent.FormattingEnabled = True
        Me.lstPresent.ItemHeight = 16
        Me.lstPresent.Location = New System.Drawing.Point(6, 21)
        Me.lstPresent.Name = "lstPresent"
        Me.lstPresent.Size = New System.Drawing.Size(188, 164)
        Me.lstPresent.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(406, 41)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "First, The Decider needs to know which members of the group are here."
        '
        'grpAll
        '
        Me.grpAll.Controls.Add(Me.lstAllPeople)
        Me.grpAll.Location = New System.Drawing.Point(12, 53)
        Me.grpAll.Name = "grpAll"
        Me.grpAll.Size = New System.Drawing.Size(200, 192)
        Me.grpAll.TabIndex = 3
        Me.grpAll.TabStop = False
        Me.grpAll.Text = "All Group Members:"
        '
        'grpPresent
        '
        Me.grpPresent.Controls.Add(Me.lstPresent)
        Me.grpPresent.Location = New System.Drawing.Point(218, 53)
        Me.grpPresent.Name = "grpPresent"
        Me.grpPresent.Size = New System.Drawing.Size(200, 192)
        Me.grpPresent.TabIndex = 4
        Me.grpPresent.TabStop = False
        Me.grpPresent.Text = "Present Group Members:"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(106, 251)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 25)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add >"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(224, 251)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(100, 25)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.Text = "< Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(12, 282)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 25)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnContinue
        '
        Me.btnContinue.Location = New System.Drawing.Point(318, 282)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(100, 25)
        Me.btnContinue.TabIndex = 8
        Me.btnContinue.Text = "Continue"
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(165, 282)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(100, 25)
        Me.btnReset.TabIndex = 9
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'errProv
        '
        Me.errProv.ContainerControl = Me
        '
        'AttendanceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 318)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnContinue)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.grpPresent)
        Me.Controls.Add(Me.grpAll)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AttendanceForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Who is here?"
        Me.grpAll.ResumeLayout(False)
        Me.grpPresent.ResumeLayout(False)
        CType(Me.errProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstAllPeople As ListBox
    Friend WithEvents lstPresent As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents grpAll As GroupBox
    Friend WithEvents grpPresent As GroupBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnContinue As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents errProv As ErrorProvider
End Class
