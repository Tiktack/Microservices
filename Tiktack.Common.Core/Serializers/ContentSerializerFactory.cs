using System;
using System.Collections.Generic;
using System.Linq;
using Tiktack.Common.Core.Serializers.Interfaces;

namespace Tiktack.Common.Core.Serializers
{
    public class ContentSerializerFactory : IContentSerializerFactory
    {
        private readonly IEnumerable<IContentSerializer> _contentSerializers;

        public ContentSerializerFactory(IEnumerable<IContentSerializer> contentSerializers)
        {
            _contentSerializers = contentSerializers;
        }

        public IContentSerializer Create(string contentType)
        {
            return _contentSerializers
                .FirstOrDefault(x => x.ContentTypes.Contains(contentType, StringComparer.OrdinalIgnoreCase));
        }
    }
}