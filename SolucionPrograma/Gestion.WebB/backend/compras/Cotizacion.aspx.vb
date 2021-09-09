
Partial Class backend_compras_Proveedores
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim ReposicionID As Integer = Request.QueryString("ReposicionID")
            If CInt(ReposicionID) > 0 Then
                ViewState("ReposicionID") = ReposicionID
                LLenarGrilla(ReposicionID)
            Else
                Response.Redirect("~/backend/Compras/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btnComprar_Click(sender As Object, e As EventArgs) Handles btnComprar.Click
        Dim ListaOrdenes As New List(Of OrdenCompra)

        For Each fila As GridViewRow In GrillaCotizacion.Rows
            Dim tbComprar As TextBox = CType(fila.FindControl("tbComprar"), TextBox)
            Dim hProductoID As HiddenField = CType(fila.FindControl("hProductoID"), HiddenField)
            Dim comboProveedor As DropDownList = CType(fila.FindControl("comboCotizacion"), DropDownList)

            If IsNumeric(tbComprar.Text) Then
                ArmarOrdenDeCompra(ListaOrdenes, CInt(ViewState("ReposicionID")), hProductoID.Value, comboProveedor.SelectedValue, tbComprar.Text)
            End If 'fin del isNumeric
        Next
        Dim GestorReposicion As New BLLReposicion
        Dim UnPedidoReposicion As Reposicion = GestorReposicion.MostrarReposicion(CInt(ViewState("ReposicionID")))

        For Each UnaOrden As OrdenCompra In ListaOrdenes
            ActualizarItemsReposicion(UnPedidoReposicion, UnaOrden.Items)
        Next

        If ListaOrdenes.Count > 0 Then
            For Each UnComprobante As Comprobante In ListaOrdenes
                Dim GestorComprobante As New BLLorden
                GestorComprobante.InsertarOrden(UnComprobante)
                LLenarGrilla(CInt(ViewState("ReposicionID")))
            Next
        End If

    End Sub

    Private Sub ArmarOrdenDeCompra(ByRef ListaOrdenes As List(Of OrdenCompra), ByVal PedidoID As Integer, ByVal ProductoID As Integer, ByVal ProveedorID As Integer, ByVal Cantidad As Integer)

        If ProveedorID > 0 Then
            'busco la orden en la lista, y si no esta la creo.
            Dim Indice As Integer = ListaOrdenes.FindIndex(Function(x) x.proveedor.ID = ProveedorID)
            Dim UnaOrden As New OrdenCompra
            If Indice = -1 Then
                UnaOrden.proveedor = New Proveedor
                UnaOrden.proveedor.ID = ProveedorID
                UnaOrden.Notas = ""
                UnaOrden.Items = New List(Of OrdenCompraItem)
                UnaOrden.Fecha = Now.Date
                UnaOrden.reposicion = New Reposicion
                UnaOrden.reposicion.ID = PedidoID
                ListaOrdenes.Add(UnaOrden)
            Else
                UnaOrden = ListaOrdenes.Item(Indice)
            End If

            Dim GestorCotizacion As New BLLCotizacion
            Dim UnaCotizacion As Cotizacion = GestorCotizacion.ListarCotizacion(PedidoID, ProductoID, ProveedorID).First()
            Dim Item As New OrdenCompraItem()
            Item.cantidad = Cantidad
            Item.CantidadEntregada = 0
            Item.iva = New IVA
            Item.iva.ID = UnaCotizacion.iva.ID
            Item.precio = UnaCotizacion.valor
            Item.insumo = New Insumo()
            Item.insumo.ID = ProductoID

            UnaOrden.Items.Add(Item)
        End If
    End Sub

    Private Sub ActualizarItemsReposicion(ByVal UnPedido As Reposicion, ByRef ListaItemsOrden As List(Of OrdenCompraItem))
        For Each UnItemOrden As OrdenCompraItem In ListaItemsOrden
            Dim UnItemReposicion As ReposicionItem = UnPedido.Items.Find(Function(x) x.insumo.ID = UnItemOrden.insumo.ID)

            If UnItemReposicion.cantidadRestante >= UnItemOrden.cantidad Then
                UnItemReposicion.cantidadRestante -= UnItemOrden.cantidad
                If UnItemReposicion.cantidadRestante = 0 Then
                    UnItemReposicion.estado = ReposicionItem.eEstado.Comprado
                End If

                Dim GestorPedido As New BLLReposicion
                GestorPedido.ActualizarItemReposicion(UnPedido.ID, UnItemReposicion)
            Else
                ListaItemsOrden.Remove(UnItemOrden)
            End If
        Next

    End Sub

#Region "Eventos de la grilla"

    Protected Sub GrillaCotizacion_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrillaCotizacion.RowCommand
        If e.CommandName = "Cotizar" Then
            Dim s As String = "$('#myModal').modal('show');"
            ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)

            Dim InsumoId As Integer = CInt(e.CommandArgument)
            ViewState("InsumoID") = InsumoId
            LLenar(ViewState("InsumoID"), ViewState("ReposicionID"))
        End If
    End Sub

    Protected Sub GrillaCotizacion_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrillaCotizacion.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblPrioridad As Label = CType(e.Row.FindControl("lblPrioridad"), Label)
            Dim Prioridad As Integer = CInt(DataBinder.Eval(e.Row.DataItem, "prioridad"))
            If Prioridad = ReposicionItem.ePrioridad.Baja Then
                lblPrioridad.Text = "Baja"
                lblPrioridad.ForeColor = Drawing.Color.Green
            ElseIf Prioridad = ReposicionItem.ePrioridad.Media Then
                lblPrioridad.Text = "Media"
                lblPrioridad.ForeColor = Drawing.Color.Orange
            Else
                lblPrioridad.Text = "Alta"
                lblPrioridad.ForeColor = Drawing.Color.Red
            End If

            Dim ProductoID As Integer = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "insumo.id"))
            Dim ReposicionID As Integer = ViewState("ReposicionID")
            Dim GestorCotizacion As New BLLCotizacion()
            Dim ListaCotizaciones As List(Of Cotizacion) = GestorCotizacion.ListarCotizacion(ReposicionID, ProductoID, 0)

            Dim comboProveedor As DropDownList = CType(e.Row.FindControl("comboCotizacion"), DropDownList)
            If ListaCotizaciones.Count > 0 Then
                For Each UnaCotizacion As Cotizacion In ListaCotizaciones
                    comboProveedor.Items.Add(New ListItem(String.Format(" {0} {1:c} ", UnaCotizacion.proveedor.Razon, UnaCotizacion.ValorUnitarioConImpuestos), UnaCotizacion.proveedor.ID))
                Next
            Else
                comboProveedor.Items.Add(New ListItem(String.Format(" {0} ", "Sin cotizar"), 0))
                comboProveedor.Enabled = False
            End If
        End If

    End Sub

    'Protected Sub GrillaReposicion_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrillaCotizacion.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        
    '    End If
    'End Sub

