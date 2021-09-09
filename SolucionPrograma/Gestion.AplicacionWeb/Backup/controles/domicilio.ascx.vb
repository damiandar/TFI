Imports Tsu.ProviderOra

Imports Tsu.Utilidades

Namespace Tsu.Paginas

    Partial Class controles_domicilio
        Inherits System.Web.UI.UserControl

#Region "campos y propiedades"

        Dim _Cuenta As Integer
        Dim _Campania As Integer
        Dim _Zona As Integer
        Dim _Domicilio As String
        Dim _Localidad As String
        Dim _CodigoPostal As Integer
        Dim _CarpetaPrevia As String



        Public Property cuenta() As Integer
            Get
                Return _Cuenta
            End Get
            Set(ByVal value As Integer)
                _Cuenta = value
            End Set
        End Property

        Public Property campania() As Integer
            Get
                Return _Campania
            End Get
            Set(ByVal value As Integer)
                _Campania = value
            End Set
        End Property

        Public Property zona() As Integer
            Get
                Return _Zona
            End Get
            Set(ByVal value As Integer)
                _Zona = value
            End Set
        End Property

        Public Property codigopostal() As Integer
            Get
                Return _CodigoPostal
            End Get
            Set(ByVal value As Integer)
                _CodigoPostal = value
            End Set
        End Property

        Public Property domicilio() As String
            Get
                Return _Domicilio
            End Get
            Set(ByVal value As String)
                _Domicilio = value
            End Set
        End Property

        Public Property CarpetaPrevia() As String
            Get
                Return _CarpetaPrevia
            End Get
            Set(ByVal value As String)
                _CarpetaPrevia = value
            End Set
        End Property

#End Region

#Region "Botones"

        Protected Sub btnborrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnborrar.Click
            borrar()
            MostrarPantallaDomicilio()
        End Sub
        Protected Sub btnConfirmar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar2.Click
            If Page.IsValid Then
                ModificarRegistro()
                MostrarPantallaDomicilio()
            End If
        End Sub
        Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar.Click
            If Page.IsValid Then
                Crear()
                MostrarPantallaDomicilio()
                Mensaje.Visible = True
            End If
        End Sub
        Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnModificar.Click
            If Page.IsValid Then
                Try
                    Dim oDomicilioAlternativoMap As New DomicilioAlternativoMapOra()
                    Dim oDomicilio As DomicilioAlternativo = oDomicilioAlternativoMap.MostrarDomicilioAlternativo(cuenta, zona, campania)

                    nuevo.Visible = False
                    ver.Visible = False
                    Modificar.Visible = True
                    Mensaje.Visible = True
                    tbDomicilio2.Text = oDomicilio.domicilio
                    tbLocalidad2.Text = oDomicilio.localidad
                Catch ex As Exception
                    UtilLogBase.Guardar(Tsu.Entity.LogBase.TipoLog.ErrorMAP, Session("cuenta"), "Control Domicilio.ascx/modificar: " & ex.Message.ToString())
                End Try

            End If

        End Sub
        Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
            ver.Visible = True
            nuevo.Visible = False
            modificar.visible = False
            Mensaje.visible = False
        End Sub

#End Region

#Region "CRUD"

        Private Sub borrar()
            Try
                Dim oDomicilioAlternativoMap As New DomicilioAlternativoMapOra()
                oDomicilioAlternativoMap.Borrar(cuenta, zona, campania)
                tbDomicilio.Text = ""
                tbLocalidad.Text = ""
                UtilLogBase.GuardarEvento(LogBase.TipoLogEvento.CambioDomicilio, cuenta, String.Format("Domicilio Borrado, Cuenta Carga:{0} ", Session("cuenta")))
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, cuenta, "Control Domicilio.ascx/borrar: " & ex.Message.ToString())
            End Try

        End Sub

       
         
         
#End Region

        Protected Sub btnContinuar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnContinuar.Click
            Response.Redirect(CarpetaPrevia & "solicitudcompra.aspx")
        End Sub
    End Class

End Namespace