using Foundation.AssetManagement.Interfaces;
using Foundation.AssetManagement.Models;
using System;
using Newtonsoft.Json;

namespace Foundation.AssetManagement.Services
{
    public class ExternalService : IExternalService
    {
        public ExternalServiceSearchResponse Search(string query, int startFrom, int pageSize)
        {
            throw new NotImplementedException();
        }

        private static string GetRequestQueryString(string query, int startFrom, int pageSize)
        {
            var requestObject = new
            {
                query = new {
                    query = query

                },
                    from = startFrom,
                    size = pageSize
         
            };
            var requestString = JsonConvert.SerializeObject(requestObject);
            return requestString;
        }
    }
}