﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Scrape4Wordlists.DB;

namespace Scrape4Wordlists.Pages
{
    public class ErrorModel : PageModel
    {

        

        private ScraperContext _context;
        public ErrorModel(ScraperContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }
    }
}