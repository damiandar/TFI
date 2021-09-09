Namespace Tsu.Paginas

    Partial Class Logout
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            FormsAuthentication.SignOut()
            Session.Abandon()
            Try
                Dim parametro As String = Request.QueryString("salir")
                If parametro = "fin" Then
                    'muestro mensaje, apreto salir desde la cabecera
                    'MensajeSalida.Text = "Tu  sesi&oacute;n ha finalizado correctamente."
                    MensajeSalida.Text = "Tu  sesi&oacute;n ha cerrado correctamente, puede volver a ingresar para continuar con su compra."
                ElseIf parametro = "error" Then
                    MensajeSalida.Text = "Se produjo un error en el sistema, vuelva a ingresar."
                Else
                    'fin por tiempo
                    MensajeSalida.Text = "Su sesión ha expirado."
                End If
            Catch ex As Exception

            End Try
       

        End Sub
    End Class
End Namespace