
Imports Tsu.ProviderOra
Imports Tsu.Seguridad
Imports Tsu.Utilidades

Namespace Tsu.Paginas

    Partial Class altausuario
        Inherits System.Web.UI.Page

#Region "Controles"
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                
                tbpass.Focus()
            Catch ex As Exception
                'UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Convert.ToInt32(Session("cuenta")), "AltaUsuario/Load:" & ex.Message.ToString())
            End Try

        End Sub

        Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
            Try
                If Page.IsValid Then
                    lblAdvertencia.Text = ""
                    paneladvertencia.Visible = False

                    If (tbRespuesta1.Text = "" And tbRespuesta2.Text = "" And tbRespuesta3.Text = "") Or CheckBox2.Checked = False Then
                        If CheckBox2.Checked = False Then
                            lblAdvertencia.Text = "Deberá aceptar los Términos y Condiciones. Por favor no olvide reingresar su contraseña."
                        Else
                            lblAdvertencia.Text = "Deberá ingresar la contraseña y repetirla, cargar al menos una respuesta, y aceptar los términos y condiciones para confirmar."
                        End If
                        paneladvertencia.Visible = True
                    Else
                        paneladvertencia.Visible = False

                        If Page.IsValid Then
                            ActualizarPreguntas()
                            Dim rol As String = UsuarioCorrecto()
                            Redireccionar(rol)
                        End If

                    End If
                End If
            Catch ex As System.Threading.ThreadAbortException
                'SubProceso anulado por el redirect.
            Catch ex As Exception
                Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.USUARIO, Patente.eAccion.ALTA, String.Format("Alta: {0}", Session("login")), False)

            End Try
        End Sub

        Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
            'btnAceptar.Enabled = (CheckBox2.Checked = True)
        End Sub
#End Region


#Region "Metodos Privados"

        Private Sub ActualizarPreguntas()
            Try
                Dim oDatosUsuarios As New DatosUsuarios()
                oDatosUsuarios.cuenta = Session("Cuenta")
                oDatosUsuarios.respuesta1 = tbRespuesta1.Text
                oDatosUsuarios.respuesta2 = tbRespuesta2.Text
                oDatosUsuarios.respuesta3 = tbRespuesta3.Text
                oDatosUsuarios.contraseniaactual = tbpass.Text
                oDatosUsuarios.recibirinfo = IIf(CheckBox1.Checked = True, 1, 0)

                Dim oDatosUsuariosMap As New DatosUsuariosMapOra()
                oDatosUsuariosMap.ActualizarUsuario(oDatosUsuarios)
            Catch ex As Exception
                Throw New Exception(String.Format("Actualizar Preguntas {0}", ex.Message.ToString()))
            End Try


        End Sub

#Region "USUARIO CORRECTO"

        Private Function UsuarioCorrecto() As String
            Try
                Dim oDatosUsuariosMap As New DatosUsuariosMapOra()
                Dim oDatosUsuarios As DatosUsuarios = oDatosUsuariosMap.MostrarDatosUsuarios(Session("cuenta"))

                Dim cuenta As Integer = Convert.ToInt32(oDatosUsuarios.cuenta)
                Dim oUsuariosMap As New UsuarioMapOra()
                Dim oUsuario As Usuarios = oUsuariosMap.MostrarCabecera(cuenta)
                Dim miCalendarioMap As New CalendarioMapOra()
                Dim oCalendario As Calendario = miCalendarioMap.MostrarCampaniaCarga(oUsuario.zona)
                'GENERAR TICKET()
                Dim rol As String = Me.GenerarTicket(oUsuario, oCalendario, oDatosUsuarios)

                Verificaciones(cuenta, rol, oUsuario, oCalendario)

                Session("cuenta") = oUsuario.cuenta
                Session("zona") = oUsuario.zona
                Session("grupo") = oUsuario.grupo

                Return rol

            Catch ex As Exception
                Throw New Exception(ex.Message.ToString())
            End Try
        End Function

        Private Function GenerarTicket(ByVal oUsuario As Usuarios, ByVal oCalendario As Calendario, ByVal oDatosUsuario As DatosUsuarios) As String
            If oDatosUsuario.horacbiocontrasenia = 0 Then
                'usuario nuevo le cambio el rol a invitado para ingresar a las preguntas en alta/altausuario
                oUsuario.tipousuario = "I"
            End If

            Dim cadenaDeDatos As String = New Tsu.Seguridad.CustomIdentity(oUsuario, oCalendario).DevuelveCadenaDeUsuario()

            ' Create the cookie that contains the forms authentication ticket
            Dim authCookie As HttpCookie = FormsAuthentication.GetAuthCookie(oUsuario.cuenta, False)

            ' Get the FormsAuthenticationTicket out of the encrypted cookie
            Dim ticket As FormsAuthenticationTicket = FormsAuthentication.Decrypt(authCookie.Value)

            ' Create a new FormsAuthenticationTicket that includes our custom User Data
            Dim newTicket As FormsAuthenticationTicket = New FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, False, cadenaDeDatos)

            ' Update the authCookie's Value to use the encrypted version of newTicket
            authCookie.Value = FormsAuthentication.Encrypt(newTicket)

            ' Manually add the authCookie to the Cookies collection
            Response.Cookies.Add(authCookie)

            ' Determine redirect URL and send user there
            Dim redirUrl As String = FormsAuthentication.GetRedirectUrl(oUsuario.cuenta, False)

            Return oUsuario.tipousuario
        End Function

        Private Sub ActualizarUsuarioIngresado(ByVal oDatosUsuarios As DatosUsuarios)
            If oDatosUsuarios.activo > 1 Then
                If Not (oDatosUsuarios.horacbiocontrasenia = 0) Then
                    ' Si ingrese las preguntas, sirve por un cambio de contraseña.
                    Dim oInicioMap As New fachadaInicio()
                    oInicioMap.UsuarioIngresado(oDatosUsuarios.cuenta)
                End If

            End If
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

