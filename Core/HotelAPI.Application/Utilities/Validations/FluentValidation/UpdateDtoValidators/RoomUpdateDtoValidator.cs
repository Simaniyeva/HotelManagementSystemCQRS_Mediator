namespace HotelAPI.Application.Utilities.Validations.FluentValidation.UpdateDtoValidators;

public class RoomUpdateDtoValidator : AbstractValidator<RoomPostDto>
{
    public RoomUpdateDtoValidator()
    {
        RuleFor(c => c.Number)
            .NotEmpty()
            .NotNull()
            .WithMessage("Don't Enter Null")
            .WithMessage(Messages.EnterValid(Messages.Room));
    }

}