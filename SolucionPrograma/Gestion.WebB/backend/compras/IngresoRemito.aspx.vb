
Partial Class compras_IngresoRemito
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PanelMensaje.Visible = False
            Dim ComprobanteID As Integer = Request.QueryString("ComprobanteID")
            ViewState("comprobanteID") = ComprobanteID
            If ComprobanteID > 0 Then
                LLenarGrilla(ComprobanteID)
            Else
                Response.Redirect("~/backend/compras/ordenes.aspx", True)
            End If

        End If
    End Sub

    Protected Sub btnIngresarRemito_Click(sender As Object, e As System.EventArgs) Handles btnIngresarRemito.Click
        Try
            Dim ComprobanteID As Integer = CInt(ViewState("comprobanteID"))
            Dim GestorComprobante As New BLLorden

            Dim UnaOrden As OrdenCompra = GestorComprobante.MostrarOrden(ViewState("comprobanteID"))

            Dim UnRemito As New Remito
            UnRemito.orden = UnaOrden
            UnRemito.Fecha = Now.Date
            UnRemito.Tipo = Comprobante.eTipo.REMITO
            UnRemito.Items = New List(Of RemitoItem)
            UnRemito.Nro = tbNro.Text
            UnRemito.Notas = tbNotas.Text


            For Each Unitem As GridViewRow In GrillaDetalle.Rows
                Dim tbCantidad As TextBox = CType(Unitem.FindControl("tbCantidadRecibida"), TextBox)
                Dim hProductoID As HiddenField = CType(Unitem.FindControl("hProductoID"), HiddenField)

                'inserto el itemremito en una lista temporal
                Dim UnDetalle As New RemitoItem
                UnDetalle.cantidad = CInt(tbCantidad.Text)
                UnDetalle.insumo = New Insumo()
                UnDetalle.insumo.ID = CInt(hProductoID.Value)
                UnDetalle.cantidad = tbCantidad.Text
                UnRemito.Items.Add(UnDetalle)
            Next
            ActualizarItemsOrden(UnaOrden, UnRemito.Items)

            'inserto si la lista de items tiene algo 
            If UnRemito.Items.Count > 0 Then
                Dim GestorRemito As New BLLRemito
                GestorRemito.InsertarRemito(UnRemito)
                PanelMensaje.Visible = True
                lblMensaje.Text = "Se ingresó correctamente."
                tbFecha.Text = ""
                tbNotas.Text = ""
                tbNro.Text = ""
            End If
            LLenarGrilla(ViewState("comprobanteID"))
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.REMITO, Patente.eAccion.ALTA, String.Format("SE CREÓ: {0} - {1}", UnRemito.Nro, UnRemito.orden.proveedor), False)
        Catch ex As Exception
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.REMITO, Patente.eAccion.ALTA, String.Format("ERROR: {0}", ex.Message.ToString()), True)
            Response.Write(ex.Message.ToString())
        End Try
    End Sub

    Private Sub ActualizarItemsOrden(ByVal UnaOrden As OrdenCompra, ByVal ItemsRemito As List(Of RemitoItem))

        For Each UnItemRemito As RemitoItem In ItemsRemito
            Dim UnItemOrden As OrdenCompraItem = UnaOrden.Items.Find(Function(x) x.insumo.ID = UnItemRemito.insumo.ID)

            If UnItemOrden.CantidadRestante >= UnItemRemito.cantidad Then
                'actualizar cantidad
                UnItemOrden.CantidadEntregada += UnItemRemito.cantidad
                If UnItemOrden.CantidadRestante = 0 Then
                    UnItemOrden.Estado = UnItemOrden.eEstado.EntregadoTotal
                End If
                Dim GestorOrden As New BLLorden
                GestorOrden.ActualizarItemOrden(UnaOrden.ID, UnItemOrden)
            Else
                ItemsRemito.Remove(UnItemRemito)
            End If
        Next

    End Sub

    Private Sub LLenarGrilla(ByVal ComprobanteID As Integer)
        Dim GestorOrdenes As New BLLorden
        Dim UnaOrden As New OrdenCompra
        UnaOrden = GestorOrdenes.MostrarOrden(ComprobanteID)
        lblProveedor.Text = UnaOrden.proveedor.Razon
        lblFecha.Text = UnaOrden.Fecha
        lblNroOrden.Text = UnaOrden.ID
        GrillaDetalle.DataSource = UnaOrden.Items
        GrillaDetalle.DataBind()
    End Sub
End Class
