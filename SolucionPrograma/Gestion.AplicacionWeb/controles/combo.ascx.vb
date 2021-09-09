
Imports Tsu.ProviderOra
Imports Tsu.Utilidades

Partial Class controles_combo
    Inherits System.Web.UI.UserControl

#Region "Campos y propiedades"


    Dim _campaniaseleccionada As Integer
    Public Event CambioCampaniaSeleccionada(ByVal campania As Integer)
    Public Event CerroCampania()

    Public Property campaniaseleccionada() As Integer
        Get
            Return _campaniaseleccionada
        End Get
        Set(ByVal value As Integer)
            _campaniaseleccionada = value
        End Set
    End Property

#End Region

#Region "Metodos Publicos"

    Public Sub LLenarCombos(ByVal oUsuario As Usuarios)
        Try
            'busco la campaña de esa zona
            Dim CalendarioZonaRevendedora As Calendario = BuscarCampaniaRevendedoras(oUsuario.zona)
            Session("campaniarevendedora") = CalendarioZonaRevendedora.campania
            'me fijo que no tenga el pedido cerrado
            ddlCampania.Items.Add(New ListItem(Session("campaniarevendedora").ToString().Insert(4, "-") & " - Finaliza el:" & FormatearFecha(CalendarioZonaRevendedora.fecha), Convert.ToInt32(Session("campaniarevendedora"))))

            Dim bPedidoCargadoRevendedora As Boolean = New HistPedidosCMapOra().PedidoCerrado(oUsuario.cuenta, Convert.ToInt32(Session("campaniarevendedora")))
            If bPedidoCargadoRevendedora Then
                'si cargo pedido y cerró, entonces no puede cargar mas.
                RaiseEvent CerroCampania()
            Else
                VerificarPedidoFacturado(oUsuario.cuenta, CalendarioZonaRevendedora.fecha)
            End If
            campaniaseleccionada = ddlCampania.SelectedValue
        Catch ex As Exception
            UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Convert.ToInt32(Session("cuenta")), "Controles/Combo/LLenarCombo:" & ex.Message.ToString())
        End Try
    End Sub

#End Region

#Region "Metodos Privados"

    Private Sub VerificarPedidoFacturado(ByVal Cuenta As Integer, ByVal fechaCierraCampRevendedora As Integer)
        Dim oCalendarioCierraHoy As Calendario = New CalendarioMapOra().MostrarCampaniaCierraHoy(DateTime.Now)
        Dim CampaniaVigente As Integer = oCalendarioCierraHoy.campania

        'verifico si esta en el historico y si cargo pedido y cantidad mayor a 0
        Dim bCampaniaCerrada As Boolean = New HistPedidosCMapOra().PedidoCerrado(Cuenta, CampaniaVigente)

        If bCampaniaCerrada Then
            'muestro mensaje
            lblCampaniaCerrada.Text = "La Revendedora ya facturó la campaña " & CampaniaVigente.ToString().Insert(4, "-") & "."
        Else
            VerificarComplementaria(CampaniaVigente, Session("campaniarevendedora"), fechaCierraCampRevendedora)
        End If
    End Sub

    'actual y complementario
    Private Sub VerificarComplementaria(ByVal CampaniaVigente As Integer, ByVal campaniaRevendedora As Integer, ByVal fechaCierre As Integer)
        If campaniaRevendedora <> CampaniaVigente Then
            Dim horaActual As Integer = Convert.ToInt32(DateTime.Now.ToString("HHmm"))
            Dim fechaActual As Integer = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"))
            Dim oHoraCierraHoy As Calendario = New CalendarioMapOra().MostrarHoraCierraHoy(DateTime.Now)
            Dim horaCierraHoy As Integer = oHoraCierraHoy.hora
            Dim fechaCierraHoy As Integer = oHoraCierraHoy.fecha
            'ver hora cierre general
            If fechaActual = fechaCierraHoy Then
                If Not ((horaActual < horaCierraHoy) Or (horaActual > horaCierraHoy + 100)) Then
                    lblCampaniaCerrada.Text = String.Format("En este horario no puede cargar la campaña {0}, inténtelo más tarde.", CampaniaVigente.ToString().Insert(4, "-"))
                Else
                    'agrego el combo de la vigente
                    ddlCampania.Items.Add(New ListItem(CampaniaVigente.ToString().Insert(4, "-") & " - Campaña Cerrada/Pedido Complementario", CampaniaVigente))
                End If
            Else
                'agrego el combo de la vigente
                ddlCampania.Items.Add(New ListItem(CampaniaVigente.ToString().Insert(4, "-") & " - Campaña Cerrada/Pedido Complementario", CampaniaVigente))
            End If
        End If

    End Sub

    Protected Sub ddlCampania_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCampania.SelectedIndexChanged
        campaniaseleccionada = ddlCampania.SelectedValue
        RaiseEvent CambioCampaniaSeleccionada(ddlCampania.SelectedValue)
    End Sub

    Private Function BuscarCampaniaRevendedoras(ByVal ZonaRevendedoraSeleccionada As Integer) As Calendario
        'busco la campaña de esa zona
        Dim ocalendarioMap As New CalendarioMapOra()
        Dim CalendarioZonaRev As Calendario = ocalendarioMap.MostrarCampaniaCarga(ZonaRevendedoraSeleccionada)
        Return CalendarioZonaRev
    End Function

    Private Function FormatearFecha(ByVal Fecha As Integer) As DateTime
        Return Convert.ToDateTime(Fecha.ToString().Insert(4, "-").Insert(7, "-"))
    End Function

#End Region

End Class
