using FluentValidation;
using OnionLibrary.Application.DTOClasses;

namespace OnionLibrary.ValidatorStructor.Validators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("kitap isimsiz olamaz");
            RuleFor(x => x.AuthorId).GreaterThan(0).WithMessage("yazar secimi zorunludur");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("kategori secimi zorunludur");
        }
    }


}


