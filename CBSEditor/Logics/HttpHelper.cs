using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace CBSEditor.Logics
{
    public class HttpHelper
    {
        private readonly HttpClient _httpClient;
        public HttpHelper(HttpClient httpclient)
        {
            this._httpClient = httpclient;
        }
        public bool POSTData(object data, string url)
        {
            using (var content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage result = _httpClient.PostAsync(url, content).Result;
                if (result.IsSuccessStatusCode)
                    return true;
                string returnValue = result.Content.ReadAsStringAsync().Result;
                throw new Exception($"Failed to POST data: ({result.StatusCode}): {returnValue}");
            }
        }
    }
}

