Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Conector

    Public Enum Tipo
        StoreProcedure
        ConsultaScript
    End Enum

    Dim CadenaConexion As String = ConfigurationManager.ConnectionStrings("BD").ConnectionString.ToString()
    Dim CadenaConexionBackUp As String = ConfigurationManager.ConnectionStrings("BACKUP").ConnectionString.ToString()

    Dim Comando As SqlCommand

    Public Sub New()
        Comando = New SqlCommand()
    End Sub

    Public Sub New(ByVal tipo As Tipo)
        Comando = New SqlCommand()
        If tipo = Conector.Tipo.StoreProcedure Then
            Comando.CommandType = CommandType.StoredProcedure
        End If
    End Sub

    ''' <summary>
    ''' Muestra Un datatable
    ''' </summary>
    ''' <param name="consulta"></param>
    ''' <param name="parametros"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MostrarDataTable(ByVal consulta As String, ByVal parametros() As SqlParameter) As DataTable
        Try
            Dim conexion As New SqlConnection(CadenaConexion)
            Dim da As New SqlDataAdapter()
            'Dim da As New SqlDataAdapter(consulta, conexion)
            Comando.CommandText = consulta
            Comando.Connection = conexion
            da.SelectCommand = Comando

            If parametros IsNot Nothing Then
                da.SelectCommand.Parameters.Clear()
                da.SelectCommand.Parameters.AddRange(parametros)
            End If
            Dim dt As New DataTable()
            conexion.Open()
            da.Fill(dt)
            conexion.Close()
            Return dt


        Catch ex As SqlException When ex.Number = 2627 'Error PK
            Throw New DALExceptionPK("Clave Duplicada")
        Catch ex As SqlException When ex.Number = 26
            Throw New DALException("Clave")
        Catch ex As SqlException When ex.Number = 13 'error en la consulta
            Throw ex
        Catch ex As SqlException When ex.Number = -1
            Throw New DALExceptionCritica(ex.Message.ToString())
        Catch ex As Exception
            Throw New DALExceptionCritica(ex.Message.ToString())
        End Try
    End Function

    ''' <summary>
    ''' Devuelve el número de filas afectadas. Usted puede utilizar el ExecuteNonQuery para realizar operaciones de catálogo (por ejemplo, consultar la estructura de una base de datos o crear objetos como tablas de base de datos), o para cambiar los datos en una base de datos sin necesidad de utilizar un conjunto de datos mediante la ejecución de UPDATE, INSERT o DELETE. 
    ''' Aunque el ExecuteNonQuery no devuelve ninguna fila, los parámetros de salida o los valores devueltos asignados a los parámetros se rellenan con datos. 
    ''' Para UPDATE, INSERT y DELETE, el valor de retorno es el número de filas afectadas por el comando. 
    ''' Cuando existe un desencadenante en una tabla que se está insertado o actualizado, el valor de retorno incluye el número de filas afectadas tanto por la inserción o operación de actualización y el número de filas afectadas por el gatillo o desencadenantes. 
    ''' Para todos los demás tipos de instrucciones, el valor devuelto es -1. Si se produce un rollback, el valor de retorno es también -1.
    ''' </summary>
    ''' <param name="consulta"></param>
    ''' <param name="parametros"></param>
    ''' <returns>Devuelve el número de filas afectadas.</returns>
    ''' <remarks></remarks>
    Public Function EjecutarComando(ByVal consulta As String, ByVal parametros() As SqlParameter) As Integer
        Try
            Using conexion As New SqlConnection(CadenaConexion)
                'Dim comando As New SqlCommand(consulta, conexion)
                Comando.CommandText = consulta
                Comando.Connection = conexion

                If parametros IsNot Nothing Then
                    Comando.Parameters.Clear()
                    Comando.Parameters.AddRange(parametros)
                End If
                conexion.Open()
                Dim id As Integer = comando.ExecuteNonQuery()
                conexion.Close()
                Return id
            End Using
        Catch ex As SqlException When ex.Number = 2627 'Error PK
            Throw New DALExceptionPK("Clave Duplicada")
        Catch ex As SqlException When ex.Number = 547
            Throw New DALExceptionFK("Clave Referenciada")
        Catch ex As SqlException When ex.Number = 13 'error en la consulta
            Throw New DALExceptionCritica(ex.Message.ToString())
        Catch ex As SqlException When ex.Number = -1
            Throw New DALExceptionCritica(ex.Message.ToString())
        Catch ex As SqlException
            Throw New DALExceptionCritica(ex.Message.ToString())
        End Try

    End Function

    ''' <summary>
    ''' Ejecuta la consulta y devuelve la primera columna de la primera fila del conjunto de resultados devuelto por la consulta. 
    ''' Columnas o filas adicionales se ignoran. 
    ''' La primera columna de la primera fila del conjunto de resultados, o una referencia nula (Nothing en Visual Basic) si el conjunto de resultados está vacío. 
    ''' Devuelve un máximo de 2033 caracteres. 
    ''' Utilice el método EjecutarScalar para recuperar un único valor (por ejemplo, un valor agregado) de una base de datos. 
    ''' Esto requiere menos código que utilizar el método MostrarDataTable y, a continuación, realizar las operaciones que usted necesita para generar el valor de un solo uso de los datos devueltos por un SqlDataReader.
    ''' </summary>
    ''' <param name="consulta"></param>
    ''' <param name="parametros"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EjecutarScalar(ByVal consulta As String, ByVal parametros() As SqlParameter) As Object
        Try
            Using conexion As New SqlConnection(CadenaConexion)
                Comando.CommandText = consulta
                Comando.Connection = conexion
                If parametros IsNot Nothing Then
                    Comando.Parameters.Clear()
                    Comando.Parameters.AddRange(parametros)
                End If
                conexion.Open()
                Dim resultado As Object = Comando.ExecuteScalar()
                conexion.Close()
                Return resultado
            End Using
        Catch ex As SqlException When ex.Number = 2627 'Error PK
            Throw New DALExceptionPK("Clave Duplicada")
        Catch ex As SqlException When ex.Number = 13 'error en la consulta
            Throw ex
        Catch ex As SqlException When ex.Number = -1
            Throw New DALExceptionCritica(ex.Message.ToString())
        Catch ex As SqlException
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Ejecuta consulta de backup
    ''' </summary>
    ''' <param name="Ruta"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GuardarBackUp(ByVal Ruta As String) As Integer
        Try
            Using conexion As New SqlConnection(CadenaConexionBackUp)
                Dim Consulta As String = String.Format("BACKUP DATABASE [LAVADERO2] TO  DISK ='{0}' WITH NOFORMAT, NOINIT,  NAME = 'Resguardo completo de base de datos', SKIP, NOREWIND, NOUNLOAD,  STATS = 10", Ruta)
                Dim comando As SqlCommand = New SqlCommand(Consulta, conexion)

                'If parametros IsNot Nothing Then
                '    comando.Parameters.AddRange(parametros)
                'End If
                conexion.Open()
                Dim id As Integer = comando.ExecuteNonQuery()
                conexion.Close()
                Return id
            End Using

        Catch ex As SqlException
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Ejecuta restore de backup
    ''' </summary>
    ''' <param name="Ruta"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RestoreBackUp(ByVal Ruta As String)
        Try
            Using conexion As New SqlConnection(CadenaConexionBackUp)
                Dim Consulta As String = String.Format("ALTER DATABASE [BD] SET OFFLINE with rollback immediate RESTORE DATABASE BD FROM DISK ='{0}' WITH REPLACE;", Ruta)
                Dim comando As SqlCommand = New SqlCommand(Consulta, conexion)

                'If parametros IsNot Nothing Then
                '    comando.Parameters.AddRange(parametros)
                'End If
                conexion.Open()
                Dim id As Integer = comando.ExecuteNonQuery()
                conexion.Close()
                Return id
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

End Class

