using Riok.Mapperly.Abstractions;
using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Sets.Models;
using Vocabify.API.Modules.Terms.Models;

namespace Vocabify.API.Modules.Terms;

[Mapper]
public partial class TermMapper
{
    public partial Term CreateTermToTerm(CreateTermModel model);
    public partial void UpdateTermToTerm(UpdateTermModel model, Term term);

    public Term StudiableItemToTerm(StudiableItem model)
    {
        Media word = model.CardSides[0].Media[0];
        Media def = model.CardSides[1].Media[0];

        string? imageUrl = null;

        if (model.CardSides[1].Media.Count > 1)
        {
            imageUrl = model.CardSides[1].Media[1].Url;
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