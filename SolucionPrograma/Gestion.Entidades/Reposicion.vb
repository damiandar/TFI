Public Class Reposicion

    Public Enum eEstado
        creado = 0
        enviado = 1
        comprado = 2
    End Enum

    Private pId As Integer
    Public Property ID As Integer
        Get
            Return pId
        End Get
        Set(ByVal value As Integer)
            pId = value
        End Set
    End Property

    Private pFecha As Date
    Public Property Fecha As Date
        Get
            Return pFecha
        End Get
        Set(ByVal value As Date)
            pFecha = value
        End Set
    End Property

    Private pEstado As eEstado
    Public Property Estado As eEstado
        Get
            Return pEstado
        End Get
        Set(ByVal value As eEstado)
            pEstado = value
        End Set
    End Property

    Private pNotas As String
    Public Property Notas() As String
        Get
            Return pNotas
        End Get
        Set(ByVal value As String)
            pNotas = value
        End Set
    End Property

    Private pComprado As Boolean
    Public Property Comprado() As Boolean
        Get
            Return pComprado
        End Get
        Set(ByVal value As Boolean)
            pComprado = value
        End Set
    End Property

    Private pItems As List(Of ReposicionItem)
    Public Property Items() As List(Of ReposicionItem)
        Get
            Return pItems
        End Get
        Set(ByVal value As List(Of ReposicionItem))
            pItems = value
        End Set
    End Property

End Class
