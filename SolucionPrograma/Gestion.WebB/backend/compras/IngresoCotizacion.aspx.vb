
Partial Class compras_IngresoCotizacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ViewState("ReposicionID") = Request.QueryString("ReposicionID")
            ViewState("ProductoID") = Request.QueryString("ProductoID")
            LLenarComboProveedor()
        Else
            Page.ClientScript.RegisterOnSubmitStatement(Me.GetType(), "closePage", "window.onunload = CloseWindow();")
        End If

    End Sub

    Protected Sub btnCotizacion_Click(sender As Object, e As System.EventArgs) Handles btnCotizacion.Click
        Dim GestorCotizacion As New BLLCotizacion
        GestorCotizacion.IngresarCotizacion(ViewState("ReposicionID"), ViewState("ProductoID"), comboProveedor.SelectedValue, 10, 20, Now.Date, 10, tbValorUnitario.Text, comboIVA.SelectedValue, 120, 1)
   End Sub

    Private Sub LLenarComboProveedor()
        Dim GestorProveedores As New BLLProveedor
        comboProveedor.DataTextField = "razon"
        comboProveedor.DataValueField = "id"
        comboProveedor.DataSource = GestorProveedores.ListarProveedores("", 0)
        comboProveedor.DataBind()
    End Sub
End Class
