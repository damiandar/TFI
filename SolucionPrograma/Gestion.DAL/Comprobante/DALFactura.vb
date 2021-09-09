Imports System.Data
Imports System.Data.SqlClient

Public Class DALFactura
    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function ListarFacturas(ByVal Id As Integer, ByVal CuentaID As Integer) As List(Of FacturaVenta)
        Dim Lista As New List(Of FacturaVenta)
        Dim ParID As New SqlParameter("@Factura_id", SqlDbType.Int, 0)
        ParID.Value = IIf(Id = 0, DBNull.Value, Id)
        Dim ParCuenta As New SqlParameter("@Cuenta_id", SqlDbType.Int, 0)
        ParCuenta.Value = IIf(CuentaID = 0, DBNull.Value, CuentaID)

        Dim dt As DataTable = Conectividad.MostrarDataTable("Factura_Show", New SqlParameter() {ParID, ParCuenta})
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                Dim UnaFactura As FacturaVenta = ConstruirObjetoConRegistro(fila)
                UnaFactura.Items = New List(Of FacturaVentaItem)
                UnaFactura.Items = ListarFacturaItem(UnaFactura.ID, 0)
                Lista.Add(UnaFactura)
            Next
        End If
        Return Lista
    End Function

    Public Function InsertarFactura(ByVal UnaFactura As FacturaVenta) As Integer
        Try
            Dim ID As Integer = 0
            'Dim ParFecha As New SqlParameter("@factura_fecha", SqlDbType.DateTime, 0)
            'ParFecha.Value = UnaFactura.Fecha
            'Dim ParNro As New SqlParameter("@factura_nro", SqlDbType.Int, 0)
            'ParNro.Value = 0
            Dim ParPtoVenta As New SqlParameter("@factura_ptoventa", SqlDbType.Int, 0)
            ParPtoVenta.Value = UnaFactura.PtoVenta
            Dim ParLetra As New SqlParameter("@factura_letra", SqlDbType.Char, 3)
            ParLetra.Value = UnaFactura.Letra
            'Dim ParCAI As New SqlParameter("@factura_CAI", SqlDbType.VarChar, 20)
            'ParCAI.Value = UnaFactura.CAI
            'Dim ParCAE As New SqlParameter("@factura_CAE", SqlDbType.VarChar, 20)
            'ParCAE.Value = UnaFactura.CAE
            Dim ParPedido As New SqlParameter("@Pedido_id", SqlDbType.Int, 0)
            ParPedido.Value = UnaFactura.PedidoID
            ID = Conectividad.EjecutarScalar("Factura_Insert", New SqlParameter() {ParPtoVenta, ParLetra, ParPedido})
            Return ID
        Catch ex As Exception
            Throw New Exception("Insertar Factura:" & ex.Message.ToString())
        End Try
    End Function

    Public Sub InsertarItem(ByVal id As Integer, ByVal UnComprobante As FacturaVentaItem)
        Try
            Dim ParID As New SqlParameter("@Factura_id", SqlDbType.Int, 0)
            ParID.Value = id
            Dim ParProducto As New SqlParameter("@producto_id", SqlDbType.Int, 0)
            ParProducto.Value = UnComprobante.producto.ID
            Dim ParPrecio As New SqlParameter("@precio", SqlDbType.Decimal, 0)
            ParPrecio.Value = UnComprobante.precio
            Dim ParCantidad As New SqlParameter("@cantidad", SqlDbType.Int, 0)
            ParCantidad.Value = UnComprobante.cantidad
            Conectividad.EjecutarComando("FacturaItem_Insert", New SqlParameter() {ParProducto, ParPrecio, ParID, ParCantidad})
        Catch ex As Exception
            Throw New Exception("Insertar factura item:" & ex.Message.ToString())
        End Try
    End Sub


    Public Function ListarFacturaItem(ByVal FacturaID As Integer, ByVal Producto_id As Integer) As List(Of FacturaVentaItem)
        Try
            Dim Lista As New List(Of FacturaVentaItem)

            Dim ParID As New SqlParameter("@factura_id", SqlDbType.Int, 0)
            ParID.Value = IIf(FacturaID = 0, DBNull.Value, FacturaID)
            Dim ParProductoID As New SqlParameter("@producto_id", SqlDbType.Int, 0)
            ParProductoID.Value = IIf(Producto_id = 0, DBNull.Value, Producto_id)

            Dim dt As DataTable = Conectividad.MostrarDataTable("FacturaItem_Show", New SqlParameter() {ParID, ParProductoID})
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    For Each fila As DataRow In dt.Rows
                        Lista.Add(ConstruirObjetoConRegistroItem(fila))
                    Next
                End If
            End If
            Return Lista
        Catch ex As Exception
            Throw New Exception("Listar factura item: " & ex.Message.ToString())
        End Try
    End Function

    '        If UnComprobante.Items IsNot Nothing Then
    'Dim ComprobanteItems As New DALComprobanteItem
    '        For Each UnItem As ComprobanteItem In UnComprobante.Items
    '            ComprobanteItems.InsertarComprobanteItem(IdComprobante, UnItem)
    '        Next
    '    End If

#Region "Metodos Privados"

    Private Function ConstruirObjetoConRegistroItem(ByVal fila As DataRow) As FacturaVentaItem
        Dim UnItem As New FacturaVentaItem
        UnItem.cantidad = fila("facturaitem_cantidad")
        UnItem.precio = fila("facturaitem_precio")
        UnItem.producto = New Productos(fila("producto_id"), fila("producto_nombrecorto"), fila("producto_nombrelargo"))
        Return UnItem
    End Function

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As FacturaVenta
        Dim UnComprobante As New FacturaVenta
        UnComprobante.cliente = New Cliente(fila("cuenta_id"), fila("cuenta_cuit"), fila("cuenta_razonsocial"))
        UnComprobante.ID = fila("Factura_id")
        UnComprobante.Nro = fila("Factura_nro")
        UnComprobante.PtoVenta = fila("Factura_ptoventa")
        ' UnComprobante.Letra = fila("Factura_letra").ToString()
        UnComprobante.Fecha = fila("Factura_fecha")
        UnComprobante.CAE = fila("factura_CAE")
        UnComprobante.CAI = fila("factura_CAI")
        UnComprobante.PedidoID = fila("pedido_id")
        Return UnComprobante
    End Function

#End Region

End Class
