
Partial Class aplicacion_Remito
    Inherits System.Web.UI.Page

    Private Sub InsertarRemito()
        Try
            Dim UnComprobante As New Remito

            UnComprobante.Fecha = Now.Date
            'UnComprobante.Tipo = ComboTipoComprobante.SelectedValue
            UnComprobante.orden.proveedor = New Proveedor()
            UnComprobante.orden.proveedor.ID = 3
            UnComprobante.Fecha = Now.Date

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



            Dim GestorFactura As New BLLRemito
            GestorFactura.InsertarRemito(UnComprobante)

            'Label1.Text = "Se inserto correctamente"

        Catch ex As Exception
            'Label1.Text = ex.Message.ToString()
        End Try
    End Sub

End Class
