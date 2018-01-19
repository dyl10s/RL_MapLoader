Imports System.ComponentModel

Public Class frmSiteBrowser
    Private Sub frmSiteBrowser_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        frmGloMenu.Show()

    End Sub

    Private Sub frmSiteBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MinimumSize = Me.Size
        lblLoad.Visible = True
        lblLoad.BringToFront()
        Me.Invalidate()
        lblLoad.Invalidate()


    End Sub

    Private Sub frmSiteBrowser_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged

        tmrLoad.Enabled = True

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Label6.Left = (Label6.Parent.Width \ 2) - (Label6.Width \ 2)

    End Sub

    Private Sub tmrLoad_Tick(sender As Object, e As EventArgs) Handles tmrLoad.Tick

        tmrLoad.Enabled = False

        Dim html As String = clsUpdate.getHtml("http://rocketleaguemods.com/mods/?category=arena-maps,other-maps,race-maps,training-maps")

        html = html.Split(New String() {"vgmmodsarea"}, StringSplitOptions.None)(1)
        Dim count As Integer = html.Split(New String() {"<li class"}, StringSplitOptions.None).Count

        For i As Integer = 0 To count - 2
            Dim ctrl As New UserControl1
            ctrl.pramItemNumber = i
            FlowLayoutPanel1.Controls.Add(ctrl)
        Next

        FlowLayoutPanel1.AutoScroll = True

        lblLoad.Visible = False
        lblLoad.Invalidate()

    End Sub
End Class