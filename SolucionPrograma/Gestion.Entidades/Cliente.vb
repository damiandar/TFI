
Public Class Cliente

    Public Sub New()

    End Sub

    Public Sub New(ByVal Id As Integer)
        pID = Id
    End Sub

    Public Sub New(ByVal CUIT As Long, ByVal Razon As String)
        Me.CUIT = CUIT
        Me.Razon = Razon
    End Sub

    Public Sub New(ByVal id As Integer, ByVal cuit As String, ByVal razon As String)
        pID = id
        pCuit = cuit
        pRazon = razon
    End Sub

    Private pID As Integer
    Public Property ID() As Integer
        Get
            Return pID
        End Get
        Set(ByVal value As Integer)
            pID = value
        End Set
    End Property

    Private pRazon As String
    Public Property Razon() As String
        Get
            Return pRazon
        End Get
        Set(ByVal value As String)
            pRazon = value
        End Set
    End Property

    Private pDomicilio As String
    Public Property Domicilio() As String
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

    Private pMail As String
    Public Property Mail() As String
        Get
            Return pMail
        End Get
        Set(ByVal value As String)
            pMail = value
        End Set
    End Property

    Private pWEB As String
    Public Property WEB() As String
        Get
            Return pWEB
        End Get
        Set(ByVal value As String)
            pWEB = value
        End Set
    End Property

    Private pContacto As String
    Public Property Contacto() As String
        Get
            Return pContacto
        End Get
        Set(ByVal value As String)
            pContacto = value
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

    Private pCuit As Long
    Public Property CUIT() As Long
        Get
            Return pCuit
        End Get
        Set(ByVal value As Long)
            pCuit = value
        End Set
    End Property

    Private pEstado As Boolean
    Public Property Estado() As Boolean
        Get
            Return pEstado
        End Get
        Set(ByVal value As Boolean)
            pEstado = value
        End Set
    End Property

    Private pResponsable As ResponsabilidadFiscal
    Public Property Responsable() As ResponsabilidadFiscal
        Get
            Return pResponsable
        End Get
        Set(ByVal value As ResponsabilidadFiscal)
            pResponsable = value
        End Set
    End Property



    Private pCtaCte As CtaCte
    Public Property ctacte As CtaCte
        Get
            Return pCtaCte
        End Get
        Set(ByVal value As CtaCte)
            pCtaCte = value
        End Set
    End Property


End Class
