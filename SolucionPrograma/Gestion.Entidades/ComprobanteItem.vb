Public Class ComprobanteItem

    'Private pCatalogo As Catalogo
    'Public Property catalogo() As Catalogo
    '    Get
    '        Return pCatalogo
    '    End Get
    '    Set(ByVal value As Catalogo)
    '        pCatalogo = value
    '    End Set
    'End Property

    Private pPrecio As Double
    Public Property precio() As Double
        Get
            Return pPrecio
        End Get
        Set(ByVal value As Double)
            pPrecio = value
        End Set
    End Property

    Private pCantidad As Integer
    Public Property cantidad() As Integer
        Get
            Return pCantidad
        End Get
        Set(ByVal value As Integer)
            pCantidad = value
        End Set
    End Property

    Private pCantidadFacturada As Integer
    Public Property CantidadFacturada() As Integer
        Get
            Return pCantidadFacturada
        End Get
        Set(ByVal value As Integer)
            pCantidadFacturada = value
        End Set
    End Property

    Private pIva As IVA
    Public Property iva() As IVA
        Get
            Return pIva
        End Get
        Set(ByVal value As IVA)
            pIva = value
        End Set
    End Property



End Class
