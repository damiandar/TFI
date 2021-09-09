
Partial Class comprobantes_nuevocomprobante
    Inherits System.Web.UI.Page

    Protected Sub btnIngresar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnIngresar.Click
        Try
            Dim UnComprobante As New FacturaVenta
            UnComprobante.Fecha = Now.Date
            UnComprobante.Tipo = ComboTipoComprobante.SelectedValue

            Dim UnItem As New FacturaVentaItem
            UnItem.cantidad = 10

            UnItem.precio = 100
            'UnItem.catalogo = New Catalogo
            'UnItem.catalogo.ID = 100
            'UnItem.catalogo.Descripcion = "kkkk"
            UnComprobante.Items = New List(Of FacturaVentaItem)
            UnComprobante.Items.Add(UnItem)
            Dim Gestor As New BLLComprobante
            Gestor.InsertarComprobante(UnComprobante)
        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim GestorComprobantes As New BLLComprobante
        GrillaComprobante.DataSource = GestorComprobantes.ListarComprobantes(0, 0, 0)
        GrillaComprobante.DataBind()
    End Sub

#Region "Metodos Privados"

    Private Sub MostrarComboIVA()
        ComboIVA.Items.Add(New ListItem("Sin IVA", 0))
        ComboIVA.Items.Add(New ListItem("10,5 %", 1))
        ComboIVA.Items.Add(New ListItem("21   %", 2))
    End Sub

    Private Sub MostrarComboTipo()
        ComboTipoComprobante.Items.Add(New ListItem("FACTURA", 1))
        ComboTipoComprobante.Items.Add(New ListItem("ORDEN DE COMPRA", 2))
        ComboTipoComprobante.Items.Add(New ListItem("REMITO", 3))
        ComboTipoComprobante.Items.Add(New ListItem("NOTA DE CREDITO", 4))
        ComboTipoComprobante.Items.Add(New ListItem("NOTA DE DEBITO", 5))
    End Sub

#End Region


End Class
