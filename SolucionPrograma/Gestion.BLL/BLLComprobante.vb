Public Class BLLComprobante

    Dim dataProvider As DALComprobante

    Public Sub New()
        dataProvider = New DALComprobante
    End Sub

    Public Function InsertarComprobante(ByVal UnComprobante As Comprobante) As Integer
        Dim IdComprobante As Integer = dataProvider.InsertarComprobante(UnComprobante)
        Return IdComprobante
    End Function

    Public Function ListarComprobantes(ByVal CuentaID As Integer, ByVal Tipo As Comprobante.eTipo, ByVal ID As Integer) As List(Of Comprobante)
        Return dataProvider.ListarComprobantes(CuentaID, Tipo, ID)
    End Function

    Public Function ListarComprobanteItem(ByVal ComprobanteID As Integer) As List(Of ComprobanteItem)
        Dim dataproviderItems As New DALComprobanteItem
        Return dataproviderItems.ListarComprobanteItem(ComprobanteID, 0)
    End Function


End Class
