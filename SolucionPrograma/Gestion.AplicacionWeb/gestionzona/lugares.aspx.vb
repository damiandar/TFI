Imports Tsu.ProviderOra

Imports Tsu.Utilidades

Namespace Tsu.Paginas
    Partial Class gestionzona_lugares
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                If HttpContext.Current.User.IsInRole("G") Then
                    LLenarComboZonaGDZ()
                Else
                    LLenarComboZonaUyV()
                End If
                GrillaLugares1.LLenarGrilla(combozona.SelectedValue)
            End If

            cargaSalon1.zona = combozona.SelectedValue
        End Sub

#Region "LLenar Combos"
        Private Sub LLenarComboZonaGDZ()
            'combozona
            'Me.comboZona.Items.Add(New ListItem("(Todas)", 0))
            combozona.Items.Add(New ListItem(Session("zonaqueatiende").ToString(), Convert.ToInt32(Session("zonaqueatiende"))))
            If Convert.ToInt32(Session("zonasuplente1")) > 0 Then
                combozona.Items.Add(New ListItem(Session("zonasuplente1").ToString(), Convert.ToInt32(Session("zonasuplente1"))))
            End If
            If Convert.ToInt32(Session("zonasuplente2")) > 0 Then
                combozona.Items.Add(New ListItem(Session("zonasuplente2").ToString(), Convert.ToInt32(Session("zonasuplente2"))))
            End If
        End Sub

        Private Sub LLenarComboZonaUyV()
            Dim oMap As New fachadaComunes
            Dim ListaZonas As List(Of Integer) = oMap.MostrarZonas()
            For Each NroZona As Integer In ListaZonas
                combozona.Items.Add(New ListItem(NroZona.ToString(), NroZona))
            Next
        End Sub
#End Region

        Protected Sub combozona_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles combozona.SelectedIndexChanged
            GrillaLugares1.LLenarGrilla(combozona.SelectedValue)
        End Sub

#Region "Eventos de controles"

        Protected Sub LLenarPaneldeCarga(ByVal idlugar As Integer, ByVal idzona As Integer) Handles GrillaLugares1.TocoModificar
            cargaSalon1.LLenarPanel(idlugar, idzona)
        End Sub

        Private Sub InsertoLugar(ByVal oSalon As Salon) Handles cargaSalon1.Inserto
            UtilLogBase.GuardarEvento(LogBase.TipoLogEvento.Salon, Session("cuenta"), String.Format("Salon CREADO:{0},zona:{1}", oSalon.nombre, oSalon.zona))
            GrillaLugares1.LLenarGrilla(combozona.SelectedValue)
        End Sub

        Private Sub ModificoLugar(ByVal oSalon As Salon) Handles cargaSalon1.Modifico
            UtilLogBase.GuardarEvento(LogBase.TipoLogEvento.Salon, Session("cuenta"), String.Format("Salon MODIFICADO:id:{0} nombre:{1}, zona:{2}", oSalon.id, oSalon.nombre, oSalon.zona))
            GrillaLugares1.LLenarGrilla(combozona.SelectedValue)
        End Sub

        Private Sub BorroLugar(ByVal id As Integer, ByVal zona As Integer) Handles GrillaLugares1.BorroItem
            UtilLogBase.GuardarEvento(LogBase.TipoLogEvento.Salon, Session("cuenta"), String.Format("Salon BORRADO:id:{0} ", id))
            GrillaLugares1.LLenarGrilla(combozona.SelectedValue)
        End Sub
#End Region


    End Class
End Namespace
