Imports System.IO

Partial Class carrito_Confirmacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lnkVolver.PostBackUrl = String.Format("FormaPago.aspx?id={0}", Session("pedido"))
            lnkFormaEnvioCambiar.PostBackUrl = String.Format("FormaEnvio.aspx?id={0}", CInt(Session("pedido")))
            lnkFormaPagoCambiar.PostBackUrl = String.Format("FormaPago.aspx?id={0}", CInt(Session("pedido")))
            lnkDomicilioEnvioCambiar.PostBackUrl = String.Format("DomicilioEnvio.aspx?id={0}", CInt(Session("pedido")))
            lnkConfirmar.PostBackUrl = String.Format("Resumen.aspx?id={0}", CInt(Session("pedido")))

            If CInt(Session("pedido")) > 0 And CInt(Session("pedido")) = CInt(Request.QueryString("id")) Then
                Dim GestorPedido As New BLLPedido()
                Dim UnPedido As Pedido = GestorPedido.MostrarPedido(Session("pedido"), True)
                Dim GestorCliente As New BLLCliente
                Dim UnaCuenta As Cliente = GestorCliente.MostrarCliente(UnPedido.cliente.ID)
                MostrarDatosCabeceraPedidos(UnPedido)
                MostrarDatosCuenta(UnaCuenta)
                MostrarDomicilioEnvio(UnPedido.domicilioenvio)
                GrillaItems.DataSource = UnPedido.Items
                GrillaItems.DataBind()
            Else
                Response.Redirect("default.aspx")
            End If
        End If

    End Sub

    Protected Sub GrillaItems_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles GrillaItems.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            'Dim id As Integer = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "producto.id"))

            'Dim lblTiempoEntrega As Label = CType(e.Item.FindControl("lblTiempoEntrega"), Label)
            'Dim TiempoEntrega As Integer = 0 'Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TiempoEntrega"))
            'lblTiempoEntrega.Style.Add("background-color", "#008000")
            'lblTiempoEntrega.ToolTip = TiempoEntrega & " dias"

            Dim imagenbyte As Byte() = DataBinder.Eval(e.Item.DataItem, "producto.imagen")
            Dim ControlImagen As Image = CType(e.Item.FindControl("Image1"), Image)
            ControlImagen.ImageUrl = "~/assets/images/nodisponible.jpg"
            ControlImagen.Visible = True
            Using memoryStream As New MemoryStream()
                If imagenbyte IsNot Nothing Then
                    If imagenbyte.Length > 1 Then
                        memoryStream.Position = 0
                        memoryStream.Read(imagenbyte, 0, CInt(imagenbyte.Length))
                        Dim base64String As String = Convert.ToBase64String(imagenbyte, 0, imagenbyte.Length)
                        ControlImagen.ImageUrl = "data:image/png;base64," & base64String
                        ControlImagen.Visible = True
                    End If
                End If
            End Using
        End If
    End Sub

    Protected Sub lnkConfirmar_Click(sender As Object, e As EventArgs) Handles lnkConfirmar.Click

    End Sub

#Region "Metodos Privados"

    Private Sub MostrarDatosCuenta(ByVal UnCliente As Cliente)
        lblDomicilio.Text = UnCliente.Domicilio
        lblLocalidad.Text = UnCliente.Localidad
        lblMail.Text = UnCliente.Mail
        lblNombre.Text = UnCliente.Razon
        lblPais.Text = ""
        lblTelefono.Text = UnCliente.Telefono
    End Sub

    Private Sub MostrarDomicilioEnvio(ByVal UnDomicilio As DomicilioEnvio)
        lblCPEnvio.Text = UnDomicilio.CP
        lblDomicilioEnvio.Text = UnDomicilio.Direccion
        lblLocalidadEnvio.Text = UnDomicilio.Localidad
        lblProvinciaEnvio.Text = UnDomicilio.Provincia.Descripcion
        lblTelefonoEnvio.Text = UnDomicilio.Telefono
    End Sub
 

    Private Sub MostrarDatosCabeceraPedidos(ByVal UnPedido As Pedido)
        Dim PrecioTotal As Double = UnPedido.Items.Sum(Function(x) x.producto.precio.ValorFinal * x.cantidad)
        'lblSubTotal.Text = String.Format("{0:c}", PrecioTotal)
        lblTotalCarrito.Text = String.Format("{0:c}", PrecioTotal)
        'lblCantidadCarrito.CssClass = "label label-info"
        'lblCantidadCarrito.Text = UnPedido.Items.Count

        lblMetodoPago.Text = UnPedido.formapago.Descripcion
        lblMetodoEnvio.Text = UnPedido.FormaEnvio.Descripcion

        'Lista.DataSource = UnPedido.Items
        'Lista.DataBind()

        'DataList1.DataSource = UnPedido.Items
        'DataList1.DataBind()
    End Sub
#End Region


End Class
