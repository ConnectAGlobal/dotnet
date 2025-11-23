using ConnectA.Application.Repositories;
using ConnectA.Application.Services;
using ConnectA.Domain.Entities;

namespace ConnectA.Application.UseCases.Matching;

public class GenerateMatchUseCase(
    IUserRepository userRepository,
    IMentorshipMatchRepository matchRepository,
    MatchingMLService ml)
{
    public async Task GenerateMatch()
    {
        var juniors = await userRepository.GetAvailableJuniorsAsync();
        var seniors = await userRepository.GetAvailableSeniorsAsync();

        if (juniors.Count == 0 || seniors.Count == 0)
            return;

        // build corpus from available users so ML.NET featurizer learns the vocabulary
        var corpus = new List<string>();
        foreach (var j in juniors)
            corpus.Add(UserToMLTextMapper.BuildJuniorText(j));
        foreach (var s in seniors)
            corpus.Add(UserToMLTextMapper.BuildSeniorText(s));

        var model = ml.CreateModel(corpus);

        foreach (var junior in juniors)
        {
            var juniorText = UserToMLTextMapper.BuildJuniorText(junior);
            var juniorVector = ml.CreateVector(model, juniorText);

            double bestScore = double.NegativeInfinity;
            User bestSenior = null;

            foreach (var senior in seniors)
            {
                var seniorText = UserToMLTextMapper.BuildSeniorText(senior);
                var seniorVector = ml.CreateVector(model, seniorText);

                var score = MatchingMLService.Cosine(juniorVector, seniorVector);

                if (!(score > bestScore)) continue;
                bestScore = score;
                bestSenior = senior;
            }

            if (bestSenior is null)
                continue;

            var match = new MentorshipMatch(
                junior.Id, 
                bestSenior.Id, 
                compatibilityScore: bestScore
            );

            await matchRepository.SaveAsync(match);
        }
    }
}