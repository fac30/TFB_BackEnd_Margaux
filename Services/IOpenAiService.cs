namespace TFB_BackEnd_Margaux.Services
{
    public interface IOpenAiService
    {
        // Define methods that the OpenAiService should implement
        Task<string> GetResponseAsync(string prompt);
    }
}
