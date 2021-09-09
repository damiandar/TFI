
Partial Class controles_login_login
    Inherits System.Web.UI.UserControl

    Protected Sub lnkLogin_Click(sender As Object, e As System.EventArgs) Handles lnkLogin.Click
        Try
            Me.Validar(UserName.Text, pwd.Text)
        Catch ex As System.Threading.ThreadAbortException
            Dim a As String = ex.Message.ToString()
        Catch ex As Exception
            lblMensaje.Text = "ERROR AL INTENTAR INGRESAR AL SISTEMA"
            Mapper_Bitacora.GuardarBitacora(UserName.Text, Patente.eObjeto.LOGIN, Patente.eAccion.INICIOSESION, String.Format("ERROR AL INGRESAR: {0}", ex.Message.ToString()), True)
        End Try

    End Sub

    Private Sub Validar(ByVal UserName As String, ByVal pwd As String)
        Dim iMaximosIntentos As Integer = Session("maxIntentos")
        'If Not Session("cuentarepetida").Equals(UserName) Then
        '    Session("contadorSession") = 0
        '    Session("cuentarepetida") = UserName
        '    ViewState("valor") = 0
        'End If

        Dim GestorUsuarios As New Gestor_Seguridad

        Dim UsuarioValidado As Usuario = GestorUsuarios.ValidarCredenciales(UserName, pwd)


        If UsuarioValidado Is Nothing Then
            ' UsuarioIncorrecto(iMaximosIntentos)
            'Dim CSM As ClientScriptManager = Page.ClientScript
            'Dim script As String = "<script type='text/javascript'>alert('Usuario Incorrecto'); </script>"
            'CSM.RegisterClientScriptBlock(Me.GetType, "Test", script)
            lblMensaje.Text = "Usuario o contraseña incorrecta"
        Else

            Session("rol") = UsuarioValidado.familia.IdFamilia
            Session("login") = UsuarioValidado.Login

            If UsuarioValidado.familia.IdFamilia = 1 Then    'tabla familia
                'cliente
                'SI ES FAMILIA "CLIENTE->FRONTEND
                'busco la cuenta de ese usuario
                Dim UnCliente As New Cliente

                Dim GestorCliente As New BLLCliente
                UnCliente = GestorCliente.BuscarPorLogin(Session("login"))

                If UnCliente IsNot Nothing Then
                    'se registro y cargo los datos de cliente
                    Session("clienteid") = UnCliente.ID
                    ' ActualizarUsuarioIngresado(oDatosUsuarios)
                    Mapper_Bitacora.GuardarBitacora(UserName, Patente.eObjeto.LOGIN, Patente.eAccion.INICIOSESION, "EL CLIENTE INGRESO", False)
                Else
                    'debe cargar los datos de cliente
                    UsuarioValidado.familia.IdFamilia = 0 'para que lo redireccione al alta.
                    Mapper_Bitacora.GuardarBitacora(UserName, Patente.eObjeto.LOGIN, Patente.eAccion.INICIOSESION, "EL CLIENTE INGRESO POR PRIMERA VEZ CON LA CLAVE ENVIADA AL MAIL", False)
                End If

            Else
                'es usuario y no es cliente
                Mapper_Bitacora.GuardarBitacora(UserName, Patente.eObjeto.LOGIN, Patente.eAccion.INICIOSESION, "EL USUARIO INGRESO", False)

            End If
            GenerarTicket(UsuarioValidado.Login, UsuarioValidado.familia.IdFamilia)
            Redireccionar(UsuarioValidado)
        End If
    End Sub

    Private Sub UsuarioIncorrecto(ByVal iMaximosIntentos As Integer)
        'los datos son incorrectos
        If Session("contadorSession").Equals(iMaximosIntentos) Then
            'se bloquea/ lo dejamos de lado en esta version
            'Me.Bloquear(Convert.ToInt32(UserName.Text))
            'Response.Redirect("loginfalla.aspx?cuenta=" & UserName.Text)

            'en esta version lo mandamos a olvide mi contraseña
            Response.Redirect("~/olvido.aspx")
        Else
            'error en los datos
            Session("contadorSession") += 1
            ViewState("valor") = Session("contadorsession")

        End If

        'If valor = 3 Then
        '    Me.lblCantidadSuperada.Text = "En el próximo intento se le bloqueará la cuenta, si desea puede ir a la opción Olvidé mi contraseña."
        'End If
        If ViewState("valor") = 3 Then
            'Me.lblCantidadSuperada.Text = "En el próximo intento inválido, la redireccionará a 'Olvidé mi contraseña' para poder recuperar su clave."
        End If
        'InvalidCredentialsMessage.Visible = True
        'reinicio el contador de intentos
    End Sub

#Region "USUARIO CORRECTO"

    Private Sub GenerarTicket(ByVal Login As String, ByVal Familia As String)
        'If oDatosUsuario.horacbiocontrasenia = 0 Then
        '    'usuario nuevo le cambio el rol a invitado para ingresar a las preguntas en alta/altausuario
        '    oUsuario.tipousuario = "I"
        'End If

        Dim cadenaDeDatos As String = Familia & "|" & Familia

        ' Create the cookie that contains the forms authentication ticket
        Dim authCookie As HttpCookie = FormsAuthentication.GetAuthCookie(Login, False)

        ' Get the FormsAuthenticationTicket out of the encrypted cookie
        Dim ticket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie.Value)

        ' Create a new FormsAuthenticationTicket that includes our custom User Data
        Dim newTicket As FormsAuthenticationTicket = New FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, False, cadenaDeDatos)

        ' Update the authCookie's Value to use the encrypted version of newTicket
        authCookie.Value = FormsAuthentication.Encrypt(newTicket)

        ' Manually add the authCookie to the Cookies collection
        Response.Cookies.Add(authCookie)

        ' Determine redirect URL and send user there
        Dim redirUrl As String = FormsAuthentication.GetRedirectUrl(Login, False)

    End Sub

    Private Sub Redireccionar(ByVal UsuarioValidado As Usuario)
        Dim rol As Integer = UsuarioValidado.familia.IdFamilia
        If rol = 1 Then
            Response.Redirect("~/frontend/default.aspx", False)
        ElseIf rol > 1 Then
            Response.Redirect("~/backend/default.aspx")
        ElseIf rol = 0 Then
            Response.Redirect(String.Format("~/alta/Default.aspx?login={0}", UsuarioValidado.Login))
        End If
    End Sub

#End Region

End Class
