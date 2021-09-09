Public Class BLLFormaEnvio

    Dim dataProvider As DALFormaEnvio

    Public Sub New()
        dataProvider = New DALFormaEnvio
    End Sub

    Public Function ListarFormasEnvio() As List(Of FormaEnvio)
        Return dataProvider.ListarFormasEnvio()
    End Function
End Class
