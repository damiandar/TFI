Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography

Public Class DALUsuario
    Dim Conectividad As Conector
    Public Sub New()
        Conectividad = New Conector()
    End Sub

    ''' <summary>
    ''' Autentica al usuario en el sistema.
    ''' </summary>
    ''' <param name="Login"></param>
    ''' <param name="sContrasenia"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarCredenciales(ByVal Login As String, ByVal sContrasenia As String) As Usuario
        Dim ParLogin As New SqlParameter("@login", SqlDbType.VarChar, 50)
        ParLogin.Value = Login

        Dim ParPass As New SqlParameter("@Contrasenia", SqlDbType.VarChar, 50)
        'encripto la contraseña
        ParPass.Value = sContrasenia
        Dim oUsuario As Usuario = Nothing

        Dim dt As DataTable = Conectividad.MostrarDataTable(" SELECT * from seg_usuario usuario " & _
  " inner join Seg_UsuarioFamilia uf on usuario.Login=uf.Login " & _
  " inner join Seg_Familia Familia on uf.Familia_id=familia.familia_id where usuario.Login=@login and Contrasenia=@Contrasenia", New SqlParameter() {ParLogin, ParPass})
        If dt.Rows.Count > 0 Then
            oUsuario = ConstruirObjConRegistro(dt.Rows(0), True)
        End If 
        Return oUsuario
    End Function

#Region "CRUD"

    Public Function MuestraUnUsuario(ByVal login As String) As Usuario
        Dim ParLogin As New SqlParameter("@login", SqlDbType.VarChar, 20)
        ParLogin.Value = login

        Dim dt As DataTable = Conectividad.MostrarDataTable(" SELECT * from seg_usuario usuario " & _
  " inner join Seg_UsuarioFamilia uf on usuario.Login=uf.Login " & _
  " inner join Seg_Familia Familia on uf.Familia_id=familia.familia_id where usuario.login=@login", New SqlParameter() {ParLogin})
        Dim UnUsuario As New Usuario

        If dt.Rows.Count > 0 Then
            UnUsuario = ConstruirObjConRegistro(dt.Rows(0), True)
        Else
            UnUsuario = Nothing
        End If
        Return UnUsuario
    End Function

    Public Function MuestraListado() As List(Of Usuario)
        Dim nuevoReader As DataTable = Conectividad.MostrarDataTable(" SELECT * from seg_usuario usuario " & _
  " inner join Seg_UsuarioFamilia uf on usuario.Login=uf.Login " & _
  " inner join Seg_Familia Familia on uf.Familia_id=familia.familia_id and estado=1 ", Nothing)

        Dim ListaUsuarios As New List(Of Usuario)

        For Each fila As DataRow In nuevoReader.Rows
            ListaUsuarios.Add(ConstruirObjConRegistro(fila, False))
        Next

        Return ListaUsuarios
    End Function

    Public Function InsertarUsuario(ByVal UnUsuario As Usuario) As Integer
        Dim ParLogin As New SqlParameter("@login", SqlDbType.VarChar, 50)
        ParLogin.Value = UnUsuario.Login

        UnUsuario.Contrasenia = UnUsuario.Contrasenia
        Dim ParPass As New SqlParameter("@Contrasenia", SqlDbType.VarChar, 50)
        'encripto la contraseña
        ParPass.Value = UnUsuario.Contrasenia

        Dim ParNombre As New SqlParameter("@nombre", SqlDbType.VarChar, 50)
        ParNombre.Value = UnUsuario.Nombre
        Dim ParDV As New SqlParameter("@digitoverificador", SqlDbType.Int, 0)
        ParDV.Value = CalcularDigitoVerificador(UnUsuario)

        Return Conectividad.EjecutarComando("insert into seg_usuario (login,contrasenia,Nombre,FechaAlta,estado,bloqueo,digitoverificador) values(@login,@Contrasenia,@nombre,getdate(),1,0,@digitoverificador)", New SqlParameter() {ParDV, ParLogin, ParNombre, ParPass})

    End Function

    Public Function ModificaUsuario(ByVal UnUsuario As Usuario) As Boolean
        Dim ParNombre As New SqlParameter("@nombre", SqlDbType.VarChar, 20)
        ParNombre.Value = UnUsuario.Nombre

        Dim ParLogin As New SqlParameter("@login", SqlDbType.VarChar, 50)
        ParLogin.Value = UnUsuario.Login

        Dim ParEstado As New SqlParameter("@estado", SqlDbType.Bit, 0)
        ParEstado.Value = UnUsuario.Estado

        UnUsuario.Contrasenia = UnUsuario.Contrasenia
        Dim ParPass As New SqlParameter("@Contrasenia", SqlDbType.VarChar, 50)
        'encripto la contraseña
        ParPass.Value = UnUsuario.Contrasenia

        Dim ParDV As New SqlParameter("@digitoverificador", SqlDbType.Int, 0)
        ParDV.Value = CalcularDigitoVerificador(UnUsuario)

        Return Conectividad.EjecutarComando("Update seg_Usuario set nombre=@nombre, contrasenia=@contrasenia, estado=@estado,digitoverificador=@digitoverificador where login=@login", New SqlParameter() {ParDV, ParLogin, ParNombre, ParPass, ParEstado})

    End Function

    Public Sub EliminaUsuario(ByVal Login As String)
        Dim ParLogin As New SqlParameter("@login", SqlDbType.VarChar, 50)
        ParLogin.Value = Login
        Conectividad.EjecutarComando("UPDATE seg_Usuario set estado=0 where login=@login", New SqlParameter() {ParLogin})
    End Sub

#End Region


#Region "Metodos Privados"

    Private Function CalcularDigitoVerificador(ByVal UnUsuario As Usuario) As Double
        Dim Indice As Integer
        Dim VDigitoVerificador As Double = 0
        Dim VRegistro As String = Trim(UnUsuario.Login.ToString()) & Trim(UnUsuario.Nombre.ToString()) & Trim(UnUsuario.Contrasenia.ToString())
        For Indice = 1 To Len(VRegistro)
            VDigitoVerificador += Asc(Mid(VRegistro.ToString, Indice, 1))
        Next
        Return VDigitoVerificador
    End Function 

    Protected Function ConstruirObjConRegistro(ByVal fila As DataRow, ByVal MostrarPatente As Boolean) As Usuario
        Dim oUsuario As New Usuario()
        oUsuario.Login = fila("Login").ToString()
        oUsuario.Contrasenia = fila("contrasenia").ToString()
        oUsuario.Bloqueado = fila("Bloqueo")
        oUsuario.Nombre = fila("Nombre").ToString()
        oUsuario.Estado = fila("estado")
        oUsuario.FechaAlta = fila("fechaalta")
        If MostrarPatente = True Then
            oUsuario.familia = New Familia(CInt(fila("familia_id")), fila("familia_nombre").ToString(), fila("familia_descripcion").ToString())
        End If
        Return oUsuario

    End Function

#End Region

End Class

