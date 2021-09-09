
Partial Class controles_Control_tbMotivo
    Inherits System.Web.UI.UserControl
    Public Property text() As String
        Get
            Return tbMotivo.Text
        End Get
        Set(ByVal value As String)
            tbMotivo.Text = ""
        End Set
    End Property


    Public Property Enabled() As Boolean
        Get
            Return tbMotivo.Enabled
        End Get
        Set(ByVal value As Boolean)
            If value = True Then
                tbMotivo.Enabled = True
            Else
                tbMotivo.Enabled = False
            End If
        End Set
    End Property

    Public Event TextChanged()


    Protected Sub tbMotivo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMotivo.TextChanged
        RaiseEvent TextChanged()
    End Sub
End Class
