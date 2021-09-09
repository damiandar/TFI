
Public Class Catalogo
    Private pId As Integer
    Private pDescripcion As String
    Private pCodigoInterno As String
    Private pEstado As Boolean

    Public Sub New()

    End Sub

    Public Sub New(ByVal id As Integer, ByVal descripcion As String)
        pId = id
        pDescripcion = descripcion
    End Sub

    Public Property ID As Integer
        Get
            Return pId
        End Get
        Set(ByVal value As Integer)
            pId = value
        End Set
    End Property

    Private pNombreCorto As String
    Public Property NombreCorto() As String
        Get
            Return pNombreCorto
        End Get
        Set(ByVal value As String)
            pNombreCorto = value
        End Set
    End Property

    Private pNombreLargo As String
    Public Property NombreLargo() As String
        Get
            Return pNombreLargo
        End Get
        Set(ByVal value As String)
            pNombreLargo = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return pDescripcion
        End Get
        Set(ByVal value As String)
            pDescripcion = value
        End Set
    End Property
     
    Public Property Estado As Boolean
        Get
            Return pEstado
        End Get
        Set(ByVal value As Boolean)
            pEstado = value
        End Set
    End Property

    Private pPrecio As Precio
    Public Property precio() As Precio
        Get
            Return pPrecio
        End Get
        Set(ByVal value As Precio)
            pPrecio = value
        End Set
    End Property

    Private pSubCategoriaId As Integer
    Public Property SubCategoriaID() As Integer
        Get
            Return pSubCategoriaId
        End Get
        Set(ByVal value As Integer)
            pSubCategoriaId = value
        End Set
    End Property

    Private pCategoriaID As Integer
    Public Property CategoriaID() As Integer
        Get
            Return pCategoriaID
        End Get
        Set(ByVal value As Integer)
            pCategoriaID = value
        End Set
    End Property

End Class

 