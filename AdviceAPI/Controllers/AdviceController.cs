using AdviceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace AdviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceController : ControllerBase
    {
        IHttpClientFactory _httpClientFactory;

        public AdviceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAdvice()
        {
            using HttpClient client = _httpClientFactory.CreateClient();

            try
            {
                var res = await client.GetFromJsonAsync<AdviceReponse>(
                    "https://api.adviceslip.com/advice",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));

                return Ok(res?.Slip?.Advice);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
