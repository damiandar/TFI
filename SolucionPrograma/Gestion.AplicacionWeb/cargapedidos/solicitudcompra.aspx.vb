
Imports Tsu.ProviderOra
Imports Tsu.Utilidades

Namespace Tsu.Paginas

    Partial Class cargapedidos_solicitudcompra
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                If Session("revendedora") > 0 Then
                    If Not Page.IsPostBack Then
                        InicializarFormulario()
                    End If
                    InicializarDetalle()
                    InicializarGrilla()
                Else
                    'si no cargue la cuenta del usuario
                    Response.Redirect("~/gestionzona/seleccionarevendedora.aspx?ruta=" + Me.AppRelativeVirtualPath.ToString())
                End If
            Catch ex As System.Threading.ThreadAbortException
                'SubProceso anulado por el redirect.
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.DatoIncorrecto, Session("revendedora"), String.Format("Carga Ped/SolicitudCompra:{0} CtaCarga: {1}", ex.Message.ToString(), Session("cuenta")))
            End Try
        End Sub

#Region "Metodos Privados"

        Private Sub InicializarFormulario()
            Try
                Dim oUsuarioMap As New UsuarioMapOra()
                Dim oUsuario As Usuarios = oUsuarioMap.MostrarCabecera(Convert.ToInt32(Session("revendedora")))
                If oUsuario IsNot Nothing Then
                    'muestro cabecera, veo campaña rev, lleno combos, pedido cerrado
                    ViewState("zonaRevendedora") = oUsuario.zona
                    combo1.LLenarCombos(oUsuario)
                    ViewState("campaniaseleccionada") = combo1.campaniaseleccionada
                    VerificaCabeceraPedido(ViewState("campaniaseleccionada"))
                    Me.panelrevendedora.Visible = True
                    cabeceraRevendedora1.mostrardomicilio = True
                    cabeceraRevendedora1.campania = ViewState("campaniaseleccionada")
                    cabeceraRevendedora1.llenarDatos(oUsuario)
                End If
            Catch ex As Exception
                Throw New Exception("INICIALIZAR FORMULARIO:" & ex.Message.ToString())
            End Try

        End Sub

        Private Sub InicializarGrilla()
            grillaProductos.campania = ViewState("campaniaseleccionada")
            grillaProductos.zona = ViewState("zonaRevendedora")
            grillaProductos.cuenta = Session("revendedora")
            grillaProductos.cuentacarga = Session("cuenta")
            grillaProductos.vereliminar = HttpContext.Current.User.IsInRole("C")
            grillaProductos.verrestaurar = HttpContext.Current.User.IsInRole("U")
            grillaProductos.cantidadingresos = Session("cantidadingresosRevendedora")
            grillaProductos.tipousuario = DevuelveUsuario()
        End Sub

        Private Sub InicializarDetalle()
            Try
                detalle1.campaniaseleccionada = ViewState("campaniaseleccionada")
                detalle1.zona = ViewState("zonaRevendedora")
                detalle1.cuenta = Convert.ToInt32(Session("revendedora"))
                detalle1.cuentacarga = Convert.ToInt32(Session("cuenta"))

                'solo para nc
                If Not Page.IsPostBack Then
                    detalle1.MostrarNumeroPedido(VerificaCabeceraPedido(ViewState("campaniaseleccionada")))
                    detalle1.CargarCampaniaOrigen(Convert.ToInt32(ViewState("campaniaseleccionada")), Convert.ToInt32(ViewState("zonaRevendedora")))
                End If

                detalle1.cantidadingresos = Convert.ToInt32(Session("cantidadingresosRevendedora"))
                detalle1.grupo = Convert.ToInt32(Session("gruporevendedora"))
                detalle1.tipousuario = DevuelveUsuario()
            Catch ex As Exception
                Throw New Exception("INICIALIZAR DETALLE:" & ex.Message.ToString())
            End Try
        End Sub

        Private Function VerificaCabeceraPedido(ByVal iCampania As Integer) As PedidosC
            Dim oPedidosCMap As New PedidosCMapOra()
            Dim oPedidosC As New PedidosC()
            Dim iCuenta As Integer = Convert.ToInt32(Session("revendedora"))
            oPedidosC = oPedidosCMap.MostrarCabPedidos(iCuenta, iCampania)
            If oPedidosC IsNot Nothing Then
                Session("cantidadingresosRevendedora") = oPedidosC.cantidadingresos
            Else
                Session("cantidadingresosRevendedora") = 0
            End If
            Return oPedidosC
        End Function

        Private Sub CerrarPanel()
            PanelPedidoCerrado.Visible = True
            grillaProductos.Visible = False
            PanelCampania.Visible = False
            combo1.Visible = False
            detalle1.Visible = False
        End Sub

        Private Function DevuelveUsuario() As String
            Dim retorno As String = "R"
            If HttpContext.Current.User.IsInRole("R") Then
                retorno = "R"
            ElseIf HttpContext.Current.User.IsInRole("G") Then
                retorno = "G"
            ElseIf HttpContext.Current.User.IsInRole("V") Then
                retorno = "V"
            ElseIf HttpContext.Current.User.IsInRole("U") Then
                retorno = "U"
            ElseIf HttpContext.Current.User.IsInRole("P") Then
                retorno = "P"
            ElseIf HttpContext.Current.User.IsInRole("C") Then
                retorno = "C"
            End If
            Return retorno
        End Function

