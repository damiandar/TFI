Imports System.Data
Imports System.Data.SqlClient

Public Class DALDigitoVerificador
    Dim Conectividad As Conector
    Public Sub New()
        Conectividad = New Conector()
    End Sub

#Region "Metodos Publicos"

    Public Sub ActualizarDigitoVerificador(ByVal Tabla As String)

        Dim ParDescripcion As New SqlParameter("@Descripcion", SqlDbType.VarChar, 20)
        ParDescripcion.Value = Tabla

        Dim ParDV As New SqlParameter("@DigitoVerificador", SqlDbType.Float, 0)
        ParDV.Value = MuestraDigitoVerificadorVertical(Tabla)

        Conectividad.EjecutarComando("Update sop_DigitoVerificador set DigitoVerificador=@DigitoVerificador where Descripcion=@Descripcion", New SqlParameter() {ParDescripcion, ParDV})
    End Sub

    ''' <summary>
    ''' Suma los DVV de todas las tablas guardadas.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MuestraDigitoVerificadorGuardado() As Double
        Return Conectividad.EjecutarScalar("select sum(DigitoVerificador) from sop_DigitoVerificador", Nothing)
    End Function

    ''' <summary>
    ''' Obtiene el DVV de la tabla que se obtiene en el momento.
    ''' </summary>
    ''' <param name="tabla"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MuestraDigitoVerificadorVertical(ByVal tabla As String) As Double
        Dim consulta As String = String.Format("select sum(DigitoVerificador) from {0}", tabla)
        Return Conectividad.EjecutarScalar(consulta, Nothing)
    End Function

#End Region




End Class
