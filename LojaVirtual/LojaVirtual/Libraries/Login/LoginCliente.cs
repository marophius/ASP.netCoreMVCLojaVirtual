using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Sessao;
using LojaVirtual.Models;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Acesso
{
    public class LoginCliente
    {
        private Sessao.Sessao _sessao;
        private string _Key = "Login.Cliente";

        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Cliente cliente)
        {
            // armazenar na sessão
            string clienteJSONString = JsonConvert.SerializeObject(cliente);
            _sessao.Cadastrar(_Key, clienteJSONString);
        }

        public Cliente GetCliente()
        {
            if (_sessao.Existe(_Key))
            {
                string clienteJSONstring = _sessao.Consultar(_Key);
                return JsonConvert.DeserializeObject<Cliente>(clienteJSONstring);
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
