Imports System.IO
Imports Tsu.ProviderOra



Partial Class controles_GrillaEvolucion
    Inherits System.Web.UI.UserControl


#Region "Campos y propiedades"

    Public Event Ordenamiento(ByVal campo As String, ByVal sentido As String)
    Public Event Exportar(ByVal TipoGrilla As eTipo)
    Dim _grillaexportacion As eTipo
    Dim _zona As Integer
    Dim _campania As Integer
    Dim _grupo As Integer
    Dim _zonaatiende As Integer
    Dim _zonasuplente1 As Integer
    Dim _zonasuplente2 As Integer
    Dim _rol As String
    Dim _ultimacampaniarevendedora As Integer
    Dim _cuenta As Integer
    Dim _general As Boolean

    Public Enum eTipo
        Curso
        Cerrado
        Anulado
        Vacio
    End Enum

    Dim _tipo As eTipo

    Public Property zona() As Integer
        Get
            Return _zona
        End Get
        Set(ByVal value As Integer)
            _zona = value
        End Set
    End Property

    Public Property campania() As Integer
        Get
            Return _campania
        End Get
        Set(ByVal value As Integer)
            _campania = value
        End Set
    End Property

    Public Property grupo() As Integer
        Get
            Return _grupo
        End Get
        Set(ByVal value As Integer)
            _grupo = value
        End Set
    End Property

    Public Property zonaatiende() As Integer
        Get
            Return _zonaatiende
        End Get
        Set(ByVal value As Integer)
            _zonaatiende = value
        End Set
    End Property

    Public Property zonasuplente1() As Integer
        Get
            Return _zonasuplente1
        End Get
        Set(ByVal value As Integer)
            _zonasuplente1 = value
        End Set
    End Property

    Public Property zonasuplente2() As Integer
        Get
            Return _zonasuplente2
        End Get
        Set(ByVal value As Integer)
            _zonasuplente2 = value
        End Set
    End Property

    Public Property rol() As String
        Get
            Return _rol
        End Get
        Set(ByVal value As String)
            _rol = value
        End Set
    End Property

    Public Property ultimacampaniarevendedora() As Integer
        Get
            Return _ultimacampaniarevendedora
        End Get
        Set(ByVal value As Integer)
            _ultimacampaniarevendedora = value
        End Set
    End Property

    Public Property cuenta() As Integer
        Get
            Return _cuenta
        End Get
        Set(ByVal value As Integer)
            _cuenta = value
        End Set
    End Property
    Public Property tipo() As eTipo
        Get
            Return _tipo
        End Get
        Set(ByVal value As eTipo)
            _tipo = value
        End Set
    End Property

    Public Property general() As Boolean
        Get
            Return _general
        End Get
        Set(ByVal value As Boolean)
            _general = value
        End Set
    End Property

    Public Property GrillaExportacion() As eTipo
        Get
            Return _grillaexportacion
        End Get
        Set(ByVal value As eTipo)
            _grillaexportacion = value
        End Set
    End Property

#End Region

#Region "Metodos propios de la grilla"

    Protected Sub Grilla_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles Grilla.RowCommand
        If Not HttpContext.Current.User.IsInRole("C") And Not HttpContext.Current.User.IsInRole("H") Then
            If e.CommandName = "MostrarCuenta" Then
                Dim Lnk As LinkButton = CType(e.CommandSource, LinkButton)
                Dim NroCuenta As Integer = Convert.ToInt32(Lnk.Text)
                Session("revendedoraPasaje") = NroCuenta
                Dim ruta As String = ""
                ruta = "~/gestionzona/seleccionarevendedora.aspx"
                Response.Redirect(ruta)
            End If
        End If
    End Sub

    Protected Sub Grilla_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles Grilla.RowDataBound

        If e.Row.RowType = DataControlRowType.Header Then
            'lo vacio la primera vez
            ViewState("iTotalUnidades") = 0
            ViewState("iTotalPedidos") = 0
        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            'cuento
            ViewState("iTotalUnidades") += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "cantidadunidades"))
            ViewState("iTotalPedidos") += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "cantidadpedidos"))
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            'muestro el total
            Me.SumaUnPP.Text = ViewState("iTotalUnidades").ToString()
            Me.SumaPP.Text = ViewState("iTotalPedidos").ToString()
        ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then
            'si la grilla esta vacia me reinicia el contador a 0
            ViewState("iTotalUnidades") = 0
            Me.SumaUnPP.Text = ViewState("iTotalUnidades").ToString()
            ViewState("iTotalPedidos") = 0
            Me.SumaPP.Text = ViewState("iTotalPedidos").ToString()
        End If
        'comboZona.Items.Add(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "zona")))
    End Sub

    Protected Function llenarMotivo6(ByVal obj As Object) As String
        Dim sRetorno As String = " "
        If obj IsNot Nothing Then
            If Convert.ToInt32(obj) > 0 Then
                sRetorno = "*"
            End If
        End If

        Return sRetorno
    End Function

