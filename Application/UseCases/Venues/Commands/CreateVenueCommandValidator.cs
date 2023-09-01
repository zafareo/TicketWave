using FluentValidation;
namespace Application.UseCases.Venues.Commands;

public class CreateVenueCommandValidator : AbstractValidator<CreateVenueCommand>
{
    public CreateVenueCommandValidator()
    {
        RuleFor(venue => venue.Name).NotEmpty().WithMessage("Venue Name is required")
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(venue => venue.Address).NotEmpty().WithMessage("Venue Address is required")
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(venue => venue.Capacity).NotEmpty().GreaterThan(0);
    }
}
