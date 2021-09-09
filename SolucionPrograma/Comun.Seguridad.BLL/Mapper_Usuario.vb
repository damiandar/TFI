Imports System.Security.Cryptography

Public Class Mapper_Usuario

    Public Enum Encriptacion
        Propia
        SHA1
    End Enum
    Dim dataProvider As DALUsuario

    Private pEncriptacion As Encriptacion

    Public Sub New()
        dataProvider = New DALUsuario
        pEncriptacion = Encriptacion.Propia
    End Sub

    Public Sub New(ByVal TipoEncriptacion As Encriptacion)
        dataProvider = New DALUsuario
        pEncriptacion = TipoEncriptacion
    End Sub

#Region "CRUD"

    Public Function InsertarUsuario(ByVal UnUsuario As Usuario) As Integer
        UnUsuario.Contrasenia = Encripta(UnUsuario.Contrasenia)
        validarDatos(UnUsuario)
        Return dataProvider.InsertarUsuario(UnUsuario)
    End Function

    Public Function ModificaUsuario(ByVal UnUsuario As Usuario) As Boolean
        UnUsuario.Contrasenia = Encripta(UnUsuario.Contrasenia)
        validarDatos(UnUsuario)
        Return dataProvider.ModificaUsuario(UnUsuario)
    End Function

    Public Sub EliminaUsuario(ByVal login As String)
        dataProvider.EliminaUsuario(login)
    End Sub

    Public Function MuestraUnUsuario(ByVal Login As String) As Usuario

        If Login.Length <= 0 Then
            Throw New Exception("Error: Login de usuario invalido")
        End If
        Dim UnUsuario As Usuario = dataProvider.MuestraUnUsuario(Login)
        If UnUsuario IsNot Nothing Then
            UnUsuario.Contrasenia = DesEncripta(UnUsuario.Contrasenia)
        End If

        Return UnUsuario
    End Function

    Public Function MuestraListado() As List(Of Usuario)
        Return dataProvider.MuestraListado()
    End Function

#End Region


    Public Function ValidarCredenciales(ByVal Login As String, ByVal sContrasenia As String) As Usuario
        If Login = "" Then
            Throw New Exception("Debe ingresar un usuario")
        End If

        If sContrasenia = "" Then
            Throw New Exception("Debe ingresar una contrasenia")
        End If

        Return dataProvider.ValidarCredenciales(Login, Encripta(sContrasenia))
    End Function

#Region "Validaciones"

    Protected Sub validarDatos(ByVal UnUsuario As Usuario)

        If UnUsuario Is Nothing Then
            Throw New Exception("Error: Objeto usuario vacio")
        End If

    End Sub


#End Region

#Region "Metodos Privados"

    Private Function Encripta(ByVal Pass As String) As String
        Dim PassEncriptado As String = ""
        If pEncriptacion = Encriptacion.Propia Then
            PassEncriptado = EncriptaPropio(Pass)
        Else
            PassEncriptado = EncriptaSHA1(Pass)
        End If

        Return PassEncriptado
    End Function

    Private Function DesEncripta(ByVal Pass As String) As String
        Dim Clave As String, i As Integer, Pass2 As String
        Dim CAR As String, Codigo As String
        Dim j As Integer
        Clave = "%<&/@#$A"
        Pass2 = ""
        j = 1
        For i = 1 To Len(Pass) Step 2
            CAR = Mid(Pass, i, 2)
            Codigo = Mid(Clave, ((j - 1) Mod Len(Clave)) + 1, 1)
            Pass2 = Pass2 & Chr(Asc(Codigo) Xor Val("&h" + CAR))
            j = j + 1
        Next i
        DesEncripta = Pass2
    End Function

    Private Function EncriptaPropio(ByVal Pass As String) As String

        Dim Clave As String, i As Integer, Pass2 As String

        Dim CAR As String, Codigo As String

        Clave = "%<&/@#$A"

        Pass2 = ""

        For i = 1 To Len(Pass)

            CAR = Mid(Pass, i, 1)

            Codigo = Mid(Clave, ((i - 1) Mod Len(Clave)) + 1, 1)

            Pass2 = Pass2 & Right("0" & Hex(Asc(Codigo) Xor Asc(CAR)), 2)

        Next i

        EncriptaPropio = Pass2

    End Function

    Private Function EncriptaSHA1(ByVal pContrasena As String) As String
        Dim data(10) As Byte
        'Dim result() As Byte
        Dim sha As SHA1 = SHA1.Create
        data = System.Text.Encoding.ASCII.GetBytes(pContrasena)
        EncriptaSHA1 = Convert.ToBase64String(sha.ComputeHash(data))
    End Function
#End Region

End Class
