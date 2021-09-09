
Partial Class backend_encuestas_Nuevo
    Inherits System.Web.UI.Page

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim UnaEncuesta As New Encuesta
        UnaEncuesta.Opciones = New List(Of EncuestaDetalle)
        UnaEncuesta.Descripcion = tbDescripcion.Text


        'Dim cph As ContentPlaceHolder = CType(Me.Master.FindControl("Content4"), ContentPlaceHolder)

        'For i = 1 To 10
        '    For Each UnControl As Control In cph.Controls
        '        If (TypeOf (UnControl) Is TextBox) Then
        '            Dim a = ""
        '        End If
        '    Next


        '    Dim nombre As String = "textbox" & i.ToString()
        '    Dim lbl As TextBox = CType(Page.FindControl(nombre), TextBox)
        'Dim valor As String = lbl.Text

        'Next
        Agregar(UnaEncuesta, TextBox1.Text)
        Agregar(UnaEncuesta, TextBox2.Text)
        Agregar(UnaEncuesta, TextBox3.Text)
        Agregar(UnaEncuesta, TextBox4.Text)
        Agregar(UnaEncuesta, TextBox5.Text)
        Agregar(UnaEncuesta, TextBox6.Text)
        Agregar(UnaEncuesta, TextBox7.Text)
        Agregar(UnaEncuesta, TextBox8.Text)
        Agregar(UnaEncuesta, TextBox9.Text)
        Agregar(UnaEncuesta, TextBox10.Text)

        If UnaEncuesta.Opciones.Count > 0 And UnaEncuesta.Descripcion.Length > 0 Then
            Dim GestorEncuesta As New BLLEncuesta
            GestorEncuesta.InsertarEncuesta(UnaEncuesta)
        End If


        tbDescripcion.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        Dim CSM As ClientScriptManager = Page.ClientScript
        Dim script As String = "<script type='text/javascript'>alert('Se inserto correctamente.'); </script>"
        CSM.RegisterClientScriptBlock(Me.GetType, "Test", script)
    End Sub


    Private Sub Agregar(ByRef UnaEncuesta As Encuesta, ByVal Valor As String)
        If Valor.Length > 0 Then
            Dim UnaOpcion As New EncuestaDetalle
            UnaOpcion.Detalle = Valor
            UnaEncuesta.Opciones.Add(UnaOpcion)
        End If
    End Sub
End Class
