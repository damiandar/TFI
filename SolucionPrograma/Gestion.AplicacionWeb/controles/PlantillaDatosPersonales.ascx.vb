
Imports Tsu.ProviderOra
Imports Tsu.Utilidades

Namespace Tsu.Paginas

    Partial Class controles_PlantillaDatosPersonales
        Inherits System.Web.UI.UserControl

        Public Event NoEncontroDatos(ByVal Mensaje As String)

        Public Sub LLenar(ByVal cuenta As Integer)
            Try
                Dim iCuenta As Integer = Convert.ToInt32(cuenta)
                'LLenarDatosBasicos(iCuenta)
                'LLenarDatosTransferidosAS(iCuenta)
            Catch ex As Exception
                Response.Write(ex.Message.ToString())
                'UtilLogBase.Guardar(LogBase.TipoLog.ErrorMAP, cuenta, "App/DatosPersonales/LLenar:" & ex.Message.ToString())
            End Try
        End Sub

        Private Sub LLenarDatosBasicos(ByVal iCuenta As Integer)
            Dim oUsuariosMap As New UsuarioMapOra
            Dim oUsuarios As Usuarios = oUsuariosMap.MostrarCabecera(iCuenta)

            ltMail.Text = IIf(oUsuarios.mail.ToString() Is String.Empty, "-", oUsuarios.mail.ToString())
            ltTelefono.Text = IIf(oUsuarios.telefono.ToString() Is String.Empty, "-", oUsuarios.telefono.ToString())
            ltCelular.Text = IIf(oUsuarios.celular = 0, "-", oUsuarios.celular.ToString())
        End Sub

        Private Sub LLenarDatosTransferidosAS(ByVal iCuenta As Integer)
            Dim oDatosUsuariosMap As New DatosUsuariosMapOra
            Dim oDatosUsuarios As DatosUsuarios = oDatosUsuariosMap.MostrarDatosUsuarios(iCuenta)

            If oDatosUsuarios Is Nothing Then
                MostrarDatosVacios() 
                RaiseEvent NoEncontroDatos("La Revendedora que está consultando no se encuentra registrada en el sitio web.")
            Else
                If oDatosUsuarios.codigopostal = 0 And oDatosUsuarios.domicilio1 = "" And oDatosUsuarios.fechanacimiento = 0 And oDatosUsuarios.localidad = "" Then
                    'no están los datos del usuario, mostrar mensaje.....
                    MostrarDatosVacios() 
                    RaiseEvent NoEncontroDatos("Los datos de la Revendedora serán actualizados a la brevedad.")
                Else

                    ltCodigoPostal.Text = oDatosUsuarios.codigopostal
                    ltDomicilio.Text = oDatosUsuarios.domicilio1
                    ltLocalidad.Text = oDatosUsuarios.localidad
                    ltFechaNacimiento.Text = Format(oDatosUsuarios.fechanacimiento, "000000").ToString().Insert(2, "/").Insert(5, "/")
                    ltProvincia.Text = New UtilProvincia().getProvincia(oDatosUsuarios.provincia)
                End If
            End If
        End Sub

        Private Sub MostrarDatosVacios()
            ltCodigoPostal.Text = "-"
            ltDomicilio.Text = "-"
            ltLocalidad.Text = "-"
            ltFechaNacimiento.Text = "-"
            ltProvincia.Text = "-"
        End Sub
    End Class

End Namespace