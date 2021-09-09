Imports Tsu.ProviderOra

Imports Tsu.Utilidades

Partial Class controles_detallepedidos
    Inherits System.Web.UI.UserControl

#Region "Campos y Propiedades"

    Enum busqueda
        Ventas = 1
        CambiosyReclamos = 2
        NotaCredito = 3
        Premios = 4
        'SinTipo = 5
        'Encuestas = 6
    End Enum

    Public Event SeActualizo()
    Public Event CargaMasiva()

    Dim _tipo As busqueda
    Dim _campaniaseleccionada As Integer
    Dim _zona As Integer
    Dim _cuenta As Integer
    Dim _cuentacarga As Integer

    Dim _cantidadingresos As Integer
    Dim _grupo As Integer
    Dim _tipousuario As String

    Public Property campaniaseleccionada() As Integer
        Get
            Return _campaniaseleccionada
        End Get
        Set(ByVal value As Integer)
            _campaniaseleccionada = value
        End Set
    End Property

    Public Property zona() As Integer
        Get
            Return _zona
        End Get
        Set(ByVal value As Integer)
            _zona = value
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

    Public Property cuentacarga() As Integer
        Get
            Return _cuentacarga
        End Get
        Set(ByVal value As Integer)
            _cuentacarga = value
        End Set
    End Property

    Public Property tipo() As busqueda
        Get
            Return _tipo
        End Get
        Set(ByVal value As busqueda)
            _tipo = value
        End Set
    End Property

    Public Property cantidadingresos() As Integer
        Get
            Return _cantidadingresos
        End Get
        Set(ByVal value As Integer)
            _cantidadingresos = value
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

    Public Property tipousuario() As String
        Get
            Return _tipousuario
        End Get
        Set(ByVal value As String)
            _tipousuario = value
        End Set
    End Property

#End Region

