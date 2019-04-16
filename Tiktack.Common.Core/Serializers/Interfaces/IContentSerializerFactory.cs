namespace Tiktack.Common.Core.Serializers.Interfaces
{
    public interface IContentSerializerFactory
    {
        IContentSerializer Create(string contentType);
    }
}