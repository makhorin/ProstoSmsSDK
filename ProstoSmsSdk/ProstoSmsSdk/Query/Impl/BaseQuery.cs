using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ProstoSmsSdk.Responses;

namespace ProstoSmsSdk.Query.Impl
{
    public abstract class BaseQuery<T> : IQuery<T>
    {
        private readonly string _baseUrl;
        protected readonly Dictionary<string, string> Parameters = new Dictionary<string, string>();

        protected BaseQuery(string apiKey, string baseUrl)
        {
            _baseUrl = baseUrl;
            if (!_baseUrl.EndsWith('/')) _baseUrl += '/';
            _baseUrl += '?';
            Parameters["key"] = apiKey;
            Parameters["format"] = "json";
        }

        protected BaseQuery(string email, string password, string baseUrl)
        {
            _baseUrl = baseUrl;
            if (!_baseUrl.EndsWith('/')) _baseUrl += '/';
            _baseUrl += '?';
            Parameters["email"] = email;
            Parameters["password"] = password;
            Parameters["format"] = "json";
        }

        private string Build()
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.Append(_baseUrl);
            foreach (var (paramName,paramValue) in Parameters)
            {
                queryBuilder.AppendFormat("{0}={1}&", paramName, HttpUtility.UrlEncode(paramValue));
            }
            queryBuilder.Remove(queryBuilder.Length - 1, 1);
            return queryBuilder.ToString();
        }

        public async Task<T> ExecuteAsync()
        {
            using var httpClient = new HttpClient();
            var queryString = Build();
            using var raw = httpClient.GetStreamAsync(queryString);
            var serializer = new DataContractJsonSerializer(typeof(BaseResponse<T>), new DataContractJsonSerializerSettings
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd HH:mm:ss")
            });
            var response = ((BaseResponse<T>)serializer.ReadObject(await raw)).Response;
            switch (response.Message.ErrorCode)
            {
                case "0": break;
                default: throw new ApiException(response.Message.ErrorCode, response.Message.Text);
            }
            return response.Data;
        }
    }

    public class ApiException : Exception
    {
        public ApiException(string code, string apiErrorText) : base($"Error: {code} Message: {apiErrorText}"){}
    }
}
