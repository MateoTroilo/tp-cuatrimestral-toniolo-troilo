using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace tp_cuatrimestral_toniolo_troilo
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;
        public void enviarMail(Paciente paciente, Medico medico, Turno turno)
        {

            string body = @"<h2>Hola " + paciente.Nombre + " " + paciente.Apellido + "</h2> <br>Te comunicamos que tenés turno con " + medico.Nombre + " " + medico.Apellido + " en la fecha " + turno.Fecha + " para la especialidad "+ turno.Especialidad +".";
            setearMail(paciente.Email, "Este correo fue enviado via C-sharp", body);

            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setearMail(string to, string asunto, string body)
        {
            string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
            string from = "programacion3.2022@hotmail.com";
            string displayName = "Clínica C#";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(to);

                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;


                SmtpClient client = new SmtpClient("smtp.office365.com", 587); //Aquí debes sustituir tu servidor SMTP y el puerto
                client.Credentials = new NetworkCredential(from, "programacion3");
                client.EnableSsl = true;//En caso de que tu servidor de correo no utilice cifrado SSL,poner en false


                client.Send(mail);
                msge = "¡Correo enviado exitosamente! Pronto te contactaremos.";

            }
            catch (Exception ex)
            {
                msge = ex.Message + ". Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente.";
            }

            return;
        }
    }
}