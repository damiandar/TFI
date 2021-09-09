Imports Tsu.ProviderOra

Imports Tsu.Seguridad


Namespace Tsu.Paginas

    Partial Class aplicacion_Default
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            'Dim ident As FormsIdentity = CType(HttpContext.Current.User.Identity, FormsIdentity)
            'Dim ticket As FormsAuthenticationTicket = ident.Ticket
            'Dim ci As New CustomIdentity(ticket)

            ' Me.ImagenInicio.ImageUrl = String.Format(" ", ci.Campania)

            If HttpContext.Current.User.IsInRole("P") Or HttpContext.Current.User.IsInRole("G") Or HttpContext.Current.User.IsInRole("U") Or HttpContext.Current.User.IsInRole("V") Then
                ImagenInicio.PostBackUrl = "~/micarga/catalogos.aspx"
            End If

            If HttpContext.Current.User.IsInRole("R") Then
                ImagenHome01.ImageUrl = "~/assets/images/rev_home01.jpg"
                ImagenHome01.PostBackUrl = "~/micarga/consultas.aspx"
                ImagenHome02.ImageUrl = "~/assets/images/rev_home02.jpg"
                ImagenHome02.PostBackUrl = "~/micarga/reparto.aspx"
                ImagenHome03.ImageUrl = "~/assets/images/rev_home03.jpg"
                ImagenHome03.PostBackUrl = "~/micarga/catalogos.aspx"

            End If


    


            If HttpContext.Current.User.IsInRole("P") Or HttpContext.Current.User.IsInRole("U") Then
                ImagenHome01.Visible = False
                ImagenHome02.Visible = False
                ImagenHome03.Visible = False
            End If



        End Sub


    End Class

End Namespace
