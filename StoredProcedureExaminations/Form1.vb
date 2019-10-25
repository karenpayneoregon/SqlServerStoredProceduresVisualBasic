Imports DataOperations

Public Class Form1
    Private ReadOnly _dataOperations As New BackendOperations()

    Private Sub GetStoredProcDetailsButton_Click(sender As Object, e As EventArgs) Handles GetStoredProcDetailsButton.Click
        GetDetails()
    End Sub
    Private Sub StoredProcedureNamesListBox_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles StoredProcedureNamesListBox.MouseDoubleClick
        GetDetails()
    End Sub
    Private Sub GetDetails()
        ParameterListView.Items.Clear()

        StoredProcedureDefinitionTextBox.Text = _dataOperations.GetStoredProcedureContents(StoredProcedureNamesListBox.Text)

        Dim details = _dataOperations.GetStoredProcedureContentsWithParameters(StoredProcedureNamesListBox.Text)
        For Each detail In details
            ParameterListView.Items.Add(New ListViewItem(detail.ItemArray()))
        Next
        ParameterListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        StoredProcedureNamesListBox.DataSource = _dataOperations.StoredProcedureNameList()
    End Sub
End Class
