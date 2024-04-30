using PuppeteerSharp;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.RegularExpressions;
using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Sets.Models;
using Vocabify.API.Modules.Terms;

namespace Vocabify.API.Modules.Sets.Services;

public class ImportService:IImportService
{
    private readonly SetMapper _setMapper;
    private readonly TermMapper _termMapper;

    public ImportService()
    {
        _termMapper = new TermMapper();
        _setMapper = new SetMapper();
    }

    public async Task<SetWithTermsDto?> FromQuizletAsync(string url)
    {
        await new BrowserFetcher().DownloadAsync();

        var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true,
            Args = ["--no-sandbox", "--disable-setuid-sandbox"]
        });

        var page = await browser.NewPageAsync();
        await page.SetExtraHttpHeadersAsync(new Dictionary<string, string>
        {
            { "Cache-Control", "max-age=0" }
        });

        await page.SetUserAgentAsync(
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 13_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36");

        await page.GoToAsync(url);

        await page.WaitForSelectorAsync("script[id=__NEXT_DATA__]");

        string content = await page.GetContentAsync();

        await browser.CloseAsync();

        string pattern = @"<script id=""__NEXT_DATA__"" type=""application/json"">(.*?)<\/script>";

        Match match = Regex.Match(content, pattern);

        if (match.Success)
        {
            Console.WriteLine("Pattern found...");

            string jsonData = match.Groups[1].Value;

            Console.WriteLine("Parsing data...");

            QuizletResponse? response = JsonSerializer.Deserialize<QuizletResponse>(jsonData, new JsonSerializerOptions
            {
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
            });

            if (response?.Props.PageProps.DehydratedReduxStateKey == null) return null;

            DehydratedReduxStateKey? dehydratedReduxStateKey = JsonSerializer.Deserialize<DehydratedReduxStateKey>(
                response.Props.PageProps.DehydratedReduxStateKey, new JsonSerializerOptions
                {
                    UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
                });

            if (dehydratedReduxStateKey == null)
            {
                throw new Exception("Failed to import from quizlet");
            }

            Console.WriteLine("Returning result...");

            Set set = _setMapper.QuizletSetToSet(dehydratedReduxStateKey.SetPage.Set);
            IEnumerable<Term> terms = dehydratedReduxStateKey.StudyModesCommon
                .StudiableData
                .StudiableItems
                .Select(si =>
                    _termMapper.StudiableItemToTerm(si)
                    );

            return new SetWithTermsDto
            {
                Set = set,
                Terms = terms
            };
        }

        return null;
    }
}