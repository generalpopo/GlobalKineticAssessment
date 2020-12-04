using GlobalKineticAssessment;
using GlobalKineticAssessment.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class CoinApiTest
    {
        private readonly HttpClient _client;

        public CoinApiTest()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Fact]
        public async Task ReturnOkStatus()
        {
            var response = await _client.GetAsync("/CoinJar");
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PostCoin()
        {
            CoinDto coinDto = new CoinDto { amount = 5 };
            var content = new StringContent(JsonSerializer.Serialize(coinDto), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync("/CoinJar",content);

            dynamic o = JObject.Parse(await response.Content.ReadAsStringAsync());

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.True(o.amount == coinDto.amount);
        }


        [Fact]
        public async Task ResetCoin()
        {
            var response = await _client.PutAsync("/CoinJar",new StringContent(""));            
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
