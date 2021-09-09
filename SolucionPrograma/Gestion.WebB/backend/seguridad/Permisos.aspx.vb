
Partial Class seguridad_Permisos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim oBLLPermisos As New Mapper_Patente
            GrillaPermisos.DataSource = oBLLPermisos.ListarPatentes
            GrillaPermisos.DataBind()
        End If
    End Sub
End Class
