
Public Class Mapper_Traduccion

    Dim dataprovider As DALTraduccion

    Public Sub New()
        dataprovider = New DALTraduccion()
    End Sub

    ''' <summary>
    ''' Traduce una palabra en el idioma seleccionado.
    ''' </summary>
    ''' <param name="ididioma"></param>
    ''' <param name="mensaje"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TraducirPalabra(ByVal ididioma As Integer, ByVal mensaje As String) As String
        Dim Traduccion As String = ""
        Dim diccionario As New Dictionary(Of String, String)
        Dim proveedor As New DALTraduccion
        diccionario = proveedor.MostrarDiccionario(ididioma)

        If diccionario.ContainsKey(mensaje) Then
            Traduccion = diccionario(mensaje)
        Else
            Traduccion = "Sin traduccion"
        End If

        Return Traduccion
    End Function

    ''' <summary>
    ''' Muestra el diccionario completo del idioma seleccionado.
    ''' </summary>
    ''' <param name="ididioma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MostrarDiccionario(ByVal ididioma As Integer) As Dictionary(Of String, String)
        Return dataprovider.MostrarDiccionario(ididioma)
    End Function

    ''' <summary>
    ''' Lista todas las traducciones del idioma seleccionado.
    ''' </summary>
    ''' <param name="idIdioma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ListarTraducciones(ByVal idIdioma As Integer) As List(Of Traduccion)
        Return dataprovider.Listar(idIdioma)
    End Function

    ''' <summary>
    ''' Actualiza una traduccion de una palabra.
    ''' </summary>
    ''' <param name="UnMensaje"></param>
    ''' <remarks></remarks>
    Public Sub Actualizar(ByVal UnMensaje As Traduccion)
        dataprovider.Actualizar(UnMensaje)
    End Sub

    ''' <summary>
    ''' Ingresa una nueva traducción para una palabra en ese idioma.
    ''' </summary>
    ''' <param name="UnMensaje"></param>
    ''' <remarks></remarks>
    Public Sub Insertar(ByVal UnMensaje As Traduccion)
        dataprovider.Insertar(UnMensaje)
    End Sub

End Class
