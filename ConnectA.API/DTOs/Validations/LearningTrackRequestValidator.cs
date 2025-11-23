using ConnectA.API.DTOs.Request;
using FluentValidation;

namespace ConnectA.API.DTOs.Validations;

public class LearningTrackRequestValidator : AbstractValidator<LearningTrackRequestDTO>
{
    public LearningTrackRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição é obrigatória.")
            .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres.");

        RuleFor(x => x.Level)
            .NotEmpty().WithMessage("O nível é obrigatório.")
            .Must(level => level == "Beginner" || level == "Intermediate" || level == "Advanced")
            .WithMessage("O nível deve ser: Beginner, Intermediate ou Advanced.");

        RuleFor(x => x.SeniorId)
            .NotEmpty().WithMessage("O SeniorId é obrigatório.")
            .NotEqual(Guid.Empty).WithMessage("O SeniorId não pode ser Guid.Empty.");

        RuleFor(x => x.TrackStages)
            .NotNull().WithMessage("A lista de TrackStages é obrigatória.")
            .Must(stages => stages.Count > 0).WithMessage("É necessário ao menos 1 TrackStage.");
        
        RuleForEach(x => x.TrackStages)
            .SetValidator(new TrackStageRequestValidator());
    }
}