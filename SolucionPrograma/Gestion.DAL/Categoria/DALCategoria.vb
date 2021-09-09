Imports System.Data
Imports System.Data.SqlClient

Public Class DALTipoCatalogo

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function MostrarTiposCatalogo() As List(Of CatalogoTipo)

        Dim ListaCategorias As New List(Of CatalogoTipo)
        'Dim ParCatalogoID As New SqlParameter("@Catalogo_id", SqlDbType.Int, 0)
        'ParCatalogoID.Value = TipoCatalogoID

        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("CatalogoTipo_Show", Nothing)
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                ListaCategorias.Add(ConstruirObjetoConRegistro(fila))
            Next
        End If
        Return ListaCategorias

    End Function

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As CatalogoTipo
        Dim UnaCategoria As New CatalogoTipo
        UnaCategoria.ID = fila("catalogotipo_id")
        UnaCategoria.Descripcion = fila("catalogotipo_descripcion")
        Return UnaCategoria
    End Function

End Class

Public Class DALCategoria

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    ''' <summary>
    ''' Muestra las categorias segun el tipo de Catalogo que puede ser Insumo, Producto o Servicio
    ''' </summary>
    ''' <param name="TipoCatalogoID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MostrarCategorias(ByVal TipoCatalogoID As Integer) As List(Of Categoria)

        Dim ListaCategorias As New List(Of Categoria)
        Dim ParCatalogoID As New SqlParameter("@CatalogoTipo_id", SqlDbType.Int, 0)
        ParCatalogoID.Value = TipoCatalogoID

        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("Categoria_Show", New SqlParameter() {ParCatalogoID})
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                ListaCategorias.Add(ConstruirObjetoConRegistro(fila))
            Next
        End If
        Return ListaCategorias

    End Function

    Public Sub EliminarCategoria(ByVal categoriaId As Integer) 
        Dim ParCategoriaID As New SqlParameter("@Categoria_id", SqlDbType.Int, 0)
        ParCategoriaID.Value = IIf(categoriaId = 0, DBNull.Value, categoriaId)
        Conectividad.EjecutarComando("Categoria_Delete", New SqlParameter() {ParCategoriaID})
    End Sub

    Public Sub EliminarSubCategoria(ByVal SubCategoriaId As Integer)
        Dim ParSubCategoriaID As New SqlParameter("@Subcategoria_id", SqlDbType.Int, 0)
        ParSubCategoriaID.Value = IIf(SubCategoriaId = 0, DBNull.Value, SubCategoriaId) 
        Conectividad.EjecutarComando("SubCategoria_Delete", New SqlParameter() {ParSubCategoriaID})
    End Sub

    Public Sub InsertarCategoria(ByVal descripcion As String, ByVal TipoCatalogoID As Integer)
        Dim ParCatalogoID As New SqlParameter("@CatalogoTipo_id", SqlDbType.Int, 0)
        ParCatalogoID.Value = TipoCatalogoID
        Dim ParDescripcion As New SqlParameter("@categoria_descripcion", SqlDbType.VarChar, 50)
        ParDescripcion.Value = descripcion
        Conectividad.EjecutarComando("Categoria_Insert", New SqlParameter() {ParCatalogoID, ParDescripcion})
    End Sub

    Public Sub InsertarSubCategoria(ByVal descripcion As String, ByVal Categoria As Integer)
        Dim ParCategoriaID As New SqlParameter("@Categoria_id", SqlDbType.Int, 0)
        ParCategoriaID.Value = Categoria
        Dim ParDescripcion As New SqlParameter("@subcategoria_detalle", SqlDbType.VarChar, 50)
        ParDescripcion.Value = descripcion
        Conectividad.EjecutarComando("SubCategoria_Insert", New SqlParameter() {ParCategoriaID, ParDescripcion})
    End Sub

    Public Function ListarCategoriaCompleta(ByVal CategoriaId As Integer, ByVal SubCategoriaID As Integer) As Categoria
        Dim UnaCategoria As New Categoria()

        Dim ParSubCategoriaID As New SqlParameter("@Subcategoria_id", SqlDbType.Int, 0)
        ParSubCategoriaID.Value = IIf(SubCategoriaID = 0, DBNull.Value, SubCategoriaID)
        Dim ParCategoriaID As New SqlParameter("@Categoria_id", SqlDbType.Int, 0)
        ParCategoriaID.Value = IIf(CategoriaId = 0, DBNull.Value, CategoriaId)
        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("SubCategoriaRuta_Show", New SqlParameter() {ParSubCategoriaID, ParCategoriaID})

        If dt.Rows.Count > 0 Then
            UnaCategoria = ConstruirObjetoConRegistro(dt.Rows(0))
            UnaCategoria.SubCategorias = New List(Of SubCategoria)

            For Each fila As DataRow In dt.Rows
                UnaCategoria.SubCategorias.Add(ConstruirObjetoConRegistroSubCategoria(fila))
            Next
        End If
        Return UnaCategoria
    End Function

#Region "Metodos Privados"

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Categoria
        Dim UnaCategoria As New Categoria
        UnaCategoria.ID = fila("categoria_id")
        UnaCategoria.Descripcion = fila("categoria_descripcion")
        Return UnaCategoria
    End Function

    Private Function ConstruirObjetoConRegistroSubCategoria(ByVal fila As DataRow) As SubCategoria
        Dim UnaSubCategoria As New SubCategoria
        UnaSubCategoria.ID = fila("subcategoria_id")
        UnaSubCategoria.Descripcion = fila("subcategoria_detalle")
        Return UnaSubCategoria
    End Function
#End Region
End Class

Public Class DALSubCategoria

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    ''' <summary>
    ''' Muestra las subcategorias segun la categoria seleccionada
    ''' </summary>
    ''' <param name="CategoriaID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MostrarSubCategorias(ByVal CategoriaID As Integer) As List(Of SubCategoria)

        Dim ListaCategorias As New List(Of SubCategoria)
        Dim ParCategoriaID As New SqlParameter("@Categoria_id", SqlDbType.Int, 0)
        ParCategoriaID.Value = CategoriaID

        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("SubCategoria_Show", New SqlParameter() {ParCategoriaID})
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                ListaCategorias.Add(ConstruirObjetoConRegistro(fila))
            Next
        End If
        Return ListaCategorias

    End Function

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As SubCategoria
        Dim UnaSubCategoria As New SubCategoria
        UnaSubCategoria.ID = fila("subcategoria_id")
        UnaSubCategoria.Descripcion = fila("subcategoria_detalle")
        Return UnaSubCategoria
    End Function


End Class