Public Class BLLEstadisticas

    Dim dataProvider As DALEstadistica

    Public Sub New()
        dataProvider = New DALEstadistica
    End Sub

    Public Function EstadisticaEncuesta(ByVal EncuestaID As Integer) As List(Of Estadistica)
        Return dataProvider.EstadisticaEncuesta(EncuestaID)
    End Function
    Public Function EstadisticaPedido(ByVal EncuestaID As Integer) As List(Of Estadistica)
        Return dataProvider.EstadisticaPedido(0)
    End Function
End Class
