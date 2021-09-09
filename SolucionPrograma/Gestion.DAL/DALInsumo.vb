Imports System.Data
Imports System.Data.SqlClient

Public Class DALInsumo

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function InsertarInsumo(ByVal UnInsumo As Insumo) As Integer
        Try
            Dim ParID As New SqlParameter("@Insumo_id", SqlDbType.Int, 0)
            ParID.Value = UnInsumo.ID
            Dim ParDescripcion As New SqlParameter("@insumo_descripcion", SqlDbType.VarChar, 150)
            ParDescripcion.Value = UnInsumo.Descripcion
            Dim ParNombreCorto As New SqlParameter("@insumo_nombrecorto", SqlDbType.VarChar, 150)
            ParNombreCorto.Value = UnInsumo.NombreCorto
            Dim ParNombreLargo As New SqlParameter("@insumo_nombrelargo", SqlDbType.VarChar, 50)
            ParNombreLargo.Value = UnInsumo.NombreLargo
            Dim ParEstado As New SqlParameter("@insumo_estado", SqlDbType.Bit, 0)
            ParEstado.Value = UnInsumo.SubCategoriaID
            Dim Parcategoria As New SqlParameter("@subcategoria_id", SqlDbType.Int, 0)
            Parcategoria.Value = UnInsumo.SubCategoriaID
            Dim ParStockMin As New SqlParameter("@insumo_StockMin", SqlDbType.Int, 0)
            ParStockMin.Value = UnInsumo.stock.Minimo
            Dim ParStockMax As New SqlParameter("@insumo_StockMax", SqlDbType.Int, 0)
            ParStockMax.Value = UnInsumo.stock.Maximo
            Dim ParStockActual As New SqlParameter("@insumo_StockActual", SqlDbType.Int, 0)
            ParStockActual.Value = UnInsumo.stock.Actual
            Return Conectividad.EjecutarScalar("Insumo_Insert", New SqlParameter() {ParStockMax, ParStockMin, ParStockActual, ParDescripcion, ParEstado, Parcategoria, ParNombreCorto, ParNombreLargo})

        Catch ex As Exception
            Throw New Exception("Insertar producto:" & ex.Message.ToString())
        End Try
    End Function

    Public Function ListarInsumos(ByVal InsumoID As Integer, ByVal CategoriaID As Integer) As List(Of Insumo)
        Dim ListaProductos As New List(Of Insumo)
        Dim ParInsumo As New SqlParameter("@Insumo_id", SqlDbType.Int, 0)
        ParInsumo.Value = IIf(InsumoID = 0, DBNull.Value, InsumoID)
        Dim ParCategoriaID As New SqlParameter("@subcategoria_id", SqlDbType.Int, 0)
        ParCategoriaID.Value = IIf(CategoriaID = 0, DBNull.Value, CategoriaID)
        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("Insumo_Show", New SqlParameter() {ParInsumo, ParCategoriaID})
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                ListaProductos.Add(ConstruirObjetoConRegistro(fila))
            Next
        End If
        Return ListaProductos
    End Function

    Public Sub ActualizarInsumo(ByVal UnInsumo As Insumo)
        Try
            Dim ParID As New SqlParameter("@Insumo_id", SqlDbType.Int, 0)
            ParID.Value = UnInsumo.ID
            Dim ParDescripcion As New SqlParameter("@insumo_descripcion", SqlDbType.VarChar, 150)
            ParDescripcion.Value = UnInsumo.Descripcion
            Dim ParNombreCorto As New SqlParameter("@insumo_nombrecorto", SqlDbType.VarChar, 150)
            ParNombreCorto.Value = UnInsumo.NombreCorto
            Dim ParNombreLargo As New SqlParameter("@insumo_nombrelargo", SqlDbType.VarChar, 50)
            ParNombreLargo.Value = UnInsumo.NombreLargo
            Dim ParEstado As New SqlParameter("@insumo_estado", SqlDbType.Bit, 0)
            ParEstado.Value = UnInsumo.Estado
            Dim Parcategoria As New SqlParameter("@subcategoria_id", SqlDbType.Int, 0)
            Parcategoria.Value = UnInsumo.SubCategoriaID
            Dim ParStockMin As New SqlParameter("@insumo_StockMin", SqlDbType.Int, 0)
            ParStockMin.Value = UnInsumo.stock.Minimo
            Dim ParStockMax As New SqlParameter("@insumo_StockMax", SqlDbType.Int, 0)
            ParStockMax.Value = UnInsumo.stock.Maximo
            Dim ParStockActual As New SqlParameter("@insumo_StockActual", SqlDbType.Int, 0)
            ParStockActual.Value = UnInsumo.stock.Actual
            Conectividad.EjecutarComando("Insumo_Update", New SqlParameter() {ParID, ParStockMax, ParStockMin, ParStockActual, ParDescripcion, ParEstado, Parcategoria, ParNombreCorto, ParNombreLargo})
        Catch ex As Exception
            Throw New Exception("Actualizar Insumo: " & ex.Message.ToString())
        End Try
    End Sub

#Region "Metodos privados"

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Insumo
        Dim UnInsumo As New Insumo
        UnInsumo.ID = fila("Insumo_id")  

        UnInsumo.Estado = CBool(fila("insumo_estado"))
        UnInsumo.Descripcion = fila("insumo_descripcion").ToString().Trim()
        UnInsumo.NombreLargo = fila("insumo_nombrelargo").ToString().Trim()
        UnInsumo.NombreCorto = fila("insumo_nombrecorto").ToString().Trim()
        UnInsumo.Estado = CBool(fila("insumo_estado"))

        UnInsumo.stock = New Stock()
        UnInsumo.stock.Actual = fila("insumo_stockactual")
        UnInsumo.stock.Minimo = fila("insumo_stockmin")
        UnInsumo.stock.Maximo = fila("insumo_stockmax")
        'UnInsumo.stock.UltimoMovimiento = fila("stock_ultimomovimiento")
        UnInsumo.SubCategoriaID = fila("subcategoria_id")
        UnInsumo.CategoriaID = fila("categoria_id")
        Return UnInsumo
    End Function

#End Region

End Class
