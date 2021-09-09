Public Class BLLProvincia
    Dim dataProvider As DALProvincia

    Public Sub New()
        dataProvider = New DALProvincia
    End Sub

    Public Function ListarProvincias() As List(Of Provincias)
        Return dataProvider.ListarProvincias()
    End Function

End Class

