Public Class Comentarios
    Private pId As Integer
    Public Property ID() As Integer
        Get
            Return pId
        End Get
        Set(ByVal value As Integer)
            pId = value
        End Set
    End Property

    Private pProductoID As Integer
    Public Property ProductoID() As Integer
        Get
            Return pProductoID
        End Get
        Set(ByVal value As Integer)
            pProductoID = value
        End Set
    End Property

    Private pTitulo As String
    Public Property Titulo() As String
        Get
            Return pTitulo
        End Get
        Set(ByVal value As String)
            pTitulo = value
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

    Private pPositivo As Integer
    Public Property Positivo() As Integer
        Get
            Return pPositivo
        End Get
        Set(ByVal value As Integer)
            pPositivo = value
        End Set
    End Property

    Private pNegativo As Integer
    Public Property Negativo() As Integer
        Get
            Return pNegativo
        End Get
        Set(ByVal value As Integer)
            pNegativo = value
        End Set
    End Property

    Private pPor As String
    Public Property Por() As String
        Get
            Return pPor
        End Get
        Set(ByVal value As String)
            pPor = value
        End Set
    End Property

    Private pFecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return pFecha
        End Get
        Set(ByVal value As DateTime)
            pFecha = value
        End Set
    End Property

    Private pPuntaje As Integer
    Public Property Puntaje() As Integer
        Get
            Return pPuntaje
        End Get
        Set(ByVal value As Integer)
            pPuntaje = value
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


End Class
