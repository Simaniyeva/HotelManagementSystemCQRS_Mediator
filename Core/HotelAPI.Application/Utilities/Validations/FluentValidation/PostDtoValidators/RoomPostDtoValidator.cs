namespace HotelAPI.Application.Utilities.Validations.FluentValidation.PostDtoValidators;

public class RoomPostDtoValidator : AbstractValidator<RoomPostDto>
{
    public RoomPostDtoValidator()
    {
        RuleFor(c => c.Number)
            .NotEmpty()
            .NotNull()
            .WithMessage("Don't Enter Null")
            .WithMessage(Messages.EnterValid(Messages.Room));
    }

}