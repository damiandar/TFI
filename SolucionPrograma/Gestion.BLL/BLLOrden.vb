Public Class BLLorden

    Dim dataProvider As DALOrdenCompra

    Public Sub New()
        dataProvider = New DALOrdenCompra
    End Sub

    Public Function InsertarOrden(ByVal UnaOrden As OrdenCompra) As Integer
        Dim IdComprobante As Integer = 0
        If UnaOrden.Items.Count > 0 Then

            IdComprobante = dataProvider.InsertarOrden(UnaOrden)
            Dim dataproviderItems As New DALOrdenItem

            For Each UnItem As OrdenCompraItem In UnaOrden.Items
                'inserta item orden
                dataproviderItems.InsertarItem(IdComprobante, UnItem)
            Next

            'If ItemsPedido.Sum(Function(x) x.cantidadRestante) = 0 Then
            '    GestorPedido.ActualizarEstadoReposicion(UnaOrden.reposicion.ID, Reposicion.eEstado.comprado)
            'End If

        End If
        Return IdComprobante
    End Function

    ''' <summary>
    ''' Se Muestra una orden de compra completa
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    Public Function MostrarOrden(ByVal ID As Integer) As OrdenCompra
        Dim UnaOrden As New OrdenCompra
        Dim Lista As New List(Of OrdenCompra)
        Lista = dataProvider.ListarOrdenes(0, ID, 0)
        If Lista.Count > 0 Then
            UnaOrden = Lista.First()
            UnaOrden.Items = New List(Of OrdenCompraItem)
            UnaOrden.Items = ListarItemsOrden(UnaOrden.ID)
        End If
        Return UnaOrden
    End Function

    Public Function ListarOrdenes(ByVal ProveedorID As Integer, ByVal ID As Integer, ByVal PedidoReposicionID As Integer, ByVal MostrarCompleto As Boolean) As List(Of OrdenCompra)
        Dim Lista As New List(Of OrdenCompra)
        Lista = dataProvider.ListarOrdenes(ProveedorID, ID, PedidoReposicionID)
        If Lista.Count > 0 Then
            For Each UnaOrden As OrdenCompra In Lista
                UnaOrden.Items = New List(Of OrdenCompraItem)
                UnaOrden.Items = ListarItemsOrden(UnaOrden.ID)
            Next
        End If
        Return Lista
    End Function

#Region "Items"

    Private Function ListarItemsOrden(ByVal ComprobanteID As Integer) As List(Of OrdenCompraItem)
        Dim dataproviderItems As New DALOrdenItem
        Return dataproviderItems.ListarItemOrden(ComprobanteID, 0)
    End Function

    Public Sub ActualizarItemOrden(ByVal OrdenID As Integer, ByVal UnItemCompra As OrdenCompraItem)
        Dim dataproviderItems As New DALOrdenItem
        dataproviderItems.ModificarItemCompra(OrdenID, UnItemCompra)
    End Sub


#End Region



End Class
