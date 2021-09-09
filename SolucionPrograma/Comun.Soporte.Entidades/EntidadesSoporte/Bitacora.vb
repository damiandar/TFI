Public Class Bitacora

#Region "Variables"

    Private VDescripcion As String
    Private Vlogin As String
    Private VIdBitacora As Integer
    Private VFecha As DateTime
    Private pEsError As Boolean

#End Region

#Region "Propiedades"


    Public Property ID() As Integer
        Get
            Return VIdBitacora
        End Get
        Set(ByVal value As Integer)
            VIdBitacora = value
        End Set
    End Property

    Public Property Login() As String
        Get
            Return Vlogin
        End Get
        Set(ByVal value As String)
            Vlogin = value
        End Set
    End Property

    Private pObjeto As Patente.eObjeto
    Public Property Objeto() As Patente.eObjeto
        Get
            Return pObjeto
        End Get
        Set(ByVal value As Patente.eObjeto)
            pObjeto = value
        End Set
    End Property

    Private pAccion As Patente.eAccion
    Public Property accion() As Patente.eAccion
        Get
            Return pAccion
        End Get
        Set(ByVal value As Patente.eAccion)
            pAccion = value
        End Set
    End Property

    Public Property Evento() As String
        Get
            Return VDescripcion
        End Get
        Set(ByVal value As String)
            VDescripcion = value
        End Set
    End Property

    Public Property EsError() As Boolean
        Get
            Return pEsError
        End Get
        Set(ByVal value As Boolean)
            pEsError = value
        End Set
    End Property

    Public Property Fecha() As DateTime
        Get
            Return VFecha
        End Get
        Set(ByVal value As DateTime)
            VFecha = value
        End Set
    End Property

#End Region

End Class
