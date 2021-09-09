
Partial Class micuenta_bitacora
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LLenarComboAccion()
            LLenarComboObjeto()
            LLenarComboUsuarios()
        End If
    End Sub


#Region "Metodos Privados"

    Private Sub LLenarComboUsuarios()
        Dim GestorUsuarios As New Mapper_Usuario
        comboUsuario.DataTextField = "login"
        comboUsuario.DataSource = GestorUsuarios.MuestraListado()
        comboUsuario.DataBind()
    End Sub

    Private Sub LLenarComboAccion()
        Dim GestorAccion As New Mapper_Patente
        comboObjeto.DataSource = GestorAccion.ListarPatentes()
        comboObjeto.DataBind()
    End Sub

    Private Sub LLenarComboObjeto()
        Dim GestorAccion As New Mapper_Patente
        comboObjeto.DataSource = GestorAccion.ListarPatentes()
        comboObjeto.DataBind()
    End Sub

#End Region

    Protected Sub btnMostrarBitacora_Click(sender As Object, e As System.EventArgs) Handles btnMostrarBitacora.Click
        Dim GestorBitacora As New Mapper_Bitacora()
        GrillaBitacora.DataSource = GestorBitacora.MuestraListado("", Nothing, Nothing)
        GrillaBitacora.DataBind()
    End Sub
End Class
