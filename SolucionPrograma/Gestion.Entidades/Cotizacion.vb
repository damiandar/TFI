
Public Class Cotizacion

    Private pid As Integer
    Public Property ID As Integer
        Get
            Return pid
        End Get
        Set(ByVal value As Integer)
            pid = value
        End Set
    End Property

    'fecha carga
    Private pfecha As Date
    Public Property Fecha As Date
        Get
            Return pfecha
        End Get
        Set(ByVal value As Date)
            pfecha = value
        End Set
    End Property

    Private pNotas As String
    Public Property Notas() As String
        Get
            Return pNotas
        End Get
        Set(ByVal value As String)
            pNotas = value
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

    Private pPlazoEntrega As Integer
    Public Property plazoentrega As Integer
        Get
            Return pPlazoEntrega
        End Get
        Set(ByVal value As Integer)
            pPlazoEntrega = value
        End Set
    End Property

    Private pplazopago As Integer
    Public Property plazopago As Integer
        Get
            Return pplazopago
        End Get
        Set(ByVal value As Integer)
            pplazopago = value
        End Set
    End Property
 
    Private pValor As Double
    Public Property valor As Double
        Get
            Return pValor
        End Get
        Set(ByVal value As Double)
            pValor = value
        End Set
    End Property

    Private pEstado As Boolean
    Public Property estado As Boolean
        Get
            Return pEstado
        End Get
        Set(ByVal value As Boolean)
            pEstado = value
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

    Private pItems As List(Of CotizacionItem)
    Public Property Items() As List(Of CotizacionItem)
        Get
            Return pItems
        End Get
        Set(ByVal value As List(Of CotizacionItem))
            pItems = value
        End Set
    End Property


    Public ReadOnly Property ValorUnitarioConImpuestos() As Double
        Get
            Return valor * iva.Multiplicador
        End Get
    End Property

End Class
