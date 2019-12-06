using System.Net.Http;
using System.Threading.Tasks;
using InterviewProject.Domain.Exceptions;
using InterviewProject.Domain.Interfaces;
using Newtonsoft.Json;

namespace InterviewProject
{
    public class Http : IHttp
    {
        private HttpClient underlyingClient;

        public Http(HttpClient underlyingClient)
        {
            this.underlyingClient = underlyingClient;
        }

        public async Task<T> Get<T>(string url)
        {
            var response = await underlyingClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new NetworkException(response.ReasonPhrase);

            string value = await response.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}