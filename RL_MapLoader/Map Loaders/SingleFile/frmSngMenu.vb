Imports System.ComponentModel
Imports System.IO

Public Class frmSngMenu

    Public Shared rlAdress As String = ""

    Public Shared maps As List(Of String)

    Public Shared processLinked As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnChange.Click

        If System.Diagnostics.Process.GetProcessesByName("RocketLeague").Length > 0 Then

            If processLinked = False Then

                If My.Settings.lastProcess = System.Diagnostics.Process.GetProcessesByName("RocketLeague").Last.SessionId Then

                    rlAdress = My.Settings.lastAdress
                    frmSngLoader.ShowDialog()

                Else

                    If linkProcess() = True Then
                        frmSngLoader.ShowDialog()
                    End If

                End If

            Else
                frmSngLoader.ShowDialog()
            End If

        Else

            Dim result As DialogResult = MsgBox("Rocket League Needs To Be Open! Would You Like To Open It Now?", MsgBoxStyle.YesNo, "Open Rocket League")

            If result = DialogResult.Yes Then

                Dim splitString As String = My.Settings.rlPath.ToString


                splitString = splitString.Remove(splitString.IndexOf("common\rocketleague") + 19)
                splitString += "\Binaries\Win32\RocketLeague.exe"

                Process.Start(splitString)

            End If

        End If


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        FlowLayoutPanel1.Left = Me.Width / 2 - FlowLayoutPanel1.Width / 2

    End Sub

    Public Function linkProcess() As Boolean

        getRLAdress()

        If rlAdress = "" Or rlAdress = "False" Then

            MsgBox("Error, Rocket League process has Not been found! Please open/re-open Rocket League And link it again.")
            Return False
        Else

            processLinked = True
            Console.WriteLine(rlAdress)
            Return True

        End If

    End Function

    Public Sub showLoad()

        lblLoad.Show()
        lblLoad.BringToFront()
        lblLoad.Invalidate()
        Application.DoEvents()

    End Sub

    Public Sub hideLoad()

        lblLoad.Hide()
        lblLoad.SendToBack()
        lblLoad.Invalidate()
        Application.DoEvents()

    End Sub

    Public Sub getRLAdress()

        Dim oldClipboard As String = ""

        oldClipboard = My.Computer.Clipboard.GetText

        My.Computer.Clipboard.Clear()

        showLoad()

        Dim ce As New ProcessStartInfo(System.AppDomain.CurrentDomain.BaseDirectory() & "\CE\cheatengine-i386.exe")
        ce.WindowStyle = ProcessWindowStyle.Hidden
        ce.CreateNoWindow = True

        System.Diagnostics.Process.Start(ce)

        While My.Computer.Clipboard.GetText = ""
            Console.WriteLine("Waiting For CE")
        End While

        System.Diagnostics.Process.GetProcessesByName("cheatengine-i386").Last.Kill()


        rlAdress = My.Computer.Clipboard.GetText

        My.Computer.Clipboard.SetText(oldClipboard)

        hideLoad()

    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        Me.CenterToScreen()

    End Sub

    Public Sub getPath()

        showLoad()

        If My.Computer.FileSystem.DirectoryExists("C:\Program Files (x86)\Steam\steamapps\common\rocketleague\TAGame\CookedPCConsole\") Then
            My.Settings.rlPath = "C:\Program Files (x86)\Steam\steamapps\common\rocketleague\TAGame\CookedPCConsole"
        End If

        If My.Computer.FileSystem.FileExists("C:\Program Files\Steam\steamapps\common\rocketleague\TAGame\CookedPCConsole\") Then
            My.Settings.rlPath = "C:\Program Files\Steam\steamapps\common\rocketleague\TAGame\CookedPCConsole"
        End If

        hideLoad()


    End Sub

    Private Sub ChangePathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePathToolStripMenuItem.Click

        MsgBox("Please Select Your RocketLeague map path " & vbCrLf & "Ex. Steam\steamapps\common\rocketleague\TAGame\CookedPCConsole")
        FolderBrowserDialog1.ShowDialog()

        If FolderBrowserDialog1.SelectedPath.Contains("CookedPCConsole") Then
            My.Settings.rlPath = FolderBrowserDialog1.SelectedPath
            MsgBox("Path has been changed!")
        Else
            MsgBox("Not a valid path!")
        End If

    End Sub

    Public Sub syncFiles()

        showLoad()

        If My.Settings.firstLoad = True Then

            Dim listOfFiles As New List(Of String)

            For Each f As String In Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderSingle")
                listOfFiles.Add(f)
            Next

            setMapName(listOfFiles.Item(0), "[Default] Euro Stadium Rainy")
            setMapName(listOfFiles.Item(1), "[Default] Euro Stadium")
            setMapName(listOfFiles.Item(2), "[Default] Hoops Stadium")
            setMapName(listOfFiles.Item(3), "[Default] Labs Cosmic")
            setMapName(listOfFiles.Item(4), "[Default] Labs Underpass")
            setMapName(listOfFiles.Item(5), "[Default] Labs Circle Pillars")
            setMapName(listOfFiles.Item(6), "[Default] Labs Double Goal")
            setMapName(listOfFiles.Item(7), "[Default] Labs Utopia")
            setMapName(listOfFiles.Item(8), "[Default] Neo Tokyo")
            setMapName(listOfFiles.Item(9), "[Default] Stadium Winter")
            setMapName(listOfFiles.Item(10), "[Default] Train Station")
            setMapName(listOfFiles.Item(11), "[Default] Park Night")
            setMapName(listOfFiles.Item(12), "[Default] Park Rainy")
            setMapName(listOfFiles.Item(13), "[Default] Stadium")
            setMapName(listOfFiles.Item(14), "[Default] Utopia Stadium")
            setMapName(listOfFiles.Item(15), "[Default] Volleyball")
            setMapName(listOfFiles.Item(16), "[Default] Wasteland")

            My.Settings.firstLoad = False
        End If


        If My.Computer.FileSystem.DirectoryExists(System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderSingle") Then
        Else
            My.Computer.FileSystem.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderSingle")
        End If

        Dim dir As New System.IO.DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderSingle")
        Dim files As System.IO.FileInfo() = dir.GetFiles

        For Each file As System.IO.FileInfo In files

            If My.Computer.FileSystem.FileExists(My.Settings.rlPath & "\" & file.Name) Then
            Else


                Dim dsoF As New DSOFile.OleDocumentProperties
                dsoF.Open(file.FullName, DSOFile.dsoFileOpenOptions.dsoOptionDefault)
                Dim fileName As String = dsoF.SummaryProperties.Company
                dsoF.Close()

                My.Computer.FileSystem.CopyFile(file.FullName, My.Settings.rlPath & "\" & file.Name)

                dsoF.Open(My.Settings.rlPath & "\" & file.Name, DSOFile.dsoFileOpenOptions.dsoOptionDefault)
                dsoF.SummaryProperties.Company = fileName
                dsoF.SummaryProperties.Author = "AngryCarrot"
                dsoF.Save()
                dsoF.Close()

            End If
        Next

        hideLoad()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        frmSngNew.ShowDialog()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If System.Diagnostics.Process.GetProcessesByName("RocketLeague").Length > 0 Then
        Else
            processLinked = False
        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        Me.Close()

    End Sub

    Public Sub setMapName(path As String, filename As String)

        Dim dsoF As New DSOFile.OleDocumentProperties

        dsoF.Open(path, DSOFile.dsoFileOpenOptions.dsoOptionDefault)
        dsoF.SummaryProperties.Company = filename
        dsoF.SummaryProperties.Author = "AngryCarrot"
        dsoF.Save()
        dsoF.Close()

    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click

        Process.Start("http://rocketleagueloader.weebly.com/help.html")

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Process.Start("http://rocketleagueloader.weebly.com/help.html")

    End Sub

    Private Sub frmMenu_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged

        syncFiles()

    End Sub

    Private Sub frmSngMenu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        frmGloMenu.Show()

    End Sub
End Class