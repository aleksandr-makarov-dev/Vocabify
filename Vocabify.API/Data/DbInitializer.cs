using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Accounts.Models;
using Vocabify.API.Modules.Sets.Models;
using Vocabify.API.Modules.Sets.Services;
using Vocabify.API.Modules.Terms.Models;
using Vocabify.API.Modules.Terms.Services;

namespace Vocabify.API.Data
{
    public static class DbInitializer
    {
        public static async Task Seed(IServiceScope scope)
        {
            List<CreateSetModel> setsToCreate = new List<CreateSetModel>
            {
                new()
                {
                    Title = "Greetings from Finland",
                    Description =
                        "Learn essential greetings and phrases from Finland with this flashcard set.",
                    TextLang = "fi",
                    DefinitionLang = "ru",
                },
                new()
                {
                    Title = "Basic Finnish Phrases",
                    Description =
                        "Learn essential Finnish phrases and greetings with this comprehensive flashcard deck.",
                    TextLang = "fi",
                    DefinitionLang = "ru",
                },
                new()
                {
                    Title = "Finnish Language Essentials",
                    Description =
                        "Enhance your Finnish language skills with this collection of essential greetings and expressions.",
                    TextLang = "fi",
                    DefinitionLang = "ru",
                },
                new()
                {
                    Title = "Finnish Greetings Flashcards",
                    Description = "Practice Finnish greetings and phrases effectively with this helpful flashcard set.",
                    TextLang = "fi",
                    DefinitionLang = "ru",
                },
                new()
                {
                    Title = "Essential Finnish Expressions",
                    Description =
                        "Master essential Finnish expressions and greetings with this comprehensive flashcard set.",
                    TextLang = "fi",
                    DefinitionLang = "ru",
                },
                new()
                {
                    Title = "Mastering Finnish Greetings",
                    Description =
                        "Study and memorize Finnish greetings and phrases thoroughly with this engaging flashcard set.",
                    TextLang = "fi",
                    DefinitionLang = "ru",
                },
                new()
                {
                    Title = "Finnish Language Practice",
                    Description =
                        "Improve your Finnish language proficiency with this set of greetings and expressions flashcards.",
                    TextLang = "fi",
                    DefinitionLang = "ru",
                }
            };

            ISetsService setsService = scope.ServiceProvider.GetRequiredService<ISetsService>();
            ITermsService termsService = scope.ServiceProvider.GetRequiredService<ITermsService>();

            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await context.Database.EnsureCreatedAsync();

            // create roles
            RoleManager<IdentityRole> roleManager =
                scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (await roleManager.RoleExistsAsync(Roles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }

            if (!await roleManager.RoleExistsAsync(Roles.User))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.User));
            }

            // create sets
            if (!await context.Sets.AnyAsync())
            {
                foreach (var set in setsToCreate)
                {
                    await setsService.CreateAsync(set);
                }
            }

            Set foundSet = await context.Sets.FirstOrDefaultAsync();

