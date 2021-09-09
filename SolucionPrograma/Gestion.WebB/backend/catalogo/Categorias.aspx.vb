
Partial Class backend_catalogo_ProductosListado
    Inherits System.Web.UI.Page

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LLenarComboTipoCatalogo()
            LLenarComboCategoria(comboTipoCatalogo.SelectedValue)
            LLenarGrillaCategoria(comboTipoCatalogo.SelectedValue)
            LLenarGrillaSubCategoria(comboCategoria.SelectedValue)
            PanelMensaje.Visible = False
            PanelMensaje2.Visible = False
            PanelErrorCategoria.Visible = False
            PanelErrorSubCategoria.Visible = False
        End If
    End Sub

    Protected Sub btnIngresarCategoria_Click(sender As Object, e As EventArgs) Handles btnIngresarCategoria.Click
        Try
            Dim GestorCategoria As New BLLCategoria
            GestorCategoria.InsertarCategoria(tbCategoria.Text, comboTipoCatalogo.SelectedValue)
            tbCategoria.Text = ""
            PanelMensaje2.Visible = False
            PanelMensaje.Visible = True
            lblMensaje.Text = "Se insertó correctamente la categoria"
            LLenarGrillaCategoria(comboTipoCatalogo.SelectedValue)
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.SUBCATEGORIA, Patente.eAccion.ALTA, String.Format("SE INSERTÓ: {0} ", tbSubCategoria.Text), False)
        Catch ex As Exception
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.SUBCATEGORIA, Patente.eAccion.ALTA, String.Format("ERROR: {0}", ex.Message.ToString()), True)
        End Try
    End Sub

    Protected Sub btnIngresarSubCategoria_Click(sender As Object, e As EventArgs) Handles btnIngresarSubCategoria.Click
        Try
            Dim GestorCategoria As New BLLCategoria
            GestorCategoria.InsertarSubCategoria(tbSubCategoria.Text, comboCategoria.SelectedValue)
            tbSubCategoria.Text = ""
            PanelMensaje.Visible = False
            PanelMensaje2.Visible = True
            lblMensaje2.Text = "Se insertó correctamente la subcategoria"
            LLenarGrillaSubCategoria(comboCategoria.SelectedValue)
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.CATEGORIA, Patente.eAccion.ALTA, String.Format("SE INSERTÓ: {0} ", tbSubCategoria.Text), False)
        Catch ex As Exception
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.CATEGORIA, Patente.eAccion.ALTA, String.Format("ERROR: {0}", ex.Message.ToString()), True)
        End Try
    End Sub

#Region "Metodos Privados"

    Private Sub LLenarGrillaCategoria(ByVal Catalogo As Integer)
        Dim GestorCategoria As New BLLCategoria
        GrillaCategorias.DataSource = GestorCategoria.MostrarCategorias(Catalogo)
        GrillaCategorias.DataBind()
    End Sub

    Private Sub LLenarGrillaSubCategoria(ByVal CategoriaID As Integer)
        Dim GestorSubCategoria As New BLLSubCategoria
        GrillaSubCategorias.DataSource = GestorSubCategoria.MostrarSubCategorias(CategoriaID)
        GrillaSubCategorias.DataBind()
    End Sub

    Private Sub LLenarComboTipoCatalogo()
        comboTipoCatalogo.Items.Add(New ListItem("Productos", 1))
        comboTipoCatalogo.Items.Add(New ListItem("Insumos", 3))
    End Sub

    Private Sub LLenarComboCategoria(ByVal Catalogo As Integer)
        'comboCategoria.Items.Insert(0, New ListItem("--Seleccionar--", "0"))
        comboCategoria.Items.Clear()
        Dim GestorCategoria As New BLLCategoria
        comboCategoria.DataTextField = "descripcion"
        comboCategoria.DataValueField = "id"
        comboCategoria.DataSource = GestorCategoria.MostrarCategorias(Catalogo)
        comboCategoria.DataBind()
    End Sub

    Private Sub comboCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboCategoria.SelectedIndexChanged
        LLenarGrillaSubCategoria(comboCategoria.SelectedValue)
    End Sub

    Private Sub comboTipoCatalogo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboTipoCatalogo.SelectedIndexChanged
        LLenarComboCategoria(comboTipoCatalogo.SelectedValue)
        LLenarGrillaCategoria(comboTipoCatalogo.SelectedValue)
        LLenarGrillaSubCategoria(comboCategoria.SelectedValue)
    End Sub

    Private Sub GrillaSubCategorias_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrillaSubCategorias.RowCommand
        If e.CommandName = "Borrar" Then
            Try
                Dim SubCategoriaID As Integer = CInt(e.CommandArgument)
                Dim GestorCategoria As New BLLCategoria
                GestorCategoria.EliminarSubCategoria(SubCategoriaID)
                LLenarGrillaCategoria(comboTipoCatalogo.SelectedValue)
            Catch ex As Exception
                PanelErrorSubCategoria.Visible = True
                lblErrorSubCategoria.Text = "Hay productos asociados a esta subcategoria"
            End Try
        End If
    End Sub

    Private Sub GrillaCategorias_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrillaCategorias.RowCommand
        If e.CommandName = "Borrar" Then
            Try
                Dim CategoriaID As Integer = CInt(e.CommandArgument)
                Dim GestorCategoria As New BLLCategoria
                GestorCategoria.EliminarCategoria(CategoriaID)
                LLenarGrillaSubCategoria(comboCategoria.SelectedValue)
            Catch ex As Exception
                PanelErrorCategoria.Visible = True
                lblErrorCategoria.Text = "Hay productos asociados a esta categoria"
            End Try
        End If
    End Sub

#End Region

End Class
