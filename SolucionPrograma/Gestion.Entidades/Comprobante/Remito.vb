Public Class Remito
    Inherits Comprobante

    Private pFechaCarga As DateTime
    Public Property fechacarga() As DateTime
        Get
            Return pFechaCarga
        End Get
        Set(ByVal value As DateTime)
            pFechaCarga = value
        End Set
    End Property

    Private pRecepciono As String
    Public Property recepciono() As String
        Get
            Return pRecepciono
        End Get
        Set(ByVal value As String)
            pRecepciono = value
        End Set
    End Property

    Private pNro As Integer
    Public Property Nro() As Integer
        Get
            Return pNro
        End Get
        Set(ByVal value As Integer)
            pNro = value
        End Set
    End Property

    Private pItems As List(Of RemitoItem)
    Public Property Items() As List(Of RemitoItem)
        Get
            Return pItems
        End Get
        Set(ByVal value As List(Of RemitoItem))
            pItems = value
        End Set
    End Property

    Private pOrden As OrdenCompra
    Public Property orden() As OrdenCompra
        Get
            Return pOrden
        End Get
        Set(ByVal value As OrdenCompra)
            pOrden = value
        End Set
    End Property
End Class
