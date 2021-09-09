Public Class BLLPrecio

    Dim dataProvider As DALPrecio
    Public Sub New()
        dataProvider = New DALPrecio
    End Sub

    Public Function MostraListasPrecio(ByVal PrecioListaID As Integer) As List(Of PrecioLista)
        Dim ListaDeListas As New List(Of PrecioLista)
        ListaDeListas = dataProvider.MostrarListaPrecios(PrecioListaID)
        If PrecioListaID > 0 Then
            If ListaDeListas.Count > 0 Then
                For Each UnaLista As PrecioLista In ListaDeListas
                    Dim GestorProducto As New BLLProducto
                    UnaLista.Productos = GestorProducto.MostrarProductosPrecioLista(PrecioListaID)
                Next
            End If
        End If
        Return ListaDeListas
    End Function

    Public Sub ModificarProductoPrecio(ByVal Producto As Productos, ByVal ListaID As Integer)
        dataProvider.ModificarProductoPrecio(Producto, ListaID)
    End Sub

    Public Sub InsertarProductoPrecio(ByVal ProductoId As Integer, ByVal Precio As Precio)
        Dim Listas As New List(Of PrecioLista)
        Listas = Me.MostraListasPrecio(0)

        Dim Activa As New PrecioLista
        Activa = Listas.Find(Function(x) x.Activa = True)

        Listas = Listas.FindAll(Function(x) x.ID >= Activa.ID)
        For Each UnaLista As PrecioLista In Listas
            dataProvider.InsertarProductoPrecio(ProductoId, Precio, UnaLista.ID)
        Next

    End Sub

    Public Sub CrearListaPrecios(ByVal FechaVigencia As DateTime)
        dataProvider.CrearListaPrecios(FechaVigencia)
    End Sub

    Public Sub ActivarListaPrecio(ByVal ListaPrecioID As Integer)
        dataProvider.ActivarListaPrecio(ListaPrecioID)
    End Sub


End Class
