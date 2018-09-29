<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PartViewer
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PartViewer))
        Me.FeatureManager = New System.Windows.Forms.TabControl()
        Me.TabPage_Feature = New System.Windows.Forms.TabPage()
        Me.TreVi_Feature = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SkizzeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SkizzeBeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NCProgrammErstellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZeigeTaschenbahnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage_CAM = New System.Windows.Forms.TabPage()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.ImLi_CamTreVi = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage_Properties = New System.Windows.Forms.TabPage()
        Me.FeatureManager.SuspendLayout()
        Me.TabPage_Feature.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage_CAM.SuspendLayout()
        Me.SuspendLayout()
        '
        'FeatureManager
        '
        resources.ApplyResources(Me.FeatureManager, "FeatureManager")
        Me.FeatureManager.Controls.Add(Me.TabPage_Feature)
        Me.FeatureManager.Controls.Add(Me.TabPage_CAM)
        Me.FeatureManager.Controls.Add(Me.TabPage_Properties)
        Me.FeatureManager.ImageList = Me.ImageList1
        Me.FeatureManager.Name = "FeatureManager"
        Me.FeatureManager.SelectedIndex = 0
        '
        'TabPage_Feature
        '
        Me.TabPage_Feature.BackColor = System.Drawing.Color.Lavender
        Me.TabPage_Feature.Controls.Add(Me.TreVi_Feature)
        resources.ApplyResources(Me.TabPage_Feature, "TabPage_Feature")
        Me.TabPage_Feature.Name = "TabPage_Feature"
        '
        'TreVi_Feature
        '
        Me.TreVi_Feature.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TreVi_Feature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreVi_Feature.ContextMenuStrip = Me.ContextMenuStrip1
        resources.ApplyResources(Me.TreVi_Feature, "TreVi_Feature")
        Me.TreVi_Feature.FullRowSelect = True
        Me.TreVi_Feature.ImageList = Me.ImageList1
        Me.TreVi_Feature.Name = "TreVi_Feature"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SkizzeToolStripMenuItem, Me.SkizzeBeendenToolStripMenuItem, Me.ToolStripMenuItem1, Me.LöschenToolStripMenuItem, Me.ToolStripSeparator1, Me.NCProgrammErstellenToolStripMenuItem, Me.ZeigeTaschenbahnToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        '
        'SkizzeToolStripMenuItem
        '
        Me.SkizzeToolStripMenuItem.Name = "SkizzeToolStripMenuItem"
        resources.ApplyResources(Me.SkizzeToolStripMenuItem, "SkizzeToolStripMenuItem")
        '
        'SkizzeBeendenToolStripMenuItem
        '
        Me.SkizzeBeendenToolStripMenuItem.Name = "SkizzeBeendenToolStripMenuItem"
        resources.ApplyResources(Me.SkizzeBeendenToolStripMenuItem, "SkizzeBeendenToolStripMenuItem")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Checked = True
        Me.ToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'LöschenToolStripMenuItem
        '
        Me.LöschenToolStripMenuItem.Name = "LöschenToolStripMenuItem"
        resources.ApplyResources(Me.LöschenToolStripMenuItem, "LöschenToolStripMenuItem")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'NCProgrammErstellenToolStripMenuItem
        '
        Me.NCProgrammErstellenToolStripMenuItem.Name = "NCProgrammErstellenToolStripMenuItem"
        resources.ApplyResources(Me.NCProgrammErstellenToolStripMenuItem, "NCProgrammErstellenToolStripMenuItem")
        '
        'ZeigeTaschenbahnToolStripMenuItem
        '
        Me.ZeigeTaschenbahnToolStripMenuItem.Name = "ZeigeTaschenbahnToolStripMenuItem"
        resources.ApplyResources(Me.ZeigeTaschenbahnToolStripMenuItem, "ZeigeTaschenbahnToolStripMenuItem")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "SWXUiTreeView.png")
        Me.ImageList1.Images.SetKeyName(1, "bossfeature.png")
        Me.ImageList1.Images.SetKeyName(2, "i_assemblypart_20.png")
        Me.ImageList1.Images.SetKeyName(3, "move_no_solve.gif")
        Me.ImageList1.Images.SetKeyName(4, "setorigin_a.bmp")
        Me.ImageList1.Images.SetKeyName(5, "sketch.gif")
        Me.ImageList1.Images.SetKeyName(6, "sketch_active.gif")
        Me.ImageList1.Images.SetKeyName(7, "sketch_nonvisible.gif")
        Me.ImageList1.Images.SetKeyName(8, "imported_active.gif")
        Me.ImageList1.Images.SetKeyName(9, "imported_not active.gif")
        Me.ImageList1.Images.SetKeyName(10, "imported_active selected.gif")
        Me.ImageList1.Images.SetKeyName(11, "imported_not active but selected.gif")
        '
        'TabPage_CAM
        '
        Me.TabPage_CAM.BackColor = System.Drawing.Color.Lavender
        Me.TabPage_CAM.Controls.Add(Me.TreeView2)
        resources.ApplyResources(Me.TabPage_CAM, "TabPage_CAM")
        Me.TabPage_CAM.Name = "TabPage_CAM"
        '
        'TreeView2
        '
        Me.TreeView2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TreeView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.TreeView2, "TreeView2")
        Me.TreeView2.ImageList = Me.ImLi_CamTreVi
        Me.TreeView2.Name = "TreeView2"
        '
        'ImLi_CamTreVi
        '
        Me.ImLi_CamTreVi.ImageStream = CType(resources.GetObject("ImLi_CamTreVi.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImLi_CamTreVi.TransparentColor = System.Drawing.Color.Transparent
        Me.ImLi_CamTreVi.Images.SetKeyName(0, "cam3d_visible.gif")
        Me.ImLi_CamTreVi.Images.SetKeyName(1, "cam3d_invisible.gif")
        Me.ImLi_CamTreVi.Images.SetKeyName(2, "cambore_invisible.gif")
        Me.ImLi_CamTreVi.Images.SetKeyName(3, "cambore_visible.gif")
        Me.ImLi_CamTreVi.Images.SetKeyName(4, "camfacemilling_invisible.gif")
        Me.ImLi_CamTreVi.Images.SetKeyName(5, "camfacemilling_visible.gif")
        Me.ImLi_CamTreVi.Images.SetKeyName(6, "campocket_invisible.gif")
        Me.ImLi_CamTreVi.Images.SetKeyName(7, "campocket_visible.gif")
        '
        'TabPage_Properties
        '
        resources.ApplyResources(Me.TabPage_Properties, "TabPage_Properties")
        Me.TabPage_Properties.BackColor = System.Drawing.Color.GhostWhite
        Me.TabPage_Properties.Name = "TabPage_Properties"
        '
        'PartViewer
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.Controls.Add(Me.FeatureManager)
        Me.Name = "PartViewer"
        Me.FeatureManager.ResumeLayout(False)
        Me.TabPage_Feature.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage_CAM.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FeatureManager As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_Feature As System.Windows.Forms.TabPage
    Friend WithEvents TabPage_CAM As System.Windows.Forms.TabPage
    Friend WithEvents TreVi_Feature As System.Windows.Forms.TreeView
    Friend WithEvents TabPage_Properties As System.Windows.Forms.TabPage
    Friend WithEvents TreeView2 As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SkizzeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SkizzeBeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NCProgrammErstellenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZeigeTaschenbahnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImLi_CamTreVi As ImageList
End Class
