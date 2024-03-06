namespace HotelAPI.Application.Utilities.Validations.FluentValidation.UpdateDtoValidators;

public class ServiceUpdateDtoValidator : AbstractValidator<ServicePostDto>
{
    public ServiceUpdateDtoValidator()
    {
        RuleFor(c => c.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("Don't Enter Null ")
            .MinimumLength(2)
            .MaximumLength(255)
            .WithMessage(Messages.EnterValid(Messages.Service));
        RuleFor(c => c.Price)
            .NotEmpty()
            .NotNull();
    }

}