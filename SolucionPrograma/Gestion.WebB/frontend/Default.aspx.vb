Imports System.IO

Partial Class carrito_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PanelMensaje.Visible = False
            Dim GestorPedidos As New BLLPedido()
            Session("pedido") = GestorPedidos.AsignarNroPedido(CInt(Session("clienteid")))
            ViewState("ProdXPagina") = 3
            lblProductosPorPagina.Text = 3
            ViewState("Orden") = 0
            Dim CategoriaId As Integer = 0
            Dim SubCategoriaId As Integer = 0
            ViewState("CategoriaId") = Request.QueryString("cat")
            ViewState("SubCategoriaId") = Request.QueryString("subcat")
            LLenarGrilla(0, CInt(ViewState("Orden")), CInt(ViewState("CategoriaId")), CInt(ViewState("SubCategoriaId")), ViewState("descripcion"))
        End If
    End Sub

    Private Sub lnkBuscar_Load(sender As Object, e As EventArgs) Handles lnkBuscar.Load
        If tbBusqueda.Text.Length > 3 Then
            ViewState("descripcion") = tbBusqueda.Text
            LLenarGrilla(0, CInt(ViewState("Orden")), CInt(ViewState("CategoriaId")), CInt(ViewState("SubCategoriaId")), ViewState("descripcion"))
        End If

    End Sub

#Region "Paginador"
    '--------->>
    'Protected Sub btnPaginaUltima_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPaginaUltima1.Click, btnPaginaUltima2.Click, btnPaginaUltima3.Click, btnPaginaUltima4.Click, btnPaginaUltima5.Click
    '    ViewState("pagina") = 5000
    '    LLenarGrilla(ViewState("pagina"))
    'End Sub
    '---->
    Protected Sub btnPaginaProxima_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPaginaProxima.Click
        Dim Pagina As Integer = CInt(ViewState("pagina"))
        ViewState("pagina") = Pagina + 1
        LLenarGrilla(ViewState("pagina"), ViewState("Orden"), CInt(ViewState("CategoriaId")), CInt(ViewState("SubCategoriaId")), ViewState("descripcion"))
    End Sub
    '---------<
    Protected Sub btnPaginaPrevia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPaginaPrevia.Click
        Dim Pagina As Integer = CInt(ViewState("pagina"))
        If Pagina > 0 Then
            ViewState("pagina") = CInt(ViewState("pagina")) - 1
        End If
        LLenarGrilla(ViewState("pagina"), ViewState("Orden"), CInt(ViewState("CategoriaId")), CInt(ViewState("SubCategoriaId")), ViewState("descripcion"))
    End Sub
    '-----------<<
    'Protected Sub btnPaginaPrimera_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPaginaPrimera1.Click, btnPaginaPrimera2.Click, btnPaginaPrimera3.Click, btnPaginaPrimera4.Click, btnPaginaPrimera5.Click
    '    ViewState("pagina") = 0
    '    LLenarGrilla(ViewState("pagina"))
    'End Sub

#End Region

#Region "Eventos Grilla"

    Protected Sub DataList1_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        If e.CommandName = "AgregarAlCarrito" Then
            Dim ProductoId As Integer = Convert.ToInt32(DataList1.DataKeys(e.Item.ItemIndex))
            AgregarEnCarrito(Session("clienteid"), Session("pedido"), ProductoId, 1)
            PanelMensaje.Visible = True
        End If
    End Sub

    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim control As HtmlControl = CType(e.Item.FindControl("divrating"), HtmlControl)
            Dim Promedio As Integer = DataBinder.Eval(e.Item.DataItem, "puntaje")
            control.Style.Add("width", Promedio.ToString() & "%")
            Dim lblTiempoEntrega As Label = CType(e.Item.FindControl("lblTiempoEntrega"), Label)
            Dim TiempoEntrega As Integer = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TiempoEntrega"))
            lblTiempoEntrega.Style.Add("background-color", "#008000")
            lblTiempoEntrega.ToolTip = TiempoEntrega & " dias"
            Dim id As Integer = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "id"))
            Dim imagenbyte As Byte() = DataBinder.Eval(e.Item.DataItem, "imagen")

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

#End Region

