using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Filtro;
using LojaVirtual.Libraries.Lang;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao]
    public class CategoriaController : Controller
    {

        private ICategoriaRepository _categoriaRepos;

        public CategoriaController(ICategoriaRepository cat)
        {
            _categoriaRepos = cat;
        }

        public IActionResult Index(int? page)
        {
           var list = _categoriaRepos.ObterTodasCategorias(page);

            return View(list);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = _categoriaRepos.ObterTodasCategorias().Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepos.Cadastrar(categoria);

                TempData["MSG_S"] = Mensagem.MSG_S001;

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categorias = _categoriaRepos.ObterTodasCategorias().Select(a => new SelectListItem(a.Nome, a.Id.ToString()));

            return View();
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            var categoriaById = _categoriaRepos.ObterCategoria(id);
            ViewBag.Categorias = _categoriaRepos.ObterTodasCategorias().Where(a => a.Id != id).Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            return View(categoriaById);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Categoria categoria, int id)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepos.Atualizar(categoria);
                TempData["MSG_S"] = Mensagem.MSG_S001;

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categorias = _categoriaRepos.ObterTodasCategorias().Where(a => a.Id != id).Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            _categoriaRepos.Excluir(id);
            TempData["MSG_S"] = Mensagem.MSG_S002;

            return RedirectToAction(nameof(Index));
        }

    }
}
