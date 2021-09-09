
Partial Class frontend_PedidosAnteriores
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim GestorPedidos As New BLLPedido
        GrillaPedidosAnteriores.DataSource = GestorPedidos.ListarPedido(Session("clienteid"), 0, 0, False)
        GrillaPedidosAnteriores.DataBind()

    End Sub
End Class
