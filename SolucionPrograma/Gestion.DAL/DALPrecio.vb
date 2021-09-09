Imports System.Data
Imports System.Data.SqlClient

Public Class DALPrecio

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Sub InsertarProductoPrecio(ByVal ProductoId As Integer, ByVal Precio As Precio, ByVal ListaPrecioID As Integer)
        Try
            Dim ParID As New SqlParameter("@producto_id", SqlDbType.Int, 0)
            ParID.Value = ProductoId
            Dim ParPrecioUnitario As New SqlParameter("@productoprecio_valor", SqlDbType.Int, 0)
            ParPrecioUnitario.Value = Precio.ValorUnitario
            Dim ParIVA As New SqlParameter("@iva_id", SqlDbType.Int, 0)
            ParIVA.Value = Precio.iva.ID
            Dim ParListaID As New SqlParameter("@productolistaprecio_id", SqlDbType.Int, 0)
            ParListaID.Value = ListaPrecioID
            Conectividad.EjecutarComando("ProductoPrecio_Insert", New SqlParameter() {ParID, ParPrecioUnitario, ParIVA, ParListaID})
        Catch ex As Exception
            Throw New Exception("Insertar producto:" & ex.Message.ToString())
        End Try
    End Sub


    Public Sub ActivarListaPrecio(ByVal ListaPrecioID As Integer)
        Try
            Dim ParListaID As New SqlParameter("@productolistaprecio_id", SqlDbType.Int, 0)
            ParListaID.Value = ListaPrecioID
            Conectividad.EjecutarComando("ProductoListaPrecio_Activar", New SqlParameter() {ParListaID})
        Catch ex As Exception
            Throw New Exception("Activar Lista Precios:" & ex.Message.ToString())
        End Try
    End Sub


    Public Sub ModificarProductoPrecio(ByVal Producto As Productos, ByVal ListaID As Integer)
        Try
            Dim ParID As New SqlParameter("@producto_id", SqlDbType.Int, 0)
            ParID.Value = Producto.ID
            Dim ParLista As New SqlParameter("@productolistaprecio_id", SqlDbType.Int, 0)
            ParLista.Value = ListaID
            Dim ParNotas As New SqlParameter("@productoprecio_nota", SqlDbType.VarChar, 50)
            ParNotas.Value = ""
            Dim ParPrecioUnitario As New SqlParameter("@productoprecio_valor", SqlDbType.Int, 0)
            ParPrecioUnitario.Value = Producto.precio.ValorUnitario
            Dim ParIVA As New SqlParameter("@iva_id", SqlDbType.Int, 0)
            ParIVA.Value = Producto.precio.iva.ID
            Conectividad.EjecutarComando("ProductoPrecio_Update", New SqlParameter() {ParLista, ParNotas, ParID, ParPrecioUnitario, ParIVA})
        Catch ex As Exception
            Throw New Exception("Modificar producto:" & ex.Message.ToString())
        End Try
    End Sub

    Public Function MostrarListaPrecios(ByVal PrecioListaID As Integer) As List(Of PrecioLista)
        Dim Lista As New List(Of PrecioLista)
        Dim ParListaID As New SqlParameter("@ProductoListaPrecio_id", SqlDbType.Int, 0)
        ParListaID.Value = IIf(PrecioListaID = 0, DBNull.Value, PrecioListaID)
        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("ListaPreciosCabecera_Show", New SqlParameter() {ParListaID})
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                Lista.Add(ConstruirObjetoConRegistro(fila))
            Next
        End If
        Return Lista
    End Function

    Public Sub CrearListaPrecios(ByVal FechaVigencia As DateTime)
        Dim ParVigencia As New SqlParameter("@ProductoListaPrecio_FechaVigencia", SqlDbType.DateTime, 0)
        ParVigencia.Value = FechaVigencia
        Conectividad.EjecutarComando("ProductoListaPrecio_Insert", New SqlParameter() {ParVigencia})
    End Sub

#Region "Metodos Privados"

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As PrecioLista
        Dim UnaListaPrecios As New PrecioLista
        UnaListaPrecios.Activa = CBool(fila("ProductoListaPrecio_activa"))
        UnaListaPrecios.FechaCreacion = CDate(fila("ProductoListaPrecio_FechaCreacion"))
        UnaListaPrecios.FechaVigencia = CDate(fila("ProductoListaPrecio_FechaVigencia"))
        UnaListaPrecios.ID = CInt(fila("ProductoListaPrecio_id"))
        Return UnaListaPrecios
    End Function

#End Region

End Class
