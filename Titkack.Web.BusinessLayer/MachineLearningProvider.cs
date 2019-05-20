using System.IO;
using System.Security.Cryptography;
using Microsoft.ML;
using Tiktack.Web.ApiML.Model.DataModels;

namespace Titkack.Web.BusinessLayer
{
    public class MachineLearningProvider : IMachineLearningProvider
    {

        private readonly MLContext _mlContext;
        private readonly ITransformer _mlModel;
        private readonly PredictionEngine<ModelInput, ModelOutput> _predictionEngine;
        public MachineLearningProvider()
        {
            // Load the model
            _mlContext = new MLContext();
            _mlModel = _mlContext.Model.Load(@"./bin/debug/netcoreapp3.0/MLModel.zip", out var modelInputSchema);

            _predictionEngine = _mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(_mlModel);

        }

        public (bool, float) PredictSatisfaction(string message)
        {
            var input = new ModelInput
            {
                SentimentText = message
            };

            // Try model on sample data
            var result = _predictionEngine.Predict(input);
            return (result.Prediction, result.Score);
        }
    }
}
