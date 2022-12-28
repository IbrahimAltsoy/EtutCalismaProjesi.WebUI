using EtutCalismaProjesi.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtutCalismaProjesi.Service.FluentValidation
{
    public class CategoriesValidator: AbstractValidator<Category>
    {
        public CategoriesValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Boş olrak ekleme yapamıyorsunuz...!")
               .NotNull().WithMessage("Boş olrak ekleme yapamıyorsunuz...!")
               .MaximumLength(50).WithMessage("Boş olrak ekleme yapamıyorsunuz...!")
               .MinimumLength(3).WithMessage("Boş olrak ekleme yapamıyorsunuz...!")
               .WithName("Kategori adı ");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Boş olrak ekleme yapamıyorsunuz...!")
               .NotNull().WithMessage("Boş olrak ekleme yapamıyorsunuz...!")
               .MaximumLength(300).WithMessage("Boş olrak ekleme yapamıyorsunuz...!")
               .MinimumLength(3).WithMessage("Boş olrak ekleme yapamıyorsunuz...!")
               .WithName("Kategori Açıklaması");
            
        }
    }
}
