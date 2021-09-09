Imports System.Net.Mail

Namespace Tsu.Paginas

    Partial Class aplicacion_cambioclave
        Inherits System.Web.UI.Page
  
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            tbContraseniaActual.Focus()
        End Sub

        Protected Sub btnConfirmar_Click1(sender As Object, e As System.EventArgs) Handles btnConfirmar.Click
            Dim sCuenta As String = Session("login")

            If Page.IsValid Then
                Try

                    Dim GestorSeguridad As New Gestor_Seguridad()
                    GestorSeguridad.CambiarPass(sCuenta, tbContraseniaActual.Text, tbContraseniaNueva.Text)
                    lblError.Text = ""
                    panel.Visible = False
                    panelexito.Visible = True

                    Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.USUARIO, Patente.eAccion.CAMBIOCONTRASENIA, String.Format("Cambio: {0}", Session("login")), False)


                Catch ex As Exception
                    'muestro el error
                    lblError.Text = "Error al cambiar la clave."
                    panelexito.Visible = False
                    'UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Convert.ToInt32(Session("clienteid")), "CambioClave/confirmar:" & ex.Message.ToString())
                End Try

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

#End Region

    End Class
End Namespace