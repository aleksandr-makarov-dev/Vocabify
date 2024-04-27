using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;
using System;

namespace Vocabify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetsController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public SetsController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet("scrap")]
        public async Task<FileContentResult> Get([FromQuery] string q)
        {
            using var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync(q);

            
            var stream = await page.PdfDataAsync();

            await browser.CloseAsync();

            return File(stream, "application/pdf","page.pdf");

;        }
    }
}
