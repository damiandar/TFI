Public Class BLLInsumo

    Dim dataProvider As DALInsumo

    Public Sub New()
        dataProvider = New DALInsumo
    End Sub

    Public Sub InsertarInsumo(ByVal UnInsumo As Insumo)
        dataProvider.InsertarInsumo(UnInsumo)
    End Sub

    Public Function ListarInsumos(ByVal ServicioID As Integer, ByVal CategoriaID As Integer) As List(Of Insumo)
        Return dataProvider.ListarInsumos(ServicioID, CategoriaID)
        Return Nothing
    End Function

    Public Function MostrarInsumos(ByVal InsumoID As Integer) As Insumo
        Dim ListaInsumos As List(Of Insumo) = dataProvider.ListarInsumos(InsumoID, 0)
        Return ListaInsumos.Item(0)

    End Function

    Public Sub ActualizarInsumo(ByVal UnInsumo As Insumo)
        dataProvider.ActualizarInsumo(UnInsumo)
    End Sub

    Public Function MostrarInsumosBajoStock() As List(Of Insumo)
        Dim ListaInsumos As List(Of Insumo) = dataProvider.ListarInsumos(0, 0)
        ListaInsumos = ListaInsumos.FindAll(Function(x) x.stock.Minimo >= x.stock.Actual)
        Return ListaInsumos
    End Function


End Class
