Imports System.IO

Partial Class compras_Remitos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim OrdenID As Integer = Request.QueryString("ComprobanteID")
            ViewState("OrdenID") = OrdenID
            If OrdenID > 0 Then
                lnkNuevo.NavigateUrl = String.Format("~/backend/compras/IngresoRemito.aspx?ComprobanteID={0}", OrdenID)
            Else
                lnkNuevo.Visible = False
            End If

            LLenarGrilla(OrdenID)
        End If
    End Sub

    Protected Sub GrillaRemitos_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrillaRemitos.RowCommand
        If e.CommandName = "Imprimir" Then
            Dim GestorAbastecimiento As New BLLRemito
            Dim GestorReportes As New Reportes()
            Dim output As MemoryStream = GestorReportes.DibujarPlanillaRemitos("aa", GestorAbastecimiento.MostrarRemito(CInt(e.CommandArgument)))

            HttpContext.Current.Response.ContentType = "application/pdf"
            HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=Remito-{0}.pdf", CInt(e.CommandArgument)))
            HttpContext.Current.Response.BinaryWrite(output.ToArray())
        End If
    End Sub

    Private Sub GrillaRemitos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GrillaRemitos.PageIndexChanging
        LLenarGrilla(ViewState("OrdenID"))
        GrillaRemitos.PageIndex = e.NewPageIndex
        GrillaRemitos.DataBind()
    End Sub


#Region "Metodos Privados"
    Private Sub LLenarGrilla(ByVal OrdenID As Integer)
        Dim GestorRemitos As New BLLRemito
        GrillaRemitos.DataSource = GestorRemitos.MostrarListadoRemito(0, 0, 0, OrdenID)
        GrillaRemitos.DataBind()
    End Sub
#End Region
End Class
