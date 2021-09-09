
Public Class Pedido

    Public Enum ePedidoEstado
        Creado = 1
        Confirmado = 2
        EnDistribucion = 3
        Entregado = 4
        Anulado = 5
    End Enum

    Private pID As Integer
    Public Property ID() As Integer
        Get
            Return pID
        End Get
        Set(ByVal value As Integer)
            pID = value
        End Set
    End Property

    Private pCliente As Cliente
    Public Property cliente() As Cliente
        Get
            Return pCliente
        End Get
        Set(ByVal value As Cliente)
            pCliente = value
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


    Private pFormaPago As FormaPago
    Public Property formapago() As FormaPago
        Get
            Return pFormaPago
        End Get
        Set(ByVal value As FormaPago)
            pFormaPago = value
        End Set
    End Property

    Private pFormaEnvio As FormaEnvio
    Public Property FormaEnvio() As FormaEnvio
        Get
            Return pFormaEnvio
        End Get
        Set(ByVal value As FormaEnvio)
            pFormaEnvio = value
        End Set
    End Property

    Private pDomicilioEnvio As DomicilioEnvio
    Public Property domicilioenvio() As DomicilioEnvio
        Get
            Return pDomicilioEnvio
        End Get
        Set(ByVal value As DomicilioEnvio)
            pDomicilioEnvio = value
        End Set
    End Property

    Private pEstadoPedido As ePedidoEstado
    Public Property EstadoPedido() As ePedidoEstado
        Get
            Return pEstadoPedido
        End Get
        Set(ByVal value As ePedidoEstado)
            pEstadoPedido = value
        End Set
    End Property

    Private pItems As List(Of PedidoItem)
    Public Property Items() As List(Of PedidoItem)
        Get
            Return pItems
        End Get
        Set(ByVal value As List(Of PedidoItem))
            pItems = value
        End Set
    End Property

    ''' <summary>
    ''' La suma de todos los totales (total con imp * cantidad) de los items.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Total() As Double
        Get
            Dim pTotal As Double = 0
            If Items.Count > 0 Then
                pTotal = Items.Sum(Function(x) x.cantidad * x.Total)
            End If
            Return pTotal
        End Get
    End Property
End Class
