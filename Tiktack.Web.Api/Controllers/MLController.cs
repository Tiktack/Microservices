using Microsoft.AspNetCore.Mvc;
using Titkack.Web.BusinessLayer;

namespace Tiktack.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MLController : ControllerBase
    {
        private readonly IMachineLearningProvider _learningProvider;

        public MLController(IMachineLearningProvider learningProvider)
        {
            _learningProvider = learningProvider;
        }

        [HttpGet("getPrediction")]
        public string GetPrediction(string message)
        {
            var (prediction, percentage) = _learningProvider.PredictSatisfaction(message);
            return $"Prediction is {prediction} with {percentage}%";
        }
    }
}