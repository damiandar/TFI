
Imports Tsu.ProviderOra
Imports Tsu.Utilidades
Imports Tsu.Seguridad

Namespace Tsu.Paginas


    Partial Class aplicacion_cambioclave
        Inherits System.Web.UI.Page
 
        Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnConfirmar.Click
            Dim iCuenta As Integer = Convert.ToInt32(Session("login"))

            If Page.IsValid Then
                Try
               
                    Dim GestorSeguridad As New Gestor_Seguridad()
                    GestorSeguridad.CambiarPass(iCuenta, tbContraseniaActual.Text, tbContraseniaNueva.Text)
                    Dim resultado As Integer = 0
                    If resultado = 0 Then
                        lblError.Text = "La contraseña actual es incorrecta"
                        panelexito.Visible = False
                    Else
                        lblError.Text = ""
                        panel.Visible = False
                        panelexito.Visible = True 
                        Mapper_Bitacora.GuardarBitacora(Session("login"), Patente.eObjeto.USUARIO, Patente.eAccion.CAMBIOCONTRASENIA, String.Format("Cambio: {0}", Session("login")), False)

                    End If
                Catch ex As Exception
                    'muestro el error
                    lblError.Text = "Error al cambiar la clave."
                    panelexito.Visible = False
                    'UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Convert.ToInt32(Session("cuenta")), "CambioClave/confirmar:" & ex.Message.ToString())
                End Try

            End If
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            tbContraseniaActual.Focus()
        End Sub
 
    End Class
End Namespace