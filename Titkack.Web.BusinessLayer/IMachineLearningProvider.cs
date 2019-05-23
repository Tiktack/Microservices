namespace Titkack.Web.BusinessLayer
{
    public interface IMachineLearningProvider
    {
        /// <summary>
        /// Predict
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        (bool, float) PredictSatisfaction(string message);
    }
}