
Imports Tsu.ProviderOra
Imports Tsu.Utilidades

Namespace Tsu.Paginas

    Partial Class controles_grillaPedidos
        Inherits System.Web.UI.UserControl

#Region "Campos y propiedades"

        Public Event ActualizoCabecera(ByVal Cuenta As Integer, ByVal Campania As Integer)

        Dim _zona As Integer
        Dim _cuenta As Integer
        Dim _campania As Integer
        Dim _vereliminar As Boolean
        Dim _cuentacarga As Integer
        Dim _verrestaurar As Boolean
        Dim _cantidadingresos As Integer
        Dim _tipousuario As String

        Public Property zona() As Integer
            Get
                Return _zona
            End Get
            Set(ByVal value As Integer)
                _zona = value
            End Set
        End Property

        Public Property cuenta() As Integer
            Get
                Return _cuenta
            End Get
            Set(ByVal value As Integer)
                _cuenta = value
            End Set
        End Property

        Public Property campania() As Integer
            Get
                Return _campania
            End Get
            Set(ByVal value As Integer)
                _campania = value
            End Set
        End Property

        Public Property vereliminar() As Boolean
            Get
                Return _vereliminar
            End Get
            Set(ByVal value As Boolean)
                _vereliminar = value
            End Set
        End Property

        Public Property cuentacarga() As Integer
            Get
                Return _cuentacarga
            End Get
            Set(ByVal value As Integer)
                _cuentacarga = value
            End Set
        End Property

        Public Property verrestaurar() As Boolean
            Get
                Return _verrestaurar
            End Get
            Set(ByVal value As Boolean)
                _verrestaurar = value
            End Set
        End Property

        Public Property cantidadingresos() As Integer
            Get
                Return _cantidadingresos
            End Get
            Set(ByVal value As Integer)
                _cantidadingresos = value
            End Set
        End Property

        Public Property tipousuario() As String
            Get
                Return _tipousuario
            End Get
            Set(ByVal value As String)
                _tipousuario = value
            End Set
        End Property
#End Region

#Region "Comunes"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If vereliminar = True Then
                btnEliminar.Visible = False
            End If
            If verrestaurar = True Then
                btnRestaurar.Visible = True
            Else
                btnRestaurar.Visible = False
            End If
        End Sub

#Region "Metodos Publicos"
        Public Sub Ordenar()
            ListaProductos.Sort("fechaultimo,horaultimo", SortDirection.Ascending)
        End Sub
        Public Sub LLenar()
            Me.ListaProductos.DataBind()
        End Sub
#End Region

