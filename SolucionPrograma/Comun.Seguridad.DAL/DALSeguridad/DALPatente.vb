Imports System.Data
Imports System.Data.SqlClient 

Public Class DALPatente

    Dim Conectividad As Conector
    Public Sub New()
        Conectividad = New Conector()
    End Sub

    Public Function ListarObjetos() As List(Of String)
        Dim ListaObjetos As New List(Of String)
        Dim dt As DataTable = Conectividad.MostrarDataTable("select * from seg_objeto", Nothing)

        For Each fila As DataRow In dt.Rows
            ListaObjetos.Add(fila("Objeto_Descripcion").ToString())
        Next
        Return ListaObjetos
    End Function

    Public Function ListarAcciones() As List(Of String)
        Dim ListaAcciones As New List(Of String)
        Dim dt As DataTable = Conectividad.MostrarDataTable("select * from seg_accion", Nothing)

        For Each fila As DataRow In dt.Rows
            ListaAcciones.Add(fila("Accion_Descripcion").ToString())
        Next
        Return ListaAcciones
    End Function
#Region "CRUD"

    Public Sub EliminarPatente(ByVal PatenteId As Integer)
        Try
            Dim ParPatente As New SqlParameter("@patente_id", SqlDbType.Int, 0)
            ParPatente.Value = PatenteId
            Conectividad.EjecutarComando("delete seg_patente where patente_id=@patente_id", New SqlParameter() {ParPatente})
        Catch ex As DALExceptionFK
            Throw ex
        End Try

    End Sub

    Public Sub InsertarPatente(ByVal descripcion As String, ByVal ObjetoId As Integer, ByVal AccionId As Integer)
        Try
            Dim ParObj As New SqlParameter("@objeto_id", SqlDbType.Int, 0)
            ParObj.Value = ObjetoId
            Dim ParAccion As New SqlParameter("@accion_id", SqlDbType.Int, 0)
            ParAccion.Value = AccionId
            Dim ParDescripcion As New SqlParameter("@descripcion", SqlDbType.VarChar, 50)
            ParDescripcion.Value = descripcion
            Conectividad.EjecutarComando("insert into seg_patente values(@descripcion,@objeto_id,@accion_id)", New SqlParameter() {ParDescripcion, ParObj, ParAccion})
        Catch ex As Exception

        End Try

    End Sub

    Public Function ListarPatentes() As List(Of Patente)
        Dim ListaPatentes As New List(Of Patente)
        Dim dt As DataTable = Conectividad.MostrarDataTable("select * from seg_patente", Nothing)

        For Each fila As DataRow In dt.Rows
            ListaPatentes.Add(ConstruirObjConRegistro(fila))
        Next
        Return ListaPatentes
    End Function

#End Region

#Region "Patentes"

    Public Function ListarPatentesFamilia(ByVal idFamilia As Integer) As List(Of Patente)
        Dim ParFamilia As New SqlParameter("@familia_id", SqlDbType.Int, 0)
        ParFamilia.Value = idFamilia
        Dim consulta As String = "select * from seg_familiapatente fp inner join seg_patente pat on pat.patente_id=fp.patente_id where familia_id=@familia_id"

        Dim dt As DataTable = Conectividad.MostrarDataTable(consulta, New SqlParameter() {ParFamilia})
        Dim ListaPatentes As New List(Of Patente)
        For Each fila As DataRow In dt.Rows
            ListaPatentes.Add(ConstruirObjConRegistro(fila))
        Next
        Return ListaPatentes
    End Function

    Public Function ListarPatentesUsuario(ByVal Login As String) As List(Of Patente)
        Dim ParLogin As New SqlParameter("@login", SqlDbType.VarChar, 50)
        ParLogin.Value = Login
        'Dim ParFamilia As New SqlParameter("@Id_familia", SqlDbType.Int, 0)
        'ParFamilia.Value = idFamilia
        Dim dt As DataTable = Conectividad.MostrarDataTable("select * from seg_patente  pat inner join seg_usuariopatente upat on pat.patente_id=upat.patente_id where login=@login", New SqlParameter() {ParLogin})
        Dim ListaPatentes As New List(Of Patente)
        For Each fila As DataRow In dt.Rows
            ListaPatentes.Add(ConstruirObjConRegistro(fila))
        Next
        Return ListaPatentes
    End Function

#End Region

#Region "Asignacion a Usuario"

    Public Sub AsignarPatenteUsuario(ByVal Login As String, ByVal PatenteId As Integer)
        Try
            Dim ParPatente As New SqlParameter("@patente_id", SqlDbType.Int, 0)
            ParPatente.Value = PatenteId
            Dim ParLogin As New SqlParameter("@login", SqlDbType.VarChar, 50)
            ParLogin.Value = Login
            Conectividad.EjecutarComando("insert into seg_usuariopatente values(@login,@patente_id)", New SqlParameter() {ParPatente, ParLogin})

        Catch ex As Exception

        End Try

    End Sub

    Public Sub DesAsignarPatenteUsuario(ByVal Login As String, ByVal PatenteId As Integer)
        Try
            Dim ParPatente As New SqlParameter("@patente_id", SqlDbType.Int, 0)
            ParPatente.Value = PatenteId
            Dim ParLogin As New SqlParameter("@login", SqlDbType.VarChar, 50)
            ParLogin.Value = Login
            Conectividad.EjecutarComando("delete seg_usuariopatente where login=@login and patente_id=@patente_id", New SqlParameter() {ParPatente, ParLogin})
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Asignacion a Familia"

    Public Sub AsignarPatenteFamilia(ByVal FamiliaId As String, ByVal PatenteId As Integer)
        Try
            Dim ParPatente As New SqlParameter("@patente_id", SqlDbType.Int, 0)
            ParPatente.Value = PatenteId
            Dim ParFamilia As New SqlParameter("@familia_id", SqlDbType.VarChar, 50)
            ParFamilia.Value = FamiliaId
            Conectividad.EjecutarComando("insert into seg_familiapatente values(@familia_id,@patente_id)", New SqlParameter() {ParPatente, ParFamilia})

        Catch ex As Exception

        End Try
    End Sub

    Public Sub DesAsignarPatenteFamilia(ByVal FamiliaId As Integer, ByVal PatenteId As Integer)
        Try
            Dim ParPatente As New SqlParameter("@patente_id", SqlDbType.Int, 0)
            ParPatente.Value = PatenteId
            Dim ParFamilia As New SqlParameter("@familia_id", SqlDbType.VarChar, 50)
            ParFamilia.Value = FamiliaId
            Conectividad.EjecutarComando("delete seg_familiapatente where familia_id=@familia_id and patente_id=@patente_id", New SqlParameter() {ParPatente, ParFamilia})
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Metodos Privados"

    Private Function ConstruirObjConRegistro(ByVal fila As DataRow) As Patente
        Dim UnaPatente As New Patente(fila("patente_id"), fila("patente_descripcion"), fila("accion_id"), fila("objeto_id"))
        Return UnaPatente
    End Function

#End Region


End Class