#Region "Botones"

    ''' <summary>
    ''' BUSCA EN LA TABLA PRODUCTOS Y TRAE EL PRODUCTO SI LO ENCUENTRA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnaceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnaceptar.Click
        If Page.IsValid Then

            Try
                Dim oProductoMapOra As New ProductosMapOra()
                'VOY A BUSCAR A LA TABLA PRODUCTOS
                Dim listaMostrar As New List(Of VistaConsulta)

                Dim oProducto As Productos = oProductoMapOra.MostrarById(Convert.ToInt32(Me.tbProducto.text), campaniaseleccionada, ProductosMapOra.busqueda.Ventas)
                If oProducto IsNot Nothing Then
                    Dim oVistaConsulta As New VistaConsulta()
                    oVistaConsulta.producto = oProducto
                    oVistaConsulta.cantidadsolicitada = Convert.ToInt32(Me.tbCantidad.Text)
                    ViewState("iCodigo") = oProducto.codigoproducto
                    ViewState("iCantidad") = oVistaConsulta.cantidadsolicitada
                    Me.btnConfirmar.Visible = True
                    Me.btnCancelar.Visible = True
                    Me.tbCantidad.Enabled = False
                    Me.tbProducto.Enabled = False
                    Me.btnaceptar.Visible = False



                    'se agrega a la lista para meterlo al detalle     
                    listaMostrar.Add(oVistaConsulta)
                    VerificarCantidadMaximaIngresada(oVistaConsulta.cantidadsolicitada)

                End If
                ViewState("bRepetido") = False
                ViewState("iCantidadAnterior") = 0
                Me.DetalleProducto.Visible = True
                Me.DetalleProducto.DataSource = listaMostrar
                Me.DetalleProducto.DataBind()
                Me.btnConfirmar.Focus()
            Catch ex As Exception
                'guardar en log
                UtilLogBase.Guardar(LogBase.TipoLog.DatoIncorrecto, cuenta, "DetallePedidos/aceptar:" & ex.Message.ToString())
            End Try

        End If
    End Sub

    ''' <summary>
    ''' SI ESTA EN PEDIDOSD LO PONE COMO REPETIDO SINO LO INSERTA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar.Click
        If Page.IsValid Then

            Try

                Dim oPedidosMapOra As New PedidosDMapOra()
                Dim oPedidosCValidado As PedidosC = LLenarObjetoCabecera()
                ValidacionCabecera(oPedidosCValidado)
                Dim oPedidosDValidado As PedidosD = LLenarObjetoItem()
                ValidacionItem(oPedidosDValidado)

                If Convert.ToBoolean(ViewState("bRepetido")) Then
                    'es repetido entonces actualizo
                    oPedidosMapOra.UpdateItem(oPedidosDValidado)
                    ViewState("bRepetido") = False
                    ActualizarCabeceraPedidos(oPedidosCValidado)
                    limpiar()
                    RaiseEvent SeActualizo()
                Else
                    'trato de insertar
                    ViewState("bRepetido") = oPedidosMapOra.InsertaItem(oPedidosDValidado)

                    If Convert.ToBoolean(ViewState("bRepetido")) = False Then
                        ViewState("iCantidadAnterior") = 0
                        ActualizarCabeceraPedidos(oPedidosCValidado)
                        RaiseEvent SeActualizo()
                    End If

                End If


                If Convert.ToBoolean(ViewState("bRepetido")) Then

                    Dim listapedidos As New List(Of VistaConsulta)
                    'lo voy a buscar a PEDIDOSD
                    Dim oVistaConsulta As VistaConsulta = New fachadaVistaConsulta().MostrarItem(oPedidosDValidado, 1)

                    If oVistaConsulta.cantidadsolicitada = 0 Then
                        'SI LA CANTIDAD ES 0 actualizo directamente
                        oPedidosMapOra.UpdateItem(oPedidosDValidado)
                        ViewState("bRepetido") = False
                        limpiar()
                        ViewState("iCantidadAnterior") = 0
                        ActualizarCabeceraPedidos(oPedidosCValidado)
                        RaiseEvent SeActualizo()
                    Else
                        'SI TENIA CANTIDAD MUESTRO EL MENSAJE
                        Me.lblrepetido.Visible = True
                        listapedidos.Add(oVistaConsulta)
                        Me.DetalleProducto.DataSource = listapedidos
                        Me.DetalleProducto.DataBind()
                        Me.btnConfirmar.Focus()
                        ViewState("iCantidadAnterior") = oVistaConsulta.cantidadsolicitada

                    End If

                Else
                    'Me.ListaProductos.DataBind()
                    'grillaProductos.LLenar()
                    RaiseEvent SeActualizo()
                    Me.limpiar()
                End If

            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.DatoIncorrecto, cuenta, "DetallePedidos/confirmar:" & ex.Message.ToString())
                Response.Redirect("~/Logout.aspx?salir=error")
            End Try

        End If
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        Me.limpiar()
    End Sub

#End Region

#Region "validaciones"

    Private Sub ValidacionItem(ByVal oPedidosD As PedidosD)

        If oPedidosD.zona = 0 Then
            Throw New Exception("Zona=0")
        End If

        If oPedidosD.cuenta = 0 Then
            Throw New Exception("Cuenta=0")
        End If

        If oPedidosD.cuentacarga = 0 Then
            Throw New Exception("CuentaCarga=0")
        End If

        If oPedidosD.campania = 0 Then
            Throw New Exception("Campania=0")
        End If

        If oPedidosD.codigoproducto = 0 Then
            Throw New Exception("CodigoProducto=0")
        End If

        If oPedidosD.cantidadsolicitada < 0 Then
            Throw New Exception("Cantidad solicitada negativa")
        End If

    End Sub

    Private Sub ValidacionCabecera(ByVal oPedidosC As PedidosC)
        If oPedidosC.cuenta = 0 Then
            Throw New Exception("Cuenta=0")
        End If

        If oPedidosC.campania = 0 Then
            Throw New Exception("Campania=0")
        End If

        If oPedidosC.totalunidades < 0 Then
            Throw New Exception("TotalUnidades negativo")
        End If

    End Sub

