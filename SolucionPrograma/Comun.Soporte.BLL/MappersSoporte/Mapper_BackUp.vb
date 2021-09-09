Public Class Mapper_BackUp

    Dim dataprovider As DALBackUp

    Public Sub New()
        dataprovider = New DALBackUp
    End Sub

    ''' <summary>
    ''' Crea el backup del sistema y lo guarda en la ruta seleccionada.
    ''' </summary>
    ''' <param name="Ruta"></param>
    ''' <remarks></remarks>
    Public Sub HacerBackUP(ByVal Ruta As String, ByVal Descripcion As String)
        Try
            dataprovider.HacerBackUP(Ruta)
            dataprovider.GuardarRuta(Ruta, Descripcion)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub RestaurarBackUp(ByVal Ruta As String)
        Try
            dataprovider.RestaurarBackUP(Ruta)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Muestra los datos de los backups y donde fueron guardados
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListarBackUp() As List(Of BackUp)
        Try
            Return dataprovider.ListarBackUp()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
 
End Class
