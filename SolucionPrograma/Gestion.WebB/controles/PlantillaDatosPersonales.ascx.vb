
Namespace Tsu.Paginas

    Partial Class controles_PlantillaDatosPersonales
        Inherits System.Web.UI.UserControl

        Public Event NoEncontroDatos(ByVal Mensaje As String)


        Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                LLenarCombo()
            End If
        End Sub

        Public Sub LLenar(ByVal cuenta As Integer)
            Try
                Dim iCuenta As Integer = Convert.ToInt32(cuenta)
                ViewState("cuenta") = iCuenta
                Dim GestorCuenta As New BLLCliente
                Dim UnaCuenta As Cliente = GestorCuenta.MostrarCliente(iCuenta)
                ltCodigoPostal.Text = UnaCuenta.CP
                ltDomicilio.Text = UnaCuenta.Domicilio.ToString
                ltLocalidad.Text = UnaCuenta.Localidad.ToString
                ltProvincia.Text = UnaCuenta.Provincia.Descripcion.ToString()
                ltTelefono.Text = UnaCuenta.Telefono
                ltCuit.Text = UnaCuenta.CUIT.ToString()
                ltRazonSocial.Text = UnaCuenta.Razon.ToString()
                ltMail.Text = UnaCuenta.Mail
                comboProvincia.SelectedValue = UnaCuenta.Provincia.ID
                comboResponsabilidad.SelectedValue = UnaCuenta.Responsable.ID
                'LLenarDatosBasicos(iCuenta)
                'LLenarDatosTransferidosAS(iCuenta)
            Catch ex As Exception
                Response.Write(ex.Message.ToString())
                'UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, cuenta, "App/DatosPersonales/LLenar:" & ex.Message.ToString())
            End Try
        End Sub

        Public Sub LLenarEdicion(ByVal Cuenta As Integer)
            Try
                PanelMostrar.Visible = False
                PanelEdicion.Visible = True

                Dim iCuenta As Integer = Convert.ToInt32(Cuenta)
                ViewState("cuenta") = iCuenta
                Dim GestorCuenta As New BLLCliente
                Dim UnaCuenta As Cliente = GestorCuenta.MostrarCliente(iCuenta)
                tbCodigoPostal.Text = UnaCuenta.CP
                tbDomicilio.Text = UnaCuenta.Domicilio.ToString
                tbLocalidad.Text = UnaCuenta.Localidad.ToString
                tbTelefono.Text = UnaCuenta.Telefono
                tbCuit.Text = UnaCuenta.CUIT.ToString()
                tbRazonSocial.Text = UnaCuenta.Razon.ToString()
                tbMail.Text = UnaCuenta.Mail
                comboProvincia.SelectedValue = UnaCuenta.Provincia.ID
                comboResponsabilidad.SelectedValue = UnaCuenta.Responsable.ID
                'LLenarDatosBasicos(iCuenta)
                'LLenarDatosTransferidosAS(iCuenta)
                LLenarCombo()
            Catch ex As Exception
                Response.Write(ex.Message.ToString())
                'UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, cuenta, "App/DatosPersonales/LLenar:" & ex.Message.ToString())
            End Try

            'ltMail.Text = IIf(oUsuarios.mail.ToString() Is String.Empty, "-", oUsuarios.mail.ToString())
            'ltTelefono.Text = IIf(oUsuarios.telefono.ToString() Is String.Empty, "-", oUsuarios.telefono.ToString())
            'ltCelular.Text = IIf(oUsuarios.celular = 0, "-", oUsuarios.celular.ToString())
        End Sub

#Region "Botones"

        Protected Sub btnModificar_Click(sender As Object, e As System.EventArgs) Handles btnModificar.Click
            Try
                Dim UnaCuenta As New Cliente
                Dim GestorCliente As New BLLCliente
                UnaCuenta.ID = CInt(ViewState("cuenta"))

                UnaCuenta.Domicilio = tbDomicilio.Text.Trim
                UnaCuenta.Localidad = tbLocalidad.Text.Trim
                UnaCuenta.Telefono = tbTelefono.Text.Trim
                UnaCuenta.Contacto = tbContacto.Text.Trim
                UnaCuenta.Razon = tbRazonSocial.Text.Trim
                UnaCuenta.Mail = tbMail.Text.Trim
                UnaCuenta.CUIT = tbCuit.Text.Trim
                UnaCuenta.WEB = tbWeb.Text.Trim
                UnaCuenta.CP = tbCodigoPostal.Text.Trim

                UnaCuenta.Provincia = New Provincias(comboProvincia.SelectedValue, "")
                UnaCuenta.Responsable = New ResponsabilidadFiscal(comboResponsabilidad.SelectedValue, "")
                GestorCliente.ModificarCliente(UnaCuenta)
                PanelMostrar.Visible = True
                PanelEdicion.Visible = False
            Catch ex As Exception
                Dim mensaje As String = ""
                mensaje = ex.Message.ToString()
            End Try
        End Sub

        Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
            PanelMostrar.Visible = True
            PanelEdicion.Visible = False
        End Sub
#End Region


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

        Private Sub MostrarDatosVacios()
            ltCodigoPostal.Text = "-"
            ltDomicilio.Text = "-"
            ltLocalidad.Text = "-"
            ltProvincia.Text = "-"
        End Sub

        Private Sub Limpiar()
            tbCodigoPostal.Text = ""
            tbDomicilio.Text = ""
            tbLocalidad.Text = ""
            tbTelefono.Text = ""
            tbCuit.Text = ""
            tbRazonSocial.Text = ""
            tbMail.Text = ""
        End Sub
#End Region

    End Class

End Namespace