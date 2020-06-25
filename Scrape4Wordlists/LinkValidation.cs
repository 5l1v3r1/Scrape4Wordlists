using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrape4Wordlists
{
    public class LinkValidation
    {
        private static string[] _ValidSchemes = { "http", "https:" };
        private static string[] _BlacklistedHosts = { "youtube.com", "youtu.be", "imgur.com", "facebook.com", "flickr.com" };
        private static string[] _IgnoreExtensions = { "css", "js" };

        //private static string[] _IgnoreFiles = { "jquery"}; use to only remove js libs and frameworks so JS files can be inspected for links

        public static Uri Validate(string link, string scrapeUrl)
        {
            Uri uri = GetUri(link, scrapeUrl);

            if (uri != null && IsValidUrl(uri))
            {
                return uri;
            }

            return null;
        }

        public static string BuildUrlFromParts(string searchUrl, string link)
        {
            if (searchUrl.Substring(searchUrl.Length - 1, 1) == "/" && link.Substring(0, 1) == "/")
            {
                searchUrl = searchUrl.Substring(0, searchUrl.Length - 2);
            }
            else if (searchUrl.Substring(searchUrl.Length - 1, 1) != "/" && link.Substring(0, 1) != "/")
            {
                searchUrl += "/";
            }

            return searchUrl + link;
        }

        private static Uri GetUri(string link, string scrapeUrl)
        {
            if (Uri.TryCreate(link, UriKind.Absolute, out Uri linkUri))
            {
                return linkUri;
            }

            if (Uri.TryCreate(BuildUrlFromParts(scrapeUrl, link), UriKind.Absolute, out Uri builtUri))
            {
                return builtUri;
            }

            return null;
        }

        public static bool IsValidUrl(Uri uri)
        {
            if (_ValidSchemes.Contains(uri.Scheme) && !_BlacklistedHosts.Contains(uri.Host))
            {
                if (!IsIgnoreFile(uri.Segments[uri.Segments.Count() - 1]))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsIgnoreFile(string lastSegment)
        {
            //FIXME change it to only remove js libs and frameworks so JS files can be inspected for links
            string[] parts = lastSegment.Split(".");

            if (parts.Length > 1)
            {
                if (_IgnoreExtensions.Contains(parts[parts.Length - 1]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
