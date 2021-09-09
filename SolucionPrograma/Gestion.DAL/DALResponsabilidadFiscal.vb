Imports System.Data
Imports System.Data.SqlClient

Public Class DALResponsabilidadFiscal

    Dim Conectividad As Conector

    Public Sub New()
        Conectividad = New Conector(Conector.Tipo.StoreProcedure)
    End Sub

    Public Function ListarResponsabilidades() As List(Of ResponsabilidadFiscal)
        Dim ListaResponsabilidades As New List(Of ResponsabilidadFiscal)
        Dim dt As New DataTable
        dt = Conectividad.MostrarDataTable("TipoResponsable_Show", Nothing)
        If dt.Rows.Count > 0 Then
            For Each fila As DataRow In dt.Rows
                ListaResponsabilidades.Add(ConstruirObjetoConRegistro(fila))
            Next
        End If
        Return ListaResponsabilidades
    End Function

    Private Function ConstruirObjetoConRegistro(ByVal fila As DataRow) As ResponsabilidadFiscal
        Dim UnaResponsabilidad As New ResponsabilidadFiscal
        UnaResponsabilidad.ID = fila("tiporesponsable_id")
        UnaResponsabilidad.Descripcion = fila("tiporesponsable_descripcion")

        Return UnaResponsabilidad
    End Function

End Class
