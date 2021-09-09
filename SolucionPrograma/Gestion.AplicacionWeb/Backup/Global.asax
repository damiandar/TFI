<%@ Application Language="VB" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="System.Web.SessionState"%>
<%@ import Namespace="System.Diagnostics" %>
<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Código que se ejecuta al iniciarse la aplicación
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Código que se ejecuta durante el cierre de aplicaciones
        Session.Clear()
        Session.Abandon()
        FormsAuthentication.SignOut()
    End Sub
        
    Sub Application_EndRequest(ByVal sender As Object, ByVal e As EventArgs)
       
        If Response.StatusCode = 302 Then
            Dim authenticated As Boolean = HttpContext.Current.User.Identity.IsAuthenticated
            If (authenticated) Then
                Response.RedirectLocation = "~/logout.aspx"
            End If
                
        End If
          
    End Sub
       
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Código que se ejecuta al producirse un error no controlado
        'Dim ctx As HttpContext = HttpContext.Current

        'Dim exception As Exception = ctx.Server.GetLastError()

        'Dim errorInfo As String = _
        '   "<br>Offending URL: " + ctx.Request.Url.ToString() + _
        '   "<br>Source: " + exception.Source + _
        '   "<br>Message: " + exception.Message + _
        '   "<br>Stack trace: " + exception.StackTrace

        'ctx.Response.Write(errorInfo)

        'ctx.Server.ClearError()

    End Sub
    
    Sub Application_OnEnd()
        'Application clean-up code goes here.
    End Sub


    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        Try
            ' Código que se ejecuta cuando finaliza una sesión o expira. 
            ' Nota: El evento Session_End se desencadena sólo con el modo sessionstate
            ' se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer 
            ' o SQLServer, el evento no se genera.
            Session.Clear()
            
           
        Catch ex As Exception

        End Try


        'Try
        '    Response.Redirect("~/login.aspx")
        'Catch ex As Exception

        'End Try
    End Sub
    


  
    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
        Session("maxIntentos") = 3
        Session("contadorSession") = 0
        Session("cuentaRepetida") = 0
        
        'Remueve el ticket cuando session se recompila (Es para Desarrollo).
        If Session.Count = 0 Then
            FormsAuthentication.SignOut()
            Response.Redirect("~/login.aspx")
        End If
    End Sub
    
    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        If (Not (HttpContext.Current.User Is Nothing)) Then
            If HttpContext.Current.User.Identity.AuthenticationType = "Forms" Then
                Dim id As FormsIdentity
                Dim tkt As FormsAuthenticationTicket
                id = HttpContext.Current.User.Identity
                tkt = id.Ticket
                Dim Role() As String
                Dim authcookie As HttpCookie
                authcookie = Request.Cookies(FormsAuthentication.FormsCookieName)
                tkt = CType(FormsAuthentication.Decrypt(authcookie.Value), FormsAuthenticationTicket)
                'Role = Split(tkt.UserData, ",")
                Dim vValoresTicket() As String = tkt.UserData.Split("|".ToCharArray())
                Role = vValoresTicket(0).Split("|".ToCharArray())
                HttpContext.Current.User = New GenericPrincipal(id, Role)
            End If
        Else
            Dim a As Integer = 3
            
        End If
    End Sub


       

    'Protected Sub Application_AcquireRequestState(ByVal sender As Object, ByVal e As System.EventArgs)
     '   If (Not (HttpContext.Current.User Is Nothing)) Then
        

      '      Session("cuenta") = HttpContext.Current.User.Identity.Name.ToString()

       ' End If
    'End Sub
</script>