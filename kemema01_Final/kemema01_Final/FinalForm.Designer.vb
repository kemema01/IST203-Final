<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FinalForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblWInner = New System.Windows.Forms.Label()
        Me.btnWinner = New System.Windows.Forms.Button()
        Me.chkReject = New System.Windows.Forms.CheckBox()
        Me.lstScoreBoard = New System.Windows.Forms.ListBox()
        Me.btnList = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnRandom = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "And lo, this is the decision that was made here."
        '
        'lblWInner
        '
        Me.lblWInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWInner.Location = New System.Drawing.Point(12, 41)
        Me.lblWInner.Name = "lblWInner"
        Me.lblWInner.Size = New System.Drawing.Size(312, 23)
        Me.lblWInner.TabIndex = 1
        Me.lblWInner.Text = "Label2"
        Me.lblWInner.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnWinner
        '
        Me.btnWinner.Location = New System.Drawing.Point(249, 67)
        Me.btnWinner.Name = "btnWinner"
        Me.btnWinner.Size = New System.Drawing.Size(75, 25)
        Me.btnWinner.TabIndex = 2
        Me.btnWinner.Text = "Accept"
        Me.btnWinner.UseVisualStyleBackColor = True
        '
        'chkReject
        '
        Me.chkReject.AutoSize = True
        Me.chkReject.Location = New System.Drawing.Point(12, 69)
        Me.chkReject.Name = "chkReject"
        Me.chkReject.Size = New System.Drawing.Size(70, 21)
        Me.chkReject.TabIndex = 3
        Me.chkReject.Text = "Reject"
        Me.chkReject.UseVisualStyleBackColor = True
        '
        'lstScoreBoard
        '
        Me.lstScoreBoard.Enabled = False
        Me.lstScoreBoard.FormattingEnabled = True
        Me.lstScoreBoard.ItemHeight = 16
        Me.lstScoreBoard.Location = New System.Drawing.Point(12, 135)
        Me.lstScoreBoard.Name = "lstScoreBoard"
        Me.lstScoreBoard.Size = New System.Drawing.Size(312, 100)
        Me.lstScoreBoard.TabIndex = 4
        '
        'btnList
        '
        Me.btnList.Enabled = False
        Me.btnList.Location = New System.Drawing.Point(249, 241)
        Me.btnList.Name = "btnList"
        Me.btnList.Size = New System.Drawing.Size(75, 25)
        Me.btnList.TabIndex = 5
        Me.btnList.Text = "Accept"
        Me.btnList.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Location = New System.Drawing.Point(12, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(312, 39)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Not good enough? Check 'Reject' and choose from the list below."
        '
        'btnRandom
        '
        Me.btnRandom.Enabled = False
        Me.btnRandom.Location = New System.Drawing.Point(168, 242)
        Me.btnRandom.Name = "btnRandom"
        Me.btnRandom.Size = New System.Drawing.Size(75, 23)
        Me.btnRandom.TabIndex = 7
        Me.btnRandom.Text = "Random"
        Me.btnRandom.UseVisualStyleBackColor = True
        '
        'FinalForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 269)
        Me.Controls.Add(Me.btnRandom)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnList)
        Me.Controls.Add(Me.lstScoreBoard)
        Me.Controls.Add(Me.chkReject)
        Me.Controls.Add(Me.btnWinner)
        Me.Controls.Add(Me.lblWInner)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FinalForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Result"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblWInner As Label
    Friend WithEvents btnWinner As Button
    Friend WithEvents chkReject As CheckBox
    Friend WithEvents lstScoreBoard As ListBox
    Friend WithEvents btnList As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnRandom As Button
End Class
