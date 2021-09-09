
Partial Class carrito_FormaPago
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If CInt(Session("pedido")) > 0 And CInt(Session("pedido")) = CInt(Request.QueryString("id")) Then
                rbCuentaCorriente.Checked = True
            Else
                Response.Redirect("default.aspx")
            End If
            lnkVolver.PostBackUrl = String.Format("FormaEnvio.aspx?id={0}", Session("pedido"))
            LLenarComboAnio()
            LLenarComboMes()
        End If
    End Sub

    Protected Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Dim GestorPedidos As New BLLPedido()
        Dim UnPedido As Pedido = GestorPedidos.MostrarPedido(Session("pedido"), False)
        UnPedido.formapago = New FormaPago()

        Dim validar As Boolean = False
        Dim mensaje As String = ""

        If rbCuentaCorriente.Checked Then
            UnPedido.formapago.ID = 1
            validar = True
        ElseIf rbPagoEfectivo.Checked Then
            UnPedido.formapago.ID = 2
            validar = True
        ElseIf rbTarjetaCredito.Checked Then
            UnPedido.formapago.ID = 4

            Dim Fecha As Integer = ValidarFecha(comboAnioVencimiento.SelectedValue, comboMesVencimiento.SelectedValue)
            If Fecha > 0 Then
                Dim objNum As New Object
                objNum = tbNumero.Text.Replace("-", "")

                If IsNumeric(objNum) And IsNumeric(tbCodigoSeguridad.Text) Then
                    Dim UnaTarjeta As New Tarjeta
                    UnaTarjeta.Nro = CDbl(objNum)
                    UnaTarjeta.Clave = CInt(tbCodigoSeguridad.Text)
                    UnaTarjeta.FechaVencimiento = Fecha
                    UnaTarjeta.Titular = tbTitular.Text
                    UnaTarjeta.Empresa = comboTarjeta.SelectedValue
                    validar = ValidarTarjeta(mensaje, UnaTarjeta)
                Else
                    'no es numerico
                    PanelAlerta.Visible = True
                    lblMensaje.Text = "Verifique que los campos NRO y Código sean numericos."
                End If

            Else
                'Verifique la fecha
                PanelAlerta.Visible = True
                lblMensaje.Text = "La fecha de vencimiento no corresponde."
            End If

        End If

        If validar = True Then
            GestorPedidos.ModificarPedido(UnPedido)
            Response.Redirect(String.Format("Confirmacion.aspx?id={0}", Session("pedido")), True)
        Else
            PanelAlerta.Visible = True
            lblMensaje.Text = "Error al confirmar el pago."
        End If
    End Sub

#Region "Radio Button"

    Protected Sub rbTarjetaCredito_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbTarjetaCredito.CheckedChanged
        PanelTarjetaCredito.Visible = True
    End Sub

    Protected Sub rbCuentaCorriente_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbCuentaCorriente.CheckedChanged
        PanelTarjetaCredito.Visible = False
    End Sub

    Protected Sub rbPagoEfectivo_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbPagoEfectivo.CheckedChanged
        PanelTarjetaCredito.Visible = False
    End Sub



#End Region

    Private Function ValidarFecha(ByVal anioVencimiento As Integer, ByVal mesVencimiento As Integer) As Integer
        Dim Fecha As Integer = 0

        Dim anioActual As Integer = Now.Year
        Dim mesActual As Integer = Now.Month
        If anioVencimiento >= anioActual Then
            Fecha = (anioVencimiento * 100) + mesVencimiento
            If anioVencimiento = anioActual And mesVencimiento < mesActual Then
                Fecha = 0
            End If
        End If
        Return Fecha
    End Function

    Private Function ValidarTarjeta(ByRef Mensaje As String, ByVal UnaTarjeta As Tarjeta) As Boolean
        Dim ListaTarjetas As New List(Of Tarjeta)
        ListaTarjetas.Add(New Tarjeta(Tarjeta.eTipoTarjeta.Master, "6666888822221111", "Damian Rosso", 3028, 201710))
        ListaTarjetas.Add(New Tarjeta(Tarjeta.eTipoTarjeta.Visa, "2222333344445555", "Damian Rosso", 3028, 201710))
        ListaTarjetas.Add(New Tarjeta(Tarjeta.eTipoTarjeta.AMEX, "9999777788881234", "Damian Rosso", 3028, 201710))
        Dim Validar As Boolean = False
        'And x.Empresa = UnaTarjeta.Empresa And x.Titular = UnaTarjeta.Titular And x.FechaVencimiento = UnaTarjeta.FechaVencimiento
        Dim TarjetaEnLista As Tarjeta = ListaTarjetas.Find(Function(x) x.Nro = UnaTarjeta.Nro)
        If TarjetaEnLista IsNot Nothing Then
            If TarjetaEnLista.FechaVencimiento = UnaTarjeta.FechaVencimiento And TarjetaEnLista.Clave = UnaTarjeta.Clave Then
                If TarjetaEnLista.Empresa = UnaTarjeta.Empresa Then
                    Validar = True
                End If

            End If
        End If
        Return Validar
    End Function

    Private Sub LLenarComboAnio()
        Dim AnioHasta As Integer = Now.Year + 15
        For i = Now.Year To AnioHasta
            comboAnioVencimiento.Items.Add(New ListItem(i, i))
        Next
    End Sub

    Private Sub LLenarComboMes()
        For i = 1 To 12
            comboMesVencimiento.Items.Add(New ListItem(i, i))
        Next
    End Sub
End Class

Public Class Tarjeta

    Public Sub New()

    End Sub

    Public Sub New(ByVal empresa As eTipoTarjeta, ByVal nro As Long, ByVal titular As String, ByVal clave As Integer, ByVal fechaVencimiento As Integer)
        Me.Empresa = empresa
        Me.Nro = nro
        Me.Titular = titular
        Me.Clave = clave
        Me.FechaVencimiento = fechaVencimiento
    End Sub
    Public Enum eTipoTarjeta
        Master = 1
        Visa = 2
        AMEX = 3
    End Enum

    Private pTipo As eTipoTarjeta
    Public Property Empresa() As eTipoTarjeta
        Get
            Return pTipo
        End Get
        Set(ByVal value As eTipoTarjeta)
            pTipo = value
        End Set
    End Property

    Private pNro As Long
    Public Property Nro() As Long
        Get
            Return pNro
        End Get
        Set(ByVal value As Long)
            pNro = value
        End Set
    End Property

    Private pTitular As String
    Public Property Titular() As String
        Get
            Return pTitular
        End Get
        Set(ByVal value As String)
            pTitular = value
        End Set
    End Property

    Private pClave As Integer
    Public Property Clave() As Integer
        Get
            Return pClave
        End Get
        Set(ByVal value As Integer)
            pClave = value
        End Set
    End Property

    Private pFecha As Integer
    Public Property FechaVencimiento() As Integer
        Get
            Return pFecha
        End Get
        Set(ByVal value As Integer)
            pFecha = value
        End Set
    End Property
End Class
