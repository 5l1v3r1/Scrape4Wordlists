using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrapySharp;
using Microsoft.EntityFrameworkCore;
using HtmlAgilityPack;
using Scrape4Wordlists.DB;
using Scrape4Wordlists.Models;
using ScrapySharp.Network;
using ScrapySharp.Extensions;
using System.Net;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Scrape4Wordlists
{
    public class Scraper
    {
        //Simple Singleton with Initialization
        //private static readonly Scraper _Instance = new Scraper();

        //public static Scraper Instance
        //{
        //    get
        //    {
        //        return _Instance;
        //    }
        //}

        //static Scraper()
        //{
        //}

        private ScrapingBrowser _browser = new ScrapingBrowser();

        public Scraper()
        {
            using (var dbContext = new ScraperContext())
            {
                if (dbContext.ScrapeUri.Count() == 0)
                {
                    Console.WriteLine("Adding start point");
                    ScrapedUri scrapeUri = new ScrapedUri
                    {
                        AbsoluteUri = "http://demo.com",
                        Scheme = "http",
                        Host = "demo.com",
                        QueryParams = ""
                    };
                    dbContext.Add(scrapeUri);
                }
            }
        }

        public async void Begin()
        {
            Console.WriteLine("Scraper Started");

            while (true)
            {
                using (var dbContext = new ScraperContext())
                {
                    ScrapedUri nextTarget = await dbContext.ScrapeUri.Where(s => s.Scraped == false && s.ScrapeAttempts < 3).FirstOrDefaultAsync();

                    if (nextTarget != default)
                    {
                        WebPage webpage = await TryScrapeWebPage(nextTarget.AbsoluteUri);

                        if (webpage != null)
                        {
                            HtmlNode[] linkNodes = webpage.Html.CssSelect("a").ToArray();


                            for (int x = 0; x < linkNodes.Length; x++)
                            {
                                string link = linkNodes[x].GetAttributeValue("href");
                                if (link != null && link != "")
                                {
                                    Uri uri = LinkValidation.Validate(link, nextTarget.AbsoluteUri);

                                    if (uri != null)
                                    {
                                        ScrapedUri scrapeUri = new ScrapedUri
                                        {
                                            AbsoluteUri = uri.AbsoluteUri,
                                            Scheme = uri.Scheme,
                                            Host = uri.Host,
                                            QueryParams = uri.Query,
                                            FileType = GetFileType(uri.Segments[uri.Segments.Length - 1]),
                                            ScrapeDataTime = DateTime.UtcNow
                                        };

                                        dbContext.Add(scrapeUri);
                                        Console.WriteLine("Adding:" + scrapeUri.AbsoluteUri);
                                    }
                                }
                            }
                            nextTarget.Scraped = true;
                        }

                        nextTarget.ScrapeAttempts++;
                        await dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        Console.WriteLine("No more Uris to scrape");
                        break;
                    }
                }
            }
            Console.WriteLine("Scraper Finished");
        }

        public async Task<WebPage> TryScrapeWebPage(string url)
        {
            Console.WriteLine("Try Scrape:" + url);
            try
            {
                return await _browser.NavigateToPageAsync(new Uri(url));
            }
            catch (WebException e)
            {
                Console.WriteLine("WebExeption: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exeption: " + e);
            }
            return null;
        }

        private string GetFileType(string lastUriSegment)
        {
            string[] parts = lastUriSegment.Split(".");

            if (parts.Length > 1)
            {
                return parts[parts.Length - 1];
            }
            return string.Empty;
        }

        //TODO Remove for prod
        private void TruncateTable()
        {
            ScraperContext context = new ScraperContext();
            context.Database.ExecuteSqlInterpolated($"TRUNCATE TABLE ScrapeUri");
        }
    }
}
