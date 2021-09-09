Imports Tsu.ProviderOra

Imports Tsu.Seguridad

Namespace Tsu.Paginas

    Public Class controles_MenuSuperior
        Inherits System.Web.UI.UserControl

        Dim _Rol As String

        Public Property Rol() As String
            Get
                Return _Rol
            End Get
            Set(ByVal value As String)
                _Rol = value
            End Set
        End Property

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
               
                Me.Rol = "R"


                Dim Item2 As New MenuItem("DATOS PERSONALES", "", "", "../micuenta/datospersonales.aspx")
                Dim Item3 As New MenuItem("SOLICITUD DE COMPRA", "", "", "../micarga/catalogos.aspx")
                Dim Item4 As New MenuItem("CONSULTAS", "", "", "../micarga/consultas.aspx") 
                Dim Item6 As New MenuItem("ADMINISTRACION", "", "", "../Administracion/bitacora.aspx")
                Dim Item7 As New MenuItem("PEDIDO PERSONAL", "", "", "../micarga/solicitudcompra.aspx")
                Dim Item8 As New MenuItem("REVENDEDORAS", "", "", "../revendedoras/grupos.aspx")
                Dim Item9 As New MenuItem("AYUDA", "", "", "../aplicacion/preguntasfrecuentes.aspx")
                'Dim Item10 As New MenuItem("CONTACTO", "", "", "../aplicacion/contacto.aspx")
                Dim Item11 As New MenuItem("CONSULTAS", "", "", "../informes/evolucionpedidos.aspx")
                Dim Item12 As New MenuItem("AYUDA", "", "", "../aplicacion/preguntasfrecuentes.aspx")
                Dim Item13 As New MenuItem("AYUDA", "", "", "../aplicacion/preguntasfrecuentes.aspx")
                Dim Item14 As New MenuItem("CONSULTAS", "", "", "../tmk/estadosesion.aspx")
                'Item9.Target = "_blank"

                Menu55.Items.Clear()
 

                If Rol = "R" Then
                    Menu55.Items.Add(Item6)
                    Menu55.Items.Add(Item2)
                    Menu55.Items.Add(Item3)
                    Menu55.Items.Add(Item4)
                End If

        

        
            Catch ex As Exception
                '  Utilidades.UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, Session("cuenta"), String.Format("MenuSuperior:{0}", ex.Message.ToString()))
                Response.Redirect("~/login.aspx")
            End Try

        End Sub

    End Class
End Namespace