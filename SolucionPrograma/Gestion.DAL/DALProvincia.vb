Imports System.Data
Imports System.Data.SqlClient

Public Class DALProvincia

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function ListarProvincias() As List(Of Provincias)
        Dim ListaProvincias As New List(Of Provincias)
        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("Provincia_Show", Nothing)
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                ListaProvincias.Add(ConstruirObjetoConRegistro(fila))
            Next
        End If
        Return ListaProvincias
    End Function

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As Provincias
        Dim UnaProvincia As New Provincias
        UnaProvincia.ID = fila("provincia_codigo")
        UnaProvincia.Descripcion = fila("provincia_nombre")

        Return UnaProvincia
    End Function

End Class
