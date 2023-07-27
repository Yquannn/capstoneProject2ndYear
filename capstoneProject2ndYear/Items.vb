Imports System.Data.SqlClient
'Imports capstoneProject2ndYear.Transaction

Public Class Items
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\source\repos\capstoneProject2ndYear\capstoneProject2ndYear\ProductVbDb.mdf;Integrated Security=True;Connect Timeout=30")
    Dim sqlQuery As String = "SELECT * FROM ProductTb1 WHERE ProductId = @ProductId"



    Public Sub populate()
        Con.Open()
        Dim sql = "Select * from ProductTb1"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, Con)
        Dim builder = New SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        ProductDVG.DataSource = ds.Tables(0)
        Con.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub


    Private Sub Items_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim myClassObj As New Transaction()
        'myClassObj.UpdatedQty()
        populate()
        ProductDVG.Refresh()



    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ProductDVG_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ProductDVG.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = Me.ProductDVG.Rows(e.RowIndex)

            ProductId.Text = row.Cells("ProductId").Value.ToString()
            ProductName.Text = row.Cells("ProductName").Value.ToString()
            Quantity.Text = row.Cells("Quantity").Value.ToString()
            Price.Text = row.Cells("Price").Value.ToString()

        End If


    End Sub




    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub




    'UPDATE
    Private Sub Button2_Click(sender As Object, e As EventArgs)




    End Sub

    Private Sub ProductId_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub Quantity_TextChanged(sender As Object, e As EventArgs) Handles Quantity.TextChanged

    End Sub

    Private Sub Quantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Quantity.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Price_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Price.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ProductName_TextChanged(sender As Object, e As EventArgs) Handles ProductName.TextChanged

    End Sub

    Private Sub Search_TextChanged(sender As Object, e As EventArgs) Handles Search.TextChanged
        Dim query As String = "SELECT * FROM ProductTb1 WHERE ProductId LIKE '%" & Search.Text & "%' OR ProductName LIKE '%" & Search.Text & "%'"

        Using Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\source\repos\capstoneProject2ndYear\capstoneProject2ndYear\ProductVbDb.mdf;Integrated Security=True;Connect Timeout=30")
            Using cmd As New SqlCommand(query, Con)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            ProductDVG.DataSource = dt
                        Else
                            MsgBox("No record found!")
                            Search.Text = ""

                        End If
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub ProductId_TextChanged(sender As Object, e As EventArgs)

    End Sub

    'Public Sub RefreshComboBox(Order As ComboBox, dataSource As Object)
    '    ' Set the data source for the ComboBox control
    '    Order.DataSource = dataSource
    '    ' Refresh the ComboBox control
    '    Order.Refresh()
    'End Sub

    'Private Function GetDataTableFromDatabase() As DataTable
    '    ' Create a new SqlConnection and SqlCommand objects
    '    Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\source\repos\capstoneProject2ndYear\capstoneProject2ndYear\ProductVbDb.mdf;Integrated Security=True;Connect Timeout=30"
    '    Dim connection As New SqlConnection(connectionString)
    '    Dim command As New SqlCommand("SELECT * FROM ProductTb1", connection)

    '    ' Create a new DataTable to store the data from the database
    '    Dim dataTable As New DataTable()

    '    ' Use a SqlDataAdapter to fill the DataTable with data from the database
    '    Dim adapter As New SqlDataAdapter(command)
    '    adapter.Fill(dataTable)

    '    ' Return the filled DataTable as the new data source
    '    Return dataTable
    'End Function

    'Private Sub RefreshComboBoxOnOtherForm()
    '    ' Get the reference to the other form
    '    Dim transaction As Transaction = CType(Application.OpenForms("Transaction"), Transaction)

    '    ' Get the new data source for the ComboBox control
    '    Dim newDataSource As Object = GetDataTableFromDatabase()

    '    ' Call the RefreshComboBox method to update the ComboBox control
    '    RefreshComboBox(transaction.Order, newDataSource)
    'End Sub




    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim password As String = "admin" ' Replace with your actual password

        Dim enteredPassword As String = InputBox("Enter the admin password:")


        If enteredPassword = password Then
            MsgBox("Password is correct!")
            Try
                If String.IsNullOrWhiteSpace(ProductName.Text) OrElse String.IsNullOrWhiteSpace(Quantity.Text) OrElse String.IsNullOrWhiteSpace(Price.Text) Then
                    MsgBox("Please add a product.")
                Else

                    Con.Open()
                    Dim query As String = "INSERT INTO ProductTb1 (ProductId, ProductName, Quantity, Price, DateTime) VALUES (@ProductId, @ProductName, @Quantity, @Price, GETDATE())"
                    Using cmd As New SqlCommand(query, Con)
                        cmd.Parameters.AddWithValue("@ProductId", Guid.NewGuid().ToString().Substring(0, 10))
                        cmd.Parameters.AddWithValue("@ProductName", ProductName.Text.ToUpper())
                        cmd.Parameters.AddWithValue("@Quantity", Integer.Parse(Quantity.Text))
                        cmd.Parameters.AddWithValue("@Price", Decimal.Parse(Price.Text))
                        cmd.ExecuteNonQuery()
                    End Using
                    Con.Close()

                    MsgBox("Product added successfully!")
                    ProductId.Text = ""
                    ProductName.Text = ""
                    Quantity.Text = ""
                    Price.Text = ""
                    populate()

                End If
            Catch ex As Exception
                MsgBox("An error occurred: " & ex.Message)
            End Try
        Else
        ' Display an error message when the password is incorrect
        MsgBox("Incorrect password!")
        End If


    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim password As String = "admin" ' Replace with your actual password

        Dim enteredPassword As String = InputBox("Enter the admin password:")


        If enteredPassword = password Then
            MsgBox("Password is correct!")
            If ProductId.Text = "" Then
            MsgBox("Enter Product ID to be deleted!")
        Else
            Con.Open()

            Dim query As String = "DELETE FROM productTb1 WHERE ProductId= @ProductId"
            Dim cmd As SqlCommand

            cmd = New SqlCommand(query, Con)
            cmd.Parameters.AddWithValue("@ProductId", ProductId.Text)
            cmd.ExecuteNonQuery()
            MsgBox("Product deleted successfully!")
            Con.Close()
            populate()
            ProductId.Text = ""
            ProductName.Text = ""
            Quantity.Text = ""
            Price.Text = ""

        End If
        Else
        ' Display an error message when the password is incorrect
        MsgBox("Incorrect password!")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim password As String = "admin" ' Replace with your actual password

        Dim enteredPassword As String = InputBox("Enter the admin password:")


        If enteredPassword = password Then
            MsgBox("Password is correct!")

            If ProductId.Text = "" Or Quantity.Text = "" Or Price.Text = "" Then
                MsgBox("Please Fill up the data you want to Update")
            Else
                Con.Open()
                Dim sql = "UPDATE ProductTb1 SET ProductName=@ProductName, Quantity=@Quantity, Price=@Price WHERE ProductId=@ProductId"
                Dim cmd As New SqlCommand(sql, Con)
                cmd.Parameters.AddWithValue("@ProductName", ProductName.Text)
                cmd.Parameters.AddWithValue("@Quantity", Quantity.Text)
                cmd.Parameters.AddWithValue("@Price", Price.Text)
                cmd.Parameters.AddWithValue("@ProductId", ProductId.Text)
                cmd.ExecuteNonQuery()
                MsgBox("Materials Updated!")
                Con.Close()
                populate()
                ProductId.Text = ""
                ProductName.Text = ""
                Quantity.Text = ""
                Price.Text = ""

            End If
        Else
            ' Display an error message when the password is incorrect
            MsgBox("Incorrect password!")
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ProductId.Text = ""
        ProductName.Text = ""
        Quantity.Text = ""
        Price.Text = ""
        Search.Text = ""
    End Sub
End Class
