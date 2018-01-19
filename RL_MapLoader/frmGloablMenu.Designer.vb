<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGloMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGloMenu))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblLoad = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnNewSng = New System.Windows.Forms.Button()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.btnNewSng)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnChange)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(121, 68)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(426, 132)
        Me.FlowLayoutPanel1.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Motorwerk", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(634, 34)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "AngryCarrot's Rocket League Map Loader"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLoad
        '
        Me.lblLoad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoad.Location = New System.Drawing.Point(0, 0)
        Me.lblLoad.Name = "lblLoad"
        Me.lblLoad.Size = New System.Drawing.Size(662, 206)
        Me.lblLoad.TabIndex = 21
        Me.lblLoad.Text = "Loading..."
        Me.lblLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblLoad.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(662, 24)
        Me.MenuStrip1.TabIndex = 22
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePathToolStripMenuItem, Me.HelpToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ChangePathToolStripMenuItem
        '
        Me.ChangePathToolStripMenuItem.Name = "ChangePathToolStripMenuItem"
        Me.ChangePathToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ChangePathToolStripMenuItem.Text = "Change Path"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'btnNewSng
        '
        Me.btnNewSng.BackColor = System.Drawing.SystemColors.Control
        Me.btnNewSng.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnNewSng.FlatAppearance.BorderSize = 2
        Me.btnNewSng.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnNewSng.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnNewSng.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnNewSng.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNewSng.Image = Global.RL_MapLoader.My.Resources.Resources.Single_File
        Me.btnNewSng.Location = New System.Drawing.Point(3, 3)
        Me.btnNewSng.Name = "btnNewSng"
        Me.btnNewSng.Size = New System.Drawing.Size(136, 126)
        Me.btnNewSng.TabIndex = 22
        Me.btnNewSng.Text = "Single File Map Loader (No Restart)"
        Me.btnNewSng.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNewSng.UseVisualStyleBackColor = False
        '
        'btnChange
        '
        Me.btnChange.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnChange.BackColor = System.Drawing.SystemColors.Control
        Me.btnChange.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnChange.FlatAppearance.BorderSize = 2
        Me.btnChange.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnChange.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnChange.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChange.Image = Global.RL_MapLoader.My.Resources.Resources.multifile
        Me.btnChange.Location = New System.Drawing.Point(145, 3)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(136, 126)
        Me.btnChange.TabIndex = 21
        Me.btnChange.Text = "Multi File Map Loader (Beta)(Restart Required)"
        Me.btnChange.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnChange.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Button1.FlatAppearance.BorderSize = 2
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Image = Global.RL_MapLoader.My.Resources.Resources.browse
        Me.Button1.Location = New System.Drawing.Point(287, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 126)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Browse Maps" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "rocketleaguemods.com" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmGloMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(662, 206)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblLoad)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGloMenu"
        Me.Text = "Menu"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnNewSng As Button
    Friend WithEvents btnChange As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents lblLoad As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangePathToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
End Class
