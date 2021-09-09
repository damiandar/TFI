
Partial Class Registrarse
    Inherits System.Web.UI.Page

    Public Sub MostrarMensaje() Handles registrar.SeInserto
        Dim s As String = "$('#myModal').modal('show');"
        ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
    End Sub

    Public Sub MostrarMensajeError(ByVal mensaje As String) Handles registrar.SePincho
        Mapper_Bitacora.GuardarBitacora("", Patente.eObjeto.LOGIN, Patente.eAccion.INICIOSESION, mensaje, True)

    End Sub
End Class
