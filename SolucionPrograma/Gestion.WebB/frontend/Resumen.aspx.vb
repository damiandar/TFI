Imports System.IO

Partial Class carrito_Resumen
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If CInt(Session("pedido")) > 0 And CInt(Session("pedido")) = CInt(Request.QueryString("id")) Then
                ViewState("pedido") = Session("pedido")
                Dim GestorPedido As New BLLPedido
                Dim UnPedido As Pedido = GestorPedido.MostrarPedido(ViewState("pedido"), True)

                lblPedidoNro.Text = UnPedido.ID
                lblPedidoFecha.Text = UnPedido.Fecha
                lblPedidoTotal.Text = UnPedido.Total
                lblCliente.Text = UnPedido.cliente.Razon
                lblMail.Text = UnPedido.cliente.Mail

                lblFormaPago.Text = UnPedido.formapago.Descripcion
                lblFormaEnvio.Text = UnPedido.FormaEnvio.Descripcion
                lblTotalCarrito.Text = String.Format("{0:c}", UnPedido.Items.Sum(Function(x) x.Total))

                Dim GestorCliente As New BLLCliente
                Dim UnaCuenta As Cliente = GestorCliente.MostrarCliente(UnPedido.cliente.ID)
                MostrarDomicilioFactura(UnaCuenta)
                MostrarDomicilioEnvio(UnPedido.domicilioenvio)


                'Lo Confirmo para que lo puedan ver desde el backend
                UnPedido.EstadoPedido = Pedido.ePedidoEstado.Confirmado
                GestorPedido.ModificarPedido(UnPedido)

                Session("pedido") = 0

                GrillaItems.DataSource = UnPedido.Items
                GrillaItems.DataBind()

            Else
                Response.Redirect("default.aspx")
            End If

        End If

    End Sub

    Protected Sub lnkPdf_Click(sender As Object, e As System.EventArgs) Handles lnkPdf.Click
        Dim GestorReportes As New Reportes()
        Dim GestorPedido As New BLLPedido()
        Dim UnPedido As Pedido = GestorPedido.MostrarPedido(ViewState("pedido"), True)
        Dim UnCliente As New Cliente
        Dim GestorCliente As New BLLCliente
        UnCliente = GestorCliente.MostrarCliente(UnPedido.cliente.ID)

        Dim output As MemoryStream = GestorReportes.DibujarPlanillaPedidos("aa", UnPedido)
        HttpContext.Current.Response.ContentType = "application/pdf"
        HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=Planilla_Pedido-{0}.pdf", "aaa"))
        HttpContext.Current.Response.BinaryWrite(output.ToArray())
    End Sub



#Region "Metodos Privados"


    Private Sub MostrarDomicilioFactura(ByVal UnDomicilio As Cliente)
        lblCPFactura.Text = UnDomicilio.CP
        lblDomicilioFactura.Text = UnDomicilio.Domicilio
        lblLocalidadFactura.Text = UnDomicilio.Localidad
        lblProvinciaFactura.Text = UnDomicilio.Provincia.Descripcion
        lblTelefonoFactura.Text = UnDomicilio.Telefono
    End Sub

    Private Sub MostrarDomicilioEnvio(ByVal UnDomicilio As DomicilioEnvio)
        lblCPEnvio.Text = UnDomicilio.CP
        lblDomicilioEnvio.Text = UnDomicilio.Direccion
        lblLocalidadEnvio.Text = UnDomicilio.Localidad
        lblProvinciaEnvio.Text = UnDomicilio.Provincia.Descripcion
        lblTelefonoEnvio.Text = UnDomicilio.Telefono
    End Sub

#End Region




End Class
