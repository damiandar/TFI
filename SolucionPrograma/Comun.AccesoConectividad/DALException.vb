Public Class DALException
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

End Class

Public Class DALExceptionPK
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

End Class

Public Class DALExceptionCritica
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

End Class


Public Class DALExceptionFK
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

End Class
