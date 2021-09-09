
Imports Tsu.ProviderOra
Imports Tsu.Utilidades
Imports Tsu.Seguridad

Namespace Tsu.Paginas

    Partial Class administracion_evolucionpedidos

        Inherits System.Web.UI.Page

#Region "Campos y Propiedades"


        Protected Property ValorFiltro() As String
            Get
                Dim o As Object = ViewState("ValorFiltrado")
                If o Is Nothing Then
                    Return String.Empty
                End If
                Return CStr(o)
            End Get
            Set(ByVal value As String)
                ViewState("ValorFiltrado") = value
            End Set
        End Property

        Protected Property ValorFiltroCampania() As String
            Get
                Dim o As Object = ViewState("ValorFiltradoCampania")
                If o Is Nothing Then
                    Return String.Empty
                End If
                Return CStr(o)
            End Get
            Set(ByVal value As String)
                ViewState("ValorFiltradoCampania") = value
            End Set
        End Property

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Not Page.IsPostBack Then
                LLenarComboUV()
            End If
        End Sub

        Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar.Click
            LLenar("", "", controles_GrillaEvolucion.eTipo.Vacio)

        End Sub

        Private Sub LLenarComboUV()
            Try
                If Not Page.IsPostBack Then
                    'combocampania
                    Me.ddlCampania.Items.Add(New ListItem("(Todas)", 0))

                    Dim oCalendarioMap As New CalendarioMapOra()
                    Dim ListaTotal As New List(Of Calendario)
                    ListaTotal = oCalendarioMap.MostrarListaCampaniasVigentes(Session("zona"))
                    For i As Integer = 0 To 6
                        ddlCampania.Items.Add(New ListItem(ListaTotal.Item(i).campania.ToString(), Convert.ToInt32(ListaTotal.Item(i).campania)))
                    Next

                    'combozona
                    Dim oComunesMapOra As New fachadaComunes()
                    Me.comboZona.Items.Add(New ListItem("(Todas)", 0))

                    Dim listaZonas As New List(Of Integer)
                    listaZonas.AddRange(oComunesMapOra.MostrarZonas())
                    For Each zona As Integer In listaZonas
                        comboZona.Items.Add(New ListItem(zona.ToString(), zona))
                    Next

                End If
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Convert.ToInt32(Session("cuenta")), "Evolucion Pedidos/LLenarComboUV:" & ex.Message.ToString())
            End Try

        End Sub

        Protected Sub OrdenarGrilla(ByVal campo As String, ByVal sentido As String) Handles GrillaEvolucionCerrado.Ordenamiento, GrillaEvolucionCurso.Ordenamiento
            LLenar(campo, sentido, controles_GrillaEvolucion.eTipo.Vacio)
        End Sub

        Protected Sub LLenar(ByVal orden As String, ByVal sentido As String, ByVal TipoGrilla As controles_GrillaEvolucion.eTipo)
            Dim oCalendarioMap As New CalendarioMapOra()
            Dim ListaCalendarioAnterior As List(Of Calendario) = oCalendarioMap.MostrarCampaniaAnterior(Session("zona"))
            Session("ultimacampaniarevendedora") = ListaCalendarioAnterior.Item(5).campania

            GrillaEvolucionCurso.ultimacampaniarevendedora = Session("ultimacampaniarevendedora")
            GrillaEvolucionCerrado.ultimacampaniarevendedora = Session("ultimacampaniarevendedora")
            GrillaEvolucionCurso.zona = comboZona.SelectedValue
            GrillaEvolucionCurso.campania = ddlCampania.SelectedValue
            GrillaEvolucionCerrado.zona = comboZona.SelectedValue
            GrillaEvolucionCerrado.campania = ddlCampania.SelectedValue
            GrillaEvolucionCurso.GrillaExportacion = TipoGrilla
            GrillaEvolucionCerrado.GrillaExportacion = TipoGrilla
            GrillaEvolucionCurso.LLenarGeneral(orden, sentido)
            GrillaEvolucionCerrado.LLenarGeneral(orden, sentido)
            PanelInforme.Visible = True
        End Sub


        Protected Sub ExportarGrilla(ByVal TipoGrilla As controles_GrillaEvolucion.eTipo) Handles GrillaEvolucionCerrado.Exportar, GrillaEvolucionCurso.Exportar
            LLenar("", "", TipoGrilla)
        End Sub

    End Class

End Namespace