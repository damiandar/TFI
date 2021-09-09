Imports System.Data
Imports System.Data.SqlClient 


Public Class DALFamilia
    Dim Conectividad As Conector
    Public Sub New()
        Conectividad = New Conector()
    End Sub

#Region "CRUD"

    Public Function MuestraListaFamilia() As List(Of Familia)
        Try
            Dim dt As DataTable = Conectividad.MostrarDataTable("select * from seg_familia where familia_estado=1", Nothing)
            Dim ListaFamilia As New List(Of Familia)
            If dt.Rows.Count > 0 Then
                For Each fila As DataRow In dt.Rows
                    ListaFamilia.Add(ConstruirObjConRegistro(fila))
                Next
            End If
            Return ListaFamilia
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function MuestraUnaFamilia(ByVal IdFamilia As Integer) As Familia

        Dim ParID As New SqlParameter("@familia_id", SqlDbType.Int, 0)
        ParID.Value = IdFamilia

        Dim dt As DataTable = Conectividad.MostrarDataTable("select * from seg_familia where familia_estado=1 and familia_id=@familia_id", New SqlParameter() {ParID})

        Dim oFamilia As New Familia()
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                oFamilia = ConstruirObjConRegistro(fila)
            Next
        End If

        Return oFamilia
    End Function

    Public Sub EliminarFamilia(ByVal idFamilia As Integer)
        Dim ParID As New SqlParameter("@Id_familia", SqlDbType.Int, 0)
        ParID.Value = idFamilia
        Conectividad.EjecutarComando("Update seg_familia set familia_estado=0 where familia_id=@id_familia", New SqlParameter() {ParID})

    End Sub

    Public Sub ModificarFamilia(ByVal UnaFamilia As Familia)
        Dim ParDesc As New SqlParameter("@descripcion", SqlDbType.VarChar, 50)
        ParDesc.Value = UnaFamilia.Descripcion
        Dim ParNombre As New SqlParameter("@Nombre", SqlDbType.VarChar, 50)
        ParNombre.Value = UnaFamilia.Nombre
        Dim ParID As New SqlParameter("@Id_familia", SqlDbType.Int, 0)
        ParID.Value = UnaFamilia.IdFamilia

        Conectividad.EjecutarComando("Update seg_familia set familia_nombre=@nombre, familia_descripcion=@descripcion where familia_id=@id_familia", New SqlParameter() {ParNombre, ParDesc, ParID})


    End Sub

    Public Sub InsertarFamilia(ByVal VFamilia As Familia)

        Dim ParID As New SqlParameter("@Id_familia", SqlDbType.Int, 0)
        ParID.Value = VFamilia.IdFamilia

        Dim ParNombre As New SqlParameter("@Nombre", SqlDbType.VarChar, 50)
        ParNombre.Value = VFamilia.Nombre
        Dim ParDesc As New SqlParameter("@descripcion", SqlDbType.VarChar, 50)
        ParDesc.Value = VFamilia.Descripcion
        Dim ParEstado As New SqlParameter("@estado", SqlDbType.Bit, 0)
        ParEstado.Value = VFamilia.Estado

        Conectividad.EjecutarComando("INSERT into seg_Familia Values(@Nombre,@descripcion,1)", New SqlParameter() {ParNombre, ParEstado})

    End Sub

#End Region


#Region "Asignar/DesAsignar Roles"

    Public Function MostrarFamiliaUsuario(ByVal Login As String) As Familia
        Try
            Dim ParLogin As New SqlParameter("@login", SqlDbType.VarChar, 20)
            ParLogin.Value = Login
            Dim dt As DataTable = Conectividad.MostrarDataTable("select * from seg_familia f inner join seg_UsuarioFamilia uf on  f.familia_Id=uf.familia_Id  where login=@login", New SqlParameter() {ParLogin})
            Dim UnaFamilia As New Familia()

            If dt.Rows.Count > 0 Then
                For Each fila As DataRow In dt.Rows
                    UnaFamilia = ConstruirObjConRegistro(fila)
                Next
            End If

            Return UnaFamilia
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ModificarFamiliaUsuario(ByVal Login As String, ByVal idFamilia As Integer)
        Dim ParFamilia As New SqlParameter("@IdFamilia", SqlDbType.Int, 0)
        ParFamilia.Value = idFamilia
        Dim ParUsuario As New SqlParameter("@login", SqlDbType.VarChar, 20)
        ParUsuario.Value = Login
        Conectividad.EjecutarComando("Update seg_usuariofamilia set familia_id=@idfamilia where login=@login", New SqlParameter() {ParFamilia, ParUsuario})
    End Sub

    Public Sub AsignarFamilia(ByVal idFamilia As Integer, ByVal Login As String)
        Dim ParFamilia As New SqlParameter("@IdFamilia", SqlDbType.Int, 0)
        ParFamilia.Value = idFamilia
        Dim ParUsuario As New SqlParameter("@login", SqlDbType.VarChar, 50)
        ParUsuario.Value = Login
        Conectividad.EjecutarComando("INSERT into seg_UsuarioFamilia(login,Familia_id) Values(@login,@IdFamilia)", New SqlParameter() {ParFamilia, ParUsuario})
    End Sub

#End Region

#Region "Metodos Privados"

    Protected Function ConstruirObjConRegistro(ByVal fila As DataRow) As Familia
        Dim oFamilia As New Familia()
        oFamilia.IdFamilia = fila("familia_id")
        oFamilia.Nombre = fila("familia_nombre")
        oFamilia.Descripcion = fila("familia_descripcion")
        oFamilia.Estado = fila("familia_estado")
        Return oFamilia
    End Function

#End Region

End Class
