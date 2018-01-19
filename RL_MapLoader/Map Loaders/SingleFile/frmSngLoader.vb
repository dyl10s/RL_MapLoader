Public Class frmSngLoader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If txtSelectedMap.Text <> "" Then


            If txtSelectedMap.Text = "[Default]" Then

                updateRLMap("Park_p")
                MsgBox("Map Loaded Successfully!")

                Exit Sub

            End If

            Dim dir As New System.IO.DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderSingle")
            Dim files As System.IO.FileInfo() = dir.GetFiles

            For Each file As System.IO.FileInfo In files
                If file.Name.Length = 10 Then

                    Dim fileInfo As New DSOFile.OleDocumentProperties

                    Try
                        fileInfo.Open(file.FullName, True, DSOFile.dsoFileOpenOptions.dsoOptionDefault)
                    Catch ex As Exception
                        MsgBox(ex.GetBaseException.ToString)
                    End Try

                    If fileInfo.SummaryProperties.Company <> Nothing Then
                        If fileInfo.SummaryProperties.Company.ToString = txtSelectedMap.Text Then

                            Console.WriteLine("Read File: " & file.Name)
                            updateRLMap(fileInfo.Name.Split(".")(0))
                            fileInfo.Close()
                            MsgBox("Map Loaded Successfully! Open Up Freeplay Training To Play!")
                            Exit Sub

                        End If
                    End If
                End If


                Console.WriteLine("Read File: " & file.Name)

            Next
        Else
            MsgBox("Please Select A Map!")
        End If

    End Sub

    Public Sub updateRLMap(mapName As String)

        Dim ASCIIEncoding As New System.Text.ASCIIEncoding()
        Dim encodedString() As Byte

        encodedString = ASCIIEncoding.GetBytes(mapName)

        If frmSngMenu.rlAdress <> "False" Or frmSngMenu.rlAdress <> "" Then
            Dim p As Process = System.Diagnostics.Process.GetProcessesByName("RocketLeague").Last
            Poke(p, Convert.ToInt32(frmSngMenu.rlAdress, 16), encodedString)

            My.Settings.lastAdress = frmSngMenu.rlAdress
            My.Settings.lastProcess = System.Diagnostics.Process.GetProcessesByName("RocketLeague").Last.SessionId

        Else
            MsgBox("Error, Rocket League process has not been found! Please open/re-open Rocket League and link it again.")
        End If

    End Sub

    Public Sub fillListBoxWithFileCompany()

        txtSelectedMap.Items.Clear()
        txtSelectedMap.Items.Add("[Default]")

        If My.Computer.FileSystem.DirectoryExists(System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderSingle") Then
        Else
            My.Computer.FileSystem.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderSingle")
        End If

        Dim dir As New System.IO.DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderSingle")
        Dim files As System.IO.FileInfo() = dir.GetFiles


        For Each file As System.IO.FileInfo In files

            Dim fileInfo As New DSOFile.OleDocumentProperties

            fileInfo.Open(file.FullName, True, DSOFile.dsoFileOpenOptions.dsoOptionDefault)

            If fileInfo.SummaryProperties.Author = "AngryCarrot" Then

                Console.WriteLine("Read File: " & file.Name)
                txtSelectedMap.Items.Add(fileInfo.SummaryProperties.Company.ToString)

                fileInfo.Close()

            End If

            Console.WriteLine("Read File: " & file.Name)

        Next

    End Sub

    Private Sub MapLoader_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        Me.CenterToScreen()

        fillListBoxWithFileCompany()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class