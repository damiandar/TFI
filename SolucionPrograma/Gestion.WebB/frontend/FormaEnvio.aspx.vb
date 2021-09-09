
Partial Class carrito_FormaEnvio
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            rbCorreo.Checked = True
            lnkVolver.PostBackUrl = String.Format("DomicilioEnvio.aspx?id={0}", Session("pedido"))
            If CInt(Session("pedido")) > 0 And CInt(Session("pedido")) = CInt(Request.QueryString("id")) Then

            Else
                Response.Redirect("default.aspx")
            End If
        End If

    End Sub

    Protected Sub btnSiguiente_Click(sender As Object, e As System.EventArgs) Handles btnSiguiente.Click
        Dim GestorPedidos As New BLLPedido()
        Dim UnPedido As Pedido = GestorPedidos.MostrarPedido(Session("pedido"), False)
        UnPedido.FormaEnvio = New FormaEnvio
        If rbCorreo.Checked = True Or rbDistribucionEmpresa.Checked = True Then
            If rbCorreo.Checked Then
                UnPedido.FormaEnvio.ID = 1
            ElseIf rbDistribucionEmpresa.Checked Then
                UnPedido.FormaEnvio.ID = 2
            End If
            GestorPedidos.ModificarPedido(UnPedido)
            Response.Redirect(String.Format("FormaPago.aspx?id={0}", Session("pedido")), True)
        Else
            'Dim s As String = "$('#myModal').modal('show');"
            'ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
            PanelAlerta.Visible = True
            lblMensaje.Text = "Debe seleccionar una forma de envio."
        End If

    End Sub

End Class
