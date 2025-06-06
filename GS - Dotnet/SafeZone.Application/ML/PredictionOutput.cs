namespace SafeZone.Application.ML.Models;

public class PredictionOutput
{
    public string PredictedLabel { get; set; } = string.Empty;
    public float Probability { get; set; }
}
