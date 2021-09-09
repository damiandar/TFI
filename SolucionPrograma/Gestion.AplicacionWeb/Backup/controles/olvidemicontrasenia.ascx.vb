
Namespace Tsu.Paginas
    Partial Class controles_olvidemicontrasenia
        Inherits System.Web.UI.UserControl


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Not Page.IsPostBack Then
                Me.tbCuenta.Focus()
                ViewState("cantidadIntentos") = 0
            End If

        End Sub

#Region "botones"

        Protected Sub btnSiguiente0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSiguiente0.Click
            Try
                If Page.IsValid Then
                    Dim UnaCuenta As New Cuenta()
                    Dim oGestor As New BLL.Negocio.BLLCuenta()
                    UnaCuenta = oGestor.MostrarCuenta(tbCuenta.Text)
                    panel1.Visible = False
                    PanelMail.Visible = True
                    lblMail.Text = UnaCuenta.Mail
                    ViewState("mail") = UnaCuenta.Mail
                End If

            Catch ex As Exception
                Response.Write(ex.Message.ToString())
                'UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, ViewState("iCuenta"), "Control Olvide mi contraseña/sgte0: " & ex.Message.ToString())
            End Try

        End Sub

        Protected Sub btnEnviarMail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEnviarMail.Click
            EnviarMail(ViewState("mail"))
        End Sub


#End Region


    
        Private Sub EnviarMail(ByVal maildestino As String)
            PanelMail.Visible = False
            Dim Mail As New GestorMail()

            Dim asunto As String = "Recupero de contraseña"
            ' oInicioMap.ContraseniaDesencriptada(Convert.ToInt32(ViewState("iCuenta")))
            Dim cuerpomensaje As String = "La contraseña es: " & "" & _
            "</br><p>Este correo se genera y se envía de forma automática. Por favor no lo responda. " & _
            "Este mensaje y sus adjuntos son confidenciales y de uso exclusivo para el usuario a quien está dirigido. " & _
            "Si Ud. no es el destinatario especificado, la copia, envío o utilización de cualquier parte del mismo y/o de sus adjuntos queda prohibida. " & _
            "Todas las opiniones contenidas en este mail son propias del autor del mensaje y no necesariamente coinciden con las de la empresa. " & _
            "Si usted ha recibido este mensaje erróneamente, por favor borre el mensaje y sus adjuntos</p>"


            Try
                Mail.Enviar(maildestino, asunto, cuerpomensaje)
                If ViewState("AgregoCuenta") <> "" Then
                    Me.lblError1.Text = ViewState("AgregoCuenta")
                Else
                    Me.lblError1.Text = "La contraseña ha sido enviada a tu casilla de e-mail."
                End If
                MensajeError1.Visible = True
            Catch ex As Exception
                Me.lblError.Text = "El mail no pudo enviarse, intente mas tarde."
                Me.lblError.Visible = True
                MensajeError1.Visible = False
                MensajeError.Visible = True
                'UtilLogBase.Guardar(Tsu.Entity.LogBase.TipoLog.NoEnviaMail, Convert.ToInt32(tbCuenta.Text), "Olvide mi contraseña/enviarmail;No pudo enviar el mail de olvide mi contraseña")
            End Try
        End Sub


    End Class

End Namespace
