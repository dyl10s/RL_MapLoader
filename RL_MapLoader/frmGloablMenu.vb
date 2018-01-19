Public Class frmGloMenu

    Dim needsLoad As Boolean = True

    Private Sub btnNewSng_Click(sender As Object, e As EventArgs) Handles btnNewSng.Click

        Dim frm As New Form
        frm = frmSngMenu
        Me.Hide()
        frm.ShowDialog()


    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click

        Dim frm As New Form
        frm = frmMultiMenu
        Me.Hide()
        frm.ShowDialog()

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

    Private Sub ChangePathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePathToolStripMenuItem.Click

        MsgBox("Please Select Your RocketLeague map path " & vbCrLf & "Ex. Steam\steamapps\common\rocketleague\TAGame\CookedPCConsole")
        FolderBrowserDialog1.ShowDialog()
        If FolderBrowserDialog1.SelectedPath.Contains("CookedPCConsole") Then
            My.Settings.rlPath = FolderBrowserDialog1.SelectedPath
            MsgBox("Path Changed!")
        Else
            MsgBox("Not a valid path!")
        End If

    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click

        Process.Start("http://rocketleagueloader.weebly.com/help.html")

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub frmGloMenu_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged


        If needsLoad = True Then
            needsLoad = False

            clsUpdate.checkForUpdate()

            If My.Settings.rlPath = "" Then

                getPath()

            End If

            If My.Settings.rlPath = "" Then
selectpath:
                MsgBox("Please Select Your RocketLeague map path " & vbCrLf & "Ex. Steam\steamapps\common\rocketleague\TAGame\CookedPCConsole")
                FolderBrowserDialog1.ShowDialog()
                If FolderBrowserDialog1.SelectedPath.Contains("CookedPCConsole") Then
                    My.Settings.rlPath = FolderBrowserDialog1.SelectedPath
                Else
                    MsgBox("Not a valid path!")
                    GoTo selectpath
                End If

            End If

        End If



    End Sub

    Private Sub frmGloMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        Me.CenterToScreen()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Hide()
        frmSiteBrowser.ShowDialog()

    End Sub
End Class