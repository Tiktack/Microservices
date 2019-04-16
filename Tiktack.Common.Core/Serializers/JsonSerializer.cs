using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Tiktack.Common.Core.Serializers.Interfaces;

namespace Tiktack.Common.Core.Serializers
{
    public class JsonSerializer : IContentSerializer
    {
        public IEnumerable<string> ContentTypes => new[] {"application/json"};

        public void Serialize(Stream stream, IEnumerable<KeyValuePair<string, object>> values)
        {
            var valuesList = (values ?? Enumerable.Empty<KeyValuePair<string, object>>()).ToList();
            if (valuesList.Count != 1)
                throw new ArgumentException($"{GetType().Name} expects only 1 value");

            var value = valuesList.First();
            var str = JsonConvert.SerializeObject(value.Value);
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(str);
                sw.Flush();
            }
        }

        public object Deserialize(Stream stream, Type type)
        {
            using (var s = new StreamReader(stream))
            {
                var str = s.ReadToEnd();
                var value = JsonConvert.DeserializeObject(str, type);
                return value;
            }
        }
    }
}