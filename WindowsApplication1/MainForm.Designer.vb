<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.NewCustomerButton = New System.Windows.Forms.Button()
        Me.ReadByContactTypeButton = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ReloadCustomersFromDatabaseButton = New System.Windows.Forms.Button()
        Me.ContactTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.RemoveCurrentCustomerButton = New System.Windows.Forms.Button()
        Me.UpdateCurrentCustomerButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NewCustomerButton
        '
        Me.NewCustomerButton.Location = New System.Drawing.Point(269, 22)
        Me.NewCustomerButton.Margin = New System.Windows.Forms.Padding(2)
        Me.NewCustomerButton.Name = "NewCustomerButton"
        Me.NewCustomerButton.Size = New System.Drawing.Size(125, 23)
        Me.NewCustomerButton.TabIndex = 2
        Me.NewCustomerButton.Text = "New Customer"
        Me.NewCustomerButton.UseVisualStyleBackColor = True
        '
        'ReadByContactTypeButton
        '
        Me.ReadByContactTypeButton.Location = New System.Drawing.Point(269, 80)
        Me.ReadByContactTypeButton.Margin = New System.Windows.Forms.Padding(2)
        Me.ReadByContactTypeButton.Name = "ReadByContactTypeButton"
        Me.ReadByContactTypeButton.Size = New System.Drawing.Size(119, 23)
        Me.ReadByContactTypeButton.TabIndex = 5
        Me.ReadByContactTypeButton.Text = "By contact type"
        Me.ReadByContactTypeButton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ExitButton)
        Me.Panel1.Controls.Add(Me.ReloadCustomersFromDatabaseButton)
        Me.Panel1.Controls.Add(Me.ContactTypeComboBox)
        Me.Panel1.Controls.Add(Me.RemoveCurrentCustomerButton)
        Me.Panel1.Controls.Add(Me.UpdateCurrentCustomerButton)
        Me.Panel1.Controls.Add(Me.NewCustomerButton)
        Me.Panel1.Controls.Add(Me.ReadByContactTypeButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 284)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(536, 114)
        Me.Panel1.TabIndex = 1
        '
        'ReloadCustomersFromDatabaseButton
        '
        Me.ReloadCustomersFromDatabaseButton.Location = New System.Drawing.Point(13, 22)
        Me.ReloadCustomersFromDatabaseButton.Margin = New System.Windows.Forms.Padding(2)
        Me.ReloadCustomersFromDatabaseButton.Name = "ReloadCustomersFromDatabaseButton"
        Me.ReloadCustomersFromDatabaseButton.Size = New System.Drawing.Size(119, 23)
        Me.ReloadCustomersFromDatabaseButton.TabIndex = 0
        Me.ReloadCustomersFromDatabaseButton.Text = "Reload from database"
        Me.ReloadCustomersFromDatabaseButton.UseVisualStyleBackColor = True
        '
        'ContactTypeComboBox
        '
        Me.ContactTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ContactTypeComboBox.FormattingEnabled = True
        Me.ContactTypeComboBox.Location = New System.Drawing.Point(11, 82)
        Me.ContactTypeComboBox.Margin = New System.Windows.Forms.Padding(2)
        Me.ContactTypeComboBox.Name = "ContactTypeComboBox"
        Me.ContactTypeComboBox.Size = New System.Drawing.Size(248, 21)
        Me.ContactTypeComboBox.TabIndex = 4
        '
        'RemoveCurrentCustomerButton
        '
        Me.RemoveCurrentCustomerButton.Location = New System.Drawing.Point(403, 22)
        Me.RemoveCurrentCustomerButton.Margin = New System.Windows.Forms.Padding(2)
        Me.RemoveCurrentCustomerButton.Name = "RemoveCurrentCustomerButton"
        Me.RemoveCurrentCustomerButton.Size = New System.Drawing.Size(119, 23)
        Me.RemoveCurrentCustomerButton.TabIndex = 3
        Me.RemoveCurrentCustomerButton.Text = "Remove Current"
        Me.RemoveCurrentCustomerButton.UseVisualStyleBackColor = True
        '
        'UpdateCurrentCustomerButton
        '
        Me.UpdateCurrentCustomerButton.Location = New System.Drawing.Point(141, 22)
        Me.UpdateCurrentCustomerButton.Margin = New System.Windows.Forms.Padding(2)
        Me.UpdateCurrentCustomerButton.Name = "UpdateCurrentCustomerButton"
        Me.UpdateCurrentCustomerButton.Size = New System.Drawing.Size(119, 23)
        Me.UpdateCurrentCustomerButton.TabIndex = 1
        Me.UpdateCurrentCustomerButton.Text = "Update Current"
        Me.UpdateCurrentCustomerButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(536, 284)
        Me.DataGridView1.TabIndex = 0
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(403, 80)
        Me.ExitButton.Margin = New System.Windows.Forms.Padding(2)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(119, 23)
        Me.ExitButton.TabIndex = 6
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 398)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Working with Stored Procedures"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NewCustomerButton As System.Windows.Forms.Button
    Friend WithEvents ReadByContactTypeButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents UpdateCurrentCustomerButton As System.Windows.Forms.Button
    Friend WithEvents RemoveCurrentCustomerButton As System.Windows.Forms.Button
    Friend WithEvents ContactTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ReloadCustomersFromDatabaseButton As System.Windows.Forms.Button
    Friend WithEvents ExitButton As Button
End Class
