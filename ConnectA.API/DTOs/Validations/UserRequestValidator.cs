using ConnectA.API.DTOs.Request;
using FluentValidation;

namespace ConnectA.API.DTOs.Validations;

public class UserRequestValidator : AbstractValidator<UserRequestDTO>
{
    public UserRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(3).WithMessage("Name must have at least 3 characters")
            .MaximumLength(100).WithMessage("Name must have at most 100 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must have at least 8 characters")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[0-9]").WithMessage("Password must contain at least one number")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");

        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Type is required")
            .Must(type => type.ToLower() is "jovem" or "senior")
            .WithMessage("Type must be one of the following: Jovem, Senior");
        
    }
    
}