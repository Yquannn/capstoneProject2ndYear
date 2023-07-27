<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalesHistory
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.myListView = New System.Windows.Forms.ListView()
        Me.Id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.name = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.araw = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tot = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.quan = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Order = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Search = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Bahnschrift Condensed", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(505, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(219, 39)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Transaction History"
        '
        'Button3
        '
        Me.Button3.AutoSize = True
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Button3.Image = Global.capstoneProject2ndYear.My.Resources.Resources.Actions_window_close_icon__1_
        Me.Button3.Location = New System.Drawing.Point(1146, -5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(54, 54)
        Me.Button3.TabIndex = 21
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'myListView
        '
        Me.myListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Id, Me.name, Me.araw, Me.tot, Me.quan, Me.Order})
        Me.myListView.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.myListView.FullRowSelect = True
        Me.myListView.GridLines = True
        Me.myListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.myListView.HideSelection = False
        Me.myListView.Location = New System.Drawing.Point(118, 155)
        Me.myListView.Name = "myListView"
        Me.myListView.Size = New System.Drawing.Size(949, 492)
        Me.myListView.TabIndex = 22
        Me.myListView.UseCompatibleStateImageBehavior = False
        Me.myListView.View = System.Windows.Forms.View.Details
        '
        'Id
        '
        Me.Id.Text = "Reference Number"
        Me.Id.Width = 170
        '
        'name
        '
        Me.name.Text = "Customer Name"
        Me.name.Width = 200
        '
        'araw
        '
        Me.araw.Text = "Date"
        Me.araw.Width = 200
        '
        'tot
        '
        Me.tot.Text = "total"
        Me.tot.Width = 100
        '
        'quan
        '
        Me.quan.Text = "Quantity"
        Me.quan.Width = 100
        '
        'Order
        '
        Me.Order.Text = "Order"
        Me.Order.Width = 150
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(132, 356)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(8, 4)
        Me.CheckedListBox1.TabIndex = 23
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button7.BackColor = System.Drawing.Color.Transparent
        Me.Button7.BackgroundImage = Global.capstoneProject2ndYear.My.Resources.Resources.icons8_search_64
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Button7.Location = New System.Drawing.Point(755, 113)
        Me.Button7.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(36, 39)
        Me.Button7.TabIndex = 93
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Search
        '
        Me.Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search.Location = New System.Drawing.Point(797, 118)
        Me.Search.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(270, 31)
        Me.Search.TabIndex = 92
        '
        'SalesHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 800)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.CheckedListBox1)
        Me.Controls.Add(Me.myListView)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None

        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SalesHistory"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Id As ColumnHeader
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Public WithEvents myListView As ListView
    Friend WithEvents name As ColumnHeader
    Friend WithEvents araw As ColumnHeader
    Friend WithEvents tot As ColumnHeader
    Friend WithEvents quan As ColumnHeader
    Friend WithEvents Order As ColumnHeader
    Friend WithEvents Button7 As Button
    Friend WithEvents Search As TextBox
End Class
