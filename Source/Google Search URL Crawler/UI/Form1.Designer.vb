<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ButtonSearch = New System.Windows.Forms.Button()
        Me.DataGridViewSearchResults = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlainTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertyGridSearchOptions = New System.Windows.Forms.PropertyGrid()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CircularProgressBar1 = New CircularProgressBar.CircularProgressBar()
        Me.LabelResults = New System.Windows.Forms.Label()
        Me.TextBoxQuery = New System.Windows.Forms.TextBox()
        CType(Me.DataGridViewSearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonSearch
        '
        Me.ButtonSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonSearch.Location = New System.Drawing.Point(12, 406)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSearch.TabIndex = 1
        Me.ButtonSearch.Text = "Search"
        Me.ButtonSearch.UseVisualStyleBackColor = True
        '
        'DataGridViewSearchResults
        '
        Me.DataGridViewSearchResults.AllowUserToAddRows = False
        Me.DataGridViewSearchResults.AllowUserToDeleteRows = False
        Me.DataGridViewSearchResults.AllowUserToOrderColumns = True
        Me.DataGridViewSearchResults.AllowUserToResizeRows = False
        Me.DataGridViewSearchResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewSearchResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewSearchResults.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewSearchResults.Name = "DataGridViewSearchResults"
        Me.DataGridViewSearchResults.ReadOnly = True
        Me.DataGridViewSearchResults.RowHeadersVisible = False
        Me.DataGridViewSearchResults.RowHeadersWidth = 50
        Me.DataGridViewSearchResults.RowTemplate.ReadOnly = True
        Me.DataGridViewSearchResults.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewSearchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewSearchResults.ShowCellToolTips = False
        Me.DataGridViewSearchResults.ShowEditingIcon = False
        Me.DataGridViewSearchResults.Size = New System.Drawing.Size(579, 376)
        Me.DataGridViewSearchResults.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(884, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearResultsToolStripMenuItem, Me.ExportResultsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ClearResultsToolStripMenuItem
        '
        Me.ClearResultsToolStripMenuItem.Enabled = False
        Me.ClearResultsToolStripMenuItem.Name = "ClearResultsToolStripMenuItem"
        Me.ClearResultsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ClearResultsToolStripMenuItem.Text = "Clear Results"
        '
        'ExportResultsToolStripMenuItem
        '
        Me.ExportResultsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlainTextToolStripMenuItem, Me.CSVToolStripMenuItem})
        Me.ExportResultsToolStripMenuItem.Enabled = False
        Me.ExportResultsToolStripMenuItem.Name = "ExportResultsToolStripMenuItem"
        Me.ExportResultsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExportResultsToolStripMenuItem.Text = "Export Results As..."
        '
        'PlainTextToolStripMenuItem
        '
        Me.PlainTextToolStripMenuItem.Name = "PlainTextToolStripMenuItem"
        Me.PlainTextToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PlainTextToolStripMenuItem.Text = "Plain Text"
        '
        'CSVToolStripMenuItem
        '
        Me.CSVToolStripMenuItem.Name = "CSVToolStripMenuItem"
        Me.CSVToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CSVToolStripMenuItem.Text = "CSV"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.AboutToolStripMenuItem.Text = "About..."
        '
        'PropertyGridSearchOptions
        '
        Me.PropertyGridSearchOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGridSearchOptions.Location = New System.Drawing.Point(0, 0)
        Me.PropertyGridSearchOptions.Name = "PropertyGridSearchOptions"
        Me.PropertyGridSearchOptions.Size = New System.Drawing.Size(277, 376)
        Me.PropertyGridSearchOptions.TabIndex = 0
        Me.PropertyGridSearchOptions.ToolbarVisible = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PropertyGridSearchOptions)
        Me.SplitContainer1.Panel1MinSize = 150
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CircularProgressBar1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridViewSearchResults)
        Me.SplitContainer1.Panel2MinSize = 200
        Me.SplitContainer1.Size = New System.Drawing.Size(860, 376)
        Me.SplitContainer1.SplitterDistance = 277
        Me.SplitContainer1.TabIndex = 6
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 354)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(579, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(16, 17)
        Me.ToolStripStatusLabel1.Text = "..."
        '
        'CircularProgressBar1
        '
        Me.CircularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner
        Me.CircularProgressBar1.AnimationSpeed = 500
        Me.CircularProgressBar1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.CircularProgressBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold)
        Me.CircularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CircularProgressBar1.InnerColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CircularProgressBar1.InnerMargin = 2
        Me.CircularProgressBar1.InnerWidth = -1
        Me.CircularProgressBar1.Location = New System.Drawing.Point(135, 42)
        Me.CircularProgressBar1.MarqueeAnimationSpeed = 2000
        Me.CircularProgressBar1.Name = "CircularProgressBar1"
        Me.CircularProgressBar1.OuterColor = System.Drawing.Color.Gray
        Me.CircularProgressBar1.OuterMargin = -25
        Me.CircularProgressBar1.OuterWidth = 26
        Me.CircularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.CircularProgressBar1.ProgressWidth = 25
        Me.CircularProgressBar1.SecondaryFont = New System.Drawing.Font("Microsoft Sans Serif", 36.0!)
        Me.CircularProgressBar1.Size = New System.Drawing.Size(300, 290)
        Me.CircularProgressBar1.StartAngle = 270
        Me.CircularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.CircularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.CircularProgressBar1.SubscriptMargin = New System.Windows.Forms.Padding(10, -35, 0, 0)
        Me.CircularProgressBar1.SubscriptText = ""
        Me.CircularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.CircularProgressBar1.SuperscriptMargin = New System.Windows.Forms.Padding(10, 35, 0, 0)
        Me.CircularProgressBar1.SuperscriptText = ""
        Me.CircularProgressBar1.TabIndex = 1
        Me.CircularProgressBar1.Text = "Please Wait"
        Me.CircularProgressBar1.TextMargin = New System.Windows.Forms.Padding(8, 8, 0, 0)
        Me.CircularProgressBar1.Value = 68
        '
        'LabelResults
        '
        Me.LabelResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelResults.AutoSize = True
        Me.LabelResults.Location = New System.Drawing.Point(758, 411)
        Me.LabelResults.Name = "LabelResults"
        Me.LabelResults.Size = New System.Drawing.Size(100, 13)
        Me.LabelResults.TabIndex = 3
        Me.LabelResults.Text = "Displaying 0 results."
        '
        'TextBoxQuery
        '
        Me.TextBoxQuery.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxQuery.Location = New System.Drawing.Point(93, 408)
        Me.TextBoxQuery.Name = "TextBoxQuery"
        Me.TextBoxQuery.ReadOnly = True
        Me.TextBoxQuery.Size = New System.Drawing.Size(654, 20)
        Me.TextBoxQuery.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 441)
        Me.Controls.Add(Me.TextBoxQuery)
        Me.Controls.Add(Me.LabelResults)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ButtonSearch)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Google Search URL Crawler"
        CType(Me.DataGridViewSearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonSearch As Button
    Friend WithEvents DataGridViewSearchResults As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportResultsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PropertyGridSearchOptions As PropertyGrid
    Friend WithEvents PlainTextToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSVToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents CircularProgressBar1 As CircularProgressBar.CircularProgressBar
    Friend WithEvents LabelResults As Label
    Friend WithEvents ClearResultsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextBoxQuery As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
End Class
