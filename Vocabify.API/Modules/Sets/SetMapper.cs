using Riok.Mapperly.Abstractions;
using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Sets.Models;

namespace Vocabify.API.Modules.Sets;

[Mapper]
public partial class SetMapper
{
    public partial Set CreateSetDtoToSet(CreateSetDto dto);
    public partial void UpdateSetDtoToSet(UpdateSetDto dto, Set set);

    [MapProperty(nameof(QuizletSet.WordLang),nameof(Set.TextLang))]
    [MapProperty(nameof(QuizletSet.DefLang), nameof(Set.DefinitionLang))]
    [MapProperty(nameof(QuizletSet.NumTerms), nameof(Set.ItemsCount))]
    [MapProperty(nameof(QuizletSet.WebUrl), nameof(Set.Url))]
    [MapProperty(nameof(QuizletSet.ThumbnailUrl), nameof(Set.Image))]
    public partial Set QuizletSetToSet(QuizletSet dto);
}