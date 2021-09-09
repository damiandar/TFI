Public Class BLLRemito

    Dim dataProvider As DALRemito

    Public Sub New()
        dataProvider = New DALRemito
    End Sub

    Public Sub InsertarRemito(ByVal UnRemito As Remito)
        Dim RemitoId As Integer = dataProvider.InsertarRemito(UnRemito)
        For Each UnItem As RemitoItem In UnRemito.Items
            Dim provideritems As New DALRemitoItem
            provideritems.Insertar(RemitoId, UnItem)
        Next
    End Sub

    Public Function MostrarRemito(ByVal id As Integer) As Remito
        Return dataProvider.MostrarRemito(id)
    End Function

    Public Function MostrarListadoRemito(ByVal Id As Integer, ByVal Nro As Integer, ByVal Proveedor_Id As Integer, ByVal OrdenId As Integer) As List(Of Remito)
        Return dataProvider.MostrarListarRemito(Id, Nro, Proveedor_Id, OrdenId)
    End Function

End Class
