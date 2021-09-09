
Public Class ComprobanteInterno

    Private pId As Integer
    Public Property ID As Integer
        Get
            Return pId
        End Get
        Set(ByVal value As Integer)
            pId = value
        End Set
    End Property

    Private pFecha As Date
    Public Property Fecha As Date
        Get
            Return pFecha
        End Get
        Set(ByVal value As Date)
            pFecha = value
        End Set
    End Property

    Private pEstado As Integer
    Public Property Estado As Integer
        Get
            Return pEstado
        End Get
        Set(ByVal value As Integer)
            pEstado = value
        End Set
    End Property

    Private pItems As List(Of PedidoItem)




    Private pNotas As String
    Public Property Notas() As String
        Get
            Return pNotas
        End Get
        Set(ByVal value As String)
            pNotas = value
        End Set
    End Property

End Class
