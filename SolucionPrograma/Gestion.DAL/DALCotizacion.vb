Imports System.Data
Imports System.Data.SqlClient

Public Class DALCotizacion

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Sub IngresarCotizacion(ByVal PedidoReposicion_id As Integer, ByVal Producto_id As Integer, ByVal Cuenta_ID As Integer, ByVal PlazoEntregaDias As Integer, ByVal PlazoPagoDias As Integer, ByVal FechaHasta As DateTime, ByVal Descuento As Integer, ByVal ValorUnitario As Double, ByVal IVA_id As Integer, ByVal GarantiaDias As Integer, ByVal Estado As Integer)
        Try
            Dim ParPedido As New SqlParameter("@PedidoReposicion_id", SqlDbType.Int, 0)
            ParPedido.Value = PedidoReposicion_id
            Dim ParProducto As New SqlParameter("@Producto_id", SqlDbType.Int, 0)
            ParProducto.Value = Producto_id
            Dim ParCuenta As New SqlParameter("@Cuenta_ID", SqlDbType.Int, 0)
            ParCuenta.Value = Cuenta_ID
            Dim ParPlazoEntrega As New SqlParameter("@Cotizacion_PlazoEntregaDias", SqlDbType.Int, 0)
            ParPlazoEntrega.Value = PlazoEntregaDias
            Dim ParPlazoPagoDias As New SqlParameter("@Cotizacion_PlazoPagoDias", SqlDbType.Int, 0)
            ParPlazoPagoDias.Value = PlazoPagoDias
            Dim ParPlazoHasta As New SqlParameter("@Cotizacion_FechaHasta", SqlDbType.DateTime, 0)
            ParPlazoHasta.Value = FechaHasta
            Dim ParDescuento As New SqlParameter("@Cotizacion_Descuento", SqlDbType.Int, 0)
            ParDescuento.Value = Descuento
            Dim ParValor As New SqlParameter("@Cotizacion_ValorUnitario", SqlDbType.Decimal, 0)
            ParValor.Value = ValorUnitario
            Dim ParIva As New SqlParameter("@iva_id", SqlDbType.Int, 0)
            ParIva.Value = IVA_id
            Dim ParGarantia As New SqlParameter("@Cotizacion_GarantiaDias", SqlDbType.Int, 0)
            ParGarantia.Value = GarantiaDias
            Dim ParEstado As New SqlParameter("@Cotizacion_Estado", SqlDbType.Int, 0)
            ParEstado.Value = Estado

            Conectividad.EjecutarComando("Cotizacion_Insert", New SqlParameter() {ParPedido, ParProducto, ParCuenta, ParPlazoEntrega, ParPlazoPagoDias, ParPlazoHasta, ParDescuento, ParValor, ParIva, ParGarantia, ParEstado})

        Catch ex As Exception
            Throw New Exception("Ingresar Cotizacion: " & ex.Message.ToString())
        End Try
    End Sub

    Public Function ListarCotizacion(ByVal PedidoReposicion_id As Integer, ByVal Producto_ID As Integer, ByVal Cuenta_ID As Integer) As List(Of Cotizacion)
        Try
            Dim Lista As New List(Of Cotizacion)
            Dim ParPedido As New SqlParameter("@PedidoReposicion_id", SqlDbType.Int, 0)
            ParPedido.Value = IIf(PedidoReposicion_id = 0, DBNull.Value, PedidoReposicion_id)
            Dim ParProducto As New SqlParameter("@Producto_id", SqlDbType.Int, 0)
            ParProducto.Value = IIf(Producto_ID = 0, DBNull.Value, Producto_ID)
            Dim ParCuenta As New SqlParameter("@Cuenta_ID", SqlDbType.Int, 0)
            ParCuenta.Value = IIf(Cuenta_ID = 0, DBNull.Value, Cuenta_ID)

            Dim dt As DataTable = Conectividad.MostrarDataTable("Cotizacion_Show", New SqlParameter() {ParPedido, ParProducto, ParCuenta})
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    For Each fila As DataRow In dt.Rows
                        Lista.Add(ConstruirObjetoConRegistro(fila))
                    Next
                End If
            End If
            Return Lista
        Catch ex As Exception
            Throw New Exception("Listar Cotizacion: " & ex.Message.ToString())
        End Try
    End Function

    'Public Sub InsertarItemCoti(ByVal id As Integer, ByVal UnComprobante As Cotizacion)
    '    Try
    '        '    Dim ParID As New SqlParameter("@comprobante_id", SqlDbType.Int, 0)
    '        '    ParID.Value = id
    '        '    Dim ParProducto As New SqlParameter("@producto_id", SqlDbType.Int, 0)
    '        '    ParProducto.Value = UnComprobante.
    '        '    Dim ParCantidad As New SqlParameter("@comprobanteitem_cantidad", SqlDbType.Int, 0)
    '        '    ParCantidad.Value = UnComprobante.cantidad
    '        '    Dim ParCantidadFacturada As New SqlParameter("@comprobanteitem_cantidadfacturada", SqlDbType.Int, 0)
    '        '    ParCantidadFacturada.Value = UnComprobante.cantidad
    '        '    Dim ParIva As New SqlParameter("@iva_id", SqlDbType.Int, 0)
    '        '    ParIva.Value = UnComprobante.iva.ID
    '        '    Dim ParPrecio As New SqlParameter("@comprobanteitem_preciounitario", SqlDbType.Int, 0)
    '        '    ParPrecio.Value = UnComprobante.precio

    '        '    Conectividad.EjecutarComando("ComprobanteItem_Insert", New SqlParameter() {ParProducto, ParCantidad, ParCantidadFacturada, ParIva, ParPrecio, ParID})
    '    Catch ex As Exception
    '        Throw New Exception("Insertar Comprobante:" & ex.Message.ToString())
    '    End Try


    'End Sub

#Region "Metodos Privados"

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Cotizacion
        Dim UnaCotizacion As New Cotizacion
        UnaCotizacion.estado = fila("Cotizacion_Estado")
        UnaCotizacion.fecha = fila("Cotizacion_fechahasta")
        UnaCotizacion.plazoentrega = fila("Cotizacion_PlazoEntregaDias")
        UnaCotizacion.plazopago = fila("Cotizacion_PlazoPagoDias")
        UnaCotizacion.valor = fila("Cotizacion_valorunitario")
        UnaCotizacion.iva = New IVA(fila("iva_id"), fila("iva_descripcion"), fila("iva_multiplicador"))
        UnaCotizacion.proveedor = New Proveedor
        UnaCotizacion.proveedor.Razon = fila("proveedor_razonsocial")
        UnaCotizacion.proveedor.ID = fila("proveedor_id")
        Return UnaCotizacion
    End Function

#End Region

End Class
