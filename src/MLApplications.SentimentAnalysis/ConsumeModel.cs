// This file was auto-generated by ML.NET Model Builder. 

using Microsoft.ML;
using System;
using System.IO;

namespace MLApplications.SentimentAnalysis
{
    public class ConsumeModel
    {
        private static Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictionEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(CreatePredictionEngine);

        // For more info on consuming ML.NET models, visit https://aka.ms/mlnet-consume
        // Method for consuming model in your app
        public static ModelOutput Predict(ModelInput input)
        {
            ModelOutput result = PredictionEngine.Value.Predict(input);
            return result;
        }

        public static PredictionEngine<ModelInput, ModelOutput> CreatePredictionEngine()
        {
            // Create new MLContext
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            string currentPath = Directory.GetCurrentDirectory();
            string modelPath = @$"{currentPath}\MLModel.zip";
            ITransformer mlModel = mlContext.Model.Load(modelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            return predEngine;
        }
    }
}
