Imports System.Net.Mail

Partial Class micuenta_Default
    Inherits System.Web.UI.Page

    Protected Sub btnEnviarMail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviarMail.Click
        EnviarMail("prueba del mail", "aca va el texto", "damiandar@hotmail.com", "xxx")
    End Sub

    Public Sub EnviarMail(ByVal titulo As String, ByVal texto As String, ByVal destino As String, ByVal asunto As String)
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
        Dim logo As New LinkedResource(Server.MapPath("../assets/images/header.jpg"))
        logo.ContentId = "header"
        'add the LinkedResource to the appropriate view
        htmlView.LinkedResources.Add(logo)
        Dim footer As New LinkedResource(Server.MapPath("../assets/images/footer.jpg"))
        footer.ContentId = "footer"
        'add the LinkedResource to the appropriate view
        htmlView.LinkedResources.Add(footer)
        GestorEnvio.Enviar(destino, asunto, htmlView)
    End Sub

End Class
