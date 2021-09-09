Imports Tsu.ProviderOra

Imports Tsu.Utilidades

Namespace Tsu.Paginas
    Partial Class controles_cargaSalon
        Inherits System.Web.UI.UserControl

        Private _zona As Integer
        Public Property zona() As Integer
            Get
                Return _zona
            End Get
            Set(ByVal value As Integer)
                _zona = value
            End Set
        End Property

        Public Event Inserto(ByVal oSalon As Salon)
        Public Event Modifico(ByVal oSalon As Salon)

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Page.IsPostBack Then
                LLenarComboProvincia()
                btnConfirmar.Visible = False
            End If
        End Sub

#Region "Botones"
        'modifica
        Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar.Click
            Try
                If Page.IsValid Then
                    Dim oSalonMap As New SalonMapOra()
                    Dim oSalon As Salon = LLenarObjeto()
                    oSalonMap.ModificarSalon(oSalon)
                    VaciarPanel()
                    btnConfirmar.Visible = False
                    btnCargar.Visible = True
                    RaiseEvent Modifico(oSalon)
                End If
            Catch ex As MapExceptionControlada
                lblMensaje.Text = "El lugar cargado ya existe, por favor revisar los datos cargados."
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Session("cuenta"), String.Format("ACT. SALON/zona:{0} msg:{1}", zona, ex.Message.ToString()))
            End Try

        End Sub
        'inserta
        Protected Sub btnCargar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCargar.Click
            Try
                If Page.IsValid Then
                    Dim oSalonMap As New SalonMapOra()
                    Dim oSalon As Salon = LLenarObjeto()
                    oSalonMap.InsertarSalon(oSalon)
                    btnConfirmar.Visible = False
                    btnCargar.Visible = True
                    VaciarPanel()
                    RaiseEvent Inserto(oSalon)
                End If
            Catch ex As MapExceptionControlada
                lblMensaje.Text = "El lugar cargado ya existe, por favor revisar los datos cargados."
            Catch ex As Exception
                UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Session("cuenta"), String.Format("BORRA SALON/zona:{0} msg:{1}", zona, ex.Message.ToString()))
            End Try

        End Sub

        Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
            btnConfirmar.Visible = False
            btnCargar.Visible = True
            VaciarPanel()
        End Sub

        Private Function LLenarObjeto() As Salon
            Dim oSalon As New Salon
            If hCodigoSalon.Value <> "" Then
                oSalon.id = hCodigoSalon.Value
            End If
            oSalon.zona = zona
            oSalon.nombre = Server.HtmlEncode(tbSalon.Text)
            oSalon.domicilio = Server.HtmlEncode(tbDireccion.Text)
            oSalon.domicilio2 = Server.HtmlEncode(tbEntreCalles.Text)
            oSalon.barrio = Server.HtmlEncode(tbBarrio.Text)
            oSalon.localidad = Server.HtmlEncode(tbLocalidad.Text)
            oSalon.provincia = ComboProvincia.SelectedValue
            oSalon.area = Server.HtmlEncode(tbArea1.Text)
            oSalon.telefono = Server.HtmlEncode(tbTelefono1.Text)
            oSalon.area2 = Server.HtmlEncode(tbArea2.Text)
            oSalon.telefono2 = Server.HtmlEncode(tbTelefono2.Text)
            Return oSalon
        End Function
#End Region

#Region "Metodos Privados"

        Private Function GuardarValorEntero(ByVal DatoIngresado As String) As Integer
            If DatoIngresado = "" Then
                Return 0
            Else
                Return Convert.ToInt32(DatoIngresado)
            End If
        End Function

        Private Sub LLenarComboProvincia()
            ComboProvincia.Items.Add(New ListItem("", ""))
            ComboProvincia.Items.Add(New ListItem("Buenos Aires", "B"))
            ComboProvincia.Items.Add(New ListItem("Capital Federal", "C"))
            ComboProvincia.Items.Add(New ListItem("Catamarca", "K"))
            ComboProvincia.Items.Add(New ListItem("Chaco", "H"))
            ComboProvincia.Items.Add(New ListItem("Chubut", "U"))
            ComboProvincia.Items.Add(New ListItem("Cordoba", "X"))
            ComboProvincia.Items.Add(New ListItem("Corrientes", "W"))
            ComboProvincia.Items.Add(New ListItem("Entre Rios", "E"))
            ComboProvincia.Items.Add(New ListItem("Formosa", "P"))
            ComboProvincia.Items.Add(New ListItem("Jujuy", "Y"))
            ComboProvincia.Items.Add(New ListItem("La Pampa", "L"))
            ComboProvincia.Items.Add(New ListItem("La Rioja", "F"))
            ComboProvincia.Items.Add(New ListItem("Mendoza", "M"))
            ComboProvincia.Items.Add(New ListItem("Misiones", "N"))
            ComboProvincia.Items.Add(New ListItem("Neuquen", "Q"))
            ComboProvincia.Items.Add(New ListItem("Rio Negro", "R"))
            ComboProvincia.Items.Add(New ListItem("Salta", "A"))
            ComboProvincia.Items.Add(New ListItem("San Juan", "J"))
            ComboProvincia.Items.Add(New ListItem("San Luis", "D"))
            ComboProvincia.Items.Add(New ListItem("Santa Cruz", "Z"))
            ComboProvincia.Items.Add(New ListItem("Santa Fe", "S"))
            ComboProvincia.Items.Add(New ListItem("Santiago del Estero", "G"))
            ComboProvincia.Items.Add(New ListItem("Tierra Del Fuego", "V"))
            ComboProvincia.Items.Add(New ListItem("Tucuman", "T"))
        End Sub

        Public Sub LLenarPanel(ByVal idSalon As Integer, ByVal idZona As Integer)
            Dim oSalonMapper As New SalonMapOra
            Dim oSalon As Salon = oSalonMapper.MostrarSalon(idSalon, idZona)
            If oSalon IsNot Nothing Then
                tbSalon.Text = Server.HtmlDecode(oSalon.nombre)
                tbDireccion.Text = Server.HtmlDecode(oSalon.domicilio)
                tbEntreCalles.Text = Server.HtmlDecode(oSalon.domicilio2)
                tbBarrio.Text = Server.HtmlDecode(oSalon.barrio)
                tbLocalidad.Text = Server.HtmlDecode(oSalon.localidad)
                tbArea1.Text = Trim(oSalon.area)
                tbTelefono1.Text = Trim(oSalon.telefono)
                tbArea2.Text = Trim(oSalon.area2)
                tbTelefono2.Text = Trim(oSalon.telefono2)

                ComboProvincia.SelectedValue = oSalon.provincia
                hCodigoSalon.Value = oSalon.id

                btnCargar.Visible = False
                btnConfirmar.Visible = True
            End If
        End Sub

        Private Sub VaciarPanel()
            tbSalon.Text = ""
            tbDireccion.Text = ""
            tbEntreCalles.Text = ""
            tbBarrio.Text = ""
            tbLocalidad.Text = ""
            tbArea1.Text = ""
            tbTelefono1.Text = ""
            tbArea2.Text = ""
            tbTelefono2.Text = ""
            ComboProvincia.Text = ""
            lblMensaje.Text = ""
        End Sub
#End Region

    End Class
End Namespace
