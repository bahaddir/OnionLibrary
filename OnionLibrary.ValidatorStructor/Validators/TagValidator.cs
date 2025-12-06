using FluentValidation;
using OnionLibrary.Application.DTOClasses;

namespace OnionLibrary.ValidatorStructor.Validators
{
    public class TagValidator : AbstractValidator<TagDto>
    {
        public TagValidator()
        {
            RuleFor(x => x.TagName).NotEmpty().WithMessage("TagName bos olamaz");

        }
    }



}


