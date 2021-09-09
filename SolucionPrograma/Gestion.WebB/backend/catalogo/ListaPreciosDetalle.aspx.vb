
Partial Class backend_catalogo_ListaPrecios
    Inherits System.Web.UI.Page

    Private Sub ListaPrecios_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PanelMensaje.Visible = False
            PanelError.Visible = False
            Dim NroDeLista As Integer = 0
            NroDeLista = Request.QueryString("id")
            If IsNumeric(NroDeLista) And NroDeLista > 0 Then
                ViewState("id") = NroDeLista
                LLenarGrilla(NroDeLista)
            Else
                Response.Redirect("ListaPrecios.aspx")
            End If

        End If
    End Sub

    Protected Sub btnActualizarPrecios_Click(sender As Object, e As EventArgs) Handles btnActualizarPrecios.Click

        For Each fila As GridViewRow In GrillaPrecios.Rows
            Dim tbPrecio As TextBox = CType(fila.FindControl("tbPrecioUnitario"), TextBox)
            If IsNumeric(tbPrecio.Text) Then
                If CInt(tbPrecio.Text) > 0 Then
                    Dim hProductoID As HiddenField = CType(fila.FindControl("hProductoID"), HiddenField)
                    If IsNumeric(hProductoID.Value) And IsNumeric(tbPrecio.Text) Then

                        ModificarPrecio(CInt(hProductoID.Value), CDbl(tbPrecio.Text))
                        PanelError.Visible = False
                        PanelMensaje.Visible = True
                    Else
                        PanelError.Visible = True
                        PanelMensaje.Visible = False
                    End If
                End If
            End If
        Next

    End Sub

#Region "Metodos privados"

    Private Sub LLenarGrilla(ByVal NroLista As Integer)
        Dim GestorPrecios As New BLLPrecio
        Dim ListaPrecios As New PrecioLista
        ListaPrecios = GestorPrecios.MostraListasPrecio(NroLista).First
        lblFechaCreacion.Text = String.Format("{0:dd/MM/yyyy}", ListaPrecios.FechaCreacion)
        lblFechaVigencia.Text = String.Format("{0:dd/MM/yyyy}", ListaPrecios.FechaVigencia)
        lblListaID.Text = ListaPrecios.ID.ToString()

        GrillaPrecios.DataSource = ListaPrecios.Productos
        GrillaPrecios.DataBind()
    End Sub

    Private Sub ModificarPrecio(ByVal ProductoID As Integer, ByVal Precio As Double)
        Dim UnProducto As New Productos
        UnProducto.ID = ProductoID
        UnProducto.precio = New Precio
        UnProducto.precio.ValorUnitario = Precio
        UnProducto.precio.iva = New IVA
        UnProducto.precio.iva.ID = 1

        Dim GestorPrecio As New BLLPrecio
        GestorPrecio.ModificarProductoPrecio(UnProducto, CInt(ViewState("id")))
    End Sub
#End Region

End Class