#Region "Verificaciones"
        Private Sub Verificaciones(ByVal cuenta As Integer, ByVal rol As String, ByVal oUsuario As Usuarios, ByVal oCalendario As Calendario)
            VerificarCabeceraPedidos(oUsuario.cuenta, oCalendario.campania)
            VerificarCabeceraCerrada(oUsuario.cuenta, oCalendario.campania)
            VerificarPerteneceZonaPretendencia(oUsuario)
            VerificarCierreDeZona(rol, oUsuario)
            VerificarCierreDeRevendedora(rol, oCalendario.fecha, oCalendario.horarevendedora)
            VerificarPermisosAuditoria(rol, cuenta)
        End Sub
        'todos los roles
        Private Sub VerificarCabeceraPedidos(ByVal iCuenta As Integer, ByVal iCampania As Integer)
            Dim oPedidosC As New PedidosC()

            Dim oPedidosCMapOra As New PedidosCMapOra()
            oPedidosC = oPedidosCMapOra.MostrarCabPedidos(iCuenta, iCampania)

            If oPedidosC Is Nothing Then
                Session("cabecerapedidos") = False
                Session("cantidadingresos") = 1 'le pongo 1 asi cuando lo inserto queda con ese valor
            Else
                Session("cabecerapedidos") = True
                Session("cantidadingresos") = oPedidosC.cantidadingresos + 1
            End If
        End Sub
        'todos los roles
        Private Sub VerificarCabeceraCerrada(ByVal iCuenta As Integer, ByVal iCampania As Integer)
            'verifica en la cabecera historica si cargo pedido y cuanta cantidad
            Session("CerradoPretendencia") = New HistPedidosCMapOra().PedidoCerrado(iCuenta, iCampania)
        End Sub
        'rol G
        Private Sub VerificarPerteneceZonaPretendencia(ByVal oUsuario As Usuarios)
            If oUsuario.tipousuario = "G" Then
                Session("TieneZonaPretendencia") = False
                Dim miCalendarioMap As New CalendarioMapOra()

                Dim oListaZonasPretendencia As List(Of Integer) = miCalendarioMap.VerificarPerteneceZonaPretendencia(oUsuario)
                Dim CantidadZonasPretendencia As Integer = oListaZonasPretendencia.Count
                If CantidadZonasPretendencia > 0 Then
                    Session("TieneZonaPretendencia") = True
                    For i As Integer = 1 To CantidadZonasPretendencia
                        Session(String.Format("zonapretendencia{0}", i)) = oListaZonasPretendencia.Item(i - 1)
                    Next
                End If
            End If
        End Sub
        'rol G
        Private Sub VerificarCierreDeZona(ByVal rol As String, ByVal oUsuario As Usuarios)
            If rol = "G" Then
                Try
                    Dim oCalendarioMapOra As New CalendarioMapOra()
                    Dim oCalendarioCierraHoy As Calendario = oCalendarioMapOra.MostrarCampaniaCierraHoy(DateTime.Now)
                    Dim horaCierraHoy As Integer = oCalendarioCierraHoy.hora
                    Dim campaniaCierraHoy As Integer = oCalendarioCierraHoy.campania
                    Session("campaniavigente") = campaniaCierraHoy
                Catch ex As Exception
                    Response.Write(ex.Message.ToString())
                End Try
            End If
        End Sub
        'rol R
        Private Sub VerificarCierreDeRevendedora(ByVal rol As String, ByVal fechacierre As Integer, ByVal horacierreRevendedora As Integer)
            If rol = "R" Then
                If fechacierre = Format(Now, "yyyyMMdd") And Format(Now, "HHmm") > horacierreRevendedora Then
                    Session("CerradoPretendencia") = True
                End If
            End If
        End Sub
        'rol P
        Private Sub VerificarPermisosAuditoria(ByVal rol As String, ByVal iCuenta As Integer)
            If rol = "P" Then
                Dim oPerfiles As Perfiles = New PerfilesMapOra().MostrarPerfiles(iCuenta)
                If oPerfiles Is Nothing Then
                    Session("auditoria") = False
                Else
                    Session("auditoria") = True
                End If
            End If
        End Sub
#End Region

#End Region

    End Class


End Namespace