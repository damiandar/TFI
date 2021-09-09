Imports Tsu.ProviderOra


Partial Class controles_GrillaConsulta
    Inherits System.Web.UI.UserControl

#Region "campos y propiedades"

    Private _cuenta As Integer
    Public Property cuenta() As Integer
        Get
            Return _cuenta
        End Get
        Set(ByVal value As Integer)
            _cuenta = value
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

    Enum eTipo
        Pedidos = 1
        CyR = 2
        NC = 3
        Premios = 4
    End Enum

    Dim _tipo As eTipo

    Public Property tipo() As eTipo
        Get
            Return _tipo
        End Get
        Set(ByVal value As eTipo)
            _tipo = value
        End Set
    End Property

    Private _micarga As Boolean
    ''' <summary>
    ''' Indica si la consulta es de mi propia cuenta
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property micarga() As Boolean
        Get
            Return _micarga
        End Get
        Set(ByVal value As Boolean)
            _micarga = value
        End Set
    End Property

    Dim cantidad As Integer

#End Region

#Region "Eventos de las grillas"
    Protected Function ContarGrilla(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) As String
        Dim valor As String = ""
        Dim sRetorno As String = ""
        valor = "iTotalUnidades"
        If e.Row.RowType = DataControlRowType.DataRow Then
            'cuento
            cantidad += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "cantidadsolicitada"))
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            'muestro el total
            sRetorno = cantidad.ToString()
        ElseIf e.Row.RowType = DataControlRowType.Header Then
            'lo vacio la primera vez
            cantidad = 0
        ElseIf e.Row.RowType = DataControlRowType.EmptyDataRow Then
            'si la grilla esta vacia me reinicia el contador a 0
            cantidad = 0
            sRetorno = cantidad.ToString()
        End If
        Return sRetorno
    End Function

    Protected Sub ListaProductos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles ListaPedidos.RowDataBound
        Summary.Text = ContarGrilla(e)
    End Sub

    Private Sub FormatearGrilla()
        If tipo = eTipo.Pedidos Then
            lblTitulo.Text = "Catálogos, Productos y auxiliares"
            ListaPedidos.Columns(0).Visible = False 'columna campania
            ListaPedidos.Columns(2).Visible = False 'columna motivo
            ListaPedidos.Columns(3).Visible = False 'columna cantidad
            ListaPedidos.Columns(4).Visible = False 'columna tipo
            ListaPedidos.Columns(10).Visible = False 'columna producto facturado
        ElseIf tipo = eTipo.CyR Then
            lblTitulo.Text = "Cambios y reclamos"
            ListaPedidos.Columns(0).Visible = False 'columna campania
            ListaPedidos.Columns(4).Visible = False 'columna tipo
            ListaPedidos.Columns(6).Visible = False 'columna cant
            ListaPedidos.Columns(7).Visible = False 'columna precio
            ListaPedidos.Columns(8).Visible = False 'columna folleto
            ListaPedidos.Columns(9).Visible = False 'columna pagina
        ElseIf tipo = eTipo.NC Then
            lblTitulo.Text = "Notas de Crédito"
            ListaPedidos.Columns(6).Visible = False 'columna cant
            ListaPedidos.Columns(7).Visible = False 'columna precio
            ListaPedidos.Columns(8).Visible = False 'columna folleto
            ListaPedidos.Columns(9).Visible = False 'columna pagina
            ListaPedidos.Columns(10).Visible = False 'columna producto facturado

        ElseIf tipo = eTipo.Premios Then
            lblTitulo.Text = "Premios"
            ListaPedidos.Columns(0).Visible = False 'columna campania
            ListaPedidos.Columns(2).Visible = False 'columna motivo
            ListaPedidos.Columns(3).Visible = False 'columna cantidad
            ListaPedidos.Columns(4).Visible = False 'columna tipo
            ListaPedidos.Columns(7).Visible = False 'columna precio
            ListaPedidos.Columns(9).Visible = False 'columna pagina
            ListaPedidos.Columns(10).Visible = False 'columna producto facturado
        End If

    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormatearGrilla()
    End Sub

    Protected Function FormatoFecha(ByVal fecha As Object) As String
        FormatoFecha = Right(fecha.ToString(), 2) & "/" & Mid(fecha.ToString(), 5, 2)
    End Function

#Region "Metodos Publicos"
    Public Sub LLenar(ByVal iCuenta As Integer, ByVal iCampania As Integer)
        Try
            Summary.Text = "0"
            Dim Mapfachada As New fachadaVistaConsulta
            Dim comp As Comparador(Of VistaConsulta)
            comp = New Comparador(Of VistaConsulta)("fechaultimo", "Descending")
            Dim listaFachada As List(Of VistaConsulta) = Mapfachada.MostrarHistPedidoCompra(iCuenta, iCampania, tipo)
            listaFachada.Sort(AddressOf comp.Compare)
            Me.ListaPedidos.DataSource = listaFachada
            Me.ListaPedidos.DataBind()
            If HttpContext.Current.User.IsInRole("G") Or HttpContext.Current.User.IsInRole("V") Or HttpContext.Current.User.IsInRole("U") Then
                ListaPedidos.Columns(14).Visible = True  'columna usuario carga
            Else
                ListaPedidos.Columns(14).Visible = False 'columna usuario carga
            End If

            If micarga = True Then
                ListaPedidos.Columns(13).Visible = False  'columna fecha
                ListaPedidos.Columns(14).Visible = False  'columna usuario carga
            End If
        Catch ex As Exception
            Throw New Exception("ControlGrillaConsulta/LLenar:" & ex.Message.ToString())
        End Try
    End Sub
    Public Sub LLenarPendientes(ByVal iCuenta As Integer, ByVal iCampania As Integer)
        Try
            Summary.Text = "0"
            Dim mapfachada As New fachadaVistaConsulta
            Me.ListaPedidos.DataSource = mapfachada.MostrarPedidoCompra(iCuenta, iCampania, tipo, "")
            Me.ListaPedidos.DataBind()
        Catch ex As Exception
            Throw New Exception("ControlGrillaConsulta/LLenarPendientes:" & ex.Message.ToString())
        End Try

    End Sub
    Public Sub LLenarAnulados(ByVal iCuenta As Integer, ByVal iCampania As Integer)
        Try
            Summary.Text = "0"
            Dim Mapfachada As New fachadaVistaConsulta
            Dim listaFachada As List(Of VistaConsulta) = Mapfachada.MostrarAnuladoPedidoCompra(iCuenta, iCampania, tipo)
            Me.ListaPedidos.DataSource = listaFachada
            Me.ListaPedidos.DataBind()
        Catch ex As Exception
            Throw New Exception("ControlGrillaConsulta/LLenarAnulados:" & ex.Message.ToString())
        End Try

    End Sub
#End Region

End Class
