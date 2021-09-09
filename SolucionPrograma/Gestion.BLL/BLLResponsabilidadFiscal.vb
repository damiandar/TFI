Public Class BLLResponsabilidadFiscal
    Dim dataProvider As DALResponsabilidadFiscal

    Public Sub New()
        dataProvider = New DALResponsabilidadFiscal
    End Sub

    Public Function ListarResponsabilidades() As List(Of ResponsabilidadFiscal)
        Return dataProvider.ListarResponsabilidades
    End Function

End Class

