Public Class BLLPago

    Dim dataProvider As DALPago

    Public Sub New()
        dataProvider = New DALPago
    End Sub

    Public Sub InsertarPago(ByVal UnPago As Pago)
        dataProvider.InsertarPago(UnPago)
    End Sub

    Public Function MostrarPago(ByVal Cuenta_id As Integer, ByVal FormaPagoId As Integer, ByVal PagoID As Integer) As List(Of Pago)
        Return dataProvider.MostrarPago(Cuenta_id, FormaPagoId, PagoID)
    End Function

End Class
