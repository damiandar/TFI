Public Class BLLProveedor

    Dim dataProvider As DALProveedor

    Public Sub New()
        dataProvider = New DALProveedor
    End Sub

    Public Sub ModificarProveedor(ByVal UnProveedor As Proveedor)
        dataProvider.ModificarProveedor(UnProveedor)
    End Sub

    Public Sub InsertarProveedor(ByVal UnProveedor As Proveedor)
        dataProvider.InsertarProveedor(UnProveedor)
    End Sub

    Public Function MostrarProveedor(ByVal ID As Integer) As Proveedor
        Dim Lista As List(Of Proveedor) = dataProvider.ListarProveedores(ID, "")
        Dim UnaCuenta As New Proveedor
        If Lista.Count > 0 Then
            UnaCuenta = Lista.First()
        End If
        Return UnaCuenta
    End Function

    Public Function ListarProveedores(ByVal CUIT As String, ByVal ID As Integer) As List(Of Proveedor)
        Return dataProvider.ListarProveedores(0, CUIT)
    End Function

End Class

