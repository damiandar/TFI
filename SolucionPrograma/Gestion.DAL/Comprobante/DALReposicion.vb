Imports System.Data
Imports System.Data.SqlClient

Public Class DALReposicion

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function ListarReposicion(ByVal PedidoId As Integer, ByVal EstadoID As Integer, ByVal Comprado As Boolean) As List(Of Reposicion)
        Try
            Dim ParId As New SqlParameter("@PedidoReposicion_id", SqlDbType.Int, 0)
            ParId.Value = IIf(PedidoId = 0, DBNull.Value, PedidoId)
            Dim ParEstado As New SqlParameter("@PedidoReposicionEstado_id", SqlDbType.Int, 0)
            ParEstado.Value = IIf(EstadoID = 0, DBNull.Value, EstadoID)
            Dim ParComprado As New SqlParameter("@PedidoReposicion_Comprado", SqlDbType.Bit, 0)
            ParComprado.Value = Comprado
            Dim Lista As New List(Of Reposicion)
            Dim dt As DataTable = Conectividad.MostrarDataTable("Reposicion_Show", New SqlParameter() {ParId, ParEstado, ParComprado})
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    For Each fila As DataRow In dt.Rows
                        Lista.Add(ConstruirObjetoConRegistro(fila))
                    Next
                End If
            End If
            Return Lista
        Catch ex As Exception
            Throw New Exception("Listar Reposicion: " & ex.Message.ToString())
        End Try
    End Function

    Public Function InsertarReposicion(ByVal UnPedidoReposicion As Reposicion) As Integer
        Try
            'Dim ParId As New SqlParameter("@PedidoReposicion_id", SqlDbType.Int, 0)
            'ParId.Value = UnPedidoReposicion.ID
            Dim ParEstado As New SqlParameter("@PedidoReposicionEstado_id", SqlDbType.Int, 0)
            ParEstado.Value = UnPedidoReposicion.Estado
            Dim ParFecha As New SqlParameter("@PedidoReposicion_fecha", SqlDbType.DateTime, 0)
            ParFecha.Value = UnPedidoReposicion.Fecha
            Dim ParNotas As New SqlParameter("@PedidoReposicion_Notas", SqlDbType.VarChar, 50)
            ParNotas.Value = UnPedidoReposicion.Notas
            Dim ParUsuario As New SqlParameter("@Usuario_id", SqlDbType.Int, 0)
            ParUsuario.Value = 1
            Dim ParComprado As New SqlParameter("@PedidoReposicion_Comprado", SqlDbType.Bit, 0)
            ParComprado.Value = 0
            Return Conectividad.EjecutarScalar("Reposicion_Insert", New SqlParameter() {ParNotas, ParUsuario, ParComprado, ParEstado, ParFecha})
        Catch ex As Exception
            Throw New Exception("Reposicion Insert: " & ex.Message.ToString())
        End Try
    End Function

    Public Sub ActualizarReposicion(ByVal UnPedidoReposicion As Reposicion)
        Try
            Dim ParId As New SqlParameter("@PedidoReposicion_id", SqlDbType.Int, 0)
            ParId.Value = UnPedidoReposicion.ID
            Dim ParEstado As New SqlParameter("@PedidoReposicionEstado_id", SqlDbType.Int, 0)
            ParEstado.Value = UnPedidoReposicion.Estado
            'Dim ParFecha As New SqlParameter("@PedidoReposicion_fecha", SqlDbType.DateTime, 0)
            'ParFecha.Value = UnPedidoReposicion.Fecha
            Dim ParNotas As New SqlParameter("@PedidoReposicion_Notas", SqlDbType.VarChar, 50)
            ParNotas.Value = UnPedidoReposicion.Notas
            'Dim ParUsuario As New SqlParameter("@Usuario_id", SqlDbType.Int, 0)
            'ParUsuario.Value = 1
            Dim ParComprado As New SqlParameter("@PedidoReposicion_Comprado", SqlDbType.Bit, 0)
            ParComprado.Value = 0
            Conectividad.EjecutarComando("Reposicion_Update", New SqlParameter() {ParId, ParNotas, ParComprado, ParEstado})

        Catch ex As Exception
            Throw New Exception("Actualizar Reposicion: " & ex.Message.ToString())
        End Try

    End Sub

    Public Sub ActualizarEstadoReposicion(ByVal PedidoID As Integer, ByVal EstadoId As Integer)
        Dim ParId As New SqlParameter("@PedidoReposicion_id", SqlDbType.Int, 0)
        ParId.Value = IIf(PedidoID = 0, DBNull.Value, PedidoID)
        Dim ParEstado As New SqlParameter("@PedidoReposicionEstado_id", SqlDbType.Int, 0)
        ParEstado.Value = IIf(EstadoId = 0, DBNull.Value, EstadoId)
        Conectividad.EjecutarComando("Reposicion_Estado_Update", New SqlParameter() {ParId, ParEstado})
    End Sub

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Reposicion
        Dim UnaReposicion As New Reposicion
        UnaReposicion.ID = fila("PedidoReposicion_id")
        UnaReposicion.Estado = fila("PedidoReposicionEstado_id")
        UnaReposicion.Fecha = fila("PedidoReposicion_fecha")
        UnaReposicion.Notas = fila("PedidoReposicion_Notas").ToString()

        Return UnaReposicion
    End Function

End Class
