
Partial Class aplicacion_Catalogo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            comboSubCategoria.Items.Insert(0, New ListItem("--Seleccionar--", "0"))
            LLenarComboCategoria()
            Dim InsumoID As Integer = 0
            InsumoID = Request.QueryString("InsumoID")
            PanelMensaje.Visible = False

            If InsumoID > 0 Then
                ViewState("InsumoID") = InsumoID
                LLenarInsumo(InsumoID)
                btnCrear.Visible = False
                btnModificar.Visible = True
            End If
        End If
    End Sub

    Protected Sub comboCategoria_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles comboCategoria.SelectedIndexChanged
        LLenarComboSubCategoria(comboCategoria.SelectedValue)
    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As System.EventArgs) Handles btnCrear.Click
        Try
            Dim UnInsumo As New Insumo()
            UnInsumo.Descripcion = tbDetalle.Text
            UnInsumo.NombreLargo = tbNombreLargo.Text
            UnInsumo.NombreCorto = tbNombreCorto.Text
            UnInsumo.SubCategoriaID = comboSubCategoria.SelectedValue
            UnInsumo.Estado = True
            UnInsumo.stock = New Stock
            UnInsumo.stock.Minimo = CInt(tbStockMin.Text)
            UnInsumo.stock.Maximo = CInt(tbStockMax.Text)
            UnInsumo.stock.Actual = CInt(tbStockActual.Text)

            Dim GestorInsumo As New BLLInsumo
            GestorInsumo.InsertarInsumo(UnInsumo)


            tbDetalle.Text = ""
            tbNombreLargo.Text = ""
            tbNombreCorto.Text = ""
            tbStockMin.Text = ""
            tbStockMax.Text = ""
            tbStockActual.Text = ""

            PanelMensaje.Visible = True
            lblMensaje.Text = "Se insertó correctamente."
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.INSUMO, Patente.eAccion.ALTA, String.Format("SE CREÓ CORRECTAMENTE: {0}", UnInsumo.NombreCorto), False)
        Catch ex As Exception
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.INSUMO, Patente.eAccion.ALTA, String.Format("ERROR: {0}", ex.Message.ToString()), True)
        End Try
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As System.EventArgs) Handles btnModificar.Click
        Try
            Dim UnInsumo As New Insumo()
            UnInsumo.ID = CInt(ViewState("InsumoID"))
            UnInsumo.Descripcion = tbDetalle.Text
            UnInsumo.NombreLargo = tbNombreLargo.Text
            UnInsumo.NombreCorto = tbNombreCorto.Text
            UnInsumo.SubCategoriaID = comboSubCategoria.SelectedValue
            UnInsumo.Estado = True
            UnInsumo.stock = New Stock
            UnInsumo.stock.Minimo = CInt(tbStockMin.Text)
            UnInsumo.stock.Maximo = CInt(tbStockMax.Text)
            UnInsumo.stock.Actual = CInt(tbStockActual.Text)

            Dim GestorInsumo As New BLLInsumo
            GestorInsumo.ActualizarInsumo(UnInsumo)
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.INSUMO, Patente.eAccion.MODIFICACION, String.Format("SE MODIFICÓ: id:{0} nombre:{1}", UnInsumo.ID, UnInsumo.NombreCorto), False)
        Catch ex As Exception
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.INSUMO, Patente.eAccion.MODIFICACION, String.Format("ERROR: {0}", ex.Message.ToString()), True)
        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        Response.Redirect("~/backend/catalogo/InsumosListado.aspx")
    End Sub

#Region "Metodos Privados"

    Private Sub LLenarInsumo(ByVal InsumoID As Integer)
        Dim UnInsumo As New Insumo()
        Dim GestorInsumo As New BLLInsumo

        UnInsumo = GestorInsumo.MostrarInsumos(InsumoID)
        tbDetalle.Text = UnInsumo.Descripcion
        tbNombreLargo.Text = UnInsumo.NombreLargo
        tbNombreCorto.Text = UnInsumo.NombreCorto
        comboCategoria.SelectedValue = UnInsumo.CategoriaID
        LLenarComboSubCategoria(UnInsumo.CategoriaID)
        comboSubCategoria.SelectedValue = UnInsumo.SubCategoriaID
        ' UnInsumo.Estado = True
        tbStockMin.Text = UnInsumo.stock.Minimo
        tbStockMax.Text = UnInsumo.stock.Maximo
        tbStockActual.Text = UnInsumo.stock.Actual

    End Sub

    Private Sub LLenarComboSubCategoria(ByVal CategoriaId As Integer)
        Dim GestorSubCategoria As New BLLSubCategoria
        comboSubCategoria.Items.Clear()
        comboSubCategoria.DataTextField = "descripcion"
        comboSubCategoria.DataValueField = "id"
        comboSubCategoria.DataSource = GestorSubCategoria.MostrarSubCategorias(CategoriaId)
        comboSubCategoria.DataBind()
    End Sub

    Private Sub LLenarComboCategoria()
        comboCategoria.Items.Insert(0, New ListItem("--Seleccionar--", "0")) 
        Dim GestorCategoria As New BLLCategoria
        comboCategoria.DataTextField = "descripcion"
        comboCategoria.DataValueField = "id"
        comboCategoria.DataSource = GestorCategoria.MostrarCategorias(3)
        comboCategoria.DataBind()
    End Sub

#End Region

End Class
