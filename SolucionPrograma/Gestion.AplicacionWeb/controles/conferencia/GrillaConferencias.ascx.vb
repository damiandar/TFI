Imports Tsu.ProviderOra

Imports System.IO

Namespace Tsu.Paginas
    Partial Class controles_GrillaConferencias
        Inherits System.Web.UI.UserControl

        Public Event Borro(ByVal id As Integer)
        Public Event TocoModificar(ByVal idConferencia As Integer)

#Region "Ordenamiento"

        Public Event Ordenamiento(ByVal campo As String, ByVal sentido As String)

        Protected WithEvents botonCampaniaAsc As ImageButton
        Protected WithEvents botonCampaniaDesc As ImageButton
        Protected WithEvents botonAnioAsc As ImageButton
        Protected WithEvents botonAnioDesc As ImageButton
        Protected WithEvents botonFechaAsc As ImageButton
        Protected WithEvents botonFechaDesc As ImageButton

        Protected Sub btnCampaniaAsc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCampaniaAsc.Click
            RaiseEvent Ordenamiento("campania", "Ascending")
        End Sub
        Protected Sub btnCampaniaDesc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonCampaniaDesc.Click
            RaiseEvent Ordenamiento("campania", "Descending")
        End Sub
        Protected Sub btnAnioAsc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonAnioAsc.Click
            RaiseEvent Ordenamiento("anio", "Ascending")
        End Sub
        Protected Sub btnAnioDesc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonAnioDesc.Click
            RaiseEvent Ordenamiento("anio", "Descending")
        End Sub
        Protected Sub btnFechaAsc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonFechaAsc.Click
            RaiseEvent Ordenamiento("fecha", "Ascending")
        End Sub
        Protected Sub btnFechaDesc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles botonFechaDesc.Click
            RaiseEvent Ordenamiento("fecha", "Descending")
        End Sub

        Private Sub Ordenar(ByVal listaConferencia As List(Of conferencia), ByVal orden As String, ByVal sentido As String)
            If orden <> "" Then
                Dim comp As Comparador(Of conferencia)

                If sentido = "Descending" Then
                    comp = New Comparador(Of conferencia)(orden, "Descending")
                Else
                    comp = New Comparador(Of conferencia)(orden, "Ascending")
                End If

                listaConferencia.Sort(AddressOf comp.Compare)
            End If
        End Sub

#End Region

        Public Sub LLenarPanelPopUp(ByVal id As Integer)
            Try
                Dim oConferenciaMap As New ConferenciaMapOra()
                Dim oConferencia As conferencia = oConferenciaMap.MostrarConferencia(id)
                ltZona.Text = oConferencia.zona
                ltCampania.Text = oConferencia.campania
                Dim diaformateado As DateTime = Convert.ToDateTime(oConferencia.fecha.ToString().Insert(4, "-").Insert(7, "-")).ToShortDateString()
                ltFechayHora.Text = String.Format("Fecha: {0}  {1} hs.", diaformateado.ToShortDateString(), oConferencia.hora.ToString("##:##"))
                ltLugar.Text = String.Format("Lugar: {0}, ({1}),{2}-{3} {4}", FormatearCampoTexto(oConferencia.salon.domicilio), FormatearCampoTexto(oConferencia.salon.domicilio2), FormatearCampoTexto(oConferencia.salon.barrio), FormatearCampoTexto(oConferencia.salon.localidad), FormatearCampoProvincia(oConferencia.salon.provincia))
                ltTipoConferencia.Text = String.Format("{0} en: {1}", FormatearCampoActividad(oConferencia.actividad), FormatearCampoTexto(oConferencia.salon.nombre))
                ltTelefono.Text = String.Format("Teléfono: {0} - {1}", oConferencia.salon.area, oConferencia.salon.telefono)
                ltTelefono2.Text = String.Format("Teléfono Alternativo: {0} - {1}", oConferencia.salon.area2, oConferencia.salon.telefono2)
                ltAnio.Text = oConferencia.anio
                ltObservaciones.Text = oConferencia.observaciones
            Catch ex As Exception
                Throw New Exception("CtrlGrillaConf/LLenarPanelPopUp:" & ex.Message.ToString())
            End Try
        End Sub

        Public Sub LLenarGrilla(ByVal zona As Integer, ByVal campania As Integer, ByVal anio As Integer, ByVal orden As String, ByVal sentido As String)
            Try
                Dim oMapConferencias As New ConferenciaMapOra()
                Dim ListaConferencias As List(Of conferencia)
                ListaConferencias = oMapConferencias.ListarConferencias(zona, anio, campania)

                If HttpContext.Current.User.IsInRole("R") Or HttpContext.Current.User.IsInRole("C") Then
                    Dim fechaActual As Integer = Format(DateTime.Now.Year, "0000") & Format(DateTime.Now.Month, "00") & Format(DateTime.Now.Day, "00")
                    ListaConferencias = ListaConferencias.Where(Function(x) x.fecha >= fechaActual).OrderBy(Function(x) x.anio).ThenBy(Function(x) x.campania).ThenBy(Function(x) x.fecha).ThenBy(Function(x) x.hora).ToList()
                End If
                Ordenar(ListaConferencias, orden, sentido)
                GrillaConferencias.DataSource = ListaConferencias
                GrillaConferencias.DataBind()
                If HttpContext.Current.User.IsInRole("R") Or HttpContext.Current.User.IsInRole("C") Or HttpContext.Current.User.IsInRole("P") Then
                    GrillaConferencias.Columns(10).Visible = False
                    GrillaConferencias.Columns(9).Visible = False
                End If

            Catch ex As Exception
                Throw New Exception("CtrlGrillaConf/LLenarGrilla:" & ex.Message.ToString())
            End Try

        End Sub

