<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.GetCustomerByCompanyNameButton = New System.Windows.Forms.Button()
        Me.GetCustomerByIdentifierButton = New System.Windows.Forms.Button()
        Me.GetAllCustomersButton = New System.Windows.Forms.Button()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.Size = New System.Drawing.Size(662, 328)
        Me.dataGridView1.TabIndex = 3
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.GetCustomerByCompanyNameButton)
        Me.panel1.Controls.Add(Me.GetCustomerByIdentifierButton)
        Me.panel1.Controls.Add(Me.GetAllCustomersButton)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel1.Location = New System.Drawing.Point(0, 328)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(662, 55)
        Me.panel1.TabIndex = 2
        '
        'GetCustomerByCompanyNameButton
        '
        Me.GetCustomerByCompanyNameButton.Location = New System.Drawing.Point(294, 15)
        Me.GetCustomerByCompanyNameButton.Name = "GetCustomerByCompanyNameButton"
        Me.GetCustomerByCompanyNameButton.Size = New System.Drawing.Size(121, 23)
        Me.GetCustomerByCompanyNameButton.TabIndex = 2
        Me.GetCustomerByCompanyNameButton.Text = "Get by company name"
        Me.GetCustomerByCompanyNameButton.UseVisualStyleBackColor = True
        '
        'GetCustomerByIdentifierButton
        '
        Me.GetCustomerByIdentifierButton.Location = New System.Drawing.Point(158, 15)
        Me.GetCustomerByIdentifierButton.Name = "GetCustomerByIdentifierButton"
        Me.GetCustomerByIdentifierButton.Size = New System.Drawing.Size(121, 23)
        Me.GetCustomerByIdentifierButton.TabIndex = 1
        Me.GetCustomerByIdentifierButton.Text = "Get by Identifier"
        Me.GetCustomerByIdentifierButton.UseVisualStyleBackColor = True
        '
        'GetAllCustomersButton
        '
        Me.GetAllCustomersButton.Location = New System.Drawing.Point(21, 15)
        Me.GetAllCustomersButton.Name = "GetAllCustomersButton"
        Me.GetAllCustomersButton.Size = New System.Drawing.Size(121, 23)
        Me.GetAllCustomersButton.TabIndex = 0
        Me.GetAllCustomersButton.Text = "Get All"
        Me.GetAllCustomersButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 383)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Multi-purpose reader"
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents dataGridView1 As DataGridView
    Private WithEvents panel1 As Panel
    Private WithEvents GetCustomerByCompanyNameButton As Button
    Private WithEvents GetCustomerByIdentifierButton As Button
    Private WithEvents GetAllCustomersButton As Button
End Class
