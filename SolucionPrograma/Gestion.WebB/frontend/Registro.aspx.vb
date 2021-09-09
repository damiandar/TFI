
Partial Class frontend_Registro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
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
        End If
    End Sub

    Protected Sub lnkLogin_Click(sender As Object, e As System.EventArgs) Handles lnkLogin.Click
        'inserta el cliente
        NuevoCliente()
    End Sub

#Region "Metodos privados"

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
            UnCliente.Mail = tbMail.Text
            UnCliente.Provincia = New Provincias(comboProvincia.SelectedValue, "")
            UnCliente.Razon = tbRazonSocial.Text
            UnCliente.Telefono = tbTelefono.Text
            UnCliente.WEB = tbWEB.Text
            UnCliente.Responsable = New ResponsabilidadFiscal(1, "Monotributo")

            Gestor.InsertarCliente(UnCliente)
        Catch ex As Exception
            Throw New Exception("Error al crear cuenta")
        End Try

    End Sub
#End Region
End Class
