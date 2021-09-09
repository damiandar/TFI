
Partial Class micuenta_datospersonales
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim iCuenta As Integer = Session("clienteid")
        PlantillaDatosPersonales1.LLenar(iCuenta)
    End Sub

    Protected Sub lnkEnviar_Click(sender As Object, e As System.EventArgs) Handles lnkEnviar.Click
        Dim iCuenta As Integer = Session("clienteid")
        plantilladatospersonales1.LLenarEdicion(iCuenta)
    End Sub
End Class
