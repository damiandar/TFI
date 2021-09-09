Imports Tsu.ProviderOra

Imports Tsu.Utilidades
Imports System.Web.Configuration

Namespace Tsu.Paginas
    Partial Class login
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            'Response.Write(WebConfigurationManager.AppSettings("mailTelemarketing").ToString())

            UserName.Focus()
        End Sub

        Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LoginButton.Click
            If Page.IsValid Then
                Try

                    Me.Validar(UserName.Text, pwd.Text)
                Catch ex As System.Threading.ThreadAbortException
                    'SubProceso anulado por el redirect.
                Catch ex As Exception
                    Response.Write(ex.Message.ToString())
                    ' UtilLogBase.Guardar(Tsu.Entity.LogBase.TipoLog.ErrorMAP, UserName.Text, "LOGIN:" & ex.Message.ToString())
                End Try
            End If
        End Sub

#Region "Metodos Privados"
        Private Function DesEncripta(ByVal Pass As String) As String

            Dim Clave As String, i As Integer, Pass2 As String

            Dim CAR As String, Codigo As String

            Dim j As Integer




            Clave = "%<&/@#$A"

            Pass2 = ""

            j = 1

            For i = 1 To Len(Pass) Step 2

                CAR = Mid(Pass, i, 2)

                Codigo = Mid(Clave, ((j - 1) Mod Len(Clave)) + 1, 1)

                Pass2 = Pass2 & Chr(Asc(Codigo) Xor Val("&h" + CAR))

                j = j + 1

            Next i

            DesEncripta = Pass2

        End Function

        Private Function Encripta(ByVal Pass As String) As String

            Dim Clave As String, i As Integer, Pass2 As String

            Dim CAR As String, Codigo As String

            Clave = "%<&/@#$A"

            Pass2 = ""

            For i = 1 To Len(Pass)

                CAR = Mid(Pass, i, 1)

                Codigo = Mid(Clave, ((i - 1) Mod Len(Clave)) + 1, 1)

                Pass2 = Pass2 & Right("0" & Hex(Asc(Codigo) Xor Asc(CAR)), 2)

            Next i

            Encripta = Pass2

        End Function

        Private Sub Validar(ByVal UserName As String, ByVal pwd As String)
            Dim iMaximosIntentos As Integer = Session("maxIntentos")
            If Not Session("cuentarepetida").Equals(UserName) Then
                Session("contadorSession") = 0
                Session("cuentarepetida") = UserName
                ViewState("valor") = 0
            End If

            Dim GestorUsuarios As New Gestor_Seguridad
            Dim UsuarioValidado As Usuario = GestorUsuarios.ValidarCredenciales(UserName, pwd)


            If UsuarioValidado Is Nothing Then
                UsuarioIncorrecto(iMaximosIntentos)
            Else
                GenerarTicket(UsuarioValidado.Login, "R")
                ' ActualizarUsuarioIngresado(oDatosUsuarios)
                ViewState("valor") = 0
                'UtilLogBase.RegistrarUsuariosConectados(Convert.ToInt32(UserName), Request.ServerVariables("REMOTE_ADDR").ToString())
                Redireccionar("R")
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
                Me.lblCantidadSuperada.Text = "En el próximo intento inválido, la redireccionará a 'Olvidé mi contraseña' para poder recuperar su clave."
            End If
            InvalidCredentialsMessage.Visible = True
            'reinicio el contador de intentos
        End Sub

#Region "USUARIO CORRECTO"

        Private Sub GenerarTicket(ByVal Login As String, ByVal Familia As String)
            'If oDatosUsuario.horacbiocontrasenia = 0 Then
            '    'usuario nuevo le cambio el rol a invitado para ingresar a las preguntas en alta/altausuario
            '    oUsuario.tipousuario = "I"
            'End If

            Dim cadenaDeDatos As String = "" 'New Tsu.Seguridad.CustomIdentity(oUsuario, oCalendario).DevuelveCadenaDeUsuario()

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

        Private Sub Redireccionar(ByVal rol As String)
            If rol = "V" Then
                Response.Redirect("~/informes/evolucionpedidos.aspx")
            ElseIf rol = "I" Then
                Response.Redirect("~/alta/altausuario.aspx")
            Else
                Response.Redirect("~/aplicacion/default.aspx")
            End If
        End Sub

#End Region


#End Region
    End Class
End Namespace