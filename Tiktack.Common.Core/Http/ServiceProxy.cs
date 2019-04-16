using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Tiktack.Common.Core.Http.Interfaces;

namespace Tiktack.Common.Core.Http
{
    public class ServiceProxy<T> : DispatchProxy
    {
        private IRestHttpClient _client;
        private IConfiguration _configuration;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            // Get http method (get, post etc.)
            var method = GetHttpMethodForAction(targetMethod);
            //Get route from attribute [RouteAttribute("")]
            var methodUrl = GetTemplateUriForAction(targetMethod);
            //Get endpoint from configuration 
            var endpoint = GetEndpoint(targetMethod);

            var url = $"{endpoint}/{methodUrl}";

            AnalyzeReturnType(targetMethod.ReturnType, out var isAsyncCall, out var returnObjectType);

            var httpClientInvoker = GetRestClientInvoker(isAsyncCall);
            var responseObj = httpClientInvoker(method, url, null, null, returnObjectType);
            //If it is async we convert to Task<T>
            if (isAsyncCall && returnObjectType != typeof(void))
                return Convert((Task<object>)responseObj, returnObjectType);

            return responseObj;
        }

        private string GetEndpoint(MemberInfo methodMetaData)
        {
            var name = methodMetaData.DeclaringType.Name;
            var cutName = name.Replace("Contract", "").Substring(1);

            return _configuration[$"Endpoints:{cutName}"].Trim('/');
        }

        private static string GetHttpMethodForAction(MemberInfo methodMetaData)
        {
            var httpMethodAttrs = methodMetaData.GetCustomAttributes()
                .Where(attr => attr is IActionHttpMethodProvider)
                .ToList();

            var httpMethods = (httpMethodAttrs.First() as IActionHttpMethodProvider)?.HttpMethods;

            if (httpMethods == null)
                throw new InvalidOperationException();

            return httpMethods.First();
        }

        private static string GetTemplateUriForAction(MemberInfo methodMetaData)
        {
            var routeAttrs = methodMetaData.GetCustomAttributes()
                .Where(attr => attr is RouteAttribute)
                .ToList();

            if (routeAttrs.Count != 1)
                throw new Exception(
                    $"More than 1 Route attributes are assigned to {methodMetaData.ReflectedType?.Name}.{methodMetaData.Name}(...)");

            if (!(routeAttrs.First() is RouteAttribute))
                throw new Exception(
                    $"No Route attributes are assigned to {methodMetaData.ReflectedType?.Name}.{methodMetaData.Name}(...)");

            return ((RouteAttribute)routeAttrs.First()).Template;
        }

        private Func<string, string, string, IEnumerable<KeyValuePair<string, object>>, Type, object>
            GetRestClientInvoker(bool isAsyncCall)
        {
            if (isAsyncCall)
                return _client.InvokeAsync;
            return _client.Invoke;
        }

        private Task Convert(Task<object> task, Type targetTaskType)
        {
            var method = new Converter().GetType()
                .GetMethod(nameof(System.Convert), BindingFlags.Static | BindingFlags.Public);
            if (method == null) throw new Exception("Can't find convert method");

            var convertMethod = method.MakeGenericMethod(targetTaskType);
            return (Task)convertMethod.Invoke(null, new object[] { task });
        }

        private static void AnalyzeReturnType(Type type, out bool isAsyncCall, out Type returnObjectType)
        {
            if (typeof(Task).IsAssignableFrom(type))
            {
                isAsyncCall = true;
                var genericTypes = type.GetGenericArguments();
                returnObjectType = genericTypes.Length == 0 ? typeof(void) : genericTypes.First();
            }
            else
            {
                isAsyncCall = false;
                returnObjectType = type;
            }
        }

        public static T Create(IRestHttpClient client, IConfiguration configuration)
        {
            object proxy = Create<T, ServiceProxy<T>>();
            ((ServiceProxy<T>)proxy).SetParameters(client, configuration);

            return (T)proxy;
        }

        private void SetParameters(IRestHttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }
    }

    public class Converter
    {
        public static async Task<T> Convert<T>(Task<object> task)
        {
            var result = await task;

            return (T)result;
        }
    }
}
