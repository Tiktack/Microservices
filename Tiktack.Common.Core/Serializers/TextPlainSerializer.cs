using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tiktack.Common.Core.Serializers.Interfaces;

namespace Tiktack.Common.Core.Serializers
{
    public class TextPlainSerializer : IContentSerializer
    {
        public IEnumerable<string> ContentTypes => new[] {"text/html", "application/javascript", "text/plain"};

        public void Serialize(Stream stream, IEnumerable<KeyValuePair<string, object>> values)
        {
            var valuesList = (values ?? Enumerable.Empty<KeyValuePair<string, object>>()).ToList();
            if (valuesList.Count != 1)
                throw new ArgumentException($"{GetType().Name} expects only 1 value");

            if (!(valuesList.First().Value is string bodyContent))
                throw new ArgumentException("The content should be string type");
            var bytes = Encoding.ASCII.GetBytes(bodyContent);
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
        }

        public object Deserialize(Stream stream, Type type)
        {
            using (var s = new StreamReader(stream))
            {
                var content = s.ReadToEnd();
                object value;
                if (type == typeof(string))
                    value = content;
                else
                    throw new NotSupportedException();
                return value;
            }
        }
    }
}