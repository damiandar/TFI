Public Class Familia
    Public Sub New()

    End Sub

    Public Sub New(ByVal FamiliaID As Integer, ByVal nombre As String, ByVal descripcion As String)
        pIdFamilia = FamiliaID
        pNombre = nombre
        pDescripcion = descripcion
    End Sub

    Private pIdFamilia As Integer
    Private pNombre As String
    Private pEstado As Boolean
    Private pDescripcion As String
    Private pListaPatentes As List(Of Patente)

    Public Property IdFamilia() As Integer
        Get
            Return pIdFamilia
        End Get
        Set(ByVal value As Integer)
            pIdFamilia = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return pNombre
        End Get
        Set(ByVal value As String)
            pNombre = value
        End Set
    End Property

    Public Property Estado() As Boolean
        Get
            Return pEstado
        End Get
        Set(ByVal value As Boolean)
            pEstado = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return pDescripcion
        End Get
        Set(ByVal value As String)
            pDescripcion = value
        End Set
    End Property

    Public Property ListaPatentes() As List(Of Patente)
        Get
            Return pListaPatentes
        End Get
        Set(ByVal value As List(Of Patente))
            pListaPatentes = value
        End Set
    End Property


End Class