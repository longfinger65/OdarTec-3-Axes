<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FM_Options
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim TreeNode42 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Allgemein")
        Dim TreeNode43 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Zeichnungsoptionen")
        Dim TreeNode44 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Farben")
        Dim TreeNode45 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Beziehungen/Fangen")
        Dim TreeNode46 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Skizze", New System.Windows.Forms.TreeNode() {TreeNode45})
        Dim TreeNode47 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Anzeige und Auswahl")
        Dim TreeNode48 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Leistung")
        Dim TreeNode49 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Baugruppen")
        Dim TreeNode50 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Externe Referenzen")
        Dim TreeNode51 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Standardvorlagen")
        Dim TreeNode52 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Dateipositionen")
        Dim TreeNode53 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Featuremanager")
        Dim TreeNode54 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ansicht")
        Dim TreeNode55 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Meldungen, Fehler, Warnungen")
        Dim TreeNode56 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Entwurfsnorm")
        Dim TreeNode57 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Beschriftungen")
        Dim TreeNode58 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ränder")
        Dim TreeNode59 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bemaßungen")
        Dim TreeNode60 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mittellinien und Mittelkreuze")
        Dim TreeNode61 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Zeichnungen")
        Dim TreeNode62 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Anzeigen virtueller Eckpunkte")
        Dim TreeNode63 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stücklisten")
        Dim TreeNode64 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("allgemeine Tabellen")
        Dim TreeNode65 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bohrungstabellen")
        Dim TreeNode66 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Stanztabellen")
        Dim TreeNode67 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tabellen", New System.Windows.Forms.TreeNode() {TreeNode63, TreeNode64, TreeNode65, TreeNode66})
        Dim TreeNode68 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ansichten")
        Dim TreeNode69 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Detaillierung")
        Dim TreeNode70 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Zeichenblätter")
        Dim TreeNode71 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gitter/Fangen")
        Dim TreeNode72 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Einheiten")
        Dim TreeNode73 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Linienschriftart")
        Dim TreeNode74 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Linienart")
        Dim TreeNode75 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Linienstärke")
        Dim TreeNode76 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Modellanzeige")
        Dim TreeNode77 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Materialeigenschaften")
        Dim TreeNode78 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bildqualität")
        Dim TreeNode79 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Blech")
        Dim TreeNode80 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Schweißkonstruktionen")
        Dim TreeNode81 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ebenenanzeige")
        Dim TreeNode82 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Konfigurationen")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FM_Options))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.TP_ToolLibrary = New System.Windows.Forms.TabPage()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CheLiBo_WorkPieceHardness = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.NuUpDo_ToolLength = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NuUpDo_CuttingLength = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_NumberOfCuttingEdges = New System.Windows.Forms.NumericUpDown()
        Me.CoBo_ToolType = New System.Windows.Forms.ComboBox()
        Me.CheBo_InnerCooling = New System.Windows.Forms.CheckBox()
        Me.NuUpDo_ShaftDiameter2 = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_ShaftDiameter1 = New System.Windows.Forms.NumericUpDown()
        Me.NuUpDo_ToolNumber = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TeBo_ToolName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CoBo_ToolCoating = New System.Windows.Forms.ComboBox()
        Me.CheBo_CenterCut = New System.Windows.Forms.CheckBox()
        Me.NuUpDo_ToolDiameter = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CoBo_ToolMaterial = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Bu_DeleteTool = New System.Windows.Forms.Button()
        Me.CheLiBo_ToolTypeFilter = New System.Windows.Forms.CheckedListBox()
        Me.Bu_ChangeTool = New System.Windows.Forms.Button()
        Me.CoBo_Tools = New System.Windows.Forms.ComboBox()
        Me.Bu_NewTool = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.GrouBo_SystemColor = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TP_ToolLibrary.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NuUpDo_ToolLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_CuttingLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_NumberOfCuttingEdges, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_ShaftDiameter2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_ShaftDiameter1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_ToolNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuUpDo_ToolDiameter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GrouBo_SystemColor.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TP_ToolLibrary)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(533, 589)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Lavender
        Me.TabPage1.Controls.Add(Me.GrouBo_SystemColor)
        Me.TabPage1.Controls.Add(Me.TreeView1)
        Me.TabPage1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(525, 563)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Systemeinstellungen"
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TreeView1.Location = New System.Drawing.Point(3, 6)
        Me.TreeView1.Name = "TreeView1"
        TreeNode42.Name = "TreViI_General"
        TreeNode42.Text = "Allgemein"
        TreeNode43.Name = "TreViI_Drawing"
        TreeNode43.Text = "Zeichnungsoptionen"
        TreeNode44.Name = "TreViI_Color"
        TreeNode44.Text = "Farben"
        TreeNode45.Name = "TreViI_ConstraintsFang"
        TreeNode45.Text = "Beziehungen/Fangen"
        TreeNode46.Name = "TreViI_Sketch"
        TreeNode46.Text = "Skizze"
        TreeNode47.Name = "Knoten4"
        TreeNode47.Text = "Anzeige und Auswahl"
        TreeNode48.Name = "Knoten5"
        TreeNode48.Text = "Leistung"
        TreeNode49.Name = "Knoten6"
        TreeNode49.Text = "Baugruppen"
        TreeNode50.Name = "Knoten7"
        TreeNode50.Text = "Externe Referenzen"
        TreeNode51.Name = "Knoten8"
        TreeNode51.Text = "Standardvorlagen"
        TreeNode52.Name = "Knoten9"
        TreeNode52.Text = "Dateipositionen"
        TreeNode53.Name = "TreViI_FeatureManager"
        TreeNode53.Text = "Featuremanager"
        TreeNode54.Name = "TreViI_View"
        TreeNode54.Text = "Ansicht"
        TreeNode55.Name = "Knoten11"
        TreeNode55.Text = "Meldungen, Fehler, Warnungen"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode42, TreeNode43, TreeNode44, TreeNode46, TreeNode47, TreeNode48, TreeNode49, TreeNode50, TreeNode51, TreeNode52, TreeNode53, TreeNode54, TreeNode55})
        Me.TreeView1.Size = New System.Drawing.Size(136, 514)
        Me.TreeView1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Lavender
        Me.TabPage2.Controls.Add(Me.TreeView2)
        Me.TabPage2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(525, 563)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Dokumenteigenschaften"
        '
        'TreeView2
        '
        Me.TreeView2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TreeView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TreeView2.Location = New System.Drawing.Point(8, 6)
        Me.TreeView2.Name = "TreeView2"
        TreeNode56.Name = "Knoten0"
        TreeNode56.Text = "Entwurfsnorm"
        TreeNode57.Name = "Knoten1"
        TreeNode57.Text = "Beschriftungen"
        TreeNode58.Name = "Knoten2"
        TreeNode58.Text = "Ränder"
        TreeNode59.Name = "Knoten3"
        TreeNode59.Text = "Bemaßungen"
        TreeNode60.Name = "Knoten4"
        TreeNode60.Text = "Mittellinien und Mittelkreuze"
        TreeNode61.Name = "Knoten5"
        TreeNode61.Text = "Zeichnungen"
        TreeNode62.Name = "Knoten6"
        TreeNode62.Text = "Anzeigen virtueller Eckpunkte"
        TreeNode63.Name = "Knoten11"
        TreeNode63.Text = "Stücklisten"
        TreeNode64.Name = "Knoten13"
        TreeNode64.Text = "allgemeine Tabellen"
        TreeNode65.Name = "Knoten14"
        TreeNode65.Text = "Bohrungstabellen"
        TreeNode66.Name = "Knoten15"
        TreeNode66.Text = "Stanztabellen"
        TreeNode67.Name = "Knoten7"
        TreeNode67.Text = "Tabellen"
        TreeNode68.Name = "Knoten8"
        TreeNode68.Text = "Ansichten"
        TreeNode69.Name = "Knoten9"
        TreeNode69.Text = "Detaillierung"
        TreeNode70.Name = "Knoten10"
        TreeNode70.Text = "Zeichenblätter"
        TreeNode71.Name = "Knoten11"
        TreeNode71.Text = "Gitter/Fangen"
        TreeNode72.Name = "Knoten0"
        TreeNode72.Text = "Einheiten"
        TreeNode73.Name = "Knoten1"
        TreeNode73.Text = "Linienschriftart"
        TreeNode74.Name = "Knoten2"
        TreeNode74.Text = "Linienart"
        TreeNode75.Name = "Knoten3"
        TreeNode75.Text = "Linienstärke"
        TreeNode76.Name = "Knoten4"
        TreeNode76.Text = "Modellanzeige"
        TreeNode77.Name = "Knoten5"
        TreeNode77.Text = "Materialeigenschaften"
        TreeNode78.Name = "Knoten6"
        TreeNode78.Text = "Bildqualität"
        TreeNode79.Name = "Knoten7"
        TreeNode79.Text = "Blech"
        TreeNode80.Name = "Knoten8"
        TreeNode80.Text = "Schweißkonstruktionen"
        TreeNode81.Name = "Knoten9"
        TreeNode81.Text = "Ebenenanzeige"
        TreeNode82.Name = "Knoten10"
        TreeNode82.Text = "Konfigurationen"
        Me.TreeView2.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode56, TreeNode57, TreeNode58, TreeNode59, TreeNode60, TreeNode61, TreeNode62, TreeNode67, TreeNode68, TreeNode69, TreeNode70, TreeNode71, TreeNode72, TreeNode73, TreeNode74, TreeNode75, TreeNode76, TreeNode77, TreeNode78, TreeNode79, TreeNode80, TreeNode81, TreeNode82})
        Me.TreeView2.Size = New System.Drawing.Size(136, 507)
        Me.TreeView2.TabIndex = 1
        '
        'TP_ToolLibrary
        '
        Me.TP_ToolLibrary.BackColor = System.Drawing.Color.Lavender
        Me.TP_ToolLibrary.Controls.Add(Me.Button4)
        Me.TP_ToolLibrary.Controls.Add(Me.Button3)
        Me.TP_ToolLibrary.Controls.Add(Me.GroupBox4)
        Me.TP_ToolLibrary.Controls.Add(Me.GroupBox3)
        Me.TP_ToolLibrary.Controls.Add(Me.GroupBox2)
        Me.TP_ToolLibrary.Controls.Add(Me.PictureBox1)
        Me.TP_ToolLibrary.ForeColor = System.Drawing.Color.MidnightBlue
        Me.TP_ToolLibrary.Location = New System.Drawing.Point(4, 22)
        Me.TP_ToolLibrary.Name = "TP_ToolLibrary"
        Me.TP_ToolLibrary.Size = New System.Drawing.Size(525, 563)
        Me.TP_ToolLibrary.TabIndex = 2
        Me.TP_ToolLibrary.Text = "Werkzeugbibliothek"
        Me.TP_ToolLibrary.ToolTipText = "Hinzufügen, ändern oder löschen von Werkzeugen"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Khaki
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(214, 525)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(86, 27)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "zurücksetzen"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.LightGreen
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(306, 525)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(133, 27)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "übernehmen"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CheLiBo_WorkPieceHardness)
        Me.GroupBox4.Location = New System.Drawing.Point(214, 382)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(227, 137)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "geeignet zur Bearbeitung von"
        '
        'CheLiBo_WorkPieceHardness
        '
        Me.CheLiBo_WorkPieceHardness.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CheLiBo_WorkPieceHardness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CheLiBo_WorkPieceHardness.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CheLiBo_WorkPieceHardness.FormattingEnabled = True
        Me.CheLiBo_WorkPieceHardness.Items.AddRange(New Object() {"Stahl, 45 HRC", "Stahl, 56 HRC", "Stahl, 62 HRC", "Aluminium, 30 HRC", "Kupfer, 30 HRC", "Messing, 30 HRC", "Bronze, 30 HRC", "Hartgewebe, 30 HRC", "Hartpapier, 30 HRC", "Kunststoff ungefüllt, 30 HRC", "Kunststoff GF, 30 HRC"})
        Me.CheLiBo_WorkPieceHardness.Location = New System.Drawing.Point(9, 19)
        Me.CheLiBo_WorkPieceHardness.Name = "CheLiBo_WorkPieceHardness"
        Me.CheLiBo_WorkPieceHardness.Size = New System.Drawing.Size(212, 107)
        Me.CheLiBo_WorkPieceHardness.TabIndex = 10
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.NuUpDo_ToolLength)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.NuUpDo_CuttingLength)
        Me.GroupBox3.Controls.Add(Me.NuUpDo_NumberOfCuttingEdges)
        Me.GroupBox3.Controls.Add(Me.CoBo_ToolType)
        Me.GroupBox3.Controls.Add(Me.CheBo_InnerCooling)
        Me.GroupBox3.Controls.Add(Me.NuUpDo_ShaftDiameter2)
        Me.GroupBox3.Controls.Add(Me.NuUpDo_ShaftDiameter1)
        Me.GroupBox3.Controls.Add(Me.NuUpDo_ToolNumber)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.TeBo_ToolName)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.CoBo_ToolCoating)
        Me.GroupBox3.Controls.Add(Me.CheBo_CenterCut)
        Me.GroupBox3.Controls.Add(Me.NuUpDo_ToolDiameter)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.CoBo_ToolMaterial)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(214, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(227, 364)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Werkzeugdetails"
        '
        'NuUpDo_ToolLength
        '
        Me.NuUpDo_ToolLength.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ToolLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ToolLength.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ToolLength.Location = New System.Drawing.Point(138, 108)
        Me.NuUpDo_ToolLength.Name = "NuUpDo_ToolLength"
        Me.NuUpDo_ToolLength.Size = New System.Drawing.Size(80, 20)
        Me.NuUpDo_ToolLength.TabIndex = 20
        Me.NuUpDo_ToolLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Werkzeuglänge L0"
        '
        'NuUpDo_CuttingLength
        '
        Me.NuUpDo_CuttingLength.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_CuttingLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_CuttingLength.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_CuttingLength.Location = New System.Drawing.Point(138, 238)
        Me.NuUpDo_CuttingLength.Name = "NuUpDo_CuttingLength"
        Me.NuUpDo_CuttingLength.Size = New System.Drawing.Size(80, 20)
        Me.NuUpDo_CuttingLength.TabIndex = 18
        Me.NuUpDo_CuttingLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NuUpDo_NumberOfCuttingEdges
        '
        Me.NuUpDo_NumberOfCuttingEdges.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_NumberOfCuttingEdges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_NumberOfCuttingEdges.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_NumberOfCuttingEdges.Location = New System.Drawing.Point(138, 212)
        Me.NuUpDo_NumberOfCuttingEdges.Name = "NuUpDo_NumberOfCuttingEdges"
        Me.NuUpDo_NumberOfCuttingEdges.Size = New System.Drawing.Size(80, 20)
        Me.NuUpDo_NumberOfCuttingEdges.TabIndex = 17
        Me.NuUpDo_NumberOfCuttingEdges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CoBo_ToolType
        '
        Me.CoBo_ToolType.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CoBo_ToolType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CoBo_ToolType.ForeColor = System.Drawing.Color.SteelBlue
        Me.CoBo_ToolType.FormattingEnabled = True
        Me.CoBo_ToolType.Items.AddRange(New Object() {"Schaftfräser", "Scheibenfräser", "Walzenfräser", "Sägeblatt", "Bohrer", "Zentrierbohrer", "Laser"})
        Me.CoBo_ToolType.Location = New System.Drawing.Point(9, 69)
        Me.CoBo_ToolType.Name = "CoBo_ToolType"
        Me.CoBo_ToolType.Size = New System.Drawing.Size(212, 21)
        Me.CoBo_ToolType.TabIndex = 16
        Me.CoBo_ToolType.Text = "Werkzeugart"
        '
        'CheBo_InnerCooling
        '
        Me.CheBo_InnerCooling.AutoSize = True
        Me.CheBo_InnerCooling.Location = New System.Drawing.Point(6, 341)
        Me.CheBo_InnerCooling.Name = "CheBo_InnerCooling"
        Me.CheBo_InnerCooling.Size = New System.Drawing.Size(91, 17)
        Me.CheBo_InnerCooling.TabIndex = 15
        Me.CheBo_InnerCooling.Text = "Innenkühlung"
        Me.CheBo_InnerCooling.UseVisualStyleBackColor = True
        '
        'NuUpDo_ShaftDiameter2
        '
        Me.NuUpDo_ShaftDiameter2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ShaftDiameter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ShaftDiameter2.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ShaftDiameter2.Location = New System.Drawing.Point(138, 186)
        Me.NuUpDo_ShaftDiameter2.Name = "NuUpDo_ShaftDiameter2"
        Me.NuUpDo_ShaftDiameter2.Size = New System.Drawing.Size(80, 20)
        Me.NuUpDo_ShaftDiameter2.TabIndex = 14
        Me.NuUpDo_ShaftDiameter2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NuUpDo_ShaftDiameter1
        '
        Me.NuUpDo_ShaftDiameter1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ShaftDiameter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ShaftDiameter1.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ShaftDiameter1.Location = New System.Drawing.Point(138, 160)
        Me.NuUpDo_ShaftDiameter1.Name = "NuUpDo_ShaftDiameter1"
        Me.NuUpDo_ShaftDiameter1.Size = New System.Drawing.Size(80, 20)
        Me.NuUpDo_ShaftDiameter1.TabIndex = 13
        Me.NuUpDo_ShaftDiameter1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NuUpDo_ToolNumber
        '
        Me.NuUpDo_ToolNumber.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ToolNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ToolNumber.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ToolNumber.Location = New System.Drawing.Point(141, 17)
        Me.NuUpDo_ToolNumber.Name = "NuUpDo_ToolNumber"
        Me.NuUpDo_ToolNumber.Size = New System.Drawing.Size(80, 20)
        Me.NuUpDo_ToolNumber.TabIndex = 12
        Me.NuUpDo_ToolNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Werkzeugnummer"
        '
        'TeBo_ToolName
        '
        Me.TeBo_ToolName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TeBo_ToolName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TeBo_ToolName.ForeColor = System.Drawing.Color.SteelBlue
        Me.TeBo_ToolName.Location = New System.Drawing.Point(94, 43)
        Me.TeBo_ToolName.Name = "TeBo_ToolName"
        Me.TeBo_ToolName.Size = New System.Drawing.Size(127, 20)
        Me.TeBo_ToolName.TabIndex = 10
        Me.TeBo_ToolName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Werkzeugname"
        '
        'CoBo_ToolCoating
        '
        Me.CoBo_ToolCoating.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CoBo_ToolCoating.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CoBo_ToolCoating.ForeColor = System.Drawing.Color.SteelBlue
        Me.CoBo_ToolCoating.FormattingEnabled = True
        Me.CoBo_ToolCoating.Items.AddRange(New Object() {"TiN", "TiCN"})
        Me.CoBo_ToolCoating.Location = New System.Drawing.Point(6, 291)
        Me.CoBo_ToolCoating.Name = "CoBo_ToolCoating"
        Me.CoBo_ToolCoating.Size = New System.Drawing.Size(212, 21)
        Me.CoBo_ToolCoating.TabIndex = 8
        Me.CoBo_ToolCoating.Text = "Beschichtung"
        '
        'CheBo_CenterCut
        '
        Me.CheBo_CenterCut.AutoSize = True
        Me.CheBo_CenterCut.Checked = True
        Me.CheBo_CenterCut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheBo_CenterCut.Location = New System.Drawing.Point(6, 318)
        Me.CheBo_CenterCut.Name = "CheBo_CenterCut"
        Me.CheBo_CenterCut.Size = New System.Drawing.Size(131, 17)
        Me.CheBo_CenterCut.TabIndex = 7
        Me.CheBo_CenterCut.Text = "über Mitte schneidend"
        Me.CheBo_CenterCut.UseVisualStyleBackColor = True
        '
        'NuUpDo_ToolDiameter
        '
        Me.NuUpDo_ToolDiameter.BackColor = System.Drawing.Color.WhiteSmoke
        Me.NuUpDo_ToolDiameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NuUpDo_ToolDiameter.ForeColor = System.Drawing.Color.SteelBlue
        Me.NuUpDo_ToolDiameter.Location = New System.Drawing.Point(138, 134)
        Me.NuUpDo_ToolDiameter.Name = "NuUpDo_ToolDiameter"
        Me.NuUpDo_ToolDiameter.Size = New System.Drawing.Size(80, 20)
        Me.NuUpDo_ToolDiameter.TabIndex = 6
        Me.NuUpDo_ToolDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Schaftdurchmesser D3"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Schaftdurchmesser D2"
        '
        'CoBo_ToolMaterial
        '
        Me.CoBo_ToolMaterial.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CoBo_ToolMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CoBo_ToolMaterial.ForeColor = System.Drawing.Color.SteelBlue
        Me.CoBo_ToolMaterial.FormattingEnabled = True
        Me.CoBo_ToolMaterial.Items.AddRange(New Object() {"HM", "HSS"})
        Me.CoBo_ToolMaterial.Location = New System.Drawing.Point(6, 264)
        Me.CoBo_ToolMaterial.Name = "CoBo_ToolMaterial"
        Me.CoBo_ToolMaterial.Size = New System.Drawing.Size(212, 21)
        Me.CoBo_ToolMaterial.TabIndex = 3
        Me.CoBo_ToolMaterial.Text = "Werkzeugwerkstoff"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 214)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Anzahl der Schneiden"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 240)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Schneidenlänge"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Durchmesser D1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Bu_DeleteTool)
        Me.GroupBox2.Controls.Add(Me.CheLiBo_ToolTypeFilter)
        Me.GroupBox2.Controls.Add(Me.Bu_ChangeTool)
        Me.GroupBox2.Controls.Add(Me.CoBo_Tools)
        Me.GroupBox2.Controls.Add(Me.Bu_NewTool)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(8, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 190)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Werkzeugwahl"
        '
        'Bu_DeleteTool
        '
        Me.Bu_DeleteTool.BackColor = System.Drawing.Color.GhostWhite
        Me.Bu_DeleteTool.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Bu_DeleteTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_DeleteTool.Location = New System.Drawing.Point(131, 131)
        Me.Bu_DeleteTool.Name = "Bu_DeleteTool"
        Me.Bu_DeleteTool.Size = New System.Drawing.Size(63, 51)
        Me.Bu_DeleteTool.TabIndex = 12
        Me.Bu_DeleteTool.Text = "löschen"
        Me.Bu_DeleteTool.UseVisualStyleBackColor = False
        '
        'CheLiBo_ToolTypeFilter
        '
        Me.CheLiBo_ToolTypeFilter.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CheLiBo_ToolTypeFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CheLiBo_ToolTypeFilter.ForeColor = System.Drawing.Color.MidnightBlue
        Me.CheLiBo_ToolTypeFilter.FormattingEnabled = True
        Me.CheLiBo_ToolTypeFilter.Items.AddRange(New Object() {"Schaftfräser", "Scheibenfräser", "Walzenfräser", "Sägeblatt", "Bohrer", "Zentrierbohrer", "Laser"})
        Me.CheLiBo_ToolTypeFilter.Location = New System.Drawing.Point(6, 21)
        Me.CheLiBo_ToolTypeFilter.Name = "CheLiBo_ToolTypeFilter"
        Me.CheLiBo_ToolTypeFilter.Size = New System.Drawing.Size(188, 77)
        Me.CheLiBo_ToolTypeFilter.TabIndex = 11
        '
        'Bu_ChangeTool
        '
        Me.Bu_ChangeTool.BackColor = System.Drawing.Color.GhostWhite
        Me.Bu_ChangeTool.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Bu_ChangeTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_ChangeTool.Location = New System.Drawing.Point(72, 131)
        Me.Bu_ChangeTool.Name = "Bu_ChangeTool"
        Me.Bu_ChangeTool.Size = New System.Drawing.Size(53, 51)
        Me.Bu_ChangeTool.TabIndex = 5
        Me.Bu_ChangeTool.Text = "ändern"
        Me.Bu_ChangeTool.UseVisualStyleBackColor = False
        '
        'CoBo_Tools
        '
        Me.CoBo_Tools.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CoBo_Tools.ForeColor = System.Drawing.Color.SteelBlue
        Me.CoBo_Tools.FormattingEnabled = True
        Me.CoBo_Tools.Location = New System.Drawing.Point(6, 104)
        Me.CoBo_Tools.Name = "CoBo_Tools"
        Me.CoBo_Tools.Size = New System.Drawing.Size(188, 21)
        Me.CoBo_Tools.TabIndex = 1
        Me.CoBo_Tools.Text = "Werkzeugwahl"
        '
        'Bu_NewTool
        '
        Me.Bu_NewTool.BackColor = System.Drawing.Color.GhostWhite
        Me.Bu_NewTool.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Bu_NewTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bu_NewTool.Location = New System.Drawing.Point(6, 131)
        Me.Bu_NewTool.Name = "Bu_NewTool"
        Me.Bu_NewTool.Size = New System.Drawing.Size(60, 51)
        Me.Bu_NewTool.TabIndex = 0
        Me.Bu_NewTool.Text = "neu"
        Me.Bu_NewTool.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(8, 209)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 343)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 596)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(532, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(26, 22)
        Me.ToolStripButton1.Text = "Ok"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripButton2.Text = "Abbrechen"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripButton3.Text = "Übernehmen"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripButton4.Text = "Hilfe"
        '
        'GrouBo_SystemColor
        '
        Me.GrouBo_SystemColor.Controls.Add(Me.Button2)
        Me.GrouBo_SystemColor.Controls.Add(Me.Button1)
        Me.GrouBo_SystemColor.Controls.Add(Me.ListBox1)
        Me.GrouBo_SystemColor.Location = New System.Drawing.Point(145, 6)
        Me.GrouBo_SystemColor.Name = "GrouBo_SystemColor"
        Me.GrouBo_SystemColor.Size = New System.Drawing.Size(371, 514)
        Me.GrouBo_SystemColor.TabIndex = 1
        Me.GrouBo_SystemColor.TabStop = False
        Me.GrouBo_SystemColor.Text = "Systemfarben"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Items.AddRange(New Object() {"Skizzenelement", "Schaltflächenfarbe "})
        Me.ListBox1.Location = New System.Drawing.Point(6, 19)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(243, 134)
        Me.ListBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(284, 486)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 22)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "übernehmen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(180, 486)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 22)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Werkseinstellung"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FM_Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(532, 621)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FM_Options"
        Me.Text = "Einstellungen"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TP_ToolLibrary.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NuUpDo_ToolLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_CuttingLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_NumberOfCuttingEdges, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_ShaftDiameter2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_ShaftDiameter1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_ToolNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuUpDo_ToolDiameter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GrouBo_SystemColor.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TP_ToolLibrary As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CoBo_Tools As System.Windows.Forms.ComboBox
    Friend WithEvents Bu_NewTool As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CoBo_ToolMaterial As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CheLiBo_WorkPieceHardness As System.Windows.Forms.CheckedListBox
    Friend WithEvents TeBo_ToolName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CoBo_ToolCoating As System.Windows.Forms.ComboBox
    Friend WithEvents CheBo_CenterCut As System.Windows.Forms.CheckBox
    Friend WithEvents NuUpDo_ToolDiameter As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CheBo_InnerCooling As System.Windows.Forms.CheckBox
    Friend WithEvents NuUpDo_ShaftDiameter2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NuUpDo_ShaftDiameter1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NuUpDo_ToolNumber As System.Windows.Forms.NumericUpDown
    Friend WithEvents Bu_ChangeTool As System.Windows.Forms.Button
    Friend WithEvents CoBo_ToolType As System.Windows.Forms.ComboBox
    Friend WithEvents CheLiBo_ToolTypeFilter As System.Windows.Forms.CheckedListBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents NuUpDo_NumberOfCuttingEdges As System.Windows.Forms.NumericUpDown
    Friend WithEvents NuUpDo_CuttingLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TreeView2 As System.Windows.Forms.TreeView
    Friend WithEvents NuUpDo_ToolLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Bu_DeleteTool As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GrouBo_SystemColor As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents ColorDialog1 As ColorDialog
End Class
