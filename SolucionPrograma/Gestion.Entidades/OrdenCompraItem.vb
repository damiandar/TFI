
Public Class OrdenCompraItem

    Public Enum eEstado
        Creado = 1
        EntregadoParcial = 2
        EntregadoTotal = 3
    End Enum

    Private pInsumo As Insumo
    Public Property insumo() As Insumo
        Get
            Return pInsumo
        End Get
        Set(ByVal value As Insumo)
            pInsumo = value
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

    Private pCantidadEntregada As Integer
    Public Property CantidadEntregada() As Integer
        Get
            Return pCantidadEntregada
        End Get
        Set(ByVal value As Integer)
            pCantidadEntregada = value
        End Set
    End Property

    Public ReadOnly Property CantidadRestante() As Integer
        Get
            Return cantidad - CantidadEntregada
        End Get
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

    Private pEstado As eEstado
    Public Property Estado() As eEstado
        Get
            Return pEstado
        End Get
        Set(ByVal value As eEstado)
            pEstado = value
        End Set
    End Property

    ''' <summary>
    ''' Cantidad * Precio con IVA
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Total() As Double
        Get
            Return cantidad * precio * iva.Multiplicador
        End Get
    End Property

    ''' <summary>
    ''' Unitario con impuestos
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property PrecioConImpuestos() As Double
        Get
            Dim ValorConImpuestos As Double = 0
            If precio > 0 Then
                ValorConImpuestos = precio * iva.Multiplicador
            End If
            Return ValorConImpuestos
        End Get
    End Property


End Class
