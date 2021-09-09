Imports System.IO

Partial Class carrito_Carrito
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                PanelMensaje.Visible = False
                If CInt(Session("pedido")) > 0 Then
                    LLenarGrilla(CInt(Session("pedido")))
                    MostrarDatosCabeceraPedidos()
                Else
                    Response.Redirect("default.aspx")
                End If
            End If

        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try

    End Sub

    Public Sub LLenarGrilla(ByVal PedidoID As Integer)
        Dim GestorPedido As New BLLPedido()
        Dim UnPedido As Pedido = GestorPedido.MostrarPedido(Session("pedido"), True)
        DataList1.DataSource = UnPedido.Items
        DataList1.DataBind()
    End Sub

    Public Sub MostrarDatosCabeceraPedidos()
        Dim GestorPedido As New BLLPedido()
        Dim UnPedido As Pedido = GestorPedido.MostrarPedido(Session("pedido"), True)
        lblTotalCarrito.Text = String.Format("{0:c}", UnPedido.Total)
        'lblCantidadCarrito.CssClass = "label label-info"
        'lblCantidadCarrito.Text = UnPedido.Items.Count
        'Lista.DataSource = UnPedido.Items
        'Lista.DataBind()

        'DataList1.DataSource = UnPedido.Items
        'DataList1.DataBind()
    End Sub

    Protected Sub DataList1_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        If e.CommandName = "Borrar" Then
            Dim GestorPedido As New BLLPedido
            Dim PedidoID As Integer = CInt(Session("pedido"))
            Dim ProductoID As Integer = CInt(e.CommandArgument)
            GestorPedido.BorrarPedidoItem(PedidoID, ProductoID)
            lblMensaje.Text = "Se ha eliminado correctamente del carrito"
            PanelMensaje.Visible = True
            LLenarGrilla(PedidoID)
            MostrarDatosCabeceraPedidos()
        End If
    End Sub


    Protected Sub DataList1_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim id As Integer = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "producto.id"))

            Dim lblTiempoEntrega As Label = CType(e.Item.FindControl("lblTiempoEntrega"), Label)
            Dim TiempoEntrega As Integer = 0 'Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TiempoEntrega"))
            lblTiempoEntrega.Style.Add("background-color", "#008000")
            lblTiempoEntrega.ToolTip = TiempoEntrega & " dias"

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


    Protected Sub lnkCheckOut_Click(sender As Object, e As System.EventArgs) Handles lnkCheckOut.Click
        Response.Redirect(String.Format("DomicilioEnvio.aspx?id={0}", Session("pedido")))
    End Sub

    Protected Sub lnkActualizarCarrito_Click(sender As Object, e As System.EventArgs) Handles lnkActualizarCarrito.Click
        For Each fila As DataListItem In DataList1.Items
            Dim PedidoID As Integer = CInt(Session("pedido"))
            Dim tbCantidad As TextBox = CType(fila.FindControl("tbCantidad"), TextBox)
            Dim Cantidad As Integer = CInt(tbCantidad.Text)
            Dim hProductoID As HiddenField = CType(fila.FindControl("hProductoID"), HiddenField)
            Dim ProductoID As Integer = CInt(hProductoID.Value)
            Dim UnItem As New PedidoItem
            UnItem.cantidad = Cantidad
            UnItem.producto = New Productos
            UnItem.producto.ID = ProductoID
            UnItem.estado = PedidoItem.EstadoItem.Creado
            Dim GestorPedido As New BLLPedido
            GestorPedido.ModificarItemPedido(PedidoID, UnItem)
        Next

        lblMensaje.Text = "Se ha actualizado correctamente el carrito"
        PanelMensaje.Visible = True
        LLenarGrilla(CInt(Session("pedido")))
        MostrarDatosCabeceraPedidos()
    End Sub

End Class
