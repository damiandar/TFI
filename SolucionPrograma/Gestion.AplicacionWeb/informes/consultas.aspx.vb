
Imports Tsu.ProviderOra
Imports Tsu.Utilidades
Imports Tsu.Seguridad

Namespace Tsu.Paginas

    Partial Class administracion_consultas
        Inherits System.Web.UI.Page


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                If Session("revendedora") > 0 Then
                    Dim oUsuarioMap As New UsuarioMapOra()
                    Dim oUsuario As Usuarios = oUsuarioMap.MostrarCabecera(Convert.ToInt32(Session("revendedora")))
                    If oUsuario IsNot Nothing Then
                        Me.panelrevendedora.Visible = True
                        LLenarCombo(oUsuario.zona)
                        cabeceraRevendedora1.campania = ddlHistCampania.SelectedValue
                        cabeceraRevendedora1.llenarDatos(oUsuario)

                        GrillaConsulta1.LLenar(oUsuario.cuenta, ddlHistCampania.SelectedValue)

                    End If
                Else
                    Response.Redirect("~/gestionzona/seleccionarevendedora.aspx?ruta=" + Me.AppRelativeVirtualPath.ToString())
                End If
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Convert.ToInt32(Session("cuenta")), "Adm/Consultas/Load:" & ex.Message.ToString())
            End Try

        End Sub

        Protected Sub ddlHistCampania_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHistCampania.Load
            TextoPretendencia()
        End Sub

        Protected Sub ddlHistCampania_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHistCampania.SelectedIndexChanged
            TextoPretendencia()
        End Sub

        Private Sub TextoPretendencia()
            If ddlHistCampania.Text = Session("campaniarevendedora") Then
                lblmensaje.visible = True
            Else
                lblmensaje.visible = False
            End If
        End Sub

        Private Sub LLenarCombo(ByVal iZona As Integer)
            Try
                If Not Page.IsPostBack Then
                    'le asigno la campania a la revendedora
                    Dim ocalendarioMap As New CalendarioMapOra()
                    Dim listaCalendario As Calendario = ocalendarioMap.MostrarCampaniaCarga(iZona)
                    Dim ListaCalendarioAnterior As List(Of Calendario) = ocalendarioMap.MostrarCampaniaAnterior(iZona)
                    Session("campaniarevendedora") = listaCalendario.campania
                    Dim bPedidoCerrado As Boolean = New HistPedidosCMapOra().PedidoCerrado(Convert.ToInt32(Session("revendedora")), listaCalendario.campania)
                    'cabeceraRevendedora1.llenardomicilio(Convert.ToInt32(ViewState("zonaRevendedora")), Session("revendedora"), Convert.ToInt32(ViewState("campaniaseleccionada")))

                    If bPedidoCerrado Then
                        ddlHistCampania.Items.Add(New ListItem(listaCalendario.campania.ToString().Insert(4, "-"), Convert.ToInt32(listaCalendario.campania)))
                        ddlHistCampania.Items.Add(New ListItem(ListaCalendarioAnterior.Item(0).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(0).campania)))
                        ddlHistCampania.Items.Add(New ListItem(ListaCalendarioAnterior.Item(1).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(1).campania)))
                        ddlHistCampania.Items.Add(New ListItem(ListaCalendarioAnterior.Item(2).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(2).campania)))
                        ddlHistCampania.Items.Add(New ListItem(ListaCalendarioAnterior.Item(3).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(3).campania)))
                        ddlHistCampania.Items.Add(New ListItem(ListaCalendarioAnterior.Item(4).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(4).campania)))
                    Else
                        'ddlHistCampania.Items.Add(New ListItem(Session("campania") - 2, Convert.ToInt32(Session("campania") - 2)))
                        ddlHistCampania.Items.Add(New ListItem(ListaCalendarioAnterior.Item(0).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(0).campania)))
                        ddlHistCampania.Items.Add(New ListItem(ListaCalendarioAnterior.Item(1).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(1).campania)))
                        ddlHistCampania.Items.Add(New ListItem(ListaCalendarioAnterior.Item(2).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(2).campania)))
                        ddlHistCampania.Items.Add(New ListItem(ListaCalendarioAnterior.Item(3).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(3).campania)))
                        ddlHistCampania.Items.Add(New ListItem(ListaCalendarioAnterior.Item(4).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(4).campania)))
                        ddlHistCampania.Items.Add(New ListItem(ListaCalendarioAnterior.Item(5).campania.ToString().Insert(4, "-"), Convert.ToInt32(ListaCalendarioAnterior.Item(5).campania)))
                    End If
                End If
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Convert.ToInt32(Session("cuenta")), "Adm/Consultas/LLenarCombos:" & ex.Message.ToString())
            End Try

        End Sub

    End Class

End Namespace