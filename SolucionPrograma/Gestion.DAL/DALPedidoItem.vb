Imports System.Data
Imports System.Data.SqlClient

Public Class DALPedidoItem

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Sub InsertarPedidoItem(ByVal PedidoId As Integer, ByVal UnPedido As PedidoItem)
        Try
            Dim ParPedido As New SqlParameter("@pedido_id", SqlDbType.Int, 0)
            ParPedido.Value = PedidoId
            Dim ParProducto As New SqlParameter("@producto_id", SqlDbType.Int, 0)
            ParProducto.Value = UnPedido.producto.ID
            Dim ParCantidad As New SqlParameter("@pedidoitem_cantidad", SqlDbType.Int, 0)
            ParCantidad.Value = UnPedido.cantidad
            Conectividad.EjecutarComando("PedidoItem_Insert", New SqlParameter() {ParProducto, ParCantidad, ParPedido})
        Catch ex As DALExceptionPK
            Throw ex
        Catch ex As Exception
            Throw New Exception("Insertar pedido item:" & ex.Message.ToString())
        End Try
    End Sub


    Public Sub BorrarPedidoItem(ByVal PedidoId As Integer, ByVal ProductoId As Integer)
        Try
            Dim ParPedido As New SqlParameter("@pedido_id", SqlDbType.Int, 0)
            ParPedido.Value = PedidoId
            Dim ParProducto As New SqlParameter("@producto_id", SqlDbType.Int, 0)
            ParProducto.Value = ProductoId
            Conectividad.EjecutarComando("PedidoItem_Delete", New SqlParameter() {ParProducto, ParPedido})
        Catch ex As DALExceptionPK
            Throw ex
        Catch ex As Exception
            Throw New Exception("Borrar pedido item:" & ex.Message.ToString())
        End Try
    End Sub

    Public Sub ModificarPedidoItem(ByVal PedidoId As Integer, ByVal UnPedido As PedidoItem)
        Try
            Dim ParPedido As New SqlParameter("@pedido_id", SqlDbType.Int, 0)
            ParPedido.Value = PedidoId
            Dim ParProducto As New SqlParameter("@producto_id", SqlDbType.Int, 0)
            ParProducto.Value = UnPedido.producto.ID
            Dim ParCantidad As New SqlParameter("@pedidoitem_cantidad", SqlDbType.Int, 0)
            ParCantidad.Value = UnPedido.cantidad
            Dim ParEstadoItem As New SqlParameter("@estadoitempedido_id", SqlDbType.Int, 0)
            ParEstadoItem.Value = UnPedido.estado
            Conectividad.EjecutarComando("PedidoItem_Update", New SqlParameter() {ParProducto, ParCantidad, ParPedido, ParEstadoItem})
        Catch ex As DALExceptionPK
            Throw ex
        Catch ex As Exception
            Throw New Exception("Modificar pedido item:" & ex.Message.ToString())
        End Try
    End Sub

    Public Function ListarPedidosItem(ByVal PedidoID As Integer) As List(Of PedidoItem)
        Try
            Dim lista As New List(Of PedidoItem)
            Dim ParPedido As New SqlParameter("@pedido_id", SqlDbType.Int, 0)
            ParPedido.Value = PedidoID
            Dim dt As DataTable = Conectividad.MostrarDataTable("PedidoItem_Show", New SqlParameter() {ParPedido})
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    For Each fila As DataRow In dt.Rows

                        lista.Add(ConstruirObjetoConRegistro(fila))
                    Next
                End If
            End If
            Return lista
        Catch ex As Exception
            Throw New Exception("Listar Pedido item: " & ex.Message.ToString())
        End Try
    End Function

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As PedidoItem
        Dim UnItem As New PedidoItem

        UnItem.producto = New Productos()
        UnItem.producto.ID = fila("producto_id")
        UnItem.producto.NombreCorto = fila("producto_nombrecorto")
        UnItem.producto.NombreLargo = fila("producto_nombrelargo")
        UnItem.producto.Descripcion = fila("producto_descripcion")
        'UnItem.producto.Estado = fila("catalogo_estado")
        'UnItem.producto.SubCategoriaID = fila("subcategoria_id")
        UnItem.cantidad = CInt(fila("PedidoItem_cantidad"))
        UnItem.producto.Imagen = fila("imagedata")
        UnItem.producto.CodigoInterno = fila("producto_codigointerno")
        UnItem.producto.TiempoEntrega = IIf(fila("producto_tiempoentrega") Is DBNull.Value, 0, fila("producto_tiempoentrega"))
        UnItem.producto.Destacado = IIf(fila("producto_destacado") Is DBNull.Value, False, fila("producto_destacado"))
        If fila("productoprecio_valor") IsNot DBNull.Value Then
            UnItem.producto.precio = New Precio(CDbl(fila("productoprecio_valor")), New IVA(fila("iva_id"), fila("iva_descripcion"), fila("iva_multiplicador")))
        End If
        UnItem.estado = fila("estadoitempedido_id")
        UnItem.cantidad = fila("pedidoitem_cantidad")
        Return UnItem
    End Function

End Class
