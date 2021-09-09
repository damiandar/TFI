Imports System.Data
Imports System.Data.SqlClient

Public Class DALProveedor
    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Sub InsertarProveedor(ByVal UnProveedor As Proveedor)
        Try
            Conectividad.EjecutarComando("Proveedor_Insert", Me.ConstruirParametros(UnProveedor))
        Catch ex As Exception
            Throw New Exception("Insertar proveedor:" & ex.Message.ToString())
        End Try
    End Sub

    Public Sub ModificarProveedor(ByVal UnProveedor As Proveedor)
        Try

            Conectividad.EjecutarComando("Proveedor_Update", ConstruirParametros(UnProveedor))

        Catch ex As Exception
            Throw New Exception("Modificar proveedor:" & ex.Message.ToString())
        End Try
    End Sub

    Public Sub BorrarProveedor(ByVal ProveedorId As Integer)
        Try
            Dim ParId As New SqlParameter("@Proveedor_id", SqlDbType.Int, 0)
            ParId.Value = ProveedorId
            Conectividad.EjecutarComando("Proveedor_Update", New SqlParameter() {ParId})
        Catch ex As Exception
            Throw New Exception("Borrar Proveedor: " & ex.Message.ToString())
        End Try
    End Sub

    Public Function ListarProveedores(ByVal CuentaID As Integer, ByVal cuit As String) As List(Of Proveedor)
        Try
            Dim ParId As New SqlParameter("@Proveedor_id", SqlDbType.Int, 0)
            ParId.Value = IIf(CuentaID = 0, DBNull.Value, CuentaID)

            Dim ParCuit As New SqlParameter("@Proveedor_cuit", SqlDbType.VarChar, 13)
            ParCuit.Value = IIf(cuit.Trim().Length = 0, DBNull.Value, cuit.Trim())


            Dim dt As DataTable = Conectividad.MostrarDataTable("Proveedor_Show", New SqlParameter() {ParId, ParCuit})
            Dim ListadoProveedores As New List(Of Proveedor)
            For Each fila As DataRow In dt.Rows
                ListadoProveedores.Add(ConstruirObjetoConRegistro(fila))
            Next
            Return ListadoProveedores
        Catch ex As Exception
            Throw New Exception("Listar Proveedores:" & ex.Message.ToString())
        End Try

    End Function

#Region "Metodos Privados"

    Private Function ConstruirParametros(ByVal UnaCuenta As Proveedor) As SqlParameter()
        'Dim ParID As New SqlParameter("@Cuenta_id", SqlDbType.Int, 0)
        'ParID.Value = UnaCuenta.ID
        Dim ParRazonSocial As New SqlParameter("@proveedor_RazonSocial", SqlDbType.VarChar, 50)
        ParRazonSocial.Value = UnaCuenta.Razon
        Dim ParDomicilioLegal As New SqlParameter("@proveedor_DomicilioLegal", SqlDbType.VarChar, 50)
        ParDomicilioLegal.Value = UnaCuenta.Domicilio
        Dim ParTelefono As New SqlParameter("@proveedor_Telefono", SqlDbType.VarChar, 50)
        ParTelefono.Value = UnaCuenta.Telefono
        Dim ParMail As New SqlParameter("@proveedor_mail", SqlDbType.VarChar, 50)
        ParMail.Value = UnaCuenta.Mail
        Dim ParWeb As New SqlParameter("@proveedor_web", SqlDbType.VarChar, 50)
        ParWeb.Value = UnaCuenta.WEB
        Dim ParContacto As New SqlParameter("@proveedor_Contacto", SqlDbType.VarChar, 50)
        ParContacto.Value = UnaCuenta.Contacto
        Dim ParLocalidad As New SqlParameter("@proveedor_localidad", SqlDbType.VarChar, 50)
        ParLocalidad.Value = UnaCuenta.Localidad
        Dim ParCP As New SqlParameter("@proveedor_CP", SqlDbType.VarChar, 50)
        ParCP.Value = UnaCuenta.CP
        Dim ParCuit As New SqlParameter("@proveedor_cuit", SqlDbType.VarChar, 13)
        ParCuit.Value = UnaCuenta.CUIT
        Dim ParEstado As New SqlParameter("@proveedor_estado", SqlDbType.Bit, 0)
        ParEstado.Value = UnaCuenta.Estado


        Dim ParResponsable As New SqlParameter("@TipoResponsable_id", SqlDbType.Int, 0)
        ParResponsable.Value = UnaCuenta.Responsable.ID

        Dim ParProvincia As New SqlParameter("@provincia_codigo", SqlDbType.VarChar, 50)
        ParProvincia.Value = UnaCuenta.Provincia.ID

        Return New SqlParameter() {ParRazonSocial, ParDomicilioLegal, ParTelefono, ParMail, ParWeb, ParContacto, ParLocalidad, ParCP, ParProvincia, ParCuit, ParEstado, ParResponsable}

    End Function

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Proveedor
        Dim UnaCuenta As New Proveedor
        UnaCuenta.ID = fila("Proveedor_id")
        UnaCuenta.Razon = fila("Proveedor_RazonSocial")
        UnaCuenta.Domicilio = IIf(fila("Proveedor_DomicilioLegal") Is DBNull.Value, "", fila("Proveedor_DomicilioLegal"))
        UnaCuenta.Telefono = IIf(fila("Proveedor_Telefono") Is DBNull.Value, "", fila("Proveedor_Telefono"))
        UnaCuenta.Mail = IIf(fila("Proveedor_mail") Is DBNull.Value, "", fila("Proveedor_mail"))
        UnaCuenta.WEB = IIf(fila("Proveedor_web") Is DBNull.Value, "", fila("Proveedor_web"))
        UnaCuenta.Contacto = IIf(fila("Proveedor_Contacto") Is DBNull.Value, "", fila("Proveedor_contacto"))
        UnaCuenta.Localidad = IIf(fila("Proveedor_localidad") Is DBNull.Value, "", fila("Proveedor_localidad"))
        UnaCuenta.CP = IIf(fila("Proveedor_CP") Is DBNull.Value, "", fila("Proveedor_CP"))
        UnaCuenta.CUIT = fila("Proveedor_cuit")
        UnaCuenta.Estado = CBool(fila("Proveedor_estado"))
        UnaCuenta.Provincia = New Provincias(CInt(fila("provincia_codigo")), fila("provincia_nombre"))
        UnaCuenta.Responsable = New ResponsabilidadFiscal(CInt(fila("TipoResponsable_id")), fila("TipoResponsable_Descripcion").ToString())

        Return UnaCuenta
    End Function

#End Region

End Class
