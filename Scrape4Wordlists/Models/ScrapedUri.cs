﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrape4Wordlists.Models
{
    public class ScrapedUri
    {
        public int ID { get; set; }
        public string AbsoluteUri { get; set; }
        public string Scheme { get; set; }
        public string Host { get; set; }
        public string QueryParams { get; set; }
        public string FileType { get; set; }
        public bool Scraped { get; set; } = false;
        public int ScrapeAttempts { get; set; } = 0;
        public DateTime ScrapeDataTime { get; set; }
    }
}
