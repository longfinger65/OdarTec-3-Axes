<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CamBore
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_Ok = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Z = New System.Windows.Forms.Label()
        Me.Y = New System.Windows.Forms.Label()
        Me.X = New System.Windows.Forms.Label()
        Me.Origin = New System.Windows.Forms.Label()
        Me.TeBo_OriginZ = New System.Windows.Forms.TextBox()
        Me.TeBo_OriginY = New System.Windows.Forms.TextBox()
        Me.TeBo_OriginX = New System.Windows.Forms.TextBox()
        Me.TeBo_OriginChooser = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LiBo_BoreElements = New System.Windows.Forms.ListBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TeBo_D1 = New System.Windows.Forms.TextBox()
        Me.La_D1 = New System.Windows.Forms.Label()
        Me.CoBo_ToolChooser = New System.Windows.Forms.ComboBox()
        Me.CoBo_CoolingAgentChooser = New System.Windows.Forms.ComboBox()
        Me.NuUpDo_LCorr = New System.Windows.Forms.NumericUpDown()
        Me.La_LCorr = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.NuUpDo_ZInFeed = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NuUpDo_DephthOfBore = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NuUpDo_FeedRetractMove = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_CuttingSpeed = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.NuUpDo_FeedRapid = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.NuUpDo_FeedWork = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button_ShowCamPath = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.NuUpDo_LCorr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.NuUpDo_ZInFeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_DephthOfBore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.NuUpDo_FeedRetractMove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_CuttingSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_FeedRapid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_FeedWork, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(277, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Bohren"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_Ok
        '
        Me.Button_Ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Ok.BackColor = System.Drawing.Color.LightGreen
        Me.Button_Ok.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Ok.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button_Ok.Location = New System.Drawing.Point(195, 438)
        Me.Button_Ok.Name = "Button_Ok"
        Me.Button_Ok.Size = New System.Drawing.Size(79, 23)
        Me.Button_Ok.TabIndex = 2
        Me.Button_Ok.Text = "Ok"
        Me.Button_Ok.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Z)
        Me.GroupBox1.Controls.Add(Me.Y)
        Me.GroupBox1.Controls.Add(Me.X)
        Me.GroupBox1.Controls.Add(Me.Origin)
        Me.GroupBox1.Controls.Add(Me.TeBo_OriginZ)
        Me.GroupBox1.Controls.Add(Me.TeBo_OriginY)
        Me.GroupBox1.Controls.Add(Me.TeBo_OriginX)
        Me.GroupBox1.Controls.Add(Me.TeBo_OriginChooser)
        Me.GroupBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox1.Location = New System.Drawing.Point(3, 117)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(137, 127)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nullpunkt"
        '
        'Z
        '
        Me.Z.AutoSize = True
        Me.Z.Location = New System.Drawing.Point(6, 99)
        Me.Z.Name = "Z"
        Me.Z.Size = New System.Drawing.Size(14, 13)
        Me.Z.TabIndex = 18
        Me.Z.Text = "Z"
        '
        'Y
        '
        Me.Y.AutoSize = True
        Me.Y.Location = New System.Drawing.Point(6, 73)
        Me.Y.Name = "Y"
        Me.Y.Size = New System.Drawing.Size(14, 13)
        Me.Y.TabIndex = 17
        Me.Y.Text = "Y"
        '
        'X
        '
        Me.X.AutoSize = True
        Me.X.Location = New System.Drawing.Point(6, 53)
        Me.X.Name = "X"
        Me.X.Size = New System.Drawing.Size(14, 13)
        Me.X.TabIndex = 16
        Me.X.Text = "X"
        '
        'Origin
        '
        Me.Origin.AutoSize = True
        Me.Origin.Location = New System.Drawing.Point(6, 22)
        Me.Origin.Name = "Origin"
        Me.Origin.Size = New System.Drawing.Size(32, 13)
        Me.Origin.TabIndex = 15
        Me.Origin.Text = "Wahl"
        '
        'TeBo_OriginZ
        '
        Me.TeBo_OriginZ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_OriginZ.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_OriginZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_OriginZ.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_OriginZ.Location = New System.Drawing.Point(67, 97)
        Me.TeBo_OriginZ.Name = "TeBo_OriginZ"
        Me.TeBo_OriginZ.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_OriginZ.TabIndex = 14
        Me.TeBo_OriginZ.Text = "0,00"
        Me.TeBo_OriginZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_OriginZ.WordWrap = False
        '
        'TeBo_OriginY
        '
        Me.TeBo_OriginY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_OriginY.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_OriginY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_OriginY.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_OriginY.Location = New System.Drawing.Point(67, 72)
        Me.TeBo_OriginY.Name = "TeBo_OriginY"
        Me.TeBo_OriginY.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_OriginY.TabIndex = 13
        Me.TeBo_OriginY.Text = "0,00"
        Me.TeBo_OriginY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_OriginY.WordWrap = False
        '
        'TeBo_OriginX
        '
        Me.TeBo_OriginX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_OriginX.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_OriginX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_OriginX.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_OriginX.Location = New System.Drawing.Point(67, 45)
        Me.TeBo_OriginX.Name = "TeBo_OriginX"
        Me.TeBo_OriginX.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_OriginX.TabIndex = 12
        Me.TeBo_OriginX.Text = "0,00"
        Me.TeBo_OriginX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_OriginX.WordWrap = False
        '
        'TeBo_OriginChooser
        '
        Me.TeBo_OriginChooser.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_OriginChooser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_OriginChooser.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_OriginChooser.Location = New System.Drawing.Point(50, 19)
        Me.TeBo_OriginChooser.Name = "TeBo_OriginChooser"
        Me.TeBo_OriginChooser.Size = New System.Drawing.Size(81, 20)
        Me.TeBo_OriginChooser.TabIndex = 11
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LiBo_BoreElements)
        Me.GroupBox2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox2.Location = New System.Drawing.Point(3, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(269, 93)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Bohrungsmittelpunkte"
        '
        'LiBo_BoreElements
        '
        Me.LiBo_BoreElements.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LiBo_BoreElements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LiBo_BoreElements.ForeColor = System.Drawing.Color.SteelBlue
        Me.LiBo_BoreElements.FormattingEnabled = True
        Me.LiBo_BoreElements.Location = New System.Drawing.Point(6, 16)
        Me.LiBo_BoreElements.Name = "LiBo_BoreElements"
        Me.LiBo_BoreElements.Size = New System.Drawing.Size(257, 67)
        Me.LiBo_BoreElements.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.GhostWhite
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button2.Location = New System.Drawing.Point(3, 438)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Abbrechen"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.GhostWhite
        Me.GroupBox4.Controls.Add(Me.TeBo_D1)
        Me.GroupBox4.Controls.Add(Me.La_D1)
        Me.GroupBox4.Controls.Add(Me.CoBo_ToolChooser)
        Me.GroupBox4.Controls.Add(Me.CoBo_CoolingAgentChooser)
        Me.GroupBox4.Controls.Add(Me.NuUpDo_LCorr)
        Me.GroupBox4.Controls.Add(Me.La_LCorr)
        Me.GroupBox4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox4.Location = New System.Drawing.Point(146, 117)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(126, 127)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Werkzeug"
        '
        'TeBo_D1
        '
        Me.TeBo_D1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_D1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_D1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_D1.Enabled = False
        Me.TeBo_D1.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_D1.Location = New System.Drawing.Point(56, 75)
        Me.TeBo_D1.Name = "TeBo_D1"
        Me.TeBo_D1.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_D1.TabIndex = 13
        Me.TeBo_D1.Text = "0,00"
        Me.TeBo_D1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_D1.WordWrap = False
        '
        'La_D1
        '
        Me.La_D1.AutoSize = True
        Me.La_D1.Location = New System.Drawing.Point(7, 77)
        Me.La_D1.Name = "La_D1"
        Me.La_D1.Size = New System.Drawing.Size(21, 13)
        Me.La_D1.TabIndex = 8
        Me.La_D1.Text = "D1"
        '
        'CoBo_ToolChooser
        '
        Me.CoBo_ToolChooser.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CoBo_ToolChooser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CoBo_ToolChooser.ForeColor = System.Drawing.Color.SteelBlue
        Me.CoBo_ToolChooser.FormattingEnabled = True
        Me.CoBo_ToolChooser.Items.AddRange(New Object() {"Schaftfräser 1", "Schaftfräser 2"})
        Me.CoBo_ToolChooser.Location = New System.Drawing.Point(10, 19)
        Me.CoBo_ToolChooser.Name = "CoBo_ToolChooser"
        Me.CoBo_ToolChooser.Size = New System.Drawing.Size(110, 21)
        Me.CoBo_ToolChooser.TabIndex = 7
        Me.CoBo_ToolChooser.Text = "Schaftfräser 1"
        '
        'CoBo_CoolingAgentChooser
        '
        Me.CoBo_CoolingAgentChooser.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CoBo_CoolingAgentChooser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CoBo_CoolingAgentChooser.ForeColor = System.Drawing.Color.SteelBlue
        Me.CoBo_CoolingAgentChooser.FormattingEnabled = True
        Me.CoBo_CoolingAgentChooser.Items.AddRange(New Object() {"keine Kühlung", "Wasserkühlung", "Ölkühlung", "Luftkühlung"})
        Me.CoBo_CoolingAgentChooser.Location = New System.Drawing.Point(10, 48)
        Me.CoBo_CoolingAgentChooser.Name = "CoBo_CoolingAgentChooser"
        Me.CoBo_CoolingAgentChooser.Size = New System.Drawing.Size(110, 21)
        Me.CoBo_CoolingAgentChooser.TabIndex = 6
        Me.CoBo_CoolingAgentChooser.Text = "keine Kühlung"
        '
        'NuUpDo_LCorr
        '
        Me.NuUpDo_LCorr.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_LCorr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_LCorr.DecimalPlaces = 2
        Me.NuUpDo_LCorr.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_LCorr.Location = New System.Drawing.Point(56, 97)
        Me.NuUpDo_LCorr.Name = "NuUpDo_LCorr"
        Me.NuUpDo_LCorr.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_LCorr.TabIndex = 5
        Me.NuUpDo_LCorr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'La_LCorr
        '
        Me.La_LCorr.AutoSize = True
        Me.La_LCorr.Location = New System.Drawing.Point(7, 99)
        Me.La_LCorr.Name = "La_LCorr"
        Me.La_LCorr.Size = New System.Drawing.Size(38, 13)
        Me.La_LCorr.TabIndex = 4
        Me.La_LCorr.Text = "L-Korr."
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.NuUpDo_ZInFeed)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_DephthOfBore)
        Me.GroupBox5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox5.Location = New System.Drawing.Point(3, 250)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(137, 74)
        Me.GroupBox5.TabIndex = 16
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Steps und Zustellung"
        '
        'NuUpDo_ZInFeed
        '
        Me.NuUpDo_ZInFeed.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ZInFeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ZInFeed.DecimalPlaces = 2
        Me.NuUpDo_ZInFeed.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ZInFeed.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NuUpDo_ZInFeed.Location = New System.Drawing.Point(67, 45)
        Me.NuUpDo_ZInFeed.Maximum = New Decimal(New Integer() {1, 0, 0, -2147287040})
        Me.NuUpDo_ZInFeed.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.NuUpDo_ZInFeed.Name = "NuUpDo_ZInFeed"
        Me.NuUpDo_ZInFeed.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_ZInFeed.TabIndex = 3
        Me.NuUpDo_ZInFeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_ZInFeed.Value = New Decimal(New Integer() {50, 0, 0, -2147352576})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Z-Zustell."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Bohrti."
        '
        'NuUpDo_DephthOfBore
        '
        Me.NuUpDo_DephthOfBore.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_DephthOfBore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_DephthOfBore.DecimalPlaces = 2
        Me.NuUpDo_DephthOfBore.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_DephthOfBore.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NuUpDo_DephthOfBore.Location = New System.Drawing.Point(67, 19)
        Me.NuUpDo_DephthOfBore.Maximum = New Decimal(New Integer() {1, 0, 0, -2147287040})
        Me.NuUpDo_DephthOfBore.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.NuUpDo_DephthOfBore.Name = "NuUpDo_DephthOfBore"
        Me.NuUpDo_DephthOfBore.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_DephthOfBore.TabIndex = 0
        Me.NuUpDo_DephthOfBore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_DephthOfBore.Value = New Decimal(New Integer() {1, 0, 0, -2147483648})
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.NuUpDo_FeedRetractMove)
        Me.GroupBox6.Controls.Add(Me.NuUpDo_CuttingSpeed)
        Me.GroupBox6.Controls.Add(Me.Label18)
        Me.GroupBox6.Controls.Add(Me.NuUpDo_FeedRapid)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.NuUpDo_FeedWork)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox6.Location = New System.Drawing.Point(3, 330)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(269, 100)
        Me.GroupBox6.TabIndex = 17
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Vorschübe u. Schnittge."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Rückzug"
        '
        'NuUpDo_FeedRetractMove
        '
        Me.NuUpDo_FeedRetractMove.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_FeedRetractMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_FeedRetractMove.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_FeedRetractMove.Location = New System.Drawing.Point(67, 71)
        Me.NuUpDo_FeedRetractMove.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NuUpDo_FeedRetractMove.Name = "NuUpDo_FeedRetractMove"
        Me.NuUpDo_FeedRetractMove.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_FeedRetractMove.TabIndex = 8
        Me.NuUpDo_FeedRetractMove.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_FeedRetractMove.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'NuUpDo_CuttingSpeed
        '
        Me.NuUpDo_CuttingSpeed.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_CuttingSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_CuttingSpeed.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_CuttingSpeed.Location = New System.Drawing.Point(199, 19)
        Me.NuUpDo_CuttingSpeed.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NuUpDo_CuttingSpeed.Name = "NuUpDo_CuttingSpeed"
        Me.NuUpDo_CuttingSpeed.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_CuttingSpeed.TabIndex = 7
        Me.NuUpDo_CuttingSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_CuttingSpeed.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(150, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 13)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Schnittg."
        '
        'NuUpDo_FeedRapid
        '
        Me.NuUpDo_FeedRapid.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_FeedRapid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_FeedRapid.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_FeedRapid.Location = New System.Drawing.Point(67, 45)
        Me.NuUpDo_FeedRapid.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NuUpDo_FeedRapid.Name = "NuUpDo_FeedRapid"
        Me.NuUpDo_FeedRapid.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_FeedRapid.TabIndex = 3
        Me.NuUpDo_FeedRapid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_FeedRapid.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Eilgang"
        '
        'NuUpDo_FeedWork
        '
        Me.NuUpDo_FeedWork.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_FeedWork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_FeedWork.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_FeedWork.Location = New System.Drawing.Point(67, 19)
        Me.NuUpDo_FeedWork.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NuUpDo_FeedWork.Name = "NuUpDo_FeedWork"
        Me.NuUpDo_FeedWork.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_FeedWork.TabIndex = 1
        Me.NuUpDo_FeedWork.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_FeedWork.Value = New Decimal(New Integer() {300, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Arbeit"
        '
        'Button_ShowCamPath
        '
        Me.Button_ShowCamPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button_ShowCamPath.BackColor = System.Drawing.Color.GhostWhite
        Me.Button_ShowCamPath.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button_ShowCamPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_ShowCamPath.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button_ShowCamPath.Location = New System.Drawing.Point(84, 438)
        Me.Button_ShowCamPath.Name = "Button_ShowCamPath"
        Me.Button_ShowCamPath.Size = New System.Drawing.Size(105, 23)
        Me.Button_ShowCamPath.TabIndex = 18
        Me.Button_ShowCamPath.Text = "Zeige Bahn"
        Me.Button_ShowCamPath.UseVisualStyleBackColor = False
        '
        'CamBore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.Controls.Add(Me.Button_ShowCamPath)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button_Ok)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(277, 464)
        Me.Name = "CamBore"
        Me.Size = New System.Drawing.Size(277, 464)
        Me.Tag = "test"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.NuUpDo_LCorr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.NuUpDo_ZInFeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_DephthOfBore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.NuUpDo_FeedRetractMove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_CuttingSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_FeedRapid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_FeedWork, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button_Ok As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Z As System.Windows.Forms.Label
    Friend WithEvents Y As System.Windows.Forms.Label
    Friend WithEvents X As System.Windows.Forms.Label
    Friend WithEvents Origin As System.Windows.Forms.Label
    Friend WithEvents TeBo_OriginZ As System.Windows.Forms.TextBox
    Friend WithEvents TeBo_OriginY As System.Windows.Forms.TextBox
    Friend WithEvents TeBo_OriginX As System.Windows.Forms.TextBox
    Friend WithEvents TeBo_OriginChooser As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents NuUpDo_DephthOfBore As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_ZInFeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents NuUpDo_FeedWork As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LiBo_BoreElements As System.Windows.Forms.ListBox
    Friend WithEvents Button_ShowCamPath As System.Windows.Forms.Button
    Friend WithEvents NuUpDo_FeedRapid As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_LCorr As System.Windows.Forms.NumericUpDown
    Friend WithEvents La_LCorr As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_CuttingSpeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CoBo_CoolingAgentChooser As System.Windows.Forms.ComboBox
    Friend WithEvents CoBo_ToolChooser As System.Windows.Forms.ComboBox
    Friend WithEvents La_D1 As System.Windows.Forms.Label
    Friend WithEvents TeBo_D1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_FeedRetractMove As System.Windows.Forms.NumericUpDown

End Class
