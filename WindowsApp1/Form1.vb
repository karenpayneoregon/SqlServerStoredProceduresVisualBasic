Public Class Form1
    Private loadingForm As Boolean = True

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn() With {.ColumnName = "Column1", .DataType = GetType(Double)})


        dt.Rows.Add(New Object() {2.3D})
        dt.Rows.Add(New Object() {5D})
        dt.Rows.Add(New Object() {1.4D})
        dt.Rows.Add(New Object() {15D})
        DataGridView1.DataSource = dt


    End Sub
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If Not loadingForm Then
            If e.ColumnIndex = 0 Then
                Dim value As Double
                If e.Value IsNot Nothing Then
                    If Not IsDBNull(e.Value) Then


                        Exit Sub
                    End If

                    Dim test = System.Text.RegularExpressions.Regex.Replace(CStr(e.Value), "[^0-9]", "")

                    If Double.TryParse(test, value) Then
                        If CDec(e.Value) > 3 Then
                            e.Value = $"-- {e.Value}"
                            e.FormattingApplied = True
                        End If
                    Else
                        MessageBox.Show("Invalid value 1")
                    End If

                End If

            End If
        End If
    End Sub
    Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs)
        If Not loadingForm Then
            Dim cell As DataGridViewCell = DataGridView1.Item(e.ColumnIndex, e.RowIndex)

            If cell.IsInEditMode Then
                Dim c As Control = DataGridView1.EditingControl

                If DataGridView1.Columns(e.ColumnIndex).Name = "Column1" Then

                    Try
                        c.Text = System.Text.RegularExpressions.Regex.Replace(c.Text, "[^0-9]", "")
                    Catch ex As Exception
                        MessageBox.Show("Not valid")
                        e.Cancel = True
                    End Try
                End If
            End If
        Else
            loadingForm = False
        End If

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        loadingForm = False
        AddHandler DataGridView1.CellFormatting, AddressOf DataGridView1_CellFormatting
        AddHandler DataGridView1.CellValidating, AddressOf DataGridView1_CellValidating
    End Sub
End Class
