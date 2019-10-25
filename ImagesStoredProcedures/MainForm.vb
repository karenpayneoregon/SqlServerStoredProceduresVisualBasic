Imports System.IO
Imports ImagesStoredProcedures.Classes

Public Class MainForm

    Private ReadOnly _bindingSource As New BindingSource()

    Private ReadOnly _databaseImageOperations As New DatabaseImageOperations()
    Private Sub BindImage(ByVal sender As Object, ByVal e As ConvertEventArgs)
        If e.DesiredType Is GetType(Image) Then
            Dim ms = New MemoryStream(DirectCast(e.Value, Byte()))
            Dim image As Image = Image.FromStream(ms)
            e.Value = image
        End If
    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.AutoGenerateColumns = False

        _bindingSource.DataSource = _databaseImageOperations.DataTable()
        DataGridView1.DataSource = _bindingSource
        BindingNavigator1.BindingSource = _bindingSource

        Dim imageBinding = New Binding("Image", _bindingSource, "ImageData")
        AddHandler imageBinding.Format, AddressOf BindImage
        PictureBox1.DataBindings.Add(imageBinding)

    End Sub
    Private Sub cmdInsertImage_Click_1(sender As Object, e As EventArgs) Handles cmdInsertImage.Click
        Dim f = New SelectImageForm()

        Try
            If f.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim Identifier As Integer = 0
                Dim fileBytes = File.ReadAllBytes(f.FileName)

                If _databaseImageOperations.InsertImage(fileBytes, f.Description, Identifier) = Success.Okay Then
                    DirectCast(_bindingSource.DataSource, DataTable).Rows.Add(Identifier, fileBytes, f.Description)

                    Dim index = _bindingSource.Find("ImageId", Identifier)

                    If index > -1 Then
                        _bindingSource.Position = index
                    End If
                End If
            End If
        Finally
            f.Dispose()
        End Try

    End Sub
End Class