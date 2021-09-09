Imports System.IO

Partial Class ventas_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Dim ClienteID As Integer = Request.QueryString("ClienteId")
                LLenarGrilla(ClienteID, 0)
                LLenarComboClientes()
                LLenarComboEstado()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lnkBuscar_Click(sender As Object, e As EventArgs) Handles lnkBuscar.Click
        Dim fechaDesde As DateTime = Nothing
        Dim fechaHasta As DateTime = Nothing

        If IsDate(tbFechaDesde.Text) Then
            fechaDesde = Convert.ToDateTime(tbFechaDesde.Text)
            ViewState("fechaDesde") = fechaDesde
        Else
            ViewState("fechaDesde") = Nothing
        End If
        If IsDate(tbFechaHasta.Text) Then
            fechaHasta = Convert.ToDateTime(tbFechaHasta.Text)
            ViewState("fechaHasta") = fechaHasta
        Else
            ViewState("fechaHasta") = Nothing
        End If
        LLenarGrilla(comboClientes.SelectedValue, comboEstado.SelectedValue)
    End Sub

    Private Sub GrillaPedidos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrillaPedidos.RowCommand
        If e.CommandName = "Imprimir" Then
            Imprimir(e.CommandArgument)
        End If
    End Sub


#Region "Metodos privados"

    Private Sub Imprimir(ByVal id As Integer)
        Dim GestorPedidos As New BLLPedido
        Dim GestorReportes As New Reportes()
        Dim output As MemoryStream = GestorReportes.DibujarPlanillaPedidos("aa", GestorPedidos.MostrarPedido(id, True))

        HttpContext.Current.Response.ContentType = "application/pdf"
        HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=Pedido_Ventas-{0}.pdf", id))
        HttpContext.Current.Response.BinaryWrite(output.ToArray())
    End Sub

    Private Sub LLenarGrilla(ByVal ClienteID As Integer, ByVal EstadoID As Integer)
        Dim GestorPedidos As New BLLPedido()
        Dim ListaPedidos As New List(Of Pedido)
        ListaPedidos = GestorPedidos.ListarPedido(ClienteID, 0, EstadoID, False)
        If IsDate(ViewState("fechaDesde")) Then
            ListaPedidos = ListaPedidos.FindAll(Function(x) x.Fecha >= CDate(ViewState("fechaDesde")))
        End If

        If IsDate(ViewState("fechaHasta")) Then
            ListaPedidos = ListaPedidos.FindAll(Function(x) x.Fecha <= CDate(ViewState("fechaHasta")))
        End If
        GrillaPedidos.DataSource = ListaPedidos
        GrillaPedidos.DataBind()
    End Sub

    Private Sub LLenarComboClientes()
        Dim ListaClientes As New List(Of Cliente)
        Dim GestorClientes As New BLLCliente
        ListaClientes = GestorClientes.ListarClientes("")
        comboClientes.Items.Add(New ListItem("-------------------------", 0))
        comboClientes.DataTextField = "razon"
        comboClientes.DataValueField = "id"
        comboClientes.DataSource = ListaClientes
        comboClientes.DataBind()
    End Sub

    Private Sub LLenarComboEstado()

        'Dim itemValues As Array = System.Enum.GetValues(GetType(Pedido.ePedidoEstado))
        'Dim itemNames As Array = System.Enum.GetNames(GetType(Pedido.ePedidoEstado)

        'For i As Integer = 0 To itemNames.Length - 1
        '    Dim item As New ListItem(itemNames(i), itemValues(i))
        '    comboEstado.Items.Add(item)
        'Next

        comboEstado.Items.Add(New ListItem("-------------------------", 0))
        comboEstado.Items.Add(New ListItem("Confirmado", Pedido.ePedidoEstado.Confirmado))
        comboEstado.Items.Add(New ListItem("En Distribucion", Pedido.ePedidoEstado.EnDistribucion))
        comboEstado.Items.Add(New ListItem("Entregado", Pedido.ePedidoEstado.Entregado))
        comboEstado.Items.Add(New ListItem("Anulado", Pedido.ePedidoEstado.Anulado))
    End Sub

    Private Sub GrillaPedidos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GrillaPedidos.PageIndexChanging
        LLenarGrilla(comboClientes.SelectedValue, comboEstado.SelectedValue)
        GrillaPedidos.PageIndex = e.NewPageIndex
        GrillaPedidos.DataBind()
    End Sub

#End Region

End Class
