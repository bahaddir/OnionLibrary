using FluentValidation;
using OnionLibrary.Application.DTOClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLibrary.ValidatorStructor.Validators
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("isim bos olamaz");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("soyisim bos olamaz");
        }
    }



}


