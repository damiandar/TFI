Partial Class compras_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LLenarGrilla()
        End If
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As System.EventArgs) Handles btnAgregar.Click
        Try
            Dim UnaReposicion As New Reposicion
            UnaReposicion.Items = New List(Of ReposicionItem)
            UnaReposicion.Notas = tbNotas.Text
            UnaReposicion.Fecha = Now
            Dim GestorAbastecimiento As New BLLReposicion
            Dim PedidoID As Integer = GestorAbastecimiento.InsertarReposicion(UnaReposicion)
            tbNotas.Text = ""
            LLenarGrilla()
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.ABASTECIMIENTO, Patente.eAccion.ALTA, String.Format("SE CREÓ NUEVO PEDIDO ABASTECIMIENTO: {0}  ", PedidoID), False)
        Catch ex As Exception
            Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.ABASTECIMIENTO, Patente.eAccion.ALTA, String.Format("ERROR AL AGREGAR PEDIDO ABASTECIMIENTO:{0} ", ex.Message.ToString()), True)
        End Try
    End Sub

    Private Sub GrillaReposicion_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GrillaReposicion.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hlVer As HyperLink = CType(e.Row.FindControl("hlVer"), HyperLink)
            Dim Estado As Reposicion.eEstado = CType(DataBinder.Eval(e.Row.DataItem, "estado"), Reposicion.eEstado)
            Dim PedidoId As Integer = CInt(DataBinder.Eval(e.Row.DataItem, "id"))

            If Estado = Reposicion.eEstado.creado Then
                hlVer.NavigateUrl = String.Format("~/backend/abastecimiento/detalle.aspx?ReposicionID={0}", PedidoId)
            ElseIf Estado = Reposicion.eEstado.enviado Then
                hlVer.NavigateUrl = String.Format("~/backend/abastecimiento/detalle.aspx?ReposicionID={0}", PedidoId)
            ElseIf Estado = Reposicion.eEstado.comprado Then
                hlVer.NavigateUrl = String.Format("~/backend/abastecimiento/detalle.aspx?ReposicionID={0}", PedidoId)
            End If
        End If
    End Sub

#Region "Metodos Privados"

    Private Sub LLenarGrilla()
        Dim GestorReposicion As New BLLReposicion
        GrillaReposicion.DataSource = GestorReposicion.ListarReposicion(0, 0, 0)
        GrillaReposicion.DataBind()
    End Sub

#End Region

End Class
