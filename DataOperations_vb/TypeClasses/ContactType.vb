Namespace TypeClasses
    Public Class ContactType
        Public Property Identifier() As Integer
        Public Property ContactType() As String

        Public Overrides Function ToString() As String
            Return ContactType
        End Function
    End Class
End Namespace