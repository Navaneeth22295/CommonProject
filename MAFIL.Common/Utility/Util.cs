using System;
using System.Text.RegularExpressions;

namespace MAFIL.Common.Utility
{
    public static class Util
    {
        public static string ToCamelCase(this string theString)
        {
            if (string.IsNullOrWhiteSpace(theString)) return theString;

            if (theString.Length < 2) return theString.ToLower();

            string[] words = theString.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            string result = "";
            foreach (string word in words)
            {
                result += word.Substring(0, 1).ToLower() + word.Substring(1);
            }
            return result;
        }

        public static string RemoveEmptyLines(this string theString)
        {
            return Regex.Replace(theString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
        }
    }
}
