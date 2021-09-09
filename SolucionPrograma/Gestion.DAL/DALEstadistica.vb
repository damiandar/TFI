Imports System.Data
Imports System.Data.SqlClient

Public Class DALEstadistica
    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub


    Public Function EstadisticaEncuesta(ByVal EncuestaID As Integer) As List(Of Estadistica)
        Try
            Dim ListaEstadisticas As New List(Of Estadistica)

            Dim ParId As New SqlParameter("@encuesta_id", SqlDbType.Int, 0)
            ParId.Value = IIf(EncuestaID = 0, DBNull.Value, EncuestaID)

            Dim dt As DataTable = Conectividad.MostrarDataTable("EstadisticaEncuesta_Show", New SqlParameter() {ParId})

            For Each fila As DataRow In dt.Rows
                Dim UnaEstadistica As New Estadistica
                UnaEstadistica.ID = fila("encuestadetalle_id")
                UnaEstadistica.Descripcion = fila("encuestadetalle_id")
                UnaEstadistica.Valor = fila("valor")
                ListaEstadisticas.Add(UnaEstadistica)
            Next
            Return ListaEstadisticas

        Catch ex As Exception
            Throw New Exception(ex.Message.ToString())
        End Try
    End Function

    Public Function EstadisticaPedido(ByVal EncuestaID As Integer) As List(Of Estadistica)
        Try
            Dim ListaEstadisticas As New List(Of Estadistica)

            'Dim ParId As New SqlParameter("@encuesta_id", SqlDbType.Int, 0)
            'ParId.Value = IIf(EncuestaID = 0, DBNull.Value, EncuestaID)
            'New SqlParameter() {ParId}
            Dim dt As DataTable = Conectividad.MostrarDataTable("EstadisticaPedido_Show", Nothing)

            For Each fila As DataRow In dt.Rows
                Dim UnaEstadistica As New Estadistica
                UnaEstadistica.ID = fila("id")
                UnaEstadistica.Descripcion = fila("descripcion")
                UnaEstadistica.Valor = fila("valor")
                ListaEstadisticas.Add(UnaEstadistica)
            Next
            Return ListaEstadisticas

        Catch ex As Exception
            Throw New Exception(ex.Message.ToString())
        End Try
    End Function

End Class
