namespace Titkack.Web.BusinessLayer
{
    public interface IMachineLearningProvider
    {
        (bool, float) PredictSatisfaction(string message);
    }
}