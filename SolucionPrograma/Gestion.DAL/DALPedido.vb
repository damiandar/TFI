Imports System.Data
Imports System.Data.SqlClient

Public Class DALPedido


    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function InsertarPedido(ByVal UnPedido As Pedido) As Integer
        Try
            Dim ParDomicilio As New SqlParameter("@domicilioenvio_id", SqlDbType.Int, 0)
            ParDomicilio.Value = UnPedido.domicilioenvio.ID
            Dim ParCuenta As New SqlParameter("@Cuenta_id", SqlDbType.Int, 0)
            ParCuenta.Value = UnPedido.cliente.ID
            Dim ParEstado As New SqlParameter("@pedido_estado", SqlDbType.TinyInt, 0)
            ParEstado.Value = 1
            Dim ParFecha As New SqlParameter("@pedido_fechacreacion", SqlDbType.DateTime, 0)
            ParFecha.Value = UnPedido.Fecha
            Dim ParFormaEnvio As New SqlParameter("@formaenvio_id", SqlDbType.Int, 0)
            ParFormaEnvio.Value = UnPedido.FormaEnvio.ID
            Dim ParFormaPago As New SqlParameter("@formapago_id", SqlDbType.Int, 0)
            ParFormaPago.Value = UnPedido.formapago.ID
            Dim ParNotas As New SqlParameter("@pedido_notas", SqlDbType.VarChar, 50)
            ParNotas.Value = ""
            Return Conectividad.EjecutarScalar("Pedido_Insert", New SqlParameter() {ParCuenta, ParEstado, ParFecha, ParFormaEnvio, ParFormaPago, ParNotas, ParDomicilio})
        Catch ex As Exception
            Throw New Exception("Insertar pedido:" & ex.Message.ToString())
        End Try
    End Function

    Public Sub ModificarPedido(ByVal UnPedido As Pedido)
        Try
            Dim ParDomicilio As New SqlParameter("@domicilioenvio_id", SqlDbType.Int, 0)
            ParDomicilio.Value = UnPedido.domicilioenvio.ID
            Dim ParPedido As New SqlParameter("@pedido_id", SqlDbType.Int, 0)
            ParPedido.Value = UnPedido.ID
            Dim ParFormaEnvio As New SqlParameter("@formaenvio_id", SqlDbType.Int, 0)
            ParFormaEnvio.Value = UnPedido.FormaEnvio.ID
            Dim ParFormaPago As New SqlParameter("@formapago_id", SqlDbType.Int, 0)
            ParFormaPago.Value = UnPedido.formapago.ID
            Dim ParEstado As New SqlParameter("@Pedido_estado", SqlDbType.Int, 0)
            ParEstado.Value = UnPedido.EstadoPedido
            Dim ParNotas As New SqlParameter("@pedido_notas", SqlDbType.VarChar, 50)
            ParNotas.Value = UnPedido.Notas
            Conectividad.EjecutarComando("Pedido_Update", New SqlParameter() {ParDomicilio, ParPedido, ParFormaEnvio, ParFormaPago, ParEstado, ParNotas})
        Catch ex As Exception
            Throw New Exception("Modificar pedido:" & ex.Message.ToString())
        End Try
    End Sub

    Public Function ListarPedidos(ByVal CuentaID As Integer, ByVal PedidoID As Integer, ByVal EstadoID As Integer) As List(Of Pedido)
        Try
            Dim Lista As New List(Of Pedido)
            Dim ParCuenta As New SqlParameter("@Cuenta_id", SqlDbType.Int, 0)
            ParCuenta.Value = IIf(CuentaID = 0, DBNull.Value, CuentaID)
            Dim ParID As New SqlParameter("@pedido_id", SqlDbType.Int, 0)
            ParID.Value = IIf(PedidoID = 0, DBNull.Value, PedidoID)
            Dim ParEstado As New SqlParameter("@Pedido_Estado", SqlDbType.Int, 0)
            ParEstado.Value = IIf(EstadoID = 0, DBNull.Value, EstadoID)

            Dim dt As DataTable = Conectividad.MostrarDataTable("Pedido_Show", New SqlParameter() {ParCuenta, ParID, ParEstado})
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    For Each fila As DataRow In dt.Rows
                        Lista.Add(ConstruirObjetoConRegistro(fila, True))
                    Next
                End If
            End If
            Return Lista
        Catch ex As Exception
            Throw New Exception("Listar Pedidos: " & ex.Message.ToString())
        End Try
    End Function

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow, ByVal MostrarCuenta As Boolean) As Pedido
        Dim UnPedido As New Pedido
        UnPedido.ID = fila("pedido_id")
        UnPedido.EstadoPedido = fila("EstadoPedido_id")
        UnPedido.FormaEnvio = New FormaEnvio(CInt(fila("formaenvio_id")), fila("formaenvio_descripcion").ToString())
        UnPedido.formapago = New FormaPago(CInt(fila("formapago_id")), fila("formapago_descripcion").ToString())
        UnPedido.Fecha = fila("pedido_fechacreacion")
        UnPedido.Notas = fila("pedido_notas")
        UnPedido.cliente = New Cliente(CInt(fila("cuenta_id")), fila("cuenta_cuit"), fila("cuenta_razonsocial"))
        UnPedido.cliente.Responsable = New ResponsabilidadFiscal(fila("tiporesponsable_id"), fila("tiporesponsable_descripcion"))
        UnPedido.cliente.Provincia = New Provincias(fila("provincia_codigo"), fila("provincia_nombre"))
        UnPedido.cliente.Mail = IIf(fila("cuenta_mail") Is DBNull.Value, "", fila("cuenta_mail"))
        'domicilio
        UnPedido.domicilioenvio = New DomicilioEnvio()
        UnPedido.domicilioenvio.ID = CInt(fila("domicilioenvio_id"))
        UnPedido.domicilioenvio.Direccion = IIf(fila("domicilioenvio_direccion") Is DBNull.Value, "", fila("domicilioenvio_direccion"))
        UnPedido.domicilioenvio.Telefono = IIf(fila("domicilioenvio_Telefono") Is DBNull.Value, "", fila("domicilioenvio_Telefono"))
        UnPedido.domicilioenvio.Localidad = IIf(fila("domicilioenvio_localidad") Is DBNull.Value, "", fila("domicilioenvio_localidad"))
        UnPedido.domicilioenvio.CP = IIf(fila("domicilioenvio_CP") Is DBNull.Value, "", fila("domicilioenvio_CP"))
        UnPedido.domicilioenvio.Provincia = New Provincias(CInt(fila("provincia_codigo")), fila("provincia_nombre"))
        Return UnPedido
    End Function


End Class