#Region "Metodos Privados"

    Private Sub LLenarGrilla(ByVal NroPagina As Integer, ByVal Orden As Integer, ByVal CategoriaID As Integer, ByVal SubCategoriaID As Integer, ByVal DescProducto As String)
        Dim Lista As New List(Of CatalogoLista)
        Dim ProdXPagina As Integer = CInt(ViewState("ProdXPagina"))

        Dim GestorProductos As New BLLProducto
        Dim ListaProductos As New List(Of Productos)
        ListaProductos = GestorProductos.ListarProducto(0, CategoriaID, SubCategoriaID, DescProducto)
        LLenarListaCatalogoProductos(Lista, ListaProductos)

        'Dim GestorServicios As New BLLServicio
        'Dim ListaServicios As New List(Of Servicio)
        'ListaServicios = GestorServicios.ListarServicios(0, CategoriaID, SubCategoriaID)
        'LLenarListaCatalogoServicios(Lista, ListaServicios)

        Ordenar(Lista, Orden)

        Dim TotalPaginas As Integer = 0

        If (Lista.Count Mod ProdXPagina = 0) Then
            TotalPaginas = (Lista.Count / ProdXPagina)
        Else
            TotalPaginas = Fix(Lista.Count / ProdXPagina) + 1
        End If

        'si tiene una pagina no muestro el paginador
        If TotalPaginas > 1 Then
            PanelPaginador.Visible = True
            If NroPagina > TotalPaginas Then
                ViewState("pagina") = TotalPaginas - 1
            ElseIf NroPagina = TotalPaginas Then
                ViewState("pagina") = NroPagina - 1
            End If

            Dim PaginaTexto As Integer = CInt(ViewState("pagina")) + 1
            lblPagina.Text = String.Format("Página {0} de {1}", PaginaTexto, TotalPaginas)
            Dim pg As New PagedDataSource()
            pg.DataSource = Lista
            pg.AllowPaging = True
            pg.PageSize = ProdXPagina
            pg.CurrentPageIndex = CInt(ViewState("pagina"))
            DataList1.DataSource = pg
        Else
            DataList1.DataSource = Lista
            PanelPaginador.Visible = False
        End If
        DataList1.DataBind()
    End Sub


    Private Sub AgregarEnCarrito(ByVal Cuenta As Integer, ByVal PedidoID As Integer, ByVal ProductoID As Integer, ByVal Cantidad As Integer)
        Dim UnItem As New PedidoItem()
        UnItem.cantidad = Cantidad
        UnItem.producto = New Productos()
        UnItem.producto.ID = ProductoID

        Dim GestorPedido As New BLLPedido()

        If PedidoID = 0 Then
            Dim UnPedido As New Pedido
            UnPedido.cliente = New Cliente()
            UnPedido.cliente.ID = Cuenta
            UnPedido.EstadoPedido = 1
            UnPedido.Fecha = Now.Date
            'UnPedido.Notas = ""
            UnPedido.FormaEnvio = New FormaEnvio
            UnPedido.FormaEnvio.ID = 1
            UnPedido.formapago = New FormaPago
            UnPedido.formapago.ID = 1
            UnPedido.Items = New List(Of PedidoItem)
            UnPedido.Items.Add(UnItem)
            PedidoID = GestorPedido.InsertarPedido(UnPedido)
        Else

        End If
        GestorPedido.InsertarItemPedido(PedidoID, UnItem)
    End Sub

    Private Sub Ordenar(ByRef Lista As List(Of CatalogoLista), ByVal TipoOrden As Integer)
        If TipoOrden = 1 Then
            Lista = Lista.OrderBy(Function(x) x.NombreCorto).ToList()
        ElseIf TipoOrden = 2 Then
            Lista = Lista.OrderByDescending(Function(x) x.NombreCorto).ToList()
        ElseIf TipoOrden = 3 Then
            Lista = Lista.OrderBy(Function(x) x.precio.ValorFinal).ToList()
        ElseIf TipoOrden = 4 Then
            Lista = Lista.OrderByDescending(Function(x) x.precio.ValorFinal).ToList()
        ElseIf TipoOrden = 5 Then
            'Lista.OrderBy(Function(x) x.)
        End If
    End Sub

    Private Sub LLenarListaCatalogoProductos(ByRef Lista As List(Of CatalogoLista), ByVal ListaProductos As List(Of Productos))
        For Each UnProducto As Productos In ListaProductos
            Dim UnCatalogo As New CatalogoLista
            UnCatalogo.CatalogoTipo = CatalogoLista.Tipo.Producto
            UnCatalogo.ID = UnProducto.ID
            UnCatalogo.NombreCorto = UnProducto.NombreCorto
            UnCatalogo.NombreLargo = UnProducto.NombreLargo
            UnCatalogo.Descripcion = UnProducto.Descripcion
            UnCatalogo.precio = UnProducto.precio
            UnCatalogo.Imagen = UnProducto.Imagen
            UnCatalogo.TiempoEntrega = UnProducto.TiempoEntrega
            Lista.Add(UnCatalogo)
        Next
    End Sub

    'Private Sub LLenarListaCatalogoServicios(ByRef Lista As List(Of CatalogoLista), ByVal ListaServicios As List(Of Servicio))
    '    For Each UnProducto As Servicio In ListaServicios
    '        Dim UnCatalogo As New CatalogoLista
    '        UnCatalogo.CatalogoTipo = CatalogoLista.Tipo.Servicio
    '        UnCatalogo.ID = UnProducto.ID
    '        UnCatalogo.NombreCorto = UnProducto.NombreCorto
    '        UnCatalogo.NombreLargo = UnProducto.NombreLargo
    '        UnCatalogo.Descripcion = UnProducto.Descripcion
    '        UnCatalogo.precio = UnProducto.precio
    '        'UnCatalogo.Imagen = UnProducto.Imagen
    '        'UnCatalogo.TiempoEntrega = UnProducto.TiempoEntrega
    '        UnCatalogo.Imagen = Nothing
    '        UnCatalogo.TiempoEntrega = 0

    '        UnCatalogo.Duracion = UnProducto.Duracion
    '        UnCatalogo.Eventual = UnProducto.Eventual
    '        UnCatalogo.Condiciones = UnProducto.Condiciones

    '        Lista.Add(UnCatalogo)
    '    Next
    'End Sub

