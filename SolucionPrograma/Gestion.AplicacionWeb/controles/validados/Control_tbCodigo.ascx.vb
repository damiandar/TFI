
Partial Class controles_Codigo
    Inherits System.Web.UI.UserControl



    Public Sub Enfocar()
        tbproducto.Focus()
    End Sub


    Public Property text() As String
        Get
            Return tbproducto.Text
        End Get
        Set(ByVal value As String)
            tbproducto.Text = ""
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return tbproducto.Enabled
        End Get
        Set(ByVal value As Boolean)
            If value = True Then
                tbproducto.Enabled = True
            Else
                tbproducto.Enabled = False
            End If
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
