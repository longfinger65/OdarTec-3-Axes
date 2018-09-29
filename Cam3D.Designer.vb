<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Cam3D
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
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
        Me.GrouBo_ElementsToMachine = New System.Windows.Forms.GroupBox()
        Me.LiBo_ElementsToMachine = New System.Windows.Forms.ListBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TeBo_D1 = New System.Windows.Forms.TextBox()
        Me.La_D1 = New System.Windows.Forms.Label()
        Me.CoBo_ToolChooser = New System.Windows.Forms.ComboBox()
        Me.CoBo_CoolingAgentChooser = New System.Windows.Forms.ComboBox()
        Me.NuUpDo_LCorr = New System.Windows.Forms.NumericUpDown()
        Me.La_LCorr = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.NuUpDo_FinalCuts = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.NuUpDo_FineMachiningOffset = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_FineCuts = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_DephtInfeedForRoughCuts = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NuUpDo_SideStepSizeRough = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.NumericUpDown5 = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NuUpDo_FeedRetractMove = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_CuttingSpeed = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.NuUpDo_FeedRapid = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.NuUpDo_FeedWork = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button_ShowCamPath = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.NuUpDo_CuttingAngle = New System.Windows.Forms.NumericUpDown()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.konturparallel = New System.Windows.Forms.RadioButton()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TeBo_UpRiBoEdgeZ = New System.Windows.Forms.TextBox()
        Me.TeBo_UpRiBoEdgeY = New System.Windows.Forms.TextBox()
        Me.TeBo_UpRiBoEdgeX = New System.Windows.Forms.TextBox()
        Me.TeBo_UpRiBoPoi = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TeBo_LoLeBoEdgeY = New System.Windows.Forms.TextBox()
        Me.TeBo_LoLeBoEdgeX = New System.Windows.Forms.TextBox()
        Me.TeBo_LoLeBoPoi = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NuUpDo_ToolStartStopRetractHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.NuUpDo_ToolWorkRetractHeight = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_SideStepSizeFine = New System.Windows.Forms.NumericUpDown()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GrouBo_ElementsToMachine.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.NuUpDo_LCorr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.NuUpDo_FinalCuts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_FineMachiningOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_FineCuts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_DephtInfeedForRoughCuts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_SideStepSizeRough, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_FeedRetractMove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_CuttingSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_FeedRapid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_FeedWork, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NuUpDo_CuttingAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NuUpDo_ToolStartStopRetractHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_ToolWorkRetractHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_SideStepSizeFine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(327, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "3D-Fräsen"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_Ok
        '
        Me.Button_Ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Ok.BackColor = System.Drawing.Color.LightGreen
        Me.Button_Ok.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Ok.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button_Ok.Location = New System.Drawing.Point(245, 698)
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
        Me.GroupBox1.Size = New System.Drawing.Size(145, 127)
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
        Me.TeBo_OriginZ.Location = New System.Drawing.Point(75, 97)
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
        Me.TeBo_OriginY.Location = New System.Drawing.Point(75, 72)
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
        Me.TeBo_OriginX.Location = New System.Drawing.Point(75, 45)
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
        Me.TeBo_OriginChooser.Size = New System.Drawing.Size(89, 20)
        Me.TeBo_OriginChooser.TabIndex = 11
        '
        'GrouBo_ElementsToMachine
        '
        Me.GrouBo_ElementsToMachine.Controls.Add(Me.LiBo_ElementsToMachine)
        Me.GrouBo_ElementsToMachine.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GrouBo_ElementsToMachine.Location = New System.Drawing.Point(3, 18)
        Me.GrouBo_ElementsToMachine.Name = "GrouBo_ElementsToMachine"
        Me.GrouBo_ElementsToMachine.Size = New System.Drawing.Size(321, 93)
        Me.GrouBo_ElementsToMachine.TabIndex = 12
        Me.GrouBo_ElementsToMachine.TabStop = False
        Me.GrouBo_ElementsToMachine.Text = "Gewählte Elemente"
        '
        'LiBo_ElementsToMachine
        '
        Me.LiBo_ElementsToMachine.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LiBo_ElementsToMachine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LiBo_ElementsToMachine.ForeColor = System.Drawing.Color.SteelBlue
        Me.LiBo_ElementsToMachine.FormattingEnabled = True
        Me.LiBo_ElementsToMachine.Location = New System.Drawing.Point(6, 16)
        Me.LiBo_ElementsToMachine.Name = "LiBo_ElementsToMachine"
        Me.LiBo_ElementsToMachine.Size = New System.Drawing.Size(309, 67)
        Me.LiBo_ElementsToMachine.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.GhostWhite
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Button2.Location = New System.Drawing.Point(3, 698)
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
        Me.GroupBox4.Location = New System.Drawing.Point(154, 117)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(170, 127)
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
        Me.TeBo_D1.Location = New System.Drawing.Point(100, 75)
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
        Me.CoBo_ToolChooser.Size = New System.Drawing.Size(142, 21)
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
        Me.CoBo_CoolingAgentChooser.Size = New System.Drawing.Size(142, 21)
        Me.CoBo_CoolingAgentChooser.TabIndex = 6
        Me.CoBo_CoolingAgentChooser.Text = "keine Kühlung"
        '
        'NuUpDo_LCorr
        '
        Me.NuUpDo_LCorr.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_LCorr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_LCorr.DecimalPlaces = 2
        Me.NuUpDo_LCorr.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_LCorr.Location = New System.Drawing.Point(100, 101)
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
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_SideStepSizeFine)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_FinalCuts)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_FineMachiningOffset)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_FineCuts)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_DephtInfeedForRoughCuts)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_SideStepSizeRough)
        Me.GroupBox5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox5.Location = New System.Drawing.Point(154, 353)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(170, 212)
        Me.GroupBox5.TabIndex = 16
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Steps und Zustellung"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 151)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 13)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "Anzahl Endschn."
        '
        'NuUpDo_FinalCuts
        '
        Me.NuUpDo_FinalCuts.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_FinalCuts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_FinalCuts.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_FinalCuts.Location = New System.Drawing.Point(100, 149)
        Me.NuUpDo_FinalCuts.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NuUpDo_FinalCuts.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NuUpDo_FinalCuts.Name = "NuUpDo_FinalCuts"
        Me.NuUpDo_FinalCuts.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_FinalCuts.TabIndex = 8
        Me.NuUpDo_FinalCuts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_FinalCuts.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 125)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 13)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Zustellung Schlic."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 99)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Anzahl Schlichtd."
        '
        'NuUpDo_FineMachiningOffset
        '
        Me.NuUpDo_FineMachiningOffset.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_FineMachiningOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_FineMachiningOffset.DecimalPlaces = 2
        Me.NuUpDo_FineMachiningOffset.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_FineMachiningOffset.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NuUpDo_FineMachiningOffset.Location = New System.Drawing.Point(100, 123)
        Me.NuUpDo_FineMachiningOffset.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NuUpDo_FineMachiningOffset.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.NuUpDo_FineMachiningOffset.Name = "NuUpDo_FineMachiningOffset"
        Me.NuUpDo_FineMachiningOffset.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_FineMachiningOffset.TabIndex = 5
        Me.NuUpDo_FineMachiningOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_FineMachiningOffset.Value = New Decimal(New Integer() {10, 0, 0, -2147352576})
        '
        'NuUpDo_FineCuts
        '
        Me.NuUpDo_FineCuts.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_FineCuts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_FineCuts.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_FineCuts.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NuUpDo_FineCuts.Location = New System.Drawing.Point(100, 97)
        Me.NuUpDo_FineCuts.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NuUpDo_FineCuts.Name = "NuUpDo_FineCuts"
        Me.NuUpDo_FineCuts.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_FineCuts.TabIndex = 4
        Me.NuUpDo_FineCuts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NuUpDo_DephtInfeedForRoughCuts
        '
        Me.NuUpDo_DephtInfeedForRoughCuts.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_DephtInfeedForRoughCuts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_DephtInfeedForRoughCuts.DecimalPlaces = 2
        Me.NuUpDo_DephtInfeedForRoughCuts.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_DephtInfeedForRoughCuts.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NuUpDo_DephtInfeedForRoughCuts.Location = New System.Drawing.Point(100, 71)
        Me.NuUpDo_DephtInfeedForRoughCuts.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NuUpDo_DephtInfeedForRoughCuts.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.NuUpDo_DephtInfeedForRoughCuts.Name = "NuUpDo_DephtInfeedForRoughCuts"
        Me.NuUpDo_DephtInfeedForRoughCuts.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_DephtInfeedForRoughCuts.TabIndex = 3
        Me.NuUpDo_DephtInfeedForRoughCuts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_DephtInfeedForRoughCuts.Value = New Decimal(New Integer() {50, 0, 0, -2147352576})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Zustellung Tiefe"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Zust. Seite Schl."
        '
        'NuUpDo_SideStepSizeRough
        '
        Me.NuUpDo_SideStepSizeRough.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_SideStepSizeRough.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_SideStepSizeRough.DecimalPlaces = 3
        Me.NuUpDo_SideStepSizeRough.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_SideStepSizeRough.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NuUpDo_SideStepSizeRough.Location = New System.Drawing.Point(100, 19)
        Me.NuUpDo_SideStepSizeRough.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NuUpDo_SideStepSizeRough.Minimum = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NuUpDo_SideStepSizeRough.Name = "NuUpDo_SideStepSizeRough"
        Me.NuUpDo_SideStepSizeRough.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_SideStepSizeRough.TabIndex = 0
        Me.NuUpDo_SideStepSizeRough.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_SideStepSizeRough.Value = New Decimal(New Integer() {15, 0, 0, 65536})
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label17)
        Me.GroupBox6.Controls.Add(Me.NumericUpDown5)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.NuUpDo_FeedRetractMove)
        Me.GroupBox6.Controls.Add(Me.NuUpDo_CuttingSpeed)
        Me.GroupBox6.Controls.Add(Me.Label18)
        Me.GroupBox6.Controls.Add(Me.NuUpDo_FeedRapid)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.NuUpDo_FeedWork)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox6.Location = New System.Drawing.Point(3, 592)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(321, 100)
        Me.GroupBox6.TabIndex = 17
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Vorschübe u. Schnittge."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(148, 47)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 13)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "Schnittg."
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NumericUpDown5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericUpDown5.ForeColor = System.Drawing.Color.SteelBlue
        Me.NumericUpDown5.Location = New System.Drawing.Point(251, 45)
        Me.NumericUpDown5.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NumericUpDown5.Name = "NumericUpDown5"
        Me.NumericUpDown5.Size = New System.Drawing.Size(64, 20)
        Me.NumericUpDown5.TabIndex = 10
        Me.NumericUpDown5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDown5.Value = New Decimal(New Integer() {20, 0, 0, 0})
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
        Me.NuUpDo_FeedRetractMove.Value = New Decimal(New Integer() {4000, 0, 0, 0})
        '
        'NuUpDo_CuttingSpeed
        '
        Me.NuUpDo_CuttingSpeed.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_CuttingSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_CuttingSpeed.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_CuttingSpeed.Location = New System.Drawing.Point(251, 19)
        Me.NuUpDo_CuttingSpeed.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NuUpDo_CuttingSpeed.Name = "NuUpDo_CuttingSpeed"
        Me.NuUpDo_CuttingSpeed.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_CuttingSpeed.TabIndex = 7
        Me.NuUpDo_CuttingSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_CuttingSpeed.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(150, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 13)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Zustellung"
        '
        'NuUpDo_FeedRapid
        '
        Me.NuUpDo_FeedRapid.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_FeedRapid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_FeedRapid.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_FeedRapid.Location = New System.Drawing.Point(67, 45)
        Me.NuUpDo_FeedRapid.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NuUpDo_FeedRapid.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
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
        Me.Button_ShowCamPath.Location = New System.Drawing.Point(84, 698)
        Me.Button_ShowCamPath.Name = "Button_ShowCamPath"
        Me.Button_ShowCamPath.Size = New System.Drawing.Size(105, 23)
        Me.Button_ShowCamPath.TabIndex = 18
        Me.Button_ShowCamPath.Text = "Zeige Bahn"
        Me.Button_ShowCamPath.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.NuUpDo_CuttingAngle)
        Me.GroupBox3.Controls.Add(Me.RadioButton3)
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.konturparallel)
        Me.GroupBox3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox3.Location = New System.Drawing.Point(154, 250)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(170, 97)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Zustellrichtung"
        '
        'NuUpDo_CuttingAngle
        '
        Me.NuUpDo_CuttingAngle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_CuttingAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_CuttingAngle.DecimalPlaces = 2
        Me.NuUpDo_CuttingAngle.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_CuttingAngle.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NuUpDo_CuttingAngle.Location = New System.Drawing.Point(100, 68)
        Me.NuUpDo_CuttingAngle.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.NuUpDo_CuttingAngle.Name = "NuUpDo_CuttingAngle"
        Me.NuUpDo_CuttingAngle.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_CuttingAngle.TabIndex = 3
        Me.NuUpDo_CuttingAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Checked = True
        Me.RadioButton3.Location = New System.Drawing.Point(6, 68)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(71, 17)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "im Winkel"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(6, 45)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(78, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Einstechen"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'konturparallel
        '
        Me.konturparallel.AutoSize = True
        Me.konturparallel.Location = New System.Drawing.Point(6, 22)
        Me.konturparallel.Name = "konturparallel"
        Me.konturparallel.Size = New System.Drawing.Size(88, 17)
        Me.konturparallel.TabIndex = 0
        Me.konturparallel.TabStop = True
        Me.konturparallel.Text = "konturparallel"
        Me.konturparallel.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label6)
        Me.GroupBox7.Controls.Add(Me.Label7)
        Me.GroupBox7.Controls.Add(Me.Label8)
        Me.GroupBox7.Controls.Add(Me.Label9)
        Me.GroupBox7.Controls.Add(Me.TeBo_UpRiBoEdgeZ)
        Me.GroupBox7.Controls.Add(Me.TeBo_UpRiBoEdgeY)
        Me.GroupBox7.Controls.Add(Me.TeBo_UpRiBoEdgeX)
        Me.GroupBox7.Controls.Add(Me.TeBo_UpRiBoPoi)
        Me.GroupBox7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox7.Location = New System.Drawing.Point(3, 250)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(145, 127)
        Me.GroupBox7.TabIndex = 20
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "oberer rechter Eckpunkt"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Z"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(14, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Y"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "X"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Wahl"
        '
        'TeBo_UpRiBoEdgeZ
        '
        Me.TeBo_UpRiBoEdgeZ.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_UpRiBoEdgeZ.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_UpRiBoEdgeZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_UpRiBoEdgeZ.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_UpRiBoEdgeZ.Location = New System.Drawing.Point(75, 97)
        Me.TeBo_UpRiBoEdgeZ.Name = "TeBo_UpRiBoEdgeZ"
        Me.TeBo_UpRiBoEdgeZ.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_UpRiBoEdgeZ.TabIndex = 14
        Me.TeBo_UpRiBoEdgeZ.Text = "0,00"
        Me.TeBo_UpRiBoEdgeZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_UpRiBoEdgeZ.WordWrap = False
        '
        'TeBo_UpRiBoEdgeY
        '
        Me.TeBo_UpRiBoEdgeY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_UpRiBoEdgeY.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_UpRiBoEdgeY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_UpRiBoEdgeY.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_UpRiBoEdgeY.Location = New System.Drawing.Point(75, 72)
        Me.TeBo_UpRiBoEdgeY.Name = "TeBo_UpRiBoEdgeY"
        Me.TeBo_UpRiBoEdgeY.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_UpRiBoEdgeY.TabIndex = 13
        Me.TeBo_UpRiBoEdgeY.Text = "0,00"
        Me.TeBo_UpRiBoEdgeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_UpRiBoEdgeY.WordWrap = False
        '
        'TeBo_UpRiBoEdgeX
        '
        Me.TeBo_UpRiBoEdgeX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_UpRiBoEdgeX.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_UpRiBoEdgeX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_UpRiBoEdgeX.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_UpRiBoEdgeX.Location = New System.Drawing.Point(75, 45)
        Me.TeBo_UpRiBoEdgeX.Name = "TeBo_UpRiBoEdgeX"
        Me.TeBo_UpRiBoEdgeX.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_UpRiBoEdgeX.TabIndex = 12
        Me.TeBo_UpRiBoEdgeX.Text = "0,00"
        Me.TeBo_UpRiBoEdgeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_UpRiBoEdgeX.WordWrap = False
        '
        'TeBo_UpRiBoPoi
        '
        Me.TeBo_UpRiBoPoi.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_UpRiBoPoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_UpRiBoPoi.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_UpRiBoPoi.Location = New System.Drawing.Point(50, 19)
        Me.TeBo_UpRiBoPoi.Name = "TeBo_UpRiBoPoi"
        Me.TeBo_UpRiBoPoi.Size = New System.Drawing.Size(89, 20)
        Me.TeBo_UpRiBoPoi.TabIndex = 11
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label12)
        Me.GroupBox8.Controls.Add(Me.Label13)
        Me.GroupBox8.Controls.Add(Me.Label14)
        Me.GroupBox8.Controls.Add(Me.TeBo_LoLeBoEdgeY)
        Me.GroupBox8.Controls.Add(Me.TeBo_LoLeBoEdgeX)
        Me.GroupBox8.Controls.Add(Me.TeBo_LoLeBoPoi)
        Me.GroupBox8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox8.Location = New System.Drawing.Point(3, 383)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(145, 100)
        Me.GroupBox8.TabIndex = 21
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "unterer linker Eckpunkt"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(14, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Y"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(14, 13)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "X"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Wahl"
        '
        'TeBo_LoLeBoEdgeY
        '
        Me.TeBo_LoLeBoEdgeY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_LoLeBoEdgeY.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_LoLeBoEdgeY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_LoLeBoEdgeY.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_LoLeBoEdgeY.Location = New System.Drawing.Point(75, 72)
        Me.TeBo_LoLeBoEdgeY.Name = "TeBo_LoLeBoEdgeY"
        Me.TeBo_LoLeBoEdgeY.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_LoLeBoEdgeY.TabIndex = 13
        Me.TeBo_LoLeBoEdgeY.Text = "0,00"
        Me.TeBo_LoLeBoEdgeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_LoLeBoEdgeY.WordWrap = False
        '
        'TeBo_LoLeBoEdgeX
        '
        Me.TeBo_LoLeBoEdgeX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_LoLeBoEdgeX.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_LoLeBoEdgeX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_LoLeBoEdgeX.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_LoLeBoEdgeX.Location = New System.Drawing.Point(75, 45)
        Me.TeBo_LoLeBoEdgeX.Name = "TeBo_LoLeBoEdgeX"
        Me.TeBo_LoLeBoEdgeX.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_LoLeBoEdgeX.TabIndex = 12
        Me.TeBo_LoLeBoEdgeX.Text = "0,00"
        Me.TeBo_LoLeBoEdgeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_LoLeBoEdgeX.WordWrap = False
        '
        'TeBo_LoLeBoPoi
        '
        Me.TeBo_LoLeBoPoi.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_LoLeBoPoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_LoLeBoPoi.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_LoLeBoPoi.Location = New System.Drawing.Point(50, 19)
        Me.TeBo_LoLeBoPoi.Name = "TeBo_LoLeBoPoi"
        Me.TeBo_LoLeBoPoi.Size = New System.Drawing.Size(89, 20)
        Me.TeBo_LoLeBoPoi.TabIndex = 11
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.NuUpDo_ToolStartStopRetractHeight)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.NuUpDo_ToolWorkRetractHeight)
        Me.GroupBox2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox2.Location = New System.Drawing.Point(3, 489)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(145, 76)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rückzugshöhen"
        '
        'NuUpDo_ToolStartStopRetractHeight
        '
        Me.NuUpDo_ToolStartStopRetractHeight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ToolStartStopRetractHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ToolStartStopRetractHeight.DecimalPlaces = 2
        Me.NuUpDo_ToolStartStopRetractHeight.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ToolStartStopRetractHeight.Location = New System.Drawing.Point(75, 45)
        Me.NuUpDo_ToolStartStopRetractHeight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NuUpDo_ToolStartStopRetractHeight.Name = "NuUpDo_ToolStartStopRetractHeight"
        Me.NuUpDo_ToolStartStopRetractHeight.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_ToolStartStopRetractHeight.TabIndex = 3
        Me.NuUpDo_ToolStartStopRetractHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_ToolStartStopRetractHeight.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 47)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 13)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "Sta-Sto-Rzh."
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(7, 21)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 13)
        Me.Label23.TabIndex = 1
        Me.Label23.Text = "Arbeitsrzh."
        '
        'NuUpDo_ToolWorkRetractHeight
        '
        Me.NuUpDo_ToolWorkRetractHeight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ToolWorkRetractHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ToolWorkRetractHeight.DecimalPlaces = 2
        Me.NuUpDo_ToolWorkRetractHeight.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ToolWorkRetractHeight.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NuUpDo_ToolWorkRetractHeight.Location = New System.Drawing.Point(75, 19)
        Me.NuUpDo_ToolWorkRetractHeight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NuUpDo_ToolWorkRetractHeight.Name = "NuUpDo_ToolWorkRetractHeight"
        Me.NuUpDo_ToolWorkRetractHeight.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_ToolWorkRetractHeight.TabIndex = 0
        Me.NuUpDo_ToolWorkRetractHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_ToolWorkRetractHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NuUpDo_SideStepSizeFine
        '
        Me.NuUpDo_SideStepSizeFine.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_SideStepSizeFine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_SideStepSizeFine.DecimalPlaces = 3
        Me.NuUpDo_SideStepSizeFine.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_SideStepSizeFine.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NuUpDo_SideStepSizeFine.Location = New System.Drawing.Point(100, 45)
        Me.NuUpDo_SideStepSizeFine.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NuUpDo_SideStepSizeFine.Minimum = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NuUpDo_SideStepSizeFine.Name = "NuUpDo_SideStepSizeFine"
        Me.NuUpDo_SideStepSizeFine.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_SideStepSizeFine.TabIndex = 10
        Me.NuUpDo_SideStepSizeFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_SideStepSizeFine.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 47)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 13)
        Me.Label19.TabIndex = 11
        Me.Label19.Text = "Zust. Seite Schl."
        '
        'Cam3D
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Button_ShowCamPath)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GrouBo_ElementsToMachine)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button_Ok)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(277, 464)
        Me.Name = "Cam3D"
        Me.Size = New System.Drawing.Size(327, 724)
        Me.Tag = "test"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrouBo_ElementsToMachine.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.NuUpDo_LCorr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.NuUpDo_FinalCuts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_FineMachiningOffset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_FineCuts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_DephtInfeedForRoughCuts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_SideStepSizeRough, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_FeedRetractMove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_CuttingSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_FeedRapid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_FeedWork, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NuUpDo_CuttingAngle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NuUpDo_ToolStartStopRetractHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_ToolWorkRetractHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_SideStepSizeFine, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GrouBo_ElementsToMachine As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents NuUpDo_SideStepSizeRough As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_DephtInfeedForRoughCuts As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents NuUpDo_FeedWork As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LiBo_ElementsToMachine As System.Windows.Forms.ListBox
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
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents NuUpDo_CuttingAngle As NumericUpDown
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents konturparallel As RadioButton
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TeBo_UpRiBoEdgeZ As TextBox
    Friend WithEvents TeBo_UpRiBoEdgeY As TextBox
    Friend WithEvents TeBo_UpRiBoEdgeX As TextBox
    Friend WithEvents TeBo_UpRiBoPoi As TextBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TeBo_LoLeBoEdgeY As TextBox
    Friend WithEvents TeBo_LoLeBoEdgeX As TextBox
    Friend WithEvents TeBo_LoLeBoPoi As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents NuUpDo_FineMachiningOffset As NumericUpDown
    Friend WithEvents NuUpDo_FineCuts As NumericUpDown
    Friend WithEvents Label16 As Label
    Friend WithEvents NuUpDo_FinalCuts As NumericUpDown
    Friend WithEvents Label17 As Label
    Friend WithEvents NumericUpDown5 As NumericUpDown
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents NuUpDo_ToolStartStopRetractHeight As NumericUpDown
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents NuUpDo_ToolWorkRetractHeight As NumericUpDown
    Friend WithEvents Label19 As Label
    Friend WithEvents NuUpDo_SideStepSizeFine As NumericUpDown
End Class
