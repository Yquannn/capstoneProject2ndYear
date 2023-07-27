Imports System.Data.SqlClient

Public Class Transaction
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\source\repos\capstoneProject2ndYear\capstoneProject2ndYear\ProductVbDb.mdf;Integrated Security=True;Connect Timeout=30")
    Dim adp As SqlDataAdapter

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
    End Sub

    Private Sub Transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FillCustomer()
        fillCategory()
        populate()

    End Sub


    Public Sub populate()
        Con.Open()

        Dim sql As String = "SELECT * FROM ProductTb4"
        Dim cmd As New SqlCommand(sql, Con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim builder As New SqlCommandBuilder(adapter)
        Dim ds As New DataSet()
        adapter.Fill(ds)
        ProductDVG3.DataSource = ds.Tables(0)
        Con.Close()
    End Sub

    Private Sub fillCategory()

        Con.Open()
        Dim sql = "Select * from ProductTb1"
        Dim cmd As New SqlCommand(sql, Con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim tb1 As New DataTable()
        adapter.Fill(tb1)
        Order.DataSource = tb1
        Order.DisplayMember = "ProductName"
        Order.ValueMember = "ProductName"
        If Order.Items.Count > 1 Then
            Order.SelectedIndex = -1
            'Order.SelectedText = "Select Order"
        End If

        Con.Close()
    End Sub



    Private Sub FillCustomer()

        Con.Open()
        Dim sql = "Select * from ProductTb4"
        Dim cmd As New SqlCommand(sql, Con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim tb1 As New DataTable()
        adapter.Fill(tb1)
        id.DataSource = tb1
        id.DisplayMember = "referenceNumber"
        id.ValueMember = "referenceNumber"

        If id.Items.Count > 1 Then
            id.SelectedIndex = -1
            'id.SelectedText = "Enter Id/Choose Id"
        End If

        Con.Close()
    End Sub
    Private Sub FillContact()
        Con.Open()
        Dim query = "SELECT * FROM ProductTb4 WHERE referenceNumber='" & id.SelectedValue.ToString() & "'"
        Dim cmd As New SqlCommand(query, Con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            Number.Text = reader(2).ToString
        End While
        Con.Close()
    End Sub


    Private Sub FillOrder()
        Con.Open()
        Dim query = "SELECT * FROM ProductTb4 WHERE referenceNumber='" & id.SelectedValue.ToString() & "'"
        Dim cmd As New SqlCommand(query, Con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            Order.Text = reader(4).ToString()
        End While
        Con.Close()

    End Sub

    Private Sub FillAddress()
        Con.Open()
        Dim query = "SELECT * FROM ProductTb4 WHERE id='" & id.SelectedValue.ToString() & "'"
        Dim cmd As New SqlCommand(query, Con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()

        While reader.Read
            address.Text = reader(3).ToString()
        End While



        Con.Close()

    End Sub

    Private Sub FillPrice()
        Con.Open()
        Dim query = "SELECT * FROM ProductTb1 WHERE ProductName='" & Order.SelectedValue.ToString() & "'"
        Dim cmd As New SqlCommand(query, Con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            Price.Text = reader(3).ToString() ' add the peso sign before the value
        End While
        Con.Close()
    End Sub




    Private Sub fillId()
        Con.Open()
        Dim query = "SELECT * FROM ProductTb1 WHERE ProductName='" & Order.SelectedValue.ToString() & "'"
        Dim cmd As New SqlCommand(query, Con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            ProdId.Text = reader(0).ToString()

        End While
        Con.Close()
    End Sub



    Private Sub fechName()
        If id.SelectedValue IsNot Nothing Then
            Con.Open()
            Dim query = "SELECT * FROM ProductTb4 WHERE referenceNumber='" & id.SelectedValue.ToString() & "'"

            Dim cmd As New SqlCommand(query, Con)
            Dim dt As New DataTable
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
            While reader.Read
                Name.Text = reader(1).ToString()
            End While
            Con.Close()
        End If
    End Sub



    'Private Sub FillId()
    '    Con.Open()
    '    Dim query = "SELECT * FROM ProductTb1 WHERE ProductId='" & id.SelectedValue.ToString() & "'"
    '    Dim cmd As New SqlCommand(query, Con)
    '    Dim dt As New DataTable
    '    Dim reader As SqlDataReader
    '    reader = cmd.ExecuteReader()
    '    While reader.Read
    '        ProdId.Text = reader(0).ToString
    '    End While
    '    Con.Close()
    'End Sub



    'Private Sub FillPrice()
    '    Con.Open()
    '    Dim query = "SELECT * FROM ProductTb1 WHERE ProductId='" & id.SelectedValue.ToString() & "'"
    '    Dim cmd As New SqlCommand(query, Con)
    '    Dim dt As New DataTable
    '    Dim reader As SqlDataReader
    '    reader = cmd.ExecuteReader()
    '    While reader.Read
    '        Price.Text = reader(3).ToString
    '    End While

    '    Con.Close()

    'End Sub

    Private Sub FillDate()
        Con.Open()
        Dim query = "SELECT * FROM ProductTb4 WHERE referenceNumber='" & id.SelectedValue.ToString() & "'"
        Dim cmd As New SqlCommand(query, Con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            DateTime2.Text = reader(6).ToString
        End While
        Con.Close()
    End Sub




    Private Sub FillQuantity()
        Con.Open()
        Dim query = "SELECT * FROM ProductTb4 WHERE referenceNumber='" & id.SelectedValue.ToString() & "'"
        Dim cmd As New SqlCommand(query, Con)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            Qty.Text = reader(5).ToString
        End While
        Con.Close()
    End Sub



    Private Sub FillBill()
        'Con.Open()
        'Dim query = "SELECT * FROM ProductTb4 WHERE id=" & id.SelectedValue.ToString & ""
        'Dim cmd As New SqlCommand(query, Con)

        'Dim adapter As New SqlDataAdapter(query, Con)
        'Dim dataTable As New DataTable()
        'adapter.Fill(dataTable)
        'Dim newColumn As New DataColumn("Total", GetType(Integer))
        'dataTable.Columns.Add(newColumn)
        'SalesHistoryDG.DataSource = dataTable
        ''ProductDVG3.Columns.Clear()
        'SalesHistoryDG.Columns.Remove("id")
        'SalesHistoryDG.Columns.Remove("Date")

        ''bug for total  price
        'Dim prices As Integer
        'If Price.Text = "" Then
        '    MsgBox("Enter Price")
        'Else
        '    If Integer.TryParse(Price.Text, prices) Then
        '        For Each row As DataRow In dataTable.Rows
        '            Dim qty As Integer = CInt(row("Quantity"))
        '            row("Total") = qty * prices
        '        Next
        '    Else

        '    End If

        'End If


    End Sub
    Private Sub fetchPrice()
        Con.Open()
        Dim query As String = "SELECT Price FROM ProductTb1 WHERE ProductName=@productName"
        Dim cmd As New SqlCommand(query, Con)
        cmd.Parameters.AddWithValue("@productName", Order.SelectedValue.ToString())
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.Read() Then
            Dim priceValue As String = reader("Price").ToString()
            Price.Text = priceValue
        End If
        reader.Close()
        Con.Close()
    End Sub


    Private Sub fetchId()
        Con.Open()
        Dim query As String = "SELECT ProductId FROM ProductTb1 WHERE ProductName=@productName"
        Dim cmd As New SqlCommand(query, Con)
        cmd.Parameters.AddWithValue("@productName", Order.SelectedValue.ToString())
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.Read() Then
            Dim IdValue As String = reader("ProductId").ToString()
            ProdId.Text = IdValue
        End If
        reader.Close()
        Con.Close()
    End Sub



    Private Sub fetchQty()
        Con.Open()
        Dim query As String = "SELECT ProductId, Quantity FROM ProductTb1 WHERE ProductName=@productName"
        Dim cmd As New SqlCommand(query, Con)
        cmd.Parameters.AddWithValue("@productName", Order.SelectedValue.ToString())
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        If reader.Read() Then
            Dim qtyValue As String = reader("Quantity").ToString()
            ProdQty.Text = qtyValue
        End If
        reader.Close()
        Con.Close()
    End Sub


    'Public Sub UpdatedQty()
    '    ProdQty.Update()

    'End Sub



    Private Sub ProductDVG2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ProductDVG3.CellContentClick

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = Me.ProductDVG3.Rows(e.RowIndex)
            id.Text = row.Cells("referenceNumber").Value.ToString()
            Name.Text = row.Cells("Customer_Name").Value.ToString()
            Number.Text = row.Cells("Contact_Number").Value.ToString()
            address.Text = row.Cells("Address").Value.ToString()
            Order.Text = row.Cells("Product_Order").Value.ToString()
            Qty.Text = row.Cells("Quantity").Value.ToString()
            DateTime2.Text = row.Cells("Date").Value.ToString()

            fetchId()
            FillPrice()
            fetchQty()
            If String.IsNullOrEmpty(RichTextBox1.Text) Then
                ShowBill()
            Else
                RichTextBox1.Clear()
                ShowBill()
            End If

        End If

    End Sub


    Private Sub ShowBill()
        Dim prices As Decimal
        Dim qtys As Integer
        If Decimal.TryParse(Price.Text, prices) AndAlso Integer.TryParse(Qty.Text, qtys) Then
            Dim res = prices * qtys
            RichTextBox1.Text += "      Escabel Ramirez Printing Services              " & vbCrLf
            RichTextBox1.Text += "               Rosario Batangas                       " & vbCrLf
            RichTextBox1.Text += "               Tel + 09321313643                        " & vbCrLf
            RichTextBox1.Text += "************************************************" & vbCrLf
            RichTextBox1.Text += "Ref No. :  " & id.Text & "  " & DateTime.Now.ToString() & vbCrLf
            RichTextBox1.Text += "************************************************" & vbCrLf
            RichTextBox1.Text += "Customer Name    :    " & Name.Text & vbCrLf
            RichTextBox1.Text += "Contact Number   :    " & Number.Text & vbCrLf
            RichTextBox1.Text += "Address          :    " & address.Text & vbCrLf
            RichTextBox1.Text += "Product Order    :    " & Order.Text & vbCrLf
            RichTextBox1.Text += "Quantity         :    x" & Qty.Text & vbCrLf
            RichTextBox1.Text += "Date Release     :    " & DateTime2.Text & vbCrLf
            RichTextBox1.Text += "************************************************" & vbCrLf
            RichTextBox1.Text += "Total            :    " & ChrW(&H20B1) & res.ToString("#,##0.00") & vbCrLf
            RichTextBox1.Text += "************************************************" & vbCrLf
            RichTextBox1.Text += "            Thank you for Shopping                  " & vbCrLf

        End If



    End Sub






    Private Sub Number_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Number.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Qty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Qty.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Price_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Transaction_TextChanged(sender As Object, e As EventArgs) Handles MyBase.TextChanged


    End Sub

    Private Sub Search_TextChanged(sender As Object, e As EventArgs) Handles Search.TextChanged
        Dim query As String = "SELECT * FROM ProductTb4 WHERE Customer_Name LIKE '%" & Search.Text & "%' OR referenceNumber LIKE '%" & Search.Text & "%'"

        Using Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\source\repos\capstoneProject2ndYear\capstoneProject2ndYear\ProductVbDb.mdf;Integrated Security=True;Connect Timeout=30")
            Using cmd As New SqlCommand(query, Con)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            ProductDVG3.DataSource = dt

                            '    Dim adapter As New SqlDataAdapter(query, Con)
                            '    Dim dataTable As New DataTable()
                            '    adapter.Fill(dataTable)
                            '    Dim newColumn As New DataColumn("Total", GetType(Integer))
                            '    dataTable.Columns.Add(newColumn)


                            '    'bug for total  price



                            '    Dim prices As Integer
                            '    If Integer.TryParse(Price.Text, prices) Then
                            '        For Each row As DataRow In dataTable.Rows
                            '            Dim qty As Integer = CInt(row("Quantity"))
                            '            row("Total") = qty * prices
                            '        Next
                            '    Else

                            '    End If

                            'SalesHistoryDG.DataSource = dataTable
                            ''ProductDVG3.Columns.Clear()
                            'SalesHistoryDG.Columns.Remove("id")
                            'SalesHistoryDG.Columns.Remove("Date")

                        Else
                            MsgBox("No record found!")
                            Search.Text = ""
                            RichTextBox1.Clear()
                        End If
                    End Using
                End Using
            End Using
        End Using








    End Sub

    Private Sub Order_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Order.SelectedIndexChanged
        'If TypeOf Order.SelectedItem Is DataRowView Then
        '    Dim selectedValue As String = CType(Order.SelectedItem, DataRowView).Item(1).ToString()
        '    If Not String.IsNullOrEmpty(selectedValue) AndAlso Not ListBox1.Items.Contains(selectedValue) Then
        '        If ListBox1.Items.Count = 0 Then
        '            ListBox1.Items.Add(selectedValue)
        '        Else
        '            ListBox1.Items.Insert(1, selectedValue)
        '        End If
        '    End If
        'End If
    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs)

        If id.Text = "" Then
            MsgBox("Enter referenceNumber to be Order Received!")
        Else
            Me.Hide()
            SalesHistory.Show()


            'Con.Open()
            'Dim query As String
            'query = " ALTER  productTb4 where id= " & id.Text & ""
            'Dim cmd As SqlCommand
            'cmd = New SqlCommand(query, Con)
            'cmd.ExecuteNonQuery()
            'MsgBox("Order Received!")
            'Con.Close()
            'populate()
            'id.Text = ""
        End If

    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles id.SelectedIndexChanged
    End Sub

    Private Sub id_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles id.SelectionChangeCommitted
        fechName()
        FillContact()
        FillOrder()
        FillQuantity()
        FillDate()
        FillBill()
        fetchId()

        fetchPrice()
        fetchId()
        FillPrice()
        fetchQty()
        FillAddress()

        'If String.IsNullOrEmpty(RichTextBox1.Text) Then
        '    ShowBill()
        'Else
        '    RichTextBox1.Clear()
        '    ShowBill()
        'End If


    End Sub

    Private Sub Order_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles Order.SelectionChangeCommitted
        fillId()
        FillPrice()
        fetchQty()
        'ShowBill()

    End Sub

    Private Sub Name_TextChanged(sender As Object, e As EventArgs) Handles Name.TextChanged

    End Sub
    Public Sub RefreshDataGridView(ProductDVG As DataGridView, dataSource As Object)
        ' Set the data source for the DataGridView control
        ProductDVG.DataSource = dataSource
        ' Refresh the DataGridView control
        ProductDVG.Refresh()
    End Sub

    Private Function GetDataTableFromDatabase() As DataTable
        ' Create a new SqlConnection and SqlCommand objects
        Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\source\repos\capstoneProject2ndYear\capstoneProject2ndYear\ProductVbDb.mdf;Integrated Security=True;Connect Timeout=30"
        Dim connection As New SqlConnection(connectionString)
        Dim command As New SqlCommand("SELECT * FROM ProductTb1", connection)

        ' Create a new DataTable to store the data from the database
        Dim dataTable As New DataTable()

        ' Use a SqlDataAdapter to fill the DataTable with data from the database
        Dim adapter As New SqlDataAdapter(command)
        adapter.Fill(dataTable)

        ' Return the filled DataTable as the new data source
        Return dataTable
    End Function

    Private Sub InsertDB()
        Dim query As String = "INSERT INTO ProductTb4 (referenceNumber, Customer_Name, Contact_Number, Address, Product_Order, Quantity, Date, Total) VALUES (@referenceNumber, @Customer_Name, @Contact_Number, @Address, @Product_Order, @Quantity, GETDATE(), @Total)"
        Dim cmd As SqlCommand = New SqlCommand(query, Con)

        cmd.Parameters.Add("@referenceNumber", SqlDbType.NVarChar, 10).Value = id.Text
        cmd.Parameters.Add("@Customer_Name", SqlDbType.NVarChar, 50).Value = Name.Text.ToUpper()
        cmd.Parameters.Add("@Contact_Number", SqlDbType.NVarChar, 20).Value = Number.Text
        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 100).Value = address.Text.ToUpper()
        cmd.Parameters.Add("@Product_Order", SqlDbType.NVarChar, 50).Value = Order.Text.ToUpper()
        cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = Integer.Parse(Qty.Text)

        Dim prices As Decimal
        Dim qtys As Integer
        Dim res As Decimal

        Dim itemsForm As Items = TryCast(Application.OpenForms("Items"), Items)
        If itemsForm IsNot Nothing Then
            Dim newDataSource As Object = GetDataTableFromDatabase()
            RefreshDataGridView(itemsForm.ProductDVG, newDataSource)
        End If




        If Decimal.TryParse(Price.Text, prices) AndAlso Integer.TryParse(Qty.Text, qtys) Then
            res = prices * qtys
        End If
        cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = res
        'ShowBill()

        Try
            Con.Open()
            cmd.ExecuteNonQuery()
            MsgBox("Added Successfully!")

            ShowBill()
            Name.Text = ""
            Number.Text = ""
            Qty.Text = ""
            Order.Text = ""
            ProdId.Text = ""
            Price.Text = ""
            id.Text = ""
            ProdQty.Text = ""
            address.Text = ""

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try



        'Con.Open()
        'cmd.CommandText = "UPDATE ProductTb1 SET Quantity=@Quantity WHERE ProductId=@ProductId"
        'cmd.Parameters.AddWithValue("@Quantity", res.ToString())
        'cmd.Parameters.AddWithValue("@ProductId", ProdId.Text)
        'cmd.ExecuteNonQuery()
        Con.Close()
        populate()

        'if richtextbox1 isnot nothing then
        '    richtextbox1.clear()
        'end if
    End Sub



    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        If RichTextBox1 IsNot Nothing Then
            RichTextBox1.Clear()
        End If

        Dim myId As Guid = Guid.NewGuid()
        Dim myIdString = myId.ToString().Substring(0, 10)
        id.Text = myIdString



        Con.Open()
        '  Dim referenceNumber As String = Guid.NewGuid().ToString("N").Substring(0, 10)
        ' Generate a unique reference number
        Dim query As String = "INSERT INTO OrderReceived (refNum, Customer_Name, id, [Date], Total, Contact_Number, Address, Product_Order, Quantity) VALUES (@refNum, @Customer_Name, @id, GETDATE(), @Total, @Contact_Number, @Address, @Product_Order, @Quantity)"
        Dim cmd As SqlCommand = New SqlCommand(query, Con)

        cmd.Parameters.Add("@refNum", SqlDbType.NVarChar, 50).Value = id.Text ' Set the reference number
        cmd.Parameters.Add("@Customer_Name", SqlDbType.NVarChar, 50).Value = Name.Text.ToUpper()
        cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = Decimal.Parse(Price.Text) ' Assuming Total is of Decimal type

        cmd.Parameters.Add("@id", SqlDbType.NVarChar, 10).Value = id.Text
        cmd.Parameters.Add("@Contact_Number", SqlDbType.NVarChar, 20).Value = Number.Text
        cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 100).Value = address.Text.ToUpper()
        cmd.Parameters.Add("@Product_Order", SqlDbType.NVarChar, 50).Value = Order.Text.ToUpper()
        cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = Integer.Parse(Qty.Text)
        cmd.ExecuteNonQuery()
        Con.Close()


        Try
            If Name.Text = "" Or Number.Text = "" Or address.Text = "" Or Qty.Text = "" Then
                MsgBox("Please Complete details before adding order!")
            Else

                Dim var_stocks As Integer = 0
                Dim var_sell As Integer = 0
                Dim result As Integer = 0

                var_stocks = Convert.ToInt32(ProdQty.Text)
                var_sell = Convert.ToInt32(Qty.Text)
                result = var_stocks - var_sell

                If var_stocks <= 0 Then
                    MsgBox("Product Sold out")
                    Qty.Text = ""
                ElseIf var_stocks < var_sell Then
                    MsgBox("Low stocked!")
                    Qty.Text = ""
                Else
                    Con.Open()
                    Dim cmds As New SqlCommand("SELECT * FROM ProductTb1", Con)
                    cmds.CommandText = "UPDATE ProductTb1 SET Quantity='" + result.ToString() + "' WHERE ProductId='" + ProdId.Text + "'"
                    cmds.ExecuteNonQuery()
                    Con.Close()
                    InsertDB()
                End If
            End If

        Catch ex As Exception
            MsgBox("Invalid")
        End Try



    End Sub


    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles Button2.Click
        If id.Text = "" Then
            MsgBox("Select Customer to be Order Received!")
        Else

            adp = New SqlDataAdapter("SELECT refNum, Customer_Name, Date, Total FROM OrderReceived WHERE id LIKE '%" & id.Text & "%'", Con)
            Dim newSalesHisto As New SalesHistory
            Dim listView1 As ListView = newSalesHisto.ListView1Instance
            Dim dt As New DataTable
            adp.Fill(dt)

            For Each drow As DataRow In dt.Rows
                listView1.Items.Add(drow(0).ToString())
                listView1.Items(listView1.Items.Count - 1).SubItems.Add(drow(1).ToString())
                listView1.Items(listView1.Items.Count - 1).SubItems.Add(drow(2).ToString())
                listView1.Items(listView1.Items.Count - 1).SubItems.Add(drow(3).ToString())
                listView1.Items(listView1.Items.Count - 1).SubItems.Add(drow(3).ToString())
                listView1.Items(listView1.Items.Count - 1).SubItems.Add(drow(3).ToString())


            Next
            Con.Close()
            MsgBox("Product received!")

            Dim querys As String = "DELETE FROM productTb4 WHERE referenceNumber = @referenceNumber"
            Dim cmds As SqlCommand
            cmds = New SqlCommand(querys, Con)
            cmds.Parameters.AddWithValue("@referenceNumber", id.Text)
            Con.Open()
            cmds.ExecuteNonQuery()
            Con.Close()
            clear()
            populate()
            Application.Restart()
        End If









    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click


        clear()
    End Sub

    Private Sub clear()
        Name.Text = ""
        Number.Text = ""
        address.Text = ""
        Qty.Text = ""
        Order.Text = ""
        id.Text = ""
        Price.Text = ""
        DateTime2.Text = ""
        ProdId.Text = ""
        ProdQty.Text = ""
        Search.Text = ""
        RichTextBox1.Clear()
    End Sub
    Private Sub Button4_Click_2(sender As Object, e As EventArgs) Handles Button4.Click

        If id.Text = "" Then
            MsgBox("select customer to cancel")

        Else
            Try



                Dim query As String = "DELETE FROM productTb4 WHERE referenceNumber = @referenceNumber"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@referenceNumber", id.Text)
                Con.Open()
                cmd.ExecuteNonQuery()
                Con.Close()
                MsgBox("Order cancelled!")

                Dim var_stocks As Integer = 0
                Dim var_sell As Integer = 0
                Dim result As Integer = 0

                If Integer.TryParse(ProdQty.Text, var_stocks) AndAlso Integer.TryParse(Qty.Text, var_sell) Then
                    result = var_stocks + var_sell
                    Dim cmds As New SqlCommand("UPDATE ProductTb1 SET Quantity='" + result.ToString() + "' WHERE ProductId='" + ProdId.Text + "'", Con)
                    Con.Open()

                    cmds.ExecuteNonQuery()
                    Con.Close()
                    populate() ' moved inside the using block
                End If

                Con.Close()

                Dim itemsForm As Items = CType(Application.OpenForms("Items"), Items)
                Dim newDataSource As Object = GetDataTableFromDatabase()
                RefreshDataGridView(itemsForm.ProductDVG, newDataSource)

                clear()

                FillCustomer()



            Catch ex As Exception
                MsgBox("An error occurred: " & ex.Message)
            End Try
        End If


    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim pageBounds As RectangleF = e.PageSettings.PrintableArea
        Dim marginBounds As RectangleF = New RectangleF(pageBounds.Left + 50, pageBounds.Top + 50, pageBounds.Width - 100, pageBounds.Height - 100)

        Dim font As Font = RichTextBox1.Font
        Dim brush As Brush = New SolidBrush(RichTextBox1.ForeColor)
        Dim text As String = RichTextBox1.Text

        Dim format As StringFormat = New StringFormat()
        format.Alignment = StringAlignment.Near
        format.LineAlignment = StringAlignment.Near

        Dim textSize As SizeF = e.Graphics.MeasureString(text, font, marginBounds.Width, format)

        e.Graphics.DrawString(text, font, brush, marginBounds, format)

        ' If there is more text to print, indicate that the next page should be printed
        If textSize.Height + marginBounds.Top < marginBounds.Bottom Then
            e.HasMorePages = False
        Else
            e.HasMorePages = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        RichTextBox1.Font = New Font("Courier New", 13)
    End Sub

    Private Sub Number_TextChanged(sender As Object, e As EventArgs) Handles Number.TextChanged

    End Sub
End Class
