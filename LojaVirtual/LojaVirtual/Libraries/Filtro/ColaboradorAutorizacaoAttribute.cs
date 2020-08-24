using LojaVirtual.Libraries.Login;
using LojaVirtual.Models;
using LojaVirtual.Models.Constantes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Filtro
{
    public class ColaboradorAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        private LoginColaborador _loginColaborador;
        private string _TipoColaboradorAutorizado;

        public ColaboradorAutorizacaoAttribute(string tipoColaboradorAutorizado = ColaboradorTipoConstant.comum)
        {
            _TipoColaboradorAutorizado = tipoColaboradorAutorizado;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginColaborador = (LoginColaborador)context.HttpContext.RequestServices.GetService(typeof(LoginColaborador));

            Colaborador colab = _loginColaborador.GetColaborador();

            if(colab == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }else
            {
                if(colab.Tipo == ColaboradorTipoConstant.comum && _TipoColaboradorAutorizado == ColaboradorTipoConstant.gerente)
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