#Region "Eventos de la grilla"

        Protected Sub ListaProductos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles ListaProductos.RowCommand
            If e.CommandName = "BorrarItem" Or e.CommandName = "ActualizaItem" Then
                Try
                    Dim lb As ImageButton = CType(e.CommandSource, ImageButton)
                    Dim gvRow As GridViewRow = lb.BindingContainer

                    Dim oPedidoD As PedidosD = LLenarObjetoItem(gvRow)
                    Dim oPedidosDMapOra As New PedidosDMapOra()

                    If e.CommandName = "BorrarItem" Then
                        oPedidosDMapOra.BorrarItem(oPedidoD)
                        LLenar()
                    ElseIf e.CommandName = "ActualizaItem" Then
                        Dim tb As New TextBox
                        tb = CType(gvRow.FindControl("tbCantidadSolicitadaGrilla"), TextBox)
                        oPedidoD.cantidadsolicitada = Convert.ToInt32(tb.Text)
                        oPedidosDMapOra.UpdateItemReemplaza(oPedidoD)
                        ListaProductos.EditIndex = -1
                    End If
                    RaiseEvent ActualizoCabecera(oPedidoD.cuenta, oPedidoD.campania)
                Catch ex As Exception
                    UtilLogBase.Guardar(LogBase.TipoLog.DatoIncorrecto, cuenta, String.Format("{0}/borrar/actualizar:{1}", Me.AppRelativeVirtualPath.ToString(), ex.Message.ToString()))
                End Try
            End If
        End Sub

        Private Function LLenarObjetoItem(ByVal gvRow As GridViewRow) As PedidosD
            Dim oPedidoD As New PedidosD()
            oPedidoD.codigoproducto = Convert.ToInt32(ListaProductos.DataKeys(gvRow.RowIndex)(0))
            oPedidoD.campania = Convert.ToInt32(ListaProductos.DataKeys(gvRow.RowIndex)(1))
            oPedidoD.cuenta = Convert.ToInt32(ListaProductos.DataKeys(gvRow.RowIndex)(2))
            oPedidoD.zona = Convert.ToInt32(ListaProductos.DataKeys(gvRow.RowIndex)(3))
            oPedidoD.motivocr = Convert.ToInt32(ListaProductos.DataKeys(gvRow.RowIndex)(4))
            oPedidoD.tipocr = ListaProductos.DataKeys(gvRow.RowIndex)(5).ToString()
            oPedidoD.campaniaorigen = Convert.ToInt32(ListaProductos.DataKeys(gvRow.RowIndex)(6))
            oPedidoD.tiponc = ListaProductos.DataKeys(gvRow.RowIndex)(7).ToString()
            oPedidoD.cuentacarga = cuentacarga
            oPedidoD.tipousuario = tipousuario
            Return oPedidoD
        End Function

        Protected Sub ListaProductos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles ListaProductos.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                'cuento
                ViewState("iTotalUnidades") += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "cantidadsolicitada"))
            ElseIf e.Row.RowType = DataControlRowType.Footer Then
                'muestro el total
                Me.Summary.Text = ViewState("iTotalUnidades").ToString()
            ElseIf e.Row.RowType = DataControlRowType.Header Then
                'lo vacio la primera vez
                ViewState("iTotalUnidades") = 0
            ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then
                'si la grilla esta vacia me reinicia el contador a 0
                ViewState("iTotalUnidades") = 0
                Me.Summary.Text = ViewState("iTotalUnidades").ToString()
            End If
            If e.Row.RowState = 5 Or e.Row.RowState = 4 Then
                Dim tb As New TextBox
                tb = CType(e.Row.FindControl("tbCantidadSolicitadaGrilla"), TextBox)
                tb.Focus()
                'tb.BackColor = Drawing.Color.SkyBlue
                Dim CSM As ClientScriptManager = Page.ClientScript
                Dim strJS As String = "document.getElementById('" & tb.ClientID & "').select();"
                CSM.RegisterClientScriptBlock(Me.GetType(), "onload", "window.onload = function() { " & strJS & " }", True)
            End If
        End Sub

        Protected Sub ODSdetallepedido_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ODSdetallepedido.Selecting
            e.InputParameters("iCuenta") = cuenta
            e.InputParameters("iCampania") = campania
        End Sub

#End Region

#Region "Eliminar y Restaurar"

        ''' <summary>
        ''' Restaurar todo el pedido
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub btnRestaurar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRestaurar.Click
            Try
                If Not (HttpContext.Current.User.IsInRole("U")) Then
                    Throw New Exception("Error de permiso, restaurar pedido grilla. No es perfil U.")
                End If
                Dim oPedidosDMapOra As New PedidosDMapOra()
                Dim oPedidosD As New PedidosD
                oPedidosD.zona = zona
                oPedidosD.campania = campania
                oPedidosD.cuenta = cuenta
                oPedidosD.cuentacarga = cuentacarga
                oPedidosD.tipousuario = tipousuario
                'restaura pedido
                Dim oRestaurarPedidos As New fachadaRestaurarPedidos()
                oRestaurarPedidos.Restaurar(oPedidosD)
                Me.ListaProductos.DataBind()
                'actualiza cabecera
                RaiseEvent ActualizoCabecera(oPedidosD.cuenta, oPedidosD.campania)
                UtilLogBase.GuardarEvento(LogBase.TipoLogEvento.RestauraPedido, cuenta, String.Format("Restaurar Pedido(grilla), Cuenta Carga:{0}", Session("cuenta")))
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.DatoIncorrecto, cuenta, String.Format("{0}/restaurar:{1}", Me.AppRelativeVirtualPath.ToString(), ex.Message.ToString()))
                Response.Redirect("~/Logout.aspx?salir=error")
            End Try
        End Sub

        ''' <summary>
        ''' Eliminar todo el pedido
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEliminar.Click
            Try
                Dim oPedidosMapOra As New PedidosDMapOra()
                Dim oPedidosD As New PedidosD
                oPedidosD.zona = zona
                oPedidosD.campania = campania
                oPedidosD.cuenta = cuenta
                oPedidosD.cuentacarga = cuentacarga
                oPedidosD.tipousuario = tipousuario
                oPedidosMapOra.BorrarTodo(oPedidosD)
                RaiseEvent ActualizoCabecera(cuenta, campania)
                Me.ListaProductos.DataBind()
                UtilLogBase.GuardarEvento(LogBase.TipoLogEvento.ElimPedido, cuenta, String.Format("Elimina todo el pedido de la cuenta {0}, Cta. Carga: {1}, Campania: {2}", cuenta, cuentacarga, campania))
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.DatoIncorrecto, cuenta, Me.AppRelativeVirtualPath.ToString() & "/eliminar:" & ex.Message.ToString())
                Response.Redirect("~/Logout.aspx?salir=error")
            End Try
        End Sub

