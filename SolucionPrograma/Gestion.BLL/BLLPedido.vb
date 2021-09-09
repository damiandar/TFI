Public Class BLLPedido

    Dim dataProvider As DALPedido

    Public Sub New()
        dataProvider = New DALPedido
    End Sub

    Public Function MostrarPedido(ByVal PedidoID As Integer, ByVal MostrarCompleto As Boolean) As Pedido
        Dim Lista As New List(Of Pedido)
        If PedidoID > 0 Then
            Lista = dataProvider.ListarPedidos(0, PedidoID, 0)
        End If

        Dim UnPedido As New Pedido
        If Lista.Count > 0 Then
            UnPedido = Lista.First()
            If MostrarCompleto Then
                UnPedido.Items = New List(Of PedidoItem)
                UnPedido.Items = Me.ListarPedidosItem(UnPedido.ID)
            End If
        End If

        Return UnPedido
    End Function

    Public Function InsertarPedido(ByVal UnPedido As Pedido) As Integer
        Dim GestorDomicilio As New BLLDomicilioEnvio
        UnPedido.domicilioenvio = New DomicilioEnvio()
        UnPedido.domicilioenvio = GestorDomicilio.ListarDomicilios(UnPedido.cliente.ID).Last()
        Dim PedidoId As Integer = dataProvider.InsertarPedido(UnPedido)
        Return PedidoId
    End Function

    Public Sub ModificarPedido(ByVal UnPedido As Pedido)
        dataProvider.ModificarPedido(UnPedido)
    End Sub

    Public Function ListarPedido(ByVal CuentaID As Integer, ByVal PedidoID As Integer, ByVal EstadoID As Integer, ByVal MostrarCompleto As Boolean) As List(Of Pedido)
        Dim ListaPedidos As New List(Of Pedido)
        ListaPedidos = dataProvider.ListarPedidos(CuentaID, PedidoID, EstadoID)

        For Each UnPedido As Pedido In ListaPedidos
            UnPedido.Items = New List(Of PedidoItem)
            UnPedido.Items = Me.ListarPedidosItem(UnPedido.ID)
        Next

        Return ListaPedidos
    End Function

    Public Sub ModificarEstadoPedido(ByVal PedidoID As Integer)
        Dim UnPedido As New Pedido
        UnPedido = Me.MostrarPedido(PedidoID, True)

        Dim CantItems As Integer = UnPedido.Items.Count

        Dim CantAnulados As Integer = UnPedido.Items.FindAll(Function(x) x.estado = PedidoItem.EstadoItem.Anulados).Count
        Dim CantEnDistribucion As Integer = UnPedido.Items.FindAll(Function(x) x.estado = PedidoItem.EstadoItem.EnDistribucion).Count
        Dim CantEntregados As Integer = UnPedido.Items.FindAll(Function(x) x.estado = PedidoItem.EstadoItem.Entregado).Count
        Dim CantEnProceso As Integer = UnPedido.Items.FindAll(Function(x) x.estado = PedidoItem.EstadoItem.EnProceso).Count

        If CantAnulados = CantItems Then
            'Estan todos anulados
            UnPedido.EstadoPedido = Pedido.ePedidoEstado.Anulado
            Me.ModificarPedido(UnPedido)
        End If

        If CantEnDistribucion + CantAnulados = CantItems Then
            'Esta en distribucion
            UnPedido.EstadoPedido = Pedido.ePedidoEstado.EnDistribucion
            Me.ModificarPedido(UnPedido)
        End If

        If CantEntregados + CantAnulados = CantItems Then
            'Esta entregado
            UnPedido.EstadoPedido = Pedido.ePedidoEstado.Entregado
            Me.ModificarPedido(UnPedido)
        End If

        If CantEnProceso + CantEnDistribucion + CantAnulados = CantItems Then
            UnPedido.EstadoPedido = Pedido.ePedidoEstado.Confirmado
            Me.ModificarPedido(UnPedido)
        End If

    End Sub


    Public Function AsignarNroPedido(ByVal ClienteID As Integer) As Integer
        Dim NroPed As Integer = 0

        Dim oGestorPedido As New BLLPedido
        Dim ListaPedidos As List(Of Pedido) = oGestorPedido.ListarPedido(ClienteID, 0, 1, False)

        If ListaPedidos IsNot Nothing Then
            If ListaPedidos.Count > 0 Then
                NroPed = CInt(ListaPedidos.Item(0).ID)
            End If

        End If

        Return NroPed
    End Function

#Region "Items"

    Public Function ListarPedidosItem(ByVal PedidoID As Integer) As List(Of PedidoItem)
        Dim dataProviderItems As New DALPedidoItem()
        Return dataProviderItems.ListarPedidosItem(PedidoID)
    End Function

    Public Sub InsertarItemPedido(ByVal PedidoID As Integer, ByVal Item As PedidoItem)
        Try
            'If Items.Count > 0 Then
            '    For Each Item As PedidoItem In Items
            Dim dataProviderItems As New DALPedidoItem()
            dataProviderItems.InsertarPedidoItem(PedidoID, Item)
            '    Next
            'End If
        Catch ex As Exception
            Throw New Exception("Insertar Item Pedido:" & ex.Message.ToString())
        End Try

    End Sub

    Public Sub BorrarPedidoItem(ByVal PedidoId As Integer, ByVal ProductoId As Integer)
        Try
            Dim dataProviderItems As New DALPedidoItem()
            dataProviderItems.BorrarPedidoItem(PedidoId, ProductoId)
        Catch ex As Exception
            Throw New Exception("Borrar Item Pedido:" & ex.Message.ToString())
        End Try
    End Sub

    Public Sub ModificarItemPedido(ByVal PedidoID As Integer, ByVal Item As PedidoItem)
        Try
            'If Items.Count > 0 Then
            '    For Each Item As PedidoItem In Items
            Dim dataProviderItems As New DALPedidoItem()
            dataProviderItems.ModificarPedidoItem(PedidoID, Item)
            '    Next
            'End If
        Catch ex As Exception
            Throw New Exception("Modificar Item Pedido:" & ex.Message.ToString())
        End Try

    End Sub

#End Region

End Class
