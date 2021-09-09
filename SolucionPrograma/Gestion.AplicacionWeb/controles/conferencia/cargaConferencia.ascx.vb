
Imports Tsu.ProviderOra
Imports Tsu.Utilidades

Partial Class controles_cargaConferencia
    Inherits System.Web.UI.UserControl

    Public Event CanceloCargaConferencia()
    Public Event InsertoConferencia(ByVal oConferencia As conferencia)
    Public Event ModificoConferencia(ByVal oConferencia As conferencia)

#Region "propiedades"
    Private _zona As Integer
    Public Property zona() As Integer
        Get
            Return _zona
        End Get
        Set(ByVal value As Integer)
            _zona = value
        End Set
    End Property

    Private _campania As Integer
    Public Property campania() As Integer
        Get
            Return _campania
        End Get
        Set(ByVal value As Integer)
            _campania = value
        End Set
    End Property

    Private _anio As Integer
    Public Property anio() As Integer
        Get
            Return _anio
        End Get
        Set(ByVal value As Integer)
            _anio = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LLenarComboActividad()
        End If
        AutoCompleteExtender1.ContextKey = zona
    End Sub

#Region "Botones"
    'crea uno nuevo
    Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar.Click
        If HttpContext.Current.User.IsInRole("R") Or HttpContext.Current.User.IsInRole("C") Or HttpContext.Current.User.IsInRole("P") Then
            Throw New Exception("Usuario no tiene permiso para editar")
        End If

        If Page.IsValid Then
            Try
                If hNombreSalon.Value.ToString() = tbSalon.Text Then
                    Dim oConferenciaMap As New ConferenciaMapOra()
                    Dim oConferencia As conferencia = LLenarObjeto()
                    oConferenciaMap.CrearConferencia(oConferencia)
                    RaiseEvent InsertoConferencia(oConferencia)
                    VaciarPanel()
                Else
                    PanelLugarNoExiste.Visible = True
                End If
            Catch ex As MapExceptionControlada
                lblMensaje.Text = "El evento cargado ya existe, por favor revisar los datos cargados"
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Session("cuenta"), String.Format("ERROR CREAR CONFERENCIA: zona:{0} campania:{1} año:{2} error:{3}", zona, campania, anio, ex.Message.ToString()))
            End Try
        End If


    End Sub

    'modifica
    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAceptar.Click
        If HttpContext.Current.User.IsInRole("R") Or HttpContext.Current.User.IsInRole("C") Or HttpContext.Current.User.IsInRole("P") Then
            Throw New Exception("Usuario no tiene permiso para editar")
        End If

        If Page.IsValid Then
            Try
                If hNombreSalon.Value.ToString() = tbSalon.Text Then
                    Dim oConferenciaMap As New ConferenciaMapOra()
                    Dim oConferencia As conferencia = LLenarObjeto()
                    oConferenciaMap.ModificarConferencia(oConferencia)
                    RaiseEvent ModificoConferencia(oConferencia)
                    btnConfirmar.Visible = True
                    btnAceptar.Visible = False
                    btnCancelar.Visible = False
                    VaciarPanel()
                Else
                    PanelLugarNoExiste.Visible = True
                End If
            Catch ex As MapExceptionControlada
                lblMensaje.Text = "El evento cargado ya existe, por favor revisar los datos cargados"
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Session("cuenta"), String.Format("ERROR ACTUALIZACION CONFERENCIA: zona:{0} campania:{1} año:{2} error:{3}", zona, campania, anio, ex.Message.ToString()))
            End Try
        End If
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        btnConfirmar.Visible = True
        btnAceptar.Visible = False
        btnCancelar.Visible = False
        VaciarPanel()
    End Sub
#End Region

#Region "LLenar Paneles"

    Public Sub LLenarPanel(ByVal id As Integer)
        Try
            VaciarPanel()
            Dim oConferenciaMap As New ConferenciaMapOra()
            Dim oConferencia As conferencia = oConferenciaMap.MostrarConferencia(id)
            tbSalon.Text = oConferencia.salon.nombre
            tbHora.Text = oConferencia.hora.ToString("##:##")
            Dim diaformateado As DateTime = Convert.ToDateTime(oConferencia.fecha.ToString().Insert(4, "-").Insert(7, "-")).ToShortDateString()
            tbFecha.Text = diaformateado.ToShortDateString()
            comboactividad.SelectedValue = oConferencia.actividad
            hCodigoConferencia.Value = oConferencia.id
            hCodigoSalon.Value = oConferencia.salon.id
            hNombreSalon.Value = oConferencia.salon.nombre
            ChkPpal.Checked = oConferencia.principal
            tbObservaciones.Text = Server.HtmlDecode(oConferencia.observaciones)
            btnConfirmar.Visible = False
            btnAceptar.Visible = True
            btnCancelar.Visible = True
        Catch ex As Exception
            Response.Write("error llenar panel:" & ex.Message.ToString())
        End Try

    End Sub

    Public Sub VaciarPanel()
        tbSalon.Text = ""
        tbHora.Text = ""
        tbFecha.Text = ""
        ChkPpal.Checked = False
        tbObservaciones.Text = ""
        PanelLugarNoExiste.Visible = False
    End Sub

#End Region

#Region "Varios"

    Private Sub LLenarComboActividad()
        comboactividad.Items.Add(New ListItem("C", "C"))
        comboactividad.Items.Add(New ListItem("N", "N"))
        comboactividad.Items.Add(New ListItem("P", "P"))
    End Sub

#End Region

#Region "Metodos privados"

    Private Function LLenarObjeto() As conferencia
        Dim oConferencia As New conferencia()
        If hCodigoConferencia.Value <> "" Then
            oConferencia.id = hCodigoConferencia.Value
        End If
        oConferencia.anio = anio
        oConferencia.campania = campania
        oConferencia.zona = zona
        oConferencia.actividad = comboactividad.SelectedValue
        oConferencia.fecha = tbFecha.Text
        oConferencia.hora = tbHora.Text.ToString().Replace(":", "")
        oConferencia.principal = ChkPpal.Checked
        oConferencia.observaciones = Server.HtmlEncode(tbObservaciones.Text)
        oConferencia.salon = New Salon
        oConferencia.salon.id = hCodigoSalon.Value
        Return oConferencia
    End Function

    Protected Sub ValidarFecha(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        Try
            Dim lectura As String = args.Value
            Dim valorfecha As DateTime = DateTime.Parse(lectura)
            If valorfecha < DateTime.Now Then
                CustomValidator1.ErrorMessage = "La fecha que está ingresando es anterior a la fecha de hoy"
                args.IsValid = False
            Else
                args.IsValid = True
            End If

        Catch ex As Exception
            CustomValidator1.ErrorMessage = "Formato de fecha incorrecto"
            args.IsValid = False
        End Try
    End Sub
#End Region

End Class
