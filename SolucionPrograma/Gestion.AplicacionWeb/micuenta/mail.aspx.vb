


Imports System.Net.Mail

Partial Class micuenta_Default
    Inherits System.Web.UI.Page


    Protected Sub btnEnviarMail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviarMail.Click
        Dim GestorEnvio As New GestorMail()
        Dim sb As New StringBuilder()

        Dim ctrl As UserControl = CType(LoadControl("~/controles/plantillamail.ascx"), UserControl)
        ' ../assets/images/header.jpg
        ' ../assets/images/footer.jpg

        Dim sw As New System.IO.StringWriter(sb)
        Dim htw As New Html32TextWriter(sw)
        ctrl.RenderControl(htw)
        'Get full body text 
        Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(sb.ToString, Nothing, "text/html")
        Dim logo As New LinkedResource(Server.MapPath("../assets/images/header.jpg"))
        logo.ContentId = "header"
        'add the LinkedResource to the appropriate view
        htmlView.LinkedResources.Add(logo)
        Dim footer As New LinkedResource(Server.MapPath("../assets/images/footer.jpg"))
        footer.ContentId = "footer"
        'add the LinkedResource to the appropriate view
        htmlView.LinkedResources.Add(footer)
        GestorEnvio.Enviar("damiandar@hotmail.com", "prueba del sistema", htmlView)

    End Sub
End Class
