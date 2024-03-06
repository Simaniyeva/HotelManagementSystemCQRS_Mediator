namespace HotelAPI.Application.Utilities.Validations.FluentValidation.PostDtoValidators;

internal class LoginDtoValidator:AbstractValidator<LoginDto>
{
public LoginDtoValidator()
{
    RuleFor(c => c.Email)
        .NotEmpty()
        .MaximumLength(60)
        .MinimumLength(8);

    RuleFor(c => c.Password)
        .NotEmpty()
        .MinimumLength(6);

}
}