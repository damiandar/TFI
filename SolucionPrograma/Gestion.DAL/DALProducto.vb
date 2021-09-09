Imports System.Data
Imports System.Data.SqlClient

Public Class DALProducto

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function InsertarProducto(ByVal UnProducto As Productos) As Integer
        Try
            Dim ParNombreCorto As New SqlParameter("@producto_NombreCorto", SqlDbType.VarChar, 150)
            ParNombreCorto.Value = UnProducto.NombreCorto
            Dim ParNombreLargo As New SqlParameter("@producto_NombreLargo", SqlDbType.VarChar, 150)
            ParNombreLargo.Value = UnProducto.NombreLargo
            Dim ParDescripcion As New SqlParameter("@producto_descripcion", SqlDbType.VarChar, 50)
            ParDescripcion.Value = UnProducto.Descripcion
            Dim ParEstado As New SqlParameter("@producto_estado", SqlDbType.Bit, 0)
            ParEstado.Value = 1
            Dim ParTiempoEntrega As New SqlParameter("@producto_tiempoentrega", SqlDbType.Int, 0)
            ParTiempoEntrega.Value = UnProducto.TiempoEntrega
            Dim ParSubCategoria As New SqlParameter("@subcategoria_id", SqlDbType.Int, 0)
            ParSubCategoria.Value = UnProducto.SubCategoriaID
            Dim ParCodigo As New SqlParameter("@producto_codigointerno", SqlDbType.VarChar, 20)
            ParCodigo.Value = UnProducto.CodigoInterno
            Dim ParMIME As New SqlParameter("@MimeType", SqlDbType.VarChar, 50)
            ParMIME.Value = UnProducto.TipoImagen
            Dim ParImagen As New SqlParameter("@ImageData", SqlDbType.VarBinary, 0)
            ParImagen.Value = UnProducto.Imagen
            Return Conectividad.EjecutarScalar("Producto_Insert", New SqlParameter() {ParNombreCorto, ParTiempoEntrega, ParNombreLargo, ParDescripcion, ParEstado, ParSubCategoria, ParCodigo, ParMIME, ParImagen})
        Catch ex As Exception
            Throw New Exception("Insertar producto:" & ex.Message.ToString())
        End Try
    End Function

    Public Function ListarProductos(ByVal ProductoID As Integer, ByVal CategoriaID As Integer, ByVal SubCategoriaID As Integer, ByVal Descripcion As String) As List(Of Productos)
        Dim ListaProductos As New List(Of Productos)
        Dim ParProductoID As New SqlParameter("@producto_id", SqlDbType.Int, 0)
        ParProductoID.Value = IIf(ProductoID = 0, DBNull.Value, ProductoID)
        Dim ParSubCategoriaID As New SqlParameter("@subcategoria_id", SqlDbType.Int, 0)
        ParSubCategoriaID.Value = IIf(SubCategoriaID = 0, DBNull.Value, SubCategoriaID)
        Dim ParCategoriaID As New SqlParameter("@categoria_id", SqlDbType.Int, 0)
        ParCategoriaID.Value = IIf(CategoriaID = 0, DBNull.Value, CategoriaID)
        Dim ParDescripcion As New SqlParameter("@producto_descripcion", SqlDbType.VarChar, 50)
        ParDescripcion.Value = DBNull.Value
        If Descripcion IsNot Nothing Then
            If Descripcion.Length > 3 Then
                ParDescripcion.Value = Descripcion
            End If
        End If

        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("Producto_Show", New SqlParameter() {ParProductoID, ParCategoriaID, ParSubCategoriaID, ParDescripcion})
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                Dim UnProducto As Productos = ConstruirObjetoConRegistro(fila)
                Dim oDalComentarios As New DALComentario
                UnProducto.comentarios = oDalComentarios.ListarComentarios(UnProducto.ID)
                ListaProductos.Add(UnProducto)
            Next
        End If
        Return ListaProductos
    End Function


    Public Function MostrarProductosPrecioLista(ByVal PrecioListaID As Integer) As List(Of Productos)
        Dim ListaProductos As New List(Of Productos)

        Dim ParProductoID As New SqlParameter("@ProductoListaPrecio_id", SqlDbType.Int, 0)
        ParProductoID.Value = IIf(PrecioListaID = 0, DBNull.Value, PrecioListaID)

        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("ListaPrecios_Show", New SqlParameter() {ParProductoID})

        If dt.Rows.Count > 0 Then
            For Each filaproducto As DataRow In dt.Rows
                Dim UnProducto As Productos = ConstruirObjetoConRegistro(filaproducto)
                Dim oDalComentarios As New DALComentario
                UnProducto.comentarios = oDalComentarios.ListarComentarios(UnProducto.ID)
                ListaProductos.Add(UnProducto)
            Next
        End If

        Return ListaProductos
    End Function


    Public Sub ActualizarProducto(ByVal UnProducto As Productos)
        Try
            Dim ParID As New SqlParameter("@producto_id", SqlDbType.Int, 0)
            ParID.Value = UnProducto.ID
            Dim ParNombreCorto As New SqlParameter("@producto_NombreCorto", SqlDbType.VarChar, 150)
            ParNombreCorto.Value = UnProducto.NombreCorto
            Dim ParNombreLargo As New SqlParameter("@producto_NombreLargo", SqlDbType.VarChar, 150)
            ParNombreLargo.Value = UnProducto.NombreLargo
            Dim ParDescripcion As New SqlParameter("@producto_descripcion", SqlDbType.VarChar, 50)
            ParDescripcion.Value = UnProducto.Descripcion
            Dim ParDestacado As New SqlParameter("@producto_destacado", SqlDbType.Bit, 0)
            ParDestacado.Value = UnProducto.Destacado
            Dim ParEstado As New SqlParameter("@producto_estado", SqlDbType.Bit, 0)
            ParEstado.Value = 1  
            Dim ParCodigo As New SqlParameter("@producto_codigointerno", SqlDbType.VarChar, 20)
            ParCodigo.Value = UnProducto.CodigoInterno
            Dim ParImagen As New SqlParameter("@ImageData", SqlDbType.VarBinary, 0)
            ParImagen.Value = IIf(UnProducto.Imagen.Length = 1, DBNull.Value, UnProducto.Imagen)
            Dim ParMIME As New SqlParameter("@MimeType", SqlDbType.VarChar, 50)
            ParMIME.Value = IIf(UnProducto.Imagen.Length = 1, DBNull.Value, UnProducto.TipoImagen)
            Dim ParPrecio As New SqlParameter("@producto_precio", SqlDbType.Decimal, 0)
            ParPrecio.Value = UnProducto.precio
            Dim ParSubCategoria As New SqlParameter("@subcategoria_id", SqlDbType.Int, 0)
            ParSubCategoria.Value = UnProducto.SubCategoriaID
            Conectividad.EjecutarComando("Producto_Update", New SqlParameter() {ParID, ParNombreCorto, ParNombreLargo, ParDescripcion, ParDestacado, ParEstado, ParSubCategoria, ParCodigo})
        Catch ex As Exception
            Throw New Exception("Actualizar Producto: " & ex.Message.ToString())
        End Try
    End Sub

