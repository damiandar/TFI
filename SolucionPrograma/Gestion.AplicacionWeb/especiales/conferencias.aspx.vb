
Imports Tsu.ProviderOra

Namespace Tsu.Paginas

    Partial Class especiales_conferencias
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                LLenarComboAnio()
                LLenarComboZonaUyV()
                LLenarComboCampania()
                GrillaConferencias1.LLenarGrilla(comboZona.SelectedValue, ddlAnio.SelectedValue, ddlAnio.SelectedValue, "", "")
            End If
        End Sub

#Region "Metodos Privados"

        Private Sub LLenarComboCampania()
            ComboCampania.Items.Clear()
            Dim oMapConferencias As New ConferenciaMapOra()
            Dim ListaConferencias As List(Of conferencia)

            Dim fechaActual As Integer = Format(DateTime.Now.Year, "0000") & Format(DateTime.Now.Month, "00") & Format(DateTime.Now.Day, "00")
            ListaConferencias = oMapConferencias.ListarConferencias(comboZona.SelectedValue, 0, 0).Where(Function(x) x.fecha >= fechaActual).ToList()
            'OrderBy(Function(x) x.anio).ThenBy(Function(x) x.campania).ThenBy(Function(x) x.fecha).ToList()
            Dim customComparer As IEqualityComparer(Of conferencia) = New Distinto(Of conferencia)("campania")
            ComboCampania.Items.Add(New ListItem("Todas", 0))
            For Each oConferencia As conferencia In ListaConferencias.Distinct(customComparer).OrderBy(Function(x) x.campania).ToList()
                ComboCampania.Items.Add(New ListItem(oConferencia.campania, oConferencia.campania))
            Next
        End Sub

        Private Sub LLenarComboAnio()
            Dim anioactual As Integer = DateTime.Now.Year
            ddlAnio.Items.Add(New ListItem("Todos", 0))
            ddlAnio.Items.Add(New ListItem(anioactual, anioactual))
            ddlAnio.Items.Add(New ListItem(anioactual + 1, anioactual + 1))
        End Sub

        Private Sub LLenarComboZonaUyV()
            Dim oComunesMap As New fachadaComunes
            Dim ListaZonas As List(Of Integer) = oComunesMap.MostrarZonas()
            For Each NroZona As Integer In ListaZonas
                comboZona.Items.Add(New ListItem(NroZona.ToString(), NroZona))
            Next
        End Sub
#End Region

#Region "Control de Eventos"
        Protected Sub ComboCampania_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCampania.SelectedIndexChanged
            GrillaConferencias1.LLenarGrilla(comboZona.SelectedValue, ComboCampania.SelectedValue, ddlAnio.SelectedValue, "", "")
        End Sub

        Protected Sub ddlAnio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAnio.SelectedIndexChanged
            GrillaConferencias1.LLenarGrilla(comboZona.SelectedValue, ComboCampania.SelectedValue, ddlAnio.SelectedValue, "", "")
        End Sub

        Protected Sub OrdenarGrilla(ByVal orden As String, ByVal sentido As String) Handles GrillaConferencias1.Ordenamiento
            GrillaConferencias1.LLenarGrilla(comboZona.SelectedValue, ComboCampania.SelectedValue, ddlAnio.SelectedValue, orden, sentido)
        End Sub

        Protected Sub comboZona_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboZona.SelectedIndexChanged
            LLenarComboCampania()
            GrillaConferencias1.LLenarGrilla(comboZona.SelectedValue, ComboCampania.SelectedValue, ddlAnio.SelectedValue, "", "")
        End Sub
#End Region

    End Class

End Namespace