Imports System.Net.Mail


Partial Class controles_login_registrar
    Inherits System.Web.UI.UserControl

    Public Event SeInserto()
    Public Event SePincho(ByVal Mensaje As String)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub lnkLogin_Click(sender As Object, e As System.EventArgs) Handles lnkLogin.Click
        Try
            CrearUsuario(tbMail.Text, tbRazonSocial.Text, pwd.Text)
            CrearFamilia(tbMail.Text)
            RaiseEvent SeInserto()
        Catch ex As Exception
            lblMensaje.Text = ex.Message.ToString()
            RaiseEvent SePincho(ex.Message.ToString())
        End Try
        ' EnviarMail("En hora buena", "Bienvenido su contraseña es : XXXX", "damiandar@hotmail.com", "LAVADERO BOUTIQUE")
    End Sub

    Protected Sub ValidarMail(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CVMail2.ServerValidate
        args.IsValid = Me.ValidarMailExpresion(args.Value)
    End Sub

#Region "Metodos Privados"

    Private Sub CrearFamilia(ByVal login As String)
        Dim GestorFamilia As New Mapper_Familia
        GestorFamilia.AsignarRol(1, login)
    End Sub

    Private Sub CrearUsuario(ByVal Mail As String, ByVal Razon As String, ByVal PASS As String)
        Try
            If ValidarMailExpresion(Mail) = False Then
                Throw New Exception("Error al validar mail.")
            End If

            Dim GestorUsuarios As New Mapper_Usuario()
            Dim UnUsuario As New Usuario()
            UnUsuario.Login = Mail.ToString()
            UnUsuario.Nombre = Razon
            UnUsuario.FechaAlta = Now.Date
            UnUsuario.Contrasenia = PASS
            GestorUsuarios.InsertarUsuario(UnUsuario)

        Catch ex As Exception
            Throw New Exception("Error al crear usuario")
        End Try
    End Sub


    Private Function ValidarMailExpresion(ByVal sMail As String) As Boolean
        Dim exp1 As String = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        Dim exp2 As String = "^(?<user>[^@]+)@(?<host>.+)$"
        Dim emailRegex As New System.Text.RegularExpressions.Regex(exp1)

        Dim emailMatch As System.Text.RegularExpressions.Match = emailRegex.Match(sMail)
        Return emailMatch.Success
    End Function

    Private Sub EnviarMail(ByVal titulo As String, ByVal texto As String, ByVal destino As String, ByVal asunto As String)
        Dim GestorEnvio As New GestorMail()
        Dim sb As New StringBuilder()

        Dim ctrl As UserControl = CType(LoadControl("~/controles/plantillamail.ascx"), UserControl)
        ' ../assets/images/header.jpg
        ' ../assets/images/footer.jpg

        Dim sw As New System.IO.StringWriter(sb)
        Dim htw As New Html32TextWriter(sw)
        ctrl.RenderControl(htw)
        'Get full body text 
        Dim cadena As String = sb.ToString()
        cadena = cadena.Replace("[TITULO]", titulo)
        cadena = cadena.Replace("[TEXTO]", texto)
        Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(cadena, Nothing, "text/html")
        Dim logo As New LinkedResource(Server.MapPath("~/assets/images/header.jpg"))
        logo.ContentId = "header"
        'add the LinkedResource to the appropriate view
        htmlView.LinkedResources.Add(logo)
        Dim footer As New LinkedResource(Server.MapPath("~/assets/images/footer.jpg"))
        footer.ContentId = "footer"
        'add the LinkedResource to the appropriate view
        htmlView.LinkedResources.Add(footer)
        GestorEnvio.Enviar(destino, asunto, htmlView)
    End Sub

#End Region


End Class
