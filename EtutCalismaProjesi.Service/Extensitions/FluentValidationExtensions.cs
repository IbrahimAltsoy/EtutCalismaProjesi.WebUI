using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtutCalismaProjesi.Service.Extensitions
{
    public static class FluentValidationExtensions
    {
        public static void AddToModelState(this ValidationResult result)
        {
            var error = result.Errors.FirstOrDefault();
            if (error != null)
            {
                result.Errors.Remove(error);
            }
            
        }
    }
}
