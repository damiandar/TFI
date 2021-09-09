Public Class BLLDomicilioEnvio

    Dim dataProvider As DALDomicilioEnvio

    Public Sub New()
        dataProvider = New DALDomicilioEnvio
    End Sub

    Public Function MostrarDomicilioPorPedido(ByVal PedidoID As Integer) As DomicilioEnvio
        Dim UnDomicilioEnvio As New DomicilioEnvio
        If PedidoID > 0 Then
            UnDomicilioEnvio = dataProvider.MostrarDomicilioPorPedido(PedidoID)
        End If
        Return UnDomicilioEnvio
    End Function

    Public Function InsertarDomicilio(ByVal UnDomicilio As DomicilioEnvio) As Integer
        Dim DomicilioID As Integer = dataProvider.InsertarDomicilio(UnDomicilio)
        Return DomicilioID
    End Function

    Public Sub ModificarDomicilio(ByVal UnDomicilio As DomicilioEnvio)
        dataProvider.ModificarDomicilio(UnDomicilio)
    End Sub

    Public Function ListarDomicilios(ByVal CuentaID As Integer) As List(Of DomicilioEnvio)
        Dim ListaPedidos As New List(Of DomicilioEnvio)
        ListaPedidos = dataProvider.ListarDomicilios(CuentaID)
        Return ListaPedidos
    End Function

End Class
