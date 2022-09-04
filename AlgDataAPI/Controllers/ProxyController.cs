using Microsoft.AspNetCore.Mvc;
using DataModels;
using System.Text;
using Newtonsoft.Json;

namespace AlgDataAPI.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ProxyController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost("{algorithmName}")]
        public async Task<ActionResult<DataSetResponse>> Algorithms([FromBody] DataSet listInt, [FromRoute] string algorithmName)
        {
            var jsonString = JsonConvert.SerializeObject(listInt);
            return await ProxyTo($"http://algorithms.api/Algorithms/{algorithmName}", jsonString);
        }

        [HttpGet("{dataStructureName}")]
        public async Task<IActionResult> DataStructures([FromRoute] string dataStructureName)
            => await ProxyTo($"http://datastructure.api/DataStructures/{dataStructureName}");



        private async Task<ContentResult> ProxyTo(string url)
            => Content(await _httpClient.GetStringAsync(url));

        private async Task<ContentResult> ProxyTo(string url, string values)
        {
            var content = new StringContent(values, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            var contents = response.Content.ReadAsStringAsync().Result;

            return Content(contents);
        }
            
    }
}
