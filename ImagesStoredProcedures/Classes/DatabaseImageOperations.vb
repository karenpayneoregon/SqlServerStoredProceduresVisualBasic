Option Infer On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports BaseConnectionLibrary.ConnectionClasses

Namespace Classes
    Public Enum Success
        ''' <summary>
        ''' Successfully completed
        ''' </summary>
        Okay
        ''' <summary>
        ''' Something went wrong
        ''' </summary>
        OhSnap
    End Enum

    Public Class DatabaseImageOperations
        Inherits SqlServerConnection

        Public Sub New()
            '
            ' Make sure to change DatabaseServer to the server
            ' with CustomerDatabase
            '
            DatabaseServer = "KARENS-PC"
            DefaultCatalog = "NORTHWND_NEW.MDF"
        End Sub
        ''' <summary>
        ''' Determines if there are any records
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>not used, was for use during writing code for the code sample</remarks>
        Public Function HasRecords() As Boolean
            Dim result As Boolean = True

            Using cn = New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd = New SqlCommand With {
                    .Connection = cn,
                    .CommandText = "SELECT COUNT(ImageID) FROM ImageData"
                }
                    cn.Open()
                    result = Convert.ToInt32(cmd.ExecuteScalar()) > 0
                End Using
            End Using

            Return result
        End Function
        ''' <summary>
        ''' Given a valid image converts it to a byte array
        ''' </summary>
        ''' <param name="image"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' Suitable for saving a file to disk
        ''' Alternate is to use a memory stream
        ''' </remarks>
        Public Function ImageToByte(image As Image) As Byte()
            Dim converter = New ImageConverter()
            Return DirectCast(converter.ConvertTo(image, GetType(Byte())), Byte())
        End Function

        ''' <summary>
        ''' Save image to the sql-server database table
        ''' </summary>
        ''' <param name="image">Valid image</param>
        ''' <param name="description">Information to describe the image</param>
        ''' <param name="identifier">New primary key</param>
        ''' <returns></returns>
        Public Function InsertImage(
            image As Image,
            description As String,
            ByRef identifier As Integer) As Success

            mHasException = False

            Using cn = New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd = New SqlCommand With {
                    .Connection = cn,
                    .CommandText = "SaveImage"
                }
                    cmd.CommandType = CommandType.StoredProcedure

                    cmd.Parameters.Add("@img", SqlDbType.Image).Value = ImageToByte(image)
                    cmd.Parameters.Add("@description", SqlDbType.Text).Value = description

                    cmd.Parameters.Add(New SqlParameter With {
                        .ParameterName = "@new_identity",
                        .SqlDbType = SqlDbType.Int,
                        .Direction = ParameterDirection.Output
                    })

                    Try

                        cn.Open()
                        identifier = Convert.ToInt32(cmd.ExecuteScalar())

                        Return Success.Okay

                    Catch ex As Exception

                        mHasException = True
                        mLastException = ex

                        Return Success.OhSnap
                    End Try
                End Using
            End Using
        End Function
        ''' <summary>
        ''' Insert image where ImageByes is a byte array from a valid image
        ''' </summary>
        ''' <param name="imageBytes">Byte array </param>
        ''' <param name="description">used to describe the image</param>
        ''' <param name="identifier">New primary key</param>
        ''' <returns></returns>
        Public Function InsertImage(imageBytes() As Byte, description As String, ByRef identifier As Integer) As Success

            mHasException = False

            Using cn = New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd = New SqlCommand With {
                    .Connection = cn,
                    .CommandText = "SaveImage"
                }
                    cmd.CommandType = CommandType.StoredProcedure

                    cmd.Parameters.Add("@img", SqlDbType.Image).Value = imageBytes

                    cmd.Parameters.Add("@description", SqlDbType.Text).Value = If(String.IsNullOrWhiteSpace(description), "None", description)

                    cmd.Parameters.Add(New SqlParameter With {
                        .ParameterName = "@new_identity",
                        .SqlDbType = SqlDbType.Int,
                        .Direction = ParameterDirection.Output
                    })

                    Try

                        cn.Open()
                        identifier = Convert.ToInt32(cmd.ExecuteScalar())

                        Return Success.Okay

                    Catch ex As Exception

                        mHasException = True
                        mLastException = ex

                        Return Success.OhSnap

                    End Try
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Set image passed in parameter 2 to bytes returned from image field of identifier or
        ''' on error or key not found an error message is set and can be read back by the caller
        ''' </summary>
        ''' <param name="identifier">primary key to locate</param>
        ''' <param name="inBoundImage">Image to set from returned bytes in database table of found record</param>
        ''' <param name="description"></param>
        ''' <returns>Success</returns>
        ''' <remarks>
        ''' An alternative is to return the image rather than success as done now
        ''' </remarks>
        Public Function GetImage(
             identifier As Integer,
             ByRef inBoundImage As Image,
             ByRef description As String) As Success

            mHasException = False

            Dim dtResults As New DataTable()
            Dim SuccessType As Success = 0

            Using cn = New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd = New SqlCommand With {
                    .Connection = cn,
                    .CommandText = "ReadImage"
                }

                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@imgId", SqlDbType.Int).Value = identifier

                    Try

                        cn.Open()
                        dtResults.Load(cmd.ExecuteReader())

                        If dtResults.Rows.Count = 1 Then
                            Dim ms = New MemoryStream(CType(dtResults.Rows(0)("ImageData"), Byte()))
                            description = Convert.ToString(dtResults.Rows(0)("Description"))
                            inBoundImage = Image.FromStream(ms)
                            SuccessType = Success.Okay
                        Else
                            SuccessType = Success.OhSnap
                        End If
                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                        SuccessType = Success.OhSnap
                    End Try
                End Using
            End Using

            Return SuccessType

        End Function
        ''' <summary>
        ''' Get an image in the database table by primary key
        ''' </summary>
        ''' <param name="identifier"></param>
        ''' <param name="inBoundImage"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' Not used, here for you if needed to get a single image, has been tested and works
        ''' </remarks>
        Public Function GetImage(identifier As Integer, ByRef inBoundImage As Image) As Success
            Dim description = ""
            Return GetImage(identifier, inBoundImage, description)
        End Function
        ''' <summary>
        ''' Return all records in our table
        ''' </summary>
        ''' <returns></returns>
        Public Function DataTable() As DataTable
            Dim dt = New DataTable()
            mHasException = False

            Using cn = New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd = New SqlCommand With {
                    .Connection = cn,
                    .CommandText = "ReadAllRecords"
                }
                    cmd.CommandType = CommandType.StoredProcedure

                    Try
                        cn.Open()
                        dt.Load(cmd.ExecuteReader())
                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                    End Try
                End Using
            End Using

            Return dt

        End Function

    End Class


End Namespace
