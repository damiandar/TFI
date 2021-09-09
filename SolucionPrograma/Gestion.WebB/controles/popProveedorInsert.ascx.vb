
Partial Class controles_popProveedorInsert
    Inherits System.Web.UI.UserControl

    Public Enum Tipo
        Proveedor = 1
        Cliente = 2
    End Enum


    Private pTipo As Tipo
    Public Property TipoIngreso() As Tipo
        Get
            Return pTipo
        End Get
        Set(ByVal value As Tipo)
            pTipo = value
        End Set
    End Property

    Public Event InsertoProveedor()

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim Login As String = ""
        Login = Request.QueryString("login")
        LLenarCombo()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click
        Try

            NuevoProveedor()
            RaiseEvent InsertoProveedor()
            Label1.Text = "Se inserto correctamente"
        Catch ex As Exception
            Label1.Text = ex.Message.ToString()
        End Try
    End Sub


    Protected Sub btnActualizar_Click(sender As Object, e As System.EventArgs) Handles btnActualizar.Click
        ActualizarProveedor()
        Dim CSM As ClientScriptManager = Page.ClientScript
        Dim script As String = "<script type='text/javascript'>$('#mymodal').modal('hide'); </script>"
        CSM.RegisterClientScriptBlock(Me.GetType, "Test", script)
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
            UnProveedor.Responsable = New ResponsabilidadFiscal(comboResponsabilidad.SelectedValue, "")


            Gestor.InsertarProveedor(UnProveedor)
        Catch ex As Exception
            Throw New Exception("Error al crear cuenta")
        End Try

    End Sub

    Private Sub ActualizarProveedor()
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
            UnProveedor.Responsable = New ResponsabilidadFiscal(comboResponsabilidad.SelectedValue, "")


            Gestor.ModificarProveedor(UnProveedor)
        Catch ex As Exception
            Throw New Exception("Error al crear cuenta")
        End Try

    End Sub
    Public Sub MostrarProveedor(ByVal Id As Integer)
        Try
            Dim Gestor As New BLLProveedor()
            Dim UnProveedor As New Proveedor()
            UnProveedor = Gestor.MostrarProveedor(Id)
            tbCuit.Text = UnProveedor.CUIT
            tbCodigoPostal.Text = UnProveedor.CP
            tbContacto.Text = UnProveedor.Contacto
            tbDomicilio.Text = UnProveedor.Domicilio
            'UnProveedor.Estado = True
            tbLocalidad.Text = UnProveedor.Localidad
            tbMail.Text = UnProveedor.Mail
            comboProvincia.SelectedValue = UnProveedor.Provincia.ID
            tbRazonSocial.Text = UnProveedor.Razon
            tbTelefono.Text = UnProveedor.Telefono
            tbWEB.Text = UnProveedor.WEB
            comboResponsabilidad.SelectedValue = UnProveedor.Responsable.ID

        Catch ex As Exception
            Throw New Exception("Error al mostrar proveedor")
        End Try

    End Sub

#End Region

End Class
