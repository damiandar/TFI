Imports Tsu.Utilidades

Partial Class paginanoencontrada
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UtilLogBase.Guardar(Tsu.Entity.LogBase.TipoLog.ErrorMAP, Session("cuenta"), "Prueba en registro error")
    End Sub
End Class
