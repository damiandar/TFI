
Partial Class controles_mensajepersonal
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If HttpContext.Current.User.IsInRole("P") Or HttpContext.Current.User.IsInRole("G") Then
            Me.Visible = True
        Else
            Me.Visible = False
        End If

    End Sub
End Class
