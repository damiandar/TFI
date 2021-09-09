Public Class Mapper_Patente
    Dim dataProvider As DALPatente

    Public Sub New()
        dataProvider = New DALPatente
    End Sub

    Public Function ListarObjetos() As List(Of String)
        Return dataProvider.ListarObjetos()
    End Function

    Public Function ListarAcciones() As List(Of String)
        Return dataProvider.ListarAcciones()
    End Function


    Public Sub InsertarPatente(ByVal descripcion As String, ByVal ObjetoId As Integer, ByVal AccionId As Integer)
        dataProvider.InsertarPatente(descripcion, ObjetoId, AccionId)
    End Sub

    Public Sub EliminarPatente(ByVal PatenteId As Integer)
        Try
            dataProvider.EliminarPatente(PatenteId)
        Catch ex As Exception
            Throw New BLLExceptionSoporte(ex.Message.ToString())

        End Try

    End Sub

    Public Function ListarPatentes() As List(Of Patente)
        Return dataProvider.ListarPatentes()
    End Function

#Region "Asignacion"

    Public Sub AsignarPatenteUsuario(ByVal Login As String, ByVal PatenteId As Integer)
        dataProvider.AsignarPatenteUsuario(Login, PatenteId)
    End Sub

    Public Sub DesAsignarPatenteUsuario(ByVal Login As String, ByVal PatenteId As Integer)
        dataProvider.DesAsignarPatenteUsuario(Login, PatenteId)
    End Sub

    Public Sub AsignarPatenteFamilia(ByVal FamiliaId As String, ByVal PatenteId As Integer)
        dataProvider.AsignarPatenteFamilia(FamiliaId, PatenteId)
    End Sub

    Public Sub DesAsignarPatenteFamilia(ByVal FamiliaId As Integer, ByVal PatenteId As Integer)
        dataProvider.DesAsignarPatenteFamilia(FamiliaId, PatenteId)
    End Sub

    Public Function ListarPatentesFamilia(ByVal idFamilia As Integer) As List(Of Patente)
        Return dataProvider.ListarPatentesFamilia(idFamilia)
    End Function

    Public Function ListarPatentesUsuario(ByVal Login As String) As List(Of Patente)
        Return dataProvider.ListarPatentesUsuario(Login)
    End Function

#End Region

End Class
