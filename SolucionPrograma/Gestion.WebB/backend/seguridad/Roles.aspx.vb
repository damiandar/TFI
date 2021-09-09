
Partial Class seguridad_Roles
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim oBLLRoles As New Mapper_Familia
            GrillaRoles.DataSource = oBLLRoles.Muestralistafamilia()
            GrillaRoles.DataBind()
        End If

    End Sub
End Class
