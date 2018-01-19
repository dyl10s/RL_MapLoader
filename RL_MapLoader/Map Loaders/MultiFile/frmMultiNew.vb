Imports System.IO
Imports System.IO.Compression

Imports SharpCompress.Archive
Imports SharpCompress.Common

Public Class frmMultiNew

    Private Sub NewMapMulti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        Me.CenterToScreen()

    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click

        OpenFileDialog1.Filter = "Compressed Files (*.zip, *.rar)|*.zip;*.rar"
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.CheckPathExists = True Then
            txtMap.Text = OpenFileDialog1.FileName
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim zipPath As String = txtMap.Text
        Dim extractPath As String = System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderMulti\" & txtName.Text

        If txtName.Text <> "" Then
            If My.Computer.FileSystem.FileExists(txtMap.Text) Then

                If My.Computer.FileSystem.DirectoryExists(System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderMulti\" & txtName.Text) Then

                    If MsgBox("This map name already exists would you like to update it with the new file?", MsgBoxStyle.YesNo, "Update") = DialogResult.Yes Then

                        My.Computer.FileSystem.DeleteDirectory(System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderMulti\" & txtName.Text, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        My.Computer.FileSystem.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderMulti\" & txtName.Text)

                    Else

                        MsgBox("Please choose another name.")
                        Exit Sub

                    End If

                Else

                    My.Computer.FileSystem.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderMulti\" & txtName.Text)

                End If

                Dim archive As IArchive = ArchiveFactory.Open(zipPath)
                For Each entry In archive.Entries
                    If Not entry.IsDirectory Then
                        Console.WriteLine(entry.FilePath)
                        entry.WriteToDirectory(extractPath,
                                                ExtractOptions.ExtractFullPath Or ExtractOptions.Overwrite)
                    End If
                Next

                Dim deleteDir As New List(Of String)

                For Each folder As String In My.Computer.FileSystem.GetDirectories(extractPath)
                    For Each file As String In My.Computer.FileSystem.GetFiles(folder)

                        My.Computer.FileSystem.MoveFile(file, extractPath & "\" & file.Split("\").Last)

                    Next

                    deleteDir.Add(folder)

                Next

                If deleteDir.Count > 0 Then
                    My.Computer.FileSystem.DeleteDirectory(deleteDir.Last, FileIO.DeleteDirectoryOption.DeleteAllContents)
                End If


                'ZipFile.ExtractToDirectory(zipPath, extractPath)

            End If
        End If

        Dim foundPark As Boolean = False

        For Each file As String In My.Computer.FileSystem.GetFiles(extractPath)
            If file.Split("\").Last.ToLower = "park_p.upk" Then
                foundPark = True
            End If
        Next

        If foundPark = False Then
            Dim frm As Form = frmMultiMapSelect
            frmMultiMapSelect.pramFolderLocation = extractPath
            frm.ShowDialog()
        End If

        MsgBox("Map Saved!")
        txtMap.Clear()
        txtName.Clear()

    End Sub

End Class