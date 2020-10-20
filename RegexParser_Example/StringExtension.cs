using System.Text.RegularExpressions;

namespace RegexParser_Example
{
    public static class StringExtension
    {
        public static string TrimLine(this string line, char[] trimChars)
            => line.Trim(trimChars);

        public static string RemoveComment(this string line)
        {
            if (line.Contains("//"))
                line.Remove(line.IndexOf("//"));
               
            return line;
        }

        public static bool ValidXml(this string line, string name)
        {
            if (!Regex.IsMatch(line, $"<{name}>.+<\\/{name}>"))
                return false;
            return true;
        }
    }
}
