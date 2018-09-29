Public Class ToolManagement

    Private Sub UserControl2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Left = 10
        ListView1.Top = 20
        ListView1.Width = Me.ClientSize.Width - 20
        ListView1.Height = 80

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class
