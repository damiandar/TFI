Public Class BLLEncuesta

    Dim dataProvider As DALEncuesta

    Public Sub New()
        dataProvider = New DALEncuesta
    End Sub


    Public Function ListarEncuestas() As List(Of Encuesta)
        Return dataProvider.ListarEncuestas()
    End Function

    Public Function ListarEncuestaPendiente(ByVal Login As String) As List(Of Encuesta)
        Return dataProvider.ListarEncuestaPendiente(Login)
    End Function

    ''' <summary>
    ''' Ingresa una encuesta con la lista de opciones para votar.
    ''' </summary>
    ''' <param name="UnaEncuesta"></param>
    ''' <remarks></remarks>
    Public Sub InsertarEncuesta(ByVal UnaEncuesta As Encuesta)
        Dim EncuestaID As Integer = dataProvider.InsertarEncuesta(UnaEncuesta)
        For Each UnDetalle As EncuestaDetalle In UnaEncuesta.Opciones
            dataProvider.InsertarEncuestaDetalle(EncuestaID, UnDetalle.Detalle)
        Next
    End Sub



    ''' <summary>
    ''' Muestra una encuesta con la lista de opciones.
    ''' </summary>
    ''' <param name="EncuestaID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MostrarEncuesta(ByVal EncuestaID As Integer) As Encuesta
        Return dataProvider.MostrarEncuesta(EncuestaID)
    End Function

    Public Sub VotarEncuesta(ByVal login As String, ByVal EncuestaID As Integer, ByVal EncuestaDetalleID As Integer, ByVal EncuestaOpinion As String)
        dataProvider.VotarEncuesta(login, EncuestaID, EncuestaDetalleID, EncuestaOpinion)
    End Sub

End Class
