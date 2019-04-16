using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tiktack.Common.Core.Http.Interfaces
{
    public interface IRestHttpClient
    {
        Task<object> InvokeAsync(string method, string url, string contentType,
            IEnumerable<KeyValuePair<string, object>> data, Type resultType);

        object Invoke(string method, string url, string contentType,
            IEnumerable<KeyValuePair<string, object>> data, Type resultType);
    }
}