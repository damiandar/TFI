Imports System.Data
Imports System.Data.SqlClient

Public Class DALServicio

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Sub InsertarServicio(ByVal UnServicio As Servicio)
        Try
            Dim ParNombreCorto As New SqlParameter("@servicio_NombreCorto", SqlDbType.VarChar, 150)
            ParNombreCorto.Value = UnServicio.NombreCorto
            Dim ParNombreLargo As New SqlParameter("@servicio_NombreLargo", SqlDbType.VarChar, 150)
            ParNombreLargo.Value = UnServicio.NombreLargo
            Dim ParDescripcion As New SqlParameter("@servicio_descripcion", SqlDbType.VarChar, 50)
            ParDescripcion.Value = UnServicio.Descripcion
            Dim ParEstado As New SqlParameter("@servicio_estado", SqlDbType.Bit, 0)
            ParEstado.Value = 1
            Dim ParSubCategoria As New SqlParameter("@subcategoria_id", SqlDbType.Int, 0)
            ParSubCategoria.Value = UnServicio.SubCategoriaID 

            Dim ParCondicion As New SqlParameter("@servicio_condiciones", SqlDbType.VarChar, 50)
            ParCondicion.Value = UnServicio.Condiciones

            Dim ParDuracion As New SqlParameter("@servicio_duracion", SqlDbType.Int, 0)
            ParDuracion.Value = UnServicio.Duracion


            Dim ParEventual As New SqlParameter("@servicio_eventual", SqlDbType.Bit, 0)
            ParEventual.Value = UnServicio.Eventual
            Conectividad.EjecutarComando("Servicio_Insert", New SqlParameter() {ParCondicion, ParDuracion, ParDescripcion, ParNombreCorto, ParNombreLargo, ParEstado, ParSubCategoria, ParEventual})

        Catch ex As Exception
            Throw New Exception("Insertar producto:" & ex.Message.ToString())
        End Try
    End Sub

    Public Function ListarServicios(ByVal ServicioID As Integer, ByVal CategoriaID As Integer, ByVal SubCategoriaID As Integer) As List(Of Servicio)
        Dim ListaProductos As New List(Of Servicio)
        Dim ServicioParam As New SqlParameter("@servicio_id", SqlDbType.Int, 0)
        ServicioParam.Value = IIf(ServicioID = 0, DBNull.Value, ServicioID)
        Dim ParSubCategoriaID As New SqlParameter("@subcategoria_id", SqlDbType.Int, 0)
        ParSubCategoriaID.Value = IIf(SubCategoriaID = 0, DBNull.Value, SubCategoriaID)
        Dim ParCategoriaID As New SqlParameter("@categoria_id", SqlDbType.Int, 0)
        ParCategoriaID.Value = IIf(CategoriaID = 0, DBNull.Value, CategoriaID)
        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("Servicio_Show", New SqlParameter() {ServicioParam, ParCategoriaID, ParSubCategoriaID})
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                ListaProductos.Add(ConstruirObjetoConRegistro(fila))
            Next
        End If
        Return ListaProductos
    End Function

    Public Sub ActualizarServicio(ByVal UnServicio As Servicio)
        Try
            Dim ParId As New SqlParameter("@servicio_id", SqlDbType.Int, 0)
            ParId.Value = UnServicio.ID
            Dim ParNombreCorto As New SqlParameter("@servicio_NombreCorto", SqlDbType.VarChar, 150)
            ParNombreCorto.Value = UnServicio.NombreCorto
            Dim ParNombreLargo As New SqlParameter("@servicio_NombreLargo", SqlDbType.VarChar, 150)
            ParNombreLargo.Value = UnServicio.NombreLargo
            Dim ParDescripcion As New SqlParameter("@servicio_descripcion", SqlDbType.VarChar, 50)
            ParDescripcion.Value = UnServicio.Descripcion
            Dim ParEstado As New SqlParameter("@servicio_estado", SqlDbType.Bit, 0)
            ParEstado.Value = 1
            Dim ParSubCategoria As New SqlParameter("@subcategoria_id", SqlDbType.Int, 0)
            ParSubCategoria.Value = UnServicio.SubCategoriaID

            Conectividad.EjecutarComando("Producto_Update", New SqlParameter() {ParId, ParNombreCorto, ParNombreLargo, ParDescripcion, ParEstado, ParSubCategoria})

        Catch ex As Exception
            Throw New Exception("Actualizar Producto: " & ex.Message.ToString())
        End Try
    End Sub

#Region "Metodos privados"

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Servicio
        Dim UnServicio As New Servicio
        UnServicio.ID = fila("servicio_id")
        UnServicio.Eventual = CBool(fila("servicio_eventual"))
        UnServicio.Condiciones = fila("servicio_condiciones").ToString().Trim()
        UnServicio.Duracion = CInt(fila("servicio_duracion"))
        UnServicio.Descripcion = fila("servicio_descripcion").ToString().Trim()
        UnServicio.NombreLargo = fila("servicio_nombrelargo").ToString().Trim()
        UnServicio.NombreCorto = fila("servicio_nombrecorto").ToString().Trim()
        UnServicio.Estado = CBool(fila("servicio_estado"))
        'UnServicio.precio = New Precio(fila("ServicioPrecio_valor"), New IVA(fila("iva_id"), fila("iva_descripcion"), fila("iva_multiplicador")), "")
        Return UnServicio
    End Function

#End Region

End Class
