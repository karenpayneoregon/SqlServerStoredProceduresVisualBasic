Public Module LanguageExtensionMethods
    ''' <summary>
    ''' Determine if a TextBox controls are not empty for a container
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function ValidateTextBoxes(sender As Control) As Boolean
        Dim list As List(Of TextBox) = sender.Controls.OfType(Of TextBox).ToList
        Return Not list.Any(Function(tb) String.IsNullOrWhiteSpace(tb.Text))
    End Function
    ''' <summary>
    ''' Return current row as a DataRow
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function CurrentRow(sender As BindingSource) As DataRow
        Return DirectCast(sender.Current, DataRowView).Row
    End Function
    ''' <summary>
    ''' Return DataSource as a DataTable
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function DataTable(sender As BindingSource) As DataTable
        Return CType(sender.DataSource, DataTable)
    End Function
    ''' <summary>
    ''' Add new DataRow to DataTable where Identifier is a valid existing primary key
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="Identifier">Existing primary key</param>
    ''' <param name="CompanyName">Company name value</param>
    ''' <param name="ContactName">Contact name value</param>
    ''' <param name="ContactTitle">Contact title value</param>
    ''' <param name="ContactTypeIdentifier">Corresponding identifier for contact title</param>
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Sub AddRow(sender As BindingSource, Identifier As Integer, CompanyName As String, ContactName As String, ContactTitle As String, ContactTypeIdentifier As Integer)
        sender.DataTable.Rows.Add(New Object() {Identifier, CompanyName, ContactName, ContactTypeIdentifier, ContactTitle})
    End Sub
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function Identifier(sender As DataRow) As Integer
        Return sender.Field(Of Integer)("Identifier")
    End Function
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function CompanyName(sender As DataRow) As String
        Return sender.Field(Of String)("CompanyName")
    End Function
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Sub SetCompanyName(sender As DataRow, newCompanyNameValue As String)
        sender.SetField("CompanyName", newCompanyNameValue)
    End Sub
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function ContactName(sender As DataRow) As String
        Return sender.Field(Of String)("ContactName")
    End Function
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Sub SetContactName(sender As DataRow, newContactNameValue As String)
        sender.SetField("ContactName", newContactNameValue)
    End Sub
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Function ContactTitle(sender As DataRow) As String
        Return sender.Field(Of String)("ContactTitle")
    End Function
    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Sub SetContactTitle(sender As DataRow, newContactTitleValue As String)
        sender.SetField("ContactTitle", newContactTitleValue)
    End Sub
    <DebuggerHidden()>
    <Runtime.CompilerServices.Extension()>
    Public Sub ExpandColumns(sender As DataGridView)
        For Each col As DataGridViewColumn In sender.Columns
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub
End Module
