using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
// ReSharper disable StringLiteralTypo




// await ExtractTweetsFromJsonTweets();

async Task ExtractTweetsFromJsonTweets()
{
    const string root = @"C:\Users\Rares\Downloads\rares_chelariu_tweets\rares chelariu tweets\json";

    foreach (var file in Directory.GetFiles(root))
    {
        var fileLines = await File.ReadAllLinesAsync(file);
        var sb = new StringBuilder();
        foreach (var line in fileLines)
        {
            var token = JObject.Parse(line);
            var tweet = (string)token["renderedContent"];
            var tweetInAsciiEncoding = Regex.Replace(tweet, @"[^\u001F-\u007F]", string.Empty);
            sb.Append(tweetInAsciiEncoding).Append(Environment.NewLine);
        }

        var outputPath = $"{file.Replace(".json", "")}_all_tweets.txt";
        await File.WriteAllTextAsync(outputPath, sb.ToString());
    }
}