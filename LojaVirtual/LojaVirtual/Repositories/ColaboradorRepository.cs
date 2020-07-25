using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {

        private LojaVirtualContext _banco;

        public ColaboradorRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        public void Atualizar(Colaborador colaborador)
        {
            _banco.Update(colaborador);
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

        public IEnumerable<Colaborador> ObterTodosColaboradores()
        {
            return _banco.Colaboradores.ToList();
        }
    }
}
