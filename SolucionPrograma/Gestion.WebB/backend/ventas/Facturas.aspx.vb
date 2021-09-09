Imports System.IO

Partial Class backend_ventas_Facturas
    Inherits System.Web.UI.Page

    Private Sub Facturas_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim FacturaID As Integer = 0
            Dim ClienteID As Integer = 0

            LLenarComboCliente()

            If IsNumeric(Request.QueryString("ClienteId")) Then
                ClienteID = CInt(Request.QueryString("ClienteId"))
            End If
            MostrarGrillaFacturas(FacturaID, ClienteID)
        End If
    End Sub

    Private Sub GrillaFacturas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GrillaFacturas.RowCommand
        If e.CommandName = "Imprimir" Then
            ImprimirPdf(e.CommandArgument)
        End If
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
        Dim FacturaID As Integer = 0
        If IsNumeric(tbID.Text) Then
            FacturaID = CInt(tbID.Text)
        End If
        MostrarGrillaFacturas(FacturaID, 0)
    End Sub

#Region "Metodos Privados"

    Private Sub ImprimirPdf(ByVal id As Integer)
        Dim GestorReportes As New Reportes
        Dim GestorFacturas As New BLLFactura

        Dim UnaFactura As FacturaVenta = GestorFacturas.ListarFacturas(id, 0).Item(0)
        Dim output As MemoryStream = GestorReportes.DibujarPlanillaFacturas("aa", UnaFactura)


        HttpContext.Current.Response.ContentType = "application/pdf"
        HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=FACTURA-{0}-{1}.pdf", UnaFactura.Letra, UnaFactura.Nro))
        HttpContext.Current.Response.BinaryWrite(output.ToArray())
    End Sub

    Private Sub MostrarGrillaFacturas(ByVal FacturaId As Integer, ByVal ClienteID As Integer)
        Dim GestorFacturas As New BLLFactura
        Dim ListaFacturas As New List(Of FacturaVenta)

        ListaFacturas = GestorFacturas.ListarFacturas(FacturaId, ClienteID)

        If ListaFacturas.Count > 0 Then
            If IsDate(tbFechaDesde.Text) Then
                ListaFacturas = ListaFacturas.FindAll(Function(x) x.Fecha >= CDate(tbFechaDesde.Text))
            End If

            If IsDate(tbFechaHasta.Text) Then
                ListaFacturas = ListaFacturas.FindAll(Function(x) x.Fecha <= CDate(tbFechaHasta.Text))
            End If
        End If

        GrillaFacturas.DataSource = ListaFacturas
        GrillaFacturas.DataBind()
    End Sub

    Private Sub LLenarComboCliente()
        Dim GestorClientes As New BLLCliente
        comboCliente.Items.Insert(0, New ListItem("--Seleccionar cliente--", 0))
        comboCliente.DataTextField = "razon"
        comboCliente.DataValueField = "id"
        comboCliente.DataSource = GestorClientes.ListarClientes("")
        comboCliente.DataBind()
    End Sub

#End Region

End Class
