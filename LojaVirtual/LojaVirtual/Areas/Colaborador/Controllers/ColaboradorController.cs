using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Libraries.Filtro;
using LojaVirtual.Libraries.Lang;
using LojaVirtual.Libraries.Texto;
using LojaVirtual.Models;
using LojaVirtual.Models.Constantes;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao(ColaboradorTipoConstant.gerente)]
    public class ColaboradorController : Controller
    {
        private IColaboradorRepository _cbRepository;
        private GerenciarEmail _gerenciarEmail;

        public ColaboradorController(IColaboradorRepository cbRepos, GerenciarEmail gerenciarEmail)
        {
            _cbRepository = cbRepos;
            _gerenciarEmail = gerenciarEmail;
        }

        public IActionResult Index(int? pagina)
        {
            IPagedList<Models.Colaborador> colaboradores =  _cbRepository.ObterTodosColaboradores(pagina);

            return View(colaboradores);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Models.Colaborador cb)
        {
            ModelState.Remove("Senha");

            if (ModelState.IsValid)
            {
                cb.Tipo = ColaboradorTipoConstant.comum;
                cb.Senha = KeyGenerator.GetUniqueKey(8);
                _cbRepository.Cadastrar(cb);

                _gerenciarEmail.EnviarSenhaPorEmail(cb);


                TempData["MSG_S"] = Mensagem.MSG_S001;

                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [HttpGet]
        [ValidateHttpReferer]
        public IActionResult GerarSenha(int id)
        {
            var colaborador = _cbRepository.ObterColaborador(id);
            colaborador.Senha = KeyGenerator.GetUniqueKey(8);

            _cbRepository.AtualizarSenha(colaborador);

            _gerenciarEmail.EnviarSenhaPorEmail(colaborador);

            TempData["MSG_S"] = Mensagem.MSG_S003;

            return RedirectToAction(nameof(Index));

        }


        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            var colaborador = _cbRepository.ObterColaborador(id);
            return View(colaborador);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Models.Colaborador cb, int id)
        {
            ModelState.Remove("Senha");

            if (ModelState.IsValid)
            {
                _cbRepository.Atualizar(cb);

                TempData["MSG_S"] = Mensagem.MSG_S001;

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        [ValidateHttpReferer]
        public IActionResult Excluir(int id)
        {
            _cbRepository.Excluir(id);
            TempData["MSG_S"] = Mensagem.MSG_S002;

            return RedirectToAction(nameof(Index));
        }

    }
}
