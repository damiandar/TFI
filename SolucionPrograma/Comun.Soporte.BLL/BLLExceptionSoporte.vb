Public Class BLLExceptionSoporte
    Inherits Exception

    Public Sub New()
        MyBase.New()
        ' Add implementation.
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)

        ' Add implementation.
    End Sub

    Public Sub New(ByVal message As String, ByVal inner As Exception)
        MyBase.New(message, inner)
        ' Add implementation.
    End Sub

    Public Event ErrorGrave()
End Class
