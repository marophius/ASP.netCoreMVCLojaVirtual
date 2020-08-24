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
using LojaVirtual.Models.Repositories;
using LojaVirtual.Models.Repositories.Contracts;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using LojaVirtual.Libraries.Acesso;
using LojaVirtual.Libraries.Filtro;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private IClienteRepository _clienteRepository;
        private INewsLetterRepository _newsLetterRepository;
        private LoginCliente _login;
        private GerenciarEmail _gerenciarEmail;

        public HomeController(IClienteRepository clRepos, INewsLetterRepository nlRepos, LoginCliente login, GerenciarEmail gerenciarEmail)
        {
            _clienteRepository = clRepos;
            _newsLetterRepository = nlRepos;
            _login = login;
            _gerenciarEmail = gerenciarEmail;
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
                _newsLetterRepository.Cadastrar(newsLetter);
              

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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] Cliente cliente)
        {
            Cliente clienteDB = _clienteRepository.Login(cliente.Email, cliente.Senha);

            if(clienteDB != null)
            {
                _login.Login(clienteDB);
                return new RedirectResult(Url.Action(nameof(Painel)));
            }

            else
            {
                ViewData["MSG_E"] = "Usuario não encontrado, verifique o email e senha digitado!";
                return View();
            }

        }

        [HttpGet]
        [ClienteAutorizacao]
        public IActionResult Painel()
        {
            return new ContentResult() { Content = "Este é o painel do cliente" };
     
        }

        [HttpGet]
        public IActionResult CadastroCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroCliente([FromForm] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.Cadastrar(cliente);

                TempData["MSG_S"] = "Cadastro Realizado com sucesso!";

                //TODO - Implementar redirecionamentos diferentes (Painel, carrinho de compras e etc)
                return RedirectToAction(nameof(CadastroCliente));
            }

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
                    _gerenciarEmail.EnviarContatoEmail(contato);

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
