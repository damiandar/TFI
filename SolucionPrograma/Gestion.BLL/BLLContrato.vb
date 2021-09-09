Public Class BLLContrato

    Dim dataProvider As DALContrato

    Public Sub New()
        dataProvider = New DALContrato
    End Sub

    Public Function InsertarContrato(ByVal UnContrato As Contrato) As Integer
        Return dataProvider.InsertarContrato(UnContrato)
    End Function

    Public Sub ModificarContrato(ByVal UnContrato As Contrato)
        dataProvider.ModificarContrato(UnContrato)
    End Sub

    Public Function ListarContrato(ByVal ContratoID As Integer, ByVal CuentaID As Integer, ByVal ServicioID As Integer) As List(Of Contrato)
        Return dataProvider.ListarContrato(ContratoID, CuentaID, ServicioID)
    End Function



End Class
