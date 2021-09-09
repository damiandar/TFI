Imports System.IO

Partial Class compras_Default
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ViewState("fechaDesde") = Nothing
            ViewState("fechaHasta") = Nothing
            LLenarGrilla(0, 0, 0)
        End If
    End Sub

    Private Sub lnkBuscar_Click(sender As Object, e As EventArgs) Handles lnkBuscar.Click
        Dim fechaDesde As DateTime = Nothing
        Dim fechaHasta As DateTime = Nothing

        If IsDate(tbFechaDesde.Text) Then
            fechaDesde = Convert.ToDateTime(tbFechaDesde.Text)
            ViewState("fechaDesde") = fechaDesde
        End If
        If IsDate(tbFechaHasta.Text) Then
            fechaHasta = Convert.ToDateTime(tbFechaHasta.Text)
            ViewState("fechaHasta") = fechaHasta
        End If

        LLenarGrilla(tbID.Text, 0, False)
    End Sub

    Private Sub LLenarGrilla(ByVal PedidoID As Integer, ByVal EstadoID As Integer, ByVal Comprado As Boolean)
        Dim GestorReposicion As New BLLReposicion
        Dim ListaReposicion As New List(Of Reposicion)

        ListaReposicion = GestorReposicion.ListarReposicion(PedidoID, EstadoID, Comprado)
        'quito todos los creados
        ListaReposicion.RemoveAll(Function(x) x.Estado = Reposicion.eEstado.creado)
        If IsDate(ViewState("fechaDesde")) Then
            ListaReposicion = ListaReposicion.FindAll(Function(x) x.Fecha >= CDate(ViewState("fechaDesde")))
        End If

        If IsDate(ViewState("fechaHasta")) Then
            ListaReposicion = ListaReposicion.FindAll(Function(x) x.Fecha <= CDate(ViewState("fechaHasta")))
        End If

        GrillaReposicion.DataSource = ListaReposicion
        GrillaReposicion.DataBind()
    End Sub

    Private Sub GrillaReposicion_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrillaReposicion.RowCommand
        If e.CommandName = "Imprimir" Then
            Dim GestorAbastecimiento As New BLLReposicion
            Dim GestorReportes As New Reportes()
            Dim output As MemoryStream = GestorReportes.DibujarPlanillaAbastecimiento("aa", GestorAbastecimiento.MostrarReposicion(e.CommandArgument))

            HttpContext.Current.Response.ContentType = "application/pdf"
            HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=Planilla_Reposicion-{0}.pdf", e.CommandArgument))
            HttpContext.Current.Response.BinaryWrite(output.ToArray())
        End If
    End Sub

    'Protected Sub btnCrearSolicitud_Click(sender As Object, e As System.EventArgs) Handles btnCrearSolicitud.Click
    '    Response.Redirect("~/backend/compras/pedidocompras.aspx")
    'End Sub

    'Protected Function ArmarRuta(ByVal PedidoId As Object, ByVal Estado As Object) As String
    '    Dim ruta As String = ""
    '    If Estado = 1 Then
    '        ruta = String.Format("~/Pedidos/AgregarItems.aspx?ReposicionID={0}", Eval("ID"))
    '    ElseIf Estado = 2 Then
    '        ruta = String.Format("~/GestionPedidos/Detalle.aspx?ReposicionID={0}", Eval("ID"))
    '    ElseIf Estado = 3 Then
    '        ruta = String.Format("~/GestionPedidos/Finalizados.aspx?ReposicionID={0}", Eval("ID"))
    '    End If
    '    Return ruta
    'End Function


End Class
