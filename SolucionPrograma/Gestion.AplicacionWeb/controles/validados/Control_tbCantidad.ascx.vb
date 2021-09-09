
Partial Class controles_Control_tbCantidad
    Inherits System.Web.UI.UserControl

    Public Property Text() As String
        Get
            Return tbCantidad.Text
        End Get
        Set(ByVal value As String)
            tbCantidad.Text = ""
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return tbCantidad.Enabled
        End Get
        Set(ByVal value As Boolean)
            If value = True Then
                tbCantidad.Enabled = True
            Else
                tbCantidad.Enabled = False
            End If
        End Set
    End Property
End Class
