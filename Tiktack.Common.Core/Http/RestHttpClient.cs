using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tiktack.Common.Core.Http.Interfaces;
using Tiktack.Common.Core.Serializers.Interfaces;

namespace Tiktack.Common.Core.Http
{
    internal class RestHttpClient: IRestHttpClient
    {
        private readonly IContentSerializerFactory _contentSerializerFactory;

        public RestHttpClient(IContentSerializerFactory contentSerializerFactory)
        {
            _contentSerializerFactory = contentSerializerFactory;
        }

        public async Task<object> InvokeAsync(string method, string url, string contentType,
            IEnumerable<KeyValuePair<string, object>> data, Type resultType)
        {
            HttpWebResponse response = null;
            try
            {
                var request = PrepareRequest(method, url, contentType, data);

                response = await request.GetResponseAsync() as HttpWebResponse;

                var res = ProcessResponse(response, resultType);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (resultType != typeof(Stream)) response?.Dispose();
            }
        }

        public object Invoke(string method, string url, string contentType,
            IEnumerable<KeyValuePair<string, object>> data, Type resultType)
        {
            var request = PrepareRequest(method, url, contentType, data);

            var response = request.GetResponse() as HttpWebResponse;

            var res = ProcessResponse(response, resultType);
            return res;
        }

        private HttpWebRequest PrepareRequest(string method,
            string url,
            string contentType,
            IEnumerable<KeyValuePair<string, object>> data)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = method;
            request.ContentType = contentType;

            var dataList = (data ?? Enumerable.Empty<KeyValuePair<string, object>>()).ToList();
            if (dataList.Count > 0)
                WriteBodyToRequest(request, contentType, dataList);
            else
                request.ContentLength = 0;

            return request;
        }

        private void WriteBodyToRequest(HttpWebRequest request, string contentType,
            ICollection<KeyValuePair<string, object>> data)
        {
            var serializer = _contentSerializerFactory.Create(contentType);
            if (data.Count == 1 && data.All(x => x.Value is Stream))
            {
                var stream = (Stream)data.First().Value;
                using (var s = request.GetRequestStream())
                {
                    stream.CopyTo(s);
                }
            }
            else
            {
                using (var s = request.GetRequestStream())
                {
                    serializer.Serialize(s, data);
                }
            }
        }

        private object ProcessResponse(HttpWebResponse response, Type resultType)
        {
            if (resultType == typeof(Stream)) return response.GetResponseStream();

            var contentType = ExtractContentType(response.ContentType);

            var serializer = _contentSerializerFactory.Create(contentType);

            using (var s = response.GetResponseStream())
            {
                return serializer.Deserialize(s, resultType);
            }
        }

        private static string ExtractContentType(string str)
        {
            return str?.Split(';')[0];
        }
    }
}
