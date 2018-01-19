Public Class UserControl1

    Public pramItemNumber As Integer
    Dim html As String
    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        html = clsUpdate.getHtml("http://rocketleaguemods.com/mods/?category=arena-maps,other-maps,race-maps,training-maps")

        html = html.Split(New String() {"vgmmodsarea"}, StringSplitOptions.None)(1)
        html = html.Split(New String() {"<li class"}, StringSplitOptions.None)(pramItemNumber + 1)

        Dim startPicIndex = html.IndexOf("<img src=")
        Dim endPicIndex = html.IndexOf("""", startPicIndex + 10)
        Dim pictureURL As String = html.Substring(startPicIndex + 10, (endPicIndex - startPicIndex) - 10)

        Dim startNameIndex = html.IndexOf("card-title") + 12
        Dim endNameIndex = html.IndexOf("<", startNameIndex)
        Dim name As String = html.Substring(startNameIndex, endNameIndex - startNameIndex)


        Dim startAuthIndex = html.IndexOf("Contributor&#039;s page") + 25
        Dim endAuthIndex = html.IndexOf("<", startAuthIndex)
        Dim Auth As String = html.Substring(startAuthIndex, endAuthIndex - startAuthIndex)

        'MsgBox(pictureURL)

        Try
            PictureBox1.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(pictureURL)))
        Catch ex As Exception

        End Try

        Try
            lblName.Text = name
        Catch ex As Exception

        End Try

        Try
            lblAuthor.Text = Auth
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Button1.Text = "Downloading..."
        Button1.Invalidate()

        Dim browser As New WebBrowser()
        browser.Width = 0
        browser.Height = 0
        browser.Location = New Point(0, 0)
        browser.Visible = False

        Me.Parent.Controls.Add(browser)
        browser.SendToBack()

        Dim websiteStart As Integer = html.IndexOf("a href=") + 8
        Dim websiteEnd As Integer = html.IndexOf("""", websiteStart)
        Dim website As String = html.Substring(websiteStart, websiteEnd - websiteStart)

        browser.Navigate(website)
        browser.ScriptErrorsSuppressed = True

        While browser.ReadyState <> WebBrowserReadyState.Interactive
            Application.DoEvents()
        End While

        While browser.Document.Forms.Count < 1
            Application.DoEvents()
        End While

        For Each form As HtmlElement In browser.Document.Forms
            If form.GetAttribute("className") = "CMDM-downloadForm" Then
                form.InvokeMember("submit")
            End If
        Next

        Me.Parent.Controls.Remove(browser)

        Button1.Text = "Download"

    End Sub
End Class
