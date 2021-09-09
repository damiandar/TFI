
Imports System.Data
Imports System.Data.SqlClient
Public Class DALPago 
        Dim Conectividad As Conector

        Public Sub New()
            Conectividad = New Conector(Conector.Tipo.StoreProcedure)
        End Sub

    Public Sub InsertarPago(ByVal UnPago As Pago)
        Try
            Dim ParID As New SqlParameter("@comprobante_id", SqlDbType.Int, 0)
            ParID.Value = UnPago.ID
            Dim ParFecha As New SqlParameter("@pago_fecha", SqlDbType.Date, 0)
            ParFecha.Value = UnPago.FechaPago
            Dim ParFormaPago As New SqlParameter("@formapago_id", SqlDbType.Int, 0)
            ParFormaPago.Value = UnPago.formapago.ID
            Dim ParConcepto As New SqlParameter("@pago_concepto", SqlDbType.VarChar, 20)
            ParConcepto.Value = UnPago.Concepto
            Conectividad.EjecutarComando("Pago_Insert", New SqlParameter() {ParID, ParFecha, ParFormaPago, ParConcepto})
        Catch ex As Exception
            Throw New Exception("Insertar Pago:" & ex.Message.ToString())
        End Try
    End Sub

    Public Function MostrarPago(ByVal Cuenta_id As Integer, ByVal FormaPagoId As Integer, ByVal PagoId As Integer) As List(Of Pago)
        Dim Lista As New List(Of Pago)

        Dim ParCuenta As New SqlParameter("@Cuenta_ID", SqlDbType.Int, 0)
        ParCuenta.Value = IIf(Cuenta_id = 0, DBNull.Value, Cuenta_id)

        Dim ParForma As New SqlParameter("@formapago_ID", SqlDbType.Int, 0)
        ParForma.Value = IIf(FormaPagoId = 0, DBNull.Value, FormaPagoId)

        Dim ParID As New SqlParameter("@pago_ID", SqlDbType.Int, 0)
        ParID.Value = IIf(PagoId = 0, DBNull.Value, PagoId)





        Dim dt As DataTable = Conectividad.MostrarDataTable("Pago_Show", New SqlParameter() {ParCuenta, ParForma, ParID})
        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then
                For Each fila As DataRow In dt.Rows
                    Lista.Add(ConstruirObjetoConRegistro(fila))
                Next
            End If
        End If
        Return Lista
    End Function

#Region "Metodos privados"

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Pago
        Dim UnPago As New Pago
        'UnPago.cuenta = New Cuenta(fila("cuenta_id"), fila("cuenta_cuit"), fila("cuenta_razonsocial"))
        UnPago.ID = fila("comprobante_id")
        UnPago.Fecha = fila("comprobante_fecha")
        UnPago.FechaPago = fila("pago_fecha")
        UnPago.formapago = New FormaPago(CInt(fila("formapago_id")), fila("formapago_descripcion").ToString())
        UnPago.Concepto = fila("pago_concepto")
        Return UnPago
    End Function

#End Region



    End Class
