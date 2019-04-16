namespace Tiktack.Common.Core.Http.Interfaces
{
    public interface IGeneratorWebServiceProxy<out T>
    {
        T GetWebService();
    }
}