namespace HotelAPI.Application.Utilities.Validations.FluentValidation.UpdateDtoValidators;

internal class LoginUpdateDtoValidator:AbstractValidator<LoginDto>
{
public LoginUpdateDtoValidator()
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