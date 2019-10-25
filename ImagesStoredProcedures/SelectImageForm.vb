Public Class SelectImageForm
    Public Property FileName() As String
    Public Property Description() As String

    Private Sub SelectImageButton_Click(sender As Object, e As EventArgs) Handles SelectImageButton.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Label1.Text = OpenFileDialog1.FileName
            FileName = Label1.Text
        End If
    End Sub
    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged
        OkButton.Enabled = Not String.IsNullOrWhiteSpace(txtDescription.Text)
        If OkButton.Enabled Then
            Description = txtDescription.Text
        End If
    End Sub
End Class