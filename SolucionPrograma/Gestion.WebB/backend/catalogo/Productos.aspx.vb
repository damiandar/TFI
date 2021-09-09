Imports System.IO

Partial Class aplicacion_Catalogo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PanelMensaje.Visible = False
            comboSubCategoria.Items.Insert(0, New ListItem("--Seleccionar--", "0"))
            LLenarComboCategoria()
            Dim ProductoID As Integer = 0
            ProductoID = Request.QueryString("ProductoID")
            If ProductoID > 0 Then
                ViewState("ProductoID") = ProductoID
                LLenarProducto(ProductoID)
                btnCrear.Visible = False
                btnModificar.Visible = True
            End If
        End If
    End Sub

    Protected Sub comboCategoria_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles comboCategoria.SelectedIndexChanged
        LLenarComboSubCategoria(comboCategoria.SelectedValue)
    End Sub

    Protected Sub btnCrear_Click(sender As Object, e As System.EventArgs) Handles btnCrear.Click
        Try
            Dim GestorProducto As New BLLProducto
            Dim UnProducto As New Productos

            UnProducto.Descripcion = tbDetalle.Text
            UnProducto.NombreLargo = tbNombreLargo.Text
            UnProducto.NombreCorto = tbNombreCorto.Text
            UnProducto.CodigoInterno = tbCodigoInterno.Text
            UnProducto.SubCategoriaID = comboSubCategoria.SelectedValue
            UnProducto.Estado = True
            UnProducto.TiempoEntrega = tbTiempoEspera.Text

            Dim extension As String = System.IO.Path.GetFileName(FileUpload1.FileName)
            Dim MIMEType As String = Nothing

            Dim imageBytes(FileUpload1.PostedFile.InputStream.Length) As Byte
            FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)
            'PRECIO
            UnProducto.precio = New Precio()
            UnProducto.precio.iva = New IVA
            UnProducto.precio.ValorUnitario = CDbl(tbPrecio.Text)
            UnProducto.precio.iva.ID = comboIva.SelectedValue

            UnProducto.Imagen = imageBytes
            UnProducto.TipoImagen = "image/jpeg"
            GestorProducto.InsertarProducto(UnProducto)

            Dim CSM As ClientScriptManager = Page.ClientScript
            Dim script As String = "<script type='text/javascript'>$('#Mensaje').css('display', 'block'); </script>"
            CSM.RegisterClientScriptBlock(Me.GetType, "Test", script)
            tbDetalle.Text = ""
            tbNombreLargo.Text = ""
            tbNombreCorto.Text = ""
            tbTiempoEspera.Text = ""
            tbCodigoInterno.Text = ""
            'tbPrecio.Text = ""

            PanelMensaje.Visible = True
            lblMensaje.Text = "Se insertó correctamente."
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.PRODUCTO, Patente.eAccion.ALTA, String.Format("SE INSERTÓ: {0} ", UnProducto.NombreCorto), False)
        Catch ex As Exception
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.PRODUCTO, Patente.eAccion.ALTA, String.Format("ERROR: {0}", ex.Message.ToString()), True)
        End Try
    End Sub


    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            Dim GestorProducto As New BLLProducto
            Dim UnProducto As New Productos
            UnProducto.ID = CInt(ViewState("ProductoID"))
            UnProducto.Descripcion = tbDetalle.Text
            UnProducto.NombreLargo = tbNombreLargo.Text
            UnProducto.NombreCorto = tbNombreCorto.Text
            UnProducto.CodigoInterno = tbCodigoInterno.Text
            UnProducto.SubCategoriaID = comboSubCategoria.SelectedValue
            UnProducto.Estado = True
            'PRECIO
            UnProducto.precio = New Precio()
            UnProducto.precio.iva = New IVA
            UnProducto.precio.ValorUnitario = CDbl(tbPrecio.Text)
            UnProducto.precio.iva.ID = comboIva.SelectedValue
            'IMAGEN
            Dim extension As String = System.IO.Path.GetFileName(FileUpload1.FileName)
            Dim MIMEType As String = Nothing
            Dim imageBytes(FileUpload1.PostedFile.InputStream.Length) As Byte
            FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)
            UnProducto.Imagen = imageBytes
            If imageBytes.Length > 1 Then
                UnProducto.TipoImagen = "image/jpeg"
            Else
                UnProducto.TipoImagen = ""
            End If
            GestorProducto.ActualizarProducto(UnProducto)
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.PRODUCTO, Patente.eAccion.MODIFICACION, String.Format("SE MODIFICO: ID: {0} NOMBRE: {1} ", UnProducto.ID, UnProducto.NombreCorto), False)
        Catch ex As Exception
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.PRODUCTO, Patente.eAccion.MODIFICACION, String.Format("ERROR: {0}", ex.Message.ToString()), True)
        End Try

    End Sub