#End Region

#Region "Click de botones de la grilla"
    Protected WithEvents botonZonaAsc0 As ImageButton
    Protected WithEvents botonZonaDesc0 As ImageButton
    Protected WithEvents botonCampaniaAsc0 As ImageButton
    Protected WithEvents botonCampaniaDesc0 As ImageButton
    Protected WithEvents botonGrupoAsc0 As ImageButton
    Protected WithEvents botonGrupoDesc0 As ImageButton
    Protected WithEvents botonCuentaAsc0 As ImageButton
    Protected WithEvents botonCuentaDesc0 As ImageButton
    Protected WithEvents botonProductosAsc0 As ImageButton
    Protected WithEvents botonProductosDesc0 As ImageButton
    Protected WithEvents botonCambiosAsc0 As ImageButton
    Protected WithEvents botonCambiosDesc0 As ImageButton
    Protected WithEvents botonCambios5Asc0 As ImageButton
    Protected WithEvents botonCambios5Desc0 As ImageButton
    Protected WithEvents botonNCAsc0 As ImageButton
    Protected WithEvents botonNCDesc0 As ImageButton
    Protected WithEvents botonFechaAsc0 As ImageButton
    Protected WithEvents botonFechaDesc0 As ImageButton

    'lista pedidos 0
    Protected Sub btnZonaDesc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonZonaDesc0.Click
        RaiseEvent Ordenamiento("zona", "Descending")
    End Sub
    Protected Sub btnZonaAsc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonZonaAsc0.Click
        RaiseEvent Ordenamiento("zona", "Ascending")
    End Sub
    Protected Sub btnCampaniaDesc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCampaniaDesc0.Click
        RaiseEvent Ordenamiento("campania", "Descending")
    End Sub
    Protected Sub btnCampaniaAsc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCampaniaAsc0.Click
        RaiseEvent Ordenamiento("campania", "Ascending")
    End Sub
    Protected Sub btnGrupoDesc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonGrupoDesc0.Click
        RaiseEvent Ordenamiento("grupo", "Descending")
    End Sub
    Protected Sub btnGrupoAsc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonGrupoAsc0.Click
        RaiseEvent Ordenamiento("grupo", "Ascending")
    End Sub
    Protected Sub btnCuentaDesc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCuentaDesc0.Click
        RaiseEvent Ordenamiento("cuenta", "Descending")
    End Sub
    Protected Sub btnCuentaAsc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCuentaAsc0.Click
        RaiseEvent Ordenamiento("cuenta", "Ascending")
    End Sub
    Protected Sub btnProductosDesc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonProductosDesc0.Click
        RaiseEvent Ordenamiento("cantunidadesPFAV", "Descending")
    End Sub
    Protected Sub btnProductosAsc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonProductosAsc0.Click
        RaiseEvent Ordenamiento("cantunidadesPFAV", "Ascending")
    End Sub
    Protected Sub btnCambiosDesc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCambiosDesc0.Click
        RaiseEvent Ordenamiento("cantunidadesCR", "Descending")
    End Sub
    Protected Sub btnCambiosAsc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCambiosAsc0.Click
        RaiseEvent Ordenamiento("cantunidadesCR", "Ascending")
    End Sub
    Protected Sub btnCambios5Desc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCambios5Desc0.Click
        RaiseEvent Ordenamiento("cantunidadesCR5", "Descending")
    End Sub
    Protected Sub btnCambios5Asc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCambios5Asc0.Click
        RaiseEvent Ordenamiento("cantunidadesCR5", "Ascending")
    End Sub
    Protected Sub btnNCDesc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonNCDesc0.Click
        RaiseEvent Ordenamiento("cantunidadesNC", "Descending")
    End Sub
    Protected Sub btnNCAsc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonNCAsc0.Click
        RaiseEvent Ordenamiento("cantunidadesNC", "Ascending")
    End Sub
    Protected Sub btnFechaAsc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonFechaAsc0.Click
        RaiseEvent Ordenamiento("fechaultimo", "Ascending")
    End Sub
    Protected Sub btnFechaDesc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonFechaDesc0.Click
        RaiseEvent Ordenamiento("fechaultimo", "Descending")
    End Sub
    Protected Sub btnCantidadPedidosDesc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCampaniaDesc0.Click
        RaiseEvent Ordenamiento("cantidadpedidos", "Descending")
    End Sub
    Protected Sub btnCantidadPedidosAsc0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCampaniaAsc0.Click
        RaiseEvent Ordenamiento("cantidadpedidos", "Ascending")
    End Sub

