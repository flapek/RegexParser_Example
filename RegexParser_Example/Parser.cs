using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace RegexParser_Example
{
    public class Parser
    {
        public Parser()
        {
        }

        public Entity Analize(string line)
            => ParseJson(line) ?? ParseJs(line) ?? ParseXML(line) ?? null;

        private Entity ParseJson(string line)
        {
            Entity result = null;
            line = line.TrimLine(new char[] { '\t', '\n', ' ' }).RemoveComment().TrimLine(new char[] { '{', '}' });

            var pattern = "\"(?<name>[A-z]+)\"\\s?:\\s?\"?(?<value>([A-z]+)|(\\d{4}-\\d{2}-\\d{2})|(\\d+(.\\d+)?))\"?,?\\s?";
            if (Regex.IsMatch(line, pattern))
            {
                result = new Entity();
                var matches = Regex.Matches(line, pattern, RegexOptions.IgnoreCase);

                foreach (Match match in matches)
                {
                    if (match.Groups[5].Value.ToLowerInvariant() == nameof(Entity.FirstName).ToLowerInvariant())
                        result.FirstName = match.Groups[6].Value;
                    if (match.Groups[5].Value.ToLowerInvariant() == nameof(Entity.LastName).ToLowerInvariant())
                        result.LastName = match.Groups[6].Value;
                    if (match.Groups[5].Value.ToLowerInvariant() == nameof(Entity.Date).ToLowerInvariant())
                        result.Date = DateTime.Parse(match.Groups[6].Value);
                    if (match.Groups[5].Value.ToLowerInvariant() == nameof(Entity.Number).ToLowerInvariant())
                        result.Number = double.Parse(match.Groups[6].Value);
                }
            }

            return result;
        }

        private Entity ParseJs(string line)
        {
            Entity result = null;
            line = line.TrimLine(new char[] { '\t', '\n', ' ' }).RemoveComment().TrimLine(new char[] { '{', '}' });

            var pattern = "(?<name>[A-z]+)\\s?:\\s?\"?(?<value>([A-z]+)|(\\d{4}-\\d{2}-\\d{2})|(\\d+(.\\d+)?))\"?,?\\s?";
            if (Regex.IsMatch(line, pattern))
            {
                result = new Entity();
                var matches = Regex.Matches(line, pattern, RegexOptions.IgnoreCase);

                foreach (Match match in matches)
                {
                    if (match.Groups[5].Value.ToLowerInvariant() == nameof(Entity.FirstName).ToLowerInvariant())
                        result.FirstName = match.Groups[6].Value;
                    if (match.Groups[5].Value.ToLowerInvariant() == nameof(Entity.LastName).ToLowerInvariant())
                        result.LastName = match.Groups[6].Value;
                    if (match.Groups[5].Value.ToLowerInvariant() == nameof(Entity.Date).ToLowerInvariant())
                        result.Date = DateTime.Parse(match.Groups[6].Value);
                    if (match.Groups[5].Value.ToLowerInvariant() == nameof(Entity.Number).ToLowerInvariant())
                        result.Number = double.Parse(match.Groups[6].Value);
                }
            }

            return result;
        }

        private Entity ParseXML(string line)
        {
            Entity result = null;
            line = line.TrimLine(new char[] { '\t', '\n', ' ' }).RemoveComment();

            bool valid = line.ValidXml("user");

            if (!valid)
                return result;

            var pattern = "<(?<tag>[A-z]+)>(?<value>([A-z]+)|(\\d{4}-\\d{2}-\\d{2})|(\\d+(.\\d+)?))<\\/([A-z]+)>";
            if (Regex.IsMatch(line, pattern))
            {
                result = new Entity();
                var matches = Regex.Matches(line, pattern, RegexOptions.IgnoreCase);

                foreach (Match match in matches)
                {
                    if (match.Groups[6].Value.ToLowerInvariant() == nameof(Entity.FirstName).ToLowerInvariant())
                        result.FirstName = match.Groups[7].Value;
                    if (match.Groups[6].Value.ToLowerInvariant() == nameof(Entity.LastName).ToLowerInvariant())
                        result.LastName = match.Groups[7].Value;
                    if (match.Groups[6].Value.ToLowerInvariant() == nameof(Entity.Date).ToLowerInvariant())
                        result.Date = DateTime.Parse(match.Groups[7].Value);
                    if (match.Groups[6].Value.ToLowerInvariant() == nameof(Entity.Number).ToLowerInvariant())
                        result.Number = double.Parse(match.Groups[7].Value);
                }
            }

            return result;
        }

    }
}