
Partial Class aplicacion_forms
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim GestorComprobantes As New BLLComprobante
            GrillaComprobantes.DataSource = GestorComprobantes.ListarComprobantes(0, 0, 0)
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
            Dim UnaFactura As New FacturaVenta
            UnaFactura.cliente = New Cliente(3)
            UnaFactura.Fecha = Now.Date
            UnaFactura.Tipo = comboTipoComprobante.SelectedValue

            UnaFactura.Letra = "A"
            UnaFactura.Nro = 1
            UnaFactura.Fecha = Now.Date
            UnaFactura.PtoVenta = 1
            UnaFactura.CAE = "222222"
            UnaFactura.CAI = "992829"

            Dim Gestor As New BLLComprobante
            UnaFactura.ID = Gestor.InsertarComprobante(UnaFactura)


            Dim UnItem As New FacturaVentaItem
            UnItem.cantidad = 10

            UnItem.precio = 100
            'UnItem.catalogo = New Catalogo
            'UnItem.catalogo.ID = 1
            'UnItem.catalogo.Descripcion = "kkkk"

            UnaFactura.Items = New List(Of FacturaVentaItem)
            UnaFactura.Items.Add(UnItem)

            Dim GestorFactura As New BLLFactura
            GestorFactura.InsertarFactura(UnaFactura)

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
