using Microsoft.AspNetCore.Mvc;
using SafeZone.Application.ML;
using SafeZone.Application.ML.Models;

namespace SafeZone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PredictionController : ControllerBase
{
    private readonly MLModelPredictor _predictor;

    public PredictionController(MLModelPredictor predictor)
    {
        _predictor = predictor;
    }

    /// <summary>
    /// Realiza uma previsão de risco com base em idade e localização.
    /// </summary>
    /// <param name="input">Dados de entrada</param>
    /// <returns>Resultado da predição</returns>
    [HttpPost("predict")]
    public IActionResult Predict([FromBody] PredictionInput input)
    {
        var result = _predictor.Predict(input);

        return Ok(new
        {
            Risco = result.PredictedLabel == "1" ? "Alto" : "Baixo",
            Precisao = result.Probability.ToString("P2")
        });
    }
}
