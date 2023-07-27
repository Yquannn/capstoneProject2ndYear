Imports System.Data.SqlClient


Public Class inventory
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\source\repos\capstoneProject2ndYear\capstoneProject2ndYear\ProductVbDb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()

    End Sub
    Public Sub populated()
        Con.Open()
        Dim sql = "Select * from ProductTb3"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, Con)
        Dim builder = New SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        ProductDVG2.DataSource = ds.Tables(0)
        Con.Close()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ProductDVG_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ProductDVG2.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = Me.ProductDVG2.Rows(e.RowIndex)

            MaterialId.Text = row.Cells("id").Value.ToString()
            Material.Text = row.Cells("Material").Value.ToString()
            Count.Text = row.Cells("Count").Value.ToString()
            Price.Text = row.Cells("Price").Value.ToString()

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)



    End Sub

    Public Sub CalcTotal()

        Dim colSum As Decimal
        For Each R As DataGridViewRow In ProductDVG2.Rows
            colSum += R.Cells(3).Value
        Next
        TotalExpenses.Text = " " & ChrW(&H20B1) & colSum.ToString("#,##0.00")

    End Sub

    Private Sub inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CalcTotal()
        populated()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub MaterialId_TextChanged(sender As Object, e As EventArgs)

    End Sub




    Private Sub Count_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Count.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Price_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Price.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub MaterialId_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Search.TextChanged

        Dim query As String = "SELECT * FROM ProductTb3 WHERE Material LIKE '%" & Search.Text & "%' OR Id LIKE '%" & Search.Text & "%'"

        Using Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\source\repos\capstoneProject2ndYear\capstoneProject2ndYear\ProductVbDb.mdf;Integrated Security=True;Connect Timeout=30")
            Using cmd As New SqlCommand(query, Con)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            ProductDVG2.DataSource = dt
                        Else
                            MsgBox("No record found!")
                            Search.Text = ""
                        End If
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
        Dim myId As Guid = Guid.NewGuid()
        Dim myIdString = myId.ToString().Substring(0, 20)
        MaterialId.Text = myIdString



    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Material.Text = ""
        Count.Text = ""
        Price.Text = ""
        MaterialId.Text = ""
        Search.Text = ""
    End Sub

    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles Button2.Click
        If MaterialId.Text = "" Then
            Dim myId As Guid = Guid.NewGuid()
            Dim myIdString = myId.ToString().Substring(0, 10)
            MaterialId.Text = myIdString

        End If
        Try
            If Material.Text = "" Then
                MsgBox("Insert Material!")
            ElseIf Count.Text = "" Then
                MsgBox("Insert Count!")
            ElseIf Price.Text = "" Then
                MsgBox("Insert Price!")
            Else
                If Con.State = ConnectionState.Closed Then
                    Con.Open()

                    Dim query As String
                    query = "INSERT INTO ProductTb3 (Id, Material, Count, Price, DateTime) VALUES (@Id, @Material, @Count, @Price, GETDATE())"
                    Dim cmd As SqlCommand
                    cmd = New SqlCommand(query, Con)
                    cmd.Parameters.AddWithValue("@Id", MaterialId.Text)
                    cmd.Parameters.AddWithValue("@Material", Material.Text.ToUpper)
                    cmd.Parameters.AddWithValue("@Count", Integer.Parse(Count.Text))
                    cmd.Parameters.AddWithValue("@Price", Decimal.Parse(Price.Text))
                    cmd.ExecuteNonQuery()
                    MsgBox("Material added Successfully!")

                    Material.Text = ""
                    Count.Text = ""
                    Price.Text = ""
                    MaterialId.Text = ""
                    Con.Close()
                    populated()

                End If
            End If
        Catch ex As Exception
            MsgBox("Error adding product: " & ex.Message)
            'Material.Text = ""
            'Count.Text = ""
            'Price.Text = ""
            'MaterialId.Text = ""
        End Try
        Con.Close()

        CalcTotal()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If Material.Text = "" Or Count.Text = "" Or Price.Text = "" Then
            CalcTotal()
            MsgBox("Please Fill up the data you want to Update")
        Else
            Con.Open()
            Dim sql = "UPDATE ProductTb3 SET Material=@Material, Count=@Count, Price=@Price WHERE Id=@MaterialId"
            If MaterialId.Text = "" Then
                'Dim colSum As Decimal
                'For Each R As DataGridViewRow In ProductDVG2.Rows
                '    colSum += R.Cells(3).Value
                'Next
                'TotalExpenses.Text = colSum
                MsgBox("Enter Material Id")
            Else
                Dim cmd As New SqlCommand(sql, Con)
                cmd.Parameters.AddWithValue("@Material", Material.Text)
                cmd.Parameters.AddWithValue("@Count", Count.Text)
                cmd.Parameters.AddWithValue("@Price", Price.Text)
                cmd.Parameters.AddWithValue("@MaterialId", MaterialId.Text)
                cmd.ExecuteNonQuery()
                MsgBox("Product Updated!")
                Con.Close()
                populated()
                Material.Text = ""
                Count.Text = ""
                Price.Text = ""
                MaterialId.Text = ""

                CalcTotal()

            End If
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If MaterialId.Text = "" Then
                MsgBox("Enter Material ID to be deleted!")
            Else
                Con.Open()



                Dim query As String = "DELETE FROM productTb3 WHERE Id= @MaterialId"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@MaterialId", MaterialId.Text)
                cmd.ExecuteNonQuery()
                MsgBox("Material deleted successfully!")
                Con.Close()
                populated()
                MaterialId.Text = ""
                Material.Text = ""
                Count.Text = ""
                Price.Text = ""

                CalcTotal()




            End If

        Catch ex As Exception
            MsgBox("Error Deleting Material: " & ex.Message)
            MaterialId.Text = ""

        End Try
    End Sub
End Class