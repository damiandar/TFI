Public Class BLLServicio

    Dim dataProvider As DALServicio

    Public Sub New()
        dataProvider = New DALServicio
    End Sub

    Public Sub InsertarServicio(ByVal UnServicio As Servicio)
        dataProvider.InsertarServicio(UnServicio)
    End Sub

    Public Function ListarServicios(ByVal ServicioID As Integer, ByVal CategoriaID As Integer, ByVal SubCategoriaID As Integer) As List(Of Servicio)
        Return dataProvider.ListarServicios(ServicioID, CategoriaID, SubCategoriaID)
    End Function

    Public Function MostrarServicio(ByVal ServicioID As Integer) As Servicio
        Dim UnServicio As New Servicio
        Dim ListaServicios As List(Of Servicio) = dataProvider.ListarServicios(ServicioID, 0, 0)
        If ListaServicios.Count > 0 Then
            UnServicio = ListaServicios.Item(0)
        End If
        Return UnServicio
    End Function

    Public Sub ActualizarServicio(ByVal UnServicio As Servicio)
        'dataProvider.ActualizarProducto(UnProducto)
    End Sub


End Class
