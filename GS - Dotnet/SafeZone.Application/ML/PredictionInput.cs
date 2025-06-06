namespace SafeZone.Application.ML.Models;

public class PredictionInput
{
    public float Idade { get; set; }
    public string Localizacao { get; set; } = string.Empty;
}
