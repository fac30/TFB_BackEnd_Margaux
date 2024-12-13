using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TFB_BackEnd_Margaux.Services;

namespace TFB_BackEnd_Margaux.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IOpenAiService _openAiService;

        public ChatController(IOpenAiService openAiService)
        {
            _openAiService = openAiService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChatRequest request)
        {
            try
            {
                Console.WriteLine($"Received chat request with message: {request.Message}");

                if (string.IsNullOrEmpty(request.Message))
                {
                    return BadRequest(new { success = false, error = "Message cannot be empty" });
                }

                var response = await _openAiService.GetResponseAsync(request.Message);
                return Ok(new { success = true, response = response });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ChatController: {ex.Message}");
                return StatusCode(
                    500,
                    new { success = false, error = "Failed to get a response from OpenAI" }
                );
            }
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; } = string.Empty;
    }
}
