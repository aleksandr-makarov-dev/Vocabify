using Riok.Mapperly.Abstractions;
using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Sets.Models;
using Vocabify.API.Modules.Terms.Models;

namespace Vocabify.API.Modules.Terms;

[Mapper]
public partial class TermMapper
{
    public partial Term CreateTermDtoToTerm(CreateTermDto dto);
    public partial void UpdateTermDtoToTerm(UpdateTermDto dto, Term term);

    public Term StudiableItemToTerm(StudiableItem dto)
    {
        Media word = dto.CardSides[0].Media[0];
        Media def = dto.CardSides[1].Media[0];

        string? imageUrl = null;

        if (dto.CardSides[1].Media.Count > 1)
        {
            imageUrl = dto.CardSides[1].Media[1].Url;
        }

        return new Term
        {
            Text = word.PlainText, 
            TextTtsUrl= word.TtsUrl,
            Image = imageUrl,
            Definition = def.PlainText,
            DefinitionTtsUrl = def.TtsUrl,
        };
    }
}