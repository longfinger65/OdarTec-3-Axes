<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CamScan2D
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
        Me.Bu_Ok = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TeBo_PictureColorDepth = New System.Windows.Forms.TextBox()
        Me.La_ColorDepth = New System.Windows.Forms.Label()
        Me.La_ScanPictureHeight = New System.Windows.Forms.Label()
        Me.La_ScanPictureWidth = New System.Windows.Forms.Label()
        Me.TeBo_PictureHeight = New System.Windows.Forms.TextBox()
        Me.TeBo_PictureWidth = New System.Windows.Forms.TextBox()
        Me.Bu_Cancel = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.La_CamFocusHeight = New System.Windows.Forms.Label()
        Me.TeBo_CamFocusHeight = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NuUpDo_BrightnessTreshold = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NuUpDo_ScalingFactor = New System.Windows.Forms.NumericUpDown()
        Me.La_LaserAngle = New System.Windows.Forms.Label()
        Me.TeBo_LaserAngle = New System.Windows.Forms.TextBox()
        Me.La_MaxHeight = New System.Windows.Forms.Label()
        Me.NuUpDo_MaxHeight = New System.Windows.Forms.NumericUpDown()
        Me.La_MMProPixel = New System.Windows.Forms.Label()
        Me.TeBo_MMProPixel = New System.Windows.Forms.TextBox()
        Me.La_ScanDepth = New System.Windows.Forms.Label()
        Me.La_ScanWidth = New System.Windows.Forms.Label()
        Me.NuUpDo_ScanDepth = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_ScanWidth = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_StepWidth = New System.Windows.Forms.NumericUpDown()
        Me.La_ScanStepWidth = New System.Windows.Forms.Label()
        Me.Bu_ScanPreview = New System.Windows.Forms.Button()
        Me.GrouBo_PictureSettings = New System.Windows.Forms.GroupBox()
        Me.LiBo_ScanCam = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PiBo_Reticle = New System.Windows.Forms.PictureBox()
        Me.PiBo_ScanView = New System.Windows.Forms.PictureBox()
        Me.Bu_Scan = New System.Windows.Forms.Button()
        Me.Bu_LaserOnOff = New System.Windows.Forms.Button()
        Me.Bu_Calibration = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.NuUpDo_PassHeight = New System.Windows.Forms.NumericUpDown()
        Me.La_PassHeight = New System.Windows.Forms.Label()
        Me.NuUpDo_PassWidth = New System.Windows.Forms.NumericUpDown()
        Me.La_PassWidth = New System.Windows.Forms.Label()
        Me.BGWor_Preview = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TraBa_ReticleBrightness = New System.Windows.Forms.TrackBar()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.RaBu_ShowHoughPicture = New System.Windows.Forms.RadioButton()
        Me.RaBu_EdgePicture = New System.Windows.Forms.RadioButton()
        Me.RaBu_CameraPicture = New System.Windows.Forms.RadioButton()
        Me.RaBu_GaugePicture = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.NuUpDo_BrightnessTreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_ScalingFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_MaxHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_ScanDepth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_ScanWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_StepWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrouBo_PictureSettings.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PiBo_Reticle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PiBo_ScanView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.NuUpDo_PassHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_PassWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.TraBa_ReticleBrightness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(701, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Scannen"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Bu_Ok
        '
        Me.Bu_Ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bu_Ok.BackColor = System.Drawing.Color.GhostWhite
        Me.Bu_Ok.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Bu_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_Ok.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Bu_Ok.Location = New System.Drawing.Point(643, 549)
        Me.Bu_Ok.Name = "Bu_Ok"
        Me.Bu_Ok.Size = New System.Drawing.Size(55, 23)
        Me.Bu_Ok.TabIndex = 2
        Me.Bu_Ok.Text = "Ok"
        Me.Bu_Ok.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TeBo_PictureColorDepth)
        Me.GroupBox2.Controls.Add(Me.La_ColorDepth)
        Me.GroupBox2.Controls.Add(Me.La_ScanPictureHeight)
        Me.GroupBox2.Controls.Add(Me.La_ScanPictureWidth)
        Me.GroupBox2.Controls.Add(Me.TeBo_PictureHeight)
        Me.GroupBox2.Controls.Add(Me.TeBo_PictureWidth)
        Me.GroupBox2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox2.Location = New System.Drawing.Point(3, 438)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(137, 105)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Scanbildinformation"
        '
        'TeBo_PictureColorDepth
        '
        Me.TeBo_PictureColorDepth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_PictureColorDepth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_PictureColorDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_PictureColorDepth.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_PictureColorDepth.Location = New System.Drawing.Point(67, 71)
        Me.TeBo_PictureColorDepth.Name = "TeBo_PictureColorDepth"
        Me.TeBo_PictureColorDepth.ReadOnly = True
        Me.TeBo_PictureColorDepth.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_PictureColorDepth.TabIndex = 19
        Me.TeBo_PictureColorDepth.Text = "0"
        Me.TeBo_PictureColorDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_PictureColorDepth.WordWrap = False
        '
        'La_ColorDepth
        '
        Me.La_ColorDepth.AutoSize = True
        Me.La_ColorDepth.Location = New System.Drawing.Point(6, 73)
        Me.La_ColorDepth.Name = "La_ColorDepth"
        Me.La_ColorDepth.Size = New System.Drawing.Size(48, 13)
        Me.La_ColorDepth.TabIndex = 18
        Me.La_ColorDepth.Text = "Farbtiefe"
        '
        'La_ScanPictureHeight
        '
        Me.La_ScanPictureHeight.AutoSize = True
        Me.La_ScanPictureHeight.Location = New System.Drawing.Point(6, 47)
        Me.La_ScanPictureHeight.Name = "La_ScanPictureHeight"
        Me.La_ScanPictureHeight.Size = New System.Drawing.Size(33, 13)
        Me.La_ScanPictureHeight.TabIndex = 17
        Me.La_ScanPictureHeight.Text = "Höhe"
        '
        'La_ScanPictureWidth
        '
        Me.La_ScanPictureWidth.AutoSize = True
        Me.La_ScanPictureWidth.Location = New System.Drawing.Point(6, 21)
        Me.La_ScanPictureWidth.Name = "La_ScanPictureWidth"
        Me.La_ScanPictureWidth.Size = New System.Drawing.Size(34, 13)
        Me.La_ScanPictureWidth.TabIndex = 16
        Me.La_ScanPictureWidth.Text = "Breite"
        '
        'TeBo_PictureHeight
        '
        Me.TeBo_PictureHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_PictureHeight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_PictureHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_PictureHeight.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_PictureHeight.Location = New System.Drawing.Point(67, 45)
        Me.TeBo_PictureHeight.Name = "TeBo_PictureHeight"
        Me.TeBo_PictureHeight.ReadOnly = True
        Me.TeBo_PictureHeight.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_PictureHeight.TabIndex = 14
        Me.TeBo_PictureHeight.Text = "0"
        Me.TeBo_PictureHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_PictureHeight.WordWrap = False
        '
        'TeBo_PictureWidth
        '
        Me.TeBo_PictureWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_PictureWidth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_PictureWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_PictureWidth.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_PictureWidth.Location = New System.Drawing.Point(67, 19)
        Me.TeBo_PictureWidth.Name = "TeBo_PictureWidth"
        Me.TeBo_PictureWidth.ReadOnly = True
        Me.TeBo_PictureWidth.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_PictureWidth.TabIndex = 13
        Me.TeBo_PictureWidth.Text = "0"
        Me.TeBo_PictureWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_PictureWidth.WordWrap = False
        '
        'Bu_Cancel
        '
        Me.Bu_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Bu_Cancel.BackColor = System.Drawing.Color.Khaki
        Me.Bu_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Bu_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_Cancel.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Bu_Cancel.Location = New System.Drawing.Point(3, 549)
        Me.Bu_Cancel.Name = "Bu_Cancel"
        Me.Bu_Cancel.Size = New System.Drawing.Size(70, 23)
        Me.Bu_Cancel.TabIndex = 14
        Me.Bu_Cancel.Text = "Abbrechen"
        Me.Bu_Cancel.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.La_CamFocusHeight)
        Me.GroupBox5.Controls.Add(Me.TeBo_CamFocusHeight)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_BrightnessTreshold)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_ScalingFactor)
        Me.GroupBox5.Controls.Add(Me.La_LaserAngle)
        Me.GroupBox5.Controls.Add(Me.TeBo_LaserAngle)
        Me.GroupBox5.Controls.Add(Me.La_MaxHeight)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_MaxHeight)
        Me.GroupBox5.Controls.Add(Me.La_MMProPixel)
        Me.GroupBox5.Controls.Add(Me.TeBo_MMProPixel)
        Me.GroupBox5.Controls.Add(Me.La_ScanDepth)
        Me.GroupBox5.Controls.Add(Me.La_ScanWidth)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_ScanDepth)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_ScanWidth)
        Me.GroupBox5.Controls.Add(Me.NuUpDo_StepWidth)
        Me.GroupBox5.Controls.Add(Me.La_ScanStepWidth)
        Me.GroupBox5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox5.Location = New System.Drawing.Point(561, 18)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(137, 258)
        Me.GroupBox5.TabIndex = 16
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Scanparameter"
        '
        'La_CamFocusHeight
        '
        Me.La_CamFocusHeight.AutoSize = True
        Me.La_CamFocusHeight.Location = New System.Drawing.Point(6, 151)
        Me.La_CamFocusHeight.Name = "La_CamFocusHeight"
        Me.La_CamFocusHeight.Size = New System.Drawing.Size(60, 13)
        Me.La_CamFocusHeight.TabIndex = 31
        Me.La_CamFocusHeight.Text = "Fokushöhe"
        '
        'TeBo_CamFocusHeight
        '
        Me.TeBo_CamFocusHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_CamFocusHeight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_CamFocusHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_CamFocusHeight.Enabled = False
        Me.TeBo_CamFocusHeight.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_CamFocusHeight.Location = New System.Drawing.Point(67, 149)
        Me.TeBo_CamFocusHeight.Name = "TeBo_CamFocusHeight"
        Me.TeBo_CamFocusHeight.ReadOnly = True
        Me.TeBo_CamFocusHeight.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_CamFocusHeight.TabIndex = 30
        Me.TeBo_CamFocusHeight.Text = "0"
        Me.TeBo_CamFocusHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_CamFocusHeight.WordWrap = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "S- / W-Gr."
        '
        'NuUpDo_BrightnessTreshold
        '
        Me.NuUpDo_BrightnessTreshold.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_BrightnessTreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_BrightnessTreshold.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_BrightnessTreshold.Location = New System.Drawing.Point(67, 227)
        Me.NuUpDo_BrightnessTreshold.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NuUpDo_BrightnessTreshold.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.NuUpDo_BrightnessTreshold.Name = "NuUpDo_BrightnessTreshold"
        Me.NuUpDo_BrightnessTreshold.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_BrightnessTreshold.TabIndex = 28
        Me.NuUpDo_BrightnessTreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_BrightnessTreshold.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 203)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Skalierung"
        '
        'NuUpDo_ScalingFactor
        '
        Me.NuUpDo_ScalingFactor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ScalingFactor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ScalingFactor.DecimalPlaces = 1
        Me.NuUpDo_ScalingFactor.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ScalingFactor.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NuUpDo_ScalingFactor.Location = New System.Drawing.Point(67, 201)
        Me.NuUpDo_ScalingFactor.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NuUpDo_ScalingFactor.Name = "NuUpDo_ScalingFactor"
        Me.NuUpDo_ScalingFactor.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_ScalingFactor.TabIndex = 26
        Me.NuUpDo_ScalingFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_ScalingFactor.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'La_LaserAngle
        '
        Me.La_LaserAngle.AutoSize = True
        Me.La_LaserAngle.Location = New System.Drawing.Point(6, 125)
        Me.La_LaserAngle.Name = "La_LaserAngle"
        Me.La_LaserAngle.Size = New System.Drawing.Size(40, 13)
        Me.La_LaserAngle.TabIndex = 25
        Me.La_LaserAngle.Text = "Winkel"
        '
        'TeBo_LaserAngle
        '
        Me.TeBo_LaserAngle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_LaserAngle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_LaserAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_LaserAngle.Enabled = False
        Me.TeBo_LaserAngle.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_LaserAngle.Location = New System.Drawing.Point(67, 123)
        Me.TeBo_LaserAngle.Name = "TeBo_LaserAngle"
        Me.TeBo_LaserAngle.ReadOnly = True
        Me.TeBo_LaserAngle.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_LaserAngle.TabIndex = 24
        Me.TeBo_LaserAngle.Text = "0"
        Me.TeBo_LaserAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_LaserAngle.WordWrap = False
        '
        'La_MaxHeight
        '
        Me.La_MaxHeight.AutoSize = True
        Me.La_MaxHeight.Location = New System.Drawing.Point(6, 177)
        Me.La_MaxHeight.Name = "La_MaxHeight"
        Me.La_MaxHeight.Size = New System.Drawing.Size(58, 13)
        Me.La_MaxHeight.TabIndex = 23
        Me.La_MaxHeight.Text = "max. Höhe"
        '
        'NuUpDo_MaxHeight
        '
        Me.NuUpDo_MaxHeight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_MaxHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_MaxHeight.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_MaxHeight.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NuUpDo_MaxHeight.Location = New System.Drawing.Point(67, 175)
        Me.NuUpDo_MaxHeight.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.NuUpDo_MaxHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NuUpDo_MaxHeight.Name = "NuUpDo_MaxHeight"
        Me.NuUpDo_MaxHeight.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_MaxHeight.TabIndex = 22
        Me.NuUpDo_MaxHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_MaxHeight.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'La_MMProPixel
        '
        Me.La_MMProPixel.AutoSize = True
        Me.La_MMProPixel.Location = New System.Drawing.Point(6, 99)
        Me.La_MMProPixel.Name = "La_MMProPixel"
        Me.La_MMProPixel.Size = New System.Drawing.Size(56, 13)
        Me.La_MMProPixel.TabIndex = 21
        Me.La_MMProPixel.Text = "mm / Pixel"
        '
        'TeBo_MMProPixel
        '
        Me.TeBo_MMProPixel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TeBo_MMProPixel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_MMProPixel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_MMProPixel.Enabled = False
        Me.TeBo_MMProPixel.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_MMProPixel.Location = New System.Drawing.Point(67, 97)
        Me.TeBo_MMProPixel.Name = "TeBo_MMProPixel"
        Me.TeBo_MMProPixel.ReadOnly = True
        Me.TeBo_MMProPixel.Size = New System.Drawing.Size(64, 20)
        Me.TeBo_MMProPixel.TabIndex = 20
        Me.TeBo_MMProPixel.Text = "0"
        Me.TeBo_MMProPixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TeBo_MMProPixel.WordWrap = False
        '
        'La_ScanDepth
        '
        Me.La_ScanDepth.AutoSize = True
        Me.La_ScanDepth.Location = New System.Drawing.Point(6, 73)
        Me.La_ScanDepth.Name = "La_ScanDepth"
        Me.La_ScanDepth.Size = New System.Drawing.Size(52, 13)
        Me.La_ScanDepth.TabIndex = 7
        Me.La_ScanDepth.Text = "Scantiefe"
        '
        'La_ScanWidth
        '
        Me.La_ScanWidth.AutoSize = True
        Me.La_ScanWidth.Location = New System.Drawing.Point(6, 47)
        Me.La_ScanWidth.Name = "La_ScanWidth"
        Me.La_ScanWidth.Size = New System.Drawing.Size(58, 13)
        Me.La_ScanWidth.TabIndex = 6
        Me.La_ScanWidth.Text = "Scanbreite"
        '
        'NuUpDo_ScanDepth
        '
        Me.NuUpDo_ScanDepth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ScanDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ScanDepth.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ScanDepth.Location = New System.Drawing.Point(67, 71)
        Me.NuUpDo_ScanDepth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NuUpDo_ScanDepth.Name = "NuUpDo_ScanDepth"
        Me.NuUpDo_ScanDepth.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_ScanDepth.TabIndex = 5
        Me.NuUpDo_ScanDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_ScanDepth.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'NuUpDo_ScanWidth
        '
        Me.NuUpDo_ScanWidth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ScanWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ScanWidth.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ScanWidth.Location = New System.Drawing.Point(67, 45)
        Me.NuUpDo_ScanWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.NuUpDo_ScanWidth.Name = "NuUpDo_ScanWidth"
        Me.NuUpDo_ScanWidth.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_ScanWidth.TabIndex = 4
        Me.NuUpDo_ScanWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_ScanWidth.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'NuUpDo_StepWidth
        '
        Me.NuUpDo_StepWidth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_StepWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_StepWidth.DecimalPlaces = 3
        Me.NuUpDo_StepWidth.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_StepWidth.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NuUpDo_StepWidth.Location = New System.Drawing.Point(67, 19)
        Me.NuUpDo_StepWidth.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NuUpDo_StepWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NuUpDo_StepWidth.Name = "NuUpDo_StepWidth"
        Me.NuUpDo_StepWidth.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_StepWidth.TabIndex = 0
        Me.NuUpDo_StepWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_StepWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'La_ScanStepWidth
        '
        Me.La_ScanStepWidth.AutoSize = True
        Me.La_ScanStepWidth.Location = New System.Drawing.Point(6, 21)
        Me.La_ScanStepWidth.Name = "La_ScanStepWidth"
        Me.La_ScanStepWidth.Size = New System.Drawing.Size(62, 13)
        Me.La_ScanStepWidth.TabIndex = 1
        Me.La_ScanStepWidth.Text = "Schrittweite"
        '
        'Bu_ScanPreview
        '
        Me.Bu_ScanPreview.BackColor = System.Drawing.Color.GhostWhite
        Me.Bu_ScanPreview.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Bu_ScanPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_ScanPreview.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Bu_ScanPreview.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Bu_ScanPreview.Location = New System.Drawing.Point(122, 549)
        Me.Bu_ScanPreview.Name = "Bu_ScanPreview"
        Me.Bu_ScanPreview.Size = New System.Drawing.Size(98, 23)
        Me.Bu_ScanPreview.TabIndex = 18
        Me.Bu_ScanPreview.Text = "Kantenvorschau"
        Me.Bu_ScanPreview.UseVisualStyleBackColor = False
        '
        'GrouBo_PictureSettings
        '
        Me.GrouBo_PictureSettings.Controls.Add(Me.LiBo_ScanCam)
        Me.GrouBo_PictureSettings.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GrouBo_PictureSettings.Location = New System.Drawing.Point(146, 438)
        Me.GrouBo_PictureSettings.Name = "GrouBo_PictureSettings"
        Me.GrouBo_PictureSettings.Size = New System.Drawing.Size(128, 105)
        Me.GrouBo_PictureSettings.TabIndex = 19
        Me.GrouBo_PictureSettings.TabStop = False
        Me.GrouBo_PictureSettings.Text = "Scangeräte"
        '
        'LiBo_ScanCam
        '
        Me.LiBo_ScanCam.FormattingEnabled = True
        Me.LiBo_ScanCam.Location = New System.Drawing.Point(6, 19)
        Me.LiBo_ScanCam.Name = "LiBo_ScanCam"
        Me.LiBo_ScanCam.Size = New System.Drawing.Size(114, 69)
        Me.LiBo_ScanCam.TabIndex = 21
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PiBo_Reticle)
        Me.GroupBox3.Controls.Add(Me.PiBo_ScanView)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 18)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Size = New System.Drawing.Size(551, 415)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "aktuelles Bild"
        '
        'PiBo_Reticle
        '
        Me.PiBo_Reticle.BackColor = System.Drawing.Color.Transparent
        Me.PiBo_Reticle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PiBo_Reticle.Location = New System.Drawing.Point(0, 0)
        Me.PiBo_Reticle.Margin = New System.Windows.Forms.Padding(0)
        Me.PiBo_Reticle.Name = "PiBo_Reticle"
        Me.PiBo_Reticle.Size = New System.Drawing.Size(551, 415)
        Me.PiBo_Reticle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PiBo_Reticle.TabIndex = 1
        Me.PiBo_Reticle.TabStop = False
        '
        'PiBo_ScanView
        '
        Me.PiBo_ScanView.BackColor = System.Drawing.Color.GhostWhite
        Me.PiBo_ScanView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PiBo_ScanView.Location = New System.Drawing.Point(6, 19)
        Me.PiBo_ScanView.Margin = New System.Windows.Forms.Padding(0)
        Me.PiBo_ScanView.Name = "PiBo_ScanView"
        Me.PiBo_ScanView.Size = New System.Drawing.Size(541, 391)
        Me.PiBo_ScanView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PiBo_ScanView.TabIndex = 0
        Me.PiBo_ScanView.TabStop = False
        '
        'Bu_Scan
        '
        Me.Bu_Scan.BackColor = System.Drawing.Color.GhostWhite
        Me.Bu_Scan.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Bu_Scan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_Scan.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Bu_Scan.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Bu_Scan.Location = New System.Drawing.Point(398, 549)
        Me.Bu_Scan.Name = "Bu_Scan"
        Me.Bu_Scan.Size = New System.Drawing.Size(70, 23)
        Me.Bu_Scan.TabIndex = 22
        Me.Bu_Scan.Text = "Scan"
        Me.Bu_Scan.UseVisualStyleBackColor = False
        '
        'Bu_LaserOnOff
        '
        Me.Bu_LaserOnOff.BackColor = System.Drawing.Color.GhostWhite
        Me.Bu_LaserOnOff.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Bu_LaserOnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_LaserOnOff.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Bu_LaserOnOff.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Bu_LaserOnOff.Location = New System.Drawing.Point(226, 549)
        Me.Bu_LaserOnOff.Name = "Bu_LaserOnOff"
        Me.Bu_LaserOnOff.Size = New System.Drawing.Size(90, 23)
        Me.Bu_LaserOnOff.TabIndex = 23
        Me.Bu_LaserOnOff.Text = "Laser Ein/Aus"
        Me.Bu_LaserOnOff.UseVisualStyleBackColor = False
        '
        'Bu_Calibration
        '
        Me.Bu_Calibration.BackColor = System.Drawing.Color.LightCoral
        Me.Bu_Calibration.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Bu_Calibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_Calibration.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Bu_Calibration.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Bu_Calibration.Location = New System.Drawing.Point(322, 549)
        Me.Bu_Calibration.Name = "Bu_Calibration"
        Me.Bu_Calibration.Size = New System.Drawing.Size(70, 23)
        Me.Bu_Calibration.TabIndex = 24
        Me.Bu_Calibration.Text = "Kalibrieren"
        Me.Bu_Calibration.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.NuUpDo_PassHeight)
        Me.GroupBox4.Controls.Add(Me.La_PassHeight)
        Me.GroupBox4.Controls.Add(Me.NuUpDo_PassWidth)
        Me.GroupBox4.Controls.Add(Me.La_PassWidth)
        Me.GroupBox4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox4.Location = New System.Drawing.Point(280, 438)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(131, 105)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Kalibriernormal"
        '
        'NuUpDo_PassHeight
        '
        Me.NuUpDo_PassHeight.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_PassHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_PassHeight.DecimalPlaces = 1
        Me.NuUpDo_PassHeight.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_PassHeight.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NuUpDo_PassHeight.Location = New System.Drawing.Point(61, 45)
        Me.NuUpDo_PassHeight.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NuUpDo_PassHeight.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NuUpDo_PassHeight.Name = "NuUpDo_PassHeight"
        Me.NuUpDo_PassHeight.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_PassHeight.TabIndex = 3
        Me.NuUpDo_PassHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_PassHeight.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'La_PassHeight
        '
        Me.La_PassHeight.AutoSize = True
        Me.La_PassHeight.Location = New System.Drawing.Point(6, 47)
        Me.La_PassHeight.Name = "La_PassHeight"
        Me.La_PassHeight.Size = New System.Drawing.Size(33, 13)
        Me.La_PassHeight.TabIndex = 2
        Me.La_PassHeight.Text = "Höhe"
        '
        'NuUpDo_PassWidth
        '
        Me.NuUpDo_PassWidth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_PassWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_PassWidth.DecimalPlaces = 1
        Me.NuUpDo_PassWidth.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_PassWidth.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NuUpDo_PassWidth.Location = New System.Drawing.Point(61, 19)
        Me.NuUpDo_PassWidth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NuUpDo_PassWidth.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NuUpDo_PassWidth.Name = "NuUpDo_PassWidth"
        Me.NuUpDo_PassWidth.Size = New System.Drawing.Size(64, 20)
        Me.NuUpDo_PassWidth.TabIndex = 0
        Me.NuUpDo_PassWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NuUpDo_PassWidth.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'La_PassWidth
        '
        Me.La_PassWidth.AutoSize = True
        Me.La_PassWidth.Location = New System.Drawing.Point(6, 21)
        Me.La_PassWidth.Name = "La_PassWidth"
        Me.La_PassWidth.Size = New System.Drawing.Size(34, 13)
        Me.La_PassWidth.TabIndex = 1
        Me.La_PassWidth.Text = "Breite"
        '
        'BGWor_Preview
        '
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TraBa_ReticleBrightness)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox6.Location = New System.Drawing.Point(417, 438)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(275, 105)
        Me.GroupBox6.TabIndex = 27
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Fadenkreuzhelligkeit"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "hell"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.Location = New System.Drawing.Point(235, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "dunkel"
        '
        'TraBa_ReticleBrightness
        '
        Me.TraBa_ReticleBrightness.LargeChange = 100
        Me.TraBa_ReticleBrightness.Location = New System.Drawing.Point(24, 47)
        Me.TraBa_ReticleBrightness.Maximum = 255
        Me.TraBa_ReticleBrightness.Name = "TraBa_ReticleBrightness"
        Me.TraBa_ReticleBrightness.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TraBa_ReticleBrightness.Size = New System.Drawing.Size(245, 45)
        Me.TraBa_ReticleBrightness.SmallChange = 10
        Me.TraBa_ReticleBrightness.TabIndex = 22
        Me.TraBa_ReticleBrightness.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.TraBa_ReticleBrightness.Value = 100
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.RaBu_GaugePicture)
        Me.GroupBox7.Controls.Add(Me.RaBu_CameraPicture)
        Me.GroupBox7.Controls.Add(Me.RaBu_EdgePicture)
        Me.GroupBox7.Controls.Add(Me.RaBu_ShowHoughPicture)
        Me.GroupBox7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupBox7.Location = New System.Drawing.Point(561, 282)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(137, 118)
        Me.GroupBox7.TabIndex = 28
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Anzeigebild"
        '
        'RaBu_ShowHoughPicture
        '
        Me.RaBu_ShowHoughPicture.AutoSize = True
        Me.RaBu_ShowHoughPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RaBu_ShowHoughPicture.Location = New System.Drawing.Point(6, 19)
        Me.RaBu_ShowHoughPicture.Name = "RaBu_ShowHoughPicture"
        Me.RaBu_ShowHoughPicture.Size = New System.Drawing.Size(76, 17)
        Me.RaBu_ShowHoughPicture.TabIndex = 0
        Me.RaBu_ShowHoughPicture.TabStop = True
        Me.RaBu_ShowHoughPicture.Text = "Hough-Bild"
        Me.RaBu_ShowHoughPicture.UseVisualStyleBackColor = True
        '
        'RaBu_EdgePicture
        '
        Me.RaBu_EdgePicture.AutoSize = True
        Me.RaBu_EdgePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RaBu_EdgePicture.Location = New System.Drawing.Point(6, 42)
        Me.RaBu_EdgePicture.Name = "RaBu_EdgePicture"
        Me.RaBu_EdgePicture.Size = New System.Drawing.Size(78, 17)
        Me.RaBu_EdgePicture.TabIndex = 1
        Me.RaBu_EdgePicture.TabStop = True
        Me.RaBu_EdgePicture.Text = "Kanten-Bild"
        Me.RaBu_EdgePicture.UseVisualStyleBackColor = True
        '
        'RaBu_CameraPicture
        '
        Me.RaBu_CameraPicture.AutoSize = True
        Me.RaBu_CameraPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RaBu_CameraPicture.Location = New System.Drawing.Point(6, 65)
        Me.RaBu_CameraPicture.Name = "RaBu_CameraPicture"
        Me.RaBu_CameraPicture.Size = New System.Drawing.Size(80, 17)
        Me.RaBu_CameraPicture.TabIndex = 2
        Me.RaBu_CameraPicture.TabStop = True
        Me.RaBu_CameraPicture.Text = "Kamera-Bild"
        Me.RaBu_CameraPicture.UseVisualStyleBackColor = True
        '
        'RaBu_GaugePicture
        '
        Me.RaBu_GaugePicture.AutoSize = True
        Me.RaBu_GaugePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RaBu_GaugePicture.Location = New System.Drawing.Point(6, 88)
        Me.RaBu_GaugePicture.Name = "RaBu_GaugePicture"
        Me.RaBu_GaugePicture.Size = New System.Drawing.Size(81, 17)
        Me.RaBu_GaugePicture.TabIndex = 3
        Me.RaBu_GaugePicture.TabStop = True
        Me.RaBu_GaugePicture.Text = "Kalibrier-Bild"
        Me.RaBu_GaugePicture.UseVisualStyleBackColor = True
        '
        'CamScan2D
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Bu_Calibration)
        Me.Controls.Add(Me.Bu_LaserOnOff)
        Me.Controls.Add(Me.Bu_Scan)
        Me.Controls.Add(Me.GrouBo_PictureSettings)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Bu_ScanPreview)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Bu_Cancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Bu_Ok)
        Me.Controls.Add(Me.Label1)
        Me.MaximumSize = New System.Drawing.Size(701, 575)
        Me.MinimumSize = New System.Drawing.Size(701, 575)
        Me.Name = "CamScan2D"
        Me.Size = New System.Drawing.Size(701, 575)
        Me.Tag = "test"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.NuUpDo_BrightnessTreshold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_ScalingFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_MaxHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_ScanDepth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_ScanWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_StepWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrouBo_PictureSettings.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.PiBo_Reticle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PiBo_ScanView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.NuUpDo_PassHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_PassWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.TraBa_ReticleBrightness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Bu_Ok As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Origin As System.Windows.Forms.Label
    Friend WithEvents TeBo_OriginZ As System.Windows.Forms.TextBox
    Friend WithEvents TeBo_OriginY As System.Windows.Forms.TextBox
    Friend WithEvents TeBo_OriginX As System.Windows.Forms.TextBox
    Friend WithEvents TeBo_OriginChooser As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Bu_Cancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents NuUpDo_StepWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents La_ScanStepWidth As System.Windows.Forms.Label
    Friend WithEvents Bu_ScanPreview As System.Windows.Forms.Button
    Friend WithEvents TeBo_PictureHeight As System.Windows.Forms.TextBox
    Friend WithEvents TeBo_PictureWidth As System.Windows.Forms.TextBox
    Friend WithEvents GrouBo_PictureSettings As System.Windows.Forms.GroupBox
    Friend WithEvents NuUpDo_Pixelsize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents PiBo_ScanView As System.Windows.Forms.PictureBox
    Friend WithEvents La_ColorDepth As System.Windows.Forms.Label
    Friend WithEvents La_ScanPictureHeight As System.Windows.Forms.Label
    Friend WithEvents La_ScanPictureWidth As System.Windows.Forms.Label
    Friend WithEvents NuUpDo_Brightness As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TeBo_PictureColorDepth As System.Windows.Forms.TextBox
    Friend WithEvents NuUpDo_Contrast As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents La_ScanDepth As Label
    Friend WithEvents La_ScanWidth As Label
    Friend WithEvents NuUpDo_ScanDepth As NumericUpDown
    Friend WithEvents NuUpDo_ScanWidth As NumericUpDown
    Friend WithEvents LiBo_ScanCam As ListBox
    Friend WithEvents Bu_Scan As Button
    Friend WithEvents Bu_LaserOnOff As Button
    Friend WithEvents Bu_Calibration As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents NuUpDo_PassHeight As NumericUpDown
    Friend WithEvents La_PassHeight As Label
    Friend WithEvents NuUpDo_PassWidth As NumericUpDown
    Friend WithEvents La_PassWidth As Label
    Friend WithEvents PiBo_Reticle As PictureBox
    Friend WithEvents BGWor_Preview As System.ComponentModel.BackgroundWorker
    Friend WithEvents La_MMProPixel As Label
    Friend WithEvents TeBo_MMProPixel As TextBox
    Friend WithEvents La_MaxHeight As Label
    Friend WithEvents NuUpDo_MaxHeight As NumericUpDown
    Friend WithEvents La_LaserAngle As Label
    Friend WithEvents TeBo_LaserAngle As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents NuUpDo_ScalingFactor As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents NuUpDo_BrightnessTreshold As NumericUpDown
    Friend WithEvents La_CamFocusHeight As Label
    Friend WithEvents TeBo_CamFocusHeight As TextBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TraBa_ReticleBrightness As TrackBar
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents RaBu_CameraPicture As RadioButton
    Friend WithEvents RaBu_EdgePicture As RadioButton
    Friend WithEvents RaBu_ShowHoughPicture As RadioButton
    Friend WithEvents RaBu_GaugePicture As RadioButton
End Class