#End Region

#Region "LLamadas al mapper"

    Public Sub LLenarTodasLasZonas(ByVal orden As String, ByVal sentido As String)
        Dim oEvolucionFachada As New fachadaEvolucion()
        Dim ListaEvolucion As New List(Of Evolucion)

        If tipo = eTipo.Curso Then
            ListaEvolucion = oEvolucionFachada.PedidosTodasZonas(zona, grupo, campania)
        ElseIf tipo = eTipo.Cerrado Then
            ListaEvolucion = oEvolucionFachada.HistPedidosTodasLasZonas(ultimacampaniarevendedora, zona, campania, grupo)
        ElseIf tipo = eTipo.Anulado Then
            ListaEvolucion = oEvolucionFachada.AnuladosPedidosTodasLasZonas(ultimacampaniarevendedora, zona, campania, grupo)
        End If

        ListaEvolucion = Me.AplicarFiltros(ListaEvolucion)
        Ordenar(ListaEvolucion, orden, sentido)
        Grilla.DataSource = ListaEvolucion
        Grilla.DataBind()
        Grilla.Columns(4).Visible = False

        If tipo = Me.GrillaExportacion Then
            ExportToExcel(ListaEvolucion, tipo.ToString())
        End If

    End Sub

    Public Sub LLenarZonaGerente(ByVal orden As String, ByVal sentido As String)
        Dim oEvolucionFachada As New fachadaEvolucion()
        Dim ListaEvolucion As New List(Of Evolucion)

        If tipo = eTipo.Curso Then
            ListaEvolucion = oEvolucionFachada.PedidosZonaGerente(zona, zonaatiende, zonasuplente1, zonasuplente2, campania, grupo)
        ElseIf tipo = eTipo.Cerrado Then
            ListaEvolucion = oEvolucionFachada.HistPedidosZonaGerente(zona, zonaatiende, zonasuplente1, zonasuplente2, ultimacampaniarevendedora, campania, grupo)
        ElseIf tipo = eTipo.Anulado Then
            ListaEvolucion = oEvolucionFachada.AnuladosPedidosZonaGerente(zona, zonaatiende, zonasuplente1, zonasuplente2, ultimacampaniarevendedora, campania, grupo)
        End If

        ListaEvolucion = AplicarFiltros(ListaEvolucion)
        Ordenar(ListaEvolucion, orden, sentido)
        Grilla.DataSource = ListaEvolucion
        Grilla.DataBind()
        Grilla.Columns(4).Visible = False
        If tipo = Me.GrillaExportacion Then
            ExportToExcel(ListaEvolucion, tipo.ToString())
        End If
    End Sub

    Public Sub LLenarPorGrupos(ByVal orden As String, ByVal sentido As String)
        Dim oEvolucionFachada As New fachadaEvolucion()
        Dim ListaEvolucion As New List(Of Evolucion)

        If tipo = eTipo.Curso Then
            ListaEvolucion = oEvolucionFachada.PedidosPorGrupo(zona, cuenta, campania, grupo)
        Else
            ListaEvolucion = oEvolucionFachada.HistPedidosPorGrupo(zona, cuenta, ultimacampaniarevendedora, campania, grupo)
        End If

        ListaEvolucion = AplicarFiltros(ListaEvolucion)
        Ordenar(ListaEvolucion, orden, sentido)
        Grilla.DataSource = ListaEvolucion
        Grilla.DataBind()
        Grilla.Columns(4).Visible = False
        Grilla.Columns(9).Visible = False
        Grilla.Columns(10).Visible = False
        If tipo = Me.GrillaExportacion Then
            ExportToExcel(ListaEvolucion, tipo.ToString())
        End If
    End Sub

    Public Sub LLenarGeneral(ByVal orden As String, ByVal sentido As String)
        Dim oEvolucionFachada As New fachadaEvolucion()
        Dim ListaEvolucion As New List(Of Evolucion)

        If tipo = eTipo.Curso Then
            ListaEvolucion = oEvolucionFachada.MostrarPedidosGralAll()
        Else
            ListaEvolucion = oEvolucionFachada.MostrarHistPedidosGralAll(ultimacampaniarevendedora)
        End If

        ListaEvolucion = AplicarFiltros(ListaEvolucion)
        Ordenar(ListaEvolucion, orden, sentido)
        Grilla.DataSource = ListaEvolucion
        Grilla.DataBind()
        Grilla.Columns(2).Visible = False
        Grilla.Columns(3).Visible = False
        Grilla.Columns(9).Visible = False
        Grilla.Columns(10).Visible = False
        Grilla.Columns(11).Visible = False
        If tipo = Me.GrillaExportacion Then
            ExportToExcel(ListaEvolucion, tipo.ToString())
        End If
    End Sub

    Public Sub LLenarGeneralGrupo(ByVal orden As String, ByVal sentido As String)
        Dim oEvolucionFachada As New fachadaEvolucion()
        Dim ListaEvolucion As New List(Of Evolucion)

        If tipo = eTipo.Curso Then
            ListaEvolucion = oEvolucionFachada.MostrarPedidosGralGrupo(zona, zonaatiende, zonasuplente1, zonasuplente2, campania, grupo, 1)
        ElseIf tipo = eTipo.Cerrado Then
            ListaEvolucion = oEvolucionFachada.MostrarHistPedidosGralGrupo(ultimacampaniarevendedora, zona, zonaatiende, zonasuplente1, zonasuplente2, campania, grupo, 2)
        ElseIf tipo = eTipo.Anulado Then
            ListaEvolucion = oEvolucionFachada.MostrarAnuladosPedidosGralGrupo(ultimacampaniarevendedora, zona, zonaatiende, zonasuplente1, zonasuplente2, campania, grupo, 3)
        End If

        ListaEvolucion = AplicarFiltros(ListaEvolucion)
        Ordenar(ListaEvolucion, orden, sentido)
        Grilla.DataSource = ListaEvolucion
        Grilla.DataBind()
        Grilla.Columns(3).Visible = False
        'Grilla.Columns(4).Visible = False
        Grilla.Columns(9).Visible = False
        Grilla.Columns(10).Visible = False
        Grilla.Columns(11).Visible = False
        If tipo = Me.GrillaExportacion Then
            ExportToExcel(ListaEvolucion, tipo.ToString())
        End If
    End Sub

