
Partial Class backend_catalogo_ListaPrecios
    Inherits System.Web.UI.Page

    Private Sub ListaPrecios_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LLenarGrilla()
            PanelMensaje.Visible = False
        End If
    End Sub

    Protected Sub btnNuevaLista_Click(sender As Object, e As EventArgs) Handles btnNuevaLista.Click
        Try
            Dim GestorPrecios As New BLLPrecio
            GestorPrecios.CrearListaPrecios(Now.Date)
            MostrarMensaje("Se agregó una nueva lista de precios correctamente.")
            LLenarGrilla()
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.PRECIO, Patente.eAccion.CREARNUEVALISTA, "SE CREÓ CORRECTAMENTE", False)
        Catch ex As Exception
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.PRECIO, Patente.eAccion.CREARNUEVALISTA, String.Format("ERROR AL CREAR LA LISTA DE PRECIOS: {0}", ex.Message.ToString()), True)
        End Try
    End Sub

    Protected Sub GrillaPrecios_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrillaPrecios.RowCommand
        If e.CommandName = "Activar" Then
            Try
                Dim ID As Integer = 0
                ID = CInt(e.CommandArgument)
                Dim GestorPrecios As New BLLPrecio
                GestorPrecios.ActivarListaPrecio(ID)
                LLenarGrilla()
                MostrarMensaje("Se activó correctamente la lista de precios.")
                Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.PRECIO, Patente.eAccion.ACTIVARLISTA, String.Format("SE ACTIVÓ LA LISTA DE PRECIOS: {0}", ID), False)
            Catch ex As Exception
                Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.PRECIO, Patente.eAccion.ACTIVARLISTA, String.Format("ERROR AL ACTIVAR: {0}", ex.Message.ToString()), True)
            End Try

        End If
    End Sub



#Region "Metodos Privados"

    Private Sub LLenarGrilla()
        Dim GestorPrecios As New BLLPrecio
        GrillaPrecios.DataSource = GestorPrecios.MostraListasPrecio(0)
        GrillaPrecios.DataBind()
    End Sub

    Private Sub MostrarMensaje(ByVal Mensaje As String)
        PanelMensaje.Visible = True
        lblMensaje.Text = Mensaje
    End Sub

#End Region

End Class
