Imports Tsu.ProviderOra

Imports Tsu.Utilidades

Imports AjaxControlToolkit

Namespace Tsu.Paginas

    Partial Class gestionzona_conferencia
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Try
                If Not Page.IsPostBack() Then
                    If HttpContext.Current.User.IsInRole("G") Then
                        LLenarComboZonaGDZ()
                    Else
                        LLenarComboZonaUyV()
                    End If
                    LLenarComboAnio()
                    LLenarComboCampania()
                    GrillaConferencias1.LLenarGrilla(comboZona.SelectedValue, ddlCampania.SelectedValue, ddlAnio.SelectedValue, "", "")
                End If
                InicializarControlCarga()
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Session("cuenta"), "Gestion/CargaConferencia:" & ex.Message.ToString())
            End Try
        End Sub

#Region "LLenar Combos Año y Campaña"

        Private Sub LLenarComboCampania()
            'Me.ddlCampania.Items.Add(New ListItem("(Todas)", 0))
            For i As Integer = 1 To 20
                ddlCampania.Items.Add(New ListItem(i, i))
            Next
        End Sub

        Private Sub LLenarComboAnio()
            Try
                Dim anioactual As Integer = DateTime.Now.Year
                If anioactual > 2012 Then
                    ddlAnio.Items.Add(New ListItem(anioactual, anioactual))
                End If
                ddlAnio.Items.Add(New ListItem(anioactual + 1, anioactual + 1))
            Catch ex As Exception
                Throw New Exception("LLenarComboAnio:" & ex.Message.ToString())
            End Try

        End Sub

#End Region

        Private Sub LLenarComboZonaUyV()
            Try
                Dim oComunesMap As New fachadaComunes
                Dim ListaZonas As List(Of Integer) = oComunesMap.MostrarZonas()
                For Each NroZona As Integer In ListaZonas
                    comboZona.Items.Add(New ListItem(NroZona.ToString(), NroZona))
                Next
            Catch ex As Exception
                Throw New Exception("LLenarComboZonaUyV:" & ex.Message.ToString())
            End Try

        End Sub

        Private Sub LLenarComboZonaGDZ()
            comboZona.Items.Add(New ListItem(Session("zonaqueatiende").ToString(), Convert.ToInt32(Session("zonaqueatiende"))))
            If Convert.ToInt32(Session("zonasuplente1")) > 0 Then
                comboZona.Items.Add(New ListItem(Session("zonasuplente1").ToString(), Convert.ToInt32(Session("zonasuplente1"))))
            End If
            If Convert.ToInt32(Session("zonasuplente2")) > 0 Then
                comboZona.Items.Add(New ListItem(Session("zonasuplente2").ToString(), Convert.ToInt32(Session("zonasuplente2"))))
            End If
        End Sub


#Region "Eventos de los controles"

        Protected Sub InsertoConferencia(ByVal oConferencia As conferencia) Handles cargaConferencia1.InsertoConferencia
            UtilLogBase.GuardarEvento(LogBase.TipoLogEvento.Conferencia, Session("cuenta"), String.Format("Conferencia CREADO:Salon:{0} Fecha:{1},Hora:{2},Zona:{3},Campania:{4}", oConferencia.salon.id, oConferencia.fecha, oConferencia.hora, oConferencia.zona, oConferencia.campania))
            GrillaConferencias1.LLenarGrilla(comboZona.SelectedValue, ddlCampania.SelectedValue, ddlAnio.SelectedValue, "", "")
        End Sub

        Protected Sub ModificoConferencia(ByVal oConferencia As conferencia) Handles cargaConferencia1.ModificoConferencia
            UtilLogBase.GuardarEvento(LogBase.TipoLogEvento.Conferencia, Session("cuenta"), String.Format("Conferencia Modificado:IdConf: {0} Salon:{1} Fecha:{2},Hora:{3},Zona:{4},Campania:{5}", oConferencia.id, oConferencia.salon.id, oConferencia.fecha, oConferencia.hora, oConferencia.zona, oConferencia.campania))
            GrillaConferencias1.LLenarGrilla(comboZona.SelectedValue, ddlCampania.SelectedValue, ddlAnio.SelectedValue, "", "")
        End Sub

        Protected Sub LLenarPanelCargaConferencia(ByVal idConferencia As Integer) Handles GrillaConferencias1.TocoModificar
            cargaConferencia1.LLenarPanel(idConferencia)
        End Sub

        Protected Sub BorroItemDesdeGrilla(ByVal id As Integer) Handles GrillaConferencias1.Borro
            UtilLogBase.GuardarEvento(LogBase.TipoLogEvento.Conferencia, Session("cuenta"), String.Format("Conferencia BORRADO:{0}", id))
            GrillaConferencias1.LLenarGrilla(comboZona.SelectedValue, ddlCampania.SelectedValue, ddlAnio.SelectedValue, "", "")
        End Sub
#End Region

#Region "Eventos de los combos"
        Protected Sub ddlCampania_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCampania.SelectedIndexChanged, ddlAnio.SelectedIndexChanged, comboZona.SelectedIndexChanged
            GrillaConferencias1.LLenarGrilla(comboZona.SelectedValue, ddlCampania.SelectedValue, ddlAnio.SelectedValue, "", "")
        End Sub
#End Region

#Region "Metodos Privados"


        Private Sub InicializarControlCarga()
            cargaConferencia1.anio = ddlAnio.SelectedValue
            cargaConferencia1.campania = ddlCampania.SelectedValue
            cargaConferencia1.zona = comboZona.SelectedValue
        End Sub
#End Region

        <System.Web.Script.Services.ScriptMethod(), _
       System.Web.Services.WebMethod()> _
      Public Shared Function SearchCustomers(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As List(Of String)
            Dim oSalonMap As New SalonMapOra()
            'Dim zona As Integer = comboZona.SelectedValue
            Dim ListaSalones As List(Of Salon) = oSalonMap.BuscarPorLugar(prefixText, contextKey)
            Dim ListaFormateada As New List(Of String)
            For Each UnSalon As Salon In ListaSalones
                ListaFormateada.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(UnSalon.nombre, UnSalon.id))
            Next
            Return ListaFormateada
        End Function

        Protected Sub btnExportarExcel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExportarExcel.Click
            Try
                GrillaConferencias1.ExportToExcel(comboZona.SelectedValue, ddlCampania.SelectedValue, ddlAnio.SelectedValue)
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Session("cuenta"), "GestionConferencia/ExportarExcel:" & ex.Message.ToString())
            End Try

        End Sub

        Protected Sub OrdenarGrilla(ByVal orden As String, ByVal sentido As String) Handles GrillaConferencias1.Ordenamiento
            GrillaConferencias1.LLenarGrilla(comboZona.SelectedValue, ddlCampania.SelectedValue, ddlAnio.SelectedValue, orden, sentido)
        End Sub

    End Class

End Namespace