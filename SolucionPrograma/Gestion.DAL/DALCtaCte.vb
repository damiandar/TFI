Imports System.Data
Imports System.Data.SqlClient

Public Class DALCtaCte
    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Sub InsertarRegistroCtaCte(ByVal CuentaId As Integer, ByVal UnaCtaCte As CtaCteDetalle)
        Dim ParCliente As New SqlParameter("@Cuenta_id", SqlDbType.Int, 0)
        ParCliente.Value = CuentaId
        Dim ParTipoCompro As New SqlParameter("@ComprobanteTipo_id", SqlDbType.Int, 0)
        ParTipoCompro.Value = UnaCtaCte.TipoComprobante
        Dim ParIDCompro As New SqlParameter("@Comprobante_id", SqlDbType.Int, 0)
        ParIDCompro.Value = UnaCtaCte.ID
        Dim ParNroCompro As New SqlParameter("@comprobante_nro", SqlDbType.Int, 0)
        ParNroCompro.Value = UnaCtaCte.Nro
        Dim ParMonto As New SqlParameter("@ctacte_monto", SqlDbType.Float, 0)
        ParMonto.Value = UnaCtaCte.Monto
        Dim ParNotas As New SqlParameter("@ctacte_notas", SqlDbType.VarChar, 50)
        ParNotas.Value = UnaCtaCte.Nota
        Dim ParFecha As New SqlParameter("@ctacte_fecha", SqlDbType.DateTime, 0)
        ParFecha.Value = UnaCtaCte.Fecha
        Conectividad.EjecutarComando("CtaCte_Insert", New SqlParameter() {ParCliente, ParTipoCompro, ParIDCompro, ParMonto, ParNotas, ParFecha})
    End Sub


    Public Function MostrarEncuesta(ByVal EncuestaID As Integer) As Encuesta
        Dim ParEncuestaID As New SqlParameter("@encuesta_id", SqlDbType.Int, 0)
        ParEncuestaID.Value = IIf(EncuestaID = 0, DBNull.Value, EncuestaID)
        Dim UnaEncuesta As New Encuesta

        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("Encuesta_Show", New SqlParameter() {ParEncuestaID})
        If dt.Rows.Count > 0 Then
            UnaEncuesta = ConstruirObjetoConRegistro(dt.Rows(0))
        End If

        dt = Conectividad.MostrarDataTable("EncuestaDetalle_show", New SqlParameter() {ParEncuestaID})
        If dt.Rows.Count > 0 Then
            UnaEncuesta.Opciones = New List(Of EncuestaDetalle)

            For Each fila As DataRow In dt.Rows
                UnaEncuesta.Opciones.Add(ConstruirObjetoConRegistroDetalle(fila))
            Next
        End If
        Return UnaEncuesta
    End Function

#Region "Metodos privados"

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Encuesta
        Dim UnaEncuesta As New Encuesta
        UnaEncuesta.ID = fila("encuesta_id")
        UnaEncuesta.Descripcion = fila("encuesta_descripcion").ToString().Trim()
        Return UnaEncuesta
    End Function

    Private Function ConstruirObjetoConRegistroDetalle(ByVal fila As DataRow) As EncuestaDetalle
        Dim UnaEncuestaDetalle As New EncuestaDetalle
        UnaEncuestaDetalle.ID = fila("encuestadetalle_id")
        UnaEncuestaDetalle.Detalle = fila("encuestadetalle_descripcion").ToString().Trim()

        Return UnaEncuestaDetalle
    End Function

#End Region


End Class
