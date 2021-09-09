Imports System.Data
Imports System.Data.SqlClient

Public Class DALBackUp

    Dim Conectividad As Conector
    Public Sub New()
        Conectividad = New Conector()
    End Sub

    Public Sub HacerBackUP(ByVal Ruta As String)
        Conectividad.GuardarBackUp(Ruta)
    End Sub

    Public Sub GuardarRuta(ByVal Ruta As String, ByVal Descripcion As String)
        Dim ParRuta As New SqlParameter("@backup_ruta", SqlDbType.VarChar, 100)
        ParRuta.Value = Ruta
        Dim ParDescripcion As New SqlParameter("@backup_descripcion", SqlDbType.VarChar, 50)
        ParDescripcion.Value = Descripcion
        'Dim ParFecha As New SqlParameter("@backup_fecha", SqlDbType.DateTime, 0)
        'ParFecha.Value = Now.Date
        Conectividad.EjecutarComando("INSERT into sop_backup(backup_fecha,backup_ruta,backup_descripcion) Values(getdate(),@backup_ruta,@backup_descripcion)", New SqlParameter() {ParRuta, ParDescripcion})

    End Sub

    ''' <summary>
    ''' Restaura un backup de base de datos
    ''' </summary>
    ''' <param name="Ruta"></param>
    ''' <remarks></remarks>
    Public Sub RestaurarBackUP(ByVal Ruta As String)
        Conectividad.RestoreBackUp(Ruta)
    End Sub

    Public Function ListarBackUp() As List(Of BackUp)
        Dim ListaBackUp As New List(Of BackUp)
        Dim dt As DataTable = Conectividad.MostrarDataTable("select * from sop_backup", Nothing)

        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                Dim UnBKP As New BackUp
                UnBKP.Fecha = CDate(fila("backup_fecha"))
                UnBKP.ID = CInt(fila("backup_id"))
                UnBKP.Ruta = fila("backup_ruta").ToString()
                UnBKP.Descripcion = fila("backup_descripcion").ToString()
                ListaBackUp.Add(UnBKP)
            Next
        End If
        Return ListaBackUp
    End Function

End Class
