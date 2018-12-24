using System;
using Foundation.AssetManagement.Configuration;
using Foundation.AssetManagement.Interfaces;
using Foundation.AssetManagement.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Foundation.AssetManagement.Services
{
    public class ExternalService : IExternalService
    {
        public ExternalServiceSearchResponse Search(string query, int startFrom, int pageSize)
        {
            string requestString = GetRequestQueryString(query, startFrom, pageSize);
            var url = ConfigSettings.SearchUrl;
            WebRequest request = RequestPost(url, "", requestString);
            using (WebResponse response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string result = reader.ReadToEnd();

                    return JsonConvert.DeserializeObject<ExternalServiceSearchResponse>(result);
                }
            }
        }

        private static string GetRequestQueryString(string query, int startFrom, int pageSize)
        {
            var requestObject = new
            {
                query = new
                {
                    multi_match = new
                    {
                        query = query,
                        fields = new[]
                        {
                            "combined_fields"
                        },
                        @operator = "and",
                        type = "best_fields",
                        fuzziness = "auto",
                        minimum_should_match = 0
                    }
                },
                from = startFrom,
                size = pageSize,
                sort = new object[]
                {
                    "_score",
                    new
                    {
                        updated = "desc"
                    },
                    "_id"
                }
            };
            var requestString = JsonConvert.SerializeObject(requestObject);
            return requestString;
        }

        private WebRequest RequestPost(string uri, string queriString, string jsonString)
        {
            return null;
        }

        private string Sign(string hashedRequestPayload, string requestMethod, string canonicalUri,
            string canonicalQueryString)
        {
            var currentDateTime = DateTime.UtcNow;
            var accessKey = ConfigSettings.AccessKey;
            var secretKey = ConfigSettings.SecretKey;
            var dateStamp = currentDateTime.ToString("yyyyMMdd");
            var requestDate = currentDateTime.ToString("yyyyMMddTHHmmss") + "Z";
            return null;
        }

        private static byte[] ToBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str.ToCharArray());
        }
        private static string HexEncode(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", string.Empty).ToLowerInvariant();
        }
        private static byte[] Hash(byte[] bytes)
        {
            return SHA256.Create().ComputeHash(bytes);
        }
        private static byte[] HmacSha256(string data, byte[] key)
        {
            return new HMACSHA256(key).ComputeHash(ToBytes(data));
        }

    }
}