#End Region

#Region "Productos por pagina"

    Private Sub lnkProductoPorPagina1_Click(sender As Object, e As EventArgs) Handles lnkProductoPorPagina1.Click
        ViewState("ProdXPagina") = 2
        lblProductosPorPagina.Text = 2
        LLenarGrilla(ViewState("pagina"), ViewState("Orden"), CInt(ViewState("CategoriaId")), CInt(ViewState("SubCategoriaId")), ViewState("descripcion"))
    End Sub

    Private Sub lnkProductoPorPagina2_Click(sender As Object, e As EventArgs) Handles lnkProductoPorPagina2.Click
        ViewState("ProdXPagina") = 3
        lblProductosPorPagina.Text = 3
        LLenarGrilla(ViewState("pagina"), ViewState("Orden"), CInt(ViewState("CategoriaId")), CInt(ViewState("SubCategoriaId")), ViewState("descripcion"))
    End Sub

#End Region

#Region "Ordenamiento"

    Private Sub lnkOrdAlfAsc_Click(sender As Object, e As EventArgs) Handles lnkOrdAlfAsc.Click
        ViewState("Orden") = 1
        'ViewState("pagina")
        lblOrden.Text = "Nombre: A-Z"
        LLenarGrilla(0, ViewState("Orden"), CInt(ViewState("CategoriaId")), CInt(ViewState("SubCategoriaId")), ViewState("descripcion"))
    End Sub
    Private Sub lnkOrdAlfDesc_Click(sender As Object, e As EventArgs) Handles lnkOrdAlfDesc.Click
        ViewState("Orden") = 2
        'ViewState("pagina")
        lblOrden.Text = "Nombre: Z-A "
        LLenarGrilla(0, ViewState("Orden"), CInt(ViewState("CategoriaId")), CInt(ViewState("SubCategoriaId")), ViewState("descripcion"))
    End Sub
    Private Sub lnkPrecAsc_Click(sender As Object, e As EventArgs) Handles lnkPrecAsc.Click
        ViewState("Orden") = 3
        'ViewState("pagina")
        lblOrden.Text = "Precio: Menor a Mayor"
        LLenarGrilla(0, ViewState("Orden"), CInt(ViewState("CategoriaId")), CInt(ViewState("SubCategoriaId")), ViewState("descripcion"))
    End Sub
    Private Sub lnkPrecDesc_Click(sender As Object, e As EventArgs) Handles lnkPrecDesc.Click
        ViewState("Orden") = 4
        'ViewState("pagina")
        lblOrden.Text = "Precio: Mayor a Menor"
        LLenarGrilla(0, ViewState("Orden"), CInt(ViewState("CategoriaId")), CInt(ViewState("SubCategoriaId")), ViewState("descripcion"))
    End Sub
    Private Sub lnkCreacion_Click(sender As Object, e As EventArgs) Handles lnkCreacion.Click
        ViewState("Orden") = 5
        'ViewState("pagina")
        lblOrden.Text = "Creación"
        LLenarGrilla(0, ViewState("Orden"), CInt(ViewState("CategoriaId")), CInt(ViewState("SubCategoriaId")), ViewState("descripcion"))
    End Sub

#End Region

End Class
