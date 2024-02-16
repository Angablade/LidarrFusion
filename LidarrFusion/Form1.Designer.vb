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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        StatusStrip1 = New StatusStrip()
        ToolStripStatusLabel1 = New ToolStripStatusLabel()
        ToolStrip1 = New ToolStrip()
        ToolStripDropDownButton1 = New ToolStripDropDownButton()
        LidarrToolStripMenuItem = New ToolStripMenuItem()
        SetURLToolStripMenuItem = New ToolStripMenuItem()
        SetAPIKeyToolStripMenuItem = New ToolStripMenuItem()
        SetRootPathToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem4 = New ToolStripSeparator()
        RequestRootPathToolStripMenuItem = New ToolStripMenuItem()
        FFmpegToolStripMenuItem = New ToolStripMenuItem()
        FfmpegexeToolStripMenuItem = New ToolStripMenuItem()
        FfprobeexeToolStripMenuItem = New ToolStripMenuItem()
        FfplayexeToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripSeparator()
        DownloadLinkToolStripMenuItem = New ToolStripMenuItem()
        YoutubeDLPToolStripMenuItem = New ToolStripMenuItem()
        PrependSearchTextToolStripMenuItem = New ToolStripMenuItem()
        SkipExistingFilesToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem5 = New ToolStripSeparator()
        YtdlpexeToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripSeparator()
        DownloadHereToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem3 = New ToolStripSeparator()
        RunSetupWizardToolStripMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        ToolStripButton1 = New ToolStripButton()
        ToolStripButton2 = New ToolStripButton()
        ToolStripButton3 = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        ToolStripTextBox1 = New ToolStripTextBox()
        ToolStripSeparator2 = New ToolStripSeparator()
        ListView1 = New ListView()
        ColumnHeader3 = New ColumnHeader()
        ColumnHeader5 = New ColumnHeader()
        ColumnHeader6 = New ColumnHeader()
        ColumnHeader7 = New ColumnHeader()
        ColumnHeader8 = New ColumnHeader()
        ColumnHeader9 = New ColumnHeader()
        OpenFileDialog1 = New OpenFileDialog()
        BackgroundWorker1 = New ComponentModel.BackgroundWorker()
        BackgroundWorker2 = New ComponentModel.BackgroundWorker()
        BackgroundWorker3 = New ComponentModel.BackgroundWorker()
        AboutToolStripMenuItem = New ToolStripMenuItem()
        StatusStrip1.SuspendLayout()
        ToolStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.Items.AddRange(New ToolStripItem() {ToolStripStatusLabel1})
        StatusStrip1.Location = New Point(0, 580)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(1212, 22)
        StatusStrip1.TabIndex = 0
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' ToolStripStatusLabel1
        ' 
        ToolStripStatusLabel1.Font = New Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point)
        ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        ToolStripStatusLabel1.Size = New Size(0, 17)
        ToolStripStatusLabel1.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripDropDownButton1, ToolStripButton1, ToolStripButton2, ToolStripButton3, ToolStripSeparator1, ToolStripTextBox1, ToolStripSeparator2})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(1212, 25)
        ToolStrip1.TabIndex = 1
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' ToolStripDropDownButton1
        ' 
        ToolStripDropDownButton1.Alignment = ToolStripItemAlignment.Right
        ToolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripDropDownButton1.DropDownItems.AddRange(New ToolStripItem() {LidarrToolStripMenuItem, FFmpegToolStripMenuItem, YoutubeDLPToolStripMenuItem, ToolStripMenuItem3, RunSetupWizardToolStripMenuItem, AboutToolStripMenuItem, ExitToolStripMenuItem})
        ToolStripDropDownButton1.Image = My.Resources.Resources._6002fa9051c2ec00048c6c7a
        ToolStripDropDownButton1.ImageTransparentColor = Color.Magenta
        ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        ToolStripDropDownButton1.RightToLeft = RightToLeft.Yes
        ToolStripDropDownButton1.Size = New Size(29, 22)
        ToolStripDropDownButton1.Text = "Settings"
        ' 
        ' LidarrToolStripMenuItem
        ' 
        LidarrToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {SetURLToolStripMenuItem, SetAPIKeyToolStripMenuItem, SetRootPathToolStripMenuItem, ToolStripMenuItem4, RequestRootPathToolStripMenuItem})
        LidarrToolStripMenuItem.Image = My.Resources.Resources._28475832
        LidarrToolStripMenuItem.Name = "LidarrToolStripMenuItem"
        LidarrToolStripMenuItem.Size = New Size(180, 22)
        LidarrToolStripMenuItem.Text = "Lidarr"
        ' 
        ' SetURLToolStripMenuItem
        ' 
        SetURLToolStripMenuItem.Image = My.Resources.Resources._5220478
        SetURLToolStripMenuItem.Name = "SetURLToolStripMenuItem"
        SetURLToolStripMenuItem.Size = New Size(171, 22)
        SetURLToolStripMenuItem.Text = "Set URL"
        ' 
        ' SetAPIKeyToolStripMenuItem
        ' 
        SetAPIKeyToolStripMenuItem.Image = My.Resources.Resources._4524213
        SetAPIKeyToolStripMenuItem.Name = "SetAPIKeyToolStripMenuItem"
        SetAPIKeyToolStripMenuItem.Size = New Size(171, 22)
        SetAPIKeyToolStripMenuItem.Text = "Set API Key"
        ' 
        ' SetRootPathToolStripMenuItem
        ' 
        SetRootPathToolStripMenuItem.Image = My.Resources.Resources._1017443
        SetRootPathToolStripMenuItem.Name = "SetRootPathToolStripMenuItem"
        SetRootPathToolStripMenuItem.Size = New Size(171, 22)
        SetRootPathToolStripMenuItem.Text = "Set Root Path"
        ' 
        ' ToolStripMenuItem4
        ' 
        ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        ToolStripMenuItem4.Size = New Size(168, 6)
        ' 
        ' RequestRootPathToolStripMenuItem
        ' 
        RequestRootPathToolStripMenuItem.Image = My.Resources.Resources._5201246
        RequestRootPathToolStripMenuItem.Name = "RequestRootPathToolStripMenuItem"
        RequestRootPathToolStripMenuItem.Size = New Size(171, 22)
        RequestRootPathToolStripMenuItem.Text = "Request Root Path"
        ' 
        ' FFmpegToolStripMenuItem
        ' 
        FFmpegToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {FfmpegexeToolStripMenuItem, FfprobeexeToolStripMenuItem, FfplayexeToolStripMenuItem, ToolStripMenuItem1, DownloadLinkToolStripMenuItem})
        FFmpegToolStripMenuItem.Image = My.Resources.Resources._1200px_FFmpeg_icon_svg
        FFmpegToolStripMenuItem.Name = "FFmpegToolStripMenuItem"
        FFmpegToolStripMenuItem.Size = New Size(180, 22)
        FFmpegToolStripMenuItem.Text = "FFmpeg"
        ' 
        ' FfmpegexeToolStripMenuItem
        ' 
        FfmpegexeToolStripMenuItem.Image = My.Resources.Resources._1200px_FFmpeg_icon_svg
        FfmpegexeToolStripMenuItem.Name = "FfmpegexeToolStripMenuItem"
        FfmpegexeToolStripMenuItem.Size = New Size(138, 22)
        FfmpegexeToolStripMenuItem.Text = "ffmpeg.exe"
        ' 
        ' FfprobeexeToolStripMenuItem
        ' 
        FfprobeexeToolStripMenuItem.Image = My.Resources.Resources.image
        FfprobeexeToolStripMenuItem.Name = "FfprobeexeToolStripMenuItem"
        FfprobeexeToolStripMenuItem.Size = New Size(138, 22)
        FfprobeexeToolStripMenuItem.Text = "ffprobe.exe"
        ' 
        ' FfplayexeToolStripMenuItem
        ' 
        FfplayexeToolStripMenuItem.Image = My.Resources.Resources.ffmpeg_icon
        FfplayexeToolStripMenuItem.Name = "FfplayexeToolStripMenuItem"
        FfplayexeToolStripMenuItem.Size = New Size(138, 22)
        FfplayexeToolStripMenuItem.Text = "ffplay.exe"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(135, 6)
        ' 
        ' DownloadLinkToolStripMenuItem
        ' 
        DownloadLinkToolStripMenuItem.Image = My.Resources.Resources.download_2_xxl1
        DownloadLinkToolStripMenuItem.Name = "DownloadLinkToolStripMenuItem"
        DownloadLinkToolStripMenuItem.Size = New Size(138, 22)
        DownloadLinkToolStripMenuItem.Text = "-Download-"
        ' 
        ' YoutubeDLPToolStripMenuItem
        ' 
        YoutubeDLPToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {PrependSearchTextToolStripMenuItem, SkipExistingFilesToolStripMenuItem, ToolStripMenuItem5, YtdlpexeToolStripMenuItem, ToolStripMenuItem2, DownloadHereToolStripMenuItem})
        YoutubeDLPToolStripMenuItem.Image = My.Resources.Resources.b6a8d716_9c7b_40ec_bc44_6422d8b741a0
        YoutubeDLPToolStripMenuItem.Name = "YoutubeDLPToolStripMenuItem"
        YoutubeDLPToolStripMenuItem.Size = New Size(180, 22)
        YoutubeDLPToolStripMenuItem.Text = "Youtube-DLP"
        ' 
        ' PrependSearchTextToolStripMenuItem
        ' 
        PrependSearchTextToolStripMenuItem.Image = My.Resources.Resources.images
        PrependSearchTextToolStripMenuItem.Name = "PrependSearchTextToolStripMenuItem"
        PrependSearchTextToolStripMenuItem.Size = New Size(176, 22)
        PrependSearchTextToolStripMenuItem.Text = "Append search text"
        ' 
        ' SkipExistingFilesToolStripMenuItem
        ' 
        SkipExistingFilesToolStripMenuItem.CheckOnClick = True
        SkipExistingFilesToolStripMenuItem.Image = My.Resources.Resources.apps_55042_2333d5c4_cd0f_45a1_bdb7_57a4b30a8cf9_4a0eb3da_0ea9_4903_acc8_5ba38654775e
        SkipExistingFilesToolStripMenuItem.Name = "SkipExistingFilesToolStripMenuItem"
        SkipExistingFilesToolStripMenuItem.Size = New Size(176, 22)
        SkipExistingFilesToolStripMenuItem.Text = "Skip Existing Files"
        ' 
        ' ToolStripMenuItem5
        ' 
        ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        ToolStripMenuItem5.Size = New Size(173, 6)
        ' 
        ' YtdlpexeToolStripMenuItem
        ' 
        YtdlpexeToolStripMenuItem.Image = My.Resources.Resources.b6a8d716_9c7b_40ec_bc44_6422d8b741a0
        YtdlpexeToolStripMenuItem.Name = "YtdlpexeToolStripMenuItem"
        YtdlpexeToolStripMenuItem.Size = New Size(176, 22)
        YtdlpexeToolStripMenuItem.Text = "yt-dlp.exe"
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(173, 6)
        ' 
        ' DownloadHereToolStripMenuItem
        ' 
        DownloadHereToolStripMenuItem.Image = My.Resources.Resources.download_2_xxl
        DownloadHereToolStripMenuItem.Name = "DownloadHereToolStripMenuItem"
        DownloadHereToolStripMenuItem.Size = New Size(176, 22)
        DownloadHereToolStripMenuItem.Text = "-Download-"
        ' 
        ' ToolStripMenuItem3
        ' 
        ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        ToolStripMenuItem3.Size = New Size(177, 6)
        ' 
        ' RunSetupWizardToolStripMenuItem
        ' 
        RunSetupWizardToolStripMenuItem.Image = My.Resources.Resources._477154
        RunSetupWizardToolStripMenuItem.Name = "RunSetupWizardToolStripMenuItem"
        RunSetupWizardToolStripMenuItem.Size = New Size(180, 22)
        RunSetupWizardToolStripMenuItem.Text = "Run Setup Wizard"
        RunSetupWizardToolStripMenuItem.Visible = False
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Image = My.Resources.Resources._7b82479ee939a7b4ad45e26cbab28c02
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(180, 22)
        ExitToolStripMenuItem.Text = "Exit"
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton1.Image = My.Resources.Resources._28475832
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(23, 22)
        ToolStripButton1.Text = "Grab Missing"
        ' 
        ' ToolStripButton2
        ' 
        ToolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton2.Image = My.Resources.Resources.b6a8d716_9c7b_40ec_bc44_6422d8b741a0
        ToolStripButton2.ImageTransparentColor = Color.Magenta
        ToolStripButton2.Name = "ToolStripButton2"
        ToolStripButton2.Size = New Size(23, 22)
        ToolStripButton2.Text = "Download Missing"
        ' 
        ' ToolStripButton3
        ' 
        ToolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton3.Image = My.Resources.Resources.apps_33412_13870881915102457_c35d48f2_3399_41e9_aff3_45a4e8871203
        ToolStripButton3.ImageTransparentColor = Color.Magenta
        ToolStripButton3.Name = "ToolStripButton3"
        ToolStripButton3.Size = New Size(23, 22)
        ToolStripButton3.Text = "Write Tags"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 25)
        ' 
        ' ToolStripTextBox1
        ' 
        ToolStripTextBox1.BorderStyle = BorderStyle.None
        ToolStripTextBox1.Name = "ToolStripTextBox1"
        ToolStripTextBox1.Size = New Size(300, 25)
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 25)
        ' 
        ' ListView1
        ' 
        ListView1.BorderStyle = BorderStyle.FixedSingle
        ListView1.Columns.AddRange(New ColumnHeader() {ColumnHeader3, ColumnHeader5, ColumnHeader6, ColumnHeader7, ColumnHeader8, ColumnHeader9})
        ListView1.Dock = DockStyle.Fill
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.Location = New Point(0, 25)
        ListView1.MultiSelect = False
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(1212, 555)
        ListView1.TabIndex = 2
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' ColumnHeader3
        ' 
        ColumnHeader3.Text = "Artist"
        ColumnHeader3.Width = 120
        ' 
        ' ColumnHeader5
        ' 
        ColumnHeader5.Text = "Album"
        ColumnHeader5.Width = 120
        ' 
        ' ColumnHeader6
        ' 
        ColumnHeader6.Text = "Track"
        ColumnHeader6.Width = 120
        ' 
        ' ColumnHeader7
        ' 
        ColumnHeader7.Text = "ID"
        ' 
        ' ColumnHeader8
        ' 
        ColumnHeader8.Text = "Youtube"
        ColumnHeader8.Width = 240
        ' 
        ' ColumnHeader9
        ' 
        ColumnHeader9.Text = "Path"
        ColumnHeader9.Width = 500
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' BackgroundWorker1
        ' 
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True
        ' 
        ' BackgroundWorker2
        ' 
        BackgroundWorker2.WorkerReportsProgress = True
        BackgroundWorker2.WorkerSupportsCancellation = True
        ' 
        ' BackgroundWorker3
        ' 
        BackgroundWorker3.WorkerReportsProgress = True
        BackgroundWorker3.WorkerSupportsCancellation = True
        ' 
        ' AboutToolStripMenuItem
        ' 
        AboutToolStripMenuItem.Image = My.Resources.Resources._78911_200
        AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        AboutToolStripMenuItem.Size = New Size(180, 22)
        AboutToolStripMenuItem.Text = "About"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1212, 602)
        Controls.Add(ListView1)
        Controls.Add(ToolStrip1)
        Controls.Add(StatusStrip1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        Text = "LidarrFusion"
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents LidarrToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetURLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetAPIKeyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FFmpegToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FfmpegexeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FfprobeexeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FfplayexeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents DownloadLinkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents YoutubeDLPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents YtdlpexeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents DownloadHereToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetRootPathToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents RequestRootPathToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RunSetupWizardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents PrependSearchTextToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker3 As System.ComponentModel.BackgroundWorker
    Friend WithEvents SkipExistingFilesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
End Class
