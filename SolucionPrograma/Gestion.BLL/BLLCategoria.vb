Public Class BLLCategoria
    Dim dataProvider As DALCategoria

    Public Sub New()
        dataProvider = New DALCategoria
    End Sub

    Public Enum TipoCatalogo
        Producto = 1
        Servicio = 2
        Insumo = 3
    End Enum

    ''' <summary>
    ''' Muestra las categorias segun el tipo de Catalogo que puede ser Insumo, Producto o Servicio
    ''' </summary>
    ''' <param name="TipoCatalogoID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MostrarCategorias(ByVal TipoCatalogoID As TipoCatalogo) As List(Of Categoria)
        Return dataProvider.MostrarCategorias(TipoCatalogoID)
    End Function

    Public Function ListarCategoriaCompleta(ByVal CategoriaID As Integer, ByVal SubCategoriaID As Integer) As Categoria
        Return dataProvider.ListarCategoriaCompleta(CategoriaID, SubCategoriaID)
    End Function

    Public Sub InsertarCategoria(ByVal descripcion As String, ByVal TipoCatalogoID As Integer)
        dataProvider.InsertarCategoria(descripcion, TipoCatalogoID)
    End Sub

    Public Sub InsertarSubCategoria(ByVal descripcion As String, ByVal Categoria As Integer)
        dataProvider.InsertarSubCategoria(descripcion, Categoria)
    End Sub

    Public Sub EliminarCategoria(ByVal categoriaId As Integer)
        dataProvider.EliminarCategoria(categoriaId)
    End Sub

    Public Sub EliminarSubCategoria(ByVal SubCategoriaId As Integer)
        dataProvider.EliminarSubCategoria(SubCategoriaId)
    End Sub

End Class

Public Class BLLSubCategoria

    Dim dataProvider As DALSubCategoria

    Public Sub New()
        dataProvider = New DALSubCategoria
    End Sub

    ''' <summary>
    ''' Muestra las subcategorias segun la categoria seleccionada
    ''' </summary>
    ''' <param name="CategoriaID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MostrarSubCategorias(ByVal CategoriaID As Integer) As List(Of SubCategoria)
        Return dataProvider.MostrarSubCategorias(CategoriaID)
    End Function
     
End Class

Public Class BLLTipoCatalogo

    Dim dataProvider As DALTipoCatalogo

    Public Sub New()
        dataProvider = New DALTipoCatalogo
    End Sub

 
    Public Function MostrarTiposCatalogo() As List(Of CatalogoTipo)
        Return dataProvider.MostrarTiposCatalogo()
    End Function
End Class