#Region "Metodos privados"

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Productos
        Dim UnProducto As New Productos
        UnProducto.ID = fila("producto_id")
        UnProducto.Descripcion = fila("producto_descripcion").ToString().Trim()
        UnProducto.NombreLargo = fila("producto_nombrelargo").ToString().Trim()
        UnProducto.NombreCorto = fila("producto_nombrecorto").ToString().Trim()
        UnProducto.CodigoInterno = fila("producto_codigointerno").ToString()
        UnProducto.Imagen = fila("imagedata")
        UnProducto.TipoImagen = fila("MimeType")
        UnProducto.Estado = CBool(fila("producto_estado"))
        UnProducto.Destacado = IIf(fila("producto_destacado") Is DBNull.Value, False, fila("producto_destacado"))
        UnProducto.Estado = IIf(fila("producto_estado") Is DBNull.Value, False, fila("producto_estado"))
        UnProducto.TiempoEntrega = CInt(fila("producto_TiempoEntrega"))
        UnProducto.precio = New Precio(CDbl(fila("productoprecio_valor")), New IVA(fila("iva_id"), fila("iva_descripcion"), fila("iva_multiplicador")))
        'End If
        UnProducto.CategoriaID = fila("categoria_id")
        UnProducto.SubCategoriaID = fila("subcategoria_id")
        Return UnProducto
    End Function

#End Region

End Class