#Region "Eventos de la grilla"

        Protected Sub GrillaConferencias_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrillaConferencias.RowCommand
            If Not e.CommandName = "" Then
                Dim lb As ImageButton = CType(e.CommandSource, ImageButton)
                Dim gvRow As GridViewRow = lb.BindingContainer
                Dim idConferencia As Integer = Convert.ToInt32(GrillaConferencias.DataKeys(gvRow.RowIndex)(0))
                'Response.Write(e.CommandName.ToString())
                If e.CommandName.ToString() = "Select" Then
                    modalPopUpExtender1.Show()
                    LLenarPanelPopUp(idConferencia)
                ElseIf e.CommandName.ToString() = "Edit" Then
                    RaiseEvent TocoModificar(idConferencia)
                ElseIf e.CommandName.ToString() = "BorrarItem" Then
                    Dim oConferenciaMapOra As New ConferenciaMapOra()
                    oConferenciaMapOra.BorrarConferencia(idConferencia)
                    RaiseEvent Borro(idConferencia)
                End If
            End If
        End Sub

        Protected Sub GrillaConferencias_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrillaConferencias.RowEditing

        End Sub

#End Region

#Region "Formato de la grilla"

        Protected Function FormatearCampoProvincia(ByVal letra As String) As String
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

        Protected Function FormatearCampoActPrincipal(ByVal oBool As Object) As String
            Dim Campo As String = ""
            If Convert.ToBoolean(oBool) = True Then
                Campo = "X"
            End If
            Return Campo
        End Function

        Protected Function FormatearCampoHora(ByVal oHora As Object) As String
            Dim hora As String = Convert.ToInt32(oHora).ToString("##:##")
            Return hora
        End Function

        Protected Function FormatearCampoFecha(ByVal oFecha As Object) As String
            Dim diaformateado As DateTime = Convert.ToDateTime(oFecha.ToString().Insert(4, "-").Insert(7, "-")).ToShortDateString()
            Return diaformateado.ToShortDateString()
        End Function

        Protected Function FormatearCampoActividad(ByVal oValor As Object) As String
            Dim valorRetorno As String = ""

            Select Case oValor.ToString()
                Case "P"
                    valorRetorno = "Posta"
                Case "C"
                    valorRetorno = "Conferencia"
                Case "N"
                    valorRetorno = "C. de Negocio"
                Case Else
                    valorRetorno = ""
            End Select

            Return valorRetorno
        End Function

        Protected Function FormatearCampoTexto(ByVal oTexto As Object) As String
            Return Server.HtmlDecode(oTexto.ToString())
        End Function

