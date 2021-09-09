
Imports BLL.Negocio


Namespace Tsu.Paginas
    Partial Class usuarionuevo
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Protected Sub btnEntrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEntrar.Click
            Try
                NuevaCuenta()
                Me.tbmensaje.Text = tbmensaje.Text & " la contraseña ha sido enviada a tu casilla de e-mail."
            Catch ex As Exception
                Me.MensajeError.Visible = True
                Me.LblMensajeError.Text = "El mail no pudo enviarse intente más tarde."
            End Try
        End Sub


#Region "Metodos Privados"

        ''' <summary>
        ''' llama a la clase que envia el mail
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub enviarMail(ByVal Login As String)
            Try
                Dim Mail As New GestorMail()
                '& oInicioMap.ContraseniaDesencriptada(Convert.ToInt32(11111))
                Dim CuerpoMensaje As String = "La contraseña es: " & _
                "</br><p>Este correo se genera y se envía de forma automática. Por favor no lo responda. " & _
                "Este mensaje y sus adjuntos son confidenciales y de uso exclusivo para el usuario a quien está dirigido. " & _
                "Si Ud. no es el destinatario especificado, la copia, envío o utilización de cualquier parte del mismo y/o de sus adjuntos queda prohibida. " & _
                "Todas las opiniones contenidas en este mail son propias del autor del mensaje y no necesariamente coinciden con las de la empresa. " & _
                "Si usted ha recibido este mensaje erróneamente, por favor borre el mensaje y sus adjuntos</p>"

                Mail.Enviar(ViewState("mail").ToString(), "Envío de contraseña Lavadero", CuerpoMensaje)

                'SALIO EL MAIL, PERO OJO!!! PUEDE ESTAR MAL LA DIRECCION
                'UtilLogBase.GuardarEvento(Tsu.Entity.LogBase.TipoLogEvento.EnvioPASS, Convert.ToInt32(11111), "Se le envio un Mail a la casilla: " & ViewState("mail").ToString())

            Catch ex As Exception
                Throw New Exception("No puedo enviar mail")
            End Try

        End Sub

        Private Sub NuevaCuenta()
            Try
                Dim Gestor As New BLL.Negocio.BLLCuenta()
                Dim UnaCuenta As New Cuenta()
                UnaCuenta.CUIT = tbCuit.Text
                UnaCuenta.CP = tbCodigoPostal.Text
                UnaCuenta.Contacto = tbContacto.Text
                UnaCuenta.Domicilio = tbDomicilio.Text
                UnaCuenta.Estado = True
                UnaCuenta.Localidad = tbLocalidad.Text
                UnaCuenta.Mail = tbMail.Text
                UnaCuenta.Provincia = New Provincias(1, "buenos aires")
                UnaCuenta.Razon = tbRazonSocial.Text
                UnaCuenta.Responsable = New ResponsabilidadFiscal(1, "Monotributo")
                UnaCuenta.Telefono = tbTelefono.Text
                UnaCuenta.WEB = tbWEB.Text
                UnaCuenta.Tipo = New CuentaTipo(1, "empresa")
                UnaCuenta.Responsable = New ResponsabilidadFiscal(1, "Monotributo")
                UnaCuenta.Provincia = New Provincias(1, "CABA")

                Gestor.InsertarCuenta(UnaCuenta)
            Catch ex As Exception
                Throw New Exception("Error al crear cuenta")
            End Try

        End Sub

#End Region

    End Class

End Namespace
