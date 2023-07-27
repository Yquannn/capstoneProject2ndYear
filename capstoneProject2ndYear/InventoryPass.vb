Public Class InventoryPass
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If UserName.Text = "admin" And Password.Text = "admin" Then
            Dim str As String = UserName.Text
            MessageBox.Show("Welcome" + " " + str + "!")
            Me.Hide()
            inventory.Show()
            Me.Hide()
            UserName.Text = ""
            Password.Text = ""

        Else
            MessageBox.Show("Invalid Account!")
        End If
    End Sub

    Private Sub InventoryPass_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Password_TextChanged(sender As Object, e As EventArgs) Handles Password.TextChanged

    End Sub

    Private Sub UserName_TextChanged(sender As Object, e As EventArgs) Handles UserName.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class