#End Region

#Region "Metodos Privados"
    Private Sub LLenarGrilla(ByVal ReposicionID As Integer)

        Dim GestorCompras As New BLLReposicion()
        Dim UnaReposicion As Reposicion = GestorCompras.MostrarReposicion(ReposicionID)
        If UnaReposicion.Estado = Reposicion.eEstado.enviado Then


            lblNro.Text = UnaReposicion.ID
            lblFecha.Text = UnaReposicion.Fecha
            lblNotas.Text = UnaReposicion.Notas

            'If UnaReposicion.Estado = Reposicion.eEstado.creado Then
            '    lblEstado.Text = "Creado"
            'ElseIf UnaReposicion.Estado = Reposicion.eEstado.enviado Then
            '    lblEstado.Text = "Enviado"
            'ElseIf UnaReposicion.Estado = Reposicion.eEstado.comprado Then

            'End If

            Dim Items As List(Of ReposicionItem) = GestorCompras.ListarReposicionItem(ReposicionID)
            GrillaCotizacion.DataSource = Items
            GrillaCotizacion.DataBind()
        Else
            Response.Redirect("default.aspx")
        End If
    End Sub


#End Region

#Region "MODAL"
    Public Sub LLenar(ByVal InsumoID As Integer, ByVal ReposicionID As Integer)


        Dim GestorProveedores As New BLLProveedor
        comboProveedor.DataTextField = "razon"
        comboProveedor.DataValueField = "id"
        comboProveedor.DataSource = GestorProveedores.ListarProveedores("", 0)
        comboProveedor.DataBind()
        'Else
        '    '$('#myModal').modal({ show: false})
        '    Page.ClientScript.RegisterOnSubmitStatement(Me.GetType(), "closePage", "$('#myModal').modal({ show: false})")
        'End If

    End Sub

    Protected Sub btnCotizacion_Click(sender As Object, e As System.EventArgs) Handles btnCotizacion.Click
        Dim GestorCotizacion As New BLLCotizacion
        GestorCotizacion.IngresarCotizacion(CInt(ViewState("ReposicionID")), CInt(ViewState("InsumoID")), comboProveedor.SelectedValue, 10, 20, Now.Date, 10, tbValorUnitario.Text, comboIVA.SelectedValue, 120, 1)
        Page.ClientScript.RegisterOnSubmitStatement(Me.GetType(), "closePage", "$('#myModal').modal({ show: false})")
        LLenarGrilla(CInt(ViewState("ReposicionID")))
        tbValorUnitario.Text = ""
    End Sub

#End Region

End Class
