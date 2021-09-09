Public Class FormaPago

    Public Sub New()

    End Sub

    Public Sub New(ByVal Id As Integer, ByVal Descripcion As String)
        pID = Id
        pDescripcion = Descripcion
    End Sub

    Private pID As Integer
    Public Property ID() As Integer
        Get
            Return pID
        End Get
        Set(ByVal value As Integer)
            pID = value
        End Set
    End Property

    Private pDescripcion As String
    Public Property Descripcion() As String
        Get
            Return pDescripcion
        End Get
        Set(ByVal value As String)
            pDescripcion = value
        End Set
    End Property

End Class
