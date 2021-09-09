Imports System.Data
Imports System.Data.SqlClient

Public Class DALFormaEnvio
    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function ListarFormasEnvio() As List(Of FormaEnvio)
        Dim Lista As New List(Of FormaEnvio)
        Dim dt As DataTable = Conectividad.MostrarDataTable("FormaEnvio_Show", Nothing)
        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then
                For Each fila As DataRow In dt.Rows
                    Lista.Add(ConstruirObjetoConRegistro(fila))
                Next
            End If
        End If
        Return Lista
    End Function


#Region "Metodos Privados"
     
    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As FormaEnvio
        Dim UnaFormaEnvio As New FormaEnvio()
        UnaFormaEnvio.ID = fila("formaenvio_id")
        UnaFormaEnvio.Descripcion = fila("formaenvio_descripcion")
        Return UnaFormaEnvio
    End Function

#End Region

End Class
