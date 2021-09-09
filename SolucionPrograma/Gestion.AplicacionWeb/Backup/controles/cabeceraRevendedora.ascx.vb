Imports Tsu.ProviderOra

Imports Tsu.Seguridad
Imports Tsu.Utilidades

Namespace Tsu.Paginas
    Public Class controles_cabeceraRevendedora
        Inherits System.Web.UI.UserControl

#Region "campos y propiedades"

        Dim _campania As Integer

        Public Property campania() As Integer
            Get
                Return _campania
            End Get
            Set(ByVal value As Integer)
                _campania = value
            End Set
        End Property

        Dim _mostrardomicilio As Boolean

        Public Property mostrardomicilio() As Boolean
            Get
                Return _mostrardomicilio
            End Get
            Set(ByVal value As Boolean)
                _mostrardomicilio = value
            End Set
        End Property

#End Region

#Region "metodos"

        Public Sub llenarDatos(ByVal oUsuario As Usuarios)
            Try
                ltapellido.Text = oUsuario.apellidonombre
                ltcuenta.Text = oUsuario.cuenta
                ltzona.Text = oUsuario.zona
                ltgrupo.Text = oUsuario.grupo

                If mostrardomicilio Then
                    Me.PanelDomicilio.Visible = True
                    MostrarCabeceraDomicilio(oUsuario.cuenta, oUsuario.zona, campania)
                Else
                    Me.PanelDomicilio.Visible = False
                End If
            Catch ex As Exception

            End Try
        End Sub

        Public Sub MostrarCabeceraDomicilio(ByVal cuenta As Integer, ByVal zona As Integer, ByVal campania As Integer)
            Try
                Dim oDomicilioAlternativoMap As New DomicilioAlternativoMapOra()
                Dim oDomicilio As DomicilioAlternativo = oDomicilioAlternativoMap.MostrarDomicilioAlternativo(cuenta, zona, campania)

                If oDomicilio IsNot Nothing Then
                    Me.lblCalleCab.Text = oDomicilio.domicilio
                    Me.lblLocalidadCab.Text = oDomicilio.localidad
                    Me.PanelDomicilio.Visible = True
                Else
                    Me.PanelDomicilio.Visible = False
                End If
            Catch ex As Exception
                UtilLogBase.Guardar(Tsu.Entity.LogBase.TipoLog.ErrorMAP, cuenta, "Control CabRevend.ascx/MostrarDomicilio: " & ex.Message.ToString())
            End Try
        End Sub

#End Region

    End Class
End Namespace

