Public Class frmMultiMapSelect

    Public pramFolderLocation = ""

    Private Sub frmMultiMapSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size

        For Each file As String In My.Computer.FileSystem.GetFiles(pramFolderLocation)
            ListBox1.Items.Add(file.Split("\").Last)
        Next

    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click

        If Not ListBox1.SelectedItem Is Nothing Then

            My.Computer.FileSystem.RenameFile(pramFolderLocation & "\" & ListBox1.SelectedItem, "Park_P.upk")
            Me.Close()


        End If

    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick

        If Not ListBox1.SelectedItem Is Nothing Then

            My.Computer.FileSystem.RenameFile(pramFolderLocation & "\" & ListBox1.SelectedItem, "Park_P.upk")
            Me.Close()

        End If

    End Sub
End Class