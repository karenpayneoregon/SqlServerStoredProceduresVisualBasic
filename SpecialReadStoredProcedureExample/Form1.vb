Imports DataOperations

Public Class Form1
    Private ReadOnly _dataOperations As New BackendOperations()

    Private Sub GetAllCustomersButton_Click(sender As Object, e As EventArgs) Handles GetAllCustomersButton.Click
        dataGridView1.DataSource = _dataOperations.GetAllCustomersRecords()
    End Sub
    Private Sub GetCustomerByIdentifierButton_Click(sender As Object, e As EventArgs) Handles GetCustomerByIdentifierButton.Click
        dataGridView1.DataSource = _dataOperations.GetAllCustomerRecordsByIdentifier(2)
    End Sub
    Private Sub GetCustomerByCompanyNameButton_Click(sender As Object, e As EventArgs) Handles GetCustomerByCompanyNameButton.Click
        dataGridView1.DataSource = _dataOperations.GetAllCustomerRecordsByCompanyName("Salem Boat Rentals")
    End Sub
End Class
