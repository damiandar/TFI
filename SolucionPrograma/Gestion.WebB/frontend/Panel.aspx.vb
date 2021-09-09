Imports System.IO

Partial Class aplicacion_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim GestorPedidos As New BLLPedido
            Dim ListaPedidos As New List(Of Pedido)
            ListaPedidos = GestorPedidos.ListarPedido(CInt(Session("clienteid")), 0, 0, False)

            'lblPedidos.Text = ListaPedidos.Count

            GrillaPedidos.DataSource = ListaPedidos
            GrillaPedidos.DataBind()

        End If

    End Sub

    Protected Sub GrillaPedidos_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrillaPedidos.RowCommand
        If e.CommandName = "Imprimir" Then
            Dim GestorReportes As New Reportes()
            Dim GestorPedido As New BLLPedido()
            Dim UnPedido As Pedido = GestorPedido.MostrarPedido(e.CommandArgument, True)

            Dim output As MemoryStream = GestorReportes.DibujarPlanillaPedidos("aa", UnPedido)
            HttpContext.Current.Response.ContentType = "application/pdf"
            HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=Pedido-Nro-{0}.pdf", UnPedido.ID))
            HttpContext.Current.Response.BinaryWrite(output.ToArray())
        End If
    End Sub

    Protected Sub GrillaPedidos_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrillaPedidos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblTotal As Label = CType(e.Row.FindControl("lblTotal"), Label)
            Dim Items As List(Of PedidoItem) = CType(DataBinder.Eval(e.Row.DataItem, "items"), List(Of PedidoItem))
            lblTotal.Text = String.Format("{0:c}", Items.Sum(Function(x) x.Total))
        End If
    End Sub


End Class
