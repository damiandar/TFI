Imports System.IO

Partial Class controles_carritomenu
    Inherits System.Web.UI.UserControl


    Protected Sub Lista_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles Lista.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim id As Integer = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "producto.id"))
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

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim GestorPedido As New BLLPedido()

        Dim PedidoID As Integer = 0
        Dim PrecioTotal As Double = 0
        Dim Items As New List(Of PedidoItem)

        If IsNumeric(Session("pedido")) Then
            PedidoID = CInt(Session("pedido"))
            Dim UnPedido As Pedido = GestorPedido.MostrarPedido(PedidoID, True)
            If UnPedido IsNot Nothing Then
                Items = UnPedido.Items
                If Items IsNot Nothing Then
                    If Items.Count > 0 Then
                        PrecioTotal = UnPedido.Items.Sum(Function(x) x.Total)
                    End If
                End If

            End If
        End If


        'lblSubTotal.Text = String.Format("{0:c}", PrecioTotal)


        If PrecioTotal > 0 Then
            lblTotalCarrito.Text = String.Format("Total Carrito {0:c}", PrecioTotal)
            lnkCarrito.Visible = True
        Else
            lblTotalCarrito.Text = "Carrito Vacio"
            lnkCarrito.Visible = False
        End If


        Lista.DataSource = Items
        Lista.DataBind()
    End Sub
End Class
