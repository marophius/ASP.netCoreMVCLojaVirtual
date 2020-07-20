using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoEmail(Contato contato)
        {
            /*
             * SMTP -> Servidor que envia o email.
             */
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("ifeme08@gmail.com", "@Reforma12");
            smtp.EnableSsl = true;

            string corpoMsg = string.Format("<h2>Contato - LojaVirtual</h2> <br />" + 
                "<b>Nome: </b> {0} <br />"+
                "<b>Email: </b> {1} <br />"+
                "<b>Texto: </b> {2} <br />"+
                "<br /> Email enviado automaticamente do site LojaVirtual",
                contato.Nome,
                contato.Email,
                contato.Texto);
            /*
             * MailMessage -> Construir a mensagem!
             */
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("ifeme08@gmail.com");
            mensagem.To.Add(new MailAddress("ifeme08@gmail.com"));
            mensagem.Subject = "Contato - LojaVirtua - Email: "+ contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;
            smtp.Send(mensagem);
        }
    }
}
