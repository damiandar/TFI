Imports System.Data
Imports System.Data.SqlClient

Public Class DALReposicionItem

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Sub InsertarReposicionItem(ByVal PedidoId As Integer, ByVal UnItem As ReposicionItem)
        Try
            Dim ParPedido As New SqlParameter("@pedidoreposicion_id", SqlDbType.Int, 0)
            ParPedido.Value = PedidoId
            Dim ParInsumo As New SqlParameter("@insumo_id", SqlDbType.Int, 0)
            ParInsumo.Value = UnItem.insumo.ID
            Dim ParEstado As New SqlParameter("@EstadoItemPedido_id", SqlDbType.Int, 0)
            ParEstado.Value = UnItem.estado
            Dim ParCantidadPedida As New SqlParameter("@reposicionitem_cantidadPedida", SqlDbType.Int, 0)
            ParCantidadPedida.Value = UnItem.cantidadPedida
            Dim ParCantidadRestante As New SqlParameter("@reposicionitem_cantidadRestante", SqlDbType.Int, 0)
            ParCantidadRestante.Value = UnItem.cantidadPedida
            Dim ParCantidadEntregada As New SqlParameter("@reposicionitem_cantidadEntregada", SqlDbType.Int, 0)
            ParCantidadEntregada.Value = 0
            Dim ParPrioridad As New SqlParameter("@ReposicionItem_PrioridadDias", SqlDbType.Int, 0)
            ParPrioridad.Value = UnItem.Prioridad
            Dim ParEspecificacion As New SqlParameter("@reposicionitem_especificacion", SqlDbType.VarChar, 50)
            ParEspecificacion.Value = UnItem.Especificacion
            Conectividad.EjecutarComando("ReposicionItem_Insert", New SqlParameter() {ParInsumo, ParEstado, ParCantidadPedida, ParCantidadRestante, ParPrioridad, ParEspecificacion, ParCantidadEntregada, ParPedido})
        Catch ex As Exception
            Throw New Exception("Insertar Reposicion item:" & ex.Message.ToString())
        End Try
    End Sub

    Public Sub ActualizarReposicionItem(ByVal PedidoId As Integer, ByVal UnPedido As ReposicionItem)
        Try
            Dim ParPedido As New SqlParameter("@pedidoreposicion_id", SqlDbType.Int, 0)
            ParPedido.Value = PedidoId
            Dim ParProducto As New SqlParameter("@insumo_id", SqlDbType.Int, 0)
            ParProducto.Value = UnPedido.insumo.ID
            Dim ParEstado As New SqlParameter("@EstadoItemPedido_id", SqlDbType.Int, 0)
            ParEstado.Value = UnPedido.estado
            Dim ParCantidadPedida As New SqlParameter("@reposicionitem_cantidadPedida", SqlDbType.Int, 0)
            ParCantidadPedida.Value = UnPedido.cantidadPedida
            Dim ParCantidadRestante As New SqlParameter("@reposicionitem_cantidadRestante", SqlDbType.Int, 0)
            ParCantidadRestante.Value = UnPedido.cantidadRestante
            Dim ParCantidadEntregada As New SqlParameter("@reposicionitem_cantidadEntregada", SqlDbType.Int, 0)
            ParCantidadEntregada.Value = UnPedido.cantidadEntregada
            Dim ParPrioridad As New SqlParameter("@ReposicionItem_PrioridadDias", SqlDbType.Int, 0)
            ParPrioridad.Value = 1
            Conectividad.EjecutarComando("ReposicionItem_Update", New SqlParameter() {ParProducto, ParEstado, ParCantidadPedida, ParCantidadRestante, ParPrioridad, ParCantidadEntregada, ParPedido})
        Catch ex As Exception
            Throw New Exception("Actualizar Reposicion item:" & ex.Message.ToString())
        End Try
    End Sub

    Public Function ListarReposicionItem(ByVal PedidoId As Integer) As List(Of ReposicionItem)
        Dim ParPedido As New SqlParameter("@pedidoreposicion_id", SqlDbType.Int, 0)
        ParPedido.Value = PedidoId
        Dim Lista As New List(Of ReposicionItem)
        Dim dt As DataTable = Conectividad.MostrarDataTable("ReposicionItem_Show", New SqlParameter() {ParPedido})
        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then
                For Each fila As DataRow In dt.Rows
                    Lista.Add(ConstruirObjetoConRegistro(fila))
                Next
            End If
        End If
        Return Lista
    End Function


#Region "Metodos Privados"

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As ReposicionItem
        Dim UnItem As New ReposicionItem
        UnItem.cantidadEntregada = fila("reposicionitem_cantidadEntregada")
        UnItem.cantidadPedida = fila("reposicionitem_cantidadPedida")
        UnItem.cantidadRestante = fila("reposicionitem_cantidadRestante")
        UnItem.Especificacion = IIf(fila("reposicionitem_especificacion") Is DBNull.Value, "", fila("reposicionitem_especificacion"))
        UnItem.Prioridad = fila("reposicionitem_prioridaddias")
        UnItem.insumo = New Insumo
        UnItem.insumo.ID = fila("insumo_id")
        UnItem.insumo.Descripcion = fila("insumo_descripcion")
        UnItem.insumo.NombreCorto = fila("insumo_nombrecorto")
        UnItem.insumo.NombreLargo = fila("insumo_nombrelargo")
        Return UnItem
    End Function


#End Region

End Class
