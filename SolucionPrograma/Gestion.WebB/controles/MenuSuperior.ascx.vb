
Partial Class controles_MenuSuperior
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            Dim ident As FormsIdentity = CType(HttpContext.Current.User.Identity, FormsIdentity)
            Dim ticket As FormsAuthenticationTicket = ident.Ticket
            Dim ci As New CustomIdentity(ticket)
            lblNombre.Text = ci.Name

            Dim Rol As Object = ci.Rol

            If Rol > 1 Then
                carritomenu1.Visible = False
                hlMisDatos.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub lnkSalir_Click(sender As Object, e As System.EventArgs) Handles lnkSalir.Click
        Response.Redirect("~/Default.aspx")
    End Sub

End Class
