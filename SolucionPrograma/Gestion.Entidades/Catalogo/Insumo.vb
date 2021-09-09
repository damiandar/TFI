
Public Class Insumo
    Inherits Catalogo

    Public Sub New()

    End Sub

    Public Sub New(ByVal InsumoId As Integer, ByVal NombreCorto As String, ByVal NombreLargo As String, ByVal Descripcion As String)
        Me.ID = InsumoId
        Me.NombreCorto = NombreCorto
        Me.NombreLargo = NombreLargo
        Me.Descripcion = Descripcion
    End Sub
    Private pStock As Stock
    Public Property stock As Stock
        Get
            Return pStock
        End Get
        Set(ByVal value As Stock)
            pStock = value
        End Set
    End Property


End Class
