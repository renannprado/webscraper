using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebSraper_Command_Line
{
    public static class GlobalOption
    {
        public static bool Verbose { get; set; }
        public static List<String> InputURLs { get; set; }
        public static String[] InputWords { get; set; }

        public static readonly char WORD_SEPARATOR = ',';
        public static readonly String HTTP_REGEX = @"^(http://)";
        public static readonly String INPUT_FILE_REGEX = @"\.txt$";
    }
}
