
Imports Tsu.ProviderOra

Partial Class controles_Control_ddlCampaniaOrigen
    Inherits System.Web.UI.UserControl

    Public Event TextChanged()
    Public Event SelectedIndexChanged()

    Protected Sub ddlCampaniaOrigen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCampaniaOrigen.SelectedIndexChanged
        RaiseEvent SelectedIndexChanged()
    End Sub

    Protected Sub ddlCampaniaOrigen_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCampaniaOrigen.TextChanged
        RaiseEvent TextChanged()
    End Sub

    Public Property SelectedValue() As String
        Get
            Return ddlCampaniaOrigen.SelectedValue
        End Get
        Set(ByVal value As String)
            ddlCampaniaOrigen.SelectedValue = value
        End Set
    End Property

    Public Sub CargarCampaniaOrigen(ByVal iCampaniaSeleccionada As Integer, ByVal iZona As Integer)
        Dim ocalendarioMap As New CalendarioMapOra()
        Dim ListaCalendarioAnterior As List(Of Calendario) = ocalendarioMap.MostrarCampaniaAnterior(iZona)
        ddlCampaniaOrigen.Items.Clear()


        Dim campaniadelalista As Integer = ListaCalendarioAnterior.Item(0).campania
        If campaniadelalista = iCampaniaSeleccionada Then
            ddlCampaniaOrigen.Items.Add(New ListItem(ListaCalendarioAnterior.Item(1).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(1).campania)))
            ddlCampaniaOrigen.Items.Add(New ListItem(ListaCalendarioAnterior.Item(2).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(2).campania)))
        Else
            ddlCampaniaOrigen.Items.Add(New ListItem(ListaCalendarioAnterior.Item(0).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(0).campania)))
            ddlCampaniaOrigen.Items.Add(New ListItem(ListaCalendarioAnterior.Item(1).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(1).campania)))
        End If
    End Sub

End Class
