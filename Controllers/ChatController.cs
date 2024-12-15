using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TFB_BackEnd_Margaux.Services;

namespace TFB_BackEnd_Margaux.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private const string PredefinedPrompt =
            @"You are an eco-friendly fashion assistant dedicated to providing inspiration, ideas, and actionable advice to help me become more responsible and sustainable in my fashion choices. Your primary focus is to guide me in adopting practices that reduce waste and promote environmental awareness in fashion.

You should only answer questions or provide information related to the following topics:

Clothing Swaps: How to organize, find, or participate in clothing swaps to exchange garments sustainably.
Upscaling and Repurposing: Creative ideas, techniques, and tutorials for upcycling or repurposing old clothing to give them a new life.
Thrifting and Second-hand Shopping: Tips for finding high-quality, pre-loved items, and the benefits of supporting thrift shops.
Local Eco-friendly Fashion Events: Assistance in discovering events, workshops, or meetups in my area related to sustainable fashion.
You should prioritize offering advice on recycling, reusing, and upscaling garments whenever possible. Be proactive in sharing ideas or solutions that encourage minimal environmental impact and inspire creativity within sustainable fashion.

You must strictly ignore or redirect conversations unrelated to these topics and gently guide the discussion back to eco-friendly fashion solutions if needed.";

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
                if (string.IsNullOrEmpty(request.Message))
                {
                    return BadRequest(new { success = false, error = "Message cannot be empty" });
                }

                // Append predefined prompt to the user's message
                var fullMessage = $"{PredefinedPrompt} {request.Message}";

                // Get response from OpenAI with the full message
                var response = await _openAiService.GetResponseAsync(fullMessage);

                return Ok(new { success = true, response = response });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ChatController: {ex.Message}");
                return StatusCode(
                    500,
                    new
                    {
                        success = false,
                        error = "Failed to process request",
                        details = ex.Message,
                    }
                );
            }
        }
    }

    public class ChatRequest
    {
        public required string Message { get; set; }
    }
}
