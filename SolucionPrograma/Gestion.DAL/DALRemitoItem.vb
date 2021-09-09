Imports System.Data
Imports System.Data.SqlClient


Public Class DALRemitoItem

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

#Region "CRUD"

    Public Sub Modificar(ByVal Id As Integer, ByVal UnComprobante As RemitoItem)
        Try
            Dim ParID As New SqlParameter("@comprobante_id", SqlDbType.Int, 0)
            ParID.Value = Id
            Dim ParProducto As New SqlParameter("@producto_id", SqlDbType.Int, 0)
            ParProducto.Value = UnComprobante.insumo.ID
            Dim ParCantidad As New SqlParameter("@comprobanteitem_cantidad", SqlDbType.Int, 0)
            ParCantidad.Value = UnComprobante.cantidad
            Dim ParCantidadFacturada As New SqlParameter("@comprobanteitem_cantidadfacturada", SqlDbType.Int, 0)
            ParCantidadFacturada.Value = UnComprobante.cantidad
            Dim ParIva As New SqlParameter("@iva_id", SqlDbType.Int, 0)
            ParIva.Value = UnComprobante.insumo.precio.iva.ID
            Dim ParPrecio As New SqlParameter("@comprobanteitem_preciounitario", SqlDbType.Int, 0)
            ParPrecio.Value = UnComprobante.insumo.precio.ValorUnitario

            Conectividad.EjecutarComando("ComprobanteItem_Update", New SqlParameter() {ParProducto, ParCantidad, ParCantidadFacturada, ParIva, ParPrecio, ParID})
        Catch ex As Exception
            Throw New Exception("Modificar Comprobante:" & ex.Message.ToString())
        End Try
    End Sub

    Public Sub Insertar(ByVal Id As Integer, ByVal UnItem As RemitoItem)
        Try
            Dim ParID As New SqlParameter("@remito_id", SqlDbType.Int, 0)
            ParID.Value = Id
            Dim ParInsumo As New SqlParameter("@insumo_id", SqlDbType.Int, 0)
            ParInsumo.Value = UnItem.insumo.ID
            Dim ParCantidad As New SqlParameter("@remitoitem_cantidad", SqlDbType.Int, 0)
            ParCantidad.Value = UnItem.cantidad

            Conectividad.EjecutarComando("RemitoItem_Insert", New SqlParameter() {ParInsumo, ParCantidad, ParID})
        Catch ex As Exception
            Throw New Exception("Insertar Comprobante:" & ex.Message.ToString())
        End Try
    End Sub

    Public Function ListarItems(ByVal RemitoID As Integer, ByVal Insumo_id As Integer) As List(Of RemitoItem)
        Try
            Dim Lista As New List(Of RemitoItem)
            Dim ParID As New SqlParameter("@remito_id", SqlDbType.Int, 0)
            ParID.Value = IIf(RemitoID = 0, DBNull.Value, RemitoID)
            Dim ParInsumoID As New SqlParameter("@insumo_id", SqlDbType.Int, 0)
            ParInsumoID.Value = IIf(Insumo_id = 0, DBNull.Value, Insumo_id)

            Dim dt As DataTable = Conectividad.MostrarDataTable("RemitoItem_Show", New SqlParameter() {ParID, ParInsumoID})
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    For Each fila As DataRow In dt.Rows
                        Lista.Add(ConstruirObjetoConRegistro(fila))
                    Next
                End If
            End If
            Return Lista
        Catch ex As Exception
            Throw New Exception("Listar remito item: " & ex.Message.ToString())
        End Try
    End Function

#End Region

    Public Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As RemitoItem
        Dim UnRemitoItem As New RemitoItem
        'Dim ParID As New fila("comprobante_id", SqlDbType.Int, 0)

        UnRemitoItem.insumo = New Insumo
        UnRemitoItem.insumo.ID = fila("insumo_id")
        UnRemitoItem.insumo.NombreCorto = fila("insumo_nombrecorto")
        UnRemitoItem.insumo.NombreLargo = fila("insumo_nombrelargo")
        UnRemitoItem.insumo.precio = New Precio()

        UnRemitoItem.cantidad = fila("remitoitem_cantidad")
        Return UnRemitoItem
    End Function


End Class
