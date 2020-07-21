using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Models;
using LojaVirtual.Libraries.Email;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LojaVirtual.Database;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private LojaVirtualContext _banco;

        public HomeController(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm]NewsLetterEmail newsLetter)
        {
            if (ModelState.IsValid)
            {
                _banco.Email.Add(newsLetter);
                _banco.SaveChanges();

                TempData["MSG_S"] = "E-mail cadastrado! Agora você receberá promoções especiais no seu email.";

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {
            try
            {
                Contato contato = new Contato();
                contato.Nome = HttpContext.Request.Form["name"];
                contato.Email = HttpContext.Request.Form["email"];
                contato.Texto = HttpContext.Request.Form["texto"];

                var ListaMensagens = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                bool isValid = Validator.TryValidateObject(contato, contexto, ListaMensagens, true);

                if(isValid)
                {
                    ContatoEmail.EnviarContatoEmail(contato);

                    ViewData["MSG_S"] = "Mensagem de contato enviada com sucesso!";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach(var text in ListaMensagens)
                    {
                        sb.Append(text.ErrorMessage + "<br />");
                    }

                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTATO"] = contato;
                }
            }
            catch(Exception e)
            {
                ViewData["MSG_E"] = "Ops! Tivemos um erro, tente novamente";
            }
            

            return View("Contato");
        }
    }
}
