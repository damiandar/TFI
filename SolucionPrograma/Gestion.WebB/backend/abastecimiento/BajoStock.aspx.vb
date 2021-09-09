Partial Class compras_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LLenarGrilla()
        End If
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim UnaReposicion As New Reposicion
        UnaReposicion.Items = New List(Of ReposicionItem)
        UnaReposicion.Notas = tbNotas.Text
        UnaReposicion.Fecha = Now

        For Each Fila As GridViewRow In GrillaReposicion.Rows
            Dim chkPedir As CheckBox = CType(Fila.FindControl("chkPedir"), CheckBox)

            If chkPedir.Checked = True Then
                Dim tbCantidad As TextBox = CType(Fila.FindControl("tbCantidad"), TextBox)

                If CInt(tbCantidad.Text) > 0 Then
                    Dim hCodigo As HiddenField = CType(Fila.FindControl("hCodigo"), HiddenField)
                    Dim comboPrioridad As DropDownList = CType(Fila.FindControl("comboPrioridad"), DropDownList)
                    Dim tbEspecificacion As TextBox = CType(Fila.FindControl("tbEspecificacion"), TextBox)

                    Dim UnItem As New ReposicionItem
                    UnItem.insumo = New Insumo
                    UnItem.insumo.ID = CInt(hCodigo.Value)

                    UnItem.cantidadPedida = CInt(tbCantidad.Text)
                    UnItem.cantidadRestante = CInt(tbCantidad.Text)
                    UnItem.cantidadEntregada = 0
                    UnItem.Prioridad = CInt(comboPrioridad.SelectedValue)
                    UnItem.Especificacion = tbEspecificacion.Text

                    UnaReposicion.Items.Add(UnItem)
                End If
            End If
        Next

        If UnaReposicion.Items.Count > 0 Then
            Dim GestorAbastecimiento As New BLLReposicion
            GestorAbastecimiento.InsertarReposicion(UnaReposicion)
        End If

    End Sub


#Region "Metodos Privados"
    Private Sub LLenarGrilla()
        Dim GestorReposicion As New BLLInsumo
        GrillaReposicion.DataSource = GestorReposicion.MostrarInsumosBajoStock()
        GrillaReposicion.DataBind()
    End Sub
#End Region


End Class
