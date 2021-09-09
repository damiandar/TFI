
Partial Class administracion_backup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            MostrarGrilla()
        End If
    End Sub

    Protected Sub btnHacerBackUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHacerBackUp.Click
        Dim GestorBackUp As New Mapper_BackUp
        GestorBackUp.HacerBackUP("c:\soluciontp\" & Now.Date.Hour & Now.Date.Minute & Now.Hour.ToString() & Now.Minute.ToString() & ".bkp", "aca va una descripcion")
    End Sub

#Region "Metodos Privados"
    Private Sub MostrarGrilla()
        Dim GestorBackUp As New Mapper_BackUp()
        GrillaBackUp.DataSource = GestorBackUp.ListarBackUp()
        GrillaBackUp.DataBind()
    End Sub
#End Region

   
End Class
