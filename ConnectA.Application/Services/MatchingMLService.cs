using ConnectA.Application.DTOs;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace ConnectA.Application.Services;

public class MatchingMLService
{
    private readonly MLContext _ml = new MLContext(seed: 0);

    private const string FEATURES = "Features";

    public ITransformer CreateModel(IEnumerable<string> corpus)
    {
        var texts = (corpus ?? []).Select(t => new MatchProfileData { FullText = t });
        var sample = _ml.Data.LoadFromEnumerable(texts);
        
        var pipeline = _ml.Transforms.Text.TokenizeIntoWords("Tokens", nameof(MatchProfileData.FullText))
            .Append(_ml.Transforms.Conversion.MapValueToKey("TokensKey", "Tokens"))
            .Append(_ml.Transforms.Text.ProduceNgrams(FEATURES, "TokensKey", ngramLength: 1, useAllLengths: false));

        return pipeline.Fit(sample);
    }

    public float[] CreateVector(ITransformer model, string? text)
    {
        var data = new[] { new MatchProfileData { FullText = text ?? string.Empty } };
        var input = _ml.Data.LoadFromEnumerable(data);
        var transformed = model.Transform(input);
        
        var column = transformed.GetColumn<VBuffer<float>>(FEATURES).First();

        return column.DenseValues().ToArray();
    }

    public static double Cosine(float[] a, float[] b)
    {
        double dot = 0, magA = 0, magB = 0;

        for (var i = 0; i < a.Length; i++)
        {
            dot += a[i] * b[i];
            magA += a[i] * a[i];
            magB += b[i] * b[i];
        }

        return dot / (Math.Sqrt(magA) * Math.Sqrt(magB));
    }
}