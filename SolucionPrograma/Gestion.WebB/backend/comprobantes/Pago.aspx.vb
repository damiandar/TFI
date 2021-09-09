
Partial Class aplicacion_forms
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim GestorComprobantes As New BLLPago
            GrillaComprobantes.DataSource = GestorComprobantes.MostrarPago(0, 0, 0)
            GrillaComprobantes.DataBind()
            'ScriptManager.GetCurrent(Me).RegisterPostBackControl(Button1)
            MostrarComboIVA()
            MostrarComboTipo()
        End If

    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As System.EventArgs) Handles btnNuevo.Click
        modalPopUpExtender1.Show()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Try
            Dim UnComprobante As New Pago

            UnComprobante.Fecha = Now.Date
            UnComprobante.Tipo = ComboTipoComprobante.SelectedValue
            UnComprobante.cliente = New Cliente()
            UnComprobante.cliente.ID = 3
            UnComprobante.Fecha = Now.Date

            UnComprobante.Concepto = "Pago de fact"
            UnComprobante.FechaPago = Now.Date
            UnComprobante.formapago = New FormaPago
            UnComprobante.formapago.ID = 1
            

            'Dim UnItem As New ComprobanteItem
            'UnItem.cantidad = 10
            'UnItem.CantidadFacturada = 0
            'UnItem.iva = New IVA(ComboIVA.SelectedValue, "", 0)
            'UnItem.precio = 100
            'UnItem.catalogo = New Catalogo
            'UnItem.catalogo.ID = 1
            'UnItem.catalogo.Descripcion = "kkkk"

            'UnComprobante.Items = New List(Of ComprobanteItem)
            'UnComprobante.Items.Add(UnItem)
            Dim Gestor As New BLLComprobante
            Dim IDComprobante As Integer = Gestor.InsertarComprobante(UnComprobante)
            UnComprobante.ID = IDComprobante



            Dim GestorFactura As New BLLPago
            GestorFactura.InsertarPago(UnComprobante)

            Label1.Text = "Se inserto correctamente"

        Catch ex As Exception
            Label1.Text = ex.Message.ToString()
        End Try
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
