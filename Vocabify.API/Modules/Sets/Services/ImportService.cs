using PuppeteerSharp;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.RegularExpressions;
using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Core.Exceptions;
using Vocabify.API.Modules.Sets.Models;
using Vocabify.API.Modules.Terms;

namespace Vocabify.API.Modules.Sets.Services;

public class ImportService:IImportService
{
    private readonly SetMapper _setMapper;
    private readonly TermMapper _termMapper;
    private readonly ILogger<ImportService> _logger;

    public ImportService(ILogger<ImportService> logger)
    {
        _logger = logger;
        _termMapper = new TermMapper();
        _setMapper = new SetMapper();
    }

    public async Task<SetWithTermsModel?> FromFileAsync(IFormFile file)
    {
        string content;

        using (var streamReader = new StreamReader(file.OpenReadStream()))
        {
            content = await streamReader.ReadToEndAsync();
        }
        
        string pattern = @"<script id=""__NEXT_DATA__"" type=""application/json"">(.*?)<\/script>";

        Match match = Regex.Match(content, pattern);

        if (match.Success)
        {
            _logger.LogInformation("Pattern found...");

            string jsonData = match.Groups[1].Value;

            _logger.LogInformation("Parsing data...");

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
                throw new DomainException("Failed to import from quizlet");
            }

            _logger.LogInformation("Returning result...");

            Set set = _setMapper.QuizletSetToSet(dehydratedReduxStateKey.SetPage.Set);
            IEnumerable<Term> terms = dehydratedReduxStateKey.StudyModesCommon
                .StudiableData
                .StudiableItems
                .Select(si =>
                    _termMapper.StudiableItemToTerm(si)
                    );

            return new SetWithTermsModel
            {
                Title = set.Title,
                Description = set.Description,
                TextLang = set.TextLang,
                DefinitionLang = set.DefinitionLang,
                Image = set.Image,
                Terms = terms
            };
        }

        return null;
    }
}