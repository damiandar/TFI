Imports Tsu.ProviderOra

Imports Tsu.Utilidades

Namespace Tsu.Paginas
    Partial Class controles_DetalleFolleto
        Inherits System.Web.UI.UserControl

#Region "Campos y Propiedades"

        Public Event Inserto()
        Public Event Modificar()

        Public Property campania() As Integer
            Get
                Return Convert.ToInt32(ViewState("campania"))
            End Get
            Set(ByVal value As Integer)
                ViewState("campania") = value
            End Set
        End Property

        Public Property cuenta() As Integer
            Get
                Return Convert.ToInt32(ViewState("cuenta"))
            End Get
            Set(ByVal value As Integer)
                ViewState("cuenta") = value
            End Set
        End Property

        Public Property zona() As Integer
            Get
                Return Convert.ToInt32(ViewState("zona"))
            End Get
            Set(ByVal value As Integer)
                ViewState("zona") = value
            End Set
        End Property

        Public Property grupo() As Integer
            Get
                Return Convert.ToInt32(ViewState("grupo"))
            End Get
            Set(ByVal value As Integer)
                ViewState("grupo") = value
            End Set
        End Property

        Public Property cuentacarga() As Integer
            Get
                Return Convert.ToInt32(ViewState("cuentacarga"))
            End Get
            Set(ByVal value As Integer)
                ViewState("cuentacarga") = value
            End Set
        End Property

        Public Property cantidadingresos() As Integer
            Get
                Return Convert.ToInt32(ViewState("cantidadingresos"))
            End Get
            Set(ByVal value As Integer)
                ViewState("cantidadingresos") = value
            End Set
        End Property


#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        End Sub

        Public Sub LLenar(ByVal i As Integer)

            Dim oFolletosMapOra As New fachadaFolletos()
            Dim ListaFolletos As List(Of Folletos) = oFolletosMapOra.MostrarFolletos(campania)
            GrillaFolletos.DataSource = ListaFolletos
            GrillaFolletos.DataBind()
            If i = 0 Then
                'editar
                GrillaFolletos.Columns(3).Visible = True
                GrillaFolletos.Columns(4).Visible = False
                btnConfirmar.Visible = True
                btnModificar.Visible = False
                btnCancelar.Visible = True
            Else
                'listar
                GrillaFolletos.Columns(3).Visible = False
                GrillaFolletos.Columns(4).Visible = True
                btnConfirmar.Visible = False
                btnModificar.Visible = True
                btnCancelar.Visible = False
            End If
            AsignarRutaCatalogos(campania)


        End Sub

        


#Region "Formatear Campos de la Grilla"

        Protected Function FormatearDescripcion(ByVal campaniafolleto As Object, ByVal tipo As Object) As String
            Dim fechaFormateada As String = Right(campaniafolleto.ToString(), 2) & "/" & Left(campaniafolleto.ToString(), 4)
            Dim tipoFormateado As String = IIf(tipo.ToString() = "C", "Belleza", "Hogar")
            'lblPrecio.Text = String.Format("{0:c}", folleto.precio)
            'Return String.Format(descripcion, CampaniaFormateada, "BELLEZA ")
            Return tipoFormateado.ToString() + " C." + fechaFormateada
        End Function

        Protected Function FormatearCantidad(ByVal Codigo As Integer) As String
            Dim oPedidosDMapOra As New PedidosDMapOra()
            Dim oPedidosDInicial As PedidosD = InicializarItem()
            oPedidosDInicial.codigoproducto = Codigo

            Dim oPedidosD As PedidosD = oPedidosDMapOra.MostrarItemPedidoD(oPedidosDInicial, 1)
            If oPedidosD IsNot Nothing Then
                '13/2/2013 mbruno, agregué el if porque no quieren que se vea cero cuando se elimina, sino vacío.
                If oPedidosD.cantidadsolicitada = 0 Then
                    Return ""
                Else
                    Return oPedidosD.cantidadsolicitada.ToString()
                End If
            Else
                Return ""
            End If
        End Function

#End Region

