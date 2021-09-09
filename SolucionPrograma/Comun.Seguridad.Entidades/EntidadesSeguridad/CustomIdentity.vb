Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Web.Security
Imports System.Web.HttpResponse


Public Class CustomIdentity

    Private _ticket As System.Web.Security.FormsAuthenticationTicket

#Region "Campos"

    Private _rol As String
    'Private _grupo As Integer
    'Private _apellidonombre As String
    'Private _zona As Integer
    'Private _documentonro As Integer
    'Private _campania As Integer
    'Private _campaniafecha As Integer
    'Private _campaniahora As Integer
    'Private _domicilioalternativo As String
    'Private _zonaqueatiende As Integer
    'Private _zonasuplente1 As Integer
    'Private _zonasuplente2 As Integer
    'Private _campaniahoracierrerevendedora As Integer
    ''20/2/2014 mbruno
    'Private _campaniafechacierrerevendedora As Integer

#End Region

#Region "Propiedades"
    '0
    Public ReadOnly Property Rol() As String
        Get
            Return _rol
        End Get
    End Property

#End Region

#Region "Metodos"

    'Public Function DevuelveCadenaDeUsuario() As String

    '    Dim listaDatos As New List(Of String)
    '    Dim userDataString As String = Rol
    '    listaDatos.Add(Zona)
    '    listaDatos.Add(Grupo)
    '    listaDatos.Add(Campania)
    '    listaDatos.Add(CampaniaFecha)
    '    listaDatos.Add(ApellidoNombre)
    '    listaDatos.Add("no cargado")
    '    listaDatos.Add(DocumentoNro)
    '    listaDatos.Add(ZonaQueAtiende)
    '    listaDatos.Add(ZonaSuplente1)
    '    listaDatos.Add(ZonaSuplente2)
    '    listaDatos.Add(CampaniaHora)
    '    listaDatos.Add(CampaniaHoraCierreRevendedora)
    '    '20/2/2014 mbruno
    '    listaDatos.Add(CampaniaFechaCierreRevendedora)
    '    For Each valor As String In listaDatos
    '        userDataString = String.Concat(userDataString, "|", valor)
    '    Next
    '    Return userDataString
    'End Function

#End Region

#Region "Constructores"

    Public Sub New()

    End Sub

    'Public Sub New(ByVal oUsuario As Usuarios, ByVal oCalendario As Calendario)
    '    _rol = oUsuario.tipousuario
    '    _zona = oUsuario.zona
    '    _grupo = oUsuario.grupo
    '    _campania = oCalendario.campania
    '    _campaniafecha = oCalendario.fecha
    '    _apellidonombre = oUsuario.apellidonombre
    '    _domicilioalternativo = "no cargado"
    '    _documentonro = oUsuario.numerodocumento
    '    _zonaqueatiende = oUsuario.zonaatiende
    '    _zonasuplente1 = oUsuario.zonasuplente1
    '    _zonasuplente2 = oUsuario.zonasuplente2
    '    _campaniahora = oCalendario.hora
    '    _campaniahoracierrerevendedora = oCalendario.horarevendedora
    '    '20/2/2014 mbruno
    '    _campaniafechacierrerevendedora = oCalendario.fecharevendedora
    '    '_cuenta = oUsuario.cuenta
    'End Sub

    Public Sub New(ByVal ticket As System.Web.Security.FormsAuthenticationTicket)
        _ticket = ticket
        Dim userDataPieces() As String = _ticket.UserData.Split("|".ToCharArray())
        _rol = userDataPieces(0)
    End Sub

#End Region

    Public ReadOnly Property AuthenticationType() As String
        Get
            Return "Custom"
        End Get
    End Property

    Public ReadOnly Property IsAuthenticated() As Boolean
        Get
            Return True
        End Get
    End Property
    'cuenta
    Public ReadOnly Property Name() As String
        Get
            Return _ticket.Name
        End Get
    End Property


End Class
