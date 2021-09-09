Imports System.IO

Partial Class backend_ventas_FacturasDetalle
    Inherits System.Web.UI.Page

    Private Sub FacturasDetalle_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim id As Object = Request.QueryString("ID")

        If IsNumeric(id) Then
            Dim GestorFacturas As New BLLFactura()
            Dim UnaFactura As FacturaVenta = GestorFacturas.ListarFacturas(CInt(id), 0).Item(0)
            lblCliente.Text = UnaFactura.cliente.Razon
            lblFecha.Text = UnaFactura.Fecha
            lblLetra.Text = UnaFactura.Letra.ToString()
            lblNro.Text = UnaFactura.Nro
            lblPtoVenta.Text = UnaFactura.PtoVenta

            GrillaFacturas.DataSource = UnaFactura.Items
            GrillaFacturas.DataBind()
        Else
            Response.Redirect("Facturas.aspx")
        End If
    End Sub

    Protected Sub ImprimirPDF_Click(sender As Object, e As EventArgs) Handles ImprimirPDF.Click
        Dim GestorReportes As New Reportes
        Dim GestorFacturas As New BLLFactura
        Dim id As Integer = Request.QueryString("ID")
        Dim UnaFactura As FacturaVenta = GestorFacturas.ListarFacturas(id, 0).Item(0)
        Dim output As MemoryStream = GestorReportes.DibujarPlanillaFacturas("aa", UnaFactura)

        HttpContext.Current.Response.ContentType = "application/pdf"
        HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=FACTURA-{0}-{1}.pdf", UnaFactura.Letra, UnaFactura.Nro))
        HttpContext.Current.Response.BinaryWrite(output.ToArray())
    End Sub
End Class
