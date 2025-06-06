using Microsoft.ML;
using SafeZone.Application.ML.Models;

namespace SafeZone.Application.ML;

public class MLModelPredictor
{
    private readonly PredictionEngine<PredictionInput, PredictionOutput> _predictionEngine;

    public MLModelPredictor()
    {
        var mlContext = new MLContext();

        // Caminho para o modelo .zip
        var modelPath = Path.Combine(AppContext.BaseDirectory, "ML", "model.zip");

        // Carrega o modelo
        DataViewSchema modelSchema;
        ITransformer mlModel = mlContext.Model.Load(modelPath, out modelSchema);

        // Cria o PredictionEngine
        _predictionEngine = mlContext.Model.CreatePredictionEngine<PredictionInput, PredictionOutput>(mlModel);
    }

    public PredictionOutput Predict(PredictionInput input)
    {
        return _predictionEngine.Predict(input);
    }
}
