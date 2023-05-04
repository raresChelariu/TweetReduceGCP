using Microsoft.AspNetCore.Mvc;
using TweetGcpApi.DTOs;

namespace TweetGcpApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GcpController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public GcpController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }

    [HttpGet("/sentiment")]
    public async Task<IActionResult> GetSentiment([FromQuery] string path)
    {
        const string urlPath = "/v1/documents:analyzeSentiment";
        var response = await SendCallToGcpNaturalLanguage(path, urlPath);
        return Ok(response);
    }
    
    [HttpGet("/entity")]
    public async Task<IActionResult> GetEntity([FromQuery] string path)
    {
        const string urlPath = "/v1/documents:analyzeEntities";
        var response = await SendCallToGcpNaturalLanguage(path, urlPath);
        return Ok(response);
    }

    [HttpGet("/entitysentiment")]
    public async Task<IActionResult> GetEntitySentiment([FromQuery] string path)
    {
        const string urlPath = "/v1/documents:analyzeEntitySentiment";
        var response = await SendCallToGcpNaturalLanguage(path, urlPath);
        return Ok(response);
    }

    private async Task<string> SendCallToGcpNaturalLanguage(string contentDiskPath, string url)
    {
        var input = await System.IO.File.ReadAllTextAsync(contentDiskPath);
        var request = GetGcpRequestWithContent(input);

        var httpClient = _httpClientFactory.CreateClient("Gcp");
        var httpResponseMessage = await httpClient.PostAsJsonAsync(url, request, CancellationToken.None);
        var response = await httpResponseMessage.Content.ReadAsStringAsync();
        return response;
    }

    private static GcpNaturalLanguageRequest GetGcpRequestWithContent(string input)
    {
        return new GcpNaturalLanguageRequest
        {
            EncodingType = "UTF8",
            Document = new GcpNaturalLanguageDocument
            {
                Type = "PLAIN_TEXT",
                Content = input 
            }
        };
    }
}