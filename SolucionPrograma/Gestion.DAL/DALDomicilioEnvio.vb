Imports System.Data
Imports System.Data.SqlClient

Public Class DALDomicilioEnvio


    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function InsertarDomicilio(ByVal UnDomicilio As DomicilioEnvio) As Integer
        Try
            Dim ParId As New SqlParameter("@domicilioenvio_id", SqlDbType.Int, 0)
            ParId.Value = IIf(UnDomicilio.ID = 0, DBNull.Value, UnDomicilio.ID)
            Dim ParDomicilioLegal As New SqlParameter("@domicilioenvio_direccion", SqlDbType.VarChar, 50)
            ParDomicilioLegal.Value = UnDomicilio.Direccion
            Dim ParTelefono As New SqlParameter("@domicilioenvio_Telefono", SqlDbType.VarChar, 50)
            ParTelefono.Value = UnDomicilio.Telefono
            Dim ParLocalidad As New SqlParameter("@domicilioenvio_localidad", SqlDbType.VarChar, 50)
            ParLocalidad.Value = UnDomicilio.Localidad
            Dim ParCP As New SqlParameter("@domicilioenvio_CP", SqlDbType.VarChar, 50)
            ParCP.Value = UnDomicilio.CP
            Dim ParProvincia As New SqlParameter("@domicilioenvio_codigo", SqlDbType.Int, 0)
            ParProvincia.Value = UnDomicilio.Provincia.ID
            Return Conectividad.EjecutarScalar("DomicilioEnvio_Insert", New SqlParameter() {ParId, ParDomicilioLegal, ParTelefono, ParLocalidad, ParCP, ParProvincia})
        Catch ex As Exception
            Throw New Exception("Insertar Domicilio:" & ex.Message.ToString())
        End Try
    End Function

    Public Sub ModificarDomicilio(ByVal UnDomicilio As DomicilioEnvio)
        Try

            Dim ParId As New SqlParameter("@domicilioenvio_id", SqlDbType.Int, 0)
            ParId.Value = IIf(UnDomicilio.ID = 0, DBNull.Value, UnDomicilio.ID)
            Dim ParDomicilioLegal As New SqlParameter("@domicilioenvio_direccion", SqlDbType.VarChar, 50)
            ParDomicilioLegal.Value = UnDomicilio.Direccion
            Dim ParTelefono As New SqlParameter("@domicilioenvio_Telefono", SqlDbType.VarChar, 50)
            ParTelefono.Value = UnDomicilio.Telefono
            Dim ParLocalidad As New SqlParameter("@domicilioenvio_localidad", SqlDbType.VarChar, 50)
            ParLocalidad.Value = UnDomicilio.Localidad
            Dim ParCP As New SqlParameter("@domicilioenvio_CP", SqlDbType.VarChar, 50)
            ParCP.Value = UnDomicilio.CP
            Dim ParProvincia As New SqlParameter("@domicilioenvio_codigo", SqlDbType.Int, 0)
            ParProvincia.Value = UnDomicilio.Provincia.ID

            Conectividad.EjecutarComando("Domicilio_Update", New SqlParameter() {ParId, ParDomicilioLegal, ParTelefono, ParLocalidad, ParCP, ParProvincia})

        Catch ex As Exception
            Throw New Exception("Modificar domicilio:" & ex.Message.ToString())
        End Try
    End Sub

    Public Function ListarDomicilios(ByVal CuentaID As Integer) As List(Of DomicilioEnvio)
        Try
            Dim Lista As New List(Of DomicilioEnvio)
            Dim ParCuenta As New SqlParameter("@Cuenta_id", SqlDbType.Int, 0)
            ParCuenta.Value = IIf(CuentaID = 0, DBNull.Value, CuentaID)
            Dim ParPedido As New SqlParameter("@Pedido_id", SqlDbType.Int, 0)
            ParPedido.Value = DBNull.Value
            Dim ParId As New SqlParameter("@domicilioenvio_id", SqlDbType.Int, 0)
            ParId.Value = DBNull.Value
            Dim dt As DataTable = Conectividad.MostrarDataTable("DomicilioEnvio_Show", New SqlParameter() {ParCuenta, ParPedido, ParId})
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    For Each fila As DataRow In dt.Rows
                        Lista.Add(ConstruirObjetoConRegistro(fila))
                    Next
                End If
            End If
            Return Lista
        Catch ex As Exception
            Throw New Exception("Listar Domicilios: " & ex.Message.ToString())
        End Try
    End Function

    Public Function MostrarDomicilioPorPedido(ByVal PedidoID As Integer) As DomicilioEnvio
        Try
            Dim UnPedido As New DomicilioEnvio
            Dim ParPedido As New SqlParameter("@Pedido_id", SqlDbType.Int, 0)
            ParPedido.Value = IIf(PedidoID = 0, DBNull.Value, PedidoID)
            Dim ParCuenta As New SqlParameter("@Cuenta_id", SqlDbType.Int, 0)
            ParCuenta.Value = DBNull.Value

            Dim ParId As New SqlParameter("@domicilioenvio_id", SqlDbType.Int, 0)
            ParId.Value = DBNull.Value

            Dim dt As DataTable = Conectividad.MostrarDataTable("DomicilioEnvio_Show", New SqlParameter() {ParPedido, ParCuenta, ParId})
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    UnPedido = ConstruirObjetoConRegistro(dt.Rows(0))
                End If
            End If
            Return UnPedido
        Catch ex As Exception
            Throw New Exception("Mostrar Domicilio: " & ex.Message.ToString())
        End Try
    End Function

#Region "Metodos Privados"
    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As DomicilioEnvio
        Dim UnDomicilio As New DomicilioEnvio
        UnDomicilio.ID = CInt(fila("domicilioenvio_id"))
        UnDomicilio.Direccion = IIf(fila("domicilioenvio_direccion") Is DBNull.Value, "", fila("domicilioenvio_direccion"))
        UnDomicilio.Telefono = IIf(fila("domicilioenvio_Telefono") Is DBNull.Value, "", fila("domicilioenvio_Telefono"))
        UnDomicilio.Localidad = IIf(fila("domicilioenvio_localidad") Is DBNull.Value, "", fila("domicilioenvio_localidad"))
        UnDomicilio.CP = IIf(fila("domicilioenvio_CP") Is DBNull.Value, "", fila("domicilioenvio_CP"))
        UnDomicilio.Provincia = New Provincias(CInt(fila("provincia_codigo")), fila("provincia_nombre"))
        Return UnDomicilio
    End Function

#End Region


End Class
