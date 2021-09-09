Imports System.Net.Mail

Namespace Tsu.Paginas
    Partial Class _Default
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Response.Redirect("~/aplicacion/default.aspx")
           
        End Sub
    End Class


End Namespace
