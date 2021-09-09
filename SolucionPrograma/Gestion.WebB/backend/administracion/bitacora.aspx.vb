
Partial Class micuenta_bitacora
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ViewState("fechaDesde") = Nothing
            ViewState("fechaHasta") = Nothing
            ViewState("usuario") = ""
            LLenarComboAccion()
            LLenarComboObjeto()
            LLenarComboUsuarios()
            LLenarGrilla("", Nothing, Nothing)
        End If
    End Sub

    Protected Sub lnkBuscar_Click(sender As Object, e As System.EventArgs) Handles lnkBuscar.Click
        Dim fechaDesde As DateTime = Nothing
        Dim fechaHasta As DateTime = Nothing
        Dim Usuario As String = ""

       


        If IsDate(tbFechaDesde.Text) Then
            fechaDesde = Convert.ToDateTime(tbFechaDesde.Text)
            ViewState("fechaDesde") = fechaDesde
        End If
        If IsDate(tbFechaHasta.Text) Then
            fechaHasta = Convert.ToDateTime(tbFechaHasta.Text)
            ViewState("fechaHasta") = fechaHasta
        End If
        If Not comboUsuario.SelectedItem.Text.Contains("--") Then
            Usuario = comboUsuario.SelectedItem.Text
            ViewState("usuario") = Usuario
        End If

        LLenarGrilla(Usuario, fechaDesde, fechaHasta)
    End Sub

#Region "Metodos Privados"

    Private Sub LLenarComboUsuarios()
        comboUsuario.Items.Insert(0, New ListItem("--Todos--", 0))
        comboUsuario.SelectedIndex = 0
        Dim GestorUsuarios As New Mapper_Usuario
        comboUsuario.DataTextField = "login"
        comboUsuario.DataSource = GestorUsuarios.MuestraListado()
        comboUsuario.DataBind()
    End Sub

    Private Sub LLenarComboAccion()
        'Dim GestorAccion As New Mapper_Patente
        'comboObjeto.DataSource = GestorAccion.ListarPatentes()
        'comboObjeto.DataBind()
        Dim itemValues As Array = System.Enum.GetValues(GetType(Patente.eAccion))
        Dim itemNames As Array = System.Enum.GetNames(GetType(Patente.eAccion))

        For i As Integer = 0 To itemNames.Length - 1
            Dim item As New ListItem(itemNames(i), itemValues(i))
            comboAccion.Items.Add(item)
        Next
    End Sub

    Private Sub LLenarComboObjeto()
        'Dim GestorAccion As New Mapper_Patente
        'comboObjeto.DataSource = GestorAccion.ListarPatentes()
        'comboObjeto.DataBind()
        Dim itemValues As Array = System.Enum.GetValues(GetType(Patente.eObjeto))
        Dim itemNames As Array = System.Enum.GetNames(GetType(Patente.eObjeto))

        For i As Integer = 0 To itemNames.Length - 1
            Dim item As New ListItem(itemNames(i), itemValues(i))
            comboObjeto.Items.Add(item)
        Next
    End Sub

    Private Sub LLenarGrilla(ByVal Login As String, ByVal FechaDesde As DateTime, ByVal FechaHasta As DateTime)
        Dim GestorBitacora As New Mapper_Bitacora()
        GrillaBitacora.DataSource = GestorBitacora.MuestraListado(Login, Nothing, Nothing, FechaDesde, FechaHasta)
        GrillaBitacora.DataBind()
    End Sub

#End Region

    Protected Sub GrillaBitacora_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrillaBitacora.PageIndexChanging
        LLenarGrilla(ViewState("usuario"), ViewState("fechaDesde"), ViewState("fechaHasta"))
        GrillaBitacora.PageIndex = e.NewPageIndex
        GrillaBitacora.DataBind()
    End Sub

    Private Sub GrillaBitacora_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GrillaBitacora.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblObjeto As Label = CType(e.Row.FindControl("lblObjeto"), Label)
            Dim Objeto As Patente.eObjeto = CType((DataBinder.Eval(e.Row.DataItem, "objeto")), Patente.eObjeto)
            lblObjeto.Text = Objeto.ToString()
            lblObjeto.ForeColor = Drawing.Color.Green

            Dim lblAccion As Label = CType(e.Row.FindControl("lblAccion"), Label)
            Dim Accion As Patente.eAccion = CType((DataBinder.Eval(e.Row.DataItem, "accion")), Patente.eAccion)
            lblAccion.Text = Accion.ToString()
            lblAccion.ForeColor = Drawing.Color.DarkBlue
        End If

    End Sub
End Class
