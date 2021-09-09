Imports System.IO

Partial Class compras_Ordenes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim ReposicionId As Integer = Request.QueryString("ReposicionID")
            ViewState("ReposicionID") = ReposicionId
            LLenarGrilla(0, 0, ReposicionId)
            LLenarComboProveedor()
        End If
    End Sub

    Private Sub lnkBuscar_Click(sender As Object, e As EventArgs) Handles lnkBuscar.Click
        Dim OrdenId As Integer = 0
        If IsNumeric(tbID.Text) Then
            OrdenId = CInt(tbID.Text)
        End If
        LLenarGrilla(comboProveedor.SelectedValue, OrdenId, 0)
    End Sub

    Private Sub GrillaOrdenes_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrillaOrdenes.RowCommand
        If e.CommandName = "Imprimir" Then
            Dim GestorAbastecimiento As New BLLorden
            Dim GestorOrdenes As New Reportes()
            Dim output As MemoryStream = GestorOrdenes.DibujarPlanillaOrdenes("aa", GestorAbastecimiento.MostrarOrden(e.CommandArgument))

            HttpContext.Current.Response.ContentType = "application/pdf"
            HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=Planilla_Orden-{0}.pdf", CInt(e.CommandArgument)))
            HttpContext.Current.Response.BinaryWrite(output.ToArray())
        End If
    End Sub

#Region "Metodos Privados"

    Private Sub LLenarComboProveedor()
        comboProveedor.Items.Insert(0, New ListItem(String.Empty, 0))
        comboProveedor.SelectedIndex = 0
        Dim GestorProveedores As New BLLProveedor
        comboProveedor.DataTextField = "razon"
        comboProveedor.DataValueField = "id"
        comboProveedor.DataSource = GestorProveedores.ListarProveedores("", 0)
        comboProveedor.DataBind()
    End Sub

    Private Sub LLenarGrilla(ByVal ProveedorID As Integer, ByVal OrdenID As Integer, ByVal PedidoId As Integer)
        Dim fechaDesde As DateTime = Nothing
        Dim fechaHasta As DateTime = Nothing
        Dim ListaOrdenes As New List(Of OrdenCompra)

        Dim GestorComprobantes As New BLLorden
        ListaOrdenes = GestorComprobantes.ListarOrdenes(ProveedorID, OrdenID, PedidoId, False)

        If IsDate(tbFechaDesde.Text) Then
            ListaOrdenes = ListaOrdenes.FindAll(Function(x) x.Fecha >= CDate(tbFechaDesde.Text))
        End If

        If IsDate(tbFechaHasta.Text) Then
            ListaOrdenes = ListaOrdenes.FindAll(Function(x) x.Fecha <= CDate(tbFechaHasta.Text))
        End If

        GrillaOrdenes.DataSource = ListaOrdenes
        GrillaOrdenes.DataBind()
    End Sub

    Private Sub GrillaOrdenes_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GrillaOrdenes.PageIndexChanging
        LLenarGrilla(0, 0, ViewState("ReposicionID"))
        GrillaOrdenes.PageIndex = e.NewPageIndex
        GrillaOrdenes.DataBind()
    End Sub

#End Region

End Class
