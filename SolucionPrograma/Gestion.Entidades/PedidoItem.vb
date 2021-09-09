
Public Class PedidoItem


    Public Enum EstadoItem
        Creado = 1
        EnProceso = 2
        EnDistribucion = 3
        Entregado = 4
        Anulados = 5
    End Enum

    Private pCantidad As Integer
    Public Property cantidad() As Integer
        Get
            Return pCantidad
        End Get
        Set(ByVal value As Integer)
            pCantidad = value
        End Set
    End Property

    Private pProducto As Productos
    Public Property producto As Productos
        Get
            Return pProducto
        End Get
        Set(ByVal value As Productos)
            pProducto = value
        End Set
    End Property

    Private pEstado As EstadoItem
    Public Property estado As EstadoItem
        Get
            Return pEstado
        End Get
        Set(ByVal value As EstadoItem)
            pEstado = value
        End Set
    End Property

    ''' <summary>
    ''' Con impuestos * cantidad
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Total() As Double
        Get
            Dim valor As Double = 0
            If producto.precio IsNot Nothing Then
                valor = producto.precio.ValorFinal * cantidad
            End If
            Return valor
        End Get
    End Property



End Class
