
Partial Class chat_atencion
    Inherits System.Web.UI.Page

    'Private Function MostrarLista() As List(Of Chat)
    '    Dim Lista As New List(Of Chat)
    '    Try

    '        Lista = CType(Application("mensajes"), List(Of Chat))
    '        If Lista Is Nothing Then
    '            Lista = New List(Of Chat)
    '        End If

    '    Catch ex As Exception
    '        'If Lista Is Nothing Then
    '        '    Lista = New List(Of Chat)
    '        'End If
    '    End Try
    '    Return Lista
    'End Function

    'Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    '    Dim Lista As List(Of Chat) = MostrarLista()
    '    For Each UnChat As Chat In Lista
    '        comboConectados.Items.Add(New ListItem(UnChat.Nombre, UnChat.Nombre))
    '    Next
    'End Sub

    'Protected Sub btnChatear_Click(sender As Object, e As System.EventArgs) Handles btnChatear.Click
    '    Dim url As String = "ventanaChat.aspx?usuario=" & comboConectados.SelectedValue.ToString()
    '    Dim s As String = "window.open('" & url + "', 'popup_window', 'width=520,height=520,status=no,resizable=yes,screenx=0,screeny=0');"
    '    ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)

    'End Sub
End Class
