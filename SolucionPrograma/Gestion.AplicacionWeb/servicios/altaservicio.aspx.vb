
Partial Class servicios_altaservicio
    Inherits System.Web.UI.Page

    Protected Sub btnCrearProducto_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnCrearProducto.Click
        Try

            Dim ServicioId As Integer = InsertarServicio()
            If (FileUpload1.HasFile) Then

                Dim filename As String = System.IO.Path.GetFileName(FileUpload1.FileName)

                FileUpload1.SaveAs(Server.MapPath("~/subidas/") & ServicioId & ".jpg")

                'Image1.ImageUrl = "subidas/" & filename

            End If
           

        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try



    End Sub

    Private Function InsertarServicio() As Integer
        Dim oGestorProducto As New BLL.Negocio.BLLProducto

        Dim UnProducto As New Productos()
        UnProducto.CodigoInterno = "2222"
        UnProducto.Descripcion = tbNombre.Text
        UnProducto.Estado = True
        Return oGestorProducto.InsertarProducto(UnProducto)
    End Function
End Class
