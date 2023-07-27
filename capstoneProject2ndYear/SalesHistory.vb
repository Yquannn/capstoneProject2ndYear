Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForm
Public Class SalesHistory

    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\source\repos\capstoneProject2ndYear\capstoneProject2ndYear\ProductVbDb.mdf;Integrated Security=True;Connect Timeout=30")
    Dim adp As SqlDataAdapter

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
    End Sub
    'Public Sub populate2()
    '    Con.Open()

    '    Dim sql As String = "SELECT * FROM OrderReceived"
    '    Dim cmd As New SqlCommand(sql, Con)
    '    Dim adapter As New SqlDataAdapter(cmd)
    '    Dim builder As New SqlCommandBuilder(adapter)
    '    Dim ds As New DataSet()
    '    adapter.Fill(ds)
    '    OrderRecieved.DataSource = ds.Tables(0)
    '    Con.Close()
    'End Sub

    Private Sub SalesHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        populate()


    End Sub
    Public Sub populate()
        Con.Open()

        Dim sql As String = "SELECT * FROM OrderReceived"
        Dim cmd As New SqlCommand(sql, Con)
        Dim reader As SqlDataReader = cmd.ExecuteReader()

        ' Clear existing items in the ListView
        myListView.Items.Clear()

        While reader.Read()
            ' Read data from the SqlDataReader and create a new ListViewItem
            Dim item As New ListViewItem(reader("refNum").ToString())
            item.SubItems.Add(reader("Customer_Name").ToString())
            item.SubItems.Add(reader("Date").ToString())
            item.SubItems.Add(reader("Total").ToString())
            item.SubItems.Add(reader("Quantity").ToString())
            item.SubItems.Add(reader("Product_Order").ToString())

            'item.SubItems.Add(reader("id").ToString())
            'item.SubItems.Add(reader("Contact_Number").ToString())
            'item.SubItems.Add(reader("Address").ToString())

            ' Add the ListViewItem to the ListView
            myListView.Items.Add(item)
        End While

        reader.Close()
        Con.Close()
    End Sub


    Public ReadOnly Property ListView1Instance As ListView
        Get
            Return myListView
        End Get
    End Property
    Private Sub Button7_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles myListView.SelectedIndexChanged



    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Search_TextChanged(sender As Object, e As EventArgs) Handles Search.TextChanged
        Dim query As String = "SELECT * FROM OrderReceived WHERE Customer_Name LIKE '%" & Search.Text & "%' OR refNum LIKE '%" & Search.Text & "%'"


        Using Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kathlene\source\repos\capstoneProject2ndYear\capstoneProject2ndYear\ProductVbDb.mdf;Integrated Security=True;Connect Timeout=30")
            Using cmd As New SqlCommand(query, Con)
                cmd.Parameters.AddWithValue("@SearchText", "%" & Search.Text & "%")

                Using da As New SqlDataAdapter()
                    da.SelectCommand = cmd

                    Using dt As New DataTable()
                        da.Fill(dt)

                        If dt.Rows.Count > 0 Then
                            myListView.Items.Clear() ' Clear existing items

                            For Each row As DataRow In dt.Rows
                                Dim item As New ListViewItem(row("refNum").ToString())
                                item.SubItems.Add(row("Customer_Name").ToString())
                                item.SubItems.Add(row("Date").ToString())
                                item.SubItems.Add(row("Total").ToString())
                                item.SubItems.Add(row("Quantity").ToString())
                                item.SubItems.Add(row("Product_Order").ToString())

                                ' Add other sub-items as needed
                                myListView.Items.Add(item)
                            Next

                            ' ... rest of your code ...

                        Else
                            MsgBox("No record found!")
                            Search.Text = ""
                        End If
                    End Using
                End Using
            End Using
        End Using
    End Sub


End Class