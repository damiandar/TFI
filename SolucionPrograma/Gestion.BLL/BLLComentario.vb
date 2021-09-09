Public Class BLLComentario

    Dim dataProvider As DALComentario

    Public Sub New()
        dataProvider = New DALComentario
    End Sub

    Public Function InsertarComentario(ByVal UnComentario As Comentarios) As Integer
        Return dataProvider.InsertarComentario(UnComentario)
    End Function

    Public Function ListarComentarios(ByVal ProductoID As Integer) As List(Of Comentarios)
        Return dataProvider.ListarComentarios(ProductoID)
    End Function

    Public Function MostrarComentario(ByVal ComentarioID As Integer) As Comentarios
        Return dataProvider.MostrarComentario(ComentarioID)
    End Function

    Public Sub ActualizarComentario(ByVal UnComentario As Comentarios)
        dataProvider.ActualizarComentario(UnComentario)
    End Sub

End Class
