Imports System.IO

Partial Class controles_GrillaProductosRelacionados
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim oGestorProductos As New BLLProducto
        GrillaProductosRecomendados.DataSource = oGestorProductos.ListarProducto(0, 0, 0, "")
        GrillaProductosRecomendados.DataBind()
    End Sub

    Protected Sub GrillaProductosRecomendados_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles GrillaProductosRecomendados.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim imagenbyte As Byte() = DataBinder.Eval(e.Item.DataItem, "imagen")
            Dim ControlImagen As Image = CType(e.Item.FindControl("Image1"), Image)

            ControlImagen.ImageUrl = "~/assets/images/nodisponible.jpg"
            ControlImagen.Visible = True

            Using memoryStream As New MemoryStream()
                If imagenbyte IsNot Nothing Then
                    If imagenbyte.Length > 1 Then
                        memoryStream.Position = 0
                        memoryStream.Read(imagenbyte, 0, CInt(imagenbyte.Length))
                        Dim base64String As String = Convert.ToBase64String(imagenbyte, 0, imagenbyte.Length)
                        ControlImagen.ImageUrl = "data:image/png;base64," & base64String
                        ControlImagen.Visible = True
                    End If
                End If

            End Using
        End If
    End Sub
End Class
