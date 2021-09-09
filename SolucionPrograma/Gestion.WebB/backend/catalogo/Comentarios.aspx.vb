
Partial Class backend_catalogo_Comentarios
    Inherits System.Web.UI.Page

    Private Sub Comentarios_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ProductoId As Integer = Request.QueryString("ProductoID")
        If ProductoId > 0 Then
            Dim GestorComentarios As New BLLComentario()
            Dim ListaComentarios As New List(Of Comentarios)
            ListaComentarios = GestorComentarios.ListarComentarios(ProductoId)
            GrillaComentarios.DataSource = ListaComentarios
            GrillaComentarios.DataBind()
        End If

    End Sub

    Private Sub GrillaComentarios_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GrillaComentarios.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblVoto As Label = CType(e.Row.FindControl("lblVoto"), Label)
            Dim Positivo As Integer = CInt(DataBinder.Eval(e.Row.DataItem, "positivo"))
            lblVoto.CssClass = "fa fa-thumbs-up"

        End If
    End Sub
End Class
