
Imports System.Net.Mail

Public Class GestorMail


    Private MailSaliente As String = "XXXXXXXXX@gmail.com"
    Private ServerSmtp As String = "smtp.gmail.com"
    Private Clave As String = "XXXXXX"

    Public Sub New()

    End Sub

    Public Sub Enviar(ByVal MailDestino As String, ByVal Asunto As String, ByVal CuerpoMensaje As String)
        Dim mensaje As New System.Net.Mail.MailMessage(MailSaliente, MailDestino)
        mensaje.Subject = Asunto
        mensaje.Body = CuerpoMensaje


        'If nombrearchivo IsNot Nothing Then
        '    Dim adjunto As New Attachment(Me.nombrearchivo, MediaTypeNames.Application.Octet)
        '    mensaje.Attachments.Add(adjunto)
        'End If

        ''then we create the Html part
        ''to embed images, we need to use the prefix 'cid' in the img src value
        ''the cid value will map to the Content-Id of a Linked resource.
        ''thus <img src='cid:companylogo'> will map to a LinkedResource with a ContentId of 'companylogo'
        'Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString("Here is an embedded image.<img src=cid:companylogo>", Nothing, "text/html")

        ''create the LinkedResource (embedded image)
        'Dim logo As New LinkedResource("c:\temp\motivo_3.gif")
        'logo.ContentId = "companylogo"
        ''add the LinkedResource to the appropriate view
        'htmlView.LinkedResources.Add(logo)

        ''add the views
        'mensaje.AlternateViews.Add(htmlView)
        Try

            Dim clientesmtp As New SmtpClient()
            clientesmtp.Host = ServerSmtp
            clientesmtp.EnableSsl = True
            Dim NetworkCred As New System.Net.NetworkCredential(MailSaliente, Clave)
            clientesmtp.UseDefaultCredentials = True
            clientesmtp.Credentials = NetworkCred
            clientesmtp.Port = 587
            clientesmtp.Send(mensaje)
        Catch ex As Exception
            Throw New Exception(ex.Message.ToString())
        End Try
    End Sub

    Public Sub Enviar(ByVal MailDestino As String, ByVal Asunto As String, ByVal CuerpoMensaje As AlternateView)
        Dim mensaje As New System.Net.Mail.MailMessage(MailSaliente, MailDestino)
        mensaje.Subject = Asunto
        'mensaje.Body = CuerpoMensaje

        'If nombrearchivo IsNot Nothing Then
        '    Dim adjunto As New Attachment(Me.nombrearchivo, MediaTypeNames.Application.Octet)
        '    mensaje.Attachments.Add(adjunto)
        'End If

        'add the views
        mensaje.AlternateViews.Add(CuerpoMensaje)
        Try

            Dim clientesmtp As New SmtpClient()
            clientesmtp.Host = ServerSmtp
            clientesmtp.EnableSsl = True
            Dim NetworkCred As New System.Net.NetworkCredential(MailSaliente, Clave)
            clientesmtp.UseDefaultCredentials = True
            clientesmtp.Credentials = NetworkCred
            clientesmtp.Port = 587
            clientesmtp.EnableSsl = True
            clientesmtp.Send(mensaje)
        Catch ex As Exception
            Throw New Exception(ex.Message.ToString())
        End Try
    End Sub

End Class
