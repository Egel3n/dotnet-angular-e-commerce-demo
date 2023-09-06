using ETicaretAPI.Application.ViewModels;
using ETicaretAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class Create_Product_Validator :AbstractValidator<VM_Product_Create>
    {
        public Create_Product_Validator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Lütfen Doldur").NotNull().WithMessage("Lütfen Doldur").MinimumLength(3).WithMessage("En az 3 karakter");
            RuleFor(x=>x.Price).NotEmpty().WithMessage("Lütfen Doldur").NotNull().WithMessage("Lütfen Doldur").GreaterThanOrEqualTo(0).WithMessage("Pozitif olsun");
            RuleFor(x => x.Stock).NotEmpty().NotNull().WithMessage("Lütfen Doldur").GreaterThanOrEqualTo(0).WithMessage("Pozitif olsun");
        }


    }
}
