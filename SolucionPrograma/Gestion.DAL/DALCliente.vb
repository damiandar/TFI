Imports System.Data
Imports System.Data.SqlClient

Public Class DALCliente
    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Sub InsertarCuenta(ByVal UnProveedor As Cliente)
        Try
            Conectividad.EjecutarComando("Cuenta_Insert", Me.ConstruirParametros(UnProveedor))
        Catch ex As Exception
            Throw New Exception("Insertar proveedor:" & ex.Message.ToString())
        End Try
    End Sub

    Public Sub ModificarCuenta(ByVal UnProveedor As Cliente)
        Try
            Conectividad.EjecutarComando("Cuenta_Update", ConstruirParametros(UnProveedor))
        Catch ex As Exception
            Throw New Exception("Modificar proveedor:" & ex.Message.ToString())
        End Try
    End Sub

    Public Sub BorrarProveedor(ByVal ClienteId As Integer)
        Try
            Dim ParId As New SqlParameter("@cuenta_id", SqlDbType.Int, 0)
            ParId.Value = ClienteId
            Conectividad.EjecutarComando("Cuenta_Update", New SqlParameter() {ParId})
        Catch ex As Exception
            Throw New Exception("Borrar Proveedor: " & ex.Message.ToString())
        End Try
    End Sub

    Public Function ListarCuentas(ByVal CuentaID As Integer, ByVal cuit As String) As List(Of Cliente)
        Try
            Dim ParId As New SqlParameter("@cuenta_id", SqlDbType.Int, 0)
            ParId.Value = IIf(CuentaID = 0, DBNull.Value, CuentaID)

            Dim ParCuit As New SqlParameter("@cuenta_cuit", SqlDbType.VarChar, 13)
            ParCuit.Value = IIf(cuit.Trim().Length = 0, DBNull.Value, cuit.Trim())

            Dim dt As DataTable = Conectividad.MostrarDataTable("Cuenta_Show", New SqlParameter() {ParId, ParCuit})
            Dim ListadoProveedores As New List(Of Cliente)
            For Each fila As DataRow In dt.Rows
                ListadoProveedores.Add(ConstruirObjetoConRegistro(fila))
            Next
            Return ListadoProveedores
        Catch ex As Exception
            Throw New Exception("Listar Proveedores:" & ex.Message.ToString())
        End Try

    End Function


    Public Function BuscarPorLogin(ByVal login As String) As Cliente
        Dim ParLogin As New SqlParameter("@login", SqlDbType.VarChar, 50)
        ParLogin.Value = login
        Dim dt As DataTable = Conectividad.MostrarDataTable("CuentaLogin_Show", New SqlParameter() {ParLogin})
        Dim unCliente As New Cliente
        If dt.Rows.Count > 0 Then
            unCliente = New Cliente
            unCliente.ID = dt.Rows(0).Item("cuenta_id")

            'unCliente = ConstruirObjetoConRegistro(dt.Rows(0))
        Else
            unCliente = Nothing
        End If

        Return unCliente
    End Function

#Region "Metodos Privados"

    Private Function ConstruirParametros(ByVal UnCliente As Cliente) As SqlParameter()

        Dim ParId As New SqlParameter("@cuenta_id", SqlDbType.Int, 0)
        ParId.Value = IIf(UnCliente.ID = 0, DBNull.Value, UnCliente.ID)
        Dim ParRazonSocial As New SqlParameter("@cuenta_RazonSocial", SqlDbType.VarChar, 50)
        ParRazonSocial.Value = UnCliente.Razon
        Dim ParDomicilioLegal As New SqlParameter("@cuenta_DomicilioLegal", SqlDbType.VarChar, 50)
        ParDomicilioLegal.Value = UnCliente.Domicilio
        Dim ParTelefono As New SqlParameter("@cuenta_Telefono", SqlDbType.VarChar, 50)
        ParTelefono.Value = UnCliente.Telefono
        Dim ParMail As New SqlParameter("@cuenta_mail", SqlDbType.VarChar, 50)
        ParMail.Value = UnCliente.Mail
        Dim ParWeb As New SqlParameter("@cuenta_web", SqlDbType.VarChar, 50)
        ParWeb.Value = UnCliente.WEB
        Dim ParContacto As New SqlParameter("@cuenta_Contacto", SqlDbType.VarChar, 50)
        ParContacto.Value = UnCliente.Contacto
        Dim ParLocalidad As New SqlParameter("@cuenta_localidad", SqlDbType.VarChar, 50)
        ParLocalidad.Value = UnCliente.Localidad
        Dim ParCP As New SqlParameter("@cuenta_CP", SqlDbType.VarChar, 50)
        ParCP.Value = UnCliente.CP
        Dim ParCuit As New SqlParameter("@cuenta_cuit", SqlDbType.VarChar, 13)
        ParCuit.Value = UnCliente.CUIT
        Dim ParEstado As New SqlParameter("@cuenta_estado", SqlDbType.Bit, 0)
        ParEstado.Value = UnCliente.Estado
        Dim ParResponsable As New SqlParameter("@TipoResponsable_id", SqlDbType.Int, 0)
        ParResponsable.Value = UnCliente.Responsable.ID
        Dim ParProvincia As New SqlParameter("@provincia_codigo", SqlDbType.Int, 0)
        ParProvincia.Value = UnCliente.Provincia.ID

        Return New SqlParameter() {ParRazonSocial, ParId, ParDomicilioLegal, ParTelefono, ParMail, ParWeb, ParContacto, ParLocalidad, ParCP, ParProvincia, ParCuit, ParEstado, ParResponsable}

    End Function

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Cliente
        Dim UnCliente As New Cliente
        UnCliente.ID = fila("cuenta_id")
        UnCliente.Razon = fila("cuenta_RazonSocial")
        UnCliente.Domicilio = IIf(fila("cuenta_DomicilioLegal") Is DBNull.Value, "", fila("cuenta_DomicilioLegal"))
        UnCliente.Telefono = IIf(fila("cuenta_Telefono") Is DBNull.Value, "", fila("cuenta_Telefono"))
        UnCliente.Mail = IIf(fila("cuenta_mail") Is DBNull.Value, "", fila("cuenta_mail"))
        UnCliente.WEB = IIf(fila("cuenta_web") Is DBNull.Value, "", fila("cuenta_web"))
        UnCliente.Contacto = IIf(fila("cuenta_Contacto") Is DBNull.Value, "", fila("cuenta_contacto"))
        UnCliente.Localidad = IIf(fila("cuenta_localidad") Is DBNull.Value, "", fila("cuenta_localidad"))
        UnCliente.CP = IIf(fila("cuenta_CP") Is DBNull.Value, "", fila("cuenta_CP"))
        UnCliente.CUIT = fila("cuenta_cuit")
        UnCliente.Estado = CBool(fila("cuenta_estado"))
        UnCliente.Provincia = New Provincias(CInt(fila("provincia_codigo")), fila("provincia_nombre"))
        UnCliente.Responsable = New ResponsabilidadFiscal(CInt(fila("TipoResponsable_id")), fila("TipoResponsable_Descripcion").ToString())

        Return UnCliente
    End Function

#End Region

End Class
