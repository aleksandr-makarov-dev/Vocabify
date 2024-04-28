using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;
using System;

namespace Vocabify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetsController : ControllerBase
    {

        [HttpGet("scrapper/puppeteer")]
        public async Task<FileContentResult> GetPuppeteer([FromQuery] string q = "https://quizlet.com/ru/653463426/sm2-kpl-7-koulutus-opiskelu-flash-cards")
        {
            await new BrowserFetcher().DownloadAsync();
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                Args = ["--no-sandbox", "--disable-setuid-sandbox"]
            });

            var page = await browser.NewPageAsync();
            await page.GoToAsync(q);
            
            var stream = await page.PdfDataAsync();

            await browser.CloseAsync();

            return File(stream, "application/pdf","page.pdf");
        }
    }
}
