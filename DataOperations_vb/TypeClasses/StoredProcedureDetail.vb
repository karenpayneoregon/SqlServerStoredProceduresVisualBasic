Namespace TypeClasses
    ''' <summary>
    ''' Container for stored procedure parameter definitions
    ''' </summary>
    Public Class StoredProcedureDetail
        Public Property Name() As String
        Public Property SystemType() As Byte
        Public Property MaxLength() As Integer
        Public Property Precision() As Byte
        Public Property Scale() As Byte
        ''' <summary>
        ''' Used to populate ListView
        ''' </summary>
        ''' <returns></returns>
        Public Function ItemArray() As String()
            Return {Name, SystemType.ToString(), MaxLength.ToString(), Precision.ToString(), Scale.ToString()}
        End Function
    End Class
End Namespace