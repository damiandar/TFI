Public Class PrecioLista

    Private pID As Integer
    Public Property ID() As Integer
        Get
            Return pID
        End Get
        Set(ByVal value As Integer)
            pID = value
        End Set
    End Property

    Private pFechaCreacion As DateTime
    Public Property FechaCreacion() As DateTime
        Get
            Return pFechaCreacion
        End Get
        Set(ByVal value As DateTime)
            pFechaCreacion = value
        End Set
    End Property

    Private pFechaVigencia As DateTime
    Public Property FechaVigencia() As DateTime
        Get
            Return pFechaVigencia
        End Get
        Set(ByVal value As DateTime)
            pFechaVigencia = value
        End Set
    End Property

    Private pActiva As Boolean
    Public Property Activa() As Boolean
        Get
            Return pActiva
        End Get
        Set(ByVal value As Boolean)
            pActiva = value
        End Set
    End Property

    Private pProductos As List(Of Productos)
    Public Property Productos() As List(Of Productos)
        Get
            Return pProductos
        End Get
        Set(ByVal value As List(Of Productos))
            pProductos = value
        End Set
    End Property

End Class
