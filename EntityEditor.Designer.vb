<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EntityEditor
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TeBo_EditEntityX = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lab_Radius = New System.Windows.Forms.Label()
        Me.TeBo_EditEntityY = New System.Windows.Forms.TextBox()
        Me.TeBo_EditEntityZ = New System.Windows.Forms.TextBox()
        Me.TeBo_EditEntityRadius = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(15, 119)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(167, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.BackColor = System.Drawing.Color.WhiteSmoke
        Me.OK_Button.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.OK_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LimeGreen
        Me.OK_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen
        Me.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(77, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseVisualStyleBackColor = false
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Cancel_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson
        Me.Cancel_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Pink
        Me.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_Button.Location = New System.Drawing.Point(86, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(78, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Abbrechen"
        Me.Cancel_Button.UseVisualStyleBackColor = false
        '
        'TeBo_EditEntityX
        '
        Me.TeBo_EditEntityX.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_EditEntityX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_EditEntityX.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_EditEntityX.Location = New System.Drawing.Point(80, 12)
        Me.TeBo_EditEntityX.Name = "TeBo_EditEntityX"
        Me.TeBo_EditEntityX.Size = New System.Drawing.Size(100, 20)
        Me.TeBo_EditEntityX.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "X"
        '
        'Lab_Radius
        '
        Me.Lab_Radius.AutoSize = true
        Me.Lab_Radius.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Lab_Radius.Location = New System.Drawing.Point(12, 92)
        Me.Lab_Radius.Name = "Lab_Radius"
        Me.Lab_Radius.Size = New System.Drawing.Size(40, 13)
        Me.Lab_Radius.TabIndex = 5
        Me.Lab_Radius.Text = "Radius"
        '
        'TeBo_EditEntityY
        '
        Me.TeBo_EditEntityY.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_EditEntityY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_EditEntityY.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_EditEntityY.Location = New System.Drawing.Point(80, 38)
        Me.TeBo_EditEntityY.Name = "TeBo_EditEntityY"
        Me.TeBo_EditEntityY.Size = New System.Drawing.Size(100, 20)
        Me.TeBo_EditEntityY.TabIndex = 6
        '
        'TeBo_EditEntityZ
        '
        Me.TeBo_EditEntityZ.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_EditEntityZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_EditEntityZ.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_EditEntityZ.Location = New System.Drawing.Point(80, 64)
        Me.TeBo_EditEntityZ.Name = "TeBo_EditEntityZ"
        Me.TeBo_EditEntityZ.Size = New System.Drawing.Size(100, 20)
        Me.TeBo_EditEntityZ.TabIndex = 7
        '
        'TeBo_EditEntityRadius
        '
        Me.TeBo_EditEntityRadius.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_EditEntityRadius.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_EditEntityRadius.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_EditEntityRadius.Location = New System.Drawing.Point(80, 90)
        Me.TeBo_EditEntityRadius.Name = "TeBo_EditEntityRadius"
        Me.TeBo_EditEntityRadius.Size = New System.Drawing.Size(100, 20)
        Me.TeBo_EditEntityRadius.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(12, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Z"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(12, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Y"
        '
        'EntityEditor
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(194, 160)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TeBo_EditEntityRadius)
        Me.Controls.Add(Me.TeBo_EditEntityZ)
        Me.Controls.Add(Me.TeBo_EditEntityY)
        Me.Controls.Add(Me.Lab_Radius)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TeBo_EditEntityX)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.ForeColor = System.Drawing.Color.MidnightBlue
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "EntityEditor"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "EntityEditor"
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TeBo_EditEntityX As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Lab_Radius As System.Windows.Forms.Label
    Friend WithEvents TeBo_EditEntityY As System.Windows.Forms.TextBox
    Friend WithEvents TeBo_EditEntityZ As System.Windows.Forms.TextBox
    Friend WithEvents TeBo_EditEntityRadius As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