#End Region

#Region "Exportar a Excel"

    Private Sub ExportToExcel(ByVal Lista As List(Of Evolucion), ByVal NombreExcel As String)
        Dim listaOrdenada As List(Of Evolucion) = Lista.OrderBy(Function(x) x.campania).ThenBy(Function(x) x.zona).ThenBy(Function(x) x.grupo).ToList()
        'Ordenar(Lista, "cuenta", "Ascending")

        Dim GrillaExporta As New GridView
        GrillaExporta.AllowPaging = False
        GrillaExporta.DataSource = listaOrdenada
        GrillaExporta.DataBind()

        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=" + NombreExcel + ".xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"

        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)

        'For i As Integer = 0 To GrillaExporta.Rows.Count - 1
        '    'Apply text style to each Row 
        '    GrillaExporta.Rows(i).Attributes.Add("class", "textmode")
        'Next

        GrillaExporta.RenderControl(hw)
        'style to format numbers to string 
        Dim style As String = "<style> .textmode{mso-number-format:\@;}</style>"
        Response.Write(style)
        Response.Output.Write(sw.ToString())
        Response.Flush()
        Response.End()

    End Sub
    Protected Sub btnExportarGrilla_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExportarGrilla.Click
        RaiseEvent Exportar(Me.tipo)
    End Sub
    Protected Function FormatoFecha(ByVal fecha As Object) As String
        FormatoFecha = Right(fecha.ToString(), 2) & "/" & Mid(fecha.ToString(), 5, 2)
    End Function
    Protected Function nombreTipoUsuario(ByVal tipoUsuario As Object) As String
        Select Case tipoUsuario
            Case "R"
                nombreTipoUsuario = "Revendedora"
            Case "C"
                nombreTipoUsuario = "CDG"
            Case "U"
                nombreTipoUsuario = "Asist.Vtas."
            Case "V"
                nombreTipoUsuario = "Dirección Vtas."
            Case "H"
                nombreTipoUsuario = "Revendedora habilitada"
            Case "G"
                nombreTipoUsuario = "GDZ"
            Case "M"
                nombreTipoUsuario = "Mixto: más de una cuenta"
            Case Else
                nombreTipoUsuario = ""
        End Select
    End Function
