
Partial Class backend_catalogo_InsumosListado
    Inherits System.Web.UI.Page

    Private Sub backend_catalogo_InsumosListado_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim Lista As New List(Of Insumo)
        Dim GestorInsumo As New BLLInsumo
        Lista = GestorInsumo.ListarInsumos(0, 0)
        GrillaInsumos.DataSource = Lista
        GrillaInsumos.DataBind()
    End Sub

    Protected Sub GrillaInsumos_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrillaInsumos.RowCommand
        If e.CommandName = "borrar" Then

        End If
    End Sub


End Class
