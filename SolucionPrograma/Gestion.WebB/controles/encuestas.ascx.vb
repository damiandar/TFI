
Partial Class controles_encuestas
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim GestorEncuesta As New BLLEncuesta
        Dim UnaEncuesta As New Encuesta
        Dim objLogin As Object = Session("login")

        If objLogin IsNot Nothing Then
            Dim Lista As New List(Of Encuesta)
            Lista = GestorEncuesta.ListarEncuestaPendiente(Session("login"))

            If Lista.Count > 0 Then
                ViewState("encuestaid") = Lista.First().ID

                UnaEncuesta = GestorEncuesta.MostrarEncuesta(ViewState("encuestaid"))
                If UnaEncuesta.Opciones Is Nothing Then
                    PanelEncuestas.Visible = False
                Else
                    lblTitulo.Text = UnaEncuesta.Descripcion
                    GrillaEncuestaDetalle.DataSource = UnaEncuesta.Opciones
                    GrillaEncuestaDetalle.DataBind()
                End If

            Else 'no hay encuestas
                PanelEncuestas.Visible = False
            End If
        Else
            Response.Redirect("~/Default.aspx")
        End If




    End Sub

    Protected Sub lnkVotar_Click(sender As Object, e As System.EventArgs) Handles lnkVotar.Click
        Dim obj As Object = Request.Form("Opcion")
        Dim oBLLEncuesta As New BLLEncuesta
        oBLLEncuesta.VotarEncuesta(Session("login"), ViewState("encuestaid"), obj, "")

    End Sub

End Class
