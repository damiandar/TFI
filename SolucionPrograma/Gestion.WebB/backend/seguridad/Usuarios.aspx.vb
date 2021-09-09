
Partial Class seguridad_Usuarios
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim oBLLUsuarios As New Mapper_Usuario

            GrillaUsuarios.DataSource = oBLLUsuarios.MuestraListado
            GrillaUsuarios.DataBind()
        End If
    End Sub

    Protected Sub GrillaUsuarios_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GrillaUsuarios.SelectedIndexChanged

    End Sub
End Class
