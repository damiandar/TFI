Imports System.Data
Imports System.Data.SqlClient

Public Class DALComentario

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function InsertarComentario(ByVal UnComentario As Comentarios) As Integer
        Try
            Dim ParProducto As New SqlParameter("@producto_id", SqlDbType.Int, 0)
            ParProducto.Value = UnComentario.ProductoID
            Dim ParDescripcion As New SqlParameter("@comentario_descripcion", SqlDbType.VarChar, 50)
            ParDescripcion.Value = UnComentario.Descripcion
            Dim ParTitulo As New SqlParameter("@comentario_titulo", SqlDbType.VarChar, 50)
            ParTitulo.Value = UnComentario.Titulo
            Dim ParPositivo As New SqlParameter("@comentario_positivo", SqlDbType.Int, 0)
            ParPositivo.Value = 0
            Dim ParNegativo As New SqlParameter("@comentario_negativo", SqlDbType.Int, 0)
            ParNegativo.Value = 0
            Dim ParPor As New SqlParameter("@comentario_por", SqlDbType.VarChar, 50)
            ParPor.Value = UnComentario.Por
            Dim ParFecha As New SqlParameter("@comentario_fecha", SqlDbType.DateTime, 0)
            ParFecha.Value = Now.Date
            Dim ParPuntaje As New SqlParameter("@comentario_puntaje", SqlDbType.Int, 0)
            ParPuntaje.Value = UnComentario.Puntaje
            Dim ParCliente As New SqlParameter("@cliente_id", SqlDbType.Int, 0)
            ParCliente.Value = UnComentario.cliente.ID
            Return Conectividad.EjecutarScalar("Comentario_Insert", New SqlParameter() {ParDescripcion, ParProducto, ParTitulo, ParPositivo, ParNegativo, ParPor, ParFecha, ParPuntaje, ParCliente})

        Catch ex As Exception
            Throw New Exception("Insertar comentario:" & ex.Message.ToString())
        End Try
    End Function

    Public Sub ActualizarComentario(ByVal UnComentario As Comentarios)
        Try
            'Dim ParProducto As New SqlParameter("@producto_id", SqlDbType.Int, 0)
            'ParProducto.Value = UnComentario.ProductoID
            'Dim ParDescripcion As New SqlParameter("@comentario_descripcion", SqlDbType.VarChar, 50)
            'ParDescripcion.Value = UnComentario.Descripcion
            'Dim ParTitulo As New SqlParameter("@comentario_titulo", SqlDbType.VarChar, 50)
            'ParTitulo.Value = UnComentario.Titulo
            Dim ParPositivo As New SqlParameter("@comentario_positivo", SqlDbType.Int, 0)
            ParPositivo.Value = UnComentario.Positivo
            Dim ParNegativo As New SqlParameter("@comentario_negativo", SqlDbType.Int, 0)
            ParNegativo.Value = UnComentario.Negativo
            'Dim ParPor As New SqlParameter("@comentario_por", SqlDbType.VarChar, 50)
            'ParPor.Value = UnComentario.Por
            'Dim ParFecha As New SqlParameter("@comentario_fecha", SqlDbType.DateTime, 0)
            'ParFecha.Value = Now.Date
            Dim ParPuntaje As New SqlParameter("@comentario_puntaje", SqlDbType.Int, 0)
            ParPuntaje.Value = UnComentario.Puntaje
            Dim ParComentarioID As New SqlParameter("@comentario_id", SqlDbType.Int, 0)
            ParComentarioID.Value = UnComentario.ID
            'Dim ParCliente As New SqlParameter("@cliente_id", SqlDbType.Int, 0)
            'ParCliente.Value = UnComentario.cliente.ID
            Conectividad.EjecutarComando("Comentario_Update", New SqlParameter() {ParComentarioID, ParPositivo, ParNegativo, ParPuntaje})

        Catch ex As Exception
            Throw New Exception("Insertar comentario:" & ex.Message.ToString())
        End Try
    End Sub

    Public Function ListarComentarios(ByVal ProductoID As Integer) As List(Of Comentarios)
        Dim ListaProductos As New List(Of Comentarios)
        Dim ParProductoID As New SqlParameter("@producto_id", SqlDbType.Int, 0)
        ParProductoID.Value = IIf(ProductoID = 0, DBNull.Value, ProductoID)

        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("Comentario_Show", New SqlParameter() {ParProductoID})
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                ListaProductos.Add(ConstruirObjetoConRegistro(fila))
            Next
        End If
        Return ListaProductos
    End Function

    Public Function MostrarComentario(ByVal ComentarioID As Integer) As Comentarios
        Dim UnComentario As New Comentarios
        Dim ParComentarioID As New SqlParameter("@comentario_id", SqlDbType.Int, 0)
        ParComentarioID.Value = ComentarioID

        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("Comentario_Show", New SqlParameter() {ParComentarioID})
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                UnComentario = ConstruirObjetoConRegistro(fila)
            Next
        End If
        Return UnComentario
    End Function

    
#Region "Metodos privados"

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Comentarios

        Dim UnComentario As New Comentarios
        UnComentario.ID = fila("comentario_id")
        UnComentario.ProductoID = fila("producto_id")
        UnComentario.Descripcion = fila("comentario_descripcion").ToString().Trim()
        UnComentario.Titulo = fila("comentario_titulo").ToString().Trim()
        UnComentario.Positivo = fila("comentario_positivo")
        UnComentario.Negativo = CBool(fila("comentario_negativo"))
        UnComentario.Por = fila("comentario_por")
        UnComentario.Fecha = fila("comentario_fecha")
        UnComentario.Puntaje = CInt(fila("comentario_puntaje"))
        UnComentario.cliente = New Cliente(fila("cuenta_id"), fila("cuenta_cuit"), fila("cuenta_razonsocial"))

        Return UnComentario

    End Function

#End Region

End Class
