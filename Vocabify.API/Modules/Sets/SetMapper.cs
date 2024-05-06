using Riok.Mapperly.Abstractions;
using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Sets.Models;

namespace Vocabify.API.Modules.Sets;

[Mapper]
public partial class SetMapper
{
    public partial Set CreateSetToSet(CreateSetModel model);
    public partial void UpdateSetToSet(UpdateSetModel model, Set set);

    [MapProperty(nameof(QuizletSetModel.WordLang),nameof(Set.TextLang))]
    [MapProperty(nameof(QuizletSetModel.DefLang), nameof(Set.DefinitionLang))]
    [MapProperty(nameof(QuizletSetModel.NumTerms), nameof(Set.ItemsCount))]
    [MapProperty(nameof(QuizletSetModel.WebUrl), nameof(Set.Url))]
    [MapProperty(nameof(QuizletSetModel.ThumbnailUrl), nameof(Set.Image))]
    public partial Set QuizletSetToSet(QuizletSetModel dto);
}