using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private IConfiguration _conf;

        private readonly LojaVirtualContext _banco;

        public CategoriaRepository(LojaVirtualContext banco, IConfiguration config)
        {
            _banco = banco;
            _conf = config;
        }

        public void Atualizar(Categoria categoria)
        {
            _banco.Update(categoria);
            _banco.SaveChanges();
        }

        public void Cadastrar(Categoria categoria)
        {
            _banco.Add(categoria);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            Categoria cat = ObterCategoria(id);
            _banco.Remove(cat);
            _banco.SaveChanges();
        }

        public Categoria ObterCategoria(int id)
        {
            return _banco.Categorias.Find(id);
        }

        public IPagedList<Categoria> ObterTodasCategorias(int? page)
        {
            int registroPorPagina = _conf.GetValue<int>("RegistroPorPagina");
            int numeroPagina = page ?? 1;
            return _banco.Categorias.Include(a => a.CategoriaPai).ToPagedList<Categoria>(numeroPagina, registroPorPagina);
        }

        public IEnumerable<Categoria> ObterTodasCategorias()
        {
            return _banco.Categorias;
        }
    }
}
