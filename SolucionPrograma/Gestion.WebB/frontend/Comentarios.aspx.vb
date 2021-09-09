
Partial Class carrito_Opinion
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            ViewState("productoID") = Request.QueryString("productoID")
            If CInt(ViewState("productoID")) = 0 Then
                Response.Redirect("default.aspx")
            End If
            Dim GestorProducto As New BLLProducto
            Dim UnProducto As Productos = GestorProducto.MostrarProducto(CInt(ViewState("productoID")))
            lblDescripcion.Text = UnProducto.NombreLargo
            LLenarGrilla(CInt(ViewState("productoID")))
        End If


    End Sub

    Protected Sub lnkAgregarComentario_Click(sender As Object, e As System.EventArgs) Handles lnkAgregarComentario.Click
        Try
            Dim Evaluacion As Integer = 0

            If RadioButton1.Checked Then
                Evaluacion = 1
            ElseIf RadioButton2.Checked Then
                Evaluacion = 2
            ElseIf RadioButton3.Checked Then
                Evaluacion = 3
            ElseIf RadioButton4.Checked Then
                Evaluacion = 4
            ElseIf RadioButton5.Checked Then
                Evaluacion = 5
            End If

            Dim UnComentario As New Comentarios
            UnComentario.ProductoID = ViewState("productoID")
            UnComentario.Por = "Damian Alejandro Rosso"
            UnComentario.Positivo = 0
            UnComentario.Negativo = 0
            UnComentario.Descripcion = tbComentarioTexto.Text
            UnComentario.Titulo = tbTitulo.Text
            UnComentario.Fecha = Now.Date
            UnComentario.Puntaje = Evaluacion
            UnComentario.cliente = New Cliente(CInt(Session("clienteid")))

            Dim oBLLComentario As New BLLComentario
            oBLLComentario.InsertarComentario(UnComentario)

            LLenarGrilla(CInt(ViewState("productoID")))
            Dim s As String = "$('#myModal').modal('show');"
            ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.COMENTARIO, Patente.eAccion.COMENTAR, "INGRESO COMENTARIO", False)
        Catch ex As Exception
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.COMENTARIO, Patente.eAccion.COMENTAR, String.Format("ERROR AL INGRESAR COMENTARIO: {0}", ex.Message.ToString()), True)
        End Try
    End Sub

    Protected Sub GrillaComentarios_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles GrillaComentarios.ItemCommand

        Dim GestorComentarios As New BLLComentario
        Dim UnComentario As New Comentarios
        UnComentario = GestorComentarios.MostrarComentario(e.CommandArgument)

        If e.CommandName = "VotarPositivo" Then
            UnComentario.Positivo = UnComentario.Positivo + 1
        End If

        If e.CommandName = "VotarNegativo" Then
            UnComentario.Negativo = UnComentario.Negativo + 1
        End If

        GestorComentarios.ActualizarComentario(UnComentario)

    End Sub

    Private Sub LLenarGrilla(ByVal ProductoID As Integer)
        Dim oBLLComentario As New BLLComentario
        Dim ListaComentarios As List(Of Comentarios) = oBLLComentario.ListarComentarios(ProductoID)

        GrillaComentarios.DataSource = ListaComentarios
        GrillaComentarios.DataBind()
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Response.Redirect(String.Format("detalle.aspx?producto_id={0}", CInt(ViewState("productoID"))))
    End Sub
End Class
