using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace _Anmol.WebApp.Common
{
    public class WebApiAuthHelper
    {
        private string app_id = "3BFD63BF-5DC7-4DAE-91D0-9D5D4E921D24";
        private string api_key = "CBUMnb/5J0C8TFP3XRNuC3qpb8ZsxnTqHn1s4JK86xM=";

        public AuthenticationHeaderValue GenerateToken(string requestUri, string requestHttpMethod)
        {
            string requestSignatureBase64String = string.Empty;

            requestUri = HttpUtility.UrlEncode(requestUri.ToLower());

            //Calculate UNIX time
            DateTime epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSpan = DateTime.UtcNow - epochStart;
            string requestTimeStamp = Convert.ToUInt64(timeSpan.TotalSeconds).ToString();

            //create random nonce for each request
            string nonce = Guid.NewGuid().ToString("N");

            string signatureRawData = "0";// String.Format("{0}{1}{2}{3}{4}", app_id, requestHttpMethod, requestUri, requestTimeStamp, nonce);

            var secretKeyByteArray = Convert.FromBase64String(api_key);

            byte[] signature = Encoding.UTF8.GetBytes(signatureRawData);

            using (HMACSHA256 hmac = new HMACSHA256(secretKeyByteArray))
            {
                byte[] signatureBytes = hmac.ComputeHash(signature);
                requestSignatureBase64String = Convert.ToBase64String(signatureBytes).TrimEnd('=');
            }
            //var token = new AuthenticationHeaderValue("token", string.Format("{0}:{1}:{2}:{3}", app_id, requestSignatureBase64String, nonce, requestTimeStamp));
            var token = new AuthenticationHeaderValue("token", "0");

            return token;
        }
    }
}