Imports System.IO

Partial Class carrito_Detalle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ViewState("productoID") = Request.QueryString("producto_id")
            ViewState("tipoid") = Request.QueryString("tipo_id")
            If CInt(ViewState("productoID")) = 0 Then
                Response.Redirect("default.aspx")
            End If

            Dim UnCatalogo As New CatalogoLista

            Dim GestorProducto As New BLLProducto
            Dim UnProducto As Productos = GestorProducto.MostrarProducto(CInt(ViewState("productoID")))
            LLenarListaCatalogoProductos(UnCatalogo, UnProducto)

            lblNombreCorto.Text = UnCatalogo.NombreCorto
            lblNombreLargo.Text = UnCatalogo.NombreLargo
            lblCodigo.Text = UnCatalogo.CodigoInterno
            lblPrecio.Text = UnCatalogo.precio.ValorFinal.ToString("C")
            lblDescripcion.Text = UnCatalogo.Descripcion
            lnkReviews.PostBackUrl = String.Format("../frontend/Comentarios.aspx?productoID={0}", UnCatalogo.ID)
            lnkReviews.Text = UnCatalogo.comentarios.Count
            Dim Promedio As Integer = UnCatalogo.Puntaje
            divrating.Style.Add("width", Promedio.ToString() & "%")
            Dim TiempoEntrega As Integer = 200
            'Dim TiempoEntrega As Integer = DataBinder.Eval(e.Item.DataItem, "tiempoentrega")
            lblTiempoEntrega.Style.Add("background-color", "#008000")
            lblTiempoEntrega.ToolTip = TiempoEntrega & " dias"

            Image1.ImageUrl = "~/assets/images/nodisponible.jpg"
            Image1.Visible = True

            Using memoryStream As New MemoryStream()
                Dim imagenbyte As Byte() = UnCatalogo.Imagen
                If imagenbyte IsNot Nothing Then
                    If imagenbyte.Length > 1 Then
                        memoryStream.Position = 0
                        memoryStream.Read(imagenbyte, 0, CInt(imagenbyte.Length))
                        Dim base64String As String = Convert.ToBase64String(imagenbyte, 0, imagenbyte.Length)
                        Image1.ImageUrl = "data:image/png;base64," & base64String
                        Image1.Visible = True
                    End If
                End If
            End Using

            linkPublicarComentario.NavigateUrl = String.Format("Comentarios.aspx?ProductoId={0}", ViewState("productoID"))
            'productos relacionados


            Dim oBLLComentario As New BLLComentario
            Dim ListaComentarios As List(Of Comentarios) = oBLLComentario.ListarComentarios(ViewState("productoID"))
            lblComentariosCantidad.Text = ListaComentarios.Count
            GrillaComentarios.DataSource = ListaComentarios
            GrillaComentarios.DataBind()
        End If
    End Sub

    Protected Sub GrillaComentarios_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles GrillaComentarios.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim divRating As HtmlGenericControl = CType(e.Item.FindControl("divRating"), HtmlGenericControl)
            Dim Puntaje As Integer = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "puntaje"))
            divRating.Style.Add("width", (Puntaje).ToString & "%")
        End If
    End Sub

    Protected Sub lnkAgregarCarrito_Click(sender As Object, e As System.EventArgs) Handles lnkAgregarCarrito.Click
        Dim ProductoId As Integer = Convert.ToInt32(ViewState("productoID"))
        AgregarEnCarrito(CInt(Session("Pedido")), ProductoId, 1)
    End Sub

#Region "Metodos Privados"

    Private Sub AgregarEnCarrito(ByVal PedidoID As Integer, ByVal ProductoID As Integer, ByVal Cantidad As Integer)
        Dim UnItem As New PedidoItem()
        UnItem.cantidad = Cantidad
        UnItem.producto = New Productos()
        UnItem.producto.ID = ProductoID

        If PedidoID = 0 Then
            Dim UnPedido As New Pedido
            UnPedido.cliente = New Cliente
            UnPedido.cliente.ID = CInt(Session("clienteid"))
            UnPedido.Fecha = Now.Date
            UnPedido.FormaEnvio = New FormaEnvio
            UnPedido.FormaEnvio.ID = 1
            UnPedido.formapago = New FormaPago
            UnPedido.formapago.ID = 1
            UnPedido.Items = New List(Of PedidoItem)
            Dim GestorPedido As New BLLPedido()
            GestorPedido.InsertarPedido(UnPedido)
        Else
            Dim GestorPedido As New BLLPedido()
            GestorPedido.InsertarItemPedido(PedidoID, UnItem)
        End If
    End Sub

    Private Sub LLenarListaCatalogoProductos(ByRef UnCatalogo As CatalogoLista, ByVal UnProducto As Productos)
        If UnProducto IsNot Nothing Then
            If UnProducto.ID > 0 Then
                UnCatalogo.CatalogoTipo = CatalogoLista.Tipo.Producto
                UnCatalogo.ID = UnProducto.ID
                UnCatalogo.NombreCorto = UnProducto.NombreCorto
                UnCatalogo.NombreLargo = UnProducto.NombreLargo
                UnCatalogo.Descripcion = UnProducto.Descripcion
                UnCatalogo.precio = UnProducto.precio
                UnCatalogo.CodigoInterno = UnProducto.CodigoInterno
                UnCatalogo.Imagen = UnProducto.Imagen
                UnCatalogo.TiempoEntrega = UnProducto.TiempoEntrega
                UnCatalogo.comentarios = New List(Of Comentarios)
                UnCatalogo.comentarios = UnProducto.comentarios
            End If
        End If
    End Sub

    Private Sub LLenarListaCatalogoServicios(ByRef UnCatalogo As CatalogoLista, ByVal UnServicio As Servicio)
        If UnServicio IsNot Nothing Then
            If UnServicio.ID > 0 Then
                UnCatalogo.CatalogoTipo = CatalogoLista.Tipo.Servicio
                UnCatalogo.ID = UnServicio.ID
                UnCatalogo.NombreCorto = UnServicio.NombreCorto
                UnCatalogo.NombreLargo = UnServicio.NombreLargo
                UnCatalogo.Descripcion = UnServicio.Descripcion
                UnCatalogo.precio = UnServicio.precio
                UnCatalogo.Imagen = Nothing
                UnCatalogo.TiempoEntrega = 0
                UnCatalogo.Duracion = UnServicio.Duracion
                UnCatalogo.Eventual = UnServicio.Eventual
                UnCatalogo.Condiciones = UnServicio.Condiciones
                UnCatalogo.comentarios = New List(Of Comentarios)
            End If


        End If
    End Sub

#End Region


End Class
