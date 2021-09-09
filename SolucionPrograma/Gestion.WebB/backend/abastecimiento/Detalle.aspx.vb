
Partial Class compras_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim ReposicionId As Integer = Request.QueryString("ReposicionID")
            If ReposicionId > 0 Then
                ViewState("reposicionID") = ReposicionId
                Dim GestorCategorias As New BLLCategoria
                comboCategoria.Items.Insert(0, New ListItem("--Seleccionar--", "0"))
                comboCategoria.DataValueField = "id"
                comboCategoria.DataTextField = "descripcion"
                comboCategoria.DataSource = GestorCategorias.MostrarCategorias(BLLCategoria.TipoCatalogo.Insumo)
                comboCategoria.DataBind()
                LLenarGrilla(ViewState("reposicionID"))
            Else
                Response.Redirect("default.aspx")
            End If
        End If
    End Sub

    Private Sub LLenarGrilla(ByVal PedidoID As Integer)
        Dim GestorReposicion As New BLLReposicion
        Dim UnaReposicion As Reposicion = GestorReposicion.MostrarReposicion(PedidoID)

        lblFecha.Text = UnaReposicion.Fecha
        lblNotas.Text = UnaReposicion.Notas
        lblNroPedido.Text = UnaReposicion.ID

        If UnaReposicion.Estado <> Reposicion.eEstado.creado Then
            PanelCargarItem.Visible = False
            btnCerrarPedido.Visible = False
        End If
        GrillaReposicion.DataSource = UnaReposicion.Items
        GrillaReposicion.DataBind()
    End Sub

#Region "Cambio de combos"
    Protected Sub comboCategoria_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles comboCategoria.SelectedIndexChanged
        ComboSubCategoria.Items.Clear()
        ComboSubCategoria.Items.Insert(0, New ListItem("--Seleccionar--", "0"))
        Dim GestorSubCategoria As New BLLSubCategoria
        comboSubCategoria.DataTextField = "descripcion"
        comboSubCategoria.DataValueField = "id"
        comboSubCategoria.DataSource = GestorSubCategoria.MostrarSubCategorias(comboCategoria.SelectedValue)
        ComboSubCategoria.DataBind()

    End Sub

    Protected Sub ComboSubCategoria_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboSubCategoria.SelectedIndexChanged
        comboproducto.Items.Clear()
        Dim GestorInsumos As New BLLInsumo
        comboproducto.DataValueField = "id"
        comboproducto.DataTextField = "nombrecorto"
        comboproducto.DataSource = GestorInsumos.ListarInsumos(0, ComboSubCategoria.SelectedValue)
        comboproducto.DataBind()
    End Sub

#End Region

    Protected Sub btnAgregar_Click(sender As Object, e As System.EventArgs) Handles btnAgregar.Click
        If comboproducto.SelectedValue <> 0 Then
            Try
                Dim GestorAbastecimiento As New BLLReposicion
                Dim unItemAbastecimiento As New ReposicionItem
                unItemAbastecimiento.insumo = New Insumo()
                unItemAbastecimiento.insumo.ID = comboproducto.SelectedValue
                unItemAbastecimiento.cantidadPedida = tbCantidad.Text
                unItemAbastecimiento.Especificacion = tbEspecificacion.Text
                unItemAbastecimiento.Prioridad = comboPrioridad.SelectedValue
                unItemAbastecimiento.cantidadRestante = CInt(tbCantidad.Text)
                unItemAbastecimiento.cantidadEntregada = 0
                GestorAbastecimiento.InsertarItemReposicion(CInt(ViewState("reposicionID")), unItemAbastecimiento)
                LLenarGrilla(CInt(ViewState("reposicionID")))
                tbCantidad.Text = ""
                tbEspecificacion.Text = ""
                Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.ABASTECIMIENTO, Patente.eAccion.PEDIRINSUMO, String.Format("SE AGREGO INSUMO AL PEDIDO: {0} - {1} ", CInt(ViewState("reposicionID")), comboproducto.SelectedItem), False)
            Catch ex As Exception
                Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.ABASTECIMIENTO, Patente.eAccion.PEDIRINSUMO, String.Format("ERROR AL AGREGAR INSUMO: PEDIDO:{0} - {1}", CInt(ViewState("reposicionID")), ex.Message.ToString()), True)
            End Try
        End If
    End Sub

    Protected Sub GrillaReposicion_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrillaReposicion.RowDataBound
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
        End If
    End Sub

    Protected Sub btnCerrarPedido_Click(sender As Object, e As EventArgs) Handles btnCerrarPedido.Click
        Try
            Dim GestorAbastecimiento As New BLLReposicion
            GestorAbastecimiento.ActualizarEstadoReposicion(CInt(ViewState("reposicionID")), Reposicion.eEstado.enviado)
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.ABASTECIMIENTO, Patente.eAccion.ENVIARPEDIDO, String.Format("SE ENVIÓ EL PEDIDO: {0} ", CInt(ViewState("reposicionID"))), False)
            Response.Redirect("default.aspx")
        Catch ex As System.Threading.ThreadAbortException

        Catch ex As Exception
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.ABASTECIMIENTO, Patente.eAccion.ENVIARPEDIDO, String.Format("ERROR AL ENVIAR EL PEDIDO:{0} - {1}", CInt(ViewState("reposicionID")), ex.Message.ToString()), True)
        End Try

    End Sub


End Class
