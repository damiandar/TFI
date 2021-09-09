
Partial Class compras_AgregarItems
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim ReposicionID As Integer = Request.QueryString("ReposicionID")
            ViewState("ReposicionID") = ReposicionID
            If ReposicionID > 0 Then
                Dim GestorCompras As New BLLReposicion()
                Dim UnaReposicion As Reposicion = GestorCompras.MostrarReposicion(ReposicionID)

                Dim Items As List(Of ReposicionItem) = GestorCompras.ListarReposicionItem(ReposicionID)
                GrillaItems.DataSource = Items
                GrillaItems.DataBind()
            Else
                Response.Redirect("~/backend/compras/PedidoCompras.aspx")
            End If

        End If
    End Sub
End Class
