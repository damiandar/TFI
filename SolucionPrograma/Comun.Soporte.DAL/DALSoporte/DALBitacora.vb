Imports System.Data
Imports System.Data.SqlClient


Public Class DALBitacora
    Dim Conectividad As Conector
    Public Sub New()
        Conectividad = New Conector()
    End Sub

    ''' <summary>
    ''' Inserta la bitacora, en donde indica el usuario que estaba usando el sistema, la pantalla y la accion que realizo. Si el ultimo bit esta en true significa que es un error.
    ''' </summary>
    ''' <param name="Login"></param>
    ''' <param name="objeto"></param>
    ''' <param name="accion"></param>
    ''' <param name="evento"></param>
    ''' <param name="esError"></param>
    ''' <remarks></remarks>
    Public Sub InsertarBitacora(ByVal Login As String, ByVal objeto As String, ByVal accion As String, ByVal evento As String, ByVal esError As Boolean)
        Dim ParEvento As New SqlParameter("@bitacora_evento", SqlDbType.VarChar, 50)
        ParEvento.Value = evento
        Dim ParLogin As New SqlParameter("@login", SqlDbType.VarChar, 100)
        ParLogin.Value = Login
        Dim ParObjeto As New SqlParameter("@objeto_id", SqlDbType.Int, 0)
        ParObjeto.Value = objeto
        Dim ParAccion As New SqlParameter("@accion_id", SqlDbType.Int, 0)
        ParAccion.Value = accion
        Dim ParEsError As New SqlParameter("@bitacora_esError", SqlDbType.Bit, 0)
        ParEsError.Value = esError

        Conectividad.EjecutarComando("INSERT into sop_bitacora(bitacora_evento,login,objeto_id,accion_id,bitacora_fecha,bitacora_esError) Values(@bitacora_evento,@login,@objeto_id,@accion_id,getdate(),@bitacora_esError)", New SqlParameter() {ParObjeto, ParAccion, ParEsError, ParEvento, ParLogin})
    End Sub

    Public Function MuestraListado(ByVal Login As String, ByVal obj As Patente.eObjeto, ByVal accion As Patente.eAccion, ByVal FechaDesde As Date, ByVal FechaHasta As Date) As List(Of Bitacora)
        Try
            Dim dia As String = FechaDesde.Date.ToString()

            Dim ParLogin As New SqlParameter("@login", SqlDbType.VarChar, 100)
            ParLogin.Value = IIf(Login.Length = 0, DBNull.Value, Login)
            Dim ParObjeto As New SqlParameter("@objeto_id", SqlDbType.Int, 0)
            ParObjeto.Value = IIf(obj = Patente.eObjeto.SINOBJETO, DBNull.Value, obj)
            Dim ParAccion As New SqlParameter("@accion_id", SqlDbType.Int, 0)
            ParAccion.Value = IIf(accion = Patente.eAccion.SINACCION, DBNull.Value, accion)
            Dim ParFechaDesde As New SqlParameter("@fecha_desde", SqlDbType.DateTime, 0)

            If FechaDesde.Date.Year = 1 Then
                ParFechaDesde.Value = DBNull.Value
            Else
                ParFechaDesde.Value = FechaDesde
            End If
            Dim ParFechaHasta As New SqlParameter("@fecha_hasta", SqlDbType.DateTime, 0)
            If FechaHasta.Date.Year = 1 Then
                ParFechaHasta.Value = DBNull.Value
            Else
                ParFechaHasta.Value = FechaHasta
            End If

            Dim nuevoReader As DataTable = Conectividad.MostrarDataTable("Select * from sop_bitacora where login=isnull(@login,login) and objeto_id=isnull(@objeto_id,objeto_id) and accion_id=isnull(@accion_id,accion_id) and bitacora_fecha>=isnull(@fecha_desde,'01/01/1900') and bitacora_fecha<=isnull(@fecha_hasta,getdate())  ", New SqlParameter() {ParLogin, ParAccion, ParObjeto, ParFechaDesde, ParFechaHasta})

            Dim ListaBitacoras As New List(Of Bitacora)

            For Each fila As DataRow In nuevoReader.Rows
                ListaBitacoras.Add(ConstruirObjConRegistro(fila))
            Next

            Return ListaBitacoras
        Catch ex As Exception
            Throw ex
        End Try


    End Function

#Region "Metodos Privados"

    Protected Function ConstruirObjConRegistro(ByVal fila As DataRow) As Bitacora
        Dim UnaBitacora As New Bitacora
        UnaBitacora.ID = fila("bitacora_id")
        UnaBitacora.Login = fila("login")
        UnaBitacora.accion = fila("accion_id")
        UnaBitacora.Objeto = fila("objeto_id")
        UnaBitacora.Evento = fila("bitacora_evento")
        UnaBitacora.Fecha = fila("bitacora_fecha")
        UnaBitacora.EsError = CBool(fila("bitacora_esError"))
        Return UnaBitacora
    End Function

#End Region

End Class
