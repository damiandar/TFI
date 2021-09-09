
Partial Class controles_Control_ddlTipo
    Inherits System.Web.UI.UserControl

    Public ReadOnly Property SelectedValue() As String
        Get
            Return ddlTipo.SelectedValue
        End Get
    End Property

    Public Event SelectedIndexChanged()


    Protected Sub ddlTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipo.SelectedIndexChanged
        RaiseEvent SelectedIndexChanged()
    End Sub
End Class
