<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox1
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

    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LabelCompanyName As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        TableLayoutPanel = New TableLayoutPanel()
        LogoPictureBox = New PictureBox()
        LabelProductName = New Label()
        LabelVersion = New Label()
        LabelCopyright = New Label()
        LabelCompanyName = New Label()
        OKButton = New Button()
        Panel1 = New Panel()
        Button2 = New Button()
        Button1 = New Button()
        TableLayoutPanel.SuspendLayout()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel
        ' 
        TableLayoutPanel.ColumnCount = 2
        TableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33F))
        TableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 67F))
        TableLayoutPanel.Controls.Add(LogoPictureBox, 0, 0)
        TableLayoutPanel.Controls.Add(LabelProductName, 1, 0)
        TableLayoutPanel.Controls.Add(LabelVersion, 1, 1)
        TableLayoutPanel.Controls.Add(LabelCopyright, 1, 2)
        TableLayoutPanel.Controls.Add(LabelCompanyName, 1, 3)
        TableLayoutPanel.Controls.Add(OKButton, 1, 5)
        TableLayoutPanel.Controls.Add(Panel1, 1, 4)
        TableLayoutPanel.Dock = DockStyle.Fill
        TableLayoutPanel.Location = New Point(10, 10)
        TableLayoutPanel.Margin = New Padding(4, 3, 4, 3)
        TableLayoutPanel.Name = "TableLayoutPanel"
        TableLayoutPanel.RowCount = 7
        TableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 45.4545441F))
        TableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 15.272727F))
        TableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 18F))
        TableLayoutPanel.Size = New Size(463, 298)
        TableLayoutPanel.TabIndex = 0
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.Dock = DockStyle.Fill
        LogoPictureBox.Image = My.Resources.Resources.lidarrfusion
        LogoPictureBox.Location = New Point(4, 3)
        LogoPictureBox.Margin = New Padding(4, 3, 4, 3)
        LogoPictureBox.Name = "LogoPictureBox"
        TableLayoutPanel.SetRowSpan(LogoPictureBox, 6)
        LogoPictureBox.Size = New Size(144, 270)
        LogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        LogoPictureBox.TabIndex = 0
        LogoPictureBox.TabStop = False
        ' 
        ' LabelProductName
        ' 
        LabelProductName.Dock = DockStyle.Fill
        LabelProductName.Location = New Point(159, 0)
        LabelProductName.Margin = New Padding(7, 0, 4, 0)
        LabelProductName.MaximumSize = New Size(0, 20)
        LabelProductName.Name = "LabelProductName"
        LabelProductName.Size = New Size(300, 20)
        LabelProductName.TabIndex = 0
        LabelProductName.Text = "Product Name"
        LabelProductName.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelVersion
        ' 
        LabelVersion.Dock = DockStyle.Fill
        LabelVersion.Location = New Point(159, 27)
        LabelVersion.Margin = New Padding(7, 0, 4, 0)
        LabelVersion.MaximumSize = New Size(0, 20)
        LabelVersion.Name = "LabelVersion"
        LabelVersion.Size = New Size(300, 20)
        LabelVersion.TabIndex = 0
        LabelVersion.Text = "Version"
        LabelVersion.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelCopyright
        ' 
        LabelCopyright.Dock = DockStyle.Fill
        LabelCopyright.Location = New Point(159, 54)
        LabelCopyright.Margin = New Padding(7, 0, 4, 0)
        LabelCopyright.MaximumSize = New Size(0, 20)
        LabelCopyright.Name = "LabelCopyright"
        LabelCopyright.Size = New Size(300, 20)
        LabelCopyright.TabIndex = 0
        LabelCopyright.Text = "Copyright"
        LabelCopyright.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' LabelCompanyName
        ' 
        LabelCompanyName.Dock = DockStyle.Fill
        LabelCompanyName.Location = New Point(159, 81)
        LabelCompanyName.Margin = New Padding(7, 0, 4, 0)
        LabelCompanyName.MaximumSize = New Size(0, 20)
        LabelCompanyName.Name = "LabelCompanyName"
        LabelCompanyName.Size = New Size(300, 20)
        LabelCompanyName.TabIndex = 0
        LabelCompanyName.Text = "Company Name"
        LabelCompanyName.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' OKButton
        ' 
        OKButton.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        OKButton.DialogResult = DialogResult.Cancel
        OKButton.Location = New Point(371, 246)
        OKButton.Margin = New Padding(4, 3, 4, 3)
        OKButton.Name = "OKButton"
        OKButton.Size = New Size(88, 27)
        OKButton.TabIndex = 0
        OKButton.Text = "&OK"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(Button1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(155, 111)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(305, 120)
        Panel1.TabIndex = 1
        ' 
        ' Button2
        ' 
        Button2.BackgroundImage = My.Resources.Resources.fluidicon
        Button2.BackgroundImageLayout = ImageLayout.Zoom
        Button2.Location = New Point(202, 14)
        Button2.Name = "Button2"
        Button2.Size = New Size(100, 88)
        Button2.TabIndex = 1
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.BackgroundImage = My.Resources.Resources._6623019
        Button1.BackgroundImageLayout = ImageLayout.Zoom
        Button1.Location = New Point(4, 14)
        Button1.Name = "Button1"
        Button1.Size = New Size(100, 88)
        Button1.TabIndex = 0
        Button1.UseVisualStyleBackColor = True
        ' 
        ' AboutBox1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = OKButton
        ClientSize = New Size(483, 318)
        Controls.Add(TableLayoutPanel)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 3, 4, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "AboutBox1"
        Padding = New Padding(10)
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "AboutBox1"
        TableLayoutPanel.ResumeLayout(False)
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
End Class
