Imports Tsu.ProviderOra

Imports Tsu.Seguridad
Imports Tsu.Utilidades

Partial Class Principal
    Inherits System.Web.UI.MasterPage
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AsignarTiempo()
    End Sub

    Protected Sub btnBotonVentanaTiempo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBotonVentanaTiempo.Click
        'AsignarTiempo()
        Dim a As Integer = 3
    End Sub

    Private Sub AsignarTiempo()
        Try
            'asigna el tiempo restante
            Dim ident As FormsIdentity = CType(HttpContext.Current.User.Identity, FormsIdentity)
            Dim ticket As FormsAuthenticationTicket = ident.Ticket
            FormsAuthentication.RenewTicketIfOld(ticket)
            Dim horaActual As DateTime = DateTime.Now
            Dim ts1 As New TimeSpan(ticket.Expiration.Ticks - horaActual.Ticks)
            minutostimeout.Value = ts1.TotalMilliseconds.ToString().Replace(",", ".")
        Catch ex As Exception
            '  UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Convert.ToInt32(Session("cuenta")), "Principal.Master:" & ex.Message.ToString())
        End Try
    End Sub


End Class


