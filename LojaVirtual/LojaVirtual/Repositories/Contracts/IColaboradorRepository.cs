using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Repositories.Contracts
{
    public interface IColaboradorRepository
    {
        Colaborador Login(string email, string senha);

        //CRUD
        void Cadastrar(Colaborador colaborador);
        void Atualizar(Colaborador colaborador);
        void AtualizarSenha(Colaborador cb);
        void Excluir(int id);
        // IEnumerable<Colaborador> ObterTodosColaboradores();
        Colaborador ObterColaborador(int id);
        List<Colaborador> ObterColaboradorEmail(string email);
        IPagedList<Colaborador> ObterTodosColaboradores(int? pagina);

    }
}
