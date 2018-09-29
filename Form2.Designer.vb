<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MachinePanel
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MachinePanel))
        Me.TabCon_MachinePanel = New System.Windows.Forms.TabControl()
        Me.TaPa_MainPanel = New System.Windows.Forms.TabPage()
        Me.GroupBox_Navigate = New System.Windows.Forms.GroupBox()
        Me.Button34 = New System.Windows.Forms.Button()
        Me.Button_Delete = New System.Windows.Forms.Button()
        Me.Button_Right = New System.Windows.Forms.Button()
        Me.Button31 = New System.Windows.Forms.Button()
        Me.Button_Left = New System.Windows.Forms.Button()
        Me.GroupBox_Action = New System.Windows.Forms.GroupBox()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button_Auto = New System.Windows.Forms.Button()
        Me.Button_Stop = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Bu_SetLaser = New System.Windows.Forms.Button()
        Me.Bu_SpindleOff = New System.Windows.Forms.Button()
        Me.Bu_SpindleOn = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button_Minus = New System.Windows.Forms.Button()
        Me.Button_Enter = New System.Windows.Forms.Button()
        Me.Button_Plus = New System.Windows.Forms.Button()
        Me.Button_Komma = New System.Windows.Forms.Button()
        Me.Button45 = New System.Windows.Forms.Button()
        Me.Button_0 = New System.Windows.Forms.Button()
        Me.Button_3 = New System.Windows.Forms.Button()
        Me.Button_1 = New System.Windows.Forms.Button()
        Me.Button_2 = New System.Windows.Forms.Button()
        Me.Button_6 = New System.Windows.Forms.Button()
        Me.Button_5 = New System.Windows.Forms.Button()
        Me.Button_4 = New System.Windows.Forms.Button()
        Me.Button_9 = New System.Windows.Forms.Button()
        Me.Button_8 = New System.Windows.Forms.Button()
        Me.Button_7 = New System.Windows.Forms.Button()
        Me.Button_D = New System.Windows.Forms.Button()
        Me.Button29 = New System.Windows.Forms.Button()
        Me.Button28 = New System.Windows.Forms.Button()
        Me.Button27 = New System.Windows.Forms.Button()
        Me.Button26 = New System.Windows.Forms.Button()
        Me.Button25 = New System.Windows.Forms.Button()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.GroupBox_Move = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TraBa_FeedRate = New System.Windows.Forms.TrackBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NuUpDo_StepSize = New System.Windows.Forms.NumericUpDown()
        Me.Bu_StepPlusZ = New System.Windows.Forms.Button()
        Me.Bu_StepPlusY = New System.Windows.Forms.Button()
        Me.Bu_StepPlusX = New System.Windows.Forms.Button()
        Me.Bu_StepMinusZ = New System.Windows.Forms.Button()
        Me.Bu_StepMinusY = New System.Windows.Forms.Button()
        Me.Bu_StepMinusX = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GrouBo_AxesStepRatio = New System.Windows.Forms.GroupBox()
        Me.Bu_TakeOverAxesStepRatio = New System.Windows.Forms.Button()
        Me.NuUpDo_Axis5MMProStep = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_Axis4MMProStep = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_ZAxisMMProStep = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_YAxisMMProStep = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_XAxisMMProStep = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Bu_LoadValuesFromMachine = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TaPa_MachineConnection = New System.Windows.Forms.TabPage()
        Me.FlowControl = New System.Windows.Forms.Label()
        Me.La_StpBits = New System.Windows.Forms.Label()
        Me.La_DataBits = New System.Windows.Forms.Label()
        Me.La_Parity = New System.Windows.Forms.Label()
        Me.La_BaudRate = New System.Windows.Forms.Label()
        Me.La_COMPorts = New System.Windows.Forms.Label()
        Me.CoBo_FlowControl = New System.Windows.Forms.ComboBox()
        Me.CoBo_StopBits = New System.Windows.Forms.ComboBox()
        Me.CoBo_DataBits = New System.Windows.Forms.ComboBox()
        Me.CoBo_Parity = New System.Windows.Forms.ComboBox()
        Me.CoBo_BaudRate = New System.Windows.Forms.ComboBox()
        Me.CoBo_COMPort = New System.Windows.Forms.ComboBox()
        Me.Bu_Disconnect = New System.Windows.Forms.Button()
        Me.Bu_Connect = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MachineInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.SerPo_Machine = New System.IO.Ports.SerialPort(Me.components)
        Me.TabCon_MachinePanel.SuspendLayout()
        Me.TaPa_MainPanel.SuspendLayout()
        Me.GroupBox_Navigate.SuspendLayout()
        Me.GroupBox_Action.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox_Move.SuspendLayout()
        CType(Me.TraBa_FeedRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_StepSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GrouBo_AxesStepRatio.SuspendLayout()
        CType(Me.NuUpDo_Axis5MMProStep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_Axis4MMProStep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_ZAxisMMProStep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_YAxisMMProStep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_XAxisMMProStep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.TaPa_MachineConnection.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabCon_MachinePanel
        '
        Me.TabCon_MachinePanel.Controls.Add(Me.TaPa_MainPanel)
        Me.TabCon_MachinePanel.Controls.Add(Me.TabPage2)
        Me.TabCon_MachinePanel.Controls.Add(Me.TaPa_MachineConnection)
        Me.TabCon_MachinePanel.Location = New System.Drawing.Point(0, 27)
        Me.TabCon_MachinePanel.Name = "TabCon_MachinePanel"
        Me.TabCon_MachinePanel.SelectedIndex = 0
        Me.TabCon_MachinePanel.Size = New System.Drawing.Size(569, 539)
        Me.TabCon_MachinePanel.TabIndex = 0
        '
        'TaPa_MainPanel
        '
        Me.TaPa_MainPanel.BackColor = System.Drawing.Color.Lavender
        Me.TaPa_MainPanel.Controls.Add(Me.GroupBox_Navigate)
        Me.TaPa_MainPanel.Controls.Add(Me.GroupBox_Action)
        Me.TaPa_MainPanel.Controls.Add(Me.GroupBox2)
        Me.TaPa_MainPanel.Controls.Add(Me.GroupBox_Move)
        Me.TaPa_MainPanel.Controls.Add(Me.TextBox1)
        Me.TaPa_MainPanel.Controls.Add(Me.Label4)
        Me.TaPa_MainPanel.Controls.Add(Me.Label1)
        Me.TaPa_MainPanel.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.TaPa_MainPanel.Location = New System.Drawing.Point(4, 22)
        Me.TaPa_MainPanel.Name = "TaPa_MainPanel"
        Me.TaPa_MainPanel.Padding = New System.Windows.Forms.Padding(3)
        Me.TaPa_MainPanel.Size = New System.Drawing.Size(561, 513)
        Me.TaPa_MainPanel.TabIndex = 0
        Me.TaPa_MainPanel.Text = "Main panel"
        '
        'GroupBox_Navigate
        '
        Me.GroupBox_Navigate.Controls.Add(Me.Button34)
        Me.GroupBox_Navigate.Controls.Add(Me.Button_Delete)
        Me.GroupBox_Navigate.Controls.Add(Me.Button_Right)
        Me.GroupBox_Navigate.Controls.Add(Me.Button31)
        Me.GroupBox_Navigate.Controls.Add(Me.Button_Left)
        Me.GroupBox_Navigate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox_Navigate.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox_Navigate.Location = New System.Drawing.Point(203, 222)
        Me.GroupBox_Navigate.Name = "GroupBox_Navigate"
        Me.GroupBox_Navigate.Size = New System.Drawing.Size(176, 198)
        Me.GroupBox_Navigate.TabIndex = 24
        Me.GroupBox_Navigate.TabStop = False
        Me.GroupBox_Navigate.Text = "Navigate"
        '
        'Button34
        '
        Me.Button34.BackColor = System.Drawing.Color.Lavender
        Me.Button34.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button34.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button34.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button34.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button34.Location = New System.Drawing.Point(62, 124)
        Me.Button34.Margin = New System.Windows.Forms.Padding(0)
        Me.Button34.Name = "Button34"
        Me.Button34.Size = New System.Drawing.Size(51, 51)
        Me.Button34.TabIndex = 4
        Me.Button34.Text = "↓"
        Me.Button34.UseVisualStyleBackColor = False
        '
        'Button_Delete
        '
        Me.Button_Delete.BackColor = System.Drawing.Color.Khaki
        Me.Button_Delete.FlatAppearance.BorderColor = System.Drawing.Color.Khaki
        Me.Button_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold
        Me.Button_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon
        Me.Button_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Delete.Location = New System.Drawing.Point(62, 72)
        Me.Button_Delete.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Delete.Name = "Button_Delete"
        Me.Button_Delete.Size = New System.Drawing.Size(51, 51)
        Me.Button_Delete.TabIndex = 3
        Me.Button_Delete.Text = "Delete"
        Me.Button_Delete.UseVisualStyleBackColor = False
        '
        'Button_Right
        '
        Me.Button_Right.BackColor = System.Drawing.Color.Lavender
        Me.Button_Right.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button_Right.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button_Right.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button_Right.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Right.Location = New System.Drawing.Point(113, 72)
        Me.Button_Right.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Right.Name = "Button_Right"
        Me.Button_Right.Size = New System.Drawing.Size(51, 51)
        Me.Button_Right.TabIndex = 2
        Me.Button_Right.Text = "→"
        Me.Button_Right.UseVisualStyleBackColor = False
        '
        'Button31
        '
        Me.Button31.BackColor = System.Drawing.Color.Lavender
        Me.Button31.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button31.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button31.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button31.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button31.Location = New System.Drawing.Point(62, 21)
        Me.Button31.Margin = New System.Windows.Forms.Padding(0)
        Me.Button31.Name = "Button31"
        Me.Button31.Size = New System.Drawing.Size(51, 51)
        Me.Button31.TabIndex = 1
        Me.Button31.Text = "↑"
        Me.Button31.UseVisualStyleBackColor = False
        '
        'Button_Left
        '
        Me.Button_Left.BackColor = System.Drawing.Color.Lavender
        Me.Button_Left.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button_Left.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button_Left.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button_Left.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Left.Location = New System.Drawing.Point(11, 72)
        Me.Button_Left.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Left.Name = "Button_Left"
        Me.Button_Left.Size = New System.Drawing.Size(51, 51)
        Me.Button_Left.TabIndex = 0
        Me.Button_Left.Text = "←"
        Me.Button_Left.UseVisualStyleBackColor = False
        '
        'GroupBox_Action
        '
        Me.GroupBox_Action.Controls.Add(Me.Button10)
        Me.GroupBox_Action.Controls.Add(Me.Button_Auto)
        Me.GroupBox_Action.Controls.Add(Me.Button_Stop)
        Me.GroupBox_Action.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox_Action.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox_Action.Location = New System.Drawing.Point(203, 426)
        Me.GroupBox_Action.Name = "GroupBox_Action"
        Me.GroupBox_Action.Size = New System.Drawing.Size(176, 79)
        Me.GroupBox_Action.TabIndex = 23
        Me.GroupBox_Action.TabStop = False
        Me.GroupBox_Action.Text = "Action"
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Location = New System.Drawing.Point(62, 19)
        Me.Button10.Margin = New System.Windows.Forms.Padding(0)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(51, 51)
        Me.Button10.TabIndex = 16
        Me.Button10.Text = "Pause"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button_Auto
        '
        Me.Button_Auto.BackColor = System.Drawing.Color.LightGreen
        Me.Button_Auto.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button_Auto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Auto.Location = New System.Drawing.Point(113, 19)
        Me.Button_Auto.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Auto.Name = "Button_Auto"
        Me.Button_Auto.Size = New System.Drawing.Size(51, 51)
        Me.Button_Auto.TabIndex = 15
        Me.Button_Auto.Text = "Auto"
        Me.Button_Auto.UseVisualStyleBackColor = False
        '
        'Button_Stop
        '
        Me.Button_Stop.BackColor = System.Drawing.Color.Crimson
        Me.Button_Stop.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Stop.Location = New System.Drawing.Point(11, 19)
        Me.Button_Stop.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Stop.Name = "Button_Stop"
        Me.Button_Stop.Size = New System.Drawing.Size(51, 51)
        Me.Button_Stop.TabIndex = 14
        Me.Button_Stop.Text = "Stop"
        Me.Button_Stop.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Bu_SetLaser)
        Me.GroupBox2.Controls.Add(Me.Bu_SpindleOff)
        Me.GroupBox2.Controls.Add(Me.Bu_SpindleOn)
        Me.GroupBox2.Controls.Add(Me.Button16)
        Me.GroupBox2.Controls.Add(Me.Button_Minus)
        Me.GroupBox2.Controls.Add(Me.Button_Enter)
        Me.GroupBox2.Controls.Add(Me.Button_Plus)
        Me.GroupBox2.Controls.Add(Me.Button_Komma)
        Me.GroupBox2.Controls.Add(Me.Button45)
        Me.GroupBox2.Controls.Add(Me.Button_0)
        Me.GroupBox2.Controls.Add(Me.Button_3)
        Me.GroupBox2.Controls.Add(Me.Button_1)
        Me.GroupBox2.Controls.Add(Me.Button_2)
        Me.GroupBox2.Controls.Add(Me.Button_6)
        Me.GroupBox2.Controls.Add(Me.Button_5)
        Me.GroupBox2.Controls.Add(Me.Button_4)
        Me.GroupBox2.Controls.Add(Me.Button_9)
        Me.GroupBox2.Controls.Add(Me.Button_8)
        Me.GroupBox2.Controls.Add(Me.Button_7)
        Me.GroupBox2.Controls.Add(Me.Button_D)
        Me.GroupBox2.Controls.Add(Me.Button29)
        Me.GroupBox2.Controls.Add(Me.Button28)
        Me.GroupBox2.Controls.Add(Me.Button27)
        Me.GroupBox2.Controls.Add(Me.Button26)
        Me.GroupBox2.Controls.Add(Me.Button25)
        Me.GroupBox2.Controls.Add(Me.Button24)
        Me.GroupBox2.Controls.Add(Me.Button23)
        Me.GroupBox2.Controls.Add(Me.Button22)
        Me.GroupBox2.Controls.Add(Me.Button21)
        Me.GroupBox2.Controls.Add(Me.Button20)
        Me.GroupBox2.Controls.Add(Me.Button19)
        Me.GroupBox2.Controls.Add(Me.Button18)
        Me.GroupBox2.Controls.Add(Me.Button17)
        Me.GroupBox2.Controls.Add(Me.Button15)
        Me.GroupBox2.Controls.Add(Me.Button14)
        Me.GroupBox2.Controls.Add(Me.Button13)
        Me.GroupBox2.Controls.Add(Me.Button12)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox2.Location = New System.Drawing.Point(9, 222)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(189, 283)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Program"
        '
        'Bu_SetLaser
        '
        Me.Bu_SetLaser.BackColor = System.Drawing.Color.Lavender
        Me.Bu_SetLaser.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Bu_SetLaser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Bu_SetLaser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Bu_SetLaser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_SetLaser.Location = New System.Drawing.Point(108, 124)
        Me.Bu_SetLaser.Margin = New System.Windows.Forms.Padding(0)
        Me.Bu_SetLaser.Name = "Bu_SetLaser"
        Me.Bu_SetLaser.Size = New System.Drawing.Size(77, 51)
        Me.Bu_SetLaser.TabIndex = 57
        Me.Bu_SetLaser.Text = "Laser einrichten"
        Me.Bu_SetLaser.UseVisualStyleBackColor = False
        '
        'Bu_SpindleOff
        '
        Me.Bu_SpindleOff.BackColor = System.Drawing.Color.Lavender
        Me.Bu_SpindleOff.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Bu_SpindleOff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Bu_SpindleOff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Bu_SpindleOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_SpindleOff.Location = New System.Drawing.Point(108, 176)
        Me.Bu_SpindleOff.Margin = New System.Windows.Forms.Padding(0)
        Me.Bu_SpindleOff.Name = "Bu_SpindleOff"
        Me.Bu_SpindleOff.Size = New System.Drawing.Size(77, 51)
        Me.Bu_SpindleOff.TabIndex = 56
        Me.Bu_SpindleOff.Text = "M05"
        Me.Bu_SpindleOff.UseVisualStyleBackColor = False
        '
        'Bu_SpindleOn
        '
        Me.Bu_SpindleOn.BackColor = System.Drawing.Color.Lavender
        Me.Bu_SpindleOn.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Bu_SpindleOn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Bu_SpindleOn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Bu_SpindleOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_SpindleOn.Location = New System.Drawing.Point(108, 72)
        Me.Bu_SpindleOn.Margin = New System.Windows.Forms.Padding(0)
        Me.Bu_SpindleOn.Name = "Bu_SpindleOn"
        Me.Bu_SpindleOn.Size = New System.Drawing.Size(77, 51)
        Me.Bu_SpindleOn.TabIndex = 55
        Me.Bu_SpindleOn.Text = "M03"
        Me.Bu_SpindleOn.UseVisualStyleBackColor = False
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.Color.Lavender
        Me.Button16.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button16.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button16.Location = New System.Drawing.Point(4, 227)
        Me.Button16.Margin = New System.Windows.Forms.Padding(0)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(77, 51)
        Me.Button16.TabIndex = 54
        Me.Button16.Text = "Teach"
        Me.Button16.UseVisualStyleBackColor = False
        '
        'Button_Minus
        '
        Me.Button_Minus.BackColor = System.Drawing.Color.Lavender
        Me.Button_Minus.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button_Minus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button_Minus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Minus.Location = New System.Drawing.Point(82, 124)
        Me.Button_Minus.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Minus.Name = "Button_Minus"
        Me.Button_Minus.Size = New System.Drawing.Size(25, 25)
        Me.Button_Minus.TabIndex = 53
        Me.Button_Minus.Text = "-"
        Me.Button_Minus.UseVisualStyleBackColor = False
        '
        'Button_Enter
        '
        Me.Button_Enter.BackColor = System.Drawing.Color.Lavender
        Me.Button_Enter.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button_Enter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button_Enter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Enter.Location = New System.Drawing.Point(108, 227)
        Me.Button_Enter.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Enter.Name = "Button_Enter"
        Me.Button_Enter.Size = New System.Drawing.Size(77, 51)
        Me.Button_Enter.TabIndex = 52
        Me.Button_Enter.Text = "Enter"
        Me.Button_Enter.UseVisualStyleBackColor = False
        '
        'Button_Plus
        '
        Me.Button_Plus.BackColor = System.Drawing.Color.Lavender
        Me.Button_Plus.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button_Plus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button_Plus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Plus.Location = New System.Drawing.Point(82, 98)
        Me.Button_Plus.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Plus.Name = "Button_Plus"
        Me.Button_Plus.Size = New System.Drawing.Size(25, 25)
        Me.Button_Plus.TabIndex = 51
        Me.Button_Plus.Text = "+"
        Me.Button_Plus.UseVisualStyleBackColor = False
        '
        'Button_Komma
        '
        Me.Button_Komma.BackColor = System.Drawing.Color.Lavender
        Me.Button_Komma.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button_Komma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button_Komma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_Komma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Komma.Location = New System.Drawing.Point(30, 176)
        Me.Button_Komma.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_Komma.Name = "Button_Komma"
        Me.Button_Komma.Size = New System.Drawing.Size(25, 25)
        Me.Button_Komma.TabIndex = 50
        Me.Button_Komma.Text = ","
        Me.Button_Komma.UseVisualStyleBackColor = False
        '
        'Button45
        '
        Me.Button45.BackColor = System.Drawing.Color.Lavender
        Me.Button45.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button45.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button45.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button45.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button45.Location = New System.Drawing.Point(56, 176)
        Me.Button45.Margin = New System.Windows.Forms.Padding(0)
        Me.Button45.Name = "Button45"
        Me.Button45.Size = New System.Drawing.Size(25, 25)
        Me.Button45.TabIndex = 49
        Me.Button45.Text = "Button45"
        Me.Button45.UseVisualStyleBackColor = False
        '
        'Button_0
        '
        Me.Button_0.BackColor = System.Drawing.Color.Lavender
        Me.Button_0.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button_0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button_0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_0.Location = New System.Drawing.Point(4, 176)
        Me.Button_0.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_0.Name = "Button_0"
        Me.Button_0.Size = New System.Drawing.Size(25, 25)
        Me.Button_0.TabIndex = 48
        Me.Button_0.Text = "0"
        Me.Button_0.UseVisualStyleBackColor = False
        '
        'Button_3
        '
        Me.Button_3.BackColor = System.Drawing.Color.Lavender
        Me.Button_3.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button_3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button_3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_3.Location = New System.Drawing.Point(56, 150)
        Me.Button_3.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_3.Name = "Button_3"
        Me.Button_3.Size = New System.Drawing.Size(25, 25)
        Me.Button_3.TabIndex = 47
        Me.Button_3.Text = "3"
        Me.Button_3.UseVisualStyleBackColor = False
        '
        'Button_1
        '
        Me.Button_1.BackColor = System.Drawing.Color.Lavender
        Me.Button_1.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button_1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button_1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_1.Location = New System.Drawing.Point(4, 150)
        Me.Button_1.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_1.Name = "Button_1"
        Me.Button_1.Size = New System.Drawing.Size(25, 25)
        Me.Button_1.TabIndex = 46
        Me.Button_1.Text = "1"
        Me.Button_1.UseVisualStyleBackColor = False
        '
        'Button_2
        '
        Me.Button_2.BackColor = System.Drawing.Color.Lavender
        Me.Button_2.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button_2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button_2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_2.Location = New System.Drawing.Point(30, 150)
        Me.Button_2.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_2.Name = "Button_2"
        Me.Button_2.Size = New System.Drawing.Size(25, 25)
        Me.Button_2.TabIndex = 45
        Me.Button_2.Text = "2"
        Me.Button_2.UseVisualStyleBackColor = False
        '
        'Button_6
        '
        Me.Button_6.BackColor = System.Drawing.Color.Lavender
        Me.Button_6.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button_6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button_6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_6.Location = New System.Drawing.Point(56, 124)
        Me.Button_6.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_6.Name = "Button_6"
        Me.Button_6.Size = New System.Drawing.Size(25, 25)
        Me.Button_6.TabIndex = 44
        Me.Button_6.Text = "6"
        Me.Button_6.UseVisualStyleBackColor = False
        '
        'Button_5
        '
        Me.Button_5.BackColor = System.Drawing.Color.Lavender
        Me.Button_5.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button_5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button_5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_5.Location = New System.Drawing.Point(30, 124)
        Me.Button_5.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_5.Name = "Button_5"
        Me.Button_5.Size = New System.Drawing.Size(25, 25)
        Me.Button_5.TabIndex = 43
        Me.Button_5.Text = "5"
        Me.Button_5.UseVisualStyleBackColor = False
        '
        'Button_4
        '
        Me.Button_4.BackColor = System.Drawing.Color.Lavender
        Me.Button_4.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button_4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button_4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_4.Location = New System.Drawing.Point(4, 124)
        Me.Button_4.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_4.Name = "Button_4"
        Me.Button_4.Size = New System.Drawing.Size(25, 25)
        Me.Button_4.TabIndex = 42
        Me.Button_4.Text = "4"
        Me.Button_4.UseVisualStyleBackColor = False
        '
        'Button_9
        '
        Me.Button_9.BackColor = System.Drawing.Color.Lavender
        Me.Button_9.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button_9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button_9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_9.Location = New System.Drawing.Point(56, 98)
        Me.Button_9.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_9.Name = "Button_9"
        Me.Button_9.Size = New System.Drawing.Size(25, 25)
        Me.Button_9.TabIndex = 41
        Me.Button_9.Text = "9"
        Me.Button_9.UseVisualStyleBackColor = False
        '
        'Button_8
        '
        Me.Button_8.BackColor = System.Drawing.Color.Lavender
        Me.Button_8.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button_8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button_8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_8.Location = New System.Drawing.Point(30, 98)
        Me.Button_8.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_8.Name = "Button_8"
        Me.Button_8.Size = New System.Drawing.Size(25, 25)
        Me.Button_8.TabIndex = 40
        Me.Button_8.Text = "8"
        Me.Button_8.UseVisualStyleBackColor = False
        '
        'Button_7
        '
        Me.Button_7.BackColor = System.Drawing.Color.Lavender
        Me.Button_7.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button_7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button_7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_7.Location = New System.Drawing.Point(4, 98)
        Me.Button_7.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_7.Name = "Button_7"
        Me.Button_7.Size = New System.Drawing.Size(25, 25)
        Me.Button_7.TabIndex = 39
        Me.Button_7.Text = "7"
        Me.Button_7.UseVisualStyleBackColor = False
        '
        'Button_D
        '
        Me.Button_D.BackColor = System.Drawing.Color.Lavender
        Me.Button_D.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button_D.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button_D.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button_D.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_D.Location = New System.Drawing.Point(4, 19)
        Me.Button_D.Margin = New System.Windows.Forms.Padding(0)
        Me.Button_D.Name = "Button_D"
        Me.Button_D.Size = New System.Drawing.Size(25, 25)
        Me.Button_D.TabIndex = 38
        Me.Button_D.Text = "D"
        Me.Button_D.UseVisualStyleBackColor = False
        '
        'Button29
        '
        Me.Button29.BackColor = System.Drawing.Color.Lavender
        Me.Button29.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button29.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button29.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button29.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button29.Location = New System.Drawing.Point(82, 72)
        Me.Button29.Margin = New System.Windows.Forms.Padding(0)
        Me.Button29.Name = "Button29"
        Me.Button29.Size = New System.Drawing.Size(25, 25)
        Me.Button29.TabIndex = 37
        Me.Button29.Text = "Z"
        Me.Button29.UseVisualStyleBackColor = False
        '
        'Button28
        '
        Me.Button28.BackColor = System.Drawing.Color.Lavender
        Me.Button28.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button28.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button28.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button28.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button28.Location = New System.Drawing.Point(56, 72)
        Me.Button28.Margin = New System.Windows.Forms.Padding(0)
        Me.Button28.Name = "Button28"
        Me.Button28.Size = New System.Drawing.Size(25, 25)
        Me.Button28.TabIndex = 36
        Me.Button28.Text = "Y"
        Me.Button28.UseVisualStyleBackColor = False
        '
        'Button27
        '
        Me.Button27.BackColor = System.Drawing.Color.Lavender
        Me.Button27.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button27.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button27.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button27.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button27.Location = New System.Drawing.Point(30, 72)
        Me.Button27.Margin = New System.Windows.Forms.Padding(0)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(25, 25)
        Me.Button27.TabIndex = 35
        Me.Button27.Text = "X"
        Me.Button27.UseVisualStyleBackColor = False
        '
        'Button26
        '
        Me.Button26.BackColor = System.Drawing.Color.Lavender
        Me.Button26.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button26.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button26.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button26.Location = New System.Drawing.Point(4, 72)
        Me.Button26.Margin = New System.Windows.Forms.Padding(0)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(25, 25)
        Me.Button26.TabIndex = 34
        Me.Button26.Text = "T"
        Me.Button26.UseVisualStyleBackColor = False
        '
        'Button25
        '
        Me.Button25.BackColor = System.Drawing.Color.Lavender
        Me.Button25.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button25.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button25.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button25.Location = New System.Drawing.Point(134, 45)
        Me.Button25.Margin = New System.Windows.Forms.Padding(0)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(25, 25)
        Me.Button25.TabIndex = 33
        Me.Button25.Text = "R"
        Me.Button25.UseVisualStyleBackColor = False
        '
        'Button24
        '
        Me.Button24.BackColor = System.Drawing.Color.Lavender
        Me.Button24.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button24.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button24.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button24.Location = New System.Drawing.Point(108, 45)
        Me.Button24.Margin = New System.Windows.Forms.Padding(0)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(25, 25)
        Me.Button24.TabIndex = 32
        Me.Button24.Text = "Q"
        Me.Button24.UseVisualStyleBackColor = False
        '
        'Button23
        '
        Me.Button23.BackColor = System.Drawing.Color.Lavender
        Me.Button23.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button23.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button23.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button23.Location = New System.Drawing.Point(82, 45)
        Me.Button23.Margin = New System.Windows.Forms.Padding(0)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(25, 25)
        Me.Button23.TabIndex = 31
        Me.Button23.Text = "P"
        Me.Button23.UseVisualStyleBackColor = False
        '
        'Button22
        '
        Me.Button22.BackColor = System.Drawing.Color.Lavender
        Me.Button22.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button22.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button22.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button22.Location = New System.Drawing.Point(56, 45)
        Me.Button22.Margin = New System.Windows.Forms.Padding(0)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(25, 25)
        Me.Button22.TabIndex = 30
        Me.Button22.Text = "N"
        Me.Button22.UseVisualStyleBackColor = False
        '
        'Button21
        '
        Me.Button21.BackColor = System.Drawing.Color.Lavender
        Me.Button21.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button21.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button21.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button21.Location = New System.Drawing.Point(4, 45)
        Me.Button21.Margin = New System.Windows.Forms.Padding(0)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(25, 25)
        Me.Button21.TabIndex = 29
        Me.Button21.Text = "L"
        Me.Button21.UseVisualStyleBackColor = False
        '
        'Button20
        '
        Me.Button20.BackColor = System.Drawing.Color.Lavender
        Me.Button20.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button20.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button20.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button20.Location = New System.Drawing.Point(160, 19)
        Me.Button20.Margin = New System.Windows.Forms.Padding(0)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(25, 25)
        Me.Button20.TabIndex = 28
        Me.Button20.Text = "K"
        Me.Button20.UseVisualStyleBackColor = False
        '
        'Button19
        '
        Me.Button19.BackColor = System.Drawing.Color.Lavender
        Me.Button19.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button19.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button19.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button19.Location = New System.Drawing.Point(134, 19)
        Me.Button19.Margin = New System.Windows.Forms.Padding(0)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(25, 25)
        Me.Button19.TabIndex = 27
        Me.Button19.Text = "J"
        Me.Button19.UseVisualStyleBackColor = False
        '
        'Button18
        '
        Me.Button18.BackColor = System.Drawing.Color.Lavender
        Me.Button18.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button18.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button18.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button18.Location = New System.Drawing.Point(108, 19)
        Me.Button18.Margin = New System.Windows.Forms.Padding(0)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(25, 25)
        Me.Button18.TabIndex = 26
        Me.Button18.Text = "I"
        Me.Button18.UseVisualStyleBackColor = False
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.Color.Lavender
        Me.Button17.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button17.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button17.Location = New System.Drawing.Point(82, 19)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(25, 25)
        Me.Button17.TabIndex = 25
        Me.Button17.Text = "H"
        Me.Button17.UseVisualStyleBackColor = False
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.Lavender
        Me.Button15.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button15.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button15.Location = New System.Drawing.Point(160, 45)
        Me.Button15.Margin = New System.Windows.Forms.Padding(0)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(25, 25)
        Me.Button15.TabIndex = 24
        Me.Button15.Text = "S"
        Me.Button15.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.Lavender
        Me.Button14.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.Button14.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise
        Me.Button14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button14.Location = New System.Drawing.Point(30, 45)
        Me.Button14.Margin = New System.Windows.Forms.Padding(0)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(25, 25)
        Me.Button14.TabIndex = 23
        Me.Button14.Text = "M"
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.Lavender
        Me.Button13.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button13.Location = New System.Drawing.Point(30, 19)
        Me.Button13.Margin = New System.Windows.Forms.Padding(1)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(25, 25)
        Me.Button13.TabIndex = 22
        Me.Button13.Text = "F"
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.Lavender
        Me.Button12.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Location = New System.Drawing.Point(56, 19)
        Me.Button12.Margin = New System.Windows.Forms.Padding(0)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(25, 25)
        Me.Button12.TabIndex = 21
        Me.Button12.Text = "G"
        Me.Button12.UseVisualStyleBackColor = False
        '
        'GroupBox_Move
        '
        Me.GroupBox_Move.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox_Move.Controls.Add(Me.Label2)
        Me.GroupBox_Move.Controls.Add(Me.Label8)
        Me.GroupBox_Move.Controls.Add(Me.TraBa_FeedRate)
        Me.GroupBox_Move.Controls.Add(Me.Label7)
        Me.GroupBox_Move.Controls.Add(Me.NuUpDo_StepSize)
        Me.GroupBox_Move.Controls.Add(Me.Bu_StepPlusZ)
        Me.GroupBox_Move.Controls.Add(Me.Bu_StepPlusY)
        Me.GroupBox_Move.Controls.Add(Me.Bu_StepPlusX)
        Me.GroupBox_Move.Controls.Add(Me.Bu_StepMinusZ)
        Me.GroupBox_Move.Controls.Add(Me.Bu_StepMinusY)
        Me.GroupBox_Move.Controls.Add(Me.Bu_StepMinusX)
        Me.GroupBox_Move.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox_Move.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox_Move.Location = New System.Drawing.Point(385, 222)
        Me.GroupBox_Move.Name = "GroupBox_Move"
        Me.GroupBox_Move.Size = New System.Drawing.Size(170, 283)
        Me.GroupBox_Move.TabIndex = 21
        Me.GroupBox_Move.TabStop = False
        Me.GroupBox_Move.Text = "Move"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(131, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "1000"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(118, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "F"
        '
        'TraBa_FeedRate
        '
        Me.TraBa_FeedRate.LargeChange = 100
        Me.TraBa_FeedRate.Location = New System.Drawing.Point(121, 28)
        Me.TraBa_FeedRate.Maximum = 10000
        Me.TraBa_FeedRate.Minimum = 1
        Me.TraBa_FeedRate.Name = "TraBa_FeedRate"
        Me.TraBa_FeedRate.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TraBa_FeedRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TraBa_FeedRate.RightToLeftLayout = True
        Me.TraBa_FeedRate.Size = New System.Drawing.Size(45, 245)
        Me.TraBa_FeedRate.SmallChange = 10
        Me.TraBa_FeedRate.TabIndex = 21
        Me.TraBa_FeedRate.Value = 1000
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Step size"
        '
        'NuUpDo_StepSize
        '
        Me.NuUpDo_StepSize.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_StepSize.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NuUpDo_StepSize.DecimalPlaces = 1
        Me.NuUpDo_StepSize.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_StepSize.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NuUpDo_StepSize.Location = New System.Drawing.Point(9, 46)
        Me.NuUpDo_StepSize.Name = "NuUpDo_StepSize"
        Me.NuUpDo_StepSize.Size = New System.Drawing.Size(106, 16)
        Me.NuUpDo_StepSize.TabIndex = 19
        Me.NuUpDo_StepSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Bu_StepPlusZ
        '
        Me.Bu_StepPlusZ.BackColor = System.Drawing.Color.Lavender
        Me.Bu_StepPlusZ.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Bu_StepPlusZ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Bu_StepPlusZ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Bu_StepPlusZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_StepPlusZ.Location = New System.Drawing.Point(60, 218)
        Me.Bu_StepPlusZ.Name = "Bu_StepPlusZ"
        Me.Bu_StepPlusZ.Size = New System.Drawing.Size(55, 55)
        Me.Bu_StepPlusZ.TabIndex = 17
        Me.Bu_StepPlusZ.Text = "Z+"
        Me.Bu_StepPlusZ.UseVisualStyleBackColor = False
        '
        'Bu_StepPlusY
        '
        Me.Bu_StepPlusY.BackColor = System.Drawing.Color.Lavender
        Me.Bu_StepPlusY.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Bu_StepPlusY.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Bu_StepPlusY.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Bu_StepPlusY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_StepPlusY.Location = New System.Drawing.Point(60, 162)
        Me.Bu_StepPlusY.Name = "Bu_StepPlusY"
        Me.Bu_StepPlusY.Size = New System.Drawing.Size(55, 55)
        Me.Bu_StepPlusY.TabIndex = 16
        Me.Bu_StepPlusY.Text = "Y+"
        Me.Bu_StepPlusY.UseVisualStyleBackColor = False
        '
        'Bu_StepPlusX
        '
        Me.Bu_StepPlusX.BackColor = System.Drawing.Color.Lavender
        Me.Bu_StepPlusX.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Bu_StepPlusX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Bu_StepPlusX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Bu_StepPlusX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_StepPlusX.Location = New System.Drawing.Point(60, 111)
        Me.Bu_StepPlusX.Name = "Bu_StepPlusX"
        Me.Bu_StepPlusX.Size = New System.Drawing.Size(55, 55)
        Me.Bu_StepPlusX.TabIndex = 15
        Me.Bu_StepPlusX.Text = "X+"
        Me.Bu_StepPlusX.UseVisualStyleBackColor = False
        '
        'Bu_StepMinusZ
        '
        Me.Bu_StepMinusZ.BackColor = System.Drawing.Color.Lavender
        Me.Bu_StepMinusZ.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Bu_StepMinusZ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Bu_StepMinusZ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Bu_StepMinusZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_StepMinusZ.Location = New System.Drawing.Point(6, 218)
        Me.Bu_StepMinusZ.Name = "Bu_StepMinusZ"
        Me.Bu_StepMinusZ.Size = New System.Drawing.Size(55, 55)
        Me.Bu_StepMinusZ.TabIndex = 14
        Me.Bu_StepMinusZ.Text = "Z-"
        Me.Bu_StepMinusZ.UseVisualStyleBackColor = False
        '
        'Bu_StepMinusY
        '
        Me.Bu_StepMinusY.BackColor = System.Drawing.Color.Lavender
        Me.Bu_StepMinusY.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Bu_StepMinusY.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Bu_StepMinusY.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Bu_StepMinusY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_StepMinusY.Location = New System.Drawing.Point(6, 161)
        Me.Bu_StepMinusY.Name = "Bu_StepMinusY"
        Me.Bu_StepMinusY.Size = New System.Drawing.Size(55, 55)
        Me.Bu_StepMinusY.TabIndex = 13
        Me.Bu_StepMinusY.Text = "Y-"
        Me.Bu_StepMinusY.UseVisualStyleBackColor = False
        '
        'Bu_StepMinusX
        '
        Me.Bu_StepMinusX.BackColor = System.Drawing.Color.Lavender
        Me.Bu_StepMinusX.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Bu_StepMinusX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Bu_StepMinusX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Bu_StepMinusX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_StepMinusX.Location = New System.Drawing.Point(6, 111)
        Me.Bu_StepMinusX.Name = "Bu_StepMinusX"
        Me.Bu_StepMinusX.Size = New System.Drawing.Size(55, 55)
        Me.Bu_StepMinusX.TabIndex = 12
        Me.Bu_StepMinusX.Text = "X-"
        Me.Bu_StepMinusX.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.SteelBlue
        Me.TextBox1.Location = New System.Drawing.Point(9, 13)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(544, 203)
        Me.TextBox1.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Lavender
        Me.TabPage2.Controls.Add(Me.GrouBo_AxesStepRatio)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(561, 513)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings"
        '
        'GrouBo_AxesStepRatio
        '
        Me.GrouBo_AxesStepRatio.Controls.Add(Me.Bu_TakeOverAxesStepRatio)
        Me.GrouBo_AxesStepRatio.Controls.Add(Me.NuUpDo_Axis5MMProStep)
        Me.GrouBo_AxesStepRatio.Controls.Add(Me.NuUpDo_Axis4MMProStep)
        Me.GrouBo_AxesStepRatio.Controls.Add(Me.NuUpDo_ZAxisMMProStep)
        Me.GrouBo_AxesStepRatio.Controls.Add(Me.NuUpDo_YAxisMMProStep)
        Me.GrouBo_AxesStepRatio.Controls.Add(Me.NuUpDo_XAxisMMProStep)
        Me.GrouBo_AxesStepRatio.Controls.Add(Me.Label10)
        Me.GrouBo_AxesStepRatio.Controls.Add(Me.Label9)
        Me.GrouBo_AxesStepRatio.Controls.Add(Me.Label6)
        Me.GrouBo_AxesStepRatio.Controls.Add(Me.Label5)
        Me.GrouBo_AxesStepRatio.Controls.Add(Me.Label3)
        Me.GrouBo_AxesStepRatio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrouBo_AxesStepRatio.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GrouBo_AxesStepRatio.Location = New System.Drawing.Point(199, 6)
        Me.GrouBo_AxesStepRatio.Name = "GrouBo_AxesStepRatio"
        Me.GrouBo_AxesStepRatio.Size = New System.Drawing.Size(208, 179)
        Me.GrouBo_AxesStepRatio.TabIndex = 4
        Me.GrouBo_AxesStepRatio.TabStop = False
        Me.GrouBo_AxesStepRatio.Text = "Achsen Stepverhältnis in mm / Step "
        '
        'Bu_TakeOverAxesStepRatio
        '
        Me.Bu_TakeOverAxesStepRatio.BackColor = System.Drawing.Color.Lavender
        Me.Bu_TakeOverAxesStepRatio.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Bu_TakeOverAxesStepRatio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Bu_TakeOverAxesStepRatio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Bu_TakeOverAxesStepRatio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_TakeOverAxesStepRatio.Location = New System.Drawing.Point(63, 149)
        Me.Bu_TakeOverAxesStepRatio.Name = "Bu_TakeOverAxesStepRatio"
        Me.Bu_TakeOverAxesStepRatio.Size = New System.Drawing.Size(87, 23)
        Me.Bu_TakeOverAxesStepRatio.TabIndex = 11
        Me.Bu_TakeOverAxesStepRatio.Text = "übernehmen"
        Me.Bu_TakeOverAxesStepRatio.UseVisualStyleBackColor = False
        '
        'NuUpDo_Axis5MMProStep
        '
        Me.NuUpDo_Axis5MMProStep.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_Axis5MMProStep.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NuUpDo_Axis5MMProStep.DecimalPlaces = 4
        Me.NuUpDo_Axis5MMProStep.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_Axis5MMProStep.Increment = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.NuUpDo_Axis5MMProStep.Location = New System.Drawing.Point(138, 123)
        Me.NuUpDo_Axis5MMProStep.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NuUpDo_Axis5MMProStep.Minimum = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.NuUpDo_Axis5MMProStep.Name = "NuUpDo_Axis5MMProStep"
        Me.NuUpDo_Axis5MMProStep.Size = New System.Drawing.Size(64, 16)
        Me.NuUpDo_Axis5MMProStep.TabIndex = 10
        Me.NuUpDo_Axis5MMProStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_Axis5MMProStep.Value = New Decimal(New Integer() {10, 0, 0, 262144})
        '
        'NuUpDo_Axis4MMProStep
        '
        Me.NuUpDo_Axis4MMProStep.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_Axis4MMProStep.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NuUpDo_Axis4MMProStep.DecimalPlaces = 4
        Me.NuUpDo_Axis4MMProStep.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_Axis4MMProStep.Increment = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.NuUpDo_Axis4MMProStep.Location = New System.Drawing.Point(138, 97)
        Me.NuUpDo_Axis4MMProStep.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NuUpDo_Axis4MMProStep.Minimum = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.NuUpDo_Axis4MMProStep.Name = "NuUpDo_Axis4MMProStep"
        Me.NuUpDo_Axis4MMProStep.Size = New System.Drawing.Size(64, 16)
        Me.NuUpDo_Axis4MMProStep.TabIndex = 9
        Me.NuUpDo_Axis4MMProStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_Axis4MMProStep.Value = New Decimal(New Integer() {10, 0, 0, 262144})
        '
        'NuUpDo_ZAxisMMProStep
        '
        Me.NuUpDo_ZAxisMMProStep.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ZAxisMMProStep.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NuUpDo_ZAxisMMProStep.DecimalPlaces = 4
        Me.NuUpDo_ZAxisMMProStep.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ZAxisMMProStep.Increment = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.NuUpDo_ZAxisMMProStep.Location = New System.Drawing.Point(138, 71)
        Me.NuUpDo_ZAxisMMProStep.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NuUpDo_ZAxisMMProStep.Minimum = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.NuUpDo_ZAxisMMProStep.Name = "NuUpDo_ZAxisMMProStep"
        Me.NuUpDo_ZAxisMMProStep.Size = New System.Drawing.Size(64, 16)
        Me.NuUpDo_ZAxisMMProStep.TabIndex = 8
        Me.NuUpDo_ZAxisMMProStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_ZAxisMMProStep.Value = New Decimal(New Integer() {10, 0, 0, 262144})
        '
        'NuUpDo_YAxisMMProStep
        '
        Me.NuUpDo_YAxisMMProStep.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_YAxisMMProStep.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NuUpDo_YAxisMMProStep.DecimalPlaces = 4
        Me.NuUpDo_YAxisMMProStep.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_YAxisMMProStep.Increment = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.NuUpDo_YAxisMMProStep.Location = New System.Drawing.Point(138, 45)
        Me.NuUpDo_YAxisMMProStep.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NuUpDo_YAxisMMProStep.Minimum = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.NuUpDo_YAxisMMProStep.Name = "NuUpDo_YAxisMMProStep"
        Me.NuUpDo_YAxisMMProStep.Size = New System.Drawing.Size(64, 16)
        Me.NuUpDo_YAxisMMProStep.TabIndex = 7
        Me.NuUpDo_YAxisMMProStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_YAxisMMProStep.Value = New Decimal(New Integer() {10, 0, 0, 262144})
        '
        'NuUpDo_XAxisMMProStep
        '
        Me.NuUpDo_XAxisMMProStep.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_XAxisMMProStep.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NuUpDo_XAxisMMProStep.DecimalPlaces = 4
        Me.NuUpDo_XAxisMMProStep.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_XAxisMMProStep.Increment = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.NuUpDo_XAxisMMProStep.Location = New System.Drawing.Point(138, 19)
        Me.NuUpDo_XAxisMMProStep.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NuUpDo_XAxisMMProStep.Minimum = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.NuUpDo_XAxisMMProStep.Name = "NuUpDo_XAxisMMProStep"
        Me.NuUpDo_XAxisMMProStep.Size = New System.Drawing.Size(64, 16)
        Me.NuUpDo_XAxisMMProStep.TabIndex = 6
        Me.NuUpDo_XAxisMMProStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_XAxisMMProStep.Value = New Decimal(New Integer() {10, 0, 0, 262144})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 125)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Achse 5"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Achse 4"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Achse 3 (Z)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Achse 2 (Y)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Achse 1 (X)"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Bu_LoadValuesFromMachine)
        Me.GroupBox4.Controls.Add(Me.Button5)
        Me.GroupBox4.Controls.Add(Me.Button4)
        Me.GroupBox4.Controls.Add(Me.Button3)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox4.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(190, 179)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Referenzieren"
        '
        'Bu_LoadValuesFromMachine
        '
        Me.Bu_LoadValuesFromMachine.BackColor = System.Drawing.Color.Lavender
        Me.Bu_LoadValuesFromMachine.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Bu_LoadValuesFromMachine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Bu_LoadValuesFromMachine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Bu_LoadValuesFromMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_LoadValuesFromMachine.Location = New System.Drawing.Point(6, 149)
        Me.Bu_LoadValuesFromMachine.Name = "Bu_LoadValuesFromMachine"
        Me.Bu_LoadValuesFromMachine.Size = New System.Drawing.Size(178, 23)
        Me.Bu_LoadValuesFromMachine.TabIndex = 6
        Me.Bu_LoadValuesFromMachine.Text = "Gespeicherte, letzte Werte laden"
        Me.Bu_LoadValuesFromMachine.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Lavender
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(6, 77)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(178, 23)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Home Z"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Lavender
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(6, 48)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(178, 23)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Home Y"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Lavender
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(6, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(178, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Home X"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'TaPa_MachineConnection
        '
        Me.TaPa_MachineConnection.BackColor = System.Drawing.Color.Lavender
        Me.TaPa_MachineConnection.Controls.Add(Me.FlowControl)
        Me.TaPa_MachineConnection.Controls.Add(Me.La_StpBits)
        Me.TaPa_MachineConnection.Controls.Add(Me.La_DataBits)
        Me.TaPa_MachineConnection.Controls.Add(Me.La_Parity)
        Me.TaPa_MachineConnection.Controls.Add(Me.La_BaudRate)
        Me.TaPa_MachineConnection.Controls.Add(Me.La_COMPorts)
        Me.TaPa_MachineConnection.Controls.Add(Me.CoBo_FlowControl)
        Me.TaPa_MachineConnection.Controls.Add(Me.CoBo_StopBits)
        Me.TaPa_MachineConnection.Controls.Add(Me.CoBo_DataBits)
        Me.TaPa_MachineConnection.Controls.Add(Me.CoBo_Parity)
        Me.TaPa_MachineConnection.Controls.Add(Me.CoBo_BaudRate)
        Me.TaPa_MachineConnection.Controls.Add(Me.CoBo_COMPort)
        Me.TaPa_MachineConnection.Controls.Add(Me.Bu_Disconnect)
        Me.TaPa_MachineConnection.Controls.Add(Me.Bu_Connect)
        Me.TaPa_MachineConnection.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.TaPa_MachineConnection.Location = New System.Drawing.Point(4, 22)
        Me.TaPa_MachineConnection.Name = "TaPa_MachineConnection"
        Me.TaPa_MachineConnection.Size = New System.Drawing.Size(561, 513)
        Me.TaPa_MachineConnection.TabIndex = 2
        Me.TaPa_MachineConnection.Text = "Verbindung zur Maschine"
        '
        'FlowControl
        '
        Me.FlowControl.AutoSize = True
        Me.FlowControl.Location = New System.Drawing.Point(8, 214)
        Me.FlowControl.Name = "FlowControl"
        Me.FlowControl.Size = New System.Drawing.Size(74, 13)
        Me.FlowControl.TabIndex = 13
        Me.FlowControl.Text = "Flußsteuerung"
        '
        'La_StpBits
        '
        Me.La_StpBits.AutoSize = True
        Me.La_StpBits.Location = New System.Drawing.Point(8, 174)
        Me.La_StpBits.Name = "La_StpBits"
        Me.La_StpBits.Size = New System.Drawing.Size(45, 13)
        Me.La_StpBits.TabIndex = 12
        Me.La_StpBits.Text = "Stopbits"
        '
        'La_DataBits
        '
        Me.La_DataBits.AutoSize = True
        Me.La_DataBits.Location = New System.Drawing.Point(8, 134)
        Me.La_DataBits.Name = "La_DataBits"
        Me.La_DataBits.Size = New System.Drawing.Size(52, 13)
        Me.La_DataBits.TabIndex = 11
        Me.La_DataBits.Text = "Datenbits"
        '
        'La_Parity
        '
        Me.La_Parity.AutoSize = True
        Me.La_Parity.Location = New System.Drawing.Point(8, 94)
        Me.La_Parity.Name = "La_Parity"
        Me.La_Parity.Size = New System.Drawing.Size(33, 13)
        Me.La_Parity.TabIndex = 10
        Me.La_Parity.Text = "Parity"
        '
        'La_BaudRate
        '
        Me.La_BaudRate.AutoSize = True
        Me.La_BaudRate.Location = New System.Drawing.Point(8, 54)
        Me.La_BaudRate.Name = "La_BaudRate"
        Me.La_BaudRate.Size = New System.Drawing.Size(50, 13)
        Me.La_BaudRate.TabIndex = 9
        Me.La_BaudRate.Text = "Baudrate"
        '
        'La_COMPorts
        '
        Me.La_COMPorts.AutoSize = True
        Me.La_COMPorts.Location = New System.Drawing.Point(8, 14)
        Me.La_COMPorts.Name = "La_COMPorts"
        Me.La_COMPorts.Size = New System.Drawing.Size(152, 13)
        Me.La_COMPorts.TabIndex = 8
        Me.La_COMPorts.Text = "Verfügbare COM-Schnittstellen"
        '
        'CoBo_FlowControl
        '
        Me.CoBo_FlowControl.BackColor = System.Drawing.Color.GhostWhite
        Me.CoBo_FlowControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CoBo_FlowControl.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CoBo_FlowControl.FormattingEnabled = True
        Me.CoBo_FlowControl.Location = New System.Drawing.Point(8, 230)
        Me.CoBo_FlowControl.Name = "CoBo_FlowControl"
        Me.CoBo_FlowControl.Size = New System.Drawing.Size(152, 21)
        Me.CoBo_FlowControl.TabIndex = 7
        '
        'CoBo_StopBits
        '
        Me.CoBo_StopBits.BackColor = System.Drawing.Color.GhostWhite
        Me.CoBo_StopBits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CoBo_StopBits.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CoBo_StopBits.FormattingEnabled = True
        Me.CoBo_StopBits.Location = New System.Drawing.Point(8, 190)
        Me.CoBo_StopBits.Name = "CoBo_StopBits"
        Me.CoBo_StopBits.Size = New System.Drawing.Size(152, 21)
        Me.CoBo_StopBits.TabIndex = 6
        '
        'CoBo_DataBits
        '
        Me.CoBo_DataBits.BackColor = System.Drawing.Color.GhostWhite
        Me.CoBo_DataBits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CoBo_DataBits.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CoBo_DataBits.FormattingEnabled = True
        Me.CoBo_DataBits.Location = New System.Drawing.Point(8, 150)
        Me.CoBo_DataBits.Name = "CoBo_DataBits"
        Me.CoBo_DataBits.Size = New System.Drawing.Size(152, 21)
        Me.CoBo_DataBits.TabIndex = 5
        '
        'CoBo_Parity
        '
        Me.CoBo_Parity.BackColor = System.Drawing.Color.GhostWhite
        Me.CoBo_Parity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CoBo_Parity.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CoBo_Parity.FormattingEnabled = True
        Me.CoBo_Parity.Location = New System.Drawing.Point(8, 110)
        Me.CoBo_Parity.Name = "CoBo_Parity"
        Me.CoBo_Parity.Size = New System.Drawing.Size(152, 21)
        Me.CoBo_Parity.TabIndex = 4
        '
        'CoBo_BaudRate
        '
        Me.CoBo_BaudRate.BackColor = System.Drawing.Color.GhostWhite
        Me.CoBo_BaudRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CoBo_BaudRate.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CoBo_BaudRate.FormattingEnabled = True
        Me.CoBo_BaudRate.Location = New System.Drawing.Point(8, 70)
        Me.CoBo_BaudRate.Name = "CoBo_BaudRate"
        Me.CoBo_BaudRate.Size = New System.Drawing.Size(152, 21)
        Me.CoBo_BaudRate.TabIndex = 3
        '
        'CoBo_COMPort
        '
        Me.CoBo_COMPort.BackColor = System.Drawing.Color.GhostWhite
        Me.CoBo_COMPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CoBo_COMPort.FormattingEnabled = True
        Me.CoBo_COMPort.Location = New System.Drawing.Point(8, 30)
        Me.CoBo_COMPort.Name = "CoBo_COMPort"
        Me.CoBo_COMPort.Size = New System.Drawing.Size(152, 21)
        Me.CoBo_COMPort.TabIndex = 2
        '
        'Bu_Disconnect
        '
        Me.Bu_Disconnect.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Bu_Disconnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Bu_Disconnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Bu_Disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_Disconnect.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Bu_Disconnect.Location = New System.Drawing.Point(353, 482)
        Me.Bu_Disconnect.Name = "Bu_Disconnect"
        Me.Bu_Disconnect.Size = New System.Drawing.Size(119, 23)
        Me.Bu_Disconnect.TabIndex = 1
        Me.Bu_Disconnect.Text = "Verbindung trennen"
        Me.Bu_Disconnect.UseVisualStyleBackColor = True
        '
        'Bu_Connect
        '
        Me.Bu_Connect.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite
        Me.Bu_Connect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PowderBlue
        Me.Bu_Connect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite
        Me.Bu_Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_Connect.Location = New System.Drawing.Point(478, 482)
        Me.Bu_Connect.Name = "Bu_Connect"
        Me.Bu_Connect.Size = New System.Drawing.Size(75, 23)
        Me.Bu_Connect.TabIndex = 0
        Me.Bu_Connect.Text = "Verbinden"
        Me.Bu_Connect.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Lavender
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.MachineInfoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(569, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "Datei"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OpenToolStripMenuItem.Text = "Open program"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveToolStripMenuItem.Text = "Save program"
        '
        'MachineInfoToolStripMenuItem
        '
        Me.MachineInfoToolStripMenuItem.Name = "MachineInfoToolStripMenuItem"
        Me.MachineInfoToolStripMenuItem.Size = New System.Drawing.Size(98, 20)
        Me.MachineInfoToolStripMenuItem.Text = "Maschineninfo"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MachinePanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 566)
        Me.Controls.Add(Me.TabCon_MachinePanel)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MachinePanel"
        Me.Text = "Machine panel"
        Me.TabCon_MachinePanel.ResumeLayout(False)
        Me.TaPa_MainPanel.ResumeLayout(False)
        Me.TaPa_MainPanel.PerformLayout()
        Me.GroupBox_Navigate.ResumeLayout(False)
        Me.GroupBox_Action.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox_Move.ResumeLayout(False)
        Me.GroupBox_Move.PerformLayout()
        CType(Me.TraBa_FeedRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_StepSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GrouBo_AxesStepRatio.ResumeLayout(False)
        Me.GrouBo_AxesStepRatio.PerformLayout()
        CType(Me.NuUpDo_Axis5MMProStep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_Axis4MMProStep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_ZAxisMMProStep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_YAxisMMProStep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_XAxisMMProStep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.TaPa_MachineConnection.ResumeLayout(False)
        Me.TaPa_MachineConnection.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents TabCon_MachinePanel As System.Windows.Forms.TabControl
    Friend WithEvents TaPa_MainPanel As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox_Move As System.Windows.Forms.GroupBox
    Friend WithEvents Bu_StepPlusZ As System.Windows.Forms.Button
    Friend WithEvents Bu_StepPlusY As System.Windows.Forms.Button
    Friend WithEvents Bu_StepPlusX As System.Windows.Forms.Button
    Friend WithEvents Bu_StepMinusZ As System.Windows.Forms.Button
    Friend WithEvents Bu_StepMinusY As System.Windows.Forms.Button
    Friend WithEvents Bu_StepMinusX As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TraBa_FeedRate As System.Windows.Forms.TrackBar
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_StepSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents GroupBox_Action As System.Windows.Forms.GroupBox
    Friend WithEvents Button_Auto As System.Windows.Forms.Button
    Friend WithEvents Button_Stop As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button_D As System.Windows.Forms.Button
    Friend WithEvents Button29 As System.Windows.Forms.Button
    Friend WithEvents Button28 As System.Windows.Forms.Button
    Friend WithEvents Button27 As System.Windows.Forms.Button
    Friend WithEvents Button26 As System.Windows.Forms.Button
    Friend WithEvents Button25 As System.Windows.Forms.Button
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents GroupBox_Navigate As System.Windows.Forms.GroupBox
    Friend WithEvents Button34 As System.Windows.Forms.Button
    Friend WithEvents Button_Delete As System.Windows.Forms.Button
    Friend WithEvents Button_Right As System.Windows.Forms.Button
    Friend WithEvents Button31 As System.Windows.Forms.Button
    Friend WithEvents Button_Left As System.Windows.Forms.Button
    Friend WithEvents Button_Minus As System.Windows.Forms.Button
    Friend WithEvents Button_Enter As System.Windows.Forms.Button
    Friend WithEvents Button_Plus As System.Windows.Forms.Button
    Friend WithEvents Button_Komma As System.Windows.Forms.Button
    Friend WithEvents Button45 As System.Windows.Forms.Button
    Friend WithEvents Button_0 As System.Windows.Forms.Button
    Friend WithEvents Button_3 As System.Windows.Forms.Button
    Friend WithEvents Button_1 As System.Windows.Forms.Button
    Friend WithEvents Button_2 As System.Windows.Forms.Button
    Friend WithEvents Button_6 As System.Windows.Forms.Button
    Friend WithEvents Button_5 As System.Windows.Forms.Button
    Friend WithEvents Button_4 As System.Windows.Forms.Button
    Friend WithEvents Button_9 As System.Windows.Forms.Button
    Friend WithEvents Button_8 As System.Windows.Forms.Button
    Friend WithEvents Button_7 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Bu_SpindleOff As System.Windows.Forms.Button
    Friend WithEvents Bu_SpindleOn As System.Windows.Forms.Button
    Friend WithEvents Bu_SetLaser As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SerPo_Machine As IO.Ports.SerialPort
    Friend WithEvents TaPa_MachineConnection As TabPage
    Friend WithEvents Bu_Disconnect As Button
    Friend WithEvents Bu_Connect As Button
    Friend WithEvents CoBo_COMPort As ComboBox
    Friend WithEvents CoBo_Parity As ComboBox
    Friend WithEvents CoBo_BaudRate As ComboBox
    Friend WithEvents CoBo_FlowControl As ComboBox
    Friend WithEvents CoBo_StopBits As ComboBox
    Friend WithEvents CoBo_DataBits As ComboBox
    Friend WithEvents La_COMPorts As Label
    Friend WithEvents La_DataBits As Label
    Friend WithEvents La_Parity As Label
    Friend WithEvents La_BaudRate As Label
    Friend WithEvents FlowControl As Label
    Friend WithEvents La_StpBits As Label
    Friend WithEvents GrouBo_AxesStepRatio As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents NuUpDo_Axis5MMProStep As NumericUpDown
    Friend WithEvents NuUpDo_Axis4MMProStep As NumericUpDown
    Friend WithEvents NuUpDo_ZAxisMMProStep As NumericUpDown
    Friend WithEvents NuUpDo_YAxisMMProStep As NumericUpDown
    Friend WithEvents NuUpDo_XAxisMMProStep As NumericUpDown
    Friend WithEvents Bu_TakeOverAxesStepRatio As Button
    Friend WithEvents Bu_LoadValuesFromMachine As Button
    Friend WithEvents MachineInfoToolStripMenuItem As ToolStripMenuItem
End Class
