Imports System.ComponentModel

Public Class frmMultiMenu

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        FlowLayoutPanel1.Left = Me.Width / 2 - FlowLayoutPanel1.Width / 2

    End Sub

    Private Sub frmMenu2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
        Me.CenterToScreen()

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        frmMultiNew.ShowDialog()

    End Sub

    Private Sub frmMultiMenu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        frmGloMenu.Show()

    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click

        frmMultiLoader.ShowDialog()

    End Sub
End Class