Imports System.Data
Imports System.Data.SqlClient


Public Class DALComprobante

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function InsertarComprobante(ByVal UnComprobante As Comprobante) As Integer
        Try
            Dim ParFecha As New SqlParameter("@comprobante_fechacarga", SqlDbType.Date, 0)
            ParFecha.Value = UnComprobante.Fecha
            Dim ParCuenta As New SqlParameter("@cuenta_id", SqlDbType.Int, 0)
            ' ParCuenta.Value = UnComprobante.cuenta.ID
            Dim ParTipo As New SqlParameter("@comprobantetipo_id", SqlDbType.Int, 0)
            ParTipo.Value = UnComprobante.Tipo
            Return Conectividad.EjecutarScalar("Comprobante_Insert", New SqlParameter() {ParFecha, ParCuenta, ParTipo})
        Catch ex As Exception
            Throw New Exception("Insertar Comprobante:" & ex.Message.ToString())
        End Try
    End Function

    Public Function ListarComprobantes(ByVal CuentaID As Integer, ByVal Tipo As Comprobante.eTipo, ByVal ID As Integer) As List(Of Comprobante)
        Dim ParCuenta As New SqlParameter("@cuenta_id", SqlDbType.Int, 0)
        ParCuenta.Value = IIf(CuentaID = 0, DBNull.Value, CuentaID)
        Dim ParTipo As New SqlParameter("@comprobantetipo_id", SqlDbType.Int, 0)
        ParTipo.Value = IIf(Tipo = 0, DBNull.Value, Tipo)
        Dim ParID As New SqlParameter("@comprobante_id", SqlDbType.Int, 0)
        ParID.Value = IIf(ID = 0, DBNull.Value, ID)
        Dim ListaComprobantes As New List(Of Comprobante)
        Dim dt As DataTable = Conectividad.MostrarDataTable("Comprobante_Show", New SqlParameter() {ParCuenta, ParTipo, ParID})
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                ListaComprobantes.Add(ConstruirObjetoConRegistro(fila))
            Next
        End If
        Return ListaComprobantes
    End Function

#Region "Metodos Privados"

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Comprobante
        Dim UnComprobante As New Comprobante
        'UnComprobante.cuenta = New Cuenta(fila("cuenta_id"), fila("cuenta_cuit"), fila("cuenta_razonsocial"))
        UnComprobante.ID = fila("comprobante_id")
        UnComprobante.Fecha = fila("comprobante_fechacarga")
        Return UnComprobante
    End Function

#End Region

End Class
