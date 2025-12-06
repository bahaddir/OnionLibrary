using FluentValidation;
using OnionLibrary.Application.DTOClasses;

namespace OnionLibrary.ValidatorStructor.Validators
{
    public class BookTagValidator : AbstractValidator<BookTagDto>
    {
        public BookTagValidator()
        {
            RuleFor(x => x.TagId).GreaterThan(0).WithMessage("TagId secimi zorunludur");
            RuleFor(x => x.BookId).GreaterThan(0).WithMessage("BookId secimi zorunludur");
        }
    }


}


