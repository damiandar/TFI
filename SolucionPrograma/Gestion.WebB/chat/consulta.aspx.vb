
Partial Class chat_consulta
    Inherits System.Web.UI.Page


    'Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    '    If Not Page.IsPostBack Then
    '        CrearUsuario()
    '    End If

    'End Sub

    'Protected Sub btnEnviarMensaje_Click(sender As Object, e As System.EventArgs) Handles btnEnviarMensaje.Click

    '    EscribirChat(MostrarLista, Session("usuario"), tbMensaje.Text)
    '    tbMensaje.Text = ""
    'End Sub

    'Protected Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
    '    MostrarChat(MostrarLista(), Session("usuario").ToString())
    'End Sub

    'Private Sub EscribirChat(ByVal Lista As List(Of Chat), ByVal Usuario As String, ByVal Mensaje As String)
    '    If Lista IsNot Nothing Then
    '        Dim oChat As New Chat()
    '        oChat.EscribirMensajes(Usuario, Lista, Mensaje, True)
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

    'Private Sub MostrarChat(ByVal Lista As List(Of Chat), ByVal Usuario As String)
    '    If Lista.Count > 0 Then
    '        Dim UnChat As Chat = Lista.Find(Function(x) x.Nombre = Usuario)
    '        If UnChat IsNot Nothing Then
    '            lblChat.Text = UnChat.Mensaje
    '        End If
    '    End If
    'End Sub

    'Private Sub CrearUsuario()
    '    Session("usuario") = "cliente"
    '    Dim oChat As New Chat() 
    '    Application("mensajes") = oChat.IniciarConversacion(Session("usuario").ToString(), MostrarLista())
    'End Sub
End Class
