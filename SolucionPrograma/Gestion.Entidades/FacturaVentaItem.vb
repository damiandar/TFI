
Public Class FacturaVentaItem

    Public Sub New()

    End Sub

    Private pProducto As Productos
    Public Property producto() As Productos
        Get
            Return pProducto
        End Get
        Set(ByVal value As Productos)
            pProducto = value
        End Set
    End Property

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

    Public ReadOnly Property Total() As Double
        Get
            Return precio * cantidad
        End Get

    End Property
End Class
