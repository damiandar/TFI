Public Class BLLReposicion

    Dim dataProvider As DALReposicion

    Public Sub New()
        dataProvider = New DALReposicion
    End Sub

    Public Function InsertarReposicion(ByVal UnPedido As Reposicion) As Integer
        Try
            'If UnPedido.Items.Count <= 0 Then
            '    Throw New Exception("Debe insertar items")
            'End If
            Dim PedidoId As Integer = dataProvider.InsertarReposicion(UnPedido)
            For Each item As ReposicionItem In UnPedido.Items
                InsertarItemReposicion(PedidoId, item)
            Next
            Return PedidoId
        Catch ex As Exception
            Throw New Exception(ex.Message.ToString())
        End Try
    End Function

    Public Function ListarReposicion(ByVal PedidoId As Integer, ByVal EstadoID As Integer, ByVal Comprado As Boolean) As List(Of Reposicion)
        Return dataProvider.ListarReposicion(PedidoId, EstadoID, Comprado)
    End Function

    Public Sub ActualizarReposicion(ByVal UnPedidoReposicion As Reposicion)
        dataProvider.ActualizarReposicion(UnPedidoReposicion)
    End Sub

    Public Function MostrarReposicion(ByVal PedidoId As Integer) As Reposicion
        Dim Lista As List(Of Reposicion) = dataProvider.ListarReposicion(PedidoId, 0, 0)
        Dim dataProviderItems As New DALReposicionItem
        Dim UnPedido As New Reposicion
        If Lista.Count > 0 Then
            UnPedido = Lista.First()
            UnPedido.Items = dataProviderItems.ListarReposicionItem(PedidoId)
        End If

        Return UnPedido
    End Function

    Public Sub ActualizarEstadoReposicion(ByVal PedidoID As Integer, ByVal EstadoId As Integer)
        dataProvider.ActualizarEstadoReposicion(PedidoID, EstadoId)
    End Sub

    Public Function ListarReposicionItem(ByVal PedidoId As Integer) As List(Of ReposicionItem)
        Dim dataproviderItems As New DALReposicionItem()
        Return dataproviderItems.ListarReposicionItem(PedidoId)
    End Function

    Public Sub ActualizarItemReposicion(ByVal PedidoId As Integer, ByVal item As ReposicionItem)
        Dim dataProviderItems As New DALReposicionItem
        dataProviderItems.ActualizarReposicionItem(PedidoId, item)
    End Sub

#Region "Metodos Privados"


    Public Sub InsertarItemReposicion(ByVal PedidoId As Integer, ByVal item As ReposicionItem)
        Dim dataProviderItems As New DALReposicionItem
        dataProviderItems.InsertarReposicionItem(PedidoId, item)
    End Sub

#End Region


End Class
