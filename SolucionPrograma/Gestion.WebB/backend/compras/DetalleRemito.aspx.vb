
Partial Class compras_DetalleRemito
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim ComprobanteID As Integer = Request.QueryString("ComprobanteID")

            If ComprobanteID > 0 Then
                Dim GestorRemito As New BLLRemito
                Dim UnRemito As New Remito
                UnRemito = GestorRemito.MostrarRemito(ComprobanteID)
                lblRemito.Text = UnRemito.Nro
                lblFecha.Text = UnRemito.Fecha
                lblProveedor.Text = UnRemito.orden.proveedor.Razon.ToString()
                lblNota.Text = UnRemito.Notas
                GrillaDetalle.DataSource = UnRemito.Items
                GrillaDetalle.DataBind()
            Else
                Response.Redirect("~/backend/compras/remitos.aspx")
            End If


        End If
    End Sub
End Class
