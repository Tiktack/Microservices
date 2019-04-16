using System;
using System.Collections.Generic;
using System.IO;

namespace Tiktack.Common.Core.Serializers.Interfaces
{
    public interface IContentSerializer
    {
        IEnumerable<string> ContentTypes { get; }
        void Serialize(Stream stream, IEnumerable<KeyValuePair<string, object>> values);
        object Deserialize(Stream stream, Type type);
    }
}