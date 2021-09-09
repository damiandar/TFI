
Partial Class controles_popCuentaInsert
    Inherits System.Web.UI.UserControl

   
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim Login As String = ""
        Login = Request.QueryString("login")
        If Not Login = "" Or Login IsNot Nothing Then
            LLenarCombo()

            ViewState("mail") =
            tbMail.Text = Request.QueryString("login").ToString()
            tbMail.ReadOnly = True

        Else
            Response.Redirect("default.aspx")
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            NuevoCliente()
            Label1.Text = "Se inserto correctamente"
        Catch ex As Exception
            Label1.Text = ex.Message.ToString()
        End Try
    End Sub

#Region "Metodos Privados"

    Private Sub LLenarCombo()
        Dim GestorProvincias As New BLLProvincia
        comboProvincia.DataTextField = "descripcion"
        comboProvincia.DataValueField = "id"
        comboProvincia.DataSource = GestorProvincias.ListarProvincias()
        comboProvincia.DataBind()

        Dim GestorResponsabilidad As New BLLResponsabilidadFiscal
        comboResponsabilidad.DataTextField = "descripcion"
        comboResponsabilidad.DataValueField = "id"
        comboResponsabilidad.DataSource = GestorResponsabilidad.ListarResponsabilidades()
        comboResponsabilidad.DataBind()
    End Sub

    Private Sub NuevoProveedor()
        Try
            Dim Gestor As New BLLProveedor()
            Dim UnProveedor As New Proveedor()
            UnProveedor.CUIT = tbCuit.Text
            UnProveedor.CP = tbCodigoPostal.Text
            UnProveedor.Contacto = tbContacto.Text
            UnProveedor.Domicilio = tbDomicilio.Text
            UnProveedor.Estado = True
            UnProveedor.Localidad = tbLocalidad.Text
            UnProveedor.Mail = tbMail.Text
            UnProveedor.Provincia = New Provincias(comboProvincia.SelectedValue, "")
            UnProveedor.Razon = tbRazonSocial.Text
            UnProveedor.Telefono = tbTelefono.Text
            UnProveedor.WEB = tbWEB.Text
            UnProveedor.Responsable = New ResponsabilidadFiscal(1, "Monotributo")
            UnProveedor.Provincia = New Provincias(1, "CABA")

            Gestor.InsertarProveedor(UnProveedor)
        Catch ex As Exception
            Throw New Exception("Error al crear cuenta")
        End Try

    End Sub

    Private Sub NuevoCliente()
        Try
            Dim Gestor As New BLLCliente()
            Dim UnCliente As New Cliente()
            UnCliente.CUIT = tbCuit.Text
            UnCliente.CP = tbCodigoPostal.Text
            UnCliente.Contacto = tbContacto.Text
            UnCliente.Domicilio = tbDomicilio.Text
            UnCliente.Estado = True
            UnCliente.Localidad = tbLocalidad.Text
            UnCliente.Mail = ViewState("mail")
            UnCliente.Provincia = New Provincias(comboProvincia.SelectedValue, "")
            UnCliente.Razon = tbRazonSocial.Text
            UnCliente.Telefono = tbTelefono.Text
            UnCliente.WEB = tbWEB.Text
            UnCliente.Responsable = New ResponsabilidadFiscal(1, "Monotributo")
            UnCliente.Provincia = New Provincias(1, "CABA")

            Gestor.InsertarCliente(UnCliente)
        Catch ex As Exception
            Throw New Exception("Error al crear cuenta")
        End Try

    End Sub

#End Region

    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class
