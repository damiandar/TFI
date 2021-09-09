Public Class BLLCtaCte

    Dim dataProvider As DALCtaCte

    Public Sub New()
        dataProvider = New DALCtaCte
    End Sub

    Public Sub InsertarRegistroCtaCte(ByVal UnaCtaCte As CtaCte)
        For Each Detalle As CtaCteDetalle In UnaCtaCte.comprobantes
            If Detalle.TipoComprobante = CtaCteDetalle.Tipo.Pago Or Detalle.TipoComprobante = CtaCteDetalle.Tipo.NC Then
                Detalle.Monto = Detalle.Monto * (-1)
            End If
            dataProvider.InsertarRegistroCtaCte(UnaCtaCte.cliente.ID, Detalle)
        Next
    End Sub

End Class
