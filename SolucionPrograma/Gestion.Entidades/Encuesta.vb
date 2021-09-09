Public Class Encuesta

    Private pid As Integer
    Public Property ID() As Integer
        Get
            Return pid
        End Get
        Set(ByVal value As Integer)
            pid = value
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

    Private pLista As List(Of EncuestaDetalle)
    Public Property Opciones() As List(Of EncuestaDetalle)
        Get
            Return pLista
        End Get
        Set(ByVal value As List(Of EncuestaDetalle))
            pLista = value
        End Set
    End Property

End Class

Public Class EncuestaDetalle

    Private pID As Integer
    Public Property ID() As Integer
        Get
            Return pID
        End Get
        Set(ByVal value As Integer)
            pID = value
        End Set
    End Property

    Private pDetalle As String
    Public Property Detalle() As String
        Get
            Return pDetalle
        End Get
        Set(ByVal value As String)
            pDetalle = value
        End Set
    End Property

End Class
