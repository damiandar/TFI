Public Class OrdenCompra
    Inherits Comprobante

    Private pAbastecimiento As Reposicion
    Public Property reposicion() As Reposicion
        Get
            Return pAbastecimiento
        End Get
        Set(ByVal value As Reposicion)
            pAbastecimiento = value
        End Set
    End Property

    'Private pNro As Integer
    'Public Property Nro() As Integer
    '    Get
    '        Return pNro
    '    End Get
    '    Set(ByVal value As Integer)
    '        pNro = value
    '    End Set
    'End Property

    Private pItems As List(Of OrdenCompraItem)
    Public Property Items() As List(Of OrdenCompraItem)
        Get
            Return pItems
        End Get
        Set(ByVal value As List(Of OrdenCompraItem))
            pItems = value
        End Set
    End Property

    Private pEstado_id As Integer
    Public Property Estado_id() As Integer
        Get
            Return pEstado_id
        End Get
        Set(ByVal value As Integer)
            pEstado_id = value
        End Set
    End Property
     
    Private pProveedor As Proveedor
    Public Property proveedor() As Proveedor
        Get
            Return pProveedor
        End Get
        Set(ByVal value As Proveedor)
            pProveedor = value
        End Set
    End Property



End Class
