using LojaVirtual.Libraries.Acesso;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Filtro
{
    public class ClienteAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        private LoginCliente _loginCliente;

        

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginCliente = (LoginCliente)context.HttpContext.RequestServices.GetService(typeof(LoginCliente));

            Cliente cl = _loginCliente.GetCliente();

            if (cl == null)
            {
                context.Result = new ContentResult() { Content = "Acesso negado" };
            }
            
        }
    }
}
