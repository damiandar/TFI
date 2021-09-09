
Partial Class controles_barracarrito
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Me.pItem <> "" Then
            If Me.pItem = "divCarrito" Then
            ElseIf Me.pItem = "divDomicilio" Then
            ElseIf Me.pItem = "divEnvio" Then
            ElseIf Me.pItem = "divPago" Then
            ElseIf Me.pItem = "divConfirmacion" Then
            ElseIf Me.pItem = "divCompletar" Then
            ElseIf Me.pItem = "" Then

            End If
            Dim divGenerica As HtmlGenericControl = CType(Me.FindControl(String.Format("{0}", pItem)), HtmlGenericControl)
            divGenerica.Attributes.Add("class", "active")
            'divCarrito.Attributes.Add("class", "active")
            'divDomicilio.Attributes.Add("class", "")
            'divEnvio.Attributes.Add("class", "")
            'divPago.Attributes.Add("class", "")
            'divConfirmacion.Attributes.Add("class", "")
            'divCompletar.Attributes.Add("class", "")
            'visited()
            'inactive()
        End If

    End Sub

    Private pItem As String
    Public Property Item() As String
        Get
            Return pItem
        End Get
        Set(ByVal value As String)
            pItem = value
        End Set
    End Property

End Class
