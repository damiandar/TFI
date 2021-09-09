Public Class BLLCliente

    Dim dataProvider As DALCliente

    Public Sub New()
        dataProvider = New DALCliente
    End Sub

    Public Sub ModificarCliente(ByVal UnaCuenta As Cliente)
        dataProvider.ModificarCuenta(UnaCuenta)
    End Sub

    Public Sub InsertarCliente(ByVal UnaCuenta As Cliente)
        dataProvider.InsertarCuenta(UnaCuenta)
    End Sub

    Public Function MostrarCliente(ByVal CuentaID As Integer) As Cliente
        Dim Lista As List(Of Cliente) = dataProvider.ListarCuentas(CuentaID, "")
        Dim UnCliente As New Cliente
        If Lista.Count > 0 Then
            UnCliente = Lista.First()
        End If
        Return UnCliente
    End Function

    Public Function ListarClientes(ByVal CUIT As String) As List(Of Cliente)
        Return dataProvider.ListarCuentas(0, CUIT)
    End Function

    Public Function BuscarPorLogin(ByVal login As String) As Cliente
        Return dataProvider.BuscarPorLogin(login)
    End Function

End Class

