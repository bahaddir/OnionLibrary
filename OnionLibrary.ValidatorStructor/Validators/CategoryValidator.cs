using FluentValidation;
using OnionLibrary.Application.DTOClasses;

namespace OnionLibrary.ValidatorStructor.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("kategori ismi bos olamaz");
        }
    }


}


