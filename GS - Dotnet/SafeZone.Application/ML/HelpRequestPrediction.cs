﻿namespace SafeZone.Application.ML;

public class HelpRequestPrediction
{
    public bool PredictedLabel { get; set; }
    public float Probability { get; set; }
    public float Score { get; set; }
}
