Imports System.Data
Imports System.Data.SqlClient

Public Class DALOrdenCompra

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub


    Public Function InsertarOrden(ByVal UnaOrden As OrdenCompra) As Integer
        Try
            Dim ParNotas As New SqlParameter("@orden_notas", SqlDbType.VarChar, 50)
            ParNotas.Value = UnaOrden.Notas
            Dim ParEstado As New SqlParameter("@orden_estado", SqlDbType.Int, 0)
            ParEstado.Value = UnaOrden.Estado_id
            Dim ParFecha As New SqlParameter("@orden_fechacarga", SqlDbType.DateTime, 0)
            ParFecha.Value = UnaOrden.Fecha
            Dim ParCuenta As New SqlParameter("@proveedor_id", SqlDbType.Int, 0)
            ParCuenta.Value = UnaOrden.proveedor.ID
            Dim ParPedido As New SqlParameter("@pedidoreposicion_id", SqlDbType.Int, 0)
            ParPedido.Value = UnaOrden.reposicion.ID
            Return Conectividad.EjecutarScalar("Orden_Insert", New SqlParameter() {ParFecha, ParCuenta, ParNotas, ParEstado, ParPedido})
        Catch ex As Exception
            Throw New Exception("Insertar Orden:" & ex.Message.ToString())
        End Try
    End Function

    Public Function ListarOrdenes(ByVal ProveedorID As Integer, ByVal ID As Integer, ByVal PedidoReposicionID As Integer) As List(Of OrdenCompra)
        Dim ParCuenta As New SqlParameter("@proveedor_id", SqlDbType.Int, 0)
        ParCuenta.Value = IIf(ProveedorID = 0, DBNull.Value, ProveedorID)
        Dim ParID As New SqlParameter("@orden_id", SqlDbType.Int, 0)
        ParID.Value = IIf(ID = 0, DBNull.Value, ID)
        Dim ParReposicion As New SqlParameter("@pedidoreposicion_id", SqlDbType.Int, 0)
        ParReposicion.Value = IIf(PedidoReposicionID = 0, DBNull.Value, PedidoReposicionID)

        Dim ListaComprobantes As New List(Of OrdenCompra)
        Dim dt As DataTable = Conectividad.MostrarDataTable("Orden_Show", New SqlParameter() {ParCuenta, ParID, ParReposicion})
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                ListaComprobantes.Add(ConstruirObjetoConRegistro(fila))
            Next
        End If
        Return ListaComprobantes
    End Function

#Region "Metodos Privados"

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As OrdenCompra
        Dim UnaOrden As New OrdenCompra
        UnaOrden.ID = fila("orden_id")
        UnaOrden.Fecha = fila("orden_fechacarga")

        UnaOrden.proveedor = New Proveedor(fila("proveedor_id"), fila("proveedor_cuit"), fila("proveedor_razonsocial"))
        UnaOrden.proveedor.Responsable = New ResponsabilidadFiscal(fila("tiporesponsable_id"), fila("tiporesponsable_descripcion"))
        UnaOrden.proveedor.Provincia = New Provincias(fila("provincia_codigo"), fila("provincia_nombre"))
        UnaOrden.proveedor.Domicilio = fila("proveedor_domiciliolegal")
        UnaOrden.proveedor.Localidad = fila("proveedor_localidad")
        Return UnaOrden
    End Function

#End Region

End Class