#End Region

#End Region

#Region "ordenamiento"
        Protected WithEvents botonCodigoAsc As ImageButton
        Protected WithEvents botonCodigoDesc As ImageButton
        Protected WithEvents botonProductoAsc As ImageButton
        Protected WithEvents botonProductoDesc As ImageButton
        Protected WithEvents botonMotivoAsc As ImageButton
        Protected WithEvents botonMotivoDesc As ImageButton
        Protected WithEvents botonTipoAsc As ImageButton
        Protected WithEvents botonTipoDesc As ImageButton
        Protected WithEvents botonCampaniaAsc As ImageButton
        Protected WithEvents botonCampaniaDesc As ImageButton
        Protected WithEvents botonPaginaAsc As ImageButton
        Protected WithEvents botonPaginaDesc As ImageButton

        Protected Sub btnCodigoDesc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCodigoDesc.Click
            ListaProductos.Sort("PedidosD.codigoproducto", SortDirection.Descending)
        End Sub
        Protected Sub btnCodigoAsc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCodigoAsc.Click
            ListaProductos.Sort("PedidosD.codigoproducto", SortDirection.Ascending)
        End Sub
        Protected Sub btnProductoDesc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonProductoDesc.Click
            ListaProductos.Sort("descripcionproducto", SortDirection.Descending)
        End Sub
        Protected Sub btnProductoAsc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonProductoAsc.Click
            ListaProductos.Sort("descripcionproducto", SortDirection.Ascending)
        End Sub
        Protected Sub btnMotivoDesc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonMotivoDesc.Click
            ListaProductos.Sort("motivocr", SortDirection.Descending)
        End Sub
        Protected Sub btnMotivoAsc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonMotivoAsc.Click
            ListaProductos.Sort("motivocr", SortDirection.Ascending)
        End Sub
        Protected Sub btnTipoDesc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonTipoDesc.Click
            ListaProductos.Sort("tiponc", SortDirection.Descending)
        End Sub
        Protected Sub btnTipoAsc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonTipoAsc.Click
            ListaProductos.Sort("tiponc", SortDirection.Ascending)
        End Sub
        Protected Sub btnCampaniaDesc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCampaniaDesc.Click
            ListaProductos.Sort("campaniaorigen", SortDirection.Descending)
        End Sub
        Protected Sub btnCampaniaAsc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCampaniaAsc.Click
            ListaProductos.Sort("campaniaorigen", SortDirection.Ascending)
        End Sub
        Protected Sub btnPaginaAsc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonPaginaAsc.Click
            ListaProductos.Sort("paginafolleto", SortDirection.Ascending)
        End Sub
        Protected Sub btnPaginaDesc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonPaginaDesc.Click
            ListaProductos.Sort("paginafolleto", SortDirection.Descending)
        End Sub
#End Region

        ''' <summary>
        ''' Cuando es motivo 5, tambien se pone en la grilla el producto facturado
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function llenarProductoFacturado(ByVal obj As Object) As String
            Try
                Dim sRetorno As String = "-"
                If obj IsNot Nothing Then
                    If Not obj.ToString = "0" Then
                        Dim oproductoMap As New ProductosMapOra()
                        Dim oProducto As Productos = oproductoMap.MostrarById(Convert.ToInt32(obj), campania, ProductosMapOra.busqueda.CambiosyReclamos)
                        If oProducto IsNot Nothing Then
                            sRetorno = oProducto.descripcionproducto
                        End If
                    End If

                End If

                Return sRetorno
            Catch ex As Exception
                Throw New Exception(ex.Message.ToString())
            End Try

        End Function

    End Class
End Namespace