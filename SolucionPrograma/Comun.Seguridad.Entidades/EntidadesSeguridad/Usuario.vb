Public Class Usuario

#Region "Variables"

    Private VContrasenia As String
    Private VFechaAlta As Date
    Private VLogin As String
    Private VNombre As String
    Private VEstado As Boolean
    Private VBloqueado As Boolean
    
#End Region

#Region "Propiedades"
 
    Public Property Login() As String
        Get
            Return VLogin
        End Get
        Set(ByVal value As String)
            VLogin = value
        End Set
    End Property
    Public Property Contrasenia() As String
        Get
            Return VContrasenia
        End Get
        Set(ByVal value As String)
            VContrasenia = value
        End Set
    End Property
    Public Property FechaAlta() As Date
        Get
            Return VFechaAlta
        End Get
        Set(ByVal value As Date)
            VFechaAlta = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return VNombre
        End Get
        Set(ByVal value As String)
            VNombre = value
        End Set
    End Property
    Public Property Estado() As Boolean
        Get
            Return VEstado
        End Get
        Set(ByVal value As Boolean)
            VEstado = value
        End Set
    End Property
    Public Property Bloqueado() As Boolean
        Get
            Return VBloqueado
        End Get
        Set(ByVal value As Boolean)
            VBloqueado = value
        End Set
    End Property

    Private pFamilia As Familia
    Public Property familia() As Familia
        Get
            Return pFamilia
        End Get
        Set(ByVal value As Familia)
            pFamilia = value
        End Set
    End Property

    Private pListaPatentes As List(Of Patente)
    Public Property ListaPatentes() As List(Of Patente)
        Get
            Return pListaPatentes
        End Get
        Set(ByVal value As List(Of Patente))
            pListaPatentes = value
        End Set
    End Property

#End Region

End Class
