
Partial Class controles_motivos
    Inherits System.Web.UI.UserControl


#Region "Campos y Propiedades"

    Public Enum Tipo
        NC
        CyR
        SOLICITUD
        PREMIOS
    End Enum

    Dim pTipoMotivo As Tipo
    Public Property TipoMotivo() As Tipo
        Get
            Return pTipoMotivo
        End Get
        Set(ByVal value As Tipo)
            pTipoMotivo = value
        End Set
    End Property

#End Region

    Protected Function llenarimagen(ByVal codigo As Object) As String
        Return "~/assets/images/motivo_" & codigo.ToString() & ".gif"
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If TipoMotivo = Tipo.CyR Or TipoMotivo = Tipo.NC Then
            If HttpContext.Current.User.IsInRole("P") Or (HttpContext.Current.User.IsInRole("G") And Session("revendedora") = 0) Then
                llenarMotivos(TipoMotivo, True)
            Else
                llenarMotivos(TipoMotivo, False)
            End If
            LLenarAdvertencia()
        Else
            Me.Visible = False
        End If
    End Sub

    Public Sub llenarMotivos(ByVal tipo As Tipo, ByVal esPersonal As Boolean)
        Dim motivo_3 As String = "Producto recibido sin facturar."
        Dim motivo_4 As String = "Sustitución no satisfactoria, cambio no atendido, producto no solicitado y facturado, cantidad recibida mayor que la solicitada (sólo Nota de Crédito)"
        Dim motivo_5 As String = "Producto recibido diferente al facturado."
        Dim motivo_6 As String = "Sólo para Gerentes de Zona."
        Dim motivo_7 As String = "Producto roto, sucio o dañado. Incompleto o vacío. Mecanismo defectuoso o no funciona."
        Dim motivo_8 As String = "Producto no solicitado u omitido en campaña anterior."
        Dim motivo_9 As String = "Producto no disponible en campaña anterior."

        Dim listaMotivos As New List(Of Motivos)

        If tipo = controles_motivos.Tipo.NC Then
            'nc
            listaMotivos.Add(New Motivos(4, motivo_4))
            listaMotivos.Add(New Motivos(5, motivo_5))
            listaMotivos.Add(New Motivos(7, motivo_7))
        ElseIf tipo = controles_motivos.Tipo.CyR Then
            'cyr
            If Not esPersonal Then
                listaMotivos.Add(New Motivos(3, motivo_3))
                listaMotivos.Add(New Motivos(5, motivo_5))
                listaMotivos.Add(New Motivos(7, motivo_7))
                listaMotivos.Add(New Motivos(8, motivo_8))
                listaMotivos.Add(New Motivos(9, motivo_9))
            Else
                listaMotivos.Add(New Motivos(8, motivo_8))
            End If

        End If
        Me.GrillaMotivos.DataSource = listaMotivos
        Me.GrillaMotivos.DataBind()

    End Sub

    Public Sub LLenarAdvertencia()
        If HttpContext.Current.User.IsInRole("R") Or (HttpContext.Current.User.IsInRole("C")) Then
            PanelImportante.Visible = True
            If TipoMotivo = Tipo.CyR Then
                lblAdvertencia.Text = "Sólo se atenderán reclamos por productos facturados en la campaña anterior."
            End If
            If TipoMotivo = Tipo.NC Then
                lblAdvertencia.Text = "Se atenderán solicitudes por productos facturados hasta dos campañas anteriores."
            End If
        Else
            PanelImportante.Visible = False
            lblAdvertencia.Text = ""
        End If
    End Sub

End Class
