
Partial Class aplicacion_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim GestorPedidos As New BLLPedido()
        Dim ListaPedidos As List(Of Pedido) = GestorPedidos.ListarPedido(0, 0, 0, False)

        If ListaPedidos.Count > 0 Then
            ListaPedidos = ListaPedidos.OrderByDescending(Function(x) x.ID).ToList()
        End If

        'lnkPedidos.Text = ListaPedidos.Count
        lblPedidos.Text = ListaPedidos.Count
        Lista.DataSource = ListaPedidos
        Lista.DataBind()

        'lblPedidos.Text = GestorPedidos.ListarPedido(0, 0, 0).Count
        'Dim GestorServicios As New BLLServicio
        'Dim listaServicios As New List(Of Servicio)
        'listaServicios = GestorServicios.ListarServicios(0, 0, 0)
        'If listaServicios IsNot Nothing Then
        '    lblServicios.Text = listaServicios.Count
        'End If


        Dim GestorProductos As New BLLProducto
        Dim listaProductos As New List(Of Productos)
        listaProductos = GestorProductos.ListarProducto(0, 0, 0, "")
        If listaProductos IsNot Nothing Then
            lblProductos.Text = listaProductos.Count
        End If

        Dim GestorClientes As New BLLCliente
        Dim ListaCLientes As New List(Of Cliente)
        ListaCLientes = GestorClientes.ListarClientes("")
        lblClientes.Text = ListaCLientes.Count

        Dim GestorComentarios As New BLLComentario()
        Dim ListaComentarios As New List(Of Comentarios)
        ListaComentarios = GestorComentarios.ListarComentarios(0)


        If ListaComentarios.Count > 0 Then
            'ListaComentarios = ListaComentarios.OrderByDescending(Function(x) x.Fecha)
            Dim UnComentario As New Comentarios
            UnComentario = ListaComentarios.Last
            hlComentarios.NavigateUrl = String.Format("catalogo/Comentarios.aspx?ProductoID={0}", UnComentario.ProductoID)
            Dim Dias As Long = DateDiff(DateInterval.Day, UnComentario.Fecha, Now)
            Dim minutos As Long = DateDiff(DateInterval.Minute, UnComentario.Fecha, Now)

            Dim Diferencia As String = ""

            If Dias > 1 Then
                Diferencia = String.Format("Hace {0} dias.", Dias)
            Else
                If minutos > 60 Then
                    Diferencia = String.Format("Hace {0} horas.", Math.Truncate(minutos / 60))
                Else
                    Diferencia = String.Format("Hace {0} minutos.", Math.Truncate(minutos))
                End If
            End If

            lblComentarios.Text = Diferencia
        End If

        Dim ListaInsumos As New List(Of Insumo)

        Dim GestorInsumos As New BLLInsumo
        ListaInsumos = GestorInsumos.ListarInsumos(0, 0)

        If ListaInsumos.Count > 0 Then
            lblInsumos.Text = ListaInsumos.Count
        End If

        Dim GestorOrdenes As New BLLorden
        Dim ListaOrdenes As New List(Of OrdenCompra)
        ListaOrdenes = GestorOrdenes.ListarOrdenes(0, 0, 0, False)
        lblOrdenes.Text = ListaOrdenes.Count

        Dim GestorAbastecimiento As New BLLReposicion
        Dim ListaAbastecimiento As New List(Of Reposicion)
        ListaAbastecimiento = GestorAbastecimiento.ListarReposicion(0, 0, False)
        lblAbastecimiento.Text = ListaAbastecimiento.Count


        'Dim GestorEncuestas As New BLLEncuesta
        'GestorEncuestas.ListarEncuestas().Count

    End Sub

End Class
