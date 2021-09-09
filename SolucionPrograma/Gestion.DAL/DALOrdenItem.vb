Imports System.Data
Imports System.Data.SqlClient


Public Class DALOrdenItem

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

#Region "CRUD"


    Public Sub ModificarItemCompra(ByVal Id As Integer, ByVal UnItemCompra As OrdenCompraItem)
        Try
            Dim ParID As New SqlParameter("@orden_id", SqlDbType.Int, 0)
            ParID.Value = Id
            Dim ParProducto As New SqlParameter("@insumo_id", SqlDbType.Int, 0)
            ParProducto.Value = UnItemCompra.insumo.ID
            Dim ParCantidad As New SqlParameter("@itemorden_cantidadpedida", SqlDbType.Int, 0)
            ParCantidad.Value = UnItemCompra.cantidad
            Dim ParCantidadFacturada As New SqlParameter("@itemorden_cantidadfacturada", SqlDbType.Int, 0)
            ParCantidadFacturada.Value = 0
            Dim ParCantidadEntregada As New SqlParameter("@itemorden_cantidadEntregada", SqlDbType.Int, 0)
            ParCantidadEntregada.Value = UnItemCompra.CantidadEntregada
            Dim ParIva As New SqlParameter("@iva_id", SqlDbType.Int, 0)
            ParIva.Value = UnItemCompra.iva.ID
            Dim ParPrecio As New SqlParameter("@itemorden_preciounitario", SqlDbType.Int, 0)
            ParPrecio.Value = UnItemCompra.precio
            Dim ParEstado As New SqlParameter("@estadoordenitem_id", SqlDbType.Int, 0)
            ParEstado.Value = UnItemCompra.Estado
            Conectividad.EjecutarComando("OrdenItem_Update", New SqlParameter() {ParEstado, ParCantidadEntregada, ParProducto, ParCantidad, ParCantidadFacturada, ParIva, ParPrecio, ParID})
        Catch ex As Exception
            Throw New Exception("Modificar item orden:" & ex.Message.ToString())
        End Try
    End Sub

    Public Sub InsertarItem(ByVal Id As Integer, ByVal UnItemCompra As OrdenCompraItem)
        Try
            Dim ParID As New SqlParameter("@orden_id", SqlDbType.Int, 0)
            ParID.Value = Id
            Dim ParProducto As New SqlParameter("@insumo_id", SqlDbType.Int, 0)
            ParProducto.Value = UnItemCompra.insumo.ID
            Dim ParCantidad As New SqlParameter("@itemorden_cantidadpedida", SqlDbType.Int, 0)
            ParCantidad.Value = UnItemCompra.cantidad
            Dim ParCantidadFacturada As New SqlParameter("@itemorden_cantidadfacturada", SqlDbType.Int, 0)
            ParCantidadFacturada.Value = 0
            Dim ParCantidadEntregada As New SqlParameter("@itemorden_cantidadEntregada", SqlDbType.Int, 0)
            ParCantidadEntregada.Value = 0
            Dim ParIva As New SqlParameter("@iva_id", SqlDbType.Int, 0)
            ParIva.Value = UnItemCompra.iva.ID
            Dim ParPrecio As New SqlParameter("@itemorden_preciounitario", SqlDbType.Int, 0)
            ParPrecio.Value = UnItemCompra.precio

            Conectividad.EjecutarComando("OrdenItem_Insert", New SqlParameter() {ParCantidadEntregada, ParProducto, ParCantidad, ParCantidadFacturada, ParIva, ParPrecio, ParID})
        Catch ex As Exception
            Throw New Exception("Insertar item orden:" & ex.Message.ToString())
        End Try
    End Sub

    Public Function ListarItemOrden(ByVal ComprobanteID As Integer, ByVal Insumo_id As Integer) As List(Of OrdenCompraItem)
        Try
            Dim Lista As New List(Of OrdenCompraItem)
            Dim ParID As New SqlParameter("@orden_id", SqlDbType.Int, 0)
            ParID.Value = IIf(ComprobanteID = 0, DBNull.Value, ComprobanteID)
            Dim ParProductoID As New SqlParameter("@insumo_id", SqlDbType.Int, 0)
            ParProductoID.Value = IIf(Insumo_id = 0, DBNull.Value, Insumo_id)
            Dim dt As DataTable = Conectividad.MostrarDataTable("OrdenItem_Show", New SqlParameter() {ParID, ParProductoID})
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    For Each fila As DataRow In dt.Rows
                        Lista.Add(ConstruirObjetoConRegistro(fila))
                    Next
                End If
            End If
            Return Lista
        Catch ex As Exception
            Throw New Exception("Listar orden item: " & ex.Message.ToString())
        End Try
    End Function

#End Region

    Public Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As OrdenCompraItem
        Dim UnaOrdenItem As New OrdenCompraItem
        'Dim ParID As New fila("comprobante_id", SqlDbType.Int, 0)

        UnaOrdenItem.insumo = New Insumo(fila("insumo_id"), fila("insumo_nombrecorto"), fila("insumo_nombrelargo"), fila("insumo_descripcion"))
        UnaOrdenItem.cantidad = fila("itemorden_cantidadpedida")
        UnaOrdenItem.CantidadEntregada = fila("itemorden_cantidadEntregada")
        UnaOrdenItem.iva = New IVA(fila("iva_id"), fila("iva_descripcion"), fila("iva_multiplicador"))
        UnaOrdenItem.precio = fila("itemorden_preciounitario")
        Return UnaOrdenItem
    End Function


End Class
