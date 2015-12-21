using System.Text.RegularExpressions;

namespace AdventOfCode.Day08
{
    public class Unescapeator
    {
        private static Regex xEscape = new Regex(@"\\x[0-9a-f]{2,2}", RegexOptions.Compiled);

        //private EscapedString escapedString;
        private string escapedString;
        public Unescapeator(string str)
        {
            escapedString = str;
        }

        public string Unescape()
        {
            var unesc = escapedString.Substring(1, escapedString.Length - 2);


            unesc = unesc.Replace("\\\"", "\"");
            unesc = unesc.Replace("\\\\", "\\");
            unesc = xEscape.Replace(unesc, ".");

            return unesc;
        }

        public string Reescape()
        {
            var unesc = escapedString;
            unesc = unesc.Replace("\\", "..");
            unesc = unesc.Replace("\"", "..");
            unesc = xEscape.Replace(unesc, "12345");
            unesc = unesc + "..";

            return unesc;
        }
    }
}