namespace HotelAPI.Application.Utilities.Validations.FluentValidation.UpdateDtoValidators;

public class RegisterUpdateDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterUpdateDtoValidator()
    {
        RuleFor(c => c.FirstName)
        .NotEmpty()
        .NotNull()
        .MinimumLength(5)
        .MaximumLength(50);

        RuleFor(c => c.LastName)
        .NotEmpty()
        .NotNull()
        .MinimumLength(2)
        .MaximumLength(50);

        RuleFor(c => c.Email)
            .NotEmpty()
            .MaximumLength(60)
            .MinimumLength(8);

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(6);

        RuleFor(c => c.ConfirmPassword)
            .NotEmpty()
            .MinimumLength(6)
            .Equal(c => c.Password);

    }
}
