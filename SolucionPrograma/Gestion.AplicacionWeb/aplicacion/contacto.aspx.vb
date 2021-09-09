Imports Tsu.Mail
Imports Tsu.Seguridad
Imports Tsu.Utilidades

Imports Tsu.ProviderOra

Imports System.IO.TextWriter

Partial Class aplicacion_contacto
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
 
    End Sub

    Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar.Click
        ' Enviar()
        'verifico si cargaron todos los campos
        If Page.IsValid Then
            If (tbTelefono.Text = "" And tbCelular.Text = "" And tbMail.Text = "") Or tbConsulta.Text = "" Or (HttpContext.Current.User.IsInRole("G")) Then
                MensajeError.Visible = True
                Enviado.Visible = False
                NOEnviado.Visible = False
            Else
                Try
                    EnviarMail()
                Catch ex As Exception
                    'si da error al enviar
                    MensajeError.Visible = False
                    Enviado.Visible = False
                    NOEnviado.Visible = True
                    'guardo en el log el error
                    UtilLogBase.Guardar(Tsu.Entity.LogBase.TipoLog.NoEnviaMail, Session("cuenta"), "Formulario de contacto/confirmar: " & ex.Message.ToString())
                End Try
            End If
        End If

    End Sub

#Region "Metodos Privados"

    Private Sub EnviarMail()
        'trato de mandar el mail, si se produce un error muestro mensajes
        Dim ident As FormsIdentity = CType(HttpContext.Current.User.Identity, FormsIdentity)
        Dim ticket As FormsAuthenticationTicket = ident.Ticket
        Dim ci As New CustomIdentity(ticket)

        Dim miCorreo As New mail()
        miCorreo.asunto = "CONSULTA PEDIDOS ONLINE"
        miCorreo.cuerpomensaje = "Nombre: " & ci.ApellidoNombre & _
        "</br>Cuenta: " & ci.Name & _
        "</br>Zona: " & ci.Zona & " Grupo:" & ci.Grupo & _
        "</br>Telefono: " & tbTelefono.Text & _
        "</br>Celular: " & tbCelular.Text & _
        "</br>Email: " & tbMail.Text & _
        "</br>Asunto: " & tbAsunto.Text & _
        "</br>Comentario:" & tbConsulta.Text

        'miCorreo.cuerpomensaje = CargarPlantilla()

        
            miCorreo.maildestino = "info@tsucosmeticos.com.ar"
            'miCorreo.cc = "drosso@tsucosmeticos.com.ar"
     
        miCorreo.EnviarMail()
        'si lo envía bien
        MensajeError.Visible = False
        Enviado.Visible = True
        NOEnviado.Visible = False
        LimpiarDatos()
    End Sub

    Private Function CargarPlantilla() As String
        Dim sb As New StringBuilder()

        Dim ctrl As UserControl = CType(LoadControl("~/controles/plantillamail.ascx"), UserControl)

        Dim sw As New System.IO.StringWriter(sb)
        Dim htw As New Html32TextWriter(sw)
        ctrl.RenderControl(htw)
        'Get full body text 

        Dim body As String = sb.ToString()


        Return body
    End Function


    Private Sub LimpiarDatos()
        tbAsunto.Text = ""
        tbCelular.Text = ""
        tbConsulta.Text = ""
        tbMail.Text = ""
        tbTelefono.Text = ""
    End Sub

#End Region


    'Private Sub algo()


    '    Dim View As System.Net.Mail.AlternateView
    '    Dim resource As System.Net.Mail.LinkedResource
    '    Dim client As SmtpClient



    '    Dim msgText As New StringBuilder

    '    msgText.Append("Hi there,")
    '    msgText.Append("Welcome to the new world programming.")
    '    msgText.Append("Thanks")
    '    msgText.Append("With regards,")
    '    msgText.Append("")

    '    'create an alternate view for your mail
    '    View = System.Net.Mail.AlternateView.CreateAlternateViewFromString(msgText.ToString(), Nothing, "text/html")

    '    'link the resource to embed
    '    resource = New System.Net.Mail.LinkedResource((Server.MapPath("Images\007jvr.gif")))

    '    'name the resource
    '    resource.ContentId = "Image1"

    '    'add the resource to the alternate view
    '    View.LinkedResources.Add(resource)

    '    'add the view to the message
    '    msg.AlternateViews.Add(View)

    '    client = New SmtpClient()
    '    client.Host = "smtp.gmail.com" 'specify your smtp server name/ip here
    '    'client.EnableSsl = True 
    '    'enable this if your smtp server needs SSL to communicate
    '    client.Credentials = New Net.NetworkCredential("username", "pwd")
    '    client.Send(msg)
    'End Sub
End Class
