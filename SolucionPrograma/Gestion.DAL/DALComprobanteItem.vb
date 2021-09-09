Imports System.Data
Imports System.Data.SqlClient


Public Class DALComprobanteItem

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

#Region "CRUD"


    Public Sub ModificarComprobanteItem(ByVal Id As Integer, ByVal UnComprobante As ComprobanteItem)
        Try
            '    Dim ParID As New SqlParameter("@comprobante_id", SqlDbType.Int, 0)
            '    ParID.Value = Id
            '    Dim ParProducto As New SqlParameter("@producto_id", SqlDbType.Int, 0)
            '    ParProducto.Value = UnComprobante.catalogo.ID
            '    Dim ParCantidad As New SqlParameter("@comprobanteitem_cantidad", SqlDbType.Int, 0)
            '    ParCantidad.Value = UnComprobante.cantidad
            '    Dim ParCantidadFacturada As New SqlParameter("@comprobanteitem_cantidadfacturada", SqlDbType.Int, 0)
            '    ParCantidadFacturada.Value = UnComprobante.CantidadFacturada
            '    Dim ParIva As New SqlParameter("@iva_id", SqlDbType.Int, 0)
            '    ParIva.Value = UnComprobante.iva.ID
            '    Dim ParPrecio As New SqlParameter("@comprobanteitem_preciounitario", SqlDbType.Int, 0)
            '    ParPrecio.Value = UnComprobante.precio

            '    Conectividad.EjecutarComando("ComprobanteItem_Update", New SqlParameter() {ParProducto, ParCantidad, ParCantidadFacturada, ParIva, ParPrecio, ParID})
        Catch ex As Exception
            Throw New Exception("Modificar Comprobante:" & ex.Message.ToString())
        End Try
    End Sub

    'Public Sub InsertarComprobanteItem(ByVal Id As Integer, ByVal UnComprobante As ComprobanteItem)
    '    Try
    '        Dim ParID As New SqlParameter("@comprobante_id", SqlDbType.Int, 0)
    '        ParID.Value = Id
    '        Dim ParProducto As New SqlParameter("@producto_id", SqlDbType.Int, 0)
    '        ParProducto.Value = UnComprobante.catalogo.ID
    '        Dim ParCantidad As New SqlParameter("@comprobanteitem_cantidad", SqlDbType.Int, 0)
    '        ParCantidad.Value = UnComprobante.cantidad
    '        Dim ParCantidadFacturada As New SqlParameter("@comprobanteitem_cantidadfacturada", SqlDbType.Int, 0)
    '        ParCantidadFacturada.Value = UnComprobante.CantidadFacturada
    '        Dim ParIva As New SqlParameter("@iva_id", SqlDbType.Int, 0)
    '        ParIva.Value = UnComprobante.iva.ID
    '        Dim ParPrecio As New SqlParameter("@comprobanteitem_preciounitario", SqlDbType.Int, 0)
    '        ParPrecio.Value = UnComprobante.precio

    '        Conectividad.EjecutarComando("ComprobanteItem_Insert", New SqlParameter() {ParProducto, ParCantidad, ParCantidadFacturada, ParIva, ParPrecio, ParID})
    '    Catch ex As Exception
    '        Throw New Exception("Insertar Comprobante:" & ex.Message.ToString())
    '    End Try
    'End Sub

    Public Function ListarComprobanteItem(ByVal ComprobanteID As Integer, ByVal Producto_id As Integer) As List(Of ComprobanteItem)
        Try
            Dim Lista As New List(Of ComprobanteItem)
            Dim ParID As New SqlParameter("@comprobante_id", SqlDbType.Int, 0)
            ParID.Value = IIf(ComprobanteID = 0, DBNull.Value, ComprobanteID)
            Dim ParProductoID As New SqlParameter("@producto_id", SqlDbType.Int, 0)
            ParProductoID.Value = IIf(Producto_id = 0, DBNull.Value, Producto_id)
            Dim dt As DataTable = Conectividad.MostrarDataTable("ComprobanteItem_Show", New SqlParameter() {ParID, ParProductoID})
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    For Each fila As DataRow In dt.Rows
                        Lista.Add(ConstruirObjetoConRegistro(fila))
                    Next
                End If
            End If
            Return Lista
        Catch ex As Exception
            Throw New Exception("Listar comprobante item: " & ex.Message.ToString())
        End Try
    End Function

#End Region

    Public Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As ComprobanteItem
        Dim UnComprobante As New ComprobanteItem
        'Dim ParID As New fila("comprobante_id", SqlDbType.Int, 0)

        'UnComprobante.catalogo = New Catalogo
        UnComprobante.cantidad = fila("comprobanteitem_cantidad")
        UnComprobante.CantidadFacturada = fila("comprobanteitem_cantidadfacturada")
        UnComprobante.iva = New IVA(fila("iva_id"), fila("iva_descripcion"), fila("iva_multiplicador"))
        UnComprobante.precio = fila("comprobanteitem_preciounitario")
        Return UnComprobante
    End Function


End Class
