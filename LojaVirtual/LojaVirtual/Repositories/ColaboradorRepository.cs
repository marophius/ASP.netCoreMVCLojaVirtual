using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Models.Constantes;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private IConfiguration _conf;
        private LojaVirtualContext _banco;

        public ColaboradorRepository(LojaVirtualContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _conf = configuration;
        }

        public void Atualizar(Colaborador colaborador)
        {
            _banco.Update(colaborador);
            _banco.Entry(colaborador).Property(a => a.Senha).IsModified = false;
            _banco.SaveChanges();
        }

        public void AtualizarSenha(Colaborador cb)
        {
            _banco.Update(cb);
            _banco.Entry(cb).Property(a => a.Nome).IsModified = false;
            _banco.Entry(cb).Property(a => a.Email).IsModified = false;
            _banco.Entry(cb).Property(a => a.Tipo).IsModified = false;

            _banco.SaveChanges();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            _banco.Add(colaborador);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            Colaborador cb = ObterColaborador(id);
            _banco.Remove(cb);
            _banco.SaveChanges();
        }

        public Colaborador Login(string email, string senha)
        {
            Colaborador cb = _banco.Colaboradores.Where(c => c.Email == email && c.Senha == senha).FirstOrDefault();
            return cb;
        }

        public Colaborador ObterColaborador(int id)
        {
            return _banco.Colaboradores.Find(id);
        }

        public List<Colaborador> ObterColaboradorEmail(string email)
        {
            return _banco.Colaboradores.Where(c => c.Email == email).AsNoTracking().ToList();
        }

        //public IEnumerable<Colaborador> ObterTodosColaboradores()
        //{
        //    return _banco.Colaboradores.Where(a => a.Tipo != "G").ToList();
        //}

        public IPagedList<Colaborador> ObterTodosColaboradores(int? pagina)
        {
            int registroPorPagina = _conf.GetValue<int>("RegistroPorPagina");
            int numeroPagina = pagina ?? 1;
            return _banco.Colaboradores.Where(a => a.Tipo != ColaboradorTipoConstant.gerente).ToPagedList<Colaborador>(numeroPagina, registroPorPagina);
        }
    }
}
