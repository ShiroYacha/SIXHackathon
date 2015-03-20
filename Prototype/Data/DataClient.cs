using RestSharp.Portable;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Data
{
    public abstract class DataClient
    {
        private RestClient client = new RestClient(DataTokens.API_ENDPOINT);
        protected void GetResponseAndHeaders(Tuple<string, HttpHeaders> tuple, out JObject results, out HttpHeaders headers)
        {
            if (tuple.Item1 != "[]" && tuple.Item1 != "")
            {
                var content = tuple.Item1.TrimStart('[').TrimEnd(']');
                results = JObject.Parse(content);
            }
            else
                results = null;
            headers = tuple.Item2;
        }

        protected async Task<Tuple<string, HttpHeaders>> SendAsync(HttpMethod type, string url, object jsonBody, params string[] inHeaders)
        {
            var request = new RestRequest(url, type);
            // content
            if (jsonBody != null)
                request.AddJsonBody(jsonBody);
            // header
            if (inHeaders != null)
                for (int i = 0; i < inHeaders.Length; i += 2)
                    request.AddHeader(inHeaders[i], inHeaders[i + 1]);
            // sent
            IRestResponse restResponse = await client.Execute(request);
            // get response
            UTF8Encoding enc = new UTF8Encoding();
            var bytes = restResponse.RawBytes;
            string response = enc.GetString(bytes, 0, bytes.Count());
            HttpHeaders outHeaders = restResponse.Headers;
            return new Tuple<string, HttpHeaders>(response, outHeaders);
        }

    }
}
