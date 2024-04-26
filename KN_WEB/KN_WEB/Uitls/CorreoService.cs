using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace KN_WEB.Uitls
{
    public class CorreoService
    {

        public string Destinatario { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }

    }

    public class CorreoNewTicket : CorreoService
    {      
        public CorreoNewTicket(string destinatario) {
            Destinatario = destinatario;
            Asunto = "Creacion de ticket";
            Cuerpo = "Su solicitud de creación de tiquete ha sido procesada correctamente<br><br>El estado de su solicitud se encuentra a la espera de asignación de un técnico";
        }
    }

    public class CorreoNewMessage : CorreoService
    {
        public CorreoNewMessage(string destinatario, int idTiquete)
        {
            Destinatario = destinatario;
            Asunto = "Nuevo mensaje a su ticket: " + idTiquete;
            Cuerpo = "Se ha incluido un nuevo mensaje dentro de su tiquete, favor revisar el comentario asignado con el feedback o recomendaciones para este tiquete";
        }
    }

    public class CorreoUpdateMessage : CorreoService {

        public CorreoUpdateMessage(string destinatario, int idTiquete) 
        {
            Destinatario = destinatario;
            Asunto = "Actualización de estado de tiquete: " + idTiquete;
            Cuerpo = "Se ha modificado la información sobre su tiquete, favor validar el estado y el técnico asignado";
        }
    }

    public static class InterfaceEmail
    {
        public static void SendEmail(CorreoService model)
        {
            MailMessage correo = new MailMessage();

            //Correo del que recibimos y nombre a aparecer en remitente
            correo.From = new MailAddress("aplicacionesService365@outlook.com", "Service365", System.Text.Encoding.UTF8);
            correo.To.Add(model.Destinatario);
            correo.Subject = model.Asunto;
            correo.Body = model.Cuerpo;
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.office365.com";
            smtp.Port = 587;
            //Correo y contrasena, en ese mismo orden
            smtp.Credentials = new System.Net.NetworkCredential("aplicacionesService365@outlook.com", "S3rV1c3365");
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(correo);
            }
            catch (Exception )
            {
            }
        }
    }
}