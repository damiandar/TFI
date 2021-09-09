Public Class Mapper_Bitacora

    Dim dataprovider As DALBitacora

    Public Sub New()
        dataprovider = New DALBitacora()
    End Sub

    ''' <summary>
    ''' Registra los eventos de la aplicación.
    ''' </summary>
    ''' <param name="Login"></param>
    ''' <param name="objeto"></param>
    ''' <param name="accion"></param>
    ''' <param name="Evento"></param>
    ''' <param name="esError"></param>
    ''' <remarks></remarks>
    Public Shared Sub GuardarBitacora(ByVal Login As String, ByVal objeto As Patente.eObjeto, ByVal accion As Patente.eAccion, ByVal Evento As String, ByVal esError As Boolean)
        Dim GestorBitacora As New DALBitacora()
        GestorBitacora.InsertarBitacora(Login, objeto, accion, Evento, esError)
    End Sub

    Public Function MuestraListado(ByVal Login As String, ByVal Objeto As Patente.eObjeto, ByVal Accion As Patente.eAccion, ByVal FechaDesde As Date, ByVal FechaHasta As Date) As List(Of Bitacora)
        Return dataprovider.MuestraListado(Login, Objeto, Accion, FechaDesde, FechaHasta)
    End Function

End Class
