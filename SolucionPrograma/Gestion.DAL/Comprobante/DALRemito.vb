Imports System.Data
Imports System.Data.SqlClient

Public Class DALRemito

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function InsertarRemito(ByVal UnRemito As Remito) As Integer

        Try
            Dim ParNumero As New SqlParameter("@remito_nro", SqlDbType.Int, 0)
            ParNumero.Value = UnRemito.Nro
            Dim ParFecha As New SqlParameter("@remito_fecha", SqlDbType.DateTime, 0)
            ParFecha.Value = UnRemito.Fecha
            Dim ParRecepciono As New SqlParameter("@remito_recepciono", SqlDbType.VarChar, 100)
            ParRecepciono.Value = UnRemito.Notas
            Dim ParFechaCarga As New SqlParameter("@remito_fechacarga", SqlDbType.DateTime, 0)
            ParFechaCarga.Value = Now.Date
            Dim ParOrden As New SqlParameter("@orden_id", SqlDbType.Int, 0)
            ParOrden.Value = UnRemito.orden.ID
            Dim ParNotas As New SqlParameter("@remito_notas", SqlDbType.VarChar, 150)
            ParNotas.Value = UnRemito.Notas
            Return Conectividad.EjecutarScalar("Remito_Insert", New SqlParameter() {ParNumero, ParFecha, ParRecepciono, ParFechaCarga, ParOrden, ParNotas})
        Catch ex As Exception
            Throw New Exception("Insertar Remito:" & ex.Message.ToString())
        End Try


    End Function

    Public Function MostrarListarRemito(ByVal Id As Integer, ByVal Nro As Integer, ByVal Proveedor_id As Integer, ByVal Orden_id As Integer) As List(Of Remito)
        Dim ParProveedor As New SqlParameter("@proveedor_id", SqlDbType.Int, 0)
        ParProveedor.Value = IIf(Proveedor_id = 0, DBNull.Value, Proveedor_id)
        Dim ParID As New SqlParameter("@remito_id", SqlDbType.Int, 0)
        ParID.Value = IIf(Id = 0, DBNull.Value, Id)
        Dim ParNro As New SqlParameter("@remito_nro", SqlDbType.Int, 0)
        ParNro.Value = IIf(Nro = 0, DBNull.Value, Nro)
        Dim ParOrdenID As New SqlParameter("@orden_id", SqlDbType.Int, 0)
        ParOrdenID.Value = IIf(Orden_id = 0, DBNull.Value, Orden_id)
        Dim dt As DataTable = Conectividad.MostrarDataTable("Remito_Show", New SqlParameter() {ParNro, ParID, ParProveedor, ParOrdenID})
        Dim ListaRemitos As New List(Of Remito)
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                ListaRemitos.Add(ConstruirObjetoConRegistro(fila))
            Next
        End If
        Return ListaRemitos
    End Function

    Public Function MostrarRemito(ByVal id As Integer) As Remito
        Dim UnRemito As New Remito

        Dim ParID As New SqlParameter("@remito_id", SqlDbType.Int, 0)
        ParID.Value = id
        Dim dt As DataTable = Conectividad.MostrarDataTable("Remito_Show", New SqlParameter() {ParID})

        If dt.Rows.Count > 0 Then
            UnRemito = ConstruirObjetoConRegistro(dt.Rows.Item(0))
            UnRemito.Items = New List(Of RemitoItem)
            Dim dataproviderItems As New DALRemitoItem
            UnRemito.Items = dataproviderItems.ListarItems(id, 0)
        End If
        Return UnRemito
    End Function

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Remito
        Dim UnRemito As New Remito

        UnRemito.Fecha = fila("remito_fecha")
        UnRemito.fechacarga = fila("remito_fechacarga")
        UnRemito.ID = CInt(fila("remito_id"))
        UnRemito.Nro = fila("remito_nro")
        UnRemito.recepciono = fila("remito_recepciono")
        UnRemito.Notas = fila("remito_notas")
        UnRemito.orden = New OrdenCompra
        UnRemito.orden.ID = fila("orden_id")

        UnRemito.orden.proveedor = New Proveedor(fila("proveedor_id"), fila("proveedor_cuit"), fila("proveedor_razonsocial"))
        UnRemito.orden.proveedor.Responsable = New ResponsabilidadFiscal(fila("tiporesponsable_id"), fila("tiporesponsable_descripcion"))
        UnRemito.orden.proveedor.Provincia = New Provincias(fila("provincia_codigo"), fila("provincia_nombre"))
        UnRemito.orden.proveedor.Domicilio = fila("proveedor_domiciliolegal")
        UnRemito.orden.proveedor.Localidad = fila("proveedor_localidad")
        Return UnRemito
    End Function

End Class