#End Region

#Region "Filtrado y Ordenamiento"

    Private Sub Ordenar(ByVal listaEvolucion As List(Of Evolucion), ByVal orden As String, ByVal sentido As String)
        If orden <> "" Then
            Dim comp As Comparador(Of Evolucion)

            If sentido = "Descending" Then
                comp = New Comparador(Of Evolucion)(orden, "Descending")
            Else
                comp = New Comparador(Of Evolucion)(orden, "Ascending")
            End If

            listaEvolucion.Sort(AddressOf comp.Compare)
        End If
    End Sub

    Private Function AplicarFiltros(ByVal ListaEvolucion As List(Of Evolucion)) As List(Of Evolucion)
        Dim listaOrdenada As List(Of Evolucion) = ListaEvolucion

        If zona <> 0 Then
            listaOrdenada = listaOrdenada.FindAll(AddressOf BuscarPorZona)
        End If

        If campania <> 0 Then
            listaOrdenada = listaOrdenada.FindAll(AddressOf BuscarPorCampania)
        End If

        If grupo <> 0 Then
            listaOrdenada = listaOrdenada.FindAll(AddressOf BuscarPorGrupo)
        End If
        Return listaOrdenada
    End Function

    Private Function BuscarPorZona(ByVal entrada As Evolucion) As Boolean
        If entrada.zona = zona Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function BuscarPorCampania(ByVal entrada As Evolucion) As Boolean
        If entrada.campania = campania Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function BuscarPorGrupo(ByVal entrada As Evolucion) As Boolean
        If entrada.grupo = grupo Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Select Case tipo
            Case eTipo.Curso
                lblTituloGrilla.Text = "Pedidos en curso"
            Case eTipo.Cerrado
                lblTituloGrilla.Text = "Pedidos cerrados"
            Case eTipo.Anulado
                lblTituloGrilla.Text = "Pedidos anulados"
        End Select

        If HttpContext.Current.User.IsInRole("C") Then
            Me.btnExportarGrilla.Visible = False
        End If
    End Sub

End Class
