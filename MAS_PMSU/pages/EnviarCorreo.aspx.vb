Imports System
Imports System.Net
Imports System.Net.Mail
Imports System.IO

Partial Class EnviarCorreo
    Inherits System.Web.UI.Page

    Protected Sub EnviarCorreo(sender As Object, e As EventArgs)
        Dim destinatario As String = txtDestinatario.Text
        Dim remitente As String = txtRemitente.Text
        Dim contra As String = ""

        Dim correo As New MailMessage()
        correo.From = New MailAddress(remitente)
        correo.To.Add(destinatario)
        correo.Subject = "Archivo de suscripción de lote"
        correo.Body = "Buenas días. Adjunto archivo PDF de suscripción de lote"

        If fuArchivo.HasFile Then
            Dim nombreArchivo As String = Path.GetFileName(fuArchivo.PostedFile.FileName)
            Dim rutaDestino As String = "C:/Users/josek/Downloads/" & nombreArchivo
            fuArchivo.SaveAs(rutaDestino)
            correo.Attachments.Add(New Attachment(rutaDestino))
        End If


        Dim clienteSmtp As New SmtpClient()
        clienteSmtp.Host = "smtp.gmail.com"
        clienteSmtp.Port = 587
        clienteSmtp.Credentials = New NetworkCredential(remitente, contra)
        clienteSmtp.EnableSsl = True

        Try
            clienteSmtp.Send(correo)
            Response.Write("El correo se ha enviado exitosamente.")
        Catch ex As Exception
            Response.Write("Error al enviar el correo: " & ex.Message)
        End Try
    End Sub
End Class
