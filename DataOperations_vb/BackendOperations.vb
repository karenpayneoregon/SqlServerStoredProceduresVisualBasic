Imports System.Data.SqlClient
Imports DataOperations.TypeClasses

''' <summary>
''' All data queries are in Stored Procedures
''' </summary>
Public Class BackendOperations
    Inherits BaseConnectionLibrary.ConnectionClasses.SqlServerConnection

    Public Sub New()
        '
        ' Make sure to change DatabaseServer to the server
        ' with CustomerDatabase
        '
        DatabaseServer = "KARENS-PC"
        DefaultCatalog = "CustomerDatabase"

    End Sub

    Public Function RetrieveAllRecords() As DataTable

        mHasException = False
        Dim dt = New DataTable

        Try
            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn, .CommandType = CommandType.StoredProcedure}

                    cmd.CommandText = "dbo.[SelectAllCustomers]"

                    cn.Open()
                    dt.Load(cmd.ExecuteReader())

                    dt.Columns("ContactTypeIdentifier").ColumnMapping = MappingType.Hidden

                End Using
            End Using

        Catch ex As Exception
            mHasException = True
            mLastException = ex
        End Try

        Return dt

    End Function
    ''' <summary>
    ''' Mocked up sample showing how to return error information from a failed
    ''' operation within a stored procedure.
    ''' </summary>
    Public Sub ReturnErrorInformation()
        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn, .CommandType = CommandType.StoredProcedure}

                cmd.CommandText = "dbo.[usp_ThrowDummyException]"

                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@ErrorMessage", .SqlDbType = SqlDbType.NVarChar,
                                      .Direction = ParameterDirection.Output}).Value = ""

                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@ErrorSeverity", .SqlDbType = SqlDbType.Int,
                                      .Direction = ParameterDirection.Output})

                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@ErrorState", .SqlDbType = SqlDbType.Int,
                                      .Direction = ParameterDirection.Output})

                Try
                    cn.Open()
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine($"[{ex.Message}]")
                    Console.WriteLine(cmd.Parameters("@ErrorSeverity").Value)
                    Console.WriteLine(cmd.Parameters("@ErrorState").Value)
                End Try
            End Using
        End Using
    End Sub
    ''' <summary>
    ''' This example does not return contact type (contact name) as this is
    ''' common practice as we know the type from the ComboBox selection.
    ''' </summary>
    ''' <param name="contactTypeIdentifier"></param>
    ''' <returns></returns>
    Public Function GetAllRecordsByContactTitle(contactTypeIdentifier As Integer) As DataTable
        mHasException = False
        Dim dt = New DataTable

        Try
            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn, .CommandType = CommandType.StoredProcedure}

                    cmd.CommandText = "dbo.ContactByType"

                    cmd.Parameters.Add(New SqlParameter With
                                          {
                                              .ParameterName = "@ContactTitleTypeIdentifier",
                                              .SqlDbType = SqlDbType.Int
                                          })

                    cmd.Parameters("@ContactTitleTypeIdentifier").Value = contactTypeIdentifier

                    cn.Open()

                    dt.Load(cmd.ExecuteReader)

                End Using
            End Using

        Catch ex As Exception
            mHasException = True
            mLastException = ex
        End Try

        Return dt

    End Function
    Public Function RetrieveContactTitles() As List(Of ContactType)

        mHasException = False

        Dim contactList As New List(Of ContactType)

        Try
            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn, .CommandType = CommandType.StoredProcedure}

                    cmd.CommandText = "dbo.[SelectContactTitles]"

                    cn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While reader.Read
                            contactList.Add(New ContactType() With
                                               {
                                                   .Identifier = reader.GetInt32(0),
                                                   .ContactType = reader.GetString(1)
                                               })
                        End While
                    End If
                End Using
            End Using

        Catch ex As Exception
            mHasException = True
            mLastException = ex
        End Try

        Return contactList

    End Function
    Public Function AddCustomer(companyName As String, contactName As String, contactTypeIdentifier As Integer) As Integer
        mHasException = False
        Try
            Using cn As New SqlConnection With {.ConnectionString = ConnectionString}

                Using cmd As New SqlCommand With {.Connection = cn, .CommandType = CommandType.StoredProcedure}

                    cmd.CommandText = "dbo.InsertCustomer"

                    cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@CompanyName", .SqlDbType = SqlDbType.NVarChar})
                    cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@ContactName", .SqlDbType = SqlDbType.NVarChar})
                    cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@ContactTypeIdentifier", .SqlDbType = SqlDbType.Int})
                    cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@Identity", .SqlDbType = SqlDbType.Int,
                                                              .Direction = ParameterDirection.Output})

                    cmd.Parameters("@CompanyName").Value = companyName
                    cmd.Parameters("@ContactName").Value = contactName
                    cmd.Parameters("@ContactTypeIdentifier").Value = contactTypeIdentifier

                    cn.Open()

                    cmd.ExecuteScalar()

                    Return CInt(cmd.Parameters("@Identity").Value)

                End Using
            End Using
        Catch ex As Exception
            mHasException = True
            mLastException = ex

            Return -1

        End Try
    End Function
    Public Function RemoveCustomer(identifier As Integer) As Boolean
        mHasException = False
        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn, .CommandType = CommandType.StoredProcedure}

                cmd.CommandText = "dbo.[DeleteCustomer]"

                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@Identity", .SqlDbType = SqlDbType.Int})
                cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@flag", .SqlDbType = SqlDbType.Bit,
                                                          .Direction = ParameterDirection.Output})

                cmd.Parameters("@Identity").Value = identifier
                cmd.Parameters("@flag").Value = 0

                Try

                    cn.Open()

                    cmd.ExecuteNonQuery()

                    If CBool(cmd.Parameters("@flag").Value) Then
                        Return True
                    Else
                        Return False
                    End If
                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                    Return False
                End Try
            End Using
        End Using
    End Function
    ''' <summary>
    ''' Update record if primary is found
    ''' </summary>
    ''' <param name="primaryKey"></param>
    ''' <param name="companyName"></param>
    ''' <param name="contactName"></param>
    ''' <param name="contactIdentifier"></param>
    ''' <returns></returns>
    Public Function UpdateCustomer(
       primaryKey As Integer,
       companyName As String,
       contactName As String,
       contactIdentifier As Integer) As Boolean

        mHasException = False

        Try
            Using cn As New SqlConnection With {.ConnectionString = Me.ConnectionString}
                Using cmd As New SqlCommand With {.Connection = cn, .CommandType = CommandType.StoredProcedure}

                    cmd.CommandText = "dbo.[UpateCustomer]"

                    cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@CompanyName", .SqlDbType = SqlDbType.NVarChar})
                    cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@ContactName", .SqlDbType = SqlDbType.NVarChar})
                    cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@ContactTypeIdentifier", .SqlDbType = SqlDbType.Int})
                    cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@Identity", .SqlDbType = SqlDbType.Int})
                    cmd.Parameters.Add(New SqlParameter With {.ParameterName = "@flag", .SqlDbType = SqlDbType.Bit,
                                                              .Direction = ParameterDirection.Output})

                    cmd.Parameters("@CompanyName").Value = companyName
                    cmd.Parameters("@ContactName").Value = contactName
                    cmd.Parameters("@ContactTypeIdentifier").Value = contactIdentifier
                    cmd.Parameters("@Identity").Value = primaryKey
                    cmd.Parameters("@flag").Value = 0

                    cn.Open()

                    cmd.ExecuteNonQuery()

                    If CBool(cmd.Parameters("@flag").Value) Then
                        Return True
                    Else
                        Return False
                    End If

                End Using
            End Using
        Catch ex As Exception
            mHasException = True
            mLastException = ex
            Return False
        End Try
    End Function
End Class