            List<CreateTermModel> terms = new List<CreateTermModel>
            {
                new CreateTermModel
                {
                    Text = "Terveiset",
                    Definition = "Привет из",
                    Image = "https://o.quizlet.com/GATl4BT4xKOqqZwxmCdwqA_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=VGVydmVpc2V0&s=uzsRudoR",
                    DefinitionTtsUrl = "/tts/ru.mp3?v=8&b=0J.RgNC40LLQtdGCINC40Lc&s=qWnguiUW",
                    SetId = foundSet.Id
                },
                new CreateTermModel
                {
                    Text = "Turkki",
                    Definition = "Турция",
                    Image = "https://o.quizlet.com/-Z0dMncdMemw6qnQFIeHKQ_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=VHVya2tp&s=tuwsLneY",
                    DefinitionTtsUrl = "/tts/ru.mp3?v=8&b=0KLRg9GA0YbQuNGP&s=JyscAJig",
                    SetId = foundSet.Id
                },
                new CreateTermModel
                {
                    Text = "ottaa aurinkoa",
                    Definition = "загорать",
                    Image = "https://o.quizlet.com/aWeQfXpuzDOwKD1-CppzQA_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=b3R0YWEgYXVyaW5rb2E&s=sSKWGmtO",
                    DefinitionTtsUrl = "/tts/ru.mp3?v=8&b=0LfQsNCz0L7RgNCw0YLRjA&s=mf1kUO-Q",
                    SetId = foundSet.Id
                },
                new CreateTermModel
                {
                    Text = "ihana",
                    Definition = "замечательный",
                    Image = "https://o.quizlet.com/i/ph70D1bQoyUtpI7KNoSYuw_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=aWhhbmE&s=qLvu7bJl",
                    DefinitionTtsUrl = "/tts/ru.mp3?v=8&b=0LfQsNC80LXRh9Cw0YLQtdC70YzQvdGL0Lk&s=rC5TQ4hD",
                    SetId = foundSet.Id
                },
                new CreateTermModel
                {
                    Text = "vuokra-auto",
                    Definition = "арендованный автомобиль",
                    Image = "https://o.quizlet.com/HkEZgrpUItS25w-tOLeU-g_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=dnVva3JhLWF1dG8&s=erX2ttqR",
                    DefinitionTtsUrl =
                        "/tts/ru.mp3?v=8&b=0LDRgNC10L3QtNC-0LLQsNC90L3Ri9C5INCw0LLRgtC-0LzQvtCx0LjQu9GM&s=nXN31e9E",
                    SetId = foundSet.Id
                },
                new CreateTermModel
                {
                    Text = "kuuluisa",
                    Definition = "известный",
                    Image = "https://o.quizlet.com/xOe02d.JNRXl-ItDenXLHg_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=a3V1bHVpc2E&s=egnY20Tu",
                    DefinitionTtsUrl = "/tts/ru.mp3?v=8&b=0LjQt9Cy0LXRgdGC0L3Ri9C5&s=hMsazBlC",
                    SetId = foundSet.Id
                },
                new CreateTermModel
                {
                    Text = "toinen",
                    Definition = "другой, второй",
                    Image = "https://o.quizlet.com/k5SI6kFCqJDQFZGDkbFE9w_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=dG9pbmVu&s=vJaT5RU5",
                    DefinitionTtsUrl = "/tts/ru.mp3?v=8&b=0LTRgNGD0LPQvtC5LCDQstGC0L7RgNC-0Lk&s=nqKRueyh",
                    SetId = foundSet.Id
                },
                new CreateTermModel
                {
                    Text = "vesiputous",
                    Definition = "водопад",
                    Image = "https://o.quizlet.com/0DzjBCBufZE67kkbiqQp4A_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=dmVzaXB1dG91cw&s=nHwWu4di",
                    DefinitionTtsUrl = "/tts/ru.mp3?v=8&b=0LLQvtC00L7Qv9Cw0LQ&s=WlpperGs",
                    SetId = foundSet.Id
                },
                new CreateTermModel
                {
                    Text = "retki",
                    Definition = "экскурсия",
                    Image = "https://o.quizlet.com/GtuMDKDzw9DAAuB9ozHVBg_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=cmV0a2k&s=aPTS5dHC",
                    DefinitionTtsUrl = "/tts/ru.mp3?v=8&b=0Y3QutGB0LrRg9GA0YHQuNGP&s=09kED.-T",
                    SetId = foundSet.Id
                },
                new CreateTermModel
                {
                    Text = "jäädä",
                    Definition = "оставаться",
                    Image = "https://o.quizlet.com/UxD4wFBMz-lfzSmzRZzo4g_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=asOkw6Rkw6Q&s=T8ukIpQG",
                    DefinitionTtsUrl = "/tts/ru.mp3?v=8&b=0L7RgdGC0LDQstCw0YLRjNGB0Y8&s=dcbi9m76",
                    SetId = foundSet.Id
                },
                new CreateTermModel
                {
                    Text = "löytää",
                    Definition = "находить",
                    Image = "https://o.quizlet.com/i/aJsiJ0NPCECmcpuItEc4pA_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=bMO2eXTDpMOk&s=vnpL8sMF",
                    DefinitionTtsUrl = "/tts/ru.mp3?v=8&b=0L3QsNGF0L7QtNC40YLRjA&s=KTLDJOiQ",
                    SetId = foundSet.Id
                },
                new CreateTermModel
                {
                    Text = "kahvila",
                    Definition = "кафе",
                    Image = "https://o.quizlet.com/Lc6DvagxKJlXkhACqf2rLw_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=a2FodmlsYQ&s=Eh3SgYw6",
                    DefinitionTtsUrl = "/tts/ru.mp3?v=8&b=0LrQsNGE0LU&s=ENygFpYA",
                    SetId = foundSet.Id
                },
                new CreateTermModel
                {
                    Text = "annos",
                    Definition = "порция",
                    Image = "https://o.quizlet.com/Omb1NZFo6uJWktAmF8h9iw_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=YW5ub3M&s=ejGTU.oc",
                    DefinitionTtsUrl = "/tts/ru.mp3?v=8&b=0L.QvtGA0YbQuNGP&s=RENmG1xw",
                    SetId = foundSet.Id
                },
                new CreateTermModel
                {
                    Text = "onneksi",
                    Definition = "к счастью",
                    Image = "https://o.quizlet.com/i/0NAR4qTnHpRCLyq_CMNl-w_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=b25uZWtzaQ&s=jQVpEqiY",
                    DefinitionTtsUrl = "/tts/ru.mp3?v=8&b=0Log0YHRh9Cw0YHRgtGM0Y4&s=EdUs8Ftm",
                    SetId = foundSet.Id
                },
                new CreateTermModel
                {
                    Text = "olla jäljellä",
                    Definition = "осталось",
                    Image = "https://o.quizlet.com/OtA7139PJln5q5JVTHUcNA_m.jpg",
                    TextTtsUrl = "/tts/fi2.mp3?v=1&b=b2xsYSBqw6RsamVsbMOk&s=Q19aCIEU",
                    DefinitionTtsUrl = "/tts/ru.mp3?v=8&b=0L7RgdGC0LDQu9C-0YHRjA&s=.-0ai8Bs",
                    SetId = foundSet.Id
                }
            };

            if (!await context.Terms.AnyAsync())
            {
                foreach (var term in terms)
                {
                    await termsService.CreateAsync(term);
                }
            }
        }
    }
}