#End Region

#Region "LLenar Objetos"
    Private Function LLenarObjetoCabecera() As PedidosC
        Dim oPedidosC As New PedidosC()
        oPedidosC.cuenta = cuenta
        oPedidosC.campania = campaniaseleccionada
        oPedidosC.cantidadingresos = cantidadingresos

        Return oPedidosC
    End Function

    Private Function LLenarObjetoItem() As PedidosD
        Dim oPedidosD As New PedidosD(PedidosD.operacion.venta)
        oPedidosD.zona = zona
        oPedidosD.cuenta = cuenta
        oPedidosD.campania = campaniaseleccionada
        oPedidosD.codigoproducto = Convert.ToInt32(ViewState("iCodigo"))
        oPedidosD.cantidadsolicitada = Convert.ToInt32(ViewState("iCantidad"))
        oPedidosD.tipocr = " "
        oPedidosD.cuentacarga = cuentacarga
        oPedidosD.tipousuario = tipousuario
        oPedidosD.grupo = grupo
        oPedidosD.tiponc = " "
        Return oPedidosD
    End Function
#End Region

    Public Sub limpiar()
        Me.tbCantidad.Text = ""
        Me.tbProducto.text = ""
        Me.tbProducto.Enabled = True
        Me.tbCantidad.Enabled = True
        'Me.tbMotivo.Text = ""
        'iCodigo = 0
        'iCantidad = 0
        ViewState("icodigo") = 0
        ViewState("icantidad") = 0
        Me.btnConfirmar.Visible = False
        Me.btnCancelar.Visible = False
        'Me.PanelSeparador.Visible = False
        Me.panelbusqueda.Visible = True
        Me.DetalleProducto.Visible = False
        Me.lblrepetido.Visible = False
        Me.lblMuchaCantidad.Visible = False
        'Me.ListaProductos.DataBind()
        Me.btnaceptar.Visible = True
        Me.tbProducto.Enfocar()
    End Sub

    Public Sub CargarCampaniaOrigen(ByVal iCampaniaSeleccionada As Integer, ByVal iZona As Integer)

    End Sub

    ''' <summary>
    ''' Se actualiza la cabecera de pedidos y muestra el numero.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ActualizarCabeceraPedidos(ByVal oPedidosC As PedidosC)
        Try
            Dim oPedidosCMap As New PedidosCMapOra()
            Dim oPedidosCRetorno As PedidosC = oPedidosCMap.cabeceraCabPedidos(oPedidosC)

        Catch ex As Exception
            UtilLogBase.Guardar(LogBase.TipoLog.DatoIncorrecto, cuenta, "DetallePedidos/cabecera:" & ex.Message.ToString())
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tbProducto.Enfocar()
        'If HttpContext.Current.User.IsInRole("R") Then
        '    panelCargaMasiva.Visible = False
        'Else
        '    panelCargaMasiva.Visible = True
        'End If
        PanelCargaMasiva.Visible = True


    End Sub

    Protected Sub btnCargaMasiva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargaMasiva.Click
        RaiseEvent CargaMasiva()
    End Sub

    Public Sub MostrarNumeroPedido(ByVal oPedidosC As PedidosC)
        Try

        Catch ex As Exception
            UtilLogBase.Guardar(LogBase.TipoLog.DatoIncorrecto, cuenta, "DetallePedidos/cabecera:" & ex.Message.ToString())
        End Try
    End Sub

    Public Sub VerificarCantidadMaximaIngresada(ByVal CantidadSolicitada As Integer)
        If CantidadSolicitada >= 25 Then
            lblMuchaCantidad.Visible = True
        Else
            lblMuchaCantidad.Visible = False
        End If
    End Sub
End Class
