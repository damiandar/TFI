
Imports System.Data
Imports System.Data.SqlClient


Public Class DALIdioma
    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector()
    End Sub

    ''' <summary>
    ''' Muestra todos los idiomas registrados en el sistema.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MuestraListado() As List(Of Idioma)
        Try
            Dim dt As DataTable = Conectividad.MostrarDataTable("Select * from sop_Idioma", Nothing)
            Dim ListaIdiomas As New List(Of Idioma)

            For Each fila As DataRow In dt.Rows
                ListaIdiomas.Add(ConstruirObjetoConRegistro(fila))
            Next
            Return ListaIdiomas
        Catch ex As DALExceptionCritica
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Agrega un nuevo idioma al sistema.
    ''' </summary>
    ''' <param name="sNuevoIdioma"></param>
    ''' <remarks></remarks>
    Public Sub Nuevo(ByVal sNuevoIdioma As String)
        Dim ParNombre As SqlParameter
        ParNombre = New SqlParameter
        ParNombre.ParameterName = "@nombre"
        ParNombre.DbType = DbType.String
        ParNombre.Value = sNuevoIdioma

        Conectividad.EjecutarComando("Insert into sop_idioma values(@nombre)", New SqlParameter() {ParNombre})
    End Sub

    ''' <summary>
    ''' Elimina un idioma del sistema.
    ''' </summary>
    ''' <param name="IdiomaID"></param>
    ''' <remarks></remarks>
    Public Sub Borrar(ByVal IdiomaID As Integer)
        Dim ParId As New SqlParameter("@id_idioma", SqlDbType.Int, 0)
        ParId.Value = IdiomaID

        Conectividad.EjecutarComando("delete sop_idioma where id_idioma=@id_idioma", New SqlParameter() {ParId})
    End Sub

    ''' <summary>
    ''' Muestra el idioma seleccionado.
    ''' </summary>
    ''' <param name="sIdioma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Mostrar(ByVal sIdioma As String) As Integer
   
        Dim ParNombre As SqlParameter
        ParNombre = New SqlParameter
        ParNombre.ParameterName = "@nombre"
        ParNombre.DbType = DbType.String
        ParNombre.Value = sIdioma

        Dim dt As DataTable = Conectividad.MostrarDataTable("select * from sop_idioma where nombre=@nombre", New SqlParameter() {ParNombre})
        Dim id As Integer = Convert.ToInt32(dt.Rows(0).Item("id_idioma").ToString())
        Return id

    End Function

#Region "Metodos Privados"

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Idioma
        Dim UnIdioma As New Idioma()
        UnIdioma.id = fila("Id_idioma")
        UnIdioma.nombre = fila("Nombre")
        Return UnIdioma
    End Function

#End Region

End Class