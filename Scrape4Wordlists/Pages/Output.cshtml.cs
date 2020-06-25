using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Scrape4Wordlists.DB;
using Scrape4Wordlists.Models;

namespace Scrape4Wordlists.Pages
{
    public class OutputModel : PageModel
    {
        public List<ScrapedUri> List { get; private set; }

        private ScraperContext _context;
        public OutputModel(ScraperContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            using (_context)
            {
                List = _context.ScrapeUri.ToList();
            }
        }
    }
}