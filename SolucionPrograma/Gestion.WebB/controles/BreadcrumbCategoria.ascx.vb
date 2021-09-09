
Partial Class controles_BreadcrumbCategoria
    Inherits System.Web.UI.UserControl

    Private Sub controles_BreadcrumbCategoria_Load(sender As Object, e As EventArgs) Handles Me.Load


        Dim SubCat As Integer = 0
        Dim Cat As Integer = 0

        SubCat = Request.QueryString("subcat")
        Cat = Request.QueryString("cat")

        If Cat > 0 Or SubCat > 0 Then
            Dim GestorCategoria As New BLLCategoria
            Dim UnaCategoria As New Categoria

            UnaCategoria = GestorCategoria.ListarCategoriaCompleta(Cat, SubCat)

            hlCategoria.Text = UnaCategoria.Descripcion
            hlCategoria.ToolTip = UnaCategoria.Descripcion
            hlCategoria.NavigateUrl = String.Format("../frontend/Default.aspx?cat={0}", UnaCategoria.ID)

            If SubCat > 0 Then
                Dim UnaSubCategoria As New SubCategoria
                UnaSubCategoria = UnaCategoria.SubCategorias.Item(0)
                hlSubCategoria.Text = UnaSubCategoria.Descripcion.ToString()
                hlSubCategoria.NavigateUrl = String.Format("../frontend/Default.aspx?subcat={0}", UnaSubCategoria.ID)
                hlSubCategoria.ToolTip = UnaSubCategoria.Descripcion.ToString()
            End If

        End If

    End Sub
End Class
