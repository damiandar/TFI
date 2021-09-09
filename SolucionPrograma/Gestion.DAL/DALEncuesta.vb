Imports System.Data
Imports System.Data.SqlClient

Public Class DALEncuesta

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function InsertarEncuesta(ByVal UnaEncuesta As Encuesta) As Integer
        Try
            Dim ParDescripcion As New SqlParameter("@encuesta_descripcion", SqlDbType.VarChar, 50)
            ParDescripcion.Value = UnaEncuesta.Descripcion

            Return Conectividad.EjecutarScalar("Encuesta_Insert", New SqlParameter() {ParDescripcion})
        Catch ex As Exception
            Throw New Exception("Insertar comentario:" & ex.Message.ToString())
        End Try
    End Function

    Public Function MostrarEncuesta(ByVal EncuestaID As Integer) As Encuesta
        Dim ParEncuestaID As New SqlParameter("@encuesta_id", SqlDbType.Int, 0)
        ParEncuestaID.Value = IIf(EncuestaID = 0, DBNull.Value, EncuestaID)
        Dim UnaEncuesta As New Encuesta

        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("Encuesta_Show", New SqlParameter() {ParEncuestaID})
        If dt.Rows.Count > 0 Then
            UnaEncuesta = ConstruirObjetoConRegistro(dt.Rows(0))
        End If

        dt = Conectividad.MostrarDataTable("EncuestaDetalle_show", New SqlParameter() {ParEncuestaID})
        If dt.Rows.Count > 0 Then
            UnaEncuesta.Opciones = New List(Of EncuestaDetalle)

            For Each fila As DataRow In dt.Rows
                UnaEncuesta.Opciones.Add(ConstruirObjetoConRegistroDetalle(fila))
            Next
        End If
        Return UnaEncuesta
    End Function

    Public Function ListarEncuestas() As List(Of Encuesta)
        Dim ListaEncuestas As New List(Of Encuesta)

        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("Encuesta_Show", Nothing)

        If dt.Rows.Count > 0 Then
            For Each Fila As DataRow In dt.Rows
                Dim UnaEncuesta As New Encuesta
                UnaEncuesta = ConstruirObjetoConRegistro(Fila)
                Dim dtItem As New DataTable
                Dim ParEncuestaID As New SqlParameter("@encuesta_id", SqlDbType.Int, 0)
                ParEncuestaID.Value = UnaEncuesta.ID
                dtItem = Conectividad.MostrarDataTable("EncuestaDetalle_show", New SqlParameter() {ParEncuestaID})
                If dtItem.Rows.Count > 0 Then
                    UnaEncuesta.Opciones = New List(Of EncuestaDetalle)
                    For Each filaItem As DataRow In dtItem.Rows
                        UnaEncuesta.Opciones.Add(ConstruirObjetoConRegistroDetalle(filaItem))
                    Next
                End If
                ListaEncuestas.Add(UnaEncuesta)
            Next
        End If


        Return ListaEncuestas
    End Function

    Public Function ListarEncuestaPendiente(ByVal Login As String) As List(Of Encuesta)

        Dim ListaEncuestas As New List(Of Encuesta)


        Dim ParDescripcion As New SqlParameter("@login", SqlDbType.VarChar, 50)
        ParDescripcion.Value = Login


        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("Encuesta_Mostrar_Pendientes", New SqlParameter() {ParDescripcion})

        If dt.Rows.Count > 0 Then
            For Each Fila As DataRow In dt.Rows
                Dim UnaEncuesta As New Encuesta
                UnaEncuesta = ConstruirObjetoConRegistro(Fila)
                Dim dtItem As New DataTable
                Dim ParEncuestaID As New SqlParameter("@encuesta_id", SqlDbType.Int, 0)
                ParEncuestaID.Value = UnaEncuesta.ID
                dtItem = Conectividad.MostrarDataTable("EncuestaDetalle_show", New SqlParameter() {ParEncuestaID})
                If dtItem.Rows.Count > 0 Then
                    UnaEncuesta.Opciones = New List(Of EncuestaDetalle)
                    For Each filaItem As DataRow In dtItem.Rows
                        UnaEncuesta.Opciones.Add(ConstruirObjetoConRegistroDetalle(filaItem))
                    Next
                End If
                ListaEncuestas.Add(UnaEncuesta)
            Next
        End If


        Return ListaEncuestas
    End Function
    Public Sub InsertarEncuestaDetalle(ByVal EncuestaID As Integer, ByVal Descripcion As String)

        Dim ParDescripcion As New SqlParameter("@encuestadetalle_descripcion", SqlDbType.VarChar, 50)
        ParDescripcion.Value = Descripcion

        Dim ParID As New SqlParameter("@encuesta_id", SqlDbType.Int, 0)
        ParID.Value = EncuestaID

        Conectividad.EjecutarComando("EncuestaDetalle_Insert", New SqlParameter() {ParID, ParDescripcion})
    End Sub

    Public Sub VotarEncuesta(ByVal Login As String, ByVal EncuestaID As Integer, ByVal EncuestaDetalleID As Integer, ByVal EncuestaOpinion As String)
        Dim ParID As New SqlParameter("@encuesta_id", SqlDbType.Int, 0)
        ParID.Value = EncuestaID
        Dim ParDetalleID As New SqlParameter("@encuestadetalle_id", SqlDbType.Int, 0)
        ParDetalleID.Value = EncuestaDetalleID
        Dim ParOpinion As New SqlParameter("@encuestavoto_comentario", SqlDbType.VarChar, 50)
        ParOpinion.Value = EncuestaOpinion
        Dim ParUsuario As New SqlParameter("@login", SqlDbType.NVarChar, 50)
        ParUsuario.Value = Login

        Conectividad.EjecutarComando("EncuestaVoto_Insert", New SqlParameter() {ParID, ParDetalleID, ParUsuario, ParOpinion})

    End Sub

#Region "Metodos privados"

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Encuesta
        Dim UnaEncuesta As New Encuesta
        UnaEncuesta.ID = fila("encuesta_id")
        UnaEncuesta.Descripcion = fila("encuesta_descripcion").ToString().Trim()
        Return UnaEncuesta
    End Function

    Private Function ConstruirObjetoConRegistroDetalle(ByVal fila As DataRow) As EncuestaDetalle
        Dim UnaEncuestaDetalle As New EncuestaDetalle
        UnaEncuestaDetalle.ID = fila("encuestadetalle_id")
        UnaEncuestaDetalle.Detalle = fila("encuestadetalle_descripcion").ToString().Trim()

        Return UnaEncuestaDetalle
    End Function

#End Region

End Class
