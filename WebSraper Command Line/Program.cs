using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace WebSraper_Command_Line
{
    class Program
    {        
        private static Dictionary<String, OptionFunction> ExecuteOnInit = null;
        private static Dictionary<String, OptionFunctionForURL> ExecuteAfterInit = null;
        private static Dictionary<String, WebScraper> WebScraperList = null;

        private delegate void OptionFunction();
        private delegate void OptionFunctionForURL(String url);

        /// <summary>
        /// This method inits the valid options for the command
        /// </summary>
        public static void init()
        {
            ExecuteOnInit = new Dictionary<String, OptionFunction>()
            {
                {"-v", setVerboseOn},
                {"-h", displayUsage}
            };

            ExecuteAfterInit = new Dictionary<String, OptionFunctionForURL>()
            {
                {"-w", executeWordCount},
                {"-c", executeCharacterCount}
                //{"-e", ?}
            };

            WebScraperList = new Dictionary<string, WebScraper>();
        }

        static void Main(string[] args)
        {
            init();
            
            //if you want to test using Visual Studio, uncomment these lines
            /*args = new string[]
            {
                "http://www.google.com.br", "-c", "-v"
            };*/

            // if passed arguments/parameters are wrong
            if (!validateAndExecuteInputArgs(args))
            {
                Console.WriteLine("Wrong options and/or arguments. Please use option -h to see usage information.");
            }

            //Console.ReadLine();
        }

        /// <summary>
        /// Method to set the verbose on
        /// </summary>
        private static void setVerboseOn()
        {
            GlobalOption.Verbose = true;
        }

        /// <summary>
        /// This method executes the command
        /// I know that it is a bit messed up and I've found some good libs to ease the implementation of command line applications,
        /// but since I was not allowed to use any 3rd party lib, I couldn't use the lib
        /// </summary>
        /// <param name="args">arguments passed by command line</param>
        /// <returns>true if it validated/executed successfully, false otherwise</returns>
        public static bool validateAndExecuteInputArgs(String[] args)
        {
            List<String> argList = args.OfType<String>().ToList();

            if (argList.Count == 0)
                return false;

            for (int i = 0; i < argList.Count; i++)
            {
                switch (argList[i])
                {
                    case "-v":
                    {
                        ExecuteOnInit[argList[i]]();
                        argList.RemoveAt(i);
                        break;
                    }
                    case "-h":
                    {
                        ExecuteOnInit[argList[i]]();
                        return true;
                    }
                }
            }

            //at this point of the execution argList[0] should be either the URL or the path to .txt file
            if (Regex.IsMatch(argList[0], GlobalOption.INPUT_FILE_REGEX, RegexOptions.IgnoreCase))
            {
                List<String> urlList = readURLsFromFile(argList[0]);

                if (urlList == null)
                {
                    Console.WriteLine("The file doesn't exist");
                    return false;
                }

                for (int i = urlList.Count - 1; i >= 0; i--)
                { 
                    if (!Regex.IsMatch(urlList[i], GlobalOption.HTTP_REGEX))
                        urlList.RemoveAt(i);
                }

                GlobalOption.InputURLs = urlList;

                argList.RemoveAt(0);
            }
            else if (Regex.IsMatch(argList[0], GlobalOption.HTTP_REGEX, RegexOptions.IgnoreCase))
            {
                GlobalOption.InputURLs = new List<String>(){ argList[0] };
                argList.RemoveAt(0);
            }
            else
            {
                return false;
            }

            if (GlobalOption.InputURLs.Count == 0)
            {
                Console.WriteLine("Input URLs are not valid.");
                return false;
            }

            //at this point of the execution, first parameter (0) should be the list of words
            if (argList.Count > 0 && !argList[0].StartsWith("-"))
            {
                GlobalOption.InputWords = argList[0].Split(GlobalOption.WORD_SEPARATOR);

                argList.RemoveAt(0);
            }
            else if (argList.Count == 0)
                return false;

            //checks if the options are supported
            for (int i = 0; i < argList.Count; i++)
            {
                if (!ExecuteAfterInit.ContainsKey(argList[i]))
                {
                    return false;
                }
            }

            //if everything is ok, execute the user request
            foreach (String url in GlobalOption.InputURLs)
            {
                Console.WriteLine("Scrapped information from URL: {0}", url);

                foreach (String opt in argList)
                {                    
                    ExecuteAfterInit[opt](url);
                }
            }

            return true;
        }

        /// <summary>
        /// This method displays the usage text
        /// </summary>
        private static void displayUsage()
        {
            Console.Write(
                "Web Scraper v1.0\n\nUsage:\n" +
                "webScrap.exe {Text file name with one URL per line | URL*} <list of comma separated words> [-c] [-w] [-e] [-v]\n\n" +
                "-c\t Count the number of characters on the web page\n" +
                "-w\t Count the occurrence number(s) of the word(s)\n" +
                "-v\t Verbose mode. It'll print the time spent to run scrap the web page\n" +
                //"-e\t It'll return the sentence(s) that has the word(s)\n" +
                "If no option is found, nothing will be done.\n" +
                @"* URLs should start with http:// and not www or http:\\." +
                "\n** There's no support for inaccessible URLs. All URLs must be valid and accessible through this machine."
                );
        }

        /// <summary>
        /// This method counts the occurrences of the words. -w option
        /// </summary>
        /// <param name="url">the URL to scrap</param>
        private static void executeWordCount(String url)
        {
            WebScraper ws = null;

            if (WebScraperList.ContainsKey(url))
            {
                ws = WebScraperList[url];
            }
            else
            {
                ws = new WebScraper(url);
                WebScraperList.Add(url, ws);
            }

            if (GlobalOption.InputWords == null || GlobalOption.InputWords.Length == 0)
            {
                Console.WriteLine("There are no input words.");
                return;
            }

            int[] wordCount = ws.countWords(GlobalOption.InputWords);

            for (int i = 0; i < GlobalOption.InputWords.Length; i++)
            {
                Console.WriteLine("Count of word \"{1}\": {0}", wordCount[i], GlobalOption.InputWords[i]);
            }
        }

        /// <summary>
        /// This method counts the characters in the HTML file. -c option
        /// </summary>
        /// <param name="url">the URL to scrap</param>
        private static void executeCharacterCount(String url)
        {
            WebScraper ws = null;

            if (WebScraperList.ContainsKey(url))
            {
                ws = WebScraperList[url];
            }
            else
            {
                ws = new WebScraper(url);
                WebScraperList.Add(url, ws);
            }

            int characterCount = ws.countCharacters();

            Console.WriteLine("Count of characters: {0}", characterCount);
        }

        private static List<String> readURLsFromFile(String fileName)
        {
            List<String> urlList = new List<String>();

            if (!File.Exists(fileName))
                return null;

            using (StreamReader file = new StreamReader(fileName))
            {               
                String url = null;
                while ((url = file.ReadLine()) != null)
                {
                    urlList.Add(url);
                }
            }

            return urlList;
        }
    }
}