using System;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace WebSraper_Command_Line
{
    /// <summary>
    /// This class holds the logic of the web scraping
    /// </summary>
    class WebScraper
    {
        public String originalHTMLCode { get; private set; }
        public String URL { get; private set; }
        public bool urlNotWork { get; private set; }

        public WebScraper(String URL)
        {
            this.URL = URL;

            this.downloadHTML();
        }

        /// <summary>
        /// This method cleans the HTML by replacing the characters to ease the scraping
        /// </summary>
        /// <returns>Clean HTML code</returns>
        private String cleanHTMLCode()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            // regex to remove javascript code
            String cleanedHTMLCode = Regex.Replace(originalHTMLCode, "<script.*?</script>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            // regex to remove inline stylesheets
            cleanedHTMLCode = Regex.Replace(cleanedHTMLCode, "<style.*?</style>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            // regex to remove HTML tags
            // I'm replacing for a space here because sometimes the HTML tags replacement causes the words to be together
            cleanedHTMLCode = Regex.Replace(cleanedHTMLCode, "</?[a-z][a-z0-9]*[^<>]*>", " ");
            // regex to remove HTML comments
            cleanedHTMLCode = Regex.Replace(cleanedHTMLCode, "<!--(.|\\s)*?-->", "");
            // regex to remove doctype
            cleanedHTMLCode = Regex.Replace(cleanedHTMLCode, "<!(.|\\s)*?>", "");
            // regex to remove excessive whitespace
            cleanedHTMLCode = Regex.Replace(cleanedHTMLCode, "[\t\r\n]", "");
            // regex to clean HTML codes like &copy;
            cleanedHTMLCode = Regex.Replace(cleanedHTMLCode, "(&)([a-z]*)(;)", " ");
            // regex to clean HTML codes like &#1233;
            cleanedHTMLCode = Regex.Replace(cleanedHTMLCode, @"(&)(#)(\d*)(;)", " ");

            stopWatch.Stop();

            if (GlobalOption.Verbose)
            {
                Console.WriteLine("Time spent to clean the HTML: {0}ms", stopWatch.Elapsed.TotalMilliseconds);
            }

            return cleanedHTMLCode;
        }

        /// <summary>
        /// This method downloads the HTML from the given URL, but doesn't download if it has query strings
        /// I didn't want to focus on this feature this time
        /// </summary>
        private void downloadHTML()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            using (WebClient client = new WebClient()) // WebClient class implements IDisposable
            {
                originalHTMLCode = client.DownloadString(URL);
            }
            
            stopWatch.Stop();

            if (GlobalOption.Verbose)
            {
                Console.WriteLine("Time spent to download the HTML: {0}ms", stopWatch.Elapsed.TotalMilliseconds);
            }
        }

        /// <summary>
        /// This method searches for the words in the <code>cleanedHTMLCode</code> and count them.
        /// The word count is NOT case sensitive, which means that it'll count either "Hello" or "hello"
        /// </summary>
        /// <param name="words">The words that you want to count</param>
        /// <returns>the occurrence of each word</returns>
        public int[] countWords(String[] words)
        {
            int[] wordCount = new int[words.Length];
            String cleanedHTMLCode = this.cleanHTMLCode();

            for (int i = 0; i < words.Length; i++)
            {
                Stopwatch stopWatch = Stopwatch.StartNew();
                //put (\W) in the end of the expression to make sure that it'll match the whole word only
                //let's say that I want to match the word "search" and we have also "Searching" in the HTML
                //putting the (\W) at the end of the expression will make sure that the string will be only matched
                //if there's a non-alphanumberic character after it
                wordCount[i] = Regex.Matches(cleanedHTMLCode, words[i] + @"(\W)", RegexOptions.Singleline | RegexOptions.IgnoreCase).Count;

                stopWatch.Stop();

                if (GlobalOption.Verbose)
                {
                    Console.WriteLine("Time spent to count the word \"{0}\": {1}ms", words[i], stopWatch.Elapsed.TotalMilliseconds);
                }
            }

            return wordCount;
        }

        /// <summary>
        /// This method counts the characters of the clean HTML
        /// </summary>
        /// <returns>the count of characters</returns>
        public int countCharacters()
        {
            int characterCount = 0;
            String cleanedHTMLCode = this.cleanHTMLCode();

            Stopwatch stopWatch = Stopwatch.StartNew();

            characterCount = Regex.Matches(cleanedHTMLCode, @"\w", RegexOptions.IgnoreCase).Count;

            stopWatch.Stop();

            if (GlobalOption.Verbose)
            {
                Console.WriteLine("Time spent to count the alphanumeric characters: {0}ms", stopWatch.Elapsed.TotalMilliseconds);
            }

            return characterCount;
        }
    }
}
