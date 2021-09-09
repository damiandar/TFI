
Imports Tsu.ProviderOra
Imports Tsu.Seguridad
Imports Tsu.Utilidades

Imports System.Web.Configuration

Namespace Tsu.Paginas

    Public Class controles_cabecera
        Inherits System.Web.UI.UserControl

        Dim TiempoTolerancia As Integer = Convert.ToInt32(WebConfigurationManager.AppSettings("TiempoTolerancia"))

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                If Not Page.IsPostBack Then
                    ViewState("paso") = False
                End If

                lblReloj.Text = Format(Now, "dd/MM/yyyy   HH:mm")

      
            Catch ex As System.Threading.ThreadAbortException
                'SubProceso anulado por el redirect.
            Catch ex As Exception
                'UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Session("cuenta"), "cabecera:" & ex.Message.ToString())
            End Try
        End Sub

#Region "LLenado de controles"

        Private Sub AsignarRutasImagenes(ByVal campania As Integer)
            Me.imagencalendario.ImageUrl = String.Format(" ", campania)
            Me.BotonCatalogo.OnClientClick = String.Format("window.open(' ', '_blank', 'width=640,height=480,scrollbars=yes,status=no,resizable=yes,screenx=0,screeny=0');", campania.ToString().Substring(4))
        End Sub

#End Region

    End Class
End Namespace
