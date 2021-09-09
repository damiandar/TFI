
Partial Class backend_catalogo_ProductosListado
    Inherits System.Web.UI.Page

    Private Sub GrillaProductos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GrillaProductos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lnkComentarios As HyperLink = CType(e.Row.FindControl("lnkComentarios"), HyperLink)
            Dim ID As Integer = CInt(DataBinder.Eval(e.Row.DataItem, "id"))

            Dim GestorComentarios As New BLLComentario
            Dim ListaComentarios As New List(Of Comentarios)
            ListaComentarios = GestorComentarios.ListarComentarios(ID)
            lnkComentarios.Text = ListaComentarios.Count.ToString()
        End If
    End Sub

    Private Sub ProductosListado_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Lista As New List(Of Productos)
        Dim GestorServicios As New BLLProducto
        Lista = GestorServicios.ListarProducto(0, 0, 0, "")
        GrillaProductos.DataSource = Lista
        GrillaProductos.DataBind()
    End Sub
End Class