#End Region

#Region "Eventos de controles"

        Protected Sub ActualizoCabeceraGrilla(ByVal Cuenta As Integer, ByVal Campania As Integer) Handles grillaProductos.ActualizoCabecera
            Try
                Dim oPedidosC As New PedidosC
                oPedidosC.cuenta = Cuenta
                oPedidosC.campania = Campania
                oPedidosC.cantidadingresos = Convert.ToInt32(Session("cantidadingresosRevendedora"))
                Dim oPedidosCMap As New PedidosCMapOra()
                oPedidosCMap.ActualizarCabPedidos(oPedidosC)
                oPedidosC = oPedidosCMap.MostrarCabPedidos(Cuenta, Campania)
                detalle1.MostrarNumeroPedido(oPedidosC)
            Catch ex As Exception
                Throw New Exception("CargaPedidos/ActualizoCabecera:" & ex.Message.ToString())
            End Try

        End Sub

        Protected Sub CambioCampaniaSeleccionada(ByVal campaniaseleccionada As Integer) Handles combo1.CambioCampaniaSeleccionada
            Try
                detalle1.limpiar()
                ViewState("campaniaseleccionada") = combo1.campaniaseleccionada
                Dim oPedidosC As PedidosC = VerificaCabeceraPedido(ViewState("campaniaseleccionada"))
                cabeceraRevendedora1.MostrarCabeceraDomicilio(Session("revendedora"), ViewState("zonaRevendedora"), ViewState("campaniaseleccionada"))
                InicializarDetalle()
                InicializarGrilla()
                grillaProductos.LLenar()
                detalle1.CargarCampaniaOrigen(ViewState("campaniaseleccionada"), ViewState("zonaRevendedora"))
                detalle1.MostrarNumeroPedido(oPedidosC)
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.DatoIncorrecto, Session("revendedora"), String.Format("Carga Ped/CambioCampaniaSeleccionada:{0} CtaCarga: {1}", ex.Message.ToString(), Session("cuenta")))
            End Try
        End Sub

        Protected Sub CargaMasiva() Handles detalle1.CargaMasiva
            Response.Redirect("~/cargapedidos/cargarapida.aspx")
        End Sub

        Protected Sub InsertoDetalle() Handles detalle1.SeActualizo
            InicializarGrilla()
            grillaProductos.LLenar()
            grillaProductos.Ordenar()
        End Sub

        Protected Sub CargoCampanias() Handles combo1.CerroCampania
            CerrarPanel()
        End Sub

#End Region


    End Class

End Namespace