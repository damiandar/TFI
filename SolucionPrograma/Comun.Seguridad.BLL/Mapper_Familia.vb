
Public Class Mapper_Familia

    Dim dataProvider As DALFamilia

    Public Sub New()
        dataProvider = New DALFamilia
    End Sub

#Region "CRUD"

    ''' <summary>
    ''' Muestra una familia 
    ''' </summary>
    ''' <param name="IdFamilia"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MuestraUnaFamilia(ByVal IdFamilia As Integer) As Familia
        Return dataProvider.MuestraUnaFamilia(IdFamilia)
    End Function

    ''' <summary>
    ''' Muestra el listado de familias
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Muestralistafamilia() As List(Of Familia)
        Return dataProvider.muestralistafamilia()
    End Function

    ''' <summary>
    ''' Inserta una familia
    ''' </summary>
    ''' <param name="UnaFamilia"></param>
    ''' <remarks></remarks>
    Public Sub InsertaFamilia(ByVal UnaFamilia As Familia)
        dataProvider.InsertarFamilia(UnaFamilia)
    End Sub

    Public Sub EliminarFamilia(ByVal idFamilia As Integer)
        dataProvider.EliminarFamilia(idFamilia)
    End Sub

    Public Sub ModificarFamilia(ByVal UnaFamilia As Familia)
        dataProvider.ModificarFamilia(UnaFamilia)
    End Sub

#End Region

#Region "Asignar/DesAsignar Roles"

    ''' <summary>
    ''' Muestra la familia del usuario seleccionado.
    ''' </summary>
    ''' <param name="Login"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MostrarFamiliaUsuario(ByVal Login As String) As Familia
        Try
            Return dataProvider.MostrarFamiliaUsuario(Login)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Modifica la familia del usuario
    ''' </summary>
    ''' <param name="Login"></param>
    ''' <param name="idFamilia"></param>
    ''' <remarks></remarks>
    Public Sub ModificarRolUsuario(ByVal Login As String, ByVal idFamilia As Integer)
        Try
            dataProvider.ModificarFamiliaUsuario(Login, idFamilia)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Asigna la familia al usuario
    ''' </summary>
    ''' <param name="idFamilia"></param>
    ''' <param name="login"></param>
    ''' <remarks></remarks>
    Public Sub AsignarRol(ByVal idFamilia As Integer, ByVal login As String)
        Try
            dataProvider.AsignarFamilia(idFamilia, login)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



#End Region

End Class
