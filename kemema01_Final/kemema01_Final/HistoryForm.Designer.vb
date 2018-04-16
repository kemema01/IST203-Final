<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HistoryForm
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
        Me.lstHistory = New System.Windows.Forms.ListBox()
        Me.lstAttendance = New System.Windows.Forms.ListBox()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.grpAttendance = New System.Windows.Forms.GroupBox()
        Me.grpHistory = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.errprov = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpAttendance.SuspendLayout()
        Me.grpHistory.SuspendLayout()
        CType(Me.errprov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstHistory
        '
        Me.lstHistory.FormattingEnabled = True
        Me.lstHistory.ItemHeight = 16
        Me.lstHistory.Location = New System.Drawing.Point(6, 21)
        Me.lstHistory.Name = "lstHistory"
        Me.lstHistory.Size = New System.Drawing.Size(188, 196)
        Me.lstHistory.TabIndex = 0
        '
        'lstAttendance
        '
        Me.lstAttendance.FormattingEnabled = True
        Me.lstAttendance.ItemHeight = 16
        Me.lstAttendance.Location = New System.Drawing.Point(6, 21)
        Me.lstAttendance.Name = "lstAttendance"
        Me.lstAttendance.Size = New System.Drawing.Size(188, 196)
        Me.lstAttendance.TabIndex = 0
        '
        'btnDone
        '
        Me.btnDone.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDone.Location = New System.Drawing.Point(318, 267)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(100, 25)
        Me.btnDone.TabIndex = 3
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'grpAttendance
        '
        Me.grpAttendance.Controls.Add(Me.lstAttendance)
        Me.grpAttendance.Location = New System.Drawing.Point(218, 38)
        Me.grpAttendance.Name = "grpAttendance"
        Me.grpAttendance.Size = New System.Drawing.Size(200, 223)
        Me.grpAttendance.TabIndex = 2
        Me.grpAttendance.TabStop = False
        Me.grpAttendance.Text = "Members Present"
        '
        'grpHistory
        '
        Me.grpHistory.Controls.Add(Me.lstHistory)
        Me.grpHistory.Location = New System.Drawing.Point(12, 38)
        Me.grpHistory.Name = "grpHistory"
        Me.grpHistory.Size = New System.Drawing.Size(200, 223)
        Me.grpHistory.TabIndex = 1
        Me.grpHistory.TabStop = False
        Me.grpHistory.Text = "History Entries"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(406, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Witness the shameful history of your bad decisions."
        '
        'errprov
        '
        Me.errprov.ContainerControl = Me
        '
        'HistoryForm
        '
        Me.AcceptButton = Me.btnDone
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnDone
        Me.ClientSize = New System.Drawing.Size(432, 303)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.grpAttendance)
        Me.Controls.Add(Me.grpHistory)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HistoryForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Decision History"
        Me.grpAttendance.ResumeLayout(False)
        Me.grpHistory.ResumeLayout(False)
        CType(Me.errprov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstHistory As ListBox
    Friend WithEvents lstAttendance As ListBox
    Friend WithEvents btnDone As Button
    Friend WithEvents grpAttendance As GroupBox
    Friend WithEvents grpHistory As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents errprov As ErrorProvider
End Class
