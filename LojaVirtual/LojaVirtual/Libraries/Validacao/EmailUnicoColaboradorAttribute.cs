using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Validacao
{
    public class EmailUnicoColaboradorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Pegar o valor do campo
            string email = (value as string).Trim();
            IColaboradorRepository cbRepos = (IColaboradorRepository)validationContext.GetService(typeof(IColaboradorRepository));

            List<Colaborador> list = cbRepos.ObterColaboradorEmail(email);

            Colaborador obj = (Colaborador) validationContext.ObjectInstance;

            if(list.Count > 1)
            {
                return new ValidationResult("E-mail já existente!");
            }

            if (list.Count == 0 && obj.Id != list[0].Id)
            {
                return new ValidationResult("Email já existente!");
            }

            return ValidationResult.Success;
        }
    }
}
