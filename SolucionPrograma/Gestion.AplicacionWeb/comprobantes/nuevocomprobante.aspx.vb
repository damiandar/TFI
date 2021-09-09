
Partial Class comprobantes_nuevocomprobante
    Inherits System.Web.UI.Page

    Protected Sub btnIngresar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnIngresar.Click
        Try
            Dim UnComprobante As New Comprobante
            UnComprobante.Nro = 1
            UnComprobante.Sucursal = 0
            UnComprobante.Fecha = Now.Date
            Dim Gestor As New BLL.Negocio.BLLComprobante
            Gestor.InsertarComprobante(UnComprobante)
        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try
    End Sub
End Class
