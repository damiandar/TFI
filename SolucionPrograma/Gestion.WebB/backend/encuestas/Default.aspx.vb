
Partial Class backend_encuestas_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim GestorEncuestas As New BLLEncuesta()
        GrillaEncuestas.DataSource = GestorEncuestas.ListarEncuestas()
        GrillaEncuestas.DataBind()
    End Sub
End Class
