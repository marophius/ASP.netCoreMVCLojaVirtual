using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class NewsLetterRepository : INewsLetterRepository
    {
        private LojaVirtualContext _banco;

        public NewsLetterRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        public void Cadastrar(NewsLetterEmail newsLetter)
        {
            _banco.Email.Add(newsLetter);
            _banco.SaveChanges();
        }

        public IEnumerable<NewsLetterEmail> ObterTodasNewsLetter()
        {
            return _banco.Email.ToList();
        }
    }
}
