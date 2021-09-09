Public Class BLLProducto

    Dim dataProvider As DALProducto

    Public Sub New()
        dataProvider = New DALProducto
    End Sub

    ''' <summary>
    ''' Inserta el producto con su precio
    ''' </summary>
    ''' <param name="UnProducto"></param>
    Public Sub InsertarProducto(ByVal UnProducto As Productos)
        Dim ProductoId As Integer = dataProvider.InsertarProducto(UnProducto)
        Dim GestorPrecio As New BLLPrecio
        GestorPrecio.InsertarProductoPrecio(ProductoId, UnProducto.precio)
    End Sub

    Public Function ListarProducto(ByVal ProductoID As Integer, ByVal CategoriaID As Integer, ByVal SubCategoriaID As Integer, ByVal Descripcion As String) As List(Of Productos)
        Return dataProvider.ListarProductos(ProductoID, CategoriaID, SubCategoriaID, Descripcion)
    End Function

    Public Function MostrarProducto(ByVal ProductoID As Integer) As Productos
        Dim UnProducto As New Productos()
        Dim ListaProductos As List(Of Productos) = dataProvider.ListarProductos(ProductoID, 0, 0, "")
        If ListaProductos.Count > 0 Then
            UnProducto = ListaProductos.Item(0)
        End If
        Return UnProducto
    End Function

    Public Function MostrarProductosPrecioLista(ByVal PrecioListaID As Integer) As List(Of Productos)
        Return dataProvider.MostrarProductosPrecioLista(PrecioListaID)
    End Function

    Public Sub ActualizarProducto(ByVal UnProducto As Productos)
        dataProvider.ActualizarProducto(UnProducto)
    End Sub


End Class
