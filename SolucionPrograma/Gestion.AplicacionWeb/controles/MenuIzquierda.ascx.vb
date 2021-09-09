Namespace Tsu.Paginas

    Partial Class controles_MenuIzquierda
        Inherits System.Web.UI.UserControl

        Public Enum TipoMenu
            Solicitud = 1
            Consultas = 2
            Datos = 3
            Gestion = 4
            Revendedoras = 5
            Ayuda = 6
            Administracion = 7
        End Enum

        Dim _menu As TipoMenu

        Public Property menu() As TipoMenu
            Get
                Return _menu
            End Get
            Set(ByVal value As TipoMenu)
                _menu = value
            End Set
        End Property

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            'Dim ident As FormsIdentity = CType(HttpContext.Current.User.Identity, FormsIdentity)
            'Dim ticket As FormsAuthenticationTicket = ident.Ticket
            'Dim ci As New CustomIdentity(ticket)
            Dim Rol As String = "R" ' ci.Rol.ToString()
            'borro todos los items del menu
            Menu1.Items.Clear()

            If menu = TipoMenu.Solicitud Then
                MenuSolicitudCompra(Rol)
            ElseIf menu = TipoMenu.Consultas Then
                MenuConsultas(Rol)
            ElseIf menu = TipoMenu.Datos Then
                MenuDatosPersonales(Rol)
            ElseIf menu = TipoMenu.Revendedoras Then
                MenuRevendedoras(Rol)
            ElseIf menu = TipoMenu.Administracion Then
                MenuAdministracion(Rol)
            ElseIf menu = TipoMenu.Ayuda Then
                MenuAyuda(Rol)
            End If


        End Sub

        Public Sub MenuAyuda(ByVal Rol As String)
            'datos personales
            Dim item1 As New MenuItem("Manual online", "", "", "../manual/personal/manual.html")
            Dim Item3 As New MenuItem("Manual en pdf", "", "", "../manual/personal/ManualPdf.pdf")

            Dim item2 As New MenuItem("Manual online", "", "", "../manual/revendedoras/visor/index.htm")
            Dim Item4 As New MenuItem("Manual en pdf", "", "", "../manual/revendedoras/ManualPdf.pdf")

            Dim Item5 As New MenuItem("Preguntas frecuentes", "", "", "../aplicacion/preguntasfrecuentes.aspx")

            '14/12/2012 mbruno
            Dim Item6 As New MenuItem("Contacto", "", "", "../aplicacion/contacto.aspx")

            item1.Target = "_blank"
            item2.Target = "_blank"
            Item3.Target = "_blank"
            Item4.Target = "_blank"

            If Rol = "P" Then
                Menu1.Items.Add(item1)
                Menu1.Items.Add(Item3)
            Else
                Menu1.Items.Add(item2)
                Menu1.Items.Add(Item4)
            End If
            Menu1.Items.Add(Item5)
            If Rol = "G" Or Rol = "R" Or Rol = "C" Then
                Menu1.Items.Add(Item6)
            End If
        End Sub

        Public Sub MenuDatosPersonales(ByVal Rol As String)
            'datos personales
            Dim Item1 As New MenuItem("Cambiar Contraseña", "", "", "../micuenta/cambioclave.aspx")
            Dim Item2 As New MenuItem("Información Personal", "", "", "../micuenta/datospersonales.aspx")
            Dim Item3 As New MenuItem("Graficos", "", "", "../micuenta/graficos.aspx")
            Dim Item4 As New MenuItem("Mail", "", "", "../micuenta/mail.aspx")
            Dim Item5 As New MenuItem("Reportes", "", "", "../micuenta/reportes.aspx")
            Dim Item6 As New MenuItem("Servicios", "", "", "../servicios/altaservicio.aspx")
            Menu1.Items.Add(Item1)
            Menu1.Items.Add(Item2)
            Menu1.Items.Add(Item3)
            Menu1.Items.Add(Item4)
            Menu1.Items.Add(Item5)
            Menu1.Items.Add(Item6)
        End Sub

        Public Sub MenuSolicitudCompra(ByVal Rol As String)
            'solicitud compra
            Dim itDomicilioOpcion As New MenuItem("Domicilio de opción", "", "", "../micarga/domicilioalternativo.aspx")
            Dim itFolletos As New MenuItem("Catálogos", "", "", "../micarga/catalogos.aspx")
            Dim itProdyAux As New MenuItem("Productos y Auxiliares", "", "", "../micarga/solicitudcompra.aspx")
            Dim itProd As New MenuItem("Productos", "", "", "../micarga/solicitudcompra.aspx")
            Dim itPremios As New MenuItem("Premios", "", "", "../micarga/premios.aspx")
            Dim itCambiosyReclamos As New MenuItem("Cambios y Reclamos", "", "", "../micarga/cambiosyreclamos.aspx")
            Dim itNotaCredito As New MenuItem("Notas de crédito", "", "", "../micarga/notasdecredito.aspx")
            Dim itPedidosAnt As New MenuItem("Pedidos anteriores", "", "", "../micarga/consultas.aspx")
            Dim itFinalizar As New MenuItem("Cerrar la carga", "", "", "../Logout.aspx?salir=fin")

            If Rol = "C" Or Rol = "R" Or Rol = "H" Then
                Menu1.Items.Add(itDomicilioOpcion)
                Menu1.Items.Add(itFolletos)
                Menu1.Items.Add(itProdyAux)
                Menu1.Items.Add(itPremios)
            Else
                Menu1.Items.Add(itProd)
            End If

            Menu1.Items.Add(itCambiosyReclamos)

            If Rol = "C" Or Rol = "R" Or Rol = "H" Then
                Menu1.Items.Add(itNotaCredito)
            End If

            If Rol = "G" Or Rol = "U" Or Rol = "V" Then
                Menu1.Items.Add(itPedidosAnt)
            End If
            Menu1.Items.Add(itFinalizar)
        End Sub

        Public Sub MenuAdministracion(ByVal Rol As String)
            'gestion de zona
            Dim itBackUp As New MenuItem("BackUP", "", "", "../administracion/backup.aspx")
            Dim itBitacora As New MenuItem("Bitacora", "", "", "../administracion/bitacora.aspx")

            'itConferencias.ChildItems().Add(itLugares)
            Menu1.Items.Add(itBitacora)
            Menu1.Items.Add(itBackUp)



        End Sub

        Public Sub MenuConsultas(ByVal Rol As String)
            'Dim itConsultas As New MenuItem("CONSULTAS", "", "", "../aplicacion/consultas.aspx")
            Dim itPedidosAnt As New MenuItem("Pedidos anteriores", "", "", "../micarga/consultas.aspx")
            Dim itEvolucion As New MenuItem("Evolución de pedidos", "", "", "../informes/evolucionpedidos.aspx")
            Dim itEstados As New MenuItem("Estados de sesión", "", "", "../tmk/estadosesion.aspx")
            Dim itConferencias As New MenuItem("Conferencias", "", "", "../micarga/conferencias.aspx")
            Dim itConferenciasAsistente As New MenuItem("Conferencias", "", "", "../especiales/conferencias.aspx")
            Dim itReparto As New MenuItem("Calendario de reparto", "", "", "../micarga/reparto.aspx")

            If Rol = "G" Or Rol = "V" Or Rol = "U" Then
                MenuSolicitudCompra(Rol)
            End If
            If Rol <> "G" And Rol <> "V" And Rol <> "U" And Rol <> "D" Then
                Menu1.Items.Add(itPedidosAnt)

            End If

            If Rol = "P" And Convert.ToBoolean(Session("auditoria")) = True Then
                Menu1.Items.Add(itConferenciasAsistente)
            End If

            If Rol = "R" Then
                Menu1.Items.Add(itConferencias)
                Menu1.Items.Add(itReparto)
            End If

            If Rol = "D" Then
                Menu1.Items.Add(itEstados)
            End If
            If Rol = "C" Or Rol = "H" Then
                Menu1.Items.Add(itConferencias)
                Menu1.Items.Add(itEvolucion)
                Menu1.Items.Add(itReparto)
            End If
        End Sub

        Public Sub MenuRevendedoras(ByVal Rol As String)

            Dim itCuentaRevGer As New MenuItem("Cuenta Revendedora", "", "", "../gestionzona/seleccionarevendedora.aspx")
            Dim itCuentaRevCoord As New MenuItem("Cuenta Revendedora", "", "", "../revendedoras/grupos.aspx")
            Dim itConsultasRev As New MenuItem("Consultas ped.anteriores", "", "", "../informes/consultas.aspx")

            Dim itDomicilioOpcionRev As New MenuItem("Domicilio de opción", "", "", "../cargapedidos/domicilioalternativo.aspx")

            Dim itFolletosRev As New MenuItem("Catálogos", "", "", "../cargapedidos/catalogosRevendedoras.aspx")
            Dim itProdyAuxRev As New MenuItem("Productos y Auxiliares", "", "", "../cargapedidos/solicitudcompra.aspx")
            Dim itPremiosRev As New MenuItem("Premios", "", "", "../cargapedidos/premiosrevendedoras.aspx")
            Dim itCambiosyReclamosRev As New MenuItem("Cambios y Reclamos", "", "", "../cargapedidos/cambios.aspx")
            Dim itNotaCreditoRev As New MenuItem("Notas de crédito", "", "", "../cargapedidos/nc.aspx")

            Dim itDomicilioOpcionCoor As New MenuItem("Domicilio de opción", "", "", "../revendedoras/domicilioalternativo.aspx")

            Dim itFolletosCoor As New MenuItem("Catálogos", "", "", "../revendedoras/catalogosRevendedoras.aspx")
            Dim itProdyAuxCoor As New MenuItem("Productos y Auxiliares", "", "", "../revendedoras/solicitudcompra.aspx")
            Dim itPremiosCoor As New MenuItem("Premios", "", "", "../revendedoras/premiosrevendedoras.aspx")
            Dim itCambiosCoor As New MenuItem("Cambios y Reclamos", "", "", "../revendedoras/cambios.aspx")
            Dim itNotaCreditoCoor As New MenuItem("Notas de crédito", "", "", "../revendedoras/nc.aspx")




            Dim itConsultasPedidosPend As New MenuItem("Consultas ped.en curso", "", "", "../informes/consultasPendientes.aspx")
            Dim itConsultasPedidosAnulados As New MenuItem("Consultas anulados", "", "", "../informes/consultasAnulados.aspx")



            If Rol = "C" Or Rol = "H" Then
                Menu1.Items.Add(itCuentaRevCoord)
                Menu1.Items.Add(itDomicilioOpcionCoor)
                Menu1.Items.Add(itFolletosCoor)
                Menu1.Items.Add(itProdyAuxCoor)
                Menu1.Items.Add(itPremiosCoor)
                Menu1.Items.Add(itCambiosCoor)
                Menu1.Items.Add(itNotaCreditoCoor)
            Else
                Menu1.Items.Add(itCuentaRevGer)
                Menu1.Items.Add(itDomicilioOpcionRev)
                Menu1.Items.Add(itFolletosRev)
                Menu1.Items.Add(itProdyAuxRev)
                Menu1.Items.Add(itPremiosRev)
                Menu1.Items.Add(itCambiosyReclamosRev)
                Menu1.Items.Add(itNotaCreditoRev)
            End If


            If Rol = "V" Or Rol = "U" Or Rol = "D" Then
                Menu1.Items.Add(itConsultasRev)
                Menu1.Items.Add(itConsultasPedidosPend)
                Menu1.Items.Add(itConsultasPedidosAnulados)
            End If

            If Rol = "G" Then
                Menu1.Items.Add(itConsultasRev)
                Menu1.Items.Add(itConsultasPedidosPend)
                Menu1.Items.Add(itConsultasPedidosAnulados)
            End If

        End Sub

        Protected Sub Menu1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu1.Load

        End Sub
    End Class

End Namespace