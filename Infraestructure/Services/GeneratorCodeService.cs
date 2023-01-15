using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Infraestructure.DataSource;

namespace Infraestructure
{
    public class GeneratorCodeService: IServiceWhatsMessage
    {
        private const string API = "";

        public async Task<string> GetCode()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            using (HttpClient httpclient = new HttpClient())
            {
                HttpResponseMessage httpResponse = await httpclient.PostAsync(API, new StringContent(string.Empty, Encoding.UTF8, "application/json"));

                if (httpResponse.IsSuccessStatusCode)
                {
                    string response = await httpResponse.Content.ReadAsStringAsync();

                    return response;
                }
                else
                {
                    return httpResponse.ReasonPhrase;
                }
            }
        }
    }
}
