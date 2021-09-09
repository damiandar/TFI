
Partial Class carrito_DomicilioEnvio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lnkVolver.PostBackUrl = String.Format("Carrito.aspx?id={0}", Session("pedido"))
            If CInt(Session("pedido")) > 0 And CInt(Session("pedido")) = CInt(Request.QueryString("id")) Then

                LLenarComboProvincia()
                LLenarDomicilioEnvio(Session("pedido"))
            Else
                Response.Redirect("default.aspx")
                End If
           


        End If
    End Sub

    Protected Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Response.Redirect(String.Format("formaenvio.aspx?id={0}", Session("pedido")))
    End Sub

#Region "Metodos Privados"

    Private Sub LLenarDomicilioEnvio(ByVal PedidoID As Integer)
        Dim GestorDomicilio As New BLLDomicilioEnvio
        Dim UnDomicilio As DomicilioEnvio = GestorDomicilio.MostrarDomicilioPorPedido(CInt(Session("pedido")))

        tbDomicilio.Text = UnDomicilio.Direccion
        tbCodigoPostal.Text = UnDomicilio.CP
        tbLocalidad.Text = UnDomicilio.Localidad
        tbTelefono.Text = UnDomicilio.Telefono
        comboProvincia.SelectedValue = UnDomicilio.Provincia.ID

    End Sub

    Private Sub LLenarComboProvincia()
        Dim GestorProvincias As New BLLProvincia
        comboProvincia.DataTextField = "descripcion"
        comboProvincia.DataValueField = "id"
        comboProvincia.DataSource = GestorProvincias.ListarProvincias()
        comboProvincia.DataBind()
    End Sub

#End Region
End Class
