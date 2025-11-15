using ConnectA.API.DTOs.Request;
using FluentValidation;

namespace ConnectA.API.DTOs.Validations;

public class ProfileRequestValdator : AbstractValidator<ProfileRequestDTO>
{

    public ProfileRequestValdator()
    {

        RuleFor(x => x.Biography)
            .NotEmpty().WithMessage("A biografia é obrigatória.")
            .MaximumLength(2000).WithMessage("A biografia pode ter no máximo 2000 caracteres.");

        RuleFor(x => x.Skills)
            .NotEmpty().WithMessage("As habilidades são obrigatórias.")
            .MaximumLength(500).WithMessage("As habilidades podem ter no máximo 500 caracteres.");

        RuleFor(x => x.Experience)
            .NotEmpty().WithMessage("A experiência é obrigatória.")
            .MaximumLength(2000).WithMessage("A experiência pode ter no máximo 2000 caracteres.");

        RuleFor(x => x.Objectives)
            .NotEmpty().WithMessage("Os objetivos são obrigatórios.")
            .MaximumLength(2000).WithMessage("Os objetivos podem ter no máximo 2000 caracteres.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("A localização é obrigatória.")
            .MaximumLength(200).WithMessage("A localização pode ter no máximo 200 caracteres.");

        RuleFor(x => x.Lenguages)
            .NotEmpty().WithMessage("Os idiomas são obrigatórios.")
            .MaximumLength(500).WithMessage("Os idiomas podem ter no máximo 500 caracteres.");
    }
    
}