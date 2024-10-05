Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.Runtime.Intrinsics.Arm
Imports System.Security.Policy
Imports Newtonsoft.Json.Linq
Imports TagLib
Imports System.Windows.Forms.VisualStyles
Imports System.ComponentModel
Imports System.Collections.Concurrent

Public Class Form1
    Private WithEvents webClient As New WebClient()
    Private WithEvents contextMenuListView As New ContextMenuStrip()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.firstrun = True Then
            My.Settings.firstrun = False
            My.Settings.Save()
            Dim X As MsgBoxResult = MsgBox("Welcome To Lidarr Fusion! Would you like to run the setup wizard?", MsgBoxStyle.YesNo, "LidarrFusion")
            If X = MsgBoxResult.Yes Then
                setupwizard()
            End If
        End If
        CheckForIllegalCrossThreadCalls = False
        SkipExistingFilesToolStripMenuItem.Checked = My.Settings.skipexist
        RequestInterventionsToolStripMenuItem.Checked = My.Settings.intervent
        SkipYoutubeSearchToolStripMenuItem.Checked = My.Settings.skipyoutube
        ToolStripMenuItem7.Checked = My.Settings.youtubemusic

        Dim icon2 As New PictureBox()
        AddHandler icon2.Click, AddressOf ToolStripTextBox1_Click
        icon2.Image = My.Resources.search_icon_sign_symbol_design_free_png
        icon2.SizeMode = PictureBoxSizeMode.StretchImage
        icon2.Dock = DockStyle.Right
        icon2.Width = 18
        icon2.BackColor = Color.Transparent
        icon2.Margin = New Padding(0, 10, icon2.Width, 10)
        ToolStripTextBox1.Control.Controls.Add(icon2)

        ListView1.ContextMenuStrip = contextMenuListView
        contextMenuListView.Items.Add("Download", Nothing, AddressOf DownloadMenuItem_Click)
        contextMenuListView.Items.Add("Write Tags", Nothing, AddressOf WriteTagsMenuItem_Click)
        contextMenuListView.Items.Add("Edit Item", Nothing, AddressOf EditTagsMenuItem_Click)
        contextMenuListView.Items.Add("Open URL", Nothing, AddressOf OpenUrlMenuItem_Click)
        contextMenuListView.Items.Add("Remove", Nothing, AddressOf RemoveMenuItem_Click)
    End Sub
    Private Sub setupwizard()
        Dim x As MsgBoxResult
        MsgBox("Lidarr Section!")
        SetURLToolStripMenuItem_Click(Me, Nothing)
        SetAPIKeyToolStripMenuItem_Click(Me, Nothing)

        x = MsgBox("Is the root path for lidarr Mapped locally?", MsgBoxStyle.YesNo, "LidarrFusion")
        If x = MsgBoxResult.Yes Then
            x = MsgBox("Do you want LidarrFusion to grab the root path from lidarr?", MsgBoxStyle.YesNo, "LidarrFusion")
            If x = MsgBoxResult.Yes Then
                RequestRootPathToolStripMenuItem_Click(Me, Nothing)
            Else
                SetRootPathToolStripMenuItem_Click(Me, Nothing)
            End If
        Else
            SetRootPathToolStripMenuItem_Click(Me, Nothing)
        End If

        MsgBox("FFmpeg Section!")
        x = MsgBox("Do you have the ffmpeg suite installed?", MsgBoxStyle.YesNo)
        If x = MsgBoxResult.No Then
            x = MsgBox("Would you like to auto download ffmpeg?", MsgBoxStyle.YesNo)
            If x = MsgBoxResult.Yes Then
                DownloadLinkToolStripMenuItem_Click(Me, Nothing)
            End If
        End If

        Task.Delay(2000)

        FfmpegexeToolStripMenuItem_Click(Me, Nothing)
        FfprobeexeToolStripMenuItem_Click(Me, Nothing)
        FfplayexeToolStripMenuItem_Click(Me, Nothing)

        MsgBox("Yt-Dlp Section!")
        x = MsgBox("Do you have yt-dlp installed?", MsgBoxStyle.YesNo)
        If x = MsgBoxResult.No Then
            x = MsgBox("Would you like to auto download it?", MsgBoxStyle.YesNo)
            If x = MsgBoxResult.Yes Then
                DownloadHereToolStripMenuItem_Click(Me, Nothing)
            End If
        End If

        Task.Delay(2000)

        YtdlpexeToolStripMenuItem_Click(Me, Nothing)

        x = MsgBox("Would you like to add Youtube search append text?", MsgBoxStyle.YesNo)
        If x = MsgBoxResult.Yes Then
            PrependSearchTextToolStripMenuItem_Click(Me, Nothing)
        End If

        x = MsgBox("Would you like LidarrFusion to skip files you have already downloaded?", vbYesNo)
        If x = MsgBoxResult.Yes Then
            SkipExistingFilesToolStripMenuItem.Checked = True
            My.Settings.skipexist = SkipExistingFilesToolStripMenuItem.Checked
            My.Settings.Save()
        End If
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Environment.Exit(0)
    End Sub

    Private Sub SetURLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetURLToolStripMenuItem.Click
        Dim userInput As String = InputBox("Enter a URL:", "URL Input", My.Settings.LidarrAPIURL)
        My.Settings.LidarrAPIURL = userInput
        My.Settings.Save()
    End Sub

    Private Sub SetAPIKeyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetAPIKeyToolStripMenuItem.Click
        Dim userInput As String = InputBox("Enter API key:", "API Key", My.Settings.LidarrAPIKey)
        My.Settings.LidarrAPIKey = userInput
        My.Settings.Save()
    End Sub

    Private Sub SetRootPathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetRootPathToolStripMenuItem.Click
        Dim userInput As String = InputBox("Enter a path:", "Root Path", My.Settings.rootpath)
        My.Settings.rootpath = userInput
        My.Settings.Save()
    End Sub

    Private Sub RequestRootPathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequestRootPathToolStripMenuItem.Click
        Dim url As String = My.Settings.LidarrAPIURL & "/api/v1/rootfolder"
        Try
            webClient.Headers.Add("X-Api-Key", My.Settings.LidarrAPIKey)
            Dim response As String = webClient.DownloadString(url)
            Dim root As String() = Newtonsoft.Json.JsonConvert.DeserializeObject(response).ToString().Split(","c)

            For Each item As String In root
                Dim x As String = item.ToString()

                If x.Contains("path") Then
                    My.Settings.rootpath = x.Split(New Char() {ChrW(34)})(3).Replace("\\", "\")
                    ToolStripStatusLabel1.Text = "Recieved Path: " & My.Settings.rootpath
                    My.Settings.Save()
                End If
            Next

        Catch ex As WebException
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub DownloadLinkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadLinkToolStripMenuItem.Click
        Try
            Dim zipUrl As String = "https://angablade.com/stuff/ffmpeg.zip"
            Dim downloadPath As String = Path.Combine(Application.StartupPath, "ffmpeg.zip")
            AddHandler webClient.DownloadProgressChanged, AddressOf WebClientDownloadProgressChanged
            webClient.DownloadFileAsync(New Uri(zipUrl), downloadPath)
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FfmpegexeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FfmpegexeToolStripMenuItem.Click
        My.Settings.ffmpeg = FindAndUseFile("ffmpeg.exe")
        My.Settings.Save()
    End Sub

    Private Sub FfprobeexeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FfprobeexeToolStripMenuItem.Click
        My.Settings.ffmpeg = FindAndUseFile("ffprobe.exe")
        My.Settings.Save()
    End Sub

    Private Sub FfplayexeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FfplayexeToolStripMenuItem.Click
        My.Settings.ffmpeg = FindAndUseFile("ffplay.exe")
        My.Settings.Save()
    End Sub

    Private Sub YtdlpexeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YtdlpexeToolStripMenuItem.Click
        My.Settings.ytdlp = FindAndUseFile("yt-dlp.exe")
        My.Settings.Save()
    End Sub

    Private Sub DownloadHereToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadHereToolStripMenuItem.Click
        Try
            Dim webpageUrl As String = "https://github.com/yt-dlp/yt-dlp/releases"
            Dim webpageSource As String = webClient.DownloadString(webpageUrl)
            Dim sourceParts As String() = webpageSource.Split(ChrW(34))
            Dim downloadLink As String = Nothing
            For Each str As String In sourceParts
                If str.Contains("/yt-dlp/yt-dlp/releases/download/") AndAlso str.Contains("/yt-dlp.exe") Then
                    downloadLink = $"https://github.com{str}"
                    ToolStripStatusLabel1.Text = "yt-dlp.exe found!"
                    Exit For
                End If
            Next

            If Not String.IsNullOrEmpty(downloadLink) Then
                Dim downloadPath As String = Path.Combine(Application.StartupPath, "yt-dlp.exe")
                AddHandler webClient.DownloadProgressChanged, AddressOf WebClientDownloadProgressChanged
                webClient.DownloadFile(New Uri(downloadLink), downloadPath)
                ToolStripStatusLabel1.Text = "yt-dlp.exe downloaded successfully."
            Else
                ToolStripStatusLabel1.Text = "Download link not found on the webpage."
            End If

        Catch ex As Exception
            ToolStripStatusLabel1.Text = $"Error: {ex.Message}"
        End Try
    End Sub

    Private Sub ToolStripDropDownButton1_MouseDown(sender As Object, e As MouseEventArgs) Handles ToolStripDropDownButton1.MouseDown
        If e.Button = MouseButtons.Middle Then
            RunSetupWizardToolStripMenuItem.Visible = True
        Else
            RunSetupWizardToolStripMenuItem.Visible = False
        End If
    End Sub
    Private Sub ToolStripDropDownButton1_DropDownClosed(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.DropDownClosed
        RunSetupWizardToolStripMenuItem.Visible = False
    End Sub
    Private Sub RunSetupWizardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunSetupWizardToolStripMenuItem.Click
        setupwizard()
    End Sub
    Private Sub WebClientDownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        ToolStripStatusLabel1.Text = $"Downloading... {e.ProgressPercentage}%"
    End Sub

    Private Sub webClient_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles webClient.DownloadFileCompleted
        If e.Error Is Nothing Then
            Dim extractPath As String = Application.StartupPath
            ZipFile.ExtractToDirectory(extractPath & "ffmpeg.zip", extractPath)
            System.IO.File.Delete(extractPath & "ffmpeg.zip")
            ToolStripStatusLabel1.Text = "Download and extraction completed."
        Else
            ToolStripStatusLabel1.Text = $"Error: {e.Error.Message}"

        End If
    End Sub
    Private Function FindAndUseFile(filename As String) As String
        Dim appPath As String = Application.StartupPath
        Dim filePath As String = Path.Combine(appPath, filename)
        If System.IO.File.Exists(filePath) Then
            Dim useExistingFile As DialogResult = MessageBox.Show($"Found '{filename}' in the application directory. Do you want to use this version?", "File Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If useExistingFile = DialogResult.Yes Then
                ToolStripStatusLabel1.Text = $"Using existing file: {filePath}"
                Return filePath
            Else
                OpenFileDialog1.FileName = filename
                OpenFileDialog1.InitialDirectory = appPath
                If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                    filePath = OpenFileDialog1.FileName
                    ToolStripStatusLabel1.Text = $"Selected file: {filePath}"
                    Return filePath
                Else
                    ToolStripStatusLabel1.Text = "Operation canceled by the user."
                End If
            End If
        Else
            OpenFileDialog1.FileName = filename
            OpenFileDialog1.InitialDirectory = appPath
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                filePath = OpenFileDialog1.FileName
                ToolStripStatusLabel1.Text = $"Selected file: {filePath}"
                Return filePath
            Else
                ToolStripStatusLabel1.Text = "Operation canceled by the user."
            End If
        End If
        Return Nothing
    End Function
    Dim cancelbgw1 As Boolean = False
    Dim cancelbgw2 As Boolean = False
    Dim cancelbgw3 As Boolean = False
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If BackgroundWorker1.IsBusy Then
            ToolStripTextBox1.Enabled = True
            ToolStripButton2.Enabled = True
            ToolStripButton3.Enabled = True
            cancelbgw1 = True
            BackgroundWorker1.CancelAsync()
        Else
            ToolStripTextBox1.Enabled = False
            ToolStripButton2.Enabled = False
            ToolStripButton3.Enabled = False
            cancelbgw1 = False
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Private Sub PrependSearchTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrependSearchTextToolStripMenuItem.Click
        Dim userInput As String = InputBox("Enter youtube search append:", "append text", My.Settings.ytpp)
        My.Settings.ytpp = userInput
        My.Settings.Save()
    End Sub
    Public Shared Function SanitizePath(Location As String) As String
        Dim invalidChars As Char() = Path.GetInvalidFileNameChars()
        Dim sanitizedPath As String = New String(Location _
        .Where(Function(c) Not invalidChars.Contains(c)) _
        .ToArray())
        Return sanitizedPath.Replace("<", "").Replace(">", "").Replace("""", "")
    End Function
    Public Function IsWindowsSafeFilePath(filePath As String) As Boolean
        Dim invalidPathChars As Char() = Path.GetInvalidPathChars()
        Return filePath.IndexOfAny(invalidPathChars) = -1
    End Function
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try

            ListView1.Items.Clear()
            Dim Url As String = My.Settings.LidarrAPIURL & "/api/v1/wanted/missing?pageSize=1000000000&includeArtist=true&monitored=true"
            webClient.Headers.Add("X-Api-Key", My.Settings.LidarrAPIKey)
            Dim response As String = webClient.DownloadString(Url)
            Dim data As JObject = Newtonsoft.Json.JsonConvert.DeserializeObject(response)
            If data("records") IsNot Nothing Then
                ToolStripProgressBar1.Value = 0
                ToolStripProgressBar1.Maximum = data("records").Count
                For Each record As JObject In data("records")
                    Try
                        Dim artist As String = If(record("artist")("artistName") IsNot Nothing, record("artist")("artistName").ToString(), "")
                        Dim album As String = If(record("title") IsNot Nothing, record("title").ToString(), "")
                        Dim id As String = If(record("id") IsNot Nothing, record("id").ToString(), "") '

                        Dim tracks As String() = Nothing
                        tracks = MusicBrainzHelper.GetTrackList(artist, album)
                        If tracks IsNot Nothing AndAlso tracks.Length > 0 Then
                            'MsgBox(ToolStripProgressBar1.Maximum.ToString())
                            For Each track In tracks

                                Try
                                    ToolStripProgressBar1.Value += 1
                                    ToolStripStatusLabel2.Text = $"{ ToolStripProgressBar1.Maximum}/{ ToolStripProgressBar1.Value}"
                                    Dim lnkcntr As Integer = 0
                                    Dim ytlink As String = ""
                                    Dim redoer As Boolean = False

                                    If My.Settings.skipyoutube = False Then
reyoutube:
                                        If ToolStripMenuItem7.Checked = False Then
                                            ytlink = YouTubeHelper.SearchYoutube($"{artist} - {album} - {track}{My.Settings.ytpp}", lnkcntr)
                                        Else
                                            ytlink = YouTubeHelper.SearchYoutubeMusic($"{artist} - {album} - {track}{My.Settings.ytpp}", lnkcntr)
                                        End If

                                        Parallel.ForEach(ListView1.Items.Cast(Of ListViewItem)(), Sub(item)

                                                                                                      If item.SubItems(4).Text = ytlink Or ytlink = "https://www.youtube.com/watch?v=" Or ytlink = "https://music.youtube.com/watch?v=" Then
                                                                                                          If ytlink.Length > 0 Then
                                                                                                              System.Diagnostics.Debug.WriteLine($"Error: Can't find video. Retrying -> {ytlink}")
                                                                                                              redoer = True
                                                                                                          End If
                                                                                                      End If
                                                                                                  End Sub)

                                            If redoer = True Then
                                                redoer = False
                                                lnkcntr += 1
                                                GoTo reyoutube
                                            End If
                                        End If
                                        Dim tracklocation As String = Path.Combine(My.Settings.rootpath, SanitizePath(artist), SanitizePath(album), SanitizePath(track) & ".mp3")
                                    Dim q As New ListViewItem()
                                    q.Text = artist
                                    q.SubItems.Add(album)
                                    q.SubItems.Add(track)
                                    q.SubItems.Add(id)
                                    q.SubItems.Add(ytlink)
                                    q.SubItems.Add(tracklocation)
                                    If IsWindowsSafeFilePath(tracklocation) Then ListView1.Items.Add(q)
                                Catch ex As Exception
                                End Try
                            Next
                        End If
                        System.Threading.Thread.Sleep(1500)
                    Catch ex As Exception
                    End Try

                    If cancelbgw1 = True Then Exit For
                Next
            Else
                ToolStripStatusLabel1.Text = "The 'records' property was not found in the response."
            End If
        Catch ex As Exception
        End Try
        ToolStripStatusLabel2.Text = "   "
        ToolStripProgressBar1.Value = 0
        ToolStripButton1.Enabled = True
        ToolStripButton2.Enabled = True
        ToolStripButton3.Enabled = True

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If BackgroundWorker2.IsBusy Then
            ToolStripButton1.Enabled = True
            ToolStripButton3.Enabled = True
            cancelbgw2 = True
            BackgroundWorker2.CancelAsync()
        Else
            ToolStripButton1.Enabled = False
            ToolStripButton3.Enabled = False
            cancelbgw2 = False
            BackgroundWorker2.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        If ListView1.SelectedItems.Count > 1 Then
            For Each itm As ListViewItem In ListView1.SelectedItems
                Try
                    Dim artist As String = itm.Text
                    Dim album As String = itm.SubItems.Item(1).Text
                    Dim track As String = itm.SubItems.Item(2).Text
                    Dim id As String = itm.SubItems.Item(3).Text
                    Dim youtubelink As String = itm.SubItems.Item(4).Text
                    Dim tracklocation As String = itm.SubItems.Item(5).Text

                    If My.Computer.FileSystem.FileExists(tracklocation) = True Then
                        If SkipExistingFilesToolStripMenuItem.Checked = True Then Exit Try
                    End If

                    Dim rootpath As String = My.Settings.rootpath

                    If Not Directory.Exists(Path.Combine(rootpath, SanitizePath(artist), SanitizePath(album))) Then
                        Directory.CreateDirectory(Path.Combine(rootpath, SanitizePath(artist), SanitizePath(album)))
                    End If

                    itm.BackColor = Color.Yellow

                    ToolStripStatusLabel1.Text = $"Processing: {artist} - {track}"
                    Dim processPath As String = My.Settings.ytdlp
                    Dim processArguments As String = ChrW(34) & youtubelink & ChrW(34) & " -x --audio-format " & ChrW(34) & "mp3" & ChrW(34) & " --match-filter " & ChrW(34) & "is_live != true & was_live != true & duration < 3600" & ChrW(34) & " --download-archive " & ChrW(34) & "archive.txt" & ChrW(34) & " --break-on-existing --output " & ChrW(34) & tracklocation & ChrW(34)

                    Dim process As New Process()
                    process.StartInfo.FileName = processPath
                    process.StartInfo.Arguments = processArguments
                    process.StartInfo.UseShellExecute = False
                    process.StartInfo.RedirectStandardOutput = True
                    process.StartInfo.RedirectStandardError = True


                    process.Start()
                    Dim standardOutput As String = process.StandardOutput.ReadToEnd()

                    Console.WriteLine(standardOutput.Trim())
                    itm.BackColor = Color.LimeGreen
                    ToolStripStatusLabel1.Text = $"Processed: {artist} - {track}"
                    process.WaitForExit()
                Catch ex As Exception
                    itm.BackColor = Color.Red
                End Try
                If cancelbgw2 = True Then Exit For
            Next
        Else
            For Each itm As ListViewItem In ListView1.Items
                Try
                    Dim artist As String = itm.Text
                    Dim album As String = itm.SubItems.Item(1).Text
                    Dim track As String = itm.SubItems.Item(2).Text
                    Dim id As String = itm.SubItems.Item(3).Text
                    Dim youtubelink As String = itm.SubItems.Item(4).Text
                    Dim tracklocation As String = itm.SubItems.Item(5).Text

                    If My.Computer.FileSystem.FileExists(tracklocation) = True Then
                        If SkipExistingFilesToolStripMenuItem.Checked = True Then Exit Try
                    End If

                    Dim rootpath As String = My.Settings.rootpath

                    If Not Directory.Exists(Path.Combine(rootpath, SanitizePath(artist), SanitizePath(album))) Then
                        Directory.CreateDirectory(Path.Combine(rootpath, SanitizePath(artist), SanitizePath(album)))
                    End If

                    itm.BackColor = Color.Yellow

                    ToolStripStatusLabel1.Text = $"Processing: {artist} - {track}"
                    Dim processPath As String = My.Settings.ytdlp
                    Dim processArguments As String = ChrW(34) & youtubelink & ChrW(34) & " -x --audio-format " & ChrW(34) & "mp3" & ChrW(34) & " --match-filter " & ChrW(34) & "is_live != true & was_live != true & duration < 3600" & ChrW(34) & " --download-archive " & ChrW(34) & "archive.txt" & ChrW(34) & " --break-on-existing --output " & ChrW(34) & tracklocation & ChrW(34)

                    Dim process As New Process()
                    process.StartInfo.FileName = processPath
                    process.StartInfo.Arguments = processArguments
                    process.StartInfo.UseShellExecute = False
                    process.StartInfo.RedirectStandardOutput = True
                    process.StartInfo.RedirectStandardError = True

                    process.Start()
                    Dim standardOutput As String = process.StandardOutput.ReadToEnd()

                    Console.WriteLine(standardOutput.Trim())
                    itm.BackColor = Color.Green
                    ToolStripStatusLabel1.Text = $"Processed: {artist} - {track}"
                    process.WaitForExit()
                Catch ex As Exception
                    itm.BackColor = Color.Red
                End Try
                If cancelbgw2 = True Then Exit For
            Next
        End If

        ToolStripButton1.Enabled = True
        ToolStripButton2.Enabled = True
        ToolStripButton3.Enabled = True
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If BackgroundWorker3.IsBusy Then
            ToolStripButton1.Enabled = True
            ToolStripButton2.Enabled = True
            cancelbgw3 = True
            BackgroundWorker3.CancelAsync()
        Else
            ToolStripButton1.Enabled = False
            ToolStripButton2.Enabled = False
            cancelbgw3 = False
            BackgroundWorker3.RunWorkerAsync()
        End If
    End Sub
    Public Shared Sub WriteID3v3Tags(filePath As String, artist As String, album As String, track As String)
        Try
            Using file = TagLib.File.Create(filePath)
                Dim tag = CType(file.GetTag(TagTypes.Id3v2, True), TagLib.Id3v2.Tag)

                tag.Title = track
                tag.Artists = New String() {artist}
                tag.Album = album
                file.Save()
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error writing ID3v3 tags: {ex.Message}")
        End Try
    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork

        If ListView1.SelectedItems.Count > 1 Then
            Dim selectedItems As List(Of ListViewItem) = ListView1.SelectedItems.Cast(Of ListViewItem)().ToList()
            Parallel.ForEach(selectedItems, Sub(itm)
                                                Try
                                                    Dim artist As String = itm.Text
                                                    Dim album As String = itm.SubItems.Item(1).Text
                                                    Dim track As String = itm.SubItems.Item(2).Text
                                                    Dim id As String = itm.SubItems.Item(3).Text
                                                    Dim youtubelink As String = itm.SubItems.Item(4).Text
                                                    Dim tracklocation As String = itm.SubItems.Item(5).Text
                                                    Dim rootpath As String = My.Settings.rootpath
                                                    itm.BackColor = Color.Yellow
                                                    ToolStripStatusLabel1.Text = $"Processing: {artist} - {track}"
                                                    WriteID3v3Tags(tracklocation, artist, album, track)
                                                    ToolStripStatusLabel1.Text = $"Processed: {artist} - {track}"
                                                    itm.BackColor = Color.Green
                                                Catch ex As Exception
                                                    itm.BackColor = Color.Red
                                                End Try
                                            End Sub)
        Else
            Dim TItems As List(Of ListViewItem) = ListView1.Items.Cast(Of ListViewItem)().ToList()
            Parallel.ForEach(TItems, Sub(itm)
                                         Try
                                             Dim artist As String = itm.Text
                                             Dim album As String = itm.SubItems.Item(1).Text
                                             Dim track As String = itm.SubItems.Item(2).Text
                                             Dim id As String = itm.SubItems.Item(3).Text
                                             Dim youtubelink As String = itm.SubItems.Item(4).Text
                                             Dim tracklocation As String = itm.SubItems.Item(5).Text
                                             Dim rootpath As String = My.Settings.rootpath
                                             itm.BackColor = Color.Yellow
                                             ToolStripStatusLabel1.Text = $"Processing: {artist} - {track}"
                                             WriteID3v3Tags(tracklocation, artist, album, track)
                                             ToolStripStatusLabel1.Text = $"Processed: {artist} - {track}"
                                             itm.BackColor = Color.Green
                                         Catch ex As Exception
                                             itm.BackColor = Color.Red
                                         End Try
                                     End Sub)
        End If

        ToolStripButton1.Enabled = True
        ToolStripButton2.Enabled = True
        ToolStripButton3.Enabled = True
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ToolStripStatusLabel1.Text = "Proccessing Data..."
    End Sub
    Public Sub PerformSearch(listView As ListView, searchTerm As String)
        If listView.Tag Is Nothing Then
            listView.Tag = New List(Of ListViewItem)(listView.Items.Cast(Of ListViewItem)())
        End If

        Dim originalItems As List(Of ListViewItem) = DirectCast(listView.Tag, List(Of ListViewItem))

        If String.IsNullOrEmpty(searchTerm) Then
            RestoreOriginalItems(listView, originalItems)
        Else
            HideItemsNotContainingTerm(listView, originalItems, searchTerm)
        End If
    End Sub

    Private Sub RestoreOriginalItems(listView As ListView, originalItems As List(Of ListViewItem))
        listView.Items.Clear()
        listView.Items.AddRange(originalItems.ToArray())
    End Sub

    Private Sub HideItemsNotContainingTerm(listView As ListView, originalItems As List(Of ListViewItem), searchTerm As String)
        searchTerm = searchTerm.ToLower()

        listView.Items.Clear()

        For Each item As ListViewItem In originalItems
            If item.Text.ToLower().Contains(searchTerm) OrElse
               item.SubItems.Cast(Of ListViewItem.ListViewSubItem)().Any(Function(subItem) subItem.Text.ToLower().Contains(searchTerm)) Then
                listView.Items.Add(CType(item.Clone(), ListViewItem))
            End If
        Next
    End Sub
    Private Sub ToolStripTextBox1_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox1.TextChanged
        PerformSearch(ListView1, ToolStripTextBox1.Text)
    End Sub

    Private Sub SkipExistingFilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SkipExistingFilesToolStripMenuItem.Click
        SkipExistingFilesToolStripMenuItem.Checked = Not SkipExistingFilesToolStripMenuItem.Checked
        My.Settings.skipexist = SkipExistingFilesToolStripMenuItem.Checked
        My.Settings.Save()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox1.Click

    End Sub
    Private Sub DownloadMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim itm As ListViewItem = ListView1.SelectedItems.Item(0)
            Try

                Dim artist As String = itm.Text
                Dim album As String = itm.SubItems.Item(1).Text
                Dim track As String = itm.SubItems.Item(2).Text
                Dim id As String = itm.SubItems.Item(3).Text
                Dim youtubelink As String = itm.SubItems.Item(4).Text
                Dim tracklocation As String = itm.SubItems.Item(5).Text
                Dim rootpath As String = My.Settings.rootpath

                If Not Directory.Exists(Path.Combine(rootpath, SanitizePath(artist), SanitizePath(album))) Then
                    Directory.CreateDirectory(Path.Combine(rootpath, SanitizePath(artist), SanitizePath(album)))
                End If

                itm.BackColor = Color.Yellow

                ToolStripStatusLabel1.Text = $"Processing: {artist} - {track}"
                Dim processPath As String = My.Settings.ytdlp
                Dim processArguments As String = ChrW(34) & youtubelink & ChrW(34) & " -x --audio-format " & ChrW(34) & "mp3" & ChrW(34) & " --match-filter " & ChrW(34) & "is_live != true & was_live != true & duration < 3600" & ChrW(34) & " --download-archive " & ChrW(34) & "archive.txt" & ChrW(34) & " --break-on-existing --output " & ChrW(34) & tracklocation & ChrW(34)

                Dim process As New Process()
                process.StartInfo.FileName = processPath
                process.StartInfo.Arguments = processArguments
                process.StartInfo.UseShellExecute = False
                process.StartInfo.RedirectStandardOutput = True
                process.StartInfo.RedirectStandardError = True
                process.StartInfo.CreateNoWindow = True

                process.Start()
                Dim standardOutput As String = process.StandardOutput.ReadToEnd()

                Console.WriteLine(standardOutput.Trim())
                itm.BackColor = Color.Green
                ToolStripStatusLabel1.Text = $"Processed: {artist} - {track}"
                process.WaitForExit()
            Catch ex As Exception
                itm.BackColor = Color.Red
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub WriteTagsMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim itm As ListViewItem = ListView1.SelectedItems.Item(0)
            Try
                Dim artist As String = itm.Text
                Dim album As String = itm.SubItems.Item(1).Text
                Dim track As String = itm.SubItems.Item(2).Text
                Dim id As String = itm.SubItems.Item(3).Text
                Dim youtubelink As String = itm.SubItems.Item(4).Text
                Dim tracklocation As String = itm.SubItems.Item(5).Text
                Dim rootpath As String = My.Settings.rootpath
                itm.BackColor = Color.Yellow
                ToolStripStatusLabel1.Text = $"Processing: {artist} - {track}"
                WriteID3v3Tags(tracklocation, artist, album, track)
                ToolStripStatusLabel1.Text = $"Processed: {artist} - {track}"
                itm.BackColor = Color.Green
            Catch ex As Exception
                itm.BackColor = Color.Red
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub EditTagsMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim itm As ListViewItem = ListView1.SelectedItems.Item(0)
            Try
                For Each itr As ListViewItem.ListViewSubItem In itm.SubItems
                    itr.Text = InputBox("Enter Changes", "Enter Changes", itr.Text)
                Next
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub
    Private Sub OpenUrlMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim itm As ListViewItem = ListView1.SelectedItems.Item(0)
            Dim youtubelink As String = itm.SubItems.Item(4).Text.Trim
            Process.Start(New ProcessStartInfo(youtubelink) With {.UseShellExecute = True})
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RemoveMenuItem_Click(sender As Object, e As EventArgs)
        Dim itm As ListViewItem = ListView1.SelectedItems.Item(0)
        ListView1.Items.Remove(itm)
    End Sub

    Private Sub RequestInterventionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequestInterventionsToolStripMenuItem.Click
        RequestInterventionsToolStripMenuItem.Checked = Not RequestInterventionsToolStripMenuItem.Checked
        My.Settings.intervent = RequestInterventionsToolStripMenuItem.Checked
        My.Settings.Save()
    End Sub

    Private Sub SkipYoutubeSearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SkipYoutubeSearchToolStripMenuItem.Click
        SkipYoutubeSearchToolStripMenuItem.Checked = Not SkipYoutubeSearchToolStripMenuItem.Checked
        My.Settings.skipyoutube = SkipYoutubeSearchToolStripMenuItem.Checked
        My.Settings.Save()
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        ToolStripMenuItem7.Checked = Not ToolStripMenuItem7.Checked
        My.Settings.youtubemusic = ToolStripMenuItem7.Checked
        My.Settings.Save()
    End Sub
End Class
Public Class MusicBrainzHelper
    Public Shared Function GetTrackList(artist As String, album As String) As String()
        Try
            Dim apiUrl As String = "https://musicbrainz.org/ws/2/"
            Dim formattedArtist As String = WebUtility.UrlEncode(artist)
            Dim formattedAlbum As String = WebUtility.UrlEncode(album)
            Dim url As String = $"{apiUrl}release/?query=artist:""{formattedArtist}""+AND+release:""{formattedAlbum}""&fmt=json"

            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "GET"
            request.UserAgent = "LidarrFusion"

            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                Using stream As Stream = response.GetResponseStream()
                    Using reader As New StreamReader(stream)
                        Dim jsonResponse As String = reader.ReadToEnd()

                        If Not String.IsNullOrEmpty(jsonResponse) Then
                            Dim data As JObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse)


                            Dim releaseId As String = data.Item("releases")(0)("id")
                            If releaseId.Length = 0 Then Return Nothing
                            Dim tracklistUrl As String = $"{apiUrl}release/{releaseId}?inc=recordings&fmt=json"

                            request = CType(WebRequest.Create(tracklistUrl), HttpWebRequest)
                            request.Method = "GET"
                            request.UserAgent = "LidarrFusion"

                            Using tracklistResponse As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                                Using tracklistStream As Stream = tracklistResponse.GetResponseStream()
                                    Using tracklistReader As New StreamReader(tracklistStream)
                                        Dim tracklistJsonResponse As String = tracklistReader.ReadToEnd()

                                        If Not String.IsNullOrEmpty(tracklistJsonResponse) Then
                                            Dim tracklistData As JObject = Newtonsoft.Json.JsonConvert.DeserializeObject(tracklistJsonResponse)
                                            Try
                                                If tracklistData.Item("media")(0)("tracks") IsNot Nothing Or tracklistData.Item("media")(0)("tracks").ToString.Length > 0 Then
                                                    Dim tracks As JArray = CType(tracklistData("media")(0)("tracks"), JArray)
                                                    Return tracks.Select(Function(t) CStr(t.Item("title"))).ToArray()
                                                Else
                                                    Return Nothing
                                                End If
                                            Catch ex As Exception
                                            End Try
                                        End If
                                    End Using
                                End Using
                            End Using
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception

        End Try
        Return Nothing
    End Function
End Class
Public Class YouTubeHelper
    Public Shared Function SearchYoutube(query As String, Optional hotindex As Integer = 0) As String
        Dim queryEncoded As String = WebUtility.UrlEncode(query)
        Dim url As String = "https://www.youtube.com/results?search_query=" & queryEncoded
        System.Diagnostics.Debug.WriteLine($"Current Hot index: {hotindex.ToString()}")

        If hotindex >= 4 Then
            If My.Settings.intervent = True Then
                Dim NewProcess As Diagnostics.ProcessStartInfo = New Diagnostics.ProcessStartInfo(url)
                NewProcess.UseShellExecute = True
                Diagnostics.Process.Start(NewProcess)
                Dim x As String = InputBox($"There was an error finding '{query}', please enter the url directly please!", "Please enter the url Directly!")
                Return x
            Else
                Return ""
            End If
        End If

        Using client As New WebClient()
            Try
                ' Set the user-agent to the latest Firefox version
                client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:117.0) Gecko/20100101 Firefox/117.0")

                Dim response As String = client.DownloadString(url)

                If response IsNot Nothing Then
                    Dim matches As Match = Regex.Match(response, """videoRenderer""\s*:\s*{""videoId""\s*:\s*""([^""]+)""")

                    If matches.Success Then
                        System.Diagnostics.Debug.WriteLine($"Matches: {matches.Groups.Count}")
                        Dim videoId As String = matches.Groups(1 + hotindex).Value
                        Dim videoUrl As String = "https://www.youtube.com/watch?v=" & videoId
                        System.Diagnostics.Debug.WriteLine("Video link found: " & videoUrl)
                        Return videoUrl
                    Else
                        Return "Video link not found in the search results."
                    End If
                Else
                    Return "Error fetching YouTube search results."
                End If

            Catch ex As WebException
                Return "Error fetching YouTube search results: " & ex.Message
            End Try
        End Using
    End Function

    Public Shared Function SearchYoutubeMusic(query As String, Optional hotindex As Integer = 0) As String
        Dim queryEncoded As String = WebUtility.UrlEncode(query)
        Dim url As String = "https://music.youtube.com/search?q=" & queryEncoded
        System.Diagnostics.Debug.WriteLine($"Current Hot index: {hotindex.ToString()}")

        If hotindex >= 4 Then
            If My.Settings.intervent = True Then
                Dim NewProcess As Diagnostics.ProcessStartInfo = New Diagnostics.ProcessStartInfo(url)
                NewProcess.UseShellExecute = True
                Diagnostics.Process.Start(NewProcess)
                Dim x As String = InputBox($"There was an error finding '{query}', please enter the URL directly!", "Please enter the URL directly!")
                Return x
            Else
                Return ""
            End If
        End If

        Using client As New WebClient()
            Try
                ' Set the user-agent to the latest Firefox version
                client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:117.0) Gecko/20100101 Firefox/117.0")

                ' Fetch response with better escaping for JSON characters
                Dim response As String = client.DownloadString(url).Replace("\x22", Chr(34)).Replace("\x7b", "{").Replace("\x7d", "}").Replace("\x5b", "[").Replace("\x5d", "]")

                MsgBox(response)

                ' Capture video/track IDs from YouTube Music
                If response IsNot Nothing Then
                    Dim matches As Match = Regex.Match(response, """videoId""\s*:\s*""([^""]+)""")

                    If matches.Success Then
                        System.Diagnostics.Debug.WriteLine($"Matches: {matches.Groups.Count}")
                        Dim videoId As String = matches.Groups(1 + hotindex).Value
                        Dim videoUrl As String = "https://music.youtube.com/watch?v=" & videoId
                        System.Diagnostics.Debug.WriteLine("Music video link found: " & videoUrl)
                        Return videoUrl
                    Else
                        Return "Music video link not found in the search results."
                    End If
                Else
                    Return "Error fetching YouTube Music search results."
                End If

            Catch ex As WebException
                Return "Error fetching YouTube Music search results: " & ex.Message
            End Try
        End Using
    End Function

End Class

