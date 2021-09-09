Public Class BLLCotizacion

    Dim dataProvider As DALCotizacion

    Public Sub New()
        dataProvider = New DALCotizacion
    End Sub

    Public Sub IngresarCotizacion(ByVal PedidoReposicion_id As Integer, ByVal Producto_id As Integer, ByVal Cuenta_ID As Integer, ByVal PlazoEntregaDias As Integer, ByVal PlazoPagoDias As Integer, ByVal FechaHasta As DateTime, ByVal Descuento As Integer, ByVal ValorUnitario As Double, ByVal IVA_id As Integer, ByVal GarantiaDias As Integer, ByVal Estado As Integer)
        dataProvider.IngresarCotizacion(PedidoReposicion_id, Producto_id, Cuenta_ID, PlazoEntregaDias, PlazoPagoDias, FechaHasta, Descuento, ValorUnitario, IVA_id, GarantiaDias, Estado)
    End Sub
    Public Function ListarCotizacion(ByVal PedidoReposicion_id As Integer, ByVal Producto_ID As Integer, ByVal Cuenta_ID As Integer) As List(Of Cotizacion)
        Return dataProvider.ListarCotizacion(PedidoReposicion_id, Producto_ID, Cuenta_ID)
    End Function

End Class
