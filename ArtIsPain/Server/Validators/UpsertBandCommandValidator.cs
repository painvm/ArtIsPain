using ArtIsPain.Server.Commands.Band;
using FluentValidation;

namespace ArtIsPain.Server.Validators
{
    public class UpsertBandCommandValidator : AbstractValidator<UpsertBandCommand>
    {
        public UpsertBandCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Band name should not be empty")
                .MaximumLength(255)
                .WithMessage("The maximum length of band name is exceeded");
        }
    }
}