Imports System.Data
Imports System.Data.SqlClient

Public Class DALContrato

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function InsertarContrato(ByVal UnContrato As Contrato) As Integer
        Dim ParCuenta As New SqlParameter("@Cuenta_id", SqlDbType.Int, 0)
        ParCuenta.Value = UnContrato.cliente.ID
        Dim ParServicio As New SqlParameter("@Servicio_id", SqlDbType.Int, 0)
        ParServicio.Value = UnContrato.servicio.ID
        Dim ParBonificado As New SqlParameter("@bonificado", SqlDbType.Bit, 0)
        ParBonificado.Value = UnContrato.Bonificado
        Dim ParDiasDeCorte As New SqlParameter("@DiasDeCorte", SqlDbType.Int, 0)
        ParDiasDeCorte.Value = UnContrato.DiasDeCorte
        Dim ParEventual As New SqlParameter("@Eventual", SqlDbType.Bit, 0)
        ParEventual.Value = UnContrato.Eventual
        Dim ParFechaFinalizado As New SqlParameter("@FechaFinalizado", SqlDbType.DateTime, 0)
        ParFechaFinalizado.Value = UnContrato.FechaFinalizado
        Dim ParFechaFirmado As New SqlParameter("@FechaFirmado", SqlDbType.DateTime, 0)
        ParFechaFirmado.Value = UnContrato.FechaFirmado
        Dim ParMesesVigencia As New SqlParameter("@MesesVigencia", SqlDbType.Int, 0)
        ParMesesVigencia.Value = UnContrato.MesesVigencia
        Return Conectividad.EjecutarScalar("Contrato_Insert", New SqlParameter() {ParCuenta, ParServicio, ParBonificado, ParDiasDeCorte, ParEventual, ParFechaFinalizado, ParFechaFirmado, ParMesesVigencia})
    End Function

    Public Sub ModificarContrato(ByVal UnContrato As Contrato)
        Dim ParCuenta As New SqlParameter("@Cuenta_id", SqlDbType.Int, 0)
        ParCuenta.Value = UnContrato.cliente.ID
        Dim ParServicio As New SqlParameter("@Servicio_id", SqlDbType.Int, 0)
        ParServicio.Value = UnContrato.servicio.ID
        Dim ParBonificado As New SqlParameter("@bonificado", SqlDbType.Bit, 0)
        ParBonificado.Value = UnContrato.Bonificado
        Dim ParDiasDeCorte As New SqlParameter("@DiasDeCorte", SqlDbType.Int, 0)
        ParDiasDeCorte.Value = UnContrato.DiasDeCorte
        Dim ParEventual As New SqlParameter("@Eventual", SqlDbType.Bit, 0)
        ParEventual.Value = UnContrato.Eventual
        Dim ParFechaFinalizado As New SqlParameter("@FechaFinalizado", SqlDbType.DateTime, 0)
        ParFechaFinalizado.Value = UnContrato.FechaFinalizado
        Dim ParFechaFirmado As New SqlParameter("@FechaFirmado", SqlDbType.DateTime, 0)
        ParFechaFirmado.Value = UnContrato.FechaFirmado
        Dim ParMesesVigencia As New SqlParameter("@MesesVigencia", SqlDbType.Int, 0)
        ParMesesVigencia.Value = UnContrato.MesesVigencia
        Conectividad.EjecutarScalar("Contrato_Update", New SqlParameter() {ParCuenta, ParServicio, ParBonificado, ParDiasDeCorte, ParEventual, ParFechaFinalizado, ParFechaFirmado, ParMesesVigencia})
    End Sub

    Public Function ListarContrato(ByVal ContratoID As Integer, ByVal CuentaID As Integer, ByVal ServicioID As Integer) As List(Of Contrato)
        Dim ParCuenta As New SqlParameter("@Cuenta_id", SqlDbType.Int, 0)
        ParCuenta.Value = IIf(CuentaID = 0, DBNull.Value, CuentaID)
        Dim ParServicio As New SqlParameter("@Servicio_id", SqlDbType.Int, 0)
        ParServicio.Value = IIf(ServicioID = 0, DBNull.Value, ServicioID)
        Dim Lista As New List(Of Contrato)
        Dim dt As DataTable = Conectividad.MostrarDataTable("Contrato_Show", New SqlParameter() {ParCuenta, ParServicio})
        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then
                For Each fila As DataRow In dt.Rows
                    Lista.Add(ConstruirObjetoConRegistro(fila))
                Next
            End If
        End If
        Return Lista
    End Function

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Contrato
        Dim UnContrato As New Contrato

        UnContrato.cliente = New Cliente()
        UnContrato.cliente.ID = fila("cuenta_id")
        UnContrato.cliente.Razon = fila("cuenta_razonsocial")

        UnContrato.servicio = New Servicio()
        UnContrato.servicio.ID = fila("producto_id")
        UnContrato.servicio.Descripcion = fila("producto_descripcion")

        UnContrato.Bonificado = fila("Contrato_bonificado")
        UnContrato.DiasDeCorte = fila("Contrato_DiasDeCorte")
        UnContrato.Eventual = fila("contrato_eventual")
        UnContrato.FechaFinalizado = fila("contrato_fechafinalizacion")
        UnContrato.FechaFirmado = fila("contrato_fechafirmado")
        UnContrato.MesesVigencia = fila("contrato_mesesvigencia")
        Return UnContrato
    End Function

End Class
