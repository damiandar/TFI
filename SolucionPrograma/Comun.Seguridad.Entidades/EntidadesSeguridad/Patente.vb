Public Class Patente

    Public Enum eAccion
        SINACCION
        ALTA
        BAJA
        MODIFICACION
        CONSULTA
        INICIOSESION
        CIERRESESION
        CIERRECAMPANIA
        ABRIRCAMPANIA
        CAMBIOCONTRASENIA
        RESTAURAR
        COMENTAR
        CREARNUEVALISTA
        ACTIVARLISTA
        PEDIRINSUMO
        ENVIARPEDIDO
    End Enum

    Public Enum eObjeto
        SINOBJETO
        BACKUP
        BITACORA
        CLIENTE
        COMENTARIO
        FACTURA
        PEDIDO
        PRODUCTO
        PERMISO
        ROL
        IDIOMA
        DIGVER
        LOGIN
        CAMPANIA
        PRECIO
        PROMOCION
        TRADUCCION
        USUARIO
        PERMISOROL
        PERMISOUSUARIO
        INSUMO
        CATEGORIA
        SUBCATEGORIA
        ABASTECIMIENTO
        REMITO
    End Enum

    Public Sub New()

    End Sub

    Public Sub New(ByVal id As Integer, ByVal descripcion As String, ByVal acc As eAccion, ByVal obj As eObjeto)
        pId = id
        pDescripcion = descripcion
        pObjetoAplicacion = obj
        pAccionAplicacion = acc
    End Sub

    Private pId As Integer
    Public Property ID() As Integer
        Get
            Return pId
        End Get
        Set(ByVal value As Integer)
            pId = value
        End Set
    End Property

    Private pDescripcion As String
    Public Property Descripcion() As String
        Get
            Return pDescripcion
        End Get
        Set(ByVal value As String)
            pDescripcion = value
        End Set
    End Property

    Private pObjetoAplicacion As eObjeto
    Public Property ObjetoAplicacion() As eObjeto
        Get
            Return pObjetoAplicacion
        End Get
        Set(ByVal value As eObjeto)
            pObjetoAplicacion = value
        End Set
    End Property

    Private pAccionAplicacion As eAccion
    Public Property AccionAplicacion() As eAccion
        Get
            Return pAccionAplicacion
        End Get
        Set(ByVal value As eAccion)
            pAccionAplicacion = value
        End Set
    End Property


End Class

 