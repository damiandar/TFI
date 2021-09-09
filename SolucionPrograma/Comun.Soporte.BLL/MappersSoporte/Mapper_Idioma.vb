

Public Class Mapper_Idioma

    Dim dataProvider As DALIdioma

    Public Sub New()
        dataProvider = New DALIdioma
    End Sub

    ''' <summary>
    ''' Muestra el listado de idiomas guardados en el sistema.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MuestraListadoIdiomas() As List(Of Idioma)
        Try
            Dim ListaIdiomas As List(Of Idioma) = Nothing
            Dim oDalIdioma As New DALIdioma
            ListaIdiomas = oDalIdioma.MuestraListado()
            Return ListaIdiomas
        Catch ex As BLLExceptionSoporte
            Throw New BLLExceptionSoporte(ex.Message.ToString())
        End Try
    End Function

    ''' <summary>
    ''' Ingresa un nuevo idioma en el sistema.
    ''' </summary>
    ''' <param name="sNuevoIdioma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Nuevo(ByVal sNuevoIdioma As String) As Integer
        dataProvider.Nuevo(sNuevoIdioma)
        Return dataProvider.Mostrar(sNuevoIdioma)
    End Function

    ''' <summary>
    ''' Elimina un idioma del sistema.
    ''' </summary>
    ''' <param name="IdiomaID"></param>
    ''' <remarks></remarks>
    Public Sub Borrar(ByVal IdiomaID As Integer)
        dataProvider.Borrar(IdiomaID)
    End Sub

End Class