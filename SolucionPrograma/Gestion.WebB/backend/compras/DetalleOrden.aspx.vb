
Partial Class compras_DetalleOrden
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim ComprobanteID As Integer = Request.QueryString("ComprobanteID")
            If ComprobanteID > 0 Then
                Dim GestorComprobante As New BLLorden
                Dim UnaOrden As New OrdenCompra
                UnaOrden = GestorComprobante.MostrarOrden(ComprobanteID)

                lblProveedor.Text = UnaOrden.proveedor.Razon.ToString()
                lblFecha.Text = UnaOrden.Fecha
                lblNroOrden.Text = UnaOrden.ID
                GrillaDetalle.DataSource = UnaOrden.Items
                GrillaDetalle.DataBind()
            Else
                Response.Redirect("~/backend/compras/Ordenes.aspx")
            End If

        End If
    End Sub

End Class
