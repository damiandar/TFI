
Partial Class backend_compras_Proveedores
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LLenarGrilla()
            'ScriptManager.GetCurrent(Me).RegisterPostBackControl(Button1)
        End If
    End Sub

    Private Sub InsertoProveedor() Handles popCuentaInsert1.InsertoProveedor
        Dim CSM As ClientScriptManager = Page.ClientScript
        Dim script As String = "<script type='text/javascript'>$('#mymodal').modal('hide'); </script>"
        CSM.RegisterClientScriptBlock(Me.GetType, "Test", script)
        LLenarGrilla()
    End Sub

    Protected Sub GrillaCuentas_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrillaCuentas.RowCommand
        If e.CommandName = "Editar" Then
            Dim id As Integer = CInt(e.CommandArgument)
            Dim GestorProveedores As New BLLProveedor
            Dim s As String = "$('#myModal').modal('show');"
            ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
            popCuentaInsert1.MostrarProveedor(id)

        End If
    End Sub

#Region "Metodos Privados"

    Private Sub LLenarGrilla()
        Dim GestorComprobantes As New BLLProveedor
        GrillaCuentas.DataSource = GestorComprobantes.ListarProveedores("", 0)
        GrillaCuentas.DataBind()
    End Sub

#End Region

End Class
