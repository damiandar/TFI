
Partial Class chat_ventanaChat
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ViewState("usuarioconectado") = Request.QueryString("usuario")
        End If

    End Sub

    'Protected Sub btnEnviarMensaje_Click(sender As Object, e As System.EventArgs) Handles btnEnviarMensaje.Click
    '    EscribirChat(MostrarLista(), ViewState("usuarioconectado").ToString(), tbMensaje.Text)
    'End Sub

    'Protected Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
    '    MostrarChat(MostrarLista(), ViewState("usuarioconectado").ToString())
    'End Sub

    'Private Sub EscribirChat(ByVal Lista As List(Of Chat), ByVal Usuario As String, ByVal Mensaje As String)
    '    If Lista IsNot Nothing Then
    '        Dim oChat As New Chat()
    '        oChat.EscribirMensajes(Usuario, Lista, Mensaje, False)
    '    End If
    'End Sub

    'Private Sub MostrarChat(ByVal Lista As List(Of Chat), ByVal Usuario As String)
    '    If Lista.Count > 0 Then
    '        Dim UnChat As Chat = Lista.Find(Function(x) x.Nombre = Usuario)
    '        If UnChat IsNot Nothing Then
    '            lblChat.Text = UnChat.Mensaje
    '        End If
    '    End If
    'End Sub

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

End Class
