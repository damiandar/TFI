Imports System.Net.Mail

Partial Class controles_login_recuperar
    Inherits System.Web.UI.UserControl

    Protected Sub lnkEntrar_Click(sender As Object, e As System.EventArgs) Handles lnkEntrar.Click

        Dim Usuario As String = tbMail.Text
        Dim UnUsuario As New Usuario
        Dim GestorUsuario As New Mapper_Usuario
        UnUsuario = GestorUsuario.MuestraUnUsuario(Usuario)
        If UnUsuario IsNot Nothing Then
            tbMail.Visible = False
            Try
                EnviarMail("En hora buena", "Bienvenido su contraseña es : " & UnUsuario.Contrasenia, "damiandar@hotmail.com", "LAVADERO BOUTIQUE")
            Catch ex As Exception
                lnkEntrar.Visible = False
                lblMensaje.Text = "Su contraseña es : " & UnUsuario.Contrasenia
            End Try
        Else
            'lnkEntrar.Visible = False
            lblMensaje.Text = "Ingrese un usuario valido."
            lblMensaje.ForeColor = Drawing.Color.Red
        End If
    End Sub

#Region "Metodos Privados"

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
