using LojaVirtual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Login
{
    public class LoginColaborador
    {
        private Sessao.Sessao _sessao;
        private string _Key = "Login.Colaborador";

        public LoginColaborador(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Colaborador colaborador)
        {
            // armazenar na sessão
            string colaboradorJSONString = JsonConvert.SerializeObject(colaborador);
            _sessao.Cadastrar(_Key, colaboradorJSONString);
        }

        public Colaborador GetColaborador()
        {
            if (_sessao.Existe(_Key))
            {
                string colaboradorJSONString = _sessao.Consultar(_Key);
                return JsonConvert.DeserializeObject<Colaborador>(colaboradorJSONString);
            }

            else
            {
                return null;
            }

        }

        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}
