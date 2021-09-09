
Public Class ReposicionItem 

    Public Enum ePrioridad
        Baja = 0
        Media = 1
        Alta = 2
    End Enum

    Public Enum eEstado
        Creado = 0
        Cotizado = 1
        Comprado = 2
    End Enum

    Private pInsumo As Insumo
    Public Property insumo As Insumo
        Get
            Return pInsumo
        End Get
        Set(ByVal value As Insumo)
            pInsumo = value
        End Set
    End Property

    Private pEspecificacion As String
    Public Property Especificacion() As String
        Get
            Return pEspecificacion
        End Get
        Set(ByVal value As String)
            pEspecificacion = value
        End Set
    End Property

    Private pCantidadPedida As Integer
    Public Property cantidadPedida As Integer
        Get
            Return pCantidadPedida
        End Get
        Set(ByVal value As Integer)
            pCantidadPedida = value
        End Set
    End Property

    Private pcantidadRestante As Integer
    Public Property cantidadRestante As Integer
        Get
            Return pcantidadRestante
        End Get
        Set(ByVal value As Integer)
            pcantidadRestante = value
        End Set
    End Property

    Private pCantidadEntregada As Integer
    Public Property cantidadEntregada As Integer
        Get
            Return pCantidadEntregada
        End Get
        Set(ByVal value As Integer)
            pCantidadEntregada = value
        End Set
    End Property

    Private pEstado As eEstado
    Public Property estado As eEstado
        Get
            Return pEstado
        End Get
        Set(ByVal value As eEstado)
            pEstado = value
        End Set
    End Property


    Private pPrioridad As ePrioridad
    Public Property Prioridad() As ePrioridad
        Get
            Return pPrioridad
        End Get
        Set(ByVal value As ePrioridad)
            pPrioridad = value
        End Set
    End Property

    Private pCotizaciones As List(Of Cotizacion)
    Public Property cotizaciones As List(Of Cotizacion)
        Get
            Return pCotizaciones
        End Get
        Set(ByVal value As List(Of Cotizacion))
            pCotizaciones = value
        End Set
    End Property

End Class
