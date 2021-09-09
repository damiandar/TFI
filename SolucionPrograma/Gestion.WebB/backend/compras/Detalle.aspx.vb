
Partial Class compras_Detalle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim ReposicionID As Integer = Request.QueryString("ReposicionID")
            If CInt(ReposicionID) > 0 Then

                Dim GestorCompras As New BLLReposicion()
                Dim UnaReposicion As Reposicion = GestorCompras.MostrarReposicion(ReposicionID)
                lblNro.Text = UnaReposicion.ID
                lblFecha.Text = UnaReposicion.Fecha
                lblNotas.Text = UnaReposicion.Notas
                If UnaReposicion.Estado = Reposicion.eEstado.creado Then
                    lblEstado.Text = "Creado"
                ElseIf UnaReposicion.Estado = Reposicion.eEstado.enviado Then
                    lblEstado.Text = "Enviado"
                ElseIf UnaReposicion.Estado = Reposicion.eEstado.comprado Then
                    lblEstado.Text = "Comprado"
                End If

                GrillaItemsReposicion.DataSource = UnaReposicion.Items
                GrillaItemsReposicion.DataBind()
            Else
                Response.Redirect("~/backend/compras/default.aspx")
            End If
        End If
    End Sub
    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("default.aspx")
    End Sub
End Class
