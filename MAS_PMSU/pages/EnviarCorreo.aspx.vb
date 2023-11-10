Imports System
Imports System.Net
Imports System.Net.Mail
Imports System.IO
Imports System.Net.Mime

Partial Class EnviarCorreo
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
    Protected Sub EnviarCorreo(sender As Object, e As EventArgs)
        Dim destinatario As String = "josekilo.07@gmail.com"
        Dim remitente As String = "josekilo.07@gmail.com"
        Dim contra As String = "qvcl goqz fmrr drvv"

        Dim correo As New MailMessage()
        correo.From = New MailAddress(remitente)
        correo.To.Add(destinatario)
        correo.Subject = "Archivo de suscripción de lote"
        correo.Body = "Buenas días/tardes. Le adjunto archivo PDF de suscripción de lote para la inscripción de SENASA. Saludos."

        If fuArchivo.HasFile Then
            Dim nombreArchivo As String = Path.GetFileName(fuArchivo.PostedFile.FileName)
            Dim rutaDestino As String = "C:/Users/josek/Downloads/" & nombreArchivo
            fuArchivo.SaveAs(rutaDestino)
            correo.Attachments.Add(New Attachment(rutaDestino, MediaTypeNames.Application.Pdf))
        End If


        Dim clienteSmtp As New SmtpClient()
        clienteSmtp.Host = "smtp.gmail.com"
        clienteSmtp.Port = 587
        clienteSmtp.Credentials = New NetworkCredential(remitente, contra)
        clienteSmtp.EnableSsl = True

        Try
            clienteSmtp.Send(correo)
            Response.Write("<script>window.alert('¡Se ha enviado excitosamente el correo!') </script>")
        Catch ex As Exception
            Response.Write("Error al enviar el correo: " & ex.Message)
        End Try


    End Sub

End Class
