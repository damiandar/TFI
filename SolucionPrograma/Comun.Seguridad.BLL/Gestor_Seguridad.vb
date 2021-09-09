
Public Class Gestor_Seguridad
    Public Enum Encriptacion
        Propia
        SHA1
    End Enum

    Private pEncriptacion As Encriptacion

    Public Sub New()
        pEncriptacion = Encriptacion.Propia
    End Sub

    Public Sub New(ByVal tipoEncriptacion As Encriptacion)
        pEncriptacion = tipoEncriptacion
    End Sub

    Public Sub CambiarPass(ByVal Login As String, ByVal sContrasenia As String, ByVal ContraseniaNueva As String)
        If sContrasenia <> ContraseniaNueva Then
            Throw New Exception("Las contraseñas deben ser iguales.")
        End If
        If sContrasenia.Length = 0 Or ContraseniaNueva.Length = 0 Then
            Throw New Exception("Debe ingresar las contraseñas correctamente.")
        End If
        If Login.Length < 5 Then
            Throw New Exception("El usuario debe tener como minimo 5 caracteres.")
        End If
        If Login.Length > 50 Then
            Throw New Exception("El usuario debe tener como maximo 50 caracteres.")
        End If
        If sContrasenia.Length < 5 Or ContraseniaNueva.Length < 5 Then
            Throw New Exception("La contraseña debe tener como minimo 5 caracteres.")
        End If
        If sContrasenia.Length > 8 Or ContraseniaNueva.Length > 8 Then
            Throw New Exception("La contraseña debe tener como maximo 8 caracteres.")
        End If

        Dim GestorUsuarios As New Mapper_Usuario(pEncriptacion)
        Dim UnUsuario As New Usuario
        UnUsuario = GestorUsuarios.ValidarCredenciales(Login, sContrasenia)
        If UnUsuario IsNot Nothing Then
            UnUsuario.Contrasenia = ContraseniaNueva
            UnUsuario.Estado = 1
            GestorUsuarios.ModificaUsuario(UnUsuario)
            Dim GestorDVV As New Mapper_DigitoVerificador()
            GestorDVV.ActualizarDigitoVerificador("seg_usuario")
        Else
            Throw New Exception("Contraseña actual incorrecta")
        End If
    End Sub

    Public Function ValidarCredenciales(ByVal Login As String, ByVal sContrasenia As String) As Usuario
        Try
            If Login.Length < 5 Then
                Throw New Exception("El usuario debe tener como minimo 5 caracteres.")
            End If
            If Login.Length > 50 Then
                Throw New Exception("El usuario debe tener como maximo 50 caracteres.")
            End If
            If sContrasenia.Length < 5 Then
                Throw New Exception("La contraseña debe tener como minimo 5 caracteres.")
            End If
            If sContrasenia.Length > 8 Then
                Throw New Exception("La contraseña debe tener como maximo 8 caracteres.")
            End If


            Dim GestorUsuarios As New Mapper_Usuario(pEncriptacion)
            Return GestorUsuarios.ValidarCredenciales(Login, sContrasenia)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Function VerificarPermisos(ByVal Login As String, ByVal objeto As Patente.eObjeto, ByVal accion As Patente.eAccion) As Boolean
        Dim Permitido As Boolean = False
        Dim GestorFamilia As New Mapper_Familia()
        Dim UnaFamilia As Familia = GestorFamilia.MostrarFamiliaUsuario(Login)
        Dim GestorPatentes As New Mapper_Patente()
        Dim ListaPatentes As List(Of Patente) = GestorPatentes.ListarPatentesFamilia(UnaFamilia.IdFamilia)
        Dim ListaPatentesUsuario As List(Of Patente) = GestorPatentes.ListarPatentesUsuario(Login)

        If ListaPatentesUsuario IsNot Nothing Then
            ListaPatentes.AddRange(ListaPatentesUsuario)
        End If

        Dim ListaResultado As New List(Of Patente)
        ListaResultado = ListaPatentes.FindAll(Function(x) x.AccionAplicacion = accion And x.ObjetoAplicacion = objeto)
        If ListaResultado.Count > 0 Then
            Permitido = True
        End If
        Return Permitido
    End Function

End Class
