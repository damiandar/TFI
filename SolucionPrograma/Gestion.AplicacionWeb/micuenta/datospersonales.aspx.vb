Imports Tsu.ProviderOra

Imports Tsu.Seguridad
Imports Tsu.Mail
Imports Tsu.Utilidades


Namespace Tsu.Paginas

    Partial Class datospersonales
        Inherits System.Web.UI.Page


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Not Page.IsPostBack Then
                Dim cuenta As Integer = Convert.ToInt32(Session("cuenta"))
                ' PlantillaDatosPersonales1.llenar(cuenta)
            End If

        End Sub

#Region "Envio de mail"

        Protected Sub lnkEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkEnviar.Click
            Try
                'trato de mandar el mail, si se produce un error muestro mensajes

                EnviarMailGDZ()
            Catch ex As Exception
                'si no se envío el mail
                Enviado.Visible = False
                NOEnviado.Visible = True
                'guardo en el log el error
                UtilLogBase.Guardar(Tsu.Entity.LogBase.TipoLog.NoEnviaMail, Session("cuenta"), "No pudo enviar el alerta a la gerente por diferencia en los datos personales. Zona= " & Session("zona"))
            End Try

        End Sub

        Private Sub EnviarMailGDZ()
            Dim ident As FormsIdentity = CType(HttpContext.Current.User.Identity, FormsIdentity)
            Dim ticket As FormsAuthenticationTicket = ident.Ticket
            Dim ci As New CustomIdentity(ticket)

            Dim miCorreo As New Tsu.Mail.mail()

            miCorreo.asunto = "CAMBIO DE DATOS PERSONALES - VIA WEB"
            miCorreo.cuerpomensaje = ArmarTextoMail(ci)
            miCorreo.maildestino = "gz" & Format(ci.Zona, "000").ToString() & "@gz.in.ar"

            miCorreo.EnviarMail()
            'si lo envía bien
            Enviado.Visible = True
            NOEnviado.Visible = False
            UtilLogBase.GuardarEvento(LogBase.TipoLogEvento.DatosPersonales, ci.Name, "Cambio Datos Personales")
        End Sub

        Private Function ArmarTextoMail(ByVal ci As CustomIdentity) As String
            Dim oDatosUsuariosMapOra As New DatosUsuariosMapOra()
            Dim MisDatos As DatosUsuarios = New DatosUsuariosMapOra().MostrarDatosUsuarios(ci.Name)

            Dim NombreGDZ As String = New UsuarioMapOra().NombreGDZ(ci.Zona)

            Dim celular As String = IIf(MisDatos.celular = 0, String.Empty, MisDatos.celular.ToString())
            Dim provincia As String = New UtilProvincia().getProvincia(MisDatos.provincia)
            Dim FechaNacimiento As String = Format(MisDatos.fechanacimiento, "000000").ToString().Insert(2, "/").Insert(5, "/")

            Dim mensaje As String = "<p>Estimada " & NombreGDZ & "</br></br>Le notificamos que " & _
         ci.ApellidoNombre & ", grupo " & ci.Grupo & ", ha ingresado al Espacio TSU.</p> " & _
        "<p>El motivo de mail es para informarle que alguno de sus datos personales, registrados en el sistema, no son correctos o los mismos están incompletos.</p> " & _
        "<p>Por este motivo le solicitamos que se ponga en contacto con ella, con el fin de actualizar los datos en el" & _
        " próximo Resumen de Campaña (RC).</p>" & _
        "</br>Nombre y apellido: " & ci.ApellidoNombre & _
        "</br>Nº de cuenta: " & Session("Cuenta").ToString() & _
        "</br>Documento: " & ci.DocumentoNro & _
        "</br>Fecha de Nacimiento: " & FechaNacimiento & _
        "</br>Domicilio: " & MisDatos.domicilio1 & _
        "</br>Localidad: " & MisDatos.localidad & _
        "</br>Cod. Postal: " & MisDatos.codigopostal & _
        "</br>Provincia: " & provincia & _
        "</br>Teléfono: " & MisDatos.telefono & _
        "</br>Celular: " & celular & _
        "</br>E-mail: " & MisDatos.mail & _
        "<p>Muchas Gracias!</p>" & _
        "<p>TSU Cosméticos</p>" & _
        "</br><p>Este correo se genera y se envía de forma automática. Por favor no lo responda</p>"
            Return mensaje
        End Function

#End Region

#Region "Eventos de la plantilla"

     

#End Region

    End Class
End Namespace