#End Region

        Public Sub ExportToExcel(ByVal zona As Integer, ByVal campania As Integer, ByVal anio As Integer)
            Try
                Dim oMapConferencias As New ConferenciaMapOra()
                Dim ListaConferencias As List(Of conferencia) = oMapConferencias.ListarConferencias(zona, anio, 0)

                Dim listaOrdenada As List(Of conferencia) = ListaConferencias.OrderBy(Function(x) x.zona).ThenBy(Function(x) x.campania).ThenBy(Function(x) x.fecha).ThenBy(Function(x) x.hora).ToList()

                Dim GrillaExporta As New GridView
                GrillaExporta.AllowPaging = False
                GrillaExporta.DataSource = listaOrdenada
                GrillaExporta.DataBind()

                Response.Clear()
                Response.Buffer = True
                'Response.ContentEncoding = System.Text.Encoding.UTF8
                'Response.Charset = "UTF-8"
                Response.ContentEncoding = System.Text.Encoding.Unicode
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())
                Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.xls", "conferencias"))
                Response.ContentType = "application/vnd.ms-excel"

                Dim sw As New StringWriter()
                Dim hw As New HtmlTextWriter(sw)

                hw.AddAttribute("border", "1")

                hw.RenderBeginTag("table")
                hw.WriteLine()
                hw.Indent += 1
                hw.AddStyleAttribute(HtmlTextWriterStyle.FontWeight, "bold")

                'hw.AddAttribute("font-weight", "bold")
                hw.RenderBeginTag("tr")
                hw.WriteLine()
                hw.Indent += 1

                hw.RenderBeginTag("td")
                hw.Write("Zona")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("Campa&ntilde;a")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("A&ntilde;o")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("Fecha")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("Hora")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("Actividad")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("Ppal.")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("Nombre")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("Direcci&oacute;n")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("Entre Calles")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("Barrio")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("Localidad")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("Provincia")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("&Aacute;rea")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("Tel&eacute;fono")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("&Aacute;rea Alt.")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("Tel&eacute;fono Alt.")
                hw.RenderEndTag()
                hw.RenderBeginTag("td")
                hw.Write("Observaciones")
                hw.RenderEndTag()

                hw.RenderEndTag()

                For Each oConferencia As conferencia In listaOrdenada
                    hw.RenderBeginTag("tr")
                    hw.WriteLine()
                    hw.Indent += 1

                    hw.RenderBeginTag("td")
                    hw.Write(oConferencia.zona)
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(oConferencia.campania)
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(oConferencia.anio)
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(FormatearCampoFecha(oConferencia.fecha))
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(FormatearCampoHora(oConferencia.hora))
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(FormatearCampoActividad(oConferencia.actividad))
                    hw.RenderEndTag()
                    hw.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "center")
                    hw.RenderBeginTag("td")
                    hw.Write(FormatearCampoActPrincipal(oConferencia.principal))
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(oConferencia.salon.nombre)
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(oConferencia.salon.domicilio)
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(oConferencia.salon.domicilio2)
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(oConferencia.salon.barrio)
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(oConferencia.salon.localidad)
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(FormatearCampoProvincia(oConferencia.salon.provincia))
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(oConferencia.salon.area)
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(oConferencia.salon.telefono)
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(oConferencia.salon.area2)
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(oConferencia.salon.telefono2)
                    hw.RenderEndTag()
                    hw.RenderBeginTag("td")
                    hw.Write(oConferencia.observaciones)
                    hw.RenderEndTag()

                    hw.RenderEndTag()
                Next

                hw.Indent -= 1
                hw.RenderEndTag()

                'GrillaExporta.RenderControl(hw)
                'style to format numbers to string 
                Dim style As String = "<style> .textmode{mso-number-format:\@;}</style>"
                Response.Write(style)
                Response.Output.Write(sw.ToString())
                Response.Flush()
                Response.End()

            Catch ex As Exception
                Throw New Exception("CtrlGrillaConf/ExporToExcel:" & ex.Message.ToString())
            End Try

        End Sub

    End Class
End Namespace

