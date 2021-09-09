Public Class BLLFactura

    Dim dataProvider As DALFactura

    Public Sub New()
        dataProvider = New DALFactura
    End Sub
    Public Function ListarFacturas(ByVal id As Integer, ByVal CuentaID As Integer) As List(Of FacturaVenta)
        Return dataProvider.ListarFacturas(id, CuentaID)
    End Function

    Public Sub InsertarFactura(ByVal UnComprobante As FacturaVenta)
        UnComprobante.ID = dataProvider.InsertarFactura(UnComprobante)
        If UnComprobante.Items IsNot Nothing Then
            Dim ComprobanteItems As New DALFactura
            For Each UnItem As FacturaVentaItem In UnComprobante.Items
                ComprobanteItems.InsertarItem(UnComprobante.ID, UnItem)
            Next
        End If
    End Sub

End Class
