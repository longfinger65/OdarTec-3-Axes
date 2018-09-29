<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CamFaceMilling
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
        Me.TextBox_OriginZ = New System.Windows.Forms.TextBox()
        Me.TextBox_OriginY = New System.Windows.Forms.TextBox()
        Me.TextBox_OriginX = New System.Windows.Forms.TextBox()
        Me.TeBo_OriginChooser = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RaBu_RR = New System.Windows.Forms.RadioButton()
        Me.RaBu_RL = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TeBo_D1 = New System.Windows.Forms.TextBox()
        Me.La_D1 = New System.Windows.Forms.Label()
        Me.CoBo_ToolChooser = New System.Windows.Forms.ComboBox()
        Me.CoBo_CoolingAgentChooser = New System.Windows.Forms.ComboBox()
        Me.NuUpDo_LCorr = New System.Windows.Forms.NumericUpDown()
        Me.La_LCorr = New System.Windows.Forms.Label()
        Me.NuUpDo_DCorr = New System.Windows.Forms.NumericUpDown()
        Me.La_DCorr = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NuUpDo_ToolWorkRetractHeight = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_ToolOverlap = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.NuUpDo_GroundInFeed = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.NuUpDo_GroundSteps = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.NuUpDo_ZInFeed = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NuUpDo_DephthOfPocket = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.NuUpDo_CuttingSpeed = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.NuUpDo_InFeed = New System.Windows.Forms.NumericUpDown()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.NuUpDo_RapidFeed = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.NuUpDo_WorkFeed = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button_ShowCamPath = New System.Windows.Forms.Button()
        Me.GB_StartPoint = New System.Windows.Forms.GroupBox()
        Me.TeBo_FaceMillingPoint1Z = New System.Windows.Forms.TextBox()
        Me.TeBo_FaceMillingPoint1Y = New System.Windows.Forms.TextBox()
        Me.TeBo_FaceMillingPoint1X = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TeBo_StaPoiChooser = New System.Windows.Forms.TextBox()
        Me.La_StaPoiChooser = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TeBo_FaceMillingPoint2Z = New System.Windows.Forms.TextBox()
        Me.TeBo_FaceMillingPoint2Y = New System.Windows.Forms.TextBox()
        Me.TeBo_FaceMillingPoint2X = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.RaBu_Round = New System.Windows.Forms.RadioButton()
        Me.RaBu_Rightangular = New System.Windows.Forms.RadioButton()
        Me.NuUpDo_ToolStartStopRetractHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.NuUpDo_LCorr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_DCorr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.NuUpDo_ToolWorkRetractHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_ToolOverlap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_GroundInFeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_GroundSteps, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_ZInFeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_DephthOfPocket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.NuUpDo_CuttingSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_InFeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_RapidFeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_WorkFeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB_StartPoint.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.NuUpDo_ToolStartStopRetractHeight, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Text = "Abzeilen"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_Ok
        '
        Me.Button_Ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Ok.BackColor = System.Drawing.Color.LightGreen
        Me.Button_Ok.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Ok.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button_Ok.Location = New System.Drawing.Point(195, 639)
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
        Me.GroupBox1.Controls.Add(Me.TextBox_OriginZ)
        Me.GroupBox1.Controls.Add(Me.TextBox_OriginY)
        Me.GroupBox1.Controls.Add(Me.TextBox_OriginX)
        Me.GroupBox1.Controls.Add(Me.TeBo_OriginChooser)
        Me.GroupBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox1.Location = New System.Drawing.Point(3, 18)
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
        'TextBox_OriginZ
        '
        Me.TextBox_OriginZ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_OriginZ.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox_OriginZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_OriginZ.ForeColor = System.Drawing.Color.SteelBlue
        Me.TextBox_OriginZ.Location = New System.Drawing.Point(67, 97)
        Me.TextBox_OriginZ.Name = "TextBox_OriginZ"
        Me.TextBox_OriginZ.Size = New System.Drawing.Size(64, 20)
        Me.TextBox_OriginZ.TabIndex = 14
        Me.TextBox_OriginZ.Text = "0,00"
        Me.TextBox_OriginZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox_OriginZ.WordWrap = False
        '
        'TextBox_OriginY
        '
        Me.TextBox_OriginY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_OriginY.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox_OriginY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_OriginY.ForeColor = System.Drawing.Color.SteelBlue
        Me.TextBox_OriginY.Location = New System.Drawing.Point(67, 72)
        Me.TextBox_OriginY.Name = "TextBox_OriginY"
        Me.TextBox_OriginY.Size = New System.Drawing.Size(64, 20)
        Me.TextBox_OriginY.TabIndex = 13
        Me.TextBox_OriginY.Text = "0,00"
        Me.TextBox_OriginY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox_OriginY.WordWrap = False
        '
        'TextBox_OriginX
        '
        Me.TextBox_OriginX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_OriginX.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox_OriginX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_OriginX.ForeColor = System.Drawing.Color.SteelBlue
        Me.TextBox_OriginX.Location = New System.Drawing.Point(67, 45)
        Me.TextBox_OriginX.Name = "TextBox_OriginX"
        Me.TextBox_OriginX.Size = New System.Drawing.Size(64, 20)
        Me.TextBox_OriginX.TabIndex = 12
        Me.TextBox_OriginX.Text = "0,00"
        Me.TextBox_OriginX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox_OriginX.WordWrap = False
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RaBu_RR)
        Me.GroupBox3.Controls.Add(Me.RaBu_RL)
        Me.GroupBox3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox3.Location = New System.Drawing.Point(3, 284)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(51, 104)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Bahn"
        '
        'RaBu_RR
        '
        Me.RaBu_RR.AutoSize = True
        Me.RaBu_RR.ForeColor = System.Drawing.Color.SteelBlue
        Me.RaBu_RR.Location = New System.Drawing.Point(6, 42)
        Me.RaBu_RR.Name = "RaBu_RR"
        Me.RaBu_RR.Size = New System.Drawing.Size(41, 17)
        Me.RaBu_RR.TabIndex = 1
        Me.RaBu_RR.Text = "RR"
        Me.RaBu_RR.UseVisualStyleBackColor = True
        '
        'RaBu_RL
        '
        Me.RaBu_RL.AutoSize = True
        Me.RaBu_RL.Checked = True
        Me.RaBu_RL.ForeColor = System.Drawing.Color.SteelBlue
        Me.RaBu_RL.Location = New System.Drawing.Point(6, 19)
        Me.RaBu_RL.Name = "RaBu_RL"
        Me.RaBu_RL.Size = New System.Drawing.Size(39, 17)
        Me.RaBu_RL.TabIndex = 0
        Me.RaBu_RL.TabStop = True
        Me.RaBu_RL.Text = "RL"
        Me.RaBu_RL.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.Khaki
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button2.Location = New System.Drawing.Point(3, 639)
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
        Me.GroupBox4.Controls.Add(Me.NuUpDo_DCorr)
        Me.GroupBox4.Controls.Add(Me.La_DCorr)
        Me.GroupBox4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox4.Location = New System.Drawing.Point(60, 284)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(212, 106)
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
        Me.TeBo_D1.Location = New System.Drawing.Point(10, 72)
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
        Me.La_D1.Location = New System.Drawing.Point(7, 48)
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
        Me.CoBo_ToolChooser.Size = New System.Drawing.Size(96, 21)
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
        Me.CoBo_CoolingAgentChooser.Location = New System.Drawing.Point(112, 19)
        Me.CoBo_CoolingAgentChooser.Name = "CoBo_CoolingAgentChooser"
        Me.CoBo_CoolingAgentChooser.Size = New System.Drawing.Size(94, 21)
        Me.CoBo_CoolingAgentChooser.TabIndex = 6
        Me.CoBo_CoolingAgentChooser.Text = "keine Kühlung"
        '
        'NuUpDo_LCorr
        '
        Me.NuUpDo_LCorr.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_LCorr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_LCorr.DecimalPlaces = 3
        Me.NuUpDo_LCorr.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_LCorr.Location = New System.Drawing.Point(142, 72)
        Me.NuUpDo_LCorr.Name = "NuUpDo_LCorr"
        Me.NuUpDo_LCorr.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_LCorr.TabIndex = 5
        Me.NuUpDo_LCorr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'La_LCorr
        '
        Me.La_LCorr.AutoSize = True
        Me.La_LCorr.Location = New System.Drawing.Point(92, 74)
        Me.La_LCorr.Name = "La_LCorr"
        Me.La_LCorr.Size = New System.Drawing.Size(38, 13)
        Me.La_LCorr.TabIndex = 4
        Me.La_LCorr.Text = "L-Korr."
        '
        'NuUpDo_DCorr
        '
        Me.NuUpDo_DCorr.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_DCorr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_DCorr.DecimalPlaces = 3
        Me.NuUpDo_DCorr.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_DCorr.Location = New System.Drawing.Point(142, 46)
        Me.NuUpDo_DCorr.Name = "NuUpDo_DCorr"
        Me.NuUpDo_DCorr.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_DCorr.TabIndex = 3
        Me.NuUpDo_DCorr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'La_DCorr
        '
        Me.La_DCorr.AutoSize = True
        Me.La_DCorr.Location = New System.Drawing.Point(92, 48)
        Me.La_DCorr.Name = "La_DCorr"
        Me.La_DCorr.Size = New System.Drawing.Size(40, 13)
        Me.La_DCorr.TabIndex = 2
        Me.La_DCorr.Text = "Ø-Korr."
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_ToolStartStopRetractHeight)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_ToolWorkRetractHeight)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_ToolOverlap)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_GroundInFeed)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_GroundSteps)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_ZInFeed)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_DephthOfPocket)
        Me.GroupBox5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox5.Location = New System.Drawing.Point(3, 394)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(269, 156)
        Me.GroupBox5.TabIndex = 16
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Steps und Zustellung"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Start- / Stop-Höhe"
        '
        'NuUpDo_ToolWorkRetractHeight
        '
        Me.NuUpDo_ToolWorkRetractHeight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ToolWorkRetractHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ToolWorkRetractHeight.DecimalPlaces = 3
        Me.NuUpDo_ToolWorkRetractHeight.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ToolWorkRetractHeight.Location = New System.Drawing.Point(199, 123)
        Me.NuUpDo_ToolWorkRetractHeight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NuUpDo_ToolWorkRetractHeight.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.NuUpDo_ToolWorkRetractHeight.Name = "NuUpDo_ToolWorkRetractHeight"
        Me.NuUpDo_ToolWorkRetractHeight.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_ToolWorkRetractHeight.TabIndex = 12
        Me.NuUpDo_ToolWorkRetractHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_ToolWorkRetractHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NuUpDo_ToolOverlap
        '
        Me.NuUpDo_ToolOverlap.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ToolOverlap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ToolOverlap.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ToolOverlap.Location = New System.Drawing.Point(199, 71)
        Me.NuUpDo_ToolOverlap.Name = "NuUpDo_ToolOverlap"
        Me.NuUpDo_ToolOverlap.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_ToolOverlap.TabIndex = 11
        Me.NuUpDo_ToolOverlap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_ToolOverlap.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(124, 13)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Werkzeug-Überdeckung"
        '
        'NuUpDo_GroundInFeed
        '
        Me.NuUpDo_GroundInFeed.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_GroundInFeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_GroundInFeed.DecimalPlaces = 3
        Me.NuUpDo_GroundInFeed.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_GroundInFeed.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NuUpDo_GroundInFeed.Location = New System.Drawing.Point(199, 45)
        Me.NuUpDo_GroundInFeed.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NuUpDo_GroundInFeed.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.NuUpDo_GroundInFeed.Name = "NuUpDo_GroundInFeed"
        Me.NuUpDo_GroundInFeed.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_GroundInFeed.TabIndex = 9
        Me.NuUpDo_GroundInFeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_GroundInFeed.Value = New Decimal(New Integer() {1, 0, 0, -2147418112})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(131, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Boden-Zust."
        '
        'NuUpDo_GroundSteps
        '
        Me.NuUpDo_GroundSteps.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_GroundSteps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_GroundSteps.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_GroundSteps.Location = New System.Drawing.Point(67, 45)
        Me.NuUpDo_GroundSteps.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NuUpDo_GroundSteps.Name = "NuUpDo_GroundSteps"
        Me.NuUpDo_GroundSteps.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_GroundSteps.TabIndex = 7
        Me.NuUpDo_GroundSteps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_GroundSteps.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Boden-St."
        '
        'NuUpDo_ZInFeed
        '
        Me.NuUpDo_ZInFeed.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ZInFeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ZInFeed.DecimalPlaces = 3
        Me.NuUpDo_ZInFeed.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ZInFeed.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NuUpDo_ZInFeed.Location = New System.Drawing.Point(199, 19)
        Me.NuUpDo_ZInFeed.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NuUpDo_ZInFeed.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.NuUpDo_ZInFeed.Name = "NuUpDo_ZInFeed"
        Me.NuUpDo_ZInFeed.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_ZInFeed.TabIndex = 3
        Me.NuUpDo_ZInFeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_ZInFeed.Value = New Decimal(New Integer() {5, 0, 0, -2147418112})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(131, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Z-Zustellung"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Abzeilti."
        '
        'NuUpDo_DephthOfPocket
        '
        Me.NuUpDo_DephthOfPocket.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_DephthOfPocket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_DephthOfPocket.DecimalPlaces = 2
        Me.NuUpDo_DephthOfPocket.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_DephthOfPocket.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NuUpDo_DephthOfPocket.Location = New System.Drawing.Point(67, 19)
        Me.NuUpDo_DephthOfPocket.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NuUpDo_DephthOfPocket.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.NuUpDo_DephthOfPocket.Name = "NuUpDo_DephthOfPocket"
        Me.NuUpDo_DephthOfPocket.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_DephthOfPocket.TabIndex = 0
        Me.NuUpDo_DephthOfPocket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_DephthOfPocket.Value = New Decimal(New Integer() {1, 0, 0, -2147483648})
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.NuUpDo_CuttingSpeed)
        Me.GroupBox6.Controls.Add(Me.Label18)
        Me.GroupBox6.Controls.Add(Me.NuUpDo_InFeed)
        Me.GroupBox6.Controls.Add(Me.Label16)
        Me.GroupBox6.Controls.Add(Me.NuUpDo_RapidFeed)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.NuUpDo_WorkFeed)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox6.Location = New System.Drawing.Point(3, 556)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(269, 76)
        Me.GroupBox6.TabIndex = 17
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Vorschübe und Schnittgeschwindigkeit"
        '
        'NuUpDo_CuttingSpeed
        '
        Me.NuUpDo_CuttingSpeed.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_CuttingSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_CuttingSpeed.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_CuttingSpeed.Location = New System.Drawing.Point(199, 46)
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
        Me.Label18.Location = New System.Drawing.Point(131, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 13)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Schnittg."
        '
        'NuUpDo_InFeed
        '
        Me.NuUpDo_InFeed.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_InFeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_InFeed.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_InFeed.Location = New System.Drawing.Point(67, 45)
        Me.NuUpDo_InFeed.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NuUpDo_InFeed.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NuUpDo_InFeed.Name = "NuUpDo_InFeed"
        Me.NuUpDo_InFeed.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_InFeed.TabIndex = 5
        Me.NuUpDo_InFeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_InFeed.Value = New Decimal(New Integer() {80, 0, 0, 0})
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Zustellung"
        '
        'NuUpDo_RapidFeed
        '
        Me.NuUpDo_RapidFeed.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_RapidFeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_RapidFeed.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_RapidFeed.Location = New System.Drawing.Point(199, 19)
        Me.NuUpDo_RapidFeed.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NuUpDo_RapidFeed.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NuUpDo_RapidFeed.Name = "NuUpDo_RapidFeed"
        Me.NuUpDo_RapidFeed.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_RapidFeed.TabIndex = 3
        Me.NuUpDo_RapidFeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_RapidFeed.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(131, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Eilgang"
        '
        'NuUpDo_WorkFeed
        '
        Me.NuUpDo_WorkFeed.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_WorkFeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_WorkFeed.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_WorkFeed.Location = New System.Drawing.Point(67, 19)
        Me.NuUpDo_WorkFeed.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NuUpDo_WorkFeed.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NuUpDo_WorkFeed.Name = "NuUpDo_WorkFeed"
        Me.NuUpDo_WorkFeed.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_WorkFeed.TabIndex = 1
        Me.NuUpDo_WorkFeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_WorkFeed.Value = New Decimal(New Integer() {200, 0, 0, 0})
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
        Me.Button_ShowCamPath.BackColor = System.Drawing.Color.GhostWhite
        Me.Button_ShowCamPath.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button_ShowCamPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_ShowCamPath.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button_ShowCamPath.Location = New System.Drawing.Point(84, 639)
        Me.Button_ShowCamPath.Name = "Button_ShowCamPath"
        Me.Button_ShowCamPath.Size = New System.Drawing.Size(105, 23)
        Me.Button_ShowCamPath.TabIndex = 18
        Me.Button_ShowCamPath.Text = "Zeige Bahn"
        Me.Button_ShowCamPath.UseVisualStyleBackColor = False
        '
        'GB_StartPoint
        '
        Me.GB_StartPoint.Controls.Add(Me.TeBo_FaceMillingPoint1Z)
        Me.GB_StartPoint.Controls.Add(Me.TeBo_FaceMillingPoint1Y)
        Me.GB_StartPoint.Controls.Add(Me.TeBo_FaceMillingPoint1X)
        Me.GB_StartPoint.Controls.Add(Me.Label8)
        Me.GB_StartPoint.Controls.Add(Me.Label7)
        Me.GB_StartPoint.Controls.Add(Me.Label6)
        Me.GB_StartPoint.Controls.Add(Me.TeBo_StaPoiChooser)
        Me.GB_StartPoint.Controls.Add(Me.La_StaPoiChooser)
        Me.GB_StartPoint.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GB_StartPoint.Location = New System.Drawing.Point(146, 18)
        Me.GB_StartPoint.Name = "GB_StartPoint"
        Me.GB_StartPoint.Size = New System.Drawing.Size(126, 127)
        Me.GB_StartPoint.TabIndex = 19
        Me.GB_StartPoint.TabStop = False
        Me.GB_StartPoint.Text = "Punkt 1"
        '
        'TeBo_FaceMillingPoint1Z
        '
        Me.TeBo_FaceMillingPoint1Z.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_FaceMillingPoint1Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_FaceMillingPoint1Z.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_FaceMillingPoint1Z.Location = New System.Drawing.Point(56, 97)
        Me.TeBo_FaceMillingPoint1Z.Name = "TeBo_FaceMillingPoint1Z"
        Me.TeBo_FaceMillingPoint1Z.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_FaceMillingPoint1Z.TabIndex = 7
        Me.TeBo_FaceMillingPoint1Z.Text = "0,00"
        Me.TeBo_FaceMillingPoint1Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TeBo_FaceMillingPoint1Y
        '
        Me.TeBo_FaceMillingPoint1Y.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_FaceMillingPoint1Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_FaceMillingPoint1Y.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_FaceMillingPoint1Y.Location = New System.Drawing.Point(56, 72)
        Me.TeBo_FaceMillingPoint1Y.Name = "TeBo_FaceMillingPoint1Y"
        Me.TeBo_FaceMillingPoint1Y.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_FaceMillingPoint1Y.TabIndex = 6
        Me.TeBo_FaceMillingPoint1Y.Text = "0,00"
        Me.TeBo_FaceMillingPoint1Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TeBo_FaceMillingPoint1X
        '
        Me.TeBo_FaceMillingPoint1X.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_FaceMillingPoint1X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_FaceMillingPoint1X.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_FaceMillingPoint1X.Location = New System.Drawing.Point(56, 46)
        Me.TeBo_FaceMillingPoint1X.Name = "TeBo_FaceMillingPoint1X"
        Me.TeBo_FaceMillingPoint1X.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_FaceMillingPoint1X.TabIndex = 5
        Me.TeBo_FaceMillingPoint1X.Text = "0,00"
        Me.TeBo_FaceMillingPoint1X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Z"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Y"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "X"
        '
        'TeBo_StaPoiChooser
        '
        Me.TeBo_StaPoiChooser.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_StaPoiChooser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_StaPoiChooser.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_StaPoiChooser.Location = New System.Drawing.Point(39, 20)
        Me.TeBo_StaPoiChooser.Name = "TeBo_StaPoiChooser"
        Me.TeBo_StaPoiChooser.Size = New System.Drawing.Size(81, 20)
        Me.TeBo_StaPoiChooser.TabIndex = 1
        '
        'La_StaPoiChooser
        '
        Me.La_StaPoiChooser.AutoSize = True
        Me.La_StaPoiChooser.Location = New System.Drawing.Point(6, 21)
        Me.La_StaPoiChooser.Name = "La_StaPoiChooser"
        Me.La_StaPoiChooser.Size = New System.Drawing.Size(32, 13)
        Me.La_StaPoiChooser.TabIndex = 0
        Me.La_StaPoiChooser.Text = "Wahl"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TeBo_FaceMillingPoint2Z)
        Me.GroupBox2.Controls.Add(Me.TeBo_FaceMillingPoint2Y)
        Me.GroupBox2.Controls.Add(Me.TeBo_FaceMillingPoint2X)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.TextBox4)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox2.Location = New System.Drawing.Point(146, 151)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(126, 127)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Punkt 2"
        '
        'TeBo_FaceMillingPoint2Z
        '
        Me.TeBo_FaceMillingPoint2Z.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_FaceMillingPoint2Z.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_FaceMillingPoint2Z.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_FaceMillingPoint2Z.Location = New System.Drawing.Point(56, 97)
        Me.TeBo_FaceMillingPoint2Z.Name = "TeBo_FaceMillingPoint2Z"
        Me.TeBo_FaceMillingPoint2Z.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_FaceMillingPoint2Z.TabIndex = 7
        Me.TeBo_FaceMillingPoint2Z.Text = "0,00"
        Me.TeBo_FaceMillingPoint2Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TeBo_FaceMillingPoint2Y
        '
        Me.TeBo_FaceMillingPoint2Y.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_FaceMillingPoint2Y.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_FaceMillingPoint2Y.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_FaceMillingPoint2Y.Location = New System.Drawing.Point(56, 72)
        Me.TeBo_FaceMillingPoint2Y.Name = "TeBo_FaceMillingPoint2Y"
        Me.TeBo_FaceMillingPoint2Y.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_FaceMillingPoint2Y.TabIndex = 6
        Me.TeBo_FaceMillingPoint2Y.Text = "0,00"
        Me.TeBo_FaceMillingPoint2Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TeBo_FaceMillingPoint2X
        '
        Me.TeBo_FaceMillingPoint2X.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_FaceMillingPoint2X.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_FaceMillingPoint2X.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_FaceMillingPoint2X.Location = New System.Drawing.Point(56, 46)
        Me.TeBo_FaceMillingPoint2X.Name = "TeBo_FaceMillingPoint2X"
        Me.TeBo_FaceMillingPoint2X.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_FaceMillingPoint2X.TabIndex = 5
        Me.TeBo_FaceMillingPoint2X.Text = "0,00"
        Me.TeBo_FaceMillingPoint2X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Z"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 79)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(14, 13)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Y"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(14, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "X"
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.ForeColor = System.Drawing.Color.SteelBlue
        Me.TextBox4.Location = New System.Drawing.Point(39, 20)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(81, 20)
        Me.TextBox4.TabIndex = 1
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 21)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(32, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Wahl"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.RaBu_Round)
        Me.GroupBox7.Controls.Add(Me.RaBu_Rightangular)
        Me.GroupBox7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox7.Location = New System.Drawing.Point(3, 151)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(137, 127)
        Me.GroupBox7.TabIndex = 21
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Abzeilart"
        '
        'RaBu_Round
        '
        Me.RaBu_Round.AutoSize = True
        Me.RaBu_Round.Location = New System.Drawing.Point(6, 46)
        Me.RaBu_Round.Name = "RaBu_Round"
        Me.RaBu_Round.Size = New System.Drawing.Size(46, 17)
        Me.RaBu_Round.TabIndex = 1
        Me.RaBu_Round.TabStop = True
        Me.RaBu_Round.Text = "rund"
        Me.RaBu_Round.UseVisualStyleBackColor = True
        '
        'RaBu_Rightangular
        '
        Me.RaBu_Rightangular.AutoSize = True
        Me.RaBu_Rightangular.Checked = True
        Me.RaBu_Rightangular.Location = New System.Drawing.Point(6, 20)
        Me.RaBu_Rightangular.Name = "RaBu_Rightangular"
        Me.RaBu_Rightangular.Size = New System.Drawing.Size(75, 17)
        Me.RaBu_Rightangular.TabIndex = 0
        Me.RaBu_Rightangular.TabStop = True
        Me.RaBu_Rightangular.Text = "rechteckig"
        Me.RaBu_Rightangular.UseVisualStyleBackColor = True
        '
        'NuUpDo_ToolStartStopRetractHeight
        '
        Me.NuUpDo_ToolStartStopRetractHeight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ToolStartStopRetractHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ToolStartStopRetractHeight.DecimalPlaces = 3
        Me.NuUpDo_ToolStartStopRetractHeight.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ToolStartStopRetractHeight.Location = New System.Drawing.Point(199, 97)
        Me.NuUpDo_ToolStartStopRetractHeight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NuUpDo_ToolStartStopRetractHeight.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.NuUpDo_ToolStartStopRetractHeight.Name = "NuUpDo_ToolStartStopRetractHeight"
        Me.NuUpDo_ToolStartStopRetractHeight.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_ToolStartStopRetractHeight.TabIndex = 14
        Me.NuUpDo_ToolStartStopRetractHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_ToolStartStopRetractHeight.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 125)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(106, 13)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Arbeitsrückzugshöhe"
        '
        'CamFaceMilling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GB_StartPoint)
        Me.Controls.Add(Me.Button_ShowCamPath)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button_Ok)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(277, 665)
        Me.Name = "CamFaceMilling"
        Me.Size = New System.Drawing.Size(277, 665)
        Me.Tag = "test"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.NuUpDo_LCorr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_DCorr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.NuUpDo_ToolWorkRetractHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_ToolOverlap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_GroundInFeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_GroundSteps, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_ZInFeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_DephthOfPocket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.NuUpDo_CuttingSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_InFeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_RapidFeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_WorkFeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB_StartPoint.ResumeLayout(False)
        Me.GB_StartPoint.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.NuUpDo_ToolStartStopRetractHeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button_Ok As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Z As System.Windows.Forms.Label
    Friend WithEvents Y As System.Windows.Forms.Label
    Friend WithEvents X As System.Windows.Forms.Label
    Friend WithEvents Origin As System.Windows.Forms.Label
    Friend WithEvents TextBox_OriginZ As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_OriginY As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_OriginX As System.Windows.Forms.TextBox
    Friend WithEvents TeBo_OriginChooser As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RaBu_RR As System.Windows.Forms.RadioButton
    Friend WithEvents RaBu_RL As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents NuUpDo_DephthOfPocket As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_ZInFeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents NuUpDo_WorkFeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button_ShowCamPath As System.Windows.Forms.Button
    Friend WithEvents GB_StartPoint As System.Windows.Forms.GroupBox
    Friend WithEvents TeBo_FaceMillingPoint1Z As System.Windows.Forms.TextBox
    Friend WithEvents TeBo_FaceMillingPoint1Y As System.Windows.Forms.TextBox
    Friend WithEvents TeBo_FaceMillingPoint1X As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TeBo_StaPoiChooser As System.Windows.Forms.TextBox
    Friend WithEvents La_StaPoiChooser As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_GroundSteps As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_RapidFeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_ToolOverlap As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_GroundInFeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_LCorr As System.Windows.Forms.NumericUpDown
    Friend WithEvents La_LCorr As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_DCorr As System.Windows.Forms.NumericUpDown
    Friend WithEvents La_DCorr As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_InFeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_CuttingSpeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CoBo_CoolingAgentChooser As System.Windows.Forms.ComboBox
    Friend WithEvents CoBo_ToolChooser As System.Windows.Forms.ComboBox
    Friend WithEvents TeBo_D1 As System.Windows.Forms.TextBox
    Friend WithEvents La_D1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TeBo_FaceMillingPoint2Z As System.Windows.Forms.TextBox
    Friend WithEvents TeBo_FaceMillingPoint2Y As System.Windows.Forms.TextBox
    Friend WithEvents TeBo_FaceMillingPoint2X As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents RaBu_Round As System.Windows.Forms.RadioButton
    Friend WithEvents RaBu_Rightangular As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_ToolWorkRetractHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_ToolStartStopRetractHeight As System.Windows.Forms.NumericUpDown

End Class
