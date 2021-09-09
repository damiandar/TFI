Imports Tsu.ProviderOra


Namespace Tsu.Paginas

    Partial Class controles_conferencia_GrillaLugares
        Inherits System.Web.UI.UserControl


        Public Event TocoModificar(ByVal idConferencia As Integer, ByVal idZona As Integer)
        Public Event ErrorEnBorrar(ByVal MensajeError As String)
        Public Event BorroItem(ByVal id As Integer, ByVal zona As Integer)

        Public Sub LLenarGrilla(ByVal zona As Integer)
            Dim oMapSalones As New SalonMapOra
            Dim ListaLugares As List(Of Salon) = oMapSalones.ListarLugares(zona)
            GrillaLugares.DataSource = ListaLugares
            GrillaLugares.DataBind()
        End Sub

        Protected Function FormatearCampoProvincia(ByVal sProvincia As Object) As String
            Return getProvincia(sProvincia.ToString())
        End Function

        Protected Function FormatearCampoTexto(ByVal oTexto As Object) As String
            Return Server.HtmlDecode(oTexto.ToString())
        End Function

        Protected Function getProvincia(ByVal letra As String) As String
            Dim retorno As String = ""

            Select Case letra
                Case "A"
                    retorno = "Salta"
                Case "B"
                    retorno = "Buenos Aires"
                Case "C"
                    retorno = "Capital Federal"
                Case "D"
                    retorno = "San Luis"
                Case "E"
                    retorno = "Entre Rios"
                Case "F"
                    retorno = "La Rioja"
                Case "G"
                    retorno = "Santiago del Estero"
                Case "H"
                    retorno = "Chaco"
                Case "J"
                    retorno = "San Juan"
                Case "K"
                    retorno = "Catamarca"
                Case "L"
                    retorno = "La Pampa"
                Case "M"
                    retorno = "Mendoza"
                Case "N"
                    retorno = "Misiones"
                Case "P"
                    retorno = "Formosa"
                Case "Q"
                    retorno = "Neuquen"
                Case "R"
                    retorno = "Rio Negro"
                Case "S"
                    retorno = "Santa Fe"
                Case "T"
                    retorno = "Tucuman"
                Case "U"
                    retorno = "Chubut"
                Case "V"
                    retorno = "Tierra del Fuego"
                Case "W"
                    retorno = "Corrientes"
                Case "X"
                    retorno = "Cordoba"
                Case "Y"
                    retorno = "Jujuy"
                Case "Z"
                    retorno = "Santa Cruz"
            End Select
            Return retorno
        End Function

        Protected Sub GrillaLugares_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrillaLugares.RowCommand
            Dim lb As ImageButton = CType(e.CommandSource, ImageButton)
            Dim gvRow As GridViewRow = lb.BindingContainer
            Dim idLugar As Integer = Convert.ToInt32(GrillaLugares.DataKeys(gvRow.RowIndex)(0))
            Dim idZona As Integer = Convert.ToInt32(GrillaLugares.DataKeys(gvRow.RowIndex)(1))

            If e.CommandName.ToString() = "Select" Then
                modalPopUpExtender1.Show()
                LLenarPanelPopUp(idLugar, idZona)
            ElseIf e.CommandName.ToString() = "Edit" Then
                RaiseEvent TocoModificar(idLugar, idZona)
            ElseIf e.CommandName.ToString() = "BorrarItem" Then
                Try
                    Dim oMapLugar As New SalonMapOra
                    oMapLugar.BorrarSalon(idLugar, idZona)
                    RaiseEvent BorroItem(idLugar, idZona)
                Catch ex As Exception
                    modalPopUpExtender2.Show()
                    RaiseEvent ErrorEnBorrar(ex.Message.ToString())
                End Try

            End If
        End Sub

        Protected Sub GrillaLugares_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrillaLugares.RowDataBound
            'If Not (e.Row.RowState = 5 Or e.Row.RowState = 4) Then
            '    e.Row.CssClass = ""
            'End If
        End Sub

        Protected Sub GrillaLugares_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrillaLugares.RowEditing
            'Dim gvRow As GridViewRow = GrillaLugares.Rows(e.NewEditIndex)
            'gvRow.CssClass = "tablaFilaDestacada"
        End Sub

        Public Sub LLenarPanelPopUp(ByVal idSalon As Integer, ByVal idZona As Integer)
            Try
                Dim oSalonMapper As New SalonMapOra
                Dim oSalon As Salon = oSalonMapper.MostrarSalon(idSalon, idZona)
                ltNombre.Text = FormatearCampoTexto(oSalon.nombre)
                ltBarrio.Text = FormatearCampoTexto(oSalon.barrio)
                ltDireccion.Text = FormatearCampoTexto(oSalon.domicilio)
                ltEntreCalles.Text = FormatearCampoTexto(oSalon.domicilio2)
                ltLocalidad.Text = FormatearCampoTexto(oSalon.localidad)
                ltProvincia.Text = FormatearCampoProvincia(oSalon.provincia)
                ltTelefono1.Text = String.Format("{0}-{1}", oSalon.area, oSalon.telefono)
                ltTelefono2.Text = String.Format("{0}-{1}", oSalon.area2, oSalon.telefono2)
                ltZona.Text = oSalon.zona
            Catch ex As Exception

            End Try
        End Sub

    End Class

End Namespace