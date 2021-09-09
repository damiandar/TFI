
Partial Class controles_MenuIzquierda
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            Dim ident As FormsIdentity = CType(HttpContext.Current.User.Identity, FormsIdentity)
            Dim ticket As FormsAuthenticationTicket = ident.Ticket
            Dim ci As New CustomIdentity(ticket)
            Dim oGestorCategoria As New BLLCategoria()
            Repeater1.DataSource = oGestorCategoria.MostrarCategorias("1")
            Repeater1.DataBind()

            If ci.Rol = "1" Then
                'si es cliente solo muestro el menu FRONTEND
                menufrontend.Visible = True
                menubackend.Visible = False
            Else
                menufrontend.Visible = False
                menubackend.Visible = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Repeater1_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        Dim item As RepeaterItem = e.Item
        If ((item.ItemType = ListItemType.Item) Or (item.ItemType = ListItemType.AlternatingItem)) Then
            Dim repe As Repeater = CType(item.FindControl("Repeater2"), Repeater)


            Dim oGestorSubCategoria As New BLLSubCategoria
            Dim o As Categoria = CType(item.DataItem, Categoria)

            repe.DataSource = oGestorSubCategoria.MostrarSubCategorias(o.ID)
            repe.DataBind()
        End If

    End Sub

End Class
