
Public Class Contrato

    Private pServicio As Servicio
    Public Property servicio() As Servicio
        Get
            Return pServicio
        End Get
        Set(ByVal value As Servicio)
            pServicio = value
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

    'si se hace solo una vez o si es mensual
    Private pEventual As Boolean
    Public Property Eventual() As Boolean
        Get
            Return pEventual
        End Get
        Set(ByVal value As Boolean)
            pEventual = value
        End Set
    End Property

    Private pFechaFirmado As Date
    Public Property FechaFirmado() As Date
        Get
            Return pFechaFirmado
        End Get
        Set(ByVal value As Date)
            pFechaFirmado = value
        End Set
    End Property

    Private pFechaFinalizado As DateTime
    Public Property FechaFinalizado() As DateTime
        Get
            Return pFechaFinalizado
        End Get
        Set(ByVal value As DateTime)
            pFechaFinalizado = value
        End Set
    End Property

    Private pMesesVigencia As Integer
    Public Property MesesVigencia() As Integer
        Get
            Return pMesesVigencia
        End Get
        Set(ByVal value As Integer)
            pMesesVigencia = value
        End Set
    End Property

    Private pBonificado As Boolean
    Public Property Bonificado() As Boolean
        Get
            Return pBonificado
        End Get
        Set(ByVal value As Boolean)
            pBonificado = value
        End Set
    End Property

    'si no pago en tantos dias se corta el servicio
    Private pDiasDeCorte As Integer
    Public Property DiasDeCorte() As Integer
        Get
            Return pDiasDeCorte
        End Get
        Set(ByVal value As Integer)
            pDiasDeCorte = value
        End Set
    End Property

   
End Class
