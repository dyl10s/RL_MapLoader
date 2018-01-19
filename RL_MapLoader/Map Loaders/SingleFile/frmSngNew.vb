Public Class frmSngNew

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click

        OpenFileDialog1.Filter = "Map Files (*.upk)|*.upk"
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.CheckPathExists = True Then
            txtMap.Text = OpenFileDialog1.FileName
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim shortNameNumber As Integer = 0
        Dim shortName As String = "Park_" & txtName.Text.First

        While My.Computer.FileSystem.FileExists(My.Settings.rlPath & "\" & shortName & ".upk")
            If shortNameNumber < 10 Then
                shortName = "Park" & shortNameNumber & txtName.Text.First
            ElseIf shortNameNumber < 100 Then
                shortName = "Par" & shortNameNumber & txtName.Text.First
            End If
            shortNameNumber += 1
        End While

        If txtMap.Text <> "" AndAlso txtName.Text <> "" Then

            Dim file As New DSOFile.OleDocumentProperties
            My.Computer.FileSystem.CopyFile(txtMap.Text, My.Settings.rlPath & "\" & shortName & ".upk")
            My.Computer.FileSystem.CopyFile(txtMap.Text, System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderSingle\" & shortName & ".upk")

            file.Open(My.Settings.rlPath & "\" & shortName & ".upk", DSOFile.dsoFileOpenOptions.dsoOptionDefault)
            file.SummaryProperties.Company = txtName.Text
            file.SummaryProperties.Author = "AngryCarrot"
            file.Save()
            file.Close()

            file.Open(System.AppDomain.CurrentDomain.BaseDirectory() & "\AngryCarrotsLoaderSingle\" & shortName & ".upk", DSOFile.dsoFileOpenOptions.dsoOptionDefault)
            file.SummaryProperties.Company = txtName.Text
            file.SummaryProperties.Author = "AngryCarrot"
            file.Save()
            file.Close()

            If System.Diagnostics.Process.GetProcessesByName("RocketLeague").Length > 0 Then
                Dim choice As MsgBoxResult = MsgBox("Map ready to load! You will have to restart Rocket League for this map to work. Would You like to restart Rocket League.", MessageBoxButtons.YesNo, "Restart")

                If choice = DialogResult.Yes Then

                    Dim proc As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName("RocketLeague").Last
                    Dim path As String = proc.MainModule.FileName
                    proc.Kill()
                    Process.Start(path)

                ElseIf choice = DialogResult.No


                End If
            Else
                MsgBox("Map ready to load!")
            End If



            txtMap.Clear()
            txtName.Clear()

        Else
            MsgBox("Please enter all fields before saving!")
        End If


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frmNewMap_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        Me.CenterToScreen()

    End Sub
End Class