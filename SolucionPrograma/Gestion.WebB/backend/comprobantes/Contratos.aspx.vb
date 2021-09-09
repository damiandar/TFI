
Partial Class aplicacion_forms
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ListarContratos()
            'ScriptManager.GetCurrent(Me).RegisterPostBackControl(Button1)
            LLenarComboServicio()
            LLenarComboCliente()
        End If

    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As System.EventArgs) Handles btnNuevo.Click
        modalPopUpExtender1.Show()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Try
            InsertarContrato()
            Label1.Text = "Se inserto correctamente"

        Catch ex As Exception
            Label1.Text = ex.Message.ToString()
        End Try
    End Sub

#Region "Metodos Privados"

#Region "Metodos Privados"
    Private Sub LLenarComboServicio()
        Dim GestorServicio As New BLLServicio
        comboServicio.DataTextField = "descripcion"
        comboServicio.DataValueField = "id"
        comboServicio.DataSource = GestorServicio.ListarServicios(0, 0, 0)
        comboServicio.DataBind()

    End Sub
    Private Sub LLenarComboCliente()
        Dim GestorClientes As New BLLCliente
        comboCliente.DataTextField = "razon"
        comboCliente.DataValueField = "id"
        comboCliente.DataSource = GestorClientes.ListarClientes("")
        comboCliente.DataBind()
    End Sub

    Private Sub InsertarContrato()
        Dim UnContrato As New Contrato
        UnContrato.servicio = New Servicio()
        UnContrato.servicio.ID = 3
        UnContrato.cliente = New Cliente()
        UnContrato.cliente.ID = 4
        UnContrato.DiasDeCorte = 20
        UnContrato.Eventual = False
        UnContrato.FechaFinalizado = Now.Date
        UnContrato.FechaFirmado = Now.Date
        UnContrato.MesesVigencia = 24

        Dim GestorContratos As New BLLContrato()
        GestorContratos.InsertarContrato(UnContrato)
    End Sub

    Private Sub ListarContratos()
        Dim GestorContratos As New BLLContrato
        GrillaContratos.DataSource = GestorContratos.ListarContrato(0, 0, 0)
        GrillaContratos.DataBind()
    End Sub
#End Region

#End Region

End Class
