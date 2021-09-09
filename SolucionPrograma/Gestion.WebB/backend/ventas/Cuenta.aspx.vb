
Partial Class aplicacion_forms
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim GestorClientes As New BLLCliente
            GrillaCuentas.DataSource = GestorClientes.ListarClientes("")
            GrillaCuentas.DataBind()
            'ScriptManager.GetCurrent(Me).RegisterPostBackControl(Button1)
        End If
    End Sub
 

End Class
