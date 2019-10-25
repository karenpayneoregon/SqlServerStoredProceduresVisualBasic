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
        Me.StoredProcedureDefinitionTextBox = New System.Windows.Forms.TextBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.GetStoredProcDetailsButton = New System.Windows.Forms.Button()
        Me.StoredProcedureNamesListBox = New System.Windows.Forms.ListBox()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ParameterListView = New System.Windows.Forms.ListView()
        Me.NameColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SystemTypeColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MaxLengthColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PrecisionColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ScaleColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.panel1.SuspendLayout()
        Me.panel2.SuspendLayout()
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StoredProcedureDefinitionTextBox
        '
        Me.StoredProcedureDefinitionTextBox.BackColor = System.Drawing.Color.Black
        Me.StoredProcedureDefinitionTextBox.ForeColor = System.Drawing.Color.Yellow
        Me.StoredProcedureDefinitionTextBox.Location = New System.Drawing.Point(214, 3)
        Me.StoredProcedureDefinitionTextBox.Multiline = True
        Me.StoredProcedureDefinitionTextBox.Name = "StoredProcedureDefinitionTextBox"
        Me.StoredProcedureDefinitionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.StoredProcedureDefinitionTextBox.Size = New System.Drawing.Size(586, 197)
        Me.StoredProcedureDefinitionTextBox.TabIndex = 0
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.panel2)
        Me.panel1.Controls.Add(Me.StoredProcedureNamesListBox)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(208, 450)
        Me.panel1.TabIndex = 2
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.Color.Black
        Me.panel2.Controls.Add(Me.GetStoredProcDetailsButton)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel2.Location = New System.Drawing.Point(0, 387)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(208, 63)
        Me.panel2.TabIndex = 1
        '
        'GetStoredProcDetailsButton
        '
        Me.GetStoredProcDetailsButton.Location = New System.Drawing.Point(13, 17)
        Me.GetStoredProcDetailsButton.Name = "GetStoredProcDetailsButton"
        Me.GetStoredProcDetailsButton.Size = New System.Drawing.Size(182, 23)
        Me.GetStoredProcDetailsButton.TabIndex = 0
        Me.GetStoredProcDetailsButton.Text = "Get details"
        Me.GetStoredProcDetailsButton.UseVisualStyleBackColor = True
        '
        'StoredProcedureNamesListBox
        '
        Me.StoredProcedureNamesListBox.BackColor = System.Drawing.Color.Black
        Me.StoredProcedureNamesListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StoredProcedureNamesListBox.ForeColor = System.Drawing.Color.White
        Me.StoredProcedureNamesListBox.FormattingEnabled = True
        Me.StoredProcedureNamesListBox.Location = New System.Drawing.Point(0, 0)
        Me.StoredProcedureNamesListBox.Name = "StoredProcedureNamesListBox"
        Me.StoredProcedureNamesListBox.Size = New System.Drawing.Size(208, 450)
        Me.StoredProcedureNamesListBox.TabIndex = 0
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer1.Name = "splitContainer1"
        Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.StoredProcedureDefinitionTextBox)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.ParameterListView)
        Me.splitContainer1.Size = New System.Drawing.Size(800, 450)
        Me.splitContainer1.SplitterDistance = 200
        Me.splitContainer1.SplitterWidth = 8
        Me.splitContainer1.TabIndex = 3
        '
        'ParameterListView
        '
        Me.ParameterListView.BackColor = System.Drawing.Color.Black
        Me.ParameterListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NameColumn, Me.SystemTypeColumn, Me.MaxLengthColumn, Me.PrecisionColumn, Me.ScaleColumn})
        Me.ParameterListView.ForeColor = System.Drawing.Color.White
        Me.ParameterListView.FullRowSelect = True
        Me.ParameterListView.Location = New System.Drawing.Point(214, 3)
        Me.ParameterListView.Name = "ParameterListView"
        Me.ParameterListView.Size = New System.Drawing.Size(583, 236)
        Me.ParameterListView.TabIndex = 1
        Me.ParameterListView.UseCompatibleStateImageBehavior = False
        Me.ParameterListView.View = System.Windows.Forms.View.Details
        '
        'NameColumn
        '
        Me.NameColumn.Text = "Name"
        '
        'SystemTypeColumn
        '
        Me.SystemTypeColumn.Text = "System Type"
        Me.SystemTypeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MaxLengthColumn
        '
        Me.MaxLengthColumn.Text = "Max length"
        Me.MaxLengthColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PrecisionColumn
        '
        Me.PrecisionColumn.Text = "Precision"
        Me.PrecisionColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ScaleColumn
        '
        Me.ScaleColumn.Text = "Scale"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.splitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Get Stored Procedure definitions"
        Me.panel1.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.PerformLayout()
        Me.splitContainer1.Panel2.ResumeLayout(False)
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents StoredProcedureDefinitionTextBox As TextBox
    Private WithEvents panel1 As Panel
    Private WithEvents panel2 As Panel
    Private WithEvents GetStoredProcDetailsButton As Button
    Private WithEvents StoredProcedureNamesListBox As ListBox
    Private WithEvents splitContainer1 As SplitContainer
    Private WithEvents ParameterListView As ListView
    Private WithEvents NameColumn As ColumnHeader
    Private WithEvents SystemTypeColumn As ColumnHeader
    Private WithEvents MaxLengthColumn As ColumnHeader
    Private WithEvents PrecisionColumn As ColumnHeader
    Private WithEvents ScaleColumn As ColumnHeader
End Class
