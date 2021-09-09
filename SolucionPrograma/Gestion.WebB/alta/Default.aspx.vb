
Partial Class alta_Default
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim Login As String = ""
        Login = Request.QueryString("login")
        If Not Login = "" Or Login IsNot Nothing Then
            LLenarCombo()

            ViewState("mail") = Login
            tbMail.Text = Login
            tbMail.ReadOnly = True
        Else
            Response.Redirect("default.aspx")
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            NuevoCliente(ViewState("mail").ToString())
            Label1.Text = "Se insertó correctamente"
            LimpiarFormulario()
            Dim s As String = "$('#myModal').modal('show');"
            ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)

        Catch ex As Exception
            Label1.Text = ex.Message.ToString()
            Label1.ForeColor = Drawing.Color.Red
        End Try
    End Sub


    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Response.Redirect("../frontend/default.aspx")
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

    Private Sub NuevoCliente(ByVal Mail As String)

        If Mail.Length = 0 Then
            Throw New Exception("ERROR: CIERRE LA SESION y VUELVA A ENTRAR")
        End If
        Dim Gestor As New BLLCliente()
        Dim UnCliente As New Cliente()
        UnCliente.CUIT = tbCuit.Text
        UnCliente.CP = tbCodigoPostal.Text
        UnCliente.Contacto = tbContacto.Text
        UnCliente.Domicilio = tbDomicilio.Text
        UnCliente.Estado = True
        UnCliente.Localidad = tbLocalidad.Text
        UnCliente.Mail = Mail
        UnCliente.Provincia = New Provincias(comboProvincia.SelectedValue, "")
        UnCliente.Razon = tbRazonSocial.Text
        UnCliente.Telefono = tbTelefono.Text
        UnCliente.WEB = tbWEB.Text
        UnCliente.Responsable = New ResponsabilidadFiscal(comboResponsabilidad.SelectedValue, "")
        UnCliente.Provincia = New Provincias(comboProvincia.SelectedValue, "")
        Gestor.InsertarCliente(UnCliente)

    End Sub

    Private Sub LimpiarFormulario()
        ViewState("mail") = ""
        tbCuit.Text = ""
        tbCodigoPostal.Text = ""
        tbContacto.Text = ""
        tbDomicilio.Text = ""
        tbLocalidad.Text = ""
        tbRazonSocial.Text = ""
        tbTelefono.Text = ""
        tbWEB.Text = ""
    End Sub


#End Region

End Class
