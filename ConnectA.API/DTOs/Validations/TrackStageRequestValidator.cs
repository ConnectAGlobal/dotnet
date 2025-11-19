using ConnectA.API.DTOs.Request;
using FluentValidation;

namespace ConnectA.API.DTOs.Validations;

public class TrackStageRequestValidator : AbstractValidator<TrackStageRequestDTO>
{
    public TrackStageRequestValidator()
    {

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("O título é obrigatório.")
            .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição é obrigatória.")
            .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres.");

        RuleFor(x => x.ActivityType)
            .NotEmpty().WithMessage("O tipo de atividade é obrigatório.")
            .Must(type => type is "READING" or "CHALLENGE" or "REFLECTION" or "PROJECT")
            .WithMessage("ActivityType deve ser: READING, CHALLENGE, REFLECTION ou PROJECT.");

        RuleFor(x => x.Order)
            .GreaterThan(0).WithMessage("A ordem deve ser maior que zero.");

        RuleFor(x => x.EstimatedDuration)
            .GreaterThan(0).WithMessage("A duração estimada deve ser maior que zero.")
            .LessThanOrEqualTo(600).WithMessage("A duração estimada não pode ultrapassar 600 minutos (10h).");

        RuleFor(x => x.ResourceLink)
            .Must(link => Uri.TryCreate(link, UriKind.Absolute, out _) || string.IsNullOrWhiteSpace(link))
            .WithMessage("O link do recurso deve ser uma URL válida.");
    }
}