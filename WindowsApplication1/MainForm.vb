Imports DataOperations
Imports DataOperations.TypeClasses
Imports ExtensionsLibrary

Public Class MainForm
    Private _dataOperations As New BackendOperations
    Private _bsCustomers As New BindingSource
    ''' <summary>
    ''' Insert a new row
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NewCustomerButton_Click(sender As Object, e As EventArgs) Handles NewCustomerButton.Click

        If _bsCustomers.DataSource Is Nothing Then
            MessageBox.Show("Please select some data")
            Exit Sub
        End If


        Dim f As New CustomerEditorForm
        Try
            f.cboContactTitles.DataSource = _dataOperations.RetrieveContactTitles
            If f.ShowDialog() = DialogResult.OK Then
                If f.ValidateTextBoxes Then

                    Dim contactTypeIdentifier = CType(f.cboContactTitles.SelectedItem, ContactType).Identifier
                    Dim primaryKey As Integer = _dataOperations.
                            AddCustomer(f.txtCompanyName.Text, f.txtContactName.Text, contactTypeIdentifier)

                    If primaryKey <> -1 Then
                        _bsCustomers.AddRow(primaryKey, f.txtCompanyName.Text, f.txtContactName.Text, f.cboContactTitles.Text, contactTypeIdentifier)
                    End If
                Else
                    MessageBox.Show("Nothing save as one or more fields were empty.")
                End If

            End If
        Finally
            f.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' Remove the current row
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RemoveCurrentCustomerButton_Click(sender As Object, e As EventArgs) Handles RemoveCurrentCustomerButton.Click

        If _bsCustomers.DataSource Is Nothing Then
            MessageBox.Show("Please select some data")
            Exit Sub
        End If

        If My.Dialogs.Question("Remove " & _bsCustomers.CurrentRow.CompanyName) Then
            If Not _dataOperations.RemoveCustomer(_bsCustomers.CurrentRow.Identifier) Then
                If Not _dataOperations.IsSuccessFul Then
                    MessageBox.Show($"Failed to remove customer{Environment.NewLine}{_dataOperations.LastExceptionMessage}")
                End If
            Else
                '
                ' Only remove row if removed successfully from the database table
                '
                _bsCustomers.RemoveCurrent()

            End If
        End If

    End Sub
    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadCustomers()
    End Sub
    Private Sub LoadCustomers()

        Dim customerDataTable = _dataOperations.RetrieveAllCustomerRecords
        Dim contactList = _dataOperations.RetrieveContactTitles()

        If _dataOperations.IsSuccessFul Then

            _bsCustomers.DataSource = customerDataTable
            _bsCustomers.Sort = "CompanyName"

            DataGridView1.DataSource = _bsCustomers
            DataGridView1.ExpandColumns()

            _bsCustomers.MoveFirst()

            ContactTypeComboBox.DataSource = contactList

        Else

            MessageBox.Show($"Failed to load data{Environment.NewLine}" &
                            $"{_dataOperations.LastExceptionMessage}")

        End If
    End Sub
    ''' <summary>
    ''' Select rows where contact type is equal to current item
    ''' in cboContactTitles
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ReadByContactTypeButton_Click(sender As Object, e As EventArgs) Handles ReadByContactTypeButton.Click

        Dim contactTypeIdentifier = CType(ContactTypeComboBox.SelectedItem, ContactType).Identifier

        Dim dt = _dataOperations.GetAllRecordsByContactTitle(contactTypeIdentifier)

        If _dataOperations.IsSuccessFul Then
            _bsCustomers.DataSource = dt
            DataGridView1.DataSource = _bsCustomers
            _bsCustomers.MoveFirst()
        Else
            _bsCustomers.DataSource = Nothing
            DataGridView1.DataSource = _bsCustomers
        End If

        _bsCustomers.DataSource = dt
        DataGridView1.DataSource = _bsCustomers

        _bsCustomers.MoveFirst()
    End Sub
    ''' <summary>
    ''' For either
    ''' a) Data has changed in the table outside of this code sample
    ''' b) The Where/filter was executed which does not return contact type
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ReloadCustomersFromDatabaseButton_Click(sender As Object, e As EventArgs) Handles ReloadCustomersFromDatabaseButton.Click
        LoadCustomers()
    End Sub
    ''' <summary>
    ''' Update current record
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UpdateCurrentCustomerButton_Click(sender As Object, e As EventArgs) Handles UpdateCurrentCustomerButton.Click
        EditCurrentCustomer()
    End Sub
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        If _bsCustomers.Current IsNot Nothing Then
            EditCurrentCustomer()
        End If
    End Sub
    Private Sub EditCurrentCustomer()
        If _bsCustomers.DataSource Is Nothing Then
            MessageBox.Show("Please select some data")
            Exit Sub
        End If

        Dim contactList = _dataOperations.RetrieveContactTitles()

        Dim f As New CustomerEditorForm
        Try

            f.txtCompanyName.Text = _bsCustomers.CurrentRow.CompanyName
            f.txtContactName.Text = _bsCustomers.CurrentRow.ContactName
            f.cboContactTitles.DataSource = contactList

            f.cboContactTitles.SelectedIndex = contactList.FindIndex(
                Function(contactType) contactType.ContactType = _bsCustomers.CurrentRow.ContactTitle)

            If f.ShowDialog() = DialogResult.OK Then
                If f.ValidateTextBoxes Then

                    Dim customerIdentifier = _bsCustomers.CurrentRow.Identifier
                    Dim contactTypeIdentifier = CType(f.cboContactTitles.SelectedItem, ContactType).Identifier

                    If _dataOperations.UpdateCustomer(customerIdentifier, f.txtCompanyName.Text, f.txtContactName.Text, contactTypeIdentifier) Then
                        _bsCustomers.CurrentRow.SetCompanyName(f.txtCompanyName.Text)
                        _bsCustomers.CurrentRow.SetContactName(f.txtContactName.Text)
                        _bsCustomers.CurrentRow.SetContactTitle(f.cboContactTitles.Text)
                    End If
                Else
                    MessageBox.Show("Nothing save as one or more fields were empty.")
                End If

            End If
        Finally
            f.Dispose()
        End Try
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        _dataOperations.ReturnErrorInformation()

    End Sub
End Class
