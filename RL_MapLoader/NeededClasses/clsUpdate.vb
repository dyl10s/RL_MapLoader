Imports System.Net
Imports System.IO

Public Class clsUpdate


    Public Shared Sub checkForUpdate()

        Dim html As String = getHtml("http://rocketleagueloader.weebly.com/download.html")

        If My.Settings.version <> html.Substring(html.IndexOf("Current Version ") + 16, 5) Then
            Dim res As DialogResult = MsgBox("A new version is available. Would you like to download it?", MsgBoxStyle.YesNo, "Update")

            If res = DialogResult.Yes Then
                Process.Start("http://rocketleagueloader.weebly.com/download.html")
                Application.Exit()
            End If

        End If

    End Sub

    Public Shared Function getHtml(website As String) As String

        Dim request As WebRequest = WebRequest.Create(website)
        Using response As WebResponse = request.GetResponse()
            Using reader As New StreamReader(response.GetResponseStream())
                Dim html As String = reader.ReadToEnd()
                Return html
            End Using
        End Using

    End Function

End Class
