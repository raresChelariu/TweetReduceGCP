namespace TweetGcpApi.DTOs;

public class GcpNaturalLanguageRequest
{
    public string EncodingType { get; set; }
    public GcpNaturalLanguageDocument Document { get; set; }
}