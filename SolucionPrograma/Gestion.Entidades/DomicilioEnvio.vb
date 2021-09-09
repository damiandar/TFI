
Public Class DomicilioEnvio


    Private pID As Integer
    Public Property ID() As Integer
        Get
            Return pID
        End Get
        Set(ByVal value As Integer)
            pID = value
        End Set
    End Property

    Private pDomicilio As String
    Public Property Direccion() As String
        Get
            Return pDomicilio
        End Get
        Set(ByVal value As String)
            pDomicilio = value
        End Set
    End Property

    Private pTelefono As String
    Public Property Telefono() As String
        Get
            Return pTelefono
        End Get
        Set(ByVal value As String)
            pTelefono = value
        End Set
    End Property

    Private pLocalidad As String
    Public Property Localidad() As String
        Get
            Return pLocalidad
        End Get
        Set(ByVal value As String)
            pLocalidad = value
        End Set
    End Property

    Private pCodigoPostal As String
    Public Property CP() As String
        Get
            Return pCodigoPostal
        End Get
        Set(ByVal value As String)
            pCodigoPostal = value
        End Set
    End Property

    Private pProvincia As Provincias
    Public Property Provincia() As Provincias
        Get
            Return pProvincia
        End Get
        Set(ByVal value As Provincias)
            pProvincia = value
        End Set
    End Property




End Class
