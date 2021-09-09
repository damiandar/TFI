
Imports Tsu.ProviderOra
Imports Tsu.Utilidades

Partial Class controles_domiciliocabecera
    Inherits System.Web.UI.UserControl


#Region "Campos y Propiedades"

    Dim _Cuenta As Integer
    Dim _Campania As Integer
    Dim _Zona As Integer

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

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MostrarCabeceraDomicilio()
    End Sub

#Region "Metodos Privados"
    Private Sub MostrarCabeceraDomicilio()
        Try
            Dim oDomicilioAlternativoMap As New DomicilioAlternativoMapOra()
            Dim oDomicilio As DomicilioAlternativo = oDomicilioAlternativoMap.MostrarDomicilioAlternativo(Me.cuenta, Me.zona, Me.campania)

            If oDomicilio IsNot Nothing Then
                Me.lblCalleCab.Text = oDomicilio.domicilio
                Me.lblLocalidadCab.Text = oDomicilio.localidad
                Me.Visible = True
            Else
                Me.Visible = False
            End If
        Catch ex As Exception
            UtilLogBase.Guardar(Tsu.Entity.LogBase.TipoLog.ErrorMAP, Me.cuenta, String.Format("Control DomiCabec.ascx/MostrarDomicilio:{0} - {1} ", ex.Message.ToString(), AppRelativeVirtualPath.ToString()))
        End Try
    End Sub
#End Region

End Class