#Region "Inicializar Valores"

        Private Function InicializarItem() As PedidosD
            Dim oPedidoD As New PedidosD(Detalle.operacion.venta)
            oPedidoD.campania = campania
            oPedidoD.cuenta = cuenta
            oPedidoD.cuentacarga = cuentacarga
            oPedidoD.zona = zona
            oPedidoD.tipousuario = DevuelveUsuario()
            oPedidoD.grupo = grupo
            oPedidoD.tipocr = " "
            oPedidoD.tiponc = " "
            Return oPedidoD
        End Function

        Private Function LLenarObjetoCabecera() As PedidosC
            Dim oPedidosC As New PedidosC()
            oPedidosC.cuenta = cuenta
            oPedidosC.campania = campania
            oPedidosC.cantidadingresos = cantidadingresos
            Return oPedidosC
        End Function

#End Region

#Region "Botones"

        Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnModificar.Click
            If Page.IsValid Then
                RaiseEvent Modificar()
            End If
        End Sub

        Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar.Click
            If Page.IsValid Then
                Try
                    For Each fila As GridViewRow In GrillaFolletos.Rows
                        Dim tbCantidad As New TextBox
                        tbCantidad = CType(fila.FindControl("tbCantidad"), TextBox)
                        Dim cantidad As Object = tbCantidad.Text

                        Dim lblCodigo As New Label
                        lblCodigo = CType(fila.FindControl("lblCodigo"), Label)
                        Dim codigo As Object = lblCodigo.Text

                        Dim oPedidosD As PedidosD = InicializarItem()
                        If Trim(cantidad.ToString()) = "" Then
                            oPedidosD.cantidadsolicitada = 0
                        Else
                            oPedidosD.cantidadsolicitada = Convert.ToInt32(cantidad)
                        End If
                        oPedidosD.codigoproducto = codigo
                        InsertarCatalogo(oPedidosD)
                    Next
                    RaiseEvent Inserto()
                Catch ex As Exception
                    UtilLogBase.Guardar(LogBase.TipoLog.DatoIncorrecto, cuenta, "DetalleFolleto/confirmar:" & ex.Message.ToString())
                End Try

            End If
        End Sub

        Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
            RaiseEvent Inserto()
        End Sub

#End Region

#Region "Metodos Privados"

        Private Function DevuelveUsuario() As String
            Dim retorno As String = "R"
            If HttpContext.Current.User.IsInRole("R") Then
                retorno = "R"
            ElseIf HttpContext.Current.User.IsInRole("G") Then
                retorno = "G"
            ElseIf HttpContext.Current.User.IsInRole("V") Then
                retorno = "V"
            ElseIf HttpContext.Current.User.IsInRole("U") Then
                retorno = "U"
            ElseIf HttpContext.Current.User.IsInRole("P") Then
                retorno = "P"
            ElseIf HttpContext.Current.User.IsInRole("C") Then
                retorno = "C"
            End If
            Return retorno
        End Function

        Private Sub InsertarCatalogo(ByVal oCatalogo As PedidosD)
            Try
                Dim oPedidosDMapOra As New PedidosDMapOra()
                Dim oPedidoD As PedidosD = oPedidosDMapOra.MostrarItemPedidoD(oCatalogo, 1)
                If oPedidoD Is Nothing Then
                    If oCatalogo.cantidadsolicitada <> 0 Then
                        oPedidosDMapOra.InsertaItem(oCatalogo)
                        ActualizarCabeceraPedidos(LLenarObjetoCabecera())
                    End If
                Else
                    'reemplazo la cantidad si es distinta
                    If oCatalogo.cantidadsolicitada <> oPedidoD.cantidadsolicitada Then
                        oPedidosDMapOra.UpdateItemReemplaza(oCatalogo)
                        ActualizarCabeceraPedidos(LLenarObjetoCabecera())
                    End If
                End If
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.DatoIncorrecto, cuenta, "DetalleFolleto/InsertarCatalogo:" & ex.Message.ToString())
            End Try

        End Sub

        Private Sub ActualizarCabeceraPedidos(ByVal oPedidosC As PedidosC)
            Try
                Dim oPedidosCMap As New PedidosCMapOra()
                Dim oPedidosCRetorno As PedidosC = oPedidosCMap.cabeceraCabPedidos(oPedidosC)
                'NumeroPedido1.MostrarNumeroPedido(oPedidosCRetorno)
            Catch ex As Exception
                Throw New Exception("DetalleFolleto/ActualizarCabeceraPedidos: " & ex.Message.ToString())
            End Try
        End Sub

        Private Sub AsignarRutaCatalogos(ByVal campania As Integer)
            Me.ImagenPromocion.ImageUrl = String.Format(" ", campania)
        End Sub


#End Region

    End Class

End Namespace