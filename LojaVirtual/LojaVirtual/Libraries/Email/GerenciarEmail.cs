using LojaVirtual.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class GerenciarEmail
    {

        private SmtpClient _smtp;
        private IConfiguration _conf;

        public GerenciarEmail(SmtpClient smtp, IConfiguration configuration)
        {
            _smtp = smtp;
            _conf = configuration;
        }

        public void EnviarContatoEmail(Contato contato)
        {
            /*
             * SMTP -> Servidor que envia o email.
             */

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
            mensagem.From = new MailAddress(_conf.GetValue<string>("Email: Username"));
            mensagem.To.Add(new MailAddress("ifeme08@gmail.com"));
            mensagem.Subject = "Contato - LojaVirtua - Email: "+ contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;
            _smtp.Send(mensagem);
        }

        public void EnviarSenhaPorEmail(Colaborador cb)
        {
            string corpoMsg = string.Format("<h2>Colaborador - LojaVirtual</h2> <br />" +
                "Sua senha: " +
                "<h3>{0}</h3>", cb.Senha
                );

            /*
             * MailMessage -> Construir a mensagem!
             */
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress(_conf.GetValue<string>("Email: Username"));
            mensagem.To.Add(new MailAddress(cb.Email));
            mensagem.Subject = "Colaborador - LojaVirtua - Senha: " + cb.Nome;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;
            _smtp.Send(mensagem);
        }
    }
}
