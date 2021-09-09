
Partial Class ventas_Detalle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If IsNumeric(Request.QueryString("PedidoID")) Then
                Dim PedidoID As Integer = Request.QueryString("PedidoID")

                ViewState("PedidoID") = PedidoID

                Dim GestorPedido As New BLLPedido
                Dim UnPedido As New Pedido

                UnPedido = GestorPedido.MostrarPedido(PedidoID, False)
                lblEstado.Text = UnPedido.EstadoPedido.ToString()
                lblFecha.Text = UnPedido.Fecha
                lblNotas.Text = UnPedido.Notas
                lblNro.Text = UnPedido.ID
                lblCliente.Text = UnPedido.cliente.Razon

                LLenarGrilla(PedidoID)
            Else
                Response.Redirect("default.aspx")
            End If
        End If

    End Sub

    Private Sub LLenarGrilla(ByVal PedidoId As Integer)
        Dim oBLLDetalle As New BLLPedido
        GrillaDetalle.DataSource = oBLLDetalle.ListarPedidosItem(PedidoId)
        GrillaDetalle.DataBind()
    End Sub

    Protected Sub GrillaDetalle_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrillaDetalle.RowCommand
        If e.CommandName = "Update" Or e.CommandName = "Anular" Then

            Dim NroFila As Integer = CInt(e.CommandArgument) - 1
            Dim comboEstado As DropDownList = CType(GrillaDetalle.Rows(NroFila).FindControl("comboEstado"), DropDownList)
            Dim ProductoId As Integer = CType(GrillaDetalle.Rows(NroFila).FindControl("hProductoID"), HiddenField).Value

            Dim UnPedidoItem As New PedidoItem()
            Dim GestorPedido As New BLLPedido
            Dim UnPedido As New Pedido
            UnPedido.Items = New List(Of PedidoItem)
            UnPedido.Items = GestorPedido.ListarPedidosItem(CInt(ViewState("PedidoID")))
            UnPedidoItem = UnPedido.Items.Find(Function(x) x.producto.ID = ProductoID)

            If e.CommandName = "Anular" Then
                UnPedidoItem.estado = 5 'anular
            Else
                If UnPedido.EstadoPedido < 4 Then
                    UnPedidoItem.estado += 1
                End If
            End If
            GestorPedido.ModificarItemPedido(CInt(ViewState("PedidoID")), UnPedidoItem)
            GestorPedido.ModificarEstadoPedido(CInt(ViewState("PedidoID")))
        End If
    End Sub


    Protected Sub GrillaDetalle_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrillaDetalle.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim Estado As Integer = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "estado"))

            If e.Row.RowState = DataControlRowState.Normal Then
                Dim lblEstado As Label = CType(e.Row.FindControl("lblEstado"), Label)

                If Estado = PedidoItem.EstadoItem.Creado Then
                    lblEstado.Text = "Confirmado"
                    lblEstado.ForeColor = Drawing.Color.Red
                ElseIf Estado = PedidoItem.EstadoItem.EnProceso Then
                    lblEstado.Text = "En Proceso"
                    lblEstado.ForeColor = Drawing.Color.Green
                ElseIf Estado = PedidoItem.EstadoItem.EnDistribucion Then
                    lblEstado.Text = "En distribución"
                    lblEstado.ForeColor = Drawing.Color.Yellow
                ElseIf Estado = PedidoItem.EstadoItem.Entregado Then
                    lblEstado.Text = "Entregado"
                    lblEstado.ForeColor = Drawing.Color.Blue
                End If

            ElseIf e.Row.RowState = DataControlRowState.Edit Then
                Dim comboEstado As DropDownList = CType(e.Row.FindControl("comboEstado"), DropDownList)

                If Estado = PedidoItem.EstadoItem.Creado Then
                    comboEstado.Items.Add(New ListItem("Confirmado", 1))
                    comboEstado.Items.Add(New ListItem("En Proceso", 2))
                ElseIf Estado = PedidoItem.EstadoItem.EnProceso Then
                    comboEstado.Items.Add(New ListItem("En Proceso", 2))
                    comboEstado.Items.Add(New ListItem("En distribución", 3))
                ElseIf Estado = PedidoItem.EstadoItem.EnDistribucion Then
                    comboEstado.Items.Add(New ListItem("En distribución", 3))
                    comboEstado.Items.Add(New ListItem("Entregado", 4))
                ElseIf Estado = PedidoItem.EstadoItem.Entregado Then
                    comboEstado.Items.Add(New ListItem("Entregado", 4))
                End If

                comboEstado.SelectedValue = Estado
            End If

        End If
    End Sub

    Protected Sub GrillaDetalle_RowCancelingEdit(sender As Object, e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GrillaDetalle.RowCancelingEdit
        GrillaDetalle.EditIndex = -1
        LLenarGrilla(ViewState("PedidoID"))
    End Sub
    Protected Sub GrillaDetalle_RowEditing(sender As Object, e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrillaDetalle.RowEditing
        GrillaDetalle.EditIndex = e.NewEditIndex
        LLenarGrilla(ViewState("PedidoID"))
    End Sub


    Protected Sub GrillaDetalle_RowUpdating(sender As Object, e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GrillaDetalle.RowUpdating
        GrillaDetalle.EditIndex = -1
        LLenarGrilla(ViewState("PedidoID"))
    End Sub

    Private Sub btnGenerarFactura_Click(sender As Object, e As EventArgs) Handles btnGenerarFactura.Click
        Dim GestorPedido As New BLLPedido
        Dim UnPedido As New Pedido

        UnPedido = GestorPedido.MostrarPedido(ViewState("PedidoID"), True)


        Dim UnaFactura As New FacturaVenta
        UnaFactura.cliente = UnPedido.cliente
        UnaFactura.Fecha = Now.Date
        UnaFactura.PedidoID = CInt(ViewState("PedidoID"))
        UnaFactura.Letra = FacturaVenta.eLetra.A
        UnaFactura.Fecha = Now.Date
        UnaFactura.PtoVenta = 1

        UnaFactura.Items = New List(Of FacturaVentaItem)

        For Each ItemPedido In UnPedido.Items
            Dim UnItem As New FacturaVentaItem
            UnItem.precio = ItemPedido.producto.precio.ValorFinal
            UnItem.cantidad = ItemPedido.cantidad
            UnItem.producto = ItemPedido.producto
            UnaFactura.Items.Add(UnItem)
        Next


        Dim GestorFactura As New BLLFactura
        GestorFactura.InsertarFactura(UnaFactura)

    End Sub
End Class
