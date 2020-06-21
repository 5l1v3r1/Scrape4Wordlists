using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Scrape4Wordlists.DB;

namespace Scrape4Wordlists.Pages
{
    public class IndexModel : PageModel
    {
        private ScraperContext _context;

        public int ScrapedUriCount { get; private set; } = 0;

        public IndexModel(ScraperContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            //try
            //{
            //    ScrapedUriCount = _context.ScrapeUri.Count();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}

        }
    }
}