#Region "Metodos Privados"

    Private Sub LLenarComboSubCategoria(ByVal CategoriaID As Integer)
        Dim GestorSubCategoria As New BLLSubCategoria
        comboSubCategoria.Items.Clear()
        comboSubCategoria.DataTextField = "descripcion"
        comboSubCategoria.DataValueField = "id"
        comboSubCategoria.DataSource = GestorSubCategoria.MostrarSubCategorias(CategoriaID)
        comboSubCategoria.DataBind()
    End Sub

    Private Sub LLenarComboCategoria()
        comboCategoria.Items.Insert(0, New ListItem("--Seleccionar--", "0"))
        Dim GestorCategoria As New BLLCategoria
        comboCategoria.DataTextField = "descripcion"
        comboCategoria.DataValueField = "id"
        comboCategoria.DataSource = GestorCategoria.MostrarCategorias(1)
        comboCategoria.DataBind()
    End Sub

    Private Sub LLenarProducto(ByVal ProductoID As Integer)
        Dim GestorProducto As New BLLProducto
        Dim UnProducto As New Productos
        UnProducto = GestorProducto.MostrarProducto(ProductoID)

        comboCategoria.SelectedValue = UnProducto.CategoriaID
        LLenarComboSubCategoria(UnProducto.CategoriaID)
        comboSubCategoria.SelectedValue = UnProducto.SubCategoriaID

        tbDetalle.Text = UnProducto.Descripcion
        tbNombreLargo.Text = UnProducto.NombreLargo
        tbNombreCorto.Text = UnProducto.NombreCorto
        tbCodigoInterno.Text = UnProducto.CodigoInterno


        comboSubCategoria.SelectedValue = UnProducto.SubCategoriaID


        Dim imagenbyte As Byte() = UnProducto.Imagen
        Image1.ImageUrl = "~/assets/images/nodisponible.jpg"
        Image1.Visible = True


        Using memoryStream As New MemoryStream()
            If imagenbyte IsNot Nothing Then
                If imagenbyte.Length > 1 Then
                    memoryStream.Position = 0
                    memoryStream.Read(imagenbyte, 0, CInt(imagenbyte.Length))
                    Dim base64String As String = Convert.ToBase64String(imagenbyte, 0, imagenbyte.Length)
                    Image1.ImageUrl = "data:image/png;base64," & base64String
                    Image1.Visible = True
                End If
            End If
        End Using



        'comboIva.SelectedValue = UnProducto.precio.iva.ID
        'tbPrecio.Text = UnProducto.precio.ValorUnitario
        'UnProducto.Estado = True
        'UnProducto.precio = New Precio()
        'UnProducto.precio.iva = New IVA

        'Dim extension As String = System.IO.Path.GetFileName(FileUpload1.FileName)
        'Dim MIMEType As String = Nothing

        'Dim imageBytes(FileUpload1.PostedFile.InputStream.Length) As Byte
        'FileUpload1.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length)

        'UnProducto.precio.ValorUnitario = tbPrecio.Text
        'UnProducto.precio.iva.ID = 1
        'UnProducto.Imagen = imageBytes
        'UnProducto.TipoImagen = "image/jpeg" 

    End Sub
#End Region

    'Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
    '    Dim CSM As ClientScriptManager = Page.ClientScript
    '    Dim script As String = "<script type='text/javascript'>document.getElementById('Mensaje').style.visibility='visible'</script>"
    '    CSM.RegisterClientScriptBlock(Me.GetType, "Test", script)
    'End Sub
End Class
