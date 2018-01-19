Imports System.ComponentModel

Public Class frmMultiLoader

    Dim baseDir As String = System.AppDomain.CurrentDomain.BaseDirectory() & "AngryCarrotsLoaderMulti\"

    Dim fileNames As New List(Of String)
    Dim backupFiles As New List(Of String)

    Public Sub filllistbox()

        For Each Dir As String In System.IO.Directory.GetDirectories(baseDir)
            If txtSelectedMap.Items.Contains(Dir.Split("\").Last) Then
            Else
                txtSelectedMap.Items.Add(Dir.Split("\").Last)
            End If
        Next

    End Sub

    Private Sub MapLoader_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        Me.CenterToScreen()

        filllistbox()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        showLoad()

        If My.Computer.FileSystem.DirectoryExists(baseDir & txtSelectedMap.Text) Then
            If Process.GetProcessesByName("RocketLeague").Length < 1 Then

                copyFiles(txtSelectedMap.Text)
                If MsgBox("Map Loaded! Would you like to start Rocket League?", MsgBoxStyle.YesNo, "Start") = DialogResult.Yes Then

                    startRL()

                End If
            Else
                Dim result = MsgBox("Rocket Leauge needs to be restarted to load the map. Would you like to do this now?", MsgBoxStyle.YesNo, "Restart")

                If result = DialogResult.Yes Then

                    For Each proc As Process In Process.GetProcessesByName("RocketLeague")
                        proc.Kill()
                        While proc.HasExited = False
                        End While
                    Next

                    copyFiles(txtSelectedMap.Text)


                    startRL()

                    MsgBox("Map Loaded!")

                End If

                If result = DialogResult.No Then
                    MsgBox("Map Not Loaded.")
                End If

            End If

        ElseIf txtSelectedMap.Text = "[Default]"

            If Process.GetProcessesByName("RocketLeague").Length < 1 Then

                For Each file As String In My.Computer.FileSystem.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory() & "\RL_BackUp\")
                    My.Computer.FileSystem.CopyFile(file, My.Settings.rlPath & "\" & file.Split("\").Last, True)
                Next

                If MsgBox("Map Loaded! Would you like to start Rocket League?", MsgBoxStyle.YesNo, "Start") = DialogResult.Yes Then

                    startRL()

                End If

            Else

                Dim result = MsgBox("Rocket Leauge needs to be restarted to load the map. Would you like to do this now?", MsgBoxStyle.YesNo, "Restart")

                If result = DialogResult.Yes Then

                    For Each proc As Process In Process.GetProcessesByName("RocketLeague")
                        proc.Kill()
                        While proc.HasExited = False
                        End While
                    Next

                    For Each file As String In My.Computer.FileSystem.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory() & "\RL_BackUp\")
                        My.Computer.FileSystem.CopyFile(file, My.Settings.rlPath & "\" & file.Split("\").Last, True)
                    Next

                    startRL()

                    MsgBox("Map Loaded!")

                Else

                    MsgBox("Map Not Loaded.")

                End If
            End If
        End If

        hideload()

    End Sub

    Public Sub copyFiles(fName As String)

        Dim backUpDir As String = System.AppDomain.CurrentDomain.BaseDirectory() & "\RL_BackUp\"

        For Each file As String In System.IO.Directory.GetFiles(baseDir & fName)
            fileNames.Add(file)
        Next

        'BACK-UP
        'If My.Computer.FileSystem.DirectoryExists(backUpDir) Then

        '    For Each file As String In My.Computer.FileSystem.GetFiles(backUpDir)
        '        My.Computer.FileSystem.CopyFile(file, My.Settings.rlPath & file.Split("\").Last, True)
        '    Next

        '    My.Computer.FileSystem.DeleteDirectory(backUpDir, FileIO.DeleteDirectoryOption.DeleteAllContents)
        '    My.Computer.FileSystem.CreateDirectory(backUpDir)

        '    For Each RLfile As String In System.IO.Directory.GetFiles(My.Settings.rlPath)
        '        If RLfile.Contains(".upk") Then
        '            For Each replaceFile As String In fileNames
        '                If RLfile.Split("\").Last.ToLower = replaceFile.Split("\").Last.ToLower Then
        '                    backupFiles.Add(RLfile)
        '                End If
        '            Next
        '        End If
        '    Next

        'Else

        '    My.Computer.FileSystem.CreateDirectory(backUpDir)

        '    For Each RLfile As String In System.IO.Directory.GetFiles(My.Settings.rlPath)
        '        For Each replaceFile As String In fileNames
        '            MsgBox(RLfile.Split("\").Last)
        '            If RLfile.Split("\").Last = replaceFile.Split("\").Last Then
        '                backupFiles.Add(RLfile)
        '            End If
        '        Next
        '    Next

        'End If

        'For Each file As String In backupFiles
        '    My.Computer.FileSystem.CopyFile(file, backUpDir & file.Split("\").Last, True)
        'Next

        For Each file As String In fileNames
            My.Computer.FileSystem.CopyFile(file, My.Settings.rlPath & "\" & file.Split("\").Last, True)
        Next

    End Sub

    Private Sub frmMultiLoader_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        For Each file As String In My.Computer.FileSystem.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory() & "\RL_BackUp\")
            My.Computer.FileSystem.CopyFile(file, My.Settings.rlPath & "\" & file.Split("\").Last, True)
        Next

    End Sub

    Public Sub startRL()

        Dim splitString As String = My.Settings.rlPath.ToString


        splitString = splitString.Remove(splitString.IndexOf("common\rocketleague") + 19)
        splitString += "\Binaries\Win32\RocketLeague.exe"

        Process.Start(splitString)

    End Sub

    Public Sub showLoad()

        lblLoad.BringToFront()
        lblLoad.Visible = True

    End Sub

    Public Sub hideload()

        lblLoad.SendToBack()
        lblLoad.Visible = False

    End Sub

End Class