using System;
using System.Collections.Generic;
using Foundation.AssetManagement.Configuration;
using Foundation.AssetManagement.Interfaces;
using Foundation.AssetManagement.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
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
            var credentialScope = $"{dateStamp}/{ConfigSettings.RegionName}/{ConfigSettings.ServiceName}/aws4_request";
            var headers = new SortedDictionary<string, string>
            {
                {"content-type", ConfigSettings.ContentType},
                {"host", ConfigSettings.Host},
                {"x-amz-date", requestDate}
            };
            string canonicalHeaders =
                string.Join("\n", headers.Select(x => x.Key.ToLowerInvariant() + ":" + x.Value.Trim())) + "\n";

            // Task 1: Create a Canonical Request For Signature v. 4
            string canonicalRequest = requestMethod + "\n"
                                                    + canonicalUri + "\n"
                                                    + canonicalQueryString + "\n"
                                                    + canonicalHeaders + "\n"
                                                    + ConfigSettings.SignedHeaders + "\n"
                                                    + hashedRequestPayload;
            string hashedCanonicalRequest = HexEncode(Hash(ToBytes(canonicalRequest)));

            // Task 2: Create a String to Sign for Signature v. 4
            string stringToSign = ConfigSettings.Algorithm + "\n" + requestDate + "\n" + credentialScope + "\n" +
                                  hashedCanonicalRequest;

            // Task 3: Calculate the AWS Signature v. 4
            byte[] signingKey =
                GetSignatureKey(secretKey, dateStamp, ConfigSettings.RegionName, ConfigSettings.ServiceName);
            string signature = HexEncode(HmacSha256(stringToSign, signingKey));

            // Task 4: Prepare a signed request v.4
            // Authorization: algorithm Credential=access key ID/credential scope, SignedHeadaers=SignedHeaders, Signature=signature
            string authorization = string.Format(
                "{0} Credential={1}/{2}/{3}/{4}/aws4_request, SignedHeaders={5}, Signature={6}",
                ConfigSettings.Algorithm,
                accessKey,
                dateStamp,
                ConfigSettings.RegionName,
                ConfigSettings.ServiceName,
                ConfigSettings.SignedHeaders,
                signature);

            return authorization;
        }

        private static byte[] GetSignatureKey(string key, string dateStamp, string regionName, string serviceName)
        {
            byte[] kDate = HmacSha256(dateStamp, ToBytes("AWS4" + key));
            byte[] kRegion = HmacSha256(regionName, kDate);
            byte[] kService = HmacSha256(serviceName, kRegion);
            return HmacSha256("aws4_request", kService);
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